using System;

namespace FindFirstAndLastPositionOfElementInSortedArray
{
    //34. 在排序数组中查找元素的第一个和最后一个位置
    //给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。
    //如果数组中不存在目标值 target，返回[-1, -1]。

    //进阶：
    //你可以设计并实现时间复杂度为 O(log n) 的算法解决此问题吗？

    //示例 1：
    //输入：nums = [5,7,7,8,8,10], target = 8
    //输出：[3,4]

    //示例 2：
    //输入：nums = [5,7,7,8,8,10], target = 6
    //输出：[-1,-1]

    //示例 3：
    //输入：nums = [], target = 0
    //输出：[-1,-1]

    //提示：
    //0 <= nums.length <= 105
    //-109 <= nums[i] <= 109
    //nums 是一个非递减数组
    //-109 <= target <= 109
    class Program
    {
        static void Main(string[] args)
        {
            var a = FindFirstAndLastPositionOfElementInSortedArray(new int[] { 5, 7, 7, 8, 8, 10 }, 8);//[3,4]
            a = FindFirstAndLastPositionOfElementInSortedArray(new int[] { 5, 7, 7, 8, 8, 10 }, 6);//[-1,-1]
            a = FindFirstAndLastPositionOfElementInSortedArray(new int[] { }, 0);//[-1,-1]
            Console.ReadKey();
        }

        //二分查找
        public static int[] FindFirstAndLastPositionOfElementInSortedArray(int[] nums, int target)
        {
            int len = nums.Length;
            if (len == 0)
            {
                return new int[] { -1, -1 };
            }
            if (len == 1)
            {
                return nums[0] == target ? new int[] { 0, 0 } : new int[] { -1, -1 };
            }

            int left = 0, right = len - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                //目标值等于中间值
                if (nums[mid] == target)
                {
                    //向两边扩散
                    left = mid;
                    right = mid;
                    while (left - 1 >= 0 && nums[left - 1] == target)
                    {
                        left--;
                    }
                    while (right + 1 < len && nums[right + 1] == target)
                    {
                        right++;
                    }

                    return new int[] { left, right };
                }
                //目标值小于中间值
                else if (target < nums[mid])
                {
                    right = mid - 1;
                }
                //目标值大于中间值
                else
                {
                    left = mid + 1;
                }
            }

            return new int[] { -1, -1 };
        }
    }
}
