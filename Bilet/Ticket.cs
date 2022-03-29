namespace Bilet
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

    }
}
