<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PrepareLotWH.aspx.vb" Inherits="WMS.PrepareLotWH" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Finish Good
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>WareHouse</a></li>
                <li><a href="PrepareLotWH.aspx"class="active">Prepare LOT</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->

                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">                            
                            <li class="active"><a href="#preparegoodsreceive" data-toggle="tab">Prepare Goods Receive</a></li>
                            <li><a href="#goodreceivedetail" data-toggle="tab">Good Receive Detail</a></li>
                            <li><a href="#importdata" data-toggle="tab">Import Data</a></li>
                        </ul>

                        <div class="tab-content">
                            <style>
                             h5{height:39px;}                                                                    
                            </style>

                            <%-----------------------------------------------------Start Confirm Good Receive-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="active tab-pane" id="preparegoodsreceive">
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
                                                                  <label for="txtJobNo_PreGoodRec" class="col-sm-4 control-label">Job No:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlJobNo_PreGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>                                                                  
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                   <label for="txtJobdate_PreGoodRec" class="col-sm-4 control-label">Job Date:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                                                    <asp:TextBox CssClass="form-control" ID="txtdatepickerJobdate_PreGoodRec" runat="server" placeholder="DD/MM/YYYY">
                                                                </asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtenderJobdate_PreGoodRec" runat="server" Enabled="True" TargetControlID="txtdatepickerJobdate_PreGoodRec" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                                  </div>                                                                  
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtCustRefNo_PreGoodRec" class="col-sm-4 control-label">Cust REF No:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCustRefNo_PreGoodRec" runat="server"/>
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
                  <label for="txtOwnerCode_PreGoodRec" class="col-sm-4 control-label">Owner Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlOwnerCode_PreGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameOwner_PreGoodRec" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameOwner_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1Owner_PreGoodRec" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Owner_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Owner_PreGoodRec" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Owner_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Owner_PreGoodRec" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Owner_PreGoodRec" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Owner_PreGoodRec" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Owner_PreGoodRec" runat="server"/>
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
                  <label for="txtWHManagement_PreGoodRec" class="col-sm-4 control-label">WH Management:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlWHManagement_PreGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameWHManage_PreGoodRec" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameWHManage_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1WHManage_PreGoodRec" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1WHManage_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2WHManage_PreGoodRec" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2WHManage_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3WHManage_PreGoodRec" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3WHManage_PreGoodRec" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4WHManage_PreGoodRec" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4WHManage_PreGoodRec" runat="server"/>
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
                  <label for="txtCustomerCode_PreGoodRec" class="col-sm-4 control-label">Customer Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="txtCustomerCode_PreGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameCustomer_PreGoodRec" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameCustomer_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1Customer_PreGoodRec" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Customer_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Customer_PreGoodRec" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Customer_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Customer_PreGoodRec" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Customer_PreGoodRec" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Customer_PreGoodRec" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Customer_PreGoodRec" runat="server"/>
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
                  <label for="txtEndUserCode_PreGoodRec" class="col-sm-4 control-label">End User Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlEndUserCode_PreGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameEndUser_PreGoodRec" class="col-sm-4 control-label">Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameEndUser_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1EndUser_PreGoodRec" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1EndUser_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2EndUser_PreGoodRec" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2EndUser_PreGoodRec" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3EndUser_PreGoodRec" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3EndUser_PreGoodRec" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4EndUser_PreGoodRec" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4EndUser_PreGoodRec" runat="server"/>
                  </div>
                </div>                
            </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

            

        </div>
         <!-- right column -->

                   <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

                   <%--------------------------------------------------------Start Mid Form----------------------------------------------------%>
                   <div class="col-md-12">
                       <div class="form-horizontal">
                <fieldset><legend>Assign Resource</legend>
              <div class="box-body">
                 <div class="form-group">
                  <label for="txtHandlePreson_PreGoodRec" class="col-sm-3 control-label">Handle Person:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtHandlePreson_PreGoodRec" runat="server"/>
                  </div>
                  <label for="txtDate_PreGoodRec" class="col-sm-3 control-label">Date:</label>
                  <div class="col-sm-3">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerDateAssign_PreGoodRec" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderDateAssign_PreGoodRec" runat="server" Enabled="True" TargetControlID="txtdatepickerDateAssign_PreGoodRec" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>   
                <div class="form-group">
                  <%-------------------------------Repeater Assign Resource--------------------%>

                </div>             
            </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

                       								<%-----------------------------------------------------Start Left Form--------------------------------------------------%>
<div class="col-md-6">
        <div class="form-horizontal">
                <fieldset><legend>Commodity</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtCommodity_PreGoodRec" class="col-sm-4 control-label">Commodity:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlCommodity_PreGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantityPackage_PreGoodRec" class="col-sm-5 control-label">Quantity Package:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQuantityPackage_PreGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuantityPackage_PreGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantityPLTSkid_PreGoodRec" class="col-sm-5 control-label">Quantity PLT/Skid:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQuantityPLTSkid_PreGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuantityPLTSkid_PreGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtRemark_PreGoodRec" class="col-sm-4 control-label">Remark:</label>
                  <div class="col-sm-8">
                    <textarea class="form-control" rows="3" id="txtRamark_PreGoodRec" placeholder="Remark" style="height: 71px; width: 872px;"></textarea>
                  </div>
                </div>
                 
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>
</div>
								 <%---------------------------------------------------------------End Left Form------------------------------------------------%>
								 
								 
								 
								 
								 
								 <%------------------------------------------------------------Start Right Form------------------------------------------------%>
								 
