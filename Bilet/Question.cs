using System.Collections.Generic;

namespace Bilet
{
    public class Question
    {
        public int Id { get; set; }
        public string Discipline { get; set; }
        public string Questionn { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }

        public Question(string questionn)
        {
            Questionn = questionn;
        }

        public Question(string discipline, string questionn) 
        {
            Discipline = discipline;
            Questionn = questionn;
        }

        public Question(int id, string discipline, string questionn)
        {
            Id = id;
            Discipline = discipline;
            Questionn = questionn;
        }
    }
}
