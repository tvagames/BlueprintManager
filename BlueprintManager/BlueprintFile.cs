using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintManager
{
    public class BlueprintFile
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
        public List<BlockInfo> Blocks { get; set; }
        public float[] MaxCord { get; set; }

        public float[] MinCord { get; set; }
        public List<Color> Colors {get; set;}
        public string Name { get; private set; }

        public BlueprintFile LoadBlocks()
        {
            using (var sr = new System.IO.StreamReader(this.Path))
            {
                var json = sr.ReadToEnd();
                try
                {
                    var ret = this;
                    ret.Blocks = new List<BlockInfo>();
                    this.Colors = new List<Color>();
                    var o = Newtonsoft.Json.Linq.JObject.Parse(json);

                    var colors = o["Blueprint"]["COL"];
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

                    var positions = o["Blueprint"]["BLP"];
                    var rotations = o["Blueprint"]["BLR"];
                    var blockIds = o["Blueprint"]["BlockIds"];
                    var colorIndexes = o["Blueprint"]["BCI"];

                    for (int i = 0; i < positions.Count(); i++)
                    {
                        var block = new BlockInfo();
                        var p = positions.Value<string>(i).Split(',');

                        block.x = Convert.ToSingle(p[0]);
                        block.y = Convert.ToSingle(p[1]);
                        block.z = Convert.ToSingle(p[2]);
                        block.id = (int)blockIds[i];
                        block.colorIndex = (int)colorIndexes[i];
                        block.rotation = (Rotation)rotations.Value<int>(i);
                        ret.Blocks.Add(block);
                    }
                    return ret;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }

        /// <summary>
        /// グループ置換
        /// </summary>
        /// <param name="fromList"></param>
        /// <param name="toList"></param>
        internal void ReplaceGroup(Dictionary<string, string> replaceMap)
        {
            Newtonsoft.Json.Linq.JObject jobj = null;
            try
            {
                using (var sr = new System.IO.StreamReader(this.Path))
                {
                    var json = sr.ReadToEnd();
                    var ret = this;
                    jobj = Newtonsoft.Json.Linq.JObject.Parse(json);
                    var idMap = jobj["ItemDictionary"] as JObject;
                    var blockIdToUidMap = new Dictionary<string, string>();
                    var uidToBlockIdMap = new Dictionary<string, string>();

                    foreach (var item in idMap)
                    {
                        var blockId = item.Key;
                        var uid = item.Value.Value<string>();
                        blockIdToUidMap.Add(blockId, uid);
                        uidToBlockIdMap.Add(uid, blockId);
                    }

                    this.ReplaceBlock(jobj["Blueprint"], replaceMap, blockIdToUidMap, uidToBlockIdMap);

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
            Dictionary<string, string> blockIdToUidMap,
            Dictionary<string, string> uidToBlockIdMap)
        {
            try
            {
                var blockIds = jobj["BlockIds"];
                var newBlockIds = new List<int>();
                for (int i = 0; i < blockIds.Count(); i++)
                {
                    var blockId = blockIds.Value<int>(i);
                    var uid = blockIdToUidMap[blockId.ToString()];
                    if (replaceMap.ContainsKey(uid))
                    {
                        var toUid = replaceMap[uid];
                        var toBlockId = Convert.ToInt32(uidToBlockIdMap[toUid]);
                        newBlockIds.Add(toBlockId);
                    }
                    else
                    {
                        newBlockIds.Add(blockId);
                    }
                }
                jobj["BlockIds"] = new JArray(newBlockIds.ToArray());

                var subconstructs = jobj["SCs"];
                if (subconstructs != null)
                {
                    for (int i = 0; i < subconstructs.Count(); i++)
                    {
                        var subconstruct = subconstructs.ElementAt(i);
                        this.ReplaceBlock(subconstruct, replaceMap, blockIdToUidMap, uidToBlockIdMap);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("replace error", ex);
            }   

        }
    }

    public class Blueprint
    {
        public string GameVersion { get; set; }
    }
}
