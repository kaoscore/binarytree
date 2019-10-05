using libLogic;
using libModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;

namespace ApiTree.Controllers
{
    [RoutePrefix("tree")]
    public class CreateTreeController : ApiController
    {


       
        [HttpGet]
        [Route("{value:int}")]
        public string AddNode(int value)
        {

            MemoryCache mc = MemoryCache.Default;                      
            SetNode(value);
            return GetTree();

        }

        [HttpGet]
        [Route("{value1:int}/{value2:int}")]
        public int LowestCommonAncestor(int value1, int value2)
        {
            
            return LCA(value1, value2);
        }

        private void SetNode(int value)
        {
            MemoryCache mc = MemoryCache.Default;
            var result = mc.Get("tree");

            if (result == null)
                result = value.ToString();
            else
                result += "," + value.ToString();

            if (mc.Contains("tree"))
            {
                mc.Remove("tree");
            }

            mc.Add("tree", result.ToString(), DateTimeOffset.UtcNow.AddHours(1));
            result = mc.Get("tree");
        }

        private string GetTree()
        {
            MemoryCache mc = MemoryCache.Default;
            return  mc.Get("tree").ToString();
        }

        private int LCA(int value1, int value2)
        {
            string cacheTree;
            cacheTree = GetTree();

            string[] nodes;

            nodes = cacheTree.Split(',');
         
            BinaryTree tree = new BinaryTree();
            
            foreach (string s in nodes)
            {
               tree.Insert(System.Convert.ToInt32(s));
            }
            
            return tree.lca(tree.root, value1, value2).data;
        }

     


    }
}
