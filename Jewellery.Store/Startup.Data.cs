using Jewellery.Store.DAL.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Jewellery.Store
{
    public partial class Startup
    {
        private void RegisterDataDependencies(IServiceCollection services)
        {
            // Register db connection
            services.AddTransient<IDbConnection>(r => new SqliteConnection(Configuration.GetConnectionString("SqliteConnection")));

            // Register repositories
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IPriceCalculatorRepository, PriceCalculatorRepository>();
        }
    }
}
