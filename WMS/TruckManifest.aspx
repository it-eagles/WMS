﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TruckManifest.aspx.vb" Inherits="WMS.TruckManifest" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Wrapper. Contains page content -->

        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Truck Manifest</h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a><i class="fa fa-file"></i>Issue Process</a></li>
                <li><a>class="active">Truck Manifest</a></li>
            </ol>
        </section>

        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-lg-12 col-xs-12">

                    <div class="box box-primary">

                        <div class="box-header">
                            <h3 class="box-title">Truck Manifest</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-horizontal">
                                <div class="col-lg-10 col-md-offset-1">
                                  <div class="row">
                <div class="col-xs-12">
                    <div class="box box-default">
                        <div class="box-body">
                            <div class="col-xs-12">
                                <button class="btn btn-app" id="btnAdd" runat="server" onserverclick="btnAdd_ServerClick"><i class="fa fa-file-text-o"></i>Add</button>
                                <button class="btn btn-app" id="btnModify" runat="server" onserverclick="btnModify_ServerClick"><i class="fa fa-edit"></i>Modify</button>
                                <button class="btn btn-app" id="btnDelete" runat="server" onserverclick="btnDelete_ServerClick"><i class="fa fa-trash"></i>Delete</button>
                                <button class="btn btn-app" id="btnFind" runat="server" onserverclick="btnFind_ServerClick"><i class="fa fa-search"></i>Find</button>
                                <button class="btn btn-app" id="btnprint" runat="server" onserverclick="btnprint_ServerClick"><i class="fa fa-print"></i>Print</button>
                                <button class="btn btn-app" id="btnCancel" runat="server" onserverclick="btnCancel_ServerClick"><i class="fa fa-undo"></i>Cancel</button>
                                <button class="btn btn-app" id="btnSave" runat="server" onserverclick="btnSave_ServerClick"><i class="fa fa-save"></i>Save</button>
                                <button class="btn btn-app" id="btnClose" runat="server" onserverclick="btnClose_ServerClick"><i class="fa fa-close"></i>Close</button>
                            </div>           
                        </div>
                    </div>
                </div>
            </div>                           
                                    <div class="form-group">
                                        <label for="txtTuckManifestCode" class="col-sm-2 control-label">TruckManifest  Code</label>
                                        <div class="col-sm-6">
                                            <input class="form-control" id="txtTuckManifestCode" runat="server" autocomplete="off"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="dcboTruckOwner" class="col-sm-2 control-label">Truck Owner</label>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="dcboTruckOwner" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6">
                                            <input class="form-control" id="txtTruckOwner" runat="server" autocomplete="off"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="tdcboTruckType" class="col-sm-2 control-label">Truck Type</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="dcboTruckType" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                        </div>
                                        <label for="dcboPlate" class="col-sm-1 control-label">PLATE</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="dcboPlate" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="dcboDriverName" class="col-sm-2 control-label">Driver Name</label>
                                        <div class="col-sm-9">
                                            <asp:DropDownList ID="dcboDriverName" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtOrigin" class="col-sm-2 control-label">Origin</label>
                                        <div class="col-sm-9">
                                            <input class="form-control" id="txtOrigin" runat="server" autocomplete="off"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtDestination" class="col-sm-2 control-label">Destination</label>
                                        <div class="col-sm-9">
                                            <input class="form-control" id="txtDestination" runat="server" autocomplete="off"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="dtpManifestDate" class="col-sm-2 control-label">Date</label>
                                        <div class="col-sm-4">
                                            <div class="input-group date">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calculator"></i>
                                                </div>
                                                <asp:TextBox CssClass="form-control" ID="dtpManifestDate" runat="server" placeholder="MM/DD/YYYY">
                                                </asp:TextBox>
                                                <%--<input class="form-control pull-right" id="dtpIEATDate" runat="server" type="text" />--%>
                                            </div>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="dtpManifestDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>


                                        <label for="mskManifestTime" class="col-sm-1 control-label">Time</label>
                                        <div class="col-sm-4">
                                            <div class="bootstrap-timepicker">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <input type="text" class="form-control timepicker" runat="server" id="mskManifestTime"/>

                                                        <div class="input-group-addon">
                                                            <i class="fa fa-clock-o"></i>
                                                        </div>
                                                    </div>
                                                    <!-- /.input group -->
                                                </div>
                                                <!-- /.form group -->
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="txtConsigneeCode" class="col-sm-2 control-label">Consignee Code</label>
                                        <div class="col-sm-9">
                                            <input class="form-control" id="txtConsigneeCode" runat="server" autocomplete="off"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtContactName" class="col-sm-2 control-label">Contact Name</label>
                                        <div class="col-sm-9">
                                            <input class="form-control" id="txtContactName" runat="server" autocomplete="off"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtContactTel" class="col-sm-2 control-label">Contact Tel</label>
                                        <div class="col-sm-4">
                                            <input class="form-control" id="txtContactTel" runat="server" autocomplete="off"/>
                                        </div>
                                        <label for="txtIssuedBy" class="col-sm-1 control-label">Issued By</label>
                                        <div class="col-sm-4">
                                            <input class="form-control" id="txtIssuedBy" runat="server" autocomplete="off"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtEasName" class="col-sm-2 control-label">EAS Name</label>
                                        <div class="col-sm-4">
                                            <input class="form-control" id="txtEasName" runat="server" autocomplete="off"/>
                                        </div>
                                        <label for="txtEasTel" class="col-sm-1 control-label">EAS Tel</label>
                                        <div class="col-sm-4">
                                            <input class="form-control" id="txtEasTel" runat="server" autocomplete="off"/>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-lg-10 col-md-offset-1">
                                    <fieldset>
                                        <legend></legend>

                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label for="txtInvoiceNo" class="col-sm-4 control-label">Invoice / TO MAWB.</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo" runat="server" autocomplete="off"/>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtQuantitye" class="col-sm-4 control-label">Quantity on Truck</label>
                                                <div class="col-sm-4">
                                                    <input class="form-control" id="txtQuantity" runat="server" value="0.0" autocomplete="off"/>
                                                </div>
                                                <div class="col-sm-4">
                                                     <asp:DropDownList ID="dcboUnitQuantity" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtQuantityFull" class="col-sm-4 control-label">Total Quantity</label>
                                                <div class="col-sm-4">
                                                    <input class="form-control" id="txtQuantityFull" runat="server" autocomplete="off"/>
                                                </div>
                                                <div class="col-sm-4">
                                                     <asp:DropDownList ID="dcboUnitQuantity1" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label for="txtTruckWaybill" class="col-sm-3 control-label">Truck WayBill</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtTruckWaybill" runat="server" autocomplete="off"/>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtWeight" class="col-sm-3 control-label">Weight</label>
                                                <div class="col-sm-4">
                                                    <input class="form-control" id="txtWeight" runat="server" value="0.0" autocomplete="off"/>
                                                </div>
                                                <div class="col-sm-4">
                                                     <asp:DropDownList ID="dcboUnitWeight" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                                    </fieldset>

                                </div>
                                <div class="col-lg-12">
                                    <fieldset>
                                        <legend></legend>
                                        <div class="form-group">

                                            <div class="col-sm-10 col-md-offset-7">
                                                <button type="button" class="btn btn-primary">Save New</button>
                                                <button type="button" class="btn btn-default">Save Modify</button>
                                                <button type="button" class="btn btn-default">Delete</button>
                                                <button type="button" class="btn btn-default">Close</button>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>

                        </div>

                        <!-- /.box-header -->

                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
            <div class="row">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                <div class="form-group">

                                    <div class="box-body">
                                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                            <HeaderTemplate>
                                                <table id="example1" class="table table-condensed">
                                                    <thead>
                                                        <tr>
                                                       <th>Select</th>
                                                        <th>TruckManifestCode</th>
                                                        <th>InvoiceNo</th>
                                                        <th>TruckWayBill</th>
                                                        <th>Remark</th>
                                                        <th>RowTruckNo</th>

                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="danger">

                                                    <td class="text-center">
                                                        <asp:LinkButton ID="clickrpt" CssClass="btn btn-default" runat="server" OnClick="clickrpt_Click"><i class="fa fa-pencil"></i></asp:LinkButton></td>
                                                    <td>
                                                        <asp:Label ID="lblTruckManifestCode" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblInvoiceNo" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblTruckWayBill" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblRemark" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblRowTruckNo" runat="server" Text="Label"></asp:Label></td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <tfoot>
                                                    <tr>
                                                        <th>Select</th>
                                                        <th>TruckManifestCode</th>
                                                        <th>InvoiceNo</th>
                                                        <th>TruckWayBill</th>
                                                        <th>Remark</th>
                                                        <th>RowTruckNo</th>
                                                    </tr>
                                                </tfoot>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>

        </section>
        <!-- /.content -->

    </form>
</asp:Content>

