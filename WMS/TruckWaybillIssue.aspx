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
                                                                <label for="txtExporterCode" class="col-sm-3 control-label">Exporter Code</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="Text1" runat="server" type="text" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtExportEng" class="col-sm-3 control-label">Name(Eng)</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="Text2" runat="server" type="text" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtStreet_Number" class="col-sm-3 control-label">Address1</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="Text3" runat="server" type="text" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtDistrict" class="col-sm-3 control-label">Address2</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="Text4" runat="server" type="text" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtSubProvince" class="col-sm-3 control-label">Address3</label>
                                                                <div class="col-md-8">
                                                                    <input class="form-control pull-right" id="Text5" runat="server" type="text" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtProvince" class="col-sm-3 control-label">Address4</label>
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

                                                        </fieldset>
                                                    </div>
                                                     </div>
                                                    
                                               </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- ./head -->



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


