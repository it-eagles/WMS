<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RptLogFrm.aspx.vb" Inherits="WMS.RptLogFrm" MasterPageFile="~/Home.Master"  %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Report Log
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>Report</a></li>     
            <li><a href="RptLog.aspx">Report Log</a></li>
           
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
                        <h3 class="box-title">Report Log</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
                                <div class="form-group" >                                    
                                        <label for="txtSelect" class="col-sm-3 control-label">Select Import/Export:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:DropDownList ID="ddlSelectImEx" CssClass="form-control" runat="server">
                                                 <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>LogExpGenLOT</asp:ListItem>
                                                    <asp:ListItem>LogInvoice</asp:ListItem>
                                                    <asp:ListItem>LogInvoiceDetail</asp:ListItem>
                                                    <asp:ListItem>LogPackingList</asp:ListItem>
                                                    <asp:ListItem>LogImpGenLOT</asp:ListItem>
                                                    <asp:ListItem>LogImpInvoice</asp:ListItem>
                                                    <asp:ListItem>LogImpInvoiceDetail</asp:ListItem>
                                                    <asp:ListItem>LogImpPackingList</asp:ListItem>
                                                    <asp:ListItem>LogBrand</asp:ListItem>
                                                    <asp:ListItem>LogCarLicense</asp:ListItem>
                                                    <asp:ListItem>LogConsignnee</asp:ListItem>
                                                    <asp:ListItem>LogCountry</asp:ListItem>
                                                    <asp:ListItem>LogCurrency</asp:ListItem>
                                                    <asp:ListItem>LogDeliveryTerm</asp:ListItem>
                                                    <asp:ListItem>LogDriver</asp:ListItem>
                                                    <asp:ListItem>LogProductDetail</asp:ListItem>
                                                    <asp:ListItem>LogProductUnit</asp:ListItem>
                                                    <asp:ListItem>LogProvince</asp:ListItem>
                                                    <asp:ListItem>LogTruckManifest</asp:ListItem>
                                                    <asp:ListItem>LogTruckManifestDetail</asp:ListItem>
                                                    <asp:ListItem>LogTruckOwner</asp:ListItem>
                                                    <asp:ListItem>LogTruckType</asp:ListItem>
                                                    <asp:ListItem>LogReferenceType</asp:ListItem>
                                                    <asp:ListItem>LogShipper</asp:ListItem>
                                                    <asp:ListItem>LogShippingMark</asp:ListItem>
                                                    <asp:ListItem>LogtransprotationMode</asp:ListItem>
                                                    <asp:ListItem>LogTruckWayBill</asp:ListItem>
                                                    <asp:ListItem>LogTruckWayBillDetail</asp:ListItem>
                                                    <asp:ListItem>LogUser</asp:ListItem>
                                                    <asp:ListItem>LogWarehouseType</asp:ListItem>
                                             </asp:DropDownList>  
                                         </div>
                                 </div> 
                                 <div class="form-group">
                                                <div class="col-sm-3"></div>
                                                <div class="col-lg3 col-md-3 col-sm-3">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbByDate" Text="By Date"  onclick="EnableDisableTextBox();"  GroupName="option1" />
                                              </label>
                                               </div>            
                                           </div>
                                
                                                <div class="col-lg3 col-md-3 col-sm-3">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbByInvoice" Text="By Invoice" onclick="EnableDisableTextBox();" GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>     
                                         
                                </div>   
                                 
                                <div class="form-group">
                                <fieldset id="FieldsetByDate" runat="server">  <legend>By Date</legend>              
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
                                <fieldset id="FieldsetByInvoice" runat="server">  <legend>By Invoice</legend>              
                                <div class="form-group" >                                    
                                        <label for="txtInvoiceNo" class="col-sm-3 control-label">Invoice No:</label>
                                         <div class="col-sm-5">     
                                             <input class="form-control" id="txtInvoiceNo" runat="server"/>                                       
                                         </div>
                                 </div>
                                 </fieldset>
                                 </div>    
                                                       
                                 <div class="form-group" >   
                                        <div class="col-sm-5"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnPrint" title="btnPrint" onserverclick="btnPrint_ServerClick">Print</button>
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnClear" title="btnClear" onserverclick="btnClear_ServerClick">Clear</button>
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
              var statusbydate = document.getElementById('<%=rdbByDate.ClientID%>').checked;
              var statusbyinvoice = document.getElementById('<%=rdbByInvoice.ClientID%>').checked;
             
              if (statusbydate == true) {
                document.getElementById('<%=FieldsetByDate.ClientID%>').disabled = false;
                document.getElementById('<%=FieldsetByInvoice.ClientID%>').disabled = true;
              } else if (statusbyinvoice == true) {
                document.getElementById('<%=FieldsetByDate.ClientID%>').disabled = true;
                document.getElementById('<%=FieldsetByInvoice.ClientID%>').disabled = false;
            }
             
        }
    </script>

</form>
 </asp:Content>