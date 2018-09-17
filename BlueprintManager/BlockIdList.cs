using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlueprintManager
{
    public class BlockIdItem
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public string Uid { get; set; }

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
                    if (string.IsNullOrWhiteSpace(factor[2].Trim('"')))
                    {
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(factor[3].Trim('"')))
                    {
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(factor[4].Trim('"')))
                    {
                        continue;
                    }

                    var item = new BlockIdItem()
                    {
                        Uid = factor[0].Trim('"'),
                        Name = factor[1].Trim('"'),
                        Width = Convert.ToInt32(factor[2].Trim('"')),
                        Height = Convert.ToInt32(factor[3].Trim('"')),
                        Length = Convert.ToInt32(factor[4].Trim('"')),
                    };

                    ret.Add(item.Uid, item);
                }
            }
            return ret;
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
