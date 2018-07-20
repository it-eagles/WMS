<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterLocation.aspx.vb" Inherits="WMS.MasterLocation" MasterPageFile="~/Home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Master Location
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>System</a></li>     
            <li><a href="MasterLocation.aspx">MasterLocation</a></li>
           
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
                        <h3 class="box-title">Master Location Add</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <from class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
                                            
                                <div class="form-group" >
                                    
                                        <label for="txtWHsite" class="col-sm-2 control-label">WHsite</label>
                                          
                                         <div class="col-sm-10">
                                           <input class="form-control" id="txtWHsite" runat="server" placeholder="WHsite" />
                                        </div>
                                    </div>
                                  <div class="form-group">
                                        <label for="txtLocationNo" class="col-sm-2 control-label">LocationNo</label>
                                           <div class="col-sm-10">
                                           <input class="form-control" id="txtLocationNo" runat="server"  placeholder="LocationNo" />
                                       </div>
                                      
                                    </div>
                                                 
                                    <div class="form-group" >
                                          <label class="col-sm-2 control-label">Status</label>
                                                                        
                                       <div class="col-lg2 col-md-5">
                                            <div class="radio">
                                            <label>                                            
                                             <asp:RadioButton runat="server" ID ="rdbPallet" Text="Pallet"  onclick="EnableDisableTextBox();"  GroupName="option1" Checked="true" />
                                          </label>
                                           </div>            
                                       </div>
                                
                                        <div class="col-lg2 col-md-5">
                                            <div class="radio">
                                            <label>                                            
                                             <asp:RadioButton runat="server" ID ="rdbPalletNone" Text="ปริมาตร" onclick="EnableDisableTextBox();" GroupName="option1"/>
                                          </label>
                                           </div>            
                                       </div>
                                       </div>                              

                                    <div class="form-group">
                                        <label for="Width" class="col-sm-2 control-label">Width</label>                                                                  
                                        <div class="col-sm-2">
                                           <input class="form-control" id="txtWidth" runat="server"  placeholder="Width" value="0" />
                                        </div>
                                        <label for="Long" class="col-sm-2 control-label">Long</label>
                                        <div class="col-sm-2">
                                           <input class="form-control" id="txtLong" runat="server"  placeholder="Long" value="0"/>
                                        </div>
                                         <label for="Heigth" class="col-sm-2 control-label">Heigth</label>
                                        <div class="col-sm-2">
                                           <input class="form-control" id="txtHeigth" runat="server"  placeholder="Heigth" value="0"/>
                                        </div>                      
                                    </div>
                                    

                                  <div class="form-group">
                                        <label for="Valume" class="col-sm-2 control-label">Valume</label>                                                       
                                      <div class="col-sm-10">
                                           <input class="form-control" id="txtValume" runat="server"  placeholder="Valume" value="0"/>
                                        </div>                      
                                  </div>

                                <div class="form-group">
                                        <label for="txtUsedStatus" class="col-sm-2 control-label">UsedStatus</label>                                                      
                                         <div class="col-sm-10">
                                         <input class="form-control" id="txtUsedStatus" runat="server" placeholder="UsedStatus" value="0"/>
                                         </div>                      
                                 </div>

                               <div class="form-group">
                                        <label for="txtQTYPallet" class="col-sm-2 control-label">QTYPallet</label>                                                             
                                        <div class="col-sm-10">
                                        <input  class="form-control" id="txtQTYPallet" runat="server"  placeholder="QTYPallet" value="0"/>
                                        </div>                      
                               </div>

                               <div class="form-group">
                                        <label for="txtRemark" class="col-sm-2 control-label">Remark</label>                                                             
                                        <div class="col-sm-10">
                                        <asp:TextBox runat="server" Cssclass="form-control" TextMode="MultiLine"  ID="txtRemark" ></asp:TextBox>
                                        </div>                      
                               </div> 

                                     <div class="box-footer text-right">
                                        <div class="text-center">
                                         <button type="submit" runat="server" class="btn btn-primary" id="btnAdd" title="btnAdd" onserverclick="Button1_ServerClick">Add</button>
                                         <button type="reset"  runat="server" class="btn btn-danger" id="btnClear" title="btnClear" onserverclick="Button2_ServerClick">Clear</button>
                                        </div>
                                     </div>

                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </from>
                          
                        <!--/.row-->
                    </div>
                    <div class="box-header with-border">
                        <h3 class="box-title">Location List</h3>
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
                                                    <th>WHsite</th>
                                                    <th>Location</th>
                                                    <th>Width</th>
                                                    <th>Long</th>
                                                    <th>Height</th>
                                                    <th>Valume</th>
                                                    <th>QTYPallet</th>
                                                    <th>Edit/Delete</th>
                                                    <th>view</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblWHsite" runat="server" Text='<%# Bind("WHsite")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("LocationNo")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblWidth" runat="server" Text='<%# Bind("Width")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblLong" runat="server" Text='<%# Bind("Long")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblHeight" runat="server" Text='<%# Bind("Height")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblValume" runat="server" Text='<%# Bind("Valume")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblQTYPallet" runat="server" Text='<%# Bind("QTYPallet")%>'></asp:Label></td>
                                            
                                            <td class="text-center" >
                                                  <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="editlocation" CommandArgument='<%# Eval("LocationNo")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                  <a class="btn btn-danger"><i class="fa fa-trash"></i></a>
                                            </td>
                                            <td class="text-center">
                                                  <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="viewprofile" CommandArgument='<%# Eval("LocationNo")%>'><i class="fa fa-search-plus"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                    <th>WHsite</th>
                                                    <th>Location</th>
                                                    <th>Width</th>
                                                    <th>Long</th>
                                                    <th>Height</th>
                                                    <th>Valume</th>
                                                    <th>QTYPallet</th>
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

          <script type="text/javascript">
          function EnableDisableTextBox() {
              var status = document.getElementById('<%=rdbPallet.ClientID%>').checked;
             
            if (status == true) {
                document.getElementById('<%=txtWidth.ClientID%>').disabled = true;
                document.getElementById('<%=txtLong.ClientID%>').disabled = true;
                document.getElementById('<%=txtHeigth.ClientID%>').disabled = true;
                document.getElementById('<%=txtValume.ClientID%>').disabled = true;
                document.getElementById('<%=txtUsedStatus.ClientID%>').disabled = true;        
                document.getElementById('<%=txtQTYPallet.ClientID%>').disabled = false;  
            } else if (status == false){
                document.getElementById('<%=txtWidth.ClientID%>').disabled = false;
                document.getElementById('<%=txtLong.ClientID%>').disabled = false;
                document.getElementById('<%=txtHeigth.ClientID%>').disabled = false;
                document.getElementById('<%=txtValume.ClientID%>').disabled = false;
                document.getElementById('<%=txtUsedStatus.ClientID%>').disabled = false;
                document.getElementById('<%=txtQTYPallet.ClientID%>').disabled = true;  
               
            }
             
        }
    </script>


</form>
 </asp:Content>
