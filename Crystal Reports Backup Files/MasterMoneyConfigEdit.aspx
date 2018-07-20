<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterMoneyConfigEdit.aspx.vb" Inherits="WMS.MasterMoneyConfigEdit" MasterPageFile="~/Home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Master Money Config
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>System</a></li>     
            <li><a href="MasterMoneyConfig.aspx">MasterMoneyConfig</a></li>
            <li><a href="MasterMoneyConfigEdit.aspx">MasterMoneyConfigEdit</a></li>
           
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
                        <h3 class="box-title">Master Money Config Add</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <from class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
                                            
                                <div class="form-group" >
                                    
                                        <label for="txtCode" class="col-sm-2 control-label">Code</label>
                                          
                                         <div class="col-sm-10">
                                           <input class="form-control" id="txtCode" runat="server" placeholder="Code" disabled="disabled"/>
                                        </div>
                                    </div>
                                  <div class="form-group">
                                        <label for="txtAmount" class="col-sm-2 control-label">Amount</label>
                                           <div class="col-sm-10">
                                           <input class="form-control" id="txtAmount" runat="server"  placeholder="Amount" />
                                       </div>                                      
                                    </div>                                         

                                  <div class="form-group">
                                        <label for="txtTotalAmount" class="col-sm-2 control-label">TotalAmount</label>                                                       
                                      <div class="col-sm-10">
                                           <input class="form-control" id="txtTotalAmount" runat="server"  placeholder="TotalAmount"  disabled="disabled"/>
                                        </div>                      
                                  </div>

                                  <div class="form-group">
                                        <label for="txtRemark" class="col-sm-2 control-label">Remark</label>                                                             
                                        <div class="col-sm-10">
                                        <asp:TextBox runat="server" Cssclass="form-control" TextMode="MultiLine"  ID="txtRemark" ></asp:TextBox>
                                  </div>                      
                               </div> 

                                <div class="form-group">
                                        <label for="dcbStatus" class="col-sm-2 control-label">Status</label>                                                      
                                         <div class="col-sm-10">
                                         <asp:DropDownList ID="dcbStatus" CssClass="form-control" runat="server"  AutoPostBack="true">
                                              <asp:ListItem> </asp:ListItem>
                                              <asp:ListItem>USE</asp:ListItem>  
                                              <asp:ListItem>NOT USE</asp:ListItem>
                                         </asp:DropDownList>
                                         </div>                      
                                 </div>

                                         <div class="box-footer text-right">
                                        <div class="text-center">
                                         <button type="submit" runat="server" class="btn btn-primary" id="btnAdd" title="btnAdd" onserverclick="btnAdd_ServerClick">Add</button>
                                         <button type="reset"  runat="server" class="btn btn-danger" id="btnClear" title="btnClear" onserverclick="btnClear_ServerClick">Clear</button>
                                        </div>
                                     </div>

                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </from>
                          
                        <!--/.row-->
                    </div>
                    <div class="box-header with-border">
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