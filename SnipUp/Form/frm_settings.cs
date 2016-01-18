using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using Microsoft.Win32;
using SnipUp.Class;
using System.Net;

namespace SnipUp
{
    public partial class frm_settings : Form
    {
        private Properties.Settings settings = Properties.Settings.Default;
        private string[] extensions = {"jpegfile", "giffile", "pngfile", "Paint.Picture"};
        private string AppPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        
        public frm_settings()
        {
            InitializeComponent();

            HotkeyStrings hotkey = new HotkeyStrings();
            txtHotkeyDefined.Text = hotkey.getHotkeyStringDefined();
            txtHotkeyFull.Text = hotkey.getHotkeyStringFull();
            txtHotkeyActive.Text = hotkey.getHotkeyStringActive();

            chkBxAutoStart.Checked = settings.AutoStart;
            chkBxExplorerContextMenu.Checked = settings.ExplorerContextMenu;
            chkBxSaveLocal.Checked = settings.SaveLocal;
            chkBxPopups.Checked = settings.Popups;
            txtSavePath.Text = settings.Path;

            this.chkBxAutoStart.CheckedChanged += new System.EventHandler(this.chkBxAutoStart_CheckedChanged);
            this.chkBxExplorerContextMenu.CheckedChanged += new System.EventHandler(this.chkBxExplorerContextMenu_CheckedChanged);
            LoadUploadLog();

            if (IsUserAdministrator())
            {
                chkBxAutoStart.Enabled = true;
                chkBxExplorerContextMenu.Enabled = true;
            }
            else
            {
                MessageBox.Show("Close the application and restart it with admin rights because it needs to edit registry keys");
            }
        }



        private void frm_settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            settings.AutoStart = chkBxAutoStart.Checked;
            settings.ExplorerContextMenu = chkBxExplorerContextMenu.Checked;
            settings.SaveLocal = chkBxSaveLocal.Checked;
            settings.Popups = chkBxPopups.Checked;
            settings.Path = txtSavePath.Text;
            settings.Save();
        }

        private void LoadUploadLog()
        {
            string date = "";
            XmlReader reader = XmlReader.Create(Path.GetTempPath() + "/UploadLog.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Date":
                            date = reader.ReadString();
                            break;
                        case "Link":
                            listViewData.Items.Add(new ListViewItem(new[] { date, reader.ReadString() }));
                            break;
                    }
                }
            }
            reader.Close();
        }


        private void btnCopyLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listViewData.SelectedItems[0].SubItems[1].Text);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            listViewData.Items.Clear();
            if (File.Exists(Path.GetTempPath() + "/UploadLog.xml"))
            {
                File.Delete(Path.GetTempPath() + "/UploadLog.xml");
            }
            XDocument xmlFile = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            xmlFile.Add(new XElement("UploadList"));
            xmlFile.Save(Path.GetTempPath() + "/UploadLog.xml");
        } 


        private void txtHotkeyScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (!new[] { 8, 17, 18, 46 }.Contains(e.KeyValue))
            {
                ModifierKeys modifierKeys = 0;
                var displayString = "";

                if (e.Control)
                {
                    modifierKeys |= Class.ModifierKeys.Control;
                    displayString += "Ctrl+";
                }
                if (e.Alt)
                {
                    modifierKeys |= Class.ModifierKeys.Alt;
                    displayString += "Alt+";
                }

                txtHotkeyDefined.Text = String.Format("{0}{1}", displayString, e.KeyCode);
                settings.KeyDefined = Enum.Format(typeof(Keys), e.KeyCode, "g");
                settings.ModifierDefined = Enum.Format(typeof(ModifierKeys), modifierKeys, "g");
                settings.Save();
                Main.Instance.ReAttachKeyboardHook();
            }
        }

        private void txtHotkeyFullScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (!new[] { 8, 17, 18, 46 }.Contains(e.KeyValue))
            {
                ModifierKeys modifierKeys = 0;
                var displayString = "";

                if (e.Control)
                {
                    modifierKeys |= Class.ModifierKeys.Control;
                    displayString += "Ctrl+";
                }
                if (e.Alt)
                {
                    modifierKeys |= Class.ModifierKeys.Alt;
                    displayString += "Alt+";
                }

                txtHotkeyFull.Text = String.Format("{0}{1}", displayString, e.KeyCode);
                settings.KeyFull = Enum.Format(typeof(Keys), e.KeyCode, "g");
                settings.ModifierFull = Enum.Format(typeof(ModifierKeys), modifierKeys, "g");
                settings.Save();
                Main.Instance.ReAttachKeyboardHook();
            }
        }

        private void txtHotkeyActive_KeyDown(object sender, KeyEventArgs e)
        {
            if (!new[] { 8, 17, 18, 46 }.Contains(e.KeyValue))
            {
                ModifierKeys modifierKeys = 0;
                var displayString = "";

                if (e.Control)
                {
                    modifierKeys |= Class.ModifierKeys.Control;
                    displayString += "Ctrl+";
                }
                if (e.Alt)
                {
                    modifierKeys |= Class.ModifierKeys.Alt;
                    displayString += "Alt+";
                }

                txtHotkeyActive.Text = String.Format("{0}{1}", displayString, e.KeyCode);
                settings.KeyActive = Enum.Format(typeof(Keys), e.KeyCode, "g");
                settings.ModifierActive = Enum.Format(typeof(ModifierKeys), modifierKeys, "g");
                settings.Save();
                Main.Instance.ReAttachKeyboardHook();
            }
        }

        private void btnChoosePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                settings.Path = dialog.SelectedPath;
                txtSavePath.Text = dialog.SelectedPath;
            }
        }


        private void chkBxAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (chkBxAutoStart.Checked)
            {
                registryKey.SetValue("SnipUp", AppPath);
            }
            else
            {
                registryKey.DeleteValue("SnipUp");
            }
        }  

        private void chkBxExplorerContextMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUserAdministrator())
            {
                if (chkBxExplorerContextMenu.Checked)
                {
                    foreach (string i in extensions)
                    {
                        AddToExplorerContextMenu(i, "upload to epvpImg", Path.GetDirectoryName(AppPath) + @"\Upload.exe %1");
                    }
                }
                else
                {
                    foreach (string i in extensions)
                    {
                        RemoveExplorerContextMenu(i, "upload to epvpImg");
                    }
                }
            }
        }

        private void chkBxSaveLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxSaveLocal.Checked)
            {
                btnChoosePath.Enabled = true;
            }
            else
            {
                btnChoosePath.Enabled = false;
            }
        }


        public void AddToExplorerContextMenu(string pExtension, string pText, string pCommand)
        {
            RegistryKey Extensionkey = Registry.ClassesRoot.CreateSubKey(pExtension);
            RegistryKey Shellkey = Extensionkey.CreateSubKey("shell");
            RegistryKey Entrykey = Shellkey.CreateSubKey(pText);
            Entrykey.SetValue("Icon", Path.GetDirectoryName(AppPath) + @"\snipup.ico");
            RegistryKey Commandkey = Entrykey.CreateSubKey("command");
            Commandkey.SetValue("", pCommand);
            Commandkey.Close();
            Entrykey.Close();
            Shellkey.Close();
            Extensionkey.Close();
        }

        public void RemoveExplorerContextMenu(string pExtension, string pText)
        {
            RegistryKey Extensionkey = Registry.ClassesRoot.OpenSubKey(pExtension, true);
            RegistryKey Shellkey = Extensionkey.OpenSubKey("Shell", true);
            Shellkey.DeleteSubKeyTree(pText);
            Shellkey.Close();
            Extensionkey.Close();
        }

        public bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }
    }
}
