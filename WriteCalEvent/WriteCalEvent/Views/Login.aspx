<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="WriteCalEvent.Views.Login" %>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
            <div class="container col-sm-6 col-sm-offset-3">
    <div class="panel panel-default" id="loginForm">

            <div class="panel-heading">
                <strong class="h1">Sign In</strong>

            </div>
            <div class="panel-body danger">
                <div class="form-horizontal">
                    <div id="usernameFormGroup" class="form-group">
                        <div class="col-sm-12">
                            <asp:TextBox ID="Username" CssClass="form-control" name="Username" placeholder="Northwest username" ClientIDMode="Static" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="form-horizontal">
                    <div id="passwordFormGroup" class="form-group">
                        <div class="col-sm-12">
                            <asp:TextBox ID="Password" CssClass="form-control" type="password" name="Password" placeholder="Northwest password" ClientIDMode="Static" runat="server" />
                        </div>
                    </div>
                </div>

                <asp:Button CssClass="btn btn-primary" runat="server" ID="LoginButton" Text="Sign In" ClientIDMode="Static" />
                <br />
                <br />
                <asp:Label ID="ErrorLabel" CssClass="text-danger" Font-Size="16px" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

