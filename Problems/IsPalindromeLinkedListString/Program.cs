using System;

namespace IsPalindromeLinkedListString
{
    class Program
    {
        static void Main(string[] args)
        {
            var lis = new LinkedList<char>();
            var test1 = new LinkedListNode<char>('1');
            var test2 = new LinkedListNode<char>('2');
            var test_1 = new LinkedListNode<char>('1');
            lis.AddFirst(test1);
            lis.AddAfter(test1, test2);
            lis.AddAfter(test2, test_1);
            Console.WriteLine("Hello World!");
        }

        static bool IsPalindromeString(LinkedList<char> input)
        {
            input.
        }
    }
}
