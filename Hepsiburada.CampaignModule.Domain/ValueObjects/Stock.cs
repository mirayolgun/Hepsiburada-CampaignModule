using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.ValueObjects
{
    public class Stock : ValueObjectBase
    {
        public int Value { get; private set; }
        public Stock(int stock)
        {
            if (stock < 0)
            {
                Logger.Log("Stock value should be greater or equal to zero");
            }
            else
            {
                Value = stock;
            }
        }
        public void DecraseStock(int value)
        {
            if (CheckStockExist(value))
            {
                Value -= value;
            }
        }
        private bool CheckStockExist(int value)
        {
            if (Value < value)
            {
                Logger.Log("There is no enough stock");
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool HasStock(int quantity)
        {
            bool exist = Value - quantity >= 0;
            if (!exist)
            {
                Logger.Log($"Product stock is not enought for this quantity, current stock is {Value}");
            }

            return exist;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
