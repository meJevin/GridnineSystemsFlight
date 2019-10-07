using System.Collections.Generic;

using Flight.Validators;

namespace Flight.Filters
{
    /*
     *
     * Here I define a set of basic filter classes
     * 
    */

    // To filter flights based on a single condition
    class SingleConditionFilter : SingleConditionFilterBase
    {
        public SingleConditionFilter(IFlightValidator validator) : base(validator)
        {
        }

        public override IList<Flight> Filter(IList<Flight> flights)
        {
            List<Flight> result = new List<Flight>();

            foreach (var flight in flights)
            {
                if (!conditionValidator.IsValid(flight))
                {
                    result.Add(flight);
                }
            }

            return result;
        }
    }

    // To filter flights based on multiple conditions (all of them)
    class AllConditionsFilter : MultipleConditionFilterBase
    {
        public AllConditionsFilter(IList<IFlightValidator> validators) : base(validators)
        {
        }

        public override IList<Flight> Filter(IList<Flight> flights)
        {
            List<Flight> result = new List<Flight>();

            foreach (var flight in flights)
            {
                bool flightSatisfiesAllConditions = true;

                foreach (var validator in conditionValidators)
                {
                    if (validator.IsValid(flight))
                    {
                        flightSatisfiesAllConditions = false;
                        break;
                    }
                }

                if (flightSatisfiesAllConditions)
                {
                    result.Add(flight);
                }
            }

            return result;
        }
    }

    // To filter flights based on mutiple conditions (at least one of them)
    class AnyConditionFilter : MultipleConditionFilterBase
    {
        public AnyConditionFilter(IList<IFlightValidator> validators) : base(validators)
        {
        }

        public override IList<Flight> Filter(IList<Flight> flights)
        {
            List<Flight> result = new List<Flight>();

            foreach (var flight in flights)
            {
                bool flightSatisfiesAtLeastOneCondition = false;

                foreach (var validator in conditionValidators)
                {
                    if (!validator.IsValid(flight))
                    {
                        flightSatisfiesAtLeastOneCondition = true;
                        break;
                    }
                }

                if (flightSatisfiesAtLeastOneCondition)
                {
                    result.Add(flight);
                }
            }

            return result;
        }
    }

}
