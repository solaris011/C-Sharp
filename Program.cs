using System;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            int examAssignments = 5;

            // Students and their scores
            string[] studentNames = { "Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "Gregor" };
            int[][] studentScores = {
                new int[] { 90, 86, 87, 98, 100, 94, 90 },
                new int[] { 92, 89, 81, 96, 90, 89 },
                new int[] { 90, 85, 87, 98, 68, 89, 89, 89 },
                new int[] { 90, 95, 87, 88, 96, 96 },
                new int[] { 92, 91, 90, 91, 92, 92, 92 },
                new int[] { 84, 86, 88, 90, 92, 94, 96, 98 },
                new int[] { 80, 90, 100, 80, 90, 100, 80, 90 },
                new int[] { 91, 91, 91, 91, 91, 91, 91 }
            };

            GenerateReport(studentNames, studentScores, examAssignments);
        }

        static void GenerateReport(string[] studentNames, int[][] studentScores, int examAssignments)
        {
            Console.WriteLine("Student\t\tGrade\n");

            for (int i = 0; i < studentNames.Length; i++)
            {
                string name = studentNames[i];
                int[] scores = studentScores[i];

                decimal averageGrade = CalculateGrade(scores, examAssignments);
                string letterGrade = DetermineLetterGrade(averageGrade);

                PrintStudentGrade(name, averageGrade, letterGrade);
            }
        }

        static decimal CalculateGrade(int[] scores, int examAssignments)
        {
            int sumAssignmentScores = 0;
            int gradedAssignments = 0;

            foreach (int score in scores)
            {
                gradedAssignments++;
                if (gradedAssignments <= examAssignments)
                    sumAssignmentScores += score;
                else
                    sumAssignmentScores += score / 10;
            }

            return (decimal)sumAssignmentScores / examAssignments;
        }

        static string DetermineLetterGrade(decimal grade)
        {
            return grade switch
            {
                >= 97 => "A+",
                >= 93 => "A",
                >= 90 => "A-",
                >= 87 => "B+",
                >= 83 => "B",
                >= 80 => "B-",
                >= 77 => "C+",
                >= 73 => "C",
                >= 70 => "C-",
                >= 67 => "D+",
                >= 63 => "D",
                >= 60 => "D-",
                _ => "F"
            };
        }

        static void PrintStudentGrade(string name, decimal averageGrade, string letterGrade)
        {
            Console.WriteLine($"{name}\t\t{averageGrade:F2}\t{letterGrade}");
        }
    }
}
