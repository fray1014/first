namespace SpectrumToolset.DrawRectForm
{
    partial class FullSlideScanShowPercentage
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PbTempProg = new System.Windows.Forms.ProgressBar();
            this.PbTotalProg = new System.Windows.Forms.ProgressBar();
            this.LTempProg = new System.Windows.Forms.Label();
            this.LTotalProg = new System.Windows.Forms.Label();
            this.LTotalProgText = new System.Windows.Forms.Label();
            this.LTempProgText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "总进度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前玻片";
            // 
            // PbTempProg
            // 
            this.PbTempProg.Location = new System.Drawing.Point(78, 51);
            this.PbTempProg.Name = "PbTempProg";
            this.PbTempProg.Size = new System.Drawing.Size(319, 23);
            this.PbTempProg.TabIndex = 2;
            // 
            // PbTotalProg
            // 
            this.PbTotalProg.Location = new System.Drawing.Point(78, 13);
            this.PbTotalProg.Name = "PbTotalProg";
            this.PbTotalProg.Size = new System.Drawing.Size(319, 23);
            this.PbTotalProg.TabIndex = 3;
            // 
            // LTempProg
            // 
            this.LTempProg.AutoSize = true;
            this.LTempProg.Location = new System.Drawing.Point(404, 56);
            this.LTempProg.Name = "LTempProg";
            this.LTempProg.Size = new System.Drawing.Size(35, 12);
            this.LTempProg.TabIndex = 5;
            this.LTempProg.Text = "0.00%";
            // 
            // LTotalProg
            // 
            this.LTotalProg.AutoSize = true;
            this.LTotalProg.Location = new System.Drawing.Point(404, 19);
            this.LTotalProg.Name = "LTotalProg";
            this.LTotalProg.Size = new System.Drawing.Size(35, 12);
            this.LTotalProg.TabIndex = 4;
            this.LTotalProg.Text = "0.00%";
            // 
            // LTotalProgText
            // 
            this.LTotalProgText.AutoSize = true;
            this.LTotalProgText.Location = new System.Drawing.Point(452, 19);
            this.LTotalProgText.Name = "LTotalProgText";
            this.LTotalProgText.Size = new System.Drawing.Size(0, 12);
            this.LTotalProgText.TabIndex = 6;
            // 
            // LTempProgText
            // 
            this.LTempProgText.AutoSize = true;
            this.LTempProgText.Location = new System.Drawing.Point(452, 55);
            this.LTempProgText.Name = "LTempProgText";
            this.LTempProgText.Size = new System.Drawing.Size(0, 12);
            this.LTempProgText.TabIndex = 7;
            // 
            // FullSlideScanShowPercentage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 86);
            this.Controls.Add(this.LTempProgText);
            this.Controls.Add(this.LTotalProgText);
            this.Controls.Add(this.LTempProg);
            this.Controls.Add(this.LTotalProg);
            this.Controls.Add(this.PbTotalProg);
            this.Controls.Add(this.PbTempProg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FullSlideScanShowPercentage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫描进度";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar PbTempProg;
        private System.Windows.Forms.ProgressBar PbTotalProg;
        private System.Windows.Forms.Label LTempProg;
        private System.Windows.Forms.Label LTotalProg;
        private System.Windows.Forms.Label LTotalProgText;
        private System.Windows.Forms.Label LTempProgText;
    }
}