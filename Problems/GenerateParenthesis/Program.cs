using System;
using System.Collections.Generic;

namespace GenerateParenthesis
{
    //22. 括号生成
    //数字 n 代表生成括号的对数，请你设计一个函数，用于能够生成所有可能的并且 有效的 括号组合。

    //示例 1：
    //输入：n = 3
    //输出：["((()))","(()())","(())()","()(())","()()()"]

    //示例 2：
    //输入：n = 1
    //输出：["()"]

    //提示：
    //1 <= n <= 8
    class Program
    {
        static void Main(string[] args)
        {
            var a = GenerateParenthesis(3);
            a = GenerateParenthesis(2);
            a = GenerateParenthesis(1);
            Console.WriteLine("Hello World!");
        }

        public static IList<string> GenerateParenthesis(int n)
        {
            var res = new List<string>();
            GetParenthesis("", n, n, ref res);
            return res;
        }

        //剩余左括号总数要小于等于右括号。 递归把所有符合要求的加上去
        private static void GetParenthesis(string str, int left, int right, ref List<string> res)
        {
            if (left == 0 && right == 0)
            {
                res.Add(str);
                return;
            }
            if (left == right)
            {
                //剩余左右括号数相等，下一个只能用左括号
                GetParenthesis(str + "(", left - 1, right, ref res);
            }
            else if (left < right)
            {
                //剩余左括号小于右括号，下一个可以用左括号也可以用右括号
                if (left > 0)
                {
                    GetParenthesis(str + "(", left - 1, right, ref res);
                }
                GetParenthesis(str + ")", left, right - 1, ref res);
            }
        }
    }
}
