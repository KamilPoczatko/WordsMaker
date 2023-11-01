using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsMaker.Application;
using WordsMaker.Core;
using WordsMaker.Infrastructure;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using WordsMaker.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace WordsMaker.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var WebApplicationBuilder = CreateHostBuilder(args).Build();

            //using (var context = WebApplicationBuilder.Services.GetService())
            //{
            //    context.Database.Migrate();
            //}  
            WebApplicationBuilder.UseHttpsRedirection();

            WebApplicationBuilder.UseRouting();

            WebApplicationBuilder.UseAuthorization();

            WebApplicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            await WebApplicationBuilder.RunAsync();
        }

        public static WebApplicationBuilder CreateHostBuilder(string[] args)
        {            
            var builder = WebApplication.CreateBuilder(args);
            builder
                .Services
                    .AddCore()
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();


            return builder;
        }
    }
}
