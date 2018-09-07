<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterGoods.aspx.vb" MasterPageFile="~/Home.Master" Inherits="WMS.MasterGoods" %>

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
                       <div class="box-body">
                           <div class="col-xs-6">
                                <button class="btn btn-app btn-sm" id="btnAddHead" runat="server" onserverclick="btnAddHead_ServerClick"><i class="fa fa-inbox"></i>Add</button>
                                <button class="btn btn-app btn-sm" id="btnEditHead" runat="server" onserverclick="btnEditHead_ServerClick"><i class="fa fa-edit"></i>Edit</button>
                            </div>
                            <div class="col-xs-6 text-right">
                                <button runat="server" class="btn btn-app btn-sm" id="btnAddGoods" title="btnAddGoods" onserverclick="saveGoods_click" visible="false"><i class="fa fa-save"></i> Save</button>
                                <button class="btn btn-app btn-sm" id="btnSaveEditHead" runat="server" onserverclick="btnSaveEditHead_ServerClick" visible="false"><i class="fa fa-save"></i>Save Edit</button>
                            </div>
                                
                           </div>
                        <!-- /.box-header -->
               <div class="form-horizontal">
                     <div class="box-body">   
                         <div class ="col-lg-6 col-md-6">
                             <div class="form-group">
                                 <label for="txtProductCode" class="col-sm-4 control-label">Product Code :</label>
                                 <div class="col-sm-6">
                                     <input class="form-control input-sm" id="txtProductCode" runat="server" placeholder="Product Code" disabled="disabled" autocomplete="off"/>
                                 </div>
                                 <div class="col-sm-2">
                                     <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal"><i class="glyphicon glyphicon-search"></i></button>
                                 </div>
                             </div>
                                  <div class="form-group">
                                        <label for="txtCustomerPart" class="col-sm-4 control-label">Owner Part :</label>
                                           <div class="col-sm-8">
                                           <input class="form-control input-sm" id="txtCustomerPart" runat="server"  placeholder="Owner Part " autocomplete="off"/>
                                       </div>
                                    </div>
                                  </div>      
                                
                                <div class="col-lg-6 col-md-6">
                                    <div class="form-group">
                                        <label for="txtProductPO" class="col-sm-3 control-label">PO :</label>          
                                      <div class="col-sm-8">
                                         <input  class="form-control input-sm" id="txtProductPO" runat="server" placeholder="Product PO" autocomplete="off"/>
                                      </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtEndUserPart" class="col-sm-3 control-label">End User Part :</label>
                                    <div class="col-sm-8">
                                        <input class="form-control input-sm" id="txtEndUserPart" runat="server"  placeholder="End User Part" autocomplete="off" />
                                    </div>
                                    </div>
                                </div> 
                         <!--------- /.col-lg-6 col-md-6 ------------->           
                            </div>
                            <!-- /.box-body -->
                            
                         </div>
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
                        
                                               <div class="form-horizontal">

                                                      <div class="box-body">   
                                                           <div class="form-group" >
                                    
                                                               <label for="txtMinimunStock" class="col-sm-4 control-label">Minimun Stock</label>
                                       
                                                             <div class="col-sm-8">
                                                               <input class="form-control input-sm" id="txtMinimunStock" runat="server" placeholder="Minimun Stock" autocomplete="off"/>
                                                             </div>

                                                           </div>
                                    
                                                        <div class="form-group">
                                                                  <label for="txtAdjustment" class="col-sm-4 control-label">Adjustment</label>
                                      
                                                     <div class="col-sm-8">
                                                                  <input class="form-control input-sm" id="txtAdjustment" runat="server" placeholder="Adjustment" autocomplete="off"/>
                                                     </div>
                      
                                                    </div>
                                                       <div class="form-group">
                                                      <label for="txtDamageQty" class="col-sm-4 control-label">Damage Qty</label>
                                                     <div class="col-sm-8">
                                                          <input class="form-control input-sm" id="txtDamageQty" runat="server"  placeholder="Damage Qty" autocomplete="off"/>
                                                     </div>
                                                </div>

                                    <div class="form-group">
                                             <label for="txtAvailableQTY" class="col-sm-4 control-label">Available QTY</label>
                                       <div class="col-sm-8">
                                            <input class="form-control input-sm" id="txtAvailableQTY" runat="server"  placeholder="Available QTY" autocomplete="off"/>
                                       </div>
                                   
                                    </div>

                              
                                    <!-- /.box-body -->
                             </div>
                            <!-- /.box-header -->
                           
                       </div>
          <!--/.col-lg-6 col-md-6 stockqty--->
               
                    </div>
                 <!--/.row-->
                       
                </div>

               </div>
             <!-- /.post -->


            <!-- /.content -->
         <!-- /.box-header -->
                <div class="row">
                    <div class="col-lg-12 col-xs-12">

                                <asp:Repeater ID="Repeater1" runat="server">
                                    <HeaderTemplate>
                                        <table id="example1" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>ProductCode</th>
                                                    <th>OwnerPart</th>
                                                    <th>EndUserPart</th>
                                                    <th>ProductDescription</th>
                                                    <%--<th>OwnerCode</th>--%>
                                                    <th>MinimumStock</th>
                                                    <th>Adjustment</th>
                                                    <th>DamageQTY</th>
                                                    <th>AvailableQTY</th>                                                                                   
                                                    <%--<th>Edit/Delete</th>
                                                    <th>view</th>--%>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td><asp:Label ID="lblProductCode" runat="server" Text='<%# Bind("ProductCode")%>'></asp:Label></td>
                                            <td><asp:Label ID="lblOwnerPart" runat="server" Text='<%# Bind("OwnerPart")%>'></asp:Label></td>
                                            <td><asp:Label ID="lblEndUserPart" runat="server" Text='<%# Bind("EndUserPart")%>'></asp:Label></td>
                                            <td><asp:Label ID="lblProductDescription" runat="server" Text='<%# Bind("ProductDescription")%>'></asp:Label></td>
                                            <%--<td><asp:Label ID="lblOwnerCode" runat="server" Text='<%# Bind("OwnerCode")%>'></asp:Label></td>--%>
                                            <td><asp:Label ID="lblMinimumStock" runat="server" Text='<%# Bind("MinimumStock")%>'></asp:Label></td>
                                            <td><asp:Label ID="lblAdjustment" runat="server" Text='<%# Bind("Adjustment")%>'></asp:Label></td>
                                            <td><asp:Label ID="lblDamageQTY" runat="server" Text='<%# Bind("DamageQTY")%>'></asp:Label></td>
                                            <td><asp:Label ID="lblAvailableQTY" runat="server" Text='<%# Bind("AvailableQTY")%>'></asp:Label></td>                                                                                            
                                        <%--    <td class="text-center" >
                                                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="editGoods" CommandArgument='<%# Eval("ProductCode")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                <a class="btn btn-danger"><i class="fa fa-trash"></i></a>
                                            </td>
                                            <td class="text-center">
                                                <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="viewGoods" CommandArgument='<%# Eval("ProductCode")%>'><i class="fa fa-search-plus"></i></asp:LinkButton>
                                            </td>--%>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>                                               
                                                    <th>ProductCode</th>
                                                    <th>OwnerPart</th>
                                                    <th>EndUserPart</th>
                                                    <th>ProductDescription</th>
                                                    <%--<th>OwnerCode</th>--%>
                                                    <th>MinimumStock</th>
                                                    <th>Adjustment</th>
                                                    <th>DamageQTY</th>
                                                    <th>AvailableQTY</th>                                                                                   
                                                   <%-- <th>Edit/Delete</th>
                                                    <th>view</th>--%>
                                            </tr>
                                        </tfoot>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                 
                                 
                         
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->   
            </div>
          <!------- /.StockQTY ---------->

             <!------- Import Goods ------->
            <div class="tab-pane" id="importgoods">
                     <!-- Post -->
               <div class="post">
                  <div class="row margin-bottom">
                    <div class="col-lg-12 col-md-12">

                        <div class="form-horizontal">
                           <div class="box-body">   
                                              
                               <div class="form-group" >
                                     
                                     <label for="txtImpProductCode" class="col-sm-2 control-label">Imp. Product Code :</label>
                                       <div class="col-md-3">
         
                                             <input class="form-control input-sm" id="txtImpProductCode" runat="server" placeholder="Product Code" autocomplete="off"/>
                                      </div>
                                           <label for="dcboImpTariffCode" class="col-sm-2 control-label">Tariff Code :</label>
                                       <div class="col-md-5">   

                                           <asp:DropDownList ID="dcboImpTariffCode" CssClass="form-control input-sm" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                        </div>
                                       </div>                
                                 
                                    <div class="form-group" >
                                     
                                         <label for="txtImpDesc1" class="col-sm-2 control-label">Desc. (ENG) 1 :</label>
                                       <div class="col-md-9" id="ImpDesc1">
         
                                             <input class="form-control input-sm" id="txtImpDesc1" runat="server" placeholder="Desc" disabled="disabled" autocomplete="off"/>
                                      </div>
                                          
                                       <div class="col-md-1">   
                                           <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkImpEnable1" onclick="EnableDisableControls();"/> Enable
                                                 </label>
                                             </div>
                                       
                                        </div>
                                       </div> 

                                 
                                    <div class="form-group" >
                                     
                                         <label for="txtImpDesc2" class="col-sm-2 control-label">Desc. (ENG) 2 :</label>
                                       <div class="col-md-9" id="ImpDesc2">
                                             <input class="form-control input-sm" id="txtImpDesc2" runat="server" placeholder="Desc" disabled="disabled" autocomplete="off"/>
                                      </div>
                                          
                                       <div class="col-md-1">   
                                           <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkImpEnable2" onclick="chkImpEnable2();"/> Enable
                                                 </label>
                                             </div>
                                        </div>
                                      </div> 
                                 
                                  <div class="form-group">
                                         <label for="txtImpDesc3" class="col-sm-2 control-label">Desc. (ENG) 3 :</label>
                                   <div class="col-md-9" id="ImpDesc3">
                                       <input class="form-control input-sm" id="txtImpDesc3" runat="server" placeholder="Desc" disabled="disabled" autocomplete="off"/>
                                   </div>
                                    <div class="col-md-1">   
                                        <div class="checkbox">
                                            <label>
                                                <input type="checkbox" runat="server" id="chkImpEnable3" onclick="chkImpEnable3();"/> Enable
                                            </label>
                                        </div>
                                      </div>
                                   </div> 
                                   <div class="form-group" >
                                       <label for="txtImpProductAttribute1" class="col-sm-2 control-label">Product Desc. (TH) :</label>
                                    <div class="col-sm-10">
                                       <input class="form-control input-sm" id="txtImpProductAttribute1" runat="server" placeholder="Desc. (TH)" autocomplete="off"/>
                                    </div>
                                   </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpProductAttribute2" class="col-sm-2 control-label">Product Attribute:</label>  
                                      <div class="col-sm-10">
                                             <input class="form-control input-sm" id="txtImpProductAttribute2" runat="server" placeholder=" Attribute" autocomplete="off"/>
                                        </div>
                                    </div>

                               <div class="col-lg-6 col-md-6">
                                   <div class="form-group">
                                        <label for="dcboImpTariffSequence" class="col-sm-4 control-label">Tariff Sequence</label>
                                           <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboImpTariffSequence" CssClass="form-control input-sm" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                           </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpCustomsProductCode" class="col-sm-4 control-label">H.S. Code</label>
                                       <div class="col-sm-8">
                                          <input class="form-control input-sm" id="txtImpCustomsProductCode" runat="server"  placeholder="H.S." autocomplete="off"/>
                                       </div>
                                    </div>

                               <div class="form-group" >
                                        <label for="txtImpDutyType" class="col-sm-4 control-label">Duty Type</label>
                                         <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtImpDutyType" runat="server" placeholder="Duty Type" autocomplete="off"/>
                                        </div>
                               </div>
                                      <div class="form-group">
                                        <label for="txtImpValueRateP" class="col-sm-4 control-label">Value Rate(P) :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control input-sm" id="txtImpValueRateP" runat="server"  placeholder="Value Rate" autocomplete="off"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpSpecificRateP" class="col-sm-4 control-label">Specific Rate(P) :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control input-sm" id="txtImpSpecificRateP" runat="server"  placeholder="Specific Rate" autocomplete="off"/>
                                        </div>
                                   
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtImpExemptDuty" class="col-sm-4 control-label">Exempt Duty :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtImpExemptDuty" runat="server" placeholder="Exempt Duty" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpSurchargeRate" class="col-sm-4 control-label">Surcharge Rate :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtImpSurchargeRate" runat="server" placeholder="Surcharge Rate" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpExciseRate" class="col-sm-4 control-label">Excise Rate :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control input-sm" id="txtImpExciseRate" runat="server" placeholder="Excise Rate" autocomplete="off"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpExciseSpcRate" class="col-sm-4 control-label">Excise Spc Rate :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control input-sm" id="txtImpExciseSpcRate" runat="server"  placeholder="Excise Spc Rate" autocomplete="off"/>
                                           </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtImpExemptExcise" class="col-sm-4 control-label">Exempt(Excise) :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtImpExemptExcise" runat="server" placeholder="Excise" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpValueRate" class="col-sm-4 control-label">Value Rate :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtImpValueRate" runat="server" placeholder="Value Rate" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpValueRateAmount" class="col-sm-4 control-label">Value Rate Amount :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control input-sm" id="txtImpValueRateAmount" runat="server" placeholder="Value Rate Amount" autocomplete="off"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpFactoryNo" class="col-sm-4 control-label">Factory No :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control input-sm" id="txtImpFactoryNo" runat="server"  placeholder="Factory No" autocomplete="off"/>
                                      </div>
                                   
                                    </div>
                               </div>

                               <div class="col-lg-6 col-md-6">
                                   <div class="form-group">
                                        <label for="dcboImpStatisticalCode" class="col-sm-4 control-label">Statistical Code</label>
                                           <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboImpStatisticalCode" CssClass="form-control input-sm" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpProductYear" class="col-sm-4 control-label">Product Year :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control input-sm" id="txtImpProductYear" runat="server"  placeholder="Product Year" autocomplete="off"/>
                                           </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtImpSpeciticRate" class="col-sm-4 control-label">Specitic Rate :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtImpSpeciticRate" runat="server" placeholder="Specitic Rate" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpSpecificCal" class="col-sm-4 control-label">Specific Cal :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtImpSpecificCal" runat="server" placeholder="Specific Cal" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpExemptVat" class="col-sm-4 control-label">Exempt Vat :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control input-sm" id="txtImpExemptVat" runat="server"  placeholder="Exempt Vat" autocomplete="off"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpExciseNo" class="col-sm-4 control-label">Excise No :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control input-sm" id="txtImpExciseNo" runat="server"  placeholder="Excise No" autocomplete="off"/>
                                           </div>
                                   
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtImpExciseRatePay" class="col-sm-4 control-label">Excise Rate Pay :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtImpExciseRatePay" runat="server" placeholder="Excise Rate Pay " autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpExciseSpcRatePay" class="col-sm-4 control-label">Excise Spc Rate Pay :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtImpExciseSpcRatePay" runat="server" placeholder="Excise Spc Rate Pay" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpPriviege" class="col-sm-4 control-label">Priviege :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control input-sm" id="txtImpPriviege" runat="server" placeholder="Priviege"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="dcboImpBrand" class="col-sm-4 control-label">Brand :</label>
                                         <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboImpBrand" CssClass="form-control input-sm" runat="server" DataTextField="Description" DataValueField="Description"></asp:DropDownList>
                                           </div>
                                   
                                    </div>
                                     <div class="form-group" >
                                          <label class="col-sm-4 control-label">Currency :</label>
                                                                        
                                       <div class="col-md-4">
         
                                          <asp:DropDownList ID="cboImpCurrency" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>            
                                      </div>
                                
                                       <div class="col-md-4">   
                                            <input class="form-control input-sm" id="txtImpExchangeRate" runat="server" placeholder="Currency"  autocomplete="off"/>
                                        </div>
                                       </div>
                                
                                      <div class="form-group">
                                        <label for="txtImpEstablishNo" class="col-sm-4 control-label">Establish No :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control input-sm" id="txtImpEstablishNo" runat="server" placeholder="Establish No" autocomplete="off"/>
                                           </div>
                                      
                                    </div>
                               </div>
                            
                                    <!-- /.box-body -->
                          </div>
                          
                       </div>

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

                       <div class="form-horizontal">
                           <div class="box-body">   
                              <div class="form-group" >
                                     <label for="txtExpProductCode" class="col-sm-2 control-label">Exp. Product Code :</label>
                                 <div class="col-md-6">
                                     <input class="form-control input-sm" id="txtExpProductCode" runat="server" placeholder="Product Code" autocomplete="off"/>
                                 </div>
                                 <div class="col-md-2"></div>
                             </div> 
                                              
                             <div class="form-group" >
                                  <label for="txtImpDesc1" class="col-sm-2 control-label">Desc. (ENG) 1 :</label>
                               <div class="col-md-9" id="ExpDesc1">
                                  <input class="form-control input-sm" id="txtExpDesc1" runat="server" placeholder="Desc" disabled="disabled" autocomplete="off"/>
                               </div>
                                <div class="col-md-1">   
                                   <div class="checkbox">
                                      <label>
                                          <input type="checkbox" runat="server" id="chkExpEnable1" onclick="chkExpEnable1();"/> Enable
                                      </label>
                                  </div>
                               </div>
                            </div> 
                               
                           <div class="form-group" >
                               <label for="txtExpDesc2" class="col-sm-2 control-label">Desc. (ENG) 2 :</label>
                                <div class="col-md-9" id="ExpDesc2">
                                    <input class="form-control input-sm" id="txtExpDesc2" runat="server" placeholder="Desc" disabled="disabled" autocomplete="off"/>
                                </div>
                               <div class="col-md-1">
                                   <div class="checkbox">
                                       <label>
                                           <input type="checkbox" runat="server" id="chkExpEnable2" onclick="chkExpEnable2();"/> Enable
                                       </label>
                                   </div>
                               </div>
                           </div> 
                                 
                          <div class="form-group" >
                              <label for="txtExpDesc3" class="col-sm-2 control-label">Desc. (ENG) 3 :</label>
                              <div class="col-md-9" id="ExpDesc3">
                                  <input class="form-control input-sm" id="txtExpDesc3" runat="server" placeholder="Desc" disabled="disabled" autocomplete="off"/>
                              </div>
                              <div class="col-md-1">
                                  <div class="checkbox">
                                      <label>
                                          <input type="checkbox" runat="server" id="chkExpEnable3" onclick="chkExpEnable3();"/> Enable
                                      </label>
                                  </div>
                              </div>
                          </div> 
                         <div class="form-group" >
                             <label for="txtExpProductAttribute1" class="col-sm-2 control-label">Attribute 1 :</label>
                                   <div class="col-sm-10">
                                        <input class="form-control input-sm" id="txtExpProductAttribute1" runat="server" placeholder="Desc. (TH)" autocomplete="off"/>
                                   </div>
                         </div>
                         
                         <div class="form-group">
                             <label for="txtExpProductAttribute2" class="col-sm-2 control-label">Attribute 2 :</label>
                                   <div class="col-sm-10">
                                             <input class="form-control input-sm" id="txtExpProductAttribute2" runat="server" placeholder=" Attribute" autocomplete="off"/>
                                        </div>
                      
                                    </div>

                               <div class="col-lg-6 col-md-6">
                                   <div class="form-group">
                                        <label for="dcboExpTariffSequence" class="col-sm-4 control-label">Tariff Sequence</label>
                                           <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboExpTariffSequence" CssClass="form-control input-sm" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtExpCustomsProductCode" class="col-sm-4 control-label">H.S. Code</label>
                                         <div class="col-sm-8">
                                          <input class="form-control input-sm" id="txtExpCustomsProductCode" runat="server"  placeholder="H.S." autocomplete="off"/>
                                        </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtExpFomulaNo" class="col-sm-4 control-label">Fomula No :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtExpFomulaNo" runat="server" placeholder="Fomula No" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                    
                                
                                      <div class="form-group">
                                        <label for="txtExpBOINo" class="col-sm-4 control-label">BOI No :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control input-sm" id="txtExpBOINo" runat="server"  placeholder="BOI No" autocomplete="off"/>
                                           </div>
                                      
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtExpDutyType" class="col-sm-4 control-label">Duty Type :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtExpDutyType" runat="server" placeholder="Duty Type" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpQtyCarton" class="col-sm-4 control-label">Qty./Carton :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtExpQtyCarton" runat="server" placeholder="Qty Carton" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtExpWeightCarton" class="col-sm-4 control-label">Weight/Carton :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control input-sm" id="txtExpWeightCarton" runat="server" placeholder="Weight/Carton" autocomplete="off"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtExpValueRate" class="col-sm-4 control-label">Value Rate :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control input-sm" id="txtExpValueRate" runat="server"  placeholder="Value Rate" autocomplete="off"/>
                                           </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtExpValueRateAmount" class="col-sm-4 control-label">Value Rate Amount :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtExpValueRateAmount" runat="server" placeholder="Value Rate Amount" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpFactoryNo" class="col-sm-4 control-label">Factory No :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtExpFactoryNo" runat="server" placeholder="Factory No" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                     
                               </div>
                               <div class="col-lg-6 col-md-6">
                               
                                      <div class="form-group">
                                        <label for="dcboExpTariffCode" class="col-sm-4 control-label">Tariff Code :</label>
                                           <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboExpTariffCode" CssClass="form-control input-sm" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                           </div>
                                      
                                    </div>
                                     <div class="form-group">
                                        <label for="dcboExpStatisticalCode" class="col-sm-4 control-label">Statistical Code</label>
                                           <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboExpStatisticalCode" CssClass="form-control input-sm" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                           </div>
                                      
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtImpSpeciticRate" class="col-sm-4 control-label">Specitic Rate :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control input-sm" id="Text20" runat="server" placeholder="Specitic Rate" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpProductYear" class="col-sm-4 control-label">Product Year :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtExpProductYear" runat="server" placeholder="Product Year" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtExp19BisTranNo" class="col-sm-4 control-label">19 Bis TranNo :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control input-sm" id="txtExp19BisTranNo" runat="server"  placeholder="19 Bis TranNo" autocomplete="off"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtExpBondFormulaNo" class="col-sm-4 control-label">Bond Formula No :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control input-sm" id="txtExpBondFormulaNo" runat="server"  placeholder="Bond Formula No" autocomplete="off"/>
                                           </div>
                                   
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtExpPriceForeight" class="col-sm-4 control-label">Price(Foreight) :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtExpPriceForeight" runat="server" placeholder="Foreight" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpQtyPallet" class="col-sm-4 control-label">QTY/PALLET :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control input-sm" id="txtExpQtyPallet" runat="server" placeholder="QTY/PALLET " autocomplete="off"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpPriviege" class="col-sm-4 control-label">Priviege :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control input-sm" id="Text26" runat="server" placeholder="Priviege" autocomplete="off"/>
                                        </div>
                                      
                                    </div>

                           
                                     <div class="form-group" >
                                          <label class="col-sm-4 control-label">Currency :</label>
                                                                        
                                       <div class="col-md-4">
         
                                          <asp:DropDownList ID="cboExpCurrency" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>            
                                      </div>
                                
                                       <div class="col-md-4">   
                                            <input class="form-control input-sm" id="txtExpExchangeRate" runat="server" placeholder="Currency"  autocomplete="off"/>
                                        </div>
                                       </div>
                                
                                      <div class="form-group">
                                        <label for="txtExpEstablishNo" class="col-sm-4 control-label">Establish No :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control input-sm" id="txtExpEstablishNo" runat="server" placeholder="Establish No" autocomplete="off"/>
                                      </div>
                                      
                                    </div>
                               </div>
                               <!-- /.box-body -->
                             </div>
                        </div>
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

                     <div class="form-horizontal">
                           <div class="box-body">

                            <fieldset class="col-md-12">
                                
                                <legend>Carton box dimension</legend>
                                
                                <div class="col-lg-6 col-md-6">
                                  <div class="form-group">
                                    <div class="col-md-4">
                                       <label for="txtProductUnit">Unit</label>
                                   </div>
                                   <div class="col-md-8">
                                       
                                         <asp:DropDownList ID="cboProductUnit" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
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
                                       <input class="form-control input-sm" id="txtProductWidth" runat="server" placeholder="Width" autocomplete="off"/>
                                  </div>
                                  
                                   <div class="col-md-2">
                                       <label for="txtProductHeight">Heigh</label>
                                       <input class="form-control input-sm" id="txtProductHeight" runat="server" placeholder="Height" autocomplete="off"/>
                                  </div>
                                     
                                   <div class="col-md-2">
                                       <label for="txtProductLeng">length</label>
                                       <input class="form-control input-sm" id="txtProductLeng" runat="server" placeholder="length" autocomplete="off"/>
                                  </div>
                                   <div class="col-md-2">
                                       <label for="txtProductVolume">Volume</label>
                                       <input class="form-control input-sm" id="txtProductVolume" runat="server" placeholder="Volume" autocomplete="off"/>
                                  </div>
                                    <div class="col-md-2 p-t-24">   
                                       <asp:DropDownList ID="cboUnitofVolume" CssClass="form-control " runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
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
                                       
                                         <asp:DropDownList ID="cboPackageUnit" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
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
                                       <input class="form-control input-sm" id="txtPackageWidth" runat="server" placeholder="Width" autocomplete="off"/>
                                  </div>
                                  
                                   <div class="col-md-2">
                                       <label for="txtPackageHeigh">Heigh</label>
                                       <input class="form-control input-sm" id="txtPackageHeigh" runat="server" placeholder="Height" autocomplete="off"/>
                                  </div>
                                     
                                   <div class="col-md-2">
                                       <label for="txtPackageLenght">length</label>
                                       <input class="form-control input-sm" id="txtPackageLenght" runat="server" placeholder="length" autocomplete="off"/>
                                  </div>
                                   <div class="col-md-2">
                                       <label for="txtPackageCarton">No of Carton</label>
                                       <input class="form-control input-sm" id="txtPackageCarton" runat="server" placeholder="Volume" autocomplete="off"/>
                                  </div>
                                    
                                 </div>
                                   
                               </div>
                             <div class="col-lg-12 col-md-12">
                                  <div class="form-group">
                                    <div class="col-md-2">
                                       <label for="txtProductUnit" >Volume of Pallet :</label>
                                   </div>
                                   <div class="col-md-4">
                                      
                                       <input class="form-control input-sm" id="txtPackageVolume" runat="server" placeholder="Volume" autocomplete="off"/>
                                  
                                  </div>
                                   <div class="col-md-4">
                                        <asp:DropDownList ID="cboPackageofUnit" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                         
                                   </div>            
                                 </div>   
                             </div>
                           
                           </fieldset>

                               <fieldset class="col-lg-12 col-md-12">
                                   <legend>Special Handing</legend>
                                   <div class="col-md-12 col-md-offset-2">
                                       <div class="form-group">
                                     <div class="col-md-8">
                                          <textarea class="form-control input-sm" id="txtRemarks" rows="6" runat="server" name="txtRemarks" placeholder="Remarks ..." autocomplete="off"></textarea>
                                     </div>
                                     
                                    </div>  
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

                            <!--- Asembly --->
                            <div class="tab-pane" id="assembly">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">
                                        <div class="col-lg-12 col-md-12">
                                            <div class="form-horizontal">
                           <div class="box-body">
                            
                               <div class="col-lg-6">
                                 <div class="form-group" >
                                   <label for="txtEAS" class="col-sm-3 control-label">EAS P/N :</label>
                                   <div class="col-md-8">
                                       <input class="form-control input-sm" id="txtEAS" runat="server" placeholder="EAS P/N" disabled="disabled" autocomplete="off"/>
                                   </div>
                           
                               </div>                
                                 
                               <div class="form-group">
                                   <label for="txtCustomer" class="col-sm-3 control-label">Customer P/N :</label>
                                       <div class="col-md-8">
                                           <input class="form-control input-sm" id="txtCustomer" runat="server" placeholder="Customer" disabled="disabled" autocomplete="off"/>
                                      </div>
                              </div> 
                             </div>
                               <div class="col-lg-6">
                                   <div class="form-group" >
                                  <label for="txtOwner" class="col-sm-3">Owner P/N :</label>
                                       <div class="col-md-8">
                                           <input class="form-control input-sm" id="txtOwner" runat="server" placeholder="Owner" disabled="disabled" autocomplete="off"/>
                                      </div>
                     
                                  </div> 
                                 
                                    <div class="form-group" >
                                        <label for="txtQty" class="col-sm-3">Quality :</label>
                                       <div class="col-md-8">
                                           <input class="form-control input-sm" id="txtQty" runat="server" placeholder="Quality" disabled="disabled" autocomplete="off"/>
                                      </div>
                                   </div> 
                                 
                               </div>
                               
                                <div class="form-group" >

                                <div class="col-md-offset-9">
                                        <button type="button" runat="server" class="btn btn-primary btn-sm" id="btAdd"  disabled="disabled"/>Add</>
                                        <button type="button" runat="server" class="btn bg-olive  btn-block btn-sm" id="btModify"  disabled="disabled"/>Modify</>
                                        <button type="button" runat="server" class="btn btn-danger  btn-block btn-sm" id="btDel"  disabled="disabled"/>Delete</>
                                </div>
                                </div>
                        
                            </div>
                          
                                    <!-- /.box-body -->
                          
                       </div>
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
        

     <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
     <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">

        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Modal Header</h4>
        </div>

        <div class="modal-body">  
           
           <section class="content">

        <div class="row">
            <!-- left column -->
            <div class="col-lg-12 col-md-12 ">

                <!-- general form elements -->
            
                    <!-- /.box-header -->
                    <div class="row">

                        <div class="form-horizontal">
                            <div class="col-lg-12 col-md-12">
                                 <div class="box-body">   
                                            
                       
                                  <div class="form-group">
                                        <label for="txtGenCode" class="col-sm-3 control-label">รหัสชื่อลูกค้า :</label>
                                       
                                      <div class="col-sm-6">
                                           <input class="form-control input-sm" id="txtGenCode" runat="server"  placeholder="Name" autocomplete="off"/>
                                       </div>
                                       <div class="col-md-3">
                                            <label for="txtGenCode">ใช้3ตัวอักษร</label>
                                        </div>
                                    </div>
                                                 
                                    <div class="form-group" >
                                          <label class="col-sm-3 control-label">รหัสกลุ่มสินค้า :</label>
                                                                        
                                       <div class="col-md-6">
                                 
                                            <asp:DropDownList ID="cdbGroupGoods" CssClass="form-control input-sm" runat="server"  DataTextField="Description" DataValueField="Description"></asp:DropDownList>
                                      </div>
                                
                                       <div class="col-md-3">
                                             <input class="form-control input-sm" id="txtCodeGoods" runat="server" placeholder="Group" autocomplete="off"/>
                                        </div>
                                       </div>
                                     <div class="col-lg-4 col-md-4 col-md-offset-2">
                                        <div class="radio">
                                         <label>
                                              <asp:RadioButton ID="rbtEnable" runat="server" Text="ลูกค้าที่มีรหัสมา" onclick="EnableDisableTextBox();" GroupName="1" Checked="true"/>
                                         </label>
                                        </div>
                                     </div>
                                       <div class="col-lg-6 col-md-6">
                                           <div class="radio">
                                         <label>
                                              <asp:RadioButton ID="rbtDisable" runat="server" Text="ลูกค้าที่ไม่มีรหัสมา" onclick="EnableDisableTextBox();" GroupName="1" />           
                                         </label>
                                     </div>
                                     </div>
                              
                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>
                          
                        <!--/.row-->
                    </div>
                    <div class="box-header with-border">
                        <h3 class="box-title">ลูกค้าที่มีรหัสมา</h3>
                    </div>
                <div id="radio1">
                   <div class="row" >
                         <div class="col-lg-12 col-md-12">

                             
                                     <!-- form start -->
                         <div class="form-horizontal">
                            <div class="col-lg-12 col-md-12">
                                 <div class="box-body">   
                                            
                                <div class="form-group">
                                        <label for="txtGenCode" class="col-sm-3 control-label p-t-10">รหัสลูกค้า :</label>
                                      
                                      <div class="col-sm-6">
                                           <input class="form-control input-sm" id="txtCodeCustomers" runat="server" name="txtCodeCustomers" placeholder="Name"  autocomplete="off"/>
                                       </div>
                                     
                                    </div>
                                     <div class="col-md-offset-3">
                                         <p class="text-red">* หมายเหตุ ให้ใช้8ตัว โดยถ้ามี7ตัวให้ใส่ 0นำหน้า เช่า 0</p>  
                                     </div>
                                        
                                  <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>
                                
                  </div> 
                     
               </div>
             </div>
                     
                         <!--/.row-->

                    <div class="box-header with-border">
                        <h3 class="box-title">ลูกค้าที่ไม่มีรหัสมา</h3>
                    </div>
                <div id="radio2">
                    <div class="row" >
                          <div class="form-horizontal">
                            <div class="col-lg-12 col-md-12">
                                 <div class="box-body">   
                                            
                      <div class="form-group">
                                        <label for="txtGenCode" class="col-sm-3 control-label p-t-8">รหัสชื่อลูกค้า :</label>
                                       
                                      <div class="col-sm-6">
                                           <input class="form-control input-sm" id="txtNoCodeGoods" name="txtNoCodeGoods" runat="server"  placeholder="Name" disabled="disabled" autocomplete="off"/>
                                       </div>
                                         <div class="col-md-3">
                                            <label for="txtGenCode">ใส่ตัวเลข 4 ตัว</label>
                                        </div>
                                    </div>
                                     
                               
                                  <div class="form-group">
                                        <label for="txtGenCode" class="col-sm-3 control-label p-t-10">รหัสขนาด :</label>
                                       
                                      <div class="col-sm-6">
                                           <input class="form-control input-sm" id="txtCodeSize" runat="server"  placeholder="Name" disabled="disabled" autocomplete="off"/>
                                      </div>
                                    
                                </div>      
                                      <div class="col-md-offset-3">
                 
                                          <p class="text-red">* ใช้ 2 ตัวอักษรหรือตัวเลย</p>
                                     </div>

                                    <div class="form-group" >
                                          <label class="col-sm-3 control-label">รหัสสีของสินค้า :</label>
                                                                        
                                       <div class="col-md-6">
                                 
                                            <asp:DropDownList ID="cdbGroupColor" CssClass="form-control input-sm" runat="server"  DataTextField="Description" DataValueField="TypeID" disabled="disabled"></asp:DropDownList>
                                      </div>
                                
                                       <div class="col-md-3">
                                             <input class="form-control input-sm" id="txtCodeColor" runat="server" placeholder="Group" disabled="disabled" autocomplete="off"/>
                                        </div>
                                    </div>
                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>
                      </div>   
                </div>
             </div> 
          </div>
                     
                <!--/.col-lg-12 -->
         

            <!--/.col (right) -->
        
        <!-- /.row -->
    </section>
    <!-- /.content -->
            
        </div>    
  
                  
        <div class="modal-footer">
         <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnAddUser" title="btnAddUser" onserverclick="genCode_click">Submit</button>
         <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">Close</button>
        </div>
      </div>
      </div>
    </div>
  
