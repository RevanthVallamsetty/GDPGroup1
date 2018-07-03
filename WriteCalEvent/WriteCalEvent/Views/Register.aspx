<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.cs" Inherits="WriteCalEvent.Views.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="max-width: 80% !important; min-width: 750px !important;">
        <div class="panel panel-primary" id="createEventsForm">
            <div class="panel-heading">
                <strong runat="server" id="panelHeader" class="h1">Register</strong>
            </div>
            <div class="panel-body">
                <div class="row" style="padding-left: 15px">
                    <div class="form-group col-md-6">
                        <div id="nameFormGroup" class="form-group">
                            <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server"
                                ControlToValidate="txtAppointmentName"
                                ErrorMessage="First Name is required." ForeColor="Red"> *
                            </asp:RequiredFieldValidator>
                            <label for="txtAppointmentName">First Name:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtAppointmentName" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" style="padding-left: 15px">
                    <div class="form-group col-md-12">
                        <div id="locationFormGroup" class="form-group">
                            <asp:RequiredFieldValidator ID="LastNameValidator" runat="server"
                                ControlToValidate="txtLastName"
                                ErrorMessage="Last Name is required." ForeColor="Red"> *
                            </asp:RequiredFieldValidator>
                            <label for="txtLastName">Last Name:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtLastName" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row" style="padding-left: 15px">
                    <div class="form-group col-md-12">
                        <div id="descriptionFormGroup" class="form-group">
                            <asp:RequiredFieldValidator ID="EmailFieldValidator" runat="server"
                                ControlToValidate="txtEmail"
                                ErrorMessage="Email is required." ForeColor="Red"> *
                            </asp:RequiredFieldValidator>
                            <label for="txtAppointmentDescription">Email:</label>
                            <asp:TextBox runat="server" CssClass="form-control description" ClientIDMode="Static" ID="txtEmail"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" style="padding-left: 15px">
                    <div class="form-group col-md-12">
                        <div id="AttendeeFormGroup" class="form-group">
                            <asp:RequiredFieldValidator ID="PhoneNumberValidator" runat="server"
                                ControlToValidate="txtPhoneNumber"
                                ErrorMessage="Phone Number is required." ForeColor="Red"> *
                            </asp:RequiredFieldValidator>
                            <label for="txtAttendee">Phone Number:</label>
                            <asp:TextBox runat="server" CssClass="form-control description" ClientIDMode="Static" TextMode="MultiLine" ID="txtPhoneNumber"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row form-group" style="padding-left: 15px">
                    <div class="form-group col-md-4 col-sm-5">
                        <asp:RequiredFieldValidator ID="PasswordValidator" runat="server"
                            ControlToValidate="txtPassword"
                            ErrorMessage="Password is required." ForeColor="Red"> *
                        </asp:RequiredFieldValidator>
                        <label for="txtPassword">Password:</label>
                        <div id="password" class="input-group">
                            <asp:TextBox ID="txtPassword" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row form-group" style="padding-left: 15px">
                    <div class="form-group col-md-4 col-sm-5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtRetypePassword"
                            ErrorMessage="Password is required." ForeColor="Red"> *
                        </asp:RequiredFieldValidator>
                        <label for="txtRetypePassword">Re-Type Password:</label>
                        <div id="divRetypePassword" class="input-group">
                            <asp:TextBox ID="TextBox1" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="col-md-12 btn-toolbar">
                        <asp:Button ID="btncancel" Text="Cancel" runat="server" CssClass="btn btn-defualt pull-left" CausesValidation="false" />
                        <asp:Button ID="btnRegister" Text="Register" runat="server" CssClass="btn btn-success pull-right" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>

</asp:Content>