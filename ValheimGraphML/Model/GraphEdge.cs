using GraphMLReaderWriter.Attributes;

namespace ValheimGraphML.Model;

public class GraphRecipe
{
    [Source]
    public GraphItem From { get; set; }
    
    [Target]
    public GraphItem To { get; set; }
}