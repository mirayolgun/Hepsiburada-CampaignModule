using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.Product
{
    public interface IProductService
    {
        void AddProduct(string productCode, double price, int stock);
        ProductDto GetProduct(string productCode);
        void IncraseTime(int totalIncrase);
        void ChangeProductPrice(string productCode, double price);
    }
}
