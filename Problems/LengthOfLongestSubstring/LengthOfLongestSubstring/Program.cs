using System;
using System.Collections.Generic;
using System.Diagnostics;


//给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

//示例 1:

//输入: "abcabcbb"
//输出: 3 
//解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
//示例 2:

//输入: "bbbbb"
//输出: 1
//解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
//示例 3:

//输入: "pwwkew"
//输出: 3
//解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
//     请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
namespace LengthOfLongestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(LengthOfLongestSubstring("abcabcbb") == 3);
            Debug.Assert(LengthOfLongestSubstring("au") == 2);
            Debug.Assert(LengthOfLongestSubstring("") == 0);
            Debug.Assert(LengthOfLongestSubstring(" ") == 1);
            Debug.Assert(LengthOfLongestSubstring("btw") == 3);
            Debug.Assert(LengthOfLongestSubstring("mm") == 1);
            Debug.Assert(LengthOfLongestSubstring("pwwkew") == 3);
            Debug.Assert(LengthOfLongestSubstring("abcdeb") == 5);
            Debug.Assert(LengthOfLongestSubstring("dvdf") == 3);
            Debug.Assert(LengthOfLongestSubstring("aab") == 2);
            Debug.Assert(LengthOfLongestSubstring("tmmzuxt") == 5);

            Console.WriteLine("Hello World!");
        }

        public static int LengthOfLongestSubstring(string s)
        {
            //记录 char-index 对应关系
            IDictionary<char, int> charIndexDic = new Dictionary<char, int>();
            int longest = 0;
            //最新前标, 初始值为 -1
            int beforeIndex = -1;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int c_Index = IndexOf(charIndexDic, c);

                //和 i 相减得到当前最新最长子串长度
                int newLength = i - beforeIndex;

                //当前 char 在前标之后，说明最新长度停止增长
                if (beforeIndex < c_Index)
                {
                    //更新前标，跳跃
                    beforeIndex = c_Index;
                    //停止增长
                    newLength -= 1;
                }

                longest = newLength > longest ? newLength : longest;
                charIndexDic[c] = i;
            }

            return longest;
        }

        //若存在返回index，否则返回 -1
        public static int IndexOf(IDictionary<char, int> charIndexDic, char c)
        {
            if (!charIndexDic.ContainsKey(c))
            {
                return -1;
            }
            else
            {
                return charIndexDic[c];
            }
        }
    }
}
