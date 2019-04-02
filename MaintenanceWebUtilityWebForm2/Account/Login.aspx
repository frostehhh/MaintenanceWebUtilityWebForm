<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MaintenanceWebUtilityWebForm.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card card-login mx-auto mt-5">
            <div class="card-header">Login</div>
            <div class="card-body">
                <%--<form method="post" asp-controller="Accounts" asp-action="LoginTry">--%>


                <asp:Login ID = "Login1" runat = "server" OnAuthenticate= "ValidateUser" CssClass="table">
                    <LayoutTemplate>
                        <div class="form-group">
                            <div class="form-label-group">
                                <asp:TextBox ID="UserName"  runat="server" class="form-control" autofocus="autofocus"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                <%--<input asp-for="Username"  id="inputEmail" class="form-control" placeholder="Email address" required="required" autofocus="autofocus">--%>
                                <%--<span asp-validation-for="Username" class="text-danger"></span>--%>
                                <label for="inputEmail">Email address</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-label-group">
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                <%--<input asp-for="PasswordTxt" type="password" id="inputPassword" class="form-control" placeholder="Password" required="required">--%>
                                <%--<span asp-validation-for="PasswordTxt" class="text-danger"></span>--%>
                                <label for="inputPassword">Password</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" value="remember-me">
                                    Remember Password
                                </label>
                            &nbsp;&nbsp;</div>
                        </div>
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login2" class="btn btn-primary btn-block"/>
                        <%--<input type="submit" value="Login" class="btn btn-primary btn-block" />--%>
                    </LayoutTemplate>
                </asp:Login>
                <%--</form>--%>
                
                <div class="text-center">
                    <a class="d-block small mt-3" href="register.html">Register an Account                    <a class="d-block small" href="forgot-password.html">Forgot Password?</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
