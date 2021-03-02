using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgApp_2_WinForms
{
    public partial class Form1 : Form
    {
        private Bitmap image = null;

        public Form1()
        {
            InitializeComponent();
            image = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            pictureBox1.Image = image;
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog  = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image != null)
                {
                    pictureBox1.Image = null;
                    image.Dispose();
                }

                image = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = image;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileFialog = new SaveFileDialog();
            saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            saveFileFialog.RestoreDirectory = true;

            if (saveFileFialog.ShowDialog() == DialogResult.OK)
            {
                if (image != null)
                {
                    image.Save(saveFileFialog.FileName);
                }
            }
        }

        private void bDraw_Click(object sender, EventArgs e)
        {
            using Graphics g = Graphics.FromImage(image);
            Random r = new Random();
            for (int i = 0; i < 10; ++i)
            {
                var color = Color.FromArgb(r.Next(255), 
                                          r.Next(255), 
                                           r.Next(255));

                using Brush b = new SolidBrush(color);
                
                g.FillEllipse(b,r.Next(image.Width), r.Next(image.Width),20,20);
            }

            pictureBox1.Refresh();
        }
    }
}
