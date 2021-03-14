using System;

namespace MaximumDepthOfBinaryTree
{
    //104. 二叉树的最大深度
    //给定一个二叉树，找出其最大深度。
    //二叉树的深度为根节点到最远叶子节点的最长路径上的节点数。

    //说明: 叶子节点是指没有子节点的节点。
    //示例：
    //给定二叉树[3, 9, 20, null, null, 15, 7]，
    //    3
    //   / \
    //  9  20
    //    /  \
    //   15   7
    //返回它的最大深度 3 。
    class Program
    {
        static void Main(string[] args)
        {
            var node15 = new TreeNode(15);
            var node7 = new TreeNode(7);
            var node20 = new TreeNode(20, node15, node7);
            var node9 = new TreeNode(9);
            var node3 = new TreeNode(3, node9, node20);

            var a = MaxDepth(node3);
            Console.ReadKey();
        }

        //如果我们知道了左子树和右子树的最大深度 ll 和 rr，那么该二叉树的最大深度即为
        //max(l, r)+1

        //复杂度分析
        //时间复杂度：O(n)，其中 n 为二叉树节点的个数。每个节点在递归中只被遍历一次。
        //空间复杂度：O(height)，其中 height 表示二叉树的高度。递归函数需要栈空间，而栈空间取决于递归的深度，因此空间复杂度等价于二叉树的高度。
        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                //max(l, r)+1
                return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
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
