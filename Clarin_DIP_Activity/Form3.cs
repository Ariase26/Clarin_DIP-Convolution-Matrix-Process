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

namespace Clarin_DIP_Activity
{
    public partial class Form3 : Form
    {
        Bitmap original;
        Bitmap processed;

        public Form3()
        {
            InitializeComponent();
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
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

        public class ConvMatrix
        {
            public int TopLeft = 0, TopMid = 0, TopRight = 0;
            public int MidLeft = 0, Pixel = 1, MidRight = 0;
            public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
            public int Factor = 1;
            public int Offset = 0;

            public void SetAll(int nVal)
            {
                TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
            }
        }

        public static bool Conv3x3(Bitmap b, ConvMatrix m)
        {
            if (m.Factor == 0) m.Factor = 1;

            Bitmap bSrc = (Bitmap)b.Clone();
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;

            IntPtr scan0 = bmData.Scan0;
            IntPtr srcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)scan0;
                byte* pSrc = (byte*)(void*)srcScan0;

                int width = b.Width - 2;
                int height = b.Height - 2;
                int offset = stride - b.Width * 3;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int blue = 0, green = 0, red = 0;

                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                int weight = GetMatrixValue(m, i, j);
                                int index = ((y + i + 1) * stride) + ((x + j + 1) * 3);

                                blue += pSrc[index] * weight;
                                green += pSrc[index + 1] * weight;
                                red += pSrc[index + 2] * weight;
                            }
                        }

                        blue = Clamp((blue / m.Factor) + m.Offset, 0, 255);
                        green = Clamp((green / m.Factor) + m.Offset, 0, 255);
                        red = Clamp((red / m.Factor) + m.Offset, 0, 255);