<script type="text/javascript">
            $(document).ready(function () {
                EnableDisableControls();
            });
            function EnableDisableControls() {
                var status = $('#<%=chkImpEnable1.ClientID%>').is(':checked');
                if (status == true) {
                    $("#ImpDesc1").find("input, select, button, textarea").prop("disabled", false);
                }
                else {
                    $("#ImpDesc1").find("input, select, button, textarea").prop("disabled", true);
                }
            }
        </script>

        <script type="text/javascript">
            $(document).ready(function () {
                chkImpEnable2();
            });
            function chkImpEnable2() {
                var status = $('#<%=chkImpEnable2.ClientID%>').is(':checked');
                if (status == true) {
                    $("#ImpDesc2").find("input, select, button, textarea").prop("disabled", false);
                }
                else {
                    $("#ImpDesc2").find("input, select, button, textarea").prop("disabled", true);
                }
            }
        </script>

        <script type="text/javascript">
            $(document).ready(function () {
                chkImpEnable3();
            });
            function chkImpEnable3() {
                var status = $('#<%=chkImpEnable3.ClientID%>').is(':checked');
                if (status == true) {
                    $("#ImpDesc3").find("input, select, button, textarea").prop("disabled", false);
                }
                else {
                    $("#ImpDesc3").find("input, select, button, textarea").prop("disabled", true);
                }
            }
        </script>


        <script type='text/javascript'>
            $(document).ready(function () {
                chkExpEnable1();
            });
            function chkExpEnable1() {
                var status = $('#<%=chkExpEnable1.ClientID%>').is(':checked');
                if (status == true) {
                    $("#ExpDesc1").find("input, select, button, textarea").prop("disabled", false);
                }
                else {
                    $("#ExpDesc1").find("input, select, button, textarea").prop("disabled", true);
                }
            }
        </script>

        <script type='text/javascript'>
            $(document).ready(function () {
                chkExpEnable2();
            });
            function chkExpEnable2() {
                var status = $('#<%=chkExpEnable2.ClientID%>').is(':checked');
                if (status == true) {
                    $("#ExpDesc2").find("input, select, button, textarea").prop("disabled", false);
                }
                else {
                    $("#ExpDesc2").find("input, select, button, textarea").prop("disabled", true);
                }
            }
        </script>

        <script type='text/javascript'>
            $(document).ready(function () {
                chkExpEnable3();
            });
            function chkExpEnable3() {
                var status = $('#<%=chkExpEnable3.ClientID%>').is(':checked');
                if (status == true) {
                    $("#ExpDesc3").find("input, select, button, textarea").prop("disabled", false);
                }
                else {
                    $("#ExpDesc3").find("input, select, button, textarea").prop("disabled", true);
                }
               
            }
        </script>

        <script type='text/javascript'>
            function openModal() {
                $('#myModal').modal('show');
            }
        </script>
   
      <script type="text/javascript">
          function EnableDisableTextBox() {
              var status = document.getElementById('<%=rbtEnable.ClientID %>').checked;
             
            if (status == true) {
                document.getElementById('<%=txtCodeCustomers.ClientID%>').disabled = false;
                document.getElementById('<%=txtNoCodeGoods.ClientID%>').disabled = true;
                document.getElementById('<%=txtCodeSize.ClientID%>').disabled = true;
                document.getElementById('<%=txtCodeColor.ClientID%>').disabled = true;
                document.getElementById('<%=cdbGroupColor.ClientID%>').disabled = true;             
            } else if (status == false){
                document.getElementById('<%=txtCodeCustomers.ClientID%>').disabled = true;
                document.getElementById('<%=txtNoCodeGoods.ClientID%>').disabled = false;
                document.getElementById('<%=txtCodeSize.ClientID%>').disabled = false;
                document.getElementById('<%=txtCodeColor.ClientID%>').disabled = false;
                document.getElementById('<%=cdbGroupColor.ClientID%>').disabled = false;
               
            }
             
        }
    </script>

           
    </form>
</asp:Content>


