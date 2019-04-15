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
                                            <th class="sorting_asc" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Name: activate to sort column descending" aria-sort="ascending" style="width: 134.009px;">Name</th>
                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: 212.009px;">Position</th>
                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: 95.0089px;">Office</th>
                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Age: activate to sort column ascending" style="width: 41.0089px;">Age</th>
                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending" style="width: 92.0089px;">Start date</th>
                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: 74px;">Salary</th>
                                        </tr>
                                    </thead>
                                    <tbody>                   
                                        <tr role="row" class="odd">
                                            <td class="sorting_1">Airi Satou</td>
                                            <td class="">Accountant</td>
                                            <td class="">Tokyo</td>
                                            <td class="">33</td>
                                            <td class="">2008/11/28</td>
                                            <td class="">$162,700</td>
                                        </tr>
                                        <tr role="row" class="even">
                                            <td class="sorting_1">Angelica Ramos</td>
                                            <td class="">Chief Executive Officer (CEO)</td>
                                            <td class="">London</td>
                                            <td class="">47</td>
                                            <td class="">2009/10/09</td>
                                            <td class="">$1,200,000</td>
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
