using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace drawRect
{
    public partial class DrawRectSetName : Form
    {
        public string[] setnames = new string[4];

        string defaultdir;
        string defaultname;
        string[] defaultnames = new string[4];
        bool[] choices = new bool[4];
        bool[] allPass = new bool[4];

        public DrawRectSetName(string filedir, string filename, bool[] choices)
        {
            InitializeComponent();

            this.defaultdir = filedir;
            this.defaultname = filename;
            this.choices = choices;

            for (int i = 0; i < 4; i++)
            {
                allPass[i] = false;
                defaultnames[i] = defaultname + "_" + i.ToString();
                setnames[i] = defaultname + "_" + i.ToString();
            }
        }

        private void DrawRectSetName_Load(object sender, EventArgs e)
        {
            slideName1.Enabled = this.choices[0];
            slideName2.Enabled = this.choices[1];
            slideName3.Enabled = this.choices[2];
            slideName4.Enabled = this.choices[3];

            pictureBox1.Enabled = this.choices[0];
            pictureBox2.Enabled = this.choices[1];
            pictureBox3.Enabled = this.choices[2];
            pictureBox4.Enabled = this.choices[3];

            btnDefaultName_Click(sender, e);

        }

        private void btnDefaultName_Click(object sender, EventArgs e)
        {
            if (choices[0]) slideName1.Text = defaultnames[0];
            if (choices[1]) slideName2.Text = defaultnames[1];
            if (choices[2]) slideName3.Text = defaultnames[2];
            if (choices[3]) slideName4.Text = defaultnames[3];
        }

        private void btnSetOK_Click(object sender, EventArgs e)
        {
            //allpass == true when dup
            //choice == true when enable
            bool isOk4Close = true;
            for (int i = 0; i < 4; i++)
            {
                if (choices[i])
                {
                    if (!allPass[i]) isOk4Close = true;
                    else
                    {
                        isOk4Close = false;
                        break;
                    }
                }
            }

            if (isOk4Close)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("文件名重名");
            }
        }

        private void slideName1_TextChanged(object sender, EventArgs e)
        {
            if (choices[0])
            {
                setnames[0] = slideName1.Text;
                allPass[0] = isFileExist(slideName1.Text);
                if (allPass[0]) pictureBox1.Image = Resource1.cross;
                else
                    pictureBox1.Image = Resource1.sign;
            }
        }

        private void slideName2_TextChanged(object sender, EventArgs e)
        {
            if (choices[1])
            {
                setnames[1] = slideName2.Text;
                allPass[1] = isFileExist(slideName2.Text);
                if (allPass[1]) pictureBox2.Image = Resource1.cross;
                else
                    pictureBox2.Image = Resource1.sign;
            }
        }

        private void slideName3_TextChanged(object sender, EventArgs e)
        {
            if (choices[2])
            {
                setnames[2] = slideName3.Text;
                allPass[2] = isFileExist(slideName3.Text);
                if (allPass[2]) pictureBox3.Image = Resource1.cross;
                else
                    pictureBox3.Image = Resource1.sign;
            }
        }

        private void slideName4_TextChanged(object sender, EventArgs e)
        {
            if (choices[3])
            {
                setnames[3] = slideName4.Text;
                allPass[3] = isFileExist(slideName4.Text);
                if (allPass[3]) pictureBox4.Image = Resource1.cross;
                else
                    pictureBox4.Image = Resource1.sign;
            }
        }


        private bool isFileExist(string filename)
        {
            bool isDup = false;

            foreach (FileInfo fs in new DirectoryInfo(this.defaultdir).GetFiles("*.dsc"))
            {
                string tfs = Path.GetFileNameWithoutExtension(fs.Name);
                if (tfs == filename)
                {
                    isDup = true;
                    break;
                }
                else
                {
                    isDup = false;
                }
            }

            return isDup;
        }
    }
}
