<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportIEATRec.aspx.vb" Inherits="WMS.ReportIEATRec" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
            <li><a><i class="fa fa-file"></i>Receive Process</a></li>     
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
                                        <div class="col-sm-4">
                                           <input class="form-control" id="txtName" runat="server"  placeholder="Name"/>
                                        </div>
                                        <label for="TAXNo" class="col-sm-2 control-label">TAX No</label>
                                        <div class="col-sm-4">
                                           <input class="form-control" id="txtTAXNo" runat="server"  placeholder="TAX No"/>
                                        </div> 
                                    </div>                                   

                                  <div class="form-group">
                                        <label for="JobSite" class="col-sm-2 control-label">Job Site</label>                                                       
                                      <div class="col-sm-10">             
                                             <asp:DropDownList ID="ddlJobSite_ReportIEATRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                                        </div>                      
                                  </div>

                                <div class="form-group">
                                            <label for="txtStatus" class="col-sm-2 control-label">Status</label>
                                                <div class="col-lg2 col-md-2 col-sm-2">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb1_1" Text="rdb1,1"  GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>
                                
                                                <div class="col-lg2 col-md-2 col-sm-2">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb1_2" Text="rdb1,2"  GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>       
                                                
                                                <div class="col-lg2 col-md-2 col-sm-2">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb1_3" Text="rdb1,3"  GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>
                                
                                                <div class="col-lg2 col-md-2 col-sm-2">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb1_4" Text="rdb1,4"  GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>                      
                                </div>

                                <div class="form-group">
                                            <label for="txtStatus" class="col-sm-2 control-label"></label>
                                                <div class="col-lg2 col-md-2 col-sm-2">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb2_1" Text="rdb2,1"  GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>
                                
                                                <div class="col-lg2 col-md-2 col-sm-2">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb2_2" Text="rdb2,2"  GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>       
                                                
                                                <div class="col-lg2 col-md-2 col-sm-2">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb2_3" Text="rdb2,3"  GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>
                                
                                                <div class="col-lg2 col-md-2 col-sm-2">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb2_4" Text="rdb2,4"  GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>                      
                                </div>

                               <div class="form-group">
                                        <label for="txtFromDate" class="col-sm-2 control-label">From Date</label>                                                             
                                        <div class="col-sm-10">                                            
                                            <asp:TextBox CssClass="form-control" ID="txtdatepickerFromDate" runat="server" placeholder="DD/MM/YYYY">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtendertxtdatepickerFromDate" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>                     
                               </div>

                               <div class="form-group">
                                        <label for="txtToDate" class="col-sm-2 control-label">To Date</label>                                                             
                                        <div class="col-sm-10">                                            
                                            <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate" runat="server" placeholder="DD/MM/YYYY">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtenderToDate" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>                     
                               </div> 

                                     <div class="box-footer text-right">
                                        <div class="text-center">
                                         <button type="submit" runat="server" class="btn btn-primary" id="btnPrint" title="btnPrint" onserverclick="btnPrint_ServerClick">Print</button>                                         
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
            } else if (status == false){
                document.getElementById('<%=ddlCode.ClientID%>').disabled = false;
                document.getElementById('<%=txtName.ClientID%>').disabled = false;
                document.getElementById('<%=txtTAXNo.ClientID%>').disabled = false;
            }
        }
    </script>


</form>
 </asp:Content>
