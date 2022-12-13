using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
                new ApiScope("contato","Seus Contatos")                
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
             
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:7080/signin-oidc" },
                    RequireConsent = true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "contato"
                    }
                }          
        };
    }
}