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
            this.cannybox1 = new System.Windows.Forms.TextBox();
            this.canny_th_up1 = new System.Windows.Forms.Button();
            this.canny_th_down1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cannybox2 = new System.Windows.Forms.TextBox();
            this.canny_th_up2 = new System.Windows.Forms.Button();
            this.canny_th_down2 = new System.Windows.Forms.Button();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Slide_Size = new System.Windows.Forms.TextBox();
            this.Slide_Size_Up = new System.Windows.Forms.Button();
            this.Slide_Size_Down = new System.Windows.Forms.Button();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.filedir = new System.Windows.Forms.Label();
            this.filedirBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(287, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Canny\'s Thresh1:";
            // 
            // cannybox1
            // 
            this.cannybox1.Font = new System.Drawing.Font("宋体", 20F);
            this.cannybox1.Location = new System.Drawing.Point(324, 513);
            this.cannybox1.Name = "cannybox1";
            this.cannybox1.Size = new System.Drawing.Size(113, 46);
            this.cannybox1.TabIndex = 4;
            // 
            // canny_th_up1
            // 
            this.canny_th_up1.Font = new System.Drawing.Font("宋体", 15F);
            this.canny_th_up1.Location = new System.Drawing.Point(479, 519);
            this.canny_th_up1.Name = "canny_th_up1";
            this.canny_th_up1.Size = new System.Drawing.Size(90, 40);
            this.canny_th_up1.TabIndex = 5;
            this.canny_th_up1.Text = "up";
            this.canny_th_up1.UseVisualStyleBackColor = true;
            this.canny_th_up1.Click += new System.EventHandler(this.Canny_th_up_Click);
            // 
            // canny_th_down1
            // 
            this.canny_th_down1.Font = new System.Drawing.Font("宋体", 15F);
            this.canny_th_down1.Location = new System.Drawing.Point(592, 519);
            this.canny_th_down1.Name = "canny_th_down1";
            this.canny_th_down1.Size = new System.Drawing.Size(90, 40);
            this.canny_th_down1.TabIndex = 6;
            this.canny_th_down1.Text = "down";
            this.canny_th_down1.UseVisualStyleBackColor = true;
            this.canny_th_down1.Click += new System.EventHandler(this.Canny_th_down_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20F);
            this.label2.Location = new System.Drawing.Point(12, 594);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 34);
            this.label2.TabIndex = 7;
            this.label2.Text = "Canny\'s Thresh2:";
            // 
            // cannybox2
            // 
            this.cannybox2.Font = new System.Drawing.Font("宋体", 20F);
            this.cannybox2.Location = new System.Drawing.Point(324, 594);
            this.cannybox2.Name = "cannybox2";
            this.cannybox2.Size = new System.Drawing.Size(113, 46);
            this.cannybox2.TabIndex = 8;
            // 
            // canny_th_up2
            // 
            this.canny_th_up2.Font = new System.Drawing.Font("宋体", 15F);
            this.canny_th_up2.Location = new System.Drawing.Point(479, 596);
            this.canny_th_up2.Name = "canny_th_up2";
            this.canny_th_up2.Size = new System.Drawing.Size(90, 40);
            this.canny_th_up2.TabIndex = 9;
            this.canny_th_up2.Text = "up";
            this.canny_th_up2.UseVisualStyleBackColor = true;
            this.canny_th_up2.Click += new System.EventHandler(this.Canny_th_up2_Click);
            // 
            // canny_th_down2
            // 
            this.canny_th_down2.Font = new System.Drawing.Font("宋体", 15F);
            this.canny_th_down2.Location = new System.Drawing.Point(592, 596);
            this.canny_th_down2.Name = "canny_th_down2";
            this.canny_th_down2.Size = new System.Drawing.Size(90, 40);
            this.canny_th_down2.TabIndex = 10;
            this.canny_th_down2.Text = "down";
            this.canny_th_down2.UseVisualStyleBackColor = true;
            this.canny_th_down2.Click += new System.EventHandler(this.Canny_th_down2_Click);
            // 
            // imageBox3
            // 
            this.imageBox3.Location = new System.Drawing.Point(766, 519);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(720, 480);
            this.imageBox3.TabIndex = 11;
            this.imageBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 20F);
            this.label3.Location = new System.Drawing.Point(12, 672);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 34);
            this.label3.TabIndex = 12;
            this.label3.Text = "Slide\'s Size:";
            // 
            // Slide_Size
            // 
            this.Slide_Size.Font = new System.Drawing.Font("宋体", 20F);
            this.Slide_Size.Location = new System.Drawing.Point(324, 669);
            this.Slide_Size.Name = "Slide_Size";
            this.Slide_Size.Size = new System.Drawing.Size(113, 46);
            this.Slide_Size.TabIndex = 13;
            // 
            // Slide_Size_Up
            // 
            this.Slide_Size_Up.Font = new System.Drawing.Font("宋体", 15F);
            this.Slide_Size_Up.Location = new System.Drawing.Point(479, 671);
            this.Slide_Size_Up.Name = "Slide_Size_Up";
            this.Slide_Size_Up.Size = new System.Drawing.Size(90, 40);
            this.Slide_Size_Up.TabIndex = 14;
            this.Slide_Size_Up.Text = "up";
            this.Slide_Size_Up.UseVisualStyleBackColor = true;
            this.Slide_Size_Up.Click += new System.EventHandler(this.Slide_Size_Up_Click);
            // 
            // Slide_Size_Down
            // 
            this.Slide_Size_Down.Font = new System.Drawing.Font("宋体", 15F);
            this.Slide_Size_Down.Location = new System.Drawing.Point(592, 672);
            this.Slide_Size_Down.Name = "Slide_Size_Down";
            this.Slide_Size_Down.Size = new System.Drawing.Size(90, 40);
            this.Slide_Size_Down.TabIndex = 15;
            this.Slide_Size_Down.Text = "down";
            this.Slide_Size_Down.UseVisualStyleBackColor = true;
            this.Slide_Size_Down.Click += new System.EventHandler(this.Slide_Size_Down_Click);
            // 
            // imageBox4
            // 
            this.imageBox4.Location = new System.Drawing.Point(12, 796);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(314, 226);
            this.imageBox4.TabIndex = 2;
            this.imageBox4.TabStop = false;
            // 
            // filedir
            // 
            this.filedir.AutoSize = true;
            this.filedir.Font = new System.Drawing.Font("宋体", 12F);
            this.filedir.Location = new System.Drawing.Point(14, 740);
            this.filedir.Name = "filedir";
            this.filedir.Size = new System.Drawing.Size(149, 20);
            this.filedir.TabIndex = 16;
            this.filedir.Text = "文件保存路径：";
            // 
            // filedirBox
            // 
            this.filedirBox.Font = new System.Drawing.Font("宋体", 12F);
            this.filedirBox.Location = new System.Drawing.Point(158, 737);
            this.filedirBox.Name = "filedirBox";
            this.filedirBox.Size = new System.Drawing.Size(475, 30);
            this.filedirBox.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 736);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 31);
            this.button1.TabIndex = 18;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F);
            this.button2.Location = new System.Drawing.Point(507, 856);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 41);
            this.button2.TabIndex = 19;
            this.button2.Text = "确认";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(361, 796);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "物镜倍数：";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "20x",
            "40x"});
            this.comboBox1.Location = new System.Drawing.Point(476, 793);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 1055);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filedirBox);
            this.Controls.Add(this.filedir);
            this.Controls.Add(this.imageBox4);
            this.Controls.Add(this.Slide_Size_Down);
            this.Controls.Add(this.Slide_Size_Up);
            this.Controls.Add(this.Slide_Size);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.canny_th_down2);
            this.Controls.Add(this.canny_th_up2);
            this.Controls.Add(this.cannybox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.canny_th_down1);
            this.Controls.Add(this.canny_th_up1);
            this.Controls.Add(this.cannybox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cannybox1;
        private System.Windows.Forms.Button canny_th_up1;
        private System.Windows.Forms.Button canny_th_down1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cannybox2;
        private System.Windows.Forms.Button canny_th_up2;
        private System.Windows.Forms.Button canny_th_down2;
        private Emgu.CV.UI.ImageBox imageBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Slide_Size;
        private System.Windows.Forms.Button Slide_Size_Up;
        private System.Windows.Forms.Button Slide_Size_Down;
        private Emgu.CV.UI.ImageBox imageBox4;
        private System.Windows.Forms.Label filedir;
        private System.Windows.Forms.TextBox filedirBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

