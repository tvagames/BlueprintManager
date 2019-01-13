using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintManager
{
    class CategoryTreeNode
    {
        public string Name { get; set; }
        public List<string> Items { get; set; }
        public List<CategoryTreeNode> SubCategories { get; set; }
    }
}
