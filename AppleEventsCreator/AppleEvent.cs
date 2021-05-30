using System;

namespace AppleEventsCreator
{
    public class AppleEvent
    {
        public DateTime CreateDateTime { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public string Summary { get; }
        public string Description { get; }

        public AppleEvent(DateTime createDateTime, DateTime startDateTime, DateTime endDateTime, string summary, string description)
        {
            CreateDateTime = createDateTime;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Summary = summary;
            Description = description;
        }
    }
}
