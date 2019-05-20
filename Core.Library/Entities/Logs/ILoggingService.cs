using Core.Library.Logs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Library.Entities.Logs
{
    public interface ILoggingService
    {
        Task SaveCallAsync(string callSource, string id);
        IEnumerable<RequestSourceTimeLog> GetLastTenLogs(int id);
    }
}
