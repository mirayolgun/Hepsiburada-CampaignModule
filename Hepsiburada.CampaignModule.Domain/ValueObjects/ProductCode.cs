using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.ValueObjects
{
    public class ProductCode : ValueObjectBase
    {
        public string Value { get; private set; }

        public ProductCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                Logger.Log("Product code must not be empty.");
            }
            else
            {
                Value = code;
            }
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


    }
}
