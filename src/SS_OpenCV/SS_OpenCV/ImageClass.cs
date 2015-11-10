using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;

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
            byte* dataOrigPtr;
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

        internal static unsafe void getSignal(Image<Bgr,byte> img)
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
                        //Definir o que é o vermelho
                        //Calcular a distancia ao vermelho e definir um threshold até ao qual consideramos um ponto vermelho
                        //Verificar se o vermelho continua a ser a componente maior!
                        if (dataPtr[2] > 70 && dataPtr[0] < 70 && dataPtr[1] < 70)
                        {
                            dataPtr[2] = 255;
                        }
                        else dataPtr[2] = 0;
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

        internal static unsafe void sinal(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img)
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

                        if (red - ((blue + green)/2) > 40 && Math.Abs(blue - green) < 20)
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
    }
}