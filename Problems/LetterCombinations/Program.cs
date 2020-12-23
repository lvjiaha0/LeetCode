using System;
using System.Collections.Generic;

//17.电话号码的字母组合
//给定一个仅包含数字 2 - 9 的字符串，返回所有它能表示的字母组合。

//给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。



//示例:

//输入："23"
//输出：["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
//说明:
//尽管上面的答案是按字典序排列的，但是你可以任意选择答案输出的顺序。

namespace LetterCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = LetterCombinations("23");
            Console.WriteLine("Hello World!");
        }

        public static IList<string> LetterCombinations(string digits)
        {
            Dictionary<char, string> dict = new Dictionary<char, string>()
                {
                    {'2', "abc"},
                    {'3', "def"},
                    {'4', "ghi"},
                    {'5', "jkl"},
                    {'6', "mno"},
                    {'7', "pqrs"},
                    {'8', "tuv"},
                    {'9', "wxyz"}
                };
            var source = new List<string>();
            foreach (var num in digits)
            {
                source.Add(dict[num]);
            }

            var result = new List<string>();
            Descartes(source, 0, result);

            return result;
        }

        private static void Descartes(List<string> source, int level, List<string> result)
        {
            if (level < source.Count - 1)
            {
                Descartes(source, level + 1, result);
                var tempL = new List<string>();
                for (int i = 0; i < result.Count; i++)
                {
                    foreach (var c in source[level])
                    {
                        tempL.Add(c + result[i]);
                    }
                }
                result.Clear();
                result.AddRange(tempL);
            }
            else if (level == source.Count - 1)
            {
                foreach (var c in source[level])
                {
                    result.Add(c.ToString());
                }
            }
        }
    }
}
