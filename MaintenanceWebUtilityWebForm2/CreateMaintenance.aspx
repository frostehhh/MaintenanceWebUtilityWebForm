<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateMaintenance.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.CreateMaintenance" %>
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
                                <td><asp:TextBox ID="Name_Row_0" runat="server" /></td>
                                <td>
                                    <asp:DropDownList ID="DataType_Row_0" runat="server">
                                        <asp:ListItem Text="varchar(50)" Value="varchar(50)" />
                                        <asp:ListItem Text="nvarchar(50)" Value="nvarchar(50)" />
                                    </asp:DropDownList>
                                </td>
                                <td><asp:CheckBox ID="AllowNulls_Row_0" runat="server" /></td>
                                <td><asp:TextBox ID="Default_Row_0" runat="server" /></td>
                            </tr>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" ClientIDMode="Static" />
                        </tbody>
                    </table>    
                    <asp:Button runat="server" class="btn btn-light" ID="AddRowBtn" Text="Add Row" OnClick="AddRowBtn_OnClick"/>
                    <asp:Button runat="server" class="btn btn-light" ID="CreateMaintenanceBtn" Text="Create"/>    
                </div>
            </div>
        </div>

        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
    </div>
    


</asp:Content>
