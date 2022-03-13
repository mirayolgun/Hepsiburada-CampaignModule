using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.ValueObjects
{
    public class Name : ValueObjectBase
    {
        public string Value { get; private set; }
        public Name(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Logger.Log("Name must not be empty");
            }
            Value = name;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
