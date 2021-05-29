using System;
using Xunit;
using Gridnine.FlightCodingTest;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestTask
{
    public class UnitTest1
    {
        [Fact]
        public void RuleTest()
        {
            List<Flight> testFlights = new List<Flight>()
            {
                FlightBuilder.CreateFlight(
                    DateTime.Parse("29.05.2020 10:30"),
                    DateTime.Parse("29.05.2020 15:30")),
                FlightBuilder.CreateFlight(
                    DateTime.Parse("29.05.2020 16:30"),
                    DateTime.Parse("29.05.2020 18:30"),
                    DateTime.Parse("29.05.2020 19:30"),
                    DateTime.Parse("29.05.2020 21:30"))
            };

            Func<Flight, bool> testRule = (flight) => { return flight.Segments.Count > 1; };

            FlightsSelecter selecter = new FlightsSelecter();

            var actualFlights = selecter.SelectFlights(testFlights, new Func<Flight, bool>[] { testRule }).ToList();
            var expectedFlights = new List<Flight>()
            {
                FlightBuilder.CreateFlight(
                    DateTime.Parse("29.05.2020 16:30"),
                    DateTime.Parse("29.05.2020 18:30"),
                    DateTime.Parse("29.05.2020 19:30"),
                    DateTime.Parse("29.05.2020 21:30"))
            };

            Assert.Equal(expectedFlights, actualFlights);
        }
    }
}
