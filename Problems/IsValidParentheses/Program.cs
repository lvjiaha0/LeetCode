using System;
using System.Collections.Generic;

namespace IsValidParentheses
{

    //20. 有效的括号
    //给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串 s ，判断字符串是否有效。

    //有效字符串需满足：
    //左括号必须用相同类型的右括号闭合。
    //左括号必须以正确的顺序闭合。

    //示例 1：
    //输入：s = "()"
    //输出：true

    //示例 2：
    //输入：s = "()[]{}"
    //输出：true

    //示例 3：
    //输入：s = "(]"
    //输出：false

    //示例 4：
    //输入：s = "([)]"
    //输出：false

    //示例 5：
    //输入：s = "{[]}"
    //输出：true

    //提示：
    //1 <= s.length <= 104
    //s 仅由括号 '()[]{}' 组成

    //来源：力扣（LeetCode）
    //链接：https://leetcode-cn.com/problems/valid-parentheses
    //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    class Program
    {
        static void Main(string[] args)
        {
            var a = IsValidParentheses("()");//true
            a = IsValidParentheses("()[]{}");//true
            a = IsValidParentheses("(]");//false
            a = IsValidParentheses("([)]");//false
            a = IsValidParentheses("{[]}");//true
            a = IsValidParentheses("([])");//true ??
            a = IsValidParentheses("({[)");//false

            Console.ReadKey();
        }

        public static bool IsValidParentheses(string s)
        {
            //字典记录对应的值
            var digits = new Dictionary<char, int>()
            {
                { '(',-1},
                { ')',1},
                { '[',-2},
                { ']',2},
                { '{',-3},
                { '}',3}
            };

            //进栈，匹配出栈
            var parenthesesStack = new Stack<char>();
            foreach (var c in s)
            {
                if (parenthesesStack.Count > 0)
                {
                    if (digits[parenthesesStack.Peek()] < 0 && digits[parenthesesStack.Peek()] + digits[c] == 0)
                    {
                        parenthesesStack.Pop();
                        continue;
                    }
                }
                parenthesesStack.Push(c);
            }

            return parenthesesStack.Count == 0;
        }
    }
}
