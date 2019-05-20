using Core.Library;
using Core.Library.Entities;
using Core.Library.Logs;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Library
{
    public class BoardGamesDbContext : DbContext, IBoardGamesDbContext
    {    
        public BoardGamesDbContext() : base(GetOptions())
        {
        }
        
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<RequestSourceTimeLog> RequestSourceTimeLogs { get; set; }
        private static DbContextOptions GetOptions(string  connectionString ="//TODO insert your connection string here!" )
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
