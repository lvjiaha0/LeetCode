using System;


//75. 颜色分类
//给定一个包含红色、白色和蓝色，一共 n 个元素的数组，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。
//此题中，我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。

//示例 1：
//输入：nums = [2,0,2,1,1,0]
//输出：[0,0,1,1,2,2]

//示例 2：
//输入：nums = [2,0,1]
//输出：[0,1,2]

//示例 3：
//输入：nums = [0]
//输出：[0]

//示例 4：
//输入：nums = [1]
//输出：[1]

//提示：
//n == nums.length
//1 <= n <= 300
//nums[i] 为 0、1 或 2

//进阶：
//你可以不使用代码库中的排序函数来解决这道题吗？
//你能想出一个仅使用常数空间的一趟扫描算法吗？
namespace SortColors
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 2, 0, 2, 1, 1, 0 };
            SortColors(a);
            Console.ReadKey();
        }

        //在第一次遍历中，我们将数组中所有的 00 交换到数组的头部。
        //在第二次遍历中，我们将数组中所有的 11 交换到头部的 00 之后。
        //此时，所有的 22 都出现在数组的尾部，这样我们就完成了排序。
        public static void SortColors(int[] nums)
        {
            if (nums.Length == 1)
            {
                return;
            }

            //动态头部位置
            var head = 0;
            //第一次循环，将0前移到头部位置
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = nums[head];
                    nums[head] = 0;
                    //移动头部位置
                    head++;
                }
            }
            //第二次循环，从头部开始遍历，将1前移到头部位置，剩余2自动排在末尾
            for (int i = head; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    nums[i] = nums[head];
                    nums[head] = 1;
                    head++;
                }
            }
        }
    }
}
