﻿using System;

namespace MergeSortedArray
{
    //88. 合并两个有序数组
    //给你两个有序整数数组 nums1 和 nums2，请你将 nums2 合并到 nums1 中，使 nums1 成为一个有序数组。
    //初始化 nums1 和 nums2 的元素数量分别为 m 和 n 。你可以假设 nums1 的空间大小等于 m + n，这样它就有足够的空间保存来自 nums2 的元素。

    //示例 1：
    //输入：nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
    //输出：[1,2,2,3,5,6]

    //示例 2：
    //输入：nums1 = [1], m = 1, nums2 = [], n = 0
    //输出：[1]

    //提示：
    //nums1.length == m + n
    //nums2.length == n
    //0 <= m, n <= 200
    //1 <= m + n <= 200
    //-109 <= nums1[i], nums2[i] <= 109
    class Program
    {
        static void Main(string[] args)
        {
            Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);
            Console.WriteLine("Hello World!");
        }

        //方法一 追加后排序
        //复杂度分析
        //时间复杂度 : O((n+m)log(n+m))。
        //空间复杂度 : O(1)。

        //方法二 双指针比大小填值
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var res = new int[m + n];
            var i = 0;
            var p1 = 0;
            var p2 = 0;
            while (p1 < m && p2 < n)
            {
                res[i] = Math.Min(nums1[p1], nums2[p2]);
                if (nums1[p1] <= nums2[p2])
                {
                    p1++;
                }
                else
                {
                    p2++;
                }
                i++;
            }
            if (p1 < m)
            {
                for (int j = p1; j < m; j++)
                {
                    res[i] = nums1[j];
                    i++;
                }
            }
            if (p2 < n)
            {
                for (int j = p2; j < n; j++)
                {
                    res[i] = nums2[j];
                    i++;
                }
            }
            for (int k = 0; k < res.Length; k++)
            {

                nums1[k] = res[k];
            }

            //复杂度分析
            //时间复杂度 : O(n + m)。
            //空间复杂度: O(m)。
        }

    }
}
