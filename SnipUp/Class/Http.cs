using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Net;

namespace SnipUp.Class
{
    public class Http
    {
        public struct UploadData
        {
            public string fieldName;
            public string fileName;
            public byte[] content;

            public UploadData(string pFieldName, string pFileName, Byte[] pContent) : this()
            {
                fieldName = pFieldName;
                fileName = pFileName;
                content = pContent;
            }
        }

        public string GetContentType(string path)
        {
            string[] extensions = {"jpg", "jpeg", "png","gif","bmp"};
            string fileExt = (new FileInfo(path).Extension).Replace(".", "");

            foreach (string ext in extensions)
            {
                if (ext == fileExt)
                {
                    return "image/" + ext;
                }
            }
            
            return "application/octet-stream";
        }

        public string GetUploadResponse(string url, UploadData upload)
        {
            string boundary = Guid.NewGuid().ToString().Replace("-", "");
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url); 
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:15.0) Gecko/20100101 Firefox/15.0.1";
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Proxy = null;

            MemoryStream PostData = new MemoryStream();
            StreamWriter writer = new StreamWriter(PostData);
            writer.Write("--" + boundary + "\n");
            writer.Write("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", upload.fieldName, upload.fileName, "\n");
            writer.Write(("Content-Type: " + GetContentType(upload.fileName) + "\n") + "\n");
            writer.Flush();
            writer.Write("\n");
            writer.Write("--{0}--{1}", boundary, "\n");
            PostData.Write(upload.content, 0, upload.content.Length);
            writer.Flush();
          
            request.ContentLength = PostData.Length;
            using (Stream s = request.GetRequestStream())
            {
                PostData.WriteTo(s);
            }
            PostData.Close();

            return new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
        }
    }
}
