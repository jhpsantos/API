using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        /// <summary>
        /// Aqui seto a lista dos recursos que estarão disponíveis sobre esta
        /// credencial de autenticação;
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        /// <summary>
        /// Definição dos Clients que consumirão a autenticação JWT.
        /// Para este caso estou usando o Middleware do Swagger;
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                 new Client
                {
                    ClientId = "swaggerui",
                    ClientName = "Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,

                    RedirectUris = { "http://localhost:5000/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { "http://localhost:5000/swagger" },

                    AllowedScopes =
                    {
                        "api1"
                    }
                }
          
            };
        }

        /// <summary>
        /// Definição dos usuários InMemory que se autenticarão e
        /// poderão utilizar as WEBAPIS do projeto;
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "joao",
                    Password = "joao"
                },
                     new TestUser
                {
                    SubjectId = "2",
                    Username = "balta",
                    Password = "balta"
                },
                          new TestUser
                {
                    SubjectId = "3",
                    Username = "will",
                    Password = "will"
                }
            };
        }
    }
}
