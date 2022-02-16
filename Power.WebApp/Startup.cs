using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Power.WebApp
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
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(opt =>
                {
                    opt.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var type2 = typeof(PowerWebResource);
                        var assemblyName = new AssemblyName(type2.GetTypeInfo().Assembly.FullName);
                        return factory.Create("PowerWebResource", assemblyName.Name);
                    };

                    //services.AddSingleton<IStringLocalizerFactory>().Configure
                    //{
                    //    var factory = sp.GetService<IStringLocalizerFactory>();
                    //    var loclizer = factory.Create("PowerWebResource", assemblyName.Name);
                    //    opt.DataAnnotationLocalizerProvider = (t, f) => loclizer;
                    //});

                    //services.AddSingleton<IStringLocalizerFactory>()
                    //.Configure<IStringLocalizerFactory>(factory =>
                    //    {
                    //        var loclizer = factory.Create("PowerWebResource", assemblyName.Name);
                    //        opt.DataAnnotationLocalizerProvider = (t, f) => loclizer;
                    //    });

                    //var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                    //var loclizer = factory.Create("PowerWebResource", assemblyName.Name);
                    //opt.DataAnnotationLocalizerProvider = (t, f) => loclizer;

                });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo> {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-EG")
                    };
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            var loclize = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(loclize.Value);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
