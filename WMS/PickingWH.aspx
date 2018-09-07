<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PickingWH.aspx.vb" Inherits="WMS.PickingWH" MasterPageFile="~/Home.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Picking
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>WareHouse</a></li>
                <li><a href="PickingWH.aspx" class="active">Picking</a></li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
<<<<<<< HEAD
            <div class="row">
                <!-- left column -->
                <div class="col-xs-12">

                    <div class="box box-default">
                        <div class="box-header with-border">
                            <h3 class="box-title">Modal Examples</h3>
                        </div>
                        <div class="box-body">
                            <div class="col-md-6">
                                <button type="button" class="btn btn-info" runat="server" id="btnAddNew" onserverclick="btnAddNew_ServerClick">
                                    <i class="fa fa-plus-square"></i>
                                    Add
                                </button>
                                <button type="button" class="btn btn-danger" runat="server" id="btnEdit" onserverclick="btnEdit_ServerClick">
                                    <i class="fa fa-edit"></i>
                                    Edit
                                </button>
                            </div>
                            <div class="col-md-6">
                                <div class="text-right">
                                    <button type="button" class=" btn btn-app" runat="server" id="btnSaveNew" onserverclick="btnSaveNew_ServerClick">
                                        <i class="fa fa-save"></i>
                                        Save
                                    </button>
                                    <button type="button" class=" btn btn-app" runat="server" id="btnSaveEdit" onserverclick="btnSaveEdit_ServerClick">
                                        <i class="fa fa-edit"></i>
                                        Edit
                                    </button>
                                </div>
                            </div>

                            <!-- /.col -->
                            <div class="col-md-12 col-lg-12 col-sm-12">
                                <fieldset>
                                    <legend></legend>
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtPullSignal">Pull Signal:</label>
                                                <input class="form-control input-sm" id="txtPullSignal_BeforeTab" runat="server" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtJobNo">Job No:</label>
                                                <input class="form-control input-sm" id="txtJobNo_BeforeTab" runat="server" autocomplete="off" />

                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <div style="padding: 12px">

                                            </div>
                                            <button runat="server" class="btn btn-primary btn-sm" type="button"  id="btnSeletJobNew"><i class="fa fa-search"></i></button>
                                            <button runat="server" class="btn  btn-danger btn-sm" type="button"  id="btnSelectJobEdit"><i class="fa fa-search"></i></button>
                                        </div>
                                        <div class="col-sm-1">
                                            <div class="form-group">
                                                <label>SCRAP</label>
                                                <div class="checkbox">
                                                    <label style="padding-right:10px"> 
                                                        <input type="checkbox" runat="server" id="chkScrap" />
                                                    </label>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="txtPullDateTime">Pull Date</label>

                                                <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickertxtPullDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderPullDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickertxtPullDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Time</label>
                                            <div class="bootstrap-timepicker">
                                                <div class="input-group">
                                                    <input type="text" class="form-control timepicker input-sm" id="txtTimePickUpPullDateTime" />
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-clock-o"></i>
                                                    </div>
                                                </div>
                                                <!-- /.input group -->
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtDeliveryDateTime">Delivery Date</label>
                                                <asp:TextBox CssClass="form-control" ID="txtdatepickerDeliveryDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderDeliveryDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerDeliveryDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <label for="txtDeliveryDateTime">Time</label>
                                                <div class="bootstrap-timepicker">
                                                    <div class="input-group">
                                                        <input type="text" class="form-control timepicker" id="txtTimePickUpDeliveryDateTime" />
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-clock-o"></i>
                                                        </div>
                                                    </div>
                                                    <!-- /.input group -->
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtConfirmDateTime">Confirm Date</label>
                                                <asp:TextBox CssClass="form-control" ID="txtdatepickerComfirmDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderComfirmDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerComfirmDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>

                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <label for="txtConfirmDateTime">Time</label>
                                                <div class="bootstrap-timepicker">
                                                    <div class="input-group">
                                                        <input type="text" class="form-control timepicker" id="txtTimePickUpConfirmDateTime" />
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-clock-o"></i>
                                                        </div>
                                                    </div>
                                                    <!-- /.input group -->
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </fieldset>
                            </div>

                        </div>
                    </div>
                </div>
            </div>


