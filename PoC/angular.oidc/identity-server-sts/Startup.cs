using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace identity_server_sts
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryIdentityResources(new List<IdentityResource> {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                        new IdentityResources.Email()
                    })
                    .AddInMemoryApiResources(new[] {
                        new ApiResource("resource1", "Resource 1")
                    })
                    .AddInMemoryClients(new[] {
                        new Client
                        {
                            ClientId = "angular2s",
                            ClientName = "My Client",
                            AllowedGrantTypes = GrantTypes.Implicit,
                            AllowAccessTokensViaBrowser = true,
                            AllowedCorsOrigins = { "http://localhost:4200" }, // My Client is a Angular application served on port 4200
                            AllowRememberConsent = true,
                            AllowedScopes =
                            {
                                IdentityServerConstants.StandardScopes.OpenId,
                                IdentityServerConstants.StandardScopes.Profile,
                                IdentityServerConstants.StandardScopes.Email,
                                "resource1"
                            },
                            RedirectUris = { "http://localhost:4200/signin-callback" },
                            PostLogoutRedirectUris = { "http://localhost:4200/signout-callback" }
                        },
                        new Client{
                            ClientId = "c2c",
                            ClientName = "My Client",
                            AllowedGrantTypes = GrantTypes.ClientCredentials,
                            ClientSecrets =
                            {
                                new Secret("secret".Sha256())
                            },
                            AllowAccessTokensViaBrowser = false,
                            AllowedCorsOrigins = { "http://localhost:4200" }, // My Client is a Angular application served on port 4200
                            AllowRememberConsent = true,
                            AllowedScopes =
                            {
                                IdentityServerConstants.StandardScopes.OpenId,
                                IdentityServerConstants.StandardScopes.Profile,
                                IdentityServerConstants.StandardScopes.Email,
                                "resource1"
                            }
                        }
                    })
                    .AddTestUsers(new List<TestUser> {
                        new TestUser {
                            SubjectId = "José",
                            Username = "shoutmetal",
                            Password = "Pass@w0rd1",
                            Claims = {
                                new Claim(IdentityServerConstants.StandardScopes.Email, "[email protected]"),
                                new Claim(IdentityServerConstants.StandardScopes.Address, "21 Jump Street")
                            }
                        }
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();
        }
    }
}
