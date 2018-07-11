<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreateRec.aspx.vb" Inherits="WMS.CreateRec" MasterPageFile="~/Home.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
                <li><a class="active"><i class="fa fa-file"></i>Receive Process</a></li>
                <li><a href="CreateRec.aspx"class="active">Create Rec. LOT</a></li>

            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->

                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#stockqty" data-toggle="tab">Master JOB</a></li>
                            <li><a href="#jobdetail" data-toggle="tab">Job Detail</a></li>
                            <li><a href="#invoice" data-toggle="tab">Invoice</a></li>
                            <li><a href="#importfile" data-toggle="tab">Import File</a></li>
                            <li><a href="#importfilenjr" data-toggle="tab">Import File NJR</a></li>
                        </ul>

                        <div class="tab-content">

                            <!------- StockQTY ---------->
                            <div class="active tab-pane" id="stockqty">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">

                                        <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->                        
                                               <div class="form-horizontal">
                                                   <fieldset>  <legend>Job</legend>
                                                      <div class="box-body">   
                                                          <div class="col-md-4 col-sm-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtJobno" class="col-sm-4 control-label">Job No:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtJobno" runat="server" placeholder="Job No"/>
                                                                </div>
                                                                  </div>
                                                                  <div class="form-group">
                                                                  <label for="txtJobsite" class="col-sm-4 control-label">Job Site:</label>                                      
                                                                 <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlJobsite" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                 </div>
                                                              </div>
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                   <label for="txtJobdate" class="col-sm-4 control-label">Job Date:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                                                    <asp:TextBox CssClass="form-control" ID="txtdatepickerJobdate" runat="server" placeholder="DD/MM/YYYY">
                                                                </asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtenderJobdate" runat="server" Enabled="True" TargetControlID="txtdatepickerJobdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                                  </div>
                                                                  <div class="form-group">
                                                                  <div class="checkbox col-sm-4">
                                                                     <label>
                                                                         <input type="checkbox" runat="server" id="chkNextmonth"/>NextMonth
                                                                     </label>
                                                                  </div>
                                                                      <label for="txtSaleman" class="col-sm-4 control-label">Sale Man:</label>                                      
                                                                 <div class="col-sm-4">
                                                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>                                                                     
                                                                 </div>          
                                                                 

                                                              </div>

                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtLotof" class="col-sm-4 control-label">LOT of:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlLotof" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                    <%--<input class="form-control" id="txtLotof" runat="server" placeholder="LOT of"/>--%>
                                                                 </div>
                                                                  </div>
                                                                  <div class="form-group">
                                                                    <%--<label for="txtSaleman" class="col-sm-4 control-label">Sale Man:</label>--%>                                      
                                                                 <div class="col-sm-8 col-sm-offset-4">
                                                                    <input class="form-control" id="txtsalemandis" runat="server" disabled="disabled"/>                                                                     
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
                 <!--/.row-->
                       
                </div>

               </div>
             <!-- /.post -->


            <!-- /.content -->
         <!-- /.box-header -->
                <div class="row">
                    
                    <div class="col-md-6">
          <!-- Horizontal Form -->
          

            <!-- form start -->
            <div class="form-horizontal">
                <fieldset>  <legend>Consignee Code</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtConsigneecode" class="col-sm-4 control-label">Consignee Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="txtConsigneecode" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameEngConsign" class="col-sm-4 control-label">Name(Eng):</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameEngConsign" runat="server"  placeholder="Name(Eng)"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress5" class="col-sm-4 control-label">Address5:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress5" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtEmail" class="col-sm-4 control-label">E-mail:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtEmail" runat="server"/>
                  </div>
                </div>
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        
          <!-- /.box -->

          <!-- general form Commodity -->
            <div class="form-horizontal">
                <fieldset><legend>Commodity</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtCommodity" class="col-sm-4 control-label">Commodity:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlCommodity" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantity" class="col-sm-5 control-label">Quantity PLT/Skid:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQuantity" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuan" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantityBox" class="col-sm-5 control-label">Quantity Box:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQuantityBox" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlquanbox" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtVolume" class="col-sm-5 control-label">Volume:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtVolume" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlvolume" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlvolume2" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtVolume2" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtShipto" class="col-sm-4 control-label">Ship To:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtShipto" runat="server"/>
                  </div>
                </div>

              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>


                        <div class="form-horizontal">
                <fieldset><legend>Actual</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtFlight" class="col-sm-3 control-label">Flight:</label>
                  <label for="txtDate" class="col-sm-3 control-label">Date:</label>
                  <label for="txtORGN" class="col-sm-3 control-label">ORGN:</label>
                  <label for="txtDSTN" class="col-sm-3 control-label">DSTN:</label>
                </div>
                <div class="form-group">
                  <div class="col-sm-3">
                    <input class="form-control" id="txtActual1" runat="server" placeholder="Actual"/>
                  </div>
                  <div class="col-sm-3">
                    <%--<input type="text" class="form-control pull-right"  id="datepickerActualDate1" />--%>
                    <asp:TextBox CssClass="form-control" ID="txtdatepickerActualDate1" runat="server" placeholder="DD/MM/YYYY">
                    </asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtenderActualDate1" runat="server" Enabled="True" TargetControlID="txtdatepickerActualDate1" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtORGN1" runat="server" placeholder="ORGN"/>
                  </div>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtDSTN1" runat="server" placeholder="DSTN"/>
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-3">
                    <input class="form-control" id="txtActual2" runat="server" placeholder="Actual"/>
                  </div>
                  <div class="col-sm-3">
                    <%--<input type="text" class="form-control pull-right" id="datepickerActualDate2"/>--%>
                    <asp:TextBox CssClass="form-control" ID="txtdatepickerActualDate2" runat="server" placeholder="DD/MM/YYYY">
                    </asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtenderActualDate2" runat="server" Enabled="True" TargetControlID="txtdatepickerActualDate2" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtORGN2" runat="server" placeholder="ORGN"/>
                  </div>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtDSTN2" runat="server" placeholder="DSTN"/>
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-3">
                    <input class="form-control" id="txtActual3" runat="server" placeholder="Actual"/>
                  </div>
                  <div class="col-sm-3">
                    <%--<input type="text" class="form-control pull-right" id="datepickerActualDate3"/>--%>
                    <asp:TextBox CssClass="form-control" ID="txtdatepickerActualDate3" runat="server" placeholder="DD/MM/YYYY">
                    </asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtenderActualDate3" runat="server" Enabled="True" TargetControlID="txtdatepickerActualDate3" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtORGN3" runat="server" placeholder="ORGN"/>
                  </div>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtDSTN3" runat="server" placeholder="DSTN"/>
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-3">
                    <input class="form-control" id="txtActual4" runat="server" placeholder="Actual"/>
                  </div>
                  <div class="col-sm-3">
                    <%--<input type="text" class="form-control pull-right" id="datepickerActualDate4"/>--%>
                    <asp:TextBox CssClass="form-control" ID="txtdatepickerActualDate4" runat="server" placeholder="DD/MM/YYYY">
                    </asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtenderActualDate4" runat="server" Enabled="True" TargetControlID="txtdatepickerActualDate4" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtORGN4" runat="server" placeholder="ORGN"/>
                  </div>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtDSTN4" runat="server" placeholder="DSTN"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtPickUp" class="col-sm-4 control-label">Pick Up Time:</label>
                  <div class="col-sm-4">                    
                      <div class="bootstrap-timepicker">

                  <div class="input-group">
                    <input type="text" class="form-control timepicker" id="txtTimePickUp"/>
                  <div class="input-group-addon">
                      <i class="fa fa-clock-o"></i>
                    </div>
                  </div>
                  <!-- /.input group -->

              </div>

                  </div>
                  <div class="col-sm-4">                    
                      <%--<input type="text" class="form-control pull-right" id="datepickerActualPickUp"/>--%>
                      <asp:TextBox CssClass="form-control" ID="txtdatepickerActualPickUp" runat="server" placeholder="DD/MM/YYYY">
                    </asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtenderdatepickerActualPickUp" runat="server" Enabled="True" TargetControlID="txtdatepickerActualPickUp" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtRamarkActual" class="col-sm-3 control-label">Remark:</label>
                  <div class="col-sm-9">
                    <textarea class="form-control" rows="3" id="txtRamarkActual" placeholder="Remark" style="height: 71px; width: 917px;"></textarea>
                  </div>                  
                </div>

              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>
        </div>
        <!--/.col (left) -->

                    <%------------------------------------------------------------Start Right Form------------------------------------------------%>
                    <div class="col-md-6">
          <!-- Horizontal Form -->                      
            <!-- form start -->
            <div class="form-horizontal">
                <fieldset>  <legend>Shipper Code</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtShippercode" class="col-sm-4 control-label">Shipper Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlShippercode" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameEngShipper" class="col-sm-4 control-label">Name(Eng):</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameEngShipper" runat="server"  placeholder="Name(Eng)"/>
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
                <fieldset><legend>Commodity</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtQuantityOfPart" class="col-sm-5 control-label">Quantity Of Part:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtQuantityOfPart" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlQuantityOfParty" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtWeight" class="col-sm-5 control-label">Weight:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtWeight" runat="server" value="0.0"/>
                  </div>
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlWeight" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtMAWB/BL/TWB" class="col-sm-4 control-label">MAWB/BL/TWB:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtMAWB_BL_TWB" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtFLT/Voy/TruckDate" class="col-sm-4 control-label">FLT/Voy/TruckDate:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtFLT_Voy_TruckDate" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtFreight" class="col-sm-4 control-label">Freight Forwarder:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlFreight" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtBilling" class="col-sm-4 control-label">Billing No.:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtBilling" runat="server"/>
                  </div>
                </div>

              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

                        <div class="form-horizontal">
                <fieldset><legend>Actual</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtETD" class="col-sm-3 control-label">ETD:</label>
                  <label for="txtETA" class="col-sm-3 control-label">ETA:</label>
                  <label for="txtPacket" class="col-sm-3 control-label">Packet:</label>
                  <label for="txtWeight" class="col-sm-3 control-label">Weight:</label>
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                    <div class="bootstrap-timepicker">
                  <div class="input-group">
                    <input type="text" class="form-control timepicker" id="txtpickupETD"/>
                  <div class="input-group-addon">
                      <i class="fa fa-clock-o"></i>
                    </div>
                  </div>
                  <!-- /.input group -->
              </div>
                  </div>
                  <div class="col-sm-4">
                      <div class="bootstrap-timepicker">
                  <div class="input-group">
                    <input type="text" class="form-control timepicker" id="txtpickupETA"/>
                  <div class="input-group-addon">
                      <i class="fa fa-clock-o"></i>
                    </div>
                  </div>
                  <!-- /.input group -->
              </div>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtPacket" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtWeightActual" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                      <div class="bootstrap-timepicker">
                  <div class="input-group">
                    <input type="text" class="form-control timepicker" id="txtpickupETD2"/>
                  <div class="input-group-addon">
                      <i class="fa fa-clock-o"></i>
                    </div>
                  </div>
                  <!-- /.input group -->
              </div>
                  </div>
                  <div class="col-sm-4">
                      <div class="bootstrap-timepicker">
                  <div class="input-group">
                    <input type="text" class="form-control timepicker" id="txtpickupETA2"/>
                  <div class="input-group-addon">
                      <i class="fa fa-clock-o"></i>
                    </div>
                  </div>
                  <!-- /.input group -->
              </div>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtPacket2" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtWeightActual2" runat="server" value="0"/>
                  </div>
                </div>
               <div class="form-group">
                  <div class="col-sm-4">
                      <div class="bootstrap-timepicker">
                  <div class="input-group">
                    <input type="text" class="form-control timepicker" id="txtpickupETD3"/>
                  <div class="input-group-addon">
                      <i class="fa fa-clock-o"></i>
                    </div>
                  </div>
                  <!-- /.input group -->
              </div>
                  </div>
                  <div class="col-sm-4">
                      <div class="bootstrap-timepicker">
                  <div class="input-group">
                    <input type="text" class="form-control timepicker" id="txtpickupETA3"/>
                  <div class="input-group-addon">
                      <i class="fa fa-clock-o"></i>
                    </div>
                  </div>
                  <!-- /.input group -->
              </div>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtPacket3" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtWeightActual3" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                      <div class="bootstrap-timepicker">
                  <div class="input-group">
                    <input type="text" class="form-control timepicker" id="txtpickupETD4"/>
                  <div class="input-group-addon">
                      <i class="fa fa-clock-o"></i>
                    </div>
                  </div>
                  <!-- /.input group -->
              </div>
                  </div>
                  <div class="col-sm-4">
                      <div class="bootstrap-timepicker">
                  <div class="input-group">
                    <input type="text" class="form-control timepicker" id="txtpickupETA4"/>
                  <div class="input-group-addon">
                      <i class="fa fa-clock-o"></i>
                    </div>
                  </div>
                  <!-- /.input group -->
              </div>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtPacket4" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-2">
                    <input class="form-control" id="txtWeightActual4" runat="server" value="0"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtArrivalToEAS" class="col-sm-4 control-label">Arrival to EAS:</label>
                  <div class="col-sm-4">
                      <div class="bootstrap-timepicker">
                  <div class="input-group">
                    <input type="text" class="form-control timepicker" id="txtArrivalToEAS"/>
                  <div class="input-group-addon">
                      <i class="fa fa-clock-o"></i>
                    </div>
                  </div>
                  <!-- /.input group -->
              </div>
                  </div>
                  <div class="col-sm-4">                    
                      <%--<input type="text" class="form-control pull-right" id="datepickerArrivalToEAS"/>--%>
                      <asp:TextBox CssClass="form-control" ID="txtdatepickerArrivalToEAS" runat="server" placeholder="DD/MM/YYYY">
                      </asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtenderArrivalToEAS" runat="server" Enabled="True" TargetControlID="txtdatepickerArrivalToEAS" Format="DD/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>

              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

        </div>
         <!-- right column -->


                    <!-- /.col -->
                </div>
                <!-- /.row -->   
            </div>
          <!------- /.MasterJob ---------->
                            <%-------------------------------------------------End MASTER JOB------------------------------------------------------------%>


                            <%-----------------------------------------------------Start JOB DETAIL-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="tab-pane" id="jobdetail">
                     <!-- Post -->
               <div class="row">
                    
                    <div class="col-md-6">
          <!-- Horizontal Form -->
          

            <!-- form start -->
            <div class="form-horizontal">
                <fieldset>  <legend>Delivery Place</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtDeliverycode" class="col-sm-4 control-label">Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlDeliveryCode" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameEngDelivery" class="col-sm-4 control-label">Name(Eng):</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameEngDelivery" runat="server"  placeholder="Name(Eng)"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1Delivery" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Delivery" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Delivery" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Delivery" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Delivery" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Delivery" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Delivery" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Delivery" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress5Delivery" class="col-sm-4 control-label">Address5:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress5Delivery" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtEmailDelivery" class="col-sm-4 control-label">E-mail:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtEmailDelivery" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtContractPersonDelivery" class="col-sm-4 control-label">Contract Person:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtContractPersonDelivery" runat="server"/>
                  </div>
                </div>
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        
          <!-- /.box -->

          <!-- general form Commodity -->
            <div class="form-horizontal">
                <fieldset><legend>Pick Up Place</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtCodePickUpPlace" class="col-sm-4 control-label">Pick Up Place:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlCodePickUpPlace" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNamePickUpPlace" class="col-sm-4 control-label">Name(Eng):</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNamePickUpPlace" runat="server"  placeholder="Name(Eng)"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1PickUpPlace" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1PickUpPlace" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2PickUpPlace" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2PickUpPlace" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3PickUpPlace" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3PickUpPlace" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4PickUpPlace" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4PickUpPlace" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress5PickUpPlace" class="col-sm-4 control-label">Address5:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress5PickUpPlace" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtEmailPickUpPlace" class="col-sm-4 control-label">E-mail:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtEmailPickUpPlace" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtContractPersonPickUpPlace" class="col-sm-4 control-label">Contract Person:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtContractPersonPickUpPlace" runat="server"/>
                  </div>
                </div>

              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>


              <div class="form-horizontal">
                <fieldset><legend>Customer Group</legend>
              <div class="box-body">
                  <div class="form-group">
                  <label for="txtCodeCustommerGroup" class="col-sm-4 control-label">Code Group:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlCodeCustommerGroup" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameCustommerGroup" class="col-sm-4 control-label">Name(Eng):</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameCustommerGroup" runat="server"  placeholder="Name(Eng)"/>
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
                <fieldset>  <legend>Customer</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtCustomercode" class="col-sm-4 control-label">Customer Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlCustomercode" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameEngCustomer" class="col-sm-4 control-label">Name(Eng):</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameEngCustomer" runat="server"  placeholder="Name(Eng)"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1Custommer" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1Custommer" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2Custommer" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2Custommer" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3Custommer" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3Custommer" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4Custommer" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4Custommer" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress5Custommer" class="col-sm-4 control-label">Address5:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress5Custommer" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtEmailCustommer" class="col-sm-4 control-label">E-mail:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtEmailCustommer" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtContractPersonCustommer" class="col-sm-4 control-label">Contract Person:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtContractPersonCustommer" runat="server"/>
                  </div>
                </div>
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        
          <!-- /.box -->

          <!-- general form Commodity -->
            <div class="form-horizontal">
                <fieldset><legend>End Customer</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtCodeEndCustomer" class="col-sm-4 control-label">End Customer Code:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlCodeEndCustomer" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameEndCustomer" class="col-sm-4 control-label">Name(Eng):</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtNameEndCustomer" runat="server"  placeholder="Name(Eng)"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress1EndCustomer" class="col-sm-4 control-label">Address1:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress1EndCustomer" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress2EndCustomer" class="col-sm-4 control-label">Address2:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress2EndCustomer" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtAddress3EndCustomer" class="col-sm-4 control-label">Address3:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress3EndCustomer" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress4EndCustomer" class="col-sm-4 control-label">Address4:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress4EndCustomer" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtAddress5EndCustomer" class="col-sm-4 control-label">Address5:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtAddress5EndCustomer" runat="server"/>
                  </div>
                </div>
                 <div class="form-group">
                  <label for="txtEmailEndCustomer" class="col-sm-4 control-label">E-mail:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtEmailEndCustomer" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtContractPersonEndCustomer" class="col-sm-4 control-label">Contract Person:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtContractPersonEndCustomer" runat="server"/>
                  </div>
                </div>

              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        
                           
         
                <div class="form-horizontal">
                <fieldset><legend>Reference</legend>
              <div class="box-body">
                  <div class="form-group">
                  <label for="txtReferenceInvoice" class="col-sm-4 control-label">Reference Invoice:</label>
                  <div class="col-sm-8">                                          
                      <input class="form-control" id="txtReferenceInvoice" runat="server"  placeholder="Reference Invoice"/> 
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtNameCustommerGroup" class="col-sm-4 control-label">Name(Eng):</label>
                  <div class="col-sm-4">
                  <asp:TextBox CssClass="form-control" ID="txtdatepickerReturnDate" runat="server" placeholder="DD/MM/YYYY">
                  </asp:TextBox>
                  <asp:CalendarExtender ID="CalendarExtenderReturnDate" runat="server" Enabled="True" TargetControlID="txtdatepickerReturnDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                  <div class="col-sm-4">
                  <asp:TextBox CssClass="form-control" ID="txtdatepickerReturnDate2" runat="server" placeholder="DD/MM/YYYY">
                  </asp:TextBox>
                  <asp:CalendarExtender ID="CalendarExtenderReturnDate2" runat="server" Enabled="True" TargetControlID="txtdatepickerReturnDate2" Format="dd/MM/yyyy"></asp:CalendarExtender>
                  </div>
                </div>

              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

        </div>
         <!-- right column -->


                   <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

                   <div class="col-lg-12 col-md-12 ">
                                            <!-- form start -->                        
                                               <div class="form-horizontal">
                                                   <fieldset>  <legend>IEAT</legend>
                                                      <div class="box-body">   
                                                          <div class="col-md-6 col-sm-6"> 
                                                              <div class="form-group">
                                                                  <label for="txtIEATNo" class="col-sm-4 control-label">IEAT No:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtIEATNo" runat="server" placeholder="IEAT  No"/>
                                                                </div>
                                                                  </div>
                                                                  <div class="form-group">
                                                                  <label for="txtIEATPermit" class="col-sm-4 control-label">IEAT Permit:</label>                                      
                                                                 <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlIEATPermit" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                 </div>
                                                              </div>
                                                              <div class="form-group">
                                                                  <label for="txtImportEntryNo" class="col-sm-4 control-label">Import Entry No:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtImportEntryNo" runat="server" placeholder="Import Entry No"/>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                       <label for="txtStatusIEAT1" class="col-sm-4 control-label">Status 1:</label> 
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlStatusIEAT1" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                 </div>
                                                              </div>
                                                          </div>

                                                          <div class="col-md-6"> 
                                                              <div class="form-group">
                                                                <div class="col-sm-4">
                                                                    <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%> 
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnGenIEATNo" title="btnGenIEATNo" >Submit</button> 
                                                                </div>
                                                                <div class="checkbox col-md-8">
                                                                    <label>
                                                                        <input type="checkbox" runat="server" id="chkGenerateIEATNo" onclick="chkExpEnable2();" />
                                                                        Request System Auto Generate IEAT No.
                                                                    </label>
                                                                </div>                                    
                                                                <%--<div class="col-sm-8">
                                                                    <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>
                                                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="DD/MM/YYYY">
                                                                </asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtdatepickerJobdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>--%>
                                                                  </div>
                                                                          <style>
                                                                              h1{height:34px;}                                                                             
                                                                          </style>
                                                                           <h1></h1>
                                                                  <div class="form-group">
                                                                       <label for="txtImportEntryDate" class="col-sm-4 control-label">Import Entry Date:</label> 
                                                                <div class="col-md-8">
                                                                    <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                                                    <asp:TextBox CssClass="form-control" ID="txtdatepickerImportEntryDate" runat="server" placeholder="DD/MM/YYYY">
                                                                </asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtenderImportEntryDate" runat="server" Enabled="True" TargetControlID="txtdatepickerImportEntryDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                </div>
                                                              </div>
                                                                <div class="form-group">
                                                                       <label for="txtStatusIEAT2" class="col-sm-4 control-label">Status 2:</label> 
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlStatusIEAT2" CssClass="form-control" runat="server"></asp:DropDownList>
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

                    <!-- /.col -->
                </div>
     <!-- /.post -->
       </div>
 <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End Job Detail-------------------------------------------------------%>



                            <%--------------------------------------------------------------Start Invoice----------------------------------------------------------%>
       <!-------- Export Goods --------->
     <div class="tab-pane" id="invoice">
                                <!-- Post -->
        <div class="row">
                    <%--------------------------------------------------------------------Start Left Form---------------------------------------------%>
                    <div class="col-md-6">
          <!-- Horizontal Form -->         
            <!-- form start -->
            <div class="form-horizontal">
                <fieldset>  <legend>Invoice</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtInvoiceNo" class="col-sm-4 control-label">Invoice No:</label>
                  <div class="col-sm-8">                    
                      <asp:DropDownList ID="ddlInvoiceNo" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtProductCodeInvoice" class="col-sm-3 control-label">Product Code:</label>
                  <div class="col-sm-4">
                    <asp:DropDownList ID="ddlProductCodeInvoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <label for="txtPONoProductCode" class="col-sm-2 control-label">PO No:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtPONoProductCode" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantityInvoice" class="col-sm-3 control-label">Quantity:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtQuantityInvoice" runat="server" value="0"/>
                  </div>                 
                  <div class="col-sm-5">
                    <asp:DropDownList ID="ddlQuantityInvoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtWeightInvoice" class="col-sm-3 control-label">Weight:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtWeightInvoice" runat="server" value="0"/>
                  </div>                 
                  <div class="col-sm-5">
                    <asp:DropDownList ID="ddlWeightInvoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtRamarkInvoice" class="col-sm-3 control-label">Remark:</label>
                  <div class="col-sm-9">
                    <textarea class="form-control" rows="3" id="txtRamarkInvoice" placeholder="Remark" style="height: 34px; width: 917px;"></textarea>
                  </div>                  
                </div>
                 <div class="form-group">
                  <label for="txtShipmentInvoice" class="col-sm-3 control-label">Shipment:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtShipmentInvoice" runat="server"/>
                  </div>                 
                  <label for="txtItemNoInvoice" class="col-sm-2 control-label">Item No:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtItemNoInvoice" runat="server"/>
                  </div> 
                </div>
                 <div class="form-group">
                  <label for="txtMeasurementInvoice" class="col-sm-4 control-label">Measurement:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtWidthInvoice" runat="server" placeholder="Width"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtHeightInvoice" runat="server" placeholder="Height"/>
                  </div>
                </div>
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        
          <!-- /.box -->

          <!-- general form Commodity -->
            <div class="form-horizontal">
                <fieldset><legend>Currency</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtCurrencyInvoice" class="col-sm-4 control-label">Currency:</label>
                  <label for="txtExchangeRateInvoice" class="col-sm-4 control-label">Exchange Rate:</label>
                  <label for="txtPriceForeignInvoice" class="col-sm-4 control-label">@Price(Foreign):</label>                  
                </div>
                <div class="form-group">
                  <div class="col-sm-4">                    
                      <asp:DropDownList ID="ddlCurrencyInvoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtExchangeRateInvoice" runat="server"  value="0.0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPriceForeignInvoice" runat="server"  value="0.0"/>
                  </div>
                </div> 
                <div class="form-group">
                  <div class="col-sm-6">
                      <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%> 
                      <button type="submit" runat="server" class="btn btn-primary" id="btnSaveInvoice" title="btnSaveInvoice" >Save Inv.</button> 
                  </div>
                  <div class="col-sm-6">
                      <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%> 
                      <button type="submit" runat="server" class="btn btn-default" id="btnModifyInvoice" title="btnModifyInvoice" >Modify Inv.</button> 
                  </div>                 
                </div> 
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>


              <div class="form-horizontal">
                <fieldset><legend>Import Flight</legend>
              <div class="box-body">
                  <div class="form-group">
                  <label for="txtFlightNoInvoice" class="col-sm-4 control-label">Flight No:</label>
                  <div class="col-sm-8">                    
                      <input class="form-control" id="txtFlightNo" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtFlightDateInvoice" class="col-sm-4 control-label">Flight Date:</label>
                  <div class="col-sm-8">                    
                      <asp:TextBox CssClass="form-control" ID="txtdatepickerFlightDateInvoice" runat="server" placeholder="DD/MM/YYYY">
                      </asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtenderFlightDateInvoice" runat="server" Enabled="True" TargetControlID="txtdatepickerFlightDateInvoice" Format="DD/MM/yyyy"></asp:CalendarExtender>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtQuantity_PLT_Skid_Invoice" class="col-sm-4 control-label">Quantity PLT/SKID:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtQuantity_PLT_Skid_Invoice" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-4">
                    <asp:DropDownList ID="ddlQuantity_PLT_Skid_Invoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group"> 
                    <div class="col-sm-4">
                    <asp:DropDownList ID="ddlQuantity_PLT_Skid_Invoice2" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                    <div class="col-sm-8">
                    <input class="form-control" id="txtQuantity_PLT_Skid_Invoice2" runat="server" value="0"/>
                  </div>
                </div>
                <div class="form-group"> 
                    <div class="col-sm-4 col-sm-offset-4">
                        <button type="submit" runat="server" class="btn btn-primary" id="btnSaveFlightNoInvoice" title="btnSaveFlightNoInvoice" >Save Flight No</button> 
                    </div>
                    <div class="col-sm-4 ">
                        <button type="submit" runat="server" class="btn btn-warning" id="btnDeleteFlightNoInvoice" title="btnDeleteFlightNoInvoice" >Delete Flight No</button> 
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
                <fieldset>  <legend>Invoice</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtDataInvoice" class="col-sm-4 control-label">Data Invoice:</label>
                  <div class="col-sm-8">                    
                      <asp:TextBox CssClass="form-control" ID="txtdatepickerDataInvoice" runat="server" placeholder="DD/MM/YYYY">
                      </asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtenderDataInvoice" runat="server" Enabled="True" TargetControlID="txtdatepickerDataInvoice" Format="DD/MM/yyyy"></asp:CalendarExtender>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtProductNameInvoice" class="col-sm-4 control-label">Product Name:</label>
                  <div class="col-sm-8">
                    <input class="form-control" id="txtProductNameInvoice" runat="server"/>
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtPallet_SKIDInvoice" class="col-sm-3 control-label">Pallet/SKID:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPallet_SKIDInvoice" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-5">
                    <asp:DropDownList ID="ddlPallet_SKIDInvoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                <div class="form-group">
                  <label for="txtBoxInvoice" class="col-sm-3 control-label">Box:</label>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtBoxInvoice" runat="server" value="0"/>
                  </div>
                  <div class="col-sm-5">
                    <asp:DropDownList ID="ddlBoxInvoice" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                </div>
                
                  <h1></h1>
                  <%--<h1></h1>--%>

                 <div class="form-group">
                  <label for="txtUnitDimension" class="col-sm-4 control-label">UnitDimension:</label>
                  <div class="col-sm-3">
                    <asp:DropDownList ID="ddlUnitDimension" CssClass="form-control" runat="server"></asp:DropDownList>  
                  </div>
                  <label for="txtPalletDimensionInvoice" class="col-sm-2 control-label">Pallet:</label>
                  <div class="col-sm-3">
                    <input class="form-control" id="txtPalletDimensionInvoice" runat="server" value="0"/>
                  </div>
                </div>                 
                 <div class="form-group">
                  <div class="col-sm-4">
                    <input class="form-control" id="txtLenghtInvoice" runat="server" placeholder="Lenght"/>
                  </div>
                  <label for="txtEntryItemNoInvoice" class="col-sm-4 control-label">EntryItemNo:</label>                  
                  <div class="col-sm-4">
                    <input class="form-control" id="txtEntryItemNoInvoice" runat="server"/>
                  </div>
                </div>
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        
          <!-- /.box -->

          <!-- general form Commodity -->
            <div class="form-horizontal">
                <fieldset><legend>Currency</legend>
              <div class="box-body">
                <div class="form-group">
                  <label for="txtPriceBathInvoice" class="col-sm-4 control-label">@Price(Bath):</label>
                  <label for="txtAmountForeignInvoice" class="col-sm-4 control-label">Amount(Foreign):</label>
                  <label for="txtAmountBathInvoice" class="col-sm-4 control-label">Amount(Bath):</label>                  
                </div>
                <div class="form-group">
                  <div class="col-sm-4">
                    <input class="form-control" id="txtPriceBathInvoice" runat="server"  value="0.0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtAmountForeignInvoice" runat="server"  value="0.0"/>
                  </div>
                  <div class="col-sm-4">
                    <input class="form-control" id="txtAmountBathInvoice" runat="server"  value="0.0"/>
                  </div>
                </div>
                <div class="form-group">
                     <div class="col-sm-6">
                      <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%> 
                      <button type="submit" runat="server" class="btn btn-warning" id="btnDeleteInvoice" title="btnDeleteInvoice" >Delete Inv.</button> 
                  </div>
                     <div class="col-sm-6">
                      <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%> 
                      <button type="submit" runat="server" class="btn btn-danger" id="btnDeleteAllInvoice" title="btnDeleteAllInvoice" >Delete Inv. All</button> 
                  </div>  
                </div>          
              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>        
                           
         
                <div class="form-horizontal">
                <fieldset><legend>Export</legend>
              <div class="box-body">
                  <div class="form-group">                 
                  <div class="col-sm-8">                                          
                      <input class="form-control" id="txtQTYExportInvoice" runat="server"  placeholder="0"/> 
                  </div>
                  <div class="col-sm-4">
                      <%--<button runat="server" class="btn-primary" id="btnGenIEATNo" title="btnGenIEATNo">Generate </button>--%> 
                      <button type="submit" runat="server" class="btn btn-primary" id="btnSumQTYInvoice" title="btnSumQTYInvoice" >Sum QTY</button> 
                  </div> 
                </div>
                <div class="form-group">                  
                  <div class="col-sm-8">
                  
                  </div>
                  <div class="col-sm-4">
                     <button type="submit" runat="server" class="btn btn-primary" id="btnSaveToPrepairInvoice" title="btnSaveToPrepairInvoice" >Save To Prepair</button> 
                  </div>
                </div>
                <div class="form-group">                  
                  <div class="col-sm-8">
                  
                  </div>
                  <div class="col-sm-4">
                     <button type="submit" runat="server" class="btn btn-soundcloud" id="btnExportCSVFileInvoice" title="btnExportCSVFileInvoice" >Export csv File   </button> 
                  </div>
                </div>
                <div class="form-group">                  
                  <div class="col-sm-8">
                  
                  </div>
                  <div class="col-sm-4">
                     <button type="submit" runat="server" class="btn btn-success" id="btnSaveToConfirmNJRCInvoice" title="btnSaveToConfirmNJRCInvoice" >Save To Confirm NJRC</button> 
                  </div>
                </div>

              </div>
              <!-- /.box-body -->
                    </fieldset>
            </div>

        </div>
         <!-- right column -->


                   <%--------------------------------------------------------------------End Right Form------------------------------------------------------%>

                    <!-- /.col -->
                </div>
              <!-- /.post -->
           </div>
            <!-----/ Export Goods----->

             <%----------------------------------------------------------------------End Invoice Tab--------------------------------------------------------------%>


                <%----------------------------------------------------------------------Start ImportFile--------------------------------------------------------%>
             <!--- Detailof Goods --->
         <div class="tab-pane" id="importfile">
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
                                  <label for="txtSelectFileForImport" class="col-sm-4 control-label">Select File For Import:</label>
                                  <div class="col-sm-4">
                                    <input type="file" class ="form-control" id="txtSelectFileForImport_Import" runat="server"/>     
                                  </div>                                  
                                  <div class="col-sm-4">
                                    <button type="submit" runat="server" class="btn btn-success" id="btnImport_Import" title="btnImport_Import" >Import</button> 
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
                                <legend>File</legend>
                               <div class="col-lg-12 col-md-12">
                                   
                                  <div class="form-group">
                                   <div class="col-sm-8">
                                   
                                   </div>
                                   <div class="col-sm-4">
                                   <button type="submit" runat="server" class="btn btn-success" id="btnSaveToInvoice_Import" title="btnSaveToInvoice_Import" >Save To Invoice</button> 
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
                            <%---------------------------------------------------------------End Import File Tab----------------------------------------------%>




                            <%-------------------------------------------------------------Start Import File NJR Tab-------------------------------------------------%>
                            <!--- Asembly --->
                            <div class="tab-pane" id="importfilenjr">
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
                                                      <label for="txtSelectFileForImport" class="col-sm-4 control-label">Select File For Import:</label>
                                                      <div class="col-sm-4">
                                                        <input type="file" class ="form-control" id="txtSelectFileForImport_ImportFileNJR" runat="server"/>     
                                                      </div>                                  
                                                      <div class="col-sm-4">
                                                        <%--<button type="submit" runat="server" class="btn btn-success" id="btnImport_ImportFileNJR" title="btnImport_Import" >Import</button>--%> 
                                                      </div>
                                                    </div>                                     
                                                   </div>                             
                                             </fieldset>                        
                                            </div>                          
                                    <!-- /.box-body -->                          
                                            </div>
                                            <!--/.col-lg-6 col-md-6--->
                                            <div class="form-horizontal">
                                               <div class="box-body">
                                                <fieldset class="col-md-12">
                                                    <legend>Import EntryItemNo File</legend>
                                                   <div class="col-lg-12 col-md-12">
                                                     <div class="form-group">
                                                      <label for="txtSelectFileForImport" class="col-sm-4 control-label">Select File For Import:</label>
                                                      <div class="col-sm-4">
                                                        <input type="file" class ="form-control" id="txtSelectFileForImportEntryItemNo_ItemPortFileNJR" runat="server"/>     
                                                      </div>                                  
                                                      <div class="col-sm-4">
                                                        <button type="submit" runat="server" class="btn btn-success" id="btnImport_ImportFileNJR" title="btnImport_ImportFileNJR" >Import Update</button> 
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
                                    <!-- /.box-body -->                          
                       </div>

                                    <div class="form-horizontal">
                           <div class="box-body">

                            <fieldset class="col-md-12">
                                <legend>File</legend>
                               <div class="col-lg-12 col-md-12">
                                   
                                  <div class="form-group">
                                   <div class="col-sm-8">
                                   
                                   </div>
                                   <div class="col-sm-4">
                                   <button type="submit" runat="server" class="btn btn-success" id="btnSaveToInvoice_ImportFileNJR" title="btnSaveToInvoice_ImportFileNJR" >Save To Invoice</button> 
                                   </div>
                                 </div>
                                   
                               </div>                             
                         </fieldset>
                    
                          </div>
                      
                     </div>
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