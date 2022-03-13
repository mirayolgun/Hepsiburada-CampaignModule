using Hepsiburada.CampaignModule.Domain;
using Hepsiburada.CampaignModule.Domain.Campaign;
using Hepsiburada.CampaignModule.Domain.Order;
using Hepsiburada.CampaignModule.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Application
{
    public class CommandManager : ICommand
    {
        private static Dictionary<string, Action<string[]>> CommandList;
        private readonly IProductService productService;
        private readonly ICampaignService campaignService;
        private readonly IOrderService orderService;
        private TimeSpan systemTime;

        public CommandManager(IProductService productService, ICampaignService campaignService, IOrderService orderService)
        {
            this.productService = productService;
            this.campaignService = campaignService;
            this.orderService = orderService;
            systemTime = new TimeSpan(0, 0, 0);
            Init();
        }
        public void Execute(string command, string[] arguments)
        {

            if (CommandList.ContainsKey(command))
            {
                CommandList[command].Invoke(arguments);
            }
            else
            {
                Logger.Log("Command is not found.");
            }
        }
        public void Init()
        {
            if (CommandList == null)
            {
                CommandList = new Dictionary<string, Action<string[]>>();

                CommandList.Add("create_product", CreateProductCommand);
                CommandList.Add("change_product_price", ChangeProductPrice);
                CommandList.Add("get_product_info", GetProductInfoCommand);
                CommandList.Add("create_order", CreateOrderCommand);
                CommandList.Add("create_campaign", CreateCampaignCommand);
                CommandList.Add("get_campaign_info", GetCampaignInfoCommand);
                CommandList.Add("increase_time", IncraseTimeCommand);
                CommandList.Add("clear", ClearCommands);
            }
        }

        private void ChangeProductPrice(string[] arguments)
        {
            string productCode = GetParameter<string>(arguments, 0);
            double price = GetParameter<double>(arguments, 1);
            productService.ChangeProductPrice(productCode, price);
        }

        private void ClearCommands(string[] obj) => Console.Clear();

        public void CreateProductCommand(string[] arguments)
        {
            string productCode = GetParameter<string>(arguments, 0);
            double price = GetParameter<double>(arguments, 1);
            int stock = GetParameter<int>(arguments, 2);

            productService.AddProduct(productCode, price, stock);


        }
        public void GetProductInfoCommand(string[] arguments)
        {
            string productCode = GetParameter<string>(arguments, 0);

            var product = productService.GetProduct(productCode);

            Logger.Log($"Product {product.ProductCode.Value} info; price {product.Price.Value}, stock {product.Stock.Value}");


        }
        public void CreateOrderCommand(string[] arguments)
        {
            string productCode = GetParameter<string>(arguments, 0);
            int quantity = GetParameter<int>(arguments, 1);
            var product = productService.GetProduct(productCode);

            orderService.AddOrder(product, quantity, systemTime);
        }
        public void CreateCampaignCommand(string[] arguments)
        {
            string campaignName = GetParameter<string>(arguments, 0);
            string productCode = GetParameter<string>(arguments, 1);
            int duration = GetParameter<int>(arguments, 2);
            int priceManipulationLimit = GetParameter<int>(arguments, 3);
            int targetSalesCount = GetParameter<int>(arguments, 4);

            var product = productService.GetProduct(productCode);

            campaignService.AddCampaing(campaignName, product, duration, priceManipulationLimit, targetSalesCount);
        }
        public void GetCampaignInfoCommand(string[] arguments)
        {
            string campaignName = GetParameter<string>(arguments, 0);

            campaignService.GetCampaignInfo(campaignName);

        }
        public void IncraseTimeCommand(string[] arguments)
        {
            int totalIncrase = GetParameter<int>(arguments, 0);

            systemTime = systemTime.Add(new TimeSpan(totalIncrase, 0, 0));

            Logger.Log($"Time is {systemTime.ToString("hh\\:mm")}");

            productService.IncraseTime(totalIncrase);
        }
        private T GetParameter<T>(string[] values, int index)
        {
            try
            {
                return (T)Convert.ChangeType(values[index], typeof(T));
            }
            catch (Exception ex)
            {
                Logger.Log("Unexcepted paramater value.");
                return Activator.CreateInstance<T>();
            }
        }

        public TimeSpan GetTime()
        {
            return systemTime;
        }

    }
}
