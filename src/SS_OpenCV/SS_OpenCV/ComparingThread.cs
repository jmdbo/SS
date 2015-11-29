using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;

namespace SS_OpenCV
{
    class ComparingThread
    {
        private Image<Bgr, byte> imgOrig;
        private Image<Bgr, byte> imgCmp;

        private bool isFinish;

        public bool isFinished
        {
            get { return isFinish; }
            set { isFinish = value; }
        }


        private float prob;
        public float probability
        {
            get { return prob; }
            set { prob = value; }
        }

        private int sign;

        public int signPos
        {
            get { return sign; }
            set { sign = value; }
        }

        public ComparingThread(Image<Bgr, byte> imgDB, Image<Bgr, byte> imgReal, int i)
        {
            this.imgOrig = imgDB.Copy();
            ImageClass.CleanupSign(this.imgOrig);
            this.imgCmp = imgReal.Copy();
            this.isFinish = false;
            this.signPos = i;

        }

        public unsafe void DoWork()
        {
            MIplImage m = imgOrig.MIplImage;
            MIplImage n = imgCmp.MIplImage;
            byte* dataRefPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte* dataPtr = (byte*)n.imageData.ToPointer(); //Apontador imagem backup;
            int width = imgOrig.Width;
            int height = imgOrig.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y, count = 0;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        if(dataPtr[0] == dataRefPtr[0])
                        {
                            count++;
                        }
                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                        dataRefPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                    dataRefPtr += padding;
                }

                prob = count / ((float)height * width);
                isFinish = true;
            }
        }
    }
}
