using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Gridnine.FlightCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightBuilder builder = new FlightBuilder();
            var flights = builder.GetFlights().ToList();
            flights.ForEach(x => x.Id = flights.IndexOf(x));

            Console.Clear();
            PrintFlights(flights);
            Console.ReadKey();


            Rules rules = new Rules();
            var rule1 = rules.Rule1;
            var rule2 = rules.Rule2;
            var rule3 = rules.Rule3;

            FlightsSelecter selecter = new FlightsSelecter();

            Console.Clear();
            Console.WriteLine("Flights, except matching rule1");
            PrintFlights(flights.Except(selecter.SelectFlights(flights, new Func<Flight, bool>[] { rule1 })).ToList());
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Flights, except matching rule2");
            PrintFlights(flights.Except(selecter.SelectFlights(flights, new Func<Flight, bool>[] { rule2 })).ToList());
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Flights, except matching rule3");
            PrintFlights(flights.Except(selecter.SelectFlights(flights, new Func<Flight, bool>[] { rule3 })).ToList());
            Console.ReadKey();

        }

        static void PrintFlights(List<Flight> flights)
        {
            flights.ForEach(x =>
            {
                Console.WriteLine($"\nFlight #{x.Id}");
                x.Segments.ToList().ForEach(s => Console.WriteLine($"{s.DepartureDate} - {s.ArrivalDate}"));
            });
        }
    }
}