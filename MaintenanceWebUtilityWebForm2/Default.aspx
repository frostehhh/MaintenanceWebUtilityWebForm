<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h1 class="display-4">Welcome</h1>
        <p>Learn about <a href="https://docs.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
    </div>

    <!---- SHOW FACILITIES HERE-->
    <!-- Icon Cards-->
    <div class="row">
        <asp:Literal runat="server" id="empAccessibleLiteral" />
    </div>

</asp:Content>
