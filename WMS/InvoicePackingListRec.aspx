﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InvoicePackingListRec.aspx.vb" Inherits="WMS.InvoicePackingListRec" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Invoice/Packing List Rec
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Receive Process</a></li>
                <li><a href="InvoicePackingListRec.aspx"class="active">Invoice/Packing List Rec</a></li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">

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

                <div class="col-md-12">
                    <fieldset runat="server" id="Head_fieldset">
                        <h1></h1>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtCustomsDeclaretion" class="col-sm-3 control-label">Declaretion:</label>
                            <label for="txtNoDate" class="col-sm-3 control-label">No Date:</label>
                            <label for="txtInvoiceNo" class="col-sm-3 control-label">Invoice No:</label>
                            <div class="col-sm-3">
                                <div class="checkbox">
                              <label class="control-label">
                                   <input type="checkbox" runat="server" id="chkRCVDNo_BeforeTab" onclick="EnableDisablechkGen();" /> RCVD No
                              </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-3">
                                <input class="form-control input-sm" id="txtDeclaretion_BeforeTab" runat="server" autocomplete="off"/>
                            </div>
                            <div class="col-sm-3">                                            
                                 <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerNoDate_beforeTab" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                 </asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtenderNoDate_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerNoDate_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>
                            <div class="col-sm-3">
                                <input class="form-control input-sm" id="txtInvoiceNo_BeforeTab" runat="server" autocomplete="off"/>
                            </div>
                            <div class="col-sm-3">
                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnGen_BeforeTab" title="btnGen_BeforeTab" onserverclick="btnGen_BeforeTab_ServerClick">Gen</button>
                            </div>
                        </div>
                        </div>

                        <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtJobNo" class="col-sm-3 control-label">Job No:</label>
                            <label for="txtInvoiceDate" class="col-sm-3 control-label">Invoice Date:</label>
                            <label for="txtDeliveryDate" class="col-sm-3 control-label">Delivery Date:</label>
                            <label for="txtCustomsRefDate" class="col-sm-3 control-label">Customs Ref:</label>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-3">
                                <input class="form-control input-sm" id="txtJobNo_BeforeTab" runat="server" autocomplete="off"/>
                            </div>
                            <div class="col-sm-3">                                            
                                 <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerInvoiceDate_beforeTab" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                 </asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtenderInvoiceDate_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerInvoiceDate_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>
                            <div class="col-sm-3">                                            
                                 <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerDeliveryDate_beforeTab" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                 </asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtenderDeliveryDate_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerDeliveryDate_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>
                            <div class="col-sm-3">                                            
                                 <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerCustomsRefDate_beforeTab" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                 </asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtenderCustomsRefDate_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerCustomsRefDate_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>
                        </div>
                        </div>
                        <div class="form-group" style="height:22px;"></div>
                        <div class="form-group" style="height:22px;"></div>                    
                    </fieldset>
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
                                        <li class="active"><a href="#invoiceheader" aria-controls="invoiceheader" role="tab" data-toggle="tab">Invoice Header</a></li>
                                        <li><a href="#easjob" aria-controls="easjob" role="tab" data-toggle="tab">EAS Job</a></li>
                                        <li><a href="#itemdetail" aria-controls="itemdetail" role="tab" data-toggle="tab">Item Detail</a></li>
                                        <li><a href="#packinglist" aria-controls="packinglist" role="tab" data-toggle="tab">Packing List</a></li>
                                    </ul>
                                    <!-- Tab panes -->
                                    <div class="tab-content" style="padding-top: 20px">

                                        <%-----------------------------------------------------Start INVOICE HEADER-----------------------------------------------------------%>
                                        <!------- Import Goods ------->
                                        <div class="active tab-pane" id="invoiceheader">
                                            <fieldset runat="server" id="invoiceheader_fieldset">
                                            <!-- Post -->
                                            <div class="row">
                                                <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                                                <div class="col-md-6">
                                                    <!-- Horizontal Form -->

                                                    <!-- form start -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Shipper</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtShipperCode" class="col-sm-4 control-label">Shipper Code:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtShippercode" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <%--<button type="button" class="btn btn-block btn-primary btn-sm" data-toggle="modal" data-target="#ShipperModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNameShipper_Invoice" class="col-sm-4 control-label">Name English:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNameShipper_Invoice" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress1Shipper" class="col-sm-4 control-label">Address1:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress1Shipper" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress2Shipper" class="col-sm-4 control-label">Address2:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress2Shipper" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress3Shipper" class="col-sm-4 control-label">Address3:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress3Shipper" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress4Shipper" class="col-sm-4 control-label">Address4:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress4Shipper" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress5Shipper" class="col-sm-4 control-label">Address5:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress5Shipper" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtEmailShipper" class="col-sm-4 control-label">E-mail:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtEmailShipper" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>
                                                    <!-- /.box -->

                                                    <!-- general form Commodity -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Consignee</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtConsigneeCode_Invoice" class="col-sm-4 control-label">Consignee Code:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtConsigneeCode" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <%--<button type="button" class="btn btn-block btn-primary btn-sm" data-toggle="modal" data-target="#consigneeModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick1"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNameConsignee_Invoice" class="col-sm-4 control-label">Name English:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNameConsignee_Invoice" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress1Consignee" class="col-sm-4 control-label">Address1:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress1Consignee" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress2Consignee" class="col-sm-4 control-label">Address2:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress2Consignee" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress3Consignee" class="col-sm-4 control-label">Address3:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress3Consignee" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress4Consignee" class="col-sm-4 control-label">Address4:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress4Consignee" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress5Consignee" class="col-sm-4 control-label">Address5:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress5Consignee" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtEmailConsignee" class="col-sm-4 control-label">E-mail:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtEmailConsignee" runat="server" autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" style="height: 34px;"></div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>

                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Transport</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtTruckLicense_Invoice" class="col-sm-4 control-label">Truck License:</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList ID="ddlTruckLicense_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtDriverName_Invoice" class="col-sm-4 control-label">Driver Name:</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList ID="ddlDriverName_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
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
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Country</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtOriginCountry" class="col-sm-4 control-label">Origin Country:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlOriginCountry_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtOriginCountry_Invoice" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPurchaseCountry" class="col-sm-4 control-label">Purchase Country:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlPurchaseCountry_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtPurchaseCountry_Invoice" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtDestinationCountry" class="col-sm-4 control-label">Destination Country:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlDestinationCountry_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtDestinationCountry_Invoice" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTermOfPayment" class="col-sm-4 control-label">Term Of Payment:</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList ID="ddlTermOfPayment_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTerm" class="col-sm-4 control-label">Term:</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList ID="ddlTerm_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTotalNetWeight" class="col-sm-4 control-label">Total Net Weight:</label>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtTotalNetWeight_Invoice" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <label for="txtSumItemWeight" class="col-sm-4 control-label">Sum Item Weight:</label>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtSumItemWeight_Invoice" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTotalGrossWeight" class="col-sm-4 control-label">Total Gross Weight:</label>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtTotalGrossWeight_Invoice" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <label for="txtTotalVolume" class="col-sm-4 control-label">Total Volume:</label>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtTotalVolume_Invoice" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTotalQuantityPack" class="col-sm-4 control-label">TotalQuantityPack:</label>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtTotalQuantityPack_Invoice" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <label for="txtTotalQuantityINV" class="col-sm-4 control-label">TotalQuantityINV:</label>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtTotalQuantityINV_Invoice" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>
                                                    <!-- /.box -->

                                                    <!-- general form Commodity -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Currency</legend>
                                                            <div class="box-body">
                                                                <div class="form-group" style="height: 34px;">
                                                                    <label for="txtspace" class="col-sm-4 control-label"></label>
                                                                    <label for="txtCurrency" class="col-sm-3 control-label">Currency:</label>
                                                                    <label for="txtAmount" class="col-sm-2 control-label">Amount:</label>
                                                                    <label for="txtAmount" class="col-sm-2 control-label">Amount:</label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTotalInvoice" class="col-sm-4 control-label">Total Invoice:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlTotalInvoice_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtTotalInvoice1_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtTotalInvoice2_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtForwarding" class="col-sm-4 control-label">Forwarding:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlForwarding_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtForwarding1_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtForwarding2_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtFreight" class="col-sm-4 control-label">Freight:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlFreight_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtFreight1_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtFreight2_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtInsurance" class="col-sm-4 control-label">Insurance:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlInsurance_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtInsurance1_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtInsurance2_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPackingCharge" class="col-sm-4 control-label">Packing Charge:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlPackingCharge_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtPackingCharge1_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtPackingCharge2_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtHandingCharge" class="col-sm-4 control-label">Handing Charge:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlHandingCharge_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtHandingCharge1_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtHandingCharge2_invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtLandingCharge" class="col-sm-4 control-label">Landing Charge:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlLandingCharge_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtLandingCharge1_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtLandingCharge2_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTotalInvoiceTHB" class="col-sm-4 control-label">Total Invoice THB:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlTotalInvoiceTHB_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtTotalInvoiceTHB1_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <input class="form-control input-sm" id="txtTotalInvoiceTHB2_Invoice" runat="server" value="0.0" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>

                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Transmit</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <div class="col-sm-5">
                                                                        <div class="radio">
                                                                            <label>
                                                                                <%--<input type="radio" name="optionsRadios" runat="server" id="rdbDiffAmount1" value="option1" />Diff By Item-Amount--%>
                                                                                <asp:RadioButton runat="server" ID="rdbDiffAmount2" Text="Diff By Item-Amount" GroupName="option1"/>
                                                                            </label>                                                                            
                                                                        </div>
                                                                    </div>
                                                                    <label for="txtTransmitDate" class="col-sm-3 control-label">Transmit Date:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerTransmitDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                                                        </asp:TextBox>
                                                                        <asp:CalendarExtender ID="CalendarExtenderTransmitDate" runat="server" Enabled="True" TargetControlID="txtdatepickerTransmitDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-5">
                                                                        <div class="radio">
                                                                            <label>
                                                                                <%--<input type="radio" name="optionsRadios" runat="server" id="rdbDiffWeight1" value="option2"  />Diff By Item-Weight--%>
                                                                                <asp:RadioButton runat="server" ID="rdbDiffWeight2" Text="Diff By Item-Weight" GroupName="option1"/>
                                                                            </label>                                                                            
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-3">
                                                                        <div class="radio">
                                                                            <label>
                                                                                <%--<input type="radio" name="optionsRadios" runat="server" id="rdbNotifyParty1" value="option3" />Notify Party--%>
                                                                                <asp:RadioButton runat="server" ID="rdbNotifyParty2" Text="Notify Party" GroupName="option2"/>
                                                                            </label>                                                                            
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-3">
                                                                        <div class="radio">
                                                                            <label>
                                                                                <%--<input type="radio" name="optionsRadios" runat="server" id="rdbOnBehalfOf1" value="option4" />On Behalf Of--%>
                                                                                <asp:RadioButton runat="server" ID="rdbOnBehalfOf2" Text="On Behalf Of" GroupName="option2"/>
                                                                            </label>
                                                                        </div>
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
                                        <%-------------------------------------------------------------End INVOICE HEADER-------------------------------------------------------%>


                                        <%--------------------------------------------------------------Start EAS JOB----------------------------------------------------------%>
                                        <!-------- Export Goods --------->
                                        <div role="tabpanel" class="tab-pane" id="easjob">
                                            <fieldset runat="server" id="easjob_fieldset">
                                            <!-- Post -->
                                            <div class="row">

                                                <div class="col-lg-12 col-md-12">
                                                    <div class="form-group">
                                                        <div class="col-sm-1"></div>
                                                        <div class="checkbox col-sm-6">                                                            
                                                            <label>
                                                                <input type="checkbox" runat="server" id="chkEnable" onclick="EnableDisablechkEnable();" />
                                                                Enable On Behalf Of
                                                            </label>                                                            
                                                        </div>
                                                    </div>
                                                </div>

                                                <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                                                <div class="col-md-6">
                                                    <!-- Horizontal Form -->

                                                    <!-- form start -->
                                                    <div class="form-horizontal">
                                                        <fieldset runat="server" id="owner_easjob_fieldset">
                                                            <legend>Owner</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtOwnerCode_EASJOB" class="col-sm-4 control-label">Owner Code:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtOwnerCode_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick4"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNameOwner_EASJOB" class="col-sm-4 control-label">Name English:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNameOwner_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress1Owner_EASJOB" class="col-sm-4 control-label">Address1:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress1Owner_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress2Owner_EASJOB" class="col-sm-4 control-label">Address2:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress2Owner_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress3Owner_EASJOB" class="col-sm-4 control-label">Address3:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress3Owner_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress4Owner_EASJOB" class="col-sm-4 control-label">Address4:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress4Owner_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress5Owner_EASJOB" class="col-sm-4 control-label">Address5:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress5Owner_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtEmailOwner_EASJOB" class="col-sm-4 control-label">E-mail:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtEmailOwner_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" style="height: 174px;"></div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>
                                                    <!-- /.box -->

                                                    <!-- general form Commodity -->
                                                    <div class="form-horizontal">
                                                        <fieldset runat="server" id="shipto_easjob_fieldset">
                                                            <legend>Ship To</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtCustomerCode_EASJOB" class="col-sm-4 control-label">Customer Code:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtCustomerCode_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <%--<button type="button" class="btn btn-block btn-primary btn-sm" data-toggle="modal" data-target="#CustomerCodeModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick2"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNameCustomer_EASJOB" class="col-sm-4 control-label">Name English:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNameCustomer_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddressCustomer_EASJOB" class="col-sm-4 control-label">Address:</label>
                                                                    <div class="col-sm-8">
                                                                        <textarea class="form-control input-sm" id="txtAddressCustomer_EASJOB" rows="3" runat="server" name="txtRemarks" placeholder="Remarks ..." autocomplete="off"></textarea>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtEmailCustomer_EASJOB" class="col-sm-4 control-label">E-mail:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtEmailCustomer_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTelNoCustomer_EASJOB" class="col-sm-4 control-label">Tel No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtTelNoCustomer_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtFaxNoCustomer_EASJOB" class="col-sm-4 control-label">Fax No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtFaxNoCustomer_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtContractPersonCustomer_EASJOB" class="col-sm-4 control-label">Contract Person:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtContractPersonCustomer_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" style="height: 34px;"></div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>

                                                </div>
                                                <!--/.col (left) -->
                                                <%---------------------------------------------------------------End Left Form------------------------------------------------%>

                                                <!-- /.col -->

                                                <%-----------------------------------------------------Start Right Form--------------------------------------------------%>
                                                <div class="col-md-6">
                                                    <!-- Horizontal Form -->

                                                    <!-- form start -->
                                                    <div class="form-horizontal">
                                                        <fieldset runat="server" id="easinv_easjob_fieldset">
                                                            <legend>EAS</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtEASINV_EASJOB" class="col-sm-4 control-label">EAS INV REF No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtEASINV_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtEASLOT_EASJOB" class="col-sm-4 control-label">EAS LOT No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtEASLOT_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtReferenceLine_EASJOB" class="col-sm-4 control-label">Reference Line:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtReferenceLine_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTruckWaybill_EASJOB" class="col-sm-4 control-label">Truck Waybill:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtTruckWaybill_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtShipMode_EASJOB" class="col-sm-4 control-label">Ship Mode:</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList ID="ddlShipMode_EASJOB" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtDeliveryTerm_EASJOB" class="col-sm-4 control-label">Delivery Term:</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList ID="ddlDeliveryTerm_EASJOB" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtShippingMark_EASJOB" class="col-sm-4 control-label">Shipping Mark:</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList ID="ddlShippingMark_EASJOB" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCompany_EASJOB" class="col-sm-4 control-label">Company:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtCompany_EASJOB" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddressEAS_EASJOB" class="col-sm-4 control-label">Address:</label>
                                                                    <div class="col-sm-8">
                                                                        <textarea class="form-control input-sm" id="txtAddressEAS_EASJOB" rows="3" runat="server" name="txtRemarks" placeholder="Remarks ..." disabled="disabled" autocomplete="off"></textarea>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtRemarkEAS_EASJOB" class="col-sm-4 control-label">Remark:</label>
                                                                    <div class="col-sm-8">
                                                                        <textarea class="form-control input-sm" id="txtRemarkEAS_EASJOB" rows="2" runat="server" name="txtRemarks" placeholder="Remarks ..." autocomplete="off"></textarea>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTotal_EASJOB" class="col-sm-4 control-label">Total:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtTotal_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>
                                                    <!-- /.box -->

                                                    <!-- general form Commodity -->
                                                    <div class="form-horizontal">
                                                        <fieldset runat="server" id="billto_easjob_fieldset">
                                                            <legend>Bill To</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtCustomerCode_BillTo_EASJOB" class="col-sm-4 control-label">Customer Code:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtCustomerCode_BillTo_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <%--<button type="button" class="btn btn-block btn-primary btn-sm" data-toggle="modal" data-target="#CustomerCode_BillTo_EASJOB_Modal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick3"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNameCustomer_BillTo_EASJOB" class="col-sm-4 control-label">Name English:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNameCustomer_BillTo_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddressCustomer_BillTo_EASJOB" class="col-sm-4 control-label">Address:</label>
                                                                    <div class="col-sm-8">
                                                                        <%--<input class="form-control input-sm" id="Text3" runat="server" />--%>
                                                                        <textarea class="form-control input-sm" id="txtAddressCustomer_BillTo_EASJOB" rows="3" runat="server" name="txtRemarks" placeholder="Remarks ..." autocomplete="off"></textarea>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtEmailCustomer_BillTo_EASJOB" class="col-sm-4 control-label">E-mail:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtEmailCustomer_BillTo_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTelNoCustomer_BillTo_EASJOB" class="col-sm-4 control-label">Tel No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtTelNoCustomer_BillTo_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtFaxNoCustomer_BillTo_EASJOB" class="col-sm-4 control-label">Fax No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtFaxNoCustomer_BillTo_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtContractPersonCustomer_BillTo_EASJOB" class="col-sm-4 control-label">Contract Person:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtContractPersonCustomer_BillTo_EASJOB" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" style="height: 34px;"></div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>

                                                </div>
                                                <!--/.col (left) -->
                                                <%---------------------------------------------------------------End Right Form------------------------------------------------%>
                                            </div>
                                            <!-- /.post -->
                                            </fieldset>
                                        </div>
                                        <!-----/ Export Goods----->

                                        <%--------------------------------------------------------------END EAS JOB----------------------------------------------------------%>


                                        <%--------------------------------------------------------------Start ITEM DETAIL JOB----------------------------------------------------------%>
                                        <!-------- Export Goods --------->
                                        <div role="tabpanel" class="tab-pane" id="itemdetail">
                                            <fieldset runat="server" id="itemdetail_fieldset">

                                            <!-- Post -->
                                            <div class="row">

                                                <%------------------------------------------------------------------Start Head------------------------------------------------------------------------------%>
                                                <div class="col-lg-12 col-md-12 col-lg-offset-1">
                                                    <div class="form-horizontal">
                                                <asp:Panel ID="Repea1Panel" runat="server" >
                                                    <asp:UpdatePanel ID="Repea1UpdatePanel" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                <asp:Repeater ID="Repea1_Itemdetail" runat="server" OnItemCommand="Repea1_Itemdetail_ItemCommand">
                                                                    <HeaderTemplate>
                                                                        <table class="table table-striped table-condensed">
                                                                            <th>Select</th>
                                                                            <th>InvoiceNo</th>
                                                                            <th>ItemNo</th>
                                                                            <th>Product</th>
                                                                            <th>Productyear</th>
                                                                            <th>Brand</th>
                                                                            <th>NatureofTrn</th>
                                                                            <th>PurchaseCountry</th>
                                                                            <th>OriginCountry</th>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr class="success">
                                                                            <td class="text-center">
                                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectProductCode_Repea1_Itemdetail" CommandArgument='<%# Eval("InvoiceNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                                            </td>
                                                                            <td><asp:Label ID="Label8" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("ItemNo")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label1" runat="server" Text='<%# Bind("Product")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label2" runat="server" Text='<%# Bind("Productyear")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label5" runat="server" Text='<%# Bind("Brand")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label4" runat="server" Text='<%# Bind("NatureofTrn")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label6" runat="server" Text='<%# Bind("PurchaseCountry")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label7" runat="server" Text='<%# Bind("OriginCountry")%>'></asp:Label></td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <AlternatingItemTemplate>
                                                                        <tr class="info">
                                                                            <td class="text-center">
                                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectProductCode_Itemdetail" CommandArgument='<%# Eval("InvoiceNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                                            </td>
                                                                            <td><asp:Label ID="Label8" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("ItemNo")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label1" runat="server" Text='<%# Bind("Product")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label2" runat="server" Text='<%# Bind("Productyear")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label5" runat="server" Text='<%# Bind("Brand")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label4" runat="server" Text='<%# Bind("NatureofTrn")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label6" runat="server" Text='<%# Bind("PurchaseCountry")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label7" runat="server" Text='<%# Bind("OriginCountry")%>'></asp:Label></td>                                                                            
                                                                        </tr>
                                                                    </AlternatingItemTemplate>
                                                                    <FooterTemplate>
                                                                            <th>Select</th>
                                                                            <th>InvoiceNo</th>
                                                                            <th>ItemNo</th>
                                                                            <th>Product</th>
                                                                            <th>Productyear</th>
                                                                            <th>Brand</th>
                                                                            <th>NatureofTrn</th>
                                                                            <th>PurchaseCountry</th>
                                                                            <th>OriginCountry</th>                                                                            
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                                </asp:Panel>
                                            </div>
                                                    <div class="col-lg-4 col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtBrand_ItemDetail" class="col-sm-6 control-label">Brand:</label>

                                                            <label for="txtProductYear_ItemDetail" class="col-sm-6 control-label">Product Year:</label>

                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-6">
                                                                <asp:DropDownList ID="ddlBrand_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <%--<asp:DropDownList ID="ddlProductYear_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>--%>
                                                                <input class="form-control input-sm" id="txtProductYear_ItemDetail" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtNatureOfTRN_ItemDetail" class="col-sm-6 control-label">Nature Of trn:</label>

                                                            <label for="txtPurchaseCtry_ItemDetail" class="col-sm-6 control-label">Purchase Ctry:</label>

                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-6">
                                                                <asp:DropDownList ID="ddlNatureOfTRN_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <asp:DropDownList ID="ddlPurchaseCtry_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 col-md-4">
                                                        <div class="form-group">
                                                            <label for="txtOriginCtry_ItemDetail" class="col-sm-12 control-label">Origin Ctry:</label>

                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-6">
                                                                <asp:DropDownList ID="ddlOriginCtry_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%------------------------------------------------------------End Head------------------------------------------------------------%>

                                                <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                                                <div class="col-md-6">
                                                    <!-- Horizontal Form -->

                                                    <!-- form start -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Item</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtItemNo_ItemDetail" class="col-sm-3 control-label">Item No:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtItemNo_ItemDetail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <label for="txtCustomerPN_ItemDetail" class="col-sm-3 control-label">Customer P/N:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtCustomerPN_ItemDetail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">                                                                    
                                                                    <label for="txtProductCode_ItemDetail" class="col-sm-3 control-label">ProductCode:</label>
                                                                    <div class="col-sm-7">
                                                                        <input class="form-control input-sm" id="txtProductCode_ItemDetail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick5"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtInvQty_ItemDetail" class="col-sm-2 control-label">Inv Qty:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtInvQty_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <label for="txtUnit1_ItemDetail" class="col-sm-1 control-label">Unit:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlUnit1_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtUnit1_ItemDetail" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtWeight_ItemDetail" class="col-sm-2 control-label">Weight:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtWeight_ItemDetail" runat="server" value="0.0"  autocomplete="off"/>
                                                                    </div>
                                                                    <label for="txtUnit2_ItemDetail" class="col-sm-1 control-label">Unit:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlUnit2_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtUnit2_ItemDetail" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtQuantity_ItemDetail" class="col-sm-2 control-label">Quantity:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtQuantity_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <label for="txtUnit3_ItemDetail" class="col-sm-1 control-label">Unit:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlUnit3_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtUnit3_ItemDetail" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTariffCode_ItemDetail" class="col-sm-4 control-label">Tariff Code:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtTariffCode_ItemDetail" runat="server" autocomplete="off"  />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTariffSequence_ItemDetail" class="col-sm-4 control-label">Tariff Sequence:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtTariffSequence_ItemDetail" runat="server" autocomplete="off"  />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPONo_ItemDetail" class="col-sm-4 control-label">PO No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtPONo_ItemDetail" runat="server" autocomplete="off"  />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtDeclaretionLine_ItemDetail" class="col-sm-4 control-label">Declaretion Line:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtDeclaretionLine_ItemDetail" runat="server" autocomplete="off"  />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtFormulaNo_ItemDetail" class="col-sm-4 control-label">Formula No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtFormulaNo_ItemDetail" runat="server" autocomplete="off"  />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txt19BisTransferNo_ItemDetail" class="col-sm-4 control-label">19 Bis Transfer No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txt19BisTransferNo_ItemDetail" runat="server" autocomplete="off"  />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtRemark_ItemDetail" class="col-sm-4 control-label">Remark:</label>
                                                                    <div class="col-sm-8">
                                                                        <textarea class="form-control input-sm" id="txtRemark_ItemDetail" rows="3" runat="server" name="txtRemarks" style="height: 34px;" placeholder="Remarks ..." autocomplete="off"></textarea>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>
                                                    <!-- /.box -->

                                                    <!-- general form Commodity -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Currency</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtSpace_ItemDetail" class="col-sm-4 control-label"></label>
                                                                    <label for="txtCurrency_ItemDetail" class="col-sm-4 control-label">Currency:</label>
                                                                    <label for="txtForeign_ItemDetail" class="col-sm-4 control-label">Foreign Amount:</label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtForwarding_ItemDetail" class="col-sm-4 control-label">Forwarding:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlForwarding_Currency_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtForwarding_ForeignAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtFreight_ItemDetail" class="col-sm-4 control-label">Freight:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlFreight_Currency_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtFreight_ForeignAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtInsurance_ItemDetail" class="col-sm-4 control-label">Insurance:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlInsurance_Currency_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtInsurance_ForeignAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPackageCharge_ItemDetail" class="col-sm-4 control-label">PackageCharge:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlPackageCharge_Currency_ItemDetail1" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtPackageCharge_ForeignAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtForeignInlandFreidge_ItemDetail" class="col-sm-4 control-label">Foreign Inland Freidge:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlForeignInlandFreidge_Currency_ItemDetail1" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtForeignInlandFreidge_ForeignAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtLandingCharge_ItemDetail" class="col-sm-4 control-label">Landing Charge:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlLandingCharge_Currency_ItemDetail1" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtLandingCharge_ForeignAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtOtherCharge_ItemDetail" class="col-sm-4 control-label">Other Charge:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlOtherCharge_Currency_ItemDetail1" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtOtherCharge_ForeignAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>

                                                </div>
                                                <!--/.col (left) -->
                                                <%---------------------------------------------------------------End Left Form------------------------------------------------%>

                                                <!-- /.col -->

                                                <%-----------------------------------------------------Start Right Form--------------------------------------------------%>
                                                <div class="col-md-6">
                                                    <!-- Horizontal Form -->

                                                    <!-- form start -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Item</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtProductDesc_ItemDetail" class="col-sm-4 control-label">Product Desc:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtProductDesc_ItemDetail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtOwnerPN_ItemDetail" class="col-sm-4 control-label">Owner P/N:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtOwnerPN_ItemDetail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCurrency_ItemDetail" class="col-sm-3 control-label">Currency:</label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddlCurrency_ItemDetail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <label for="txtExchangeRate_ItemDetail" class="col-sm-3 control-label">Exchange Rate:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtExchangeRate_ItemDetail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPriceForeign_ItemDetail" class="col-sm-3 control-label">Price Foreign:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtPriceForeign_ItemDetail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <label for="txtAmountForeign_ItemDetail" class="col-sm-3 control-label">Amount:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtAmountForeign_ItemDetail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPriceBath_ItemDetail" class="col-sm-3 control-label">Price Bath:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtPriceBath_ItemDetail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <label for="txtAmountBath_ItemDetail" class="col-sm-3 control-label">Amount:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtAmountBath_ItemDetail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtStatisticalCode_ItemDetail" class="col-sm-4 control-label">Statistical Code:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtStatisticalCode_ItemDetail" runat="server" autocomplete="off"  />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtProductAttribute1_ItemDetail" class="col-sm-4 control-label">Product Attribute1:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtProductAttribute1_ItemDetail" runat="server" autocomplete="off"  />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPriceIncreaseForreign_ItemDetail" class="col-sm-4 control-label">Price Increase Forreign:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtPriceIncreaseForreign_ItemDetail" runat="server" autocomplete="off" value="0.0" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPriceIncreaseBath_ItemDetail" class="col-sm-4 control-label">Price Increase Bath:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtPriceIncreaseBath_ItemDetail" runat="server" autocomplete="off" value="0.0" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtBOILicenseNo_ItemDetail" class="col-sm-4 control-label">BOI License No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtBOILicenseNo_ItemDetail" runat="server" autocomplete="off"  />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtBondFormulaNo_ItemDetail" class="col-sm-4 control-label">Bond Formula No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtBondFormulaNo_ItemDetail" runat="server" autocomplete="off"  />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" style="height: 34px;"></div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>
                                                    <!-- /.box -->

                                                    <!-- general form Commodity -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Currency</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtExchangeRate_ItemDetail" class="col-sm-4 control-label">Exchange Rate:</label>
                                                                    <label for="txtBath_ItemDetail" class="col-sm-4 control-label">Bath Amount:</label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtForwarding_Exchange_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtForwarding_BathAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtFreight_Exchange_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtFreight_BathAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtInsurance_Exchange_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtInsurance_BathAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtPackageCharge_Exchange_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtPackageCharge_BathAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtForeignInlandFreidge_Exchange_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtForeignInlandFreidge_BathAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtLandingCharge_Exchange_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtLandingCharge_BathAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtOtherCharge_Exchange_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtOtherCharge_BathAmount_ItemDetail" runat="server" value="0.0" autocomplete="off" />
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>
                                                </div>
                                                <!--/.col (left) -->
                                                <%---------------------------------------------------------------End Right Form------------------------------------------------%>

                                                <div class="col-lg-12 col-md-12 ">
                                                    <!-- form start -->
                                                    <div class="form-horizontal">

                                                        <div class="box-body">
                                                            <div class="box-footer text-right">
                                                                <div class="text-center">
                                                                    <div class="form-group">

                                                                        <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnAddNewItem_ItemDetail" title="btnAddNewItem_ItemDetail" onserverclick="btnAddNewItem_ItemDetail_ServerClick">AddNewItem</button>

                                                                        <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnSaveModify_ItemDetail" title="btnSaveModify_ItemDetail" onserverclick="btnSaveModify_ItemDetail_ServerClick">SaveModify</button>

                                                                        <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnDelete_ItemDetail" title="btnDelete_ItemDetail" onserverclick="btnDelete_ItemDetail_ServerClick">Delete</button>

                                                                        <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnCreatePacking_ItemDetail" title="btnCreatePacking_ItemDetail" onserverclick="btnCreatePacking_ItemDetail_ServerClick">Create Packing</button>

                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <!-- /.box-body -->
                                                        </div>
                                                        <!-- /.box-header -->

                                                    </div>
                                                    <!--/.col-lg-6 col-md-6 stockqty--->

                                                </div>

                                            </div>
                                            <!-- /.post -->
                                            </fieldset>
                                        </div>
                                        <!-----/ Export Goods----->

                                        <%--------------------------------------------------------------END ITEM DETAIL----------------------------------------------------------%>


                                        <%--------------------------------------------------------------Start Packing List----------------------------------------------------------%>
                                        <!-------- Export Goods --------->
                                        <div role="tabpanel" class="tab-pane" id="packinglist">
                                            <fieldset runat="server" id="packinglist_fieldset">
                                            <!-- Post -->
                                            <div class="row">

                                                <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                                                <div class="col-md-6">
                                                    <!-- Horizontal Form -->

                                                    <!-- form start -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Product</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtProductCode_PACKINGLIST" class="col-sm-4 control-label">Produce Code:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtProductCode_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick5"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtProductDesc_PACKINGLIST" class="col-sm-4 control-label">Produce Desc:</label>
                                                                    <div class="col-sm-8">
                                                                        <textarea class="form-control input-sm" id="txtProductDesc_PACKINGLIST" rows="1" runat="server" name="txtProductDesc_PACKINGLIST" style="height: 34px;" placeholder="Desc ..." autocomplete="off"></textarea>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCustomerPN_PACKINGLIST" class="col-sm-4 control-label">Customer P/N:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtCustomerPN_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtOriginCtry_PACKINGLIST" class="col-sm-4 control-label">Origin Crty:</label>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtOriginCtry_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick8"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtOriginCtry2_PACKINGLIST" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNumberOfPLT_PACKINGLIST" class="col-sm-4 control-label">Number Of PLT:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtNumberOfPLT_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick6"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPLTQuantity_PACKINGLIST" class="col-sm-4 control-label">PLT Quantity:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtPLTQuantity_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNetWeight_PACKINGLIST" class="col-sm-4 control-label">Net Weight:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtNetWeight_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick7"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtVolumeCBM_PACKINGLIST" class="col-sm-4 control-label">Volume (CBM):</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtVolumeCBM_PACKINGLIST" runat="server" value="0.000" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtMeasurement_PACKINGLIST" class="col-sm-4 control-label">Measurement:</label>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtMeasurement_Width_PACKINGLIST" runat="server" placeholder="Width" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtMeasurement_Height_PACKINGLIST" runat="server" placeholder="Height" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtspace" class="col-sm-4 control-label"></label>
                                                                    <div class="col-sm-4">
                                                                        <div class="radio">
                                                                            <label>
                                                                                <asp:RadioButton runat="server" ID="rdbCM" Text="CM" onclick="EnableDisableTextBox();" GroupName="option4" />
                                                                            </label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-sm-4">
                                                                        <div class="radio">
                                                                            <label>
                                                                                <asp:RadioButton runat="server" ID="rdbInch" Text="Inch" onclick="EnableDisableTextBox();" GroupName="option4" />
                                                                            </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>
                                                    <!-- /.box -->

                                                    <!-- general form Commodity -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Amount</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtPLTNetAmount_PACKINGLIST" class="col-sm-4 control-label">PLT Net Amount:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtPLTNetAmount_PACKINGLIST" runat="server" value="0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCTNNetAmount_PACKINGLIST" class="col-sm-4 control-label">CTN Net Amount:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtCTNNetAmount_PACKINGLIST" runat="server" value="0" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTotal_PACKINGLIST" class="col-sm-4 control-label">Total:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtTotal_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>

                                                </div>
                                                <!--/.col (left) -->
                                                <%---------------------------------------------------------------End Left Form------------------------------------------------%>

                                                <!-- /.col -->

                                                <%-----------------------------------------------------Start Right Form--------------------------------------------------%>
                                                <div class="col-md-6">
                                                    <!-- Horizontal Form -->

                                                    <!-- form start -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Product</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtspace_PACKINGLIST" class="col-sm-4 control-label"></label>
                                                                    <div class="col-sm-8">
                                                                        <button type="submit" runat="server" class="btn btn-primary btn-sm" id="NetWeight_PACKINGLIST" title="NetWeight_PACKINGLIST" onserverclick="NetWeight_PACKINGLIST_ServerClick">Sum Net(W)</button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" style="height: 34px;"></div>
                                                                <div class="form-group">
                                                                    <label for="txtOwnerPN_PACKINGLIST" class="col-sm-4 control-label">Owner P/N:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtOwnerPN_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtUnit_PACKINGLIST" class="col-sm-4 control-label">Unit:</label>
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlUnit_PACKINGLIST" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtUnit_PACKINGLIST" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtTotalCTN_PACKINGLIST" class="col-sm-4 control-label">Total CTN:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtTotalCTN_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtProductQuantity_PACKINGLIST" class="col-sm-4 control-label">Product Quantity:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtProductQuantity_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick9"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>                                                                    
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtGrossWeight_PACKINGLIST" class="col-sm-4 control-label">Gross Weight:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtGrossWeight_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick10"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div> 
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPONo_PACKINGLIST" class="col-sm-4 control-label">PO No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtPONo_PACKINGLIST" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <input class="form-control input-sm" id="txtLenght_PACKINGLIST" runat="server" placeholder="Lenght"  autocomplete="off"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" style="height: 27px;"></div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>
                                                    <!-- /.box -->

                                                    <!-- general form Commodity -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Amount</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlPLTNetAmount_PACKINGLIST" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtPLTNetAmount2_PACKINGLIST" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <asp:DropDownList ID="ddlCTNNetAmount_PACKINGLIST" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtCTNNetAmount2_PACKINGLIST" runat="server" autocomplete="off" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">                                                                    
                                                                    <div class="col-sm-3">
                                                                        <input class="form-control input-sm" id="txtRowNo_PACKINGLIST" runat="server" autocomplete="off" disabled="disabled" visible="false" />
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>

                                                </div>
                                                <!--/.col (left) -->
                                                <%---------------------------------------------------------------End Right Form------------------------------------------------%>
                                                <div class="col-lg-12 col-sm-12 col-lg-offset-7">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <div class="checkbox col-sm-2">
                                                                <label>
                                                                    <input type="checkbox" runat="server" id="chkCopyToDetail" />Copy To Detail
                                                                </label>
                                                            </div>
                                                            <%--<div class="col-sm-3">--%>
                                                            <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnAddNewItem_PACKINGLIST" title="btnAddNewItem_PACKINGLIST" onserverclick="btnAddNewItem_PACKINGLIST_ServerClick">AddNewItem</button>
                                                            <%--</div>--%>
                                                            <%--<div class="col-sm-3">--%>
                                                            <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnSaveModify_PACKINGLIST" title="btnSaveModify_PACKINGLIST" onserverclick="btnSaveModify_PACKINGLIST_ServerClick">SaveModify</button>
                                                            <%--</div>--%>
                                                            <%--<div class="col-sm-3">--%>
                                                            <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnDelete_PACKINGLIST" title="btnDelete_PACKINGLIST" onserverclick="btnDelete_PACKINGLIST_ServerClick">Delete</button>
                                                            <%--</div>--%>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <!-- /.post -->
                                            </fieldset>
                                        </div>
                                        <!-----/ Export Goods----->

                                        <%--------------------------------------------------------------END Packing List----------------------------------------------------------%>


                                    </div>
                                    <!-- /.tab-pane -->
                                </div>
                                <!-- /.tab-pane -->
                                <asp:HiddenField ID="TabName" runat="server" />                    
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </section>
        <!-- /.content -->
        
        <!-- Shipper Modal -->
        <!-- Modal -->
        <asp:Panel ID="ShipperPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
        <%--<div class="modal fade" id="ShipperModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Select Shipper Code</h4>
              </div>
                    <asp:UpdatePanel ID="ShipperUpdatePanel" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
              <div class="modal-body">
                <section class="content">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 " style="overflow:auto;">
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example1" class="table table-striped table-condensed table-responsive" style="overflow:auto;">
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
                                                 <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectShipper" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress3" runat="server" Text='<%# Bind("PartyAddressCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress2" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>                         
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
            <%--</div>--%>
            </asp:Panel>
        <!-- End Shipper Modal -->

        <!-- Consignee Modal -->
        <!-- Modal -->
        <asp:Panel ID="ConsigneePanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
        <%--<div class="modal fade" id="consigneeModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
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
                        <div class="col-lg-12 col-md-12 " style="overflow:auto;">
                            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example2" class="table table-striped table-condensed table-responsive" style="overflow:auto;">
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
                                                 <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectConsignee" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress3" runat="server" Text='<%# Bind("PartyAddressCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress2" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>
                                            
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
            <%--</div>--%>
            </asp:Panel>
        <!-- End Consignee Modal -->

                <!-- CustomerCode Modal -->
        <!-- Modal -->
        <asp:Panel ID="CustomerCodePanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
        <%--<div class="modal fade" id="CustomerCodeModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Select Ship To</h4>
              </div>
                    <asp:UpdatePanel ID="CustomerCodeUpdatePanel" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
              <div class="modal-body">
                <section class="content">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 " style="overflow:auto;">
                            <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater3_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example3" class="table table-striped table-condensed table-responsive" style="overflow:auto;">
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
                                                 <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectCustomerCode" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress3" runat="server" Text='<%# Bind("PartyAddressCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress2" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>
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
            <%--</div>--%>
            </asp:Panel>
        <!-- End CustomerCode Modal -->
                        <!-- CustomerCode_BillTo_EASJOB Modal -->
        <!-- Modal -->
        <asp:Panel ID="CustomerCode_BillToPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
        <%--<div class="modal fade" id="CustomerCode_BillTo_EASJOB_Modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Select Bill To</h4>
              </div>
                    <asp:UpdatePanel ID="CustomerCode_BillToUpdatePanel" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
              <div class="modal-body">
                <section class="content">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 " style="overflow:auto;">
                            <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="Repeater4_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example4" class="table table-striped table-condensed table-responsive" style="overflow:auto;">
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
                                                 <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectCustomerCode_BillTo" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress3" runat="server" Text='<%# Bind("PartyAddressCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress2" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>
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
            <%--</div>--%>
            </asp:Panel>
        <!-- End CustomerCode_BillTo_EASJOB Modal -->   

        <!-- ProductCode_Itemdetail Modal -->
        <!-- Modal -->
        <asp:Panel ID="ProductCode_ItemdetailPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
        <%--<div class="modal fade" id="CustomerCode_BillTo_EASJOB_Modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Select Product Code</h4>
              </div>
                    <asp:UpdatePanel ID="ProductCode_ItemdetailUpdatePanel" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
              <div class="modal-body">
                <section class="content">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 " style="overflow:auto;">
                            <asp:Repeater ID="Repeater5" runat="server" OnItemCommand="Repeater5_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example5" class="table table-striped table-condensed table-responsive" style="overflow:auto;">
                                            <thead>
                                                <tr>
                                                    <th>Select</th>
                                                    <th>ProductCode</th>
                                                    <th>ExpDesc1</th>
                                                    <th>EndUserPart</th>
                                                    <th>CustomerPart</th>
                                                    <th>ExpProductAttribute1</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                 <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectProductCode_Itemdetail" CommandArgument='<%# Eval("ProductCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("ProductCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress3" runat="server" Text='<%# Bind("ExpDesc1")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("EndUserPart")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("CustomerPart")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress2" runat="server" Text='<%# Bind("ExpProductAttribute1")%>'></asp:Label></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                    <th>Select</th>
                                                    <th>ProductCode</th>
                                                    <th>ExpDesc1</th>
                                                    <th>EndUserPart</th>
                                                    <th>CustomerPart</th>
                                                    <th>ExpProductAttribute1</th>
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
        <!-- End CustomerCode_BillTo_EASJOB Modal -->   

                <script type="text/javascript">
                    $(function () {
                        var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "invoiceheader";
                        $('#Tabs a[href="#' + tabName + '"]').tab('show');
                        $("#Tabs a").click(function () {
                            $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                        });
                    });
                </script>

                <script type="text/javascript">
                    function EnableDisablechkEnable() {
                        var status = document.getElementById('<%=chkEnable.ClientID%>').checked;
                        if (status == true) {
                            document.getElementById('<%=owner_easjob_fieldset.ClientID%>').disabled = true;
                            document.getElementById('<%=shipto_easjob_fieldset.ClientID%>').disabled = false;
                            document.getElementById('<%=easinv_easjob_fieldset.ClientID%>').disabled = false;
                            document.getElementById('<%=billto_easjob_fieldset.ClientID%>').disabled = false;
                        } else if (status == false) {
                            document.getElementById('<%=owner_easjob_fieldset.ClientID%>').disabled = true;
                            document.getElementById('<%=shipto_easjob_fieldset.ClientID%>').disabled = true;
                            document.getElementById('<%=easinv_easjob_fieldset.ClientID%>').disabled = true;
                            document.getElementById('<%=billto_easjob_fieldset.ClientID%>').disabled = true;
                        }
                }
                </script> 

                <script type="text/javascript">
                    function EnableDisablechkGen() {
                        var status = document.getElementById('<%=chkRCVDNo_BeforeTab.ClientID%>').checked;
                        if (status == true) {
                            document.getElementById('<%=btnGen_BeforeTab.ClientID%>').disabled = false;
                        } else if (status == false) {
                            document.getElementById('<%=btnGen_BeforeTab.ClientID%>').disabled = true;
                        }
                }
                </script>
    </form>
</asp:Content>