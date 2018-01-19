using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            // synth.Speak("Hello! This is the grade book program");
            IGradeTracker book = CreateGradeBook();

            //GetBookName(book);
            AddGrades(book);

            SaveGrades(book);
            WriteResults(book);

            //synth.Speak("Average Grade is " + stats.AverageGrade);
            //synth.Speak("Highest Grade is " + stats.HighestGrade);
            //synth.Speak("Lowest Grade is " + stats.LowestGrade);
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);

            }

            WriteResult("Average Grade", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
            Console.WriteLine(stats.Description);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {

                book.WriteGrades(outputFile);

            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
                Console.WriteLine(book.Name);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }


        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }
        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}" );
        }
    }
}
