using System;

namespace ValidPalindrome
{
    //125. 验证回文串
    //给定一个字符串，验证它是否是回文串，只考虑字母和数字字符，可以忽略字母的大小写。
    //说明：本题中，我们将空字符串定义为有效的回文串。

    //示例 1:
    //输入: "A man, a plan, a canal: Panama"
    //输出: true

    //示例 2:
    //输入: "race a car"
    //输出: false
    class Program
    {
        static void Main(string[] args)
        {
            var a = IsPalindrome("A man, a plan, a canal: Panama");//true
            var b = IsPalindrome("race a car");//false
            Console.WriteLine("Hello World!");
        }

        public static bool IsPalindrome(string s)
        {
            var p = 0;
            var q = s.Length - 1;
            while (p < q)
            {
                if (!Char.IsLetterOrDigit(s[p]))
                {
                    p++;
                    continue;
                }
                else if (!Char.IsLetterOrDigit(s[q]))
                {
                    q--;
                    continue;
                }
                else if (Char.ToLower(s[p]) != Char.ToLower(s[q]))
                {
                    return false;
                }
                else
                {
                    p++;
                    q--;
                }

            }
            return true;
        }

        //时间复杂度：O(∣s∣)，其中 |s| 是字符串 s 的长度。
        //空间复杂度：O(1)。
    }
}
