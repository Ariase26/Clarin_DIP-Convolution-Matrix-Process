using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace Clarin_DIP_Activity
{
    public partial class Form1 : Form
    {
        Bitmap original;
        Bitmap processed;
        FilterInfoCollection device;
        VideoCaptureDevice vidCam;
        bool onCam = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void openIMGFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap originalImage = new Bitmap(ofd.FileName);
                    Bitmap resizedImage = new Bitmap(originalImage, new Size(250, 250));
                    originalImage.Dispose();

                    original = resizedImage;
                    processed = (Bitmap)original.Clone();
                    pictureBox1.Image = original;
                    pictureBox2.Image = processed;
                    pictureBox2.Image = null;

                }
            }
        }

        private void saveIMGFile_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG|*.png|JPEG|*.jpg|BMP|*.bmp";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    processed.Save(sfd.FileName, ImageFormat.Png);
                }
            }
        }

        private void clearIMG_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            original = null;
            processed = null;
        }

        private void copyIMG_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Bitmap curr = new Bitmap(pictureBox1.Image);

            processed = new Bitmap(curr.Width, curr.Height);
            for (int x = 0; x < curr.Width; x++)
            {
                for (int y = 0; y < curr.Height; y++)
                {
                    processed.SetPixel(x, y, curr.GetPixel(x, y));
                }
            }

            pictureBox2.Image = processed;
            label2.Text = "Processed Image";
        }

        private void greyscaleIMG_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Bitmap curr = new Bitmap(pictureBox1.Image);

            processed = new Bitmap(curr.Width, curr.Height);
            for (int x = 0; x < curr.Width; x++)
            {
                for (int y = 0; y < curr.Height; y++)
                {
                    Color pixel = curr.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    processed.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }

            pictureBox2.Image = processed;
            label2.Text = "Greyscale Result";
        }

        private void colorInversionIMG_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Bitmap curr = new Bitmap(pictureBox1.Image);

            processed = new Bitmap(curr.Width, curr.Height);
            for (int x = 0; x < curr.Width; x++)
            {
                for (int y = 0; y < curr.Height; y++)
                {
                    Color pixel = curr.GetPixel(x, y);
                    processed.SetPixel(x, y, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
            }

            pictureBox2.Image = processed;
            label2.Text = "Color Inversion Result";
        }

        private void histogramIMG_Click(object sender, EventArgs e)
        {
            if (processed == null) { return; }

            int[] histogram = new int[256];
            for (int y = 0; y < processed.Height; y++)
            {
                for (int x = 0; x < processed.Width; x++)
                {
                    Color pixel = processed.GetPixel(x, y);
                    int grayValue = (pixel.R + pixel.G + pixel.B) / 3;
                    histogram[grayValue]++;
                }
            }

            int max = histogram.Max();
            Bitmap histogramBitmap = new Bitmap(240, 240);
            using (Graphics g = Graphics.FromImage(histogramBitmap))
            {
                g.Clear(Color.White);
                for (int i = 0; i < histogram.Length; i++)
                {
                    int barHeight = (int)((histogram[i] / (float)max) * histogramBitmap.Height);
                    g.DrawLine(Pens.Black, i, histogramBitmap.Height, i, histogramBitmap.Height - barHeight);
                }
            }

            pictureBox2.Image = histogramBitmap;
            label2.Text = "Histogram Result";
        }

        private void sepiaIMG_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Bitmap curr = new Bitmap(pictureBox1.Image);

            processed = new Bitmap(curr.Width, curr.Height);
            for (int i = 0; i < curr.Width; i++)
            {
                for (int j = 0; j < curr.Height; j++)
                {
                    Color pixel = curr.GetPixel(i, j);
                    int r = Math.Min((int)((pixel.R * 0.393) + (pixel.G * 0.769) + (pixel.B * 0.189)), 255);
                    int g = Math.Min((int)((pixel.R * 0.349) + (pixel.G * 0.686) + (pixel.B * 0.168)), 255);
                    int b = Math.Min((int)((pixel.R * 0.272) + (pixel.G * 0.534) + (pixel.B * 0.131)), 255);
                    processed.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBox2.Image = processed;
            label2.Text = "Sepia Result";
        }

        private void horizontalReverseIMG_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Bitmap curr = new Bitmap(pictureBox1.Image);

            processed = new Bitmap(curr.Width, curr.Height);
            for (int x = 0; x < curr.Width; x++)
            {
                for (int y = 0; y < curr.Height; y++)
                {
                    Color pixel = curr.GetPixel(curr.Width - 1 - x, y);
                    processed.SetPixel(x, y, pixel);
                }
            }

            pictureBox2.Image = processed;
            label2.Text = "Reverse Image";
        }

        private void moreFeatures_btn_Click(object sender, EventArgs e)
        {
            Form2 otherFunctions = new Form2();
            otherFunctions.FormClosed += (s, args) => this.Show();
            otherFunctions.Show();
            this.Hide();
        }

        private void webcamONOFF_btn_Click(object sender, EventArgs e)
        {
            if (!onCam)
            {
                device = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (device.Count == 0) { return; }

                vidCam = new VideoCaptureDevice(device[0].MonikerString);
                vidCam.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                vidCam.Start();

                webcamONOFF_btn.Text = "WebCam Off";
                onCam = true;
            }
            else
            {
                vidCam.SignalToStop();
                vidCam.WaitForStop();
                webcamONOFF_btn.Text = "WebCam On";
                onCam = false;
            }
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            Bitmap resizedFrame = new Bitmap(frame, new Size(250, 250));
            pictureBox1.Image = resizedFrame;
            frame.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 otherFunctions = new Form3();
            otherFunctions.FormClosed += (s, args) => this.Show();
            otherFunctions.Show();
            this.Hide();
        }
    }
}
