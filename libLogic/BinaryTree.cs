﻿using libModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libLogic
{
    class BinaryTree
    {
        public TreeNode root;

        public virtual TreeNode lca(TreeNode node, int n1, int n2)
        {
            if (node == null)
            {
                return null;
            }

            // If both n1 and n2 are smaller than root, then LCA lies in left  
            if (node.data > n1 && node.data > n2)
            {
                return lca(node.left, n1, n2);
            }

            // If both n1 and n2 are greater than root, then LCA lies in right  
            if (node.data < n1 && node.data < n2)
            {
                return lca(node.right, n1, n2);
            }

            return node;
        }
    }
}
