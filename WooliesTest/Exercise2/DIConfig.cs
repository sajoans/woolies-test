using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AzureFunctions.Autofac.Configuration;
using WooliesTest.Common;
using WooliesTest.Exercise2.Services;
using WooliesTest.Exercise2.Sorting;

namespace WooliesTest.Exercise2
{
    public class DIConfig
    {
        public DIConfig(string functionName)
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterType<WooliesHttpClient>().As<IHttpClient>();
                builder.RegisterType<ProductSorterFactory>().As<IProductSorterFactory>();
                builder.RegisterType<ProductsService>().As<IProductsService>();
                builder.RegisterType<ShopperHistoryService>().As<IShopperHistoryService>();
            }, functionName);
        }
    }
}