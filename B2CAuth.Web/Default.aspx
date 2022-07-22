<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Contoso.Intranet.WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
    <h2>User Information - WebForms Example</h2>
    <table class="table table-striped table-hover">
        <%
            foreach (var row in this.UserInformation)
            {
        %>
        <tr>
            <td><%: row.Key %></td>
            <td><%: row.Value %></td>
        </tr>
        <%
            }
        %>
    </table>
</asp:Content>
