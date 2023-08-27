using System.IO;
using BepInEx;
using GraphMLWriter;
using Jotunn;
using ValheimGraphML.Model;

namespace ValheimGraphML
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Main.ModGuid)]
    internal class ValheimGraphMLPlugin : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.jotunnmodstub";
        public const string PluginName = "ValheimGraphML";
        public const string PluginVersion = "0.0.1";


        private void Awake()
        {
            var path = Path.Combine(Paths.ConfigPath, "file.graphml");
            var input = Example();
            var writer = new Writer<GraphGame>();
            writer.Save(input: input, path: path);
        }

        private static GraphGame Example()
        {
            var a = new GraphItem { InternalName = "A" };
            var b = new GraphItem { InternalName = "B" };
            var c = new GraphItem { InternalName = "C" };
            return new GraphGame
            {
                Items = new[] { a, b, c },
                Recipes = new[]
                {
                    new GraphRecipe { From = a, To = b },
                    new GraphRecipe { From = a, To = c },
                    new GraphRecipe { From = b, To = c }
                }
            };
        }
    }
}