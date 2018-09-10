<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RejectIssuedWH.aspx.vb" Inherits="WMS.RejectIssuedWH" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Reject Issued
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a><i class="fa fa-file"></i>WareHouse</a></li>
                <li><a href="RejectIssuedWH.aspx">RejectIssued</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="box box-primary">
                <div class="row">
                    <!-- left column -->
                    <div class="col-lg-12 col-md-12 ">
                        <!-- general form elements -->

                        <%--------------------------------------------------------------Start Reject Issued----------------------------------------------------------%>

                        <%-----------------------------------------------------Start HEAD BEFORE LEFT FORM-----------------------------------------------------------%>

                        <div class="col-lg-12 col-md-12 ">
                            <!-- form start -->
                            <%------------------------------------------------Start Find Job-------------------------------------------------------------------%>
                            <div class="form-horizontal">
                                <fieldset>
                                    <legend>Find</legend>
                                    <div class="box-body">
                                        <div class="col-md-4 col-sm-4">
                                            <div class="form-group">
                                                <label for="txtPullSignal" class="col-sm-4 control-label">Pull Signal:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtPullSignal" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="txtJobNo" class="col-sm-4 control-label">Job No:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtJobNo" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <div class="col-sm-2">
                                                    <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnFind" title="btnFind" onserverclick="btnFind_ServerClick">Find</button>
                                                </div>
                                                <div class="col-sm-2">
                                                    <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnClear" title="btnClear" onserverclick="btnClear_ServerClick">Clear</button>
                                                </div>
                                            </div>
                                        </div>


                                        <!-- /.box-body -->
                                    </div>
                                    <!-- /.box-header -->
                                </fieldset>
                            </div>
                            <%--------------------------------------------------------------End Find Job-----------------------------------------------------%>
                            <div class="form-horizontal">
                                <fieldset>
                                    <legend>Input</legend>
                                    <div class="box-body">
                                        <div class="col-md-4 col-sm-4">
                                            <div class="form-group">
                                                <label for="txtWHSite" class="col-sm-4 control-label">WH Site:</label>
                                                <div class="col-sm-8">
                                                    <asp:DropDownList ID="ddlWHSite" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtCusLOTNo" class="col-sm-4 control-label">Cus LOT No:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtCusLOTNo" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtEASPN" class="col-sm-4 control-label">EAS P/N:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtEASPN" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtProductDesc" class="col-sm-4 control-label">Product Desc:</label>
                                                <div class="col-sm-8">
                                                    <textarea class="form-control input-sm" runat="server" rows="3" id="txtRemark" placeholder="Desc .." style="height: 34px; width: 552px;" autocomplete="off"></textarea>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="txtWHLocation" class="col-sm-4 control-label">WH Location:</label>
                                                <div class="col-sm-8">
                                                    <asp:DropDownList ID="ddlWHLocation" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtCustWHFac" class="col-sm-4 control-label">Cust W/H Fac:</label>
                                                <div class="col-sm-8">
                                                    <asp:DropDownList ID="ddlCustWHFac" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtCustomerPN" class="col-sm-4 control-label">CustomerP/N:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtCustomerPN" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="txtENDCustomer" class="col-sm-4 control-label">ENDCustomer:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtENDCustomer" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtItemNo" class="col-sm-4 control-label">Item No:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtItemNo" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtOwnerPN" class="col-sm-4 control-label">Owner P/N:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtOwnerPN" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtMeasurement" class="col-sm-4 control-label">Measurement:</label>
                                                <div class="col-sm-8">
                                                    <asp:DropDownList ID="ddlMeasurement" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
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
                        <%-------------------------------------------------------End HEAD BEFORE LEFT FORM----------------------------------------------------------------%>

                        <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                        <div class="col-md-6">
                            <!-- Horizontal Form -->

                            <!-- form start -->
                            <!-- general form Commodity -->
                            <div class="form-horizontal">
                                <%--<fieldset><legend>Owner</legend>--%>
                                <div class="box-body">
                                    <div class="form-group">
                                        <label for="txtSpace" class="col-sm-4 control-label"></label>
                                        <label for="txtWidth" class="col-sm-4 control-label">Width:</label>
                                        <label for="txtHight" class="col-sm-4 control-label">Hight:</label>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtDimension" class="col-sm-4 control-label">Dimension:</label>
                                        <div class="col-sm-4">
                                            <input class="form-control input-sm" id="txtWidth" runat="server" value="0" autocomplete="off" />
                                        </div>
                                        <div class="col-sm-4">
                                            <input class="form-control input-sm" id="txtHight" runat="server" value="0" autocomplete="off" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtOrderNo" class="col-sm-4 control-label">Order No:</label>
                                        <div class="col-sm-8">
                                            <input class="form-control input-sm" id="txtOrderNo" runat="server" autocomplete="off" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtReceiveNo" class="col-sm-4 control-label">Receive No:</label>
                                        <div class="col-sm-8">
                                            <input class="form-control input-sm" id="txtReceiveNo" runat="server" autocomplete="off" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-1"></div>
                                        <div class="col-sm-3">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" runat="server" id="chkNotUseDate" />Not Use Date
                                                </label>
                                            </div>

                                        </div>
                                        <label for="txtManufacturing" class="col-sm-4 control-label">Manufacturing:</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerManufacturing" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtenderManufacturing" runat="server" Enabled="True" TargetControlID="txtdatepickerManufacturing" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtReceiveDate" class="col-sm-4 control-label">Receive Date:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerReceiveDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtenderReceiveDate" runat="server" Enabled="True" TargetControlID="txtdatepickerReceiveDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtQuantity" class="col-sm-4 control-label">Quantity:</label>
                                        <div class="col-sm-4">
                                            <input class="form-control input-sm" id="txtQuantity" runat="server" value="0" autocomplete="off" />
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlQuantity" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->
                                <%--</fieldset>--%>
                            </div>
                        </div>
                        <!--/.col (left) -->
                        <%---------------------------------------------------------------End Left Form------------------------------------------------%>



                        <%------------------------------------------------------------Start Right Form------------------------------------------------%>
                        <div class="col-md-6">
                            <!-- Horizontal Form -->
                            <!-- form start -->
                            <!-- general form Commodity -->
                            <div class="form-horizontal">
                                <%--<fieldset><legend>Customer</legend>--%>
                                <div class="box-body">
                                    <div class="form-group">
                                        <label for="txtLength" class="col-sm-4 control-label">Length:</label>
                                        <label for="txtProductVolume" class="col-sm-4 control-label">Product Volume:</label>
                                        <label for="txtPalletNo" class="col-sm-4 control-label">Pallet No:</label>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-4">
                                            <input class="form-control input-sm" id="txtLength" runat="server" value="0" autocomplete="off" />
                                        </div>
                                        <div class="col-sm-4">
                                            <input class="form-control input-sm" id="txtProductVolume" runat="server" value="0" autocomplete="off" />
                                        </div>
                                        <div class="col-sm-4">
                                            <input class="form-control input-sm" id="txtPalletNo" runat="server" value="0" autocomplete="off" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtStatus" class="col-sm-4 control-label">Status:</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlStatus" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem>Goods Complete</asp:ListItem>
                                                <asp:ListItem>Goods Damage</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtType" class="col-sm-4 control-label">Type:</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlType" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem>Q-FFL</asp:ListItem>
                                                <asp:ListItem>Q-CON</asp:ListItem>
                                                <asp:ListItem>Q-SC</asp:ListItem>
                                                <asp:ListItem>Q-SCRAP</asp:ListItem>
                                                <asp:ListItem>BackFill</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtExpiredDate" class="col-sm-4 control-label">Expired Date:</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerExpiredDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtenderExpiredDate" runat="server" Enabled="True" TargetControlID="txtdatepickerExpiredDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 34px;"></div>
                                    <div class="form-group">
                                        <label for="txtWeight2" class="col-sm-4 control-label">Weight:</label>
                                        <div class="col-sm-4">
                                            <input class="form-control input-sm" id="txtWeight2" runat="server" value="0" autocomplete="off" />
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlWeight2" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->
                                <%--</fieldset>--%>
                            </div>
                        </div>
                        <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

                         <%-----------------------------------------------------Start Tabel1 FORM------------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-sm-12">
                                                        <%--------------------------------------Data Picking Detail Repeater---------------------------------%>
                                                      <asp:Repeater ID="Repeater8" runat="server" OnItemDataBound="Repeater8_ItemDataBound">
                                                            <HeaderTemplate>
                                                                <table class="table table-striped table-condensed" id="example8">
                                                                    <thead>
                                                                        <tr>                                                                            
                                                                            <th>PullSignal</th>
                                                                            <th>LOTNo</th>
                                                                            <th>ItemNo</th>
                                                                            <th>WHSite</th>
                                                                            <th>ENDCustomer</th>
                                                                            <th>CustomerLOTNo</th>
                                                                            <th>ProductCode</th>
                                                                        </tr>
                                                                    </thead>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr class="dark">                                                                    
                                                                    <td>
                                                                        <asp:Label ID="lblPullSignal" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblLOTNo" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblItemNo" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblWHSite" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblENDCustomer" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCustomerLOTNo" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblProductCode" runat="server"></asp:Label></td>
                                                                </tr>

                                                            </ItemTemplate>
                                                           
                                                            <FooterTemplate>
                                                                <tfoot>
                                                                    <tr>                                                                        
                                                                        <th>PullSignal</th>
                                                                        <th>LOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>WHSite</th>
                                                                        <th>ENDCustomer</th>
                                                                        <th>CustomerLOTNo</th>
                                                                        <th>ProductCode</th>
                                                                    </tr>
                                                                </tfoot>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                        <%--------------------------------------Data Picking Detail Repeater---------------------------------%>
                                                    </div>

                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->

                                        </div>
                                        <%-------------------------------------------------------End Tabel1 FORM----------------------------------------------------------------%>

                        <%-----------------------------------------------------Start BUTTON FORM------------------------------------------------------------%>
                        <div class="col-lg-12 col-md-12 ">
                            <!-- form start -->
                            <div class="form-horizontal">
                                <%--<fieldset>  <legend>Job</legend>--%>
                                <div class="box-body">
                                    <div class="col-sm-6">
                                        <%--<div class="form-group">
                                            <div class="col-sm-4">
                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnSelectAll" title="btnSelectAll">Select All</button>
                                            </div>
                                            <div class="col-sm-4">
                                                <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnCencelSelectAll" title="btnCencelSelectAll">Cencel Select All</button>
                                            </div>
                                        </div>--%>
                                    </div>

                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <div class="col-sm-7"></div>
                                            <div class="col-sm-5">
                                                <button type="submit" runat="server" class="btn btn-danger btn-sm" id="btnDelete" onserverclick="btnDelete_ServerClick" title="btnDelete">Delete</button>
                                            </div>
                                        </div>
                                    </div>


                                    <!-- /.box-body -->
                                </div>
                                <!-- /.box-header -->
                                <%--</fieldset>--%>
                            </div>
                            <!--/.col-lg-6 col-md-6 stockqty--->

                        </div>
                        <%-------------------------------------------------------End BUTTON FORM----------------------------------------------------------------%>

                        <%-----------------------------------------------------Start Tabel2 FORM------------------------------------------------------------%>
                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <%--<fieldset>  <legend>Job</legend>--%>
                                                <div class="box-body">
                                                    <div class="col-sm-12">
                                                        <%--------------------------------------Data Issued Detail Repeater---------------------------------%>
                                                      <asp:Repeater ID="Repeater9" runat="server" >
                                                            <HeaderTemplate>
                                                                <table id="example9" class="table table-striped table-condensed">
                                                                    <thead>
                                                                        <tr>
                                                                            <th style="width: 8px">
                                                                                <asp:CheckBox runat="server" ID="chkAll_Pull" Checked="false" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true"></asp:CheckBox></th>
                                                                            <th>PullSignal</th>
                                                                            <th>LOTNo</th>
                                                                            <th>ItemNo</th>
                                                                            <th>WHSite</th>
                                                                            <th>WHLocation</th>
                                                                            <th>ENDCustomer</th>
                                                                            <th>CustomerLOTNo</th>
                                                                        </tr>
                                                                    </thead>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td><asp:CheckBox ID="chk_Pull" runat="server"  AutoPostBack="true" OnCheckedChanged="chk_Pull_CheckedChanged"/></td>
                                                                    <td>
                                                                        <asp:Label ID="lblPullSignal" runat="server" Text='<%# Bind("PullSignal")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblLOTNo" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblItemNo" runat="server" Text='<%# Bind("ItemNo")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblWHSite" runat="server" Text='<%# Bind("WHSite")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblWHLocation" runat="server" Text='<%# Bind("WHLocation")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblENDCustomer" runat="server" Text='<%# Bind("ENDCustomer")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCustomerLOTNo" runat="server" Text='<%# Bind("CustomerLOTNo")%>'></asp:Label></td>
                                                                </tr>

                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <tfoot>
                                                                    <tr>
                                                                        <th style="width: 8px">
                                                                           <asp:CheckBox runat="server" ID="chkAll_Pull" Checked="false" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true"></asp:CheckBox></th>
                                                                        <th>PullSignal</th>
                                                                        <th>LOTNo</th>
                                                                        <th>ItemNo</th>
                                                                        <th>WHSite</th>
                                                                        <th>WHLocation</th>
                                                                        <th>ENDCustomer</th>
                                                                        <th>CustomerLOTNo</th>
                                                                    </tr>
                                                                </tfoot>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                        <%--------------------------------------Data Issued Detail Repeater---------------------------------%>
                                                    </div>

                                                    <!-- /.box-body -->
                                                </div>
                                                <!-- /.box-header -->
                                                <%--</fieldset>--%>
                                            </div>
                                            <!--/.col-lg-6 col-md-6 stockqty--->

                                        </div>
                                        <%-------------------------------------------------------End Tabel2 FORM----------------------------------------------------------------%>

                        <%--------------------------------------------------------------END Reject Issued----------------------------------------------------------%>

                        <!--/.box box-primary-->

                        <!--/.col-lg-12 -->

                    </div>
                </div>
            </div>
            <!--/.col (right) -->

            <!-- /.row -->
        </section>
        <!-- /.content -->



        <script>
            $(document).ready(function () {
                // CHECK-UNCHECK ALL CHECKBOXES IN THE REPEATER 
                // WHEN USER CLICKS THE HEADER CHECKBOX.
                $('table [id*=chkAll_Pull]').click(function () {
                    if ($(this).is(':checked'))
                        $('table [id*=chk_Pull]').prop('checked', true)
                    else
                        $('table [id*=chk_Pull]').prop('checked', false)
                });

                // NOW CHECK THE HEADER CHECKBOX, IF ALL THE ROW CHECKBOXES ARE CHECKED.
                $('table [id*=chkRowData]').click(function () {

                    var total_rows = $('table [id*=chk_Pull]').length;
                    var checked_Rows = $('table [id*=chk_Pull]:checked').length;

                    if (checked_Rows == total_rows)
                        $('table [id*=chkAll_Pull]').prop('checked', true);
                    else
                        $('table [id*=chkAll_Pull]').prop('checked', false);
                });
            });
</script>
    </form>
</asp:Content>
