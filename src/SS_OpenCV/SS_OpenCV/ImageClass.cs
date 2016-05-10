using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;

namespace SS_OpenCV
{
    class ImageClass
    {

        /// <summary>
        /// Negativo da Imagem
        /// Manipulação Imagem - Primitivas EmguCV
        /// Algoritmo de manipulação de imagem mais lento 
        /// </summary>
        /// <param name="img">Imagem</param>
        internal static void Negative(Image<Bgr, byte> img)
        {
            Bgr aux;
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    // acesso directo : mais lento 
                    aux = img[y, x];
                    img[y, x] = new Bgr(255 - aux.Blue, 255 - aux.Green, 255 - aux.Red);
                }
            }
        }
     

        /// <summary>
        /// Conversão para Cinzento
        /// Manipulação Imagem - Acesso directo à memoria
        /// </summary>
        /// <param name="img">imagem</param>
        /// <param name="imgUndo">Cópia da Imagem</param>
        internal static unsafe void ConvertToGray(Image<Bgr, byte> img)
        {
            // acesso directo à memoria da imagem (sequencial)
            // direcção top left -> bottom right

            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte blue, green, red, gray;

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y;
                        
            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //obtém as 3 componentes
                        blue = dataPtr[0];
                        green = dataPtr[1];
                        red = dataPtr[2];

                        // converte para cinza
                        gray = (byte)(((int)blue + green + red) / 3);

                        // guarda na imagem
                        dataPtr[0] = gray;
                        dataPtr[1] = gray;
                        dataPtr[2] = gray;

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }

                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }            
        }

        internal static unsafe void FastNegative(Image<Bgr, byte> img)
        {
            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem                     
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //obtém as 3 componentes
                        dataPtr[0] = (byte)(255 - dataPtr[0]);
                        dataPtr[1] = (byte)(255- dataPtr[1]);
                        dataPtr[2] = (byte)(255 - dataPtr[2]);

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }
        }

        internal static unsafe void BlueComponent(Image<Bgr, byte> img)
        {
            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //obtém as 3 componentes
                        //dataPtr[0] = (byte)(255 - dataPtr[0]);
                        dataPtr[1] = dataPtr[0];
                        dataPtr[2] = dataPtr[0];

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }            
        }

        internal static unsafe void GreenComponent(Image<Bgr, byte> img)
        {
            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //obtém as 3 componentes
                        //dataPtr[0] = (byte)(255 - dataPtr[0]);
                        dataPtr[0] = dataPtr[1];
                        dataPtr[2] = dataPtr[1];

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }            
        }

        internal static unsafe void RedComponent(Image<Bgr, byte> img)
        {
            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        dataPtr[0] = dataPtr[2];
                        dataPtr[1] = dataPtr[2];

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }            
        }

        internal static unsafe void Translation(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, int dx, int dy)
        {
            MIplImage m = img.MIplImage;
            MIplImage n = imgUndo.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte* dataUndoPtr = (byte*)n.imageData.ToPointer(); //Apontador imagem backup;
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y, xOrig, yOrig;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        xOrig = x - dx;
                        yOrig = y - dy;
                        if ((yOrig >= 0) && (xOrig >= 0) && (yOrig< height) && (xOrig < width))
                        {
                                
                            dataPtr[0] = (dataUndoPtr + (yOrig) * n.widthStep + (xOrig) * nChan)[0];
                            dataPtr[1] = (dataUndoPtr + (yOrig) * n.widthStep + (xOrig) * nChan)[1];
                            dataPtr[2] = (dataUndoPtr + (yOrig) * n.widthStep + (xOrig) * nChan)[2];
                        }
                        else
                        {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }
        }

        internal static unsafe void Rotation(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, float angle)
        {
            MIplImage m = img.MIplImage;
            MIplImage n = imgUndo.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte* dataUndoPtr = (byte*)n.imageData.ToPointer(); //Apontador imagem backup;
            byte* dataOrigPtr;
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y, xOrig, yOrig;
            double angleRad = (Math.PI / 180) * angle;
            double cos = Math.Cos(angleRad);
            double sin = Math.Sin(angleRad);

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        xOrig = (int)Math.Round(((x - (width / 2)) * cos) - (((height / 2) - y) * sin) + (width / 2));
                        yOrig = (int)Math.Round((height / 2) - ((x - (width / 2)) * sin) - (((height / 2) - y) * cos));
                        dataOrigPtr = dataUndoPtr + (yOrig) * n.widthStep + (xOrig) * nChan;

                        if ((yOrig >= 0) && (xOrig >= 0) && (yOrig < height) && (xOrig < width))
                        {
                            dataPtr[0] = dataOrigPtr[0];
                            dataPtr[1] = dataOrigPtr[1];
                            dataPtr[2] = dataOrigPtr[2];
                        }
                        else
                        {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }            
        }

        internal static unsafe void nonlinearfilter(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, int[] matrix, int weight,int size)
        {
            MIplImage m = img.MIplImage;
            MIplImage n = imgUndo.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte* dataUndoPtr = (byte*)n.imageData.ToPointer(); //Apontador imagem backup;
            byte* dataOrigPtr;
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y, xOrig, yOrig;
            int[] sum = new int[3] { 0, 0, 0};
            //byte[] mean = new byte[3];

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        sum[0] = 0;
                        sum[1] = 0;
                        sum[2] = 0;
                        for (int xFilter = 0; xFilter < (size); xFilter++)
                        {
                            for (int yFilter = 0; yFilter < size; yFilter++)
                            {
                                yOrig = y - (size/2) + yFilter;
                                xOrig = x - (size/2) + xFilter;
                                if (yOrig < 0)
                                    yOrig = 0;
                                if (yOrig >= height)
                                    yOrig = height - 1;
                                    
                                if (xOrig < 0)
                                    xOrig = 0;
                                if (xOrig >= width)
                                    xOrig = width - 1;

                                dataOrigPtr = dataUndoPtr + (yOrig) * n.widthStep + (xOrig) * nChan;
                                sum[0] = sum[0] + (matrix[xFilter + (yFilter * size)]) * dataOrigPtr[0];
                                sum[1] = sum[1] + (matrix[xFilter + (yFilter * size)]) * dataOrigPtr[1];
                                sum[2] = sum[2] + (matrix[xFilter + (yFilter * size)]) * dataOrigPtr[2];
                            }
                        }
                    
                        dataPtr[0] = (byte) (sum[0] / (weight));
                        dataPtr[1] = (byte) (sum[1] / (weight));
                        dataPtr[2] = (byte) (sum[2] / (weight));
                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }
        }

        internal static unsafe void Zoom(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, float zoom, int mouseX, int mouseY)
        {            
            MIplImage m = img.MIplImage;
            MIplImage n = imgUndo.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte* dataUndoPtr = (byte*)n.imageData.ToPointer(); //Apontador imagem backup;
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y, xOrig, yOrig;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        xOrig = (int)Math.Round(x / zoom)+mouseX;
                        yOrig = (int)Math.Round(y / zoom)+mouseY;

                        if ((yOrig >= 0) && (xOrig >= 0) && (yOrig < height) && (xOrig < width))
                        {
                            dataPtr[0] = (dataUndoPtr + (yOrig) * n.widthStep + (xOrig) * nChan)[0];
                            dataPtr[1] = (dataUndoPtr + (yOrig) * n.widthStep + (xOrig) * nChan)[1];
                            dataPtr[2] = (dataUndoPtr + (yOrig) * n.widthStep + (xOrig) * nChan)[2];
                        }
                        else
                        {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }            
        }

        internal static unsafe void sobelfilter(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, int size)
        {

            MIplImage m = img.MIplImage;
            MIplImage n = imgUndo.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte* dataUndoPtr = (byte*)n.imageData.ToPointer(); //Apontador imagem backup;
            byte* dataOrigPtr;

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y;
            int[] sum = new int[3] { 0, 0, 0 };
            int[] sx = new int[3], sy = new int[3], s = new int[3];
            
            if (nChan == 3) // imagem em RGB
            {
                //Não processando as bordas temos de avançar uma linha e uma coluna;
                dataPtr += nChan; //Avança uma coluna
                dataPtr += n.widthStep; //Avança uma linha
                for (y = size/2; y < height-(size/2); y++)
                {
                    for (x = size/2; x < width-(size/2); x++)
                    {
                        sum[0] = 0;
                        sum[1] = 0;
                        sum[2] = 0;
                        dataOrigPtr = dataUndoPtr + (y) * n.widthStep + (x) * nChan;
                        sx[0] = (((dataOrigPtr - n.widthStep - nChan)[0] + (2 *((dataOrigPtr - nChan)[0])) + (dataOrigPtr + n.widthStep - nChan)[0]) - 
                            ((dataOrigPtr - n.widthStep + nChan)[0] + (2 *((dataOrigPtr + nChan)[0])) + (dataOrigPtr + n.widthStep + nChan)[0]));
                        sx[1] = (((dataOrigPtr - n.widthStep - nChan)[1] + (2 * ((dataOrigPtr - nChan)[1])) + (dataOrigPtr + n.widthStep - nChan)[1]) -
                           ((dataOrigPtr - n.widthStep + nChan)[1] + (2 * ((dataOrigPtr + nChan)[1])) + (dataOrigPtr + n.widthStep + nChan)[1]));
                        sx[2] = (((dataOrigPtr - n.widthStep - nChan)[2] + (2 * ((dataOrigPtr - nChan)[2])) + (dataOrigPtr + n.widthStep - nChan)[2]) -
                           ((dataOrigPtr - n.widthStep + nChan)[2] + (2 * ((dataOrigPtr + nChan)[2])) + (dataOrigPtr + n.widthStep + nChan)[2]));

                        sy[0] = ((dataOrigPtr - nChan + n.widthStep)[0] + (2 * (dataOrigPtr + n.widthStep)[0]) + (dataOrigPtr + nChan + n.widthStep)[0]) - 
                            ((dataOrigPtr - n.widthStep - nChan)[0] + (2*((dataOrigPtr - n.widthStep)[0])) + ((dataOrigPtr - n.widthStep + nChan)[0])) ;
                        sy[1] = ((dataOrigPtr - nChan + n.widthStep)[1] + (2 * (dataOrigPtr + n.widthStep)[1]) + (dataOrigPtr + nChan + n.widthStep)[1]) -
                            ((dataOrigPtr - n.widthStep - nChan)[1] + (2 * ((dataOrigPtr - n.widthStep)[1])) + ((dataOrigPtr - n.widthStep + nChan)[1]));
                        sy[2] = ((dataOrigPtr - nChan + n.widthStep)[2] + (2 * (dataOrigPtr + n.widthStep)[2]) + (dataOrigPtr + nChan + n.widthStep)[2]) -
                            ((dataOrigPtr - n.widthStep - nChan)[2] + (2 * ((dataOrigPtr - n.widthStep)[2])) + ((dataOrigPtr - n.widthStep + nChan)[2]));

                        if (sy[0] < 0)
                            sy[0] = 0 - sy[0];
                        if (sy[1] < 0)
                            sy[1] = 0 - sy[1];
                        if (sy[2] < 0)
                            sy[2] = 0 - sy[2];

                        if (sx[0] < 0)
                            sx[0] = 0 - sx[0];
                        if (sx[1] < 0)
                            sx[1] = 0 - sx[1];
                        if (sx[2] < 0)
                            sx[2] = 0 - sx[2];

                        if (sy[0] > 255)
                            sy[0] = 255;
                        if (sy[1] > 255)
                            sy[1] = 255;
                        if (sy[2] > 255)
                            sy[2] = 255;

                        if (sx[0] > 255)
                            sx[0] = 255;
                        if (sx[1] > 255)
                            sx[1] = 255;
                        if (sx[2] > 255)
                            sx[2] = 255;

                        dataPtr[0] =(byte) (sx[0] + sy[0]);
                        dataPtr[1] =(byte) (sx[1] + sy[1]);
                        dataPtr[2] =(byte) (sx[2] + sy[2]);

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding + 2*nChan; //Avança uma coluna no fim e no inicio
                }
            }
        }

        internal static unsafe void medianFilter(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, int size)
        {
            MIplImage m = img.MIplImage;
            MIplImage n = imgUndo.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte* dataUndoPtr = (byte*)n.imageData.ToPointer(); //Apontador imagem backup;
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y, xOrig, yOrig, minDist, tempDist, xMinus, yMinus, xPlus,yPlus;
            byte[] value_med = new byte[3];

            if (nChan == 3)
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        minDist = int.MaxValue;
                        for (int xFilter = 0; xFilter < (size); xFilter++)
                        {
                            for (int yFilter = 0; yFilter < size; yFilter++)
                            {
                                yOrig = y - (size / 2) + yFilter;
                                xOrig = x - (size / 2) + xFilter;
                                if (yOrig < 0)
                                    yOrig = 0;
                                if (yOrig >= height)
                                    yOrig = height - 1;

                                if (xOrig < 0)
                                    xOrig = 0;
                                if (xOrig >= width)
                                    xOrig = width - 1;
                                xPlus = x + 1;
                                yPlus = y + 1;
                                xMinus = x - 1;
                                yMinus = y - 1;
                                if (xMinus < 0)
                                    xMinus = 0;
                                if (yMinus < 0)
                                    yMinus = 0;
                                if (yPlus >= height)
                                    yPlus = height - 1;
                                if (xPlus >= width)
                                    xPlus = width - 1;


                                tempDist = 
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[0] - (dataUndoPtr + (yMinus) * n.widthStep + (xMinus) * nChan)[0]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[0] - (dataUndoPtr + (yMinus) * n.widthStep + (x + 0) * nChan)[0]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[0] - (dataUndoPtr + (yMinus) * n.widthStep + (xPlus) * nChan)[0]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[0] - (dataUndoPtr + (y + 0) * n.widthStep + (xMinus) * nChan)[0]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[0] - (dataUndoPtr + (y + 0) * n.widthStep + (x + 0) * nChan)[0]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[0] - (dataUndoPtr + (y + 0) * n.widthStep + (xPlus) * nChan)[0]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[0] - (dataUndoPtr + (yPlus) * n.widthStep + (xMinus) * nChan)[0]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[0] - (dataUndoPtr + (yPlus) * n.widthStep + (x + 0) * nChan)[0]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[0] - (dataUndoPtr + (yPlus) * n.widthStep + (xPlus) * nChan)[0]) +

                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[1] - (dataUndoPtr + (yMinus) * n.widthStep + (xMinus) * nChan)[1]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[1] - (dataUndoPtr + (yMinus) * n.widthStep + (x + 0) * nChan)[1]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[1] - (dataUndoPtr + (yMinus) * n.widthStep + (xPlus) * nChan)[1]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[1] - (dataUndoPtr + (y + 0) * n.widthStep + (xMinus) * nChan)[1]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[1] - (dataUndoPtr + (y + 0) * n.widthStep + (x + 0) * nChan)[1]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[1] - (dataUndoPtr + (y + 0) * n.widthStep + (xPlus) * nChan)[1]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[1] - (dataUndoPtr + (yPlus) * n.widthStep + (xMinus) * nChan)[1]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[1] - (dataUndoPtr + (yPlus) * n.widthStep + (x + 0) * nChan)[1]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[1] - (dataUndoPtr + (yPlus) * n.widthStep + (xPlus) * nChan)[1]) +

                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[2] - (dataUndoPtr + (yMinus) * n.widthStep + (xMinus) * nChan)[2]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[2] - (dataUndoPtr + (yMinus) * n.widthStep + (x + 0) * nChan)[2]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[2] - (dataUndoPtr + (yMinus) * n.widthStep + (xPlus) * nChan)[2]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[2] - (dataUndoPtr + (y + 0) * n.widthStep + (xMinus) * nChan)[2]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[2] - (dataUndoPtr + (y + 0) * n.widthStep + (x + 0) * nChan)[2]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[2] - (dataUndoPtr + (y + 0) * n.widthStep + (xPlus) * nChan)[2]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[2] - (dataUndoPtr + (yPlus) * n.widthStep + (xMinus) * nChan)[2]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[2] - (dataUndoPtr + (yPlus) * n.widthStep + (x + 0) * nChan)[2]) +
                                    Math.Abs((dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[2] - (dataUndoPtr + (yPlus) * n.widthStep + (xPlus) * nChan)[2]);
                                if (tempDist < minDist)
                                {
                                    minDist = tempDist;
                                    value_med[0] = (dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[0];
                                    value_med[1] = (dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[1];
                                    value_med[2] = (dataUndoPtr + (yOrig) * n.widthStep + xOrig * nChan)[2];

                                }
                            }
                        }
                        dataPtr[0] = value_med[0];
                        dataPtr[1] = value_med[1];
                        dataPtr[2] = value_med[2];


                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }
        }

        internal static void CompareWithDB(Image<Bgr, byte> img)
        {
            throw new NotImplementedException();
        }

        internal static unsafe void CleanupSign(Image<Bgr, byte> img)
        {
            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y, blue, green, red;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //obtém as 3 componentes
                        blue = (dataPtr + (y) * m.widthStep + (x) * nChan)[0];
                        green = (dataPtr + (y) * m.widthStep + (x) * nChan)[1];
                        red = (dataPtr + (y) * m.widthStep + (x) * nChan)[2];

                        if (red - ((blue + green) / 2) > 30 && Math.Abs(blue - green) < 20)
                        {
                            x = width;
                        }
                        else
                        {
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[0] = 255;
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[1] = 255;
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[2] = 255;
                        }
                    }
                }

                for (y = 0; y < height; y++)
                {
                    for (x = width - 1; x >= 0; x--)
                    {
                        //obtém as 3 componentes
                        blue = (dataPtr + (y) * m.widthStep + (x) * nChan)[0];
                        green = (dataPtr + (y) * m.widthStep + (x) * nChan)[1];
                        red = (dataPtr + (y) * m.widthStep + (x) * nChan)[2];

                        if (red - ((blue + green) / 2) > 30 && Math.Abs(blue - green) < 20)
                        {
                            x = -1;
                        }
                        else
                        {
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[0] = 255;
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[1] = 255;
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[2] = 255;
                        }
                    }
                }

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //obtém as 3 componentes
                        blue = (dataPtr + (y) * m.widthStep + (x) * nChan)[0];
                        green = (dataPtr + (y) * m.widthStep + (x) * nChan)[1];
                        red =   (dataPtr + (y) * m.widthStep + (x) * nChan)[2];

                        if (red - ((blue + green) / 2) > 30 && Math.Abs(blue - green) < 20)
                        {
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[0] = 0;
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[1] = 0;
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[2] = 0;
                        }
                        else if((blue+green+ red)/3 > 80)
                        {
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[0] = 255;
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[1] = 255;
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[2] = 255;
                        }
                        else
                        {
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[0] = 0;
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[1] = 0;
                            (dataPtr + (y) * m.widthStep + (x) * nChan)[2] = 0;
                        }
                    }
                }

                
            }
        }

        internal static unsafe void CropImage(Image<Bgr, byte> imgUndo, out Image<Bgr, byte> img, Image<Bgr, byte> imgToShow, int xMaxPos, int xMinPos, int yMaxPos, int yMinPos)
        {
            int x, y, xOrig, yOrig;
            int imgWidth = xMaxPos - xMinPos + 1;
            int imgHeight = yMaxPos - yMinPos + 1;
            img = new Image<Bgr, byte>(imgWidth, imgHeight);
            MIplImage n = imgUndo.MIplImage;
            MIplImage m = img.MIplImage;
            MIplImage o = imgToShow.MIplImage;
            byte* dataNewPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem backup
            byte* dataPtr = (byte*)n.imageData.ToPointer(); //Apontador imagem ;
            byte* dataToShowPtr = (byte*)o.imageData.ToPointer();
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < imgHeight; y++)
                {
                    yOrig = yMinPos + y;

                    for (x = 0; x < imgWidth; x++)
                    {
                        xOrig = xMinPos + x;
                        
                        dataNewPtr[0] = (dataPtr + (yOrig) * n.widthStep + (xOrig) * nChan)[0];
                        dataNewPtr[1] = (dataPtr + (yOrig) * n.widthStep + (xOrig) * nChan)[1];
                        dataNewPtr[2] = (dataPtr + (yOrig) * n.widthStep + (xOrig) * nChan)[2];
                       
                        // avança apontador para próximo pixel
                        dataNewPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataNewPtr += padding;
                }

                for(x=0; x<imgWidth; x++)
                {
                    xOrig = xMinPos + x;
                    (dataToShowPtr + (yMinPos) * n.widthStep + (xOrig) * nChan)[0] = 0;
                    (dataToShowPtr + (yMinPos) * n.widthStep + (xOrig) * nChan)[1] = 0;
                    (dataToShowPtr + (yMinPos) * n.widthStep + (xOrig) * nChan)[2] = 255;

                    (dataToShowPtr + (yMaxPos) * n.widthStep + (xOrig) * nChan)[0] = 0;
                    (dataToShowPtr + (yMaxPos) * n.widthStep + (xOrig) * nChan)[1] = 0;
                    (dataToShowPtr + (yMaxPos) * n.widthStep + (xOrig) * nChan)[2] = 255;
                }

                for (y = 1; y < imgHeight; y++)
                {
                    yOrig = yMinPos + y;
                    (dataToShowPtr + (yOrig) * n.widthStep + (xMinPos) * nChan)[0] = 0;
                    (dataToShowPtr + (yOrig) * n.widthStep + (xMinPos) * nChan)[1] = 0;
                    (dataToShowPtr + (yOrig) * n.widthStep + (xMinPos) * nChan)[2] = 255;

                    (dataToShowPtr + (yOrig) * n.widthStep + (xMaxPos) * nChan)[0] = 0;
                    (dataToShowPtr + (yOrig) * n.widthStep + (xMaxPos) * nChan)[1] = 0;
                    (dataToShowPtr + (yOrig) * n.widthStep + (xMaxPos) * nChan)[2] = 255;

                }


            }
            
        }

        internal static unsafe void otsu(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img)
        {
            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            int[] intensity = new int[256];
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x = 0, y = 0;

            int Threshold;
            int Tval = 0, aux = 0, imgSize = width * height;
            float maxT = 0, q1 = 0, q2 = 0, u1, u2;
            float sigma = 0;
            float [] intens_prob = new float[256];

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        intensity[(dataPtr[0] + dataPtr[1] + dataPtr[2]) / 3]++;

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }

            for (aux = 0; aux < 256; aux++)
                intens_prob[aux] = (float)intensity[aux] / imgSize;

            for (Threshold = 0; Threshold < 256; Threshold++)
            {
                u1 = 0;
                u2 = 0;
                q1 = 0;
                q2 = 0;

                for (aux = 0; aux < Threshold; aux++)
                    q1 += intens_prob[aux];
                q2 = 1 - q1;

                if ((q1 * q2) != 0)
                {
                    for (aux = 0; aux < (Threshold + 1); aux++)
                        u1 += aux * intens_prob[aux];
                    u1 = (u1 / q1);

                    for (aux = (Threshold + 1); aux < 256; aux++)
                        u2 += aux * intens_prob[aux];
                    u2 = (u2 / q2);

                    sigma = q1 * q2 * (u1 - u2) * (u1 - u2);

                    if (sigma > maxT)
                    {
                        maxT = sigma;
                        Tval = Threshold;
                    }
                }
            }

            Console.WriteLine("Final -> " + Tval);
            binar(imgUndo, img, Tval);
        }

        internal static unsafe void binar(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, int CutValue)
        {
            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte blue, green, red, average;

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //obtém as 3 componentes
                        blue = dataPtr[0];
                        green = dataPtr[1];
                        red = dataPtr[2];

                        // converte para cinza
                        average = (byte)(((int)blue + green + red) / 3);

                        if (average < CutValue)
                        {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }

                        else
                        {
                            dataPtr[0] = 255;
                            dataPtr[1] = 255;
                            dataPtr[2] = 255;
                        }

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }

                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }
        }

        internal static Image<Bgr, byte> ShowHoughCircles(Image<Bgr, byte> img, Image<Bgr, byte> imgOriginal, int threshold)
        {
            // convert to Gray
            Image<Gray, byte> imgGray = img.Convert<Gray, byte>();

            int minraio = 40;
            int maxraio = 100;
            int canny = 50;
            int minDistCirc = 20;

            MemStorage SS = new MemStorage();
            IntPtr segmentsPtr = CvInvoke.cvHoughCircles(imgGray, SS.Ptr,
                Emgu.CV.CvEnum.HOUGH_TYPE.CV_HOUGH_GRADIENT, 1, minDistCirc, canny, threshold, minraio, maxraio);


            // draw lines
            Seq<CircleF> segments = new Seq<CircleF>(segmentsPtr, SS);
            CircleF[] circles = segments.ToArray();

            Image<Bgr, byte> circleImage = imgOriginal.Copy();

            foreach (CircleF circle in circles)
            {
                circleImage.Draw(circle, new Bgr(255, 0, 0), 1);
            }

            return circleImage;
        }

        internal static unsafe void histogram(Image<Bgr, byte> img, int[] intensity, int[] red, int[] green, int[] blue, int v)
        {
            MIplImage m = img.MIplImage;
           // MIplImage n = imgUndo.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            //byte* dataUndoPtr = (byte*)n.imageData.ToPointer(); //Apontador imagem backup;
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        intensity[(int)(dataPtr[0] + dataPtr[1] + dataPtr[2]+0.5) / 3]++;
                        blue[dataPtr[0]]++;
                        green[dataPtr[1]]++;
                        red[dataPtr[2]]++;

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }

        }

        internal static unsafe void sinal(Image<Bgr, byte> img)
        {
            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte blue, green, red;

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x, y;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //obtém as 3 componentes
                        blue = dataPtr[0];
                        green = dataPtr[1];
                        red = dataPtr[2];

                        if (red - ((blue + green)/2) > 30 && Math.Abs(blue - green) < 20)
                        {
                            dataPtr[0] = 255;
                            dataPtr[1] = 255;
                            dataPtr[2] = 255;
                        }
                        else
                        {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }

                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }
        }

        internal static unsafe void projection(Image<Bgr, byte> img, int[] HistX, int[] HistY, out int xMaxPos, out int xMinPos, out int yMaxPos, out int yMinPos)
        {
            MIplImage n = img.MIplImage;
            byte* dataPtr = (byte*)n.imageData.ToPointer(); // obter apontador do inicio da imagem

            int width = img.Width;
            int height = img.Height;
            int nChan = n.nChannels; // numero de canais 3
            int padding = n.widthStep - n.nChannels * n.width; // alinhamento (padding)
            int x, y,  xMaxTemp=0, xMinTemp=0, yMaxTemp = 0, yMinTemp = 0;
            bool isSign = false;
            xMaxPos = -1;
            xMinPos = -1;
            yMaxPos = -1;
            yMinPos = -1;

            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    if ((dataPtr + y * n.widthStep + x * nChan)[0]==255)
                    {
                        HistX[x]++;
                        HistY[y]++;
                    }
                }
            }


            for (x = 0; x < width; x++)
            {
                if (HistX[x] > 15 && !isSign)
                {
                    isSign = true;
                    xMinTemp = x;
                } else if ( HistX[x] < 15 && isSign)
                {
                    isSign = false;
                    xMaxTemp = x;

                    if (xMaxPos - xMinPos < xMaxTemp - xMinTemp)
                    {
                        xMaxPos = xMaxTemp;
                        xMinPos = xMinTemp;
                    }
                }
            }

            isSign = false;

            for (y = 0; y < height; y++)
            {
                if (HistY[y] > 15 && !isSign)
                {
                    isSign = true;
                    yMinTemp = y;
                }
                else if (HistY[y] < 15 && isSign)
                {
                    isSign = false;
                    yMaxTemp = y;

                    if (yMaxPos - yMinPos < yMaxTemp - yMinTemp)
                    {
                        yMaxPos = yMaxTemp;
                        yMinPos = yMinTemp;
                    }
                }
            }           

            Console.WriteLine("Maximum in x");
            Console.WriteLine("Min: "+ xMinPos.ToString());
            Console.WriteLine("Max: " + xMaxPos.ToString());
            Console.WriteLine("Sign in y");
            Console.WriteLine("Min: " + yMinPos.ToString());
            Console.WriteLine("Max: " + yMaxPos.ToString());

        }

        internal static unsafe void erode(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img)
        {
            MIplImage m = img.MIplImage;
            MIplImage n = imgUndo.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
            byte* dataUndoPtr = (byte*)n.imageData.ToPointer(); //Apontador imagem backup;
            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // numero de canais 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
            int x = 0, y = 0;

            int xPlus = 0;
            int yPlus = 0;
            int xMins = 0;
            int yMins = 0;

            if (nChan == 3) // imagem em RGB
            {
                for (y = 1; y < height-1; y++)
                {
                    for (x = 1; x < width-1; x++)
                    {
                        xPlus = x + 1;
                        yPlus = y + 1;
                        xMins = x - 1;
                        yMins = y - 1;

                        if (
                            (dataUndoPtr + nChan)[0] == 0 ||
                            (dataUndoPtr - nChan)[0] == 0 ||
                            (dataUndoPtr + n.widthStep)[0] == 0 ||
                            (dataUndoPtr - n.widthStep)[0] == 0 ||
                            (dataUndoPtr - nChan + n.widthStep)[0] == 0 ||
                            (dataUndoPtr + nChan + n.widthStep)[0] == 0 ||
                            (dataUndoPtr - nChan - n.widthStep)[0] == 0 ||
                            (dataUndoPtr + nChan - n.widthStep)[0] == 0
                           )
                        {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }

                            // avança apontador para próximo pixel
                            dataPtr += nChan;
                            dataUndoPtr += nChan;
                    }

                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                    dataUndoPtr += padding;
                }
            }
        }

        public static void myRound(Image<Gray, float> img)
        {
            unsafe
            {
                // acesso directo à memoria da imagem (sequencial)
                // top left to bottom right
                MIplImage m = img.MIplImage;
                int start = m.imageData.ToInt32();
                float* dataPtr = (float*)start;
                int h = img.Height;
                int w = img.Width;
                int x, y;
                int nC = m.nChannels;
                int wStep = m.widthStep - m.nChannels * m.width * sizeof(float);
                //byte gray;

                for (y = 0; y < h; y++)
                {
                    for (x = 0; x < w; x++)
                    {
                        // converte BGR para cinza 
                        *dataPtr = (float)Math.Round((double)*dataPtr);

                        // avança apontador 
                        dataPtr++;
                    }

                    //no fim da linha avança alinhamento
                    dataPtr += wStep;

                }
            }
        }

        public static Image<Gray, float> GetQuantificationMatrix(bool LuminanceOrChrominance, int compfactor)
        {
            float[] LumQuant = {   16,11,10,16,24,40,51,61,
                                12,12,14,19,26,58,60,55,
                                14,13,16,24,40,57,69,56,
                                14,17,22,29,51,87,80,62,
                                18,22,37,56,68,109,103,77,
                                24,35,55,64,81,104,113,92,
                                49,64,78,87,103,121,120,101,
                                72,92,95,98,112,100,103,99};

            float[] ChrQuant = {17,18,24,47,99,99,99,99,
                                18,21,26,66,99,99,99,99,
                                24,26,56,99,99,99,99,99,
                                47,66,99,99,99,99,99,99,
                                99,99,99,99,99,99,99,99,
                                99,99,99,99,99,99,99,99,
                                99,99,99,99,99,99,99,99,
                                99,99,99,99,99,99,99,99
                                };



            Image<Gray, float> matrix = new Image<Gray, float>(8, 8);
            int idx = 0;
            float[] Quant = (LuminanceOrChrominance) ? LumQuant : ChrQuant;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    matrix[y, x] = new Gray(Quant[idx++] * 100 / compfactor);
                }
            }

            return matrix;
        }


        /// <summary>
        /// Compute image connected components 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        internal static Image<Gray, int> GetConnectedComponents(Image<Bgr, byte> img)
        {
            Image<Gray, byte> imgThresh = img.Convert<Gray, byte>();
            CvInvoke.cvThreshold(imgThresh, imgThresh, 0, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY | Emgu.CV.CvEnum.THRESH.CV_THRESH_OTSU);

            ShowSingleIMG.ShowIMGStatic(imgThresh);

            Contour<Point > contours = imgThresh.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_CCOMP);
            Image<Gray, int> labelsImg = new Image<Gray, int>(imgThresh.Size);
            int count = 1;

            while (contours != null)
            {
                labelsImg.Draw(contours, new Gray(count), -1);
                labelsImg.Draw(contours, new Gray(-10), 1);
                contours = contours.HNext;
                count++;
            }

            return labelsImg;
        }



        /// <summary>
        /// Watershed with labels (Meyer)
        /// </summary>
        /// <param name="img"></param>
        /// <param name="labels"></param>
        /// <returns></returns>
        internal static Image<Gray, int> GetWatershedFromLabels(Image<Bgr, byte> img, Image<Gray, byte> labels)
        {
            Image<Gray, int> watershedAux = labels.Convert<Gray, int>();

            CvInvoke.cvWatershed(img, watershedAux);

            return watershedAux;
        }


        /// <summary>
        /// Watershed By Immersion (Vincent and Soille)
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        internal static Image<Gray, int> GetWatershedByImmersion(Image<Bgr, byte> img)
        {
            WatershedGrayscale wt = new WatershedGrayscale();
            Image<Gray, byte> wtImg = img.Convert<Gray, byte>();
            wt.ProcessFilter(wtImg.Not());
            wtImg.SetZero();
            Image<Gray, int> wtOutimg = new Image<Gray, int>(img.Size);
            wt.DrawWatershedLines(wtOutimg);

            return wtOutimg;
        }

        /// <summary>
        /// Get Gradient Path Labelling (GPL) segmnentation 
        /// </summary>
        /// <param name="img">image</param>
        /// <returns></returns>
        internal static Image<Bgr, byte> GetGPL(Image<Bgr, byte> img)
        {
            GPL_lib.GPL_lib gpl = new GPL_lib.GPL_lib(img, false);

            gpl.ShowConfigForm();

            return gpl.GetImage();
        }



        /// <summary>
        /// Calculates Hough Transform major lines using EmguCV function
        /// </summary>
        /// <param name="imgPreprocessed"></param>
        /// <param name="imgOriginal"></param>
        /// <returns></returns>
        internal static Image<Bgr, byte> ShowHoughLines(Image<Bgr, byte> img, Image<Bgr, byte> imgOriginal, int threshold)
        {

            // convert to Gray
            Image<Gray, byte> imgGray = img.Convert<Gray, byte>();

            MemStorage SS = new MemStorage();
            IntPtr segmentsPtr = CvInvoke.cvHoughLines2(imgGray, SS.Ptr,
                Emgu.CV.CvEnum.HOUGH_TYPE.CV_HOUGH_STANDARD, 1, Math.PI / 180, threshold, 0, 0);


            // draw lines
            Seq<PointF> segments = new Seq<PointF>(segmentsPtr, SS);
            PointF[] lines = segments.ToArray();

            Image<Bgr, byte> lineImage = imgOriginal.Copy();

            foreach (PointF line in lines)
            {
                float rho = line.X;
                float theta = line.Y;
                Point pt1 = new Point(), pt2 = new Point();

                double a = Math.Cos(theta), b = Math.Sin(theta);
                double x0 = a * rho, y0 = b * rho;
                pt1.X = (int)Math.Round(x0 + 1000 * (-b));
                pt1.Y = (int)Math.Round(y0 + 1000 * (a));
                pt2.X = (int)Math.Round(x0 - 1000 * (-b));
                pt2.Y = (int)Math.Round(y0 - 1000 * (a));

                lineImage.Draw(new LineSegment2D(pt1, pt2), new Bgr(255, 0, 0), 1);

            }

            return lineImage;
        }



        /// <summary>
        /// Calculate Hough Transform Plane
        /// </summary>
        /// <param name="img"></param>
        /// <param name="angleSpacing">Radians</param>
        /// <param name="minAngle">Radians</param>
        /// <param name="maxAngle">Radians</param>
        /// <returns></returns>
        internal static Image<Gray, float> HoughTransform(Image<Gray, byte> img, float angleSpacing, float minAngle, float maxAngle)
        {
            int numberAngles = (int)((maxAngle - minAngle) / angleSpacing);
            float angle = 0;
            Image<Gray, byte> workImg = img.Clone();
            Matrix<float> imgHough = null;

            for (float col = 0; col < numberAngles; col++)
            {
                workImg = img.Rotate(angle, new Gray(0), true);
                angle += angleSpacing;

                Matrix<float> imgMatH = new Matrix<float>(workImg.Height, 1, 1);

                workImg.Reduce<float>(imgMatH, Emgu.CV.CvEnum.REDUCE_DIMENSION.SINGLE_COL, Emgu.CV.CvEnum.REDUCE_TYPE.CV_REDUCE_SUM);
                if (imgHough == null)
                    imgHough = imgMatH;
                else
                    imgHough = imgHough.ConcateHorizontal(imgMatH);

            }
            Image<Gray, float> houghImg = new Image<Gray, float>(numberAngles, img.Height);
            CvInvoke.cvConvert(imgHough, houghImg);

            return houghImg;
        }


    }
}