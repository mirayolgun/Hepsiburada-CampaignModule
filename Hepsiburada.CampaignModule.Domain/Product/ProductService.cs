using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.Product
{
    public class ProductService : IProductService
    {
        private List<ProductDto> ProductList { get; set; }

        public ProductService()
        {
            if (ProductList == null)
                ProductList = new List<ProductDto>();
        }
        public void AddProduct(string productCode, double price, int stock)
        {
            if (ProductList.Any(x => x.ProductCode.Value == productCode))
            {
                Logger.Log("This product already exists");
            }
            else
            {
                ProductList.Add(new ProductDto(productCode, price, stock));
                Logger.Log($"Product created; code {productCode}, price {price}, stock {stock}");
            }

        }
        public ProductDto GetProduct(string productCode)
        {
            var product = ProductList.FirstOrDefault(x => x.ProductCode.Value == productCode);
            if (product != null)
            {
                return product;
            }
            else
            {
                Logger.Log("Product not exits");
                return null;
            }
        }
        private void MakeDiscount()
        {
            foreach (var item in ProductList)
            {
                //not linear
                item.MakeDiscount(RandomizeDiscountValue());
            }
        }
        private int RandomizeDiscountValue() => new Random().Next(-15, 15);

        public void IncraseTime(int totalIncrase)
        {
            for (int i = 0; i < totalIncrase; i++)
            {
                MakeDiscount();
            }
        }

        public void ChangeProductPrice(string productCode, double price)
        {
            var product = this.ProductList.FirstOrDefault(x => x.ProductCode.Value == productCode);
            if (product != null)
            {
                product.RealPrice.SetPrice(price);
                product.Price.SetPrice(price);
            }
        }

    }
}
