using System;
using System.Collections.Generic;

//14.最长公共前缀
//编写一个函数来查找字符串数组中的最长公共前缀。

//如果不存在公共前缀，返回空字符串 ""。

 

//示例 1：

//输入：strs = ["flower", "flow", "flight"]
//输出："fl"
//示例 2：

//输入：strs = ["dog", "racecar", "car"]
//输出：""
//解释：输入不存在公共前缀。
 

//提示：

//0 <= strs.length <= 200
//0 <= strs[i].length <= 200
//strs[i] 仅由小写英文字母组成
class Program
{
    static void Main(string[] args)
    {
        var aa = LongestCommonPrefix(new string[] { "flower", "flow", "flight" });//"fl"
        aa = LongestCommonPrefix(new string[] { "dog", "racecar", "car" });//""
        Console.ReadKey();
    }

    public static string LongestCommonPrefix(string[] strs)
    {
        //预判断，得到最小长度
        var minLength = GetMinStrLength(strs);
        if (minLength == 0)
        {
            return string.Empty;
        }

        //循环遍历比较
        var chars = new List<char>();
        for (int i = 0; i < minLength; i++)
        {
            var tempChar = strs[0][i];
            chars.Add(tempChar);
            foreach (var str in strs)
            {
                //一旦字符不相等，跳出
                if (str[i] != tempChar)
                {
                    chars.RemoveAt(chars.Count - 1);
                    goto res;
                }
            }
        }

        res:
        return new string(chars.ToArray());
    }

    public static int GetMinStrLength(string[] strs)
    {
        if (strs == null || strs.Length == 0)
        {
            return 0;
        }

        var minLength = strs[0].Length;
        foreach (var str in strs)
        {
            minLength = Math.Min(minLength, str.Length);
        }
        return minLength;
    }
}