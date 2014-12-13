using System;

namespace EdgeFilesCore.Models
{
    public interface IXmlGenerator
    {
        String GenerateXml(string filePath);
        String HiosId { get; set; }
        String ExecutionZone { get; set; }
    }
}