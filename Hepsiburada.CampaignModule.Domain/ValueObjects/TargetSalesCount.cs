using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.ValueObjects
{
    public class TargetSalesCount : ValueObjectBase
    {
        public int Value { get; private set; }
        public TargetSalesCount(int count)
        {
            if (count < 0)
            {
                Logger.Log("Target sales count value must be greather than zero");
            }
            else
            {
                Value = count;
            }
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


    }
}
