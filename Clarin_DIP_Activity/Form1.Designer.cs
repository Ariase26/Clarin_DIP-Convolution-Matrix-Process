namespace Clarin_DIP_Activity
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openImg_btn = new System.Windows.Forms.Button();
            this.saveImg_btn = new System.Windows.Forms.Button();
            this.moreFeatures_btn = new System.Windows.Forms.Button();
            this.histogram_btn = new System.Windows.Forms.Button();
            this.sepia_btn = new System.Windows.Forms.Button();
            this.colorInversion_btn = new System.Windows.Forms.Button();
            this.greyscale_btn = new System.Windows.Forms.Button();
            this.copyImg_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reverseImg_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.webcamONOFF_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(95, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(460, 104);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 250);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // openImg_btn
            // 
            this.openImg_btn.Location = new System.Drawing.Point(12, 14);
            this.openImg_btn.Name = "openImg_btn";
            this.openImg_btn.Size = new System.Drawing.Size(75, 23);
            this.openImg_btn.TabIndex = 4;
            this.openImg_btn.Text = "Open Image";
            this.openImg_btn.UseVisualStyleBackColor = true;
            this.openImg_btn.Click += new System.EventHandler(this.openIMGFile_Click);
            // 
            // saveImg_btn
            // 
            this.saveImg_btn.Location = new System.Drawing.Point(12, 46);
            this.saveImg_btn.Name = "saveImg_btn";
            this.saveImg_btn.Size = new System.Drawing.Size(75, 23);
            this.saveImg_btn.TabIndex = 5;
            this.saveImg_btn.Text = "Save Image";
            this.saveImg_btn.UseVisualStyleBackColor = true;
            this.saveImg_btn.Click += new System.EventHandler(this.saveIMGFile_Click);
            // 
            // moreFeatures_btn
            // 
            this.moreFeatures_btn.BackColor = System.Drawing.Color.Black;
            this.moreFeatures_btn.ForeColor = System.Drawing.Color.White;
            this.moreFeatures_btn.Location = new System.Drawing.Point(675, 415);
            this.moreFeatures_btn.Name = "moreFeatures_btn";
            this.moreFeatures_btn.Size = new System.Drawing.Size(113, 23);
            this.moreFeatures_btn.TabIndex = 7;
            this.moreFeatures_btn.Text = "Subtract Process";
            this.moreFeatures_btn.UseVisualStyleBackColor = false;
            this.moreFeatures_btn.Click += new System.EventHandler(this.moreFeatures_btn_Click);
            // 
            // histogram_btn
            // 
            this.histogram_btn.Location = new System.Drawing.Point(590, 46);
            this.histogram_btn.Name = "histogram_btn";
            this.histogram_btn.Size = new System.Drawing.Size(91, 23);
            this.histogram_btn.TabIndex = 6;
            this.histogram_btn.Text = "Histogram";
            this.histogram_btn.UseVisualStyleBackColor = true;
            this.histogram_btn.Click += new System.EventHandler(this.histogramIMG_Click);
            // 
            // sepia_btn
            // 
            this.sepia_btn.Location = new System.Drawing.Point(697, 14);
            this.sepia_btn.Name = "sepia_btn";
            this.sepia_btn.Size = new System.Drawing.Size(91, 23);
            this.sepia_btn.TabIndex = 9;
            this.sepia_btn.Text = "Sepia";
            this.sepia_btn.UseVisualStyleBackColor = true;
            this.sepia_btn.Click += new System.EventHandler(this.sepiaIMG_Click);
            // 
            // colorInversion_btn
            // 
            this.colorInversion_btn.Location = new System.Drawing.Point(590, 14);
            this.colorInversion_btn.Name = "colorInversion_btn";
            this.colorInversion_btn.Size = new System.Drawing.Size(91, 23);
            this.colorInversion_btn.TabIndex = 8;
            this.colorInversion_btn.Text = "Color Inversion";
            this.colorInversion_btn.UseVisualStyleBackColor = true;
            this.colorInversion_btn.Click += new System.EventHandler(this.colorInversionIMG_Click);
            // 
            // greyscale_btn
            // 
            this.greyscale_btn.Location = new System.Drawing.Point(483, 46);
            this.greyscale_btn.Name = "greyscale_btn";
            this.greyscale_btn.Size = new System.Drawing.Size(91, 23);
            this.greyscale_btn.TabIndex = 11;
            this.greyscale_btn.Text = "Greyscale";
            this.greyscale_btn.UseVisualStyleBackColor = true;
            this.greyscale_btn.Click += new System.EventHandler(this.greyscaleIMG_Click);
            // 
            // copyImg_btn
            // 
            this.copyImg_btn.Location = new System.Drawing.Point(483, 14);
            this.copyImg_btn.Name = "copyImg_btn";
            this.copyImg_btn.Size = new System.Drawing.Size(91, 23);
            this.copyImg_btn.TabIndex = 10;
            this.copyImg_btn.Text = "Basic Copy";
            this.copyImg_btn.UseVisualStyleBackColor = true;
            this.copyImg_btn.Click += new System.EventHandler(this.copyIMG_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(510, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Processed Image";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reverseImg_btn
            // 
            this.reverseImg_btn.Location = new System.Drawing.Point(697, 46);
            this.reverseImg_btn.Name = "reverseImg_btn";
            this.reverseImg_btn.Size = new System.Drawing.Size(91, 23);
            this.reverseImg_btn.TabIndex = 14;
            this.reverseImg_btn.Text = "Reverse";
            this.reverseImg_btn.UseVisualStyleBackColor = true;
            this.reverseImg_btn.Click += new System.EventHandler(this.horizontalReverseIMG_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Clear Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clearIMG_Click);
            // 
            // webcamONOFF_btn
            // 
            this.webcamONOFF_btn.BackColor = System.Drawing.Color.Turquoise;
            this.webcamONOFF_btn.Location = new System.Drawing.Point(370, 203);
            this.webcamONOFF_btn.Name = "webcamONOFF_btn";
            this.webcamONOFF_btn.Size = new System.Drawing.Size(64, 55);
            this.webcamONOFF_btn.TabIndex = 16;
            this.webcamONOFF_btn.Text = "WebCam On";
            this.webcamONOFF_btn.UseVisualStyleBackColor = false;
            this.webcamONOFF_btn.Click += new System.EventHandler(this.webcamONOFF_btn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(17, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Convolution Matrix Process";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.webcamONOFF_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reverseImg_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.greyscale_btn);
            this.Controls.Add(this.copyImg_btn);
            this.Controls.Add(this.sepia_btn);
            this.Controls.Add(this.colorInversion_btn);
            this.Controls.Add(this.moreFeatures_btn);
            this.Controls.Add(this.histogram_btn);
            this.Controls.Add(this.saveImg_btn);
            this.Controls.Add(this.openImg_btn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button openImg_btn;
        private System.Windows.Forms.Button saveImg_btn;
        private System.Windows.Forms.Button moreFeatures_btn;
        private System.Windows.Forms.Button histogram_btn;
        private System.Windows.Forms.Button sepia_btn;
        private System.Windows.Forms.Button colorInversion_btn;
        private System.Windows.Forms.Button greyscale_btn;
        private System.Windows.Forms.Button copyImg_btn;
        private System.Windows.Forms.OpenFileDialog openFileUI;
        private System.Windows.Forms.SaveFileDialog saveFileUI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button reverseImg_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button webcamONOFF_btn;
        private System.Windows.Forms.Button button2;
    }
}

