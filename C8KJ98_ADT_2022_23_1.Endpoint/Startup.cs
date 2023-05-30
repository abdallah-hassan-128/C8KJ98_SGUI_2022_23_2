using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using C8KJ98_ADT_2022_23_1.Data;
using C8KJ98_ADT_2022_23_1.Logic;
using C8KJ98_ADT_2022_23_1.Repository;
using C8KJ98_ADT_2022_23_1.Endpoint.services;




namespace C8KJ98_ADT_2022_23_1.Endpoint
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //// services.AddControllersWithViews().AddNewtonsoftJson(options =>
           ////                                      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
            services.AddSignalR();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
               .AllowCredentials()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithOrigins("http://localhost:23079"));

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");

            });
        }
    }
}
