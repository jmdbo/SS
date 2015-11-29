using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;

namespace SS_OpenCV
{
    public partial class SignForm : Form
    {
        private List<Image<Bgr, byte>> ImgStepList;
        private int currentPos;

        public SignForm(List<Image<Bgr, byte>> imgSteps)
        {
            InitializeComponent();
            this.ImgStepList = imgSteps;
            ImageViewer.SizeMode = PictureBoxSizeMode.Zoom;
            ImageViewer.Dock = DockStyle.Fill;
            currentPos = 0;
            if(ImgStepList.Count != 0)
            {
                ImageViewer.Image = ImgStepList.ElementAt(0).Bitmap;
                ImageViewer.Refresh();
                buttonNext.Enabled = true;
                buttonPrevious.Enabled = false;

            }
            
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            currentPos--;
            ImageViewer.Image = ImgStepList.ElementAt(currentPos).Bitmap;
            ImageViewer.Refresh();
            if(currentPos == 0)
            {
                buttonPrevious.Enabled = false;
            }
            buttonNext.Enabled = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            currentPos++;
            ImageViewer.Image = ImgStepList.ElementAt(currentPos).Bitmap;
            ImageViewer.Refresh();
            if (currentPos == ImgStepList.Count-1)
            {
                buttonNext.Enabled = false;
            }
            buttonPrevious.Enabled = true;
        }
    }
}
