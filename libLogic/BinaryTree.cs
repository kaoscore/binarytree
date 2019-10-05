using libModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libLogic
{
    public class BinaryTree
    {
        public TreeNode root;

        public void Insert(int data)
        {
            // 1. If the tree is empty, return a new, single node 
            if (root == null)
            {
                root = new TreeNode(data);
                return;
            }
            // 2. Otherwise, recur down the tree 
            InsertRec(root, new TreeNode(data));
        }
        private void InsertRec(TreeNode root, TreeNode newNode)
        {
            if (root == null)
                root = newNode;

            if (newNode.data < root.data)
            {
                if (root.left == null)
                    root.left = newNode;
                else
                    InsertRec(root.left, newNode);

            }
            else
            {
                if (root.right == null)
                    root.right = newNode;
                else
                    InsertRec(root.right, newNode);
            }
        }

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
