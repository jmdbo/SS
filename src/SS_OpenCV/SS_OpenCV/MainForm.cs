using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace SS_OpenCV
{
    public partial class MainForm : Form
    {
        Image<Bgr, Byte> img = null; // imagem corrente
        Image<Bgr, Byte> imgUndo = null; // imagem backup - UNDO
        Image<Bgr, Byte> imgOri = null;
        ImageViewer viewer = null;
        Capture capture;
        int mouseX = 0, mouseY=0;
        string title_bak = "";

        public MainForm()
        {
            InitializeComponent();
            title_bak = Text;
            ImageViewer.SizeMode = PictureBoxSizeMode.Zoom;
            ImageViewer.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Abrir uma nova imagem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = new Image<Bgr, byte>(openFileDialog1.FileName);
                Text = title_bak + " [" +
                        openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1) +
                        "]";
                imgUndo = img.Copy();
                imgOri = img.Copy();
                ImageViewer.Image = img.Bitmap;
                ImageViewer.Refresh();
            }
        }

        /// <summary>
        /// Guardar a imagem com novo nome
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageViewer.Image.Save(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Fecha a aplicação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// repoe a ultima copia da imagem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgUndo == null) // protege de executar a função sem ainda ter aberto a imagem 
                return; 
            Cursor = Cursors.WaitCursor;
            img = imgUndo.Copy();
            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh();
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Altera o modo de vizualização
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // zoom
            if (autoZoomToolStripMenuItem.Checked)
            {
                ImageViewer.SizeMode = PictureBoxSizeMode.Zoom;
                ImageViewer.Dock = DockStyle.Fill;
            }
            else // com scroll bars
            {
                ImageViewer.Dock = DockStyle.None;
                ImageViewer.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }

        /// <summary>
        /// Mostra a janela Autores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorsForm form = new AuthorsForm();
            form.ShowDialog();
        }


        /// <summary>
        /// Converte a imagem para tons de cinzento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;
            Cursor = Cursors.WaitCursor; // cursor relogio

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.ConvertToGray(img);

            ImageViewer.Refresh(); // atualiza imagem no ecrã

            Cursor = Cursors.Default; // cursor normal
        }

        /// <summary>
        /// Efectua o negativo da imagem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;
            Cursor = Cursors.WaitCursor; // cursor relogio

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.Negative(img);

            ImageViewer.Refresh(); // atualiza imagem no ecrã

            Cursor = Cursors.Default; // cursor normal
        }

        private void fastNegativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;
            Cursor = Cursors.WaitCursor; // cursor relogio

            //copy Undo Image
            imgUndo = img.Copy();
            DateTime d1 = DateTime.Now;

            ImageClass.FastNegative(img);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void blueChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;
            Cursor = Cursors.WaitCursor; // cursor relogio

            //copy Undo Image
            imgUndo = img.Copy();
            DateTime d1 = DateTime.Now;

            ImageClass.BlueComponent(img);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void greenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;
            Cursor = Cursors.WaitCursor; // cursor relogio

            //copy Undo Image
            imgUndo = img.Copy();
            DateTime d1 = DateTime.Now;

            ImageClass.GreenComponent(img);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());

        }

        private void redChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;
            Cursor = Cursors.WaitCursor; // cursor relogio

            //copy Undo Image
            imgUndo = img.Copy();
            DateTime d1 = DateTime.Now;

            ImageClass.RedComponent(img);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());

        }

        private void translationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Dx, Dy;

            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;            

            TranslationBox frame = new TranslationBox();
            frame.ShowDialog();
            Cursor = Cursors.WaitCursor; // cursor relogio
            try
            {
                Dx = Int32.Parse(frame.DxTextBox.Text);
                Dy = Int32.Parse(frame.DyTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please insert integer values!");
                Cursor = Cursors.Default; // cursor normal
                return;
            }

            //copy Undo Image
            imgUndo = img.Copy();
            DateTime d1 = DateTime.Now;

            ImageClass.Translation(imgUndo, img, Dx, Dy);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());

        }

        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float Angle;

            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            InputBox frame = new InputBox("Rotation Angle");
            frame.ShowDialog();
            Cursor = Cursors.WaitCursor; // cursor relogio
            try
            {
                Angle = float.Parse(frame.ValueTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please insert float values!");
                Cursor = Cursors.Default; // cursor normal
                return;
            }

            //copy Undo Image
            imgUndo = img.Copy();
            DateTime d1 = DateTime.Now;

            ImageClass.Rotation(imgUndo, img, Angle);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());

        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float Zoom;

            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            InputBox frame = new InputBox("Zoom value");
            frame.ShowDialog();
            Cursor = Cursors.WaitCursor; // cursor relogio
            try
            {
                Zoom = float.Parse(frame.ValueTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please insert float values!");
                return;
            }

            //copy Undo Image
            imgUndo = img.Copy();
            DateTime d1 = DateTime.Now;

            ImageClass.Zoom(imgUndo, img, Zoom, mouseX, mouseY);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void x3MeanNoiseReductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            Cursor = Cursors.WaitCursor; // cursor relogio                                         
            imgUndo = img.Copy(); //copy Undo Image
            DateTime d1 = DateTime.Now;
            int[] matrix = new int[9] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            ImageClass.nonlinearfilter(imgUndo, img, matrix, 9, 3);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void nonUniformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] matrix;
            int weight;

            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            WeightMatrixBox frame = new WeightMatrixBox();
            if(frame.ShowDialog() == DialogResult.OK){
                Cursor = Cursors.WaitCursor; // cursor relogio 
                imgUndo = img.Copy();
                DateTime d1 = DateTime.Now;

                if (frame.comboBox1.SelectedIndex == 0)
                {
                    matrix = new int[9];
                    try
                    {
                        matrix[0] = int.Parse(frame.matrixBox17.Text);
                        matrix[1] = int.Parse(frame.matrixBox18.Text);
                        matrix[2] = int.Parse(frame.matrixBox19.Text);
                        matrix[3] = int.Parse(frame.matrixBox24.Text);
                        matrix[4] = int.Parse(frame.matrixBox25.Text);
                        matrix[5] = int.Parse(frame.matrixBox26.Text);
                        matrix[6] = int.Parse(frame.matrixBox31.Text);
                        matrix[7] = int.Parse(frame.matrixBox32.Text);
                        matrix[8] = int.Parse(frame.matrixBox33.Text);
                        weight = int.Parse(frame.weightBox.Text);
                        ImageClass.nonlinearfilter(imgUndo, img, matrix, weight, 3);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error! Coeficients must be integers!\n"+ex.Message);
                    }            


                } else if (frame.comboBox1.SelectedIndex == 1)
                {
                    try
                    {
                        matrix = new int[25];
                        matrix[0] = int.Parse(frame.matrixBox9.Text);
                        matrix[1] = int.Parse(frame.matrixBox10.Text);
                        matrix[2] = int.Parse(frame.matrixBox11.Text);
                        matrix[3] = int.Parse(frame.matrixBox12.Text);
                        matrix[4] = int.Parse(frame.matrixBox13.Text);
                        matrix[5] = int.Parse(frame.matrixBox16.Text);
                        matrix[6] = int.Parse(frame.matrixBox17.Text);
                        matrix[7] = int.Parse(frame.matrixBox18.Text);
                        matrix[8] = int.Parse(frame.matrixBox19.Text);
                        matrix[9] = int.Parse(frame.matrixBox20.Text);
                        matrix[10] = int.Parse(frame.matrixBox23.Text);
                        matrix[11] = int.Parse(frame.matrixBox24.Text);
                        matrix[12] = int.Parse(frame.matrixBox25.Text);
                        matrix[13] = int.Parse(frame.matrixBox26.Text);
                        matrix[14] = int.Parse(frame.matrixBox27.Text);
                        matrix[15] = int.Parse(frame.matrixBox30.Text);
                        matrix[16] = int.Parse(frame.matrixBox31.Text);
                        matrix[17] = int.Parse(frame.matrixBox32.Text);
                        matrix[18] = int.Parse(frame.matrixBox33.Text);
                        matrix[19] = int.Parse(frame.matrixBox34.Text);
                        matrix[20] = int.Parse(frame.matrixBox37.Text);
                        matrix[21] = int.Parse(frame.matrixBox38.Text);
                        matrix[22] = int.Parse(frame.matrixBox39.Text);
                        matrix[23] = int.Parse(frame.matrixBox40.Text);
                        matrix[24] = int.Parse(frame.matrixBox41.Text);
                        weight = int.Parse(frame.weightBox.Text);
                        ImageClass.nonlinearfilter(imgUndo, img, matrix, weight, 5);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error! Coeficients must be integers!\n" + ex.Message);
                    }
                    

                } else if (frame.comboBox1.SelectedIndex == 2)
                {
                    try
                    {
                        matrix = new int[49];
                        matrix[0] = int.Parse(frame.matrixBox1.Text);
                        matrix[1] = int.Parse(frame.matrixBox2.Text);
                        matrix[2] = int.Parse(frame.matrixBox3.Text);
                        matrix[3] = int.Parse(frame.matrixBox4.Text);
                        matrix[4] = int.Parse(frame.matrixBox5.Text);
                        matrix[5] = int.Parse(frame.matrixBox6.Text);
                        matrix[6] = int.Parse(frame.matrixBox7.Text);
                        matrix[7] = int.Parse(frame.matrixBox8.Text);
                        matrix[8] = int.Parse(frame.matrixBox9.Text);
                        matrix[9] = int.Parse(frame.matrixBox10.Text);
                        matrix[10] = int.Parse(frame.matrixBox11.Text);
                        matrix[11] = int.Parse(frame.matrixBox12.Text);
                        matrix[12] = int.Parse(frame.matrixBox13.Text);
                        matrix[13] = int.Parse(frame.matrixBox14.Text);
                        matrix[14] = int.Parse(frame.matrixBox15.Text);
                        matrix[15] = int.Parse(frame.matrixBox16.Text);
                        matrix[16] = int.Parse(frame.matrixBox17.Text);
                        matrix[17] = int.Parse(frame.matrixBox18.Text);
                        matrix[18] = int.Parse(frame.matrixBox19.Text);
                        matrix[19] = int.Parse(frame.matrixBox20.Text);
                        matrix[20] = int.Parse(frame.matrixBox21.Text);
                        matrix[21] = int.Parse(frame.matrixBox22.Text);
                        matrix[22] = int.Parse(frame.matrixBox23.Text);
                        matrix[23] = int.Parse(frame.matrixBox24.Text);
                        matrix[24] = int.Parse(frame.matrixBox25.Text);
                        matrix[25] = int.Parse(frame.matrixBox26.Text);
                        matrix[26] = int.Parse(frame.matrixBox27.Text);
                        matrix[27] = int.Parse(frame.matrixBox28.Text);
                        matrix[28] = int.Parse(frame.matrixBox29.Text);
                        matrix[29] = int.Parse(frame.matrixBox30.Text);
                        matrix[30] = int.Parse(frame.matrixBox31.Text);
                        matrix[31] = int.Parse(frame.matrixBox32.Text);
                        matrix[32] = int.Parse(frame.matrixBox33.Text);
                        matrix[33] = int.Parse(frame.matrixBox34.Text);
                        matrix[34] = int.Parse(frame.matrixBox35.Text);
                        matrix[35] = int.Parse(frame.matrixBox36.Text);
                        matrix[36] = int.Parse(frame.matrixBox37.Text);
                        matrix[37] = int.Parse(frame.matrixBox38.Text);
                        matrix[38] = int.Parse(frame.matrixBox39.Text);
                        matrix[39] = int.Parse(frame.matrixBox40.Text);
                        matrix[40] = int.Parse(frame.matrixBox41.Text);
                        matrix[41] = int.Parse(frame.matrixBox42.Text);
                        matrix[42] = int.Parse(frame.matrixBox43.Text);
                        matrix[43] = int.Parse(frame.matrixBox44.Text);
                        matrix[44] = int.Parse(frame.matrixBox45.Text);
                        matrix[45] = int.Parse(frame.matrixBox46.Text);
                        matrix[46] = int.Parse(frame.matrixBox47.Text);
                        matrix[47] = int.Parse(frame.matrixBox48.Text);
                        matrix[48] = int.Parse(frame.matrixBox49.Text);
                        weight = int.Parse(frame.weightBox.Text);
                        ImageClass.nonlinearfilter(imgUndo, img, matrix, weight, 7);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error! Coeficients must be integers!\n" + ex.Message);
                    }                    

                }
                ImageViewer.Refresh(); // atualiza imagem no ecrã
                DateTime d2 = DateTime.Now;
                Cursor = Cursors.Default; // cursor normal
                MessageBox.Show((d2 - d1).ToString());
            }            
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            Cursor = Cursors.WaitCursor; // cursor relogio                                         
            imgUndo = img.Copy(); //copy Undo Image
            DateTime d1 = DateTime.Now;
            ImageClass.sobelfilter(imgUndo, img, 3);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            Cursor = Cursors.WaitCursor; // cursor relogio                                         
            imgUndo = img.Copy(); //copy Undo Image
            DateTime d1 = DateTime.Now;
            ImageClass.medianFilter(imgUndo, img, 3);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] intensity = new int[256];
            int[] red = new int[256];
            int[] green = new int[256];
            int[] blue = new int[256];
           
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            Cursor = Cursors.WaitCursor; // cursor relogio                                         
            DateTime d1 = DateTime.Now;
            ImageClass.histogram(img, intensity, red, green, blue, 3);
            Histogram histForm = new Histogram(intensity, red, green, blue);
            histForm.Show();

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());

        }

        private void binarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CutValue;

            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            histogramToolStripMenuItem_Click(sender, e);

            InputBox frame = new InputBox("Cut value");
            frame.ShowDialog();
            Cursor = Cursors.WaitCursor; // cursor relogio
            try
            {
                CutValue = int.Parse(frame.ValueTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please insert float values!");
                return;
            }
            
            imgUndo = img.Copy(); //copy Undo Image
            DateTime d1 = DateTime.Now;
            ImageClass.binar(imgUndo, img, CutValue);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void otsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            //histogramToolStripMenuItem_Click(sender, e);

            Cursor = Cursors.WaitCursor; // cursor relogio

            imgUndo = img.Copy(); //copy Undo Image
            DateTime d1 = DateTime.Now;
            ImageClass.otsu(imgUndo, img);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void sinalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] HistY = new int[img.Height];
            int[] HistX = new int[img.Width];
            Image<Bgr, byte> imgTemp2;
            List<ComparingThread> ComparingList = new List<ComparingThread>();
            List<Thread> ThreadList = new List<Thread>();
            List<Image<Bgr, byte>> stepList = new List<Image<Bgr, byte>>();
            int xMaxPos = 0, xMinPos = 0, yMaxPos = 0, yMinPos = 0, probPos = 0;
            float maxProb = 0;

            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            Cursor = Cursors.WaitCursor; // cursor relogio                                         
            //DateTime d1 = DateTime.Now;
            Image<Bgr, byte> imgTemp = img.Copy();
            ImageClass.sinal(imgTemp);
            stepList.Add(imgTemp.Copy());
            ImageClass.projection(imgTemp, HistX, HistY, out xMaxPos, out xMinPos, out yMaxPos, out yMinPos);
            ImageClass.CropImage(imgUndo, out imgTemp, img, xMaxPos, xMinPos, yMaxPos, yMinPos);
            stepList.Add(img.Copy());
            stepList.Add(imgTemp.Copy());
            imgTemp = imgTemp.Resize(111, 111, Emgu.CV.CvEnum.INTER.CV_INTER_NN);
            stepList.Add(imgTemp.Copy());
            ImageClass.CleanupSign(imgTemp);
            stepList.Add(imgTemp.Copy());
            for (int i = 0; i < 60; i++)
            {
                if (File.Exists("C:\\dev\\SS\\Handouts\\BaseDados\\" + i.ToString() + ".png"))
                {
                    imgTemp2 = new Image<Bgr, byte>("C:\\dev\\SS\\Handouts\\BaseDados\\" + i.ToString() + ".png");
                    ComparingList.Add(new ComparingThread(imgTemp2, imgTemp, i));
                }
            }

            foreach (ComparingThread item in ComparingList)
            {
                ThreadList.Add(new Thread(new ThreadStart(item.DoWork)));
            }
            foreach (Thread tr in ThreadList)
            {
                tr.Start();
            }
            foreach (Thread tr in ThreadList)
            {
                tr.Join();
            }
            //Thread T1 = new Thread(new ThreadStart());

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // atualiza imagem no ecrã
            //DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            foreach (ComparingThread item in ComparingList)
            {
                if (item.probability > maxProb)
                {
                    probPos = item.signPos;
                    maxProb = item.probability;
                }
            }
            stepList.Add(new Image<Bgr, byte>("C:\\dev\\SS\\Handouts\\BaseDados\\" + probPos.ToString() + ".png"));
            SignForm showSteps = new SignForm(stepList);
            showSteps.Show();
            MessageBox.Show("Item: " + probPos.ToString() + "\n Probability: " + maxProb.ToString());
        }

        private void erosaoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;
            Cursor = Cursors.WaitCursor; // cursor relogio

            //copy Undo Image
            imgUndo = img.Copy();
            DateTime d1 = DateTime.Now;

            img._Dilate(3);
            img._Erode(6);
            img._Dilate(3);  

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void erodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;
            Cursor = Cursors.WaitCursor; // cursor relogio

            //copy Undo Image
            imgUndo = img.Copy();
            DateTime d1 = DateTime.Now;

            ImageClass.erode(imgUndo, img);

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());

        }

        private void dilateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;
            Cursor = Cursors.WaitCursor; // cursor relogio

            //copy Undo Image
            imgUndo = img.Copy();
            DateTime d1 = DateTime.Now;
            img._Dilate(1);
            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void projectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] HistY = new int[img.Height];
            int[] HistX = new int[img.Width];
            List<ComparingThread> ComparingList = new List<ComparingThread>();
            List<Thread> ThreadList = new List<Thread>();
            int xMaxPos = 0, xMinPos = 0, yMaxPos = 0, yMinPos = 0;      

            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            Cursor = Cursors.WaitCursor; // cursor relogio                                         
            DateTime d1 = DateTime.Now;

            ImageClass.projection(img, HistX, HistY, out xMaxPos, out xMinPos, out yMaxPos, out yMinPos);

            HistogramXY histForm = new HistogramXY(HistX, "X");
            HistogramXY histForm2 = new HistogramXY(HistY, "Y");

            histForm.Show();
            histForm2.Show();


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            
            MessageBox.Show((d2 - d1).ToString());

        }

        private void findSignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;
            Cursor = Cursors.WaitCursor; // cursor relogio

            //copy Undo Image
            imgUndo = img.Copy();
            //DateTime d1 = DateTime.Now;

            ImageClass.sinal(img);


            ImageViewer.Refresh(); // atualiza imagem no ecrã
            //DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            //MessageBox.Show((d2 - d1).ToString());



        }

        private void aula1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] intensity = new int[256];
            int[] red = new int[256];
            int[] green = new int[256];
            int[] blue = new int[256];

            if (img == null) // protege de executar a função sem ainda ter aberto a imagem 
                return;

            Cursor = Cursors.WaitCursor; // cursor relogio                                         
            DateTime d1 = DateTime.Now;
            ImageClass.histogram(img, intensity, red, green, blue, 3);
            Form CompTable = new CompressionTableForm(intensity, img);
            CompTable.Show();

            ImageViewer.Refresh(); // atualiza imagem no ecrã
            DateTime d2 = DateTime.Now;
            Cursor = Cursors.Default; // cursor normal
            MessageBox.Show((d2 - d1).ToString());
        }

        private void aula2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;

            //copy Undo Image
            imgUndo = img.Copy();

            Image<Gray, float> matrix = ImageClass.GetQuantificationMatrix(true, 100);
            Image<Ycc, float> blockYCC;



            //TableForm.ShowTableStatic(matrix,"Matriz de Quantificacao");


            Image<Ycc, float> imgYCC = img.Convert<Ycc, float>(); //Transformar o espaço de cor RGB para YCbCr

            // TODO subsampling

            //Para cada bloco de 8x8 pixéis, fazer: (Copy(new rectangle(...) ) )
            int Yblocks = (int)Math.Ceiling(img.Height / 8.0);
            int Xblocks = (int)Math.Ceiling(img.Width / 8.0);


            for (int x = 0; x < Xblocks; x++)
            {
                for (int y = 0; y < Yblocks; y++)
                {

                    Image<Gray, float> y1 = imgYCC[0].Copy(new Rectangle(x * 8, y * 8, 8, 8)); 
                    Image<Gray, float> Cr = imgYCC[1].Copy(new Rectangle(x * 8, y * 8, 8, 8)); 
                    Image<Gray, float> Cb = imgYCC[2].Copy(new Rectangle(x * 8, y * 8, 8, 8)); 

                    CvInvoke.cvDCT(y1, y1, CV_DCT_TYPE.CV_DXT_FORWARD);//cálculo da transformada de cossenos DCT
                    CvInvoke.cvDCT(Cb, Cb, CV_DCT_TYPE.CV_DXT_FORWARD);
                    CvInvoke.cvDCT(Cr, Cr, CV_DCT_TYPE.CV_DXT_FORWARD);

                    CvInvoke.cvDiv(y1, matrix, y1, 1); // quantificação dos coeficientes
                    CvInvoke.cvDiv(Cb, matrix, Cb, 1);
                    CvInvoke.cvDiv(Cr, matrix, Cr, 1);

                    ImageClass.myRound(y1); //arredondamento dos coeficientes
                    ImageClass.myRound(Cb);
                    ImageClass.myRound(Cr);

                    // DESCOMPRESSÃO

                    CvInvoke.cvMul(y1, matrix, y1, 1); // recuperação dos coeficientes (Mul)
                    CvInvoke.cvMul(Cb, matrix, Cb, 1);
                    CvInvoke.cvMul(Cr, matrix, Cr, 1);

                    CvInvoke.cvDCT(y1, y1, CV_DCT_TYPE.CV_DXT_INVERSE);//cálculo da transformada inversa de cossenos iDCT (
                    CvInvoke.cvDCT(Cb, Cb, CV_DCT_TYPE.CV_DXT_INVERSE);
                    CvInvoke.cvDCT(Cr, Cr, CV_DCT_TYPE.CV_DXT_INVERSE);

                    imgYCC.ROI = new Rectangle(x * 8, y * 8, 8, 8);


                    blockYCC = new Image<Ycc, float>(8, 8);
                    CvInvoke.cvMerge(y1, Cr, Cb, IntPtr.Zero, blockYCC);


                    blockYCC.CopyTo(imgYCC);

                    imgYCC.ROI = Rectangle.Empty;

                }
            }

            Image<Bgr, byte> imgfinal = imgYCC.Convert<Bgr, float>().Convert<Bgr, byte>();

            ShowIMG.ShowIMGStatic(img, imgfinal);


        }

        private void componentesLigadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;

            //copy Undo Image
            imgUndo = img.Copy();

            Image<Gray, int> imgFinal = ImageClass.GetConnectedComponents(img);
            ShowIMG.ShowIMGStatic(img, imgFinal);



        }

        private void fromLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (img == null)
                return;

            //copy Undo Image
            imgUndo = img.Copy();
            OpenFileDialog openMask = new OpenFileDialog();
            if (openMask.ShowDialog() == DialogResult.OK)
            {
                Image<Gray, byte> mask = new Image<Gray, byte>(openMask.FileName);

                Image<Gray, int> imgFinal = ImageClass.GetWatershedFromLabels(img, mask);
                ShowIMG.ShowIMGStatic(img, imgFinal);
            }

        }

        private void byImmersionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (img == null)
                return;

            //copy Undo Image
            imgUndo = img.Copy();

            Image<Gray, int> imgFinal = ImageClass.GetWatershedByImmersion(img);
            ShowIMG.ShowIMGStatic(img, imgFinal);
        }

        private void getGPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;

            Image<Bgr, byte> imgFinal = ImageClass.GetGPL(img);
            ShowIMG.ShowIMGStatic(img, imgFinal);
        }

        private void houghTransformsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;

            float angleSpacing = 1;
            float minAngle = 0;
            float maxAngle = 180;
            Image<Gray, float> houghImg = ImageClass.HoughTransform(img.Convert<Gray, byte>(), angleSpacing, minAngle, maxAngle);

            ShowIMG.ShowIMGStatic(img, houghImg);
        }

        private void houghLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;

            float angleSpacing = 1;
            float minAngle = 0;
            float maxAngle = 180;
            int T = 2;


            Image<Gray, float> houghImg = ImageClass.HoughTransform(img.Convert<Gray, byte>(), angleSpacing, minAngle, maxAngle);


            //  Image<Bgr, byte> img1 = null;
            Image<Bgr, byte> lines = ImageClass.ShowHoughLines(img, img, T);
            ShowIMG.ShowIMGStatic(houghImg, lines);
        }

        private void hLinesWPreprocessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;

            float angleSpacing = 1;
            float minAngle = 0;
            float maxAngle = 180;
            InputBox Threshold = new InputBox();

            Threshold.ShowDialog();
            int T = Convert.ToInt32(Threshold.ValueTextBox.Text);

            imgUndo = img.Copy();

            ImageClass.sobelfilter(imgUndo, img, 3);
            ImageClass.otsu(imgUndo, img);

            Image<Gray, float> houghImg = ImageClass.HoughTransform(img.Convert<Gray, byte>(), angleSpacing, minAngle, maxAngle);

            Image<Bgr, byte> lines = ImageClass.ShowHoughLines(img, imgOri, T);

            ShowIMG.ShowIMGStatic(img, lines);
        }

        private void circlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;

            float angleSpacing = 1;
            float minAngle = 0;
            float maxAngle = 180;
            InputBox Threshold = new InputBox();

            Threshold.ShowDialog();
            int T = Convert.ToInt32(Threshold.ValueTextBox.Text);

            imgUndo = img.Copy();

            Image<Gray, float> houghImg = ImageClass.HoughTransform(img.Convert<Gray, byte>(), angleSpacing, minAngle, maxAngle);

            Image<Bgr, byte> lines = ImageClass.ShowHoughCircles(img, imgOri, T);

           ShowIMG.ShowIMGStatic(img, lines);
        }

        private void getInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCL_Class.GetInfo();
        }

        private void multiplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCL_Class.Setup();
            OpenCL_Class.Multiply();
            OpenCL_Class.Release();
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewer = new ImageViewer(); //create an image viewer
            capture = new Capture(); //create a camera captue
            Application.Idle += ProcessFrame;
            viewer.ShowDialog(); //show the image viewer
            viewer.FormClosed += Viewer_FormClosed;
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Idle -= ProcessFrame;
            capture.Dispose();
            viewer.Dispose();

        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if(viewer!=null && capture != null)
            {
                img = capture.QueryFrame();
      
                HaarCascade haar = new HaarCascade("../../haarcascade_frontalface_default.xml");
                Image<Gray, byte> grayframe = img.Convert<Gray, byte>();
                var faces = haar.Detect(grayframe, 1.2, 3, HAAR_DETECTION_TYPE.DO_ROUGH_SEARCH, new Size(20, 20), new Size(img.Width / 2, img.Height / 2));
                foreach (var face in faces)
                {
                    img.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);
                }
                viewer.Image = img;
            }
                
        }


        private void ImageViewer_MouseClick(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }
    }
}