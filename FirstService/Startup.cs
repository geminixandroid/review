using FirstService.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicesDTO;
using System.Reflection;

namespace FirstService
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
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddMvc(setup => {              
            }).AddFluentValidation();

            services.AddTransient<IValidator<UserDTO>, UserValidator>();
            services.AddMassTransit(x =>
             {
                 x.UsingRabbitMq((context, cfg) =>
                 {
                     cfg.Host("rabbitmq", "/", h =>
                     {
                         h.Username("guest");
                         h.Password("guest");
                     });
                     cfg.ConfigureEndpoints(context);
                 });

             });
            services.AddMassTransitHostedService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            //app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
