<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomsInvoice.aspx.vb" Inherits="WMS.CustomsInvoice" EnableEventValidation="false" EnableViewState="true" MasterPageFile="~/Home.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ OutputCache Duration="60" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="360000"></asp:ScriptManager>
        <section class="content-header">
            <h1>Export Customs Invoice & Packing List
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Issue Process</a></li>
                <li><a class="active">Customs Invoice</a></li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                <!-- left column -->
                <div class="col-lg-12 col-md-12">

                    <!-- general form elements -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <div class="form-group">
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
                                        <button type="button" class=" btn btn-app" runat="server" id="btnSaveNew">
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
                            <!-- /.box-header -->
                            <div class="form-horizontal">
                                <div class="box-body">
                                    <div class="col-md-12 col-lg-12">
                                        <fieldset>
                                            <legend></legend>
                                            <div class="form-group">
                                                <div class="col-md-3">
                                                    <label for="txtReferenceNo">Customs Declaration No</label>
                                                    <input class="form-control" id="txtReferenceNo" runat="server" autocomplete="off" />
                                                </div>
                                                <div class="col-md-3">
                                                    <label for="txtTruckWayBill">Date</label>
                                                    <div class="input-group date col-md-12">
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-calculator"></i>
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="CustomsConfirmDate" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                        </asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="CustomsConfirmDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label for="txtInvoiceNo">Invoice No</label>
                                                    <div class="form-group">
                                                        <div class="col-md-9">
                                                            <input class="form-control" id="txtInvoiceNo" runat="server" autocomplete="off" />
                                                        </div>
                                                        <div class="col-md-3">
                                                            <button runat="server" class="btn btn-primary btn-block" type="button" id="btnInvoice" onserverclick="btnInvoice_ServerClick"><i class="fa fa-search"></i></button>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <label for="txtPurechaseOrderNo">JOB No</label>
                                                    <input class="form-control" id="txtPurechaseOrderNo" runat="server" autocomplete="off" />
                                                </div>

                                            </div>

                                            <div class="form-group">
                                                <div class="col-md-3">
                                                    <label for="txtTruckWayBill">Invoice Date</label>
                                                    <div class="input-group date col-md-12">
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-calculator"></i>
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="dtpInvoiceDate" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                        </asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="dtpInvoiceDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label for="txtTruckWayBill">Delivery Date</label>
                                                    <div class="input-group date col-md-12">
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-calculator"></i>
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="dtpDeliveryDate" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                        </asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="dtpDeliveryDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">

                                                    <label for="txtTruckWayBill">Customs Ref. Date</label>
                                                    <div class="input-group date col-md-12">
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-calculator"></i>
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="dtpReferenceDate" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                        </asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" TargetControlID="dtpReferenceDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                    </div>
                                                </div>
                                            </div>
                                        </fieldset>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-------- ./ row --------->
            <div class="panel panel-default">
                <div id="Tabs" role="tabpanel" class="nav-tabs-custom">
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li><a href="#header" aria-controls="header" role="tab" data-toggle="tab" class="active">Invoice Header</a></li>
                        <li><a href="#job" aria-controls="job" role="tab" data-toggle="tab">EAS JOB</a></li>
                        <li><a href="#deetail" aria-controls="deetail" role="tab" data-toggle="tab">Item Detail</a></li>
                        <li><a href="#list" aria-controls="list" role="tab" data-toggle="tab">Packing List</a></li>
                    </ul>
                    <!-- Tab panes -->
                    <div class="tab-content" style="padding-top: 10px">

                        <div role="tabpanel" class="tab-pane active" id="header">
                            <div class="post">
                                <div class="row margin-bottom">

                                    <div class="col-lg-12 col-md-8">
                                        <!-- form start -->
                                        <div class="form-horizontal ">

                                            <div class="box-body">
                                                <fieldset runat="server" id="header_">
                                                    <legend></legend>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="col-md-6 col-lg-6">

                                                            <div class="form-group">
                                                                <label for="txtExporterCode" class="col-sm-3 control-label">Shipper Code</label>
                                                                <div class="col-md-6">
                                                                    <input class="form-control pull-right" id="txtExporterCode" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <button runat="server" class="btn btn-primary btn-block" type="button" id="btnShipper" onserverclick="btnShipper_ServerClick"><i class="fa fa-search"></i></button>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtExportEng" class="col-sm-3 control-label">Name (Eng)</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtExportEng" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtStreet_Number" class="col-sm-3 control-label">Address1</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtStreet_Number" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtDistrict" class="col-sm-3 control-label">Address2</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtDistrict" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtSubProvince" class="col-sm-3 control-label">Address3</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtSubProvince" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtProvince" class="col-sm-3 control-label">Address4</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtProvince" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtPostCode" class="col-sm-3 control-label">Address5</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtPostCode" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCompensateCode" class="col-sm-3 control-label">Email</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtCompensateCode" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-6 col-lg-6">

                                                            <div class="form-group">
                                                                <label for="dcboCountry" class="col-sm-4 control-label">Origin Country</label>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="dcboCountry" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code" OnSelectedIndexChanged="dcboCountry_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <%-- <input class="form-control pull-right" id="txtNotifyParty" runat="server" type="text" />--%>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <input class="form-control pull-right" id="txtCountry" runat="server" type="text" autocomplete="off" disabled="disabled" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="dcboPurchaseCountry" class="col-sm-4 control-label">Purchase Country</label>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="dcboPurchaseCountry" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code" OnSelectedIndexChanged="dcboPurchaseCountry_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <%-- <input class="form-control pull-right" id="txtCarLicense" runat="server" type="text" />--%>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <input class="form-control pull-right" id="txtPurchaseCountry" runat="server" type="text" autocomplete="off" disabled="disabled" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="cboDestinationCountry" class="col-sm-4 control-label">Destination Country</label>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="cboDestinationCountry" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code" OnSelectedIndexChanged="cboDestinationCountry_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <%-- <input class="form-control pull-right" id="txtCarLicense" runat="server" type="text" />--%>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <input class="form-control pull-right" id="txtDestinationCountry" runat="server" type="text" autocomplete="off" disabled="disabled" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="dcboTermofPayment" class="col-sm-4 control-label">Term of Payment</label>
                                                                <div class="col-md-8">
                                                                    <asp:DropDownList ID="dcboTermofPayment" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="dcboTerm" class="col-sm-4 control-label">Term</label>
                                                                <div class="col-md-8">
                                                                    <asp:DropDownList ID="dcboTerm" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtTotalNetWeight" class="col-sm-4 control-label">Total Net weight</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtTotalNetWeight" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtSumItemWeight" class="col-sm-4 control-label">Sum Item Weight</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtSumItemWeight" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtTotalGrossWeight" class="col-sm-4 control-label">Total Gross Weight</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtTotalGrossWeight" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtVolumAmount" class="col-sm-4 control-label">Total Volume</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtVolumAmount" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtTotalQuantity" class="col-sm-4 control-label">TotalQuantityPack</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtTotalQuantity" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtTotalQuantityINV" class="col-sm-4 control-label">TotalQuantityINV</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtTotalQuantityINV" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="col-md-6">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <div class="form-group">
                                                                    <label for="txtConsigneeCode" class="col-sm-4 control-label">Consignee Code</label>
                                                                    <div class="col-md-6">
                                                                        <input class="form-control pull-right" id="txtConsigneeCode" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-md-2">
                                                                        <button runat="server" class="btn btn-primary btn-block" type="button" id="btnSCon" onserverclick="btnSCon_ServerClick"><i class="fa fa-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeEng" class="col-sm-4 control-label">Name (Eng)</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeEng" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label for="txtConsignneeStreet_Number" class="col-sm-4 control-label">Address1</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeStreet_Number" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeDistrict" class="col-sm-4 control-label">Address2</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeDistrict" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeSubProvince" class="col-sm-4 control-label">Address3</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeSubProvince" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeProvince" class="col-sm-4 control-label">Address4</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeProvince" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeProvince" class="col-sm-4 control-label">Address5</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneePostCode" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeEMail" class="col-sm-4 control-label">Email</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeEMail" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" style="height: 34px;">
                                                                </div>

                                                            </fieldset>

                                                            <div class="form-horizontal">
                                                                <fieldset>
                                                                    <legend>Transport</legend>
                                                                    <div class="box-body">
                                                                        <div class="form-group">
                                                                            <label for="txtTruckLicense_Invoice" class="col-sm-4 control-label">Truck License:</label>
                                                                            <div class="col-sm-8">
                                                                                <asp:DropDownList ID="dcboCarLicense" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label for="txtDriverName_Invoice" class="col-sm-4 control-label">Driver Name:</label>
                                                                            <div class="col-sm-8">
                                                                                <asp:DropDownList ID="dcboDriverName" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </fieldset>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-6">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <div class="form-group">
                                                                    <label for="txtspace" class="col-sm-2 control-label"></label>
                                                                    <label for="txtCurrency" class="col-sm-3 control-label">Currency:</label>
                                                                    <label for="txtAmount" class="col-sm-3 control-label">Amount:</label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="dcboTotalInvoice" class="col-sm-3 control-label">Total Invoice</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="dcboTotalInvoice" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtTotalInvoiceAmount" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtTotalInvoiceAmount1" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">

                                                                    <label for="txtConsignneeEng" class="col-sm-3 control-label">Forwarding</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="dcboForwarding" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtForwardingAmount" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtForwardingAmount1" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">

                                                                    <label for="dcboFreight" class="col-sm-3 control-label">Freight</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="dcboFreight" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtFreightAmount" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-md-3">

                                                                        <input class="form-control pull-right" id="txtFreightAmount1" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">

                                                                    <label for="dcboInsurance" class="col-sm-3 control-label">Insurance</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="dcboInsurance" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtInsuranceAmount" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtInsuranceAmount1" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">

                                                                    <label for="dcboPackingCharge" class="col-sm-3 control-label">Packing Charge</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="dcboPackingCharge" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtPackingChargeAmount" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-md-3">

                                                                        <input class="form-control pull-right" id="txtPackingChargeAmount1" runat="server" type="text" autocomplete="off" />
                                                                    </div>

                                                                </div>
                                                                <div class="form-group">


                                                                    <label for="txtConsignneeProvince" class="col-sm-3 control-label">Handling Charge</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="dcboForeignInland" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtForeignInlandAmount" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtForeignInlandAmount1" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label for="txtConsignneeProvince" class="col-sm-3 control-label">Landing Charge</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="dcboLandingCharge" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtLandingChargeAmount" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-md-3">

                                                                        <input class="form-control pull-right" id="txtLandingChargeAmount1" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">

                                                                    <label for="txtConsignneeEMail" class="col-sm-3 control-label">Total Invoice THB</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="dcboOtherCharge" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtTotalInvoiceTHBAmount" runat="server" type="text" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <input class="form-control pull-right" id="txtTotalInvoiceTHBAmount1" runat="server" type="text" autocomplete="off" />

                                                                    </div>
                                                                </div>

                                                            </fieldset>

                                                            <div class="form-horizontal">
                                                                <fieldset>
                                                                    <legend>Transmit</legend>
                                                                    <div class="box-body">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-5">
                                                                                <div class="radio">
                                                                                    <label>
                                                                                        <asp:RadioButton runat="server" ID="rdbDiffAmount" Text="Diff By Item-Amount" onclick="EnableDisableTextBox();" GroupName="option2" />
                                                                                    </label>
                                                                                </div>
                                                                            </div>
                                                                            <label for="txtTransmitDate" class="col-sm-3 control-label">Transmit Date:</label>
                                                                            <div class="col-sm-4">
                                                                                <asp:TextBox CssClass="form-control" ID="txtdatepickerTransmitDate" runat="server" placeholder="DD/MM/YYYY">
                                                                                </asp:TextBox>
                                                                                <asp:CalendarExtender ID="CalendarExtenderTransmitDate" runat="server" Enabled="True" TargetControlID="txtdatepickerTransmitDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-5">
                                                                                <div class="radio">
                                                                                    <label>
                                                                                        <asp:RadioButton runat="server" ID="rdbDiffWeight" Text="Diff By Item-Weight" onclick="EnableDisableTextBox();" GroupName="option2" />
                                                                                    </label>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="radio">
                                                                                    <label>
                                                                                        <asp:RadioButton runat="server" ID="rdbNotifyParty" Text="Notify Party" onclick="EnableDisableTextBox();" GroupName="option3" />
                                                                                    </label>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="radio">
                                                                                    <label>
                                                                                        <asp:RadioButton runat="server" ID="rdbOnBehalfOf" Text="On Behalf Of" onclick="EnableDisableTextBox();" GroupName="option3" />
                                                                                    </label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </fieldset>
                                                            </div>
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
                      
  
                        <div role="tabpanel" class="tab-pane" id="job">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">
                                    <div class="col-lg-12 col-md-12">
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                <div class="col-lg-12 col-md-12">
                                                    <div class="form-group">
                                                        <div class="checkbox col-sm-6">
                                                            <label>
                                                                <input type="checkbox" runat="server" id="chkEnablebehalf_EASJOB" onclick="chkExpEnable1();" />Enable On Behalf Of
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%-----------------------------------------------------Start Left Form--------------------------------------------------%>

                                                <div class="col-lg-12 col-md-12">
                                                    <fieldset runat="server" id="job_1">
                                                        <legend></legend>
                                                        <div class="col-md-6">
                                                            <!-- Horizontal Form -->

                                                            <div class="form-group">
                                                                <label for="txtOwnerCode_EASJOB" class="col-sm-4 control-label">Owner Code:</label>
                                                                <div class="col-sm-6">
                                                                    <input class="form-control" id="txtEASExporterCode" runat="server" autocomplete="off" />
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <button runat="server" class="btn btn-primary btn-block" type="button" id="btnOwner" onserverclick="btnOwner_ServerClick"><i class="fa fa-search"></i></button>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEASNameEng" class="col-sm-4 control-label">Name English:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEASNameEng" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEASStreet_Number" class="col-sm-4 control-label">Address1:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEASStreet_Number" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEASDistrict" class="col-sm-4 control-label">Address2:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEASDistrict" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEASSubProvince" class="col-sm-4 control-label">Address3:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEASSubProvince" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEASProvince" class="col-sm-4 control-label">Address4:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEASProvince" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEASPostCode" class="col-sm-4 control-label">Address5:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEASPostCode" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEASCompensateCode" class="col-sm-4 control-label">E-mail:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEASCompensateCode" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>

                                                            <fieldset>
                                                                <legend>Ship TO</legend>
                                                                <div class="form-group">
                                                                    <label for="txtCustomerCode" class="col-sm-4 control-label">Customer Code:</label>
                                                                    <div class="col-sm-6">
                                                                        <input runat="server" id="txtCustomerCode" class="form-control" autocomplete="off" />

                                                                    </div>
                                                                    <div class="col-md-2">
                                                                        <button runat="server" class="btn btn-primary btn-block" type="button" id="btnShip" onserverclick="btnShip_ServerClick"><i class="fa fa-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCustomerEng" class="col-sm-4 control-label">Name English:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control" id="txtCustomerEng" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCustomerAddress" class="col-sm-4 control-label">Address:</label>
                                                                    <div class="col-sm-8">
                                                                        <textarea class="form-control" id="txtCustomerAddress" rows="3" runat="server" name="txtRemarks" placeholder="Remarks ..."></textarea>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCustomerEMail" class="col-sm-4 control-label">E-mail:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control" id="txtCustomerEMail" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCustomerTelNo" class="col-sm-4 control-label">Tel No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control" id="txtCustomerTelNo" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCustomerFaxNo" class="col-sm-4 control-label">Fax No:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control" id="txtCustomerFaxNo" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCustomerContactPerson" class="col-sm-4 control-label">Contract Person:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control" id="txtCustomerContactPerson" runat="server" autocomplete="off" />
                                                                    </div>
                                                                </div>

                                                            </fieldset>

                                                            <fieldset runat="server" id="chk">
                                                                <legend>นำของออกชั่วคราว</legend>
                                                                <div class="box-body">

                                                                    <div class="form-group">
                                                                        <div class="checkbox col-sm-6">
                                                                            <label>
                                                                                <input type="checkbox" runat="server" id="CoutItem" onclick="chkExpEnable2();" />นำของออกชั่วคราว
                                                                            </label>
                                                                        </div>
                                                                        <div class="col-sm--">
                                                                            <button type="button" runat="server" class="btn btn-info" id="Use" onserverclick="Use_ServerClick">ใส่ยอดเงินที่ใช้</button>
                                                                            <%--  <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">Open modal for @mdo</button>--%>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!-- /.box-body -->
                                                            </fieldset>
                                                        </div>
                                                        <div class="col-md-6">

                                                            <div class="form-group">
                                                                <label for="txtEASInvREFNo" class="col-sm-3 control-label">EAS INV REF No:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEASInvREFNo" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEASLOTNo" class="col-sm-3 control-label">EAS LOT No:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEASLOTNo" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerRefNo" class="col-sm-3 control-label">Reference Line:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerRefNo" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtTruckWaybill_EASJOB" class="col-sm-3 control-label">Truck Waybill:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtSpecialInstruction" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtShipMode_EASJOB" class="col-sm-3 control-label">Ship Mode:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="dcboShipMode" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="dcboDeliveryTerm" class="col-sm-3 control-label">Delivery Term:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="dcboDeliveryTerm" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="dcboShippingMark" class="col-sm-3 control-label">Shipping Mark:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="dcboShippingMark" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCompany_EASJOB" class="col-sm-3 control-label">Company:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtShippingCompany" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtAddressEAS_EASJOB" class="col-sm-3 control-label">Address:</label>
                                                                <div class="col-sm-8">
                                                                    <textarea class="form-control" id="txtShippingAddress" rows="3" runat="server" name="txtRemarks" placeholder="Remarks ..." autocomplete="off"></textarea>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEASRemark" class="col-sm-3 control-label">Remark:</label>
                                                                <div class="col-sm-8">
                                                                    <textarea class="form-control" id="txtEASRemark" rows="2" runat="server" name="txtRemarks" placeholder="Remarks ..." autocomplete="off"></textarea>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtTotal_EASJOB" class="col-sm-3 control-label">Total:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtTotalCurrency" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>


                                                            <fieldset>
                                                                <legend>Bill To</legend>
                                                                <div class="box-body">
                                                                    <div class="form-group">
                                                                        <label for="txtEASCustomerCode" class="col-sm-3 control-label">Customer Code:</label>
                                                                        <div class="col-sm-6">
                                                                            <input runat="server" id="txtEASCustomerCode" class="form-control" autocomplete="off" />
                                                                            <%-- <asp:DropDownList ID="ddlCustomerCode_BillTo_EASJOB" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <button runat="server" class="btn btn-primary btn-block" type="button" id="btnBill" onserverclick="btnBill_ServerClick"><i class="fa fa-search"></i></button>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtNameCustomer_BillTo_EASJOB" class="col-sm-3 control-label">Name English:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control" id="txtEASCustomerEng1" runat="server" autocomplete="off" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtAddressCustomer_BillTo_EASJOB" class="col-sm-3 control-label">Address:</label>
                                                                        <div class="col-sm-8">
                                                                            <%--<input class="form-control" id="Text3" runat="server" />--%>
                                                                            <textarea class="form-control" id="txtEASCustomerAddress" rows="3" runat="server" name="txtRemarks" placeholder="Remarks ..." autocomplete="off"></textarea>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtEmailCustomer_BillTo_EASJOB" class="col-sm-3 control-label">E-mail:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control" id="txtEASEmail" runat="server" autocomplete="off" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtTelNoCustomer_BillTo_EASJOB" class="col-sm-3 control-label">Tel No:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control" id="txtEASTelNo" runat="server" autocomplete="off" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtFaxNoCustomer_BillTo_EASJOB" class="col-sm-3 control-label">Fax No:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control" id="txtEASFaxNo" runat="server" autocomplete="off" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtContractPersonCustomer_BillTo_EASJOB" class="col-sm-3 control-label">Contract Person:</label>
                                                                        <div class="col-sm-8">
                                                                            <input class="form-control" id="txtEASContactPerson" runat="server" autocomplete="off" />
                                                                        </div>
                                                                    </div>

                                                                    <h5></h5>
                                                                </div>
                                                                <!-- /.box-body -->
                                                            </fieldset>

                                                            <!-- /.box-body -->
                                                        </div>
                                                    </fieldset>
                                                </div>
                                            </div>
                                            <!--/.col-lg-6 col-md-6--->
                                        </div>
                                        <!--/.row-->
                                    </div>
                                </div>
                                <!-- /.post -->
                            </div>
                        </div>


                        <div role="tabpanel" class="tab-pane" id="deetail">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">
                                    <div class="col-lg-12 col-md-12">
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                <fieldset runat="server" id="deetail_">
                                                    <legend></legend>
                                                    <div class="col-lg-12 col-md-12">

                                                        <div class="form-group">
                                                            <label for="txtBrand_ItemDetail" class="col-sm-3">Brand</label>
                                                            <label for="txtProductYear_ItemDetail" class="col-sm-2">Product Year</label>
                                                            <label for="txtNatureOfTM_ItemDetail" class="col-sm-2">Nature Of tm</label>
                                                            <label for="txtPurchaseCtry_ItemDetail" class="col-sm-3">Purchase Ctry</label>
                                                            <label for="txtOriginCtry_ItemDetail" class="col-sm-2">Origin Ctry</label>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-3">
                                                                <asp:DropDownList ID="dcboBrand" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <%--<asp:DropDownList ID="ddlProductYear_ItemDetail" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                <input class="form-control" id="txtProductYea" runat="server" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboNatureOfTrn" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <asp:DropDownList ID="dcboPurchaseCtry" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboOriginCtry" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="form-group">
                                                            <label for="txtItemNo_ItemDetail" class="col-sm-1 control-label">Item No:</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control" id="txtItemNo" runat="server" autocomplete="off" />
                                                            </div>
                                                            <label for="txtProductCode_ItemDetail" class="col-sm-1 control-label">ProductCode:</label>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="ddlProductCode" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerPN_ItemDetail" class="col-sm-2 control-label">Product Desc:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtProductDesc1" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtCustomerPN_ItemDetail" class="col-sm-2 control-label">Customer P/N:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtProductDesc2" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerPN_ItemDetail" class="col-sm-2 control-label">Owner P/N :</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtProductDesc3" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="form-group">
                                                            <label for="txtInvQty_ItemDetail" class="col-sm-2 control-label">Inv Qty:</label>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtInvQty" runat="server" autocomplete="off" />
                                                            </div>
                                                            <label for="txtUnit1_ItemDetail" class="col-sm-1 control-label">Unit:</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboInvQtyUnit" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtInvQtyUnit" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtWeight_ItemDetail" class="col-sm-2 control-label">Weight:</label>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtWeight" runat="server" autocomplete="off" />
                                                            </div>
                                                            <label for="txtUnit2_ItemDetail" class="col-sm-1 control-label">Unit:</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboWeightUnit" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtWeightUnit" runat="server" disabled="disabled" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantity_ItemDetail" class="col-sm-2 control-label">Quantity:</label>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtQuantity" runat="server" autocomplete="off" />
                                                            </div>
                                                            <label for="txtUnit3_ItemDetail" class="col-sm-1 control-label">Unit:</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList runat="server" ID="dcboQuantityUnit" CssClass="form-control"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtQuantityUnit" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantity_ItemDetail" class="col-sm-2 control-label">Currency :</label>

                                                            <div class="col-sm-3">
                                                                <asp:DropDownList ID="dcboCurrency" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                            <label for="txtUnit3_ItemDetail" class="col-sm-2 control-label">Exchange Rate :</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtExchangeRate" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPriceForeigh" class="col-sm-2 control-label">@Price(Foreigh)</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtPriceForeigh" runat="server" autocomplete="off" />
                                                            </div>
                                                            <label for="txtPriceForeighAmount" class="col-sm-2 control-label">Amount :</label>

                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtPriceForeighAmount" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPriceBath" class="col-sm-2 control-label">@Price(Bath)</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtPriceBath" runat="server" autocomplete="off" />
                                                            </div>
                                                            <label for="txtUnit3_ItemDetail" class="col-sm-2 control-label">Amount :</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtPriceBathAmount" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtTariffCode" class="col-sm-2 control-label">Tariff Code:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtTariffCode" runat="server" autocomplete="off" />
                                                            </div>
                                                            <label for="txtStatisticalCode" class="col-sm-2 control-label">Statistical Code</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtStatisticalCode" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtTariffSequence" class="col-sm-2 control-label">Tariff Sequence</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtTariffSequence" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <label for="txtProductAttribute1" class="col-sm-2 control-label">Product Attribute1</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtProductAttribute1" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtProductAttribute2" class="col-sm-2 control-label">PO No</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtProductAttribute2" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <label for="txtPriceIncreaseForeign" class="col-sm-2 control-label">Price Increase(Foreign)</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtPriceIncreaseForeign" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPriceIncreseBath" class="col-sm-2 control-label">Price Increse(Bath)</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtPriceIncreseBath" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <label for="txtDeclarationLine" class="col-sm-2 control-label">Declaretion Line:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtDeclarationLine" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtFormulaNo_ItemDetail" class="col-sm-2 control-label">Formula No:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtFormulaNo_ItemDetail" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <label for="txtBOILicenseNo" class="col-sm-2 control-label">BOI License No</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtBOILicenseNo" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txt19BisTransferNo" class="col-sm-2 control-label">19 Bis Transfer No:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txt19BisTransferNo" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <label for="txt19BisTransferNo" class="col-sm-2 control-label">Bond Formula No.</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtBondFurmulaNo" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="form-group">
                                                            <label for="txtRemark_ItemDetail" class="col-sm-2 control-label">Remark:</label>
                                                            <div class="col-sm-6">
                                                                <textarea class="form-control" id="txtItemRemark" rows="3" runat="server" name="txtRemarks" style="height: 55px; width: 825px" placeholder="Remarks ..." autocomplete="off"> </textarea>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="form-group">
                                                            <label for="txtBrand_ItemDetail" class="col-sm-2 col-md-offset-2">Currency</label>
                                                            <label for="txtProductYear_ItemDetail" class="col-sm-2">Foriegn Amount</label>
                                                            <label for="txtNatureOfTM_ItemDetail" class="col-sm-2">Exchange Rate</label>
                                                            <label for="txtPurchaseCtry_ItemDetail" class="col-sm-3">Bath Amount</label>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="dcboForwardingCurrency" class="col-sm-2 control-label">Forwarding</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboForwardingCurrency" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtForwardingForiegnAmount" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtForwardingExchangeRate" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtForwardingBathAmount" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRemark_ItemDetail" class="col-sm-2 control-label">Freight</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboFreightCurrency" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtFreightForiegnAmo" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtFreightExchangeRate" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtFreightBathAmount" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRemark_ItemDetail" class="col-sm-2 control-label">Insurance</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboInsuranceCurrency" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtInsuranceForiegnAmount" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtInsuranceExchangeRate" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtInsuranceBathAmount" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRemark_ItemDetail" class="col-sm-2 control-label">Package Charge</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboPackageChargeCurrency" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtPackageChargeFoiegnAmount" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtPackageChargeExchangeRate" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtPackageChargeBathAmount" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRemark_ItemDetail" class="col-sm-2 control-label">Foreighn Inland Freidge</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboForeighnCurrency" CssClass="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtForeighnForiegnAmount" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtForeighnExchangeRate" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtForeighnBathAmount" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRemark_ItemDetail" class="col-sm-2 control-label">Landing Charge</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboLandingChargeCurrency" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtLandingChargeForiegnAmount" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtLandingChargeExchangeRate" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtLandingChargeBathAmount" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRemark_ItemDetail" class="col-sm-2 control-label">Other Charge</label>
                                                            <div class="col-sm-2">
                                                                <asp:DropDownList ID="dcboOtherChargeCurrency" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtOtherChargeForiegnAmount" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtOtherChargeExchangeRate" runat="server" disabled="disabled" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtOtherChargeBathAmount" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                    </div>

                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="form-group">
                                                            <div class="col-md-offset-6 col-lg-offset-7">
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnAddNewItem_ItemDetail" title="btnAddNewItem_ItemDetail">AddNewItem</button>
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnSaveModify_ItemDetail" title="btnSaveModify_ItemDetail">SaveModify</button>
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnDelete_ItemDetail" title="btnDelete_ItemDetail">Delete</button>
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnCreatePacking_ItemDetail" title="btnCreatePacking_ItemDetail">Create Packing</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="collg-12 col-md-12">
                                                        <fieldset>
                                                            <legend></legend>
                                                            <asp:Repeater ID="dgvLotNo" runat="server">
                                                                <HeaderTemplate>
                                                                    <table class="table table-bordered">
                                                                        <th style="width: 10px">InvoiceNo</th>
                                                                        <th style="width: 10px">ReferenceNo</th>
                                                                        <th style="width: 10px">ReferenceDate</th>
                                                                        <th style="width: 10px">PurchaseOrderNo</th>
                                                                        <th style="width: 10px">InvoiceDate</th>
                                                                        <th style="width: 10px">EASLOTNo</th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="success">
                                                                        <td>
                                                                            <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ReferenceNo")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ReferenceDate", "{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("PurchaseOrderNo")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("InvoiceDate", "{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lalEASLOTNo" runat="server" Text='<%# Bind("EASLOTNo")%>'></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <AlternatingItemTemplate>
                                                                    <tr class="info">
                                                                        <td>
                                                                            <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ReferenceNo", "{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ReferenceDate")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("PurchaseOrderNo")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("InvoiceDate", "{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblEASLOTNo1" runat="server" Text='<%# Bind("EASLOTNo")%>'></asp:Label></td>
                                                                    </tr>
                                                                </AlternatingItemTemplate>
                                                                <FooterTemplate>
                                                                    <th>InvoiceNo</th>
                                                                    <th>ReferenceNo</th>
                                                                    <th>ReferenceDate</th>
                                                                    <th>PurchaseOrderNo</th>
                                                                    <th>InvoiceDate</th>
                                                                    <th>EASLOTNo</th>
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </fieldset>
                                                    </div>

                                                </fieldset>

                                            </div>
                                        </div>
                                    </div>
                                    <!--/.col-lg-6 col-md-6--->
                                </div>
                                <!--/.row-->
                            </div>
                            <!-- /.post -->
                        </div>

                        <div role="tabpanel" class="tab-pane" id="list">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">
                                    <div class="col-lg-12 col-md-12">
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                <fieldset runat="server" id="list_">
                                                    <legend></legend>

                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="form-group">
                                                            <label for="txtProductCode_PACKINGLIST" class="col-sm-2 control-label">Produce Code:</label>
                                                            <div class="col-sm-4">
                                                                <input runat="server" id="txtPackProductCode" class="form-control" autocomplete="off" />
                                                                <%--                                      <asp:DropDownList ID="ddlProductCode_PACKINGLIST" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <button type="submit" runat="server" class="btn btn-primary" id="NetWeight_PACKINGLIST" title="NetWeight_PACKINGLIST">Sum Net(W)</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 col-lg-12">
                                                        <div class="form-group">
                                                            <label for="txtProductDesc_PACKINGLIST" class="col-sm-2 control-label">Produce Desc:</label>
                                                            <div class="col-sm-10">
                                                                <textarea class="form-control" id="txtPackProductDesc" rows="1" runat="server" name="txtPackProductDesc" style="height: 50px; width: 799px;" placeholder="Desc ..." autocomplete="off"></textarea>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">

                                                        <div class="col-md-6 col-lg-6">


                                                            <div class="form-group">
                                                                <label for="txtCustomerPN_PACKINGLIST" class="col-sm-4 control-label">Customer P/N:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerPN" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerPN" class="col-sm-4 control-label">Origin Crty:</label>
                                                                <div class="col-sm-4">
                                                                    <%--<input runat="server" id="dcboPackCountry" class="form-control" />--%>

                                                                    <asp:DropDownList ID="dcboPackCountry" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <input class="form-control" id="txtPackCountry" runat="server" disabled="disabled" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtNumberOfPLT_PACKINGLIST" class="col-sm-4 control-label">Number Of PLT:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="txtPLTAmount" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtPLTQuantity_PACKINGLIST" class="col-sm-4 control-label">PLT Quantity:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPLTQuantity" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtNetWeight_PACKINGLIST" class="col-sm-4 control-label">Net Weight:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="txtPackWeight" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtVolumeCBM_PACKINGLIST" class="col-sm-4 control-label">Volume (CBM):</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPackVolume" runat="server" autocomplete="off" />
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

                                                        <div class="col-lg-6 col-md-6">

                                                            <div class="form-group">
                                                                <label for="txtOwnerPN_PACKINGLIST" class="col-sm-3 control-label">Owner P/N:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtOwnerPN" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtUnit_PACKINGLIST" class="col-sm-3 control-label">Unit:</label>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList ID="dcboPackUnit" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <input class="form-control" id="txtPackUnit" runat="server" disabled="disabled" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtTotalCTN_PACKINGLIST" class="col-sm-3 control-label">Total CTN:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCTNAmount" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtProductQuantity_PACKINGLIST" class="col-sm-3 control-label">Product Quantity:</label>
                                                                <div class="col-sm-8">
                                                                    <input runat="server" id="txtPackQuantity" class="form-control" autocomplete="off" />
                                                                    <%-- <asp:DropDownList ID="dcboUnitPLT" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtPackGross" class="col-sm-3 control-label">Gross Weight:</label>
                                                                <div class="col-sm-8">
                                                                    <input runat="server" id="txtPackGross" class="form-control" autofocus="autofocus" autocomplete="off" />
                                                                    <%--<asp:DropDownList ID="dcboCTN" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtPONo_PACKINGLIST" class="col-sm-3 control-label">PO No:</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPONo" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="form-group">
                                                            <label for="txtMeasurement_PACKINGLIST" class="col-sm-2 control-label">Measurement:</label>
                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtWidth" runat="server" placeholder="Width" autocomplete="off" />
                                                            </div>

                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtHeight" runat="server" placeholder="Height" autocomplete="off" />
                                                            </div>

                                                            <div class="col-sm-3">
                                                                <input class="form-control" id="txtLeng" runat="server" placeholder="Lenght" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="form-horizontal">
                                                            <fieldset>
                                                                <legend>Amount</legend>
                                                                <div class="box-body">
                                                                    <div class="form-group">
                                                                        <label for="txtPLTNetAmount_PACKINGLIST" class="col-sm-2 control-label">PLT Net Amount:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control" id="txtPLTNetAmount" runat="server" autocomplete="off" />
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:DropDownList ID="dcboUnitPLT" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control" id="txtPLTUnit" runat="server" disabled="disabled" autocomplete="off" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtCTNNetAmount_PACKINGLIST" class="col-sm-2 control-label">CTN Net Amount:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control" id="txtCTNNetAmount" runat="server" autocomplete="off" />
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:DropDownList ID="dcboCTN" CssClass="form-control" runat="server" autocomplete="off"></asp:DropDownList>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control" id="txtCTNUnit" runat="server" disabled="disabled" autocomplete="off" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtTotal_PACKINGLIST" class="col-sm-2 control-label">Total:</label>
                                                                        <div class="col-sm-8">
                                                                            <%-- <input class="form-control" id="txtTotal_PACKINGLIST" runat="server" />--%>
                                                                            <textarea class="form-control" id="txtTotalText" rows="1" runat="server" name="txtProductDesc_PACKINGLIST" style="height: 50px; width: 799px;" placeholder="Desc ..."></textarea>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                                <!-- /.box-body -->
                                                            </fieldset>
                                                        </div>

                                                    </div>
                                                    <div class="col-lg-12 col-sm-12 col-lg-offset-6">
                                                        <div class="form-horizontal">
                                                            <div class="form-group">
                                                                <div class="checkbox col-sm-2">
                                                                    <label>
                                                                        <input type="checkbox" runat="server" id="chkCopyToDetail" />Copy To Detail
                                                                    </label>
                                                                </div>
                                                                <%--<div class="col-sm-3">--%>
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnAddNewItem_PACKINGLIST" title="btnAddNewItem_PACKINGLIST">AddNewItem</button>
                                                                <%--</div>--%>
                                                                <%--<div class="col-sm-3">--%>
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnSaveModify_PACKINGLIST" title="btnSaveModify_PACKINGLIST">SaveModify</button>
                                                                <%--</div>--%>
                                                                <%--<div class="col-sm-3">--%>
                                                                <button type="submit" runat="server" class="btn btn-primary" id="btnDelete_PACKINGLIST" title="btnDelete_PACKINGLIST">Delete</button>
                                                                <%--</div>--%>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </fieldset>
                                            </div>
                                            <!-- /.box-body -->
                                        </div>

                                        <!------- ./form-horizontal ----->
                                    </div>
                                    <!--/.col-lg-12 col-md-12--->
                                </div>
                                <!--/.row-->
                            </div>
                            <!-- /.post -->
                        </div>
                        <!------ ./tab-content ----->
                    </div>
                </div>
                <!--------- ./ Tabs------->

                <%--<asp:Button ID="Button1" Text="Submit" runat="server" CssClass="btn btn-primary" />--%>
                <asp:HiddenField ID="TabName" runat="server" />
            </div>
            <!--------- ./ panel --------->
        </section>
        <!-- Modal JoB No-->
        <asp:Panel ID="plSearch1" runat="server" CssClass="modal" TabIndex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true"></span>
                        </button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <asp:UpdatePanel ID="upSearch1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="box-body">
                                            <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                                 
                                                <asp:Repeater ID="dgvSearch" runat="server" OnItemCommand="dgvSearch_ItemCommand">
                                                    <HeaderTemplate>
                                                        <table id="example8" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                            <thead>
                                                                <tr>
                                                                    <th>select</th>
                                                                    <th>InvoiceNo</th>
                                                                    <th>ReferenceNo</th>
                                                                    <th>PurchaseOrderNo</th>
                                                                    <th>ExporterCode</th>
                                                                </tr>
                                                            </thead>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="text-center">
                                                                <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="selectInvoiceNo" CommandArgument='<%# Eval("InvoiceNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblReferenceNo" runat="server" Text='<%# Bind("ReferenceNo")%>'></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Bind("PurchaseOrderNo")%>'></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblExp" runat="server" Text='<%# Bind("ExporterCode")%>'></asp:Label></td>
                                                        </tr>

                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tfoot>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>InvoiceNo</th>
                                                                <th>ReferenceNo</th>
                                                                <th>PurchaseOrderNo</th>
                                                                <th>ExporterCode</th>
                                                            </tr>
                                                        </tfoot>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="col-md-12">
                                            <fieldset>
                                                <legend></legend>
                                               
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label for="txtStartInvoiceNo" class="col-sm-4 control-label">Invoice No.</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control" id="txtStartInvoiceNo" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtStartExporter" class="col-sm-4 control-label">Exporter</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control" id="txtStartExporter" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtStartConsignnee" class="col-sm-4 control-label">Consignnees</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control" id="txtStartConsignnee" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtStartInvoiceNo" class="col-sm-4 control-label">Invoice Date</label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox CssClass="form-control" ID="dtpStartInvoiceDate" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                                    </asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" TargetControlID="dtpStartInvoiceDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label for="txtEndInvoiceNo" class="col-sm-4 control-label">To Invoice No.</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEndInvoiceNo" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEndExporter" class="col-sm-4 control-label">To Exporter</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEndExporter" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtToConsignnee" class="col-sm-4 control-label">To Consignnee</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtToConsignnee" runat="server" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="dtpEndInvoiceDate" class="col-sm-4 control-label">To Invoice Date</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" ID="dtpEndInvoiceDate" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                                    </asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" TargetControlID="dtpEndInvoiceDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                            </div>

                                                        </div>                                                                                         
                                            </fieldset>
                                        </div>
                                        </div>
                            </form>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <button type="button" class="btn btn-secondary" id="btnadd_" runat="server" onserverclick="btnadd__ServerClick">Add</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <!-- Modal ConsigneeCode-->
        <asp:Panel ID="plExporter" runat="server" CssClass="modal" TabIndex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upExporter" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvExporter" runat="server" OnItemDataBound="dgvExporter_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example2" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
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
                                                            <asp:LinkButton ID="lnkPartyCode" CssClass="btn bg-navy" runat="server" OnClick="lnkPartyCode_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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
        <asp:Panel ID="plExporterCode" runat="server" CssClass="modal" TabIndex="-1" role="dialog">
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

                                            <asp:Repeater ID="dgvExporterCode" runat="server">
                                                <HeaderTemplate>
                                                    <table id="example3" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
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
                                                            <asp:LinkButton ID="lnkPartyCode_Ex" CssClass="btn bg-navy" runat="server"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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
        <asp:Panel ID="plConsignnee" runat="server" CssClass="modal" TabIndex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upConsignnee" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvConsignnee" runat="server" OnItemDataBound="dgvConsignnee_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example4" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
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
                                                        <asp:LinkButton ID="lnkPartyCode_Con" CssClass="btn bg-navy" runat="server" OnClick="lnkPartyCode_Con_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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
        <asp:Panel ID="plExporter1" runat="server" CssClass="modal" TabIndex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upExporter1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvExporter1" runat="server" OnItemDataBound="dgvExporter1_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example5" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
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
                                                        <asp:LinkButton ID="lnkPartyCode_Exp1" CssClass="btn bg-navy" runat="server" OnClick="lnkPartyCode_Exp1_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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
        <asp:Panel ID="plShipTo" runat="server" CssClass="modal" TabIndex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upShipTo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvShipTo" runat="server" OnItemDataBound="dgvShipTo_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example6" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
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
                                                        <asp:LinkButton ID="lnkPartyCode_ShipTo" CssClass="btn bg-navy" runat="server" OnClick="lnkPartyCode_ShipTo_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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
     
        <asp:Panel ID="plBillTo" runat="server" CssClass="modal" TabIndex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upBillTo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvBillTo" runat="server" OnItemDataBound="dgvBillTo_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example7" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
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
                                                        <asp:LinkButton ID="lnkPartyCode_BillTo" CssClass="btn bg-navy" runat="server" OnClick="lnkPartyCode_BillTo_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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
        <script type="text/javascript">
            function chkExpEnable1() {
                var status = document.getElementById('<%=chkEnablebehalf_EASJOB.ClientID%>').checked;

                if (status == true) {
                    document.getElementById('<%=job_1.ClientID%>').disabled = false;

                } else if (status == false) {
                    document.getElementById('<%=job_1.ClientID%>').disabled = true;
                }

        }
        </script>

        <script type="text/javascript">
            function chkExpEnable2() {
                var status = document.getElementById('<%=CoutItem.ClientID%>').checked;

                if (status == true) {
                    document.getElementById('<%=Use.ClientID%>').disabled = false;

                } else if (status == false) {
                    document.getElementById('<%=Use.ClientID%>').disabled = true;
                }

        }
        </script>

        <script type="text/javascript">
            $(function () {
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "header";
                $('#Tabs a[href="#' + tabName + '"]').tab('show');
                $("#Tabs a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });
            });
        </script>

    </form>
</asp:Content>
