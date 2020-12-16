using System;
using System.Collections.Generic;

/// <summary>
/// 链表中环的检测
/// </summary>
namespace IsLinkedListHasLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new ListNode(1);
            var node2 = new ListNode(2);
            node.Next = node2;
            node.Next.Next = new ListNode(3);
            node.Next.Next.Next = new ListNode(4);
            node.Next.Next.Next.Next = new ListNode(5);
            var node6 = new ListNode(6);
            node.Next.Next.Next.Next.Next = node6;
            //node6.Next = node2;

            var res = IsLinkedListHasLoop2(node);
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 法1：快慢指针，跨指针经过慢指针时存在
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool IsLinkedListHasLoop(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null && fast.Next != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    fast = fast.Next;
                    if (fast == slow)
                    {
                        return true;
                    }
                }
                slow = slow.Next;
            }
            return false;
        }

        /// <summary>
        /// 使用字典，快指针的足迹存在过时存在
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool IsLinkedListHasLoop2(ListNode head)
        {
            var dict = new Dictionary<ListNode, int>();
            while (head != null)
            {
                if (dict.ContainsKey(head))
                {
                    return true;
                }
                else
                {
                    dict.Add(head, 0);
                }
                head = head.Next;
            }
            return false;
        }
    }

    public class ListNode
    {
        public ListNode(int val)
        {
            Value = val;
        }
        public int Value;
        public ListNode Next;
    }
}
