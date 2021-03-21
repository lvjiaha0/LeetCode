using System;
using System.Linq;

namespace ConvertSortedArrayToBinarySearchTree
{
    //108. 将有序数组转换为二叉搜索树
    //给你一个整数数组 nums ，其中元素已经按 升序 排列，请你将其转换为一棵 高度平衡 二叉搜索树。
    //高度平衡 二叉树是一棵满足「每个节点的左右两个子树的高度差的绝对值不超过 1 」的二叉树。

    //示例 1：
    //输入：nums = [-10,-3,0,5,9]
    //输出：[0,-3,9,-10,null,5]
    //解释：[0,-10,5,null,-3,null,9] 也将被视为正确答案：

    //示例 2：
    //输入：nums = [1,3]
    //输出：[3,1]
    //解释：[1,3] 和[3, 1] 都是高度平衡二叉搜索树。

    //提示：
    //1 <= nums.length <= 104
    //-104 <= nums[i] <= 104
    //nums 按 严格递增 顺序排列
    class Program
    {
        static void Main(string[] args)
        {
            var a = SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });
            Console.WriteLine("Hello World!");
        }

        //递归建树
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            //1，2为递归边界
            if (nums.Length == 1)
            {
                return new TreeNode(nums[0]);
            }
            else if (nums.Length == 2)
            {
                return new TreeNode(nums[0], null, new TreeNode(nums[1]));
            }
            else
            {
                //递归建立左右子树
                var midIndex = nums.Length / 2;
                return new TreeNode(nums[midIndex],
                    SortedArrayToBST(nums.Take(midIndex).ToArray()),
                    SortedArrayToBST(nums.TakeLast(nums.Length - midIndex - 1).ToArray()));
            }
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}

