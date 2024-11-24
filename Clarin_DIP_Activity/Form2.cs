using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Clarin_DIP_Activity
{
    public partial class Form2 : Form
    {
        Bitmap imageA;
        Bitmap imageB;
        Bitmap result;

        public Form2()
        {
            InitializeComponent();
        }

        private void backPanel_btn_Click(object sender, EventArgs e)
        {
            Form1 mainFunctions = new Form1();
            mainFunctions.FormClosed += (s, args) => this.Show();
            mainFunctions.Show();
            this.Hide();
        }

        private void saveResultIMG_btn_Click(object sender, EventArgs e)
        {
            if (result == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG|*.png|JPEG|*.jpg|BMP|*.bmp";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    result.Save(sfd.FileName, ImageFormat.Png);
                }
            }
        }

        private void loadIMG1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap originalImage = new Bitmap(ofd.FileName);
                    Bitmap resizedImage = new Bitmap(originalImage, new Size(250, 250));
                    originalImage.Dispose();

                    imageA = resizedImage;
                    pictureBox1.Image = imageA;
                }
            }
        }

        private void loadIMG2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap originalImage = new Bitmap(ofd.FileName);
                    Bitmap resizedImage = new Bitmap(originalImage, new Size(250, 250));
                    originalImage.Dispose();

                    imageB = resizedImage;
                    pictureBox2.Image = imageB;
                }
            }
        }

        private void subtractIMG_btn_Click(object sender, EventArgs e)
        {
            if (imageA == null || imageB == null) { return; }

            Color targetGreen = Color.FromArgb(0, 255, 0);
            result = new Bitmap(imageA.Width, imageA.Height);
            int threshold = 60;

            for (int x = 0; x < imageA.Width; x++)
            {
                for (int y = 0; y < imageA.Height; y++)
                {
                    Color greenPixel = imageA.GetPixel(x, y);
                    Color backgroundPixel = imageB.GetPixel(x, y);

                    if (greenPixel.G > greenPixel.R + threshold && greenPixel.G > greenPixel.B + threshold)
                    {
                        result.SetPixel(x, y, backgroundPixel);
                    }
                    else
                    {
                        result.SetPixel(x, y, greenPixel);
                    }
                }
            }

            pictureBox3.Image = result;
        }
    }
}
