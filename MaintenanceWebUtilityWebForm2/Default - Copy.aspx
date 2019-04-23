<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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
