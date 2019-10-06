using System;
using System.Collections.Generic;

using Flight.Validators;

namespace Flight.Filters
{
    /*
     * IFlightFilter is the most important interface in this application
     * 
     * It is used to filter flights based on differnt sets of rules
    */
    public interface IFlightFilter
    {
        IList<Flight> Filter(IList<Flight> flights);
    }

    // Abstract class for filters that use multiple conditions in order to 
    // filter flights
    public abstract class MultipleConditionFilterBase : IFlightFilter
    {
        protected List<IFlightValidator> conditionValidators;

        public MultipleConditionFilterBase(IList<IFlightValidator> validators)
        {
            foreach (var validator in validators)
            {
                conditionValidators.Add(validator);
            }
        }

        public virtual IList<Flight> Filter(IList<Flight> flights)
        {
            throw new NotImplementedException();
        }
    }

    // Abstract class for filters that use a single condition in order to
    // filter flights
    public abstract class SingleConditionFilterBase : IFlightFilter
    {
        protected IFlightValidator conditionValidator;

        public SingleConditionFilterBase(IFlightValidator validator)
        {
            conditionValidator = validator;
        }

        public virtual IList<Flight> Filter(IList<Flight> flights)
        {
            throw new NotImplementedException();
        }
    }

}
