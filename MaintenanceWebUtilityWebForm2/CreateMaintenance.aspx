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
                    <div id="dataTable_wrapper" class="dataTables_wrapper dt-bootstrap4">
                         <div class="row">
                            <div class="col-sm-12">
                                <table class="table table-bordered dataTable" id="dataTable" width="100%" cellspacing="0" role="grid" aria-describedby="dataTable_info" style="width: 100%;">
                                    <thead>
                                        <tr role="row">
                                            <th tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" >PK</th>
                                            <th tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" >Name</th>
                                            <th tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" >Data Type</th>
                                            <th tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" >Allow Nulls</th>
                                            <th tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" >Default Value</th>
                                        </tr>
                                    </thead>
                                    <tbody>                   
                                        <tr role="row" class="odd">
                                            <td>Airi Satou</td>
                                            <td>Accountant</td>
                                            <td>Tokyo</td>
                                            <td>33</td>
                                            <td>2008/11/28</td>
                                        </tr>
                                        <tr role="row" class="even">
                                            <td>Airi Satou</td>
                                            <td>Accountant</td>
                                            <td>Tokyo</td>
                                            <td>33</td>
                                            <td>2008/11/28</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>                 
                    </div>
                </div>
            </div>
        </div>

        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
    </div>

</asp:Content>
