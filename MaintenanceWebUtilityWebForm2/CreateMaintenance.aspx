<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="CreateMaintenance.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.CreateMaintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Dashboard</a>
        </li>
        <li class="breadcrumb-item active">Create New Maintenance</li>
    </ol>
    <div class="card mb-3">
      
        <!--table with tabulator.js-->
        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                Create New Maintenance
            </div>
            <div class="card-body">
                <div class="form-group row">

                        <label for="MaintenanceName" class="col-sm-2">Maintenance Table Name</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="MaintenanceName" runat="server" CssClass="form-control" />
                        </div>
                </div>
                <div class="table-responsive">
                    <table id="" class="table table-bordered">
                        <thead>
                            <tr>
                                <th>PK</th>
                                <th>Name</th>
                                <th>Data Type</th>
                                <th>Allow Nulls</th>
                                <th>Default</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><label>PK</label></td>
                                <td><asp:TextBox ID="Name_Row_PK" runat="server" CssClass="form-control" /></td>
                                <td>
                                    <div class="container">
                                        <div class="row">
                                            <asp:DropDownList ID="DataType_Row_PK" runat="server" CssClass="form-control col-sm-9" AutoPostBack="true" OnSelectedIndexChanged="DataType_Row_OnSelectedIndexChanged"/>
                                            <asp:TextBox ID="DataTypeNum_Row_PK" runat="server" CssClass="form-control col-sm-2" Enabled="false" />
                                        </div>
                                    </div>
                                </td>
                                <td><asp:CheckBox ID="AllowNulls_Row_PK" Enabled="false" runat="server" /></td>
                                <td><asp:TextBox ID="Default_Row_PK" runat="server" CssClass="form-control" /></td>
                            </tr>
                            <asp:PlaceHolder ID="TableDataPlaceHolder" runat="server" ClientIDMode="Static" />
                        </tbody>
                    </table>    
                    <asp:Button runat="server" class="btn btn-light" ID="AddRowBtn" Text="Add Row" OnClick="AddRowBtn_OnClick"/>
                    <asp:Button runat="server" class="btn btn-light" ID="CreateMaintenanceBtn" Text="Create" OnClick="CreateBtn_OnClick"/> 
                    <asp:Button runat="server" class="btn btn-light" ID="Button1" Text="Testing" OnClick="TestCreatePages_OnClick"/>    

                </div>
            </div>
        </div>

        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
    </div>
    


</asp:Content>
