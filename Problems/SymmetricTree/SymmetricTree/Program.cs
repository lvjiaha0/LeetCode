using System;
using System.Collections.Generic;

//101. 对称二叉树
//给定一个二叉树，检查它是否是镜像对称的。

//例如，二叉树[1, 2, 2, 3, 4, 4, 3] 是对称的。
//    1
//   / \
//  2   2
// / \ / \
//3  4 4  3

//但是下面这个[1, 2, 2, null, 3, null, 3] 则不是镜像对称的:
//    1
//   / \
//  2   2
//   \   \
//   3    3

//进阶：
//你可以运用递归和迭代两种方法解决这个问题吗？

namespace SymmetricTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodel2 = new TreeNode(2, new TreeNode(3), new TreeNode(4));
            var noder2 = new TreeNode(2, new TreeNode(4), new TreeNode(3));
            var node1 = new TreeNode(1, nodel2, noder2);
            var a = IsSymmetric(node1);
            Console.ReadKey();
        }

        //递归实现
        public static bool IsSymmetric(TreeNode root)
        {
            //自己与自己镜像
            return Check(root, root);
        }

        //两个树在什么情况下互为镜像？
        //如果同时满足下面的条件，两个树互为镜像：
        //它们的两个根结点具有相同的值
        //每个树的右子树都与另一个树的左子树镜像对称
        public static bool Check(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }
            else
            {
                //值相等，自己左人家右，自己右人家左
                return p.val == q.val && Check(p.left, q.right) && Check(p.right, q.left);
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
