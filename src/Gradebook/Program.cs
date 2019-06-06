using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("Naj's Grade Book");
            book.GradeAdded += OnGradeAdded;
            // book.AddGrade(44.2);
            // book.AddGrade(99.2);
            // book.AddGrade(22.3);
            EnterGrades(book);
            Statistics stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low:N2}");
            Console.WriteLine($"The highest grade is {stats.High:N2}");
            Console.WriteLine($"The average is {stats.Average:N2}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            var input = "none";
            var grade = double.MinValue;

            do
            {
                Console.Write("Enter a grade or enter 'q' to quit: ");
                input = Console.ReadLine();

                if (input != "q")
                {
                    try
                    {
                        grade = double.Parse(input);
                        book.AddGrade(grade);
                    }

                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Exception encountered {e}");
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Exception encountered {e}");
                    }
                }

            } while (input != "q");
        }

        static void OnGradeAdded(object sender, EventArgs e)
            {
                Console.WriteLine("A grade is added");
            }
    }
}
