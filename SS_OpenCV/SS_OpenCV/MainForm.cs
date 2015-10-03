using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;

namespace SS_OpenCV
{
    public partial class MainForm : Form
    {
        Image<Bgr, Byte> img = null; // imagem corrente
        Image<Bgr, Byte> imgUndo = null; // imagem backup - UNDO
        int mouseX = 0, mouseY=0;
        string title_bak = "";

        public MainForm()
        {
            InitializeComponent();
            title_bak = Text;
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

        private void ImageViewer_MouseClick(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }
    }
}