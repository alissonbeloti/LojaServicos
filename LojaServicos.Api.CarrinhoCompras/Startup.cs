using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LojaServicos.Api.CarrinhoCompras.Aplicacao;
using LojaServicos.Api.CarrinhoCompras.Persistencia;
using LojaServicos.Api.CarrinhoCompras.RemoteInterface;
using LojaServicos.Api.CarrinhoCompras.RemoteServices;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LojaServicos.Api.CarrinhoCompras
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
            services.AddScoped<ILivrosService, LivrosService>();
            services.AddControllers();
            services.AddDbContext<CarrinhoContexto>(option =>
            {
                option.UseMySQL(Configuration.GetConnectionString("dbConection"));
            });
            services.AddMediatR(typeof(Novo.Manipulador).Assembly);
            services.AddHttpClient("Livros", config => {
                config.BaseAddress = new Uri(Configuration["Services:Livros"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