<div class="col-md-6">
			<div class="form-horizontal">
                <fieldset><legend>Commodity</legend>
              <div class="box-body">
              <div class="form-group">
                <label for="txtQuantityOfGood_PreGoodRec" class="col-sm-5 control-label">Quantity Of Goods:</label>
                <div class="col-sm-3">
                  <input class="form-control" id="txtQuantityOfGood_PreGoodRec" runat="server" value="0.0"/>
                </div>
                <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlQuantityOfGood_PreGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                </div>
              </div>
                <div class="form-group">
                  <label for="txtWeight_PreGoodRec" class="col-sm-5 control-label">Weight:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtWeight_PreGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlWeight_PreGoodRec" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtVolume_PreGoodRec" class="col-sm-5 control-label">Volume:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtVolume_PreGoodRec" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>    
                </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>					 
</div>					
						<%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

                   </div>
                        <%-------------------------------------------------------------End Mid Form----------------------------------------------------%>

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
                                                                   <textarea class="form-control" rows="3" id="txtProductDesc_GoodRecDetail" placeholder="Desc .."style="height: 34px; width: 552px;" ></textarea>
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
                  <div class="col-sm-8">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerReceiveDate_GoodRecDetail" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderReceiveDate_GoodRecDetail" runat="server" Enabled="True" TargetControlID="txtdatepickerReceiveDate_GoodRecDetail" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantity_GoodRecDetail" class="col-sm-4 control-label">Quantity:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtQuantity_GoodRecDetail" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlQuantity_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList> 
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
                <div class="form-group" style="height:34px;">
                  <%--<label for="txtType_GoodRecDetail" class="col-sm-4 control-label">Type:</label>
                  <div class="col-sm-8">                    
                    <asp:DropDownList ID="ddlType_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>--%>
                </div>
                <div class="form-group">
                  <label for="txtExpiredDate_GoodRecDetail" class="col-sm-4 control-label">Expired Date:</label>
                  <div class="col-sm-4">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerExpiredDate_GoodRecDetail" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderExpiredDate_GoodRecDetail" runat="server" Enabled="True" TargetControlID="txtdatepickerExpiredDate_GoodRecDetail" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div> 
                <div class="form-group">
                  <label for="txtStorageExpDate_GoodRecDetail" class="col-sm-4 control-label">Storage EXP Date:</label>
                  <div class="col-sm-4">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerStorageExpDate_GoodRecDetail" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderStorageExpDate_GoodRecDetail" runat="server" Enabled="True" TargetControlID="txtdatepickerStorageExpDate_GoodRecDetail" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div> 
                 <div class="form-group">
                  <label for="txtWeight_GoodRecDetail" class="col-sm-4 control-label">Weight:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtWeight_GoodRecDetail" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlWeight_GoodRecDetail" CssClass="form-control" runat="server"></asp:DropDownList> 
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
                                                          <div class="col-sm-3 col-sm-offset-9">
                                                              <div class="form-group">
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnAddNew_GoodRecDetail" title="btnAddNew_GoodRecDetail" onserverclick="btnAddNew_GoodRecDetail_ServerClick" >Add New</button>                                                                    
                                                                                                                                                                                                       
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnSaveModify_GoodRecDetail" title="btnSaveModify_GoodRecDetail" onserverclick="btnSaveModify_GoodRecDetail_ServerClick" >Save Modify</button>                                                                    
                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnDelete_GoodRecDetail" title="btnDelete_GoodRecDetail" onserverclick="btnDelete_GoodRecDetail_ServerClick" >Delete</button>   
                                                              </div>
                                                          </div>

                                                          <div class="col-sm-6">
                                                              <div class="form-group">
                                                                  <div class="col-sm-4">                                                                    
                                                                                                                                     
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


             <%----------------------------------------------------------------------Start Import Data Tab--------------------------------------------------------%>
             <!--- Detailof Goods --->
         <div class="tab-pane" id="importdata">
            <!-- Post -->
            <div class="post">
             <div class="row margin-bottom">
                <div class="col-lg-12 col-md-12">

                     <div class="form-horizontal">
                           <div class="box-body">

                            <fieldset class="col-md-12">
                                <legend>Import File</legend>
                               <div class="col-lg-12 col-md-12">
                                 <div class="form-group">
                                  <label for="txtSelectFileForImport_ImportData" class="col-sm-4 control-label">Select File For Import:</label>
                                  <div class="col-sm-4">
                                    <input type="file" class ="form-control" id="txtSelectFileForImport_ImportData" runat="server"/>     
                                  </div>                                  
                                  <div class="col-sm-4">
                                    <button type="submit" runat="server" class="btn btn-success" id="btnImport_ImportData" title="btnImport_ImportData" >Import</button> 
                                  </div>
                                </div>  
                                 <div class="form-group">
                                   <div class="col-sm-12">
                                   <div class="progress active">
                                    <div class="progress-bar progress-bar-primary progress-bar-striped" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
                                      <span class="sr-only">40% Complete (success)</span>
                                    </div>
                                   </div>
                                   </div>
                                 </div> 
                                   
                               </div>                             
                         </fieldset>
                    
                          </div>
                      
                     </div>
                     
                    <div class="form-horizontal">
                           <div class="box-body">

                            <fieldset class="col-md-12">
                                <legend>Data Imported List</legend>
                               <div class="col-lg-12 col-md-12">
                                   <%------------------Repeater DataImport--------------------%>
                               </div>                             
                         </fieldset>
                    
                          </div>
                      
                     </div>

                     </div>
                <!--/.col-lg-6 col-md-6--->
                  </div>
                </div>
              </div>
          <!----/Detailof Goods----->
                            <%---------------------------------------------------------------End Import Data Tab----------------------------------------------%>
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