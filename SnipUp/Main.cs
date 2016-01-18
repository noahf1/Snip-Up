using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SnipUp.Class;
using System.IO;
using System.Xml.Linq;
using System.Configuration;

namespace SnipUp
{
    class Main
    {
        private Class.TrayIcon trayIcon;
        private NotifyIcon pointTrayIcon;
        private KeyboardHook Hook { get; set; }
        public Properties.Settings settings = Properties.Settings.Default;
        public static Main Instance { get; private set; }

        private Keys KeyDefined, KeyFull, KeyActive;
        private ModifierKeys ModifierDefined, ModifierFull, ModifierActive;

        public Main()
        {
            Instance = this;
            trayIcon = new Class.TrayIcon();
            pointTrayIcon = trayIcon.trayIcon;

            Hook = new KeyboardHook();
            ReAttachKeyboardHook();

            if (!File.Exists(Path.GetTempPath() + "/UploadLog.xml"))
            {
                XDocument xmlFile = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                xmlFile.Add(new XElement("UploadList"));
                xmlFile.Save(Path.GetTempPath() + "/UploadLog.xml");
            }
        }



        public void ReAttachKeyboardHook()
        {
            try
            {
                Hook.Dispose();
                Hook = new KeyboardHook();

                if (!String.IsNullOrEmpty(settings.KeyDefined))
                {
                    KeyDefined = (Keys)Enum.Parse(typeof(Keys), settings.KeyDefined);
                    ModifierDefined = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), settings.ModifierDefined);
                    Hook.RegisterHotKey(ModifierDefined, KeyDefined);
                }
               
                if (!String.IsNullOrEmpty(settings.KeyFull))
                {
                    KeyFull = (Keys)Enum.Parse(typeof(Keys), settings.KeyFull);
                    ModifierFull = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), settings.ModifierFull);
                    Hook.RegisterHotKey(ModifierFull, KeyFull);
                }

                if (!String.IsNullOrEmpty(settings.KeyActive))
                {
                    KeyActive = (Keys)Enum.Parse(typeof(Keys), settings.KeyActive);
                    ModifierActive = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), settings.ModifierActive);
                    Hook.RegisterHotKey(ModifierActive, KeyActive);
                }

                Hook.KeyPressed += HandleKeyPressed;
            }
            catch (Exception ex)
            {
                trayIcon.ShowError(ex.Message);
            }

        }
    

        private void HandleKeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Key == KeyDefined && e.Modifier == ModifierDefined)
            {
                NewScreenshot(SnippingTool.ScreenshotType.DEFINED);
            }

            if (e.Key == KeyFull && e.Modifier == ModifierFull)
            {
                NewScreenshot(SnippingTool.ScreenshotType.FULL);
            }

            if (e.Key == KeyActive && e.Modifier == ModifierActive)
            {
                NewScreenshot(SnippingTool.ScreenshotType.ACTIVE);
            }

        }

        public void NewScreenshot(SnippingTool.ScreenshotType type)
        {
            Image bmp = SnippingTool.Snip(type);

            if (bmp != null)
            {
                frm_main newFrmMain = new frm_main(bmp, pointTrayIcon);
                newFrmMain.ShowDialog();
            }
        }
    }
}
