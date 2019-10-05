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
        /// <summary>
        /// Permite agregar un nuevo nodo dentro del arbol
        /// </summary>
        /// <param name="data"></param>
        public void Insert(int data)
        {
            
            if (root == null)
            {
                root = new TreeNode(data);
                return;
            }
            
            InsertRec(root, new TreeNode(data));
        }
        /// <summary>
        /// Evalua de que lado de la rama del arbol debe ir el nuevo nodo de acuerdo a su valor
        /// </summary>
        /// <param name="root"></param>
        /// <param name="newNode"></param>
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
        /// <summary>
        /// Calcula el ancestro común mas cercano
        /// </summary>
        /// <param name="node"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public virtual TreeNode lca(TreeNode node, int n1, int n2)
        {
            if (node == null)
            {
                return null;
            }

            
            if (node.data > n1 && node.data > n2)
            {
                return lca(node.left, n1, n2);
            }

            
            if (node.data < n1 && node.data < n2)
            {
                return lca(node.right, n1, n2);
            }

            return node;
        }
    }
}
