using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core
{
    static public class Extension
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            //services.AddScoped<IWordsMakerCoreService, WordsMakerCoreService>();
            return services;
        }
    }
}
