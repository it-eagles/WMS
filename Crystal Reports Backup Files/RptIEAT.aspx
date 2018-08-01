<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RptIEAT.aspx.vb" Inherits="WMS.RptIEAT" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Report IEAT
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>Report</a></li>     
            <li><a href="RptIEAT.aspx">Report IEAT</a></li>
           
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
                        <h3 class="box-title">Report IEAT</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
                                <div class="form-group" >                                    
                                        <label for="txtSelect" class="col-sm-3 control-label">Select Import/Export:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:DropDownList ID="ddlSelectImEx" CssClass="form-control" runat="server"></asp:DropDownList>  
                                         </div>
                                 </div> 
                                 <div class="form-group">
                                                <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbByDate" Text="By Date"  onclick="EnableDisableTextBox();"  GroupName="option1" />
                                              </label>
                                               </div>            
                                           </div>
                                
                                                <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbByIEATNo" Text="By IEAT No" onclick="EnableDisableTextBox();" GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>     

                                                <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="RdbByIEATPermit" Text="By IEAT Permit"  onclick="EnableDisableTextBox();"  GroupName="option1"  />
                                              </label>
                                               </div>            
                                           </div>                                 
                                </div>   
                                 
                                <div class="form-group">
                                <fieldset>  <legend>By Date</legend>              
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">Date Start:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerDate" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderDate" runat="server" Enabled="True" TargetControlID="txtdatepickerDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>
                                  <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">Date Stop:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderToDate" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>  
                                 </fieldset>
                                 </div> 
                                     
                                 <div class="form-group">
                                <fieldset>  <legend>By IEAT No</legend>              
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">IEAT No:</label>
                                         <div class="col-sm-5">     
                                             <input class="form-control" id="txtIEATNo" runat="server"/>                                       
                                         </div>
                                 </div>
                                 </fieldset>
                                 </div>    
                                 
                                <div class="form-group">
                                <fieldset>  <legend>By IEAT Permit</legend>              
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">IEAT Permit:</label>
                                         <div class="col-sm-5">     
                                             <input class="form-control" id="txtIEATPermit" runat="server"/>                                       
                                         </div>
                                 </div>
                                 </fieldset>
                                 </div>   
                                                       
                                 <div class="form-group" >   
                                        <div class="col-sm-5"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnPrint" title="btnPrint" onserverclick="btnPrint_ServerClick">Print</button>
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnClose" title="btnClose" onserverclick="btnClose_ServerClick">Close</button>
                                 </div>



                                     <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                                     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>--%>


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
              var status = document.getElementById('<%=rdbByDate.ClientID%>').checked;
             
              if (status == true) {
                <%--document.getElementById('<%=txtWidth.ClientID%>').disabled = true;
                document.getElementById('<%=txtLong.ClientID%>').disabled = true;
                document.getElementById('<%=txtHeigth.ClientID%>').disabled = true;
                document.getElementById('<%=txtValume.ClientID%>').disabled = true;
                document.getElementById('<%=txtUsedStatus.ClientID%>').disabled = true;        
                document.getElementById('<%=txtQTYPallet.ClientID%>').disabled = false;  --%>
            } else if (status == false){
               <%-- document.getElementById('<%=txtWidth.ClientID%>').disabled = false;
                document.getElementById('<%=txtLong.ClientID%>').disabled = false;
                document.getElementById('<%=txtHeigth.ClientID%>').disabled = false;
                document.getElementById('<%=txtValume.ClientID%>').disabled = false;
                document.getElementById('<%=txtUsedStatus.ClientID%>').disabled = false;
                document.getElementById('<%=txtQTYPallet.ClientID%>').disabled = true; --%> 
               
            }
             
        }
    </script>

</form>
 </asp:Content>