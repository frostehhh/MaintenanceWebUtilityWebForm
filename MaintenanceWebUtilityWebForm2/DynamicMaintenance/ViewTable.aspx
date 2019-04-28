<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTable.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.DynamicMaintenance.ViewTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-responsive">
        <asp:GridView runat="server" ID="ViewTable_GridView" CssClass="table table-bordered dataTable" AutoGenerateEditButton="true" ShowHeaderWhenEmpty="true" OnDataBound="AssignCssPerRow">
        </asp:GridView>
    </div>
</asp:Content>
