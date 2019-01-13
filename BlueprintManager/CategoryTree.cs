using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintManager
{
    class CategoryTree
    {
        internal static string CATEGORY_TREE_FILE = "CategoryTree.json";

        public static CategoryTreeNode Load(string path)
        {
            var ret = new CategoryTreeNode();
            using (var sr = new System.IO.StreamReader(path))
            {
                var json = sr.ReadToEnd();
                try
                {
                    ret = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoryTreeNode>(json);
  
                    return ret;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }

        public static void Save(string path, CategoryTreeNode tree)
        {
            using (var sr = new System.IO.StreamWriter(path))
            {
                try
                {
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(tree, Formatting.Indented);
                    sr.Write(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
