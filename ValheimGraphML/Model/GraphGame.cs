using GraphMLReaderWriter.Attributes;

namespace ValheimGraphML.Model;

public class GraphGame
{
    [Edges]
    public GraphRecipe[] Recipes { get; set; }
    
    [Nodes]
    public GraphItem[] Items { get; set; }
}