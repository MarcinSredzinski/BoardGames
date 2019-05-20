using Core.Library.Entities;
using Core.Library.Logs;
using System.Collections.Generic;

namespace BoardGames.Web.ViewModels
{
    public class DetailsViewModel
    {
        public BoardGame BoardGameDetailed { get; set; }
        public IEnumerable<RequestSourceTimeLog> Logs { get; set; }
    }
}