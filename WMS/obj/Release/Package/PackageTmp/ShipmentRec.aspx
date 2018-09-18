<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ShipmentRec.aspx.vb" Inherits="WMS.ShipmentRec" MasterPageFile="~/Home.Master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
<!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Shipment
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i> Home</a></li>
             <li><a class="active"><i class="fa fa-file"></i>Receive Process</a></li>
            <li><a href="ShipmentRec.aspx">Shipment</a></li>
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">

      <div class="row">
            <!-- left column -->

             <div class="col-lg-12 col-xs-12">

                        <div class="box">
                            <!-- /.box-header -->
                            <div class="box-body">
                                <div class="form-horizontal">
                           <div class="box-body">   
                                <div class="form-group" >
                                        <label for="txtMAWB" class="col-sm-3 control-label">MAWB</label>
                                         <div class="col-sm-6">
                                            <input class="form-control" id="txtMAWB" runat="server"/>
                                        </div>
                                    </div>               
                                    <div class="form-group" >
                                    
                                        <label for="txtFlight" class="col-sm-3 control-label">Flight</label>
                                       
                                         <div class="col-sm-6">
                                            <input class="form-control" id="txtFlight" runat="server"/>
                                        </div>                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtAmountOfMAWB" class="col-sm-3 control-label">Amount Of MAWB</label>                                      
                                      <div class="col-sm-6">
                                           <input class="form-control" id="txtAmountOfMAWB" runat="server"/>                                          
                                        </div>                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtHAWBNo1" class="col-sm-3 control-label">HAWB No 1</label>
                                           <div class="col-sm-2">
                                           <input class="form-control" id="txtHAWBNo1" runat="server"/>
                                           </div>
                                        <label for="txtHAWBNo5" class="col-sm-2 control-label">HAWB No 5</label>
                                           <div class="col-sm-2">
                                           <input class="form-control" id="txtHAWBNo5" runat="server"/>
                                           </div>                                      
                                      </div>

                                      <div class="form-group">
                                        <label for="txtHAWBNo2" class="col-sm-3 control-label">HAWB No 2</label>
                                           <div class="col-sm-2">
                                           <input class="form-control" id="txtHAWBNo2" runat="server"/>
                                           </div>
                                        <label for="txtHAWBNo6" class="col-sm-2 control-label">HAWB No 6</label>
                                           <div class="col-sm-2">
                                           <input class="form-control" id="txtHAWBNo6" runat="server"/>
                                           </div>                                      
                                      </div>

                                      <div class="form-group">
                                        <label for="txtHAWBNo3" class="col-sm-3 control-label">HAWB No 3</label>
                                           <div class="col-sm-2">
                                           <input class="form-control" id="txtHAWBNo3" runat="server"/>
                                           </div>
                                        <label for="txtHAWBNo7" class="col-sm-2 control-label">HAWB No 7</label>
                                           <div class="col-sm-2">
                                           <input class="form-control" id="txtHAWBNo7" runat="server"/>
                                           </div>                                      
                                      </div>

                                      <div class="form-group">
                                        <label for="txtHAWBNo4" class="col-sm-3 control-label">HAWB No 4</label>
                                           <div class="col-sm-2">
                                           <input class="form-control" id="txtHAWBNo4" runat="server"/>
                                           </div>
                                        <label for="txtHAWBNo8" class="col-sm-2 control-label">HAWB No 8</label>
                                           <div class="col-sm-2">
                                           <input class="form-control" id="txtHAWBNo8" runat="server"/>
                                           </div>                                      
                                      </div>

                                    <div class="form-group">
                                        <label for="txtRemark" class="col-sm-3 control-label">Remark</label>
                                           <div class="col-sm-6">
                                                <asp:TextBox runat="server" Cssclass="form-control" TextMode="MultiLine" Height="102px"  ID="txtRemark" ></asp:TextBox>
                                           </div>                                      
                                    </div>

                                 <div class="text-right">
                                   <div class="text-center">
                                    <button type="submit" runat="server" class="btn btn-primary" id="btnPrint" title="btnPrint" onserverclick="btnPrint_ServerClick">Print</button>
                                    <button type="submit" runat="server" class="btn btn-primary" id="btnClose" title="btnClose" onserverclick="btnClose_ServerClick">Close</button>
                                   </div>
                                 </div>
                                    <!-- /.box-body -->
                             </div>
                          
                       </div>               

                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                     
          </div>
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
</form>
 </asp:Content>