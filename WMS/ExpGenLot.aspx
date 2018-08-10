<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExpGenLot.aspx.vb" Inherits="WMS.ExpGenLot" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="Content1">
    <form runat="server" id="form1">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Issue Process
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-share-square-o"></i>Issue Process</a></li>
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
                        <li><a href="#master" aria-controls="master" role="tab" data-toggle="tab" class="active">Master JOB</a></li>
                        <li><a href="#detail" aria-controls="detail" role="tab" data-toggle="tab">JOB Detail</a></li>
                        <li><a href="#invoice" aria-controls="invoice" role="tab" data-toggle="tab">Invoice</a></li>
                    </ul>
                    <!-- Tab panes -->
                    <div class="tab-content" style="padding-top: 20px">
                        <div role="tabpanel" class="tab-pane active" id="master">
                            <div class="post">
                                <div class="row margin-bottom">

                                    <div class="col-lg-12 col-md-8 ">
                                        <!-- form start -->
                                        <div class="form-horizontal">

                                            <div class="box-body">
                                                <div class="col-lg-12">
                                                    <div class="col-md-5 col-lg-5">
                                                        <div class="form-group">
                                                            <label for="txtLotNo" class="col-sm-3 control-label">JOB No</label>
                                                            <div class="col-sm-7">
                                                                <input class="form-control" id="txtLotNo" runat="server" placeholder="JOB NO" autofocus="autofocus" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <button runat="server" class="btn btn-primary " type="button" onserverclick="Unnamed_ServerClick" id="btnSeletJob"><i class="fa fa-search"></i></button>
                                                                <%--<asp:Button runat="server" CSSClass="btn btn-primary" Text="Button" ID="Button1" OnClick="Unnamed_ServerClick"></asp:Button>--%>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cboJobSite" class="col-sm-3 control-label">JOB Site</label>
                                                            <div class="col-sm-5">
                                                                <asp:DropDownList ID="cboJobSite" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="checkbox">
                                                                    <label>
                                                                        <input type="checkbox" runat="server" id="NextMonth" onclick="chkExpEnable2();" />
                                                                        Next Month
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="dtpInvoiceDate" class="col-sm-4 control-label">JOB Date</label>
                                                            <div class="col-md-7">
                                                                <div class="input-group date">
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-calculator"></i>
                                                                    </div>
                                                                    <asp:TextBox CssClass="form-control" ID="dtpInvoiceDate" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                                    </asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="dtpInvoiceDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="dcbSales" class="col-sm-4 control-label">Site Man</label>
                                                            <div class="col-md-7">
                                                                <asp:DropDownList ID="dcbSales" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="DropDownList5" class="col-sm-4 control-label">JOB of</label>
                                                            <div class="col-md-7">
                                                                <asp:DropDownList ID="ComboBox2" CssClass="form-control" runat="server">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem>Air Out</asp:ListItem>
                                                                    <asp:ListItem>Sea Out</asp:ListItem>
                                                                    <asp:ListItem>Truck Out</asp:ListItem>
                                                                    <asp:ListItem>Other</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-md-11">
                                                                <input class="form-control pull-right" id="txtSalesName" runat="server" type="text" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </div>

                                                <div class="col-lg-12">
                                                    <div class="col-md-6 col-lg-6">
                                                        <fieldset>
                                                            <legend></legend>
                                                            <div class="form-group">
                                                                <label for="txtConsigneeCode" class="col-sm-3 control-label">Consignee Code</label>
                                                                <div class="col-md-6">
                                                                    <%--<asp:DropDownList ID="ddlConsigneeCode" CssClass="form-control select2" runat="server" DataTextField="PartyFullName" DataValueField="PartyCode"> </asp:DropDownList>--%>
                                                                    <input class="form-control pull-right" id="txtConsigneeCode" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <button runat="server" class="btn btn-primary btn-block" type="button" onserverclick="Unnamed_ServerClick1"><i class="fa fa-search"></i></button>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtConsignneeEng" class="col-sm-3 control-label">Name(Eng)</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtConsignneeEng" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtConsignneeStreet_Number" class="col-sm-3 control-label">Address1</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtConsignneeStreet_Number" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtConsignneeDistrict" class="col-sm-3 control-label">Address2</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtConsignneeDistrict" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtConsignneeSubProvince" class="col-sm-3 control-label">Address3</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtConsignneeSubProvince" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtConsignneeProvince" class="col-sm-3 control-label">Address4</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtConsignneeProvince" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtConsignneePostCode" class="col-sm-3 control-label">Address5</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtConsignneePostCode" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtConsignneeEMail" class="col-sm-3 control-label">E-Mail</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtConsignneeEMail" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <fieldset>
                                                            <legend></legend>
                                                            <div class="form-group">
                                                                <label for="txtExporterCode" class="col-sm-3 control-label">Exporter Code</label>
                                                                <div class="col-md-6">
                                                                    <%--  <asp:DropDownList ID="ddlExporterCode" CssClass="form-control select2" runat="server" DataTextField="Code" DataValueField="Code"> </asp:DropDownList>--%>
                                                                    <input class="form-control pull-right" id="txtExporterCode" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <button runat="server" class="btn btn-primary btn-block" type="button" onserverclick="Unnamed_ServerClick3"><i class="fa fa-search"></i></button>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtExportEng" class="col-sm-3 control-label">Name(Eng)</label>
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

                                                        </fieldset>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 col-lg-12">
                                                    <fieldset>
                                                        <legend></legend>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label for="txtCommodity" class="col-sm-4 control-label">Commodity</label>
                                                                <div class="col-md-8">
                                                                    <asp:DropDownList ID="txtCommodity" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtSubProvince" class="col-sm-4 control-label">Quantity PLT/Skid</label>
                                                                <div class="col-md-4">
                                                                    <input class="form-control pull-right" id="txtQuantityPLT" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="dcbQuantity2" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                                </div>
                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtBox" class="col-sm-4 control-label">Quantity Box</label>
                                                                <div class="col-md-4">
                                                                    <input class="form-control pull-right" id="txtBox" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="cdbBox1" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtVolume" class="col-sm-4 control-label">Volume</label>
                                                                <div class="col-md-4">
                                                                    <input class="form-control pull-right" id="txtVolume" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="dcbVolume" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="ComboBox7" CssClass="form-control" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>HAWB.</asp:ListItem>
                                                                        <asp:ListItem>HBL.</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtDocumentCode" runat="server" type="text" autocomplete="off" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtShipTo" class="col-sm-4 control-label">Ship To</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtShipTo" runat="server" type="text" autocomplete="off" />
                                                                </div>

                                                            </div>

                                                        </div>

                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label for="txtSubProvince" class="col-sm-4 control-label">Quantity of Part</label>
                                                                <div class="col-md-4">
                                                                    <input class="form-control pull-right" id="txtQuantityofPart" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="dcbQuantity1" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                                </div>
                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtSubProvince" class="col-sm-4 control-label">Weight</label>
                                                                <div class="col-md-4">
                                                                    <input class="form-control pull-right" id="txtWeight" runat="server" type="text" autocomplete="off" />
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="dcbWeight" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                                </div>
                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtMAWB" class="col-sm-4 control-label">MAWB/BL/TWB</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtMAWB" runat="server" type="text" autocomplete="off" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtFlight" class="col-sm-4 control-label">FLT/Voy/TruckDate</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtFlight" runat="server" type="text" autocomplete="off" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtFreigh" class="col-sm-4 control-label">Freigh Forwarder</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtFreigh" runat="server" type="text" autocomplete="off" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtBillingNo" class="col-sm-4 control-label">Billing No</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtBillingNo" runat="server" type="text" autocomplete="off" />
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtJobRemark" class="col-sm-2 control-label">Remark</label>
                                                            <div class="col-md-10">
                                                                <input class="form-control pull-right" id="txtJobRemark" runat="server" type="text" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                    </fieldset>
                                                </div>
                                                <div class="collg-12 col-md-12">
                                                    <fieldset>
                                                        <legend></legend>
                                                        <div class="form-group">
                                                            <label for="txtPathFile" class="col-sm-2 control-label">Select Files to Storage</label>
                                                            <div class="col-md-6">
                                                                <input class="form-control pull-right" id="txtPathFile" runat="server" type="text" autocomplete="off" />
                                                            </div>
                                                            <div class="col-md-4">
                                                                <input type="file" id="exampleInputFile">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtStatusFile" class="col-sm-2 control-label">Status File</label>
                                                            <div class="col-md-6">
                                                                <input class="form-control pull-right" id="txtStatusFile" runat="server" type="text" autocomplete="off" />
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:Button runat="server" ID="cmdOpenFile" Text="Open File" />
                                                                <asp:Button runat="server" ID="Bsave" Text="Save" OnClick="Bsave_Click" />
                                                            </div>
                                                        </div>
                                                    </fieldset>
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
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.col-->
                                </div>
                                <!-- /.rom -->
                            </div>
                            <!-- /.post -->
                        </div>
                        <div role="tabpanel" class="tab-pane" id="detail">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">

                                    <div class="col-lg-12 col-md-12">

                                        <div class="form-horizontal">
                                            <div class="box-body">

                                                <div class="col-lg-6 col-md-6">
                                                    <fieldset>
                                                        <legend>Delivery Place</legend>
                                                        <div class="form-group">
                                                            <label for="txtDOCode" class="col-sm-4 control-label">Code</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control pull-right" id="txtDOCode" runat="server" autocomplete="off" />
                                                                <%--  <asp:DropDownList ID="ddlDOCode" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"> </asp:DropDownList>--%>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <button runat="server" class="btn btn-primary btn-block" type="button" onserverclick="Unnamed_ServerClick2"><i class="fa fa-search"></i></button>
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtDONameENG" class="col-sm-4 control-label">Name (Eng)</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtDONameENG" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">

                                                            <label for="txtDOStreet" class="col-sm-4 control-label">Address1</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtDOStreet" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>


                                                        <div class="form-group">
                                                            <label for="txtDODistrict" class="col-sm-4 control-label">Address2</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtDODistrict" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">

                                                            <label for="txtDOSubProvince" class="col-sm-4 control-label">Address3</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtDOSubProvince" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtDOProvince" class="col-sm-4 control-label">Address4</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtDOProvince" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtDOPostCode" class="col-sm-4 control-label">Address5</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtDOPostCode" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtDOEmail" class="col-sm-4 control-label">E-Mail</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtDOEmail" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">

                                                            <label for="Contact Person" class="col-sm-4 control-label">Value Rate Amount :</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtDOContactPerson" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>


                                                    </fieldset>
                                                </div>

                                                <div class="col-lg-6 col-md-6">
                                                    <fieldset>
                                                        <legend>Customer</legend>
                                                        <div class="form-group">
                                                            <label for="txtCustomerCode" class="col-sm-4 control-label">Customer Code</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control" id="txtCustomerCode" runat="server" />
                                                                <%-- <asp:DropDownList ID="ddlCustomerCode" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"> </asp:DropDownList>--%>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <button runat="server" class="btn btn-primary btn-block" type="button" onserverclick="Unnamed_ServerClick4"><i class="fa fa-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerENG" class="col-sm-4 control-label">Name(Eng)</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCustomerENG" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">

                                                            <label for="txtCustomerStreet" class="col-sm-4 control-label">Address1</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCustomerStreet" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtCustomerDistrict" class="col-sm-4 control-label">Address2</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCustomerDistrict" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerSub" class="col-sm-4 control-label">Address3</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCustomerSub" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtCustomerProvince" class="col-sm-4 control-label">Address4</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCustomerProvince" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">

                                                            <label for="txtCustomerPostCode" class="col-sm-4 control-label">Address5</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCustomerPostCode" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtCustomerEmail" class="col-sm-4 control-label">E-mail</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCustomerEmail" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerContact" class="col-sm-4 control-label">Contact Person</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCustomerContact" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                    </fieldset>

                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <fieldset>
                                                        <legend>Pick Up Place</legend>
                                                        <div class="form-group">
                                                            <label for="txtPickUpCode" class="col-sm-4 control-label">Code</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control" id="txtPickUpCode" runat="server" autocomplete="off" />
                                                                <%--  <asp:DropDownList ID="ddlPickUpCode" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"> </asp:DropDownList>--%>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <button runat="server" class="btn btn-primary btn-block" type="button" onserverclick="Unnamed_ServerClick5"><i class="fa fa-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPickUpNameEng" class="col-sm-4 control-label">Name(Eng)</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtPickUpNameEng" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">

                                                            <label for="txtPickUpAddress1" class="col-sm-4 control-label">Address1</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtPickUpAddress1" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtPickUpAddress2" class="col-sm-4 control-label">Address2</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtPickUpAddress2" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPickUpAddress3" class="col-sm-4 control-label">Address3</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtPickUpAddress3" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtPickUpAddress4" class="col-sm-4 control-label">Address4</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtPickUpAddress4" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">

                                                            <label for="txtPickUpAddress5" class="col-sm-4 control-label">Address5</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtPickUpAddress5" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtPickUpEmail" class="col-sm-4 control-label">E-mail</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtPickUpEmail" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPickUpContact" class="col-sm-4 control-label">Contact Person</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtPickUpContact" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                    </fieldset>

                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <fieldset>
                                                        <legend>End Customer</legend>
                                                        <div class="form-group">
                                                            <label for="txtEndCusCode" class="col-sm-4 control-label">End Customer Code</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control" id="txtEndCusCode" runat="server" autocomplete="off" />
                                                                <%--    <asp:DropDownList ID="ddlEndCusCode" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"> </asp:DropDownList>--%>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <button runat="server" class="btn btn-primary btn-block" type="button" onserverclick="Unnamed_ServerClick6"><i class="fa fa-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtEndCusNameEng" class="col-sm-4 control-label">Name(Eng)</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtEndCusNameEng" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">

                                                            <label for="txtEndCusAddress1" class="col-sm-4 control-label">Address1</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtEndCusAddress1" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtEndCusAddress2" class="col-sm-4 control-label">Address2</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtEndCusAddress2" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtEndCusAddress3" class="col-sm-4 control-label">Address3</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtEndCusAddress3" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtEndCusAddress4" class="col-sm-4 control-label">Address4</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtEndCusAddress4" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">

                                                            <label for="txtEndCusAddress5" class="col-sm-4 control-label">Address5</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtEndCusAddress5" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtEndCusEmail" class="col-sm-4 control-label">E-mail</label>

                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtEndCusEmail" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtEndCusContact" class="col-sm-4 control-label">Contact Person</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtEndCusContact" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <fieldset>
                                                        <legend>Customer Group</legend>
                                                        <div class="form-group">
                                                            <label for="txtCustomerCodeGroup" class="col-sm-4 control-label">Code Group</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control" id="txtCustomerCodeGroup" runat="server" autocomplete="off" />
                                                                <%--   <asp:DropDownList ID="ddlCustomerCodeGroup" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"> </asp:DropDownList>--%>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <button runat="server" class="btn btn-primary btn-block" type="button" onserverclick="Unnamed_ServerClick7"><i class="fa fa-search"></i></button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerENGGroup" class="col-sm-4 control-label">Name Group (Eng)</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCustomerENGGroup" runat="server" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                    </fieldset>

                                                </div>
                                                <!-- /.box-body -->
                                            </div>
                                        </div>
                                        <!--/.col-lg-6 col-md-6--->
                                    </div>
                                    <!--/.row-->
                                </div>
                            </div>
                            <!-- /.post -->
                        </div>
                        <div role="tabpanel" class="tab-pane" id="invoice">
                            <!-- Post -->
                            <div class="post">
                                <div class="row margin-bottom">
                                    <div class="col-lg-12 col-md-12">
                                        <div class="form-horizontal">
                                            <div class="box-body">

                                                <div class="col-lg-6">
                                                    <fieldset>
                                                        <legend></legend>
                                                        <div class="form-group">
                                                            <label for="txtCustomerCodeGroup" class="col-sm-3 control-label">IEAT No</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control" id="txtIEATNo" runat="server" disabled="disabled" />
                                                                <div class="checkbox">
                                                                    <label>
                                                                        <input type="checkbox" runat="server" id="Checkbox1" onclick="EnableDisableTextBox();" />
                                                                        Request System Auto Generate IEAT No.
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <asp:Button runat="server" ID="Gen" Text="Gen" CssClass="btn" OnClick="Gen_Click" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtIEATPermit" class="col-sm-3 control-label">IEAT Permit</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtIEATPermit" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerENGGroup" class="col-sm-3 control-label">IEAT Date</label>
                                                            <div class="col-sm-8">


                                                                <div class="input-group date">
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-calculator"></i>
                                                                    </div>
                                                                    <asp:TextBox CssClass="form-control" ID="txtIEATDate" runat="server" placeholder="MM/DD/YYYY">
                                                                    </asp:TextBox>
                                                                    <%--<input class="form-control pull-right" id="dtpIEATDate" runat="server" type="text" />--%>
                                                                </div>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtIEATDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Customs Declaration</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control pull-right" id="txtEntryNo" runat="server" type="text" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Delivery Date</label>
                                                            <div class="col-sm-4">
                                                                <div class="input-group date">
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-calculator"></i>
                                                                    </div>
                                                                    <asp:TextBox CssClass="form-control" ID="dtpDeliveryDate" runat="server" placeholder="MM/DD/YYYY">
                                                                    </asp:TextBox>
                                                                    <%--<input class="form-control pull-right" id="dtpIEATDate" runat="server" type="text" />--%>
                                                                </div>
                                                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="dtpDeliveryDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                            </div>
                                                            <label for="txtCustomerENGGroup" class="col-sm-1 control-label">Time</label>
                                                            <div class="col-sm-3">
                                                                <div class="bootstrap-timepicker">
                                                                    <div class="form-group">
                                                                        <div class="input-group">
                                                                            <input type="text" class="form-control timepicker" runat="server" autocomplete="off" id="txtDeliveryTime">

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
                                                            <label for="dcbStatus1" class="col-sm-3 control-label">Status1</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="dcbStatus1" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem>บัญชีผลิตภัณฑ์ฯ</asp:ListItem>
                                                                    <asp:ListItem>บัญชีอื่นๆ</asp:ListItem>
                                                                    <asp:ListItem>วัตถุดิบ</asp:ListItem>
                                                                    <asp:ListItem>อื่นๆ</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="dcbStatus2" class="col-sm-3 control-label">Status2</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="dcbStatus2" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code" OnSelectedIndexChanged="dcbStatus2_SelectedIndexChanged">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem>ส่งออกไปต่างประเทศ(ใบขนฯขาออก)</asp:ListItem>
                                                                    <asp:ListItem>ใช้หรือจำหน่ายภายในประเทศ</asp:ListItem>
                                                                    <asp:ListItem>การโอนของออก</asp:ListItem>
                                                                    <asp:ListItem>การทำลาย</asp:ListItem>
                                                                    <asp:ListItem>ใช้หรือจำหน่ายภายในประเทศ(ชำระภาษี)</asp:ListItem>
                                                                    <asp:ListItem>นำออกชั่วคราว</asp:ListItem>
                                                                    <asp:ListItem>อื่นๆ</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Status3</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="dcbStatus3" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem>BOI</asp:ListItem>
                                                                    <asp:ListItem>19 ทวิ</asp:ListItem>
                                                                    <asp:ListItem>คลังสินค้าทัณฑ์บนฯ</asp:ListItem>
                                                                    <asp:ListItem>เขตประกอบการเสรีต่างเขตกัน</asp:ListItem>
                                                                    <asp:ListItem>เขตปลอดอากร</asp:ListItem>
                                                                    <asp:ListItem>อื่นๆ</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </fieldset>

                                                    <fieldset>
                                                        <legend></legend>
                                                        <div class="form-group">
                                                            <label for="txtEASInv" class="col-sm-3 control-label">EAS Invoice</label>
                                                            <div class="col-sm-6">
                                                                <input class="form-control" id="txtEASInv" runat="server" autocomplete="off" />
                                                                <div class="checkbox">
                                                                    <label>
                                                                        <input type="checkbox" runat="server" id="Checkbox3" onclick="chkExpEnable2();" />
                                                                        Request System Auto Generate EAS Invoice.
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <asp:Button runat="server" ID="Button2" Text="Gen" CssClass="btn" OnClick="Button2_Click" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPullSignal" class="col-sm-3 control-label">Pull Signal</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtPullSignal" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Customer Invoice</label>
                                                            <div class="col-sm-8">

                                                                <input class="form-control" id="txtCustomerINV" runat="server" type="text" autocomplete="off" />

                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtRemark" class="col-sm-3 control-label">Remark</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="txtRemark" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem>Clean Room Sorting</asp:ListItem>
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label for="txtCancleIEAT" class="col-sm-3 control-label">IEAT Cancle</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtCancleIEAT" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-11">
                                                                <div class="col-md-offset-6">
                                                                    <button type="button" class="btn btn-primary" id="btnInvoice" runat="server" onserverclick="btnInvoice_ServerClick">Save Invoice No.</button>
                                                                    <button type="button" class="btn btn-default" id="btnInv" runat="server" onserverclick="btnInv_ServerClick">Delete Inv.</button>
                                                                </div>
                                                                <asp:Repeater ID="dgvEASInv" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table class="table table-bordered">
                                                                            <th style="width: 10px">InvoiceNo</th>
                                                                            <th style="width: 10px">LOTNo</th>
                                                                            <th style="width: 10px">PullSignal</th>
                                                                            <th style="width: 10px">Remark</th>
                                                                            <th style="width: 10px">CustomerINV</th>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr class="success">
                                                                            <td>
                                                                                <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("PullSignal")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Remark")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("CustomerINV")%>'></asp:Label></td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <AlternatingItemTemplate>
                                                                        <tr class="info">
                                                                            <td>
                                                                                <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("PullSignal")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Remark")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("CustomerINV")%>'></asp:Label></td>
                                                                        </tr>
                                                                    </AlternatingItemTemplate>
                                                                    <FooterTemplate>
                                                                        <th>InvoiceNo</th>
                                                                        <td>LOTNo</td>
                                                                        <th>PullSignal</th>
                                                                        <th>Remark</th>
                                                                        <th>CustomerINV</th>
                                                                        </table>
                                                                    </FooterTemplate>

                                                                </asp:Repeater>

                                                            </div>
                                                        </div>

                                                    </fieldset>
                                                </div>
                                                <div class="col-lg-6">
                                                    <fieldset>
                                                        <legend></legend>
                                                        <div class="form-group">
                                                            <label for="txtGenInvNo" class="col-sm-3 control-label">Customer Invoice</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtGenInvNo" runat="server" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtQuantityDetail" class="col-sm-3 control-label">Quantiy</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control" id="txtQuantityDetail" runat="server" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="cdbUnitQuantityDetail" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPallet" class="col-sm-3 control-label">Pallet/Skid/Triwall</label>
                                                            <div class="col-sm-4">

                                                                <input class="form-control" id="txtPallet" runat="server" type="text" autocomplete="off" />

                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="cdbUnitPallet" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtBoxINV" class="col-sm-3 control-label">Box/Carton</label>
                                                            <div class="col-sm-4">

                                                                <input class="form-control" id="txtBoxINV" runat="server" type="text" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="cdbBox" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtWeightInv" class="col-sm-3 control-label">Weight</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control pull-right" id="txtWeightInv" runat="server" type="text" autocomplete="off" />
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <asp:DropDownList ID="cdbUnitWeightInv" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtPullS" class="col-sm-3 control-label">Pull Signal</label>
                                                            <div class="col-sm-8">

                                                                <input class="form-control" id="txtPullS" runat="server" type="text" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtWeightInv" class="col-sm-3 control-label">Date Invoice</label>

                                                            <div class="col-sm-4">
                                                                <div class="input-group date">
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-calculator"></i>
                                                                    </div>
                                                                    <asp:TextBox CssClass="form-control" ID="dtpInvoice" runat="server" placeholder="MM/DD/YYYY">
                                                                    </asp:TextBox>
                                                                    <%--<input class="form-control pull-right" id="dtpIEATDate" runat="server" type="text" />--%>
                                                                </div>
                                                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" TargetControlID="dtpInvoice" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                            </div>

                                                            <label for="txtWeightInv" class="col-sm-2 control-label">ITem No</label>
                                                            <div class="col-sm-2">
                                                                <input class="form-control" id="txtItemNo" runat="server" type="text" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtShipment" class="col-sm-3 control-label">Shipment</label>
                                                            <div class="col-sm-8">

                                                                <input class="form-control" id="txtShipment" runat="server" type="text" autocomplete="off" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Price(Bath)</label>
                                                            <div class="col-sm-8">

                                                                <input class="form-control" id="txtPriceBath" runat="server" type="text" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Price(Foreign)</label>
                                                            <div class="col-sm-8">

                                                                <input class="form-control" id="txtPriceForeign" runat="server" type="text" />
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <div class="col-md-11 col-xs-10">
                                                                <div class="col-md-offset-7">
                                                                    <div class="form-group">
                                                                        <div class="checkbox">
                                                                            <label>
                                                                                <input type="checkbox" runat="server" id="chkAssign" />
                                                                                To Assign Detail 
                                                                            </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <button type="button" class="btn btn-primary" runat="server" id="cmdGenInvNo" onserverclick="cmdGenInvNo_ServerClick">Save</button>
                                                                        <button type="button" class="btn btn-default" runat="server" id="Button4" onserverclick="Button4_ServerClick">Modify</button>
                                                                        <button type="button" class="btn btn-danger" runat="server" id="cmdDeleteInv" onserverclick="cmdDeleteInv_ServerClick">Delete</button>
                                                                    </div>
                                                                </div>
                                                                <asp:Repeater ID="dgvInvNo" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table class="table table-bordered">
                                                                            <th style="width: 10px">InvoiceNo</th>
                                                                            <th style="width: 10px">ReferenceNo</th>
                                                                            <th style="width: 10px">ReferenceDate</th>
                                                                            <th style="width: 10px">Quantity</th>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr class="success">
                                                                            <td>
                                                                                <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("DateInv", "{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Quantity")%>'></asp:Label></td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <AlternatingItemTemplate>
                                                                        <tr class="info">
                                                                            <td>
                                                                                <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("DateInv", "{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Quantity")%>'></asp:Label></td>
                                                                        </tr>
                                                                    </AlternatingItemTemplate>
                                                                    <FooterTemplate>
                                                                        <th>InvoiceNo</th>
                                                                        <th>ReferenceNo</th>
                                                                        <th>ReferenceDate</th>
                                                                        <th>Quantity</th>
                                                                        </table>
                                                                    </FooterTemplate>

                                                                </asp:Repeater>

                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                    <input runat="server" id="txtTypeCode" visible="false" />
                                                    <input runat="server" id="txtRunNo" visible="false" />
                                                    <input runat="server" id="txtMountNo" visible="false" />
                                                    <input runat="server" id="txtYearNo" visible="false" />
                                                    <input runat="server" id="txtDigitNo" visible="false" />
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.box-body -->

                                    </div>
                                    <!--/.col-lg-6 col-md-6--->
                                </div>
                                <!--/.row-->
                            </div>
                            <!-- /.post -->
                        </div>
                    </div>
                </div>
                <%--<asp:Button ID="Button1" Text="Submit" runat="server" CssClass="btn btn-primary" />--%>
                <asp:HiddenField ID="TabName" runat="server" />
            </div>
            <!-- /.row -->
        </section>
        <!-- /.content -->

        <!-- Modal JoB No-->
        <asp:Panel ID="Panel1" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="exampleModalLabel">Select JOB No</h4>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvLot" runat="server" OnItemCommand="dgvLot_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example1" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>EASLOTNo</th>
                                                                <th>CustomerCode</th>
                                                                <th>EndCusCode</th>
                                                                <th>JobSite</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="selectLotNO" CommandArgument='<%# Eval("EASLOTNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEASLOTNo" runat="server" Text='<%# Bind("EASLOTNo")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Bind("CustomerCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblEndCusCode" runat="server" Text='<%# Bind("EndCusCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("JobSite")%>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>EASLOTNo</th>
                                                            <th>CustomerCode</th>
                                                            <th>EndCusCode</th>
                                                            <th>JobSite</th>
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
        <asp:Panel ID="Panel2" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvConsigneeCode" runat="server" OnItemCommand="dgvConsigneeCode_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example1" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectConsigneeCode" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEASLOTNo" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblEndCusCode" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>PartyCode</th>
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

                                            <asp:Repeater ID="dgvExporterCode" runat="server" OnItemCommand="dgvExporterCode_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example3" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectExporterCode" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEASLOTNo" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblEndCusCode" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>PartyCode</th>
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
        <asp:Panel ID="plDOCode" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upDOCod" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvcodeconsignnee" runat="server" OnItemCommand="dgvcodeconsignnee_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example4" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="Selectcodeconsignnee" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEASLOTNo" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblEndCusCode" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>


                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>PartyCode</th>
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
        <asp:Panel ID="plCustomerCode" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upCustomerCode" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvCustomer" runat="server" OnItemCommand="dgvCustomer_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example5" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectCustomer" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEASLOTNo" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblEndCusCode" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>PartyCode</th>
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
        <asp:Panel ID="plPickUpCode" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upPickUpCode" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvPickUp" runat="server" OnItemCommand="dgvPickUp_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example6" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>

                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectPickUp" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEASLOTNo" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblEndCusCode" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>

                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>PartyCode</th>
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
        <asp:Panel ID="plEndCusCode" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upEndCusCode" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvEndCus" runat="server" OnItemCommand="dgvEndCus_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example7" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyFullName</th>
                                                                <th>Address1</th>
                                                                <th>Address2</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectEndCus" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEASLOTNo" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblEndCusCode" runat="server" Text='<%# Bind("Address1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblJobSite" runat="server" Text='<%# Bind("Address2")%>'></asp:Label></td>


                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>PartyCode</th>
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
        <asp:Panel ID="plCustomerGroup" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Code</h4>
                    </div>
                    <asp:UpdatePanel ID="upCustomerGroup" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="dgvCustomerGroup" runat="server" OnItemCommand="dgvCustomerGroup_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example8" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>PartyFullName</th>

                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectCustomerGroup" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEASLOTNo" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>PartyCode</th>
                                                            <th>PartyFullName</th>

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
            function EnableDisableTextBox() {
                var status = document.getElementById('<%=Checkbox1.ClientID%>').checked;

              if (status == true) {
                  document.getElementById('<%=Gen.ClientID%>').disabled = false;

              } else if (status == false) {
                  document.getElementById('<%=Gen.ClientID%>').disabled = true;
            }

    }
        </script>
        <script type="text/javascript">
            function chkExpEnable2() {
                var status = document.getElementById('<%=Checkbox3.ClientID%>').checked;

                  if (status == true) {
                      document.getElementById('<%=Button2.ClientID%>').disabled = false;

                  } else if (status == false) {
                      document.getElementById('<%=Button2.ClientID%>').disabled = true;
              }

      }
        </script>
         <script type="text/javascript">
             $(function () {
                 var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "master";
                 $('#Tabs a[href="#' + tabName + '"]').tab('show');
                 $("#Tabs a").click(function () {
                     $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                 });
             });
</script>
    </form>
</asp:Content>
