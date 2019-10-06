using System;
using System.Collections.Generic;

using Flight.Validators;

namespace Flight.Filters
{
    public interface IFlightFilter
    {
        IList<Flight> Filter(IList<Flight> flights);
    }

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
