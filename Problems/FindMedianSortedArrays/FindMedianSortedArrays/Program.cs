using System;
using System.Diagnostics;



//给定两个大小为 m 和 n 的有序数组 nums1 和 nums2。

//请你找出这两个有序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。

//你可以假设 nums1 和 nums2 不会同时为空。

//示例 1:

//nums1 = [1, 3]
//nums2 = [2]

//则中位数是 2.0
//示例 2:

//nums1 = [1, 2]
//nums2 = [3, 4]

//则中位数是(2 + 3)/2 = 2.5
namespace FindMedianSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }) == 2.0);
            Debug.Assert(FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }) == 2.5);
            Debug.Assert(FindMedianSortedArrays(new int[] { 2 }, new int[] { }) == 2.0);
            Debug.Assert(FindMedianSortedArrays(new int[] { 1000001 }, new int[] { 1000000 }) == 1000000.5);
            Console.WriteLine("Hello World!");
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int length1 = nums1.Length;
            int length2 = nums2.Length;

            //总数为奇数
            bool isOdd = (length1 + length2) % 2 != 0;
            double resIndex = (length1 + length2) / 2.0;
            
            //两Array Pop出来的值按顺序排列得到的合并Array，长度只需大于中位数index即可
            //？？？优化内存，考虑缩小合并Array的Size，最大为2
            int[] combinedArray = new int[(int)(resIndex + 1)]; 

            int tempIndex = -1;
            int curr1 = 0;
            int curr2 = 0;

            while (true)
            {
                tempIndex += 1;
                if (tempIndex > resIndex)//已经获取到有效数据，后面的不需要了，退出循环
                {
                    break;
                }

                //判断小值在哪出的逻辑，注意一些边界值
                bool smallInNums1 = false;
                if (length1 == 0)
                {
                    smallInNums1 = false;
                }
                else if (length2 == 0)
                {
                    smallInNums1 = true;
                }
                else if (curr1 >= length1)
                {
                    smallInNums1 = false;
                }
                else if (curr2 >= length2)
                {
                    smallInNums1 = true;
                }
                else if (nums1[curr1] <= nums2[curr2])
                {
                    smallInNums1 = true;
                }

                //每一轮，寻找小值Append到合并Array中去
                if (smallInNums1)
                {
                    combinedArray[tempIndex] = nums1[curr1];
                    curr1 += 1;
                }
                else
                {
                    combinedArray[tempIndex] = nums2[curr2];
                    curr2 += 1;
                }

            }

            if (isOdd)//如果总数为奇数
            {
                double res = combinedArray[(int)Math.Ceiling(resIndex - 1)];
                return res;
            }
            else//如何总数为偶数，则为平均值
            {
                int pre = combinedArray[(int)resIndex - 1];
                int last = combinedArray[(int)resIndex];
                double res = (pre + last) / 2.0;
                return res;
            }
        }
    }
}
