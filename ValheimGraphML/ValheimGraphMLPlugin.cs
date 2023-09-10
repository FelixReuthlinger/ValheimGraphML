using System.IO;
using System.Text;
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
            graph.NamespaceMap.AddNamespace("material", UriFactory.Create("urn:prefab:material"));
            graph.NamespaceMap.AddNamespace("recipe", UriFactory.Create("urn:crafting:recipe"));
            graph.NamespaceMap.AddNamespace("item", UriFactory.Create("urn:prefab:item"));
            graph.NamespaceMap.AddNamespace("relation", UriFactory.Create("urn:crafting:relation"));

            IUriNode requiredFor = graph.CreateUriNode("relation:required for");
            IUriNode crafts = graph.CreateUriNode("relation:crafts");

            IUriNode wood = graph.CreateUriNode("material:wood");
            IUriNode stone = graph.CreateUriNode("material:stone");
            IUriNode hammer_recipe = graph.CreateUriNode("recipe:hammer");
            IUriNode hammer = graph.CreateUriNode("item:hammer");

            graph.Assert(new Triple(wood, requiredFor, hammer_recipe));
            graph.Assert(new Triple(stone, requiredFor, hammer_recipe));
            graph.Assert(new Triple(hammer_recipe, crafts, hammer));

            TripleStore store = new TripleStore();
            store.Add(graph);

            GraphMLWriter writer = new GraphMLWriter();
            writer.Save(store, Path.Combine(Paths.ConfigPath, "file.graphml"));

            GraphVizWriter dotWriter = new GraphVizWriter();
            using var output = new StreamWriter(File.OpenWrite(Path.Combine(Paths.ConfigPath, "file.dot")), Encoding.UTF8);
            dotWriter.Save(graph, output);
        }
    }
}