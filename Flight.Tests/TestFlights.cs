using System;
using System.Collections.Generic;

namespace Flight.Tests
{
    public static class TestFlights
    {

        public static Flight twoOrMoreHoursGroundTime = new Flight()
        {
            Segments = new List<Segment>()
                {
                    new Segment()
                    {
                        DepartureDate = DateTime.Now.AddDays(-10),
                        ArrivalDate = DateTime.Now.AddDays(-9),
                    },

                    new Segment()
                    {
                        DepartureDate = DateTime.Now.AddDays(-6),
                        ArrivalDate = DateTime.Now.AddDays(-3),
                    }
                }
        };

        public static Flight arrivalBeforeDeparture = new Flight()
        {
            Segments = new List<Segment>()
                {
                    new Segment()
                    {
                        DepartureDate = DateTime.Now.AddDays(-10),
                        ArrivalDate = DateTime.Now.AddDays(-11)
                    }
                }
        };

        public static Flight departingInThePast = new Flight()
        {
            Segments = new List<Segment>()
                {
                    new Segment()
                    {
                        DepartureDate = DateTime.Now.AddDays(-10),
                        ArrivalDate = DateTime.Now.AddDays(-9)
                    }
                }
        };

        public static Flight normal = new Flight()
        {
            Segments = new List<Segment>()
                {
                    new Segment()
                    {
                        DepartureDate = DateTime.Now.AddDays(5),
                        ArrivalDate = DateTime.Now.AddDays(6)
                    }
                }
        };
    }
}
