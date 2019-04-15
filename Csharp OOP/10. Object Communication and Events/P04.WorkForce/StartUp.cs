using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.WorkForce
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var allWorkers = new List<IEmployee>();
            var allJobs = new List<Job>();

            while (input != "End")
            {
                var currentInput = input.Split();
                var commandType = currentInput[0];

                switch (commandType)
                {
                    case "StandardEmployee":
                        var standardEmployee = new StandardEmployee(currentInput[1]);
                        allWorkers.Add(standardEmployee);
                        break;
                    case "PartTimeEmployee":
                        var partTimeEmployee = new PartTimeEmployee(currentInput[1]);
                        allWorkers.Add(partTimeEmployee);
                        break;
                    case "Job":
                        var jobName = currentInput[1];
                        var hoursOfWorkRequired = int.Parse(currentInput[2]);
                        var employeeName = currentInput[3];
                        var currentEmplpoyee = allWorkers.FirstOrDefault(x => x.Name == employeeName);
                        var currentJob = new Job(currentEmplpoyee, jobName, hoursOfWorkRequired);
                        allJobs.Add(currentJob);
                        break;
                    case "Pass":
                        PassWeek(allJobs);
                        break;
                    case "Status":
                        CheckJobStatus(allJobs);
                        break;
                }


                input = Console.ReadLine();
            }
        }

        public static void CheckJobStatus(List<Job> allJobs)
        {
            foreach (var job in allJobs)
            {
                Console.WriteLine(job.StatusReport());
            }
        }

        public static void PassWeek(List<Job> allJobs)
        {
            foreach (var job in allJobs)
            {
                job.Update();
            }

            allJobs.RemoveAll(x => x.HoursOfWorkRequired <= 0);
        }
    }
}
