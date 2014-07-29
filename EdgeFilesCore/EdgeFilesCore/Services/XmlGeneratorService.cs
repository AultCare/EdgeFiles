using EdgeFilesCore.Models;

namespace EdgeFilesCore.Services
{
    public class XmlGeneratorService
    {
        private readonly IXmlGenerator _xmlGenerator;

        public XmlGeneratorService(IXmlGenerator xmlGenerator)
        {
            _xmlGenerator = xmlGenerator;
        }

        public string GenerateXml(string filepath)
        {
            string filename = _xmlGenerator.GenerateXml(filepath);
            return filename;
        }
    }
}