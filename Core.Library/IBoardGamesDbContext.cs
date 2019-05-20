using Core.Library.Entities;
using Core.Library.Logs;
using Microsoft.EntityFrameworkCore;

namespace Core.Library
{
    public interface IBoardGamesDbContext
    {
        DbSet<BoardGame> BoardGames { get; set; }
        DbSet<RequestSourceTimeLog> RequestSourceTimeLogs { get; set; }

    }
}
