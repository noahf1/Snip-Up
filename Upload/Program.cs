using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Threading.Tasks;
using SnipUp.Class;
using SnipUp.Properties;

namespace SnipUp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string path = args[0];
                Http web = new Http();
                Http.UploadData upload = new Http.UploadData("files[]", path, File.ReadAllBytes(path));

                Console.WriteLine("Uploading to epvpImg ...");
                string result = web.GetUploadResponse("http://epvpimg.com/upload/", upload);
                result = result.Substring(result.IndexOf("alphaid")).Split('"')[2];
                result = "http://i.epvpimg.com/" + result + Path.GetExtension(path);
                Clipboard.SetText(result);
                UpdateUploadLog(DateTime.Now.ToString("yyyy-MM-dd"),result);
                Console.WriteLine("Successfully uploaded to epvpImg!");
                Application.Exit();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void UpdateUploadLog(string date, string link)
        {
            string path = Path.GetTempPath() + "/UploadLog.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.DocumentElement;
            XmlElement Task = doc.CreateElement("Image");
            XmlElement Date = doc.CreateElement("Date");
            Date.InnerText = date;
            XmlElement Link = doc.CreateElement("Link");
            Link.InnerText = link;
            Task.AppendChild(Date);
            Task.AppendChild(Link);
            root.AppendChild(Task);
            doc.Save(path);
        }
    }
}
