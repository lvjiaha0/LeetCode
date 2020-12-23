using System;
using System.Collections.Generic;
using System.Linq;

//387.字符串中的第一个唯一字符
//给定一个字符串，找到它的第一个不重复的字符，并返回它的索引。如果不存在，则返回 - 1。

//示例：

//s = "leetcode"
//返回 0

//s = "loveleetcode"
//返回 2

//提示：你可以假定该字符串只包含小写字母。

namespace FirstUniqChar
{
    class Program
    {
        static void Main(string[] args)
        {
            var a0 = FirstUniqChar("leetcode");
            var a2 = FirstUniqChar("loveleetcode");
            Console.WriteLine("Hello World!");
        }

        public static int FirstUniqChar(string s)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, i);
                }
                else
                {
                    dict[c] = -1;
                }
            }
            var find = dict.FirstOrDefault(item => item.Value != -1);
            return find.Equals(default(KeyValuePair<char, int>)) ? -1 : find.Value;
        }
    }
}
