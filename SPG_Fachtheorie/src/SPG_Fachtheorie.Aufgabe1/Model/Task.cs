using System;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Task
    {
        public Task() { }

        public Task(string text, DateTime dateFrom, DateTime dateTo, Department departmentNavigation)
        {
            Text = text;
            DateFrom = dateFrom;
            DateTo = dateTo;
            DepartmentNavigation = departmentNavigation;
        }

        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Department DepartmentNavigation { get; set; }
        public int DepartmentId { get; set; }
       
    }
}
