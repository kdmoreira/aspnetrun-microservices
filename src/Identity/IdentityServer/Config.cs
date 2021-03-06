using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId = "shopping_web",
                ClientName = "Shopping Web App",
                AllowedGrantTypes = GrantTypes.Hybrid,
                AllowRememberConsent = false,
                RedirectUris = new List<string>()
                {
                    "https://localhost:5007/signin-oidc" // This is the client app port
                },
                PostLogoutRedirectUris = new List<string>()
                {
                    "https://localhost:5007/signout-callback-oidc"
                },
                ClientSecrets = new List<Secret>
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },
            new Client
            {
                ClientId = "catalogClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret" .Sha256())
                },
                AllowedScopes = { "catalogAPI" }
            },
            new Client
            {
                ClientId = "basketClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret" .Sha256())
                },
                AllowedScopes = { "basketAPI" }
            },
            new Client
            {
                ClientId = "discountClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret" .Sha256())
                },
                AllowedScopes = { "discountAPI" }
            },
            new Client
            {
                ClientId = "orderingClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret" .Sha256())
                },
                AllowedScopes = { "orderingAPI" }
            }
        };
        
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] 
        { 
            new ApiScope("catalogAPI", "Catalog API"),
            new ApiScope("basketAPI", "Basket API"),
            new ApiScope("discountAPI", "Discount API"),
            new ApiScope("orderingAPI", "Ordering API")

        };

        public static List<string> AllowedScopes => new List<string>
        {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            "catalogAPI",
            "basketAPI",
            "discountAPI",
            "orderingAPI"
        };

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] { };
        
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
        
        public static List<TestUser> TestUsers => new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "5BE86359–073C-434B-AD2D-A3932222DABE",
                Username = "mehmet",
                Password = "mehmet",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.GivenName, "mehmet"),
                    new Claim(JwtClaimTypes.FamilyName, "ozkaya")
                }
            }
        };
    }
}
