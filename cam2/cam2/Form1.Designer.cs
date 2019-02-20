namespace cam2
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
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cannybox = new System.Windows.Forms.TextBox();
            this.canny_th_up = new System.Windows.Forms.Button();
            this.canny_th_down = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(12, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(720, 480);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(766, 12);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(720, 480);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.Location = new System.Drawing.Point(12, 516);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Canny\'s Thresh:";
            // 
            // cannybox
            // 
            this.cannybox.Font = new System.Drawing.Font("宋体", 20F);
            this.cannybox.Location = new System.Drawing.Point(324, 513);
            this.cannybox.Name = "cannybox";
            this.cannybox.Size = new System.Drawing.Size(113, 46);
            this.cannybox.TabIndex = 4;
            // 
            // canny_th_up
            // 
            this.canny_th_up.Font = new System.Drawing.Font("宋体", 15F);
            this.canny_th_up.Location = new System.Drawing.Point(479, 519);
            this.canny_th_up.Name = "canny_th_up";
            this.canny_th_up.Size = new System.Drawing.Size(90, 40);
            this.canny_th_up.TabIndex = 5;
            this.canny_th_up.Text = "up";
            this.canny_th_up.UseVisualStyleBackColor = true;
            this.canny_th_up.Click += new System.EventHandler(this.canny_th_up_Click);
            // 
            // canny_th_down
            // 
            this.canny_th_down.Font = new System.Drawing.Font("宋体", 15F);
            this.canny_th_down.Location = new System.Drawing.Point(592, 519);
            this.canny_th_down.Name = "canny_th_down";
            this.canny_th_down.Size = new System.Drawing.Size(90, 40);
            this.canny_th_down.TabIndex = 6;
            this.canny_th_down.Text = "down";
            this.canny_th_down.UseVisualStyleBackColor = true;
            this.canny_th_down.Click += new System.EventHandler(this.canny_th_down_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 753);
            this.Controls.Add(this.canny_th_down);
            this.Controls.Add(this.canny_th_up);
            this.Controls.Add(this.cannybox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cannybox;
        private System.Windows.Forms.Button canny_th_up;
        private System.Windows.Forms.Button canny_th_down;
    }
}

