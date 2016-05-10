using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CASS.OpenCL;
using CASS.Types;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;

namespace SS_OpenCV
{
    class OpenCL_Class
    {

        static CLContext ctx;
        static CLCommandQueue comQ;
        static CLKernel kernel_mult;
        static CLProgram program;



        /// <summary>
        /// Get platform and device info
        /// </summary>
        internal static void GetInfo()
        {
            try
            {
                uint num_entries = 0;
                uint num_entries_devices = 0;
                // get device
                CLPlatformID[] platforms = new CLPlatformID[5];
                CLError err = OpenCLDriver.clGetPlatformIDs(5, platforms, ref num_entries);
                if (err != CLError.Success) throw new Exception(err.ToString());
                if (num_entries == 0) throw new Exception("No Platform Entries found!");
                // get platform properties
                byte[] buffer = new byte[1000];
                GCHandle bufferGC = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                SizeT buffSize, buffSizeOut = new SizeT();
                for (int i = 0; i < num_entries; i++)
                {
                    buffSize = new CASS.Types.SizeT(1000);
                    err = OpenCLDriver.clGetPlatformInfo(platforms[i], CLPlatformInfo.Name, buffSize,
                    bufferGC.AddrOfPinnedObject(), ref buffSizeOut);
                    if (err != CLError.Success) throw new Exception(err.ToString());
                    MessageBox.Show("Platform: " + i + "\n" + System.Text.Encoding.ASCII.GetString(buffer));

                    CLDeviceID[] devices = new CLDeviceID[2];
                    err = OpenCLDriver.clGetDeviceIDs(platforms[i], CLDeviceType.All, 2, devices, ref num_entries_devices);
                    if (err != CLError.Success) throw new Exception(err.ToString());

                    string result = "";
                    err = OpenCLDriver.clGetDeviceInfo(devices[0], CLDeviceInfo.Vendor, buffSize,
                    bufferGC.AddrOfPinnedObject(), ref buffSizeOut);
                    result += CLDeviceInfo.Vendor.ToString() + ": " +
                    Encoding.ASCII.GetString(buffer, 0, buffSizeOut - 1) + "\n";
                    buffSize = new CASS.Types.SizeT(1000);
                    err = OpenCLDriver.clGetDeviceInfo(devices[0], CLDeviceInfo.Name, buffSize,
                    bufferGC.AddrOfPinnedObject(), ref buffSizeOut);
                    result += CLDeviceInfo.Name.ToString() + ": " +
                    Encoding.ASCII.GetString(buffer, 0, buffSizeOut - 1) + "\n";

                    int[] workDim = new int[1];
                    bufferGC = GCHandle.Alloc(workDim, GCHandleType.Pinned);
                    buffSize = new CASS.Types.SizeT(sizeof(int));
                    err = OpenCLDriver.clGetDeviceInfo(devices[0], CLDeviceInfo.MaxComputeUnits, buffSize,
                    bufferGC.AddrOfPinnedObject(), ref buffSizeOut);
                    result += CLDeviceInfo.MaxComputeUnits.ToString() + ": " + workDim[0] + "\n";
                    err = OpenCLDriver.clGetDeviceInfo(devices[0], CLDeviceInfo.MaxWorkItemDimensions,
                    workDim.Length * sizeof(int), bufferGC.AddrOfPinnedObject(), ref buffSizeOut);
                    result += CLDeviceInfo.MaxWorkItemDimensions.ToString() + ": " + workDim[0] + "\n";
                    SizeT[] sizeWI = new SizeT[workDim[0]];
                    bufferGC = GCHandle.Alloc(sizeWI, GCHandleType.Pinned);
                    err = OpenCLDriver.clGetDeviceInfo(devices[0], CLDeviceInfo.MaxWorkItemSizes, sizeWI.Length *
                    sizeof(int), bufferGC.AddrOfPinnedObject(), ref buffSizeOut);
                    result += CLDeviceInfo.MaxWorkItemSizes.ToString() + ": " +
                    sizeWI[0] + "x" + sizeWI[1] + "x" + sizeWI[2] + "\n";
                    MessageBox.Show(result, "Device");

                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }



        /// <summary>
        /// Setup OpenCL
        /// </summary>
        internal static void Setup()
        {
            try
            {
                // ADD YOUR CODE HERE
                CLError err;
                uint num_entries = 0;// get platform
                CLPlatformID[] platforms = new CLPlatformID[5];
                err = OpenCLDriver.clGetPlatformIDs(5, platforms, ref num_entries);
                if (num_entries == 0) throw new Exception("No Platform Entries found!");
                //get device ID
                CLDeviceID[] devices = new CLDeviceID[1];
                err = OpenCLDriver.clGetDeviceIDs(platforms[0], CLDeviceType.GPU, 1, devices, ref num_entries);
                // create context
                ctx = OpenCLDriver.clCreateContext(null, 1, devices, null, IntPtr.Zero, ref err);
                if (err != CLError.Success) throw new Exception(err.ToString());

                // create command queue
                comQ = OpenCLDriver.clCreateCommandQueue(ctx, devices[0], 0, ref err);
                if (err != CLError.Success) throw new Exception(err.ToString());

                // Compile Program
                string[] progString = new string[1];
                progString[0] = File.ReadAllText("..\\..\\prog.cl");
                program = OpenCLDriver.clCreateProgramWithSource(ctx, 1, progString, null, ref err);
                err = OpenCLDriver.clBuildProgram(program, 1, devices, "", null, IntPtr.Zero);

                //create kernel
                kernel_mult = OpenCLDriver.clCreateKernel(program, "multiply", ref err);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        /// <summary>
        /// Release OpenCL objects (final)
        /// </summary>
        internal static void Release()
        {
            try
            {
                CLError err;
                // ADD YOUR CODE HERE
                err = OpenCLDriver.clReleaseCommandQueue(comQ);
                if(err != CLError.Success) throw new Exception(err.ToString());
                err = OpenCLDriver.clReleaseKernel(kernel_mult);
                if (err != CLError.Success) throw new Exception(err.ToString());
                err = OpenCLDriver.clReleaseContext(ctx);
                if (err != CLError.Success) throw new Exception(err.ToString());
                err = OpenCLDriver.clUnloadCompiler();
                if(err != CLError.Success) throw new Exception(err.ToString());

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        /// <summary>
        /// Multiply an array by a constant value
        /// </summary>
        internal static void Multiply()
        {
            try
            {
                CLError err = new CLError();
                //Allocate memory
                float[] arr = new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                GCHandle arrGC = GCHandle.Alloc(arr, GCHandleType.Pinned);
                CLMem bufferFilter = OpenCLDriver.clCreateBuffer(ctx, CLMemFlags.ReadWrite | CLMemFlags.CopyHostPtr, new SizeT(arr.Length * sizeof(float)), arrGC.AddrOfPinnedObject(), ref err);

                //set parameters
                unsafe
                {
                    OpenCLDriver.clSetKernelArg(kernel_mult, 0, new SizeT(sizeof(CLMem)), ref bufferFilter);
                }

                //Define grid & execute
                err = OpenCLDriver.clFinish(comQ);
                SizeT[] localws = { 5, 1 };
                SizeT[] globalws = { 10, 1 };
                CLEvent eventObj = new CLEvent();
                err = OpenCLDriver.clEnqueueNDRangeKernel(comQ, kernel_mult, 2, null,
                globalws, localws, 0, null, ref eventObj);
                CLEvent[] eventObjs = new CLEvent[1];
                eventObjs[0] = eventObj;
                OpenCLDriver.clWaitForEvents(1, eventObjs);
                // read buffer
                err = OpenCLDriver.clEnqueueReadBuffer(comQ, bufferFilter, CLBool.True, 0,
                10 * sizeof(float), arrGC.AddrOfPinnedObject(), 0, null, ref eventObj);

                TableForm.ShowTableStatic(arr, "OpenCL Test");


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }


        internal static unsafe void NegativeImage(Image<Bgr, byte> img)
        {
            try
            {
                // ADD YOUR CODE HERE
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer();
                int width = img.Width;
                int height = img.Height;
                int padding = m.widthStep - m.nChannels * m.width;

                //GCHandle dataGC = GCHandle.Alloc(dataPtr, GCHandleType.Pinned);
                //CLMem bufferFilter = OpenCLDriver.clCreateBuffer(ctx, CLMemFlags.ReadWrite | CLMemFlags.CopyHostPtr, new SizeT(arr.Length * sizeof(float)), arrGC.AddrOfPinnedObject(), ref err);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
