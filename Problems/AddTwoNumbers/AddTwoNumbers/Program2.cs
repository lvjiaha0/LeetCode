using System;
using System.Collections;


//给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。

//如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。

//您可以假设除了数字 0 之外，这两个数都不会以 0 开头。

//示例：

//输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
//输出：7 -> 0 -> 8
//原因：342 + 465 = 807
namespace AddTwoNumbers
{
    class Program2
    {
        static void Main(string[] args)
        {
            ListNode l1 = new Program().ConstructList(new int[] { 1 });

            ListNode l2 = new Program().ConstructList(new int[] { 9, 9 });


            ListNode res = new Program2().AddTwoNumbers(l1, l2);
            ListNode head = res;

            Console.ReadKey();
        }


        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            ListNode temp = new ListNode(0);
            ListNode p = l1, q = l2, cursor = temp;

            while (p != null || q != null || carry != 0)
            {
                int pVal = p == null ? 0 : p.val;
                int qVal = q == null ? 0 : q.val;
                int newVal = pVal + qVal + carry;
                carry = newVal / 10;
                cursor.next = new ListNode(newVal % 10);
                cursor = cursor.next;
                if (p?.next == null && q?.next == null && carry == 0)
                {
                    break;
                }

                p = p?.next;
                q = q?.next;
            }

            return temp.next;
        }

    }

}
