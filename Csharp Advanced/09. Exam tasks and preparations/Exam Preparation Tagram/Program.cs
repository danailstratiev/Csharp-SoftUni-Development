using System;
using System.Linq;
using System.Collections.Generic;


namespace Exam_Preparation_Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var users = new Dictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                var currentUser = input.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var userName = currentUser[0];

                if (userName != "ban")
                {
                    var tag = currentUser[1];
                    var likes = int.Parse(currentUser[2]);

                    if (!users.ContainsKey(userName))
                    {
                        users[userName] = new Dictionary<string, int>();
                        users[userName].Add(tag, likes);
                    }
                    else
                    {
                        if (!users[userName].ContainsKey(tag))
                        {
                            users[userName].Add(tag, likes);
                        }
                        else
                        {
                            users[userName][tag] += likes;
                        }
                    }
                }
                else
                {
                    var userToBan = currentUser[1];

                    if (users.Any(x => x.Key == userToBan))
                    {
                        users.Remove(userToBan);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var user in users.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(y => y.Value.Count))
            {
                var currentUserName = user.Key;
                var tagsAndLikes = user.Value;

                Console.WriteLine(currentUserName);
                foreach (var item in tagsAndLikes)
                {
                    Console.WriteLine($"- {item.Key}: {item.Value}");
                }
            }
        }
    }
}
