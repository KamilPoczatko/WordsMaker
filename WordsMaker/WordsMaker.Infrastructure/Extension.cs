using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using WordsMaker.Infrastructure.DAL;
using WordsMaker.Core.Repository;
using WordsMaker.Infrastructure.DAL.Repositories;

namespace WordsMaker.Infrastructure
{
    public static class Extension
    {
        private const string OptionsSectionName = "connString";
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqlServerOptions>(x => configuration.GetSection(OptionsSectionName));
            var SqlServerOptions = configuration.GetOptions<SqlServerOptions>(OptionsSectionName);

            services.AddDbContext<WordsMakerDbContext>(options => options.UseSqlServer(SqlServerOptions.ConnectionString));

            services.AddTransient<IDictSufixRepository,     DictSufixRepository>()
                    .AddTransient<IDictWordRepository,      DictWordRepository>()
                    .AddTransient<ILangRepository,          LangRepository>()
                    .AddTransient<ITranslationRepository,   TranslationRepository>();
            return services;
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            var section = configuration.GetRequiredSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}
