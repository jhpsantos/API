﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Patrimonio.Business;
using Patrimonio.Business.Interface;
using Patrimonio.Repository.Interface;
using Patrimonio.Repository.RepositoriosEntidades;
using Swashbuckle.AspNetCore.Swagger;

namespace API
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
            
            services.AddTransient<IPatrimonioBusiness, PatrimonioBusiness>();
            services.AddTransient<IPatrimonioRepository, PatrimonioRepository>();
            services.AddTransient<IUsuarioBusiness, UsuarioBusiness>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                        "v1"
                        , new Swashbuckle.AspNetCore.Swagger.Info
                        {
                            Title = "ESX - Desafio"
                            ,
                            Version = "v1"
                            ,
                            Description = "WEBAPI Avaliação ESX"
                            ,
                        }
                    );
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                     builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials());
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

            app.UseSwagger()
                .UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ESX - Desafio")
            );

            app.UseMvcWithDefaultRoute();
        }
    }
}
