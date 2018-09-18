<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterTariffCode.aspx.vb" Inherits="WMS.MasterTariffCode" MasterPageFile="~/Home.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Master Exchange Rate
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>System</a></li>     
            <li><a href="MasterExchangeRate.aspx">MasterExchangeRate</a></li>                   
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
                        <h3 class="box-title">Master Exchange Rate</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
                                            
                               
                                    <!-- /.box-body -->
                                     <div class="form-group">
                                     <label for="txtlocationtariff" class="col-sm-3 control-label">พิกัดศุลกากร:</label>
                                         <div class="col-sm-5">
                                     <input type="text" class ="form-control input-sm" id="txtlocationtariff" runat="server" autocomplete="off"/>
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
                                    <label for="txtdayenduse" class="col-sm-3 control-label">วันที่สิ้นสุดการใช้:</label>
                                    <div class="col-sm-5">
                                        <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                        <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerdayenduse" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                        </asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtenderdayenduse" runat="server" Enabled="True" TargetControlID="txtdatepickerdayenduse" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                    </div>
                                </div>

                             </div>
                           </div>
                             
                       </div>
                          
                        <!--/.row-->
                        <div class="row">
                         <div class="col-lg-8 col-md-8 col-md-offset-2">
                               <div class="form-group">
                                 
                                    <div class="box-body">
                               <asp:Repeater ID="Repeater2" runat="server">
                                    <HeaderTemplate>
                                        <table id="example2" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>พิกัดศุลกากร</th>
                                                    <th>ได้รับการชดเชย</th>
                                                    <th>เริ่มต้นใช้</th>
                                                    <th>สิ้นสุดใช้</th>                                                   
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

</form>
 </asp:Content>
