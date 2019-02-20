namespace cam
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.captureImageBox = new Emgu.CV.UI.ImageBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.laplacebox = new Emgu.CV.UI.ImageBox();
            this.cannybox = new Emgu.CV.UI.ImageBox();
            this.other = new Emgu.CV.UI.ImageBox();
            this.canny_th = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laplacebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannybox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.other)).BeginInit();
            this.SuspendLayout();
            // 
            // captureImageBox
            // 
            this.captureImageBox.Location = new System.Drawing.Point(12, 6);
            this.captureImageBox.Name = "captureImageBox";
            this.captureImageBox.Size = new System.Drawing.Size(450, 450);
            this.captureImageBox.TabIndex = 2;
            this.captureImageBox.TabStop = false;
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(12, 918);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(152, 31);
            this.captureButton.TabIndex = 3;
            this.captureButton.Text = "state";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(843, 922);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "pixel";
            // 
            // laplacebox
            // 
            this.laplacebox.Location = new System.Drawing.Point(527, 6);
            this.laplacebox.Name = "laplacebox";
            this.laplacebox.Size = new System.Drawing.Size(450, 450);
            this.laplacebox.TabIndex = 2;
            this.laplacebox.TabStop = false;
            // 
            // cannybox
            // 
            this.cannybox.Location = new System.Drawing.Point(12, 462);
            this.cannybox.Name = "cannybox";
            this.cannybox.Size = new System.Drawing.Size(450, 450);
            this.cannybox.TabIndex = 5;
            this.cannybox.TabStop = false;
            // 
            // other
            // 
            this.other.Location = new System.Drawing.Point(527, 462);
            this.other.Name = "other";
            this.other.Size = new System.Drawing.Size(450, 450);
            this.other.TabIndex = 6;
            this.other.TabStop = false;
            // 
            // canny_th
            // 
            this.canny_th.Location = new System.Drawing.Point(443, 922);
            this.canny_th.Name = "canny_th";
            this.canny_th.Size = new System.Drawing.Size(100, 25);
            this.canny_th.TabIndex = 7;
            this.canny_th.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 926);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Canny\'s Thresh";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 953);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.canny_th);
            this.Controls.Add(this.other);
            this.Controls.Add(this.cannybox);
            this.Controls.Add(this.laplacebox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.captureImageBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laplacebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannybox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.other)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox captureImageBox;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.Label label1;
        private Emgu.CV.UI.ImageBox laplacebox;
        private Emgu.CV.UI.ImageBox cannybox;
        private Emgu.CV.UI.ImageBox other;
        private System.Windows.Forms.TextBox canny_th;
        private System.Windows.Forms.Label label2;
    }
}

