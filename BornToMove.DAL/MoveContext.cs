using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL;
{

    internal class MoveContext : DbContext 
    {
        private const string MYSQL_CONNECTION_STRING = "Server=localhost; User ID=nicole; Password=cbfBC&~*4mmQmu; Database=Born2Move";
        public DbSet<Move> Move { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) 
        {
            optionsBuilder.UseMySql(MYSQL_CONNECTION_STRING, ServerVersion.AutoDetect(MYSQL_CONNECTION_STRING));
            
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }
    }
}