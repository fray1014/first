using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpectrumToolset.DrawRectForm
{
    public partial class FullSlideScanShowPercentage : Form
    {
        public long cumuTotalPoints;
        public long cumuTempPoints;
        public long currTotalPoints;
        public long currTempPoints;

        Form thisForm;

        public FullSlideScanShowPercentage(Int32 totalPoints)
        {
            InitializeComponent();
            thisForm = this;
            cumuTotalPoints = totalPoints;
            cumuTempPoints = 0;
            currTotalPoints = 0;
            currTempPoints = 0;
        }

        public int UpdatePoints(bool isSwitch, Int32 totalPoints)
        {

            cumuTempPoints += 1;
            if (isSwitch)
            {
                currTempPoints = 0;
                InfoPanelUtil.MyConsoleWrite(ref thisForm, "currTempPoints = 0 ");
            }
            else currTempPoints += 1;

            currTotalPoints = totalPoints;


            return RefreshUI();
        }

        public int RefreshUI()
        {
            int retVal = 0;

            // if enter blank scan, will more than 100.00
            //if (cumuProg >= 100.00) cumuProg = 100.00;
            //if (currProg >= 100.00) currProg = 100.00;
            //if (cumuTempPoints > cumuTotalPoints)
            //{
            //    cumuTempPoints = cumuTotalPoints;
            //}
            //if (currTempPoints > currTotalPoints)
            //{
            //    currTempPoints = currTotalPoints;
            //}

            double cumuProg = (double)cumuTempPoints * 100 / (double)cumuTotalPoints;
            double currProg = (double)currTempPoints * 100 / (double)currTotalPoints;

            
            LTotalProg.Text = cumuProg.ToString("f2") + "%";
            LTempProg.Text = currProg.ToString("f2") + "%";
            LTotalProgText.Text = cumuTempPoints.ToString() + "/" + cumuTotalPoints.ToString();
            LTempProgText.Text = currTempPoints.ToString() + "/" + currTotalPoints.ToString();

            PbTotalProg.Value = (int)cumuProg;
            PbTempProg.Value = (int)currProg;

            this.Refresh();
            return retVal;

        }
    }
}