=======

            <div class="row">
                <div class="col-xs-12">
                    <div class="box box-default">
                        <div class="box-body">
                            <div class="col-xs-6">
                                <button class="btn btn-app btn-sm" id="btnAddHead" runat="server" onserverclick="btnAddHead_ServerClick"><i class="fa fa-inbox"></i>Add</button>
                                <button class="btn btn-app btn-sm" id="btnEditHead" runat="server" onserverclick="btnEditHead_ServerClick"><i class="fa fa-edit"></i>Edit</button>
                            </div>
                            <div class="col-xs-6 text-right">
                                <button class="btn btn-app btn-sm" id="btnSaveAddHead" runat="server" onserverclick="btnSaveAddHead_ServerClick" visible="false"><i class="fa fa-save"></i>Save Add</button>
                                <button class="btn btn-app btn-sm" id="btnSaveEditHead" runat="server" onserverclick="btnSaveEditHead_ServerClick" visible="false"><i class="fa fa-save"></i>Save Edit</button>
                            </div>

                            <%-------------------------------------------------Start Before Custom Tab---------------------------------------------------%>
                            <%--<div class="col-md-12">
                                <fieldset runat="server" id="beforecustomtab_fieldset">
                                    <h2></h2>
                                    <div class="col-sm-6">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <label for="txtPullSignal" class="col-sm-3 control-label">Pull Signal:</label>
                                                <div class="col-sm-3">
                                                    <input class="form-control input-sm" id="txtPullSignal_BeforeTab" runat="server" autocomplete="off" />
                                                </div>
                                                <label for="txtJobNo" class="col-sm-3 control-label">Job No:</label>
                                                <div class="col-sm-3">
                                                    <input class="form-control input-sm" id="txtJobNo_BeforeTab" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-sm-2">
                                                    <div class="checkbox">
                                                        <label>
                                                            <input type="checkbox" runat="server" id="chkScrap" />SCRAP
                                                        </label>
                                                    </div>
                                                </div>
                                                <label for="txtPullDateTime" class="col-sm-3 control-label">Pull Date/Time:</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickertxtPullDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                                    </asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtenderPullDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickertxtPullDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                </div>

                                                <div class="col-sm-3">
                                                    <div class="bootstrap-timepicker">
                                                        <div class="input-group">
                                                            <input type="text" class="form-control timepicker" id="txtTimePickUpPullDateTime" />
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
                                                    <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerDeliveryDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                                    </asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtenderDeliveryDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerDeliveryDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="bootstrap-timepicker">
                                                        <div class="input-group">
                                                            <input type="text" class="form-control timepicker" id="txtTimePickUpDeliveryDateTime" />
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
                                                    <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerComfirmDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                                    </asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtenderComfirmDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerComfirmDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="bootstrap-timepicker">
                                                        <div class="input-group">
                                                            <input type="text" class="form-control timepicker" id="txtTimePickUpConfirmDateTime" />
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
                            </div>--%>
                            <%------------------------------------------------End Before Custom Tab---------------------------------------------------%>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row">


                <!-- left column -->

                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#pickinghead" data-toggle="tab">Picking Head</a></li>
                            <li><a href="#importfiles" data-toggle="tab">Import Files</a></li>
                            <li><a href="#assigndetailofpullsignal" data-toggle="tab">Assign Detail Of Pull Signal</a></li>
                            <li><a href="#pickpack" data-toggle="tab">Pick/Pack</a></li>
                            <li><a href="#picknjr" data-toggle="tab">Pick NJR</a></li>
                            <li><a href="#pickautopallet" data-toggle="tab">Piack Auto Pallet</a></li>
                        </ul>

                        <div class="tab-content">


                            <%-----------------------------------------------------Start Picking Head-----------------------------------------------------------%>
                            <!------- Import Goods ------->
                            <div class="active tab-pane" role="tabpanel" id="pickinghead">
                                <fieldset runat="server" id="pickinghead_fieldset">
                                    <!-- Post -->
                                    <div class="row">
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
                                                            <label for="txtExporterCode_PickingHead" class="col-sm-4 control-label">Exporter Code:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlExporterCode_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameExporter_PickingHead" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtNameExporter_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1Exporter_PickingHead" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress1Exporter_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2Exporter_PickingHead" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress2Exporter_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3Exporter_PickingHead" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress3Exporter_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4Exporter_PickingHead" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress4Exporter_PickingHead" runat="server" autocomplete="off" />
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
                                                            <label for="txtOwnerCode_PickingHead" class="col-sm-4 control-label">Owner Code:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlOwnerCode_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameOwner_PickingHead" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtNameOwner_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1Owner_PickingHead" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress1Owner_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2Owner_PickingHead" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress2Owner_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3Owner_PickingHead" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress3Owner_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4Owner_PickingHead" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress4Owner_PickingHead" runat="server" autocomplete="off" />
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
                                                            <label for="txtCommodity_PickingHead" class="col-sm-4 control-label">Commodity:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlCommodity_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityPackage_PickingHead" class="col-sm-5 control-label">Quantity Package:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control input-sm" id="txtQuantityPackage_PickingHead" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlQuantityPackage_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityPLTSkid_PickingHead" class="col-sm-5 control-label">Quantity PLT/Skid:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control input-sm" id="txtQuantityPLTSkid_PickingHead" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlQuantityPLTSkid_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityPicked_PickingHead" class="col-sm-5 control-label">Quantity Picked:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control input-sm" id="txttxtQuantityPicked_PickingHead" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlQuantityPicked_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRemark_PickingHead" class="col-sm-4 control-label">Remark:</label>
                                                            <div class="col-sm-8">
                                                                <textarea class="form-control input-sm" rows="3" runat="server" id="txtRemark_PickingHead" placeholder="Remark" style="height: 71px; width: 872px;" autocomplete="off"></textarea>
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
                                                            <label for="txtConsigneeCode_PickingHead" class="col-sm-4 control-label">Consignee Code:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="txtConsigneeCode_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameConsignee_PickingHead" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtNameConsignee_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1Consignee_PickingHead" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress1Consignee_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2Consignee_PickingHead" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress2Consignee_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3Consignee_PickingHead" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress3Consignee_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4Consignee_PickingHead" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress4Consignee_PickingHead" runat="server" autocomplete="off" />
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
                                                            <label for="txtShipToCode_PickingHead" class="col-sm-4 control-label">Ship To Code:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlShipToCode_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameShipTo_PickingHead" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtNameShipTo_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1ShipTo_PickingHead" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress1ShipTo_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2ShipTo_PickingHead" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress2ShipTo_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3ShipTo_PickingHead" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress3ShipTo_PickingHead" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4ShipTo_PickingHead" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtAddress4ShipTo_PickingHead" runat="server" autocomplete="off" />
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
                                                            <label for="txtQuantityOfGood_PickingHead" class="col-sm-5 control-label">Quantity Of Goods:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control input-sm" id="txtQuantityOfGood_PickingHead" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlQuantityOfGood_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtWeight_PickingHead" class="col-sm-5 control-label">Weight:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control input-sm" id="txtWeight_PickingHead" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlWeight_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtVolume_PickingHead" class="col-sm-5 control-label">Volume:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control input-sm" id="txtVolume_PickingHead" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="DropDownList1" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQTYDiscrepancy_PickingHead" class="col-sm-5 control-label">QTY Discrepancy:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control input-sm" id="txtQTYDiscrepancy_PickingHead" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlQTYDiscrepancy_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
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
                            <%-------------------------------------------------------------End Picking Head-------------------------------------------------------%>


                            <%--------------------------------------------------------Start Import Files TAB------------------------------------------------------%>

                            <div class="tab-pane" role="tabpanel" id="importfiles">
                                <fieldset runat="server" id="importfiles_fieldset">
                                    <!-- Post -->
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12">

                                            <div class="form-horizontal">
                                                <div class="box-body">
                                                    <fieldset class="col-md-12">
                                                        <legend>Import File SEQ</legend>
                                                        <div class="col-lg-12 col-md-12">
                                                            <div class="form-group">
                                                                <label for="txtSelectFileForImport_SEQ_ImportFiles" class="col-sm-4 control-label">Select File For Import:</label>
                                                                <div class="col-sm-4">
                                                                    <input type="file" class="form-control input-sm" id="txtSelectFileForImport_SEQ_ImportFiles" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                            </div>

                                            <div class="form-horizontal">
                                                <div class="box-body">
                                                    <fieldset class="col-md-12">
                                                        <legend>Import File Detail</legend>
                                                        <div class="col-lg-12 col-md-12">
                                                            <div class="form-group">
                                                                <label for="txtSelectFileForImport_Detail_ImportFiles" class="col-sm-4 control-label">Select File For Import:</label>
                                                                <div class="col-sm-4">
                                                                    <input type="file" class="form-control input-sm" id="txtSelectFileForImport_Detail_ImportFiles" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                            </div>

                                            <div class="form-horizontal">
                                                <div class="box-body">
                                                    <fieldset class="col-md-12">
                                                        <legend>Import File Shipment</legend>
                                                        <div class="col-lg-12 col-md-12">
                                                            <div class="form-group">
                                                                <label for="txtSelectFileForImport_Shipment_ImportFiles" class="col-sm-4 control-label">Select File For Import:</label>
                                                                <div class="col-sm-4">
                                                                    <input type="file" class="form-control input-sm" id="txtSelectFileForImport_Shipment_ImportFiles" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-4 col-sm-offset-6">
                                                                    <button type="submit" runat="server" class="btn btn-success btn-sm" id="btnImport3NJRC_ImportFiles" title="btnImport3NJRC_ImportFiles">Import 3 NJRC</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                            </div>

                                            <div class="form-horizontal">
                                                <div class="box-body">
                                                    <fieldset class="col-md-12">
                                                        <legend>Import New File NJRC</legend>
                                                        <div class="col-lg-12 col-md-12">
                                                            <div class="form-group">
                                                                <label for="txtSelectFileForImport_NewFileNJRC_ImportFiles" class="col-sm-4 control-label">Select File For Import:</label>
                                                                <div class="col-sm-4">
                                                                    <input type="file" class="form-control input-sm" id="txtSelectFileForImport_NewFileNJRC_ImportFiles" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-4 col-sm-offset-6">
                                                                    <button type="submit" runat="server" class="btn btn-success btn-sm" id="btnImport1NJRC_ImportFiles" title="btnImport1NJRC_ImportFiles">Import 1 NJRC</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                            </div>

                                            <div class="form-horizontal">
                                                <div class="box-body">
                                                    <fieldset class="col-md-12">
                                                        <legend>Import File Pallet</legend>
                                                        <div class="col-lg-12 col-md-12">
                                                            <div class="form-group">
                                                                <label for="txtSelectFileForImport_Pallet_ImportFiles" class="col-sm-4 control-label">Select File For Import:</label>
                                                                <div class="col-sm-4">
                                                                    <input type="file" class="form-control input-sm" id="txtSelectFileForImport_Pallet_ImportFiles" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-4 col-sm-offset-6">
                                                                    <button type="submit" runat="server" class="btn btn-success btn-sm" id="btnImportPallet_ImportFiles" title="btnImportPallet_ImportFiles">Import Pallet</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <!-- /.post -->
                                </fieldset>
                            </div>
                            <%-----------------------------------------------------End Import Files TAB------------------------------------------------------%>




                            <%----------------------------------------------------Start Assign Detail Of Pull Signal TAB---------------------------------------------------------%>
                            <!-------- Export Goods --------->
                            <div class="tab-pane" role="tabpanel" id="assigndetailofpullsignal">
                                <fieldset runat="server" id="assigndetailofpullsignal_fieldset">
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
                                                            <label for="txtItemNo_AssignDetail" class="col-sm-4 control-label">Item No:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtItemNo_AssignDetail" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtOwnerPN_AssignDetail" class="col-sm-4 control-label">Owner P/N:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtOwnerPN_AssignDetail" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRequestedQuantity_AssignDetail" class="col-sm-5 control-label">Request Quantity:</label>
                                                            <div class="col-sm-7">
                                                                <input class="form-control input-sm" id="txtRequestedQuantity_AssignDetail" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerLot_AssignDetail" class="col-sm-5 control-label">Customer LOT:</label>
                                                            <div class="col-sm-7">
                                                                <input class="form-control input-sm" id="txtCustomerLot_AssignDetail" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>


                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtEASPN_AssignDetail" class="col-sm-4 control-label">EAS P/N:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlEASPN_AssignDetail" CssClass="form-control input-sm" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtProductDesc_AssignDetail" class="col-sm-4 control-label">Product Desc:</label>
                                                            <div class="col-sm-8">
                                                                <textarea class="form-control input-sm" rows="3" runat="server" id="txtRemark_ConGoodRec55554" placeholder="Desc.." style="height: 34px; width: 552px;" autocomplete="off"></textarea>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlRequestedQuantity_AssignDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                            <label for="txtOrderNo_AssignDetail" class="col-sm-3 control-label">OrderNo:</label>
                                                            <div class="col-sm-5">
                                                                <input class="form-control input-sm" id="txtOrderNo_AssignDetail" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPriceForeign_AssignDetail" class="col-sm-4 control-label">Price(Foreign):</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtPriceForeign_AssignDetail" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtCustomerPN_AssignDetail" class="col-sm-4 control-label">CustomerP/N:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtCustomerPN_AssignDetail" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group" style="height: 34px;"></div>
                                                        <div class="form-group" style="height: 34px;">
                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rdbIMP" Text="IMP" onclick="EnableDisableTextBox();" GroupName="option1" />
                                                                    </label>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rdbEXP" Text="EXP" onclick="EnableDisableTextBox();" GroupName="option1" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="form-group">
                                                            <label for="txtPriceBath_AssignDetail" class="col-sm-4 control-label">Price(Bath):</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtPriceBath_AssignDetail" runat="server" autocomplete="off" />
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
                                                        <div class="col-sm-4">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" runat="server" id="chkNotUseDate_AssignDetail" />Not Use Date
                                                                </label>
                                                            </div>
                                                        </div>
                                                        <label for="txtManufacturing_AssignDetail" class="col-sm-4 control-label">Manufacturing:</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerManufacturing_AssignDetail" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                                            </asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderManufacturing_AssignDetail" runat="server" Enabled="True" TargetControlID="txtdatepickerManufacturing_AssignDetail" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAvailableQuantity_AssignDetail" class="col-sm-4 control-label">Available Quantity:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAvailableQuantity_AssignDetail" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtOrderFromOnline_AssignDetail" class="col-sm-4 control-label">Order From Online:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtOrderFromOnline_AssignDetail" runat="server" value="0" autocomplete="off" />
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
                                                        <label for="txtExpiredDate_AssignDetail" class="col-sm-4 control-label">Expired Date:</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerExpiredDate_AssignDetail" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                                            </asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderExpiredDate_AssignDetail" runat="server" Enabled="True" TargetControlID="txtdatepickerExpiredDate_AssignDetail" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtPalletNo_AssignDetail" class="col-sm-4 control-label">Pallet No:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtPalletNo_AssignDetail" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtCustomerFromOnline_AssignDetail" class="col-sm-4 control-label">Customer From Online:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtCustomerFromOnline_AssignDetail" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.box-body -->
                                                <%--</fieldset>--%>
                                            </div>
                                        </div>
                                        <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

                                        <%-----------------------------------------------------Start AFTER RIGHT FORM------------------------------------------------------------%>






                                        <%-------------------------------------------------------End AFTER RIGHT FORM----------------------------------------------------------------%>

                                        <%-----------------------------------------------------Start BUTTON FORM------------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-sm-4 col-sm-offset-8">
                                                        <div class="form-group">
                                                            <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnSaveNew_AssignDetail" title="btnSaveNew_AssignDetail">Save New</button>

                                                            <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnSaveModify_AssignDetail" title="btnSaveModify_AssignDetail">Save Modify</button>

                                                            <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnDelete_AssignDetail" title="btnDelete_AssignDetail">Delete</button>

                                                            <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnDeleteAll_AssignDetail" title="btnDeleteAll_AssignDetail">Delete All</button>
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

                                        <%-----------------------------------------------------------Start Import File---------------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12">

                                            <div class="form-horizontal">
                                                <div class="box-body">

                                                    <fieldset class="col-md-12">
                                                        <legend>Import File</legend>
                                                        <div class="col-lg-12 col-md-12">
                                                            <div class="form-group">
                                                                <label for="txtSelectFileForImport_AssignDetail" class="col-sm-4 control-label">Select File For Import:</label>
                                                                <div class="col-sm-4">
                                                                    <input type="file" class="form-control input-sm" id="txtSelectFileForImport_AssignDetail" runat="server" autocomplete="off" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <button type="submit" runat="server" class="btn btn-success btn-sm" id="btnImport_AssignDetail" title="btnImport_AssignDetail">Import</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                            </div>
                                        </div>
                                        <%-------------------------------------------------------------------End Import File ---------------------------------------------------------%>
                                    </div>
                                    <!-- right column -->
                                    <!-- /.post -->
                                </fieldset>
                            </div>
                            <!-----/ Export Goods----->

                            <%-----------------------------------------------------------END Assign Detail Of Pull Signal TAB----------------------------------------------------------%>




                            <%-----------------------------------------------------Start PICK/PACK TAB-----------------------------------------------------------%>
                            <!------- Import Goods ------->
                            <div class="tab-pane" role="tabpanel" id="pickpack">
                                <fieldset runat="server" id="pickpack_fieldset">
                                    <!-- Post -->
                                    <div class="row">
                                        <%-----------------------------------------------------Start JOB Form-----------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->


                                            <%----------------------------------------------------start First repeater----------------------------------------------
                       <div class="form-horizontal">
	                        <div class="box-body">
                            -------data repeater------
	                        </div>
                        </div>    
                       ----------------------------------------------------End First Repeater------------------------------------------------%>

                                            <%----------------------------------------------------Start Input data-----------------------------------------------%>
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-md-4 col-sm-4">
                                                        <div class="form-group " style="height: 34px;">
                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rdbOwner" Text="Owner" onclick="EnableDisableTextBox();" GroupName="option2" />
                                                                    </label>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rdbSpecific" Text="Specific" onclick="EnableDisableTextBox();" GroupName="option2" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerLOT_PickPack" class="col-sm-4 control-label">CustomerLOT:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtCustomerLOT_PickPack" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtOwnerPN_PickPack" class="col-sm-4 control-label">Owner P/N:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtOwnerPN_PickPack" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtWHSite_PickPack" class="col-sm-4 control-label">WH/Site:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlWHSite_PickPack" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtINVNo_PickPack" class="col-sm-4 control-label">INV No:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtINVNo_PickPack" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtENDCustomer_PickPack" class="col-sm-4 control-label">ENDCustomer:</label>
                                                            <div class="col-sm-5">
                                                                <input class="form-control input-sm" id="txtENDCustomer_PickPack" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="checkbox">
                                                                    <label>
                                                                        <input type="checkbox" runat="server" id="chkCustomerLot_PickPack" />CustomerLot
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->
                                            <%----------------------------------------------------End Input Data---------------------------------------------------%>
                                        </div>
                                        <%-------------------------------------------------------End JOB Form----------------------------------------------------------------%>

                                        <%----------------------------------------------------start Second repeater----------------------------------------------
                       <div class="form-horizontal">
	                        <div class="box-body">
                            -------data Second repeater------
	                        </div>
                        </div>    
                       ----------------------------------------------------End Second Repeater--------------------------------------------------%>


                                        <%------------------------------------------------------Start Input/Button Data--------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-md-4 col-sm-4">
                                                        <div class="form-group " style="height: 34px;">
                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rcbFIFO" Text="FIFO" onclick="EnableDisableTextBox();" GroupName="option3" />
                                                                    </label>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rcbLIFO" Text="LIFO" onclick="EnableDisableTextBox();" GroupName="option3" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPalletNo_PickPack" class="col-sm-4 control-label">Pallet No:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtPalletNo_PickPack" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-6">
                                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnSelectAll" title="btnSelectAll" onserverclick="btnSelectAll_ServerClick">Select All</button>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnCancelSelectAll" title="btnCancelSelectAll" onserverclick="btnCancelSelectAll_ServerClick">CancelSelectAll</button>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <%--<label for="txtOwnerPN_PickPack" class="col-sm-4 control-label">Owner P/N:</label>--%>
                                                            <div class="col-sm-6">
                                                                <input class="form-control input-sm" id="txtFIFO_PickPack" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <input class="form-control input-sm" id="txtLIFO_PickPack" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityOfPick_PickPack" class="col-sm-4 control-label">QuantityOfPick:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlQuantityOfPick_PickPack" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtQTYCanPick_PickPack" class="col-sm-4 control-label">QTY Can Pick:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtQTYCanPick_PickPack" runat="server" value="0" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPONo_PickPack" class="col-sm-4 control-label">PO No:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtPONo_PickPack" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-6">
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnPick" title="btnPick" onserverclick="btnPick_ServerClick">Pick</button>

                                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnCancel" title="btnCancel" onserverclick="btnCancel_ServerClick">Cancel</button>
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
                                        <%---------------------------------------------End Input/Button Data----------------------------------------------------%>


                                        <%----------------------------------------------------start Third repeater----------------------------------------------
                       <div class="form-horizontal">
	                        <div class="box-body">
                            -------data Third repeater------
	                        </div>
                        </div>    
                       ----------------------------------------------------End Third Repeater--------------------------------------------------%>
                                    </div>
                                    <!-- /.post -->
                                </fieldset>
                            </div>
                            <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End PICK/PACK TAB-------------------------------------------------------%>



                            <%-----------------------------------------------------Start PICK NJR TAB-----------------------------------------------------------%>
                            <!------- Import Goods ------->
                            <div class="tab-pane" role="tabpanel" id="picknjr">
                                <fieldset runat="server" id="picknjr_fieldset">
                                    <!-- Post -->
                                    <div class="row">
                                        <%-----------------------------------------------------Start JOB Form-----------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->


                                            <%----------------------------------------------------start First repeater----------------------------------------------
                       <div class="form-horizontal">
	                        <div class="box-body">
                            -------data repeater------
	                        </div>
                        </div>    
                       ----------------------------------------------------End First Repeater------------------------------------------------%>

                                            <%----------------------------------------------------Start Input data-----------------------------------------------%>
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-md-4 col-sm-4">
                                                    </div>

                                                    <div class="col-md-4">
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtWHSite_PickNJR" class="col-sm-4 control-label">WH/Site:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlWHSite_PickNJR" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>

                                                    </div>


                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->
                                            <%----------------------------------------------------End Input Data---------------------------------------------------%>
                                        </div>
                                        <%-------------------------------------------------------End JOB Form----------------------------------------------------------------%>

                                        <%----------------------------------------------------start Second repeater----------------------------------------------
                       <div class="form-horizontal">
	                        <div class="box-body">
                            -------data Second repeater------
	                        </div>
                        </div>    
                       ----------------------------------------------------End Second Repeater--------------------------------------------------%>


                                        <%------------------------------------------------------Start Input/Button Data--------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-md-4 col-sm-4">
                                                    </div>

                                                    <div class="col-md-4">

                                                        <div class="form-group">
                                                            <label for="txtQuantityOfPick_PickNJR" class="col-sm-4 control-label">QuantityOfPick:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtQuantityOfPick_PickNJR" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">


                                                        <div class="form-group">
                                                            <div class="col-sm-6">
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnAutoPickNJR" title="btnAutoPickNJR" onserverclick="btnAutoPickNJR_ServerClick">Auto Pick NJR</button>
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
                                        <%---------------------------------------------End Input/Button Data----------------------------------------------------%>


                                        <%----------------------------------------------------start Third repeater----------------------------------------------
                       <div class="form-horizontal">
	                        <div class="box-body">
                            -------data Third repeater------
	                        </div>
                        </div>    
                       ----------------------------------------------------End Third Repeater--------------------------------------------------%>
                                    </div>
                                    <!-- /.post -->
                                </fieldset>
                            </div>
                            <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End PICK NJR TAB-------------------------------------------------------%>



                            <%-----------------------------------------------------Start PICK AUTO PALLET TAB-----------------------------------------------------------%>
                            <!------- Import Goods ------->
                            <div class="tab-pane" role="tabpanel" id="pickautopallet">
                                <fieldset runat="server" id="pickautopallet_fieldset">
                                    <!-- Post -->
                                    <div class="row">
                                        <%-----------------------------------------------------Start JOB Form-----------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->


                                            <%----------------------------------------------------start First repeater----------------------------------------------
                       <div class="form-horizontal">
	                        <div class="box-body">
                            -------data repeater------
	                        </div>
                        </div>    
                       ----------------------------------------------------End First Repeater------------------------------------------------%>

                                            <%----------------------------------------------------Start Input data-----------------------------------------------%>
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-md-4 col-sm-4">
                                                    </div>

                                                    <div class="col-md-4">
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtWHSite_PickAutoPallet" class="col-sm-4 control-label">WH/Site:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlWHSite_PickAutoPallet" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>

                                                    </div>


                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->
                                            <%----------------------------------------------------End Input Data---------------------------------------------------%>
                                        </div>
                                        <%-------------------------------------------------------End JOB Form----------------------------------------------------------------%>

                                        <%----------------------------------------------------start Second repeater----------------------------------------------
                       <div class="form-horizontal">
	                        <div class="box-body">
                            -------data Second repeater------
	                        </div>
                        </div>    
                       ----------------------------------------------------End Second Repeater--------------------------------------------------%>


                                        <%------------------------------------------------------Start Input/Button Data--------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-md-4 col-sm-4">
                                                    </div>

                                                    <div class="col-md-4">
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <div class="col-sm-6">
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnAutoPickPallet" title="btnAutoPickPallet" onserverclick="btnAutoPickPallet_ServerClick">Auto Pick Pallet</button>
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
                                        <%---------------------------------------------End Input/Button Data----------------------------------------------------%>
                                    </div>
                                    <!-- /.post -->
                                </fieldset>
                            </div>
                            <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End PICK AUTO PALLET TAB-------------------------------------------------------%>
                        </div>
                        <!-- /.tab-pane -->
                    </div>
                    <!-- /.tab-pane -->
                </div>
                <!-- /.col -->
            </div>
>>>>>>> 46a066c0c7ae1c74ecaeb38ec709ea88273eb732
            <!-- /.row -->
        </section>
        <!-- /.content -->

    </form>
</asp:Content>
