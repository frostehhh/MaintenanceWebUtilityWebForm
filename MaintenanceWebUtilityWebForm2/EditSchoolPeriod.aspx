<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSchoolPeriod.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.EditSchoolPeriod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit SHS School Period</h1>

    <asp:FormView ID="SHS_School_Period_FormView" runat="server" AutoGenerateColumns="False" DataKeyNames="Period_ID, SHS_Term_Code" SelectMethod="GetSchoolPeriodDetails" ItemType="MaintenanceWebUtilityWebForm2.SHS_School_Period" OnDataBound="FormView_OnDataBound">
        <ItemTemplate>
            <table>
                <tr>
                    <td><asp:Label ID="Period_ID_Lbl" runat="server" Text="Period_ID"></asp:Label></td>
                    <td><asp:TextBox ID="Period_ID"  Width="240" runat="server" ReadOnly="True" value='<%#:Item.Period_ID%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="SHS_Term_Code_Lbl" runat="server" Text="SHS_Term_Code"></asp:Label></td>
                    <td><asp:TextBox ID="SHS_Term_Code"  Width="240" runat="server" value='<%#:Item.SHS_Term_Code%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Period_Number"></asp:Label></td>
                    <td><asp:TextBox ID="Period_Number"  Width="240" runat="server" value='<%#:Item.Period_Number%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Period_Description"></asp:Label></td>
                    <td><asp:TextBox ID="Period_Description"  Width="240" runat="server" value='<%#:Item.Period_Description%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="School_Days"></asp:Label></td>
                    <td><asp:TextBox ID="School_Days"  Width="240" runat="server" value='<%#:Item.School_Days%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Is_Active"></asp:Label></td>
                    <td>
                        <asp:SqlDataSource ID="SqlSelectIs_Active" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:MaintenanceWebUtilityDbConnectionString %>" 
                            SelectCommand="uspGetIsActiveSelections" 
                            SelectCommandType="StoredProcedure" />
                        <asp:RadioButtonList ID ="Is_ActiveRadioBtn" runat="server" SelectedValue="<%#:Item.Is_Active%>" DataSourceID="SqlSelectIs_Active" DataValueField="Is_Active" DataTextField="Is_Active" CssClass="display:inline"></asp:RadioButtonList>
                    </td>
                    
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Encoding_Start"></asp:Label></td>
                    <td><asp:TextBox ID="Encoding_Start" type="datetime-local" Width="240" runat="server" value='<%#:Item.Encoding_Start.ToString("yyyy-MM-ddTHH:mm:ss")%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Encoding_End"></asp:Label></td>
                    <td><asp:TextBox ID="Encoding_End" type="datetime-local" Width="240" runat="server" value='<%#:Item.Encoding_End.ToString("yyyy-MM-ddTHH:mm:ss")%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Updated_Date_Lbl" runat="server" Text="Updated_Date"></asp:Label></td>
                    <td><asp:TextBox ID="Updated_Date" type="datetime-local" Width="240" runat="server" value='<%#:Item.Updated_Date.ToString("yyyy-MM-ddTHH:mm:ss")%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Updated_By_Lbl" runat="server" Text="Updated_By"></asp:Label></td>
                    <td><asp:TextBox ID="Updated_By"  Width="240" runat="server" value='<%#:Item.Updated_By%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Updated_Host_Lbl" runat="server" Text="Updated_Host"></asp:Label></td>
                    <td><asp:TextBox ID="Updated_Host"  Width="240" runat="server" value='<%#:Item.Updated_Host%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Updated_App_Lbl" runat="server" Text="Updated_App"></asp:Label></td>
                    <td><asp:TextBox ID="Updated_App"  Width="240" runat="server" value='<%#:Item.Updated_App%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
</asp:Content>
