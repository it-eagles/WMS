<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChkStockWH.aspx.vb" Inherits="WMS.ChkStockWH" MasterPageFile="~/Home.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Check Stock
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>WareHouse</a></li>     
            <li><a href="ChkStockWH.aspx">CheckStockWH</a></li>
           
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
                        <h3 class="box-title">Check Stock</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

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
                                                                  <input class="form-control" id="txtOwnerPN" runat="server"/>
                                                                </div>
                                                                  </div>  
                                                              <div class="form-group">
                                                                   <label for="txtWHSite" class="col-sm-4 control-label">WH Site:</label>                                       
                                                                <div class="col-sm-8">                                                                   
                                                                    <asp:DropDownList ID="ddlWHSite" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtDamageOther" class="col-sm-4 control-label">DamageOther:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                  <input class="form-control" id="txtDamageOther" runat="server" value="0"/>
                                                                </div>
                                                                  </div>                                                          
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                   <label for="txtWHSource" class="col-sm-4 control-label">WHSoucre:</label>                                       
                                                                <div class="col-sm-8">                                                                   
                                                                    <asp:DropDownList ID="ddlWHSource" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtQuantity" class="col-sm-4 control-label">Quantity:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                  <input class="form-control" id="txtQuantity" runat="server" value="0"/>
                                                                </div>
                                                                  </div>      
                                                              <div class="form-group">
                                                                  <label for="txtQSCRAP" class="col-sm-4 control-label">Q-SCRAP:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                  <input class="form-control" id="txtQSCRAP" runat="server" value="0"/>
                                                                </div>
                                                                  </div>                                                                 
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtCustomerPN" class="col-sm-4 control-label">Customer P/N:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustomerPN" runat="server"/>
                                                                </div>
                                                                  </div>                
                                                              <div class="form-group">
                                                                  <label for="txtCusLot" class="col-sm-4 control-label">Cus Lot:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                  <input class="form-control" id="txtCusLot" runat="server" />
                                                                </div>
                                                                  </div>     
                                                              <div class="form-group">
                                                                  <label for="txtspace" class="col-sm-4 control-label"></label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                  <button type="submit" runat="server" class="btn btn-primary" id="btnFind" title="btnFind" onserverclick="btnFind_ServerClick">Find</button>
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
                        
                    </div>
                    <!--/.row-->
                   <%-- <div class="box-header with-border">
                        <h3 class="box-title">Code Money Config</h3>
                    </div>
                     <div class="row">
                         <div class="col-lg-8 col-md-8 col-md-offset-2">
                               <div class="form-group">
                                 
                                    <div class="box-body">
                               <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example1" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Code</th>
                                                    <th>Amount</th>
                                                    <th>TotalAmount</th>
                                                    <th>Remark</th>
                                                    <th>Status</th>
                                                    <th>Edit/Delete</th>
                                                    <th>view</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amonut")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Bind("TotalAmonut")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status")%>'></asp:Label></td>
                                            <td class="text-center" >
                                                  <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="editcode" CommandArgument='<%# Eval("Code")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                  <a class="btn btn-danger"><i class="fa fa-trash"></i></a>
                                            </td>
                                            <td class="text-center">
                                                  <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="viewprofile" CommandArgument='<%# Eval("Code")%>'><i class="fa fa-search-plus"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                    <th>Code</th>
                                                    <th>Amount</th>
                                                    <th>TotalAmount</th>
                                                    <th>Remark</th>
                                                    <th>Status</th>
                                                    <th>Edit/Delete</th>
                                                    <th>view</th>
                                            </tr>
                                        </tfoot>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                    </div>
                               </div> 
                          </div>
                           
                        
                        </div>--%>
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