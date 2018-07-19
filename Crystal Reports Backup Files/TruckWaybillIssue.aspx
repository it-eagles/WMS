<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TruckWaybillIssue.aspx.vb" Inherits="WMS.TruckWaybillIssue" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="Content1">
    <form runat="server" id="form1">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Truck Way Bill Issue
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-share-square-o"></i>Issue Process</a></li>
                <li><i></i>Truck Way Bill Issue</li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->

                <div class="col-md-12 col-lg-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#head" data-toggle="tab">Truck Way Bill(HEAD)</a></li>
                            <li><a href="#detail" data-toggle="tab">Truck Way Bill(DETAIL)</a></li>

                        </ul>

                        <div class="tab-content">

                            <!------- head ---------->
                            <div class="active tab-pane" id="head">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">

                                        <div class="col-lg-12 col-md-8 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">

                                                <div class="box-body">
                                                    <div class="col-lg-12 col-md-offset-1">
                                                        <div class="form-group">
                                                            <div class="col-md-3">
                                                                <div class="form-group">

                                                                    <label for="txtTruckWayBill">Truck W/B No</label>
                                                                    <div class="col-md-11">
                                                                        <input class="form-control" id="txtTruckWayBill" runat="server" />

                                                                    </div>


                                                                </div>

                                                            </div>

                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="txtTruckWayBill">Received Date</label>
                                                                    <div class="input-group date col-md-10">
                                                                        <div class="input-group-addon">
                                                                            <i class="fa fa-calculator"></i>
                                                                        </div>
                                                                        <asp:TextBox CssClass="form-control" ID="dtpInvoiceDate" runat="server" placeholder="MM/DD/YYYY">
                                                                        </asp:TextBox>
                                                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="dtpInvoiceDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                    </div>

                                                                </div>

                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="txtTruckWayBill">Date of issue</label>
                                                                    <div class="input-group date col-md-10">
                                                                        <div class="input-group-addon">
                                                                            <i class="fa fa-calculator"></i>
                                                                        </div>
                                                                        <asp:TextBox CssClass="form-control" ID="DateTimePicker1" runat="server" placeholder="MM/DD/YYYY">
                                                                        </asp:TextBox>
                                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="DateTimePicker1" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="col-md-6">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <div class="form-group">
                                                                    <label for="txtNoOriginals" class="col-sm-3 control-label">No. of Originals</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtNoOriginals" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtDelivery" class="col-sm-3 control-label">Delivery of Goods</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtDelivery" runat="server" type="text" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label for="txtDriverName" class="col-sm-3 control-label">Driver Name</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtDriverName" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPrepaid" class="col-sm-3 control-label">Prepaid</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtPrepaid" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtGrossWeight" class="col-sm-3 control-label">Gross Weight</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtGrossWeight" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPlaceCode" class="col-sm-3 control-label">Place Delivery Code</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtPlaceCode" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPlaceName" class="col-sm-3 control-label">Place Delivery Name</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtPlaceName" runat="server" type="text" />
                                                                    </div>
                                                                </div>

                                                            </fieldset>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <div class="form-group">
                                                                    <label for="txtNotifyParty" class="col-sm-3 control-label">Notify Party</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtNotifyParty" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCarLicense" class="col-sm-3 control-label">Car License</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtCarLicense" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtFreightCharges" class="col-sm-3 control-label">Freight & Charges</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtFreightCharges" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtQuantityAmount" class="col-sm-3 control-label">Quantity Amount</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtQuantityAmount" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtMeasurement" class="col-sm-3 control-label">Measurement</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtMeasurement" runat="server" type="text" />
                                                                    </div>
                                                                </div>

                                                            </fieldset>
                                                        </div>


                                                    </div>
                                                    <div class="col-lg-12 col-md-12 ">
                                                        <div class="col-lg-10 col-md-10">
                                                            <div class="form-group">
                                                                <label for="txtPlaceAddress" class="col-sm-2 control-label">Address</label>
                                                                <div class="col-md-10">
                                                                    <textarea class="form-control" id="txtPlaceAddress" rows="4" runat="server" name="txtRemarks" placeholder="Remarks ..."></textarea>
                                                                    <%--<input class="form-control pull-right" id="txtPlaceAddress" runat="server" type="text" />--%>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="col-md-6">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <div class="form-group">
                                                                    <label for="txtExporterCode" class="col-sm-3 control-label">Shipper Code</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtExporterCode" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtExportEng" class="col-sm-3 control-label">Name (Eng)</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtExportEng" runat="server" type="text" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label for="txtStreet_Number" class="col-sm-3 control-label">Address1</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtStreet_Number" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtDistrict" class="col-sm-3 control-label">Address2</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtDistrict" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtSubProvince" class="col-sm-3 control-label">Address3</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtSubProvince" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                       <div class="form-group">
                                                                    <label for="txtProvince" class="col-sm-3 control-label">Address4</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtProvince" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPostCode" class="col-sm-3 control-label">Address5</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtPostCode" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCompensateCode" class="col-sm-3 control-label">Email</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtCompensateCode" runat="server" type="text" />
                                                                    </div>
                                                                </div>

                                                            </fieldset>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <div class="form-group">
                                                                    <label for="txtConsigneeCode" class="col-sm-3 control-label">Consignee Code</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsigneeCode" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeEng" class="col-sm-3 control-label">Name (Eng)</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeEng2" runat="server" type="text" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label for="txtConsignneeStreet_Number" class="col-sm-3 control-label">Address1</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeStreet_Number" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeDistrict" class="col-sm-3 control-label">Address2</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeDistrict" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeSubProvince" class="col-sm-3 control-label">Address3</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeSubProvince" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                     <div class="form-group">
                                                                    <label for="txtConsignneeProvince" class="col-sm-3 control-label">Address5</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeProvince" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneePostCode" class="col-sm-3 control-label">Address5</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneePostCode" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeEMail" class="col-sm-3 control-label">Email</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtConsignneeEMail" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                            </fieldset>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <div class="form-group">
                                                                    <label for="txtConsigneeCode" class="col-sm-3 control-label">Total Invoice</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text1" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeEng" class="col-sm-3 control-label">Forwarding</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text2" runat="server" type="text" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label for="txtConsignneeStreet_Number" class="col-sm-3 control-label">Freight</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text3" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeDistrict" class="col-sm-3 control-label">Insurance</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text4" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeSubProvince" class="col-sm-3 control-label">Packing Charge</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text5" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                     <div class="form-group">
                                                                    <label for="txtConsignneeProvince" class="col-sm-3 control-label">Handling Charge</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text6" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneePostCode" class="col-sm-3 control-label">Landing Charge</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text7" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeEMail" class="col-sm-3 control-label">Total Invoice THB</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text8" runat="server" type="text" />
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
                            </div>
                            <!-- ./head -->

                            <!-- detail -->
                            <div class="active tab-pane" id="detail">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">

                                        <div class="col-lg-12 col-md-8 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">

                                                <div class="box-body">

                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="col-md-8">

                                                            <div class="form-group">
                                                                <label for="txtInvoiceNo" class="col-sm-2 control-label">Invoice No</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtInvoiceNo" runat="server" type="text" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtLOTNo" class="col-sm-2 control-label">LOT No</label>
                                                                <div class="col-md-10">
                                                                    <input class="form-control pull-right" id="txtLOTNo" runat="server" type="text" />
                                                                </div>
                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtPartDesc" class="col-sm-2 control-label">Part Desc</label>
                                                                <div class="col-md-10">
                                                                    <input class="form-control pull-right" id="txtPartDesc" runat="server" type="text" />
                                                                </div>
                                                            </div>


                                                        </div>

                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="col-md-6">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <div class="form-group">
                                                                    <label for="txtOwner" class="col-sm-3 control-label">Owner P/N</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtOwner" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtQuantity" class="col-sm-3 control-label">Quantity</label>
                                                                    <div class="col-md-4">
                                                                        <input class="form-control pull-right" id="txtQuantity" runat="server" type="text" />
                                                                    </div>
                                                                    <label for="dcbQuantityUnit" class="col-sm-1 control-label">Unit</label>
                                                                    <div class="col-md-4">
                                                                        <asp:DropDownList ID="dcbQuantityUnit" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label for="txtMeasurementDetail" class="col-sm-3 control-label">Measurement</label>
                                                                    <div class="col-md-9">
                                                                        <input class="form-control pull-right" id="txtMeasurementDetail" runat="server" type="text" />
                                                                    </div>
                                                                </div>

                                                            </fieldset>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <div class="form-group">
                                                                    <label for="txtCustomer" class="col-sm-3 control-label">Customer P/N</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtCustomer" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtConsignneeEng" class="col-sm-3 control-label">Gross Weight</label>
                                                                    <div class="col-md-4">
                                                                        <input class="form-control pull-right" id="txtWeight" runat="server" type="text" />
                                                                    </div>
                                                                    <label for="dcbWeightUnit" class="col-sm-1 control-label">Unit</label>
                                                                    <div class="col-md-4">
                                                                        <asp:DropDownList ID="dcbWeightUnit" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="dcbCountryofOrigin" class="col-sm-3 control-label">Country of Origin</label>
                                                                    <div class="col-md-9">
                                                                        <asp:DropDownList ID="dcbCountryofOrigin" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                            <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>



                                                            </fieldset>
                                                        </div>


                                                    </div>
                                                    <div class="col-lg-12">
                                                        <fieldset>
                                                            <legend></legend>
                                                            <div class="form-group">

                                                                <div class="col-sm-10 col-md-offset-7">
                                                                    <button type="button" class="btn btn-primary">SaveNew</button>
                                                                    <button type="button" class="btn btn-default">SaveModify</button>
                                                                    <button type="button" class="btn btn-default">Delete</button>
                                                                    <button type="button" class="btn btn-default">Close</button>
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
                            <!-- ./ detail-->
                        </div>
                    </div>





                </div>
                <!-- /.col -->

            </div>
            <!-- /.row -->

        </section>
        <!-- /.content -->


    </form>
</asp:Content>


