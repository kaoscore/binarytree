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

        /// <summary>
        /// Limpia el arbol para iniciar de nuevo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public bool CleanNodes()
        {

            MemoryCache mc = MemoryCache.Default;
            if (mc.Contains("tree"))
            {
                mc.Remove("tree");
            }
            return true;

        }
        /// <summary>
        /// Agrega un nuevo nodo al arbol
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Retorna cada nodo concatenado con comas</returns>
        [HttpGet]
        [Route("{value:int}")]
        public string AddNode(int value)
        {

            MemoryCache mc = MemoryCache.Default;                      
            SetNode(value);
            return GetTree();

        }
        /// <summary>
        /// Muestra el ancestro comun mas cercano entre dos nodos
        /// </summary>
        /// <param name="value1">Primer nodo</param>
        /// <param name="value2">Segundo nodo</param>
        /// <returns>Ancestro comun mas cercano</returns>
        [HttpGet]
        [Route("{value1:int}/{value2:int}")]
        public int LowestCommonAncestor(int value1, int value2)
        {
            try
            {
                return LCA(value1, value2);
            }
            catch (Exception e)
            {
                return 0;
            }

            
        }
        /// <summary>
        /// Agrega un nuevo nodo y lo almacena en memoria cache
        /// </summary>
        /// <param name="value"></param>
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
        /// <summary>
        /// Retorna lo almacenado hasta el momento en memoria cache
        /// </summary>
        /// <returns></returns>
        private string GetTree()
        {
            MemoryCache mc = MemoryCache.Default;
            return  mc.Get("tree").ToString();
        }
        /// <summary>
        /// Evalua el arbol y por cada nodo crea un Arbol Binario y obtiene el ancestro comun
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
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
