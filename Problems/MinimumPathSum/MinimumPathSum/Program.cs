using System;


//64. 最小路径和
//给定一个包含非负整数的 m x n 网格 grid ，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
//说明：每次只能向下或者向右移动一步。

//示例 1：
//输入：grid = [[1,3,1],[1,5,1],[4,2,1]]
//输出：7
//解释：因为路径 1→3→1→1→1 的总和最小。

//示例 2：
//输入：grid = [[1,2,3],[4,5,6]]
//输出：12

//提示：
//m == grid.length
//n == grid[i].length
//1 <= m, n <= 200
//0 <= grid[i][j] <= 100
namespace MinimumPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new int[3][]
            {
            new int[] { 1, 3, 1 },
            new int[] { 1, 5, 1 },
            new int[] { 4, 2, 1 }
            };
            var a = MinPathSum(grid);

            var grid2 = new int[2][]
            {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 }
            };
            var b = MinPathSum(grid2);
            Console.ReadKey();
        }

        //动态规划，dp从左上计算到右下
        //动态规划公式: dp[i, j] = grid[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1])

        //复杂度分析
        //时间复杂度：O(mn)
        //空间复杂度：O(mn)
        //空间复杂度可以优化，例如每次只存储上一行的
        //dp 值，则可以将空间复杂度优化到 O(n)。列m同理
        //TODO 空间复杂度优化
        public static int MinPathSum(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }
            var m = grid.Length;
            var n = grid[0].Length;
            var dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //左上顶点
                    if (i == 0 && j == 0) dp[0, 0] = grid[0][0];
                    //上边
                    else if (i == 0 && j > 0) dp[i, j] = grid[i][j] + dp[0, j - 1];
                    //左边
                    else if (i > 0 && j == 0) dp[i, j] = grid[i][j] + dp[i - 1, 0];
                    //中间区域
                    else
                    {
                        dp[i, j] = grid[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            //动态规划结束，返回右下角计算的最短路径值
            return dp[m - 1, n - 1];
        }
    }
}
