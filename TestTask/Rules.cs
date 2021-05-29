using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Gridnine.FlightCodingTest
{
    class Rules
    {
        public Func<Flight, bool> Rule1 { get; set; }

        public Func<Flight, bool> Rule2 { get; set; }

        public Func<Flight, bool> Rule3 { get; set; }

        public Rules()
        {
            Rule1 = (flight) =>
            {
                return flight.Segments.Any(x => x.DepartureDate < DateTime.Now);
            };

            Rule2 = (flight) =>
            {
                return flight.Segments.Any(x => x.ArrivalDate < x.DepartureDate); ;
            };

            Rule3 = (flight) =>
            {
                if (flight.Segments.Count < 2)
                {
                    return false;
                }

                TimeSpan totalBreaksTime = TimeSpan.Zero;

                for (int i = 1; i < flight.Segments.Count; i++)
                {
                    totalBreaksTime += flight.Segments[i].DepartureDate - flight.Segments[i - 1].ArrivalDate;
                }

                return (totalBreaksTime.TotalHours > 2);
            };
        }
    }
}
