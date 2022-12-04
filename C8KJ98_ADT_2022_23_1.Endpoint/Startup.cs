using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Data;
using C8KJ98_ADT_2022_23_1.Logic;
using C8KJ98_ADT_2022_23_1.Repository;


namespace C8KJ98_ADT_2022_23_1.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IFansLogic, FansLogic>();
            services.AddTransient<IArtistsLogic, ArtistsLogic>();
            services.AddTransient<IReservationsLogic, ReservationsLogic>();
            services.AddTransient<IReservationsServicesLogic, ReservationsServicesLogic>();
            services.AddTransient<IServicesLogic, ServicesLogic>();
            services.AddTransient<IFansRepository, FansRepository>();
            services.AddTransient<IArtistsRepository, ArtistsRepository>();
            services.AddTransient<IReservationsRepository, ReservationsRepository>();
            services.AddTransient<IReservationsServicesRepository, ReservationsServicesRepository>();
            services.AddTransient<IServicesRepository, ServicesRepository>();
            services.AddTransient<TalkWithYourFavoriteArtistDbContext, TalkWithYourFavoriteArtistDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
