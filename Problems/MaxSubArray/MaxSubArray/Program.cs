using System;

//53. 最大子序和
//给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。

//示例 1：
//输入：nums = [-2,1,-3,4,-1,2,1,-5,4]
//输出：6
//解释：连续子数组[4, -1, 2, 1] 的和最大，为 6 。

//示例 2：
//输入：nums = [1]
//输出：1

//示例 3：
//输入：nums = [0]
//输出：0

//示例 4：
//输入：nums = [-1]
//输出：-1

//示例 5：
//输入：nums = [-100000]
//输出：-100000


//提示：
//1 <= nums.length <= 3 * 104
//-105 <= nums[i] <= 105

namespace MaxSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            Console.ReadKey();
        }

        //贪心算法，时间复杂度O(1)
        public static int MaxSubArray(int[] nums)
        {
            var res = nums[0];
            var sum = 0;
            foreach (var num in nums)
            {
                //sum大于0，说明sum对结果有增益效果，则sum 保留并加上当前遍历数字
                if (sum > 0)
                {
                    sum += num;
                }
                //说明sum对结果无增益效果，需要舍弃
                else
                {
                    sum = num;
                }

                //每次比较 sum 和 res的大小，将最大值置为res，遍历结束返回结果
                res = Math.Max(res, sum);
            }

            return res;
        }

    }
}
