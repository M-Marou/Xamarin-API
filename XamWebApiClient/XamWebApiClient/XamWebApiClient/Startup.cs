using Microsoft.Extensions.DependencyInjection;
using System;
using XamWebApiClient.Services;
using XamWebApiClient.ViewModels;

namespace XamWebApiClient
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add services
            services.AddHttpClient<IProductService, ApiProductService>(c => 
            { 
                c.BaseAddress = new Uri("http://10.0.2.2:50438/api/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            //add viewmodels
            services.AddTransient<ProductViewModel>();
            services.AddTransient<AddproductViewModel>();
            services.AddTransient<ProductDetailViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
