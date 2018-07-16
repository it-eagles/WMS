<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SingleIssuedWH.aspx.vb" Inherits="WMS.SingleIssuedWH" MasterPageFile="~/Home.Master" %>
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
                <li><a class="active"><i class="fa fa-file"></i>WareHouse</a></li>
                <li><a href="SingleIssuedWH.aspx"class="active">Single Issued</a></li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <style>
                             h5{height:39px;}                                
                             h3{height:27px;} 
                             h4{height:76px;}
                             h1{height:34px;}                                                                                                                    
                            </style>
            <div class="row">


                <!-- left column -->

                <div class="col-md-12">
                    <%-------------------------------------------------Start Before Custom Tab---------------------------------------------------%>
                    <div class="col-md-12">
                        <h2></h2>                        
                    <div class="col-sm-6">
                        <div class="form-horizontal">
                        <div class="form-group">
                            <label for="txtPullSignal" class="col-sm-3 control-label">Pull Signal:</label>
                            <div class="col-sm-3">
                                <input class="form-control" id="txtPullSignal_BeforeTab" runat="server"/>
                            </div>
                            <label for="txtJobNo" class="col-sm-3 control-label">Job No:</label>
                            <div class="col-sm-3">
                                <input class="form-control" id="txtJobNo_BeforeTab" runat="server"/>
                            </div>
                        </div>
                        <div class="form-group">     
                            <div class="col-sm-2">
                              <label>
                                <input type="checkbox" runat="server" id="chkScrap" />SCRAP
                              </label>
                            </div>
                            <label for="txtPullDateTime" class="col-sm-3 control-label">Pull Date/Time:</label>                       
                            <div class="col-sm-4">                                            
                                 <asp:TextBox CssClass="form-control" ID="txtdatepickertxtPullDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                 </asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtenderPullDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickertxtPullDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>
                            
                            <div class="col-sm-3">                    
                                      <div class="bootstrap-timepicker">
                                  <div class="input-group">
                                    <input type="text" class="form-control timepicker" id="txtTimePickUpPullDateTime"/>
                                  <div class="input-group-addon">
                                      <i class="fa fa-clock-o"></i>
                                    </div>
                                  </div>
                                  <!-- /.input group -->
                              </div>
                            </div>
                      </div>
                        </div>
                     </div>

                        <div class="col-sm-6">
                        <div class="form-horizontal">
                        <div class="form-group">     
                            <label for="txtDeliveryDateTime" class="col-sm-4 control-label">Delivery Date/Time:</label>                       
                            <div class="col-sm-4">                                            
                                 <asp:TextBox CssClass="form-control" ID="txtdatepickerDeliveryDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                 </asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtenderDeliveryDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerDeliveryDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>
                            
                            <div class="col-sm-4">                    
                                      <div class="bootstrap-timepicker">
                                  <div class="input-group">
                                    <input type="text" class="form-control timepicker" id="txtTimePickUpDeliveryDateTime"/>
                                  <div class="input-group-addon">
                                      <i class="fa fa-clock-o"></i>
                                    </div>
                                  </div>
                                  <!-- /.input group -->
                              </div>
                            </div>
                      </div>
                       <div class="form-group">     
                            <label for="txtConfirmDateTime" class="col-sm-4 control-label">Delivery Date/Time:</label>                       
                            <div class="col-sm-4">                                            
                                 <asp:TextBox CssClass="form-control" ID="txtdatepickerComfirmDateTime_beforeTab" runat="server" placeholder="DD/MM/YYYY">
                                 </asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtenderComfirmDateTime_beforeTab" runat="server" Enabled="True" TargetControlID="txtdatepickerComfirmDateTime_beforeTab" Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>
                            
                            <div class="col-sm-4">                    
                                      <div class="bootstrap-timepicker">
                                  <div class="input-group">
                                    <input type="text" class="form-control timepicker" id="txtTimePickUpConfirmDateTime"/>
                                  <div class="input-group-addon">
                                      <i class="fa fa-clock-o"></i>
                                    </div>
                                  </div>
                                  <!-- /.input group -->
                              </div>
                            </div>
                      </div>
                        </div>                  
                        </div>
                        <%--<h3></h3>
                        <h3></h3>--%>
                            
                        </div>
                               <%------------------------------------------------End Before Custom Tab---------------------------------------------------%>

                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">                            
                            <li class="active"><a href="#issuecondition" data-toggle="tab">Issue Condition</a></li>
                            <li><a href="#confirmissue" data-toggle="tab">Confirm Issue</a></li>                            
                        </ul>

                        <div class="tab-content">
                            

                        
                        
                    

                            <%-----------------------------------------------------Start Issue Condition-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="active tab-pane" id="issuecondition">
                     <!-- Post -->
               <div class="row">
                        <%-----------------------------------------------------Start JOB Form-----------------------------------------------------------%>
                   <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->                        
                                               <div class="form-horizontal">
                                                   <fieldset>  <legend>Job</legend>
                                                      <div class="box-body">   
                                                          <div class="col-md-4 col-sm-4"> 
                                                              <div class="form-group">                                                                  
                                                                  <label for="txtJobNo_IssueCon" class="col-sm-4 control-label">Job No:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlJobNo_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>   
                                                              <div class="form-group">
                                                                  <div class="col-sm-4">  
                                                                  </div> 
                                                                  <div class="col-sm-8">
                                                                     <label>
                                                                         <input type="checkbox" runat="server" id="chkMoveTo" />Move to
                                                                     </label>
                                                                  </div>                                                                  
                                                                  </div>                                                               
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtCustRefNo_IssueCon" class="col-sm-4 control-label">Cust REF No:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustRefNo_IssueCon" runat="server"/>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">      
                                                                  <div class="col-sm-4">  
                                                                  </div>         
                                                                  <div class="col-sm-8">
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnRejectMoveTo_IssueCon" title="btnRejectMoveTo_IssueCon" onserverclick="btnRejectMoveTo_IssueCon_ServerClick">Reject MoveTo</button>
                                                                  </div>
                                                              </div>
                                                                                                                               
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                   <label for="txtWHSite_IssueCon" class="col-sm-4 control-label">WH/Site:</label>                                       
                                                                <div class="col-sm-8">
                                                                <asp:DropDownList ID="ddlWHSite_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                                                                </div>
                                                                  </div>                                                                   
                                                          </div>
                                                           
                                                                                                                                            
                                    <!-- /.box-body -->
                             </div>
                            <!-- /.box-header -->
                           </fieldset>
                       </div>
          <!--/.col-lg-6 col-md-6 stockqty--->
               
                    </div>
                         <%-------------------------------------------------------End JOB Form----------------------------------------------------------------%>

                         <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                    <div class="col-md-6">
          <!-- Horizontal Form -->
          
            <!-- form start -->
          <!-- general form Commodity -->
            <div class="form-horizontal">
                <fieldset><legend>Exporter</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtExporterCode_IssueCon" class="col-sm-4 control-label">Exporter Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlExporterCode_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameExporter_IssueCon" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameExporter_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1Exporter_IssueCon" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Exporter_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Exporter_IssueCon" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Exporter_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Exporter_IssueCon" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Exporter_IssueCon" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Exporter_IssueCon" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Exporter_IssueCon" runat="server"/>
                  </div>
                </div>                
            </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

                 <div class="form-horizontal">
                <fieldset><legend>Owner</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtOwnerCode_IssueCon" class="col-sm-4 control-label">Owner Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlOwnerCode_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameOwner_IssueCon" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameOwner_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1Owner_IssueCon" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Owner_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Owner_IssueCon" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Owner_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Owner_IssueCon" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Owner_IssueCon" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Owner_IssueCon" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Owner_IssueCon" runat="server"/>
                  </div>
                </div>                
            </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>      

            <div class="form-horizontal">
                <fieldset><legend>Summer Detail</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtCommodity_IssueCon" class="col-sm-4 control-label">Commodity:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlCommodity_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantityPackage_IssueCon" class="col-sm-5 control-label">Quantity Package:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQuantityPackage_IssueCon" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuantityPackage_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantityPLTSkid_IssueCon" class="col-sm-5 control-label">Quantity PLT/Skid:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQuantityPLTSkid_IssueCon" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuantityPLTSkid_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>                
                <div class="form-group">
                  <label for="txtQuantityPicked_IssueCon" class="col-sm-5 control-label">Quantity Picked:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txttxtQuantityPicked_IssueCon" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuantityPicked_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtRemark_IssueCon" class="col-sm-4 control-label">Remark:</label>
                  <div class="col-sm-8">
                    <textarea class="form-control" rows="3" id="txtRamark_IssueCon" placeholder="Remark" style="height: 71px; width: 872px;"></textarea>
                  </div>
                </div>
                 <div class="form-group">      
                  <div class="col-sm-4">  
                  </div>         
                  <div class="col-sm-8">
                    <button type="submit" runat="server" class="btn btn-primary" id="btnSumQTY_IssueCon" title="btnSumQTY_IssueCon" onserverclick="btnSumQTY_IssueCon_ServerClick">Sum QTY</button>
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
          <!-- general form Commodity -->
            <div class="form-horizontal">
                <fieldset><legend>Consignee</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtConsigneeCode_IssueCon" class="col-sm-4 control-label">Consignee Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="txtConsigneeCode_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameConsignee_IssueCon" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameConsignee_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1Consignee_IssueCon" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Consignee_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Consignee_IssueCon" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Consignee_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Consignee_IssueCon" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Consignee_IssueCon" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Consignee_IssueCon" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Consignee_IssueCon" runat="server"/>
                  </div>
                </div>                                 
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        

                <div class="form-horizontal">
                <fieldset><legend>Ship To</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtShipToCode_IssueCon" class="col-sm-4 control-label">Ship To Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlShipToCode_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameShipTo_IssueCon" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameShipTo_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1ShipTo_IssueCon" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1ShipTo_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2ShipTo_IssueCon" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2ShipTo_IssueCon" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3ShipTo_IssueCon" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3ShipTo_IssueCon" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4ShipTo_IssueCon" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4ShipTo_IssueCon" runat="server"/>
                  </div>
                </div>                
            </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

            <div class="form-horizontal">
                <fieldset><legend>Summer Detail</legend>
              <div class="box-body">
              <div class="form-group">
                <label for="txtQuantityOfGood_IssueCon" class="col-sm-5 control-label">Quantity Of Goods:</label>
                <div class="col-sm-3">
                  <input class="form-control" id="txtQuantityOfGood_IssueCon" runat="server" value="0.0"/>
                </div>
                <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlQuantityOfGood_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                </div>
              </div>
                <div class="form-group">
                  <label for="txtWeight_IssueCon" class="col-sm-5 control-label">Weight:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtWeight_IssueCon" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlWeight_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtVolume_IssueCon" class="col-sm-5 control-label">Volume:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtVolume_IssueCon" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>                
                <div class="form-group">
                  <label for="txtQTYDiscrepancy_IssueCon" class="col-sm-5 control-label">QTY Discrepancy:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQTYDiscrepancy_IssueCon" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQTYDiscrepancy_IssueCon" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>   
                  <h4></h4> 
                 <div class="form-group">      
                  <div class="col-sm-4">  
                  </div>         
                  <div class="col-sm-4">
                    <button type="submit" runat="server" class="btn btn-primary" id="btnConfirmIssued_IssueCon" title="btnConfirmIssued_IssueCon" onserverclick="btnConfirmIssued_IssueCon_ServerClick">Confirm Issued</button>
                  </div>
                  <div class="col-sm-4">
                    <button type="submit" runat="server" class="btn btn-primary" id="btnRejectConfirm_IssueCon" title="btnRejectConfirm_IssueCon" onserverclick="btnRejectConfirm_IssueCon_ServerClick">Reject Confirm</button>
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
                            <%-------------------------------------------------------------End Issue Condition-------------------------------------------------------%>



                           <%--------------------------------------------------------------Start Confirm Issue----------------------------------------------------------%>
       <!-------- Export Goods --------->
     <div class="tab-pane" id="confirmissue">
                                <!-- Post -->
        <div class="row">

            <%-----------------------------------------------------Start HEAD BEFORE LEFT FORM-----------------------------------------------------------%>
                   <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->                        
                                               <div class="form-horizontal">
                                                   <%--<fieldset>  <legend>Job</legend>--%>
                                                      <div class="box-body">   
                                                          <div class="col-md-4 col-sm-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtWHSite_ConfirmIssue" class="col-sm-4 control-label">WH Site:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlWHSite_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtCusLOTNo_ConfirmIssue" class="col-sm-4 control-label">Cus LOT No:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtCusLOTNo_ConfirmIssue" runat="server"/>
                                                                </div>
                                                                  </div>   
                                                              <div class="form-group">
                                                                  <label for="txtEASPN_ConfirmIssue" class="col-sm-4 control-label">EAS P/N:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlEASPN_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtProductDesc_ConfirmIssue" class="col-sm-4 control-label">Product Desc:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                   <textarea class="form-control" rows="3" id="txtRamark_ConGoodRec55554" placeholder="Desc .."style="height: 34px; width: 552px;" ></textarea>
                                                                </div>
                                                                  </div>                                                                                                                             
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                   <label for="txtWHLocation_ConfirmIssue" class="col-sm-4 control-label">WH Location:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlWHLocation_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                   <label for="txtCustWHFac_ConfirmIssue" class="col-sm-4 control-label">Cust W/H Fac:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlCustWHFac_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>  
                                                              <div class="form-group">
                                                                   <label for="txtCustomerPN_ConfirmIssue" class="col-sm-4 control-label">CustomerP/N:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtCustomerPN_ConfirmIssue" runat="server"/>
                                                                </div>
                                                                  </div>                                                             
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtENDCustomer_ConfirmIssue" class="col-sm-4 control-label">ENDCustomer:</label>
                                                                 <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlENDCustomer_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtItemNo_ConfirmIssue" class="col-sm-4 control-label">Item No:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtItemNo_ConfirmIssue" runat="server"/>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtOwnerPN_ConfirmIssue" class="col-sm-4 control-label">Owner P/N:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtOwnerPN_ConfirmIssue" runat="server"/>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtMeasurement_ConfirmIssue" class="col-sm-4 control-label">Measurement:</label>
                                                                 <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlMeasurement_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>                                                       
                                                          </div>
                                                           
                                                                                                                                            
                                    <!-- /.box-body -->
                             </div>
                            <!-- /.box-header -->
                           <%--</fieldset>--%>
                       </div>
          <!--/.col-lg-6 col-md-6 stockqty--->
               
                    </div>
                         <%-------------------------------------------------------End HEAD BEFORE LEFT FORM----------------------------------------------------------------%>

                         <%-----------------------------------------------------Start Left Form--------------------------------------------------%>
                    <div class="col-md-6">
          <!-- Horizontal Form -->
          
            <!-- form start -->
          <!-- general form Commodity -->
            <div class="form-horizontal">
                <%--<fieldset><legend>Owner</legend>--%>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtSpace_ConfirmIssue" class="col-sm-4 control-label"></label>
                  <label for="txtWidth_ConfirmIssue" class="col-sm-4 control-label">Width:</label>
                  <label for="txtHight_ConfirmIssue" class="col-sm-4 control-label">Hight:</label>
                </div>
                <div class="form-group">
                  <label for="txtDimension_ConfirmIssue" class="col-sm-4 control-label">Dimension:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtWidth_ConfirmIssue" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtHight_ConfirmIssue" runat="server" value="0"/>   
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtOrderNo_ConfirmIssue" class="col-sm-4 control-label">Order No:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtOrderNo_ConfirmIssue" runat="server"/>
                  </div>                  
                </div>
                <div class="form-group">
                  <label for="txtReceiveNo_ConfirmIssue" class="col-sm-4 control-label">Receive No:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtReceiveNo_ConfirmIssue" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                      <label>
                           <input type="checkbox" runat="server" id="chkNotUseDate_ConfirmIssue" />Not Use Date
                      </label>
                  </div>
                  <label for="txtManufacturing_ConfirmIssue" class="col-sm-4 control-label">Manufacturing:</label>
                  <div class="col-sm-4">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerManufacturing_ConfirmIssue" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderManufacturing_ConfirmIssue" runat="server" Enabled="True" TargetControlID="txtdatepickerManufacturing_ConfirmIssue" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtReceiveDate_ConfirmIssue" class="col-sm-4 control-label">Receive Date:</label>
                  <div class="col-sm-8">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerReceiveDate_ConfirmIssue" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderReceiveDate_ConfirmIssue" runat="server" Enabled="True" TargetControlID="txtdatepickerReceiveDate_ConfirmIssue" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantity_ConfirmIssue" class="col-sm-4 control-label">Quantity:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtQuantity_ConfirmIssue" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlQuantity_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtCurrency_ConfirmIssue" class="col-sm-4 control-label">Currency:</label>
                  <label for="txtPriceForeign_ConfirmIssue" class="col-sm-4 control-label">Price Foreign:</label>
                  <label for="txtPriceBath_ConfirmIssue" class="col-sm-4 control-label">Price Bath:</label>
                </div>
                <div class="form-group">     
                  <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlCurrency_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>             
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPriceForeign_ConfirmIssue" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPriceBath_ConfirmIssue" runat="server" value="0"/>
                  </div>                  
                </div>                                
            </div>
              <!-- /.box-body -->
                    <%--</fieldset>--%>
            </div>                 
        </div>
        <!--/.col (left) -->
                   <%---------------------------------------------------------------End Left Form------------------------------------------------%>



                    <%------------------------------------------------------------Start Right Form------------------------------------------------%>
                    <div class="col-md-6">
          <!-- Horizontal Form -->                      
            <!-- form start -->
          <!-- general form Commodity -->
            <div class="form-horizontal">
                <%--<fieldset><legend>Customer</legend>--%>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtLength_ConfirmIssue" class="col-sm-4 control-label">Length:</label>
                  <label for="txtProductVolume_ConfirmIssue" class="col-sm-4 control-label">Product Volume:</label>
                  <label for="txtPalletNo_ConfirmIssue" class="col-sm-4 control-label">Pallet No:</label>
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                    <input class="form-control" id="txtLength_ConfirmIssue" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtProductVolume_ConfirmIssue" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPalletNo_ConfirmIssue" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtStatus_ConfirmIssue" class="col-sm-4 control-label">Status:</label>
                  <div class="col-sm-8">
                    <asp:DropDownList ID="ddlStatus_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>                  
                </div>
                <div class="form-group">
                  <label for="txtType_ConfirmIssue" class="col-sm-4 control-label">Type:</label>
                  <div class="col-sm-8">                    
                    <asp:DropDownList ID="ddlType_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtExpiredDate_ConfirmIssue" class="col-sm-4 control-label">Expired Date:</label>
                  <div class="col-sm-4">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerExpiredDate_ConfirmIssue" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderExpiredDate_ConfirmIssue" runat="server" Enabled="True" TargetControlID="txtdatepickerExpiredDate_ConfirmIssue" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div> 
                <div class="form-group">
                  <label for="txtPONo_ConfirmIssue" class="col-sm-4 control-label">PO No:</label>
                  <div class="col-sm-4">                       
                      <input class="form-control" id="txtPONo_ConfirmIssue" runat="server" value="0"/>
                  </div>
                </div> 
                 <div class="form-group">
                  <label for="txtWeight_ConfirmIssue" class="col-sm-4 control-label">Weight:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtWeight_ConfirmIssue" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlWeight_ConfirmIssue" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>
                </div>
                  <div class="form-group">
                  <label for="txtExchangeRate_ConfirmIssue" class="col-sm-4 control-label">ExchangeRate:</label>
                  <label for="txtAmount_ConfirmIssue" class="col-sm-4 control-label">Amount:</label>
                  <label for="txtBathAmount_ConfirmIssue" class="col-sm-4 control-label">Bath Amount:</label>
                </div>
                <div class="form-group">     
                 <div  class="col-sm-4">                    
                    <input class="form-control" id="txtExchangeRate_ConfirmIssue" runat="server" value="0"/> 
                  </div>             
                  <div class="col-sm-4">
                    <input class="form-control" id="txtAmount_ConfirmIssue" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtBathAmount_ConfirmIssue" runat="server" value="0"/>
                  </div>                  
                </div>                               
              </div>
              <!-- /.box-body -->
                    <%--</fieldset>--%>
            </div> 
            </div>        
             <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

                            <%-----------------------------------------------------Start AFTER RIGHT FORM------------------------------------------------------------%>
                   





                         <%-------------------------------------------------------End AFTER RIGHT FORM----------------------------------------------------------------%>

             <%-----------------------------------------------------Start BUTTON FORM------------------------------------------------------------%>
                   <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->                        
                                               <div class="form-horizontal">
                                                   <%--<fieldset>  <legend>Job</legend>--%>
                                                      <div class="box-body">   
                                                          <div class="col-sm-6">
                                                              <div class="form-group">
                                                                  <div class="col-sm-3">                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnSelectAll_ConfirmIssue" title="btnSelectAll_ConfirmIssue" >Select All</button>                                                                    
                                                                  </div>
                                                                  <div class="col-sm-3">                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnCencelSelectAll_ConfirmIssue" title="btnCencelSelectAll_ConfirmIssue" >Cencel Select All</button>                                                                    
                                                                  </div>
                                                                      <label for="txtReceiveDate_Button_ConfirmIssue" class="col-sm-3 control-label">Receive Date:</label>
                                                                  <div class="col-sm-3">                       
                                                                       <asp:TextBox CssClass="form-control" ID="txtdatepickerReceiveDate_Button_ConfirmIssue" runat="server" placeholder="DD/MM/YYYY">
                                                                       </asp:TextBox>
                                                                       <asp:CalendarExtender ID="CalendarExtenderReceiveDate_Button_ConfirmIssue" runat="server" Enabled="True" TargetControlID="txtdatepickerReceiveDate_Button_ConfirmIssue" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                  </div>
                                                              </div>
                                                          </div>

                                                          <div class="col-sm-6">
                                                              <div class="form-group">
                                                                  <label for="txtWHLocation_ConfirmIssue" class="col-sm-4 control-label">WH Location:</label>                                       
                                                                    <div class="col-sm-4">                                                                    
                                                                        <input class="form-control" id="txtWHLocation_ConfirmIssue" runat="server"/>
                                                                    </div>
                                                                  <div class="col-sm-4">                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnIssue_ConfirmIssue" title="btnIssue_ConfirmIssue" >Issue</button>                                                                    
                                                                  </div>
                                                              </div>
                                                          </div>

                                                                         
                                    <!-- /.box-body -->
                             </div>
                            <!-- /.box-header -->
                           <%--</fieldset>--%>
                       </div>
          <!--/.col-lg-6 col-md-6 stockqty--->
               
                    </div>
                         <%-------------------------------------------------------End BUTTON FORM----------------------------------------------------------------%>
                       
        </div>
         <!-- right column -->
                    <!-- /.post -->
                </div>
             <!-----/ Export Goods----->

              <%--------------------------------------------------------------END Good Receive Detail----------------------------------------------------------%>
                                          


              
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