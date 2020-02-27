using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RentalServices
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                // NOTE: building custom routes is tedious and messy as a complex system will have a number of custom routes.
                // Furthermore these definitions are set string values so if a name is changed for a controller it will not update here making this approach not modular.
                // Instead of this we can use Attribute Routing
                
                // order of route mapping matters as there is a prescedence hierarchy from most specific map routes to most generic (ie defaults)
                // Essentially ASP.NET will check the url that matches the MapRoute description from top to bottom
                // Custom route for sorting by release date
                //routes.MapRoute(
                //    name: "BooksByReleaseDate",
                //    template: "books/released/{year}/{month}",
                //    new { controller = "Books", action = "ByReleaseDate" },
                //    // specifying router constraints (4 digits for year and 2 for month)
                //    // @ specifies a verbatim string which means to ignore escape characters and take everything as a literal string and not an operation since \ is an escape sequence
                //    new { year = @"\d{4}", month = @"\d{2}" });

                routes.MapRoute(
                    name: "default",
                    // Defaults defined in template for the parameter id: {id?} the question mark means its an optional parameter.
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
