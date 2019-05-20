using Core.Library.Entities.Logs;
using Core.Library.Logs;
using Core.Library.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Web.Services
{
    public class LoggingService : ILoggingService
    {
        private IRepositoryBase<RequestSourceTimeLog> _logsRepository;

        public LoggingService(IRepositoryBase<RequestSourceTimeLog> logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public IEnumerable<RequestSourceTimeLog> GetLastTenLogs(int id)
        {
            int tenResults = 10;
            var wynik = Awaiter();
            var lastTenResults = wynik.Where(r => r.PositionsId == id.ToString()).Take(tenResults);
            return lastTenResults;
        }
        private IEnumerable<RequestSourceTimeLog> Awaiter()
        {
            Task<IEnumerable<RequestSourceTimeLog>> task = Task.Run(async () => await _logsRepository.FindAllAsync());
            return task.Result;
        }
        public async Task SaveCallAsync(string callSource, string id)
        {
            _logsRepository.Create(new RequestSourceTimeLog(callSource, DateTime.Now, id));
            await _logsRepository.SaveAsync();
        }
    }
}