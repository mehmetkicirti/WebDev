using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
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
            //IBookService ne kullanýcagýný bilmedigi için Dependency Resolver yoluyla Arka planda BookManageri olusturuyor IbookDalýn Constructorunu kim istiyorsa ona EfBookDal vermisiz o nesneyi veriyor.
            //Fakat biz bunu Autofac gibi Aop altyapýsýný saglayan yapýlarý kullanýrýz interception aop destekledigi için business a tasýrýz normalde.
            services.AddSingleton<IBookService,BookManager>();//BookMAnager ý new liyor referansýný IBookServise atýyor
            services.AddSingleton<IBookDal, EfBookDal>();//new liyor bookDalý constructor da kim istiyorsa IbookDaldan bir nesne ona veriyor.
            //güvenlik problemini aþmak icin  4200 nolu bir adresten istek gelirse izin ver 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:4200"));
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //tüm isteklere izin ver diyoruz.
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
