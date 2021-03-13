using System;
using System.Collections.Generic;
using System.Linq;

//49. 字母异位词分组
//给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。

//示例:
//输入: ["eat", "tea", "tan", "ate", "nat", "bat"]
//输出:
//[
//  ["ate","eat","tea"],
//  ["nat","tan"],
//  ["bat"]
//]

//说明：
//所有输入均为小写字母。
//不考虑答案输出的顺序。

namespace GroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            Console.ReadKey();
        }


        //排序后的chars作为key，建立字典
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var charsDict = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var chars = str.ToCharArray();
                Array.Sort(chars);
                var keyStr = new string(chars);
                if (charsDict.ContainsKey(keyStr))
                {
                    charsDict[keyStr].Add(str);
                }
                else
                {
                    charsDict.Add(keyStr, new List<string>() { str });
                }
            }

            //返回字典Values
            return charsDict.Values.ToList<IList<string>>();
        }
    }
}
