using System;
using System.Collections.Generic;

namespace CountAndSay
{
    //38. 外观数列
    //给定一个正整数 n ，输出外观数列的第 n 项。
    //「外观数列」是一个整数序列，从数字 1 开始，序列中的每一项都是对前一项的描述。
    //你可以将其视作是由递归公式定义的数字字符串序列：

    //countAndSay(1) = "1"
    //countAndSay(n) 是对 countAndSay(n-1) 的描述，然后转换成另一个数字字符串。
    //前五项如下：

    //1.     1
    //2.     11
    //3.     21
    //4.     1211
    //5.     111221
    //第一项是数字 1 
    //描述前一项，这个数是 1 即 “ 一 个 1 ”，记作 "11"
    //描述前一项，这个数是 11 即 “ 二 个 1 ” ，记作 "21"
    //描述前一项，这个数是 21 即 “ 一 个 2 + 一 个 1 ” ，记作 "1211"
    //描述前一项，这个数是 1211 即 “ 一 个 1 + 一 个 2 + 二 个 1 ” ，记作 "111221"

    //示例 1：
    //输入：n = 1
    //输出："1"
    //解释：这是一个基本样例。

    //示例 2：
    //输入：n = 4
    //输出："1211"
    //解释：
    //countAndSay(1) = "1"
    //countAndSay(2) = 读 "1" = 一 个 1 = "11"
    //countAndSay(3) = 读 "11" = 二 个 1 = "21"
    //countAndSay(4) = 读 "21" = 一 个 2 + 一 个 1 = "12" + "11" = "1211"

    //提示：
    //1 <= n <= 30
    class Program
    {
        static void Main(string[] args)
        {
            var a = CountAndSay(1);
            var b = CountAndSay(2);
            var c = CountAndSay(3);
            var d = CountAndSay(4);
            var e = CountAndSay(5);
            Console.WriteLine("Hello World!");
        }


        //确认递归边界返回
        //求 n 处的结果时是对 n-1 处遍历
        public static string CountAndSay(int n)
        {
            //递归边界返回
            if (n == 1) return "1";
            else if (n == 2) return "11";
            else
            {
                //使用栈临时存储出现的值及其数量
                var preRes = CountAndSay(n - 1);
                var tempStack = new Stack<char>();
                var res = string.Empty;
                for (int i = 0; i < preRes.Length; i++)
                {
                    if (tempStack.Count == 0) tempStack.Push(preRes[i]);
                    else
                    {
                        if (tempStack.Peek() == preRes[i]) tempStack.Push(preRes[i]);
                        else
                        {
                            res += (tempStack.Count.ToString() + tempStack.Peek().ToString());
                            tempStack.Clear();
                            tempStack.Push(preRes[i]);
                        }
                    }

                    //最后一处的处理
                    if (i == preRes.Length - 1)
                    {
                        res += (tempStack.Count.ToString() + tempStack.Peek().ToString());
                        tempStack.Clear();
                    }
                }
                return res;
            }
        }
    }
}
