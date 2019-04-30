<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTable.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.DynamicMaintenance.ViewTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Dashboard</a>
        </li>
        <li class="breadcrumb-item ">Dynamic Maintenance</li>
        <li class="breadcrumb-item active">View Table</li>
    </ol>
    <div class="card mb-3">
        <div class="card-header">
            <i class="fas fa-table"></i>
            <asp:Literal  ID="tableNameLiteral" runat="server"/>
        </div>
        <div class="table-responsive">
            <asp:GridView runat="server" ID="ViewTable_GridView" CssClass="table table-bordered dataTable" 
                AutoGenerateEditButton="true" ShowHeaderWhenEmpty="true" 
                OnRowEditing="ViewTable_GridView_OnRowEditing"
                OnRowCancelingEdit="ViewTable_GridView_OnRowCancelingEdit"
                OnRowUpdating="ViewTable_GridView_OnRowUpdating"
                >
            </asp:GridView>
        </div>
        <asp:LinkButton ID="InsertRow_LinkBtn" runat="server" CssClass="btn btn-light" Text="Insert Row" OnClick="InsertRow_LinkBtn_OnClick" />
    </div>
</asp:Content>
