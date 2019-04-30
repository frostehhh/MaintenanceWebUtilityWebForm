<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dynamic.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.Dynamic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Dashboard</a>
        </li>
        <li class="breadcrumb-item active">Dynamic Maintenance</li>
    </ol>
    <div class="row">
        <asp:PlaceHolder runat="server" ID="MaintenanceNavPlaceHolder" />
    </div>
</asp:Content>
