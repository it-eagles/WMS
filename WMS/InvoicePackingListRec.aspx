<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InvoicePackingListRec.aspx.vb" Inherits="WMS.InvoicePackingListRec" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Invoice/Packing List Rec
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Receive Process</a></li>
                <li><a href="InvoicePackingListRec.aspx"class="active">Invoice/Packing List Rec</a></li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">


                <!-- left column -->

                <div class="col-md-12">

                    <%--<div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtCustomsDeclaretion" class="col-sm-3 control-label">Declaretion:</label>
                            <label for="txtNoDate" class="col-sm-3 control-label">No Date:</label>
                            <label for="txtInvoiceNo" class="col-sm-3 control-label">Invoice No:</label>
                            <div class="col-sm-3">
                              <label>
                                   <input type="checkbox" runat="server" id="chkPrint" /> RCVD No
                              </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-3">
                                <input class="form-control" id="Text1" runat="server"/>
                            </div>
                            <div class="col-sm-3">
                                <input class="form-control" id="Text2" runat="server"/>
                            </div>
                            <div class="col-sm-3">
                                <input class="form-control" id="Text3" runat="server"/>
                            </div>
                            <div class="col-sm-3">
                                <input class="form-control" id="Text4" runat="server"/>
                            </div>
                        </div>
                        </div>

                        <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtJobNo" class="col-sm-3 control-label">Job No:</label>
                            <label for="txtToDate" class="col-sm-3 control-label">To Date:</label>
                            <label for="txtToDate" class="col-sm-3 control-label">To Date:</label>
                            <label for="txtToDate" class="col-sm-3 control-label">To Date:</label>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-3">
                                <input class="form-control" id="Text5" runat="server"/>
                            </div>
                            <div class="col-sm-3">
                                <input class="form-control" id="Text6" runat="server"/>
                            </div>
                            <div class="col-sm-3">
                                <input class="form-control" id="Text7" runat="server"/>
                            </div>
                            <div class="col-sm-3">
                                <input class="form-control" id="Text8" runat="server"/>
                            </div>
                        </div>
                        </div>--%>

                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">                            
                            <li class="active"><a href="#invoiceheader" data-toggle="tab">Invoice Header</a></li>
                            <li><a href="#truckwaybilldetail" data-toggle="tab">Truck Way Bill Detail</a></li>
                        </ul>

                        <div class="tab-content">
                            <style>
                             h5{height:39px;}                                                                    
                            </style>

                        
                        
                    

                            <%-----------------------------------------------------Start INVOICE HEADER-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="active tab-pane" id="invoiceheader">
                     <!-- Post -->
               <div class="row">
                         <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                    <div class="col-md-6">
          <!-- Horizontal Form -->
          
            <!-- form start -->
            <div class="form-horizontal">
                <fieldset>  <legend>Shipper</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtShipperCode" class="col-sm-4 control-label">Shipper Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlShipperCode_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameShipper_Invoice" class="col-sm-4 control-label">Name English:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameShipper_Invoice" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress1Shipper" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Shipper" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Shipper" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Shipper" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Shipper" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Shipper" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Shipper" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Shipper" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress5Shipper" class="col-sm-4 control-label">Address5:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress5Shipper" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtEmailShipper" class="col-sm-4 control-label">E-mail:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtEmailShipper" runat="server"/>
                  </div>
                </div>
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        
          <!-- /.box -->

          <!-- general form Commodity -->
            <div class="form-horizontal">
                <fieldset><legend>Consignee</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtConsigneeCode_Invoice" class="col-sm-4 control-label">Consignee Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="txtConsigneeCode_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameConsignee_Invoice" class="col-sm-4 control-label">Name English:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameConsignee_Invoice" runat="server" />
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1Consignee" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Consignee" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Consignee" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Consignee" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Consignee" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Consignee" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Consignee" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Consignee" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress5Consignee" class="col-sm-4 control-label">Address5:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress5Consignee" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtEmailConsignee" class="col-sm-4 control-label">E-mail:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtEmailConsignee" runat="server"/>
                  </div>
                </div>         
                  <h5></h5>       
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

            <div class="form-horizontal">
                <fieldset><legend>Transport</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtTruckLicense_Invoice" class="col-sm-4 control-label">Truck License:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlTruckLicense_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtDriverName_Invoice" class="col-sm-4 control-label">Driver Name:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlDriverName_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

        </div>
        <!--/.col (left) -->
                   <%---------------------------------------------------------------End Left Form------------------------------------------------%>



                    <%------------------------------------------------------------Start Right Form------------------------------------------------%>
                    <div class="col-md-6">
          <!-- Horizontal Form -->                      
            <!-- form start -->
                <div class="form-horizontal">
                <fieldset>  <legend>Country</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtOriginCountry" class="col-sm-4 control-label">Origin Country:</label>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlOriginCountry_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtOriginCountry_Invoice" runat="server" disabled="disabled"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtPurchaseCountry" class="col-sm-4 control-label">Purchase Country:</label>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlPurchaseCountry_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPurchaseCountry_Invoice" runat="server" disabled="disabled"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtDestinationCountry" class="col-sm-4 control-label">Destination Country:</label>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlDestinationCountry_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtDestinationCountry_Invoice" runat="server" disabled="disabled"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtTermOfPayment" class="col-sm-4 control-label">Term Of Payment:</label>
                  <div class="col-sm-8">
                    <asp:DropDownList ID="ddlTermOfPayment_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtTerm" class="col-sm-4 control-label">Term:</label>
                  <div class="col-sm-8">
                    <asp:DropDownList ID="ddlTerm_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtTotalNewWeight" class="col-sm-4 control-label">Total New Weight:</label>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtTotalNewWeight_Invoice" runat="server" value="0.0"/>
                  </div>
                  <label for="txtSumItemWeight" class="col-sm-4 control-label">Sum Item Weight:</label>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtSumItemWeight_Invoice" runat="server" value="0.0"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtTotalGrossWeight" class="col-sm-4 control-label">Total Gross Weight:</label>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtTotalGrossWeight_Invoice" runat="server" value="0.0"/>
                  </div>
                  <label for="txtTotalVolume" class="col-sm-4 control-label">Total Volume:</label>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtTotalVolume_Invoice" runat="server" value="0.0"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtTotalQuantityPack" class="col-sm-4 control-label">TotalQuantityPack:</label>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtTotalQuantityPack_Invoice" runat="server" value="0.0"/>
                  </div>
                  <label for="txtTotalQuantityINV" class="col-sm-4 control-label">TotalQuantityINV:</label>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtTotalQuantityINV_Invoice" runat="server" value="0.0"/>
                  </div>
                </div>
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        
          <!-- /.box -->

          <!-- general form Commodity -->
                <div class="form-horizontal">
                <fieldset>  <legend>Currency</legend>
              <div class="box-body">
                <div class="form-group" style="height: 34px;">
                  <label for="txtspace" class="col-sm-4 control-label"></label>
                  <label for="txtCurrency" class="col-sm-3 control-label">Currency:</label>
                  <label for="txtAmount" class="col-sm-2 control-label">Amount:</label>
                  <label for="txtAmount" class="col-sm-2 control-label">Amount:</label>
                </div>
                <div class="form-group">
                  <label for="txtTotalInvoice" class="col-sm-4 control-label">Total Invoice:</label>
                  <div class="col-sm-3">                    
                      <asp:DropDownList ID="ddlTotalInvoice_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtTotalInvoice1_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtTotalInvoice2_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtForwarding" class="col-sm-4 control-label">Forwarding:</label>
                  <div class="col-sm-3">                    
                      <asp:DropDownList ID="ddlForwarding_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtForwarding1_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtForwarding2_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtFreight" class="col-sm-4 control-label">Freight:</label>
                  <div class="col-sm-3">                    
                      <asp:DropDownList ID="ddlFreight_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtFreight1_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtFreight2_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtInsurance" class="col-sm-4 control-label">Insurance:</label>
                  <div class="col-sm-3">                    
                      <asp:DropDownList ID="ddlInsurance_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtInsurance1_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtInsurance2_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtPackingCharge" class="col-sm-4 control-label">Packing Charge:</label>
                  <div class="col-sm-3">                    
                      <asp:DropDownList ID="ddlPackingCharge_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtPackingCharge1_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtPackingCharge2_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtHandingCharge" class="col-sm-4 control-label">Handing Charge:</label>
                  <div class="col-sm-3">                    
                      <asp:DropDownList ID="ddlHandingCharge_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtHandingCharge1_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtHandingCharge2_invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtLandingCharge" class="col-sm-4 control-label">Landing Charge:</label>
                  <div class="col-sm-3">                    
                      <asp:DropDownList ID="ddlLandingCharge_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtLandingCharge1_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtLandingCharge2_Invoice" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtTotalInvoiceTHB" class="col-sm-4 control-label">Total Invoice THB:</label>
                  <div class="col-sm-3">                    
                      <asp:DropDownList ID="ddlTotalInvoiceTHB_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="Text1" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="Text2" runat="server" value="0.0" disabled="disabled"/>
                  </div>
                </div>              
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

            <div class="form-horizontal">
                <fieldset><legend>Transmit</legend>
              <div class="box-body">
                <div class="form-group">
                  <div class="col-sm-5">
                       <div class="radio">
                       <label>                                            
                          <asp:RadioButton runat="server" ID ="rdbDiffAmount" Text="Diff By Item-Amount"  onclick="EnableDisableTextBox();"  GroupName="option2"  />
                       </label>
                       </div>            
                  </div>
                  <label for="txtTransmitDate" class="col-sm-3 control-label">Transmit Date:</label>
                  <div class="col-sm-4">                                            
                     <asp:TextBox CssClass="form-control" ID="txtdatepickerTransmitDate" runat="server" placeholder="DD/MM/YYYY">
                     </asp:TextBox>
                     <asp:CalendarExtender ID="CalendarExtenderTransmitDate" runat="server" Enabled="True" TargetControlID="txtdatepickerTransmitDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-5">
                       <div class="radio">
                       <label>                                            
                          <asp:RadioButton runat="server" ID ="rdbDiffWeight" Text="Diff By Item-Weight"  onclick="EnableDisableTextBox();"  GroupName="option2"  />
                       </label>
                       </div>            
                  </div>
                  <div class="col-sm-3">
                       <div class="radio">
                       <label>                                            
                          <asp:RadioButton runat="server" ID ="rdbNotifyParty" Text="Notify Party"  onclick="EnableDisableTextBox();"  GroupName="option3"  />
                       </label>
                       </div>            
                  </div>
                  <div class="col-sm-3">
                       <div class="radio">
                       <label>                                            
                          <asp:RadioButton runat="server" ID ="rdbOnBehalfOf" Text="On Behalf Of"  onclick="EnableDisableTextBox();"  GroupName="option3"  />
                       </label>
                       </div>            
                  </div>
                </div>
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>
                    

        </div>
         <!-- right column -->

                   <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>
                </div>
     <!-- /.post -->
       </div>
 <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End INVOICE HEADER-------------------------------------------------------%>



                            <%--------------------------------------------------------------Start TRUCK WAY BILL DETAIL----------------------------------------------------------%>
       <!-------- Export Goods --------->
     <div class="tab-pane" id="truckwaybilldetail">
                                <!-- Post -->
        <div class="row">

            <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->                        
                                               <div class="form-horizontal">
                                                   <fieldset>  <legend>Invoice</legend>
                                                      <div class="box-body">   
                                                          <div class="col-md-11 col-sm-11"> 
                                                              <div class="form-group">
                                                                  <label for="txtInvoiceNo" class="col-sm-2 control-label">Invoice No:</label>                                       
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList ID="txtInvoiceNo" CssClass="form-control" runat="server"></asp:DropDownList>                                                                    
                                                                </div>
                                                                  <label for="txtLOTNo" class="col-sm-2 control-label">LOT No:</label>                                      
                                                                 <div class="col-sm-4">
                                                                    <input class="form-control" id="txtLOTNo" runat="server"/>
                                                                 </div>
                                                                  
                                                                  </div>
                                                                <div class="form-group">
                                                                <label for="txtPartDesc" class="col-sm-2 control-label">Part Desc:</label>                                       
                                                                <div class="col-sm-4">
                                                                    <input class="form-control" id="txtPartDesc" runat="server"/>
                                                                </div>
                                                                <label for="txtMeasurement" class="col-sm-2 control-label">Measurement:</label>                                       
                                                                <div class="col-sm-4">
                                                                    <input class="form-control" id="txtMeasurement_Detail" runat="server"/>
                                                                </div>                                                                
                                                                  </div>                                                              

                                                              <div class="form-group">
                                                                  <label for="txtOwnP/N" class="col-sm-2 control-label">Own P/N:</label>                                       
                                                                <div class="col-sm-4">
                                                                    <input class="form-control" id="txtOwnP_N" runat="server"/>
                                                                </div>
                                                                  <label for="txtCustomerP/N" class="col-sm-2 control-label">CustomerP/N:</label>                                       
                                                                <div class="col-sm-4">
                                                                    <input class="form-control" id="txtCustomerP_N" runat="server"/>
                                                                </div>                                                                  
                                                              </div>

                                                              <div class="form-group">
                                                                <label for="txtQuantity_Detail" class="col-sm-2 control-label">Quantity:</label>                                       
                                                                <div class="col-sm-4">
                                                                    <input class="form-control" id="txtQuantity_Detail" runat="server"/>
                                                                </div>
                                                                <label for="txtUnitQuantity_Detail" class="col-sm-2 control-label">Unit:</label>                                       
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList ID="ddlUnitQuantity_Detail" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>                                                                
                                                              </div>

                                                              <div class="form-group">
                                                                   <label for="txtGrossWeight" class="col-sm-2 control-label">Gross Weight:</label>                                      
                                                                 <div class="col-sm-4">
                                                                    <input class="form-control" id="txtGrossWeight_Detail" runat="server"/>
                                                                 </div>
                                                                  <label for="txtUnit_GrossWeight" class="col-sm-2 control-label">Unit:</label>                                      
                                                                 <div class="col-sm-4">
                                                                     <asp:DropDownList ID="ddlUnit_GrossWeight" CssClass="form-control" runat="server"></asp:DropDownList> 
                                                                 </div>                                                
                                                              </div>
                                                              
                                                              <div class="form-group">
                                                                  <label for="txtCountryOfOrigin" class="col-sm-2 control-label">Country Of Origin:</label> 
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList ID="ddlCountryOfOrigin" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                 </div>
                                                                  
                                                              </div>
                                                          </div>
                                                              
                                                              <div class="form-group">
                                                                <div class="col-sm-12 col-sm-offset-4">                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnSaveNew_Detail" title="btnSaveNew_Detail" >Save New</button>
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnSaveModify_Detail" title="btnSaveModify_Detail" >Save Modify</button> 
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnDelete_Detail" title="btnDelete_Detail" >Delete</button>
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnCencel_Detail" title="btnCencel_Detail" >Cencel</button>
                                                                </div>                                                                           
                                                              </div>
                                                                                                                                                                                                   
                                    <!-- /.box-body -->
                             </div>
                            <!-- /.box-header -->
                           </fieldset>
                       </div>
          <!--/.col-lg-6 col-md-6 stockqty--->
               
                    </div>

                    <!-- /.col -->

                </div>
              <!-- /.post -->
           </div>
            <!-----/ Export Goods----->

              <%--------------------------------------------------------------END TRUCK WAY BILL DETAIL----------------------------------------------------------%>


               




                        </div>
                        <!-- /.tab-pane -->
                    </div>
                    <!-- /.tab-pane -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </section>
        <!-- /.content -->
        
    </form>
</asp:Content>