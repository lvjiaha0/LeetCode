using System;
using System.Collections.Generic;

//给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
//你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        //Solution 1
        public int[] TwoSum(int[] nums, int target)
        {
            IDictionary<int, int> numIndexDic = new Dictionary<int, int>();
            //记录 值-下标 到字典中
            for (int i = 0; i < nums.Length; i++)
            {
                numIndexDic[nums[i]] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                //差值，第二个数
                int complement = target - nums[i];
                //字典中已存在第二个值
                if (numIndexDic.ContainsKey(complement) && numIndexDic[complement] != i)
                {
                    //第一个值下标，查到的第二个值下标
                    return new[] { i, numIndexDic[complement] };
                }
            }
            throw new Exception();
        }

        //Solution 2
        public int[] TwoSum2(int[] nums, int target)
        {
            IDictionary<int, int> numIndexDic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numIndexDic.ContainsKey(complement) && numIndexDic[complement] != i)
                {
                    return new[] { numIndexDic[complement], i };
                }
                numIndexDic[nums[i]] = i;
            }

            throw new Exception();
        }
    }
}

//1
//3
