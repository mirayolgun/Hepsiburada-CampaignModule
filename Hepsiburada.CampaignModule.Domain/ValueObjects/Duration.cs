using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.ValueObjects
{
    public class Duration : ValueObjectBase
    {
        public int Value { get; private set; }
        public Duration(int hour)
        {
            Incrase(hour);
        }
        public void Incrase(int hour)
        {
            if (hour < 0)
            {
                Logger.Log("Duration value is greather than zero");
            }
            else
            {
                Value += hour;
            }
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
