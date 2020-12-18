using System;

/// <summary>
/// 21. 合并两个有序链表
/// 将两个升序链表合并为一个新的 升序 链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 
/// 示例：
/// 输入：1->2->4, 1->3->4
/// 输出：1->1->2->3->4->4
/// </summary>
namespace MergeTwoLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new ListNode(1);
            node1.Next = new ListNode(3);
            node1.Next.Next = new ListNode(5);
            node1.Next.Next.Next = new ListNode(7);
            node1.Next.Next.Next.Next = new ListNode(9);

            var node2 = new ListNode(2);
            node2.Next = new ListNode(4);
            node2.Next.Next = new ListNode(6);
            node2.Next.Next.Next = new ListNode(8);
            node2.Next.Next.Next.Next = new ListNode(10);

            ListNode res = MergeTwoLinkedLists(node1, node2);
            Console.WriteLine("Hello World!");
        }

        public static ListNode MergeTwoLinkedLists(ListNode head1, ListNode head2)
        {
            //定义临时目标链头，值为-1
            ListNode preHead = new ListNode(-1);
            MergeTwoLinkedListsInner(preHead, head1, head2);
            return preHead.Next;
        }

        /// <summary>
        /// 递归给目标链串联下一个
        /// </summary>
        /// <param name="res"></param>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        public static void MergeTwoLinkedListsInner(ListNode res, ListNode head1, ListNode head2)
        {
            if (head1 == null || head2 == null)
            {
                res.Next = head1 ?? head2;
            }
            else
            {
                if (head1.Value < head2.Value)
                {
                    res.Next = head1;
                    MergeTwoLinkedListsInner(res.Next, head1.Next, head2);
                }
                else
                {
                    res.Next = head2;
                    MergeTwoLinkedListsInner(res.Next, head1, head2.Next);
                }
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
