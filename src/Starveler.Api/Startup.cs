﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.vNext;
using Starveler.Api.Options;
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
            services.AddDbContext<StarvelerContext>(dbOptions => 
                dbOptions.UseSqlServer(Configuration.GetConnectionString("StarvelerConnectionString"), b => b.MigrationsAssembly("Starveler.Api"))
            );
            services.AddScoped<IRepository<Order>,OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            var sbOptions = new RabbitOptions();
            var section = Configuration.GetSection("rabbitmq");
            section.Bind(sbOptions);

             var rabbitMqClient = BusClientFactory.CreateDefault(sbOptions);
            services.AddSingleton<IBusClient>(_ => rabbitMqClient);
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
