using System;
using System.Linq;
using System.Collections.Generic;


namespace Demo_Exam_Task_1_Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftSocks = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var rightSocks = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var pairsOfSocks = new List<int>();

            var leftSocksStack = new Stack<int>(leftSocks);
            var rightSocksQueue = new Queue<int>(rightSocks);

            while (true)
            {
                if (leftSocksStack.Count <= 0 || rightSocksQueue.Count <= 0)
                {
                    break;
                }

                var leftSock = leftSocksStack.Peek();
                var rightSock = rightSocksQueue.First();

                if (leftSock > rightSock)
                {
                    var pair = leftSock + rightSock;
                    pairsOfSocks.Add(pair);

                    leftSocksStack.Pop();
                    rightSocksQueue.Dequeue();

                    continue;
                }
                else if(rightSock > leftSock)
                {
                    leftSocksStack.Pop();

                    continue;
                }
                else
                {
                    leftSock++;
                    rightSocksQueue.Dequeue();

                    while (rightSocksQueue.Count > 0)
                    {
                        rightSock = rightSocksQueue.First();

                        if (leftSock > rightSock)
                        {
                            var pair = leftSock + rightSock;
                            pairsOfSocks.Add(pair);

                            leftSocksStack.Pop();
                            rightSocksQueue.Dequeue();

                            break; ;
                        }
                        else if (rightSock > leftSock)
                        {
                            leftSocksStack.Pop();

                            break;
                        }
                        else
                        {
                            leftSock++;
                            rightSocksQueue.Dequeue();
                            continue;
                        }
                    }
                    continue;
                }
            }


            Console.WriteLine(pairsOfSocks.Max());
            Console.WriteLine(string.Join(" ", pairsOfSocks));
        }
    }
}
