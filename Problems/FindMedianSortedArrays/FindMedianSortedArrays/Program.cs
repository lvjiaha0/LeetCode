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
            Console.WriteLine("Hello World!");
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int length1 = nums1.Length;
            int length2 = nums2.Length;

            //总数为奇数
            bool isOdd = (length1 + length2) % 2 != 0;
            int resIndex = (length1 + length2) / 2;
            int tempIndex = 0;
            double resVal = 0;

            int curr1 = 0;
            int curr2 = 0;
            bool smallInNums1 = true;
            while (true)
            {
                while (smallInNums1)
                {
                    for (int i = curr1; i < nums1.Length - 1; i++)
                    {
                        if (nums1[i] <= nums2[curr2])
                        {
                            resVal = nums1[i];
                        }
                        else
                        {
                            smallInNums1 = false;
                            break;
                        }
                    }
                }

                while (!smallInNums1)
                {
                    for (int i = curr2; i < nums2.Length - 1; i++)
                    {
                        if (nums2[i] <= nums1[curr1])
                        {
                            resVal = nums2[i];
                        }
                        else
                        {
                            smallInNums1 = true;
                            break;
                        }
                    }
                }

                tempIndex += 1;
                if (tempIndex == resIndex)
                {
                    if (isOdd)
                    {
                        return resVal;
                    }
                    else
                    {
                        int nextVal = smallInNums1 ? nums1[curr1 + 1] : nums2[curr2 + 1];
                        return (resVal + nextVal) / 2;
                    }
                }
            }
        }
    }
}
