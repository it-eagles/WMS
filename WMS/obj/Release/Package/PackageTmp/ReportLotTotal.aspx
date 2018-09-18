<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportLotTotal.aspx.vb" Inherits="WMS.ReportLotTotal" MasterPageFile="~/Home.Master" %>

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
                <li><a class="active"><i class="fa fa-file"></i>Master Files</a></li>
                <li><a href="ReprotLotTotal.aspx"class="active">Report Lot Total</a></li>

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
                                                <div class="col-md-12">
                                                    <!-- Horizontal Form -->

                                                    <!-- form start -->
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                    <label for="txtstartdate" class="col-sm-3 control-label">วันที่เริ่มต้นใช้:</label>
                                    <div class="col-sm-5">
                                        <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                        <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerstartdate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                        </asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtenderstartdate" runat="server" Enabled="True" TargetControlID="txtdatepickerstartdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                    </div>
                                </div>

                                                         <div class="form-group">
                                    <label for="txtstartdate" class="col-sm-3 control-label">วันที่เริ่มต้นใช้:</label>
                                    <div class="col-sm-5">
                                        <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                        <asp:TextBox CssClass="form-control input-sm" ID="TextBox1" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                        </asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtdatepickerstartdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                    </div>
                                </div>

                                      <div class="form-group">
                                    <label for="txtlocationtariffrequite" class="col-sm-3 control-label">พิกัดศุลกากรที่ได้รับการชดเชย:</label>
                                    <div class="col-sm-5">
                                                    <asp:DropDownList ID="ddllocationtariffrequite" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code" >
                                                         <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                    </div>
                                </div>

                                                    </div>
                                                    <!-- /.box -->

                                                    <!-- general form Commodity -->
                                                    

                                                </div>
                                                <!--/.col (left) -->

                                            </div>
                                            <!-- /.post -->
                                                </fieldset>
                                        </div>
                                        <!------- /. Import Goods ------->
                                        <%-------------------------------------------------------------End TRUCK WAY BILL HEAD-------------------------------------------------------%>


                                        <%--------------------------------------------------------------Start TRUCK WAY BILL DETAIL----------------------------------------------------------%>
                                        <!-------- Export Goods --------->
                                        <div role="tabpanel" class="tab-pane" id="truckwaybilldetail">
                                            
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


    </form>
</asp:Content>