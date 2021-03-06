﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdLocWH.aspx.vb" Inherits="WMS.AdLocWH" MasterPageFile="~/Home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Adjust Location
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a><i class="fa fa-file"></i>WareHouse</a></li>
                <li><a href="AdLocWH.aspx">AdjustLocation</a></li>

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
                            <h3 class="box-title">Adjust Location</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="row">
                            <style>
                                h1 {
                                    height: 34px;
                                }
                            </style>
                            <%-----------------------------------------------------Start JOB Form-----------------------------------------------------------%>
                            <div class="col-lg-12 col-md-12 ">
                                <!-- form start -->
                                <div class="form-horizontal">
                                    <%--<fieldset>  <legend>Job</legend>--%>
                                    <div class="box-body">
                                        <div class="col-md-4 col-sm-4">
                                            <div class="form-group">
                                                <label for="txtOwnerPN" class="col-sm-4 control-label">Owner P/N:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtOwnerPN" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtJobNo" class="col-sm-4 control-label">Job No:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtJobNo" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtInvoice" class="col-sm-4 control-label">Inovice:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control input-sm" id="txtInvoice" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="txtCustomerLotNo" class="col-sm-5 control-label">Customer Lot No:</label>
                                                <div class="col-sm-7">
                                                    <input class="form-control" id="txtCustomerLotNo" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtFind" class="col-sm-5 control-label" style="height: 34px;">Find:</label>
                                                <div class="col-sm-7">
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton runat="server" ID="rdbAdLoc" Text="Adjust Location" onclick="EnableDisableTextBox();" GroupName="option4" />
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-2">
                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnFind" title="btnFind" onserverclick="btnFind_ServerClick">Find</button>
                                                </div>
                                                <div class="col-sm-2"></div>
                                                <div class="col-sm-2">
                                                    <button type="submit" runat="server" class="btn btn-success" id="btnClear" title="btnClear" onserverclick="btnClear_ServerClick">Clear</button>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="txtCusRefNo" class="col-sm-5 control-label">Cus Ref No(To):</label>
                                                <div class="col-sm-7">
                                                    <input class="form-control input-sm" id="txtCusRefNo" runat="server" autocomplete="off" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-sm-8">
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton runat="server" ID="rdbAdQTY" Text="Adjust QTY" onclick="EnableDisableTextBox();" GroupName="option4" />
                                                        </label>
                                                    </div>
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
                            <%-------------------------------------------------------End JOB Form----------------------------------------------------------------%>

                            <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                            <div class="col-md-6">
                                <!-- Horizontal Form -->

                                <!-- form start -->
                                <div class="form-horizontal">
                                    <fieldset>
                                        <legend>Input</legend>
                                        <div class="box-body">
                                            <div class="form-group">
                                                <label for="txtOwnerPN2" class="col-sm-4 control-label">Owner P/N:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtOwnerPN2" runat="server" value="0" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtLocation" class="col-sm-3 control-label">Location:</label>
                                                <div class="checkbox col-sm-1">
                                                    <input type="checkbox" runat="server" id="chkLocation" onclick="EnableDisableTextBox();" checked="checked"/>
                                                </div>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtLocation" runat="server" value="0" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtAvalibleQTY" class="col-sm-3 control-label">Avalible QTY:</label>
                                                <div class="checkbox col-sm-1">
                                                    <input type="checkbox" runat="server" id="chkAvalibleQTY" onclick="EnableDisableTextBox3();" checked="checked"/>
                                                </div>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtAvalibleQTY" runat="server" value="0" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtType" class="col-sm-4 control-label">Type:</label>
                                                <div class="col-sm-8">
                                                    <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server">
                                                        <asp:ListItem> Q-FFL</asp:ListItem>
                                                         <asp:ListItem> Q-CON</asp:ListItem>
                                                        <asp:ListItem> Q-SC</asp:ListItem>
                                                         <asp:ListItem> Q-SCRAP</asp:ListItem>
                                                        <asp:ListItem> BackFill</asp:ListItem>
                                                         <asp:ListItem> SAMPLE</asp:ListItem>
                                                        <asp:ListItem> QC FZ AIR</asp:ListItem>
                                                         <asp:ListItem> RETURN FZ AIR</asp:ListItem>
                                                        <asp:ListItem> NG PART FZ AIR</asp:ListItem>
                                                         <asp:ListItem> QC FZ SEA</asp:ListItem>
                                                        <asp:ListItem> RETURN FZ SEA</asp:ListItem>
                                                         <asp:ListItem> NG PART FZ SEA</asp:ListItem>
                                                        <asp:ListItem> SCRAP AFTER CLAIM</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtWeight" class="col-sm-4 control-label">Weight:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtWeight" runat="server" value="0" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtRemark" class="col-sm-4 control-label">Remark:</label>
                                                <div class="col-sm-8">
                                                    <textarea class="form-control" rows="3" id="txtRemark" placeholder="Remark" runat="server" style="height: 71px;"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.box-body -->
                                    </fieldset>
                                </div>
                                <!-- /.box -->
                            </div>
                            <!--/.col (left) -->
                            <%---------------------------------------------------------------End Left Form------------------------------------------------%>
                            <%------------------------------------------------------------Start Right Form------------------------------------------------%>
                            <div class="col-md-6">
                                <!-- Horizontal Form -->
                                <!-- form start -->
                                <div class="form-horizontal">
                                    <fieldset>
                                        <legend>Input</legend>
                                        <div class="box-body">
                                            <div class="form-group">
                                                <label for="txtCustomerLotNo2" class="col-sm-4 control-label">Customer Lot No:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtCustomerLotNo2" runat="server" value="0" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtRCVQuantity" class="col-sm-4 control-label">RCV Quantity:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtRCVQuantity" runat="server" value="0" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtStatus" class="col-sm-3 control-label">Status:</label>
                                                <div class="checkbox col-sm-1">
                                                    <input type="checkbox" runat="server" id="chkStatus" onclick="EnableDisableTextBox1();" checked="checked" />
                                                </div>
                                                <div class="col-sm-4">
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton runat="server" ID="rdbGoodComplete" Text="Goods Complete" onclick="EnableDisableTextBox4();" GroupName="option3" />
                                                        </label>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4">
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton runat="server" ID="rdbGoodDamage" Text="Goods Damage"  onclick="EnableDisableTextBox4();" GroupName="option3" />
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtDamageQTY" class="col-sm-3 control-label">Damage QTY:</label>
                                                <div class="checkbox col-sm-1">
                                                    <input type="checkbox" runat="server" id="chkDamageQTY" checked="checked"/>
                                                </div>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtDamageQTY" runat="server" value="0"  />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtUnit" class="col-sm-4 control-label">Unit:</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtUnit" runat="server" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtspace" class="col-sm-4 control-label"></label>
                                                <div class="col-sm-8">
                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnSave" title="btnSave" onserverclick="btnSave_ServerClick">Save</button>
                                                </div>
                                            </div>


                                        </div>
                                        <!-- /.box-body -->
                                    </fieldset>
                                </div>
                                <!-- /.box -->
                            </div>
                            <!-- right column -->

                            <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>
                        </div>
                        <!--/.row-->
                        <div class="box-header with-border">
                            
                        </div>
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
                                                            <th>OwnerPN</th>
                                                            <th>CustomerLOTNo</th>
                                                            <th>LOTNo</th>
                                                            <th>ItemNo</th>
                                                            <th>ReceiveNo</th>

                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="danger">

                                                    <td class="text-center">
                                                        <asp:LinkButton ID="clickrpt" CssClass="btn btn-default" runat="server" OnClick="clickrpt_Click"><i class="fa fa-pencil"></i></asp:LinkButton></td>
                                                    <td>
                                                        <asp:Label ID="lblOwnerPN" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblCustomerLOTNo" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblLOTNo" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblItemNo" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblReceiveNo" runat="server" Text="Label"></asp:Label></td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <tfoot>
                                                    <tr>
                                                        <th>Select</th>
                                                        <th>OwnerPN</th>
                                                        <th>CustomerLOTNo</th>
                                                        <th>LOTNo</th>
                                                        <th>ItemNo</th>
                                                        <th>ReceiveNo</th>


                                                    </tr>
                                                </tfoot>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                <div class="form-group">

                                    <div class="box-body">
                                        <asp:Repeater ID="Repeater2" runat="server">
                                            <HeaderTemplate>
                                                <table id="example2" class="table table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th>LOTNo</th>
                                                            <th>WHSite</th>
                                                            <th>ENDCustomer</th>
                                                            <th>CustomerLOTNo</th>
                                                            <th>ItemNo</th>
                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLOTNo" runat="server" Text='<%# Bind("LOTNo")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblWHSite" runat="server" Text='<%# Bind("WHSite")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblENDCustomer" runat="server" Text='<%# Bind("ENDCustomer")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblCustomerLOTNo" runat="server" Text='<%# Bind("CustomerLOTNo")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblItemNo" runat="server" Text='<%# Bind("ItemNo")%>'></asp:Label></td>

                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <tfoot>
                                                    <tr>
                                                        <th>LOTNo</th>
                                                        <th>WHSite</th>
                                                        <th>ENDCustomer</th>
                                                        <th>CustomerLOTNo</th>
                                                        <th>ItemNo</th>
                                                    </tr>
                                                </tfoot>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>


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
                      var status = document.getElementById('<%=chkLocation.ClientID%>').checked;

                if (status == true) {
                   
                  document.getElementById('<%=txtLocation.ClientID%>').disabled = true;

                
              } else if (status == false) {
                  
                document.getElementById('<%=txtLocation.ClientID%>').disabled = false;
                

            }

                  }


        </script>

        <script type="text/javascript">
            function EnableDisableTextBox1() {
                var status = document.getElementById('<%=chkStatus.ClientID%>').checked;

                      if (status == true) {
                          document.getElementById('<%=rdbGoodComplete.ClientID%>').disabled = true;
                          document.getElementById('<%=rdbGoodDamage.ClientID%>').disabled = true;
                          

                } else if (status == false) {
                    document.getElementById('<%=rdbGoodComplete.ClientID%>').disabled = false;
                    document.getElementById('<%=rdbGoodDamage.ClientID%>').disabled = false;
         }

            }

        </script>
        

         

        <script type="text/javascript">
            function EnableDisableTextBox2() {
                var status = document.getElementById('<%=chkDamageQTY.ClientID%>').checked;

                if (status == true) {
                    document.getElementById('<%=txtDamageQTY.ClientID%>').disabled = true;

                      } else  {
                          document.getElementById('<%=txtDamageQTY.ClientID%>').disabled = false;
                }

        }

        </script>


        <script type="text/javascript">
            function EnableDisableTextBox3() {
                var status = document.getElementById('<%=chkAvalibleQTY.ClientID%>').checked;

                if (status == true) {
                    document.getElementById('<%=txtAvalibleQTY.ClientID%>').disabled = true;

                } else {
                    document.getElementById('<%=txtAvalibleQTY.ClientID%>').disabled = false;
                }

            }

        </script>

        <script type="text/javascript">
            function EnableDisableTextBox4() {
                var status = document.getElementById('<%=rdbGoodComplete.ClientID%>').checked;

                if (status == true) {
                    document.getElementById('<%=txtAvalibleQTY.ClientID%>').disabled = false;
                    document.getElementById('<%=txtDamageQTY.ClientID%>').disabled = true;
                    document.getElementById('<%=chkAvalibleQTY.ClientID%>').checked = false;
                    document.getElementById('<%=chkDamageQTY.ClientID%>').checked = true;

                } else {
                    document.getElementById('<%=txtAvalibleQTY.ClientID%>').disabled = true;
                    document.getElementById('<%=txtDamageQTY.ClientID%>').disabled = false;
                    document.getElementById('<%=chkAvalibleQTY.ClientID%>').checked = true;
                    document.getElementById('<%=chkDamageQTY.ClientID%>').checked = false;
                }

            }

        </script>
        
      

    </form>
</asp:Content>
