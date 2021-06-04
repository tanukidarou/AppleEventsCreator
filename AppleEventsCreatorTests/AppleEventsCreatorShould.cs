using NUnit.Framework;
using AppleEventsCreator;
using System;
using System.Collections.Generic;

namespace AppleEventsCreatorTests
{
    public class AppleEventsCreatorShould
    {
        private readonly DateTime SomeStartDateTime = new DateTime(628219086000000000);
        private readonly DateTime SomeEndDateTime = new DateTime(628219086000000000).AddHours(1);
        private readonly string SomeSummary = "SomeSummary";
        private readonly string SomeDescription = "SomeDescription";

        private AppleEventsCreatorService service;

        [SetUp]
        public void Setup()
        {
            service = new AppleEventsCreatorService();
        }

        [Test]
        public void Create_Event_Start_With_Calendar_Tag()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            Assert.AreEqual("BEGIN:VCALENDAR", result.Data.Substring(0, 15));
        }

        [Test]
        public void Create_Event_With_Version_Tag()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            Assert.AreNotEqual(-1, result.Data.IndexOf("VERSION:2.0"));
        }

        [Test]
        public void Create_Event_With_Some_Start_Event_Tag()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            Assert.AreNotEqual(-1, result.Data.IndexOf("BEGIN:VEVENT"));
        }

        [Test]
        public void Create_Event_With_Some_Create_DateTime()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            var expectedResult = "CREATED:";
            Assert.AreNotEqual(-1, result.Data.IndexOf(expectedResult));
        }

        [Test]
        public void Create_Event_With_Start_DateTime()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            var expectedResult = "DTSTART:" + FormatDateTime(SomeStartDateTime);
            Assert.AreNotEqual(-1, result.Data.IndexOf(expectedResult));
        }

        [Test]
        public void Create_Event_With_End_DateTime()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            var expectedResult = "DTEND:" + FormatDateTime(SomeEndDateTime);
            Assert.AreNotEqual(-1, result.Data.IndexOf(expectedResult));
        }

        [Test]
        public void Create_Event_With_Summary()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            Assert.AreNotEqual(-1, result.Data.IndexOf("SUMMARY:SomeSummary"));
        }

        [Test]
        public void Create_Event_With_Description()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            Assert.AreNotEqual(-1, result.Data.IndexOf("DESCRIPTION:SomeDescription"));
        }

        [Test]
        public void Create_Event_With_Some_Secuence_Tag()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            Assert.AreNotEqual(-1, result.Data.IndexOf("SEQUENCE:0"));
        }

        [Test]
        public void Create_Event_With_Some_End_Event_Tag()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            Assert.AreNotEqual(-1, result.Data.IndexOf("END:VEVENT"));
        }

        [Test]
        public void Create_Event_With_End_Calendar_Tag_On_The_End()
        {
            // Given
            var appleEvent = CreateSimpleEvent();
            var listOfAppleEvents = new List<AppleEvent> { appleEvent };

            // Where
            var result = service.CreateFile(listOfAppleEvents);

            // Then
            var indexStartLastString = result.Data.Length - 13;
            Assert.AreEqual("END:VCALENDAR", result.Data.Substring(indexStartLastString, 13));
        }

        private string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString("s").Replace("-", "").Replace(":", "") + "Z";
        }


        private AppleEvent CreateSimpleEvent()
        {
            return new AppleEvent(SomeStartDateTime, SomeEndDateTime, SomeSummary, SomeDescription);
        }
    }
}