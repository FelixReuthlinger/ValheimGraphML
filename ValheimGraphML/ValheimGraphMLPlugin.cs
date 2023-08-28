using System.IO;
using System.Runtime.Remoting.Messaging;
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

            ILiteralNode requiredFor = graph.CreateLiteralNode("required for");
            ILiteralNode crafts = graph.CreateLiteralNode("crafts");
            
            ILiteralNode wood = graph.CreateLiteralNode("wood");
            ILiteralNode stone = graph.CreateLiteralNode("stone");
            ILiteralNode hammer_recipe = graph.CreateLiteralNode("recipe for a hammer");
            ILiteralNode hammer = graph.CreateLiteralNode("hammer");

            graph.Assert(new Triple(wood, requiredFor, hammer_recipe));
            graph.Assert(new Triple(stone, requiredFor, hammer_recipe));
            graph.Assert(new Triple(hammer_recipe, crafts, hammer));

            TripleStore store = new TripleStore();
            store.Add(graph);

            GraphMLWriter writer = new GraphMLWriter();
            writer.Save(store, Path.Combine(Paths.ConfigPath, "file.graphml"));

            GraphVizWriter dotWriter = new GraphVizWriter();
            dotWriter.Save(graph, Path.Combine(Paths.ConfigPath, "file.dot"));
        }
    }
}