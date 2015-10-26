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
        public Histogram(int [] intensity, int [] red, int [] green, int [] blue)
        {
            int i;

            InitializeComponent();

            // get a reference to the GraphPane
            GraphPane myPane = zedGraphControl1.GraphPane;

            //Set the titles
            myPane.Title.Text = "Histograma";
            myPane.XAxis.Title.Text = "Intensidade";
            myPane.YAxis.Title.Text = "Contagem";
            //list points
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            for (i = 0; i < intensity.Length; i++)
            {
                list1.Add(i, intensity[i]);
            }
            for (i = 0; i < red.Length; i++)
            {
                list2.Add(i, red[i]);
            }
            for (i = 0; i < green.Length; i++)
            {
                list3.Add(i, green[i]);
            }
            for (i = 0; i < blue.Length; i++)
            {
                list4.Add(i, blue[i]);
            }
            //add bar series
            myPane.AddCurve("intensity", list1, Color.Gray, SymbolType.None);
            myPane.AddCurve("red", list2, Color.Red, SymbolType.None);
            myPane.AddCurve("green", list3, Color.Green, SymbolType.None);
            myPane.AddCurve("blue", list4, Color.Blue, SymbolType.None);
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 255;
            zedGraphControl1.AxisChange();
        }
    }
}