                        int dstIndex = ((y + 1) * stride) + ((x + 1) * 3);
                        p[dstIndex] = (byte)blue;
                        p[dstIndex + 1] = (byte)green;
                        p[dstIndex + 2] = (byte)red;
                    }
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }


        private static int GetMatrixValue(ConvMatrix m, int row, int col)
        {
            if (row == -1 && col == -1) return m.TopLeft;
            if (row == -1 && col == 0) return m.TopMid;
            if (row == -1 && col == 1) return m.TopRight;
            if (row == 0 && col == -1) return m.MidLeft;
            if (row == 0 && col == 0) return m.Pixel;
            if (row == 0 && col == 1) return m.MidRight;
            if (row == 1 && col == -1) return m.BottomLeft;
            if (row == 1 && col == 0) return m.BottomMid;
            if (row == 1 && col == 1) return m.BottomRight;

            return 0;
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            ConvMatrix sharpenMatrix = new ConvMatrix();
            sharpenMatrix.TopLeft = 0;
            sharpenMatrix.TopMid = -2;
            sharpenMatrix.TopRight = 0;
            sharpenMatrix.MidLeft = -2;
            sharpenMatrix.Pixel = 11; 
            sharpenMatrix.MidRight = -2;
            sharpenMatrix.BottomLeft = 0;
            sharpenMatrix.BottomMid = -2;
            sharpenMatrix.BottomRight = 0;

            sharpenMatrix.Factor = 3;
            sharpenMatrix.Offset = 0;

            if (Conv3x3(processed, sharpenMatrix))
            {
                pictureBox2.Image = processed;
            }
        }

        private void smoothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            ConvMatrix smoothEmbossMatrix = new ConvMatrix();
            smoothEmbossMatrix.TopLeft = -1;
            smoothEmbossMatrix.TopMid = -1;
            smoothEmbossMatrix.TopRight = 0;
            smoothEmbossMatrix.MidLeft = -1;
            smoothEmbossMatrix.Pixel = 1;
            smoothEmbossMatrix.MidRight = 1;
            smoothEmbossMatrix.BottomLeft = 0;
            smoothEmbossMatrix.BottomMid = 1;
            smoothEmbossMatrix.BottomRight = 1;
            smoothEmbossMatrix.Factor = 1;
            smoothEmbossMatrix.Offset = 128;

            if (Conv3x3(processed, smoothEmbossMatrix))
            {
                pictureBox2.Image = processed;
            }
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            ConvMatrix gaussianMatrix = new ConvMatrix();

            gaussianMatrix.TopLeft = 1;
            gaussianMatrix.TopMid = 2;
            gaussianMatrix.TopRight = 1;
            gaussianMatrix.MidLeft = 2;
            gaussianMatrix.Pixel = 4;
            gaussianMatrix.MidRight = 2;
            gaussianMatrix.BottomLeft = 1;
            gaussianMatrix.BottomMid = 2;
            gaussianMatrix.BottomRight = 1;

            gaussianMatrix.Factor = 16;
            gaussianMatrix.Offset = 0;  

            if (Conv3x3(processed, gaussianMatrix))
            {
                pictureBox2.Image = processed;
            }
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            ConvMatrix meanRemovalMatrix = new ConvMatrix();
            meanRemovalMatrix.TopLeft = -1;
            meanRemovalMatrix.TopMid = -1;
            meanRemovalMatrix.TopRight = -1;
            meanRemovalMatrix.MidLeft = -1;
            meanRemovalMatrix.Pixel = 9;
            meanRemovalMatrix.MidRight = -1;
            meanRemovalMatrix.BottomLeft = -1;
            meanRemovalMatrix.BottomMid = -1;
            meanRemovalMatrix.BottomRight = -1;
            meanRemovalMatrix.Factor = 1;
            meanRemovalMatrix.Offset = 0;

            if (Conv3x3(processed, meanRemovalMatrix))
            {
                pictureBox2.Image = processed;
            }
        }

        private void laplaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            ConvMatrix laplacianMatrix = new ConvMatrix();
            laplacianMatrix.TopLeft = -1;
            laplacianMatrix.TopMid = 0;
            laplacianMatrix.TopRight = -1;
            laplacianMatrix.MidLeft = 0;
            laplacianMatrix.Pixel = 4;
            laplacianMatrix.MidRight = 0;
            laplacianMatrix.BottomLeft = -1;
            laplacianMatrix.BottomMid = 0;
            laplacianMatrix.BottomRight = -1;

            laplacianMatrix.Factor = 1;
            laplacianMatrix.Offset = 127;

            if (Conv3x3(processed, laplacianMatrix))
            {
                pictureBox2.Image = processed;
            }

        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            ConvMatrix horizontalMatrix = new ConvMatrix();
            horizontalMatrix.TopLeft = 0;
            horizontalMatrix.TopMid = -1;
            horizontalMatrix.TopRight = 0;
            horizontalMatrix.MidLeft = -1;
            horizontalMatrix.Pixel = 4;
            horizontalMatrix.MidRight = -1;
            horizontalMatrix.BottomLeft = 0;
            horizontalMatrix.BottomMid = -1;
            horizontalMatrix.BottomRight = 0;
            horizontalMatrix.Factor = 1;
            horizontalMatrix.Offset = 127;

            if (Conv3x3(processed, horizontalMatrix))
            {
                pictureBox2.Image = processed;
            }
        }

        private void allDirectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            ConvMatrix allDirectionMatrix = new ConvMatrix();
            allDirectionMatrix.TopLeft = -1;
            allDirectionMatrix.TopMid = -1;
            allDirectionMatrix.TopRight = -1;
            allDirectionMatrix.MidLeft = -1;
            allDirectionMatrix.Pixel = 8;
            allDirectionMatrix.MidRight = -1;
            allDirectionMatrix.BottomLeft = -1;
            allDirectionMatrix.BottomMid = -1;
            allDirectionMatrix.BottomRight = -1;

            allDirectionMatrix.Factor = 1;
            allDirectionMatrix.Offset = 127;

            if (Conv3x3(processed, allDirectionMatrix))
            {
                pictureBox2.Image = processed;
            }
        }

        private void lossyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            ConvMatrix lossyMatrix = new ConvMatrix();

            lossyMatrix.TopLeft = 1;
            lossyMatrix.TopMid = -2;
            lossyMatrix.TopRight = 1;
            lossyMatrix.MidLeft = -2;
            lossyMatrix.Pixel = 4;
            lossyMatrix.MidRight = -2;
            lossyMatrix.BottomLeft = -2;
            lossyMatrix.BottomMid = 1;
            lossyMatrix.BottomRight = -2;

            lossyMatrix.Factor = 1;
            lossyMatrix.Offset = 128;

            if (Conv3x3(processed, lossyMatrix))
            {
                pictureBox2.Image = processed;
            }
        }

        private void horizontalOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            ConvMatrix horizontalOnlyMatrix = new ConvMatrix();
            horizontalOnlyMatrix.TopLeft = 0;
            horizontalOnlyMatrix.TopMid = 0;
            horizontalOnlyMatrix.TopRight = 0;
            horizontalOnlyMatrix.MidLeft = -1;
            horizontalOnlyMatrix.Pixel = 2;
            horizontalOnlyMatrix.MidRight = -1;
            horizontalOnlyMatrix.BottomLeft = 0;
            horizontalOnlyMatrix.BottomMid = 0;
            horizontalOnlyMatrix.BottomRight = 0;
            horizontalOnlyMatrix.Factor = 1;
            horizontalOnlyMatrix.Offset = 127;

            if (Conv3x3(processed, horizontalOnlyMatrix))
            {
                pictureBox2.Image = processed;
            }
        }

        private void verticalOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processed == null) return;

            ConvMatrix verticalOnlyMatrix = new ConvMatrix();
            verticalOnlyMatrix.TopLeft = 0;
            verticalOnlyMatrix.TopMid = -1;
            verticalOnlyMatrix.TopRight = 0;
            verticalOnlyMatrix.MidLeft = 0;
            verticalOnlyMatrix.Pixel = 0;
            verticalOnlyMatrix.MidRight = 0;
            verticalOnlyMatrix.BottomLeft = 0;
            verticalOnlyMatrix.BottomMid = 1;
            verticalOnlyMatrix.BottomRight = 0;
            verticalOnlyMatrix.Factor = 1;
            verticalOnlyMatrix.Offset = 127;

            if (Conv3x3(processed, verticalOnlyMatrix))
            {
                pictureBox2.Image = processed;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 backToHome = new Form1();
            backToHome.FormClosed += (s, args) => this.Show();
            backToHome.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            original = null;
            processed = null;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
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
        }
    }
}
