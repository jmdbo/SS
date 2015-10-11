using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SS_OpenCV
{
    public partial class WeightMatrixBox : Form
    {
        public WeightMatrixBox()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                matrixBox1.Visible = false;
                matrixBox2.Visible = false;
                matrixBox3.Visible = false;
                matrixBox4.Visible = false;
                matrixBox5.Visible = false;
                matrixBox6.Visible = false;
                matrixBox7.Visible = false;
                matrixBox8.Visible = false;
                matrixBox9.Visible = false;
                matrixBox10.Visible = false;
                matrixBox11.Visible = false;
                matrixBox12.Visible = false;
                matrixBox13.Visible = false;
                matrixBox14.Visible = false;
                matrixBox15.Visible = false;
                matrixBox16.Visible = false;

                matrixBox17.Visible = true;
                matrixBox18.Visible = true;
                matrixBox19.Visible = true;

                matrixBox20.Visible = false;
                matrixBox21.Visible = false;
                matrixBox22.Visible = false;
                matrixBox23.Visible = false;

                matrixBox24.Visible = true;
                matrixBox25.Visible = true;
                matrixBox26.Visible = true;

                matrixBox27.Visible = false;
                matrixBox28.Visible = false;
                matrixBox29.Visible = false;
                matrixBox30.Visible = false;

                matrixBox31.Visible = true;
                matrixBox32.Visible = true;
                matrixBox33.Visible = true;

                matrixBox34.Visible = false;
                matrixBox35.Visible = false;
                matrixBox36.Visible = false;
                matrixBox37.Visible = false;
                matrixBox38.Visible = false;
                matrixBox39.Visible = false;
                matrixBox40.Visible = false;
                matrixBox41.Visible = false;
                matrixBox42.Visible = false;
                matrixBox43.Visible = false;
                matrixBox44.Visible = false;
                matrixBox45.Visible = false;
                matrixBox46.Visible = false;
                matrixBox47.Visible = false;
                matrixBox48.Visible = false;
                matrixBox49.Visible = false;          
                
            } else if (comboBox1.SelectedIndex == 1)
            {
                matrixBox1.Visible = false;
                matrixBox2.Visible = false;
                matrixBox3.Visible = false;
                matrixBox4.Visible = false;
                matrixBox5.Visible = false;
                matrixBox6.Visible = false;
                matrixBox7.Visible = false;
                matrixBox8.Visible = false;

                matrixBox9.Visible = true;
                matrixBox10.Visible = true;
                matrixBox11.Visible = true;
                matrixBox12.Visible = true;
                matrixBox13.Visible = true;

                matrixBox14.Visible = false;
                matrixBox15.Visible = false;

                matrixBox16.Visible = true;
                matrixBox17.Visible = true;
                matrixBox18.Visible = true;
                matrixBox19.Visible = true;
                matrixBox20.Visible = true;

                matrixBox21.Visible = false;
                matrixBox22.Visible = false;

                matrixBox23.Visible = true;
                matrixBox24.Visible = true;
                matrixBox25.Visible = true;
                matrixBox26.Visible = true;
                matrixBox27.Visible = true;

                matrixBox28.Visible = false;
                matrixBox29.Visible = false;

                matrixBox30.Visible = true;
                matrixBox31.Visible = true;
                matrixBox32.Visible = true;
                matrixBox33.Visible = true;
                matrixBox34.Visible = true;

                matrixBox35.Visible = false;
                matrixBox36.Visible = false;

                matrixBox37.Visible = true;
                matrixBox38.Visible = true;
                matrixBox39.Visible = true;
                matrixBox40.Visible = true;
                matrixBox41.Visible = true;

                matrixBox42.Visible = false;
                matrixBox43.Visible = false;
                matrixBox44.Visible = false;
                matrixBox45.Visible = false;
                matrixBox46.Visible = false;
                matrixBox47.Visible = false;
                matrixBox48.Visible = false;
                matrixBox49.Visible = false;

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                matrixBox1.Visible = true;
                matrixBox2.Visible = true;
                matrixBox3.Visible = true;
                matrixBox4.Visible = true;
                matrixBox5.Visible = true;
                matrixBox6.Visible = true;
                matrixBox7.Visible = true;
                matrixBox8.Visible = true;

                matrixBox9.Visible = true;
                matrixBox10.Visible = true;
                matrixBox11.Visible = true;
                matrixBox12.Visible = true;
                matrixBox13.Visible = true;

                matrixBox14.Visible = true;
                matrixBox15.Visible = true;

                matrixBox16.Visible = true;
                matrixBox17.Visible = true;
                matrixBox18.Visible = true;
                matrixBox19.Visible = true;
                matrixBox20.Visible = true;

                matrixBox21.Visible = true;
                matrixBox22.Visible = true;

                matrixBox23.Visible = true;
                matrixBox24.Visible = true;
                matrixBox25.Visible = true;
                matrixBox26.Visible = true;
                matrixBox27.Visible = true;

                matrixBox28.Visible = true;
                matrixBox29.Visible = true;

                matrixBox30.Visible = true;
                matrixBox31.Visible = true;
                matrixBox32.Visible = true;
                matrixBox33.Visible = true;
                matrixBox34.Visible = true;

                matrixBox35.Visible = true;
                matrixBox36.Visible = true;

                matrixBox37.Visible = true;
                matrixBox38.Visible = true;
                matrixBox39.Visible = true;
                matrixBox40.Visible = true;
                matrixBox41.Visible = true;

                matrixBox42.Visible = true;
                matrixBox43.Visible = true;
                matrixBox44.Visible = true;
                matrixBox45.Visible = true;
                matrixBox46.Visible = true;
                matrixBox47.Visible = true;
                matrixBox48.Visible = true;
                matrixBox49.Visible = true;

            }
        }
    }
}
