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
                <!-- left column -->

                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#master" data-toggle="tab">Master JOB</a></li>
                            <li><a href="#detail" data-toggle="tab">JOB Detail</a></li>
                            <li><a href="#invoice" data-toggle="tab">Invoice</a></li>

                        </ul>

                        <div class="tab-content">

                            <!------- master ---------->
                            <div class="active tab-pane" id="master">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">

                                        <div class="col-lg-10 col-md-8 col-md-offset-1">
                                            <!-- form start -->

                                            <div class="form-horizontal">

                                                <div class="box-body">
                                                    <div class="col-md-4">
                                                        <div class="form-group">

                                                            <label for="txtLotNo" class="col-sm-3 control-label">JOB No</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control" id="txtLotNo" runat="server" placeholder="JOB NO" />
                                                            </div>
                                                        </div>


                                                        <div class="form-group">
                                                            <label for="cboJobSite" class="col-sm-3 control-label">JOB Site</label>
                                                            <div class="col-sm-5">
                                                                <asp:DropDownList ID="cboJobSite" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
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
                                                            <label for="dtpInvoiceDate" class="col-sm-3 control-label">JOB Date</label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox CssClass="form-control" ID="txtDateIt_R" runat="server" placeholder="MM/DD/YYYY">
                                                                </asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtDateIt_R" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                              <%--  <div class="input-group date">
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-calculator"></i>
                                                                    </div>
                                                                    <input class="form-control pull-right" id="dtpInvoiceDate" type="text" />
                                                                </div>--%>

                                                            </div>
                                                        </div>
                                                        <div class="form-group">

                                                            <label for="dcbSales" class="col-sm-3 control-label">Site Man</label>
                                                            <div class="col-md-8">
                                                                <asp:DropDownList ID="dcbSales" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>

                                                            </div>

                                                        </div>

                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="DropDownList5" class="col-sm-3 control-label">JOB of</label>
                                                            <div class="col-md-8">

                                                                <asp:DropDownList ID="DropDownList5" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>

                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-md-11">
                                                                <input class="form-control pull-right" id="txtSalesName" runat="server" type="text" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->

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
                                                                <label for="txtConsignneeEng" class="col-sm-3 control-label">Name(Eng)</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtConsignneeEng" runat="server" type="text" />
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
                                                                <label for="txtConsignneeProvince" class="col-sm-3 control-label">Address4</label>
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
                                                                <label for="txtConsignneeEMail" class="col-sm-3 control-label">E-Mail</label>
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
                                                                <label for="txtExporterCode" class="col-sm-3 control-label">Exporter Code</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="txtExporterCode" runat="server" type="text" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtExportEng" class="col-sm-3 control-label">Name(Eng)</label>
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
                                                    <div class="col-md-12 col-lg-12">
                                                        <fieldset>
                                                            <legend></legend>
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label for="txtCommodity" class="col-sm-4 control-label">Commodity</label>
                                                                    <div class="col-md-8">
                                                                        <asp:DropDownList ID="txtCommodity" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtSubProvince" class="col-sm-4 control-label">Quantity PLT/Skid</label>
                                                                    <div class="col-md-4">
                                                                        <input class="form-control pull-right" id="txtQuantityPLT" runat="server" type="text" />
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:DropDownList ID="dcbQuantity2" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label for="txtBox" class="col-sm-4 control-label">Quantity Box</label>
                                                                    <div class="col-md-4">
                                                                        <input class="form-control pull-right" id="txtBox" runat="server" type="text" />
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:DropDownList ID="cdbBox1" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtVolume" class="col-sm-4 control-label">Volume</label>
                                                                    <div class="col-md-4">
                                                                        <input class="form-control pull-right" id="txtVolume" runat="server" type="text" />
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:DropDownList ID="dcbVolume" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-md-4">
                                                                        <asp:DropDownList ID="ComboBox7" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtDocumentCode" runat="server" type="text" />
                                                                    </div>

                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtShipTo" class="col-sm-4 control-label">Ship To</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtShipTo" runat="server" type="text" />
                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label for="txtSubProvince" class="col-sm-4 control-label">Quantity of Part</label>
                                                                    <div class="col-md-4">
                                                                        <input class="form-control pull-right" id="txtQuantityofPart" runat="server" type="text" />
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:DropDownList ID="dcbQuantity1" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label for="txtSubProvince" class="col-sm-4 control-label">Weight</label>
                                                                    <div class="col-md-4">
                                                                        <input class="form-control pull-right" id="txtWeight" runat="server" type="text" />
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:DropDownList ID="dcbWeight" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label for="txtMAWB" class="col-sm-4 control-label">MAWB/BL/TWB</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtMAWB" runat="server" type="text" />
                                                                    </div>

                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtFlight" class="col-sm-4 control-label">FLT/Voy/TruckDate</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtFlight" runat="server" type="text" />
                                                                    </div>

                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtFreigh" class="col-sm-4 control-label">Freigh Forwarder</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtFreigh" runat="server" type="text" />
                                                                    </div>

                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtBillingNo" class="col-sm-4 control-label">Billing No</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="txtBillingNo" runat="server" type="text" />
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtJobRemark" class="col-sm-2 control-label">Remark</label>
                                                                <div class="col-md-10">
                                                                    <input class="form-control pull-right" id="txtJobRemark" runat="server" type="text" />
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
                                                                    <input class="form-control pull-right" id="txtPathFile" runat="server" type="text" />
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <input type="file" id="exampleInputFile">
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtStatusFile" class="col-sm-2 control-label">Status File</label>
                                                                <div class="col-md-6">
                                                                    <input class="form-control pull-right" id="txtStatusFile" runat="server" type="text" />
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:Button runat="server" ID="cmdOpenFile" Text="Open File" />
                                                                    <asp:Button runat="server" ID="Bsave" Text="Save" />
                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                        <div class="collg-12 col-md-12">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <table class="table table-bordered">
                                                                    <tr>
                                                                        <th style="width: 10px">#</th>
                                                                        <th>Task</th>
                                                                        <th>Progress</th>
                                                                        <th style="width: 40px">Label</th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>1.</td>
                                                                        <td>Update software</td>
                                                                        <td>
                                                                            <div class="progress progress-xs">
                                                                                <div class="progress-bar progress-bar-danger" style="width: 55%"></div>
                                                                            </div>
                                                                        </td>
                                                                        <td><span class="badge bg-red">55%</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>2.</td>
                                                                        <td>Clean database</td>
                                                                        <td>
                                                                            <div class="progress progress-xs">
                                                                                <div class="progress-bar progress-bar-yellow" style="width: 70%"></div>
                                                                            </div>
                                                                        </td>
                                                                        <td><span class="badge bg-yellow">70%</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>3.</td>
                                                                        <td>Cron job running</td>
                                                                        <td>
                                                                            <div class="progress progress-xs progress-striped active">
                                                                                <div class="progress-bar progress-bar-primary" style="width: 30%"></div>
                                                                            </div>
                                                                        </td>
                                                                        <td><span class="badge bg-light-blue">30%</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>4.</td>
                                                                        <td>Fix and squish bugs</td>
                                                                        <td>
                                                                            <div class="progress progress-xs progress-striped active">
                                                                                <div class="progress-bar progress-bar-success" style="width: 90%"></div>
                                                                            </div>
                                                                        </td>
                                                                        <td><span class="badge bg-green">90%</span></td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                    <!--/.col-lg-6 col-md-6 stockqty--->
                                                </div>

                                                <!--/.row-->
                                            </div>
                                        </div>

                                    </div>
                                    <!-- /.post -->
                                </div>
                            </div>
                            <!------- /.master ---------->


                            <!-------- detail --------->
                            <div class="tab-pane" id="detail">
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
                                                                    <input class="form-control" id="txtDOCode" runat="server" />

                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtDONameENG" class="col-sm-4 control-label">Name (Eng)</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtDONameENG" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">

                                                                <label for="txtDOStreet" class="col-sm-4 control-label">Address1</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtDOStreet" runat="server" />
                                                                </div>

                                                            </div>


                                                            <div class="form-group">
                                                                <label for="txtDODistrict" class="col-sm-4 control-label">Address2</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtDODistrict" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">

                                                                <label for="txtDOSubProvince" class="col-sm-4 control-label">Address3</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtDOSubProvince" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtDOProvince" class="col-sm-4 control-label">Address4</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtDOProvince" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtDOPostCode" class="col-sm-4 control-label">Address5</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtDOPostCode" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtDOEmail" class="col-sm-4 control-label">E-Mail</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtDOEmail" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">

                                                                <label for="Contact Person" class="col-sm-4 control-label">Value Rate Amount :</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtDOContactPerson" runat="server" />
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
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerENG" class="col-sm-4 control-label">Name(Eng)</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerENG" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">

                                                                <label for="txtCustomerStreet" class="col-sm-4 control-label">Address1</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerStreet" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtCustomerDistrict" class="col-sm-4 control-label">Address2</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerDistrict" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerSub" class="col-sm-4 control-label">Address3</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerSub" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtCustomerProvince" class="col-sm-4 control-label">Address4</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerProvince" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">

                                                                <label for="txtCustomerPostCode" class="col-sm-4 control-label">Address5</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerPostCode" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtCustomerEmail" class="col-sm-4 control-label">E-mail</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerEmail" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerContact" class="col-sm-4 control-label">Contact Person</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerContact" runat="server" />
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
                                                                    <input class="form-control" id="txtPickUpCode" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtPickUpNameEng" class="col-sm-4 control-label">Name(Eng)</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPickUpNameEng" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">

                                                                <label for="txtPickUpAddress1" class="col-sm-4 control-label">Address1</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPickUpAddress1" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtPickUpAddress2" class="col-sm-4 control-label">Address2</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPickUpAddress2" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtPickUpAddress3" class="col-sm-4 control-label">Address3</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPickUpAddress3" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtPickUpAddress4" class="col-sm-4 control-label">Address4</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPickUpAddress4" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">

                                                                <label for="txtPickUpAddress5" class="col-sm-4 control-label">Address5</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPickUpAddress5" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtPickUpEmail" class="col-sm-4 control-label">E-mail</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPickUpEmail" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtPickUpContact" class="col-sm-4 control-label">Contact Person</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPickUpContact" runat="server" />
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
                                                                    <input class="form-control" id="txtEndCusCode" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEndCusNameEng" class="col-sm-4 control-label">Name(Eng)</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEndCusNameEng" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">

                                                                <label for="txtEndCusAddress1" class="col-sm-4 control-label">Address1</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEndCusAddress1" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtEndCusAddress2" class="col-sm-4 control-label">Address2</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEndCusAddress2" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEndCusAddress3" class="col-sm-4 control-label">Address3</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEndCusAddress3" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtEndCusAddress4" class="col-sm-4 control-label">Address4</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEndCusAddress4" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">

                                                                <label for="txtEndCusAddress5" class="col-sm-4 control-label">Address5</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEndCusAddress5" runat="server" />
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtEndCusEmail" class="col-sm-4 control-label">E-mail</label>

                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEndCusEmail" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtEndCusContact" class="col-sm-4 control-label">Contact Person</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtEndCusContact" runat="server" />
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
                                                                    <input class="form-control" id="txtCustomerCodeGroup" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerENGGroup" class="col-sm-4 control-label">Name Group (Eng)</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerENGGroup" runat="server" />
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
                            <!-----/ Export Goods----->

                            <!--- Detailof Goods --->



                            <!--- Asembly --->
                            <div class="tab-pane" id="invoice">
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
                                                                <div class="col-sm-4">
                                                                    <input class="form-control" id="txtIEATNo" runat="server" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:Button runat="server" ID="Gen" Text="Gen" />
                                                                </div>
                                                                <div class="checkbox col-md-offset-4">
                                                                    <label>
                                                                        <input type="checkbox" runat="server" id="Checkbox1" onclick="chkExpEnable2();" />
                                                                        Request System Auto Generate IEAT No.
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtIEATPermit" class="col-sm-3 control-label">IEAT Permit</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtIEATPermit" runat="server" />
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
                                                                    <input class="form-control pull-right" id="txtEntryNo" runat="server" type="text" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Delivery Date</label>
                                                                <div class="col-sm-4">
                                                                    <div class="input-group date">
                                                                        <div class="input-group-addon">
                                                                            <i class="fa fa-calculator"></i>
                                                                        </div>
                                                                        <input class="form-control pull-right" id="Text3" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <label for="txtCustomerENGGroup" class="col-sm-1 control-label">Time</label>
                                                                <div class="col-sm-3">
                                                                    <div class="bootstrap-timepicker">
                                                                        <div class="form-group">
                                                                            <div class="input-group">
                                                                                <input type="text" class="form-control timepicker" runat="server">

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
                                                                    <asp:DropDownList ID="dcbStatus1" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="dcbStatus2" class="col-sm-3 control-label">Status2</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="dcbStatus2" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Status3</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="dcbStatus3" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                        <fieldset>
                                                            <legend></legend>
                                                            <div class="form-group">
                                                                <label for="txtEASInv" class="col-sm-3 control-label">EAS Invoice</label>
                                                                <div class="col-sm-4">
                                                                    <input class="form-control" id="txtEASInv" runat="server" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:Button runat="server" ID="Button2" Text="Gen" />
                                                                </div>
                                                                <div class="checkbox col-md-offset-4">
                                                                    <label>
                                                                        <input type="checkbox" runat="server" id="Checkbox3" onclick="chkExpEnable2();" />
                                                                        Request System Auto Generate EAS Invoice.
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtPullSignal" class="col-sm-3 control-label">Pull Signal</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPullSignal" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Customer Invoice</label>
                                                                <div class="col-sm-8">

                                                                    <input class="form-control" id="txtCustomerINV" runat="server" type="text" />

                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtRemark" class="col-sm-3 control-label">Remark</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="txtRemark" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                </div>

                                                            </div>

                                                            <div class="form-group">
                                                                <label for="txtCancleIEAT" class="col-sm-3 control-label">IEAT Cancle</label>
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCancleIEAT" runat="server" />
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
                                                                    <input class="form-control" id="txtGenInvNo" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtQuantityDetail" class="col-sm-3 control-label">Quantiy</label>
                                                                <div class="col-sm-4">
                                                                    <input class="form-control" id="txtQuantityDetail" runat="server" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList ID="cdbUnitQuantityDetail" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtPallet" class="col-sm-3 control-label">Pallet/Skid/Triwall</label>
                                                                <div class="col-sm-4">

                                                                    <input class="form-control" id="txtPallet" runat="server" type="text" />

                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList ID="cdbUnitPallet" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtBoxINV" class="col-sm-3 control-label">Box/Carton</label>
                                                                <div class="col-sm-4">

                                                                    <input class="form-control" id="txtBoxINV" runat="server" type="text" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList ID="cdbBox" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtWeightInv" class="col-sm-3 control-label">Weight</label>
                                                                <div class="col-sm-4">
                                                                    <input class="form-control pull-right" id="txtWeightInv" runat="server" type="text" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList ID="cdbUnitWeightInv" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtPullS" class="col-sm-3 control-label">Pull Signal</label>
                                                                <div class="col-sm-8">

                                                                    <input class="form-control" id="txtPullS" runat="server" type="text" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtWeightInv" class="col-sm-3 control-label">Date Invoice</label>
                                                                <div class="col-sm-4">
                                                                    <input class="form-control pull-right" id="Text1" runat="server" type="text" />
                                                                </div>
                                                                <label for="txtWeightInv" class="col-sm-2 control-label">ITem No</label>
                                                                <div class="col-sm-4">
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtShipment" class="col-sm-3 control-label">Shipment</label>
                                                                <div class="col-sm-8">

                                                                    <input class="form-control" id="txtShipment" runat="server" type="text" />
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Price(Bath)</label>
                                                                <div class="col-sm-8">

                                                                    <input class="form-control" id="txtPriceBath" runat="server" type="text" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtCustomerENGGroup" class="col-sm-3 control-label">Price(Foreign)</label>
                                                                <div class="col-sm-8">

                                                                    <input class="form-control" id="txtPriceForeign" runat="server" type="text" />
                                                                </div>
                                                            </div>
                                                        </fieldset>
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
                            <!----/ .Asembly----->



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


    </form>
</asp:Content>
