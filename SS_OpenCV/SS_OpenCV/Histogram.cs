using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace SS_OpenCV
{
    public partial class Histogram : Form
    {
        public Histogram(int [] array)
        {
            InitializeComponent();

            // get a reference to the GraphPane
            GraphPane myPane = zedGraphControl1.GraphPane;

            //Set the titles
            myPane.Title.Text = "Histograma";
            myPane.XAxis.Title.Text = "Intensidade";
            myPane.YAxis.Title.Text = "Contagem";
            //list points
            PointPairList list1 = new PointPairList();
            for (int i = 0; i < array.Length; i++)
            {
                list1.Add(i, array[i]);
            }
            //add bar series
            myPane.AddBar("imagem", list1, Color.Gray);
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 255;
            zedGraphControl1.AxisChange();
        }
    }
}
