using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministration.Models
{
    public class Grade
    {
        public decimal Analysis { get; private set; } // wel readonly voor andere klassen.
        public decimal Design { get; private set; }
        public decimal Code { get; private set; }

        public Grade(decimal analysis, decimal design, decimal code)
        {
            Analysis = analysis;
            Design = design;
            Code = code;
            decimal[] grades = new decimal[3] { analysis, design, code };
            foreach (decimal grade in grades)
            {
                if (grade < 0 || grade > 10)
                {
                    throw new InvalidGradeException("Invalid input: " + grade);
                }
            }
        }

        [Serializable]
        public class InvalidGradeException : Exception
        {
            public InvalidGradeException()
            {
            }

            public InvalidGradeException(string message) : base(message)
            {
            }

            public InvalidGradeException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected InvalidGradeException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
