using DaBulllet.TODO.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da.Bullet.TODO.API.IntegrationTests
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Api>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            base.ConfigureWebHost(builder);
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>{});

            return base.CreateHost(builder);
        }
    }
}
