﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PartyMaster.aspx.vb" MasterPageFile="~/Home.Master" Inherits="WMS.PartyMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Party Master
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Master Files</a></li>
                <li><a href="HomeMain.aspx"><i class="active"></i>Add Party</a></li>               

            </ol>
        </section>
        
        <section class="content">
            
            <div class="row">
                <!-- left column -->
                <div class="col-lg-12 col-md-12">

                    <!-- general form elements -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <div class="form-group">
                                <div class="col-sm-2">
                                  <h3 class="box-title p-t-8">Add Party</h3>
                            </div>             
                            
                          </div>         
                        </div>
                       
                        <!-- /.box-header -->
               <div class="form-horizontal">
                   
                            <div class="box-footer text-right">
                                <button runat="server" class="btn btn-app btn-sm" id="btnAddParty" title="btnAddParty" onserverclick="btnAddParty_click"><i class="fa fa-save"></i> Save</button>
                           </div>
                         </div>
                    </div>
                </div>
               <!--------- /.col-lg-12 col-md-12 ------------->
            </div>
             <!--/.row-->
            <div class="row">
                <!-- left column -->

                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#information" data-toggle="tab">Information</a></li>
                            <li><a href="#address" data-toggle="tab">Address</a></li>
                            <li><a href="#amounnt" data-toggle="tab">Amounnt Guarantee</a></li>
                        </ul>

                        <div class="tab-content">

                            <!------- information ---------->
                            <div class="active tab-pane" id="information">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">

                                        <div class="col-lg-12 col-md-12">
                                            <!-- form start -->

                                            <div class="form-horizontal">
                                                <div class="form-group" >
                                     
                                                        <label for="txtImpProductCode" class="col-sm-2 control-label">Party Code :</label>
                                                    <div class="col-md-6">
         
                                                         <input class="form-control input-sm" id="txtPartyCode" runat="server" placeholder="Party Code" autocomplete="off"/>
                                                    </div>
                                      
                                                </div>
                                                <div class="form-group" >
                                     
                                                       <label for="txtImpDesc1" class="col-sm-2 control-label">Full Name :</label>
                                                
                                                    <div class="col-md-9" id="ImpDesc1">
         
                                                        <input class="form-control input-sm" id="txtFullName" runat="server" placeholder="FullName" autocomplete="off"/>
                                                    </div>
                                                </div> 
                                                <div class="form-group" >
                                                        <label class="col-sm-2 control-label">Local Name :</label>
                                                                        
                                                <div class="col-md-4">
         
                                                <input class="form-control input-sm" id="txtLocalCode" runat="server" placeholder="Local"  autocomplete="off"/>
                                              </div>
                                
                                              <div class="col-md-5">   
                                                    <input class="form-control input-sm" id="txtLocalName" runat="server" placeholder="Local" autocomplete="off" />
                                             </div>
                                            </div>
                                              
                                           <div class="form-group" >
                                                <label class="col-sm-2 control-label">Location :</label>
                                                                        
                                            <div class="col-md-2">
                                                    
                                                    <asp:DropDownList ID="cboLocationID" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code" >
                                                         <%--<asp:ListItem Text = "--Select Country--" Value = ""></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                
                                            </div>
                                
                                            <div class="col-md-2">   
                                                     <asp:DropDownList ID="cboCity" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code">
                                                         <%--<asp:ListItem Text = "--Select City--" Value = ""></asp:ListItem>--%>
                                                     </asp:DropDownList>
                                                        
                                            </div>
                                            
                                            <div class="col-md-6">   
                                             <div class="form-group">
                                                    <label for="txtImpCustomsProductCode" class="col-sm-3 control-label">Registration No :</label>
                                             <div class="col-sm-7">
                                                    <input class="form-control input-sm" id="txtRegistrationNo" runat="server"  placeholder="Registration No" autocomplete="off"/>
                                             </div>
                                            </div>
                                          </div>
                                         </div>
                                      
                                       <div class="form-group" >
                                          <label class="col-sm-2 control-label">Type :</label>
                                                                        
                                       <div class="col-md-2">
         
                                           <asp:DropDownList ID="cboPartyType" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                      </div>
                                
                                       <div class="col-md-2">   
                                             <input class="form-control input-sm" id="txtTypeName" runat="server"  placeholder="H.S." autocomplete="off"/>
                                        </div>
                                    <div class="col-md-6">   
                                             <div class="form-group">
                                        <label for="txtImpCustomsProductCode" class="col-sm-4 control-label">Commission to Sales :</label>
                                       <div class="col-sm-2">
                                         <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkCommissiontoSale"/>
                                                 </label>
                                             </div>
                                       </div>
                                    </div>
                                   </div>
                                 </div>
                                <div class="form-group">
                                        <label for="txtImpCustomsProductCode" class="col-sm-2 control-label">IATA Code :</label>
                                       <div class="col-sm-6">
                                          <input class="form-control input-sm" id="txtIATACode" runat="server"  placeholder="IATA Code" autocomplete="off"/>
                                       </div>
                                    </div>

                                 <div class="form-group">
                                     <label for="txtImpCustomsProductCode" class="col-sm-2 control-label">Remarks :</label>
                                     <div class="col-md-9">
                                          <textarea class="form-control input-sm" id="txtRemarks" rows="6" runat="server" name="txtRemarks" placeholder="Remarks ..." autocomplete="off"></textarea>
                                     </div>
                                 </div>
                                <div class="form-group">
                                     <label class="col-sm-2 control-label">Status :</label>
                                    <div class="col-lg-2 col-md-2">
                                   
                                         <div class="box-body">
                                              <div class="radio">
                                         <label>
                                             <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                             <asp:RadioButton runat="server" ID ="rdbConfirm_" Text="Confirm" GroupName="option1"/>
                                          </label>
                                           </div>
                                         </div>
                                        <!--/.box-body-->
                                    
                                     </div>
                                     <!--/.col-lg-2 col-md-2--->

                                      <div class="col-lg-2 col-md-2">
                                     <!-- form start -->
                                     
                                      <div class="box-body">

                                        <div class="radio">
                                         <label>
                                           <%--  <input type="radio" name="optionsRadios" runat="server" id ="rdbPending" value="option1"/> Pending--%>
                                             <asp:RadioButton runat="server" ID="rdbPending_" Text="Pending" GroupName="option1"/>
                                         </label>
                                        </div>
                                             
                                      </div>
                                       <!--/.box-body-->
                                    </div>
                                  <!--/.col-lg-2 col-md-2--->
                           
                                  
                                 <div class="col-lg-2 col-md-2">
                                     <!-- form start -->
                                
                                   <div class="box-body">

                                       <div class="radio">
                                         <label>
                                             <asp:RadioButton runat="server" ID="rdbBlacklisted_" Text="Blacklisted" GroupName="option1"/>
                                            <%-- <input type="radio" name="optionsRadios" runat="server" id ="rdbBlacklisted" value="option1"/>Blacklisted--%>
                                          </label>
                                      </div>
                                                 
                                     </div>
                                       <!--/.box-body-->
                                   
                                 </div>
                                      <!--/.col-lg-2 col-md-2--->

                                      <div class="col-lg-2 col-md-2">
                                     <!-- form start -->
                                   
                                         <div class="box-body">

                                           <div class="radio">
                                            <label>
                                                <asp:RadioButton runat="server" ID="rdbRevoke_" Text="Revoke" GroupName="option1"/>
                                              <%--  <input type="radio" name="optionsRadios" runat="server" id ="rdbRevoke" value="option1"/> Revoke--%>
                                            </label> 
                                           </div>                                            
                                         </div>
                                       <!--/.box-body-->
                                    
                                      </div>
                                     <!--/.col-lg-2 col-md-2--->
                                    </div>
                                    
                                      <div class="form-group">
                                                    <label for="txtImpCustomsProductCode" class="col-sm-2 control-label">Brance ID :</label>
                                          <div class="col-sm-6">
                                                <input class="form-control input-sm" id="txtMessageHubID" runat="server"  placeholder="Brance ID" autocomplete="off"/>
                                         </div>
                                     </div>
                                    <div class="form-group">
                                                    <label for="txtImpCustomsProductCode" class="col-sm-2 control-label">Full Thai Name :</label>
                                          <div class="col-sm-9">
                                                <input class="form-control input-sm" id="txtOtherSystemPartyID" runat="server"  placeholder="Full Thai Name" autocomplete="off"/>
                                         </div>
                                     </div>
                                      <div class="form-group">
                                                    <label for="txtImpCustomsProductCode" class="col-sm-2 control-label">TAX ID :</label>
                                          <div class="col-sm-6">
                                                <input class="form-control input-sm" id="txtFormID" runat="server"  placeholder="TAX ID" autocomplete="off"/>
                                         </div>
                                     </div>
                                          <div class="form-group">
                                              <label for="txtImpCustomsProductCode" class="col-sm-2 control-label">Role </label>
                                                <div class="col-sm-2">
                                                        <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkShipper"/> Shipper
                                                 </label>
                                             </div>
                                              <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkConsignee"/>Consignee
                                                 </label>
                                             </div>
                                             <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkBranch"/>Branch/Agent
                                                 </label>
                                             </div>
                                             <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkCoLoader"/>Co-Loader
                                                 </label>
                                             </div>
                                            <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkTrucking"/>Trucking
                                                 </label>
                                             </div>
                                            <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkShippingLine"/>Shipping Line
                                                 </label>
                                             </div>
                                              <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkVendor"/>Vendor
                                                 </label>
                                             </div>
                                             
                                               
                                          </div>
                                               <div class="col-md-2">
                                                    <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkContainerYard"/>Container Yard
                                                 </label>
                                             </div>
                                             <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkWarehouse"/>Warehouse
                                                 </label>
                                             </div>
                                                <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkBank"/>Bank
                                                 </label>
                                             </div>
                                             <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkFactory"/>Factory
                                                 </label>
                                             </div>
                                            <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkConference"/>Traiding Firm
                                                 </label>
                                             </div>
                                                     <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkBroker"/>Broker
                                                 </label>
                                             </div>
                                                     <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkAirLine"/>AirLine
                                                 </label>
                                             </div>
                                                       <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkEndCustomer"/>End Customer
                                                 </label>
                                             </div>
                                                </div>
                                               </div>
                                        </div>
                                     <!-------- /.from --------->

                                        </div>
                                        <!--/.col-lg-9 col-md-9 information --->

                                             

                                    </div>
                                    <!-----------/. row margin-bottom information ------------->
                                </div>
                                <!-- /.post information-->


                            </div>
                            <!------- /.information ---------->
                             <!------- address ------->
            <div class="tab-pane" id="address">
                     <!-- Post -->
               <div class="post">
                  <div class="row margin-bottom">
                    <div class="col-lg-12 col-md-12">

                        <div class="form-horizontal">
                           <div class="box-body">   
                                              
                                    
                                    <div class="form-group">
                                        <label for="txtImpProductAttribute2" class="col-sm-2 control-label">Data:</label>  
                                      <div class="col-sm-9">
                                            <h1>DataTable</h1>
                                        </div>
                                    </div>
                               <div class="form-group">
                                        <label for="dcboImpTariffSequence" class="col-sm-2 control-label">Party Type :</label>
                                           <div class="col-sm-6">
                                             <asp:DropDownList ID="cboAddressType" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                           </div>
                                    </div>
                                <div class="form-group">
                                        <label for="txtImpCustomsProductCode" class="col-sm-2 control-label">Address :</label>
                                       <div class="col-sm-4">
                                          <input class="form-control input-sm" id="txtAddress1" runat="server"  placeholder="Address" autocomplete="off"/>
                                       </div>
                                      <label for="txtImpDutyType" class="col-sm-1 control-label">Attn :</label>
                                         <div class="col-sm-4">
                                             <input class="form-control input-sm" id="txtAttn" runat="server" placeholder="Attn" autocomplete="off"/>
                                        </div>
                                </div>
                                 <div class="form-group" >
                                      <label for="txtImpExemptDuty" class="col-sm-2 control-label"></label>
                                         <div class="col-sm-4">
                                             <input class="form-control input-sm" id="txtAddress2" runat="server" autocomplete="off"/>
                                        </div>
                                      <label for="txtImpExemptDuty" class="col-sm-1 control-label">Tel :</label>
                                       
                                         <div class="col-sm-4">
                                             <input class="form-control input-sm" id="txtTel" runat="server" placeholder="Tel" autocomplete="off"/>
                                        </div>
                      
                               </div>
                                      <div class="form-group">
                                        <label for="txtImpValueRateP" class="col-sm-2 control-label"></label>
                                           <div class="col-sm-4">
                                              <input class="form-control input-sm" id="txtAddress3" runat="server"  autocomplete="off"/>
                                           </div>
                                       <label for="txtImpExemptDuty" class="col-sm-1 control-label">Fax :</label>
                                       
                                         <div class="col-sm-4">
                                             <input class="form-control input-sm" id="txtFax" runat="server" placeholder="Fax" autocomplete="off"/>
                                        </div>
                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpSpecificRateP" class="col-sm-2 control-label"></label>
                                         <div class="col-sm-4">
                                          <input class="form-control input-sm" id="txtAddress4" runat="server" autocomplete="off" />
                                        </div>
                                    <label for="txtImpExemptDuty" class="col-sm-1 control-label">Web :</label>
                                       
                                         <div class="col-sm-4">
                                             <input class="form-control input-sm" id="txtWebsite" runat="server" placeholder="Web" autocomplete="off"/>
                                        </div>
                      
                                    </div>

                                <div class="form-group">
                                        <label for="txtImpSpecificRateP" class="col-sm-2 control-label">Zip Code :</label>
                                         <div class="col-md-4">
                                          <input class="form-control input-sm" id="txtZipCode" runat="server"  placeholder="Zip Code" autocomplete="off"/>
                                        
                                    
                                         </div>
                                   
                                    <label for="txtImpExemptDuty" class="col-sm-1 control-label">E-Mail :</label>
                                       
                                         <div class="col-sm-4">
                                             <input class="form-control input-sm" id="txtEmail" runat="server" placeholder="E-Mail" autocomplete="off"/>
                                        </div>
                      
                                    </div>
                               <div class="form-group">
                                     <label for="txtImpSpecificRateP" class="col-sm-2 control-label">Area Code :</label>
                               <div class="col-md-4">
                                           <asp:DropDownList ID="cboAreaCode" CssClass="form-control input-sm" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
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
 <!------- /. address ------->

  <!-------- amounnt --------->
     <div class="tab-pane" id="amounnt">
                                <!-- Post -->
        <div class="post">
         <div class="row margin-bottom">

                <div class="col-lg-12 col-md-12">

                       <div class="form-horizontal">
                           <div class="box-body">   
                              <div class="form-group" >
                                     <label for="txtExpProductCode" class="col-sm-3 control-label">ยอดเงินค้ำประกันทั้งหมด :</label>
                                 <div class="col-md-6">
                                     <input class="form-control input-sm" id="txtAmountGuarantee" runat="server" placeholder="Product Code" value="0" autocomplete="off"/>
                                 </div>
                                   <label for="txtExpProductCode" class="col-sm-1 control-label">บาท</label>
                                
                             </div> 
                                              
                             <div class="form-group" >
                                  <label for="txtImpDesc1" class="col-sm-3 control-label">ยอดเงินที่ใช้ไป :</label>
                               <div class="col-md-6" id="ExpDesc1">
                                  <input class="form-control input-sm" id="txtAmountUsed" runat="server" disabled="disabled" value="0" autocomplete="off"/>
                               </div>
                             <label for="txtExpProductCode" class="col-sm-1 control-label">บาท</label>
                                
                            </div> 
                               
                           <div class="form-group" >
                               <label for="txtExpDesc2" class="col-sm-3 control-label">ยอดเงินคงเหลือ :</label>
                                <div class="col-md-6" id="ExpDesc2">
                                    <input class="form-control input-sm" id="txtBalance" runat="server" value="0" autocomplete="off"/>
                                </div>
                             <label for="txtExpProductCode" class="col-sm-1 control-label">บาท</label>
                                
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
            <!-----/ amounnt ----->
                         
                        </div>
                        <!------/. tab-content ------>
                    </div>
                    <!------ /. nav-tabs-custom ------>
                </div>
                <!----- /.col-lg-12 ------->
          
            <!--------/.row --------->
        </section>



    </form>
</asp:Content>


