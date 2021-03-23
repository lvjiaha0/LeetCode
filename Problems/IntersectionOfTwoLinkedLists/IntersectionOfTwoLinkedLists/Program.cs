using System;

namespace IntersectionOfTwoLinkedLists
{

    //160. 相交链表
    //编写一个程序，找到两个单链表相交的起始节点。
    //如下面的两个链表：

    //在节点 c1 开始相交。
    //示例 1：

    //输入：intersectVal = 8, listA = [4,1,8,4,5], listB = [5,0,1,8,4,5], skipA = 2, skipB = 3
    //输出：Reference of the node with value = 8
    //输入解释：相交节点的值为 8 （注意，如果两个链表相交则不能为 0）。从各自的表头开始算起，链表 A 为[4, 1, 8, 4, 5]，链表 B 为[5, 0, 1, 8, 4, 5]。在 A 中，相交节点前有 2 个节点；在 B 中，相交节点前有 3 个节点。

    //示例 2：

    //输入：intersectVal = 2, listA = [0,9,1,2,4], listB = [3,2,4], skipA = 3, skipB = 1
    //输出：Reference of the node with value = 2
    //输入解释：相交节点的值为 2 （注意，如果两个链表相交则不能为 0）。从各自的表头开始算起，链表 A 为[0, 9, 1, 2, 4]，链表 B 为[3, 2, 4]。在 A 中，相交节点前有 3 个节点；在 B 中，相交节点前有 1 个节点。

    //示例 3：

    //输入：intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
    //输出：null
    //输入解释：从各自的表头开始算起，链表 A 为[2, 6, 4]，链表 B 为[1, 5]。由于这两个链表不相交，所以 intersectVal 必须为 0，而 skipA 和 skipB 可以是任意值。
    //解释：这两个链表不相交，因此返回 null。


    //注意：
    //如果两个链表没有交点，返回 null.
    //在返回结果后，两个链表仍须保持原有的结构。
    //可假定整个链表结构中没有循环。
    //程序尽量满足 O(n) 时间复杂度，且仅用 O(1) 内存。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        //方法三：双指针法
        //创建两个指针 pApA 和 pBpB，分别初始化为链表 A 和 B 的头结点。然后让它们向后逐结点遍历。
        //当 pApA 到达链表的尾部时，将它重定位到链表 B 的头结点(你没看错，就是链表 B); 类似的，当 pBpB 到达链表的尾部时，将它重定位到链表 A 的头结点。
        //若在某一时刻 pApA 和 pBpB 相遇，则 pApA/pBpB 为相交结点。
        //想弄清楚为什么这样可行, 可以考虑以下两个链表: A={1,3,5,7,9,11} 和 B = { 2, 4, 9, 11 }，相交于结点 9。 由于 B.length(=4) < A.length(=6)，pBpB 比 pApA 少经过 22 个结点，会先到达尾部。将 pBpB 重定向到 A 的头结点，pApA 重定向到 B 的头结点后，pBpB 要比 pApA 多走 2 个结点。因此，它们会同时到达交点。
        //如果两个链表存在相交，它们末尾的结点必然相同。因此当 pA/pB 到达链表结尾时，记录下链表 A/B 对应的元素。若最后元素不相同，则两个链表不相交。

        //复杂度分析
        //时间复杂度 : O(m+n)。
        //空间复杂度 : O(1)。
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode curr1 = headA;
            ListNode curr2 = headB;
            ListNode lastA = null;
            ListNode lastB = null;
            while (curr1 != curr2)
            {
                if (curr1.next == null)
                {
                    if (lastA == null)
                    {
                        lastA = curr1;
                    }
                    curr1 = headB;
                }
                else
                {
                    curr1 = curr1.next;
                }

                if (curr2.next == null)
                {
                    if (lastB == null)
                    {
                        lastB = curr2;
                    }
                    curr2 = headA;
                }
                else
                {
                    curr2 = curr2.next;
                }

                //如果两个链表存在相交，它们末尾的结点必然相同
                if (lastA != null && lastB != null && lastA != lastB)
                {
                    return null;
                }
            }

            return curr1;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
