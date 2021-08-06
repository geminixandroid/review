using SecondService.Consumers;
using SecondService.Services;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace SecondService
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
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseNpgsql(
                     Configuration.GetConnectionString("DefaultConnection")
                     ));
            services.AddAutoMapper(typeof(Startup));            
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddScoped < IUsersService, UsersService>();            
            services.AddScoped < IOrganizationsService, OrganizationsService>();
            services.AddScoped <ConsumerUser>();
         
             
            services.AddMassTransit(x =>
            {
                x.AddConsumer<ConsumerUser>();
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
            // services.AddHostedService<Worker>();
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
