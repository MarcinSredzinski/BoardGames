using Core.Library.Entities;
using System;

namespace Core.Library.Logs
{
    public class RequestSourceTimeLog : BaseEntity
    {
        public RequestSourceTimeLog(string requestSource, DateTime requestDateTime, string positionsId)
        {
            RequestSource = requestSource;
            RequestDateTime = requestDateTime;
            PositionsId = positionsId;
        }

        public string RequestSource { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string PositionsId { get; set; }
    }
}