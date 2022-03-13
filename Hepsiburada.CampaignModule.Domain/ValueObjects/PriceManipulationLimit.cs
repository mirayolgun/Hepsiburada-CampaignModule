using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.ValueObjects
{
    public class PriceManipulationLimit : ValueObjectBase
    {
        public int Value { get; private set; }
        public PriceManipulationLimit(int limit)
        {
            if (limit < 0)
            {
                Logger.Log("Price manipulation limit must be greather than zero");
            }
            else
            {
                Value = limit;
            }
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
