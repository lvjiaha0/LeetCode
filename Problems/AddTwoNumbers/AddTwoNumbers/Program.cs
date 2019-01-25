﻿using System;
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
            Console.WriteLine("Hello World!");
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode headNode1 = l1;
            ListNode headNode2 = l2;
        }

        public ListNode Revert(ListNode node, ListNode currentNode)
        {
            ListNode headNode = node;
            ListNode preNode = headNode.next;
            ListNode newNode = preNode.next;
            while (newNode != null && Put(headNode, preNode, newNode))
            {
                preNode
            }

        }

        public bool Put(ListNode headNode, ListNode preNode, ListNode newNode)
        {
            bool res = false;
            ListNode deletedNode = DeleteNext(preNode);
            if (deletedNode != null)
            {
                InsertAfterHead(headNode, deletedNode);
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

        public ListNode DeleteNext(ListNode preNode)
        {
            ListNode deletedNode = preNode.next;
            if (deletedNode != null)
            {
                ListNode nextNode = deletedNode.next;
                preNode.next = nextNode;
                deletedNode.next = null;
            }
            return deletedNode;
        }
    }

}
