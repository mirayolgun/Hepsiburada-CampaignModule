using Hepsiburada.CampaignModule.Application;
using Hepsiburada.CampaignModule.Domain.Campaign;
using Hepsiburada.CampaignModule.Domain.Order;
using Hepsiburada.CampaignModule.Domain.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Presentation
{
    public class DependencyLoader
    {
        public ServiceProvider Init()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddSingleton<IProductService, ProductService>();
            serviceDescriptors.AddSingleton<IOrderService, OrderService>();
            serviceDescriptors.AddSingleton<ICampaignService, CampaignService>();
            serviceDescriptors.AddSingleton<ICampaignService, CampaignService>();
            serviceDescriptors.AddSingleton<ICommand, CommandManager>();
            return serviceDescriptors.BuildServiceProvider();

        }

    }
}
