using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gridnine.FlightCodingTest
{
    public class FlightsSelecter
    {
        public IList<Flight> SelectFlights(IList<Flight> flights, Func<Flight, bool>[] rules)
        {
            rules.ToList().ForEach(x =>
            {
                flights = flights.Where(x).ToList();
            });
            return flights;
        }
    }
}
