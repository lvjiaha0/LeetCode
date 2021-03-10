using System;
using System.Diagnostics;

//将一个给定字符串根据给定的行数，以从上往下、从左到右进行 Z 字形排列。

//比如输入字符串为 "LEETCODEISHIRING" 行数为 3 时，排列如下：

//L C   I R
//E T O E S I I G
//E D   H N
//之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："LCIRETOESIIGEDHN"。

//请你实现这个将字符串进行指定行数变换的函数：

//string convert(string s, int numRows);
//示例 1:

//输入: s = "LEETCODEISHIRING", numRows = 3
//输出: "LCIRETOESIIGEDHN"
//示例 2:

//输入: s = "LEETCODEISHIRING", numRows = 4
//输出: "LDREOEIIECIHNTSG"
//解释:

//L D     R
//E   O E   I I
//E C   I H   N
//T     S G
namespace Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Debug.Assert(Convert("LEETCODEISHIRING", 3) == "LCIRETOESIIGEDHN");
            Debug.Assert(Convert("LEETCODEISHIRING", 4) == "LDREOEIIECIHNTSG");
            Debug.Assert(Convert("AB", 1) == "AB");
        }

        public static string Convert(string s, int numRows)
        {
            string[] strs = new string[numRows];
            bool nextIsDown = true;
            int preIndex = -1;
            for (int i = 0; i < s.Length; i++)
            {
                strs[GetIndexCursor(numRows, ref preIndex, ref nextIsDown)] += s[i];
            }

            //连接得到结果
            return String.Join("", strs);
        }


        //记录当前行以及方向，从而确定加在哪一行
        public static int GetIndexCursor(int numRows, ref int preIndex, ref bool nextIsDown)
        {
            if (numRows == 1)
            {
                return 0;
            }
            if (nextIsDown)
            {
                preIndex += 1;
            }
            else
            {
                preIndex -= 1;
            }

            if (preIndex == 0)
            {
                nextIsDown = true;
            }

            if (preIndex == numRows - 1)
            {
                nextIsDown = false;
            }

            return preIndex;
        }
    }


}
