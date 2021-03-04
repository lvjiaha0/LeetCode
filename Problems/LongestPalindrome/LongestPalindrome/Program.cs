using System;

//5.最长回文子串
//给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

//示例 1：

//输入: "babad"
//输出: "bab"
//注意: "aba" 也是一个有效答案。
//示例 2：

//输入: "cbbd"
//输出: "bb"

//提示：

//1 <= s.length <= 1000
//s 仅由数字和英文字母（大写和/或小写）组成

namespace LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = LongestPalindrome("babad"); //bab
            var a = LongestPalindrome("cbbd");//bb
            Console.ReadKey();
        }


        //中心扩散法
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2)
            {
                return s;
            }

            int strLen = s.Length;
            int maxStart = 0;  //最长回文串的起点
            int maxLen = 1;  //最长回文串的长度

            //缓存记录区间是否回文，提升性能
            bool[,] dp = new bool[strLen, strLen];

            for (int right = 1; right < strLen; right++)
            {
                for (int left = 0; left < right; left++)
                {
                    //right - left <= 2， 举例：三/二个节点中心对称
                    //调用dp避免重复遍历
                    if (s[left] == s[right] && (right - left <= 2 || dp[left + 1, right - 1]))
                    {
                        dp[left, right] = true;
                        if (right - left + 1 > maxLen)
                        {
                            maxLen = right - left + 1;
                            maxStart = left;
                        }
                    }
                }
            }
            return s.Substring(maxStart, maxLen);

            //作者：reedfan
            //链接：https://leetcode-cn.com/problems/longest-palindromic-substring/solution/zhong-xin-kuo-san-fa-he-dong-tai-gui-hua-by-reedfa/
        }
    }
}
