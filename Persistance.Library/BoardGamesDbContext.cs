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
        private static DbContextOptions GetOptions(string  connectionString = "Server=tcp:bestboardbase.database.windows.net,1433;Initial Catalog=BestBoardBase;Persist Security Info=False;User ID={board};Password={Games1234};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Data Source=bestboardbase.database.windows.net;Initial Catalog=BestBoardBase;User ID=board;Password=Games1234;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
