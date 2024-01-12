using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{

    public class MoveContext : DbContext 
    {
        private const string MYSQL_CONNECTION_STRING = "Server=localhost;Database=Born2Move;User ID=nicole;Password=4cbfBC&~*4mmQmu;Pooling=true;";
        public DbSet<Move> Moves { get; set; }
        public DbSet<MoveRating> MoveRating { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(MYSQL_CONNECTION_STRING, ServerVersion.AutoDetect(MYSQL_CONNECTION_STRING));
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}