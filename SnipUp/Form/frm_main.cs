using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading;
using SnipUp.Class;
using SnipUp.Properties;

namespace SnipUp
{
    public partial class frm_main : Form
    {
        Image img;
        NotifyIcon tray;
        bool usePopups, localCopy;
        
        public frm_main(Image pImage, NotifyIcon pTray)
        {
            InitializeComponent();

            img = pImage;
            picBox.Image = img;
            tray = pTray;
            usePopups = Properties.Settings.Default.Popups;
            localCopy = Properties.Settings.Default.SaveLocal;

            if (img.Width > picBox.Width)
            {
                this.Size = new Size(Size.Width + img.Width - 277, Size.Height + img.Height - 150);
            }
          
            picBox.Size = img.Size;
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Settings.Default.Path != "")
            {
                saveImage(Settings.Default.Path);
            }
            else
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.Path = dialog.SelectedPath;
                    saveImage(dialog.SelectedPath);
                }
            }
            
            this.Close();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                saveImage(dialog.SelectedPath);
            }
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string path = "";
            if (localCopy)
            {
                path = saveImage(Settings.Default.Path);
            }
            else
            {
                path = saveImage(Path.GetTempPath());
            }
           
            if (usePopups)
            {
                tray.ShowBalloonTip(1000, "uploading to epvpImg", "...", ToolTipIcon.Info);
            }
            Thread uploadThread = new Thread(uploadImage);
            uploadThread.Start(path);
        }

        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(img);
            this.Close();
        }


        private string saveImage(string path)
        {
            string tempName = DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".png";
            tempName = Path.Combine(path, tempName);
            img.Save(tempName, ImageFormat.Png);
            return tempName;
        }

        private void uploadImage(object pPath)
        {
            string path = (string)pPath;
            Http web = new Http();
            Http.UploadData upload = new Http.UploadData("files[]", path, File.ReadAllBytes(path));

            string result = web.GetUploadResponse("http://epvpimg.com/upload/", upload);
            result = result.Substring(result.IndexOf("alphaid")).Split('"')[2];
            setResult(result, path);
        }

        private void setResult(string result, string path)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, string>(setResult), result, path);
            }
            else
            {
                string tempLink = "http://i.epvpimg.com/" + result + ".png";//
                
                Clipboard.SetText(tempLink);
                
                if (usePopups)
                {
                    tray.ShowBalloonTip(100, "successfully uploaded and link copied to clipboard", tempLink, ToolTipIcon.Info);
                }

                if (!localCopy && File.Exists(path))
                {
                    File.Delete(path);
                }
                UpdateUploadLog(DateTime.Now.ToString("yyyy-MM-dd"), tempLink);
                this.Close();
            }
        } 


        private void UpdateUploadLog(string date, string link)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.GetTempPath() + "/UploadLog.xml");
            XmlNode root = doc.DocumentElement;
            XmlElement Task = doc.CreateElement("Image");
            XmlElement Date = doc.CreateElement("Date");
            Date.InnerText = date;
            XmlElement Link = doc.CreateElement("Link");
            Link.InnerText = link;
            Task.AppendChild(Date);
            Task.AppendChild(Link);
            root.AppendChild(Task);
            doc.Save(Path.GetTempPath() + "/UploadLog.xml");
        }
    }
}
