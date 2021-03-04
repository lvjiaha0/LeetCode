using System;

namespace SearchInRotatedSortedArray
{
    class Program
    {
        //整数数组 nums 按升序排列，数组中的值 互不相同 。
        //在传递给函数之前，nums 在预先未知的某个下标 k（0 <= k<nums.Length）上进行了 旋转，使数组变为[nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]]（下标 从 0 开始 计数）。例如， [0, 1, 2, 4, 5, 6, 7] 在下标 3 处经旋转后可能变为[4, 5, 6, 7, 0, 1, 2] 。
        //给你 旋转后 的数组 nums 和一个整数 target ，如果 nums 中存在这个目标值 target ，则返回它的索引，否则返回 -1 。

        //示例 1：
        //输入：nums = [4,5,6,7,0,1,2], target = 0
        //输出：4

        //示例 2：
        //输入：nums = [4,5,6,7,0,1,2], target = 3
        //输出：-1

        //示例 3：
        //输入：nums = [1], target = 0
        //输出：-1

        //提示：
        //1 <= nums.Length <= 5000
        //-10^4 <= nums[i] <= 10^4
        //nums 中的每个值都 独一无二
        //nums 肯定会在某个点上旋转
        //-10^4 <= target <= 10^4

        //进阶：你可以设计一个时间复杂度为 O(log n) 的解决方案吗？

        //链接：https://leetcode-cn.com/problems/search-in-rotated-sorted-array
        static void Main(string[] args)
        {
            var a = SearchInRotatedSortedArray(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);//4
            a = SearchInRotatedSortedArray(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3);//-1
            a = SearchInRotatedSortedArray(new int[] { 1 }, 0);//-1
            a = SearchInRotatedSortedArray(new int[] { 1, 3 }, 0);//-1
            Console.ReadKey();
        }

        //遍历一遍 O（n）
        //public static int SearchInRotatedSortedArray(int[] nums, int target)
        //{
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (nums[i] == target)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        //推荐算法，考察二分法查找
        //二分法 O(logn)
        //只要mid比最左侧大，那么mid的左侧必然是有序的，判断最左侧，或者判断临时的left都可以 
        public static int SearchInRotatedSortedArray(int[] nums, int target)
        {
            int len = nums.Length;
            if (len == 0)
            {
                return -1;
            }
            if (len == 1)
            {
                return nums[0] == target ? 0 : -1;
            }
            int left = 0, right = len - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[left] <= nums[mid])
                {
                    //mid左侧为有序数组
                    if (nums[left] <= target && nums[mid] >= target)
                    {
                        //如果target在mid左侧的话
                        right = mid - 1;
                    }
                    else
                    {
                        //在mid右侧
                        left = mid + 1;
                    }
                }
                else
                {
                    //mid右侧为有序数组
                    if (nums[mid] <= target && nums[right] >= target)
                    {
                        //如果target在mid右侧的话
                        left = mid + 1;
                    }
                    else
                    {
                        //在mid左侧
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }
    }
}
