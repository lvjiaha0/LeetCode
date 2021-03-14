using System;

namespace RemoveDuplicatesFromSortedArray
{
    //26. 删除排序数组中的重复项
    //给定一个排序数组，你需要在 原地 删除重复出现的元素，使得每个元素只出现一次，返回移除后数组的新长度。
    //不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。

    //示例 1:
    //给定数组 nums = [1, 1, 2],
    //函数应该返回新的长度 2, 并且原数组 nums 的前两个元素被修改为 1, 2。 
    //你不需要考虑数组中超出新长度后面的元素。

    //示例 2:
    //给定 nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4],
    //函数应该返回新的长度 5, 并且原数组 nums 的前五个元素被修改为 0, 1, 2, 3, 4。
    //你不需要考虑数组中超出新长度后面的元素。

    //说明:
    //为什么返回数值是整数，但输出的答案是数组呢?
    //请注意，输入数组是以「引用」方式传递的，这意味着在函数里修改输入数组对于调用者是可见的。
    //你可以想象内部操作如下:

    //nums 是以“引用”方式传递的。也就是说，不对实参做任何拷贝
    //int len = removeDuplicates(nums);

    // 在函数里修改输入数组对于调用者是可见的。
    // 根据你的函数返回的长度, 它会打印出数组中该长度范围内的所有元素。
    //for (int i = 0; i<len; i++) {
    //    print(nums[i]);
    //}
    class Program
    {
        static void Main(string[] args)
        {
            //var a = RemoveDuplicates(new int[] { 1, 1, 2 });//2
            var b = RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });//5
            //var c = RemoveDuplicates(new int[] { 1, 2 });//0
            Console.ReadKey();
        }

        //法一
        //快慢指针法，慢指针 i 找要填的位置，快指针 j 找新值
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                //找到新值后，慢指针往后移动，移动后的位置要填新值
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }
        //复杂度分析
        //时间复杂度：O(n)，假设数组的长度是 n，那么 i 和 j 分别最多遍历 n 步。
        //空间复杂度：O(1)。



        //法二
        //先标记重复后移动位置
        public static int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length == 0) return 0;

            //把重复的值标记为intMax
            var duplicate = nums[0];
            var newLength = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == duplicate)
                {
                    nums[i] = int.MaxValue;
                }
                else
                {
                    newLength++;
                    duplicate = nums[i];
                }
            }


            //移动位置法一
            var location = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != int.MaxValue && i != location)
                {
                    nums[location] = nums[i];
                    location++;
                }
            }

            //移动位置法二
            //Array.Sort(nums);

            return newLength;
        }
    }
}
