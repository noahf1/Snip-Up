using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using SnipUp.Properties;

namespace SnipUp.Class
{
    public class TrayIcon
    {
        public NotifyIcon trayIcon;
        private readonly ContextMenuStrip settingsMenu;
        private Properties.Settings settings = Properties.Settings.Default;
      
        public TrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.Icon = new Icon(Properties.Resources.snipup, 40, 40);
            trayIcon.Visible = true;
            trayIcon.Text = "SnipUp";

            HotkeyStrings hotkey = new HotkeyStrings();
            settingsMenu = new ContextMenuStrip();
            settingsMenu.Items.Add("Defined Area Capture [" + hotkey.getHotkeyStringDefined() + "]", Properties.Resources.IconDefined, (sender, e) => NewScreenshot(SnippingTool.ScreenshotType.DEFINED));
            settingsMenu.Items.Add("Fullscreen Capture [" + hotkey.getHotkeyStringFull() + "]", Properties.Resources.IconFull, (sender, e) => NewScreenshot(SnippingTool.ScreenshotType.FULL));
            settingsMenu.Items.Add("Active Window Capture [" + hotkey.getHotkeyStringActive() + "]", Properties.Resources.IconActive, (sender, e) => NewScreenshot(SnippingTool.ScreenshotType.ACTIVE));
            settingsMenu.Items.Add("-");
            settingsMenu.Items.Add("Settings", Properties.Resources.IconSettings, (sender, e) => OpenSettings());
            settingsMenu.Items.Add("Open Folder", Properties.Resources.IconFolder, (sender, e) => OpenFolder());
            settingsMenu.Items.Add("-");
            settingsMenu.Items.Add("Exit", null, (sender, e) => Application.Exit());
            trayIcon.ContextMenuStrip = settingsMenu;
        }

       

        public void NewScreenshot(SnippingTool.ScreenshotType type)
        {
            Image bmp = SnippingTool.Snip(type);

            if (bmp != null)
            {
                frm_main newFrmMain = new frm_main(bmp, trayIcon);
                newFrmMain.ShowDialog();
            }
        }

        public void OpenSettings()
        {
            frm_settings newSettings = new frm_settings();
            newSettings.ShowDialog();
        }

        public void OpenFolder()
        {
            System.Diagnostics.Process.Start("explorer.exe", settings.Path);
        }
           

       

        public void ShowNoDevices()
        {
            trayIcon.ShowBalloonTip(3000, "SoundSwitch: Configuration needed", "No devices available to switch to. Open configuration by right-clicking on the SoundSwitch icon. ", ToolTipIcon.Warning);
        }

       
        public void ShowError(string errorMessage, string errorTitle = "Error")
        {
            trayIcon.ShowBalloonTip(3000, "SoundSwitch: " + errorTitle, errorMessage, ToolTipIcon.Error);
        }
    }
}
