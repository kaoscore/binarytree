using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libModel
{
    public class TreeNode
    {
        public int data;
        public TreeNode left, right;

        public TreeNode(int item)
        {
            data = item;
            left = right = null;
        }
    }
}
