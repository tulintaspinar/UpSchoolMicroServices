﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace UpSchoolECommerce.IdentityServer
{
    public static class Config
    {
        // Servis kısıtlamalarının yapıldığı yer.
        public static IEnumerable<ApiResource> ApiResources =>
                   new ApiResource[]
                   {
                        new ApiResource("Resource_Catalog"){Scopes ={"Catalog_FullPermission"}},
                            //new ApiResource("Resource_Order"){Scopes ={"Order_FullPermission"}},
                                new ApiResource("Resource_Discount"){Scopes ={ "Discount_FullPermission" }},
                                    new ApiResource("Resource_Basket"){Scopes ={ "Basket_FullPermission" }},
                            //            new ApiResource("Resource_Payment"){Scopes ={ "Payment_FullPermission" }},
                                            new ApiResource("Resource_Photo_Stock"){Scopes ={ "Photo_Stock_FullPermission" }},
                                                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
                   };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.OpenId()
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("Catalog_FullPermission","Katalog API için tam yetkili erişim"),
                //new ApiScope("Order_FullPermission","Sipariş API için tam yetkili erişim"),
                new ApiScope("Discount_FullPermission","İndirim API için tam yetkili erişim"),
                new ApiScope("Basket_FullPermission","Sepet API için tam yetkili erişim"),
                //new ApiScope("Payment_FullPermission","Ödeme API için tam yetkili erişim"),
                new ApiScope("Photo_Stock_FullPermission","Fotoğraf API için tam yetkili erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                // sisteme giriş yapmadan önceki kısım
                new Client
                {
                    ClientId ="mvcClient",
                    ClientName = "asp.netcoremvc",

                    AccessTokenLifetime=300, //5 dk geçerli

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = { "Catalog_FullPermission" , 
                        /*"Basket_FullPermission",*/ 
                        /*"Order_FullPermission", "Discount_FullPermission", "Payment_FullPermission",*/ 
                        "Photo_Stock_FullPermission" , 
                        IdentityServerConstants.LocalApi.ScopeName }
                },

                // interactive client using code flow + pkce
                //  sisteme otantike olduktan sonra kullanılacak olan kısım
                new Client
                {
                    ClientId = "mvcClientForUser",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { 
                        "Catalog_FullPermission",
                        "Basket_FullPermission",
                        "Discount_FullPermission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName },
                    AccessTokenLifetime = 300
                },
            };
    }
}