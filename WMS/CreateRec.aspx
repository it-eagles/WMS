<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreateRec.aspx.vb" Inherits="WMS.CreateRec" MasterPageFile="~/Home.Master"%>

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
                            <li><a href="#importgoods" data-toggle="tab">Job Detail</a></li>
                            <li><a href="#exportgoods" data-toggle="tab">Invoice</a></li>
                            <li><a href="#detailofgoods" data-toggle="tab">Import File</a></li>
                            <li><a href="#assembly" data-toggle="tab">Import File NJR</a></li>
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
                                                                    <input type="text" class="form-control pull-right" id="datepickerJobdate"/>
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
                    <input type="text" class="form-control pull-right"  id="datepickerActualDate1" />
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
                    <input type="text" class="form-control pull-right" id="datepickerActualDate2"/>
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
                    <input type="text" class="form-control pull-right" id="datepickerActualDate3"/>
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
                    <input type="text" class="form-control pull-right" id="datepickerActualDate4"/>
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
                      <input type="text" class="form-control pull-right" id="datepickerActualPickUp"/>
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
                      <input type="text" class="form-control pull-right" id="datepickerArrivalToEAS"/>
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
         
                                             <input class="form-control" id="txtImpProductCode" runat="server" placeholder="Product Code"/>
                                      </div>
                                           <label for="dcboImpTariffCode" class="col-sm-2 control-label">Tariff Code :</label>
                                       <div class="col-md-5">   

                                           <asp:DropDownList ID="dcboImpTariffCode" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                        </div>
                                       </div>                
                                 
                                    <div class="form-group" >
                                     
                                         <label for="txtImpDesc1" class="col-sm-2 control-label">Desc. (ENG) 1 :</label>
                                       <div class="col-md-9" id="ImpDesc1">
         
                                             <input class="form-control" id="txtImpDesc1" runat="server" placeholder="Desc" disabled="disabled"/>
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
                                             <input class="form-control" id="txtImpDesc2" runat="server" placeholder="Desc" disabled="disabled"/>
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
                                       <input class="form-control" id="txtImpDesc3" runat="server" placeholder="Desc" disabled="disabled"/>
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
                                       <input class="form-control" id="txtImpProductAttribute1" runat="server" placeholder="Desc. (TH)"/>
                                    </div>
                                   </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpProductAttribute2" class="col-sm-2 control-label">Product Attribute:</label>  
                                      <div class="col-sm-10">
                                             <input class="form-control" id="txtImpProductAttribute2" runat="server" placeholder=" Attribute"/>
                                        </div>
                                    </div>

                               <div class="col-lg-6 col-md-6">
                                   <div class="form-group">
                                        <label for="dcboImpTariffSequence" class="col-sm-4 control-label">Tariff Sequence</label>
                                           <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboImpTariffSequence" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                           </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpCustomsProductCode" class="col-sm-4 control-label">H.S. Code</label>
                                       <div class="col-sm-8">
                                          <input class="form-control" id="txtImpCustomsProductCode" runat="server"  placeholder="H.S."/>
                                       </div>
                                    </div>

                               <div class="form-group" >
                                        <label for="txtImpDutyType" class="col-sm-4 control-label">Duty Type</label>
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtImpDutyType" runat="server" placeholder="Duty Type"/>
                                        </div>
                               </div>
                                      <div class="form-group">
                                        <label for="txtImpValueRateP" class="col-sm-4 control-label">Value Rate(P) :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control" id="txtImpValueRateP" runat="server"  placeholder="Value Rate"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpSpecificRateP" class="col-sm-4 control-label">Specific Rate(P) :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtImpSpecificRateP" runat="server"  placeholder="Specific Rate"/>
                                        </div>
                                   
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtImpExemptDuty" class="col-sm-4 control-label">Exempt Duty :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtImpExemptDuty" runat="server" placeholder="Exempt Duty"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpSurchargeRate" class="col-sm-4 control-label">Surcharge Rate :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtImpSurchargeRate" runat="server" placeholder="Surcharge Rate"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpExciseRate" class="col-sm-4 control-label">Excise Rate :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtImpExciseRate" runat="server" placeholder="Excise Rate"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpExciseSpcRate" class="col-sm-4 control-label">Excise Spc Rate :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtImpExciseSpcRate" runat="server"  placeholder="Excise Spc Rate"/>
                                           </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtImpExemptExcise" class="col-sm-4 control-label">Exempt(Excise) :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtImpExemptExcise" runat="server" placeholder="Excise"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpValueRate" class="col-sm-4 control-label">Value Rate :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtImpValueRate" runat="server" placeholder="Value Rate"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpValueRateAmount" class="col-sm-4 control-label">Value Rate Amount :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtImpValueRateAmount" runat="server" placeholder="Value Rate Amount"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpFactoryNo" class="col-sm-4 control-label">Factory No :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtImpFactoryNo" runat="server"  placeholder="Factory No"/>
                                      </div>
                                   
                                    </div>
                               </div>

                               <div class="col-lg-6 col-md-6">
                                   <div class="form-group">
                                        <label for="dcboImpStatisticalCode" class="col-sm-4 control-label">Statistical Code</label>
                                           <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboImpStatisticalCode" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpProductYear" class="col-sm-4 control-label">Product Year :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtImpProductYear" runat="server"  placeholder="Product Year"/>
                                           </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtImpSpeciticRate" class="col-sm-4 control-label">Specitic Rate :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtImpSpeciticRate" runat="server" placeholder="Specitic Rate"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpSpecificCal" class="col-sm-4 control-label">Specific Cal :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtImpSpecificCal" runat="server" placeholder="Specific Cal"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpExemptVat" class="col-sm-4 control-label">Exempt Vat :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control" id="txtImpExemptVat" runat="server"  placeholder="Exempt Vat"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtImpExciseNo" class="col-sm-4 control-label">Excise No :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtImpExciseNo" runat="server"  placeholder="Excise No"/>
                                           </div>
                                   
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtImpExciseRatePay" class="col-sm-4 control-label">Excise Rate Pay :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtImpExciseRatePay" runat="server" placeholder="Excise Rate Pay "/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtImpExciseSpcRatePay" class="col-sm-4 control-label">Excise Spc Rate Pay :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtImpExciseSpcRatePay" runat="server" placeholder="Excise Spc Rate Pay"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpPriviege" class="col-sm-4 control-label">Priviege :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtImpPriviege" runat="server" placeholder="Priviege"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="dcboImpBrand" class="col-sm-4 control-label">Brand :</label>
                                         <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboImpBrand" CssClass="form-control" runat="server" DataTextField="Description" DataValueField="Description"></asp:DropDownList>
                                           </div>
                                   
                                    </div>
                                     <div class="form-group" >
                                          <label class="col-sm-4 control-label">Currency :</label>
                                                                        
                                       <div class="col-md-4">
         
                                          <asp:DropDownList ID="cboImpCurrency" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>            
                                      </div>
                                
                                       <div class="col-md-4">   
                                            <input class="form-control" id="txtImpExchangeRate" runat="server" placeholder="Currency" />
                                        </div>
                                       </div>
                                
                                      <div class="form-group">
                                        <label for="txtImpEstablishNo" class="col-sm-4 control-label">Establish No :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtImpEstablishNo" runat="server" placeholder="Establish No"/>
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
                                     <input class="form-control" id="txtExpProductCode" runat="server" placeholder="Product Code"/>
                                 </div>
                                 <div class="col-md-2"></div>
                             </div> 
                                              
                             <div class="form-group" >
                                  <label for="txtImpDesc1" class="col-sm-2 control-label">Desc. (ENG) 1 :</label>
                               <div class="col-md-9" id="ExpDesc1">
                                  <input class="form-control" id="txtExpDesc1" runat="server" placeholder="Desc" disabled="disabled"/>
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
                                    <input class="form-control" id="txtExpDesc2" runat="server" placeholder="Desc" disabled="disabled"/>
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
                                  <input class="form-control" id="txtExpDesc3" runat="server" placeholder="Desc" disabled="disabled"/>
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
                                        <input class="form-control" id="txtExpProductAttribute1" runat="server" placeholder="Desc. (TH)"/>
                                   </div>
                         </div>
                         
                         <div class="form-group">
                             <label for="txtExpProductAttribute2" class="col-sm-2 control-label">Attribute 2 :</label>
                                   <div class="col-sm-10">
                                             <input class="form-control" id="txtExpProductAttribute2" runat="server" placeholder=" Attribute"/>
                                        </div>
                      
                                    </div>

                               <div class="col-lg-6 col-md-6">
                                   <div class="form-group">
                                        <label for="dcboExpTariffSequence" class="col-sm-4 control-label">Tariff Sequence</label>
                                           <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboExpTariffSequence" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtExpCustomsProductCode" class="col-sm-4 control-label">H.S. Code</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtExpCustomsProductCode" runat="server"  placeholder="H.S."/>
                                        </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtExpFomulaNo" class="col-sm-4 control-label">Fomula No :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtExpFomulaNo" runat="server" placeholder="Fomula No"/>
                                        </div>
                      
                                    </div>
                                    
                                
                                      <div class="form-group">
                                        <label for="txtExpBOINo" class="col-sm-4 control-label">BOI No :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control" id="txtExpBOINo" runat="server"  placeholder="BOI No"/>
                                           </div>
                                      
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtExpDutyType" class="col-sm-4 control-label">Duty Type :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtExpDutyType" runat="server" placeholder="Duty Type"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpQtyCarton" class="col-sm-4 control-label">Qty./Carton :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtExpQtyCarton" runat="server" placeholder="Qty Carton"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtExpWeightCarton" class="col-sm-4 control-label">Weight/Carton :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtExpWeightCarton" runat="server" placeholder="Weight/Carton"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtExpValueRate" class="col-sm-4 control-label">Value Rate :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtExpValueRate" runat="server"  placeholder="Value Rate"/>
                                           </div>
                                   
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtExpValueRateAmount" class="col-sm-4 control-label">Value Rate Amount :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtExpValueRateAmount" runat="server" placeholder="Value Rate Amount"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpFactoryNo" class="col-sm-4 control-label">Factory No :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtExpFactoryNo" runat="server" placeholder="Factory No"/>
                                        </div>
                      
                                    </div>
                                     
                               </div>
                               <div class="col-lg-6 col-md-6">
                               
                                      <div class="form-group">
                                        <label for="dcboExpTariffCode" class="col-sm-4 control-label">Tariff Code :</label>
                                           <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboExpTariffCode" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                           </div>
                                      
                                    </div>
                                     <div class="form-group">
                                        <label for="dcboExpStatisticalCode" class="col-sm-4 control-label">Statistical Code</label>
                                           <div class="col-sm-8">
                                             <asp:DropDownList ID="dcboExpStatisticalCode" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                           </div>
                                      
                                    </div>

                               <div class="form-group" >
                                    
                                        <label for="txtImpSpeciticRate" class="col-sm-4 control-label">Specitic Rate :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="Text20" runat="server" placeholder="Specitic Rate"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpProductYear" class="col-sm-4 control-label">Product Year :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtExpProductYear" runat="server" placeholder="Product Year"/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtExp19BisTranNo" class="col-sm-4 control-label">19 Bis TranNo :</label>
                                           <div class="col-sm-8">
                                              <input class="form-control" id="txtExp19BisTranNo" runat="server"  placeholder="19 Bis TranNo"/>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtExpBondFormulaNo" class="col-sm-4 control-label">Bond Formula No :</label>
                                         <div class="col-sm-8">
                                          <input class="form-control" id="txtExpBondFormulaNo" runat="server"  placeholder="Bond Formula No"/>
                                           </div>
                                   
                                    </div>

                                <div class="form-group" >
                                    
                                        <label for="txtExpPriceForeight" class="col-sm-4 control-label">Price(Foreight) :</label>
                                       
                                         <div class="col-sm-8">
                                             <input class="form-control" id="txtExpPriceForeight" runat="server" placeholder="Foreight"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtExpQtyPallet" class="col-sm-4 control-label">QTY/PALLET :</label>
                                       
                                      <div class="col-sm-8">
                                             <input class="form-control" id="txtExpQtyPallet" runat="server" placeholder="QTY/PALLET "/>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtImpPriviege" class="col-sm-4 control-label">Priviege :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="Text26" runat="server" placeholder="Priviege"/>
                                        </div>
                                      
                                    </div>

                           
                                     <div class="form-group" >
                                          <label class="col-sm-4 control-label">Currency :</label>
                                                                        
                                       <div class="col-md-4">
         
                                          <asp:DropDownList ID="cboExpCurrency" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>            
                                      </div>
                                
                                       <div class="col-md-4">   
                                            <input class="form-control" id="txtExpExchangeRate" runat="server" placeholder="Currency" />
                                        </div>
                                       </div>
                                
                                      <div class="form-group">
                                        <label for="txtExpEstablishNo" class="col-sm-4 control-label">Establish No :</label>
                                           <div class="col-sm-8">
                                            <input class="form-control" id="txtExpEstablishNo" runat="server" placeholder="Establish No"/>
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
                                       
                                         <asp:DropDownList ID="cboProductUnit" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
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
                                       <input class="form-control" id="txtProductWidth" runat="server" placeholder="Width"/>
                                  </div>
                                  
                                   <div class="col-md-2">
                                       <label for="txtProductHeight">Heigh</label>
                                       <input class="form-control" id="txtProductHeight" runat="server" placeholder="Height"/>
                                  </div>
                                     
                                   <div class="col-md-2">
                                       <label for="txtProductLeng">length</label>
                                       <input class="form-control" id="txtProductLeng" runat="server" placeholder="length"/>
                                  </div>
                                   <div class="col-md-2">
                                       <label for="txtProductVolume">Volume</label>
                                       <input class="form-control" id="txtProductVolume" runat="server" placeholder="Volume"/>
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
                                       
                                         <asp:DropDownList ID="cboPackageUnit" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
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
                                       <input class="form-control" id="txtPackageWidth" runat="server" placeholder="Width"/>
                                  </div>
                                  
                                   <div class="col-md-2">
                                       <label for="txtPackageHeigh">Heigh</label>
                                       <input class="form-control" id="txtPackageHeigh" runat="server" placeholder="Height"/>
                                  </div>
                                     
                                   <div class="col-md-2">
                                       <label for="txtPackageLenght">length</label>
                                       <input class="form-control" id="txtPackageLenght" runat="server" placeholder="length"/>
                                  </div>
                                   <div class="col-md-2">
                                       <label for="txtPackageCarton">No of Carton</label>
                                       <input class="form-control" id="txtPackageCarton" runat="server" placeholder="Volume"/>
                                  </div>
                                    
                                 </div>
                                   
                               </div>
                             <div class="col-lg-12 col-md-12">
                                  <div class="form-group">
                                    <div class="col-md-2">
                                       <label for="txtProductUnit" >Volume of Pallet :</label>
                                   </div>
                                   <div class="col-md-4">
                                      
                                       <input class="form-control" id="txtPackageVolume" runat="server" placeholder="Volume"/>
                                  
                                  </div>
                                   <div class="col-md-4">
                                        <asp:DropDownList ID="cboPackageofUnit" CssClass="form-control" runat="server" DataTextField="Code" DataValueField="Code"></asp:DropDownList>
                                         
                                   </div>            
                                 </div>   
                             </div>
                           
                           </fieldset>

                               <fieldset class="col-lg-12 col-md-12">
                                   <legend>Special Handing</legend>
                                   <div class="col-md-12 col-md-offset-2">
                                       <div class="form-group">
                                     <div class="col-md-8">
                                          <textarea class="form-control" id="txtRemarks" rows="6" runat="server" name="txtRemarks" placeholder="Remarks ..."></textarea>
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
                                       <input class="form-control" id="txtEAS" runat="server" placeholder="EAS P/N" disabled="disabled"/>
                                   </div>
                           
                               </div>                
                                 
                               <div class="form-group">
                                   <label for="txtCustomer" class="col-sm-3 control-label">Customer P/N :</label>
                                       <div class="col-md-8">
                                           <input class="form-control" id="txtCustomer" runat="server" placeholder="Customer" disabled="disabled"/>
                                      </div>
                              </div> 
                             </div>
                               <div class="col-lg-6">
                                   <div class="form-group" >
                                  <label for="txtOwner" class="col-sm-3">Owner P/N :</label>
                                       <div class="col-md-8">
                                           <input class="form-control" id="txtOwner" runat="server" placeholder="Owner" disabled="disabled"/>
                                      </div>
                     
                                  </div> 
                                 
                                    <div class="form-group" >
                                        <label for="txtQty" class="col-sm-3">Quality :</label>
                                       <div class="col-md-8">
                                           <input class="form-control" id="txtQty" runat="server" placeholder="Quality" disabled="disabled"/>
                                      </div>
                                   </div> 
                                 
                               </div>
                               
                                <div class="form-group" >

                                <div class="col-md-offset-9">
                                        <button type="submit" runat="server" class="btn btn-primary" id="btAdd" title="btnAddUser" disabled="disabled"/>Add</>
                                        <button type="submit" runat="server" class="btn bg-olive" id="btModify" title="btnAddUser" disabled="disabled"/>Modify</>
                                        <button type="submit" runat="server" class="btn btn-danger" id="btDel" title="btnAddUser" disabled="disabled"/>Delete</>
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

                        <from class="form-horizontal">
                            <div class="col-lg-12 col-md-12">
                                 <div class="box-body">   
                                            
                       
                                  <div class="form-group">
                                        <label for="txtGenCode" class="col-sm-3 control-label">รหัสชื่อลูกค้า :</label>
                                       
                                      <div class="col-sm-6">
                                           <input class="form-control" id="txtGenCode" runat="server"  placeholder="Name"/>
                                       </div>
                                       <div class="col-md-3">
                                            <label for="txtGenCode">ใช้3ตัวอักษร</label>
                                        </div>
                                    </div>
                                                 
                                    <div class="form-group" >
                                          <label class="col-sm-3 control-label">รหัสกลุ่มสินค้า :</label>
                                                                        
                                       <div class="col-md-6">
                                 
                                            <asp:DropDownList ID="cdbGroupGoods" CssClass="form-control" runat="server"  DataTextField="Description" DataValueField="Description"></asp:DropDownList>
                                      </div>
                                
                                       <div class="col-md-3">
                                             <input class="form-control" id="txtCodeGoods" runat="server" placeholder="Group"/>
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
                             
                       </from>
                          
                        <!--/.row-->
                    </div>
                    <div class="box-header with-border">
                        <h3 class="box-title">ลูกค้าที่มีรหัสมา</h3>
                    </div>
                <div id="radio1">
                   <div class="row" >
                         <div class="col-lg-12 col-md-12">

                             
                                     <!-- form start -->
                         <from class="form-horizontal">
                            <div class="col-lg-12 col-md-12">
                                 <div class="box-body">   
                                            
                                <div class="form-group">
                                        <label for="txtGenCode" class="col-sm-3 control-label p-t-10">รหัสลูกค้า :</label>
                                      
                                      <div class="col-sm-6">
                                           <input class="form-control" id="txtCodeCustomers" runat="server" name="txtCodeCustomers" placeholder="Name" />
                                       </div>
                                     
                                    </div>
                                     <div class="col-md-offset-3">
                                         <p class="text-red">* หมายเหตุ ให้ใช้8ตัว โดยถ้ามี7ตัวให้ใส่ 0นำหน้า เช่า 0</p>  
                                     </div>
                                        
                                  <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </from>
                                
                  </div> 
                     
               </div>
             </div>
                     
                         <!--/.row-->

                    <div class="box-header with-border">
                        <h3 class="box-title">ลูกค้าที่ไม่มีรหัสมา</h3>
                    </div>
                <div id="radio2">
                    <div class="row" >
                          <from class="form-horizontal">
                            <div class="col-lg-12 col-md-12">
                                 <div class="box-body">   
                                            
                      <div class="form-group">
                                        <label for="txtGenCode" class="col-sm-3 control-label p-t-8">รหัสชื่อลูกค้า :</label>
                                       
                                      <div class="col-sm-6">
                                           <input class="form-control" id="txtNoCodeGoods" name="txtNoCodeGoods" runat="server"  placeholder="Name" disabled="disabled"/>
                                       </div>
                                         <div class="col-md-3">
                                            <label for="txtGenCode">ใส่ตัวเลข 4 ตัว</label>
                                        </div>
                                    </div>
                                     
                               
                                  <div class="form-group">
                                        <label for="txtGenCode" class="col-sm-3 control-label p-t-10">รหัสขนาด :</label>
                                       
                                      <div class="col-sm-6">
                                           <input class="form-control" id="txtCodeSize" runat="server"  placeholder="Name" disabled="disabled"/>
                                      </div>
                                    
                                </div>      
                                      <div class="col-md-offset-3">
                 
                                          <p class="text-red">* ใช้ 2 ตัวอักษรหรือตัวเลย</p>
                                     </div>

                                    <div class="form-group" >
                                          <label class="col-sm-3 control-label">รหัสสีของสินค้า :</label>
                                                                        
                                       <div class="col-md-6">
                                 
                                            <asp:DropDownList ID="cdbGroupColor" CssClass="form-control" runat="server"  DataTextField="Description" DataValueField="TypeID" disabled="disabled"></asp:DropDownList>
                                      </div>
                                
                                       <div class="col-md-3">
                                             <input class="form-control" id="txtCodeColor" runat="server" placeholder="Group" disabled="disabled"/>
                                        </div>
                                    </div>
                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </from>
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
            } else if (status == false) {
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