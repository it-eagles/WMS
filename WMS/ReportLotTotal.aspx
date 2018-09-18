<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportLotTotal.aspx.vb" Inherits="WMS.ReportLotTotal" MasterPageFile="~/Home.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>ReportLotTotal
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Master Files</a></li>
                <li><a href="ReprotLotTotal.aspx" class="active">Report Lot Total</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="box box-default">
                            <div class="box-body">
                                <div class="col-xs-6">
                                    <button class="btn btn-app btn-sm" id="btnAddHead" runat="server" onserverclick="btnAddHead_ServerClick"><i class="fa fa-inbox"></i>Add</button>
                                    <button class="btn btn-app btn-sm" id="btnEditHead" runat="server" onserverclick="btnEditHead_ServerClick"><i class="fa fa-edit"></i>Edit</button>
                                </div>
                                <div class="col-xs-6 text-right">
                                    <button class="btn btn-app btn-sm" id="btnSaveAddHead" runat="server" onserverclick="btnSaveAddHead_ServerClick"><i class="fa fa-save"></i>Save Add</button>
                                    <button class="btn btn-app btn-sm" id="btnSaveEditHead" runat="server" onserverclick="btnSaveEditHead_ServerClick"><i class="fa fa-save"></i>Save Edit</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- left column -->

                <div class="panel panel-default">
                    <div id="Tabs" role="tabpanel" class="nav-tabs-custom">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="EndJob" aria-controls="Master" role="tab" data-toggle="tab">Master</a></li>
                            <li><a href="Master" aria-controls="EndJob" role="tab" data-toggle="tab">End Job</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content" style="padding-top: 20px">
                            <%-----------------------------------------------------Start TRUCK WAY BILL HEAD-----------------------------------------------------------%>
                            <!------- Import Goods ------->
                            <div role="tabpanel" class="active tab-pane" id="EndJob">
                                <fieldset runat="server" id="Master_fieldset">
                                    <!-- Post -->
                                    <div class="row">
                                        <div class="col-md-12">
                                            <!-- Horizontal Form -->

                                            <!-- form start -->
                                            <div class="form-horizontal">

                                                <div class="form-group">
                                                    <label for="txtDate" class="col-sm-3 control-label">Date:</label>
                                                    <div class="checkbox col-sm-1">
                                                        <input type="checkbox" runat="server" id="chkDate" />
                                                    </div>
                                                    <label for="txtCustomer" class="col-sm-3 control-label">Customer:</label>
                                                    <div class="checkbox col-sm-1">
                                                        <input type="checkbox" runat="server" id="chkCustomer" />
                                                    </div>

                                                </div>
                                                <div class="form-group">

                                                    <label for="txtFromDate" class="col-sm-3 control-label">FromDate:</label>
                                                    <div class="col-sm-5">
                                                        <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                                        <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerFromDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                                        </asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtenderFromDate" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label for="txtToDate" class="col-sm-3 control-label">ToDate:</label>
                                                    <div class="col-sm-5">
                                                        <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                                        <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerToDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                                        </asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label for="txtCustomer" class="col-sm-3 control-label">Customer:</label>
                                                    <div class="col-sm-5">
                                                        <asp:DropDownList ID="ddllocationtariffrequite" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code">
                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group">

                                                    <label for="txtLotReport" class="col-sm-3 control-label">Lot Report:</label>

                                                    <div class="radio">

                                                        <label>
                                                            <asp:RadioButton runat="server" ID="RadioLBKIN" Text="LBK IN" onclick="EnableDisableTextBox();" GroupName="option3" />
                                                        </label>

                                                        <label>
                                                            <asp:RadioButton runat="server" ID="RadioLBKOUT" Text="LBK OUT" onclick="EnableDisableTextBox();" GroupName="option3" />
                                                        </label>

                                                        <label>
                                                            <asp:RadioButton runat="server" ID="RadioHCRIN" Text="HCR IN" onclick="EnableDisableTextBox();" GroupName="option3" />
                                                        </label>

                                                        <label>
                                                            <asp:RadioButton runat="server" ID="RadioHCROUT" Text="HCR OUT" onclick="EnableDisableTextBox();" GroupName="option3" />
                                                        </label>

                                                    </div>
                                                    <div class="col-sm-2">
                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnFind" title="btnFind" onserverclick="btnFind_ServerClick">Find</button>
                                                </div>
                                                </div>


                                                <!-- /.radio -->

                                            </div>
                                    </div>
                           
                        <!-- general form Commodity -->

                </div>
                <!-- /.post -->
                </fieldset>
            </div>
            <!------- /. Import Goods ------->
            <%-------------------------------------------------------------End TRUCK WAY BILL HEAD-------------------------------------------------------%>


            <%--------------------------------------------------------------Start TRUCK WAY BILL DETAIL----------------------------------------------------------%>
            <!-------- Export Goods --------->
                <div role="tabpanel" class="tab-pane" id="Master">
               
                 </div>
                <!-----/ Export Goods----->

                <%--------------------------------------------------------------END TRUCK WAY BILL DETAIL----------------------------------------------------------%>
            </div>
            <!-- /.tab-pane -->
            </div>
                                <!-- /.tab-pane -->
            <asp:HiddenField ID="TabName" runat="server" />
            </div>
                            <!-- /.col -->
            
        </section>
        <!-- /.content -->


    </form>
</asp:Content>
