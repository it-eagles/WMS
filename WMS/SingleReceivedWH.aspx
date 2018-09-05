<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SingleReceivedWH.aspx.vb" Inherits="WMS.SingleReceivedWH" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Single Received
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>WareHouse</a></li>
                <li><a href="SingleReceivedWH.aspx" class="active">SingleReceived</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">

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

                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div id="Tabs" role="tabpanel" class="nav-tabs-custom">
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li><a href="#confirmgoodreceive" aria-controls="master" role="tab" data-toggle="tab" class="active">Confirm Good Receive</a></li>
                        <li><a href="#goodreceivedetail" aria-controls="detail" role="tab" data-toggle="tab">Good Receive Detail</a></li>
                        <li><a href="#putaway" aria-controls="invoice" role="tab" data-toggle="tab">Put Away</a></li>
                    </ul>
                    <!-- Tab panes -->
                    <div class="tab-content" style="padding-top: 10px">
                        <div role="tabpanel" class="tab-pane active" id="confirmgoodreceive">
                            <div class="post">
                                <div class="row margin-bottom">

                                    <div class="col-lg-12 col-md-8 ">
                                        <!-- form start -->
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                <fieldset runat="server" id="confirmgoodreceive_">
                                                    <legend></legend>
                                                    <div class="col-md-12 col-lg-12">
                                                        <div class="col-md-4 col-sm-4">
                                                            <div class="form-group">
                                                                <label for="txtLotNo" class="col-sm-3 control-label">Job No:</label>
                                                                <div class="col-sm-7">
                                                                    <%--  <asp:DropDownList ID="ddlJobNo_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                    <input runat="server" id="txtLotNo_" class="form-control input-sm" autocomplete="off" type="text" />

                                                                </div>
                                                                <div class="col-md-2">
                                                                    <button runat="server" class="btn btn-primary btn-sm" type="button" onserverclick="btnSeletJobNew_ServerClick" id="btnSeletJobNew"><i class="fa fa-search"></i></button>
                                                                    <button runat="server" class="btn  btn-danger btn-sm" type="button" onserverclick="btnSelectJobEdit_ServerClick" id="btnSelectJobEdit"><i class="fa fa-search"></i></button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="dtpInvoiceDate" class="col-sm-4 control-label">Job Date:</label>
                                                                <div class="col-sm-8">
                                                                    <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                                                    <asp:TextBox CssClass="form-control input-sm" ID="dtpInvoiceDate" runat="server" placeholder="DD/MM/YYYY"> </asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtenderJobdate_ConGoodRec" runat="server" Enabled="True" TargetControlID="dtpInvoiceDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="txtCustomerLot" class="col-sm-5 control-label">Cust REF No:</label>
                                                                <div class="col-sm-7">
                                                                    <input class="form-control input-sm" id="txtCustomerLot" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- /.box-header -->
                                                    </div>



                                                    <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                                                    <div class="col-md-6">
                                                        <!-- Horizontal Form -->

                                                        <!-- form start -->
                                                        <!-- general form Commodity -->
                                                        <div class="form-horizontal">
                                                            <fieldset>
                                                                <legend>Owner</legend>
                                                                <div class="box-body">
                                                                    <div class="form-group">
                                                                        <label for="txtOwnerCode_ConGoodRec" class="col-sm-4 control-label">Owner Code:</label>
                                                                        <div class="col-sm-6">
                                                                            <input runat="server" id="txtOwnerCode" class="form-control input-sm" type="text" autocomplete="off" />
                                                                            <%-- <asp:DropDownList ID="ddlOwnerCode_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <button runat="server" class="btn btn-primary btn-sm" type="button" onserverclick="Unnamed_ServerClick"><i class="fa fa-search"></i></button>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtOwnerEng" class="col-sm-4 control-label">Name:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtOwnerEng" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtOwnerStreet_Number" class="col-sm-4 control-label">Address1:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtOwnerStreet_Number" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtOwnerDistrict" class="col-sm-4 control-label">Address2:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtOwnerDistrict" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtOwnerSubProvince" class="col-sm-4 control-label">Address3:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtOwnerSubProvince" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtOwnerProvince" class="col-sm-4 control-label">Address4:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtOwnerProvince" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!-- /.box-body -->
                                                            </fieldset>
                                                        </div>

                                                        <div class="form-horizontal">
                                                            <fieldset>
                                                                <legend>WH Management</legend>
                                                                <div class="box-body">
                                                                    <div class="form-group">
                                                                        <label for="txtWHManagement_ConGoodRec" class="col-sm-4 control-label">WH Management:</label>
                                                                        <div class="col-sm-6">
                                                                            <%--<asp:DropDownList ID="ddlWHManagement_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                            <input runat="server" id="txtBrokerCode" class="form-control input-sm" type="text" autocomplete="off" />
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <button runat="server" class="btn btn-primary btn-sm" type="button" onserverclick="Unnamed_ServerClick1"><i class="fa fa-search"></i></button>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtNameWHManage_ConGoodRec" class="col-sm-4 control-label">Name:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtBrokerNameEng" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtBrokerStreet" class="col-sm-4 control-label">Address1:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtBrokerStreet" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtBrokerDistrict" class="col-sm-4 control-label">Address2:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtBrokerDistrict" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtBrokerSubProvince" class="col-sm-4 control-label">Address3:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtBrokerSubProvince" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtBrokerProvince" class="col-sm-4 control-label">Address4:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtBrokerProvince" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!-- /.box-body -->
                                                            </fieldset>
                                                        </div>

                                                        <div class="form-horizontal">
                                                            <fieldset>
                                                                <legend>Commodity</legend>
                                                                <div class="box-body">
                                                                    <div class="form-group">
                                                                        <label for="txtCommodity" class="col-sm-4 control-label">Commodity:</label>
                                                                        <div class="col-sm-8">
                                                                            <asp:DropDownList ID="dolCommodity" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="dcbQuantity2" class="col-sm-5 control-label">Quantity Package:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtQuantityPackage" runat="server" value="0.0" />
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="dcbQuantity2" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtQuantityPLTSkid_ConGoodRec" class="col-sm-5 control-label">Quantity PLT/Skid:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtPLT" runat="server" value="0.0" />
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="dcbPLT" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtQuantityReceived_ConGoodRec" class="col-sm-5 control-label">Quantity Received:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtQtyReceived" runat="server" value="0.0" />
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="cboReceivedUNIT" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtQuantityDamage_ConGoodRec" class="col-sm-5 control-label">Quantity Damage:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtQtyDamage" runat="server" value="0.0" />
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="cboDamageUNIT" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtRemark_ConGoodRec" class="col-sm-4 control-label">Remark:</label>
                                                                        <div class="col-sm-8">
                                                                            <textarea class="form-control input-sm" runat="server" rows="3" id="txtRamark" placeholder="Remark" style="height: 80px; width: 830px;"></textarea>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                        </div>
                                                                        <div class="col-sm-8">
                                                                            <button type="submit" runat="server" class="btn btn-primary " id="btnSumQTY_ConGoodRec" title="btnSumQTY_ConGoodRec" onserverclick="btnSumQTY_ConGoodRec_ServerClick">Sum QTY</button>
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
                                                                <legend>Customer</legend>
                                                                <div class="box-body">
                                                                    <div class="form-group">
                                                                        <label for="txtCustomerCode_ConGoodRec" class="col-sm-4 control-label">Customer Code:</label>
                                                                        <div class="col-sm-6">
                                                                            <%-- <asp:DropDownList ID="txtConsigneeCode" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                            <input runat="server" id="txtConsigneeCode_" class="form-control input-sm" type="text" autocomplete="off">
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <button runat="server" class="btn btn-primary btn-sm" type="button" onserverclick="Unnamed_ServerClick2"><i class="fa fa-search"></i></button>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtNameCustomer_ConGoodRec" class="col-sm-4 control-label">Name:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtConsignneeEng" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtAddress1Customer_ConGoodRec" class="col-sm-4 control-label">Address1:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtConsignneeStreet_Number" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtAddress2Customer_ConGoodRec" class="col-sm-4 control-label">Address2:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtConsignneeDistrict" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtAddress3Customer_ConGoodRec" class="col-sm-4 control-label">Address3:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtConsignneeSubProvince" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtAddress4Customer_ConGoodRec" class="col-sm-4 control-label">Address4:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtConsignneeProvince" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!-- /.box-body -->
                                                            </fieldset>
                                                        </div>

                                                        <div class="form-horizontal">
                                                            <fieldset>
                                                                <legend>End User</legend>
                                                                <div class="box-body">
                                                                    <div class="form-group">
                                                                        <label for="txtEndUserCode_ConGoodRec" class="col-sm-4 control-label">End User Code:</label>
                                                                        <div class="col-sm-6">
                                                                            <input runat="server" id="txtExporterCode" class="form-control input-sm" autocomplete="off" type="text" />
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <button runat="server" class="btn btn-primary btn-sm" type="button" onserverclick="Unnamed_ServerClick3"><i class="fa fa-search"></i></button>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtNameEndUser_ConGoodRec" class="col-sm-4 control-label">Name:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtExportEng" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtAddress1EndUser_ConGoodRec" class="col-sm-4 control-label">Address1:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtStreet_Number" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtAddress2EndUser_ConGoodRec" class="col-sm-4 control-label">Address2:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtDistrict" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtAddress3EndUser_ConGoodRec" class="col-sm-4 control-label">Address3:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtSubProvince" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtAddress4EndUser_ConGoodRec" class="col-sm-4 control-label">Address4:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control input-sm" id="txtProvince" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!-- /.box-body -->
                                                            </fieldset>
                                                        </div>

                                                        <div class="form-horizontal">
                                                            <fieldset>
                                                                <legend>Commodity</legend>
                                                                <div class="box-body">
                                                                    <div class="form-group">
                                                                        <label for="txtQuantityOfGood_ConGoodRec" class="col-sm-5 control-label">Quantity Of Goods:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtQuantityofPart" runat="server" value="0.0" />
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="dcbQuantity1" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtWeight_ConGoodRec" class="col-sm-5 control-label">Weight:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtWeight" runat="server" value="0.0" />
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="dcbWeight" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtVolume_ConGoodRec" class="col-sm-5 control-label">Volume:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtVolume" runat="server" value="0.0" />
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="dcbVolume" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtQTYWaitRec_ConGoodRec" class="col-sm-5 control-label">QTY Wait Receive:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtQtyWaitReceive" runat="server" value="0.0" />
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="cboWaitReceiveUNIT" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtQTYDiscrepancy_ConGoodRec" class="col-sm-5 control-label">QTY Discrepancy:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtQtyDiscrepancy" runat="server" value="0.0" />
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
                        <div role="tabpanel" class="tab-pane" id="goodreceivedetail">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">

                                    <div class="col-lg-12 col-md-12">

                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                <fieldset runat="server" id="goodreceivedetail_">
                                                    <legend></legend>
                                                    <div class="col-lg-12">
                                                        <div class="col-md-4 col-sm-4">
                                                            <div class="form-group">
                                                                <label for="dcbSite" class="col-sm-4 control-label">WH Site:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="dcbSite" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCusLOTNo_GoodRecDetail" class="col-sm-4 control-label">Cus LOT No:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtCusLOTNo" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEASPN_GoodRecDetail" class="col-sm-4 control-label">EAS P/N:</label>
                                                                <div class="col-sm-6">
                                                                    <%--    <asp:DropDownList ID="ddlEASPN_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                    <input runat="server" id="txtProductCode" autocomplete="off" type="text" class="form-control input-sm" />
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <button runat="server" class="btn btn-primary btn-sm" type="button" onserverclick="Unnamed_ServerClick4"><i class="fa fa-search"></i></button>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="txtWHLocation_GoodRecDetail" class="col-sm-4 control-label">WH Location:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="dcbLocation" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustWHFac_GoodRecDetail" class="col-sm-5 control-label">Cust W/H Fac:</label>
                                                                <div class="col-sm-7">
                                                                    <asp:DropDownList ID="dcbSource" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerPN_GoodRecDetail" class="col-sm-4 control-label">CustomerP/N:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtProductDesc2" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="txtENDCustomer_GoodRecDetail" class="col-sm-4 control-label">ENDCustomer:</label>
                                                                <div class="col-sm-6">
                                                                    <%-- <asp:DropDownList ID="ddlENDCustomer_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                    <input runat="server" id="txtCustomer" class="form-control input-sm" autocomplete="off" />
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <button runat="server" class="btn btn-primary btn-sm" type="button" onserverclick="Unnamed_ServerClick5"><i class="fa fa-search"></i></button>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtItemNo_GoodRecDetail" class="col-sm-4 control-label">Item No:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtItemNo" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtOwnerPN_GoodRecDetail" class="col-sm-4 control-label">Owner P/N:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtProductDesc3" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label for="txtProductDesc_GoodRecDetail" class="col-sm-3 control-label">Product Desc:</label>
                                                                <div class="col-sm-6">
                                                                    <textarea class="form-control input-sm" runat="server" rows="3" id="txtProductDesc1" placeholder="Desc .." style="height: 34px; width: 410px;"></textarea>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label for="txtMeasurement_GoodRecDetail" class="col-sm-4 control-label">Measurement</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlProductUnit" CssClass="form-control input-sm" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>CM</asp:ListItem>
                                                                        <asp:ListItem>INC</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-------------------------------------------------------End HEAD BEFORE LEFT FORM----------------------------------------------------------------%>

                                                    <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                                                    <div class="col-md-12">
                                                        <!-- Horizontal Form -->
                                                        <div class="form-group">
                                                            <label for="txtSpace_GoodRecDetail" class="col-sm-1"></label>
                                                            <label for="txtWidth_GoodRecDetail" class="col-sm-2">Width:</label>
                                                            <label for="txtHight_GoodRecDetail" class="col-sm-2">Hight:</label>
                                                            <label for="txtLength_GoodRecDetail" class="col-sm-2">Length:</label>
                                                            <label for="txtProductVolume_GoodRecDetail" class="col-sm-2">Product Volume:</label>
                                                            <label for="txtPalletNo_GoodRecDetail" class="col-sm-2">Pallet No:</label>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtDimension_GoodRecDetail" class="col-sm-1 control-label">Dimension:</label>
                                                            <div class="col-sm-2">
                                                                <%--<input class="form-control input-sm" id="txtProductWidth" runat="server" autocomplete="off" />--%>
                                                                <asp:TextBox runat="server" ID="txtProductWidth_" AutoPostBack="true" CssClass="form-control input-sm" OnTextChanged="txtProductWidth_TextChanged"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <%--<input class="form-control input-sm" id="txtProductHeight" runat="server" autocomplete="off" />--%>
                                                                <asp:TextBox runat="server" ID="txtProductHeight_" AutoPostBack="true" CssClass="form-control input-sm" OnTextChanged="txtProductHeight_TextChanged"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <%-- <input class="form-control input-sm" id="txtProductLeng" runat="server" autocomplete="off" />--%>
                                                                <asp:TextBox runat="server" ID="txtProductLeng_" AutoPostBack="true" CssClass="form-control input-sm" OnTextChanged="txtProductLeng_TextChanged"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control input-sm" id="txtProductVolume" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control input-sm" id="txtPalletNo" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6 col-lg-6">
                                                            <div class="form-group">
                                                                <label for="txtOrderNo_GoodRecDetail" class="col-sm-3 control-label">Order No:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtOrder" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtReceiveNo_GoodRecDetail" class="col-sm-3 control-label">Receive No:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtReceive" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-3">
                                                                    <div class="checkbox">
                                                                        <label>
                                                                            <input type="checkbox" runat="server" id="CbNotDate" />Not Use Date
                                                                        </label>
                                                                    </div>

                                                                </div>
                                                                <label for="txtManufacturing_GoodRecDetail" class="col-sm-3 control-label">Manufacturing:</label>
                                                                <div class="col-sm-5">
                                                                    <asp:TextBox CssClass="form-control input-sm" ID="txtManufacturingDate" runat="server" placeholder="DD/MM/YYYY"> </asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtenderManufacturing_GoodRecDetail" runat="server" Enabled="True" TargetControlID="txtManufacturingDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtReceiveDate_GoodRecDetail" class="col-sm-3 control-label">Receive Date:</label>
                                                                <div class="col-sm-3">
                                                                    <asp:TextBox CssClass="form-control input-sm" ID="txtReceiveDate" runat="server" placeholder="DD/MM/YYYY"> </asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtenderReceiveDate_GoodRecDetail" runat="server" Enabled="True" TargetControlID="txtReceiveDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                                <label for="txtActualQTY_GoodRecDetail" class="col-sm-3 control-label">ETA/ARR Date</label>
                                                                <div class="col-sm-3">
                                                                    <%-- <input class="form-control" id="txtActualQTY" runat="server" value="0" />--%>
                                                                    <asp:TextBox CssClass="form-control input-sm" ID="txtExpectedDate" runat="server" placeholder="DD/MM/YYYY"> </asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtExpectedDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtQuantity1QTY_GoodRecDetail" class="col-sm-3 control-label">Quantity1 QTY:</label>
                                                                <div class="col-sm-4">
                                                                    <input class="form-control input-sm" id="txtQuantity" runat="server" autocomplete="off" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList ID="ddlUnit4" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6 col-lg-6">
                                                            <div class="form-group">
                                                                <label for="txtStatus_GoodRecDetail" class="col-sm-2 control-label">Status:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="dcbType" CssClass="form-control input-sm" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Goods Damage</asp:ListItem>
                                                                        <asp:ListItem>Goods Complete</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtType_GoodRecDetail" class="col-sm-2 control-label">Type:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="dcbTypeDamage" CssClass="form-control input-sm" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Q-FFL</asp:ListItem>
                                                                        <asp:ListItem>Q-CON</asp:ListItem>
                                                                        <asp:ListItem>Q-SC</asp:ListItem>
                                                                        <asp:ListItem>Q-SCRAP</asp:ListItem>
                                                                        <asp:ListItem>BackFill</asp:ListItem>
                                                                        <asp:ListItem>QC FZ AIR</asp:ListItem>
                                                                        <asp:ListItem>RETURN FZ AIR</asp:ListItem>
                                                                        <asp:ListItem>NG PART FZ AIR</asp:ListItem>
                                                                        <asp:ListItem>QC FZ SEA</asp:ListItem>
                                                                        <asp:ListItem>RETURN FZ SEA</asp:ListItem>
                                                                        <asp:ListItem>NG PART FZ SEA</asp:ListItem>

                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtExpiredDate_GoodRecDetail" class="col-sm-3 control-label">Expired Date:</label>
                                                                <div class="col-sm-7">
                                                                    <asp:TextBox CssClass="form-control input-sm" ID="txtExpiredDate" runat="server" placeholder="DD/MM/YYYY"> </asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtenderExpiredDate_GoodRecDetail" runat="server" Enabled="True" TargetControlID="txtExpiredDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">

                                                                <label for="txtEntryNo_GoodRecDetail" class="col-sm-2 control-label">EntryNo:</label>
                                                                <div class="col-sm-4">
                                                                    <input class="form-control input-sm" id="txtEntryNo" runat="server" autocomplete="off" />
                                                                </div>
                                                                <label for="txtEntryItemNo_GoodRecDetail" class="col-sm-3 control-label">EntryItemNo:</label>
                                                                <div class="col-sm-3">
                                                                    <input class="form-control input-sm" id="txtEntryItemNo" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtQuantity2_GoodRecDetail" class="col-sm-2 control-label">Quantity2:</label>
                                                                <div class="col-sm-4">
                                                                    <input class="form-control input-sm" id="txtWeightDetail" runat="server" autocomplete="off" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList ID="dcboUnitWeightDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 col-lg-12">
                                                        <div class="form-group">
                                                            <label for="txtCurrency_GoodRecDetail" class="col-sm-2">Currency:</label>
                                                            <label for="txtPriceForeign_GoodRecDetail" class="col-sm-2">Price Foreign:</label>
                                                            <label for="txtPriceBath_GoodRecDetail" class="col-sm-2">Price Bath:</label>
                                                            <label for="txtExchangeRate_GoodRecDetail" class="col-sm-2">ExchangeRate:</label>
                                                            <label for="txtAmount_GoodRecDetail" class="col-sm-2">Amount:</label>
                                                            <label for="txtBathAmount_GoodRecDetail" class="col-sm-2">Bath Amount:</label>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboCurrency" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="dcboCurrency_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <%--<input class="form-control input-sm" id="txtPriceForeigh" runat="server" autocomplete="off"  autofocus="autofocus"/>--%>
                                                                <asp:TextBox runat="server" CssClass="form-control input-sm" ID="txtPriceForeigh_" AutoPostBack="true" OnTextChanged="txtPriceForeigh_TextChanged" AutoComplete="off"></asp:TextBox>

                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control input-sm" id="txtPriceBath" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control input-sm" id="txtExchangeRate" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control input-sm" id="txtPriceForeighAmount" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control input-sm" id="txtPriceBathAmount" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <div class="col-sm-2">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rbShort" Text="Short Ship" onclick="EnableDisableTextBox();" GroupName="option2" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rbOver" Text="Over Ship" onclick="EnableDisableTextBox();" GroupName="option2" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <label for="txtInvoice_GoodRecDetail" class="col-sm-2 control-label">Invoice:</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="txtInvoice" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 col-sm-4">
                                                            <div class="form-group">
                                                                <label for="txtSupplier_GoodRecDetail" class="col-sm-4 control-label">Supplier:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtSupplier" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtDestination_GoodRecDetail" class="col-sm-4 control-label">Destination:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtDestination" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="txtBuyer_GoodRecDetail" class="col-sm-4 control-label">Buyer:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtBuyer" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtConsignee_GoodRecDetail" class="col-sm-4 control-label">Consignee:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtConsignee" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="txtExporter_GoodRecDetail" class="col-sm-4 control-label">Exporter:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtExporter" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtShippingMark_GoodRecDetail" class="col-sm-4 control-label">ShippingMark:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control input-sm" id="txtShippingMark" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <%-------------------------------------------------------End AFTER RIGHT FORM----------------------------------------------------------------%>
                                                    <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend></legend>
                                                            <asp:Repeater runat="server" ID="dgvItemDetail" OnItemDataBound="dgvItemDetail_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table id="taConfirm" class="table table-condensed">
                                                                        <th style="width: 2px">
                                                                            <asp:CheckBox runat="server" ID="chkAll_Item" Checked="false"></asp:CheckBox></th>
                                                                        <th style="width: 10px">LOTNo</th>
                                                                        <th style="width: 10px">WHSite</th>
                                                                        <th style="width: 10px">ENDCustomer</th>
                                                                        <th style="width: 10px">CustomerLOTNo</th>
                                                                        <th style="width: 5px">ItemNo</th>
                                                                        <th style="width: 10px">ProductCode</th>
                                                                        <th style="width: 10px">CustomerPN</th>
                                                                        <th style="width: 2px">Status</th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                        <td>
                                                                            <asp:CheckBox ID="chkLotNo" runat="server" AutoPostBack="true" OnCheckedChanged="chkLotNo_CheckedChanged"></asp:CheckBox></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblSite" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblEND" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblCus" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItem" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPc" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                        <%--        <AlternatingItemTemplate>
                                                                    <tr class="info">
                                                                        <td>
                                                                            <asp:CheckBox ID="chkLotNo" runat="server"></asp:CheckBox></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblSite" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblEND" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblCus" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItem" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPc" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </AlternatingItemTemplate>--%>
                                                                <FooterTemplate>
                                                                    <th>select</th>
                                                                    <th>LOTNo</th>
                                                                    <th>WHSite</th>
                                                                    <th>ENDCustomer</th>
                                                                    <th>CustomerLOTNo</th>
                                                                    <th>ItemNo</th>
                                                                    <th>ProductCode</th>
                                                                    <th>CustomerPN</th>
                                                                    <th>Status</th>
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
                                                    <%-----------------------------------------------------Start BUTTON FORM------------------------------------------------------------%>
                                                    <div class="col-lg-12 col-md-12 ">
                                                        <!-- form start -->
                                                        <div class="form-horizontal">
                                                            <%--<fieldset>  <legend>Job</legend>--%>
                                                            <div class="box-body">
                                                                <div class="col-md-12 col-md-offset-11">
                                                                    <div class="form-group">
                                                                        <div class="col-sm-2">
                                                                            <button type="submit" runat="server" class="btn btn-primary" id="btnReceive_GoodRecDetail" title="btnReceive_GoodRecDetail" onserverclick="btnReceive_GoodRecDetail_ServerClick">Receive</button>
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
                                                            <legend></legend>
                                                            <asp:Repeater runat="server" ID="dgvConfirmDetail" OnItemDataBound="dgvConfirmDetail_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table id="example20" class="table table-condensed">
                                                                        <th>LOTNo</th>
                                                                        <th>WHSite</th>
                                                                        <th>ENDCustomer</th>
                                                                        <th>CustomerLOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>ProductCode</th>
                                                                        <th>CustomerPN</th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblSite" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblEND" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblCus" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItem" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPc" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>                                                       
                                                                <FooterTemplate>
                                                                    <th>LOTNo</th>
                                                                    <th>WHSite</th>
                                                                    <th>ENDCustomer</th>
                                                                    <th>CustomerLOTNo</th>
                                                                    <th>ItemNo</th>
                                                                    <th>ProductCode</th>
                                                                    <th>CustomerPN</th>
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
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


                        <div role="tabpanel" class="tab-pane" id="putaway">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">
                                    <div class="col-lg-12 col-md-12">
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                <fieldset runat="server" id="putaway_">
                                                    <legend></legend>
                                                    <div class="col-md-4 col-sm-4">
                                                        <div class="form-group">
                                                            <label for="dcbSite1" class="col-sm-4 control-label">WH/Site:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="dcbSite1" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="dcbSite1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group " style="height: 34px;">
                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rdbManual" Text="Manual" OnCheckedChanged="rdbManual_CheckedChanged" GroupName="option1" AutoPostBack="true" />
                                                                    </label>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg5 col-md-5 col-sm-5">
                                                                <div class="radio">
                                                                    <label>
                                                                        <asp:RadioButton runat="server" ID="rdbAutoPallet" Text="Auto Pallet" OnCheckedChanged="rdbAutoPallet_CheckedChanged" GroupName="option1" AutoPostBack="true" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtmessages1_PutAway" class="col-sm-8 control-label">พื้นที่จัดเก็บ(ปริมาตร):</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="LblInValume" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtmessages2_PutAway" class="col-sm-8 control-label">Jobอื่นใช้พื้นที่จัดเก็บ(ปริมาตร):</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="LblUseValume" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="dcbLocation1" class="col-sm-4 control-label">WH/Location:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="dcbLocation1" CssClass="form-control input-sm" runat="server" DataTextField="LocationNo" DataValueField="LocationNo" OnSelectedIndexChanged="dcbLocation1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRemark_PutAway" class="col-sm-4 control-label">Remark:</label>
                                                            <div class="col-sm-8">
                                                                <textarea class="form-control input-sm" rows="1" id="txtRemarkP" placeholder="Remark" style="width: 563px;"></textarea>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtmessages3_PutAway" class="col-sm-8 control-label">พื้นที่จัดเก็บ(Pallet):</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="LblInpallet" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtmessages4_PutAway" class="col-sm-8 control-label">Jobอื่นใช้พื้นที่จัดเก็บ(Pallet):</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control input-sm" id="LblUsePallet" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtPalletNo_PutAway" class="col-sm-4 control-label">Pallet No:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="Txtpallet" runat="server" value="0" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend></legend>
                                                            <asp:Repeater runat="server" ID="dgvConfirmDetailbefor" OnItemDataBound="dgvConfirmDetailbefor_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table class="table table-condensed">
                                                                        <th style="width: 30px">LOTNo</th>
                                                                        <th style="width: 10px">WHSite</th>
                                                                        <th style="width: 30px">PalletNo</th>
                                                                        <th style="width: 10px">ENDCustomer</th>
                                                                        <th style="width: 10px">CustomerLOTNo</th>
                                                                        <th style="width: 5px">ItemNo</th>
                                                                        <th style="width: 20px">ProductCode</th>
                                                                        <th style="width: 10px">CustomerPN</th>
                                                                        <th style="width: 2px">ProductVolume</th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblSite" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPallet" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblEND" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblCus" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItem" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPc" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProductVolume" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <AlternatingItemTemplate>
                                                                    <tr class="info">
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblSite" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPallet" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblEND" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblCus" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItem" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPc" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProductVolume" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </AlternatingItemTemplate>
                                                                <FooterTemplate>
                                                                    <th style="width: 30px">LOTNo</th>
                                                                    <th>WHSite</th>
                                                                    <th style="width: 30px">PalletNo</th>
                                                                    <th>ENDCustomer</th>
                                                                    <th>CustomerLOTNo</th>
                                                                    <th>ItemNo</th>
                                                                    <th>ProductCode</th>
                                                                    <th>CustomerPN</th>
                                                                    <th>ProductVolume</th>
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
                                                    <%-------------------------------------------------------End JOB Form----------------------------------------------------------------%>
                                                    <div class="col-lg-12 col-md-12 ">
                                                        <!-- form start -->
                                                        <div class="form-horizontal">
                                                            <%--<fieldset>  <legend>Job</legend>--%>
                                                            <div class="box-body">
                                                                <div class="col-md-12">
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnPutAway" title="btnPutAway" onserverclick="btnPutAway_ServerClick">PutAway</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend></legend>
                                                            <asp:Repeater runat="server" ID="dgvConfirmDetailafter" OnItemDataBound="dgvConfirmDetailafter_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table class="table table-condensed">
                                                                       <th style="width: 30px">LOTNo</th>
                                                                        <th style="width: 10px">WHSite</th>
                                                                        <th style="width: 30px">PalletNo</th>
                                                                        <th style="width: 10px">WHLocation</th>
                                                                        <th style="width: 10px">CustomerLOTNo</th>
                                                                        <th style="width: 5px">ItemNo</th>
                                                                        <th style="width: 20px">ProductCode</th>
                                                                        <th style="width: 10px">CustomerPN</th>
                                                                        <th style="width: 2px">ProductVolume</th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                        <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblSite" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPallet" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLocation" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblCus" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItem" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPc" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProductVolume" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <AlternatingItemTemplate>
                                                                    <tr class="info">
                                                                         <td>
                                                                            <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblSite" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPallet" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLocation" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblCus" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblItem" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPc" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblPn" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProductVolume" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </AlternatingItemTemplate>
                                                                <FooterTemplate>
                                                                     <th style="width: 30px">LOTNo</th>
                                                                        <th style="width: 10px">WHSite</th>
                                                                        <th style="width: 30px">PalletNo</th>
                                                                        <th style="width: 10px">WHLocation</th>
                                                                        <th style="width: 10px">CustomerLOTNo</th>
                                                                        <th style="width: 5px">ItemNo</th>
                                                                        <th style="width: 20px">ProductCode</th>
                                                                        <th style="width: 10px">CustomerPN</th>
                                                                        <th style="width: 2px">ProductVolume</th>
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>
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
        <!-- /.content -->
        <!-- Modal JoB No-->
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
                                                    <table id="example1" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
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
        <!-- End Shipper Modal -->

        <!-- Modal ConsigneeCode-->
        <asp:Panel ID="plBroker" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upBroker" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvBroker" runat="server" OnItemDataBound="dgvBroker_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example2" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
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
                                                            <asp:LinkButton ID="lnkPartyCode_Broker" CssClass="btn bg-navy btn-sm" runat="server" OnClick="lnkPartyCode_Broker_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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
                                                    <table id="example3" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
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
        <!-- End Shipper Modal -->

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
                                                    <table id="example4" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
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
        <asp:Panel ID="plPrepire" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upPrepire" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvPrepire" runat="server" OnItemDataBound="dgvPrepire_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example5" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
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
        <asp:Panel ID="plConfirmGood" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upConfirmGood" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvConfirmGood" runat="server" OnItemDataBound="dgvConfirmGood_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example5" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
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
                                                        <asp:LinkButton ID="lnk_Confirm" CssClass="btn bg-navy btn-sm" runat="server" OnClick="lnk_Confirm_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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



        <!-- End Shipper Modal -->
        <asp:Panel ID="ProductCodePanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <%--<div class="modal fade" id="ProductCodeModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
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
                                            <asp:Repeater ID="dgvProduct" runat="server" OnItemCommand="dgvProduct_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example7" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
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
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy btn-sm" runat="server" CausesValidation="False" CommandName="SelectProductCode" CommandArgument='<%# Eval("ProductCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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
            <%--</div>--%>
        </asp:Panel>

        <asp:Panel ID="EndCustomerPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Delivery Code</h4>
                    </div>
                    <asp:UpdatePanel ID="EndCustomerUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="dgvCustomer" runat="server" OnItemDataBound="dgvCustomer_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example6" class="table table-condensed table-striped table-responsive" style="overflow: auto;">
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
                                                            <asp:LinkButton ID="LinkButton3" CssClass="btn bg-navy btn-sm" runat="server" OnClick="clickendcus_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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
        <script type="text/javascript">
            $(function () {
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "confirmgoodreceive";
                $('#Tabs a[href="#' + tabName + '"]').tab('show');
                $("#Tabs a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });
            });
        </script>

        <script>
            $(document).ready(function () {
                // CHECK-UNCHECK ALL CHECKBOXES IN THE REPEATER 
                // WHEN USER CLICKS THE HEADER CHECKBOX.
                $('table [id*=chkAll_Item]').click(function () {
                    if ($(this).is(':checked'))
                        $('table [id*=chkLotNo]').prop('checked', true)
                    else
                        $('table [id*=chkLotNo]').prop('checked', false)
                });

                // NOW CHECK THE HEADER CHECKBOX, IF ALL THE ROW CHECKBOXES ARE CHECKED.
                $('table [id*=chkLotNo]').click(function () {

                    var total_rows = $('table [id*=chkLotNo]').length;
                    var checked_Rows = $('table [id*=chkLotNo]:checked').length;

                    if (checked_Rows == total_rows)
                        $('table [id*=chkAll_Item]').prop('checked', true);
                    else
                        $('table [id*=chkAll_Item]').prop('checked', false);
                });
            });
        </script>
        <script type="text/javascript">
            function EnableDisableChkUseDate() {
                var status = document.getElementById('<%=rdbManual.ClientID%>').checked;
                if (status == true) {
                    document.getElementById('<%=dcbLocation.ClientID%>').disabled = true;
                           document.getElementById('<%=Txtpallet.ClientID%>').disabled = true;
                       } else if (status == false) {
                           document.getElementById('<%=dcbLocation.ClientID%>').disabled = false;
                    document.getElementById('<%=dcbLocation.ClientID%>').disabled = false;
                }
        }
        </script>

        <script type="text/javascript">
            function keyUP(txt) {
                alert(txt.value);
            }
        </script>


    </form>
</asp:Content>
