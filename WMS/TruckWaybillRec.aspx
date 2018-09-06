<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TruckWaybillRec.aspx.vb" Inherits="WMS.TruckWaybillRec" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Truck Way Bill
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Receive Process</a></li>
                <li><a href="TruckWaybillRec.aspx"class="active">Truck Way Bill</a></li>

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
                                        <li class="active"><a href="#truckwaybillhead" aria-controls="truckwaybillhead" role="tab" data-toggle="tab">Truck Way Bill Head</a></li>
                                        <li><a href="#truckwaybilldetail" aria-controls="truckwaybilldetail" role="tab" data-toggle="tab">Truck Way Bill Detail</a></li>
                                    </ul>
                                    <!-- Tab panes -->
                                    <div class="tab-content" style="padding-top: 20px">
                                        <%-----------------------------------------------------Start TRUCK WAY BILL HEAD-----------------------------------------------------------%>
                                        <!------- Import Goods ------->
                                        <div role="tabpanel" class="active tab-pane" id="truckwaybillhead">
                                            <fieldset runat="server" id="truckwaybillhead_fieldset">
                                            <!-- Post -->
                                            <div class="row">
                                                <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                                                <div class="col-md-6">
                                                    <!-- Horizontal Form -->

                                                    <!-- form start -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Truck W/B</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtTruckW/B" class="col-sm-4 control-label">TruckW/B:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtTruckW_B" runat="server" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" id="btnSearchTruck" onserverclick="btnSearchTruck_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNoOfOriginals" class="col-sm-4 control-label">No Of Originals:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNoOfOriginals" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtDeliveryOfGoods" class="col-sm-4 control-label">Delivery Of Goods:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtDeliveryOfGoods" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtDriverName" class="col-sm-4 control-label">Driver Name:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtDriverName" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPrepaid" class="col-sm-4 control-label">Prepaid:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtPrepaid" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtGrossWeight" class="col-sm-4 control-label">Gross Weight:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtGrossWeight" runat="server" value="0.0" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNotifyPartyCode" class="col-sm-4 control-label">Notify Party Code:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtNotifyPartyCode" runat="server" autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <%--<button type="button" class="btn btn-block btn-primary btn-sm" data-toggle="modal" data-target="#NotifyPartyModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNotifyPartyName" class="col-sm-4 control-label">Notify Party Name:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNotifyPartyName" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNotifyPartyAddress" class="col-sm-4 control-label">Notify Party Address:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNotifyPartyAddress" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <%--<div class="form-group">
                  <label for="txtPlaceOfReceipt" class="col-sm-4 control-label">Place Of Receipt:</label>
                  <div class="col-sm-8">
                    <input class="form-control input-sm" id="txtPlaceOfReceipt" runat="server"/>
                  </div>
                </div>--%>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </fieldset>
                                                    </div>
                                                    <!-- /.box -->

                                                    <!-- general form Commodity -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Shipper</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtShipperCode" class="col-sm-4 control-label">Shipper Code:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtShippercode" runat="server"  autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <%--<button type="button" class="btn btn-block btn-primary btn-sm" data-toggle="modal" data-target="#ShipperModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick1"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNameShipper" class="col-sm-4 control-label">Name(Eng):</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNameShipper" runat="server" placeholder="Name(Eng)" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress1Shipper" class="col-sm-4 control-label">Address1:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress1Shipper" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress2Shipper" class="col-sm-4 control-label">Address2:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress2Shipper" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress3Shipper" class="col-sm-4 control-label">Address3:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress3Shipper" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress4Shipper" class="col-sm-4 control-label">Address4:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress4Shipper" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress5Shipper" class="col-sm-4 control-label">Address5:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress5Shipper" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtEmailShipper" class="col-sm-4 control-label">E-mail:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtEmailShipper" runat="server" />
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
                                                            <legend>Truck W/B</legend>
                                                            <div class="box-body">
                                                                <div class="form-group">
                                                                    <label for="txtReceivedDate" class="col-sm-4 control-label">Received Date:</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerReceivedDate" runat="server" placeholder="DD/MM/YYYY">
                                                                        </asp:TextBox>
                                                                        <asp:CalendarExtender ID="CalendarExtenderReceivedDate" runat="server" Enabled="True" TargetControlID="txtdatepickerReceivedDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtDateOfIssue" class="col-sm-4 control-label">Date Of Issue:</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerDateOfIssue" runat="server" placeholder="DD/MM/YYYY">
                                                                        </asp:TextBox>
                                                                        <asp:CalendarExtender ID="CalendarExtenderDateOfIssue" runat="server" Enabled="True" TargetControlID="txtdatepickerDateOfIssue" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNotifyParty" class="col-sm-4 control-label">Notify Party:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNotifyParty" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCarLicense" class="col-sm-4 control-label">Car License:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtCarLicense" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtFreightCharges" class="col-sm-4 control-label">Freight Charges:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtFreightCharges" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtQuantityAmount" class="col-sm-4 control-label">Quantity Amount:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtQuantityAmount" runat="server" value="0.0" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtMeasurement" class="col-sm-4 control-label">Measurement:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtMeasurement" runat="server" value="0.0" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPlaceOfReceipt" class="col-sm-4 control-label">Place Of Receipt:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtPlaceOfReceipt" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" style="height: 30px;"></div>

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
                                                                    <label for="txtConsigneeCode" class="col-sm-4 control-label">Consignee Code:</label>
                                                                    <div class="col-sm-6">
                                                                        <input class="form-control input-sm" id="txtConsigneeCodee" runat="server"  autocomplete="off" />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <%--<button type="button" class="btn btn-block btn-primary btn-sm" data-toggle="modal" data-target="#consigneeModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                                        <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick2"><i class="glyphicon glyphicon-search"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtNameConsignee" class="col-sm-4 control-label">Name(Eng):</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtNameConsignee" runat="server" placeholder="Name(Eng)" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress1Consignee" class="col-sm-4 control-label">Address1:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress1Consignee" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress2Consignee" class="col-sm-4 control-label">Address2:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress2Consignee" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress3Consignee" class="col-sm-4 control-label">Address3:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress3Consignee" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress4Consignee" class="col-sm-4 control-label">Address4:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress4Consignee" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtAddress5Consignee" class="col-sm-4 control-label">Address5:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtAddress5Consignee" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtEmailConsignee" class="col-sm-4 control-label">E-mail:</label>
                                                                    <div class="col-sm-8">
                                                                        <input class="form-control input-sm" id="txtEmailConsignee" runat="server" />
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
                                        <%-------------------------------------------------------------End TRUCK WAY BILL HEAD-------------------------------------------------------%>


                                        <%--------------------------------------------------------------Start TRUCK WAY BILL DETAIL----------------------------------------------------------%>
                                        <!-------- Export Goods --------->
                                        <div role="tabpanel" class="tab-pane" id="truckwaybilldetail">
                                            <fieldset runat="server" id="truckwaybilldetail_fieldset">
                                            <!-- Post -->
                                            <div class="row">

                                                <div class="col-lg-12 col-md-12 ">
                                                    <!-- form start -->
                                                    <div class="form-horizontal">
                                                        <fieldset>
                                                            <legend>Invoice</legend>
                                                            <div class="box-body">
                                                                <div class="col-md-11 col-sm-11">
                                                                    <div class="form-group">
                                                                        <label for="txtInvoiceNo" class="col-sm-2 control-label">Invoice No:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtInvoiceNoo" runat="server"  autocomplete="off" />
                                                                        </div>
                                                                        <div class="col-sm-1">
                                                                            <%--<button type="button" class="btn btn-block btn-primary btn-sm" data-toggle="modal" data-target="#InvoiceNoModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                                            <button type="button" class="btn btn-block btn-primary btn-sm" runat="server" onserverclick="Unnamed_ServerClick3"><i class="glyphicon glyphicon-search"></i></button>
                                                                        </div>
                                                                        <label for="txtLOTNo" class="col-sm-2 control-label">LOT No:</label>
                                                                        <div class="col-sm-4">
                                                                            <input class="form-control input-sm" id="txtLOTNo" runat="server" />
                                                                        </div>

                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtPartDesc" class="col-sm-2 control-label">Part Desc:</label>
                                                                        <div class="col-sm-3">
                                                                            <input class="form-control input-sm" id="txtPartDesc" runat="server"  autocomplete="off" />
                                                                        </div>
                                                                        <div class="col-sm-1">
                                                                            <button type="button" class="btn btn-block btn-primary btn-sm" data-toggle="modal" data-target="#PartDescModal" runat="server" id="btnPartDesc" onserverclick="btnPartDesc_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                                        </div>
                                                                        <label for="txtMeasurement" class="col-sm-2 control-label">Measurement:</label>
                                                                        <div class="col-sm-4">
                                                                            <input class="form-control input-sm" id="txtMeasurement_Detail" runat="server" />
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group">
                                                                        <label for="txtOwnP/N" class="col-sm-2 control-label">Own P/N:</label>
                                                                        <div class="col-sm-4">
                                                                            <input class="form-control input-sm" id="txtOwnP_N" runat="server" />
                                                                        </div>
                                                                        <label for="txtCustomerP/N" class="col-sm-2 control-label">CustomerP/N:</label>
                                                                        <div class="col-sm-4">
                                                                            <input class="form-control input-sm" id="txtCustomerP_N" runat="server" />
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group">
                                                                        <label for="txtQuantity_Detail" class="col-sm-2 control-label">Quantity:</label>
                                                                        <div class="col-sm-4">
                                                                            <input class="form-control input-sm" id="txtQuantity_Detail" runat="server" />
                                                                        </div>
                                                                        <label for="txtUnitQuantity_Detail" class="col-sm-2 control-label">Unit:</label>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="ddlUnitQuantity_Detail" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group">
                                                                        <label for="txtGrossWeight" class="col-sm-2 control-label">Gross Weight:</label>
                                                                        <div class="col-sm-4">
                                                                            <input class="form-control input-sm" id="txtGrossWeight_Detail" runat="server" />
                                                                        </div>
                                                                        <label for="txtUnit_GrossWeight" class="col-sm-2 control-label">Unit:</label>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="ddlUnit_GrossWeight" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group">
                                                                        <label for="txtCountryOfOrigin" class="col-sm-2 control-label">Country Of Origin:</label>
                                                                        <div class="col-sm-4">
                                                                            <asp:DropDownList ID="ddlCountryOfOrigin" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                        </div>

                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="col-sm-12 col-sm-offset-4">
                                                                        <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnSaveNew_Detail" title="btnSaveNew_Detail" onserverclick="btnSaveNew_Detail_ServerClick">Save New</button>
                                                                        <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnSaveModify_Detail" title="btnSaveModify_Detail" onserverclick="btnSaveModify_Detail_ServerClick">Save Modify</button>
                                                                        <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnDelete_Detail" title="btnDelete_Detail" onserverclick="btnDelete_Detail_ServerClick">Delete</button>
                                                                        <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnCencel_Detail" title="btnCencel_Detail" onserverclick="btnCencel_Detail_ServerClick">Cencel</button>
                                                                    </div>
                                                                </div>

                                                                <!-- /.box-body -->
                                                            </div>
                                                            <!-- /.box-header -->
                                                        </fieldset>
                                                    </div>
                                                    <!--/.col-lg-6 col-md-6 stockqty--->

                                                </div>

                                                <!-- /.col -->

                                            </div>
                                            <!-- /.post -->
                                            </fieldset>
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
            </div>
            <!-- /.row -->
        </section>
        <!-- /.content -->



        <!-- NotifyParty Modal -->
        <!-- Modal -->
        <asp:Panel ID="NofityPartyPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
        <%--<div class="modal fade" id="NotifyPartyModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Select NotifyParty Code</h4>
              </div>
                <asp:UpdatePanel ID="NofityPartyUpdatePanel" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
              <div class="modal-body">
                <section class="content">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 " style="overflow:auto;">
                            <asp:Repeater ID="Repeater1" runat="server">
                                    <HeaderTemplate>
                                        <table id="example1" class="table table-bordered table-striped table-responsive" style="overflow:auto;">
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
                                            <%--<td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress2" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress3" runat="server" Text='<%# Bind("Address3")%>'></asp:Label></td>--%>
                                                        <td class="text-center">
                                                             <%--<asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectNotifyParty" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-plus-square"></i></asp:LinkButton>--%>
                                                            <asp:LinkButton ID="LinkButton1" CssClass="btn bg-navy" runat="server" OnClick="clicknotifyparty_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress1" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress2" runat="server" ></asp:Label></td>
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
        <!-- End NotifyParty Modal -->

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
                            <asp:Repeater ID="Repeater2" runat="server">
                                    <HeaderTemplate>
                                        <table id="example2" class="table table-bordered table-striped table-responsive" style="overflow:auto;">
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
                                            <%--<td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress2" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress3" runat="server" Text='<%# Bind("Address3")%>'></asp:Label></td>--%>
                                                        <td class="text-center">
                                                             <%--<asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectShipper" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-plus-square"></i></asp:LinkButton>--%>
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" OnClick="clickshipper_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress1" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress2" runat="server" ></asp:Label></td>
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
                            <asp:Repeater ID="Repeater3" runat="server">
                                    <HeaderTemplate>
                                        <table id="example3" class="table table-bordered table-striped table-responsive" style="overflow:auto;">
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
                                            <%--<td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress2" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress3" runat="server" Text='<%# Bind("Address3")%>'></asp:Label></td>--%>
                                                        <td class="text-center">
                                                             <%--<asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectConsignee" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-plus-square"></i></asp:LinkButton>--%>
                                                            <asp:LinkButton ID="LinkButton3" CssClass="btn bg-navy" runat="server" OnClick="clickconsignee_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress1" runat="server" ></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAddress2" runat="server" ></asp:Label></td>
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

                <!-- InvoiceNo Modal -->
        <!-- Modal -->
        <asp:Panel ID="InvoicePanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
        <%--<div class="modal fade" id="InvoiceNoModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Select Invoice No</h4>
              </div>
                    <asp:UpdatePanel ID="InvoiceUpdatePanel" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
              <div class="modal-body">
                <section class="content">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 " style="overflow:auto;">
                            <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="Repeater4_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example4" class="table table-bordered table-striped table-responsive" style="overflow:auto;">
                                            <thead>
                                                <tr>
                                                    <th>InvoiceNo</th>
                                                    <th>QuantityAmount</th>
                                                    <th>GrossWeightAmount</th>
                                                    <th>VolumAmount</th>
                                                    <th>EASLOTNo</th>
                                                    <th>view</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PLTNETAmount")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("GrossWeightAmount")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress2" runat="server" Text='<%# Bind("VolumAmount")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAddress3" runat="server" Text='<%# Bind("EASLOTNo")%>'></asp:Label></td>
                                            <td class="text-center">
                                                 <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectInvoiceNo" CommandArgument='<%# Eval("InvoiceNo")%>'><i class="fa fa-plus-square"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                    <th>InvoiceNo</th>
                                                    <th>QuantityAmount</th>
                                                    <th>GrossWeightAmount</th>
                                                    <th>VolumAmount</th>
                                                    <th>EASLOTNo</th>
                                                    <th>view</th>
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
        <!-- End InvoiceNo Modal -->
         <!--Start ProductCode Modal -->
        <!-- Modal -->
        <asp:Panel ID="PartDescPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
        <%--<div class="modal fade" id="PartDescModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Select Product Code</h4>
              </div>
                    <asp:UpdatePanel ID="PartDescUpdatePanel" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
              <div class="modal-body">
                <section class="content">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 " style="overflow:auto;">
                            <asp:Repeater ID="Repeater5" runat="server" OnItemCommand="Repeater5_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example5" class="table table-bordered table-striped table-responsive" style="overflow:auto;">
                                            <thead>
                                                <tr>
                                                    <th>Select</th>
                                                    <th>ProductCode</th>
                                                    <th>ImpDesc1</th>
                                                    <th>CustomerPart</th>
                                                    <th>EndUserPart</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                 <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectProductCode" CommandArgument='<%# Eval("ProductCode")%>'><i class="fa fa-plus-square"></i></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("ProductCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("ImpDesc1")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("CustomerPart")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("EndUserPart")%>'></asp:Label></td                                            
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                    <th>Select</th>
                                                    <th>ProductCode</th>
                                                    <th>ImpDesc1</th>
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
        <!-- End ProductCode Modal -->

        <!-- Modal TruckNo-->
        <asp:Panel ID="TrucknoPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="exampleModalLabel">Select Truck No</h4>
                    </div>
                    <asp:UpdatePanel ID="TrucknoUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="Repeater6" runat="server" OnItemCommand="Repeater6_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example6" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>TruckNo</th>
                                                                <th>NotifyPartyCode</th>
                                                                <th>ShipperCode</th>
                                                                <th>ConsigneeCode</th>                                                                
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="selectTruckNO" CommandArgument='<%# Eval("TruckWayBillNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTruckWayBillNo" runat="server" Text='<%# Bind("TruckWayBillNo")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblNotifyPartyCode" runat="server" Text='<%# Bind("PlaceCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblShipperCode" runat="server" Text='<%# Bind("ExporterCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblConsigneeCode" runat="server" Text='<%# Bind("ConsignneeCode")%>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                                <th>select</th>
                                                                <th>TruckNo</th>
                                                                <th>NotifyPartyCode</th>
                                                                <th>ShipperCode</th>
                                                                <th>ConsigneeCode</th> 
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
        <!-- End TruckNo Modal -->

        <script type="text/javascript">
            $(function () {
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "truckwaybillhead";
                $('#Tabs a[href="#' + tabName + '"]').tab('show');
                $("#Tabs a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });
            });
        </script>

    </form>
</asp:Content>
