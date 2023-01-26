using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Upload
    {
        public Upload() { }
        public int Id { get; set; }
        public DateTime Zeitstempel { get; set; }
        public string URL { get; set; }
        public Applicant ApplicationNavigation { get; set; } = default!;
        public int ApplicantId { get; set; }
        public Task TaskNavigation { get; set; } = default!;
        public int TaskId { get; set; }
    }
}
