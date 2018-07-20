<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterLocationEdit.aspx.vb" Inherits="WMS.MasterLocationEdit" MasterPageFile="~/Home.Master"%>

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
            <li><a href="MasterLocationEdit.aspx">MasterLocationEdit</a></li>
           
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
                        <h3 class="box-title">Master Location Edit</h3>
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
                                           <input class="form-control" id="txtLocationNo" runat="server"  placeholder="LocationNo" disabled="disabled" />
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
                                        
                                        </div>
                                     </div>

                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </from>
                          
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