using System;

/// <summary>
/// 删除链表倒数第 n 个结点, n为有效值
/// </summary>
namespace LinkedListRemoveNthFromEnd
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

            var res = RemoveNthFromEnd2(node, 1);
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 法1:遍历一遍求长度，再删除长度-n个Node
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int length = 1;
            ListNode cur = head;
            while (cur.Next != null)
            {
                cur = cur.Next;
                length += 1;
            }

            //删第一个
            if (n == length)
            {
                return head.Next;
            }
            else
            {
                ListNode pre = head;
                for (int i = 1; i < length - n; i++)
                {
                    pre = pre.Next;
                }
                ListNode del = pre.Next;
                if (del.Next != null)
                {
                    pre.Next = del.Next;
                }
                else
                {
                    pre.Next = null;
                }
                return head;
            }
        }

        /// <summary>
        /// 法2:快慢指针，快指针提前走N个，慢指针最终指向删除Node的前一个
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            ListNode slow = head;
            ListNode fast = head;
            for (int i = 0; i < n; i++)
            {
                fast = fast.Next;
            }

            //删第一个
            if (fast == null)
            {
                return head.Next;
            }
            else
            {
                while (fast.Next != null)
                {
                    fast = fast.Next;
                    slow = slow.Next;
                }

                ListNode del = slow.Next;
                if (del.Next != null)
                {
                    slow.Next = del.Next;
                }
                else
                {
                    slow.Next = null;
                }

                return head;
            }

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
