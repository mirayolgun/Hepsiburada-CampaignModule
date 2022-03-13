using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.ValueObjects
{
    public class Price : ValueObjectBase
    {
        public double Value { get; private set; }

        public Price(double price)
        {
            SetPrice(price);
        }
        public void SetPrice(double price)
        {
            if (price < 0)
            {
                Logger.Log("Price value should be greater or equal to zero");
            }
            else
            {
                Value = price;
            }
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
