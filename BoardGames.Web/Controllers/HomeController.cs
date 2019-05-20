using BoardGames.Web.ViewModels;
using Core.Library.Entities;
using Core.Library.Entities.Logs;
using Core.Library.Logs;
using Core.Library.Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BoardGames.Web.Controllers
{
    public class HomeController : BaseController<BoardGame>
    {
        private readonly IRepositoryBase<BoardGame> _repository;
        private readonly ILoggingService _loggingService;

        public HomeController(IRepositoryBase<BoardGame> repository, ILoggingService loggingService) : base(repository)
        {
            _repository = repository;
            _loggingService = loggingService;
        }

        [HttpGet]
        public override async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                int nnid = id.GetValueOrDefault();
                await _loggingService.SaveCallAsync("Web page", nnid.ToString());
                IEnumerable<RequestSourceTimeLog> logs = _loggingService.GetLastTenLogs(nnid);
                BoardGame gameDetails = await _repository.GetDetailsAsync(nnid);
                return View(new DetailsViewModel() { BoardGameDetailed = gameDetails, Logs = logs });

            }


        }
        // POST: BoardGames/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<ActionResult> Create([Bind(Include = "Id,Name,MinNumberOfPlayers,MaxNumberOfPlayers,MinimalAge,PublicationDate")] BoardGame boardGame)
        {
            return await base.Create(boardGame);
        }

        // POST: BoardGames/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<ActionResult> Edit(int id, [Bind(Include = "Id,Name,MinNumberOfPlayers,MaxNumberOfPlayers,MinimalAge,PublicationDate")] BoardGame boardGame)
        {
            return await base.Edit(boardGame.Id, boardGame);
        }
    }
}