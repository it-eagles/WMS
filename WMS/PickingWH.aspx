    <%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PickingWH.aspx.vb" Inherits="WMS.PickingWH" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true" %>

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
                                <fieldset runat="server" id="picking_">
                                    <legend></legend>
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtPullSignal">Pull Signal:</label>
                                                <input class="form-control input-sm" id="txtPullSignal" runat="server" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtJobNo">Job No:</label>
                                                <input class="form-control input-sm" id="txtLOtNo" runat="server" autocomplete="off" />

                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <div style="padding: 12px">

                                            </div>
                                            <button runat="server" class="btn btn-primary btn-sm" type="button"  id="btnSeletJobNew" onserverclick="btnSeletJobNew_ServerClick"><i class="fa fa-search"></i></button>
                                            <button runat="server" class="btn  btn-danger btn-sm" type="button"  id="btnSelectJobEdit" onserverclick="btnSelectJobEdit_ServerClick" ><i class="fa fa-search"></i></button>
                                        </div>
                                        <div class="col-sm-1">
                                            <div class="form-group">
                                                <label>SCRAP</label>
                                                <div class="checkbox">
                                                    <label style="padding-right:10px"> 
                                                        <input type="checkbox" runat="server" id="chkSCRAP" />
                                                    </label>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="txtPullDateTime">Pull Date</label>

                                                <asp:TextBox CssClass="form-control input-sm" ID="dtpPullDate" runat="server" placeholder="DD/MM/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderPullDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="dtpPullDate" Format="dd/MM/yyyy"></asp:CalendarExtender>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Time</label>
                                            <div class="bootstrap-timepicker">
                                                <div class="input-group">
                                                    <input type="text" class="form-control timepicker input-sm" id="txtPullTime" runat="server"/>
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
                                                <asp:TextBox CssClass="form-control input-sm" ID="dtpDeliveryDate" runat="server" placeholder="DD/MM/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderDeliveryDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="dtpDeliveryDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <label for="txtDeliveryDateTime">Time</label>
                                                <div class="bootstrap-timepicker">
                                                    <div class="input-group">
                                                        <input type="text" class="form-control timepicker input-sm" id="txtDeliveryTime" runat="server"/>
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
                                                <asp:TextBox CssClass="form-control input-sm" ID="dtpConfirmDate" runat="server" placeholder="DD/MM/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderComfirmDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="dtpConfirmDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>

                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <label for="txtConfirmDateTime">Time</label>
                                                <div class="bootstrap-timepicker">
                                                    <div class="input-group">
                                                        <input type="text" class="form-control timepicker input-sm" id="txtComfirmTime" runat="server" />
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
            
            <div class="panel panel-default">
                <div id="Tabs" role="tabpanel" class="nav-tabs-custom">
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li><a href="#pickinghead" aria-controls="pickinghead" role="tab" data-toggle="tab" class="active">Picking Head</a></li>
                        <li><a href="#importfiles" aria-controls="detail" role="tab" data-toggle="tab">Import Files</a></li>
                        <li><a href="#assigndetailofpullsignal" aria-controls="invoice" role="tab" data-toggle="tab">Assign Detail Of Pull Signal</a></li>
                        <li><a href="#pickpack" aria-controls="invoice" role="tab" data-toggle="tab">Pick/Pack</a></li>
                        <li><a href="#picknjr" aria-controls="invoice" role="tab" data-toggle="tab">Pick NJR</a></li>
                        <li><a href="#pickautopallet" aria-controls="invoice" role="tab" data-toggle="tab">Piack Auto Pallet</a></li>
                    </ul>
                    <!-- Tab panes -->
                    <div class="tab-content" style="padding-top: 10px">
                        <div role="tabpanel" class="tab-pane active" id="pickinghead">
                            <div class="post">
                                <div class="row margin-bottom">

                                    <div class="col-lg-12 col-md-8 ">
                                        <!-- form start -->
                                        <div class="form-horizontal">
                                            <div class="box-body">
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
                                                            <div class="col-sm-6">
                                                              <%--  <asp:DropDownList ID="ddlExporterCode" CssClass="form-control input-sm select2" runat="server"></asp:DropDownList>--%>
                                                                <input runat="server" id="txtExporterCode" class="form-control input-sm" autocomplete="off"/>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                 <button type="button" class="btn btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameExporter_PickingHead" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtExportEng" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1Exporter_PickingHead" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtExporterAddress1" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2Exporter_PickingHead" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtExporterAddress2" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3Exporter_PickingHead" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtExporterAddress3" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4Exporter_PickingHead" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtExporterAddress4" runat="server" autocomplete="off" />
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
                                                            <div class="col-sm-6">                                   
                                                                <input runat="server" class="form-control input-sm" id="txtOwnerCode" autocomplete="off"/>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <button type="button" class="btn btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick1"><i class="glyphicon glyphicon-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameOwner_PickingHead" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtOwnerName" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1Owner_PickingHead" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtOwnerAddress1" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2Owner_PickingHead" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtOwnerAddress2" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3Owner_PickingHead" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtOwnerAddress3" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4Owner_PickingHead" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtOwnerAddress4" runat="server" autocomplete="off" />
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
                                                                <asp:DropDownList ID="cboCommodity" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            
                                                            </div>
                                                            
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityPackage_PickingHead" class="col-sm-4 control-label">Quantity Package:</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="txtQuantityPackage" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="dcbQuantityPackage" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityPLTSkid_PickingHead" class="col-sm-4 control-label">Weight</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="txtWeight" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="dcbWeight" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityPicked_PickingHead" class="col-sm-4 control-label">Quantity Picked</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="txtQtyReceived" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="cboReceivedUNIT" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
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
                                                            <div class="col-sm-6">
                                                                <%--<asp:DropDownList ID="txtConsigneeCode_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>--%>
                                                                    <input runat="server" id="txtConsignneeCode" class="form-control input-sm" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <button type="button" class="btn btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick2"><i class="glyphicon glyphicon-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameConsignee_PickingHead" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtConsignneeEng" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1Consignee_PickingHead" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtConsignneeAddress1" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2Consignee_PickingHead" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtConsignneeAddress2" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3Consignee_PickingHead" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtConsignneeAddress3" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4Consignee_PickingHead" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtConsignneeAddress4" runat="server" autocomplete="off" />
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
                                                            <div class="col-sm-6">
                                                                <input runat="server" id="txtShipToCode" class="form-control input-sm" autocomplete="off" />
                                                               <%-- <asp:DropDownList ID="ddlShipToCode_PickingHead" CssClass="form-control input-sm" runat="server"></asp:DropDownList>--%>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                 <button type="button" class="btn btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick3"><i class="glyphicon glyphicon-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtNameShipTo_PickingHead" class="col-sm-4 control-label">Name:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtShiptoName" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress1ShipTo_PickingHead" class="col-sm-4 control-label">Address1:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtShiptoAddress1" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress2ShipTo_PickingHead" class="col-sm-4 control-label">Address2:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtShiptoAddress2" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress3ShipTo_PickingHead" class="col-sm-4 control-label">Address3:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtShiptoAddress3" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtAddress4ShipTo_PickingHead" class="col-sm-4 control-label">Address4:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtShiptoAddress4" runat="server" autocomplete="off" />
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
                                                            <label for="txtQuantityOfGood_PickingHead" class="col-sm-4 control-label">Quantity Of Goods:</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="txtQuantityofPart" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="dcbQuantityofPart" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtWeight_PickingHead" class="col-sm-4 control-label">Quantity PLT/Skid</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="txtQuantityPLT" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="dcbQuantityPLT" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtVolume_PickingHead" class="col-sm-4 control-label">Volume:</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="txtVolume" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="dcbVolume" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQTYDiscrepancy_PickingHead" class="col-sm-4 control-label">QTY Discrepancy:</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="txtQTYDiscrepancy" runat="server" value="0.0" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="cboDiscrepencyUNIT" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
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

                                        </div>
                                    </div>
                                    <!-- /.col-->
                                </div>
                                <!-- /.rom -->
                            </div>
                            <!-- /.post -->
                        </div>
                        <div role="tabpanel" class="tab-pane" id="importfiles"">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">

                                    <div class="col-lg-12 col-md-12">

                                        <div class="form-horizontal">
                                            <div class="box-body">
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
                                                                    <asp:FileUpload ID="txtImport1" CssClass="form-control" runat="server" />
                                                                    <%--<input type="file" class="form-control input-sm" id="txtImport" runat="server" autocomplete="off" />--%>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-4 col-sm-offset-6">
                                                                    <button type="submit" runat="server" class="btn btn-success btn-sm" id="btnImport1NJRC_ImportFiles" title="btnImport1NJRC_ImportFiles" onserverclick="btnImport1NJRC_ImportFiles_ServerClick">Import 1 NJRC</button>
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

                                            <!-- /.box-body -->
                                        </div>
                                        <!--/.col-lg-6 col-md-6--->
                                    </div>
                                    <!--/.row-->
                                </div>
                            </div>
                            <!-- /.post -->
                        </div>


                        <div role="tabpanel" class="tab-pane" id="assigndetailofpullsignal">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">
                                    <div class="col-lg-12 col-md-12">
                                        <div class="form-horizontal">
                                            <div class="box-body">
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
                                                                <input class="form-control input-sm" id="txtItemNo" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtOwnerPN_AssignDetail" class="col-sm-4 control-label">Owner P/N:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtOwnerPart" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRequestedQuantity_AssignDetail" class="col-sm-4 control-label">Request Quantity:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtRequestedQuantity" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerLot_AssignDetail" class="col-sm-4 control-label">Customer LOT:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtCustomerLot" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>


                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtEASPN_AssignDetail" class="col-sm-3 control-label">EAS P/N:</label>
                                                            <div class="col-sm-6">
                                                                <input runat="server" id="txtProductCode" class="input-sm form-control" autocomplete="off" />
                                                            </div>
                                                            <div class="col-md-2">
                                                                 <button type="button" class="btn btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick4"><i class="glyphicon glyphicon-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtProductDesc_AssignDetail" class="col-sm-4 control-label">Product Desc:</label>
                                                            <div class="col-sm-8">
                                                                <textarea class="form-control input-sm" rows="3" runat="server" id="txtProductDesc" placeholder="Desc.." style="height: 34px; width: 552px;" autocomplete="off"></textarea>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="cboRequestUnit" CssClass="form-control input-sm" runat="server" DataTextField = "Code" DataValueField="Code"></asp:DropDownList>
                                                              <%--  <asp:DropDownList ID="ddlRequestedQuantity_AssignDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>--%>
                                                            </div>
                                                            <label for="txtOrderNo_AssignDetail" class="col-sm-3 control-label">OrderNo:</label>
                                                            <div class="col-sm-5">
                                                                <input class="form-control input-sm" id="txtOrder" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPriceForeign_AssignDetail" class="col-sm-4 control-label">Price(Foreign):</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtPriceForeigh" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtCustomerPN_AssignDetail" class="col-sm-4 control-label">CustomerP/N:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtCustomerPart" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group" style="height: 34px;"></div>
                                                        <div class="form-group" style="height: 34px;">
                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rdbIMP" Text="IMP" onclick="EnableDisableTextBox();" GroupName="option1" Checked="false"/>
                                                                    </label>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rdbEXP" Text="EXP" onclick="EnableDisableTextBox();" GroupName="option1"/>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="form-group">
                                                            <label for="txtPriceBath_AssignDetail" class="col-sm-4 control-label">Price(Bath):</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtPriceBath" runat="server" autocomplete="off" />
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
                                                                    <input type="checkbox" runat="server" id="chkNotUseDate_AssignDetail" onclick="EnableDisableTextBox();"/>Not Use Date
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
                                                            <input class="form-control input-sm" id="txtAvailableQuantity" runat="server"  autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtOrderFromOnline_AssignDetail" class="col-sm-4 control-label">Order From Online:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtOrderFrmOnline" runat="server" value="0" autocomplete="off" />
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
                                                            <input class="form-control input-sm" id="txtPalletNoAssign" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtCustomerFromOnline_AssignDetail" class="col-sm-4 control-label">Customer From Online:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtCustFrmOnline" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.box-body -->
                                                <%--</fieldset>--%>
                                            </div>
                                        </div>
                                        <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>
                                        <%-----------------------------------------------------Start BUTTON FORM------------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-sm-4 col-sm-offset-8">
                                                        <div class="form-group">
                                                            <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnSaveNew_AssignDetail" title="btnSaveNew_AssignDetail" onserverclick="btnSaveNew_AssignDetail_ServerClick">Save New</button>

                                                            <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnSaveModify_AssignDetail" title="btnSaveModify_AssignDetail" onserverclick="btnSaveModify_AssignDetail_ServerClick">Save Modify</button>

                                                            <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnDelete_AssignDetail" title="btnDelete_AssignDetail">Delete</button>

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
                                        <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-sm-12">
                                               <asp:Repeater runat="server" ID="dgvImported" OnItemDataBound="dgvItemDetail_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table class="table table-condensed table-striped table-responsive" id="example11" style="overflow: auto;">
                                                                        <thead>
                                                                        <th><asp:CheckBox runat="server" ID="chkAll_Imp" Checked="false" AutoPostBack="true"></asp:CheckBox></th>
                                                                        <th>PullSignal</th>
                                                                        <th>LOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>ProductNo</th>
                                                                        <th>CutomerPart</th>
                                                                        <th>OwnerPart</th>                                                                      
                                                                        <th>OrderNo</th>
                                                                        <th>CustomerLot</th>
                                                                        </thead>                                                                                                                                            
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                
                                                                    <tr class="success">
                                                                        <td class="text-center">
                                                                            <asp:CheckBox ID="chkpull" runat="server" AutoPostBack="true" OnCheckedChanged="chkpull_CheckedChanged"></asp:CheckBox></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server" Text="Label"></asp:Label></td>                                                                      
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server" Text="Label"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server" Text="Label"></asp:Label></td>
                                                                    </tr>
                                                              
                                                                </ItemTemplate>
                                                               <AlternatingItemTemplate>
                                                                    <tr class="danger">
                                                                        <td class="text-center">
                                                                            <asp:CheckBox ID="chkpull" runat="server" AutoPostBack="true"></asp:CheckBox></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server" Text="Label"></asp:Label></td>                                                                      
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server" Text="Label"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server" Text="Label"></asp:Label></td>
                                                                    </tr>
                                                              
                                                               </AlternatingItemTemplate>
                                                                <FooterTemplate>
                                                                    <tfoot>
                                                                       <th></th>
                                                                       <th>PullSignal</th>
                                                                       <th>LOTNo</th>
                                                                       <th>ItemNo</th>
                                                                       <th>ProductNo</th>
                                                                       <th>CutomerPart</th>
                                                                       <th>OwnerPart</th>                                                                 
                                                                       <th>OrderNo</th>
                                                                       <th>CustomerLot</th>
                                                                    </tfoot>                                                             
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        <%--------------------------------------Data Picking Detail Repeater---------------------------------%>
                                                    </div>

                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                        <%-------------------------------------------------------------------End Import File ---------------------------------------------------------%>
                                    </div>
                                    <!-- right column -->
                                    <!-- /.post -->
                                </fieldset>

                                            </div>
                                            <!--/.col-lg-6 col-md-6--->
                                        </div>
                                        <!--/.row-->
                                    </div>
                                    <!-- /.post -->
                                </div>
                            </div>
                        </div>
                        
                        <div role="tabpanel" class="tab-pane" id="pickpack">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">
                                    <div class="col-lg-12 col-md-12">
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                 <fieldset runat="server" id="pickpack_fieldset">
                                    <!-- Post -->
                                    <div class="row">

                                        <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend>ตาราง1</legend>
                                                            <asp:Repeater runat="server" ID="dgvReadWHIssuedRequest" OnItemDataBound="dgvReadWHIssuedRequest_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table  class="table table-condensed" id="example12">
                                                                        <thead>
                                                                        <th><asp:CheckBox runat="server" ID="chkAll_Imp" Checked="false" AutoPostBack="true"/></th>                                                                       
                                                                        <th>PullSignal</th>
                                                                        <th>LOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>ProductNo</th>
                                                                        <th>CutomerPart</th>
                                                                        <th>OwnerPart</th>                                                                      
                                                                        <th>OrderNo</th>
                                                                        <th>CustomerLot</th>
                                                                        </thead>                                                                                                                                           
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                     <td><asp:CheckBox ID="chkpull_Issud" runat="server" AutoPostBack="true" OnCheckedChanged="chkpull_Issud_CheckedChanged"/></td>
                                                                     <td><asp:Label ID="lblPull" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblItemNo" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblProduct" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblPart" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblDesc" runat="server"></asp:Label></td>                                                                     
                                                                     <td><asp:Label ID="lblPn" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblLot" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                 <AlternatingItemTemplate>
                                                                    <tr class="danger">
                                                                     <td><asp:CheckBox ID="chkpull_Issud" runat="server"/></td>
                                                                     <td><asp:Label ID="lblPull" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblItemNo" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblProduct" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblPart" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblDesc" runat="server"></asp:Label></td>                                                                     
                                                                     <td><asp:Label ID="lblPn" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lblLot" runat="server"></asp:Label></td>
                                                                    </tr>
                                                              
                                                               </AlternatingItemTemplate>
                                                                <FooterTemplate>
                                                                   <tfoot>
                                                                   <th></th>                                                                 
                                                                   <th>PullSignal</th>
                                                                   <th>LOTNo</th>
                                                                   <th>ItemNo</th>
                                                                   <th>ProductNo</th>
                                                                   <th>CutomerPart</th>
                                                                   <th>OwnerPart</th>                                                      
                                                                   <th>OrderNo</th>
                                                                   <th>CustomerLot</th>
                                                                   </tfoot>                                                                
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
                                        <%-----------------------------------------------------Start JOB Form-----------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                

                                            <%----------------------------------------------------Start Input data-----------------------------------------------%>
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-md-4 col-sm-4">
                                                        <div class="form-group " style="height: 34px;">
                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rdbOwner" Text="Owner" onclick="EnableOWner();" GroupName="option2"/>
                                                                    </label>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rdbSpecific" Text="Specific" onclick="EnableOWner();" GroupName="option2"  />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerLOT_PickPack" class="col-sm-4 control-label">CustomerLOT:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtCUL" runat="server" autocomplete="off" disabled="disabled" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtOwnerPN_PickPack" class="col-sm-4 control-label">Owner P/N:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtOW" runat="server" autocomplete="off" disabled="disabled"/>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtWHSite_PickPack" class="col-sm-4 control-label">WH/Site:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="dcbSite" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtINVNo_PickPack" class="col-sm-4 control-label">INV No:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtINVNo" runat="server" autocomplete="off" disabled="disabled" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtENDCustomer_PickPack" class="col-sm-4 control-label">ENDCustomer:</label>
                                                            <div class="col-sm-5">
                                                                <input class="form-control input-sm" id="txtENDCustomer" runat="server" autocomplete="off" disabled="disabled" />
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

                                        <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend>ตาราง2</legend>
                                                            <asp:Repeater runat="server" ID="dgvReadWHIssuedDetail" OnItemDataBound="dgvReadWHIssuedDetail_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table id="example13" class="table table-condensed">
                                                                        <thead>
                                                                            <th>select</th>
                                                                            <th>LOTNo</th>
                                                                            <th>WHSite</th>                                                                                                                                             
                                                                            <th>CustomerLOTNo</th>                                                                      
                                                                            <th>ItemNo</th>
                                                                            <th>ProductCode</th>
                                                                            <th>CustomerPN</th>
                                                                            <th>OwnerPN</th>
                                                                            <th>Quantity</th>
                                                                        </thead>                                                                                                                                    
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                        <td><asp:CheckBox ID="chkLotNo" runat="server" AutoPostBack="true" OnCheckedChanged="chkLotNo_CheckedChanged"></asp:CheckBox></td>
                                                                        <td><asp:Label ID="lblLOTNo" runat="server" Text="Label"></asp:Label></td>
                                                                        <td><asp:Label ID="lblSite" runat="server" Text="Label"></asp:Label></td>                                                                        
                                                                        <td><asp:Label ID="lblCustomer" runat="server" Text="Label"></asp:Label></td>                                                                                                                                             
                                                                        <td><asp:Label ID="lblItemNo" runat="server" Text="Label"></asp:Label></td>
                                                                        <td><asp:Label ID="lblProduct" runat="server" Text="Label"></asp:Label></td>
                                                                        <td><asp:Label ID="lblPN" runat="server" Text="Label"></asp:Label></td>
                                                                        <td><asp:Label ID="lblOwner" runat="server" Text="Label"></asp:Label></td>
                                                                        <td><asp:Label ID="lblEntry" runat="server" Text="Label"></asp:Label></td>                                                                  
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <AlternatingItemTemplate>
                                                                        <tr class="danger">
                                                                            <td><asp:CheckBox ID="chkLotNo" runat="server" AutoPostBack="true"></asp:CheckBox></td>
                                                                            <td><asp:Label ID="lblLOTNo" runat="server" Text="Label"></asp:Label></td>
                                                                            <td><asp:Label ID="lblSite" runat="server" Text="Label"></asp:Label></td>                                                                        
                                                                            <td><asp:Label ID="lblCustomer" runat="server" Text="Label"></asp:Label></td>                                                                                                                                             
                                                                            <td><asp:Label ID="lblItemNo" runat="server" Text="Label"></asp:Label></td>
                                                                            <td><asp:Label ID="lblProduct" runat="server" Text="Label"></asp:Label></td>
                                                                            <td><asp:Label ID="lblPN" runat="server" Text="Label"></asp:Label></td>
                                                                            <td><asp:Label ID="lblOwner" runat="server" Text="Label"></asp:Label></td>
                                                                            <td><asp:Label ID="lblEntry" runat="server" Text="Label"></asp:Label></td>                                                                  
                                                                    </tr>
                                                                </AlternatingItemTemplate>
                                                                <FooterTemplate>
                                                                    <tfoot>
                                                                        <th>select</th>
                                                                        <th>LOTNo</th>
                                                                        <th>WHSite</th>                                                                                                                                           
                                                                        <th>CustomerLOTNo</th>                                                                   
                                                                        <th>ItemNo</th>
                                                                        <th>ProductCode</th>
                                                                        <th>CustomerPN</th>
                                                                        <th>OwnerPN</th>
                                                                        <th>Quantity</th>
                                                                      </tfoot>                                                                   
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
                                      
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
                                                                <input runat="server" id="txtPalletNo" autocomplete="off" class="form-control input-sm" />
                                                            </div>
                                                        </div>                                                      
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <%--<label for="txtOwnerPN_PickPack" class="col-sm-4 control-label">Owner P/N:</label>--%>
                                                            <div class="col-sm-6">
                                                                <input class="form-control input-sm" id="txtIssuedQTY" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <input class="form-control input-sm" id="CalcEdit2" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQTYOfPick" class="col-sm-4 control-label">QuantityOfPick:</label>
                                                            <div class="col-sm-8">
                                                               <%-- <asp:DropDownList ID="ddlQuantityOfPick_PickPack" CssClass="form-control input-sm" runat="server"></asp:DropDownList>--%>
                                                                <input runat="server" id="txtQTYOfPick" class="form-control input-sm" autocomplete="off"/>
                                                            </div>
                                                         </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtSumQTYPick1" class="col-sm-4 control-label">QTY Can Pick:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtSumQTYPick1" runat="server" autocomplete="off" disabled />
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

                                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnCancel" title="btnCancel">Cancel</button>
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
                                          <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend>ตาราง3</legend>
                                                            <asp:Repeater runat="server" ID="dgvWHPickDetail" OnItemDataBound="dgvItemDetail_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table  class="table table-condensed">
                                                                        <thead>
                                                                        <th>
                                                                        <asp:CheckBox runat="server" ID="chkAll_Item" Checked="false"></asp:CheckBox>select</th>
                                                                        <th>PullSignal</th>
                                                                        <th>LOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>ProductNo</th>
                                                                        <th>CutomerPart</th>
                                                                        <th>OwnerPart</th>                                                                   
                                                                        <th>OrderNo</th>
                                                                        <th>CustomerLot</th>
                                                                        </thead>                                                                                                                                        
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                        <td>
                                                                            <asp:CheckBox ID="chkLotNo" runat="server" AutoPostBack="true"></asp:CheckBox></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server"></asp:Label></td>                                                                     
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <AlternatingItemTemplate>
                                                                    <tr class="Danger">
                                                                        <td>
                                                                            <asp:CheckBox ID="chkLotNo" runat="server" AutoPostBack="true"></asp:CheckBox></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server"></asp:Label></td>                                                                     
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </AlternatingItemTemplate>
                                                                <FooterTemplate>
                                                                    <tfoot>
                                                                    <th>select</th>
                                                                   <th>PullSignal</th>
                                                                   <th>LOTNo</th>
                                                                   <th>ItemNo</th>
                                                                   <th>ProductNo</th>
                                                                   <th>CutomerPart</th>
                                                                   <th>OwnerPart</th>                                                                  
                                                                   <th>OrderNo</th>
                                                                   <th>CustomerLot</th>
                                                                    </tfoot>                                                                
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
                                    </div>
                                    <!-- /.post -->
                                </fieldset>

                                            </div>
                                            <!--/.col-lg-6 col-md-6--->
                                        </div>
                                        <!--/.row-->
                                    </div>
                                    <!-- /.post -->
                                </div>
                            </div>
                        </div>
                        
                        <div role="tabpanel" class="tab-pane" id="picknjr">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">
                                    <div class="col-lg-12 col-md-12">
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                  <fieldset runat="server" id="picknjr_fieldset">                         
                                        <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend>ตาราง4</legend>
                                                            <asp:Repeater runat="server" ID="dgvReadWHIssuedRequestNJR" OnItemDataBound="dgvReadWHIssuedRequestNJR_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table class="table table-condensed" id="example13">
                                                                        <thead>                                                                     
                                                                        <th>PullSignal</th>
                                                                        <th>LOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>ProductNo</th>
                                                                        <th>CutomerPart</th>
                                                                        <th>OwnerPart</th>                                                                      
                                                                        <th>OrderNo</th>
                                                                        <th>CustomerLot</th>                                                                      
                                                                        </thead>                                                                   
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">                                                                      
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server"></asp:Label></td>                                                                      
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <AlternatingItemTemplate>
                                                                    <tr class="danger">                                                                       
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server" Text="Label"></asp:Label></td>                                                                      
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server" Text="Label"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server" Text="Label"></asp:Label></td>
                                                                    </tr>
                                                              
                                                               </AlternatingItemTemplate>
                                                                <FooterTemplate>
                                                                    <tfoot>                                                            
                                                                   <th>PullSignal</th>
                                                                   <th>LOTNo</th>
                                                                   <th>ItemNo</th>
                                                                   <th>ProductNo</th>
                                                                   <th>CutomerPart</th>
                                                                   <th>OwnerPart</th>                                                                
                                                                   <th>OrderNo</th>
                                                                   <th>CustomerLot</th>
                                                                    </tfoot>                                                                  
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
                                        <%-----------------------------------------------------Start JOB Form-----------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 col-md-offset-8">
                                             
                                                        <div class="form-group">
                                                            <label for="txtWHSite_PickNJR" class="col-sm-2 control-label">WH/Site:</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="ddlWHSite_PickNJR" CssClass="form-control input-sm" runat="server">
                                                                    <asp:ListItem></asp:ListItem>
                                                                     <asp:ListItem>NJR-JP</asp:ListItem>
                                                                     <asp:ListItem>NJR-US</asp:ListItem>
                                                                     <asp:ListItem>NJR-CN</asp:ListItem>
                                                                    <asp:ListItem>NJR-SG</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->                                           
                                     
                                        <%-------------------------------------------------------End JOB Form----------------------------------------------------------------%>

                                        <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend>ตาราง5</legend>
                                                            <asp:Repeater runat="server" ID="dgvItemAuto">
                                                                <HeaderTemplate>
                                                                    <table class="table table-condensed">
                                                                        <thead>
                                                                         <th style="width: 2px">
                                                                        <asp:CheckBox runat="server" ID="chkAll_Item" Checked="false"></asp:CheckBox>select</th>
                                                                        <th>PullSignal</th>
                                                                        <th>LOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>ProductNo</th>
                                                                        <th>CutomerPart</th>
                                                                        <th>OwnerPart</th>
                                                                        <th>ProductDesc</th>
                                                                        <th>OrderNo</th>
                                                                        <th>CustomerLot</th>
                                                                        </thead>                                                                                                                                     
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                        <td>
                                                                            <asp:CheckBox ID="chkLotNo" runat="server" AutoPostBack="true"></asp:CheckBox></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                       
                                                                <FooterTemplate>
                                                                    <tfoot>
                                                                   <th>select</th>
                                                                   <th>PullSignal</th>
                                                                   <th>LOTNo</th>
                                                                   <th>ItemNo</th>
                                                                   <th>ProductNo</th>
                                                                   <th>CutomerPart</th>
                                                                   <th>OwnerPart</th>
                                                                   <th>ProductDesc</th>
                                                                   <th>OrderNo</th>
                                                                   <th>CustomerLot</th>
                                                                    </tfoot>
                                                                   
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
                                        <%------------------------------------------------------Start Input/Button Data--------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 col-md-offset-6">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                               
                                                    <div class="col-md-4">

                                                        <div class="form-group">
                                                            <label for="txtQuantityOfPick_PickNJR" class="col-sm-5 control-label">QuantityOfPick:</label>
                                                            <div class="col-sm-7">
                                                                <input class="form-control input-sm" id="txtQuantityOfPick_PickNJR" runat="server" autocomplete="off"/>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-2">
                                                       <div class="form-group">                                                           
                                                            <div class="col-sm-3">
                                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnAutoPickNJR" title="btnAutoPickNJR">Auto Pick NJR</button>
                                                            </div>
                                                        </div>
                                                    </div>


                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->

                                        </div>
                                        <%---------------------------------------------End Input/Button Data----------------------------------------------------%>
                                        <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend>ตาราง6</legend>
                                                            <asp:Repeater runat="server" ID="dgvNewPick">
                                                                <HeaderTemplate>
                                                                    <table  class="table table-condensed">
                                                                        <thead>
                                                                         <th style="width: 2px">
                                                                        <asp:CheckBox runat="server" ID="chkAll_Item" Checked="false"></asp:CheckBox>select</th>
                                                                        <th>PullSignal</th>
                                                                        <th style="width: 10px">LOTNo</th>
                                                                        <th style="width: 10px">ItemNo</th>
                                                                        <th style="width: 10px">ProductNo</th>
                                                                        <th style="width: 10px">CutomerPart</th>
                                                                        <th style="width: 10px">OwnerPart</th>
                                                                        <th style="width: 5px">ProductDesc</th>
                                                                        <th style="width: 10px">OrderNo</th>
                                                                        <th style="width: 10px">CustomerLot</th>
                                                                        </thead>                                                                                                                                     
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                        <td>
                                                                            <asp:CheckBox ID="chkLotNo" runat="server" AutoPostBack="true"></asp:CheckBox></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                       
                                                                <FooterTemplate>
                                                                    <tfoot>
                                                                   <th>select</th>
                                                                   <th>PullSignal</th>
                                                                   <th>LOTNo</th>
                                                                   <th>ItemNo</th>
                                                                   <th>ProductNo</th>
                                                                   <th>CutomerPart</th>
                                                                   <th>OwnerPart</th>
                                                                   <th>ProductDesc</th>
                                                                   <th>OrderNo</th>
                                                                   <th>CustomerLot</th>
                                                                    </tfoot>                                                                 
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>                                  
                       <%----------------------------------------------------End Third Repeater--------------------------------------------------%>                                   
                                    <!-- /.post -->
                                </fieldset>
                                                
                                            </div>
                                            <!--/.col-lg-6 col-md-6--->
                                        </div>
                                        <!--/.row-->
                                    </div>
                                    <!-- /.post -->
                                </div>
                            </div>
                        </div>

                             <div role="tabpanel" class="tab-pane" id="pickautopallet">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">
                                    <div class="col-lg-12 col-md-12">
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                 <fieldset runat="server" id="pickautopallet_fieldset">
                                            <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend>ตาราง7</legend>
                                                            <asp:Repeater runat="server" ID="dgvReadAssign" OnItemDataBound="dgvReadAssign_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table class="table table-condensed" id="example14">
                                                                        <thead>
                                                                        <th>PullSignal</th>                                                                   
                                                                        <th>LOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>ProductNo</th>
                                                                        <th>CutomerPart</th>
                                                                        <th>OwnerPart</th>                                                                       
                                                                        <th>OrderNo</th>
                                                                        <th>CustomerLot</th>
                                                                        </thead>                                                                                                                                          
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">                                                                      
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server"></asp:Label></td>                                                                   
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate> 
                                                                <AlternatingItemTemplate>
                                                                    <tr class="danger">                                                              
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server" Text="Label"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server" Text="Label"></asp:Label></td>                                                                      
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server" Text="Label"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server" Text="Label"></asp:Label></td>
                                                                    </tr>
                                                              
                                                               </AlternatingItemTemplate>                                                     
                                                                <FooterTemplate>
                                                                    <tfoot>                                                              
                                                                   <th>PullSignal</th>
                                                                   <th>LOTNo</th>
                                                                   <th>ItemNo</th>
                                                                   <th>ProductNo</th>
                                                                   <th>CutomerPart</th>
                                                                   <th>OwnerPart</th>                                                                
                                                                   <th>OrderNo</th>
                                                                   <th>CustomerLot</th>
                                                                    </tfoot>                                                                
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
                                                     <div class="col-lg-12 col-md-12 col-md-offset-8">                                                                                                                                    
                                                        <div class="form-group">
                                                            <label for="txtWHSite_PickNJR" class="col-sm-2 control-label">WH/Site:</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcbSite2" CssClass="form-control input-sm" runat="server">
                                                                    <asp:ListItem></asp:ListItem>
                                                                     <asp:ListItem>CKT</asp:ListItem>
                                                                     <asp:ListItem>EPN-EVENT</asp:ListItem>
                                                                     <asp:ListItem>EPN-ONLINE</asp:ListItem>
                                                                
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                      
                                                     <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend>ตาราง8</legend>
                                                            <asp:Repeater runat="server" ID="dgvPickPallet" OnItemDataBound="dgvItemDetail_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table class="table table-condensed">
                                                                        <thead>
                                                                        <th style="width: 2px">
                                                                        <asp:CheckBox runat="server" ID="chkAll_Item" Checked="false"></asp:CheckBox></th>
                                                                        <th>PullSignal</th>
                                                                        <th style="width: 10px">LOTNo</th>
                                                                        <th style="width: 10px">ItemNo</th>
                                                                        <th style="width: 10px">ProductNo</th>
                                                                        <th style="width: 10px">CutomerPart</th>
                                                                        <th style="width: 10px">OwnerPart</th>
                                                                        <th style="width: 5px">ProductDesc</th>
                                                                        <th style="width: 10px">OrderNo</th>
                                                                        <th style="width: 10px">CustomerLot</th>
                                                                        </thead>                                                                                                                                             
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                        <td>
                                                                            <asp:CheckBox ID="chkLotNo" runat="server" AutoPostBack="true"></asp:CheckBox></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPull" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItemNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProduct" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPart" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesc" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblLot" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                       
                                                                <FooterTemplate>
                                                                    <tfoot>
                                                                    <th></th>
                                                                   <th>PullSignal</th>
                                                                   <th>LOTNo</th>
                                                                   <th>ItemNo</th>
                                                                   <th>ProductNo</th>
                                                                   <th>CutomerPart</th>
                                                                   <th>OwnerPart</th>
                                                                   <th>ProductDesc</th>
                                                                   <th>OrderNo</th>
                                                                   <th>CustomerLot</th>
                                                                    </tfoot>
                                                                  
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
                                        <%------------------------------------------------------Start Input/Button Data--------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                                                                                                 
                                                            <div class="col-md-offset-10">
                                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnAutoPickPallet" title="btnAutoPickPallet">Auto Pick Pallet</button>
                                                            </div>
                                                        </div>                                               
                                             
                                        <%---------------------------------------------End Input/Button Data----------------------------------------------------%>  
                                                                                  
                                    <!-- /.post -->
                                </fieldset>

                                            </div>
                                            <!--/.col-lg-6 col-md-6--->
                                        </div>
                                        <!--/.row-->
                                    </div>
                                    <!-- /.post -->
                                </div>
                            </div>
                        </div>
            
                        <asp:HiddenField ID="TabName" runat="server" />
                    </div>
                </div>
            </div>
            <!-- /.row -->
        </section>
        <asp:Panel ID="plOwner" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="exampleModalLabel">Select JOB No</h4>
                    </div>
                    <asp:UpdatePanel ID="upOwner" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvOwner" runat="server" OnItemDataBound="dgvOwner_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example11" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyAddressCode</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="lnkPartyCode_Owner" CssClass="btn bg-navy btn-sm" runat="server" OnClick="lnkPartyCode_Owner_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAdd" runat="server" Text="Label"></asp:Label></td>
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
                                                            <th>select</th>
                                                            <th>PartyCode</th>
                                                            <th>PartyAddressCode</th>
                                                            <th>PartyFullName</th>
                                                            <th>Address1</th>
                                                            <th>Address2</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </form>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>

         <!-- Modal ExporterCode-->
        <asp:Panel ID="plConsigneeCode" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upConsigneeCode" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvConsigneeCode" runat="server" OnItemDataBound="dgvConsigneeCode_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example12" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyAddressCode</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="lnkPartyCode_Con" CssClass="btn bg-navy btn-sm" runat="server" OnClick="lnkPartyCode_Con_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAdd" runat="server" Text="Label"></asp:Label></td>
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
                                                            <th>select</th>
                                                            <th>PartyCode</th>
                                                            <th>PartyAddressCode</th>
                                                            <th>PartyFullName</th>
                                                            <th>Address1</th>
                                                            <th>Address2</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </form>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>

         <!-- Modal-->
        <asp:Panel ID="plExporterCode" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upExporterCode" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvExporterCode" runat="server" OnItemDataBound="dgvExporterCode_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example13" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyAddressCode</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <td class="text-center">
                                                        <asp:LinkButton ID="lnkPartyCode_Ex" CssClass="btn bg-navy btn-sm" runat="server" OnClick="lnkPartyCode_Ex_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblPartyAdd" runat="server" Text="Label"></asp:Label></td>
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
                                                            <th>select</th>
                                                            <th>PartyCode</th>
                                                            <th>PartyAddressCode</th>
                                                            <th>PartyFullName</th>
                                                            <th>Address1</th>
                                                            <th>Address2</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </form>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>
            </div>
        </asp:Panel>
        <!-- End Shipper Modal -->
        <!-- Modal-->
        <asp:Panel ID="plShipto" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upShipto" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvShipto" runat="server" OnItemDataBound="dgvShipto_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example14" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>LOTNo</th>
                                                                <th>LOTDate</th>
                                                                <th>CustREFNo</th>
                                                                <th>OwnerCode</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <td class="text-center">
                                                        <asp:LinkButton ID="lnkPartyCode_LOTNo" CssClass="btn bg-navy btn-sm" runat="server" OnClick="lnkPartyCode_LOTNo_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblLOTNo" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblLOTDate" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblCustREFNo" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblOwnerCode" runat="server" Text="Label"></asp:Label></td>

                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>LOTNo</th>
                                                            <th>LOTDate</th>
                                                            <th>CustREFNo</th>
                                                            <th>OwnerCode</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </form>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <!-- End Shipper Modal -->

        <!-- Modal-->
        <asp:Panel ID="plGenExp" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upGenExp" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvGenExp" runat="server" OnItemDataBound="dgvGenExp_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example15" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                              <tr>
                                                                <th>select</th>
                                                                <th>EASLOTNo</th>
                                                                <th>CustomerCode</th>
                                                                <th>SalesCode</th>
                                                                <th>JobSite</th>
                                                                <th>EndCusCode</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <td class="text-center">
                                                        <asp:LinkButton ID="lnk_EAS" CssClass="btn bg-navy btn-sm" runat="server" OnClick="lnk_EAS_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEASLOTNo" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblCustomer" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSales" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSite" runat="server" Text="Label"></asp:Label></td>
                                                     <td>
                                                        <asp:Label ID="lblCus" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>EASLOTNo</th>
                                                            <th>CustomerCode</th>
                                                            <th>SalesCode</th>
                                                            <th>JobSite</th>
                                                            <th>EndCusCode</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </form>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <!-- End Shipper Modal -->

        <!-- Modal-->
        <!-- End Shipper Modal -->
        <asp:Panel ID="plPicklist" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <%--<div class="modal fade" id="ProductCodeModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Product Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upPicklist" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="dgvPicklist" runat="server" OnItemDataBound="dgvPicklist_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example16" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>Select</th>
                                                                <th>PullSignal</th>
                                                                <th>LOTNo</th>
                                                                <th>PullDate</th>
                                                                <th>DeliveryDate</th>
                                                              
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="btnPullSignal" CssClass="btn bg-navy btn-sm" runat="server" OnClick="btnPullSignal_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPullSignal" runat="server"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPullDate" runat="server"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblDelivery" runat="server"></asp:Label></td>
                                                      
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Select</th>
                                                            <th>PullSignal</th>
                                                            <th>LOTNo</th>
                                                            <th>PullDate</th>
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
            <%--</div>--%>
        </asp:Panel>

        <asp:Panel ID="plProduct" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Delivery Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upProduct" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="dgvProduct" runat="server" OnItemDataBound="dgvProduct_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example17" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>Select</th>
                                                                <th>ProductCode</th>
                                                                <th>Desc</th>
                                                                <th>EndUserPart</th>
                                                                <th>CustomerPart</th>                                                               
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="lbCode" CssClass="btn bg-navy btn-sm" runat="server" OnClick="lbCode_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblProductCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblExpDesc" runat="server" Text="Label"></asp:Label>
                                                            <asp:Label ID="lblimpDesc" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUserPart" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPart" runat="server" Text="Label"></asp:Label></td>                                                       
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Select</th>
                                                            <th>ProductCode</th>
                                                            <th>Desc</th>
                                                            <th>EndUserPart</th>
                                                            <th>CustomerPart</th> 
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
        <!-- /.content -->
          <script type="text/javascript">
              $(function () {
                  var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "pickinghead";
                  $('#Tabs a[href="#' + tabName + '"]').tab('show');
                  $("#Tabs a").click(function () {
                      $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                  });
              });
        </script>
        
        <script type="text/javascript">
            function EnableDisableTextBox() {
                var status = document.getElementById('<%=chkNotUseDate_AssignDetail.ClientID%>').checked;

                if (status == true) {
                    document.getElementById('<%=txtdatepickerExpiredDate_AssignDetail.ClientID%>').disabled = true;
                    document.getElementById('<%=txtdatepickerManufacturing_AssignDetail.ClientID%>').disabled = true;
                } else if (status == false) {
                    document.getElementById('<%=txtdatepickerManufacturing_AssignDetail.ClientID%>').disabled = false;
                  document.getElementById('<%=txtdatepickerExpiredDate_AssignDetail.ClientID%>').disabled = false;
              }

      }
        </script>
          <script type="text/javascript">
              function EnableOWner() {
                  var status = document.getElementById('<%=rdbOwner.ClientID%>').checked;

                if (status == true) {
                    document.getElementById('<%=txtOW.ClientID%>').disabled = true;
                    document.getElementById('<%=txtENDCustomer.ClientID%>').disabled = true;
                    document.getElementById('<%=txtCUL.ClientID%>').disabled = true;               
                } else if (status == false) {
                    document.getElementById('<%=txtOW.ClientID%>').disabled = false;
                    document.getElementById('<%=txtENDCustomer.ClientID%>').disabled = false;
                    document.getElementById('<%=txtCUL.ClientID%>').disabled = false;  
                }

        }
        </script>
              <script>
                  $(document).ready(function () {
                      // CHECK-UNCHECK ALL CHECKBOXES IN THE REPEATER 
                      // WHEN USER CLICKS THE HEADER CHECKBOX.
                      $('table [id*=chkAll_Imp]').click(function () {
                          if ($(this).is(':checked'))
                              $('table [id*=chkpull]').prop('checked', true)
                          else
                              $('table [id*=chkpull]').prop('checked', false)
                      });

                      // NOW CHECK THE HEADER CHECKBOX, IF ALL THE ROW CHECKBOXES ARE CHECKED.
                      $('table [id*=chkLotNo]').click(function () {

                          var total_rows = $('table [id*=chkpull]').length;
                          var checked_Rows = $('table [id*=chkpull]:checked').length;

                          if (checked_Rows == total_rows)
                              $('table [id*=chkAll_Imp]').prop('checked', true);
                          else
                              $('table [id*=chkAll_Imp]').prop('checked', false);
                      });
                  });
        </script>
    </form>
</asp:Content>
