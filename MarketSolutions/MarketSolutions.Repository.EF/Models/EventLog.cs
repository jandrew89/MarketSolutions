using System;
using System.Collections.Generic;

namespace MarketSolutions.Repository.EF.Models
{
    public partial class EventLog
    {
        public int EventLogID { get; set; }
        public int EventType { get; set; }
        public string Key { get; set; }
        public string Message { get; set; }
        public System.DateTime EntryDate { get; set; }
    }
}
