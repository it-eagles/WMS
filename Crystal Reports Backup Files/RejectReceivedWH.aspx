<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RejectReceivedWH.aspx.vb" Inherits="WMS.RejectReceivedWH" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Reject Received
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>WareHouse</a></li>     
            <li><a href="RejectReceivedWH.aspx">RejectReceived</a></li>
           
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">
        <style>
         h1{height:34px;}                                                                    
        </style>
        <div class="row">
            <!-- left column -->
            <div class="col-lg-12 col-md-12 ">
                <div class="box box-primary">
                <!-- general form elements -->
                
                     <%--------------------------------------------------------------Start Reject Issued----------------------------------------------------------%>
                <div class="row">

            <%-----------------------------------------------------Start HEAD BEFORE LEFT FORM-----------------------------------------------------------%>
                   <div class="col-lg-12 col-md-12 ">
                                            <!-- form start --> 
                             <%------------------------------------------------Start Find Job-------------------------------------------------------------------%>        
                                <div class="form-horizontal">
                                                   <fieldset>  <legend>Find</legend>
                                                      <div class="box-body">   
                                                          <div class="col-md-4 col-sm-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtJobNo" class="col-sm-4 control-label">Job No:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtJobNo" runat="server"/>
                                                                </div>
                                                                  </div>                                                                    
                                                          </div>

                                                          <div class="col-md-4"> 
                                                               <div class="form-group">
                                                                  <div class="col-sm-8">                                                                    
                                                                  <button type="submit" runat="server" class="btn btn-primary" id="btnFind" title="btnFind" onserverclick="btnFind_ServerClick">Find</button>
                                                             </div>
                                                                  </div>                                                                
                                                          </div>

                                                          <div class="col-md-4"> 
                                                                                                                               
                                                          </div>
                                                           
                                                                                                                                            
                                    <!-- /.box-body -->
                             </div>
                            <!-- /.box-header -->
                           </fieldset>
                       </div>
                       <%--------------------------------------------------------------End Find Job-----------------------------------------------------%>               
                                               <div class="form-horizontal">
                                                   <fieldset>  <legend>Input</legend>
                                                      <div class="box-body">   
                                                          <div class="col-md-4 col-sm-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtWHSite" class="col-sm-4 control-label">WH Site:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlWHSite" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtCusLOTNo" class="col-sm-4 control-label">Cus LOT No:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtCusLOTNo" runat="server"/>
                                                                </div>
                                                                  </div>   
                                                              <div class="form-group">
                                                                  <label for="txtEASPN" class="col-sm-4 control-label">EAS P/N:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlEASPN" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtProductDesc" class="col-sm-4 control-label">Product Desc:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                   <textarea class="form-control" rows="3" id="txtRamark" placeholder="Desc .."style="height: 34px; width: 552px;" ></textarea>
                                                                </div>
                                                                  </div>                                                                                                                             
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                   <label for="txtWHLocation" class="col-sm-4 control-label">WH Location:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlWHLocation" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                   <label for="txtCustWHFac" class="col-sm-4 control-label">Cust W/H Fac:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <asp:DropDownList ID="ddlCustWHFac" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>  
                                                              <div class="form-group">
                                                                   <label for="txtCustomerPN" class="col-sm-4 control-label">CustomerP/N:</label>                                       
                                                                <div class="col-sm-8">                                                                    
                                                                    <input class="form-control" id="txtCustomerPN" runat="server"/>
                                                                </div>
                                                                  </div>                                                             
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtENDCustomer" class="col-sm-4 control-label">ENDCustomer:</label>
                                                                 <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlENDCustomer" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtItemNo" class="col-sm-4 control-label">Item No:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtItemNo" runat="server"/>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtOwnerPN" class="col-sm-4 control-label">Owner P/N:</label>
                                                                 <div class="col-sm-8">
                                                                    <input class="form-control" id="txtOwnerPN" runat="server"/>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtMeasurement" class="col-sm-4 control-label">Measurement:</label>
                                                                 <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlMeasurement" CssClass="form-control" runat="server"></asp:DropDownList>
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
                  <label for="txtSpace" class="col-sm-4 control-label"></label>
                  <label for="txtWeight" class="col-sm-4 control-label">Weight:</label>
                  <label for="txtHight" class="col-sm-4 control-label">Hight:</label>
                </div>
                <div class="form-group">
                  <label for="txtDimension" class="col-sm-4 control-label">Dimension:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtWeight" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtHight" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtOrderNo" class="col-sm-4 control-label">Order No:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtOrderNo" runat="server"/>
                  </div>                  
                </div>
                <div class="form-group">
                  <label for="txtReceiveNo" class="col-sm-4 control-label">Receive No:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtReceiveNo" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                      <label>
                           <input type="checkbox" runat="server" id="chkNotUseDate" />Not Use Date
                      </label>
                  </div>
                  <label for="txtManufacturing" class="col-sm-4 control-label">Manufacturing:</label>
                  <div class="col-sm-4">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerManufacturing" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderManufacturing" runat="server" Enabled="True" TargetControlID="txtdatepickerManufacturing" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtReceiveDate" class="col-sm-4 control-label">Receive Date:</label>
                  <div class="col-sm-8">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerReceiveDate" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderReceiveDate" runat="server" Enabled="True" TargetControlID="txtdatepickerReceiveDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantity" class="col-sm-4 control-label">Quantity:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtQuantity" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlQuantity" CssClass="form-control" runat="server"></asp:DropDownList> 
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
                  <label for="txtLength" class="col-sm-4 control-label">Length:</label>
                  <label for="txtProductVolume" class="col-sm-4 control-label">Product Volume:</label>
                  <label for="txtPalletNo" class="col-sm-4 control-label">Pallet No:</label>
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                    <input class="form-control" id="txtLength" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtProductVolume" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPalletNo" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtStatus" class="col-sm-4 control-label">Status:</label>
                  <div class="col-sm-8">
                    <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>                  
                </div>
                <div class="form-group">
                  <label for="txtType" class="col-sm-4 control-label">Type:</label>
                  <div class="col-sm-8">                    
                    <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtExpiredDate" class="col-sm-4 control-label">Expired Date:</label>
                  <div class="col-sm-4">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerExpiredDate" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderExpiredDate" runat="server" Enabled="True" TargetControlID="txtdatepickerExpiredDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div> 
                <div class="form-group">
                  <label for="txtETAARRDate" class="col-sm-4 control-label">ETA/ARR Date:</label>
                  <div class="col-sm-4">                       
                       <asp:TextBox CssClass="form-control" ID="txtdatepickerETAARRDate" runat="server" placeholder="DD/MM/YYYY">
                       </asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtenderETAARRDate" runat="server" Enabled="True" TargetControlID="txtdatepickerETAARRDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtWeight2" class="col-sm-4 control-label">Weight:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtWeight2" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">                    
                    <asp:DropDownList ID="ddlWeight2" CssClass="form-control" runat="server"></asp:DropDownList> 
                  </div>
                </div>                                    
              </div>
              <!-- /.box-body -->
                    <%--</fieldset>--%>
            </div> 
            </div>        
             <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

            

             <%-----------------------------------------------------Start BUTTON FORM------------------------------------------------------------%>
                   <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->                        
                                               <div class="form-horizontal">
                                                   <%--<fieldset>  <legend>Job</legend>--%>
                                                      <div class="box-body">   
                                                          <div class="col-sm-6">
                                                              <div class="form-group">
                                                                  <div class="col-sm-4">                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnSelectAll" title="btnSelectAll" onserverclick="btnSelectAll_ServerClick">Select All</button>                                                                    
                                                                  </div>
                                                                  <div class="col-sm-4">                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnCencelSelectAll" title="btnCencelSelectAll" onserverclick="btnCencelSelectAll_ServerClick">Cencel Select All</button>                                                                    
                                                                  </div> 
                                                              </div>
                                                          </div>

                                                          <div class="col-sm-6">
                                                              <div class="form-group">
                                                                  <div class="col-sm-4">                                                                    
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnDelete" title="btnDelete" onserverclick="btnDelete_ServerClick">Delete</button>                                                                    
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
                        <%--------------------------------------------------------------END Reject Issued----------------------------------------------------------%>
                    
                    <!--/.box box-primary-->
                </div>
                <!--/.col-lg-12 -->
            </div>
            </div> 
            <!--/.col (right) -->
        
        <!-- /.row -->
    </section>
    <!-- /.content -->

</form>
 </asp:Content>