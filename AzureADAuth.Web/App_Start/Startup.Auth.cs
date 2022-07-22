//===============================================================================
// Microsoft FastTrack for Azure
// ASP.Net Modern Authentication Samples
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Configuration;
using System.Threading.Tasks;

namespace AzureADAuth.Web
{
    public partial class Startup
    {
        private readonly string _clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private readonly string _authority = string.Format("{0}/{1}/", ConfigurationManager.AppSettings["ida:Authority"], ConfigurationManager.AppSettings["ida:Tenant"]);

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions() { CookieName = "AzureADAuth" });

            OpenIdConnectAuthenticationNotifications notifications = new OpenIdConnectAuthenticationNotifications()
            {
                AuthenticationFailed = context =>
                {
                    context.HandleResponse();
                    context.Response.Redirect("~/Error.aspx?message=" + context.Exception.Message);
                    return Task.FromResult(0);
                }
            };

            // If a domain has been configured, pass a domain hint to the identity provider to bypass home realm discovery
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ida:Domain"]))
            {
                notifications.RedirectToIdentityProvider = (context) =>
                {
                    context.ProtocolMessage.DomainHint = ConfigurationManager.AppSettings["ida:Domain"];
                    return Task.FromResult(0);
                };
            }

            app.UseOpenIdConnectAuthentication(
                 new OpenIdConnectAuthenticationOptions
                 {
                     ClientId = _clientId,
                     Authority = _authority,
                     Notifications = notifications
                 });
        }
    }
}