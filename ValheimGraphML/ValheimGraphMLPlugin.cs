using System.IO;
using BepInEx;
using Jotunn;
using VDS.RDF;
using VDS.RDF.Writing;

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
            Example();
        }

        public static void Example()
        {
            IGraph graph = new Graph();

            ILiteralNode requiredFor = new LiteralNode("required for");
            ILiteralNode crafts = new LiteralNode("crafts");
            
            ILiteralNode wood = new LiteralNode("wood");
            ILiteralNode stone = new LiteralNode("stone");
            ILiteralNode hammer_recipe = new LiteralNode("recipe for a hammer");
            ILiteralNode hammer = new LiteralNode("hammer");

            graph.Assert(new Triple(wood, requiredFor, hammer_recipe));
            graph.Assert(new Triple(stone, requiredFor, hammer_recipe));
            graph.Assert(new Triple(hammer_recipe, crafts, hammer));
            
            foreach (Triple triple in graph.Triples) 
            {
                Jotunn.Logger.LogInfo(triple.ToString());
            }

            TripleStore store = new TripleStore();
            store.Add(graph);
            
            GraphMLWriter writer = new GraphMLWriter();
            writer.Save(store, Path.Combine(Paths.ConfigPath, "file.graphml"));
        }
    }
}