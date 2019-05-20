using Core.Library.Entities;
using Core.Library.Persistance;
using Persistance.Library;

namespace Persistance.Repository.Library
{
    public class BoardGameRepository : RepositoryBase<BoardGame>, IRepositoryBase<BoardGame>
    {
        public BoardGameRepository(BoardGamesDbContext dbContext) : base(dbContext)
        {
        }
    }
}
