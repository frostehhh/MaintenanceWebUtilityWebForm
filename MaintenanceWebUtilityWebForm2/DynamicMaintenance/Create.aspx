<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.DynamicMaintenance.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="EditRow_FormView" runat="server">
        <ItemTemplate>
            <asp:PlaceHolder ID="EditRow_PlaceHolder" runat="server" />
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
