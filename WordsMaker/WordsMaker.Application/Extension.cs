using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Application.ServiceInterface.ServiceAbstractions;
using WordsMaker.Application.ServiceInterface.ServiceDefinitions;

namespace WordsMaker.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ILangService, LangService>()
                    .AddTransient<IDictWordService, DictWordService>()
                    .AddTransient<IDictSufixService, DictSufixService>();
                    //.AddTransient<ITranslationService,  TranslationService>();
            return services;
        }
    }
}
