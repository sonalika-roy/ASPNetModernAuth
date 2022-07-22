<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Contoso.Intranet.WebApp.Error" %>
<!--
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
-->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Error</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>The following error has occurred</h2>
            <p><%: this.ErrorMessage %></p>
        </div>
    </form>
</body>
</html>