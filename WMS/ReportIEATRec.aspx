<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportIEATRec.aspx.vb" Inherits="WMS.ReportIEATRec" MasterPageFile="~/Home.Master" %>

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
            <li><a href="ReportIEATRec.aspx">Report IEAT Rec</a></li>           
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
                        <h3 class="box-title">Report IEAT Rec</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
                                            
                                <div class="form-group">                                    
                                        <label for="txtReportName" class="col-sm-2 control-label">Report Name</label>                                          
                                         <div class="col-sm-10">             
                                             <asp:DropDownList ID="ddlReportName" CssClass="form-control" runat="server"></asp:DropDownList>  
                                        </div>
                                </div>
                                <div class="form-group">
                                            <label for="txtConsignee" class="col-sm-2 control-label">Consignee</label>
                                                <div class="col-lg5 col-md-5 col-sm-5">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbEAS001" Text="EAS001"  onclick="EnableDisableTextBox();"  GroupName="option1" Checked="true" />
                                              </label>
                                               </div>            
                                           </div>
                                
                                                <div class="col-lg5 col-md-5 col-sm-5">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbOther" Text="Other" onclick="EnableDisableTextBox();" GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>                                      
                                </div>                             

                                    <div class="form-group">
                                        <label for="Code" class="col-sm-2 control-label">Code</label>                                                                  
                                        <div class="col-sm-10">             
                                             <asp:DropDownList ID="ddlCode" CssClass="form-control" runat="server"></asp:DropDownList>  
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="Name" class="col-sm-2 control-label">Name</label>
                                        <div class="col-sm-2">
                                           <input class="form-control" id="txtName" runat="server"  placeholder="Name"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                         <label for="TAXNo" class="col-sm-2 control-label">TAX No</label>
                                        <div class="col-sm-2">
                                           <input class="form-control" id="txtTAXNo" runat="server"  placeholder="TAX No"/>
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
              var status = document.getElementById('<%=rdbEAS001.ClientID%>').checked;
             
            if (status == true) {
                document.getElementById('<%=ddlCode.ClientID%>').disabled = true;
                document.getElementById('<%=txtName.ClientID%>').disabled = true;
                document.getElementById('<%=txtTAXNo.ClientID%>').disabled = true;
                document.getElementById('<%=txtValume.ClientID%>').disabled = true;
            } else if (status == false){
                document.getElementById('<%=ddlCode.ClientID%>').disabled = false;
                document.getElementById('<%=txtName.ClientID%>').disabled = false;
                document.getElementById('<%=txtTAXNo.ClientID%>').disabled = false;
                document.getElementById('<%=txtValume.ClientID%>').disabled = false;
               
            }
             
        }
    </script>


</form>
 </asp:Content>
