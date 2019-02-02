using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_7_Balanced_Parentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            string parentheses = Console.ReadLine();

            char[] openParentheses = new char[] { '(', '[', '{' };

            Stack<char> stack = new Stack<char>();

            bool isValid = true;

            for (int i = 0; i < parentheses.Length; i++)
            {
                var currentBracket = parentheses[i];

                if (openParentheses.Contains(currentBracket))
                {
                    stack.Push(currentBracket);
                    continue;
                }

                if (stack.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stack.Peek() == '(' && currentBracket == ')')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '[' && currentBracket == ']')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '{' && currentBracket == '}')
                {
                    stack.Pop();
                }
            }

            if (isValid && stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
