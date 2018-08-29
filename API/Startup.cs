using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Patrimonios.API;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ///Implementando as settings de Configuração do JWT - Autenticação;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            ///Injeção das dependências para as classes de Negócio e Repository;
            services.AddTransient<IPatrimonioBusiness, PatrimonioBusiness>();
            services.AddTransient<IPatrimonioRepository, PatrimonioRepository>();
            services.AddTransient<IUsuarioBusiness, UsuarioBusiness>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IMarcaBusiness, MarcaBusiness>();
            services.AddTransient<IMarcaRepository, MarcaRepository>();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
           .AddIdentityServerAuthentication(options =>
           {
               options.Authority = "http://localhost:5001";
               options.ApiName = "api1"; // required audience of access tokens
                options.RequireHttpsMetadata = false; // dev only!
            });

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
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
                ///Adicionando as Options do Swagger para o client de autenticação,
                ///pela documentação dos Hosts disponíveis do IdentityServer;
                options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Flow = "implicit",
                    AuthorizationUrl = "http://localhost:5001/connect/authorize",
                    TokenUrl = "http://localhost:5001/connect/token",
                    ///Definindo o escopo da autorizaçao/serviços que os usuários 
                    ///autenticados podem acessar;
                    Scopes = new Dictionary<string, string>()
                    {
                        { "api1", "My API" }
                    }
                });
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                     builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials());
            });

           
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            ///Declarativa de uso da autenticação;
            app.UseAuthentication();
            ///Adicionando a Rota default para apontar para o swagger;
            app.UseMvcWithDefaultRoute();
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ESX - Desafio");
                    ///Adicionando aos Midleware do swagger o client de autenticação e o 
                    ///appname definido no WebApplication.Core do Identity Server;
                    c.OAuthClientId("swaggerui");
                    c.OAuthAppName("Swagger UI");
                }
            );
        }
    }
}
