<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdLocWH.aspx.vb" Inherits="WMS.AdLocWH" MasterPageFile="~/Home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Adjust Location
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
                             h1{height:34px;}                                                                    
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
                                                                    <input class="form-control" id="txtOwnerPN" runat="server"/>
                                                                </div>
                                                                  </div> 
                                                              <div class="form-group">
                                                                  <label for="txtJobNo" class="col-sm-4 control-label">Job No:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                  <input class="form-control" id="txtJobNo" runat="server"/>
                                                                </div>
                                                                  </div>                                                                                                                      
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                   <label for="txtCustomerLotNo" class="col-sm-5 control-label">Customer Lot No:</label>                                       
                                                                <div class="col-sm-7">                                                                   
                                                                    <input class="form-control" id="txtCustomerLotNo" runat="server"/>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group"> 
                                                                   <label for="txtFind" class="col-sm-4 control-label">Find:</label>                                                                  
                                                                   <div class="col-sm-8">
                                                                       <div class="radio">
                                                                       <label>                                            
                                                                          <asp:RadioButton runat="server" ID ="rdbAdLoc" Text="Adjust Location"  onclick="EnableDisableTextBox();"  GroupName="option4"  />
                                                                       </label>
                                                                       </div>            
                                                                  </div>
                                                                                  
                                                              </div>
                                                              </div>

                                                          <div class="col-md-4">    
                                                              <div class="form-group">
                                                                   <label for="txtCusRefNo" class="col-sm-5 control-label">Cus Ref No(To):</label>                                       
                                                                <div class="col-sm-7">                                                                   
                                                                    <input class="form-control" id="txtCusRefNo" runat="server"/>
                                                                </div>
                                                                  </div>                                                                                                               
                                                              <div class="form-group">
                                                                     <div class="col-sm-8">
                                                                       <div class="radio">
                                                                       <label>                                            
                                                                          <asp:RadioButton runat="server" ID ="rdbAdQTY" Text="Adjust QTY"  onclick="EnableDisableTextBox();"  GroupName="option4"  />
                                                                       </label>
                                                                       </div>            
                                                                  </div>                             
                                                                <div class="col-sm-4">                                                                    
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
                        
                        <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                    <div class="col-md-6">
          <!-- Horizontal Form -->
          
            <!-- form start -->
            <div class="form-horizontal">
                <fieldset>  <legend>Input</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtRecordQTY" class="col-sm-4 control-label">Record QTY:</label>
                  <div class="col-sm-8">                    
                      <input class="form-control" id="txtRecordQTY" runat="server" value="0"/>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAvalibleQTY" class="col-sm-4 control-label">Avalible QTY:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAvalibleQTY" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtType" class="col-sm-4 control-label">Type:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server"></asp:DropDownList>  
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
                <fieldset>  <legend>Input</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtRCVQuantity" class="col-sm-4 control-label">RCV Quantity:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtRCVQuantity" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-3">
                     <label>
                         <input type="checkbox" runat="server" id="chkStatus" />Status
                     </label>
                  </div>
                   <div class="col-sm-4">
                       <div class="radio">
                       <label>                                            
                          <asp:RadioButton runat="server" ID ="rdbGoodComplete" Text="Goods Complete"  onclick="EnableDisableTextBox();"  GroupName="option3"  />
                       </label>
                       </div>            
                  </div>
                  <div class="col-sm-4">
                       <div class="radio">
                       <label>                                            
                          <asp:RadioButton runat="server" ID ="rdbGoodDamage" Text="Goods Damage"  onclick="EnableDisableTextBox();"  GroupName="option3"  />
                       </label>
                       </div>            
                  </div>                  
                </div>
                <div class="form-group">
                  <label for="txtDamageQTY" class="col-sm-4 control-label">Damage QTY:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtDamageQTY" runat="server" value="0"/>
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