<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PickingWH.aspx.vb" Inherits="WMS.PickingWH" MasterPageFile="~/Home.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Picking
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>WareHouse</a></li>
                <li><a href="PickingWH.aspx" class="active">Picking</a></li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <!-- left column -->
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

                            <!-- /.col -->
                            <div class="col-md-12 col-lg-12 col-sm-12">
                                <fieldset>
                                    <legend></legend>
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtPullSignal">Pull Signal:</label>
                                                <input class="form-control input-sm" id="txtPullSignal_BeforeTab" runat="server" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtJobNo">Job No:</label>
                                                <input class="form-control input-sm" id="txtJobNo_BeforeTab" runat="server" autocomplete="off" />

                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <div style="padding: 12px">

                                            </div>
                                            <button runat="server" class="btn btn-primary btn-sm" type="button"  id="btnSeletJobNew"><i class="fa fa-search"></i></button>
                                            <button runat="server" class="btn  btn-danger btn-sm" type="button"  id="btnSelectJobEdit"><i class="fa fa-search"></i></button>
                                        </div>
                                        <div class="col-sm-1">
                                            <div class="form-group">
                                                <label>SCRAP</label>
                                                <div class="checkbox">
                                                    <label style="padding-right:10px"> 
                                                        <input type="checkbox" runat="server" id="chkScrap" />
                                                    </label>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="txtPullDateTime">Pull Date</label>

                                                <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickertxtPullDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderPullDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickertxtPullDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Time</label>
                                            <div class="bootstrap-timepicker">
                                                <div class="input-group">
                                                    <input type="text" class="form-control timepicker input-sm" id="txtTimePickUpPullDateTime" />
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-clock-o"></i>
                                                    </div>
                                                </div>
                                                <!-- /.input group -->
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtDeliveryDateTime">Delivery Date</label>
                                                <asp:TextBox CssClass="form-control" ID="txtdatepickerDeliveryDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderDeliveryDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerDeliveryDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <label for="txtDeliveryDateTime">Time</label>
                                                <div class="bootstrap-timepicker">
                                                    <div class="input-group">
                                                        <input type="text" class="form-control timepicker" id="txtTimePickUpDeliveryDateTime" />
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-clock-o"></i>
                                                        </div>
                                                    </div>
                                                    <!-- /.input group -->
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtConfirmDateTime">Confirm Date</label>
                                                <asp:TextBox CssClass="form-control" ID="txtdatepickerComfirmDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderComfirmDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerComfirmDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>

                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <label for="txtConfirmDateTime">Time</label>
                                                <div class="bootstrap-timepicker">
                                                    <div class="input-group">
                                                        <input type="text" class="form-control timepicker" id="txtTimePickUpConfirmDateTime" />
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-clock-o"></i>
                                                        </div>
                                                    </div>
                                                    <!-- /.input group -->
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </fieldset>
                            </div>

                        </div>
                    </div>
                </div>
            </div>


            <!-- /.row -->
        </section>
        <!-- /.content -->

    </form>
</asp:Content>
