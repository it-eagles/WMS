<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ViewGoods.aspx.vb" MasterPageFile="~/Home.Master" Inherits="WMS.ViewGoods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Master Goods
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Master Files</a></li>
                <li><a class="active">Master Goods</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->
                <div class="col-lg-12 col-md-12">

                    <!-- general form elements -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <div class="form-group">
                                <div class="col-sm-2">
                                  <h3 class="box-title p-t-8">Product Deatil</h3>
                            </div>             
                         
                          </div>         
                        </div>
                       
                        <!-- /.box-header -->
               <from class="form-horizontal">
                     <div class="box-body">   
                         <div class ="col-lg-6 col-md-6">
                               <div class="form-group" >
                                    <label for="txtProductCode" class="col-sm-4 control-label">Product Code :</label>
                                         <div class="col-sm-8">
                                           <input class="form-control" id="txtProductCode" runat="server" placeholder="Product Code" disabled>
                                        </div>
                                    </div>
                                  <div class="form-group">
                                        <label for="txtCustomerPart" class="col-sm-4 control-label">Owner Part :</label>
                                           <div class="col-sm-8">
                                           <input class="form-control" id="txtCustomerPart" runat="server"  placeholder="Owner Part" disabled>
                                       </div>
                                    </div>
                                 <div class="form-group">
                                            <label for="txtCustomerPart" class="col-sm-4 control-label">Create By :</label>
                                               <div class="col-sm-8">
                                               <input class="form-control" id="txtCreateBy" runat="server"  placeholder="Create By" disabled>
                                           </div>
                                        </div>
                                 <div class="form-group">
                                            <label for="txtCustomerPart" class="col-sm-4 control-label">Create Date :</label>
                                               <div class="col-sm-8">
                                               <input class="form-control" id="txtCreateDate" runat="server"  placeholder="Create Date" disabled>
                                           </div>
                                        </div>
                                      </div>      
                                
                                <div class="col-lg-6 col-md-6">
                                    <div class="form-group">
                                        <label for="txtProductPO" class="col-sm-3 control-label">PO :</label>
          
                                      <div class="col-sm-8">
                                         <input  class="form-control" id="txtProductPO" runat="server" placeholder="Product PO" disabled>
                                      </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtEndUserPart" class="col-sm-3 control-label">End User Part :</label>
                                    <div class="col-sm-8">
                                        <input class="form-control" id="txtEndUserPart" runat="server"  placeholder="End User Part" disabled/>
                                    </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtEndUserPart" class="col-sm-3 control-label">Update By :</label>
                                    <div class="col-sm-8">
                                        <input class="form-control" id="txtUpdateBy" runat="server"  placeholder="Update By" disabled/>
                                    </div>
                                    </div>

                                     <div class="form-group">
                                        <label for="txtEndUserPart" class="col-sm-3 control-label">Update Date :</label>
                                    <div class="col-sm-8">
                                        <input class="form-control" id="txtUpdateDate" runat="server"  placeholder="Update Date" disabled/>
                                    </div>
                                    </div>
                                </div> 
                         <!--------- /.col-lg-6 col-md-6 ------------->           
                            </div>
                            <!-- /.box-body -->
                           
                         </from>
                    </div>
                     <!---------- /.box box-primary  --------->
                </div>
               <!--------- /.col-lg-12 col-md-12 ------------->
            </div>
             <!--/.row-->

            <div class="row">
                <!-- left column -->

                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#stockqty" data-toggle="tab">Stock QTY.</a></li>
                            <li><a href="#importgoods" data-toggle="tab">Import Goods</a></li>
                            <li><a href="#exportgoods" data-toggle="tab">Export Goods</a></li>
                            <li><a href="#detailofgoods" data-toggle="tab">Detail of goods</a></li>
                            <li><a href="#assembly" data-toggle="tab">Assembly</a></li>
                        </ul>

                        <div class="tab-content">

                            <!------- StockQTY ---------->
                            <div class="active tab-pane" id="stockqty">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">

                                        <div class="col-lg-8 col-md-8 col-md-offset-1">
                                            <!-- form start -->
                        
                                               <from class="form-horizontal">

                                                      <div class="box-body">   
                                                           <div class="form-group" >
                                    
                                                               <label for="txtMinimunStock" class="col-sm-4 control-label">Minimun Stock</label>
                                       
                                                             <div class="col-sm-8">
                                                               <input class="form-control" id="txtMinimunStock" runat="server" placeholder="Minimun Stock" disabled>
                                                             </div>

                                                           </div>
                                    
                                                        <div class="form-group">
                                                                  <label for="txtAdjustment" class="col-sm-4 control-label">Adjustment</label>
                                      
                                                     <div class="col-sm-8">
                                                                  <input class="form-control" id="txtAdjustment" runat="server" placeholder="Adjustment" disabled>
                                                     </div>
                      
                                                    </div>
                                                       <div class="form-group">
                                                      <label for="txtDamageQty" class="col-sm-4 control-label">Damage Qty</label>
                                                     <div class="col-sm-8">
                                                          <input class="form-control" id="txtDamageQty" runat="server"  placeholder="Damage Qty" disabled>
                                                     </div>
                                                </div>

                                    <div class="form-group">
                                             <label for="txtAvailableQTY" class="col-sm-4 control-label">Available QTY</label>
                                       <div class="col-sm-8">
                                            <input class="form-control" id="txtAvailableQTY" runat="server"  placeholder="Available QTY" disabled>
                                       </div>
                                   
                                    </div>

                              
                                    <!-- /.box-body -->
                             </div>
                            <!-- /.box-header -->
                           
                       </from>
          <!--/.col-lg-6 col-md-6 stockqty--->
               
                    </div>
                 <!--/.row-->
                       
                </div>

               </div>
             <!-- /.post -->


            <!-- /.content -->
         <!-- /.box-header -->
               
            </div>
          <!------- /.StockQTY ---------->

             <!------- Import Goods ------->
            <div class="tab-pane" id="importgoods">
                     <!-- Post -->
               <div class="post">
                  <div class="row margin-bottom">
                    <div class="col-lg-12 col-md-12">

                        <from class="form-horizontal">
                           <div class="box-body">   
                                              
                               <div class="form-group" >
                                     
                                     <label for="txtImpProductCode" class="col-sm-2 control-label">Imp. Product Code :</label>
                                       <div class="col-md-3">
         
                                             <input class="form-control" id="txtImpProductCode" runat="server" placeholder="Product Code" disabled>
                                      </div>
                                           <label for="dcboImpTariffCode" class="col-sm-2 control-label">Tariff Code :</label>
                                       <div class="col-md-5">   
                                             <input class="form-control" id="txtImpTariffCode" runat="server" placeholder="Tariff Code" disabled>
                                          
                                        </div>
                                       </div>                
                                 
                                    <div class="form-group" >
                                     
                                         <label for="txtImpDesc1" class="col-sm-2 control-label">Desc. (ENG) 1 :</label>
                                       <div class="col-md-9" id="ImpDesc1">
         
                                             <input class="form-control" id="txtImpDesc1" runat="server" placeholder="Desc" disabled>
                                      </div>
                              
                                       </div> 

                                 
                                    <div class="form-group" >
                                     
                                         <label for="txtImpDesc2" class="col-sm-2 control-label">Desc. (ENG) 2 :</label>
                                       <div class="col-md-9" id="ImpDesc2">
                                             <input class="form-control" id="txtImpDesc2" runat="server" placeholder="Desc" disabled>
                                      </div>
                                          
                                 
                                      </div> 
                                 
                                  <div class="form-group">
                                         <label for="txtImpDesc3" class="col-sm-2 control-label">Desc. (ENG) 3 :</label>
                                   <div class="col-md-9" id="ImpDesc3">
                                       <input class="form-control" id="txtImpDesc3" runat="server" placeholder="Desc" disabled>
                                   </div>
                                
                                   </div> 
                                   <div class="form-group" >
                                       <label for="txtImpProductAttribute1" class="col-sm-2 control-label">Product Desc. (TH) :</label>
                                    <div class="col-sm-10">
                                       <input class="form-control" id="txtImpProductAttribute1" runat="server" placeholder="Desc. (TH)" disabled>
                                    </div>
                                   </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpProductAttribute2" class="col-sm-2 control-label">Product Attribute:</label>  
                                      <div class="col-sm-10">
                                             <input class="form-control" id="txtImpProductAttribute2" runat="server" disabled>
                                        </div>
                                    </div>

                               <div class="col-lg-6 col-md-6">
                                   <div class="form-group">
                                        <label for="dcboImpTariffSequence" class="col-sm-4 control-label">Tariff Sequence</label>
                                           <div class="col-sm-8">
                                             <input class="form-control" id="txtImpTariffSequence" runat="server" disabled>
                                          </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpCustomsProductCode" class="col-sm-4 control-label">H.S. Code</label>
                                       <div class="col-sm-8">
                                          <input class="form-control" id="txtImpCustomsProductCode" runat="server"  placeholder="H.S." disabled>
                                       </div>
                                    </div>

                               <div class="form-group" >
                                        <label for="txtImpDutyType" class="col-sm-4 control-label">Duty Type</label>
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtImpDutyType" runat="server" placeholder="Duty Type" disabled>
                                        </div>
                               </div>
                                      <div class="form-group">
                                        <label for="txtImpValueRateP" class="col-sm-4 control-label">Value Rate(P) :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control" id="txtImpValueRateP" runat="server"  placeholder="Value Rate" disabled>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpSpecificRateP" class="col-sm-4 control-label">Specific Rate(P) :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtImpSpecificRateP" runat="server"  placeholder="Specific Rate" disabled>
                                        </div>
                                   
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtImpExemptDuty" class="col-sm-4 control-label">Exempt Duty :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtImpExemptDuty" runat="server" placeholder="Exempt Duty" disabled>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpSurchargeRate" class="col-sm-4 control-label">Surcharge Rate :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtImpSurchargeRate" runat="server" placeholder="Surcharge Rate" disabled>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpExciseRate" class="col-sm-4 control-label">Excise Rate :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtImpExciseRate" runat="server" placeholder="Excise Rate" disabled>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpExciseSpcRate" class="col-sm-4 control-label">Excise Spc Rate :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtImpExciseSpcRate" runat="server"  placeholder="Excise Spc Rate" disabled>
                                           </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtImpExemptExcise" class="col-sm-4 control-label">Exempt(Excise) :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtImpExemptExcise" runat="server" placeholder="Excise" disabled>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpValueRate" class="col-sm-4 control-label">Value Rate :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtImpValueRate" runat="server" placeholder="Value Rate" disabled>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpValueRateAmount" class="col-sm-4 control-label">Value Rate Amount :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtImpValueRateAmount" runat="server" placeholder="Value Rate Amount" disabled>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpFactoryNo" class="col-sm-4 control-label">Factory No :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtImpFactoryNo" runat="server"  placeholder="Factory No" disabled>
                                      </div>
                                   
                                    </div>
                               </div>

                               <div class="col-lg-6 col-md-6">
                                   <div class="form-group">
                                        <label for="dcboImpStatisticalCode" class="col-sm-4 control-label">Statistical Code</label>
                                           <div class="col-sm-8">
                                                <input class="form-control" id="txtImpStatisticalCode" runat="server"  placeholder="Statistical Code" disabled>
                                             
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpProductYear" class="col-sm-4 control-label">Product Year :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtImpProductYear" runat="server"  placeholder="Product Year" disabled>
                                           </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtImpSpeciticRate" class="col-sm-4 control-label">Specitic Rate :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtImpSpeciticRate" runat="server" placeholder="Specitic Rate" disabled>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpSpecificCal" class="col-sm-4 control-label">Specific Cal :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtImpSpecificCal" runat="server" placeholder="Specific Cal" disabled>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpExemptVat" class="col-sm-4 control-label">Exempt Vat :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control" id="txtImpExemptVat" runat="server"  placeholder="Exempt Vat" disabled>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpExciseNo" class="col-sm-4 control-label">Excise No :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtImpExciseNo" runat="server"  placeholder="Excise No" disabled>
                                           </div>
                                   
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtImpExciseRatePay" class="col-sm-4 control-label">Excise Rate Pay :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtImpExciseRatePay" runat="server" placeholder="Excise Rate Pay" disabled> 
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpExciseSpcRatePay" class="col-sm-4 control-label">Excise Spc Rate Pay :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtImpExciseSpcRatePay" runat="server" placeholder="Excise Spc Rate Pay" disabled>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpPriviege" class="col-sm-4 control-label">Priviege :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtImpPriviege" runat="server" placeholder="Priviege" disabled>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="dcboImpBrand" class="col-sm-4 control-label">Brand :</label>
                                         <div class="col-sm-8">
                                              <input class="form-control" id="txtImpBrand" runat="server" placeholder="Brand" disabled>
                                           </div>           
                                    </div>
                                     <div class="form-group" >
                                          <label class="col-sm-4 control-label">Currency :</label>
                                                                        
                                       <div class="col-md-4">
                                            <input class="form-control" id="txtImpCurrency" runat="server" placeholder="Currency" disabled>
                                                     
                                      </div>
                                
                                       <div class="col-md-4">   
                                            <input class="form-control" id="txtImpExchangeRate" runat="server" placeholder="Currency" disabled>
                                        </div>
                                       </div>
                                
                                      <div class="form-group">
                                        <label for="txtImpEstablishNo" class="col-sm-4 control-label">Establish No :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtImpEstablishNo" runat="server" placeholder="Establish No" disabled>
                                           </div>
                                      
                                    </div>
                               </div>
                            
                                    <!-- /.box-body -->
                          </div>
                          
                       </from>

                <!--/.col-lg-6 col-md-6--->
                 </div>
           <!--/.row-->
            </div>
         </div>
     <!-- /.post -->
       </div>
 <!------- /. Import Goods ------->

       <!-------- Export Goods --------->
     <div class="tab-pane" id="exportgoods">
                                <!-- Post -->
        <div class="post">
         <div class="row margin-bottom">

                <div class="col-lg-12 col-md-12">

                       <from class="form-horizontal">
                           <div class="box-body">   
                              <div class="form-group" >
                                     <label for="txtExpProductCode" class="col-sm-2 control-label">Exp. Product Code :</label>
                                 <div class="col-md-6">
                                     <input class="form-control" id="txtExpProductCode" runat="server" placeholder="Product Code" disabled>
                                 </div>
                                 <div class="col-md-2"></div>
                             </div> 
                                              
                             <div class="form-group" >
                                  <label for="txtImpDesc1" class="col-sm-2 control-label">Desc. (ENG) 1 :</label>
                               <div class="col-md-9" id="ExpDesc1">
                                  <input class="form-control" id="txtExpDesc1" runat="server" placeholder="Desc" disabled>
                               </div>
                             
                            </div> 
                               
                           <div class="form-group" >
                               <label for="txtExpDesc2" class="col-sm-2 control-label">Desc. (ENG) 2 :</label>
                                <div class="col-md-9" id="ExpDesc2">
                                    <input class="form-control" id="txtExpDesc2" runat="server" placeholder="Desc" disabled>
                                </div>
                              
                           </div> 
                                 
                          <div class="form-group" >
                              <label for="txtExpDesc3" class="col-sm-2 control-label">Desc. (ENG) 3 :</label>
                              <div class="col-md-9" id="ExpDesc3">
                                  <input class="form-control" id="txtExpDesc3" runat="server" placeholder="Desc" disabled>
                              </div>
                             
                          </div> 
                         <div class="form-group" >
                             <label for="txtExpProductAttribute1" class="col-sm-2 control-label">Attribute 1 :</label>
                                   <div class="col-sm-10">
                                        <input class="form-control" id="txtExpProductAttribute1" runat="server" placeholder="Desc. (TH)" disabled>
                                   </div>
                         </div>
                         
                         <div class="form-group">
                             <label for="txtExpProductAttribute2" class="col-sm-2 control-label">Attribute 2 :</label>
                                   <div class="col-sm-10">
                                             <input class="form-control" id="txtExpProductAttribute2" runat="server" placeholder=" Attribute" disabled>
                                        </div>
                      
                                    </div>

                               <div class="col-lg-6 col-md-6">
                                   <div class="form-group">
                                        <label for="dcboExpTariffSequence" class="col-sm-4 control-label">Tariff Sequence</label>
                                           <div class="col-sm-8">
                                                <input class="form-control" id="txtExpTariffSequence" runat="server" placeholder=" Attribute" disabled>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtExpCustomsProductCode" class="col-sm-4 control-label">H.S. Code</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtExpCustomsProductCode" runat="server"  placeholder="H.S." disabled>
                                        </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtExpFomulaNo" class="col-sm-4 control-label">Fomula No :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtExpFomulaNo" runat="server" placeholder="Fomula No" disabled>
                                        </div>
                      
                                    </div>
                                    
                                
                                      <div class="form-group">
                                        <label for="txtExpBOINo" class="col-sm-4 control-label">BOI No :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control" id="txtExpBOINo" runat="server"  placeholder="BOI No" disabled>
                                           </div>
                                      
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtExpDutyType" class="col-sm-4 control-label">Duty Type :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtExpDutyType" runat="server" placeholder="Duty Type" disabled>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpQtyCarton" class="col-sm-4 control-label">Qty./Carton :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtExpQtyCarton" runat="server" placeholder="Qty Carton" disabled>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtExpWeightCarton" class="col-sm-4 control-label">Weight/Carton :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtExpWeightCarton" runat="server" placeholder="Weight/Carton" disabled>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtExpValueRate" class="col-sm-4 control-label">Value Rate :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtExpValueRate" runat="server"  placeholder="Value Rate" disabled>
                                           </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtExpValueRateAmount" class="col-sm-4 control-label">Value Rate Amount :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtExpValueRateAmount" runat="server" placeholder="Value Rate Amount" disabled>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpFactoryNo" class="col-sm-4 control-label">Factory No :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtExpFactoryNo" runat="server" placeholder="Factory No" disabled>
                                        </div>
                      
                                    </div>
                                     
                               </div>
                               <div class="col-lg-6 col-md-6">
                               
                                      <div class="form-group">
                                        <label for="dcboExpTariffCode" class="col-sm-4 control-label">Tariff Code :</label>
                                           <div class="col-sm-8">
                                                <input class="form-control" id="txtExpTariffCode" runat="server" placeholder="Tariff Code" disabled>
                                             
                                           </div>
                                      
                                    </div>
                                     <div class="form-group">
                                        <label for="dcboExpStatisticalCode" class="col-sm-4 control-label">Statistical Code</label>
                                           <div class="col-sm-8">
                                               <input class="form-control" id="txtExpStatisticalCode" runat="server" placeholder="Statistical Code" disabled>
                                    
                                           </div>
                                      
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtImpSpeciticRate" class="col-sm-4 control-label">Specitic Rate :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="Text20" runat="server" placeholder="Specitic Rate" disabled>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpProductYear" class="col-sm-4 control-label">Product Year :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtExpProductYear" runat="server" placeholder="Product Year" disabled>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtExp19BisTranNo" class="col-sm-4 control-label">19 Bis TranNo :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control" id="txtExp19BisTranNo" runat="server"  placeholder="19 Bis TranNo" disabled>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtExpBondFormulaNo" class="col-sm-4 control-label">Bond Formula No :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtExpBondFormulaNo" runat="server"  placeholder="Bond Formula No" disabled>
                                           </div>
                                   
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtExpPriceForeight" class="col-sm-4 control-label">Price(Foreight) :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtExpPriceForeight" runat="server" placeholder="Foreight" disabled>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpQtyPallet" class="col-sm-4 control-label">QTY/PALLET :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtExpQtyPallet" runat="server" placeholder="QTY/PALLET " disabled>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpPriviege" class="col-sm-4 control-label">Priviege :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtPriviege" runat="server" placeholder="Priviege" disabled>
                                        </div>
                                      
                                    </div>

                           
                                     <div class="form-group" >
                                          <label class="col-sm-4 control-label">Currency :</label>
                                                                        
                                       <div class="col-md-4">
                                          <input class="form-control" id="txtExpCurrency" runat="server" placeholder="Currency" disabled>
                                                     
                                      </div>
                                
                                       <div class="col-md-4">   
                                            <input class="form-control" id="txtExpExchangeRate" runat="server" placeholder="Currency" disabled>
                                        </div>
                                       </div>
                                
                                      <div class="form-group">
                                        <label for="txtExpEstablishNo" class="col-sm-4 control-label">Establish No :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtExpEstablishNo" runat="server" placeholder="Establish No" disabled>
                                      </div>
                                      
                                    </div>
                               </div>
                               <!-- /.box-body -->
                             </div>
                        </from>
                  <!--/.col-lg-6 col-md-6--->
                     </div>
                <!--/.row-->
                  </div>
               </div>
              <!-- /.post -->
           </div>
            <!-----/ Export Goods----->

             <!--- Detailof Goods --->
         <div class="tab-pane" id="detailofgoods">
            <!-- Post -->
            <div class="post">
             <div class="row margin-bottom">
                <div class="col-lg-12 col-md-12">

                     <from class="form-horizontal">
                           <div class="box-body">

                            <fieldset class="col-md-12">
                                
                                <legend>Carton box dimension</legend>
                                
                                <div class="col-lg-6 col-md-6">
                                  <div class="form-group">
                                    <div class="col-md-4">
                                       <label for="txtProductUnit">Unit</label>
                                   </div>
                                   <div class="col-md-8">
                                        <input class="form-control" id="txtProductUnit" runat="server" placeholder="Unit" disabled>
                                    </div>
                            
                                 </div>
                                </div>
                                   
                                  <div class="col-md-12">
                                      <h4>Measurement</h4>
                                   </div>
                                           
                               <div class="col-lg-12 col-md-12 col-md-offset-2">
                                 <div class="form-group">
                              
                                   <div class="col-md-2">
                                       <label for="txtProductWidth">Width</label>
                                       <input class="form-control" id="txtProductWidth" runat="server" placeholder="Width" disabled>
                                  </div>
                                  
                                   <div class="col-md-2">
                                       <label for="txtProductHeight">Heigh</label>
                                       <input class="form-control" id="txtProductHeight" runat="server" placeholder="Height" disabled>
                                  </div>
                                     
                                   <div class="col-md-2">
                                       <label for="txtProductLeng">Leng</label>
                                       <input class="form-control" id="txtProductLeng" runat="server" placeholder="Leng" disabled>
                                  </div>
                                   <div class="col-md-2">
                                       <label for="txtProductVolume">Volume</label>
                                       <input class="form-control" id="txtProductVolume" runat="server" placeholder="Volume" disabled>
                                  </div>
                                    <div class="col-md-2 p-t-24">
                                       <input class="form-control" id="txtUnitofVolume" runat="server" placeholder="Volume" disabled>
                                       
                                  </div>
                                 </div>
                                   
                               </div>
                             
                         </fieldset>
                              
                     

                         <fieldset class="col-md-12">
                            <legend>Pallet Dimension</legend>
                                 <div class="col-lg-6 col-md-6">
                                  <div class="form-group">
                                    <div class="col-md-4">
                                       <label for="txtProductUnit">Unit</label>
                                   </div>
                                   <div class="col-md-8">
                                          <input class="form-control" id="txtPackageUnit" runat="server" placeholder="Unit" disabled>
                                       
                                    </div>                        
                                 </div>
                                </div>
                                   
                                  <div class="col-md-12">
                                      <h4>Measurement</h4>
                                   </div>
                                           
                               <div class="col-lg-12 col-md-12 col-md-offset-2">
                                 <div class="form-group">
                              
                                   <div class="col-md-2">
                                       <label for="txtPackageWidth">Width</label>
                                       <input class="form-control" id="txtPackageWidth" runat="server" placeholder="Width" disabled>
                                  </div>
                                  
                                   <div class="col-md-2">
                                       <label for="txtPackageHeigh">Heigh</label>
                                       <input class="form-control" id="txtPackageHeigh" runat="server" placeholder="Height" disabled>
                                  </div>
                                     
                                   <div class="col-md-2">
                                       <label for="txtPackageLenght">Leng</label>
                                       <input class="form-control" id="txtPackageLenght" runat="server" placeholder="Leng" disabled>
                                  </div>
                                   <div class="col-md-2">
                                       <label for="txtPackageCarton">No of Carton</label>
                                       <input class="form-control" id="txtPackageCarton" runat="server" placeholder="Volume" disabled>
                                  </div>
                                    
                                 </div>
                                   
                               </div>
                             <div class="col-lg-12 col-md-12">
                                  <div class="form-group">
                                    <div class="col-md-2">
                                       <label for="txtProductUnit" >Volume of Pallet :</label>
                                   </div>
                                   <div class="col-md-4">
                                      
                                       <input class="form-control" id="txtPackageVolume" runat="server" placeholder="Volume" disabled>
                                  
                                  </div>
                                   <div class="col-md-4">
                                        <input class="form-control" id="txtPackageofUnit" runat="server" placeholder="Volume" disabled>
                                        
                                         
                                   </div>            
                                 </div>   
                             </div>
                           
                           </fieldset>

                               <fieldset class="col-lg-12 col-md-12">
                                   <legend>Special Handing</legend>
                                   <div class="col-md-12 col-md-offset-2">
                                       <div class="form-group">
                                     <div class="col-md-8">
                                          <textarea class="form-control" id="txtRemarks" rows="6" runat="server" name="txtRemarks" placeholder="Remarks ..." disabled></textarea>
                                     </div>
                                     
                                    </div>  
                                   </div>
                                     
                               </fieldset>
                                              
                          </div>
                      
                     </from>
                     </div>
                <!--/.col-lg-6 col-md-6--->
                  </div>
                </div>
              </div>


          <!----/Detailof Goods----->

                            <!--- Asembly --->
                            <div class="tab-pane" id="assembly">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">
                                        <div class="col-lg-12 col-md-12">
                                            <from class="form-horizontal">
                           <div class="box-body">
                            
                               <div class="col-lg-6">
                                 <div class="form-group" >
                                   <label for="txtEAS" class="col-sm-3 control-label">EAS P/N :</label>
                                   <div class="col-md-8">
                                       <input class="form-control" id="txtEAS" runat="server" placeholder="EAS P/N" disabled>
                                   </div>
                           
                               </div>                
                                 
                               <div class="form-group">
                                   <label for="txtCustomer" class="col-sm-3 control-label">Customer P/N :</label>
                                       <div class="col-md-8">
                                           <input class="form-control" id="txtCustomer" runat="server" placeholder="Customer" disabled>
                                      </div>
                              </div> 
                             </div>
                               <div class="col-lg-6">
                                   <div class="form-group" >
                                  <label for="txtOwner" class="col-sm-3">Owner P/N :</label>
                                       <div class="col-md-8">
                                           <input class="form-control" id="txtOwner" runat="server" placeholder="Owner" disabled>
                                      </div>
                     
                                  </div> 
                                 
                                    <div class="form-group" >
                                        <label for="txtQty" class="col-sm-3">Quality :</label>
                                       <div class="col-md-8">
                                           <input class="form-control" id="txtQty" runat="server" placeholder="Quality" disabled>
                                      </div>
                                   </div> 
                                 
                               </div>
                               
                               
                            </div>
                          
                                    <!-- /.box-body -->
                          
                       </from>
                                            <!--/.col-lg-6 col-md-6--->
                                        </div>
                                        <!--/.row-->
                                    </div>
                                    <!-- /.post -->
                                </div>
                            </div>
                            <!----/ .Asembly----->



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
