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
    public partial class HistogramXY : Form
    {
        public HistogramXY(int [] x, String axis)
        {
            int i;

            InitializeComponent();

            // get a reference to the GraphPane
            GraphPane myPane = zedGraphControl1.GraphPane;

            //Set the titles
            myPane.Title.Text = "Histograma";
            myPane.XAxis.Title.Text = axis;
            myPane.YAxis.Title.Text = "Contagem";
            //list points
            PointPairList list1 = new PointPairList();
            for (i = 0; i < x.Length; i++)
            {
                list1.Add(i, x[i]);
            }
            //add bar series
            myPane.AddCurve(axis, list1, Color.Gray, SymbolType.None);
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = x.Length-1;
            zedGraphControl1.AxisChange();
        }
    }
}
