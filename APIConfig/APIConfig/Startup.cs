using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIConfig.Models;
using APIConfig.Repository;
using APIConfig.Repository.Imp;
using APIConfig.Services;
using APIConfig.Services.Imp;
using APIConfig.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIConfig
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ConfigContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DB")));
            //services.AddDbContext<ConfigContext>(options => options.UseSqlServer())

            #region Repository
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion
            #region ConnectionString
                services.AddScoped(typeof(IConnectionStringsService), typeof(ConnectionStringService));
            #endregion
            #region Service
                services.AddScoped(typeof(IService<>), typeof(Service<>));
            #endregion
            #region UnitOfWork
                services.AddScoped<IUnitOfWork, UnitOfWork.Imp.UnitOfWork>();
            #endregion
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My DAB API", Version = "V3.2.2" });
            });
            #endregion

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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
