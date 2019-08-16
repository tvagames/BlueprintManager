using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintManager
{
    public class BlueprintFile : Construction
    {
        public static BlueprintFile Load(string path)
        {
            var ret = new BlueprintFile();
            using (var sr = new System.IO.StreamReader(path))
            {
                var json = sr.ReadToEnd();
                try
                {
                    ret = Newtonsoft.Json.JsonConvert.DeserializeObject<BlueprintFile>(json);
                    var o = Newtonsoft.Json.Linq.JObject.Parse(json);
                    ret.Name = o["Blueprint"].Value<string>("Name");
                    ret.MaxCord = o["Blueprint"].Value<string>("MaxCords")
                        .Split(',')
                        .Select(v => Convert.ToSingle(v))
                        .ToArray();

                    ret.MinCord = o["Blueprint"].Value<string>("MinCords")
                        .Split(',')
                        .Select(v => Convert.ToSingle(v))
                        .ToArray();

                    ret.Path = path;
                    return ret;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }

        public string Path { get; set; }
        public int Version { get; set; }
        public Blueprint Blueprint { get; set; }
        public float[] MaxCord { get; set; }

        public float[] MinCord { get; set; }
        public List<Color> Colors {get; set;}
        public string Name { get; private set; }
        public Dictionary<string, string> BlockIdToUidMap { get; private set; }
        public Dictionary<string, string> UidToBlockIdMap { get; private set; }
        public Dictionary<string, BlockDefinition> BlockDefinitions { get; private set; }

        public BlueprintFile LoadBlocks()
        {
            this.BlockDefinitions = BlockDefinitionStore.LoadBlockDefinitions();
            using (var sr = new System.IO.StreamReader(this.Path))
            {
                var json = sr.ReadToEnd();
                try
                {
                    var ret = this;
                    ret.Blocks = new List<BlockInfo>();
                    var jobj = Newtonsoft.Json.Linq.JObject.Parse(json);

                    this.Colors = new List<Color>();
                    var colors = jobj["Blueprint"]["COL"];
                    for (int i = 0; i < colors.Count(); i++)
                    {
                        var rgba = colors.Value<string>(i)
                            .Split(',')
                            .Select(f => Convert.ToSingle(f))
                            .ToArray();
                        this.Colors.Add(Color.FromArgb((int)(rgba[3] * 255), 
                            (int)(rgba[0] * 255),
                            (int)(rgba[1] * 255),
                            (int)(rgba[2] * 255)));
                    }

                    var jo = jobj["Blueprint"];
                    var idMap = jobj["ItemDictionary"] as JObject;
                    this.BlockIdToUidMap = new Dictionary<string, string>();
                    this.UidToBlockIdMap = new Dictionary<string, string>();

                    foreach (var item in idMap)
                    {
                        var blockId = item.Key;
                        var uid = item.Value.Value<string>();
                        if (this.BlockIdToUidMap.ContainsKey(blockId)) {
                            continue;
                        }
                        if (this.UidToBlockIdMap.ContainsKey(uid))
                        {
                            continue;
                        }
                        this.BlockIdToUidMap.Add(blockId, uid);
                        this.UidToBlockIdMap.Add(uid, blockId);
                    }

                    this.LoadBlocks(jo, ret);

                    return ret;
                }
                catch (BpmException ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw ex;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw new Exception("block loading is failed.", ex);
                }
            }
        }

        private Vector3 ConvertToBlockPosition(string s)
        {
            var pos = new Vector3();
            var p = s.Split(',');

            pos.X = Convert.ToSingle(p[0]);
            pos.Y = Convert.ToSingle(p[1]);
            pos.Z = Convert.ToSingle(p[2]);
            return pos;
        }

        private void LoadBlocks(JToken o, Construction construction)
        {

            var positions = o["BLP"];
            var rotations = o["BLR"];
            var blockIds = o["BlockIds"];
            var colorIndexes = o["BCI"];
            var lps = o["LocalPosition"].Value<string>();
            construction.LocalPosition = ConvertToBlockPosition(lps);
            if (construction.Parent != null)
            {
                var pos = new Vector3();
                pos.X = construction.Parent.Position.X + construction.LocalPosition.X;
                pos.Y = construction.Parent.Position.Y + construction.LocalPosition.Y;
                pos.Z = construction.Parent.Position.Z + construction.LocalPosition.Z;
                construction.Position = pos;
            }
            else
            {
                construction.Position = construction.LocalPosition;
            }

            for (int i = 0; i < positions.Count(); i++)
            {
                var block = new BlockInfo();
                block.id = (int)blockIds[i];
                block.colorIndex = (int)colorIndexes[i];
                block.rotation = (Rotation)rotations.Value<int>(i);
                block.localPosition = ConvertToBlockPosition(positions.Value<string>(i));

                var uid = this.BlockIdToUidMap[block.id.ToString()];
                BlockDefinition blockDef = null;
                if (this.BlockDefinitions.ContainsKey(uid))
                {
                    blockDef = this.BlockDefinitions[uid];
                }
                else
                {
                    blockDef = new BlockDefinition()
                    {
                        Width = 1,
                        Height = 1,
                        Length = 1,
                        Category = "undefined",
                        Grouped = GroupedStatus.NotGrouped,
                        Uid = uid,
                    };
                    this.BlockDefinitions.Add(uid, blockDef);
                }

                if (construction.Parent != null)
                {
                    var pos = new Vector3();
                    pos.X = construction.Position.X + block.localPosition.X;
                    pos.Y = construction.Position.Y + block.localPosition.Y;
                    pos.Z = construction.Position.Z + block.localPosition.Z;
                    block.position = pos;
                    block.FillVertecies(block.position, blockDef);
                }
                else
                {
                    block.position = block.localPosition;
                    block.FillVertecies(block.position, blockDef);
                }
                //var p = positions.Value<string>(i).Split(',');

                //block.x = Convert.ToSingle(p[0]);
                //block.y = Convert.ToSingle(p[1]);
                //block.z = Convert.ToSingle(p[2]);
                construction.Blocks.Add(block);
            }


            var scs = o["SCs"];
            for (int i = 0; i < scs.Count(); i++)
            {
                var sc = scs.ElementAt(i);
                var subconst = new Construction();
                subconst.Parent = construction;
                LoadBlocks(sc, subconst);
                construction.Subconstructions.Add(subconst);
            }

        }

        internal void SaveColors(Color[] colors)
        {
            Newtonsoft.Json.Linq.JObject jobj = null;
            try
            {

                using (var sr = new System.IO.StreamReader(this.Path))
                {
                    var json = sr.ReadToEnd();
                    var ret = this;
                    jobj = Newtonsoft.Json.Linq.JObject.Parse(json);
                    var s = colors.Select(item =>
                    {
                        return string.Format("{0},{1},{2},{3}", 
                            (decimal)((decimal)item.R / 255M),
                            (decimal)((decimal)item.G / 255M),
                            (decimal)((decimal)item.B / 255M),
                            (decimal)((decimal)item.A / 255M));
                    }).ToArray();
                    jobj["Blueprint"]["COL"] = new JArray(s);
                }

                if (jobj != null)
                {
                    using (var sw = new System.IO.StreamWriter(this.Path))
                    {
                        var json = jobj.ToString();
                        sw.Write(json);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception("color palette error", ex);
            }

        }

        internal void EraseBlocks(Dictionary<string, BlockDefinition> items, BlockCondition targetCondition)
        {
            Newtonsoft.Json.Linq.JObject jobj = null;
            try
            {

                using (var sr = new System.IO.StreamReader(this.Path))
                {
                    var json = sr.ReadToEnd();
                    var ret = this;
                    jobj = Newtonsoft.Json.Linq.JObject.Parse(json);
                    this.EraseBlocks(jobj["Blueprint"], this, items, targetCondition);
                }

                if (jobj != null)
                {
                    using (var sw = new System.IO.StreamWriter(this.Path))
                    {
                        var json = jobj.ToString();
                        sw.Write(json);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception("erase error", ex);
            }

        }

        private bool EraseBlocks(JToken jobj, Construction construction, Dictionary<string, BlockDefinition> items, BlockCondition targetCondition, bool isMain = true)
        {
            try
            {

                if ((isMain && targetCondition.IsMain) ||
                    !isMain && targetCondition.IsSub)
                {

                    var oldBlockIds = jobj["BlockIds"];
                    var newBlockIds = new List<int>();
                    // BLR, BCI
                    var oldBlr = jobj["BLR"];
                    var newBlr = new List<int>();
                    var oldBci = jobj["BCI"];
                    var newBci = new List<int>();
                    // BLP, BP1, BP2
                    var oldBlp = jobj["BLP"];
                    var newBlp = new List<string>();
                    var oldBp1 = jobj["BP1"];
                    var newBp1 = new List<string>();
                    var oldBp2 = jobj["BP2"];
                    var newBp2 = new List<string>();

                    // BEI
                    var oldBei = jobj["BEI"];
                    var newBei = new List<decimal>();
                    var beiIdMap = new Dictionary<int, List<decimal>>();
                    var beiIndex = 0;
                    if (oldBei.Count() > 0)
                    {
                        while (beiIndex < oldBei.Count())
                        {
                            var beiItem = oldBei.Value<decimal>(beiIndex);
                            var beiParams = new List<decimal>();
                            var beiNum = (int)oldBei.Value<decimal>(beiIndex + 1);
                            for (int i = 0; i < beiNum; i++)
                            {
                                beiParams.Add(oldBei.Value<decimal>(beiIndex + 2 + i));
                            }
                            beiIdMap.Add((int)beiItem, beiParams);
                            beiIndex += (1 + beiNum + 1);
                        }
                    }

                    var newIndex = 0;
                    for (int i = 0; i < oldBlockIds.Count(); i++)
                    {
                        try
                        {
                            var blockInfo = construction.Blocks[i];
                            var blockId = oldBlockIds.Value<int>(i);

                            var uid = this.BlockIdToUidMap[blockId.ToString()];
                        
                            if (!IsHitBlock(items[uid], blockInfo, targetCondition))
                            {
                                newBlockIds.Add(blockId);
                                newBlr.Add(oldBlr.Value<int>(i));
                                newBci.Add(oldBci.Value<int>(i));
                                newBlp.Add(oldBlp.Value<string>(i));
                                if (oldBp1.Count() != 0)
                                {
                                    newBp1.Add(oldBp1.Value<string>(i));
                                }
                                if (oldBp2.Count() != 0)
                                {
                                    newBp2.Add(oldBp2.Value<string>(i));
                                }

                                if (beiIdMap.ContainsKey(i))
                                {
                                    var bei = beiIdMap[i];
                                    newBei.Add(newIndex);
                                    newBei.Add(bei.Count);
                                    newBei.AddRange(bei);
                                }
                                newIndex++;
                            }
                            else
                            {
                                if (beiIdMap.ContainsKey(i))
                                {
                                    beiIdMap.Remove(i);
                                }

                                if (i == 0 && items.ContainsKey(uid) && items[uid].IsSubconstruction)
                                {
                                    // remove this construction
                                    return true;
                                }
                            }

                        }
                        catch (Exception ex2)
                        {
                            throw ex2;
                        }

                    }
                    jobj["BlockIds"] = new JArray(newBlockIds.ToArray());
                    jobj["BLR"] = new JArray(newBlr.ToArray());
                    jobj["BCI"] = new JArray(newBci.ToArray());
                    jobj["BLP"] = new JArray(newBlp.ToArray());
                    if (newBp1.Count() == 0)
                    {
                        jobj["BP1"] = null;
                    }
                    else
                    {
                        jobj["BP1"] = new JArray(newBp1.ToArray());
                    }

                    if (newBp2.Count() == 0)
                    {
                        jobj["BP2"] = null;
                    }
                    else
                    {
                        jobj["BP2"] = new JArray(newBp2.ToArray());
                    }

                    if (newBei.Count() == 0)
                    {
                        jobj["BEI"] = null;
                    }
                    else
                    {
                        jobj["BEI"] = new JArray(newBei.ToArray());
                    }
                }

                if (targetCondition.IsSub)
                {
                    var subconstructs = jobj["SCs"];
                    if (subconstructs != null)
                    {
                        var removingIndexes = new List<int>();
                        for (int i = 0; i < subconstructs.Count(); i++)
                        {
                            var subconstruct = subconstructs.ElementAt(i);
                            if (this.EraseBlocks(subconstruct, construction.Subconstructions[i], items, targetCondition, false))
                            {
                                // remove construction
                                removingIndexes.Add(i);
                            }
                        }
                        for (int i = removingIndexes.Count - 1; 0 <= i; i--)
                        {
                            var subconstruct = subconstructs.ElementAt(removingIndexes[i]);
                            subconstruct.Remove();
                        }
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("erase error", ex);
            }


        }

        internal void ReplaceGroup(BlockCondition targetCondition, BlockAction action)
        {
            Newtonsoft.Json.Linq.JObject jobj = null;
            try
            {
                var map = new Dictionary<string, string>();
                if (action.Action != BlockAction.ActionType.None)
                {
                    if (targetCondition.Target == BlockCondition.TargetType.Group)
                    {
                        var fromList = targetCondition.Group;
                        var toList = action.Group;
                        for (int i = 0; i < fromList.Count; i++)
                        {
                            map.Add(fromList[i], toList[i]);
                        }
                    }
                    else if (targetCondition.Target == BlockCondition.TargetType.Block)
                    {
                        map.Add(targetCondition.Block.Uid, action.Block.Uid);
                    }
                }

                using (var sr = new System.IO.StreamReader(this.Path))
                {
                    var json = sr.ReadToEnd();
                    var ret = this;
                    jobj = Newtonsoft.Json.Linq.JObject.Parse(json);
                    this.ReplaceBlock(jobj["Blueprint"], map, targetCondition, action);
                }

                if (jobj != null)
                {
                    using (var sw = new System.IO.StreamWriter(this.Path))
                    {
                        var json = jobj.ToString();
                        sw.Write(json);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception("replace error", ex);
            }
        }

        private void ReplaceBlock(JToken jobj,
            Dictionary<string, string> replaceMap,
            BlockCondition targetCondition, BlockAction action, bool isMain = true)
        {
            try
            {

                if ((isMain && targetCondition.IsMain) ||
                    !isMain && targetCondition.IsSub)
                {
                    var newBlockIds = new List<int>();
                    var blockIds = jobj["BlockIds"];

                    var colorIds = jobj["BCI"];
                    var newColorIds = new List<int>();

                    for (int i = 0; i < blockIds.Count(); i++)
                    {
                        var blockInfo = this.Blocks[i];
                        var blockId = blockIds.Value<int>(i);
                        var uid = this.BlockIdToUidMap[blockId.ToString()];

                        var isTarget = true;
                        // position
                        if (targetCondition.IsX && !IsHitPosition(blockInfo.localPosition.X, targetCondition.XFrom, targetCondition.XTo, targetCondition.IsXInverted))
                        {
                            isTarget = false;
                        }
                        if (targetCondition.IsY && !IsHitPosition(blockInfo.localPosition.Y, targetCondition.YFrom, targetCondition.YTo, targetCondition.IsYInverted))
                        {
                            isTarget = false;
                        }
                        if (targetCondition.IsZ && !IsHitPosition(blockInfo.localPosition.Z, targetCondition.ZFrom, targetCondition.ZTo, targetCondition.IsZInverted))
                        {
                            isTarget = false;
                        }

                        // color
                        if (targetCondition.IsColor && blockInfo.colorIndex != targetCondition.ColorNumber)
                        {
                            isTarget = false;
                        }

                        if (replaceMap.Any() && !replaceMap.ContainsKey(uid))
                        {
                            isTarget = false;
                        }

                        // color
                        if (isTarget && action.IsColor)
                        {
                            newColorIds.Add(action.ColorNumber);
                        }
                        else
                        {
                            newColorIds.Add(blockInfo.colorIndex);
                        }

                        // block id
                        if (isTarget && replaceMap.ContainsKey(uid))
                        {
                            var toUid = replaceMap[uid];
                            var toBlockId = Convert.ToInt32(this.UidToBlockIdMap[toUid]);
                            newBlockIds.Add(toBlockId);
                        }
                        else
                        {
                            newBlockIds.Add(blockId);
                        }
                    }
                    jobj["BlockIds"] = new JArray(newBlockIds.ToArray());
                    jobj["BCI"] = new JArray(newColorIds.ToArray());
                }

                if (targetCondition.IsSub)
                {
                    var subconstructs = jobj["SCs"];
                    if (subconstructs != null)
                    {
                        for (int i = 0; i < subconstructs.Count(); i++)
                        {
                            var subconstruct = subconstructs.ElementAt(i);
                            this.ReplaceBlock(subconstruct, replaceMap, targetCondition, action, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("replace error", ex);
            }

        }

        private bool IsHitPosition(float value, Nullable<int> from, Nullable<int> to, bool inverted)
        {
            if (from.HasValue && to.HasValue)
            {
                if (!inverted && (from.Value > value || to.Value < value))
                {
                    return false;
                }
                if (inverted && (from.Value < value && to.Value > value))
                {
                    return false;
                }
            }
            else if (from.HasValue)
            {
                if (!inverted && from.Value > value)
                {
                    return false;
                }
                if (inverted && from.Value < value)
                {
                    return false;
                }
            }
            else if (to.HasValue)
            {
                if (!inverted && to.Value < value)
                {
                    return false;
                }
                if (inverted && to.Value > value)
                {
                    return false;
                }
            }
            return true;
        }

        private Color GetColor(BlockDefinition block, BlockInfo item, BlockCondition targetCondition)
        {
            if (targetCondition != null && this.IsHitBlock(block, item, targetCondition))
            {
                return Color.FromArgb(255, 255, 0, 0);
            }
            else
            {
                return Color.FromArgb(128, 218, 218, 218);
            }

        }

        private Bitmap bmp;
        public Bitmap GetBmp(Dictionary<string, BlockDefinition> definitions, BlockCondition targetCondition, decimal zoomRate)
        {
            var allBlocks = this.GetAllBlocks();
            var orderedList = allBlocks.Where(block => {
                return this.BlockIdToUidMap.ContainsKey(block.id.ToString()) &&
                definitions.ContainsKey(this.BlockIdToUidMap[block.id.ToString()]);

            }).OrderBy(item => item.position.Y);
            int startOffset = 10;
            int directionOffset = 20;
            float zoom = (float)zoomRate;
            float bmpWidth = ((this.MaxCord[2] - this.MinCord[2]) + (this.MaxCord[0] - this.MinCord[0]) + startOffset * 2 + directionOffset * 2) * zoom;
            float bmpHeight = ((this.MaxCord[1] - this.MinCord[1]) + (this.MaxCord[0] - this.MinCord[0]) + startOffset * 2 + directionOffset * 2) * zoom;
            float offsetX = this.MinCord[2] * -1;
            float offsetY = this.MaxCord[1] * 1;
            offsetX += startOffset;
            offsetY += startOffset;
            float topLine = offsetY;
            Color color = Color.FromArgb(32, 128, 128, 128);
            Color originColor = Color.Green;
            this.bmp = new Bitmap((int)Math.Ceiling((decimal)bmpWidth), (int)Math.Ceiling((decimal)bmpHeight));

            Graphics g = Graphics.FromImage(this.bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var hitBlocks = new List<BlockInfo>();
            PointF offset = new PointF() { X = offsetX * zoom, Y = offsetY * zoom };
            foreach (var block in orderedList)
            {
                var uid = this.BlockIdToUidMap[block.id.ToString()];
                var blockDef = definitions[uid];
                if (targetCondition != null && this.IsHitBlock(blockDef, block, targetCondition))
                {
                    hitBlocks.Add(block);
                }

                color = this.GetColor(blockDef, block, targetCondition);
                this.DrawBlock2d(g, zoom, block, offset, color, Axis.X);
            }
            foreach (var block in hitBlocks)
            {
                color = Color.Red;
                this.DrawBlock2d(g, zoom, block, offset, color, Axis.X);
            }
            //this.DrawBeam(zoom, offsetX, offsetY, g, 0, 0, 1, Direction.Top, originColor);

            offsetY += directionOffset;
            offsetY += this.MinCord[1] * -1;
            offsetY += this.MaxCord[0] * 1;

            offset = new PointF() { X = offsetX * zoom, Y = offsetY * zoom };
            foreach (var block in allBlocks.OrderBy(item => item.position.X))
            {
                var uid = this.BlockIdToUidMap[block.id.ToString()];
                var blockDef = definitions[uid];
                color = this.GetColor(blockDef, block, targetCondition);
                this.DrawBlock2d(g, zoom, block, offset, color, Axis.Y);
            }
            foreach (var block in hitBlocks)
            {
                color = Color.Red;
                this.DrawBlock2d(g, zoom, block, offset, color, Axis.Y);
            }
            //this.DrawBeam(zoom, offsetX, offsetY, g, 0, 0, 1, Direction.Top, originColor);

            offsetY = topLine;
            offsetX += directionOffset;
            offsetX += this.MinCord[0] * -1;
            offsetX += this.MaxCord[2] * 1;
            offset = new PointF() { X = offsetX * zoom, Y = offsetY * zoom };

            foreach (var block in allBlocks.OrderBy(item => item.position.Z))
            {
                var uid = this.BlockIdToUidMap[block.id.ToString()];
                var blockDef = definitions[uid];
                color = this.GetColor(blockDef, block, targetCondition);
                this.DrawBlock2d(g, zoom, block, offset, color, Axis.Z);

            }
            foreach (var block in hitBlocks)
            {
                color = Color.Red;
                this.DrawBlock2d(g, zoom, block, offset, color, Axis.Z);
            }
            //this.DrawBeam(zoom, offsetX, offsetY, g, 0, 0, 1, Direction.Top, originColor);

            return this.bmp;
        }

        public Bitmap GetBmp2(Dictionary<string, BlockDefinition> definitions, BlockCondition targetCondition)
        {
            var allBlocks = this.GetAllBlocks();
            var orderedList = allBlocks.OrderBy(item => item.position.Y);
            float zoom = 3;
            float offsetX = this.MinCord[2] * -1;
            float offsetY = this.MaxCord[1] * 1;
            offsetX += 10;
            offsetY += 10;
            Color color = Color.FromArgb(64, 128, 128, 128);
            Color originColor = Color.Green;
            this.bmp = new Bitmap(2000, 2000); ;

            Graphics g = Graphics.FromImage(this.bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            foreach (var info in orderedList)
            {
                if (!this.BlockIdToUidMap.ContainsKey(info.id.ToString()))
                {
                    continue;
                }
                var uid = this.BlockIdToUidMap[info.id.ToString()];
                if (!definitions.ContainsKey(uid))
                {
                    continue;
                }
                var blockDef = definitions[uid];
     

                color = this.GetColor(blockDef, info, targetCondition);

                Direction d = Direction.Other;
                int len = blockDef.Length;
                if (info.IsForward())
                {
                    d = Direction.Right;
                }
                else if (info.IsBack())
                {
                    d = Direction.Left;
                }
                else if (info.IsRight())
                {
                    d = Direction.Bottom;
                }
                else if (info.IsLeft())
                {
                    d = Direction.Top;
                }
                else if (info.IsUp())
                {
                    d = Direction.Right;
                    len = blockDef.Width;
                }
                else if (info.IsDown())
                {
                    d = Direction.Right;
                    len = blockDef.Width;
                }

                this.DrawBeam(zoom, offsetX, offsetY, g, info.position.Z, info.position.X, len, d, color);
            }
            this.DrawBeam(zoom, offsetX, offsetY, g, 0, 0, 1, Direction.Top, originColor);

            offsetY += 50;
            offsetY += this.MinCord[1] * -1;
            offsetY += this.MaxCord[0] * 1;

            foreach (var item in allBlocks.OrderBy(item => item.position.X))
            {
                if (!this.BlockIdToUidMap.ContainsKey(item.id.ToString()))
                {
                    continue;
                }
                var uid = this.BlockIdToUidMap[item.id.ToString()];
                if (!definitions.ContainsKey(uid))
                {
                    continue;
                }
                var block = definitions[uid];

                color = this.GetColor(block, item, targetCondition);

                Direction d = Direction.Other;
                int len = block.Length;

                if (item.IsForward())
                {
                    d = Direction.Right;
                }
                else if (item.IsBack())
                {
                    d = Direction.Left;
                }
                else if (item.IsRight())
                {
                    d = Direction.Right;
                    len = block.Width;
                }
                else if (item.IsLeft())
                {
                    d = Direction.Right;
                    len = block.Width;
                }
                else if (item.IsDown())
                {
                    d = Direction.Bottom;
                }
                else if (item.IsUp())
                {
                    d = Direction.Top;
                }

                this.DrawBeam(zoom, offsetX, offsetY, g, item.position.Z, item.position.Y * -1, len, d, color);
            }
            this.DrawBeam(zoom, offsetX, offsetY, g, 0, 0, 1, Direction.Top, originColor);


            offsetX += 50;
            offsetX += this.MinCord[0] * -1;
            offsetX += this.MaxCord[2] * 1;

            foreach (var item in allBlocks.OrderBy(item => item.position.Z))
            {
                if (!this.BlockIdToUidMap.ContainsKey(item.id.ToString()))
                {
                    continue;
                }
                var uid = this.BlockIdToUidMap[item.id.ToString()];
                if (!definitions.ContainsKey(uid))
                {
                    continue;
                }
                var block = definitions[uid];

                color = this.GetColor(block, item, targetCondition);

                Direction d = Direction.Other;
                int len = block.Length;

                if (item.IsForward())
                {
                    d = Direction.Right;
                    len = block.Width;
                }
                else if (item.IsBack())
                {
                    d = Direction.Right;
                    len = block.Width;
                }
                else if (item.IsRight())
                {
                    d = Direction.Left;
                }
                else if (item.IsLeft())
                {
                    d = Direction.Right;
                }
                else if (item.IsDown())
                {
                    d = Direction.Bottom;
                }
                else if (item.IsUp())
                {
                    d = Direction.Top;
                }

                this.DrawBeam(zoom, offsetX, offsetY, g, item.position.X, item.position.Y * -1, len, d, color);
            }
            this.DrawBeam(zoom, offsetX, offsetY, g, 0, 0, 1, Direction.Top, originColor);

            return this.bmp;
        }

        private bool IsHitBlock(BlockDefinition block, BlockInfo item, BlockCondition targetCondition)
        {
            if (targetCondition.Target == BlockCondition.TargetType.Block)
            {
                if (targetCondition.Block.Uid != this.BlockIdToUidMap[item.id.ToString()])
                {
                    return false;
                }
            }
            else if (targetCondition.Target == BlockCondition.TargetType.Group)
            {
                if (!targetCondition.Group.Contains(this.BlockIdToUidMap[item.id.ToString()]))
                {
                    return false;
                }
            }
            else if (targetCondition.Target == BlockCondition.TargetType.Blocks )
            {
                if (!targetCondition.Blocks.Any(a => a.Uid == block.Uid))
                {
                    return false;
                }
            }


            if (targetCondition.IsColor)
            {
                if (targetCondition.ColorNumber != item.colorIndex)
                {
                    return false;
                }
            }

            // position
            if (targetCondition.IsX && !IsHitPosition(item.localPosition.X, targetCondition.XFrom, targetCondition.XTo, targetCondition.IsXInverted))
            {
                return false;
            }
            if (targetCondition.IsY && !IsHitPosition(item.localPosition.Y, targetCondition.YFrom, targetCondition.YTo, targetCondition.IsYInverted))
            {
                return false;
            }
            if (targetCondition.IsZ && !IsHitPosition(item.localPosition.Z, targetCondition.ZFrom, targetCondition.ZTo, targetCondition.IsZInverted))
            {
                return false;
            }

            return true;
        }

        private void DrawSrope(float zoom, float offsetX, float offsetY, Graphics g, BlockInfo item, float x, float y, int srope, Direction direct, Direction top)
        {
            if (x == 0)
            {
                x = 1;
            }
            if (y == 0)
            {
                y = 1;
            }
            if (srope == 0)
            {
                srope = 1;
            }

            if (direct == Direction.Right)
            {
                if (top == Direction.Bottom)
                {
                    g.FillPolygon(new SolidBrush(this.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX + srope) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY + 1) * zoom),
                    });
                }
                else if (top == Direction.Top)
                {
                    g.FillPolygon(new SolidBrush(this.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX + srope) * zoom, (y + offsetY + 1) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY + 1) * zoom),
                    });
                }
            }
            else if (direct == Direction.Left)
            {
                if (top == Direction.Bottom)
                {
                    g.FillPolygon(new SolidBrush(this.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX+1) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX+1 - srope) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY + 1) * zoom),
                    });
                }
                else if (top == Direction.Top)
                {
                    g.FillPolygon(new SolidBrush(this.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX+1) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX+1 - srope) * zoom, (y + offsetY + 1) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY + 1) * zoom),
                    });
                }
            }
            else if (direct == Direction.Top)
            {
                if (top == Direction.Right)
                {
                    g.FillPolygon(new SolidBrush(this.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX) * zoom, (y + offsetY+1) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY+1-srope) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY+1) * zoom),
                    });
                }
                else if (top == Direction.Left)
                {
                    g.FillPolygon(new SolidBrush(this.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX+1) * zoom, (y + offsetY+1) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY+1-srope) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY+1) * zoom),
                    });
                }
            }
            else if (direct == Direction.Bottom)
            {
                if (top == Direction.Right)
                {
                    g.FillPolygon(new SolidBrush(this.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY-srope) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY) * zoom),
                    });
                }
                else if (top == Direction.Left)
                {
                    g.FillPolygon(new SolidBrush(this.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX+1) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY-srope) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY) * zoom),
                    });
                }
            }
        }

        private enum Direction
        {
            Top,
            Left,
            Right,
            Bottom,
            Other,
        }


        private void DrawBeam(float zoom, float offsetX, float offsetY, Graphics g, float x, float y, float beam, Direction direct, Color color)
        {
            if (x == 0)
            {
                x = 1;
            }
            if (y == 0)
            {
                y = 1;
            }
            if (beam == 0)
            {
                beam = 1;
            }


            if (direct == Direction.Right)
            {
                var r = new RectangleF((x + offsetX) * zoom, (y + offsetY) * zoom, zoom * beam, zoom);
                g.FillRectangle(new SolidBrush(color), r);
            }
            else if (direct == Direction.Left)
            {
                var r = new RectangleF((x + offsetX - beam) * zoom, (y + offsetY) * zoom, zoom * beam, zoom);
                g.FillRectangle(new SolidBrush(color), r);
            }
            else if (direct == Direction.Bottom)
            {
                var r = new RectangleF((x + offsetX) * zoom, (y + offsetY) * zoom, zoom * beam, zoom * beam);
                g.FillRectangle(new SolidBrush(color), r);
            }
            else if (direct == Direction.Top)
            {
                var r = new RectangleF((x + offsetX - beam) * zoom, (y + offsetY) * zoom, zoom * beam, zoom * beam);
                g.FillRectangle(new SolidBrush(color), r);
            }
            else
            {
                var r = new RectangleF((x + offsetX) * zoom, (y + offsetY) * zoom, zoom, zoom);
                g.FillRectangle(new SolidBrush(color), r);
            }
        }

        public void Draw3d(Graphics g, float zoom, Vector3 rotate, PointF offset, Dictionary<string, BlockDefinition> items, BlockCondition targetCondition)
        {
   
            var allBlocks = this.GetAllBlocks();
            var orderedList = allBlocks.OrderBy(item => item.position.Y);
            foreach (var item in orderedList)
            {
                if (!this.BlockIdToUidMap.ContainsKey(item.id.ToString()))
                {
                    continue;
                }
                var uid = this.BlockIdToUidMap[item.id.ToString()];
                var block = items[uid];
                var color = this.GetColor(block, item, targetCondition);
                
                this.DrawBlock3d(g, zoom, rotate, item, offset, color);

            }
        }

        public enum Axis
        {
            X,
            Y,
            Z
        }

        private void DrawBlock2d(Graphics g, float zoom, BlockInfo block, PointF offset, Color color, Axis axis)
        {
            Vector3[] v = null;
            switch (axis)
            {
                case Axis.X:
                    v = block.Vertecis.Select(s => new Vector3()
                    {
                        X = s.Z * zoom,
                        Y = s.Y * zoom * -1,
                        Z = s.X * zoom
                    }).ToArray();
                    break;
                case Axis.Y:
                    v = block.Vertecis.Select(s => new Vector3()
                    {
                        X = s.Z * zoom,
                        Y = s.X * zoom,
                        Z = s.Y * zoom
                    }).ToArray();
                    break;
                case Axis.Z:
                    v = block.Vertecis.Select(s => new Vector3()
                    {
                        X = s.X * zoom * -1,
                        Y = s.Y * zoom * -1,
                        Z = s.Z * zoom
                    }).ToArray();
                    break;
                default:
                    break;
            }

            this.DrawCube(g, v, offset, color);
        }

        private void DrawBlock3d(Graphics g, float zoom, Vector3 rotate, BlockInfo block, PointF offset, Color color)
        {
            var v = block.Vertecis.Select(s => new Vector3()
            {
                X = s.X * zoom,
                Y = s.Y * zoom,
                Z = s.Z * zoom
            }).ToArray();
            RotateZ(rotate.X, v);
            RotateY(rotate.Y, v);
            //RotateZ(rotate.Z, v);

            this.DrawCube(g, v, offset, color);
        }

        private void DrawCube(Graphics g, Vector3[] vertecis, PointF offset, Color color)
        {
            var points = vertecis.Select(v => new PointF(v.X + offset.X, v.Y + offset.Y)).ToArray();
            this.DrawCube(g, points, color);
        }


        private void DrawCube(Graphics g, PointF[] points, Color color)
        {
            using (var b = new SolidBrush(color))
            {
                g.FillPolygon(b, new PointF[] { points[0], points[1], points[2], points[3] });
                g.FillPolygon(b, new PointF[] { points[4], points[5], points[6], points[7] });
                g.FillPolygon(b, new PointF[] { points[4], points[5], points[1], points[0] });
                g.FillPolygon(b, new PointF[] { points[7], points[6], points[2], points[3] });
                g.FillPolygon(b, new PointF[] { points[1], points[2], points[6], points[5] });
                g.FillPolygon(b, new PointF[] { points[4], points[7], points[3], points[0] });
            }

            //var lineColor = Color.FromArgb(64, 64, 64, 64);
            //using (var p = new Pen(lineColor))
            //{
            //    g.DrawPolygon(p, new PointF[] { points[0], points[1], points[2], points[3] });
            //    g.DrawPolygon(p, new PointF[] { points[4], points[5], points[6], points[7] });
            //    g.DrawPolygon(p, new PointF[] { points[4], points[5], points[1], points[0] });
            //    g.DrawPolygon(p, new PointF[] { points[7], points[6], points[2], points[3] });
            //    g.DrawPolygon(p, new PointF[] { points[1], points[2], points[6], points[5] });
            //    g.DrawPolygon(p, new PointF[] { points[4], points[7], points[3], points[0] });
            //}
        }

        private void RotateZ(float deg, Vector3[] vertecis)
        {
            var angle = Math.PI * deg / 180.0;
            foreach (var item in vertecis)
            {
                var x = item.X;
                var y = item.Y;
                item.X = (float)(x * Math.Cos(angle) - y * Math.Sin(angle));
                item.Y = (float)(x * Math.Sin(angle) + y * Math.Cos(angle));
            }
        }

        private void RotateY(float deg, Vector3[] vertecis)
        {
            var angle = Math.PI * deg / 180.0;
            foreach (var item in vertecis)
            {
                var x = item.X;
                var y = item.Z;
                item.X = (float)(x * Math.Cos(angle) - y * Math.Sin(angle));
                item.Z = (float)(x * Math.Sin(angle) + y * Math.Cos(angle));
            }
        }

        private void RotateX(float deg, Vector3[] vertecis)
        {
            var angle = Math.PI * deg / 180.0;
            foreach (var item in vertecis)
            {
                var x = item.Z;
                var y = item.Y;
                item.Z = (float)(x * Math.Cos(angle) - y * Math.Sin(angle));
                item.Y = (float)(x * Math.Sin(angle) + y * Math.Cos(angle));
            }
        }


    }

    public class Blueprint
    {
        public string GameVersion { get; set; }
    }
}
