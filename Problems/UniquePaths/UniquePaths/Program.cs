﻿using System;

//62. 不同路径
//一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为 “Start” ）。
//机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为 “Finish” ）。
//问总共有多少条不同的路径？

//示例 1：
//输入：m = 3, n = 7
//输出：28

//示例 2：
//输入：m = 3, n = 2
//输出：3
//解释：
//从左上角开始，总共有 3 条路径可以到达右下角。
//1. 向右 -> 向下 -> 向下
//2. 向下 -> 向下 -> 向右
//3. 向下 -> 向右 -> 向下

//示例 3：
//输入：m = 7, n = 3
//输出：28

//示例 4：
//输入：m = 3, n = 3
//输出：6

//提示：
//1 <= m, n <= 100
//题目数据保证答案小于等于 2 * 109
namespace UniquePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = UniquePaths(3, 7);//28
            a = UniquePaths(3, 2);//3
            a = UniquePaths(3, 3);//6
            Console.ReadKey();
        }

        //思路一：数学公式
        //思路二：动态规划
        //我们令 dp[i][j] 是到达 i, j 最多路径
        //动态方程：dp[i][j] = dp[i - 1][j] + dp[i][j - 1]
        //注意，对于第一行 dp[0][j]，或者第一列 dp[i][0]，由于都是在边界，所以只能为 1
        //时间复杂度：O(m* n)O(m∗n)
        //空间复杂度：O(m* n)O(m∗n)

        //TODO
        //优化：因为我们每次只需要 dp[i - 1][j],dp[i][j - 1]

        //作者：powcai
        //链接：https://leetcode-cn.com/problems/unique-paths/solution/dong-tai-gui-hua-by-powcai-2/
        public static int UniquePaths(int m, int n)
        {
            var dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //对于第一行 dp[0][j]，或者第一列 dp[i][0]，由于都是在边界，所以只能为 1
                    if (i == 0) dp[0, j] = 1;
                    else if (j == 0) dp[i, 0] = 1;
                    else
                    {
                        //等于左边和上方之和
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
