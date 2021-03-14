using System;
using System.Collections.Generic;

namespace SingleNumber
{
    //136. 只出现一次的数字
    //给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现两次。找出那个只出现了一次的元素。
    //说明：
    //你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？
    //示例 1:
    //输入: [2,2,1]
    //输出: 1

    //示例 2:
    //输入: [4,1,2,1,2]
    //输出: 4
    class Program
    {
        static void Main(string[] args)
        {
            //var a = SingleNumber(new int[] { 2, 2, 1 });
            var b = SingleNumber(new int[] { 4, 1, 2, 1, 2 });
            Console.ReadKey();
        }

        //排序
        //遍历找出只出现一次的数字
        public static int SingleNumber(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            Array.Sort(nums);
            var numberStack = new Stack<int>();
            foreach (var num in nums)
            {
                if (numberStack.Count == 0)
                {
                    numberStack.Push(num);
                }
                else if(numberStack.Peek() == num)
                {
                    numberStack.Pop();
                }
                else
                {
                    break;
                }
            }
            return numberStack.Pop();
        }
    }
}
