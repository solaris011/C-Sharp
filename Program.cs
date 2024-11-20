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
            decimal[][] studentScores = [
                [ 90, 86, 87, 98, 100, 94, 90 ],
                [ 92, 89, 81, 96, 90, 89 ],
                [ 90, 85, 87, 98, 68, 89, 89, 89 ],
                [ 90, 95, 87, 88, 96, 96 ],
                [ 92, 91, 90, 91, 92, 92, 92 ],
                [ 84, 86, 88, 90, 92, 94, 96, 98 ],
                [ 80, 90, 100, 80, 90, 100, 80, 90 ],
                [ 91, 91, 91, 91, 91, 91, 91 ]
            ];

            GenerateReport(studentNames, studentScores, examAssignments);
        }

        static void GenerateReport(string[] studentNames, decimal[][] studentScores, int examAssignments)
        {
            Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit\n");

            for (int i = 0; i < studentNames.Length; i++)
            {
                string name = studentNames[i];
                decimal[] scores = studentScores[i];

                decimal[] scoresAverages = CalculateGrade(scores, examAssignments);
                string letterGrade = DetermineLetterGrade(scoresAverages[1]);

                PrintStudentGrade(name, scoresAverages, letterGrade);
            }
        }

        static decimal[] CalculateGrade(decimal[] scores, int examAssignments)
        {
            decimal examAvgScore = 0;
            decimal overallGradeScore = 0;
            int extraCreditAvg = 0;
            //decimal extraCreditPoints = 0;
            int gradedAssignments = 0;
            decimal[] scoresAvg = new decimal[4];

            foreach (decimal score in scores)
            {
                gradedAssignments++;
                if (gradedAssignments <= examAssignments) 
                {
                    examAvgScore += score;
                    overallGradeScore += score;
                }
                else
                {
                    extraCreditAvg += (int)score;
                    overallGradeScore += score / 10;
                }
            }

            scoresAvg[0] = examAvgScore / examAssignments;
            scoresAvg[1] = overallGradeScore / examAssignments;
            scoresAvg[2] = extraCreditAvg / (scores.Length - examAssignments);
            scoresAvg[3] = scoresAvg[1] - scoresAvg[0];

            return scoresAvg;
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

        static void PrintStudentGrade(string name, decimal[] scoreAvgs, string letterGrade)
        {
            Console.WriteLine($"{name}\t\t{scoreAvgs[0]:F1}\t\t{scoreAvgs[1]:F2}\t{letterGrade}\t{scoreAvgs[2]} ({scoreAvgs[3]:F2} pts)");
        }
    }
}
