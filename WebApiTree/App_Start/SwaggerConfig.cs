using System.Web.Http;
using WebActivatorEx;
using WebApiTree;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiTree
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Binary Tree API")
                        .Description("An API for work with Binary Trees and find the Lowest Common Ancestor")                
                        .Contact(cc => cc
                          .Name("Guillermo Valenzuela")
                          .Url("https://github.com/kaoscore/binarytree")
                          .Email("guillermo.valenzuela53@yahoo.com"))
                        .License(lc => lc
                          .Name("Public for Test")
                          .Url("https://somostechies.com/license"));
                        c.IncludeXmlComments(string.Format(@"{0}\bin\WebApiTree.XML",
                          System.AppDomain.CurrentDomain.BaseDirectory));
                    })
                .EnableSwaggerUi();
        }
    }
}
