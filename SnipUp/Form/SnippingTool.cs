/* 
 * Credit for this portion of Imgur Snipping Tool goes to Hans Passant from stackoverflow.com
 * http://stackoverflow.com/questions/3123776/net-equivalent-of-snipping-tool
 * 
 * Modified to work with multiple monitors.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace SnipUp
{
    public partial class SnippingTool : Form
    {
        public enum ScreenshotType
        {
            FULL, ACTIVE, DEFINED
        }

        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern int GetForegroundWindow();

        
        public static Image Snip(ScreenshotType type)
        {
            switch(type)
            {
                case ScreenshotType.FULL:
                    return CreateScreenshot(0, 0, SystemInformation.VirtualScreen.Width,SystemInformation.VirtualScreen.Height);

                case ScreenshotType.DEFINED:
                     SnippingTool snipper = new SnippingTool(CreateScreenshot(0, 0, SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height), new Point(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top));
                     if (snipper.ShowDialog() == DialogResult.OK)
                     {
                         return snipper.Image;
                     }
                     break;
                case ScreenshotType.ACTIVE:
                    RECT windowRectangle;
                    GetWindowRect((System.IntPtr)GetForegroundWindow(), out windowRectangle);
                    return CreateScreenshot(windowRectangle.Left, windowRectangle.Top, windowRectangle.Right - windowRectangle.Left, windowRectangle.Bottom - windowRectangle.Top);
            }
            return null;
        }

        private static Bitmap CreateScreenshot(int left, int top, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(left, top, 0, 0, new Size(width, height));
            g.Dispose();
            return bmp;
        }

       
        public SnippingTool(Image screenShot, Point startPos)
        {
            InitializeComponent();
            this.BackgroundImage = screenShot;
            Size s = screenShot.Size;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = s;
            this.Location = startPos;
            this.DoubleBuffered = true;
        }
        public Image Image { get; set; }

        private Rectangle rcSelect = new Rectangle();
        private Point pntStart;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Start the snip on mouse down
            if (e.Button != MouseButtons.Left) return;
            pntStart = e.Location;
            rcSelect = new Rectangle(e.Location, new Size(0, 0));
            this.Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Modify the selection on mouse move
            if (e.Button != MouseButtons.Left) return;
            int x1 = Math.Min(e.X, pntStart.X);
            int y1 = Math.Min(e.Y, pntStart.Y);
            int x2 = Math.Max(e.X, pntStart.X);
            int y2 = Math.Max(e.Y, pntStart.Y);
            rcSelect = new Rectangle(x1, y1, x2 - x1, y2 - y1);
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Complete the snip on mouse-up
            if (rcSelect.Width <= 0 || rcSelect.Height <= 0) return;
            Image = new Bitmap(rcSelect.Width, rcSelect.Height);
            using (Graphics gr = Graphics.FromImage(Image))
            {
                gr.DrawImage(this.BackgroundImage, new Rectangle(0, 0, Image.Width, Image.Height),
                    rcSelect, GraphicsUnit.Pixel);
            }
            DialogResult = DialogResult.OK;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the current selection
            using (Brush br = new SolidBrush(Color.FromArgb(120, Color.White)))
            {
                int x1 = rcSelect.X; int x2 = rcSelect.X + rcSelect.Width;
                int y1 = rcSelect.Y; int y2 = rcSelect.Y + rcSelect.Height;
                e.Graphics.FillRectangle(br, new Rectangle(0, 0, x1, this.Height));
                e.Graphics.FillRectangle(br, new Rectangle(x2, 0, this.Width - x2, this.Height));
                e.Graphics.FillRectangle(br, new Rectangle(x1, 0, x2 - x1, y1));
                e.Graphics.FillRectangle(br, new Rectangle(x1, y2, x2 - x1, this.Height - y2));
            }
            using (Pen pen = new Pen(Color.Red, 1))
            {
                e.Graphics.DrawRectangle(pen, rcSelect);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Allow canceling the snip with the Escape key
            if (keyData == Keys.Escape) this.DialogResult = DialogResult.Cancel;
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

}
