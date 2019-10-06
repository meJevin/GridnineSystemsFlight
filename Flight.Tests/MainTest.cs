using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Flight.Validators.Custom;

namespace Flight.Tests
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void FlightDepartingInThePast_DepartInPastValidator_ReturnsTrue()
        {
            // Departures in the past

            DepartedInPastValidator validator = new DepartedInPastValidator();

            bool result = validator.IsValid(TestFlights.departingInThePast);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FlightArrivalBeforeDeparture_ArrivalBeforeDepartureValidator_ReturnsTrue()
        {
            // Arrival before departure

            ArrivalBeforeDepartureValidator validator = new ArrivalBeforeDepartureValidator();

            bool result = validator.IsValid(TestFlights.arrivalBeforeDeparture);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FlightGroundTimeIsGreaterThanTwo_TwoAndMoreHoursOnGroundValidator_ReturnsFalse()
        {
            // More than two hours ground time

            TwoAndMoreHoursOnGroundValidator validator = new TwoAndMoreHoursOnGroundValidator();

            bool result = validator.IsValid(TestFlights.twoOrMoreHoursGroundTime);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FlightNormal_DepartInPastValidator_ReturnsFalse()
        {
            DepartedInPastValidator validator = new DepartedInPastValidator();

            bool result = validator.IsValid(TestFlights.normal);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FlightNormal_ArrivalBeforeDepartureValidator_ReturnsFalse()
        {
            ArrivalBeforeDepartureValidator validator = new ArrivalBeforeDepartureValidator();

            bool result = validator.IsValid(TestFlights.normal);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FlightNormal_TwoAndMoreHoursOnGroundValidator_ReturnsFalse()
        {
            TwoAndMoreHoursOnGroundValidator validator = new TwoAndMoreHoursOnGroundValidator();

            bool result = validator.IsValid(TestFlights.normal);

            Assert.IsFalse(result);
        }
    }
}
