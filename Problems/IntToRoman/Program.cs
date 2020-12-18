using System;
using System.Collections.Generic;

/// <summary>
/// 
/// 
/// 12. 整数转罗马数字
///罗马数字包含以下七种字符： I， V， X， L，C，D 和 M。
///
///字符          数值
///I             1
///V             5
///X             10
///L             50
///C             100
///D             500
///M             1000
///例如， 罗马数字 2 写做 II ，即为两个并列的 1。12 写做 XII ，即为 X + II 。 27 写做  XXVII, 即为 XX + V + II 。
///
///通常情况下，罗马数字中小的数字在大的数字的右边。但也存在特例，例如 4 不写做 IIII，而是 IV。数字 1 在数字 5 的左边，所表示的数等于大数 5 减小数 1 得到的数值 4 。同样地，数字 9 表示为 IX。这个特殊的规则只适用于以下六种情况：
///
///I 可以放在 V (5) 和 X(10) 的左边，来表示 4 和 9。
///X 可以放在 L (50) 和 C(100) 的左边，来表示 40 和 90。 
///C 可以放在 D (500) 和 M(1000) 的左边，来表示 400 和 900。
///给定一个整数，将其转为罗马数字。输入确保在 1 到 3999 的范围内。
///
///示例 1:
///
///输入: 3
///输出: "III"
///示例 2:
///
///输入: 4
///输出: "IV"
///示例 3:
///
///输入: 9
///输出: "IX"
///示例 4:
///
///输入: 58
///输出: "LVIII"
///解释: L = 50, V = 5, III = 3.
///示例 5:
///
///输入: 1994
///输出: "MCMXCIV"
///解释: M = 1000, CM = 900, XC = 90, IV = 4.
/// </summary>
namespace IntToRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            var III = IntToRoman2(3);
            var IV = IntToRoman2(4);
            var IX = IntToRoman2(9);
            var LVIII = IntToRoman2(58);
            var MCMXCIV = IntToRoman2(1994);
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 法1，字典建立千百十个位，字符串拼接
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IntToRoman(int num)
        {
            //M-*-*
            Dictionary<int, string> dic1000 = new Dictionary<int, string>() {
                { 0, "" } ,
                { 1, "M" } ,
                { 2, "MM" } ,
                { 3, "MMM" }
            };
            //C-D-M
            Dictionary<int, string> dic100 = new Dictionary<int, string>() {
                { 0, "" } ,
                { 1, "C" },
                { 2, "CC" },
                { 3, "CCC" },
                { 4, "CD" },
                { 5, "D" },
                { 6, "DC" },
                { 7, "DCC" },
                { 8, "DCCC" },
                { 9, "CM" }
            };
            //X-L-C
            Dictionary<int, string> dic10 = new Dictionary<int, string>() {
                { 0, "" } ,
                { 1, "X" },
                { 2, "XX" },
                { 3, "XXX" },
                { 4, "XL" },
                { 5, "L" },
                { 6, "LX" },
                { 7, "LXX" },
                { 8, "LXXX" },
                { 9, "XC" }
            };
            //*-V-X
            Dictionary<int, string> dic1 = new Dictionary<int, string>() {
                { 0, "" } ,
                { 1, "I" },
                { 2, "II" },
                { 3, "III" },
                { 4, "IV" },
                { 5, "V" },
                { 6, "VI" },
                { 7, "VII" },
                { 8, "VIII" },
                { 9, "IX" }
            };

            int n1000 = num / 1000;
            int n100 = (num - n1000 * 1000) / 100;
            int n10 = (num - int.Parse(string.Concat(n1000, n100)) * 100) / 10;
            int n1 = num - int.Parse(string.Concat(n1000, n100, n10)) * 10;

            return string.Concat(dic1000[n1000], dic100[n100], dic10[n10], dic1[n1]);
        }

        /// <summary>
        /// 法2 贪心算法实现，易于扩展
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IntToRoman2(int num)
        {
            var digits = new (int, string)[]
            {
                (1000, "M"),
                (900, "CM"),
                (500, "D"),
                (400, "CD"),
                (100, "C"),
                (90, "XC"),
                (50, "L"),
                (40, "XL"),
                (10, "X"),
                (9, "IX"),
                (5, "V"),
                (4, "IV"),
                (1, "I")
            };

            var res = string.Empty;
            foreach (var item in digits)
            {
                if (num >= item.Item1)
                {
                    var count = num / item.Item1;
                    var remain = num % item.Item1;

                    //Repeat count times
                    for (int i = 0; i < count; i++)
                    {
                        res += item.Item2;
                    }

                    //number is the rest
                    num = remain;
                }
            }
            return res;
        }
    }
}
