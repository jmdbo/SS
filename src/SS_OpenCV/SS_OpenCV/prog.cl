__kernel void multiply(__global float* arr)
{
	int i = get_global_id(0);
	arr[i] = arr[i] * arr[i];
}

__kernel void negative(__global uchar* image,
int w,
int h,
int padding,
int nchan,
__global uchar* imageOut)
{
	int x = get_global_id(0);
	int y = get_global_id(1);
	
	if(x < w && y < h){
		int x_pos = x * nchan;
		int y_pos = y * (w * nchan + padding);


		imageOut[0+x_pos+y_pos] = (byte)(255 - image[0+x_pos+y_pos]);
		imageOut[1+x_pos+y_pos] = (byte)(255 - image[1+x_pos+y_pos]);
		imageOut[2+x_pos+y_pos] = (byte)(255 - image[2+x_pos+y_pos]);
	}
	

}