namespace SPG_Fachtheorie.Aufgabe2.Model
{
    public class Subject
    {
        public Subject() { }

        public Subject(string shortname, string longmame)
        {
            Shortname = shortname;
            Longmame = longmame;
        }

        public string Shortname { get; set; }
        public string Longmame { get; set; }
    }
}
