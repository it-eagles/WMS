<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RptSumLOTFrm.aspx.vb" Inherits="WMS.RptSumLOTFrm" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Report Sum LOT
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>Report</a></li>     
            <li><a href="RptSumLOT.aspx">Report Sum LOT</a></li>
           
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
                        <h3 class="box-title">Report Sum LOT</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
 
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">From Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerFromDate" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderFromDate" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>
                                  <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">To Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderToDate" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>  
                                 

                                <div class="form-group" >                                    
                                        <div class="col-lg3 col-md-3 col-sm-3">
                                                <label>
                                                   <input type="checkbox" runat="server" id="chkCustomer" />Customer
                                              </label>            
                                           </div>
                                         <div class="col-sm-5">                                            
                                             <asp:DropDownList ID="ddlCustomer" CssClass="form-control" runat="server"></asp:DropDownList>  
                                         </div>
                                 </div> 
                                 
                                 <div class="form-group" >                                    
                                        <div class="col-lg3 col-md-3 col-sm-3">
                                                <label>
                                                   <input type="checkbox" runat="server" id="chkENDCustomer" />END Customer
                                              </label>            
                                           </div>
                                         <div class="col-sm-5">                                            
                                             <asp:DropDownList ID="ddlENDCustomer" CssClass="form-control" runat="server"></asp:DropDownList>  
                                         </div>
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
</form>
 </asp:Content>