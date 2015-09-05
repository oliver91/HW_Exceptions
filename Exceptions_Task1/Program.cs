using System;
using System.Text.RegularExpressions;

namespace Exceptions_Task1
{
    class Program
    {
        static void Main()
        {
            Worker[] workers = new Worker[5];

            FillingTheData(workers);

            Console.WriteLine("Workers:");
            foreach (Worker w in workers)
                Console.WriteLine(w.ToString());

            PrintExperiencedWorkers(workers);

            Console.ReadKey();
        }

        public static Worker[] FillingTheData(Worker[] workers)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                Console.WriteLine("Enter information about the Employee:");
                Console.Write("Surname And Initials: ");
                workers[i].surnameAndInitials = Console.ReadLine();
                Console.Write("\nPosition: ");
                workers[i].position = Console.ReadLine();

                while (true)
                {
                    try
                    {
                        Console.Write("\nYear of joining (format: yyyy ): ");
                        string yearStr = Console.ReadLine();
                        Regex rgx = new Regex(@"^\d{4}$");
                        if (!rgx.IsMatch(yearStr))
                        {
                            throw new YearFormatException();
                        }
                        workers[i].yearOfJoining = UInt16.Parse(yearStr);
                    }
                    catch (YearFormatException yEx)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(yEx.Message);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Try again.");
                        continue;
                    }
                    break;
                }

                Console.WriteLine("\n");
            }
            Array.Sort<Worker>(workers, (w1, w2) => w1.surnameAndInitials.CompareTo(w2.surnameAndInitials));
            return workers;
        }

        public static void PrintExperiencedWorkers(Worker[] workers)
        {
            Console.WriteLine("\nEnter desired work experience: ");
            byte enteredExp = Byte.Parse(Console.ReadLine());
            foreach (Worker w in workers)
            {
                if((DateTime.Today.Year - w.yearOfJoining) > enteredExp)
                    Console.WriteLine(w.ToString());
            }
        }
    }

    public struct Worker
    {
        public string surnameAndInitials;
        public string position;
        public ushort yearOfJoining;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", surnameAndInitials, position, yearOfJoining);
        }
    }
}
