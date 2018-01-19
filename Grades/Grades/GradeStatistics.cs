using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }
        public string LetterGrade
        {
            get
            {
                string result;
                if (AverageGrade >= 90)
                {
                    result = "A";
                }
                else if (AverageGrade >= 80)
                {
                    result = "B";
                }
                else if (AverageGrade >= 70)
                {
                    result = "C";
                }
                else if (AverageGrade >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }
        public string Description
        {
            get
            {
                string output;
                switch (LetterGrade)
                {


                    case "A":
                        output = "An A...Great Job!";
                        break;
                    case "B":
                        output = "A B...Not Bad.";
                        break;
                    case "C":
                        output = "A C...You can Do Better.";
                        break;
                    case "D":
                        output = "A D...You are Underperforming.";
                        break;
                    case "F":
                        output = "An F?!!!  Totally unacceptable!";
                        break;
                    default:
                        output = "Your grade is incomplete.";
                        break;
                }

                return output;

            }
            
        }
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }


}

