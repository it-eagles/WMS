<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomsInvoice.aspx.vb" Inherits="WMS.CustomsInvoice" EnableEventValidation="false" EnableViewState="true" MasterPageFile="~/Home.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Export Customs Invoice & Packing List
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Issue Process</a></li>
                <li><a class="active">Customs Invoice</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->
                <div class="col-lg-12 col-md-12">

                    <!-- general form elements -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <h3 class="box-title p-t-8">Export Customs Invoice & Packing List</h3>
                                </div>
                                <%-- <div class="col-sm-2">
                                 <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal"><i class="glyphicon glyphicon-search"></i></button>
                            </div>--%>
                            </div>
                        </div>

                        <!-- /.box-header -->
                        <div class="form-horizontal">
                            <div class="box-body">
                                <div class="col-md-12">
                                    <div class="form-group">

                                        <div class="col-md-3">

                                            <label for="txtTruckWayBill">Customs Declaration No</label>

                                            <input class="form-control" id="txtTruckWayBill" runat="server" />


                                        </div>


                                        <div class="col-md-3">

                                            <label for="txtTruckWayBill">Date</label>
                                            <div class="input-group date col-md-12">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calculator"></i>
                                                </div>
                                                <asp:TextBox CssClass="form-control" ID="CustomsConfirmDate" runat="server" placeholder="MM/DD/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="CustomsConfirmDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>



                                        </div>

                                        <div class="col-md-3">

                                            <label for="txtTruckWayBill">Invoice No</label>

                                            <input class="form-control" id="Text1" runat="server" />

                                        </div>


                                        <div class="col-md-3">

                                            <label for="txtTruckWayBill">JOB No</label>

                                            <input class="form-control" id="Text2" runat="server" />


                                        </div>
                                    </div>
                                    <div class="form-group">

                                   <div class="col-md-3">

                                            <label for="txtTruckWayBill">Invoice Date</label>
                                            <div class="input-group date col-md-12">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calculator"></i>
                                                </div>
                                                <asp:TextBox CssClass="form-control" ID="dtpInvoiceDate" runat="server" placeholder="MM/DD/YYYY">
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
                                                <asp:TextBox CssClass="form-control" ID="dtpDeliveryDate" runat="server" placeholder="MM/DD/YYYY">
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
                                                <asp:TextBox CssClass="form-control" ID="dtpReferenceDate" runat="server" placeholder="MM/DD/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" TargetControlID="dtpReferenceDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>



                                        </div>

                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
            

            <div class="row">
                <!-- left column -->

                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#header" data-toggle="tab">Invoice Header</a></li>
                            <li><a href="#job" data-toggle="tab">EAS JOB</a></li>
                            <li><a href="#deetail" data-toggle="tab">Item Detail</a></li>
                            <li><a href="#list" data-toggle="tab">Packing List</a></li>
                     
                        </ul>

                        <div class="tab-content">

                            <!------- Invoice Header ---------->
                            <div class="active tab-pane" id="header">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">

                                        <div class="col-lg-12 col-md-12">
                                            <!-- form start -->

                                            <div class="form-horizontal">

                                             <div class="box-body">
                                                
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="col-md-6">
                                                            
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
                                                                    <label for="txtProvince" class="col-sm-3 control-label">Address3</label>
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

                                                        </div>
                                                        <div class="col-md-6">
                                                            
                                                                <div class="form-group">
                                                                    <label for="dcboCountry" class="col-sm-3 control-label">Origin Country</label>
                                                                    <div class="col-md-4">
                                                                          <asp:DropDownList ID="dcboCountry" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                       
                                                                        </asp:DropDownList>
                                                                       <%-- <input class="form-control pull-right" id="txtNotifyParty" runat="server" type="text" />--%>
                                                                    </div>
                                                                
                                                                    <div class="col-md-4">
                                                                        <input class="form-control pull-right" id="txtCountry" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="dcboPurchaseCountry" class="col-sm-3 control-label">Purchase Country</label>
                                                                    <div class="col-md-4">
                                                                          <asp:DropDownList ID="dcboPurchaseCountry" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                         
                                                                        </asp:DropDownList>
                                                                       <%-- <input class="form-control pull-right" id="txtCarLicense" runat="server" type="text" />--%>
                                                                    </div>
                                                                     <div class="col-md-4">
                                                                        <input class="form-control pull-right" id="Text3" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="cboDestinationCountry" class="col-sm-3 control-label">Destination Country</label>
                                                                    <div class="col-md-4">
                                                                          <asp:DropDownList ID="cboDestinationCountry" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                         
                                                                        </asp:DropDownList>
                                                                       <%-- <input class="form-control pull-right" id="txtCarLicense" runat="server" type="text" />--%>
                                                                    </div>
                                                                     <div class="col-md-4">
                                                                        <input class="form-control pull-right" id="txtDestinationCountry" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="dcboTermofPayment" class="col-sm-3 control-label">Term of Payment</label>
                                                                    <div class="col-md-8">
                                                                         <asp:DropDownList ID="dcboTermofPayment" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                         
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="dcboTerm" class="col-sm-3 control-label">Term</label>
                                                                    <div class="col-md-8">
                                                                        <asp:DropDownList ID="dcboTerm" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code">
                                                                         
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                               <div class="form-group">
                                                                    <label for="txtStreet_Number" class="col-sm-3 control-label">Address1</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text4" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtDistrict" class="col-sm-3 control-label">Address2</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text5" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtProvince" class="col-sm-3 control-label">Address3</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text6" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtPostCode" class="col-sm-3 control-label">Address5</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text7" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtCompensateCode" class="col-sm-3 control-label">Email</label>
                                                                    <div class="col-md-8">
                                                                        <input class="form-control pull-right" id="Text8" runat="server" type="text" />
                                                                    </div>
                                                                </div>
                                                        </div>


                                                    </div>
                                             
                                                    <div class="col-lg-12 col-md-12">
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
                                                               
                                                            </fieldset>
                                                        </div>


                                                    </div>
                                                </div>
                                                

                                                </div>

                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->

                                        </div>
                                        <!--/.row-->
                                    </div>
                                    </div>
                            <!------- /.Invoice Header ---------->

                          
                            </div>
                        </div>
                    </div>
                </div>
            </section>
    </form>
</asp:Content>
