<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WriteCalEvent._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="max-width: 80% !important; min-width: 750px !important;">
        <div class="panel panel-primary" id="createEventsForm">
            <div class="panel-heading">
                <strong runat="server" id="panelHeader" class="h1">Schedule Appointment</strong>
            </div>
            <div class="panel-body">
                <div class="row" style="padding-left: 15px">
                    <div class="form-group col-md-6">
                        <div id="nameFormGroup" class="form-group">
                            <asp:RequiredFieldValidator ID="eventNameValidator" runat="server"
                                ControlToValidate="txtAppointmentName"
                                ErrorMessage="Event name is required." ForeColor="Red"> *
                            </asp:RequiredFieldValidator>
                            <label for="txtAppointmentName">Appointment Name:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtAppointmentName" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="form-group col-md-6 pull-left">
                                <div id="locationFormGroup" class="form-group">
                                    <asp:RequiredFieldValidator ID="eventLocationValidator" runat="server"
                                        ControlToValidate="txtLocation"
                                        ErrorMessage="Location is required." ForeColor="Red"> *
                                    </asp:RequiredFieldValidator>
                                    <label for="txtLocation">Location:</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtLocation" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="row" style="padding-left: 15px">
                    <div class="form-group col-md-12">
                        <div id="descriptionFormGroup" class="form-group">
                            <label for="txtAppointmentDescription">Description:</label>
                            <asp:TextBox runat="server" CssClass="form-control description" ClientIDMode="Static" TextMode="MultiLine" ID="txtAppointmentDescription"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" style="padding-left: 15px">
                    <div class="form-group col-md-12">
                        <div id="AttendeeFormGroup" class="form-group">
                             <asp:RequiredFieldValidator ID="eventAttendeeValidator" runat="server"
                                        ControlToValidate="txtAttendee"
                                        ErrorMessage="Location is required." ForeColor="Red"> *
                                    </asp:RequiredFieldValidator>
                            <label for="txtAttendee">Attendes:(Add mails sepereted by ";")</label>
                            <asp:TextBox runat="server" CssClass="form-control description" ClientIDMode="Static" TextMode="MultiLine" ID="txtAttendee"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row form-group" style="padding-left: 15px">
                    <div class="form-group col-md-4 col-sm-5">
                        <asp:RequiredFieldValidator ID="startdatepickerTBValidator" runat="server"
                            ControlToValidate="startdatepickerTB"
                            ErrorMessage="Start Date is required." ForeColor="Red"> *
                        </asp:RequiredFieldValidator>
                        <label for="startdatepicker">Start Date:</label>
                        <div id="startdatepicker" class="input-group">
                            <asp:TextBox ID="startdatepickerTB" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
                    <div class="form-group col-md-4 col-sm-5">
                        <asp:RequiredFieldValidator ID="starttimepickerTBValidator" runat="server"
                            ControlToValidate="starttimepickerTB"
                            ErrorMessage="Start Time is required." ForeColor="Red"> *
                        </asp:RequiredFieldValidator>
                        <label for="starttimepicker">Start Time:</label>
                        <div id="starttimepicker" class="input-group">
                            <asp:TextBox ID="starttimepickerTB" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-time"></span>
                            </span>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
                </div>
                <div class="row form-group" style="padding-left: 15px">
                    <div class="form-group col-md-4 col-sm-5">
                        <asp:RequiredFieldValidator ID="enddatepickerTBValidator" runat="server"
                            ControlToValidate="enddatepickerTB"
                            ErrorMessage="End Date is required." ForeColor="Red"> *
                        </asp:RequiredFieldValidator>
                        <label for="enddatepicker">End Date:</label>
                        <div id="enddatepicker" class="input-group date">
                            <asp:TextBox ID="enddatepickerTB" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
                    <div class="form-group col-md-4 col-sm-5">
                        <asp:RequiredFieldValidator ID="endTimepickerTBValidator" runat="server"
                            ControlToValidate="endTimepickerTB"
                            ErrorMessage="End Time is required." ForeColor="Red"> *
                        </asp:RequiredFieldValidator>
                        <label for="endtimepicker">End Time:</label>
                        <div id="endtimepicker" class="input-group">
                            <asp:TextBox ID="endTimepickerTB" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-time"></span>
                            </span>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
                </div>

                <div class="row-fluid">
                    <div class="col-md-12 btn-toolbar">
                        <asp:Button ID="cancel" Text="Cancel" runat="server" OnClick="cancel_Click" CssClass="btn btn-defualt pull-left" CausesValidation="false" />
                        <asp:Button ID="createEvent" OnClick="createEvent_Click" Text="Create" runat="server" CssClass="btn btn-success pull-right" />
                    </div>
                </div>
                <br />
                <br />
                <div class="row" style="padding-left: 15px">
                    <div class="form-group col-md-12">
                        <div id="DisplayLink" class="form-group">
                            <label for="lblDisplayLink">Link of Created Event: </label>
                            <asp:HyperLink runat="server" ID="lnkEventLink"></asp:HyperLink>                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/moment.js"></script>
    <script src="../Scripts/bootstrap-datetimepicker.min.js"></script>
    <script src="../Scripts/bootstrap-datepicker.js"></script>
    <script src="../Scripts/jquery.timepicker.js"></script>
    <script src="../Scripts/jquery.timepicker.min.js"></script>

    <script type="text/javascript">
        $(function () {

            $('#startdatepicker,#enddatepicker').datetimepicker({
                format: "MM-DD-YYYY",
                useCurrent: false,
                minDate: moment()
            });
            $('#startdatepicker').datetimepicker().on('dp.change', function (e) {
                var incrementDay = moment(new Date(e.date));
                //incrementDay.add(0, 'days');
                $('#enddatepicker').data('DateTimePicker').minDate(incrementDay);
                $(this).data("DateTimePicker").hide();
            });

            $('#enddatepicker').datetimepicker().on('dp.change', function (e) {
                var decrementDay = moment(new Date(e.date));
                //decrementDay.subtract(0, 'days');
                $('#startdatepicker').data('DateTimePicker').maxDate(decrementDay);
                $(this).data("DateTimePicker").hide();
            });

            $('#starttimepicker,#endtimepicker').datetimepicker({
                format: "LT",
                stepping: 15
            });
           
        });
       
    </script>
</asp:Content>
