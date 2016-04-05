using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace SS_OpenCV
{
    public partial class CompressionTableForm : Form
    {
        Image<Bgr, byte> workImage;
        int[] table;
        string[] noCompression = new string[256];
        string[] huffman = new string[256];
        string[] shannon_fano = new string[256];

        /// <summary>
        /// Reveives histogram and the image
        /// </summary>
        /// <param name="_histogram"></param>
        /// <param name="_workImage"></param>
        public CompressionTableForm(int[] _histogram, Image<Bgr, byte> _workImage)
        {
            InitializeComponent();

            table = _histogram;
			workImage = _workImage;

			dataGridView1.Rows.Add(256);

			for(int i = 0; i < 256; i++)
			{
				dataGridView1.Rows[i].Cells[0].Value = i;
				dataGridView1.Rows[i].Cells[1].Value = table[i];

				dataGridView1.Rows[i].Cells[2].Value = "";
				dataGridView1.Rows[i].Cells[3].Value = "";
				dataGridView1.Rows[i].Cells[4].Value = "";
			
			}

        }

        private void button1_Click(object sender, EventArgs e)
        {
          	// fill Crompression table struture with interface data
			int idx;
			for(int i = 0; i < 256; i++)
			{
				idx = ((int)dataGridView1.Rows[i].Cells[0].Value);
				noCompression[idx] = dataGridView1.Rows[i].Cells[2].Value.ToString();
				huffman[idx] = dataGridView1.Rows[i].Cells[3].Value.ToString();
				shannon_fano[idx] = dataGridView1.Rows[i].Cells[4].Value.ToString();

			}

			imageTextBox.Text = CompressImage(workImage, noCompression);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // fill Crompression table struture with interface data
            int idx;
            for (int i = 0; i < 256; i++)
            {
                idx = ((int)dataGridView1.Rows[i].Cells[0].Value);
                noCompression[idx] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                huffman[idx] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                shannon_fano[idx] = dataGridView1.Rows[i].Cells[4].Value.ToString();

            }

            imageTextBox.Text = CompressImage(workImage, huffman);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // fill Crompression table struture with interface data
            int idx;
            for (int i = 0; i < 256; i++)
            {
                idx = ((int)dataGridView1.Rows[i].Cells[0].Value);
                noCompression[idx] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                huffman[idx] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                shannon_fano[idx] = dataGridView1.Rows[i].Cells[4].Value.ToString();

            }

            imageTextBox.Text = CompressImage(workImage, shannon_fano);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // count strings length * histogram count
            int countN = 0, countH = 0, countS = 0;
            for (int i = 0; i < 256; i++)
            {
                countN += ((int)dataGridView1.Rows[i].Cells[1].Value) * ((int)dataGridView1.Rows[i].Cells[2].Value.ToString().Length);
                countH += ((int)dataGridView1.Rows[i].Cells[1].Value) * ((int)dataGridView1.Rows[i].Cells[3].Value.ToString().Length);
                countS += ((int)dataGridView1.Rows[i].Cells[1].Value) * ((int)dataGridView1.Rows[i].Cells[4].Value.ToString().Length);
            }
            textBox2.Text = countN.ToString();
            textBox3.Text = countH.ToString();
            textBox4.Text = countS.ToString();
        }        
        
        /// <summary>
        /// image generation
        /// </summary>
        /// <param name="workImage"></param>
        /// <param name="coding"></param>
        /// <returns></returns>
        private string CompressImage(Image<Bgr,byte> workImage, string[] coding)
        {
            string imageStr = "";

            for (int i = 0; i < workImage.Height; i++)
            {
                for (int j = 0; j < workImage.Width; j++)
                {
                    imageStr += coding[(int) workImage[i, j].Blue];
                }
            }

            return imageStr;
        }

            
    
    }
}
