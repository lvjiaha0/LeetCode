using System;

//11.盛最多水的容器
//给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和(i, 0) 。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。

//说明：你不能倾斜容器。



//示例 1：



//输入：[1,8,6,2,5,4,8,3,7]
//输出：49
//解释：图中垂直线代表输入数组[1, 8, 6, 2, 5, 4, 8, 3, 7]。在此情况下，容器能够容纳水（表示为蓝色部分）的最大值为 49。
//示例 2：

//输入：height = [1, 1]
//输出：1
//示例 3：

//输入：height = [4, 3, 2, 1, 4]
//输出：16
//示例 4：

//输入：height = [1, 2, 1]
//输出：2



//提示：

//n = height.length
//2 <= n <= 3 * 104
//0 <= height[i] <= 3 * 104

namespace MaxArea
{
    class Program
    {
        static void Main(string[] args)
        {
            var height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            //var height = new int[] { 1, 2, 1 };
            //var height = new int[] { 4, 3, 2, 1, 4 };
            //var height = new int[] { 1, 1 };
            var area = MaxArea(height);
            Console.WriteLine("Hello World!");
        }

        //双指针
        //双指针代表的是 可以作为容器边界的所有位置的范围。
        //在一开始，双指针指向数组的左右边界，表示 数组中所有的位置都可以作为容器的边界，因为我们还没有进行过任何尝试。
        //在这之后，我们每次将 对应的数字较小的那个指针 往 另一个指针 的方向移动一个位置，就表示我们认为 这个指针不可能再作为容器的边界了。
        //链接：https://leetcode-cn.com/problems/container-with-most-water/solution/sheng-zui-duo-shui-de-rong-qi-by-leetcode-solution/
        public static int MaxArea(int[] height)
        {
            int res = 0;
            int left = 0;
            int right = height.Length - 1;
            while (left < right)
            {
                int area = (right - left) * Math.Min(height[left], height[right]);
                if (area > res)
                {
                    res = area;
                }
                if (height[left] <= height[right])
                {
                    left += 1;
                }
                else
                {
                    right -= 1;
                }
            }
            return res;
        }

        //O2 双For
        public static int MaxArea_2(int[] height)
        {
            int res = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i; j < height.Length; j++)
                {
                    int area = (j - i) * Math.Min(height[i], height[j]);
                    if (area > res)
                    {
                        res = area;
                    }
                }
            }
            return res;
        }
    }
}
