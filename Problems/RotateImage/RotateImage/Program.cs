using System;


//48. 旋转图像
//给定一个 n × n 的二维矩阵 matrix 表示一个图像。请你将图像顺时针旋转 90 度。

//你必须在 原地 旋转图像，这意味着你需要直接修改输入的二维矩阵。请不要 使用另一个矩阵来旋转图像。

//示例 1：
//输入：matrix = [[1,2,3],[4,5,6],[7,8,9]]
//输出：[[7,4,1],[8,5,2],[9,6,3]]

//示例 2：
//输入：matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
//输出：[[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]

//示例 3：
//输入：matrix = [[1]]
//输出：[[1]]

//示例 4：
//输入：matrix = [[1,2],[3,4]]
//输出：[[3,1],[4,2]]

//提示：
//matrix.length == n
//matrix[i].length == n
//1 <= n <= 20
//-1000 <= matrix[i][j] <= 1000

namespace RotateImage
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[3][];
            matrix[0] = new int[] { 1, 2, 3 };
            matrix[1] = new int[] { 4, 5, 6 };
            matrix[2] = new int[] { 7, 8, 9 };
            RotateImage(matrix);
            Console.ReadKey();
        }


        //法一（使用相同大小矩阵2）
        //思路简单，为暴力法。时间空间复杂度都为O(n^2)

        //法二（两次翻转）
        //左上右下翻转，左右翻转
        //时间复杂度O(n^2)，空间复杂度O(1)
        public static void RotateImage(int[][] matrix)
        {
            var n = matrix.Length;
            //第一次，左上右下翻转
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            //第二次，左右翻转
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - 1 - j];
                    matrix[i][n - 1 - j] = temp;
                }
            }
        }
    }
}
