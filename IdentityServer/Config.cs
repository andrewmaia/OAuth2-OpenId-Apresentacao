using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
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
                            RedirectUris = { "https://localhost:7080/contato/ContatoCallback" },
                            RequireConsent = true,
                            RequirePkce=false,
                            AllowedScopes = new List<string>
                            {
                                "contato"
                            }
                        }         
            };
    }
}