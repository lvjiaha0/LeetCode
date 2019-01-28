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

    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new Program().ConstructList(new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });

            ListNode l2 = new Program().ConstructList(new int[] { 5, 6, 4 });


            ListNode res = new Program().AddTwoNumbers(l1, l2);
            ListNode head = res;

            Console.ReadKey();
        }

        public ListNode ConstructList(int[] arr)
        {
            ListNode head = new ListNode(arr[0]);
            ListNode res = head;
            for (int i = 1; i <= arr.Length - 1; i++)
            {
                head.next = new ListNode(arr[i]);
                head = head.next;
            }

            return res;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode l1Re = Revert(l1);
            ListNode l2Re = Revert(l2);
            long val1 = Convert2Number(l1Re);
            long val2 = Convert2Number(l2Re);
            long resVal = val1 + val2;

            long[] resArr = DigitArr(resVal);
            ListNode head = new ListNode((int)resArr[0]);
            ListNode res = head;
            for (int i = 1; i <= resArr.Length - 1; i++)
            {
                head.next = new ListNode((int)resArr[i]);
                head = head.next;
            }

            return Revert(res);
        }

        public ListNode Revert(ListNode node)
        {
            ListNode headNode = node;
            ListNode res = node;
            if (headNode.next != null)
            {
                ListNode preNode = headNode.next;
                while (Put(headNode, preNode))
                {
                    if (preNode.next == null)
                    {
                        break;
                    }
                }
                res = res.next;
                headNode.next = null;
                preNode.next = headNode;
            }

            return res;
        }

        public long Convert2Number(ListNode node)
        {
            long res = 0;
            while (node != null)
            {
                res += node.val;
                if (node.next != null)
                {
                    res *= 10;
                }
                node = node.next;
            }

            return res;
        }

        public long[] DigitArr(long n)
        {
            if (n == 0) return new long[1] { 0 };

            int length = n.ToString().Length;
            var digits = new long[length];

            for (; n != 0; n /= 10)
            {
                digits[length - 1] = n % 10;
                length -= 1;
            }

            return digits;
        }

        public bool Put(ListNode headNode, ListNode preNode)
        {
            bool res = false;
            ListNode popedNode = PopNext(preNode);
            if (popedNode != null)
            {
                InsertAfterHead(headNode, popedNode);
                res = true;
            }
            return res;
        }

        public void InsertAfterHead(ListNode headNode, ListNode newNode)
        {
            ListNode nextNode = headNode.next;
            headNode.next = newNode;
            newNode.next = nextNode;
        }

        public ListNode PopNext(ListNode preNode)
        {
            ListNode popedNode = preNode.next;
            if (popedNode != null)
            {
                ListNode nextNode = popedNode.next;
                preNode.next = nextNode;
                popedNode.next = null;
            }
            return popedNode;
        }
    }

}
