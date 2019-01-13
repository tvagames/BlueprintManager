using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlueprintManager
{
    public enum DefinitionsStatus
    {
        /// <summary>
        /// 定義ファイルにあり名前がある
        /// </summary>
        Named,
        /// <summary>
        /// 定義ファイルにあるが名前が無い
        /// </summary>
        Unknown,
        /// <summary>
        /// 定義ファイルにない
        /// </summary>
        Undefined,
    }

    public enum CategorisedStatus
    {
        Categorised,
        Uncategorised,
    }

    public enum GroupedStatus
    {
        Grouped,
        NotGrouped,
    }


    public class BlockIdItem
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public DefinitionsStatus Defined { get; set; }
        public string Category { get; set; }
        public GroupedStatus Grouped { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    class BlockIdStore
    {
        public static Dictionary<string, BlockIdItem> LoadIdList()
        {
            var ret = new Dictionary<string, BlockIdItem>();
            using (var sr = new StreamReader("BlockIdList.csv"))
            {
                var isHeader = true;
                while (sr.Peek() != -1)
                {
                    var line = sr.ReadLine();
                    if (isHeader)
                    {
                        isHeader = false;
                        continue;
                    }
                    var factor = line.Split(',');
                    if (factor.Length < 5)
                    {
                        continue;
                    }

                    var item = new BlockIdItem()
                    {
                        Uid = factor[0].Trim('"'),
                        Name = factor[1].Trim('"'),
                        Grouped = GroupedStatus.NotGrouped,
                    };

                    int temp;
                    if (int.TryParse(factor[2].Trim('"'), out temp))
                    {
                        item.Width = temp;
                    }
                    if (int.TryParse(factor[3].Trim('"'), out temp))
                    {
                        item.Height = temp;
                    }
                    if (int.TryParse(factor[4].Trim('"'), out temp))
                    {
                        item.Length = temp;
                    }

                    if (int.TryParse(item.Name, out temp))
                    {
                        // no name
                        item.Defined = DefinitionsStatus.Unknown;
                    }
                    else
                    {
                        // named
                        item.Defined = DefinitionsStatus.Named;
                    }

                    ret.Add(item.Uid, item);
                }
            }
            return ret;
        }

        public static void SaveIdList(Dictionary<string, BlockIdItem> list)
        {
            using (var sr = new StreamWriter("BlockIdList.csv"))
            {
                sr.WriteLine("\"UID\",\"name\", \"width\", \"height\", \"length\"");
                foreach (var item in list.Values)
                {
                    sr.Write("\"" + item.Uid + "\"");
                    sr.Write(",\"" + item.Name + "\"");
                    sr.Write(",\"" + item.Width + "\"");
                    sr.Write(",\"" + item.Height + "\"");
                    sr.Write(",\"" + item.Length + "\"");
                    sr.WriteLine("");
                }
            }
        }

        public static Dictionary<string, List<string>> LoadGroupMap()
        {
            var ret = new Dictionary<string, List<string>>();
            using (var sr = new StreamReader("GroupMap.csv"))
            {
                var isHeader = true;
                while (sr.Peek() != -1)
                {
                    var line = sr.ReadLine();
                    var factor = line.Split(',');
                    if (isHeader)
                    {
                        isHeader = false;
                        continue;
                    }
                    var key = factor[0].Trim('"');
                    var list = new List<string>();
                    for (int i = 1; i < factor.Length; i++)
                    {
                        list.Add(factor[i].Trim('"'));
                    }
                    ret.Add(key, list);
                }
            }
            return ret;
        }

    }
}
