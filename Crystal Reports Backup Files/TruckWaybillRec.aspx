<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TruckWaybillRec.aspx.vb" Inherits="WMS.TruckWaybillRec" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Truck Way Bill
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Receive Process</a></li>
                <li><a href="TruckWaybillRec.aspx"class="active">Truck Way Bill</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->

                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">                            
                            <li class="active"><a href="#truckwaybillhead" data-toggle="tab">Truck Way Bill Head</a></li>
                            <li><a href="#truckwaybilldetail" data-toggle="tab">Truck Way Bill Detail</a></li>
                        </ul>

                        <div class="tab-content">
                            <style>
                             h5{height:39px;}                                                                    
                            </style>

                            <%-----------------------------------------------------Start TRUCK WAY BILL HEAD-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="active tab-pane" id="truckwaybillhead">
                     <!-- Post -->
               <div class="row">
                         <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                    <div class="col-md-6">
          <!-- Horizontal Form -->
          
            <!-- form start -->
            <div class="form-horizontal">
                <fieldset>  <legend>Truck W/B</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtTruckW/B" class="col-sm-4 control-label">TruckW/B:</label>
                  <div class="col-sm-8">                    
                      <input class="form-control" id="txtTruckW_B" runat="server"/>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNoOfOriginals" class="col-sm-4 control-label">No Of Originals:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNoOfOriginals" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtDeliveryOfGoods" class="col-sm-4 control-label">Delivery Of Goods:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtDeliveryOfGoods" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtDriverName" class="col-sm-4 control-label">Driver Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtDriverName" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtPrepaid" class="col-sm-4 control-label">Prepaid:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtPrepaid" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtGrossWeight" class="col-sm-4 control-label">Gross Weight:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtGrossWeight" runat="server" value="0.0"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtNotifyPartyCode" class="col-sm-4 control-label">Notify Party Code:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNotifyPartyCode" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtNotifyPartyName" class="col-sm-4 control-label">Notify Party Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNotifyPartyName" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNotifyPartyAddress" class="col-sm-4 control-label">Notify Party Address:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNotifyPartyAddress" runat="server"/>
                  </div>
                </div>
                <%--<div class="form-group">
                  <label for="txtPlaceOfReceipt" class="col-sm-4 control-label">Place Of Receipt:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtPlaceOfReceipt" runat="server"/>
                  </div>
                </div>--%>
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        
          <!-- /.box -->

          <!-- general form Commodity -->
            <div class="form-horizontal">
                <fieldset><legend>Shipper</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtShipperCode" class="col-sm-4 control-label">Shipper Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlShipperCode" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameShipper" class="col-sm-4 control-label">Name(Eng):</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameShipper" runat="server"  placeholder="Name(Eng)"/>
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

        </div>
        <!--/.col (left) -->
                   <%---------------------------------------------------------------End Left Form------------------------------------------------%>



                    <%------------------------------------------------------------Start Right Form------------------------------------------------%>
                    <div class="col-md-6">
          <!-- Horizontal Form -->                      
            <!-- form start -->
                <div class="form-horizontal">
                <fieldset>  <legend>Truck W/B</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtReceivedDate" class="col-sm-4 control-label">Received Date:</label>
                  <div class="col-sm-8">                                            
                      <asp:TextBox CssClass="form-control" ID="txtdatepickerReceivedDate" runat="server" placeholder="DD/MM/YYYY">
                      </asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtenderReceivedDate" runat="server" Enabled="True" TargetControlID="txtdatepickerReceivedDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtDateOfIssue" class="col-sm-4 control-label">Date Of Issue:</label>
                  <div class="col-sm-8">                                            
                      <asp:TextBox CssClass="form-control" ID="txtdatepickerDateOfIssue" runat="server" placeholder="DD/MM/YYYY">
                      </asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtenderDateOfIssue" runat="server" Enabled="True" TargetControlID="txtdatepickerDateOfIssue" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNotifyParty" class="col-sm-4 control-label">Notify Party:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNotifyParty" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtCarLicense" class="col-sm-4 control-label">Car License:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtCarLicense" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtFreightCharges" class="col-sm-4 control-label">Freight Charges:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtFreightCharges" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtQuantityAmount" class="col-sm-4 control-label">Quantity Amount:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtQuantityAmount" runat="server" value="0.0"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtMeasurement" class="col-sm-4 control-label">Measurement:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtMeasurement" runat="server" value="0.0"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtPlaceOfReceipt" class="col-sm-4 control-label">Place Of Receipt:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtPlaceOfReceipt" runat="server"/>
                  </div>
                </div>
                  <h5></h5>
                 
                  
                
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
                  <label for="txtConsigneeCode" class="col-sm-4 control-label">Consignee Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="txtConsigneeCode" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameConsignee" class="col-sm-4 control-label">Name(Eng):</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameConsignee" runat="server"  placeholder="Name(Eng)"/>
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
                            <%-------------------------------------------------------------End TRUCK WAY BILL HEAD-------------------------------------------------------%>



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
