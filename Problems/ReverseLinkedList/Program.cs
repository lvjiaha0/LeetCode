using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 链表反转
/// </summary>

namespace ReverseLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new ListNode(1);
            node.Next = new ListNode(2);
            node.Next.Next = new ListNode(3);
            node.Next.Next.Next = new ListNode(4);
            node.Next.Next.Next.Next = new ListNode(5);
            node.Next.Next.Next.Next.Next = new ListNode(6);

            var res = ReverseLinkedList_UseStack(node);
            Console.WriteLine("Hello World!");
        }

        static ListNode ReverseLinkedList(ListNode node)
        {
            ListNode res = null;
            while (node != null)
            {
                ListNode next = node.Next;
                node.Next = res;
                res = node;

                node = next;
            }

            return res;
        }
        //使用栈实现
        static ListNode ReverseLinkedList_UseStack(ListNode node)
        {
            var s = new Stack<ListNode>();
            while (node != null)
            {
                s.Push(node);
                node = node.Next;
            }

            //head边界哨兵节点保持不变
            ListNode head = s.Pop();
            ListNode last = head;
            while (s.Any())
            {
                ListNode pop = s.Pop();
                last.Next = pop;
                last = pop;
            }

            // 最后一个节点赋为null（不然会造成死循环）
            //最后一节点为1，Next记录为2，所以置空
            last.Next = null; 

            return head;
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
