using Core.Library.Entities;
using Core.Library.Entities.Logs;
using Core.Library.Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoardGames.Web.Controllers
{
    public class BoardGamesController : ApiController
    {
        private readonly IRepositoryBase<BoardGame> _repository;
        private readonly ILoggingService _loggingService;

        public BoardGamesController(IRepositoryBase<BoardGame> repository, ILoggingService loggingService)
        {
            _repository = repository;
            _loggingService = loggingService;
        }

        [HttpGet]
        [Route("api/BoardGames")]
        public async Task<IEnumerable<BoardGame>> Get()
        {
            return await _repository.FindAllAsync();
        }

        [HttpGet]
        [Route("api/BoardGames")]
        public async Task<IEnumerable<BoardGame>> Get(int pageSize)
        {
            return await _repository.FindSpecifiedAmount(pageSize);
        }

        public async Task<BoardGame> GetDetails(int id)
        {
            await _loggingService.SaveCallAsync("API", id.ToString());
            return await _repository.GetDetailsAsync(id);
        }
    }
}