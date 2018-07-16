<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SingleReceivedWH.aspx.vb" Inherits="WMS.SingleReceivedWH" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Single Received
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>WareHouse</a></li>
                <li><a href="SingleReceivedWH.aspx"class="active">SingleReceived</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->

                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">                            
                            <li class="active"><a href="#confirmgoodreceive" data-toggle="tab">Confirm Good Receive</a></li>
                            <li><a href="#goodreceivedetail" data-toggle="tab">Good Receive Detail</a></li>
                            <li><a href="#putaway" data-toggle="tab">Put Away</a></li>
                        </ul>

                        <div class="tab-content">
                            <style>
                             h5{height:39px;}                                                                    
                            </style>

                            <%-----------------------------------------------------Start Confirm Good Receive-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="active tab-pane" id="confirmgoodreceive">
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
                                                                  <label for="txtJobNo_ConGoodRec" class="col-sm-4 control-label">Job No:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlJobNo_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>                                                                  
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                   <label for="txtJobdate_ConGoodRec" class="col-sm-4 control-label">Job Date:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                                                    <asp:TextBox CssClass="form-control" ID="txtdatepickerJobdate_ConGoodRec" runat="server" placeholder="DD/MM/YYYY">
                                                                </asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtenderJobdate_ConGoodRec" runat="server" Enabled="True" TargetControlID="txtdatepickerJobdate_ConGoodRec" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                                  </div>                                                                  
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtCustRefNo_ConGoodRec" class="col-sm-4 control-label">Cust REF No:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustRefNo_ConGoodRec" runat="server"/>
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
                <fieldset><legend>Owner</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtOwnerCode_ConGoodRec" class="col-sm-4 control-label">Owner Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlOwnerCode_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameOwner_ConGoodRec" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameOwner_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1Owner_ConGoodRec" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Owner_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Owner_ConGoodRec" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Owner_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Owner_ConGoodRec" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Owner_ConGoodRec" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Owner_ConGoodRec" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Owner_ConGoodRec" runat="server"/>
                  </div>
                </div>                
            </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

                 <div class="form-horizontal">
                <fieldset><legend>WH Management</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtWHManagement_ConGoodRec" class="col-sm-4 control-label">WH Management:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlWHManagement_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameWHManage_ConGoodRec" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameWHManage_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1WHManage_ConGoodRec" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1WHManage_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2WHManage_ConGoodRec" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2WHManage_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3WHManage_ConGoodRec" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3WHManage_ConGoodRec" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4WHManage_ConGoodRec" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4WHManage_ConGoodRec" runat="server"/>
                  </div>
                </div>                
            </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>      

            <div class="form-horizontal">
                <fieldset><legend>Commodity</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtCommodity_ConGoodRec" class="col-sm-4 control-label">Commodity:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlCommodity_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantityPackage_ConGoodRec" class="col-sm-5 control-label">Quantity Package:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQuantityPackage_ConGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuantityPackage_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantityPLTSkid_ConGoodRec" class="col-sm-5 control-label">Quantity PLT/Skid:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQuantityPLTSkid_ConGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuantityPLTSkid_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantityReceived_ConGoodRec" class="col-sm-5 control-label">Quantity Received:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQuantityReceived_ConGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuantityReceived_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantityDamage_ConGoodRec" class="col-sm-5 control-label">Quantity Damage:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txttxtQuantityDamage_ConGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuantityDamage_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtRemark_ConGoodRec" class="col-sm-4 control-label">Remark:</label>
                  <div class="col-sm-8">
                    <textarea class="form-control" rows="3" id="txtRamark_ConGoodRec" placeholder="Remark" style="height: 71px; width: 872px;"></textarea>
                  </div>
                </div>
                 <div class="form-group">      
                  <div class="col-sm-4">  
                  </div>         
                  <div class="col-sm-8">
                    <button type="submit" runat="server" class="btn btn-primary" id="btnSumQTY_ConGoodRec" title="btnSumQTY_ConGoodRec" onserverclick="btnSumQTY_ConGoodRec_ServerClick">Sum QTY</button>
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
                <fieldset><legend>Customer</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtCustomerCode_ConGoodRec" class="col-sm-4 control-label">Customer Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="txtCustomerCode_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameCustomer_ConGoodRec" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameCustomer_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1Customer_ConGoodRec" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Customer_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Customer_ConGoodRec" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Customer_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Customer_ConGoodRec" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Customer_ConGoodRec" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Customer_ConGoodRec" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Customer_ConGoodRec" runat="server"/>
                  </div>
                </div>                                 
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        

                <div class="form-horizontal">
                <fieldset><legend>End User</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtEndUserCode_ConGoodRec" class="col-sm-4 control-label">End User Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlEndUserCode_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameEndUser_ConGoodRec" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameEndUser_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1EndUser_ConGoodRec" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1EndUser_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2EndUser_ConGoodRec" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2EndUser_ConGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3EndUser_ConGoodRec" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3EndUser_ConGoodRec" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4EndUser_ConGoodRec" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4EndUser_ConGoodRec" runat="server"/>
                  </div>
                </div>                
            </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

            <div class="form-horizontal">
                <fieldset><legend>Commodity</legend>
              <div class="box-body">
              <div class="form-group">
                <label for="txtQuantityOfGood_ConGoodRec" class="col-sm-5 control-label">Quantity Of Goods:</label>
                <div class="col-sm-3">
                  <input class="form-control" id="txtQuantityOfGood_ConGoodRec" runat="server" value="0.0"/>
                </div>
                <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlQuantityOfGood_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                </div>
              </div>
                <div class="form-group">
                  <label for="txtWeight_ConGoodRec" class="col-sm-5 control-label">Weight:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtWeight_ConGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlWeight_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtVolume_ConGoodRec" class="col-sm-5 control-label">Volume:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtVolume_ConGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQTYWaitRec_ConGoodRec" class="col-sm-5 control-label">QTY Wait Receive:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQTYWaitRec_ConGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQTYWaitRec_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQTYDiscrepancy_ConGoodRec" class="col-sm-5 control-label">QTY Discrepancy:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQTYDiscrepancy_ConGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQTYDiscrepancy_ConGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
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
                            <%-------------------------------------------------------------End Confirm Good Receive-------------------------------------------------------%>



                            <%--------------------------------------------------------------Start Good Receive Detail----------------------------------------------------------%>
       <!-------- Export Goods --------->
     <div class="tab-pane" id="goodreceivedetail">
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
                                                                  <label for="txtWHSite_GoodRecDetail" class="col-sm-4 control-label">WH Site:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlWHSite_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtCusLOTNo_GoodRecDetail" class="col-sm-4 control-label">Cus LOT No:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtCusLOTNo_GoodRecDetail" runat="server"/>
                                                                </div>
                                                                  </div>   
                                                              <div class="form-group">
                                                                  <label for="txtEASPN_GoodRecDetail" class="col-sm-4 control-label">EAS P/N:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlEASPN_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtProductDesc_GoodRecDetail" class="col-sm-4 control-label">Product Desc:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                   <textarea class="form-control" rows="3" id="txtRamark_ConGoodRec55554" placeholder="Desc .."style="height: 34px; width: 552px;" ></textarea>
                                                                </div>
                                                                  </div>                                                                                                                             
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                   <label for="txtWHLocation_GoodRecDetail" class="col-sm-4 control-label">WH Location:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlWHLocation_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                   <label for="txtCustWHFac_GoodRecDetail" class="col-sm-4 control-label">Cust W/H Fac:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlCustWHFac_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>  
                                                              <div class="form-group">
                                                                   <label for="txtCustomerPN_GoodRecDetail" class="col-sm-4 control-label">CustomerP/N:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtCustomerPN_GoodRecDetail" runat="server"/>
                                                                </div>
                                                                  </div>                                                             
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtENDCustomer_GoodRecDetail" class="col-sm-4 control-label">ENDCustomer:</label>
                                                                 <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlENDCustomer_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtItemNo_GoodRecDetail" class="col-sm-4 control-label">Item No:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtItemNo_GoodRecDetail" runat="server"/>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtOwnerPN_GoodRecDetail" class="col-sm-4 control-label">Owner P/N:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtOwnerPN_GoodRecDetail" runat="server"/>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtMeasurement_GoodRecDetail" class="col-sm-4 control-label">Measurement:</label>
                                                                 <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlMeasurement_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList>
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
                  <label for="txtSpace_GoodRecDetail" class="col-sm-4 control-label"></label>
                  <label for="txtWidth_GoodRecDetail" class="col-sm-4 control-label">Width:</label>
                  <label for="txtHight_GoodRecDetail" class="col-sm-4 control-label">Hight:</label>
                </div>
                <div class="form-group">
                  <label for="txtDimension_GoodRecDetail" class="col-sm-4 control-label">Dimension:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtWidth_GoodRecDetail" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtHight_GoodRecDetail" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtOrderNo_GoodRecDetail" class="col-sm-4 control-label">Order No:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtOrderNo_GoodRecDetail" runat="server"/>
                  </div>                  
                </div>
                <div class="form-group">
                  <label for="txtReceiveNo_GoodRecDetail" class="col-sm-4 control-label">Receive No:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtReceiveNo_GoodRecDetail" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                      <label>
                           <input type="checkbox" runat="server" id="chkNotUseDate_GoodRecDetail" />Not Use Date
                      </label>
                  </div>
                  <label for="txtManufacturing_GoodRecDetail" class="col-sm-4 control-label">Manufacturing:</label>
                  <div class="col-sm-4">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerManufacturing_GoodRecDetail" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderManufacturing_GoodRecDetail" runat="server" Enabled="True" TargetControlID="txtdatepickerManufacturing_GoodRecDetail" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtReceiveDate_GoodRecDetail" class="col-sm-4 control-label">Receive Date:</label>
                  <div class="col-sm-3">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerReceiveDate_GoodRecDetail" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderReceiveDate_GoodRecDetail" runat="server" Enabled="True" TargetControlID="txtdatepickerReceiveDate_GoodRecDetail" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                  <label for="txtActualQTY_GoodRecDetail" class="col-sm-2 control-label">ActualQTY:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtActualQTY" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantity1QTY_GoodRecDetail" class="col-sm-4 control-label">Quantity1 QTY:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtQuantity1QTY_GoodRecDetail" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlQuantity1QTY_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtCurrency_GoodRecDetail" class="col-sm-4 control-label">Currency:</label>
                  <label for="txtPriceForeign_GoodRecDetail" class="col-sm-4 control-label">Price Foreign:</label>
                  <label for="txtPriceBath_GoodRecDetail" class="col-sm-4 control-label">Price Bath:</label>
                </div>
                <div class="form-group">     
                  <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlCurrency_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>             
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPriceForeign_GoodRecDetail" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPriceBath_GoodRecDetail" runat="server" value="0"/>
                  </div>                  
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                       <div class="radio">
                       <label>                                            
                          <asp:RadioButton runat="server" ID ="rdbShortShip" Text="Short Ship"  onclick="EnableDisableTextBox();"  GroupName="option2"  />
                       </label>
                       </div>            
                  </div>
                  <div class="col-sm-4">
                       <div class="radio">
                       <label>                                            
                          <asp:RadioButton runat="server" ID ="rdbOverShip" Text="Over Ship"  onclick="EnableDisableTextBox();"  GroupName="option2"  />
                       </label>
                       </div>            
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
                  <label for="txtLength_GoodRecDetail" class="col-sm-4 control-label">Length:</label>
                  <label for="txtProductVolume_GoodRecDetail" class="col-sm-4 control-label">Product Volume:</label>
                  <label for="txtPalletNo_GoodRecDetail" class="col-sm-4 control-label">Pallet No:</label>
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                    <input class="form-control" id="txtLength_GoodRecDetail" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtProductVolume_GoodRecDetail" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPalletNo_GoodRecDetail" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtStatus_GoodRecDetail" class="col-sm-4 control-label">Status:</label>
                  <div class="col-sm-8">
                    <asp:DropDownList ID="ddlStatus_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>                  
                </div>
                <div class="form-group">
                  <label for="txtType_GoodRecDetail" class="col-sm-4 control-label">Type:</label>
                  <div class="col-sm-8">                    
                    <asp:DropDownList ID="ddlType_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtExpiredDate_GoodRecDetail" class="col-sm-3 control-label">Expired Date:</label>
                  <div class="col-sm-3">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerExpiredDate_GoodRecDetail" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderExpiredDate_GoodRecDetail" runat="server" Enabled="True" TargetControlID="txtdatepickerExpiredDate_GoodRecDetail" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                  <label for="txtEntryNo_GoodRecDetail" class="col-sm-3 control-label">EntryNo:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtEntryNo_GoodRecDetail" runat="server"/>
                  </div>
                </div> 
                <div class="form-group">
                  <label for="txtETAARRDate_GoodRecDetail" class="col-sm-3 control-label">ETA/ARR Date:</label>
                  <div class="col-sm-3">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerETAARRDate_GoodRecDetail" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderETAARRDate_GoodRecDetail" runat="server" Enabled="True" TargetControlID="txtdatepickerETAARRDate_GoodRecDetail" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                  <label for="txtEntryItemNo_GoodRecDetail" class="col-sm-3 control-label">EntryItemNo:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtEntryItemNo_GoodRecDetail" runat="server"/>
                  </div>
                </div> 
                 <div class="form-group">
                  <label for="txtQuantity2_GoodRecDetail" class="col-sm-4 control-label">Quantity2:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtQuantity2_GoodRecDetail" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlQuantity2_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>
                </div>
                  <div class="form-group">
                  <label for="txtExchangeRate_GoodRecDetail" class="col-sm-4 control-label">ExchangeRate:</label>
                  <label for="txtAmount_GoodRecDetail" class="col-sm-4 control-label">Amount:</label>
                  <label for="txtBathAmount_GoodRecDetail" class="col-sm-4 control-label">Bath Amount:</label>
                </div>
                <div class="form-group">     
                 <div  class="col-sm-4">                    
                    <input class="form-control" id="txtExchangeRate_GoodRecDetail" runat="server" value="0"/> 
                  </div>             
                  <div class="col-sm-4">
                    <input class="form-control" id="txtAmount_GoodRecDetail" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtBathAmount_GoodRecDetail" runat="server" value="0"/>
                  </div>                  
                </div>  
                 <div class="form-group">
                  <label for="txtInvoice_GoodRecDetail" class="col-sm-4 control-label">Invoice:</label>
                  <div class="col-sm-4">                     
                    <input class="form-control" id="txtInvoice_GoodRecDetail" runat="server"/>
                  </div>
                </div>                             
              </div>
              <!-- /.box-body -->
                    <%--</fieldset>--%>
            </div> 
            </div>        
             <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

            <%-----------------------------------------------------Start AFTER RIGHT FORM------------------------------------------------------------%>
                   <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->                        
                                               <div class="form-horizontal">
                                                   <%--<fieldset>  <legend>Job</legend>--%>
                                                      <div class="box-body">   
                                                          <div class="col-md-4 col-sm-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtSupplier_GoodRecDetail" class="col-sm-4 control-label">Supplier:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtSupplier_GoodRecDetail" runat="server"/>
                                                                </div>
                                                                  </div> 
                                                              <div class="form-group">
                                                                  <label for="txtDestination_GoodRecDetail" class="col-sm-4 control-label">Destination:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtDestination_GoodRecDetail" runat="server"/>
                                                                </div>
                                                                  </div>                                                                  
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtBuyer_GoodRecDetail" class="col-sm-4 control-label">Buyer:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtBuyer_GoodRecDetail" runat="server"/>
                                                                </div>
                                                                  </div> 
                                                              <div class="form-group">
                                                                  <label for="txtConsignee_GoodRecDetail" class="col-sm-4 control-label">Consignee:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtConsignee_GoodRecDetail" runat="server"/>
                                                                </div>
                                                                  </div>                                                                  
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtExporter_GoodRecDetail" class="col-sm-4 control-label">Exporter:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtExporter_GoodRecDetail" runat="server"/>
                                                                </div>
                                                                  </div> 
                                                              <div class="form-group">
                                                                  <label for="txtShippingMark_GoodRecDetail" class="col-sm-4 control-label">ShippingMark:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtShippingMark_GoodRecDetail" runat="server"/>
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
                         <%-------------------------------------------------------End AFTER RIGHT FORM----------------------------------------------------------------%>

             <%-----------------------------------------------------Start BUTTON FORM------------------------------------------------------------%>
                   <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->                        
                                               <div class="form-horizontal">
                                                   <%--<fieldset>  <legend>Job</legend>--%>
                                                      <div class="box-body">   
                                                          <div class="col-sm-6">
                                                              <div class="form-group">
                                                                  <div class="col-sm-4">                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnSelectAll_GoodRecDetail" title="btnSelectAll_GoodRecDetail" onserverclick="btnSelectAll_GoodRecDetail_ServerClick">Select All</button>                                                                    
                                                                  </div>
                                                                  <div class="col-sm-4">                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnCencelSelectAll_GoodRecDetail" title="btnCencelSelectAll_GoodRecDetail" onserverclick="btnCencelSelectAll_GoodRecDetail_ServerClick" >Cencel Select All</button>                                                                    
                                                                  </div> 
                                                              </div>
                                                          </div>

                                                          <div class="col-sm-6">
                                                              <div class="form-group">
                                                                  <div class="col-sm-4">                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnReceive_GoodRecDetail" title="btnReceive_GoodRecDetail" onserverclick="btnReceive_GoodRecDetail_ServerClick" >Receive</button>                                                                    
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
            


               




                        </div>
                        <!-- /.tab-pane -->
                    </div>
                    <!-- /.tab-pane -->
                </div>
                <!-- /.col -->
           
            <!-- /.row -->
        </section>
        <!-- /.content -->
        
    </form>
</asp:Content>