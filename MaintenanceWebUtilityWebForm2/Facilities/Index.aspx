<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.Facilities.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Index</h1>
    <!--<asp:EntityDataSource ID="FaciltyPeriodsDataSource" runat="server" ConnectionString="name=MaintenanceWebUtilityDbEntities" DefaultContainerName="MaintenanceWebUtilityDbEntities" EnableDelete="True" EnableFlattening="False" EnableUpdate="True" EntitySetName="FacilityPeriods" EntityTypeFilter="FacilityPeriod"></asp:EntityDataSource>-->
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" SelectMethod="GetFacilityPeriods"  CssClass="table">
        
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="FacilityId" HeaderText="FacilityId" SortExpression="FacilityId" />
            <asp:BoundField DataField="PeriodId" HeaderText="PeriodId" SortExpression="PeriodId" />
            <asp:BoundField DataField="EncodingStartDate" HeaderText="EncodingStartDate" SortExpression="EncodingStartDate" />
            <asp:BoundField DataField="EncodingEndDate" HeaderText="EncodingEndDate" SortExpression="EncodingEndDate" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="./Edit.aspx?fpId={0}" Text="Edit"/>
        </Columns>
    </asp:GridView>
</asp:Content>
