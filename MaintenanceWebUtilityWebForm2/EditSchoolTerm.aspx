<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSchoolTerm.aspx.cs" Inherits="MaintenanceWebUtilityWebForm2.EditSchoolTerm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit SHS Term Code</h1>

    <asp:FormView ID="SHS_Term_Code_FormView" runat="server" AutoGenerateColumns="False" DataKeyNames="SHS_Term_Code" SelectMethod="GetSchoolTermDetails" ItemType="MaintenanceWebUtilityWebForm2.SHS_School_Term" OnDataBound="FormView_OnDataBound" >
        <ItemTemplate>
            <table>
                <tr>
                    <td><asp:Label ID="SHS_Term_Code_Lbl" runat="server" Text="SHS_Term_Code"></asp:Label></td>
                    <td><asp:TextBox ID="SHS_Term_Code"  Width="240" runat="server" ReadOnly="True" value='<%#:Item.SHS_Term_Code%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="School_Year"></asp:Label></td>
                    <td><asp:TextBox ID="School_Year"  Width="240" runat="server" value='<%#:Item.School_Year%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="School_Term_Number"></asp:Label></td>
                    <td>
                        <asp:SqlDataSource ID="SqlSelectSchool_Term_Number" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:MaintenanceWebUtilityDbConnectionString %>" 
                            SelectCommand="uspGetSchoolTermNumberDropDown" 
                            SelectCommandType="StoredProcedure" />
                        <asp:DropDownList  ID="School_Term_Number" SelectedValue="<%# Item.School_Term_Number %>"  DataSourceID="SqlSelectSchool_Term_Number" DataValueField="School_Term_Number" DataTextField="School_Term_Number" Width="240" runat="server" AutoPostBack="true"  CssClass="form-control valid" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Description"></asp:Label></td>
                    <td><asp:TextBox ID="Description"  Width="240" runat="server" value='<%#:Item.Description%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Date_Start"></asp:Label></td>
                    <td><asp:TextBox ID="Date_Start" type="datetime-local" Width="240" runat="server" value='<%#:Item.Date_Start.ToString("yyyy-MM-ddTHH:mm:ss")%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Date_End"></asp:Label></td>
                    <td><asp:TextBox ID="Date_End" type="datetime-local" Width="240" runat="server" value='<%#:Item.Date_End.ToString("yyyy-MM-ddTHH:mm:ss")%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Is_Active"></asp:Label></td>
                    <asp:SqlDataSource ID="SqlSelectIs_Active" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:MaintenanceWebUtilityDbConnectionString %>" 
                            SelectCommand="uspGetIsActiveSelections" 
                            SelectCommandType="StoredProcedure" />
                    <td><asp:RadioButtonList ID ="Is_ActiveRadioBtn" runat="server" SelectedValue="<%#:Item.Is_Active%>" DataSourceID="SqlSelectIs_Active" DataValueField="Is_Active" DataTextField="Is_Active" CssClass="display:inline"></asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Graduation_Date"></asp:Label></td>
                    <td><asp:TextBox ID="Graduation_Date" type="datetime-local" Width="240" runat="server" value='<%#:Item.Graduation_Date.HasValue ? Item.Graduation_Date.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Enrollment_Date_Start"></asp:Label></td>
                    <td><asp:TextBox ID="Enrollment_Date_Start" type="datetime-local" Width="240" runat="server" value='<%#:Item.Enrollment_Date_Start.HasValue ? Item.Enrollment_Date_Start.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Enrollment_Date_End"></asp:Label></td>
                    <td><asp:TextBox ID="Enrollment_Date_End" type="datetime-local" Width="240" runat="server" value='<%#:Item.Enrollment_Date_End.HasValue ? Item.Enrollment_Date_End.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null%>' CssClass="form-control valid" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="College_Term_Code"></asp:Label></td>
                    <td><asp:TextBox ID="College_Term_Code"  Width="240" runat="server" value='<%#:Item.College_Term_Code%>' CssClass="form-control valid" ></asp:TextBox></td>
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
