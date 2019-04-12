namespace cam2
{
    partial class roiDetection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(roiDetection));
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cannyBox1 = new System.Windows.Forms.TextBox();
            this.canny_th_up1 = new System.Windows.Forms.Button();
            this.canny_th_down1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cannyBox2 = new System.Windows.Forms.TextBox();
            this.canny_th_up2 = new System.Windows.Forms.Button();
            this.canny_th_down2 = new System.Windows.Forms.Button();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.label3 = new System.Windows.Forms.Label();
            this.slideMinSize = new System.Windows.Forms.TextBox();
            this.Slide_Size_Up = new System.Windows.Forms.Button();
            this.Slide_Size_Down = new System.Windows.Forms.Button();
            this.filedir = new System.Windows.Forms.Label();
            this.filedirBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.canThBar1 = new System.Windows.Forms.TrackBar();
            this.canThBar2 = new System.Windows.Forms.TrackBar();
            this.slideMinSizeBar = new System.Windows.Forms.TrackBar();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.roiMaxSizeBar = new System.Windows.Forms.TrackBar();
            this.roiSizeDown = new System.Windows.Forms.Button();
            this.roiSizeUp = new System.Windows.Forms.Button();
            this.roiMaxSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.roiMinSizeBar = new System.Windows.Forms.TrackBar();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.roiMinSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.slideMaxSizeBar = new System.Windows.Forms.TrackBar();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.slideMaxSize = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canThBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canThBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideMinSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roiMaxSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roiMinSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideMaxSizeBar)).BeginInit();
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
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(12, 516);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Canny Thresh1:";
            // 
            // cannyBox1
            // 
            this.cannyBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.cannyBox1.Location = new System.Drawing.Point(186, 513);
            this.cannyBox1.Name = "cannyBox1";
            this.cannyBox1.Size = new System.Drawing.Size(113, 30);
            this.cannyBox1.TabIndex = 4;
            // 
            // canny_th_up1
            // 
            this.canny_th_up1.Font = new System.Drawing.Font("宋体", 12F);
            this.canny_th_up1.Location = new System.Drawing.Point(328, 511);
            this.canny_th_up1.Name = "canny_th_up1";
            this.canny_th_up1.Size = new System.Drawing.Size(60, 30);
            this.canny_th_up1.TabIndex = 5;
            this.canny_th_up1.Text = "up";
            this.canny_th_up1.UseVisualStyleBackColor = true;
            this.canny_th_up1.Click += new System.EventHandler(this.Canny_th_up_Click);
            // 
            // canny_th_down1
            // 
            this.canny_th_down1.Font = new System.Drawing.Font("宋体", 12F);
            this.canny_th_down1.Location = new System.Drawing.Point(394, 511);
            this.canny_th_down1.Name = "canny_th_down1";
            this.canny_th_down1.Size = new System.Drawing.Size(60, 30);
            this.canny_th_down1.TabIndex = 6;
            this.canny_th_down1.Text = "down";
            this.canny_th_down1.UseVisualStyleBackColor = true;
            this.canny_th_down1.Click += new System.EventHandler(this.Canny_th_down_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(12, 564);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Canny Thresh2:";
            // 
            // cannyBox2
            // 
            this.cannyBox2.Font = new System.Drawing.Font("宋体", 12F);
            this.cannyBox2.Location = new System.Drawing.Point(187, 561);
            this.cannyBox2.Name = "cannyBox2";
            this.cannyBox2.Size = new System.Drawing.Size(113, 30);
            this.cannyBox2.TabIndex = 8;
            // 
            // canny_th_up2
            // 
            this.canny_th_up2.Font = new System.Drawing.Font("宋体", 12F);
            this.canny_th_up2.Location = new System.Drawing.Point(329, 559);
            this.canny_th_up2.Name = "canny_th_up2";
            this.canny_th_up2.Size = new System.Drawing.Size(60, 30);
            this.canny_th_up2.TabIndex = 9;
            this.canny_th_up2.Text = "up";
            this.canny_th_up2.UseVisualStyleBackColor = true;
            this.canny_th_up2.Click += new System.EventHandler(this.Canny_th_up2_Click);
            // 
            // canny_th_down2
            // 
            this.canny_th_down2.Font = new System.Drawing.Font("宋体", 12F);
            this.canny_th_down2.Location = new System.Drawing.Point(395, 559);
            this.canny_th_down2.Name = "canny_th_down2";
            this.canny_th_down2.Size = new System.Drawing.Size(60, 30);
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
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(13, 615);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Slide Min Size:";
            // 
            // slideMinSize
            // 
            this.slideMinSize.Font = new System.Drawing.Font("宋体", 12F);
            this.slideMinSize.Location = new System.Drawing.Point(187, 612);
            this.slideMinSize.Name = "slideMinSize";
            this.slideMinSize.Size = new System.Drawing.Size(113, 30);
            this.slideMinSize.TabIndex = 13;
            // 
            // Slide_Size_Up
            // 
            this.Slide_Size_Up.Font = new System.Drawing.Font("宋体", 12F);
            this.Slide_Size_Up.Location = new System.Drawing.Point(329, 610);
            this.Slide_Size_Up.Name = "Slide_Size_Up";
            this.Slide_Size_Up.Size = new System.Drawing.Size(60, 30);
            this.Slide_Size_Up.TabIndex = 14;
            this.Slide_Size_Up.Text = "up";
            this.Slide_Size_Up.UseVisualStyleBackColor = true;
            this.Slide_Size_Up.Click += new System.EventHandler(this.Slide_Size_Up_Click);
            // 
            // Slide_Size_Down
            // 
            this.Slide_Size_Down.Font = new System.Drawing.Font("宋体", 12F);
            this.Slide_Size_Down.Location = new System.Drawing.Point(395, 610);
            this.Slide_Size_Down.Name = "Slide_Size_Down";
            this.Slide_Size_Down.Size = new System.Drawing.Size(60, 30);
            this.Slide_Size_Down.TabIndex = 15;
            this.Slide_Size_Down.Text = "down";
            this.Slide_Size_Down.UseVisualStyleBackColor = true;
            this.Slide_Size_Down.Click += new System.EventHandler(this.Slide_Size_Down_Click);
            // 
            // filedir
            // 
            this.filedir.AutoSize = true;
            this.filedir.Font = new System.Drawing.Font("宋体", 12F);
            this.filedir.Location = new System.Drawing.Point(13, 828);
            this.filedir.Name = "filedir";
            this.filedir.Size = new System.Drawing.Size(149, 20);
            this.filedir.TabIndex = 16;
            this.filedir.Text = "文件保存路径：";
            // 
            // filedirBox
            // 
            this.filedirBox.Font = new System.Drawing.Font("宋体", 12F);
            this.filedirBox.Location = new System.Drawing.Point(157, 825);
            this.filedirBox.Name = "filedirBox";
            this.filedirBox.Size = new System.Drawing.Size(475, 30);
            this.filedirBox.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(638, 824);
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
            this.button2.Location = new System.Drawing.Point(501, 876);
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
            this.label4.Location = new System.Drawing.Point(14, 879);
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
            this.comboBox1.Location = new System.Drawing.Point(130, 876);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 28);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 12F);
            this.button3.Location = new System.Drawing.Point(306, 876);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 41);
            this.button3.TabIndex = 22;
            this.button3.Text = "开始扫描";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // canThBar1
            // 
            this.canThBar1.Location = new System.Drawing.Point(460, 513);
            this.canThBar1.Name = "canThBar1";
            this.canThBar1.Size = new System.Drawing.Size(272, 56);
            this.canThBar1.TabIndex = 23;
            this.canThBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.canThBar1.Scroll += new System.EventHandler(this.canThBar1_Scroll);
            // 
            // canThBar2
            // 
            this.canThBar2.Location = new System.Drawing.Point(461, 559);
            this.canThBar2.Name = "canThBar2";
            this.canThBar2.Size = new System.Drawing.Size(272, 56);
            this.canThBar2.TabIndex = 24;
            this.canThBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.canThBar2.Scroll += new System.EventHandler(this.canThBar2_Scroll);
            // 
            // slideMinSizeBar
            // 
            this.slideMinSizeBar.Location = new System.Drawing.Point(461, 610);
            this.slideMinSizeBar.Name = "slideMinSizeBar";
            this.slideMinSizeBar.Size = new System.Drawing.Size(272, 56);
            this.slideMinSizeBar.TabIndex = 25;
            this.slideMinSizeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slideMinSizeBar.Scroll += new System.EventHandler(this.slideSizeBar_Scroll);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 12F);
            this.button4.Location = new System.Drawing.Point(306, 947);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 41);
            this.button4.TabIndex = 26;
            this.button4.Text = "停止扫描";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox2.Location = new System.Drawing.Point(130, 919);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(102, 28);
            this.comboBox2.TabIndex = 27;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(14, 922);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "扫描个数：";
            // 
            // roiMaxSizeBar
            // 
            this.roiMaxSizeBar.Location = new System.Drawing.Point(462, 760);
            this.roiMaxSizeBar.Name = "roiMaxSizeBar";
            this.roiMaxSizeBar.Size = new System.Drawing.Size(272, 56);
            this.roiMaxSizeBar.TabIndex = 33;
            this.roiMaxSizeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.roiMaxSizeBar.Scroll += new System.EventHandler(this.roiSizeBar_Scroll);
            // 
            // roiSizeDown
            // 
            this.roiSizeDown.Font = new System.Drawing.Font("宋体", 12F);
            this.roiSizeDown.Location = new System.Drawing.Point(396, 760);
            this.roiSizeDown.Name = "roiSizeDown";
            this.roiSizeDown.Size = new System.Drawing.Size(60, 30);
            this.roiSizeDown.TabIndex = 32;
            this.roiSizeDown.Text = "down";
            this.roiSizeDown.UseVisualStyleBackColor = true;
            this.roiSizeDown.Click += new System.EventHandler(this.roiSizeDown_Click);
            // 
            // roiSizeUp
            // 
            this.roiSizeUp.Font = new System.Drawing.Font("宋体", 12F);
            this.roiSizeUp.Location = new System.Drawing.Point(330, 760);
            this.roiSizeUp.Name = "roiSizeUp";
            this.roiSizeUp.Size = new System.Drawing.Size(60, 30);
            this.roiSizeUp.TabIndex = 31;
            this.roiSizeUp.Text = "up";
            this.roiSizeUp.UseVisualStyleBackColor = true;
            this.roiSizeUp.Click += new System.EventHandler(this.roiSizeUp_Click);
            // 
            // roiMaxSize
            // 
            this.roiMaxSize.Font = new System.Drawing.Font("宋体", 12F);
            this.roiMaxSize.Location = new System.Drawing.Point(188, 762);
            this.roiMaxSize.Name = "roiMaxSize";
            this.roiMaxSize.Size = new System.Drawing.Size(113, 30);
            this.roiMaxSize.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(14, 765);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Roi Max Size:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(14, 963);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "区域个数：";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBox3.Location = new System.Drawing.Point(130, 960);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(102, 28);
            this.comboBox3.TabIndex = 34;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // roiMinSizeBar
            // 
            this.roiMinSizeBar.Location = new System.Drawing.Point(461, 709);
            this.roiMinSizeBar.Name = "roiMinSizeBar";
            this.roiMinSizeBar.Size = new System.Drawing.Size(272, 56);
            this.roiMinSizeBar.TabIndex = 45;
            this.roiMinSizeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.roiMinSizeBar.Scroll += new System.EventHandler(this.roiMinSizeBar_Scroll);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 12F);
            this.button5.Location = new System.Drawing.Point(395, 709);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 30);
            this.button5.TabIndex = 44;
            this.button5.Text = "down";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("宋体", 12F);
            this.button6.Location = new System.Drawing.Point(329, 709);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 30);
            this.button6.TabIndex = 43;
            this.button6.Text = "up";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // roiMinSize
            // 
            this.roiMinSize.Font = new System.Drawing.Font("宋体", 12F);
            this.roiMinSize.Location = new System.Drawing.Point(187, 711);
            this.roiMinSize.Name = "roiMinSize";
            this.roiMinSize.Size = new System.Drawing.Size(113, 30);
            this.roiMinSize.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(13, 714);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Roi Min Size:";
            // 
            // slideMaxSizeBar
            // 
            this.slideMaxSizeBar.Location = new System.Drawing.Point(461, 661);
            this.slideMaxSizeBar.Name = "slideMaxSizeBar";
            this.slideMaxSizeBar.Size = new System.Drawing.Size(272, 56);
            this.slideMaxSizeBar.TabIndex = 40;
            this.slideMaxSizeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slideMaxSizeBar.Scroll += new System.EventHandler(this.slideMaxSizeBar_Scroll);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("宋体", 12F);
            this.button7.Location = new System.Drawing.Point(395, 661);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 30);
            this.button7.TabIndex = 39;
            this.button7.Text = "down";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("宋体", 12F);
            this.button8.Location = new System.Drawing.Point(329, 661);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(60, 30);
            this.button8.TabIndex = 38;
            this.button8.Text = "up";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // slideMaxSize
            // 
            this.slideMaxSize.Font = new System.Drawing.Font("宋体", 12F);
            this.slideMaxSize.Location = new System.Drawing.Point(187, 663);
            this.slideMaxSize.Name = "slideMaxSize";
            this.slideMaxSize.Size = new System.Drawing.Size(113, 30);
            this.slideMaxSize.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(13, 666);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 20);
            this.label9.TabIndex = 36;
            this.label9.Text = "Slide Max Size:";
            // 
            // roiDetection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1532, 1055);
            this.Controls.Add(this.roiMaxSizeBar);
            this.Controls.Add(this.roiMinSizeBar);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.roiMinSize);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.slideMaxSizeBar);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.slideMaxSize);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.roiSizeDown);
            this.Controls.Add(this.roiSizeUp);
            this.Controls.Add(this.roiMaxSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.slideMinSizeBar);
            this.Controls.Add(this.canThBar2);
            this.Controls.Add(this.canThBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filedirBox);
            this.Controls.Add(this.filedir);
            this.Controls.Add(this.Slide_Size_Down);
            this.Controls.Add(this.Slide_Size_Up);
            this.Controls.Add(this.slideMinSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.canny_th_down2);
            this.Controls.Add(this.canny_th_up2);
            this.Controls.Add(this.cannyBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.canny_th_down1);
            this.Controls.Add(this.canny_th_up1);
            this.Controls.Add(this.cannyBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "roiDetection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Roi Detection";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canThBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canThBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideMinSizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roiMaxSizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roiMinSizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideMaxSizeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cannyBox1;
        private System.Windows.Forms.Button canny_th_up1;
        private System.Windows.Forms.Button canny_th_down1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cannyBox2;
        private System.Windows.Forms.Button canny_th_up2;
        private System.Windows.Forms.Button canny_th_down2;
        private Emgu.CV.UI.ImageBox imageBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox slideMinSize;
        private System.Windows.Forms.Button Slide_Size_Up;
        private System.Windows.Forms.Button Slide_Size_Down;
        private System.Windows.Forms.Label filedir;
        private System.Windows.Forms.TextBox filedirBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TrackBar canThBar1;
        private System.Windows.Forms.TrackBar canThBar2;
        private System.Windows.Forms.TrackBar slideMinSizeBar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar roiMaxSizeBar;
        private System.Windows.Forms.Button roiSizeDown;
        private System.Windows.Forms.Button roiSizeUp;
        private System.Windows.Forms.TextBox roiMaxSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TrackBar roiMinSizeBar;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox roiMinSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar slideMaxSizeBar;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox slideMaxSize;
        private System.Windows.Forms.Label label9;
    }
}

