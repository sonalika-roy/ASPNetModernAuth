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
using System;

namespace Contoso.Intranet.WebApp
{
    public partial class Error : System.Web.UI.Page
    {
        protected string ErrorMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ErrorMessage = Request.QueryString["message"];
        }
    }
}