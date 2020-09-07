using Commander.Model;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {

        //usng EF core to connect with database
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }

        public DbSet<Command> Commands { get; set; }
    }
}