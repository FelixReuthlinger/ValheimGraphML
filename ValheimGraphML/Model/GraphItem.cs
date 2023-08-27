using GraphMLReaderWriter.Attributes;

namespace ValheimGraphML.Model;

public class GraphItem
{
    [Id]
    public string InternalName { get; set; }

}