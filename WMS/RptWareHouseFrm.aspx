<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RptWareHouseFrm.aspx.vb" Inherits="WMS.RptWareHouseFrm" MasterPageFile="~/Home.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Report Ware House   
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a><i class="fa fa-file"></i>Report</a></li>
                <li><a href="RptWareHouse.aspx">Report Ware House</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->
                <div class="col-lg-12 col-md-12 ">

                    <!-- general form elements -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Report Ware House</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="row">

                            <div class="form-horizontal">

                                <div class="box-body">
                                    <div class="col-md-4 col-sm-4">
                                        <div class="form-group">
                                            <label for="txtDocType" class="col-sm-4 control-label">Doc Type:</label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlDocType" CssClass="form-control" runat="server">
                                                    <asp:ListItem>General Stock Report</asp:ListItem>
                                                    <asp:ListItem> Stock Report New</asp:ListItem>
                                                    <asp:ListItem>HTI Quarantine Stock Control</asp:ListItem>
                                                    <asp:ListItem>Check HTI Quarantine Stock Control</asp:ListItem>
                                                    <asp:ListItem>Summary Receipt</asp:ListItem>
                                                    <asp:ListItem>Summary Issue</asp:ListItem>
                                                    <asp:ListItem>Check Summary Receipt</asp:ListItem>
                                                    <asp:ListItem>Summary Unpicking Report</asp:ListItem>
                                                    <asp:ListItem>HTI Stock Take</asp:ListItem>
                                                    <asp:ListItem>Receipt Planned Report</asp:ListItem>
                                                    <asp:ListItem>Receipt Summary Report</asp:ListItem>
                                                    <asp:ListItem>Unstuffing Tally Report</asp:ListItem>
                                                    <asp:ListItem>Receipt Discrepancy Report</asp:ListItem>
                                                    <asp:ListItem>Goods Receipt Note Report</asp:ListItem>
                                                    <asp:ListItem>Product Inventory Detail Report</asp:ListItem>
                                                    <asp:ListItem>Product Inventory Detail For Export Report</asp:ListItem>
                                                    <asp:ListItem>Product Inventory Summary Report</asp:ListItem>
                                                    <asp:ListItem>Putaway List Report</asp:ListItem>
                                                    <asp:ListItem>Stock Out Report</asp:ListItem>
                                                    <asp:ListItem>Stock Movement Report</asp:ListItem>
                                                    <asp:ListItem>Order Tally Report</asp:ListItem>
                                                    <asp:ListItem>Pick List/Ticket Report</asp:ListItem>
                                                    <asp:ListItem>Pick List/Ticket Report for Pick</asp:ListItem>
                                                    <asp:ListItem>Picking Not Issued</asp:ListItem>
                                                    <asp:ListItem>Delivery Summary Report</asp:ListItem>
                                                    <asp:ListItem>Issued Planned Report</asp:ListItem>
                                                    <asp:ListItem>WareHouse Activity Report</asp:ListItem>
                                                    <asp:ListItem>Summary Job Receipt From LKB</asp:ListItem>
                                                    <asp:ListItem>Summary Job Issued From LKB</asp:ListItem>
                                                    <asp:ListItem>Other Summary Receipt</asp:ListItem>
                                                    <asp:ListItem>Other Summary Issue</asp:ListItem>
                                                    <asp:ListItem>Other Quarantine Stock Control</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtJobno" class="col-sm-4 control-label">Job No:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtJobno" runat="server" placeholder="Job No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtPartNo" class="col-sm-4 control-label">Part No:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtPartNo" runat="server" placeholder="Part No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtLocationNo" class="col-sm-4 control-label">Location No:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtLocationNo" runat="server" placeholder="Location No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtCusRefNo" class="col-sm-4 control-label">CUSREF No:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtCusRefNo" runat="server" placeholder="CUSREF No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtOrderNo" class="col-sm-4 control-label">Order No:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtOrderNo" runat="server" placeholder="Order No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtReceivedDate" class="col-sm-5 control-label">Received Date:</label>
                                            <div class="col-sm-1">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" runat="server" id="chkReceivedDate" checked="checked" onclick="EnableDisableTextBox();" />
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <asp:TextBox CssClass="form-control input" ID="txtdatepickerReceivedDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderReceivedDate" runat="server" Enabled="True" TargetControlID="txtdatepickerReceivedDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtIssuedDate" class="col-sm-5 control-label">Issued Date:</label>
                                            <div class="col-sm-1">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" runat="server" id="chkIssuedDate" checked="checked" onclick="EnableDisableTextBox2();" />
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <asp:TextBox CssClass="form-control input" ID="txtdatepickerIssuedDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderIssuedDate" runat="server" Enabled="True" TargetControlID="txtdatepickerIssuedDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtCusCode" class="col-sm-4 control-label">Cus Code:</label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlCusCode" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtENDUserCode" class="col-sm-4 control-label">END User Code:</label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlENDUserCode" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtWHSite" class="col-sm-3 control-label">WH Site:</label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlWHSite" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtToJobno" class="col-sm-3 control-label">To:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtToJobno" runat="server" placeholder="Job No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtToPartNo" class="col-sm-3 control-label">To:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtToPartNo" runat="server" placeholder="Part No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtToLocationNo" class="col-sm-3 control-label">To:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtToLocationNo" runat="server" placeholder="Location No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtToCusRefNo" class="col-sm-3 control-label">To:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtToCusRefNo" runat="server" placeholder="CUSREF No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtWHSource" class="col-sm-3 control-label">WH Source:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtWHSource" runat="server" placeholder="WHSource No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtToReceivedDate" class="col-sm-3 control-label">To:</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox CssClass="form-control input" ID="txtdatepickerToReceivedDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderToReceivedDate" runat="server" Enabled="True" TargetControlID="txtdatepickerToReceivedDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtToIssuedDate" class="col-sm-3 control-label">To:</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox CssClass="form-control input" ID="txtdatepickerToIssuedDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtenderToIssuedDate" runat="server" Enabled="True" TargetControlID="txtdatepickerToIssuedDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtToCusCode" class="col-sm-3 control-label">To:</label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlToCusCode" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtToENDUserCode" class="col-sm-3 control-label">To:</label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlToENDUserCode" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>


                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group" style="height: 34px;">
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-4">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" runat="server" id="chkAllNJR" />All NJR
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group" style="height: 34px;">
                                            <%--<div class="col-sm-3"></div>--%>
                                        </div>
                                        <div class="form-group" style="height: 34px;">
                                            <label for="txtLiveOfGoods" class="col-sm-4 control-label">Live Of Goods:</label>
                                            <div class="col-sm-4">
                                                <div class="radio">
                                                    <label>
                                                        <asp:RadioButton runat="server" ID="rdbExpireDate" Text="Expire Date" GroupName="option1" />
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="radio">
                                                    <label>
                                                        <asp:RadioButton runat="server" ID="rdbNotExpire" Text="Not Expire" GroupName="option1" />
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group" style="height: 34px;">
                                            <%--<div class="col-sm-3"></div>--%>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtTypeOfGoods" class="col-sm-4 control-label">TypeOfGoods:</label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlTypeOfGoods" CssClass="form-control" runat="server">
                                                    <asp:ListItem>Q-FFL</asp:ListItem>
                                                    <asp:ListItem>Q-CON</asp:ListItem>
                                                    <asp:ListItem>Q-SC</asp:ListItem>
                                                    <asp:ListItem>Q-SCRAP</asp:ListItem>
                                                    <asp:ListItem>BackFill</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtEndCustomer" class="col-sm-4 control-label">End Customer:</label>
                                            <div class="col-sm-8">
                                                <input class="form-control" id="txtEndCustomer" runat="server" placeholder="EndCustomer No" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-sm-4"></div>
                                        <div class="form-group">
                                            <div class="col-sm-4">
                                                <button type="submit" runat="server" class="btn btn-primary btn-lg" id="btnListData" title="btnListData" onserverclick="btnListData_ServerClick">LIST DATA</button>
                                            </div>
                                            <div class="col-sm-2">
                                                <button type="submit" runat="server" class="btn btn-primary btn-lg" id="btnReport" title="btnReport" onserverclick="btnReport_ServerClick"><i class="fa fa-print"></i></button>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-3"></div>

                                        </div>

                                    </div>
                                    <div class="col-lg-12 col-xs-12">
                                        <asp:Repeater ID="Repeater1" runat="server" >
                                            <HeaderTemplate>
                                                <table id="example1" class="table table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th>UserName</th>
                                                            <th>Name</th>
                                                            <th>UserGroup</th>
                                                            <th>GroupName</th>
                                                            <th>Dept</th>
                                                            <th>Edit/Delete</th>
                                                            <th>view</th>
                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>

                                            <ItemTemplate>


                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblUserGroup" runat="server" Text='<%# Bind("UserGroupCode")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("UserGroupName")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblDept" runat="server" Text='<%# Bind("DepartmentName")%>'></asp:Label></td>
                                                    <td class="text-center">
                                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="edituser" CommandArgument='<%# Eval("UserName")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                        <a class="btn btn-danger"><i class="fa fa-trash"></i></a>
                                                    </td>
                                                    <td class="text-center">
                                                        <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="viewprofile" CommandArgument='<%# Eval("UserName")%>'><i class="fa fa-search-plus"></i></asp:LinkButton>

                                                    </td>
                                                </tr>

                                            </ItemTemplate>

                                            <FooterTemplate>
                                                <tfoot>
                                                    <tr>
                                                        <th>UserName</th>
                                                        <th>Name</th>
                                                        <th>UserGroup</th>
                                                        <th>GroupName</th>
                                                        <th>Dept</th>
                                                        <th>Edit/Delete</th>
                                                        <th>view</th>
                                                    </tr>
                                                </tfoot>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>

                                    <!-- /.box-body -->
                                </div>
                                <!-- /.box-header -->

                            </div>

                            <!--/.row-->
                        </div>


                        <!--/.row-->
                    </div>


                    <!--/.box box-primary-->
                </div>
                <!--/.col-lg-12 -->
            </div>

            <!--/.col (right) -->

            <!-- /.row -->
        </section>
        <!-- /.content -->

        <script type="text/javascript">
            function EnableDisableTextBox() {
                var status1 = document.getElementById('<%=chkReceivedDate.ClientID%>').checked;
              if (status1 == true) {
                  document.getElementById('<%=txtdatepickerReceivedDate.ClientID%>').disabled = true;
                  document.getElementById('<%=txtdatepickerToReceivedDate.ClientID%>').disabled = true;
              } else if (status1 == false) {
                  document.getElementById('<%=txtdatepickerReceivedDate.ClientID%>').disabled = false;
                document.getElementById('<%=txtdatepickerToReceivedDate.ClientID%>').disabled = false;
            }
    }
        </script>

        <script type="text/javascript">
            function EnableDisableTextBox2() {
                var status2 = document.getElementById('<%=chkIssuedDate.ClientID%>').checked;
                        if (status2 == true) {
                            document.getElementById('<%=txtdatepickerIssuedDate.ClientID%>').disabled = true;
                    document.getElementById('<%=txtdatepickerToIssuedDate.ClientID%>').disabled = true;
                } else if (status2 == false) {
                    document.getElementById('<%=txtdatepickerIssuedDate.ClientID%>').disabled = false;
                document.getElementById('<%=txtdatepickerToIssuedDate.ClientID%>').disabled = false;
            }
    }
        </script>
        <%--<script type="text/javascript">
                function EnableDisableTextBox2() {
                    var status2 = document.getElementById('<%=txtJobno.ClientID%>').onkeyup;
                        if (status2 == true) {
                            document.getElementById('<%=txtToJobno.ClientID%>').textContent = document.getElementById('<%=txtJobno.ClientID%>').textContent;
                }
    }
    </script>--%>
    </form>
</asp:Content>
