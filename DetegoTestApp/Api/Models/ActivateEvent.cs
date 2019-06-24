using System;

namespace Api.Models
{
    public class ActivateEvent
    {
        public int Id { get; set; }

        public DateTime EventTime { get; set; }

        public TagInfo TagInfo { get; set; }
    }
}