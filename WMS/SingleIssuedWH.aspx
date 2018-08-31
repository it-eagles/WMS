<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SingleIssuedWH.aspx.vb" Inherits="WMS.SingleIssuedWH" MasterPageFile="~/Home.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Single Issued
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>WareHouse</a></li>
                <li><a href="SingleIssuedWH.aspx" class="active">Single Issued</a></li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="row">


                <!-- left column -->

                <div class="col-md-12">

                    <div class="row">
                        <div class="col-xs-12">
                            <div class="box box-default">
                                <div class="box-body">
                                    <div class="col-xs-6">
                                        <button class="btn btn-app" id="btnAddHead" runat="server" onserverclick="btnAddHead_ServerClick"><i class="fa fa-inbox"></i>Add</button>
                                        <button class="btn btn-app" id="btnEditHead" runat="server" onserverclick="btnEditHead_ServerClick"><i class="fa fa-edit"></i>Edit</button>
                                    </div>
                                    <div class="col-xs-6 text-right">
                                        <button class="btn btn-app" id="btnSaveAddHead" runat="server" onserverclick="btnSaveAddHead_ServerClick" visible="false"><i class="fa fa-save"></i>Save Add</button>
                                        <button class="btn btn-app" id="btnSaveEditHead" runat="server" onserverclick="btnSaveEditHead_ServerClick" visible="false"><i class="fa fa-save"></i>Save Edit</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>



                    <%-------------------------------------------------Start Before Custom Tab---------------------------------------------------%>
                    <div class="col-md-12">
                        <fieldset runat="server" id="beforecustomtab_fieldset">
                            <h2></h2>
                            <div class="col-sm-6">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label for="txtPullSignal" class="col-sm-2 control-label">PullSignal:</label>
                                        <div class="col-sm-4">
                                            <input class="form-control" id="txtPullSignal_BeforeTab" runat="server" />
                                        </div>
                                        <label for="txtPullDateTime" class="col-sm-3 control-label">Pull Date/Time:</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox CssClass="form-control" ID="txtdatepickertxtPullDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtenderPullDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickertxtPullDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>

                                    </div>
                                    <div class="form-group">
                                        <label for="txtJobNo" class="col-sm-2 control-label">Job No:</label>
                                        <div class="col-sm-3">
                                            <input class="form-control" id="txtJobNo_BeforeTab" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                            <button type="button" class="btn btn-block btn-primary" runat="server" id="btnJobNoHead" onserverclick="btnJobNoHead_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                            <button type="button" class="btn btn-block btn-primary" runat="server" id="btnJobNoHead_Edit" onserverclick="btnJobNoHead_Edit_ServerClick" visible="false"><i class="glyphicon glyphicon-search"></i></button>
                                        </div>

                                        <div class="col-sm-2">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" runat="server" id="chkScrap" />
                                                    SCRAP
                                                </label>
                                            </div>

                                        </div>

                                        <div class="col-sm-3">
                                            <div class="bootstrap-timepicker">
                                                <div class="input-group">
                                                    <input type="text" class="form-control timepicker" runat="server" id="txtTimePickUpPullDateTime" />
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-clock-o"></i>
                                                    </div>
                                                </div>
                                                <!-- /.input group -->
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-6">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label for="txtDeliveryDateTime" class="col-sm-4 control-label">Delivery Date/Time:</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox CssClass="form-control" ID="txtdatepickerDeliveryDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtenderDeliveryDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerDeliveryDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="bootstrap-timepicker">
                                                <div class="input-group">
                                                    <input type="text" class="form-control timepicker" runat="server" id="txtTimePickUpDeliveryDateTime" />
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-clock-o"></i>
                                                    </div>
                                                </div>
                                                <!-- /.input group -->
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtConfirmDateTime" class="col-sm-4 control-label">Confirm Date/Time:</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox CssClass="form-control" ID="txtdatepickerComfirmDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtenderComfirmDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerComfirmDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="bootstrap-timepicker">
                                                <div class="input-group">
                                                    <input type="text" class="form-control timepicker" runat="server" id="txtTimePickUpConfirmDateTime" />
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-clock-o"></i>
                                                    </div>
                                                </div>
                                                <!-- /.input group -->
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <%------------------------------------------------End Before Custom Tab---------------------------------------------------%>

                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#issuecondition" data-toggle="tab">Issue Condition</a></li>
                            <li><a href="#confirmissue" data-toggle="tab">Confirm Issue</a></li>
                        </ul>

                        <div class="tab-content">






                            <%-----------------------------------------------------Start Issue Condition-----------------------------------------------------------%>
                            <!------- Import Goods ------->
                            <div class="active tab-pane" id="issuecondition">
                                <fieldset runat="server" id="issuecondition_fieldset">
                                    <!-- Post -->
                                    <div class="row">
                                        <%-----------------------------------------------------Start JOB Form-----------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <fieldset>
                                                    <legend>Job</legend>
                                                    <div class="box-body">
                                                        <div class="col-md-4 col-sm-4">
                                                            <div class="form-group">
                                                                <label for="txtJobNo_IssueCon" class="col-sm-4 control-label">Job No:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtJobNo_IssueCon" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-4">
                                                                </div>
                                                                <div class="col-sm-8">
                                                                    <div class="checkbox">
                                                                        <label>
                                                                            <input type="checkbox" runat="server" id="chkMoveTo" />Move to
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="txtCustRefNo_IssueCon" class="col-sm-4 control-label">Cust REF No:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustRefNo_IssueCon" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-4">
                                                                </div>
                                                                <div class="col-sm-8">
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnRejectMoveTo_IssueCon" title="btnRejectMoveTo_IssueCon" onserverclick="btnRejectMoveTo_IssueCon_ServerClick">Reject MoveTo</button>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="txtWHSite_IssueCon" class="col-sm-4 control-label">WH/Site:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlWHSite_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <!-- /.box-body -->
                                                    </div>
                                                    <!-- /.box-header -->
                                                </fieldset>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->

                                        </div>
                                        <%-------------------------------------------------------End JOB Form----------------------------------------------------------------%>

                                        <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                                        <div class="col-md-6">
                                            <!-- Horizontal Form -->

                                            <!-- form start -->
                                            <!-- general form Commodity -->
                                            <div class="form-horizontal">
                                                <fieldset>
                                                    <legend>Exporter</legend>
                                                    <div class="box-body">
                                                        <div class="form-group">
                                                            <label for="txtExporterCode_IssueCon" class="col-sm-4 control-label">Exporter Code:</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control" id="txtExporterCode_IssueCon" runat="server" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <button type="button" class="btn btn-block btn-primary" runat="server" id="btnExporterCode_IssueCon" onserverclick="btnExporterCode_IssueCon_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameExporter_IssueCon" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtNameExporter_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1Exporter_IssueCon" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress1Exporter_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2Exporter_IssueCon" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress2Exporter_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3Exporter_IssueCon" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress3Exporter_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4Exporter_IssueCon" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress4Exporter_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </fieldset>
                                            </div>

                                            <div class="form-horizontal">
                                                <fieldset>
                                                    <legend>Owner</legend>
                                                    <div class="box-body">
                                                        <div class="form-group">
                                                            <label for="txtOwnerCode_IssueCon" class="col-sm-4 control-label">Owner Code:</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control" id="txtOwnerCode_IssueCon" runat="server" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <button type="button" class="btn btn-block btn-primary" runat="server" id="btnOwnerCode_IssueCon" onserverclick="btnOwnerCode_IssueCon_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameOwner_IssueCon" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtNameOwner_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1Owner_IssueCon" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress1Owner_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2Owner_IssueCon" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress2Owner_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3Owner_IssueCon" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress3Owner_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4Owner_IssueCon" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress4Owner_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </fieldset>
                                            </div>

                                            <div class="form-horizontal">
                                                <fieldset>
                                                    <legend>Summer Detail</legend>
                                                    <div class="box-body">
                                                        <div class="form-group">
                                                            <label for="txtCommodity_IssueCon" class="col-sm-4 control-label">Commodity:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlCommodity_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityPackage_IssueCon" class="col-sm-5 control-label">Quantity Package:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtQuantityPackage_IssueCon" runat="server" value="0.0" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlQuantityPackage_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityPLTSkid_IssueCon" class="col-sm-5 control-label">Quantity PLT/Skid:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtQuantityPLTSkid_IssueCon" runat="server" value="0.0" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlQuantityPLTSkid_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityPicked_IssueCon" class="col-sm-5 control-label">Quantity Picked:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtQuantityPicked_IssueCon" runat="server" value="0.0" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlQuantityPicked_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRemark_IssueCon" class="col-sm-4 control-label">Remark:</label>
                                                            <div class="col-sm-8">
                                                                <textarea class="form-control" rows="3" runat="server" id="txtRemark_IssueCon" placeholder="Remark" style="height: 71px; width: 872px;"></textarea>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-4">
                                                            </div>
                                                            <div class="col-sm-8">
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnSumQTY_IssueCon" title="btnSumQTY_IssueCon" onserverclick="btnSumQTY_IssueCon_ServerClick">Sum QTY</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </fieldset>
                                            </div>

                                        </div>
                                        <!--/.col (left) -->
                                        <%---------------------------------------------------------------End Left Form------------------------------------------------%>



                                        <%------------------------------------------------------------Start Right Form------------------------------------------------%>
                                        <div class="col-md-6">
                                            <!-- Horizontal Form -->
                                            <!-- form start -->
                                            <!-- general form Commodity -->
                                            <div class="form-horizontal">
                                                <fieldset>
                                                    <legend>Consignee</legend>
                                                    <div class="box-body">
                                                        <div class="form-group">
                                                            <label for="txtConsigneeCode_IssueCon" class="col-sm-4 control-label">Consignee Code:</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control" id="txtConsigneeCode01_IssueCon" runat="server" placeholder="Job No" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <button type="button" class="btn btn-block btn-primary" runat="server" id="btnConsigneeCode_IssueCon" onserverclick="btnConsigneeCode_IssueCon_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameConsignee_IssueCon" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtNameConsignee_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1Consignee_IssueCon" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress1Consignee_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2Consignee_IssueCon" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress2Consignee_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3Consignee_IssueCon" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress3Consignee_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4Consignee_IssueCon" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress4Consignee_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </fieldset>
                                            </div>

                                            <div class="form-horizontal">
                                                <fieldset>
                                                    <legend>Ship To</legend>
                                                    <div class="box-body">
                                                        <div class="form-group">
                                                            <label for="txtShipToCode_IssueCon" class="col-sm-4 control-label">Ship To Code:</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control" id="txtShipToCode_IssueCon" runat="server" placeholder="Ship No" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <button type="button" class="btn btn-block btn-primary" runat="server" id="btnShipToCode_IssueCon" onserverclick="btnShipToCode_IssueCon_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameShipTo_IssueCon" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtNameShipTo_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1ShipTo_IssueCon" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress1ShipTo_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2ShipTo_IssueCon" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress2ShipTo_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3ShipTo_IssueCon" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress3ShipTo_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4ShipTo_IssueCon" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtAddress4ShipTo_IssueCon" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </fieldset>
                                            </div>

                                            <div class="form-horizontal">
                                                <fieldset>
                                                    <legend>Summer Detail</legend>
                                                    <div class="box-body">
                                                        <div class="form-group">
                                                            <label for="txtQuantityOfGood_IssueCon" class="col-sm-5 control-label">Quantity Of Goods:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtQuantityOfGood_IssueCon" runat="server" value="0.0" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlQuantityOfGood_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtWeight_IssueCon" class="col-sm-5 control-label">Weight:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtWeight_IssueCon" runat="server" value="0.0" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlWeight_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtVolume_IssueCon" class="col-sm-5 control-label">Volume:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtVolume_IssueCon" runat="server" value="0.0" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlVolume_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQTYDiscrepancy_IssueCon" class="col-sm-5 control-label">QTY Discrepancy:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtQTYDiscrepancy_IssueCon" runat="server" value="0.0" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlQTYDiscrepancy_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group" style="height: 71px;"></div>
                                                        <div class="form-group">
                                                            <div class="col-sm-4">
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnConfirmIssued_IssueCon" title="btnConfirmIssued_IssueCon" onserverclick="btnConfirmIssued_IssueCon_ServerClick">Confirm Issued</button>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnRejectConfirm_IssueCon" title="btnRejectConfirm_IssueCon" onserverclick="btnRejectConfirm_IssueCon_ServerClick">Reject Confirm</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </fieldset>
                                            </div>

                                        </div>
                                        <!-- right column -->

                                        <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>
                                    </div>
                                    <!-- /.post -->
                                </fieldset>
                            </div>
                            <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End Issue Condition-------------------------------------------------------%>



                            <%--------------------------------------------------------------Start Confirm Issue----------------------------------------------------------%>
                            <!-------- Export Goods --------->
                            <div class="tab-pane" id="confirmissue">
                                <fieldset runat="server" id="confirmissue_fieldset">
                                    <!-- Post -->
                                    <div class="row">

                                        <%-----------------------------------------------------Start HEAD BEFORE LEFT FORM-----------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-md-4 col-sm-4">
                                                        <div class="form-group">
                                                            <label for="txtWHSite_ConfirmIssue" class="col-sm-4 control-label">WH Site:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlWHSite_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCusLOTNo_ConfirmIssue" class="col-sm-4 control-label">Cus LOT No:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCusLOTNo_ConfirmIssue" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtEASPN_ConfirmIssue" class="col-sm-4 control-label">EAS P/N:</label>
                                                            <div class="col-sm-5">
                                                                <input class="form-control" id="txtEASPN_ConfirmIssue" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <button type="button" class="btn btn-block btn-primary" runat="server" id="btnEASPN_ConfirmIssue" onserverclick="btnEASPN_ConfirmIssue_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtProductDesc_ConfirmIssue" class="col-sm-4 control-label">Product Desc:</label>
                                                            <div class="col-sm-8">
                                                                <textarea class="form-control" rows="3" runat="server" id="txtProductDesc_ConfirmIssue" placeholder="Desc .." style="height: 34px; width: 552px;"></textarea>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtWHLocation_ConfirmIssue" class="col-sm-4 control-label">WH Location:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlWHLocation_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustWHFac_ConfirmIssue" class="col-sm-4 control-label">Cust W/H Fac:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlCustWHFac_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerPN_ConfirmIssue" class="col-sm-4 control-label">CustomerP/N:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCustomerPN_ConfirmIssue" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtENDCustomer_ConfirmIssue" class="col-sm-4 control-label">ENDCustomer:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtENDCustomer_ConfirmIssue" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtItemNo_ConfirmIssue" class="col-sm-4 control-label">Item No:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtItemNo_ConfirmIssue" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtOwnerPN_ConfirmIssue" class="col-sm-4 control-label">Owner P/N:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtOwnerPN_ConfirmIssue" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtMeasurement_ConfirmIssue" class="col-sm-4 control-label">Measurement:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlMeasurement_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->

                                        </div>
                                        <%-------------------------------------------------------End HEAD BEFORE LEFT FORM----------------------------------------------------------------%>

                                        <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                                        <div class="col-md-6">
                                            <!-- Horizontal Form -->

                                            <!-- form start -->
                                            <!-- general form Commodity -->
                                            <div class="form-horizontal">
                                                <%--<fieldset><legend>Owner</legend>--%>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtSpace_ConfirmIssue" class="col-sm-4 control-label"></label>
                                                        <label for="txtWidth_ConfirmIssue" class="col-sm-4 control-label">Width:</label>
                                                        <label for="txtHight_ConfirmIssue" class="col-sm-4 control-label">Hight:</label>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtDimension_ConfirmIssue" class="col-sm-4 control-label">Dimension:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtWidth_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtHight_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtOrderNo_ConfirmIssue" class="col-sm-4 control-label">Order No:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control" id="txtOrderNo_ConfirmIssue" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtReceiveNo_ConfirmIssue" class="col-sm-4 control-label">Receive No:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control" id="txtReceiveNo_ConfirmIssue" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" runat="server" id="chkNotUseDate_ConfirmIssue" />Not Use Date
                                                                </label>
                                                            </div>
                                                        </div>
                                                        <label for="txtManufacturing_ConfirmIssue" class="col-sm-4 control-label">Manufacturing:</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox CssClass="form-control" ID="txtdatepickerManufacturing_ConfirmIssue" runat="server" placeholder="DD/MM/YYYY">
                                                            </asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderManufacturing_ConfirmIssue" runat="server" Enabled="True" TargetControlID="txtdatepickerManufacturing_ConfirmIssue" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtReceiveDate_ConfirmIssue" class="col-sm-4 control-label">Receive Date:</label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox CssClass="form-control" ID="txtdatepickerReceiveDate_ConfirmIssue" runat="server" placeholder="DD/MM/YYYY">
                                                            </asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderReceiveDate_ConfirmIssue" runat="server" Enabled="True" TargetControlID="txtdatepickerReceiveDate_ConfirmIssue" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtQuantity_ConfirmIssue" class="col-sm-4 control-label">Quantity:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtQuantity_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlQuantity_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtCurrency_ConfirmIssue" class="col-sm-4 control-label">Currency:</label>
                                                        <label for="txtPriceForeign_ConfirmIssue" class="col-sm-4 control-label">Price Foreign:</label>
                                                        <label for="txtPriceBath_ConfirmIssue" class="col-sm-4 control-label">Price Bath:</label>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlCurrency_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtPriceForeign_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtPriceBath_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.box-body -->
                                                <%--</fieldset>--%>
                                            </div>
                                        </div>
                                        <!--/.col (left) -->
                                        <%---------------------------------------------------------------End Left Form------------------------------------------------%>



                                        <%------------------------------------------------------------Start Right Form------------------------------------------------%>
                                        <div class="col-md-6">
                                            <!-- Horizontal Form -->
                                            <!-- form start -->
                                            <!-- general form Commodity -->
                                            <div class="form-horizontal">
                                                <%--<fieldset><legend>Customer</legend>--%>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtLength_ConfirmIssue" class="col-sm-4 control-label">Length:</label>
                                                        <label for="txtProductVolume_ConfirmIssue" class="col-sm-4 control-label">Product Volume:</label>
                                                        <label for="txtPalletNo_ConfirmIssue" class="col-sm-4 control-label">Pallet No:</label>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtLength_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtProductVolume_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtPalletNo_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtStatus_ConfirmIssue" class="col-sm-4 control-label">Status:</label>
                                                        <div class="col-sm-8">
                                                            <asp:DropDownList ID="ddlStatus_ConfirmIssue" CssClass="form-control" runat="server">
                                                                <asp:ListItem>Goods Complete</asp:ListItem>
                                                                <asp:ListItem>Goods Damage</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtType_ConfirmIssue" class="col-sm-4 control-label">Type:</label>
                                                        <div class="col-sm-8">
                                                            <asp:DropDownList ID="ddlType_ConfirmIssue" CssClass="form-control" runat="server">
                                                                <asp:ListItem>Q-FFL</asp:ListItem>
                                                                <asp:ListItem>Q-CON</asp:ListItem>
                                                                <asp:ListItem>Q-SC</asp:ListItem>
                                                                <asp:ListItem>Q-SCRAP</asp:ListItem>
                                                                <asp:ListItem>BackFill</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtExpiredDate_ConfirmIssue" class="col-sm-4 control-label">Expired Date:</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox CssClass="form-control" ID="txtdatepickerExpiredDate_ConfirmIssue" runat="server" placeholder="DD/MM/YYYY">
                                                            </asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderExpiredDate_ConfirmIssue" runat="server" Enabled="True" TargetControlID="txtdatepickerExpiredDate_ConfirmIssue" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtPONo_ConfirmIssue" class="col-sm-4 control-label">PO No:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtPONo_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtWeight_ConfirmIssue" class="col-sm-4 control-label">Weight:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtWeight_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlWeight_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtExchangeRate_ConfirmIssue" class="col-sm-4 control-label">ExchangeRate:</label>
                                                        <label for="txtAmount_ConfirmIssue" class="col-sm-4 control-label">Amount:</label>
                                                        <label for="txtBathAmount_ConfirmIssue" class="col-sm-4 control-label">Bath Amount:</label>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtExchangeRate_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtAmount_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control" id="txtBathAmount_ConfirmIssue" runat="server" value="0" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.box-body -->
                                                <%--</fieldset>--%>
                                            </div>
                                        </div>
                                        <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

                                        <%-----------------------------------------------------Start AFTER RIGHT FORM------------------------------------------------------------%>

                                        <%-----------------------------------------------------Start Tabel1 FORM------------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-sm-12">
                                                        <%--------------------------------------Data Picking Detail Repeater---------------------------------%>
                                                        <asp:Panel ID="DataPickingDetailPanel" runat="server" >
                                                    <asp:UpdatePanel ID="DataPickingDetailUpdatePanel" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Repeater ID="Repeater8" runat="server" OnItemCommand="Repeater8_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table id="example8" class="table table-bordered table-striped">
                                                                    <thead>
                                                                        <tr>
                                                                            <th style="width: 8px"><asp:CheckBox ID="chkAll" runat="server" Checked="false"/></th>
                                                                            <th>PullSignal</th>
                                                                            <th>LOTNo</th>
                                                                            <th>ItemNo</th>
                                                                            <th>WHSite</th>
                                                                            <th>ENDCustomer</th>
                                                                            <th>CustomerLOTNo</th>
                                                                            <th>ProductCode</th>
                                                                        </tr>
                                                                    </thead>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <%--<td class="text-center">
                                                                        <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="Selectdatapickigdetail" CommandArgument='<%# Eval("ItemNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                                    </td>--%>
                                                                    <td><asp:CheckBox ID="chkRowData" runat="server" /></td>
                                                                    <td>
                                                                        <asp:Label ID="lblPullSignal" runat="server" Text='<%# Bind("PullSignal")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblLOTNo" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblItemNo" runat="server" Text='<%# Bind("ItemNo")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblWHSite" runat="server" Text='<%# Bind("WHSite")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblENDCustomer" runat="server" Text='<%# Bind("ENDCustomer")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCustomerLOTNo" runat="server" Text='<%# Bind("CustomerLOTNo")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblProductCode" runat="server" Text='<%# Bind("ProductCode")%>'></asp:Label></td>
                                                                </tr>

                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <tfoot>
                                                                    <tr>
                                                                        <th style="width: 8px"><asp:CheckBox ID="chkAll" runat="server" Checked="false"/></th>
                                                                        <th>PullSignal</th>
                                                                        <th>LOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>WHSite</th>
                                                                        <th>ENDCustomer</th>
                                                                        <th>CustomerLOTNo</th>
                                                                        <th>ProductCode</th>
                                                                    </tr>
                                                                </tfoot>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                        </ContentTemplate>
                                                </asp:UpdatePanel>
                                                </asp:Panel>
                                                        <%--------------------------------------Data Picking Detail Repeater---------------------------------%>
                                                    </div>

                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->

                                        </div>
                                        <%-------------------------------------------------------End Tabel1 FORM----------------------------------------------------------------%>




                                        <%-------------------------------------------------------End AFTER RIGHT FORM----------------------------------------------------------------%>

                                        <%-----------------------------------------------------Start BUTTON FORM------------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <div class="col-sm-3">
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnSelectAll_ConfirmIssue" title="btnSelectAll_ConfirmIssue">Select All</button>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnCencelSelectAll_ConfirmIssue" title="btnCencelSelectAll_ConfirmIssue">Cencel Select All</button>
                                                            </div>
                                                            <label for="txtReceiveDate_Button_ConfirmIssue" class="col-sm-3 control-label">Receive Date:</label>
                                                            <div class="col-sm-3">
                                                                <asp:TextBox CssClass="form-control" ID="txtdatepickerReceiveDate_Button_ConfirmIssue" runat="server" placeholder="DD/MM/YYYY">
                                                                </asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtenderReceiveDate_Button_ConfirmIssue" runat="server" Enabled="True" TargetControlID="txtdatepickerReceiveDate_Button_ConfirmIssue" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <label for="txtWHLocation_ConfirmIssue" class="col-sm-4 control-label">WH Location:</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control" id="txtWHLocation_ConfirmIssue" runat="server" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnIssue_ConfirmIssue" onserverclick="btnIssue_ConfirmIssue_ServerClick" title="btnIssue_ConfirmIssue">Issue</button>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->

                                        </div>
                                        <%-------------------------------------------------------End BUTTON FORM----------------------------------------------------------------%>

                                        <%-----------------------------------------------------Start Tabel2 FORM------------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-sm-12">
                                                        <%--------------------------------------Data Issued Detail Repeater---------------------------------%>
                                                        <asp:Panel ID="DataIssuedDetailPanel" runat="server" >
                                                    <asp:UpdatePanel ID="DataIssuedDetailUpdatePanel" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Repeater ID="Repeater9" runat="server" OnItemCommand="Repeater9_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table id="example9" class="table table-bordered table-striped">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>Select</th>
                                                                            <th>PullSignal</th>
                                                                            <th>LOTNo</th>
                                                                            <th>ItemNo</th>
                                                                            <th>WHSite</th>
                                                                            <th>WHLocation</th>
                                                                            <th>ENDCustomer</th>
                                                                            <th>CustomerLOTNo</th>
                                                                        </tr>
                                                                    </thead>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td class="text-center">
                                                                        <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="Selectdataissueddetail" CommandArgument='<%# Eval("ItemNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PullSignal")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ItemNo")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("WHSite")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("WHLocation")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ENDCustomer")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("CustomerLOTNo")%>'></asp:Label></td>
                                                                </tr>

                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <tfoot>
                                                                    <tr>
                                                                        <th>Select</th>
                                                                        <th>PullSignal</th>
                                                                        <th>LOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>WHSite</th>
                                                                        <th>WHLocation</th>
                                                                        <th>ENDCustomer</th>
                                                                        <th>CustomerLOTNo</th>
                                                                    </tr>
                                                                </tfoot>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                        </ContentTemplate>
                                                </asp:UpdatePanel>
                                                </asp:Panel>
                                                        <%--------------------------------------Data Issued Detail Repeater---------------------------------%>
                                                    </div>

                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->

                                        </div>
                                        <%-------------------------------------------------------End Tabel2 FORM----------------------------------------------------------------%>

                                    </div>
                                    <!-- right column -->
                                    <!-- /.post -->
                                </fieldset>
                            </div>
                            <!-----/ Export Goods----->

                            <%--------------------------------------------------------------END Good Receive Detail----------------------------------------------------------%>
                        </div>
                        <!-- /.tab-pane -->
                    </div>
                    <!-- /.tab-pane -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </section>
        <!-- /.content -->

        <!-- Exporter Modal -->
        <!-- Modal -->
        <asp:Panel ID="ExporterPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Exporter Code</h4>
                    </div>
                    <asp:UpdatePanel ID="ExporterUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example1" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>Select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyAddress</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton3" CssClass="btn bg-navy" runat="server" OnClick="clickexporter_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress1" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress2" runat="server" Text="Label"></asp:Label></td>

                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Select</th>
                                                            <th>PartyCode</th>
                                                            <th>PartyAddress</th>
                                                            <th>PartyFullName</th>
                                                            <th>Address1</th>
                                                            <th>Address2</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <!-- End Exporter Modal -->

        <!-- Owner Modal -->
        <!-- Modal -->
        <asp:Panel ID="OwnerPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Owner Code</h4>
                    </div>
                    <asp:UpdatePanel ID="OwnerUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example2" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>Select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyAddress</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton3" CssClass="btn bg-navy" runat="server" OnClick="clickowner_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress1" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress2" runat="server" Text="Label"></asp:Label></td>

                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Select</th>
                                                            <th>PartyCode</th>
                                                            <th>PartyAddress</th>
                                                            <th>PartyFullName</th>
                                                            <th>Address1</th>
                                                            <th>Address2</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <!-- End Owner Modal -->

        <!--Start Consignee Modal -->
        <asp:Panel ID="ConsigneePanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Consignee Code</h4>
                    </div>
                    <asp:UpdatePanel ID="ConsigneeUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater3" runat="server" OnItemDataBound="Repeater3_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example3" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>Select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyAddress</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" OnClick="clickconsignee_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress1" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress2" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Select</th>
                                                            <th>PartyCode</th>
                                                            <th>PartyAddress</th>
                                                            <th>PartyFullName</th>
                                                            <th>Address1</th>
                                                            <th>Address2</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <!-- End Consignee Modal -->

        <!--Start ShipTo Modal -->
        <asp:Panel ID="ShipToPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Ship To Code</h4>
                    </div>
                    <asp:UpdatePanel ID="ShipToUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater4" runat="server" OnItemDataBound="Repeater4_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example4" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>Select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyAddress</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" OnClick="clickshipto_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress1" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress2" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Select</th>
                                                            <th>PartyCode</th>
                                                            <th>PartyAddress</th>
                                                            <th>PartyFullName</th>
                                                            <th>Address1</th>
                                                            <th>Address2</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <!-- End ShipTo Modal -->

        <!--Start ProductCode Modal -->
        <!-- Modal -->
        <asp:Panel ID="ProductCodePanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Product Code</h4>
                    </div>
                    <asp:UpdatePanel ID="ProductCodeUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater5" runat="server" OnItemCommand="Repeater5_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example5" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>Select</th>
                                                                <th>ProductCode</th>
                                                                <th>ImpDesc1</th>
                                                                <th>PONo</th>
                                                                <th>CustomerPart</th>
                                                                <th>EndUserPart</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectProductCode" CommandArgument='<%# Eval("ProductCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("ProductCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("ImpDesc1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("PONo")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("CustomerPart")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("EndUserPart")%>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Select</th>
                                                            <th>ProductCode</th>
                                                            <th>ImpDesc1</th>
                                                            <th>PONo</th>
                                                            <th>CustomerPart</th>
                                                            <th>EndUserPart</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <!-- End ProductCode Modal -->

        <!--Start JobNoAdd Modal -->
        <!-- Modal -->
        <asp:Panel ID="JobNoAddPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Job No</h4>
                    </div>
                    <asp:UpdatePanel ID="JobNoAddUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater6" runat="server" OnItemCommand="Repeater6_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example6" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>Select</th>
                                                                <th>LOTNo</th>
                                                                <th>PullSignal</th>
                                                                <th>PullDate</th>
                                                                <th>PullTime</th>
                                                                <th>DeliveryDate</th>                                                                
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="Selectjobnoadd" CommandArgument='<%# Eval("LOTNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PullSignal")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("PullDate")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("PullTime")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("DeliveryDate")%>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Select</th>
                                                            <th>LOTNo</th>
                                                            <th>PullSignal</th>
                                                            <th>PullDate</th>
                                                            <th>PullTime</th>
                                                            <th>DeliveryDate</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <!-- End JobNoAdd Modal -->

        <!--Start JobNoEdit Modal -->
        <!-- Modal -->
        <asp:Panel ID="JobNoEditPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Job No</h4>
                    </div>
                    <asp:UpdatePanel ID="JobNoEditUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater7" runat="server" OnItemCommand="Repeater7_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example7" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>Select</th>
                                                                <th>LOTNo</th>
                                                                <th>PullSignal</th>
                                                                <th>PullDate</th>
                                                                <th>PullTime</th>
                                                                <th>DeliveryDate</th>                                                                
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="Selectjobnoedit" CommandArgument='<%# Eval("LOTNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PullSignal")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("PullDate")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("PullTime")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("DeliveryDate")%>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Select</th>
                                                            <th>LOTNo</th>
                                                            <th>PullSignal</th>
                                                            <th>PullDate</th>
                                                            <th>PullTime</th>
                                                            <th>DeliveryDate</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <!-- End JobNoEdit Modal -->



        <script>
            $(document).ready(function () {
                // CHECK-UNCHECK ALL CHECKBOXES IN THE REPEATER 
                // WHEN USER CLICKS THE HEADER CHECKBOX.
                $('table [id*=chkAll]').click(function () {
                    if ($(this).is(':checked'))
                        $('table [id*=chkRowData]').prop('checked', true)
                    else
                        $('table [id*=chkRowData]').prop('checked', false)
                });

                // NOW CHECK THE HEADER CHECKBOX, IF ALL THE ROW CHECKBOXES ARE CHECKED.
                $('table [id*=chkRowData]').click(function () {

                    var total_rows = $('table [id*=chkRowData]').length;
                    var checked_Rows = $('table [id*=chkRowData]:checked').length;

                    if (checked_Rows == total_rows)
                        $('table [id*=chkAll]').prop('checked', true);
                    else
                        $('table [id*=chkAll]').prop('checked', false);
                });
            });
</script>

    </form>
</asp:Content>
