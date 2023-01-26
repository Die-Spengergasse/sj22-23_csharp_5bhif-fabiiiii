using System;

namespace SPG_Fachtheorie.Aufgabe2.Model
{
    public class Class
    {
        public Class() { 

        }

        public Class(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
