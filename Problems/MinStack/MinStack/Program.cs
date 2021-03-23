using System;
using System.Linq;
using System.Collections.Generic;

namespace MinStack
{
    //155. 最小栈
    //设计一个支持 push ，pop ，top 操作，并能在常数时间内检索到最小元素的栈。
    //push(x) —— 将元素 x 推入栈中。
    //pop()—— 删除栈顶的元素。
    //top()—— 获取栈顶元素。
    //getMin() —— 检索栈中的最小元素。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class MinStack
        {

            //记录每个元素存在时的对应的最小值
            //能在常数时间内检索到最小元素的栈
            private List<Tuple<int, int>> _stack;
            /** initialize your data structure here. */
            public MinStack()
            {
                _stack = new List<Tuple<int, int>>();
            }

            public void Push(int val)
            {
                if (!_stack.Any())
                {
                    _stack.Add(new Tuple<int, int>(val, val));
                }
                else
                {
                    _stack.Add(new Tuple<int, int>(val, Math.Min(val, _stack.Last().Item2)));
                }
            }

            public void Pop()
            {
                _stack.RemoveAt(_stack.Count - 1);
            }

            public int Top()
            {
                return _stack.Last().Item1;
            }

            public int GetMin()
            {
                return _stack.Last().Item2;
            }
        }
    }
}
