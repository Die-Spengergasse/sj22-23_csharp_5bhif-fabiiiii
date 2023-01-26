using System;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class ApplicantStatus
    {
        public ApplicantStatus() { }

        public ApplicantStatus(DateTime ratedDate, bool passed)
        {
            RatedDate = ratedDate;
            Passed = passed;
        }

        public int Id { get; set; }
        public DateTime RatedDate { get; set; }
        public bool Passed { get; set; }
    }
}
