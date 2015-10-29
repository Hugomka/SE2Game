using System;
using System.Collections.Generic;

namespace StudentAdministration.Models
{
    public class Student
    {
        private readonly int id = -1;

        public int Id { get { return id; } }
        public string Name { get; set; }
        public string Email { get; set; }

        public Student(int id, string name, string email)
        {
            // Domain logic: email address should be "properly" formed
            bool atMissing = email.IndexOf("@", 2) == -1;
            bool dotMissing = email.IndexOf(".", email.IndexOf("@", 2) + 2) == -1;
            bool toplevelMissing = email.Length - email.IndexOf(".", email.IndexOf("@", 2) + 2) < 2;

            // Evaluate the booleans determined above
            if (atMissing || dotMissing || toplevelMissing)
            {
                string message = "The email address {0} has an invalid format";
                throw new FormatException(String.Format(message, email));
            }

            this.id = id;
            this.Name = name;
            this.Email = email;
        }

        public Student(string name, string email)
            : this(-1, name, email)
        {
        }

        public override string ToString()
        {
            return String.Format("{0:0000}: {1} ({2})", id, Name, Email);
        }
    }
}
