using System;

namespace AppleEventsCreator
{
    public readonly struct AppleEvent
    {
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public string Summary { get; }
        public string Description { get; }

        public AppleEvent(DateTime startDateTime, DateTime endDateTime, string summary, string description)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Summary = summary;
            Description = description;
        }
    }
}
