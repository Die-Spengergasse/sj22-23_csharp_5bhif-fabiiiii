using System;
using System.Collections.Generic;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Applicant
    {
        
        public Applicant() { }

        public Applicant(Department departmentNavigation, ApplicantStatus applicantStatusNavigation) {
            DepartmentNavigation = departmentNavigation;
            ApplicantStatusNavigation = applicantStatusNavigation;
        }

        public Applicant(string vorname, string nachName, DateTime geburtsdatum, Department departmentNavigation, ApplicantStatus applicantStatusNavigation)
        {
            Vorname = vorname;
            NachName = nachName;
            Geburtsdatum = geburtsdatum;
            DepartmentNavigation = departmentNavigation;
            ApplicantStatusNavigation = applicantStatusNavigation;
        }

        public int Id { get; set; } // Id wird automatisch zu PK, int wird automatisch zu auto incrementS
        public string Vorname { get; set; }
        public string NachName { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public List<Upload> Uploads { get; set; } = new();
        public Department DepartmentNavigation { get; set; }
        public int DepartmentId { get; set; }
        public ApplicantStatus ApplicantStatusNavigation  { get; set; }
        public int ApplicantStatusId { get; set; }
    }
}
