using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EdgeFilesAPI.Controllers
{
    public class FilesController : ApiController
    {
        public string[] Get()
        {
            return Directory.GetFiles(HttpContext.Current.Request.MapPath(@"~/Output"));
        }

        public FileResult Get(string id)
        {
            var allFiles = Directory.GetFiles(HttpContext.Current.Request.MapPath(@"~/Output"));
            var filename = "";
            foreach (var file in allFiles)
            {
                var newfilename = file.Replace(".", "");
                newfilename = newfilename.Substring(0, newfilename.Length - 3);

                if (newfilename.Contains(id))
                {
                    filename = file;
                    break;
                }
            }

            var outputDirectory = HttpContext.Current.Request.MapPath(@"~/Output");
            var filepath = Path.Combine(outputDirectory, filename);
            return new FilePathResult(filepath, "application/xml");
        }
    }
}