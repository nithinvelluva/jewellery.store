using Jewellery.Store.Services;
using Jewellery.Store.Services.PriceCalculatorHelpers;
using Jewellery.Store.ViewModels.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Jewellery.Store
{
    public partial class Startup
    {
        private void RegisterServiceDependencies(IServiceCollection services)
        {
            // Register services            
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPriceCalculatorService, PriceCalculatorService>();

            // Register codecs
            services.AddScoped<IPriceFactory,PriceCalculatorFactory>();
            services.AddScoped<IUserMapper, UserMapper>();
        }
    }
}
