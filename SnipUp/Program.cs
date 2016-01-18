using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SnipUp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Main newMain;
        [STAThread]
        static void Main()
        {
             //string[] args = Environment.GetCommandLineArgs();
             //MessageBox.Show(args[1]);

            bool createdNew;
            using (var mutex = new Mutex(true, "SnipUp", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.ThreadException += Application_ThreadException;
                    newMain = new Main();
                    Application.Run();
                }
            }
            
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var message = String.Format("It seems SnipUp has crashed.{0}Do you want to save a log of the error that ocurred?{0}This could be useful to fix bugs. Please mail this file to: m2kmod@web.de", Environment.NewLine);
            var result = MessageBox.Show(message, "SnipUp crashed...", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                var textToWrite = String.Format("{0}\nException:\n{1}\n\nInner Exception:\n{2}\n\n\n\n", DateTime.Now, e.Exception.Message, e.Exception.InnerException);
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                using (var sw = new StreamWriter(dialog.OpenFile()))
                {
                    sw.Write(textToWrite);
                }
            }
        }
    }
}
