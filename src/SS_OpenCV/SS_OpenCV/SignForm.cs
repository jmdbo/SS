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
                buttonNext.Enabled = true;
                buttonPrevious.Enabled = true;

            }
            
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {

        }
    }
}
