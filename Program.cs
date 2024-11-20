using System;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            initialize();
        }

        static void initialize(){
            int examAssignments = 5;

            int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
            int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
            int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
            int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };
            int[] beckyScores = new int[] { 92, 91, 90, 91, 92, 92, 92 };
            int[] chrisScores = new int[] { 84, 86, 88, 90, 92, 94, 96, 98 };
            int[] ericScores = new int[] { 80, 90, 100, 80, 90, 100, 80, 90 };
            int[] gregorScores = new int[] { 91, 91, 91, 91, 91, 91, 91 };    

            // Student names
            string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "Gregor" };

            int[] studentScores = new int[10];
            string currentStudentLetterGrade = "";

            // Write the Report Header to the console
            Console.WriteLine("Student\t\tGrade\n");
            foreach (string name in studentNames)
            {
                string currentStudent = name;

                if (currentStudent == "Sophia")
                    studentScores = sophiaScores;
                else if (currentStudent == "Andrew")
                    studentScores = andrewScores;
                else if (currentStudent == "Emma")
                    studentScores = emmaScores;
                else if (currentStudent == "Logan")
                    studentScores = loganScores;
                else if (currentStudent == "Becky")
                    studentScores = beckyScores;
                else if (currentStudent == "Chris")
                    studentScores = chrisScores;
                else if (currentStudent == "Eric")
                    studentScores = ericScores;
                else if (currentStudent == "Gregor")
                    studentScores = gregorScores;
                else
                    continue;
                    
                // initialize/reset the sum of scored assignments
                int sumAssignmentScores = 0;

                // initialize/reset the calculated average of exam + extra credit scores
                decimal currentStudentGrade = 0;
                int gradedAssignments = 0;


                foreach (int score in studentScores)
                {
                    gradedAssignments += 1;

                    if (gradedAssignments <= examAssignments)
                        sumAssignmentScores += score;
                    else
                        sumAssignmentScores += score / 10;                                   
                }

                currentStudentGrade = (decimal)(sumAssignmentScores) / examAssignments;

                switch(currentStudentGrade) 
                {
                case >= 97:
                    currentStudentLetterGrade = "A+";
                    break;
                case >= 93:
                    currentStudentLetterGrade = "A";
                    break;
                case >= 90:
                    currentStudentLetterGrade = "A-";
                    break;
                case >= 87:
                    currentStudentLetterGrade = "B+";
                    break;
                case >= 83:
                    currentStudentLetterGrade = "B";
                    break;
                case >= 80:
                    currentStudentLetterGrade = "B-";
                    break;
                case >= 77:
                    currentStudentLetterGrade = "C+";
                    break;
                case >= 73:
                    currentStudentLetterGrade = "C";
                    break;
                case >= 70:
                    currentStudentLetterGrade = "C-";
                    break;
                case >= 67:
                    currentStudentLetterGrade = "D+";
                    break;
                case >= 63:
                    currentStudentLetterGrade = "D";
                    break;
                case >= 60:
                    currentStudentLetterGrade = "D-";
                    break;
                default:
                    currentStudentLetterGrade = "F";
                    break;
                }
                Console.WriteLine($"{currentStudent}\t\t{currentStudentGrade}\t{currentStudentLetterGrade}");
            }
        }
    }
}

