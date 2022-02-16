using Microsoft.Extensions.DependencyInjection;
using Power.Core.Repository;
using Power.Core.Services;
using Power.Core.Services.Implemenation;
using Power.Core.Services.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.API.Helper
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ICryptorEngineService, CryptorEngineService>();

            return services;
        }
    }
}
