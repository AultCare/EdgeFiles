namespace EdgeFilesCore.Models
{
    public interface IXmlGenerator
    {
        string GenerateXml(string filePath);
        string HiosId { get; set; }
        char ExecutionZone { get; set; }
    }
}