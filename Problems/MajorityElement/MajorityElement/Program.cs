using System;

namespace MajorityElement
{
    //169. 多数元素
    //给定一个大小为 n 的数组，找到其中的多数元素。多数元素是指在数组中出现次数 大于 ⌊ n/2 ⌋ 的元素。
    //你可以假设数组是非空的，并且给定的数组总是存在多数元素。

    //示例 1：
    //输入：[3,2,3]
    //输出：3

    //示例 2：
    //输入：[2,2,1,1,1,2,2]
    //输出：2

    //进阶：
    //尝试设计时间复杂度为 O(n)、空间复杂度为 O(1) 的算法解决此问题。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        //先排序，然后取n/2处的值，这是规律
        public static int MajorityElement(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }
        //复杂度分析
        //时间复杂度：O(nlogn)。将数组排序的时间复杂度为 O(nlogn)。
        //空间复杂度：O(logn)。如果使用语言自带的排序算法，需要使用 O(logn) 的栈空间。如果自己编写堆排序，则只需要使用 O(1) 的额外空间。

    }
}
