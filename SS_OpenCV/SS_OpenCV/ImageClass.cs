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
        internal static void ConvertToGray(Image<Bgr, byte> img)
        {
            unsafe
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
        }

        internal static void FastNegative(Image<Bgr, byte> img)
        {
            unsafe
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
        }

        internal static void BlueComponent(Image<Bgr, byte> img)
        {
            unsafe
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
        }

        internal static void GreenComponent(Image<Bgr, byte> img)
        {
            unsafe
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
        }

        internal static void RedComponent(Image<Bgr, byte> img)
        {
            unsafe
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
        }

        internal static void Translation(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, int dx, int dy)
        {
            unsafe
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

        }

        internal static void Rotation(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, float angle)
        {
            unsafe
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
        }

        internal static void x3nonlinearfilter(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, int[] matrix, int weight,int size)
        {
            unsafe{
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
                            for (int xFilter = 0; xFilter < size; xFilter++)
                            {
                                for (int yFilter = 0; yFilter < size; yFilter++)
                                {
                                    yOrig = y - size + yFilter;
                                    xOrig = x - size + xFilter;
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
            

        }

        internal static void Zoom(Image<Bgr, byte> imgUndo, Image<Bgr, byte> img, float zoom, int mouseX, int mouseY)
        {
            unsafe
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
        }
    }
}