<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterExchangeRate.aspx.vb" Inherits="WMS.MasterExchangeRate" MasterPageFile="~/Home.Master"%>

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

                        <from class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
                                            
                                <div class="form-group" >
                                    
                                        <label for="txtSelect" class="col-sm-3 control-label">Select File For Import</label>                                          
                                         <div class="col-sm-5">
                                           <input type="file" class ="form-control" id="txtDirectory" runat="server"/>
                                        </div>
                                       
                                    </div>

                                <div class="form-group">
                                        <label for="dcbStatus" class="col-sm-3 control-label">Status</label>                                                      
                                         <div class="col-sm-5">
                                         <asp:DropDownList ID="dcbStatus" CssClass="form-control" runat="server" AutoPostBack="true" >
                                              <asp:ListItem Text="--Select--"></asp:ListItem>
                                              <asp:ListItem>Import</asp:ListItem>  
                                              <asp:ListItem>Export</asp:ListItem>
                                         </asp:DropDownList>
                                         </div>                      
                                 </div>

                                     <div class="box-footer text-right">
                                        <div class="text-center">  
                                           <button type="submit" runat="server" class="btn btn-primary" id="btnImport" title="btnImport" onserverclick="btnGenScript_Click">Import</button>
<%--                                         <button type="submit" runat="server" class="btn btn-primary" id="btnAdd" title="btnAdd" onserverclick="btnAdd_ServerClick">Add</button>
                                         <button type="reset"  runat="server" class="btn btn-danger" id="btnClear" title="btnClear" onserverclick="btnClear_ServerClick">Clear</button>--%>
                                        </div>
                                     </div>

                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </from>
                          
                        <!--/.row-->
                    </div>
                    <div class="box-header with-border">
                        <h3 class="box-title">Exchange Rate List</h3>
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
                                                    <th>Currency</th>
                                                    <th>StartDate</th>
                                                    <th>EndDate</th>
                                                    <th>ExchangeRate</th>
                                                    <th>BathAmount</th>
                                                    <th>Status</th>
                                                    <%--<th>Edit/Delete</th>
                                                    <th>view</th>--%>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Currency")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("StartDate")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Bind("EndDate")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("ExchangeRate")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("BathAmount")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Status")%>'></asp:Label></td>
                                            <%--<td class="text-center" >
                                                  <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="editcode" CommandArgument='<%# Eval("Code")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                  <a class="btn btn-danger"><i class="fa fa-trash"></i></a>
                                            </td>
                                            <td class="text-center">
                                                  <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="viewprofile" CommandArgument='<%# Eval("Code")%>'><i class="fa fa-search-plus"></i></asp:LinkButton>
                                            </td>--%>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                    <th>Currency</th>
                                                    <th>StartDate</th>
                                                    <th>EndDate</th>
                                                    <th>ExchangeRate</th>
                                                    <th>BathAmount</th>
                                                    <th>Status</th>
                                                    <%--<th>Edit/Delete</th>
                                                    <th>view</th>--%>
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
