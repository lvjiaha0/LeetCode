using System;

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

            var res = ReverseLinkedList(node);
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
