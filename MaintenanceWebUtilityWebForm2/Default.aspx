<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Breadcrumbs-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Dashboard</a>
        </li>
        <li class="breadcrumb-item active">Facilities</li>
    </ol>

    <!---- SHOW FACILITIES HERE-->
    <!-- Icon Cards-->
    <div class="row">
        <asp:Literal runat="server" id="empAccessibleLiteral" />
    </div>
    <div class="table-responsive">
        <asp:GridView ID="SHS_Term_GridView" runat="server" AutoGenerateColumns="false" DataKeyNames="SHS_Term_Code" SelectMethod="GetSchoolTerm" CssClass="table table-bordered dataTable" OnRowDataBound="SHS_Term_GridView_OnRowDataBound">
            <Columns>
                <asp:BoundField DataField="SHS_Term_Code" HeaderText="SHS_Term_Code" ReadOnly="True" SortExpression="SHS_Term_Code" />
                <asp:BoundField DataField="School_Year" HeaderText="School_Year" ReadOnly="True" SortExpression="School_Year" />
                <asp:BoundField DataField="School_Term_Number" HeaderText="School_Term_Number" ReadOnly="True" SortExpression="School_Term_Number" />
                <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True" SortExpression="Description" />
                <asp:BoundField DataField="Date_Start" HeaderText="Date_Start" ReadOnly="True" SortExpression="Date_Start" />
                <asp:BoundField DataField="Date_End" HeaderText="Date_End" ReadOnly="True" SortExpression="Date_End" />
                <asp:BoundField DataField="Is_Active" HeaderText="Is_Active" ReadOnly="True" SortExpression="Is_Active" />
                <asp:BoundField DataField="Graduation_Date" HeaderText="Graduation_Date" ReadOnly="True" SortExpression="Graduation_Date" />
                <asp:BoundField DataField="Enrollment_Date_Start" HeaderText="Enrollment_Date_Start" ReadOnly="True" SortExpression="Enrollment_Date_Start" />
                <asp:BoundField DataField="Enrollment_Date_End" HeaderText="Enrollment_Date_End" ReadOnly="True" SortExpression="Enrollment_Date_End" />
                <asp:BoundField DataField="College_Term_Code" HeaderText="College_Term_Code" ReadOnly="True" SortExpression="College_Term_Code" />
                <asp:BoundField DataField="Updated_Date" HeaderText="Updated_Date" ReadOnly="True" SortExpression="Updated_Date" />
                <asp:BoundField DataField="Updated_By" HeaderText="Updated_By" ReadOnly="True" SortExpression="Updated_By" />
                <asp:BoundField DataField="Updated_Host" HeaderText="Updated_Host" ReadOnly="True" SortExpression="Updated_Host" />
                <asp:BoundField DataField="Updated_App" HeaderText="Updated_App" ReadOnly="True" SortExpression="Updated_App" />
                <asp:HyperLinkField DataNavigateUrlFields="SHS_Term_Code" DataNavigateUrlFormatString="./EditSchoolTerm.aspx?SHSTermCode={0}" Text="Edit"/>
            </Columns>
        </asp:GridView>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="School_Period_GridView" runat="server" AutoGenerateColumns="false" DataKeyNames="Period_ID" SelectMethod="GetSchoolPeriod" CssClass="datatable" OnRowDataBound="School_Period_GridView_OnRowDataBound">
            <Columns>
                <asp:BoundField DataField="Period_ID" HeaderText="Period_ID" ReadOnly="True" SortExpression="Period_ID" />
                <asp:BoundField DataField="SHS_Term_Code" HeaderText="SHS_Term_Code" ReadOnly="True" SortExpression="SHS_Term_Code" />
                <asp:BoundField DataField="Period_Number" HeaderText="Period_Number" ReadOnly="True" SortExpression="Period_Number" />
                <asp:BoundField DataField="Period_Description" HeaderText="Period_Description" ReadOnly="True" SortExpression="Period_Description" />
                <asp:BoundField DataField="School_Days" HeaderText="School_Days" ReadOnly="True" SortExpression="School_Days" />
                <asp:BoundField DataField="Is_Active" HeaderText="Is_Active" ReadOnly="True" SortExpression="Is_Active" />
                <asp:BoundField DataField="Encoding_Start" HeaderText="Encoding_Start" ReadOnly="True" SortExpression="Encoding_Start" />
                <asp:BoundField DataField="Encoding_End" HeaderText="Encoding_End" ReadOnly="True" SortExpression="Encoding_End" />
                <asp:BoundField DataField="Updated_Date" HeaderText="Updated_Date" ReadOnly="True" SortExpression="Updated_Date" />
                <asp:BoundField DataField="Updated_By" HeaderText="Updated_By" ReadOnly="True" SortExpression="Updated_By" />
                <asp:BoundField DataField="Updated_Host" HeaderText="Updated_Host" ReadOnly="True" SortExpression="Updated_Host" />
                <asp:BoundField DataField="Updated_App" HeaderText="Updated_App" ReadOnly="True" SortExpression="Updated_App" />
                <asp:HyperLinkField DataNavigateUrlFields="Period_ID" DataNavigateUrlFormatString="./EditSchoolPeriod.aspx?PeriodId={0}" Text="Edit"/>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
