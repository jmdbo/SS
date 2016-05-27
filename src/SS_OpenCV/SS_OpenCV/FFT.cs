using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace SS_OpenCV
{
    public class FFT
    {
        /// <summary>
        /// Get direct FFT 
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="fft_Amp">Amplitude</param>
        /// <param name="fft_Phase">Phase</param>
        internal static void GetFFTAmpAndPhase(Image<Bgr, byte> img, out Image<Gray, float> fft_Amp, out Image<Gray, float> fft_Phase)
        {
            Image<Gray, float> imgFFT_Re;
            Image<Gray, float> imgFFT_Im;
            GetFFTReAndIm(img, out imgFFT_Re, out imgFFT_Im);

            // Get amplitude and Phase Channels
            Image<Gray, float> imgFFT_Amp = imgFFT_Re.CopyBlank();
            Image<Gray, float> imgFFT_Phase = imgFFT_Re.CopyBlank();
            CvInvoke.cvCartToPolar(imgFFT_Re, imgFFT_Im, imgFFT_Amp, imgFFT_Phase, false);


            //rearange the fft output
            fft_Amp = FFT2shift(imgFFT_Amp,false);
            fft_Phase = FFT2shift(imgFFT_Phase,false);
        }


        /// <summary>
        /// Calculate image FFT and return real and imaginary 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="fft_Re"></param>
        /// <param name="fft_Im"></param>
        private static Size GetFFTReAndIm(Image<Bgr, byte> img, out IntPtr imageFFT)
        {
            // First create image with optimal size and copy the content

            //get optimal size
            int wOptim = CvInvoke.cvGetOptimalDFTSize(img.Width);
            int hOptim = CvInvoke.cvGetOptimalDFTSize(img.Height);

            //create empty image
            Image<Bgr, byte> src1 = new Image<Bgr, byte>(wOptim, hOptim);
            src1.SetZero();

            // copy original to src
            src1.ROI = new Rectangle(0, 0, img.Width, img.Height);
            img.Copy(src1, null);
            src1.ROI = Rectangle.Empty;

            // prepare image with 2 channels for DFT
            Image<Gray, float> imgFFT_Re = src1.Convert<Gray, float>();
            Image<Gray, float> imgFFT_Im = src1.Convert<Gray, float>();
            imgFFT_Im.SetZero();

            //merge the 2 channels into one image 
            imageFFT = CvInvoke.cvCreateImage(src1.Size, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_32F, 2);
            CvInvoke.cvMerge(imgFFT_Re, imgFFT_Im, System.IntPtr.Zero, System.IntPtr.Zero, imageFFT);

            // calculate DFT 
            CvInvoke.cvDFT(imageFFT, imageFFT, Emgu.CV.CvEnum.CV_DXT.CV_DXT_FORWARD, 0);

            return new Size(wOptim, hOptim);
        }


        /// <summary>
        /// Calculate image FFT and return real and imaginary 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="fft_Re"></param>
        /// <param name="fft_Im"></param>
        private static void GetFFTReAndIm(Image<Bgr, byte> img, out Image<Gray, float> fft_Re, out Image<Gray, float> fft_Im)
        {
            // prepare image with 2 channels for DFT
            IntPtr imageFFT;

            Size s = GetFFTReAndIm(img, out imageFFT);

            Image<Gray, float> imgFFT_Re = new Image<Gray, float>(s);
            Image<Gray, float> imgFFT_Im = new Image<Gray, float>(s);

            // get Real and Imaginary channels
            CvInvoke.cvSplit(imageFFT, imgFFT_Re, imgFFT_Im, System.IntPtr.Zero, System.IntPtr.Zero);

            fft_Re = imgFFT_Re;
            fft_Im = imgFFT_Im;
        }


        /// <summary>
        /// Rearrange the FFT Output
        /// </summary>
        /// <param name="imgFFT_Amp"></param>
        public static Image<Gray, float> FFT2shift(Image<Gray, float> imgFFT_Amp, bool inverse)
        {
            int w2 = imgFFT_Amp.Width >> 1;
            int driftW = imgFFT_Amp.Width - w2 * 2;
            int h2 = imgFFT_Amp.Height >> 1;
            int driftH = imgFFT_Amp.Height - h2 * 2;

            Image<Gray, float> imgOut = imgFFT_Amp.Copy();//new Rectangle(0, 0, w2 * 2, h2 * 2));
            if (!inverse)
            {
                imgFFT_Amp.ROI = new Rectangle(0, 0, w2, h2);
                imgOut.ROI = new Rectangle(w2 + driftW, h2 + driftH, w2, h2);
                imgFFT_Amp.Copy(imgOut, null);

                imgFFT_Amp.ROI = new Rectangle(w2, 0, w2 + driftW, h2);
                imgOut.ROI = new Rectangle(0, h2 + driftH, w2 + driftW, h2);
                imgFFT_Amp.Copy(imgOut, null);

                imgFFT_Amp.ROI = new Rectangle(0, h2, w2, h2 + driftH);
                imgOut.ROI = new Rectangle(w2 + driftW, 0, w2, h2 + driftH);
                imgFFT_Amp.Copy(imgOut, null);

                imgFFT_Amp.ROI = new Rectangle(w2, h2, w2 + driftW, h2 + driftH);
                imgOut.ROI = new Rectangle(0, 0, w2 + driftW, h2 + driftH);
                imgFFT_Amp.Copy(imgOut, null);
            }
            else {
                imgFFT_Amp.ROI = new Rectangle(0, 0, w2+driftW, h2+driftH);
                imgOut.ROI = new Rectangle(w2 , h2 , w2 + driftW, h2 + driftH);
                imgFFT_Amp.Copy(imgOut, null);

                imgFFT_Amp.ROI = new Rectangle(w2 + driftW, 0, w2, h2 + driftH);
                imgOut.ROI = new Rectangle(0, h2 , w2 , h2 + driftH);
                imgFFT_Amp.Copy(imgOut, null);

                imgFFT_Amp.ROI = new Rectangle(0, h2+driftH, w2+driftW, h2 );
                imgOut.ROI = new Rectangle(w2 , 0, w2+driftW, h2 );
                imgFFT_Amp.Copy(imgOut, null);

                imgFFT_Amp.ROI = new Rectangle(w2+driftW, h2+driftH, w2 , h2 );
                imgOut.ROI = new Rectangle(0, 0, w2 , h2 );
                imgFFT_Amp.Copy(imgOut, null);
            
            
            }
            imgFFT_Amp.ROI = Rectangle.Empty;
            imgOut.ROI = Rectangle.Empty;
            return imgOut;
        }




        /// <summary>
        /// Calculate Inverse FFT
        /// </summary>
        /// <param name="fft_Amp1"></param>
        /// <param name="fft_Phase2"></param>
        /// <returns></returns>
        internal static Image<Gray, byte> GetFFT_InverseAmpAndPhase(Image<Gray, float> fft_Amp, Image<Gray, float> fft_Phase)
        {
            //rearange the fft output
            fft_Amp = FFT2shift(fft_Amp,true);
            fft_Phase = FFT2shift(fft_Phase,true);


            // Get amplitude and Phase Channels
            Image<Gray, float> imgFFT_Re = fft_Amp.CopyBlank();
            Image<Gray, float> imgFFT_Im = fft_Amp.CopyBlank();
            CvInvoke.cvPolarToCart(fft_Amp, fft_Phase, imgFFT_Re, imgFFT_Im, false);

            return GetFFT_InverseReAndIm(imgFFT_Re, imgFFT_Im);
        }

        /// <summary>
        /// Calculate Inverse FFT from complex image
        /// </summary>
        /// <param name="fft_Re"></param>
        /// <param name="fft_Im"></param>
        /// <returns></returns>
        private static Image<Gray, byte> GetFFT_InverseReAndIm(Image<Gray, float> fft_Re, Image<Gray, float> fft_Im)
        {
            //merge the 2 channels into one image 
            IntPtr imageFFT = CvInvoke.cvCreateImage(fft_Re.Size, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_32F, 2);
            CvInvoke.cvMerge(fft_Re, fft_Im, System.IntPtr.Zero, System.IntPtr.Zero, imageFFT);

            // calculate DFT 
            CvInvoke.cvDFT(imageFFT, imageFFT, Emgu.CV.CvEnum.CV_DXT.CV_DXT_INVERSE, 0);

            // get Real and Imaginary channels
            CvInvoke.cvSplit(imageFFT, fft_Re, fft_Im, System.IntPtr.Zero, System.IntPtr.Zero);

            Image<Gray, byte> result = fft_Re.Convert<Gray, byte>();

            return result;
        }


        /// <summary>
        /// Normalize data for visualization
        /// </summary>
        /// <param name="fft"></param>
        /// <param name="showLog">show in logarithm format</param>
        /// <returns></returns>
        internal static Image<Gray, float> PrepareForVizualization(Image<Gray, float> fft, bool showLog)
        {
            Image<Gray, float> result;
            if (showLog)
                result = fft.Log();
            else
                result = fft.Copy();

            CvInvoke.cvNormalize(result, result, 0, 255, Emgu.CV.CvEnum.NORM_TYPE.CV_MINMAX, IntPtr.Zero);
            
            return result;
        }


        /// <summary>
        /// generate a sharp filter
        /// </summary>
        /// <param name="size"></param>
        /// <param name="isHighPass"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        internal static Image<Gray, float> GenerateFilterMask(Size size, bool isHighPass, int width)
        {
            Image<Gray, float> mask = new Image<Gray, float>(size);
            if (isHighPass)
            {
                mask.SetValue(1);
                mask.Draw(new CircleF(new PointF(size.Width / 2, size.Height / 2), width), new Gray(0), 0);
            }
            else
            {
                mask.SetZero();
                mask.Draw(new CircleF(new PointF(size.Width / 2, size.Height / 2), width), new Gray(1), 0);
            }
            return mask;
        }


        /// <summary>
        /// generate a Butterworth Low-pass filter
        /// </summary>
        /// <param name="size"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        internal static Image<Gray, float> GenerateGaussianMask(Size size, double width)
        {
            Image<Gray, float> mask = new Image<Gray, float>(size);
            double order = 1;
            double uu, vv;
            for (int u = 0; u < size.Height; u++)
            {
                for (int v = 0; v < size.Width; v++)
                {
                    uu = u - size.Height / 2.0;
                    vv = v - size.Width / 2.0;
                    mask[u, v] = new Gray(1.0  * Math.Exp(- Math.Sqrt(uu * uu + vv * vv) / (double)(2 * width * width)));
                }
            }

            return mask;
        }
    }
}