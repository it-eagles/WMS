<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HTITrackingRec.aspx.vb" Inherits="WMS.HTITrackingRec" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
<!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            HTI Tracking
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i> Home</a></li>
             <li><a class="active"><i class="fa fa-file"></i>Receive Process</a></li>
            <li><a href="HTITracking.aspx">HTI Tracking</a></li>
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">

      <div class="row">
            <!-- left column -->

             <div class="col-lg-12 col-xs-12">

                        <div class="box">
                            <!-- /.box-header -->
                            <div class="box-body">
                                <div class="form-horizontal">
                           <div class="box-body">   
                                <div class="form-group" >
                                        <label for="txtToDate" class="col-sm-3 control-label">To Date:</label>
                                         <div class="col-sm-6">                                            
                                            <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate" runat="server" placeholder="DD/MM/YYYY">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtenderToDate" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>
                                    </div>    
                                          
                                    <div class="form-group" >
                                        <label for="txtFromDate" class="col-sm-3 control-label">From Date:</label>
                                         <div class="col-sm-6">                                            
                                            <asp:TextBox CssClass="form-control" ID="txtdatepickerFromDate" runat="server" placeholder="DD/MM/YYYY">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtenderFromDate" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </div>
                                    </div>
                                    
                                 <div class="text-right">
                                   <div class="text-center">
                                    <button type="submit" runat="server" class="btn btn-primary" id="btnPrint" title="btnPrint" onserverclick="btnPrint_ServerClick">Print</button>
                                    <button type="submit" runat="server" class="btn btn-primary" id="btnClose" title="btnClose" onserverclick="btnClose_ServerClick">Close</button>
                                   </div>
                                 </div>
                                    <!-- /.box-body -->
                             </div>
                          
                       </div>               

                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                     
          </div>
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
</form>
 </asp:Content>