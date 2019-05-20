using Core.Library.Logs;
using Core.Library.Persistance;
using Persistance.Library;

namespace Persistance.Repository.Library
{
    public class LogsRepository : RepositoryBase<RequestSourceTimeLog>, IRepositoryBase<RequestSourceTimeLog>
    {
        public LogsRepository(BoardGamesDbContext dbContext) : base(dbContext)
        {
        }
    }
}
