using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace Exercise_09_Simple_Text_Editor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split();

                var currentCommand = commands[0];

                if (currentCommand == "1")
                {
                    string currentText = commands[1];
                    stack.Push(text);

                    text += currentText;
                }
                else if (currentCommand == "2")
                {
                    int count = int.Parse(commands[1]);

                    if (count > text.Length)
                    {
                        count = Math.Min(text.Length, count);
                    }

                    stack.Push(text);
                    text = text.Substring(0, text.Length - count);
                }
                else if (currentCommand == "3")
                {
                    int index = int.Parse(commands[1]);
                    Console.WriteLine(text[index-1]);
                }
                else if (currentCommand == "4")
                {
                    text = stack.Pop();
                }
            }
        }
    }
}
