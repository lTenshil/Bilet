using System.Data.Entity;

namespace Bilet
{
    class MyDBContext : DbContext
    {
        public MyDBContext() : base("DbConnect")
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
