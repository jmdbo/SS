using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace SS_OpenCV
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();

        }
        public static void ShowTableStatic(Image<Gray, byte> _data, string Title)
        {
            TableForm form = new TableForm();

            if (form.checkBox1.Checked)
                return;
            form.Text = "Table - " + Title;

            // Create the output table.
            DataTable d = new DataTable();

            // Loop through all process names.
            for (int i = 0; i < _data.Width; i++)
            {
                // Add the program name to our columns.
                d.Columns.Add(i.ToString());
            }

            for (int i = 0; i < _data.Height; i++)
            {
                d.Rows.Add();

                for (int j = 0; j < _data.Width; j++)
                {
                    // Add the program name to our columns.
                    d.Rows[i][j] = ((Gray)_data[i, j]).Intensity.ToString();
                }


            }

            form.dataGridView1.DataSource = d;

            for (int i = 0; i < _data.Width; i++)
            {
                form.dataGridView1.Columns[i].Width = 50;
            }

            form.ShowDialog();
        }

        public static void ShowTableStatic(Image<Gray, float> _data, string Title)
        {
            TableForm form = new TableForm();

            if (form.checkBox1.Checked)
                return;
            form.Text = "Table - " + Title;

            // Create the output table.
            DataTable d = new DataTable();

            // Loop through all process names.
            for (int i = 0; i < _data.Width; i++)
            {
                // Add the program name to our columns.
                d.Columns.Add(i.ToString());
            }

            for (int i = 0; i < _data.Height; i++)
            {
                d.Rows.Add();

                for (int j = 0; j < _data.Width; j++)
                {
                    // Add the program name to our columns.
                    d.Rows[i][j] = ((Gray)_data[i, j]).Intensity.ToString();
                }


            }

            form.dataGridView1.DataSource = d;

            for (int i = 0; i < _data.Width; i++)
            {
                form.dataGridView1.Columns[i].Width = 50;
            }

            form.ShowDialog();
        }

        internal void ShowTable(Image<Gray, float> _data, string Title)
        {
            if (checkBox1.Checked)
                return;
            this.Text = "Table - " + Title;

            // Create the output table.
            DataTable d = new DataTable();

            // Loop through all process names.
            for (int i = 0; i < _data.Width; i++)
            {
                // Add the program name to our columns.
                d.Columns.Add(i.ToString());
            }

            for (int i = 0; i < _data.Height; i++)
            {
                d.Rows.Add();

                for (int j = 0; j < _data.Width; j++)
                {
                    // Add the program name to our columns.
                    d.Rows[i][j] = ((Gray)_data[i, j]).Intensity.ToString();
                }


            }

            dataGridView1.DataSource = d;

            for (int i = 0; i < _data.Width; i++)
            {
                dataGridView1.Columns[i].Width = 50;
            }

            ShowDialog();
        }

        public static void ShowTableStatic(float[] _data, string Title)
        {
            TableForm form = new TableForm();

            if (form.checkBox1.Checked)
                return;
            form.Text = "Table - " + Title;

            // Create the output table.
            DataTable d = new DataTable();

            // Loop through all process names.
            for (int i = 0; i < 1; i++)
            {
                // Add the program name to our columns.
                d.Columns.Add(i.ToString());
            }

            for (int i = 0; i < _data.Length; i++)
            {
                d.Rows.Add();

                for (int j = 0; j < 1; j++)
                {
                    // Add the program name to our columns.
                    d.Rows[i][j] = (_data[i]).ToString();
                }


            }

            form.dataGridView1.DataSource = d;

            for (int i = 0; i < 1; i++)
            {
                form.dataGridView1.Columns[i].Width = 50;
            }

            form.ShowDialog();
        }
    }
}