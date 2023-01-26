using System;

namespace SPG_Fachtheorie.Aufgabe2.Model
{
    public class Teacher
    {
        public Teacher() { }

        public Teacher(string firstname, string lastname, string email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
