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
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace Contoso.Intranet.WebApp
{
    public partial class _Default : Page
    {
        protected readonly Dictionary<string, string> UserInformation = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get current user information.
            if (!Request.IsAuthenticated) // Initiate log in
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            else
            {
                // Get current user information.
                try
                {
                    foreach (var claim in ((System.Security.Claims.ClaimsIdentity)User.Identity).Claims)
                    {
                        this.UserInformation[claim.Type] = claim.Value;
                    }
                }
                catch (Exception exc)
                {
                    this.UserInformation["ExceptionMessage"] = exc.Message;
                    this.UserInformation["ExceptionDetails"] = exc.ToString();
                }
            }
        }
    }
}