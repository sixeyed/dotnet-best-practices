using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorldWideImporters.Caching;
using WorldWideImporters.Caching.Options;
using WorldWideImporters.Data;
using WorldWideImporters.Mapping;

namespace WorldWideImporters.Api
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
            services.AddAutoMapper(typeof(CityProfile));

            services.AddOptions()
                    .Configure<CachingOptions>(Configuration.GetSection("Caching"));

            services.AddSingleton<ICache, MemoryCache>();

            services.AddDbContext<WorldWideImportersContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("wwi-db")));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
