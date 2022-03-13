using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.ValueObjects
{
    public class Quantity : ValueObjectBase
    {
        public int Value { get; private set; }
        public Quantity(int quantity)
        {
            Incrase(quantity);
        }
        public void Incrase(int quantity)
        {
            if (quantity < 1)
            {
                Logger.Log("Quantity value should be greater or equal to zero");
            }
            else
            {
                Value += quantity;
            }
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
