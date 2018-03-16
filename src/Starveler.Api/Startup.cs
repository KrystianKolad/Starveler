using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Starveler.Common.Entities;
using Starveler.Infrastructure.DataAccess;
using Starveler.Infrastructure.Repositories;
using Starveler.Infrastructure.Repositories.Interfaces;
using Starveler.Infrastructure.Services;
using Starveler.Infrastructure.Services.Interfaces;

namespace Starveler.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<StarvelerContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("StarvelerConnectionString"), b => b.MigrationsAssembly("Starveler.Api"))
            );
            services.AddScoped<IRepository<Order>,OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
