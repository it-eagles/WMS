<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreateRec.aspx.vb" Inherits="WMS.CreateRec" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Create Rec. LOT
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Receive Process</a></li>
                <li><a href="CreateRec.aspx" class="active">Create Rec. LOT</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box box-default">
                        <div class="box-body">
                            <div class="col-xs-6">
                                <button class="btn btn-app" id="btnAddHead" runat="server" onserverclick="btnAddHead_ServerClick"><i class="fa fa-inbox"></i>Add</button>
                                <button class="btn btn-app" id="btnEditHead" runat="server" onserverclick="btnEditHead_ServerClick"><i class="fa fa-edit"></i>Edit</button>
                            </div>
                            <div class="col-xs-6 text-right">
                                <button class="btn btn-app" id="btnSaveAddHead" runat="server" onserverclick="btnSaveAddHead_ServerClick" visible="false"><i class="fa fa-save"></i>Save Add</button>
                                <button class="btn btn-app" id="btnSaveEditHead" runat="server" onserverclick="btnSaveEditHead_ServerClick" visible="false"><i class="fa fa-save"></i>Save Edit</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
                <div class="panel panel-default">
                    <div id="Tabs" role="tabpanel" class="nav-tabs-custom">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#stockqty" aria-controls="stockqty" role="tab" data-toggle="tab">Master JOB</a></li>
                            <li><a href="#importgoods" aria-controls="importgoods" role="tab" data-toggle="tab">Job Detail</a></li>
                            <li><a href="#exportgoods" aria-controls="exportgoods" role="tab" data-toggle="tab">Invoice</a></li>
                            <li><a href="#detailofgoods" aria-controls="detailofgoods" role="tab" data-toggle="tab">Import File</a></li>
                            <li><a href="#assembly" aria-controls="assembly" role="tab" data-toggle="tab">Import File NJR</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content" style="padding-top: 20px">
                            <%--------------------------------------------------Start Stock TAB-------------------------------------------------%>
                            <!------- StockQTY ---------->
                            <div class="active tab-pane" id="stockqty" role="tabpanel">
                                <fieldset runat="server" id="stockqty_fieldset">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">                                        
                                        <div class="col-lg-12 col-md-12 ">                                            
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                
                                                <fieldset>
                                                    <legend>Job</legend>
                                                    <div class="box-body">
                                                        <div class="col-md-5 col-sm-5">
                                                            <div class="form-group">
                                                                <label for="txtJobno" class="col-sm-3 control-label">Job No:</label>
                                                                <div class="col-sm-7">
                                                                    <input class="form-control input-sm" id="txtJobno" runat="server" placeholder="Job No" autocomplete="off" disabled="disabled"/>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <button type="button" class="btn btn-primary btn-sm" runat="server" id="btnJobSiteSeacrh" onserverclick="btnJobSiteSeacrh_ServerClick" visible="false" ><i class="glyphicon glyphicon-search"></i></button>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="txtJobsite" class="col-sm-3 control-label">Job Site:</label>
                                                                <div class="col-sm-5">
                                                                    <asp:DropDownList ID="ddlJobsite" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                                                </div>
                                                                <div class="checkbox col-sm-4">
                                                                    <label>
                                                                        <input type="checkbox" runat="server" id="chkNextmonth" />NextMonth
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="txtJobdate" class="col-sm-4 control-label">Job Date:</label>
                                                                <div class="col-sm-8">
                                                                    <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                                                    <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerJobdate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtenderJobdate" runat="server" Enabled="True" TargetControlID="txtdatepickerJobdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">                                                                
                                                                <label for="txtSaleman" class="col-sm-4 control-label">SaleMan:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlSaleman" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code" AutoPostBack="true" OnSelectedIndexChanged="dllSaleman_SelectedIndexChanged" ></asp:DropDownList>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label for="txtLotof" class="col-sm-4 control-label">LOT of:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlLotof" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                    <%--<input class="form-control" id="txtLotof" runat="server" placeholder="LOT of"/>--%>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <%--<label for="txtSaleman" class="col-sm-4 control-label">Sale Man:</label>--%>
                                                                <div class="col-sm-8 col-sm-offset-4">
                                                                    <input class="form-control input-sm" id="txtsalemandis" runat="server" disabled="disabled" />
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <!-- /.box-body -->
                                                    </div>
                                                    <!-- /.box-header -->
                                                </fieldset>
                                                
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->
                                               
                                        </div>
                                        <!--/.row-->
                                                                                                                                    
                                    </div>

                                </div>
                                <!-- /.post -->


                                <!-- /.content -->
                                <!-- /.box-header -->
                                <div class="row">
                                    <%---------------------------------------------------------Start Left Form--------------------------------------------------------%>
                                    <div class="col-md-6" id="FormLeft_MasterJob" runat="server">
                                        <!-- Horizontal Form -->

                                        <!-- form start -->
                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>Consignee Code</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtConsigneecode" class="col-sm-4 control-label">Consignee Code:</label>
                                                        <div class="col-sm-6">
                                                            <input class="form-control input-sm" id="txtConsigneecode" runat="server" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <%--<button type="button" id="btnconsigneecode" class="btn btn-block btn-primary" data-toggle="modal" data-target="#consigneeModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                            <button type="button" class="btn btn-sm btn-primary" runat="server" onserverclick="Unnamed_ServerClick"><i class="glyphicon glyphicon-search"></i></button>
                                                            

                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtNameEngConsign" class="col-sm-4 control-label">Name(Eng):</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtNameEngConsign" runat="server" placeholder="Name(Eng)" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress1" class="col-sm-4 control-label">Address1:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress1" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress2" class="col-sm-4 control-label">Address2:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress2" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress3" class="col-sm-4 control-label">Address3:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress3" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress4" class="col-sm-4 control-label">Address4:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress4" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress5" class="col-sm-4 control-label">Address5:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress5" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtEmail" class="col-sm-4 control-label">E-mail:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtEmail" runat="server" autocomplete="off" />
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
                                                <legend>Commodity</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtCommodity" class="col-sm-4 control-label">Commodity:</label>
                                                        <div class="col-sm-8">
                                                            <asp:DropDownList ID="ddlCommodity" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtQuantity" class="col-sm-4 control-label">Quantity PLT/Skid:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtQuantity" runat="server" value="0.0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlQuan" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtQuantityBox" class="col-sm-4 control-label">Quantity Box:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtQuantityBox" runat="server" value="0.0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlquanbox" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtVolume" class="col-sm-4 control-label">Volume:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtVolume" runat="server" value="0.0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlvolume" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlvolume2" CssClass="form-control input-sm" runat="server">
                                                                <asp:ListItem>--select--</asp:ListItem>
                                                                <asp:ListItem>HAWB</asp:ListItem>
                                                                <asp:ListItem>HBL</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtVolume2" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtShipto" class="col-sm-4 control-label">Ship To:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtShipto" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- /.box-body -->
                                            </fieldset>
                                        </div>


                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>Actual</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtFlight" class="col-sm-3 control-label">Flight:</label>
                                                        <label for="txtDate" class="col-sm-3 control-label">Date:</label>
                                                        <label for="txtORGN" class="col-sm-3 control-label">ORGN:</label>
                                                        <label for="txtDSTN" class="col-sm-3 control-label">DSTN:</label>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtActual1" runat="server" placeholder="Actual" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <%--<input type="text" class="form-control pull-right"  id="datepickerActualDate1" />--%>
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerActualDate1" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderActualDate1" runat="server" Enabled="True" TargetControlID="txtdatepickerActualDate1" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtORGN1" runat="server" placeholder="ORGN" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtDSTN1" runat="server" placeholder="DSTN" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtActual2" runat="server" placeholder="Actual" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <%--<input type="text" class="form-control pull-right" id="datepickerActualDate2"/>--%>
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerActualDate2" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderActualDate2" runat="server" Enabled="True" TargetControlID="txtdatepickerActualDate2" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtORGN2" runat="server" placeholder="ORGN" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtDSTN2" runat="server" placeholder="DSTN" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtActual3" runat="server" placeholder="Actual" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <%--<input type="text" class="form-control pull-right" id="datepickerActualDate3"/>--%>
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerActualDate3" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderActualDate3" runat="server" Enabled="True" TargetControlID="txtdatepickerActualDate3" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtORGN3" runat="server" placeholder="ORGN" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtDSTN3" runat="server" placeholder="DSTN" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtActual4" runat="server" placeholder="Actual" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <%--<input type="text" class="form-control pull-right" id="datepickerActualDate4"/>--%>
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerActualDate4" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderActualDate4" runat="server" Enabled="True" TargetControlID="txtdatepickerActualDate4" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtORGN4" runat="server" placeholder="ORGN" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtDSTN4" runat="server" placeholder="DSTN" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtPickUp" class="col-sm-4 control-label">Pick Up Time:</label>
                                                        <div class="col-sm-4">
                                                            <div class="bootstrap-timepicker">

                                                                <div class="input-group">
                                                                    <input type="text" class="form-control timepicker input-sm" id="txtTimePickUp" autocomplete="off" runat="server" />
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-clock-o"></i>
                                                                    </div>
                                                                </div>
                                                                <!-- /.input group -->

                                                            </div>

                                                        </div>
                                                        <div class="col-sm-4">
                                                            <%--<input type="text" class="form-control pull-right" id="datepickerActualPickUp"/>--%>
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerActualPickUp" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderdatepickerActualPickUp" runat="server" Enabled="True" TargetControlID="txtdatepickerActualPickUp" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtRamarkActual" class="col-sm-3 control-label">Remark:</label>
                                                        <div class="col-sm-9">
                                                            <textarea class="form-control input-sm" rows="3" id="txtRamarkActual" placeholder="Remark" style="height: 71px; width: 870px;" runat="server"></textarea>
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- /.box-body -->
                                            </fieldset>
                                        </div>
                                    </div>
                                    <!--/.col (left) -->
                                    <%---------------------------------------------------------End Left Form--------------------------------------------------------%>

                                    <%------------------------------------------------------------Start Right Form------------------------------------------------%>
                                    <div class="col-md-6" id="FormRight_MasterJob" runat="server">
                                        <!-- Horizontal Form -->
                                        <!-- form start -->
                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>Shipper Code</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtShippercode" class="col-sm-4 control-label">Shipper Code:</label>
                                                        <div class="col-sm-6">
                                                            <input class="form-control input-sm" id="txtShippercode" runat="server" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <%--<button type="button" class="btn btn-block btn-primary" data-toggle="modal" data-target="#ShipperModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                            <button type="button" class="btn btn-sm btn-primary" runat="server" onserverclick="Unnamed_ServerClick1"><i class="glyphicon glyphicon-search"></i></button>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtNameEngShipper" class="col-sm-4 control-label">Name(Eng):</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtNameEngShipper" runat="server" placeholder="Name(Eng)" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress1Shipper" class="col-sm-4 control-label">Address1:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress1Shipper" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress2Shipper" class="col-sm-4 control-label">Address2:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress2Shipper" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress3Shipper" class="col-sm-4 control-label">Address3:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress3Shipper" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress4Shipper" class="col-sm-4 control-label">Address4:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress4Shipper" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress5Shipper" class="col-sm-4 control-label">Address5:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress5Shipper" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtEmailShipper" class="col-sm-4 control-label">E-mail:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtEmailShipper" runat="server" autocomplete="off" />
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
                                                <legend>Commodity</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtQuantityOfPart" class="col-sm-4 control-label">Quantity Of Part:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtQuantityOfPart" runat="server" value="0.0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlQuantityOfParty" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtWeight" class="col-sm-4 control-label">Weight:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtWeight" runat="server" value="0.0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlWeight" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtMAWB/BL/TWB" class="col-sm-4 control-label">MAWB/BL/TWB:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtMAWB_BL_TWB" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtFLT/Voy/TruckDate" class="col-sm-4 control-label">FLT/Voy/TruckDate:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtFLT_Voy_TruckDate" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtFreight" class="col-sm-4 control-label">Freight Forwarder:</label>
                                                        <div class="col-sm-8">
                                                            <asp:DropDownList ID="ddlFreight" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtBilling" class="col-sm-4 control-label">Billing No.:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtBilling" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- /.box-body -->
                                            </fieldset>
                                        </div>

                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>Actual</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtETD" class="col-sm-3 control-label">ETD:</label>
                                                        <label for="txtETA" class="col-sm-3 control-label">ETA:</label>
                                                        <label for="txtPacket" class="col-sm-3 control-label">Packet:</label>
                                                        <label for="txtWeight" class="col-sm-3 control-label">Weight:</label>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <input type="text" class="form-control timepicker input-sm" id="txtpickupETD" autocomplete="off" runat="server" />
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-clock-o"></i>
                                                                    </div>
                                                                </div>
                                                                <!-- /.input group -->
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <input type="text" class="form-control timepicker input-sm" id="txtpickupETA" autocomplete="off" runat="server" />
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-clock-o"></i>
                                                                    </div>
                                                                </div>
                                                                <!-- /.input group -->
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input class="form-control input-sm" id="txtPacket" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input class="form-control input-sm" id="txtWeightActual" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <input type="text" class="form-control timepicker input-sm" id="txtpickupETD2" autocomplete="off" runat="server" />
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-clock-o"></i>
                                                                    </div>
                                                                </div>
                                                                <!-- /.input group -->
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <input type="text" class="form-control timepicker input-sm" id="txtpickupETA2" autocomplete="off" runat="server" />
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-clock-o"></i>
                                                                    </div>
                                                                </div>
                                                                <!-- /.input group -->
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input class="form-control input-sm" id="txtPacket2" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input class="form-control input-sm" id="txtWeightActual2" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <input type="text" class="form-control timepicker input-sm" id="txtpickupETD3" autocomplete="off" runat="server" />
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-clock-o"></i>
                                                                    </div>
                                                                </div>
                                                                <!-- /.input group -->
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <input type="text" class="form-control timepicker input-sm" id="txtpickupETA3" autocomplete="off" runat="server" />
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-clock-o"></i>
                                                                    </div>
                                                                </div>
                                                                <!-- /.input group -->
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input class="form-control input-sm" id="txtPacket3" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input class="form-control input-sm" id="txtWeightActual3" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <input type="text" class="form-control timepicker input-sm" id="txtpickupETD4" autocomplete="off" runat="server" />
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-clock-o"></i>
                                                                    </div>
                                                                </div>
                                                                <!-- /.input group -->
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <input type="text" class="form-control timepicker input-sm" id="txtpickupETA4" autocomplete="off" runat="server" />
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-clock-o"></i>
                                                                    </div>
                                                                </div>
                                                                <!-- /.input group -->
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input class="form-control input-sm" id="txtPacket4" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input class="form-control input-sm" id="txtWeightActual4" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtArrivalToEAS" class="col-sm-4 control-label">Arrival to EAS:</label>
                                                        <div class="col-sm-4">
                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <input type="text" class="form-control timepicker input-sm" id="txtArrivalToEAS" autocomplete="off" runat="server" />
                                                                    <div class="input-group-addon">
                                                                        <i class="fa fa-clock-o"></i>
                                                                    </div>
                                                                </div>
                                                                <!-- /.input group -->
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <%--<input type="text" class="form-control pull-right" id="datepickerArrivalToEAS"/>--%>
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerArrivalToEAS" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderArrivalToEAS" runat="server" Enabled="True" TargetControlID="txtdatepickerArrivalToEAS" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- /.box-body -->
                                            </fieldset>
                                        </div>

                                    </div>
                                    <!-- right column -->
                                    <%----------------------------------------------------------End Right Form-------------------------------------------------------%>

                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->
                                </fieldset>  
                            </div>
                            <!------- /.MasterJob ---------->
                            <%-------------------------------------------------End MASTER JOB------------------------------------------------------------%>



                            <%-----------------------------------------------------Start JOB DETAIL-----------------------------------------------------------%>
                            <!------- Import Goods ------->
                            <div role="tabpanel" class="tab-pane" id="importgoods">
                                <fieldset runat="server" id="importgoods_fieldset">
                                <!-- Post -->
                                <div class="row" runat="server">

                                    <div class="col-md-6">
                                        <!-- Horizontal Form -->

                                        <!-- form start -->
                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>Delivery Place</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtDeliverycode" class="col-sm-4 control-label">Code:</label>
                                                        <div class="col-sm-6">
                                                            <input class="form-control input-sm" id="txtDeliverycode" runat="server" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <%--<button type="button" class="btn btn-block btn-primary" data-toggle="modal" data-target="#DeliveryModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                            <button type="button" class="btn btn-sm btn-primary" runat="server" onserverclick="Unnamed_ServerClick2"><i class="glyphicon glyphicon-search"></i></button>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtNameEngDelivery" class="col-sm-4 control-label">Name(Eng):</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtNameEngDelivery" runat="server" placeholder="Name(Eng)" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress1Delivery" class="col-sm-4 control-label">Address1:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress1Delivery" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress2Delivery" class="col-sm-4 control-label">Address2:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress2Delivery" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress3Delivery" class="col-sm-4 control-label">Address3:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress3Delivery" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress4Delivery" class="col-sm-4 control-label">Address4:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress4Delivery" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress5Delivery" class="col-sm-4 control-label">Address5:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress5Delivery" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtEmailDelivery" class="col-sm-4 control-label">E-mail:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtEmailDelivery" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtContractPersonDelivery" class="col-sm-4 control-label">Contract Person:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtContractPersonDelivery" runat="server" autocomplete="off" />
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
                                                <legend>Pick Up Place</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtCodePickUpPlace" class="col-sm-4 control-label">Pick Up Place:</label>
                                                        <div class="col-sm-6">
                                                            <input class="form-control input-sm" id="txtCodePickUpPlace" runat="server"  autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <%--<button type="button" class="btn btn-block btn-primary" data-toggle="modal" data-target="#PickUpModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                            <button type="button" class="btn btn-sm btn-primary" runat="server" onserverclick="Unnamed_ServerClick3"><i class="glyphicon glyphicon-search"></i></button>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtNamePickUpPlace" class="col-sm-4 control-label">Name(Eng):</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtNamePickUpPlace" runat="server" placeholder="Name(Eng)" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress1PickUpPlace" class="col-sm-4 control-label">Address1:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress1PickUpPlace" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress2PickUpPlace" class="col-sm-4 control-label">Address2:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress2PickUpPlace" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress3PickUpPlace" class="col-sm-4 control-label">Address3:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress3PickUpPlace" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress4PickUpPlace" class="col-sm-4 control-label">Address4:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress4PickUpPlace" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress5PickUpPlace" class="col-sm-4 control-label">Address5:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress5PickUpPlace" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtEmailPickUpPlace" class="col-sm-4 control-label">E-mail:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtEmailPickUpPlace" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtContractPersonPickUpPlace" class="col-sm-4 control-label">Contract Person:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtContractPersonPickUpPlace" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- /.box-body -->
                                            </fieldset>
                                        </div>


                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>Customer Group</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtCodeCustommerGroup" class="col-sm-4 control-label">Code Group:</label>
                                                        <div class="col-sm-6">
                                                            <input class="form-control input-sm" id="txtCodeCustommerGroup" runat="server" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <%--<button type="button" class="btn btn-block btn-primary" data-toggle="modal" data-target="#CustomerGroupModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                            <button type="button" class="btn btn-sm btn-primary" runat="server" onserverclick="Unnamed_ServerClick6"><i class="glyphicon glyphicon-search"></i></button>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtNameCustommerGroup" class="col-sm-4 control-label">Name(Eng):</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtNameCustommerGroup" runat="server" placeholder="Name(Eng)" autocomplete="off" />
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
                                                <legend>Customer</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtCustomercode" class="col-sm-4 control-label">Customer Code:</label>
                                                        <div class="col-sm-6">
                                                            <input class="form-control input-sm" id="txtCustomercode" runat="server" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <%--<button type="button" class="btn btn-block btn-primary" data-toggle="modal" data-target="#CustomerModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                            <button type="button" class="btn btn-sm btn-primary" runat="server" onserverclick="Unnamed_ServerClick4"><i class="glyphicon glyphicon-search"></i></button>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtNameEngCustomer" class="col-sm-4 control-label">Name(Eng):</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtNameEngCustomer" runat="server" placeholder="Name(Eng)" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress1Custommer" class="col-sm-4 control-label">Address1:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress1Custommer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress2Custommer" class="col-sm-4 control-label">Address2:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress2Custommer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress3Custommer" class="col-sm-4 control-label">Address3:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress3Custommer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress4Custommer" class="col-sm-4 control-label">Address4:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress4Custommer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress5Custommer" class="col-sm-4 control-label">Address5:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress5Custommer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtEmailCustommer" class="col-sm-4 control-label">E-mail:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtEmailCustommer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtContractPersonCustommer" class="col-sm-4 control-label">Contract Person:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtContractPersonCustommer" runat="server" autocomplete="off" />
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
                                                <legend>End Customer</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtCodeEndCustomer" class="col-sm-4 control-label">End Customer Code:</label>
                                                        <div class="col-sm-6">
                                                            <input class="form-control input-sm" id="txtCodeEndCustomer" runat="server"  autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <%--<button type="button" class="btn btn-block btn-primary" data-toggle="modal" data-target="#EndCustomerModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                            <button type="button" class="btn btn-sm btn-primary" runat="server" onserverclick="Unnamed_ServerClick5"><i class="glyphicon glyphicon-search"></i></button>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtNameEndCustomer" class="col-sm-4 control-label">Name(Eng):</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtNameEndCustomer" runat="server" placeholder="Name(Eng)" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress1EndCustomer" class="col-sm-4 control-label">Address1:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress1EndCustomer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress2EndCustomer" class="col-sm-4 control-label">Address2:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress2EndCustomer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress3EndCustomer" class="col-sm-4 control-label">Address3:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress3EndCustomer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress4EndCustomer" class="col-sm-4 control-label">Address4:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress4EndCustomer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAddress5EndCustomer" class="col-sm-4 control-label">Address5:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtAddress5EndCustomer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtEmailEndCustomer" class="col-sm-4 control-label">E-mail:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtEmailEndCustomer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtContractPersonEndCustomer" class="col-sm-4 control-label">Contract Person:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtContractPersonEndCustomer" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- /.box-body -->
                                            </fieldset>
                                        </div>


                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>Reference</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtReferenceInvoice" class="col-sm-4 control-label">Reference Invoice:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtReferenceInvoice" runat="server" placeholder="Reference Invoice" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtNameCustommerGroup" class="col-sm-4 control-label">Name(Eng):</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerReturnDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderReturnDate" runat="server" Enabled="True" TargetControlID="txtdatepickerReturnDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerReturnDate2" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderReturnDate2" runat="server" Enabled="True" TargetControlID="txtdatepickerReturnDate2" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- /.box-body -->
                                            </fieldset>
                                        </div>

                                    </div>
                                    <!-- right column -->


                                    <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

                                    <div class="col-lg-12 col-md-12 ">
                                        <!-- form start -->
                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>IEAT</legend>
                                                <div class="box-body">
                                                    <div class="col-md-6 col-sm-6">
                                                        <div class="form-group">
                                                            <label for="txtIEATNo" class="col-sm-4 control-label">IEAT No:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtIEATNo" runat="server" placeholder="IEAT  No" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtIEATPermit" class="col-sm-4 control-label">IEAT Permit:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlIEATPermit" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtImportEntryNo" class="col-sm-4 control-label">Import Entry No:</label>
                                                            <div class="col-sm-8">
                                                                <input class="form-control input-sm" id="txtImportEntryNo" runat="server" placeholder="Import Entry No" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtStatusIEAT1" class="col-sm-4 control-label">Status 1:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlStatusIEAT1" CssClass="form-control input-sm" runat="server">
                                                                    <asp:ListItem>--Select Status--</asp:ListItem>
                                                                    <asp:ListItem>บัญชีวัตถุดิบและสิ่งจำเป็นที่ต้องใช้ในการผลิต</asp:ListItem>
                                                                    <asp:ListItem>บัญชีเครื่องจักรและอุปกรณ์</asp:ListItem>
                                                                    <asp:ListItem>นำเข้าในนามผู้อื่น</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <div class="col-sm-4">
                                                                <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%>
                                                                <button type="submit" runat="server" class="btn btn-sm btn-primary" id="btnGenIEATNo" title="btnGenIEATNo" onserverclick="btnGenIEATNo_ServerClick">Gen</button>
                                                            </div>
                                                            <div class="checkbox col-md-8">
                                                                <label>
                                                                    <input type="checkbox" runat="server" id="chkGenerateIEATNo" onclick="EnableDisableChkGenIEATNo();" />
                                                                    Request System Auto Generate IEAT No.
                                                                </label>
                                                            </div>
                                                            <%--<div class="col-sm-8">
                                                                    <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>
                                                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="DD/MM/YYYY">
                                                                </asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtdatepickerJobdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>--%>
                                                        </div>
                                                        <style>
                                                            h1 {
                                                                height: 34px;
                                                            }
                                                        </style>
                                                        <h1></h1>
                                                        <div class="form-group">
                                                            <label for="txtImportEntryDate" class="col-sm-4 control-label">Import Entry Date:</label>
                                                            <div class="col-md-8">
                                                                <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                                                <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerImportEntryDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtenderImportEntryDate" runat="server" Enabled="True" TargetControlID="txtdatepickerImportEntryDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtStatusIEAT2" class="col-sm-4 control-label">Status 2:</label>
                                                            <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlStatusIEAT2" CssClass="form-control input-sm" runat="server">
                                                                    <asp:ListItem>--Select Status--</asp:ListItem>
                                                                    <asp:ListItem>จากต่างประเทศ(ใบขนฯขาเข้า)</asp:ListItem>
                                                                    <asp:ListItem>จากในประเทศ(ใบขนฯขาออก)</asp:ListItem>
                                                                    <asp:ListItem>จากในประเทศ(ตามคำร้อง)</asp:ListItem>
                                                                    <asp:ListItem>การรับโอนของเข้าจากสิทธิประโยชน์อื่น</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
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
                            <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End Job Detail-------------------------------------------------------%>



                            <%--------------------------------------------------------------Start Invoice----------------------------------------------------------%>
                            <!-------- Export Goods --------->
                            <div role="tabpanel" class="tab-pane" id="exportgoods">
                                <fieldset runat="server" id="exportgoods_fieldset">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-horizontal">
                                                <asp:Panel ID="Repea2Panel" runat="server" >
                                                    <asp:UpdatePanel ID="Repea2UpdatePanel" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                <asp:Repeater ID="Repea2_Invoice" runat="server" OnItemCommand="Repea2_Invoice_ItemCommand">
                                                                    <HeaderTemplate>
                                                                        <table class="table table-bordered">
                                                                            <th>Select</th>
                                                                            <th>InvoiceNo</th>
                                                                            <th>LOTNo</th>
                                                                            <th>DateInv</th>
                                                                            <th>ProduceCode</th>
                                                                            <th>ProduceName</th>
                                                                            <th>Quantity</th>
                                                                            <th>QuantityUnit</th>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr class="success">
                                                                            <td class="text-center">
                                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectInvoiceNo" CommandArgument='<%# Eval("InvoiceNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                                            </td>
                                                                            <td><asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="lblLOTNo" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label2" runat="server" Text='<%# Bind("DateInv", "{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label5" runat="server" Text='<%# Bind("ProductCode")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label4" runat="server" Text='<%# Bind("ProductName")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label6" runat="server" Text='<%# Bind("Quantity")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label7" runat="server" Text='<%# Bind("QuantityUnit")%>'></asp:Label></td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <AlternatingItemTemplate>
                                                                        <tr class="info">
                                                                            <td class="text-center">
                                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectInvoiceNo" CommandArgument='<%# Eval("InvoiceNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                                            </td>
                                                                            <td><asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="lblLOTNo" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label2" runat="server" Text='<%# Bind("DateInv", "{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label5" runat="server" Text='<%# Bind("ProductCode")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label4" runat="server" Text='<%# Bind("ProductName")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label6" runat="server" Text='<%# Bind("Quantity")%>'></asp:Label></td>
                                                                            <td><asp:Label ID="Label7" runat="server" Text='<%# Bind("QuantityUnit")%>'></asp:Label></td>
                                                                        </tr>
                                                                    </AlternatingItemTemplate>
                                                                    <FooterTemplate>
                                                                            <th>Select</th>
                                                                            <th>InvoiceNo</th>
                                                                            <th>LOTNo</th>
                                                                            <th>DateInv</th>
                                                                            <th>ProduceCode</th>
                                                                            <th>ProduceName</th>
                                                                            <th>Quantity</th>
                                                                            <th>QuantityUnit</th>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>


                                <!-- Post -->
                                <div class="row">
                                    <%--------------------------------------------------------------------Start Left Form---------------------------------------------%>
                                    <div class="col-md-6">
                                        <!-- Horizontal Form -->
                                        <!-- form start -->
                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>Invoice</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtInvoiceNo" class="col-sm-3 control-label">Invoice No:</label>
                                                        <div class="col-sm-9">
                                                            <input class="form-control input-sm" id="txtInvoiceNo" runat="server" autocomplete="off" />
                                                            <%--<asp:DropDownList ID="ddlInvoiceNo" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtProductCodeInvoice" class="col-sm-3 control-label">Product Code:</label>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtProductCodeInvoice" runat="server" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-1">
                                                            <%--<button type="button" id="btnProductCode" class="btn btn-block btn-primary" data-toggle="modal" data-target="#ProductCodeModal" runat="server"><i class="glyphicon glyphicon-search"></i></button>--%>
                                                            <button type="button" class="btn btn-sm btn-primary" runat="server" onserverclick="Unnamed_ServerClick7"><i class="glyphicon glyphicon-search"></i></button>
                                                        </div>
                                                        <label for="txtPONoProductCode" class="col-sm-2 control-label">PO No:</label>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtPONoProductCode" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtQuantityInvoice" class="col-sm-3 control-label">Quantity:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtQuantityInvoice" runat="server" value="0" autocomplete="off" autofocus="autofocus" />
                                                        </div>
                                                        <div class="col-sm-5">
                                                            <asp:DropDownList ID="ddlQuantityInvoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtWeightInvoice" class="col-sm-3 control-label">Weight:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtWeightInvoice" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-5">
                                                            <asp:DropDownList ID="ddlWeightInvoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtRamarkInvoice" class="col-sm-3 control-label">Remark:</label>
                                                        <div class="col-sm-9">
                                                            <textarea class="form-control input-sm" rows="3" runat="server" id="txtRemarkInvoice" placeholder="Remark" style="height: 34px; width: 917px;"></textarea>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtShipmentInvoice" class="col-sm-3 control-label">Shipment:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtShipmentInvoice" runat="server" autocomplete="off" />
                                                        </div>
                                                        <label for="txtItemNoInvoice" class="col-sm-2 control-label">Item No:</label>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtItemNoInvoice" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtMeasurementInvoice" class="col-sm-3 control-label">Measurement:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtWidthInvoice" runat="server" placeholder="Width" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtHeightInvoice" runat="server" placeholder="Height" autocomplete="off" />
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
                                                        <label for="txtCurrencyInvoice" class="col-sm-4">Currency:</label>
                                                        <label for="txtExchangeRateInvoice" class="col-sm-3">Exchange Rate:</label>
                                                        <label for="txtPriceForeignInvoice" class="col-sm-4">@Price(Foreign):</label>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlCurrencyInvoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtExchangeRateInvoice" runat="server" value="0.0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtPriceForeignInvoice" runat="server" value="0.0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-6">
                                                            <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%>
                                                            <button type="submit" runat="server" class="btn btn-primary" id="btnSaveInvoice" title="btnSaveInvoice" onserverclick="btnSaveInvoice_ServerClick">Save Inv.</button>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%>
                                                            <button type="submit" runat="server" class="btn btn-default" id="btnModifyInvoice" title="btnModifyInvoice" onserverclick="btnModifyInvoice_ServerClick">Modify Inv.</button>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.box-body -->
                                            </fieldset>
                                        </div>


                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>Import Flight</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtFlightNoInvoice" class="col-sm-4 control-label">Flight No:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtFlightNo" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtFlightDateInvoice" class="col-sm-4 control-label">Flight Date:</label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerFlightDateInvoice" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderFlightDateInvoice" runat="server" Enabled="True" TargetControlID="txtdatepickerFlightDateInvoice" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtQuantity_PLT_Skid_Invoice" class="col-sm-4 control-label">Quantity PLT/SKID:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtQuantity_PLT_Skid_Invoice" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlQuantity_PLT_Skid_Invoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlQuantity_PLT_Skid_Invoice2" CssClass="form-control input-sm" runat="server">
                                                                <asp:ListItem>--select--</asp:ListItem>
                                                                <asp:ListItem>HAWB</asp:ListItem>
                                                                <asp:ListItem>HBL</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtQuantity_PLT_Skid_Invoice2" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4 col-sm-offset-4">
                                                            <button type="submit" runat="server" class="btn btn-primary" id="btnSaveFlightNoInvoice" title="btnSaveFlightNoInvoice" onserverclick="btnSaveFlightNoInvoice_ServerClick">Save Flight No</button>
                                                        </div>
                                                        <div class="col-sm-4 ">
                                                            <button type="submit" runat="server" class="btn btn-warning" id="btnDeleteFlightNoInvoice" title="btnDeleteFlightNoInvoice" onserverclick="btnDeleteFlightNoInvoice_ServerClick">Delete Flight No</button>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <%--------------------------------------Data Issued Detail Repeater---------------------------------%>
                                                      <asp:Repeater ID="Repeater10" runat="server" OnItemCommand="Repeater10_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table id="example10" class="table table-striped table-condensed">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>Select</th>
                                                                            <th>LotNo</th>
                                                                            <th>Number</th>
                                                                            <th>FlightNo</th>
                                                                            <th>DateFlight</th>
                                                                        </tr>
                                                                    </thead>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td class="text-center">
                                                                        <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy  btn-sm" runat="server" CausesValidation="False" CommandName="Selectdataflight" CommandArgument='<%# Eval("Number")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblLotNo" runat="server" Text='<%# Bind("LotNo")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblNumber" runat="server" Text='<%# Bind("Number")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblFlightNo" runat="server" Text='<%# Bind("FlightNo")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDateFlight" runat="server" Text='<%# Bind("DateFlight")%>'></asp:Label></td>
                                                                </tr>

                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <tfoot>
                                                                    <tr>
                                                                        <th>Select</th>
                                                                        <th>LotNo</th>
                                                                        <th>Number</th>
                                                                        <th>FlightNo</th>
                                                                        <th>DateFlight</th>
                                                                    </tr>
                                                                </tfoot>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                        <%--------------------------------------Data Issued Detail Repeater---------------------------------%>
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
                                                <legend>Invoice</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label for="txtDataInvoice" class="col-sm-3 control-label">Data Invoice:</label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerDataInvoice" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtenderDataInvoice" runat="server" Enabled="True" TargetControlID="txtdatepickerDataInvoice" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtProductNameInvoice" class="col-sm-3 control-label">Product Name:</label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtProductNameInvoice" runat="server" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtPallet_SKIDInvoice" class="col-sm-3 control-label">Pallet/SKID:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtPallet_SKIDInvoice" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlPallet_SKIDInvoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtBoxInvoice" class="col-sm-3 control-label">Box:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtBoxInvoice" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:DropDownList ID="ddlBoxInvoice" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <h1></h1>
                                                    <%--<h1></h1>--%>

                                                    <div class="form-group">
                                                        <label for="txtUnitDimension" class="col-sm-3 control-label">UnitDimension:</label>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlUnitDimension" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                        </div>
                                                        <label for="txtPalletDimensionInvoice" class="col-sm-2 control-label">Pallet:</label>
                                                        <div class="col-sm-3">
                                                            <input class="form-control input-sm" id="txtPalletDimensionInvoice" runat="server" value="0" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtLenghtInvoice" runat="server" placeholder="Lenght" autocomplete="off" />
                                                        </div>
                                                        <label for="txtEntryItemNoInvoice" class="col-sm-3 control-label">EntryItemNo:</label>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtEntryItemNoInvoice" runat="server" autocomplete="off" />
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
                                                        <label for="txtPriceBathInvoice" class="col-sm-4 ">@Price(Bath):</label>
                                                        <label for="txtAmountForeignInvoice" class="col-sm-4 ">Amount(Foreign):</label>
                                                        <label for="txtAmountBathInvoice" class="col-sm-4 ">Amount(Bath):</label>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtPriceBathInvoice" runat="server" value="0.0" readonly="true" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtAmountForeignInvoice" runat="server" value="0.0" readonly="true" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <input class="form-control input-sm" id="txtAmountBathInvoice" runat="server" value="0.0" readonly="true" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-6">
                                                            <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%>
                                                            <button type="submit" runat="server" class="btn btn-warning" id="btnDeleteInvoice" title="btnDeleteInvoice" onserverclick="btnDeleteInvoice_ServerClick">Delete Inv.</button>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%>
                                                            <button type="submit" runat="server" class="btn btn-danger" id="btnDeleteAllInvoice" title="btnDeleteAllInvoice" onserverclick="btnDeleteAllInvoice_ServerClick">Delete Inv. All</button>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.box-body -->
                                            </fieldset>
                                        </div>


                                        <div class="form-horizontal">
                                            <fieldset>
                                                <legend>Export</legend>
                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <div class="col-sm-8">
                                                            <input class="form-control input-sm" id="txtQTYExportInvoice" runat="server" placeholder="0" autocomplete="off" />
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%>
                                                            <button type="submit" runat="server" class="btn btn-primary" id="btnSumQTYInvoice" onserverclick="btnSumQTYInvoice_ServerClick" title="btnSumQTYInvoice">Sum QTY</button>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-8">
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <button type="submit" runat="server" class="btn btn-primary" id="btnSaveToPrepairInvoice" onserverclick="btnSaveToPrepairInvoice_ServerClick" title="btnSaveToPrepairInvoice">Save To Prepair</button>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-8">
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <button type="submit" runat="server" class="btn btn-soundcloud" id="btnExportCSVFileInvoice" onserverclick="btnExportCSVFileInvoice_ServerClick" title="btnExportCSVFileInvoice">Export csv File   </button>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-sm-8">
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <button type="submit" runat="server" class="btn btn-success" id="btnSaveToConfirmNJRCInvoice" onserverclick="btnSaveToConfirmNJRCInvoice_ServerClick" title="btnSaveToConfirmNJRCInvoice">Save To Confirm NJRC</button>
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- /.box-body -->
                                            </fieldset>
                                        </div>

                                    </div>
                                    <!-- right column -->


                                    <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

                                    <!-- /.col -->
                                </div>
                                <!-- /.post -->
                                </fieldset>
                            </div>
                            <!-----/ Export Goods----->

                            <%----------------------------------------------------------------------End Invoice Tab--------------------------------------------------------------%>


                            <%----------------------------------------------------------------------Start ImportFile--------------------------------------------------------%>
                            <!--- Detailof Goods --->
                            <div role="tabpanel" class="tab-pane" id="detailofgoods">
                                <fieldset runat="server" id="detailofgoods_fieldset">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">
                                        <div class="col-lg-12 col-md-12">

                                            <div class="form-horizontal">
                                                <div class="box-body">

                                                    <fieldset class="col-md-12">
                                                        <legend>Import File</legend>
                                                        <div class="col-lg-12 col-md-12">
                                                            <div class="form-group">
                                                                <label for="txtSelectFileForImport" class="col-sm-4 control-label">Select File For Import:</label>
                                                                <div class="col-sm-4">
                                                                    <input type="file" class="form-control input-sm" id="txtSelectFileForImport_Import" runat="server" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <button type="submit" runat="server" class="btn btn-success" id="btnImport_Import" title="btnImport_Import">Import</button>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-12">
                                                                    <div class="progress active">
                                                                        <div class="progress-bar progress-bar-primary progress-bar-striped" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
                                                                            <span class="sr-only">40% Complete (success)</span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </fieldset>

                                                </div>

                                            </div>

                                            <div class="form-horizontal">
                                                <div class="box-body">

                                                    <fieldset class="col-md-12">
                                                        <legend>File</legend>
                                                        <div class="col-lg-12 col-md-12">

                                                            <div class="form-group">
                                                                <div class="col-sm-8">
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <button type="submit" runat="server" class="btn btn-success" id="btnSaveToInvoice_Import" title="btnSaveToInvoice_Import">Save To Invoice</button>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </fieldset>

                                                </div>

                                            </div>

                                        </div>
                                        <!--/.col-lg-6 col-md-6--->
                                    </div>
                                </div>
                                </fieldset>
                            </div>
                            <!----/Detailof Goods----->
                            <%---------------------------------------------------------------End Import File Tab----------------------------------------------%>


                            <%-------------------------------------------------------------Start Import File NJR Tab-------------------------------------------------%>
                            <!--- Asembly --->
                            <div role="tabpanel" class="tab-pane" id="assembly">
                                <fieldset runat="server" id="assembly_fieldset">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">
                                        <div class="col-lg-12 col-md-12">
                                            <div class="form-horizontal">
                                                <div class="box-body">
                                                    <fieldset class="col-md-12">
                                                        <legend>Import File</legend>
                                                        <div class="col-lg-12 col-md-12">
                                                            <div class="form-group">
                                                                <label for="txtSelectFileForImport" class="col-sm-4 control-label">Select File For Import:</label>
                                                                <div class="col-sm-4">
                                                                    <input type="file" class="form-control input-sm" id="txtSelectFileForImport_ImportFileNJR" runat="server" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <%--<button type="submit" runat="server" class="btn btn-success" id="btnImport_ImportFileNJR" title="btnImport_Import" >Import</button>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                                <!-- /.box-body -->
                                            </div>
                                            <!--/.col-lg-6 col-md-6--->
                                            <div class="form-horizontal">
                                                <div class="box-body">
                                                    <fieldset class="col-md-12">
                                                        <legend>Import EntryItemNo File</legend>
                                                        <div class="col-lg-12 col-md-12">
                                                            <div class="form-group">
                                                                <label for="txtSelectFileForImport" class="col-sm-4 control-label">Select File For Import:</label>
                                                                <div class="col-sm-4">
                                                                    <input type="file" class="form-control input-sm" id="txtSelectFileForImportEntryItemNo_ItemPortFileNJR" runat="server" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <button type="submit" runat="server" class="btn btn-success" id="btnImport_ImportFileNJR" title="btnImport_ImportFileNJR">Import Update</button>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-12">
                                                                    <div class="progress active">
                                                                        <div class="progress-bar progress-bar-primary progress-bar-striped" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
                                                                            <span class="sr-only">40% Complete (success)</span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </fieldset>
                                                </div>
                                                <!-- /.box-body -->
                                            </div>

                                            <div class="form-horizontal">
                                                <div class="box-body">

                                                    <fieldset class="col-md-12">
                                                        <legend>File</legend>
                                                        <div class="col-lg-12 col-md-12">

                                                            <div class="form-group">
                                                                <div class="col-sm-8">
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <button type="submit" runat="server" class="btn btn-success" id="btnSaveToInvoice_ImportFileNJR" title="btnSaveToInvoice_ImportFileNJR">Save To Invoice</button>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </fieldset>

                                                </div>
                                            </div>
                                        </div>
                                        <!--/.row-->
                                    </div>
                                    <!-- /.post -->
                                </div>
                                </fieldset>
                            </div>
                            <!----/ .Asembly----->

                        </div>
                        <!-- /.tab-pane -->
                    </div>
                    <!-- /.tab-pane -->
                </div>

                 <asp:HiddenField ID="TabName" runat="server" />
                <!-- /.col -->
          
        </section>
        <!-- /.content -->

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
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" >
                                                <HeaderTemplate>
                                                    <table id="example1" class="table table-striped table-responsive table-condensed" style="overflow: auto;">
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
                                                            <asp:LinkButton ID="LinkButton1" CssClass="btn bg-navy btn-sm" runat="server" OnClick="clickconsignee_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                         <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" Text="Label"></asp:Label></td>
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
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example2" class="table table-striped table-responsive table-condensed" style="overflow: auto;">
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
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy btn-sm" runat="server" OnClick="clickshipper_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" Text="Label"></asp:Label></td>
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

        <!-- Delivery Modal -->
        <!-- Modal -->
        <asp:Panel ID="DeliveryPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <%--<div class="modal fade" id="DeliveryModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Delivery Code</h4>
                    </div>
                    <asp:UpdatePanel ID="DeliveryUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater3" runat="server" OnItemDataBound="Repeater3_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example3" class="table table-striped table-responsive table-condensed" style="overflow: auto;">
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
<%--                                                        <td>
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
                                                            <%--<asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectDelivery" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-plus-square"></i></asp:LinkButton>--%>
                                                            <asp:LinkButton ID="LinkButton3" CssClass="btn bg-navy btn-sm" runat="server" OnClick="clickdelivery_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" Text="Label"></asp:Label></td>
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
        <!-- End Delivery Modal -->
        <!-- PickUp Modal -->
        <!-- Modal -->
        <asp:Panel ID="PickUpPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <%--<div class="modal fade" id="PickUpModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select PickUp Code</h4>
                    </div>
                    <asp:UpdatePanel ID="PickUpUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater4" runat="server" OnItemDataBound="Repeater4_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example4" class="table table-striped table-responsive table-condensed" style="overflow: auto;">
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
                                                            <%--<asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectPickUp" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-plus-square"></i></asp:LinkButton>--%>
                                                            <asp:LinkButton ID="LinkButton4" CssClass="btn bg-navy btn-sm" runat="server" OnClick="clickpickup_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" Text="Label"></asp:Label></td>
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
        <!-- End PickUp Modal -->
        <!-- Customer Modal -->
        <!-- Modal -->
        <asp:Panel ID="CustomerPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <%--<div class="modal fade" id="CustomerModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Customer Code</h4>
                    </div>
                    <asp:UpdatePanel ID="CustomerUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater5" runat="server" OnItemDataBound="Repeater5_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example5" class="table table-striped table-responsive table-condensed" style="overflow: auto;">
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
                                                            <%--<asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectCustomer" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-plus-square"></i></asp:LinkButton>--%>
                                                            <asp:LinkButton ID="LinkButton5" CssClass="btn bg-navy btn-sm" runat="server" OnClick="clickcustomer_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" Text="Label"></asp:Label></td>
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
        <!-- End Customer Modal -->
        <!--Start EndCustomer Modal -->
        <!-- Modal -->
        <asp:Panel ID="EndCustomerPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <%--<div class="modal fade" id="EndCustomerModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select EndCustomer Code</h4>
                    </div>
                    <asp:UpdatePanel ID="EndCustomerUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater6" runat="server" OnItemDataBound="Repeater6_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="example6" class="table table-striped table-responsive table-condensed" style="overflow: auto;">
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
                                                            <%--<asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectEndCustomer" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-plus-square"></i></asp:LinkButton>--%>
                                                            <asp:LinkButton ID="LinkButton6" CssClass="btn bg-navy btn-sm" runat="server" OnClick="clickendcustomer_Click"><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyAddressCode" runat="server" Text="Label" ></asp:Label></td>
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
        <!-- End Customer Modal -->
        <!--Start CustomerGroup Modal -->
        <!-- Modal -->
        <asp:Panel ID="CustomerGroupPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <%--<div class="modal fade" id="CustomerGroupModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select CustomerGroup Code</h4>
                    </div>
                    <asp:UpdatePanel ID="CustomerGroupUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater7" runat="server" OnItemCommand="Repeater7_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example7" class="table table-striped table-responsive table-condensed" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>PartyCode</th>
                                                                <th>PartyFullName</th>
                                                                <th>Select</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="SelectCustomerGroup" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-plus-square"></i></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>PartyCode</th>
                                                            <th>PartyFullName</th>
                                                            <th>Select</th>
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
        <!-- End CustomerGroup Modal -->
        <!--Start ProductCode Modal -->
        <!-- Modal -->
        <asp:Panel ID="ProductCodePanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <%--<div class="modal fade" id="ProductCodeModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">--%>
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Select Product Code</h4>
                    </div>
                    <asp:UpdatePanel ID="ProductCodeUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="Repeater8" runat="server" OnItemCommand="Repeater8_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example8" class="table table-striped table-responsive table-condensed" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>Select</th>
                                                                <th>ProductCode</th>
                                                                <th>ImpDesc1</th>
                                                                <th>PONo</th>
                                                                <th>CustomerPart</th>
                                                                <th>EndUserPart</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy btn-sm" runat="server" CausesValidation="False" CommandName="SelectProductCode" CommandArgument='<%# Eval("ProductCode")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("ProductCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("ImpDesc1")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("PONo")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("CustomerPart")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("EndUserPart")%>'></asp:Label></td>                                                        
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Select</th>
                                                            <th>ProductCode</th>
                                                            <th>ImpDesc1</th>
                                                            <th>PONo</th>
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

        <!-- Modal JobNo-->
        <asp:Panel ID="JobnoPanel" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabe1">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="exampleModalLabel">Select JOB No</h4>
                    </div>
                    <asp:UpdatePanel ID="JobnoUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body">
                                <section class="content">
                                    <form class="form-horizontal">
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                            <asp:Repeater ID="Repeater9" runat="server" OnItemCommand="Repeater9_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example9" class="table table-striped table-responsive table-condensed" style="overflow: auto;">
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
                                                            <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy btn-sm" runat="server" CausesValidation="False" CommandName="selectLotNO" CommandArgument='<%# Eval("EASLOTNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
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
        <!-- End JobNo Modal -->

        <script type="text/javascript">
            $(function () {
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "stockqty";
                $('#Tabs a[href="#' + tabName + '"]').tab('show');
                $("#Tabs a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });
            });
        </script>

        <script type="text/javascript">
            function EnableDisableChkGenIEATNo() {
                var status = document.getElementById('<%=chkGenerateIEATNo.ClientID%>').checked;
                        if (status == true) {
                            document.getElementById('<%=btnGenIEATNo.ClientID%>').disabled = false;
                } else if (status == false) {
                    document.getElementById('<%=btnGenIEATNo.ClientID%>').disabled = true;
              }
      }
        </script>
    </form>
</asp:Content>
