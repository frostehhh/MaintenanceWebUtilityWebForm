<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.Facilities.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Index</h1>
    <asp:GridView ID="FacilityPeriodDetailsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id,FacilityId" SelectMethod="GetFacilityPeriodDetails" ItemType="MaintenanceWebUtilityWebForm2.FacilityPeriod" CssClass="table">
        <Columns>
            <asp:TemplateField HeaderText="EncodingStartDate">
                <ItemTemplate>
                    <asp:TextBox ID="EncodingStartDate" type="datetime-local" Width="240" runat="server" value='<%#:Item.EncodingStartDate.Value.ToString("yyyy-MM-ddTHH:mm:ss")%>' CssClass="form-control valid" ></asp:TextBox>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="EncodingEndDate">
                <ItemTemplate>
                    <asp:TextBox ID="EncodingEndDate" type="datetime-local" Width="240" runat="server" OnTextChanged="EncodingEndDate_TextChanged" value='<%#: Item.EncodingEndDate.Value.ToString("yyyy-MM-ddTHH:mm:ss") %>' CssClass="form-control valid"></asp:TextBox>
                    <asp:HiddenField ID="InitialEncodingEndDate" runat="server"  Value='<%#: Item.EncodingEndDate.Value.ToString("yyyy-MM-ddTHH:mm:ss") %>' />
                    <asp:HiddenField ID="ChangedEncodingDate" runat="server" />
                    <asp:HiddenField ID="IsEncodingEndDateChanged" runat="server" Value="false" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
</asp:Content>
