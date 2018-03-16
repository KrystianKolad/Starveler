using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.vNext;
using RawRabbit.vNext.Pipe;
using Starveler.Common.Events;
using Starveler.Common.Extensions;
using Starveler.Service.Configuration;
using Starveler.Service.Extensions;
using Starveler.Service.Handlers;
using Starveler.Service.Handlers.Interfaces;
using Starveler.Service.Helpers;
using Starveler.Service.Helpers.Interfaces;

namespace Starveler.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRawRabbit(new RawRabbitOptions {
                ClientConfiguration = Configuration
                    .GetRabbitMqConfigurationSection()
                    .Get<RawRabbitConfiguration>()
            });
            services.Configure<EmailConfiguration>(
                Configuration.GetEmailConfigurationSection());
                
            services.AddScoped<IEventHandler<OrderReceivedEvent>,OrderReceivedEventHandler>();
            services.AddScoped<IEmailHelper,EmailHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IBusClient busClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Ready to serve!");
            });

            var participantWasSignUpHandler = app
                .ApplicationServices
                .GetService<IEventHandler<OrderReceivedEvent>>();

            busClient.SubscribeAsync<OrderReceivedEvent>(async message => {
                participantWasSignUpHandler.Handle(message);
            });
        }
    }
}
