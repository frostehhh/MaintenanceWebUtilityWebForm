<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.DynamicMaintenance.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:PlaceHolder ID="EditRow_PlaceHolder" runat="server" />
    <asp:LinkButton ID="InsertRow_LinkBtn" runat="server" CssClass="btn btn-light" Text="Insert Row" OnClick="InsertRow_LinkBtn_OnClick" />
</asp:Content>
