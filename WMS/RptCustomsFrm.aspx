<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RptCustomsFrm.aspx.vb" Inherits="WMS.RptCustomsFrm" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Picking
            </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>WareHouse</a></li>
                <li><a href="PickingWH.aspx"class="active">Picking</a></li>
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
                    <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">                                                     
                                 <div class="form-group">
                                                <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbNormalReport" Text="Normal Report"  onclick="EnableDisableTextBox();"  GroupName="option1" />
                                              </label>
                                               </div>            
                                           </div>
                                
                                                <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbCompleteReport" Text="Complete Report" onclick="EnableDisableTextBox();" GroupName="option1"/>
                                              </label>
                                               </div>            
                                           </div>     

                                                <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbNotCompleteReport" Text="Not Complete Report"  onclick="EnableDisableTextBox();"  GroupName="option1"  />
                                              </label>
                                               </div>            
                                           </div>                                 
                                </div>                
                                 <div class="form-group" >   
                                        <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbIN" Text="IN"  onclick="EnableDisableTextBox();"  GroupName="option2"  />
                                              </label>
                                               </div>            
                                           </div>
                                        <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdbOUT" Text="OUT"  onclick="EnableDisableTextBox();"  GroupName="option2"  />
                                              </label>
                                               </div>            
                                           </div>
                                        <div class="col-sm-4"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnAddData" title="btnAddData" onserverclick="btnAddData_ServerClick">AddData</button>
                                        
                                 </div>

                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>
                        </div>
                               <%------------------------------------------------End Before Custom Tab---------------------------------------------------%>

                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">                            
                            <li class="active"><a href="#TAB01" data-toggle="tab">สินค้านำเข้าคลัง</a></li>
                            <li><a href="#TAB02" data-toggle="tab">สินค้านำออกคลัง</a></li>
                            <li><a href="#TAB03" data-toggle="tab">สินค้านำเข้าฝากเก็บเข้าคลัง</a></li>  
                            <li><a href="#TAB04" data-toggle="tab">สินค้านำเข้าฝากเก็บออกจากคลัง</a></li>              
                            <li><a href="#TAB05" data-toggle="tab">สินค้าส่งออกฝากเก็บเข้าคลัง</a></li>     
                            <li><a href="#TAB06" data-toggle="tab">รายการสินค้าคงเหลือ</a></li>    
                            <li><a href="#TAB07" data-toggle="tab">รายการสินค้าเข้า</a></li>     
                            <li><a href="#TAB08" data-toggle="tab">รายการสินค้าออก</a></li>       
                        </ul>

                        <div class="tab-content">
                            

                            <%-----------------------------------------------------Start 01 TAB-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="active tab-pane" id="TAB01">
                     <!-- Post -->
               <div class="row">
                   <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">     
                                
                                <div class="form-group">
                                                <div class="col-sm-2"></div>    
                                                <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb01_TAB01"   onclick="EnableDisableTextBox();"  GroupName="option1" />สินค้านำเข้าคลังฯ โดยคำร้อง"อ"
                                              </label>
                                               </div>            
                                           </div>
                                
                                                <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb02_TAB01"  onclick="EnableDisableTextBox();" GroupName="option1"/>สินค้านำเข้าคลังฯ โดยคำร้อง"G"
                                              </label>
                                               </div>            
                                           </div>                                               
                                </div>          
                                
                                <div class="form-group">
											<div class="col-sm-2"></div>    
											<div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb03_TAB01" onclick="EnableDisableTextBox();"  GroupName="option1"  />สินค้านำเข้าคลังฯ โดยใบขน"0"
                                              </label>
                                               </div>            
                                           </div>
										   
										   <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb04_TAB01" onclick="EnableDisableTextBox();" GroupName="option1"/>สินค้านำเข้าคลังฯ โดยใบขน"D"
                                              </label>
                                               </div>            
                                           </div>
										</div>
                                                                                     
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">From Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerFromDate_TAB01" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderFromDate_TAB01" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate_TAB01" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>
                                  <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">To Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate_TAB01" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderToDate_TAB01" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate_TAB01" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>  
                        
                                 <div class="form-group" >   
                                        <div class="col-sm-5"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnReport_TAB01" title="btnReport_TAB01" onserverclick="btnReport_TAB01_ServerClick">Report</button>
                                 </div>



                                     <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                                     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>--%>


                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>

                </div>
     <!-- /.post -->
       </div>
 <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End 01 TAB-------------------------------------------------------%>


                            <%--------------------------------------------------------Start 02 TAB------------------------------------------------------%>

                    <div class="tab-pane" id="TAB02">
                     <!-- Post -->
               <div class="row">
                         <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">  
                                <div class="form-group">
											<div class="col-sm-2"></div>    
											<div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb01_TAB02" onclick="EnableDisableTextBox();"  GroupName="option1"  />สินค้านำเข้าคลังฯ โดยใบขน"C"
                                              </label>
                                               </div>            
                                           </div>
										   
										   <div class="col-lg4 col-md-4 col-sm-4">
                                                <div class="radio">
                                                <label>                                            
                                                 <asp:RadioButton runat="server" ID ="rdb02_TAB02" onclick="EnableDisableTextBox();" GroupName="option1"/>สินค้านำเข้าคลังฯ โดยใบขน"1"
                                              </label>
                                               </div>            
                                           </div>
										</div>
                                                                                     
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">From Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerFromDate_TAB02" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderFromDate_TAB02" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate_TAB02" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>
                                  <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">To Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate_TAB02" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderToDate_TAB02" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate_TAB02" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>  
                        
                                 <div class="form-group" >   
                                        <div class="col-sm-5"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnReport_TAB02" title="btnReport_TAB02" onserverclick="btnReport_TAB02_ServerClick">Report</button>
                                 </div>



                                     <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                                     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>--%>


                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>
                </div>
     <!-- /.post -->
       </div>
                            <%-----------------------------------------------------End 02 TAB------------------------------------------------------%>




                           <%----------------------------------------------------Start 03 TAB---------------------------------------------------------%>
       <!-------- Export Goods --------->
     <div class="tab-pane" id="TAB03">
                                <!-- Post -->
        <div class="row">
                  <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">                                                     
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">From Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerFromDate_TAB03" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderFromDate_TAB03" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate_TAB03" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>
                                  <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">To Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate_TAB03" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderToDate_TAB03" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate_TAB03" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>  
                        
                                 <div class="form-group" >   
                                        <div class="col-sm-5"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnReport_TAB03" title="btnReport_TAB03" onserverclick="btnReport_TAB03_ServerClick">Report</button>
                                 </div>



                                     <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                                     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>--%>


                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>

                       
        </div>
         <!-- right column -->
                    <!-- /.post -->
                </div>
             <!-----/ Export Goods----->

              <%-----------------------------------------------------------END 03 TAB----------------------------------------------------------%>
                                


                            
                         <%-----------------------------------------------------Start 04 TAB-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="tab-pane" id="TAB04">
                     <!-- Post -->
               <div class="row">
                   <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">                                                     
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">From Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerFromDate_TAB04" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderFromDate_TAB04" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate_TAB04" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>
                                  <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">To Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate_TAB04" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderToDate_TAB04" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate_TAB04" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>  
                        
                                 <div class="form-group" >   
                                        <div class="col-sm-5"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnReport_TAB04" title="btnReport_TAB04" onserverclick="btnReport_TAB04_ServerClick">Report</button>
                                 </div>



                                     <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                                     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>--%>


                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>
                         
                </div>
     <!-- /.post -->
       </div>
 <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End 04 TAB-------------------------------------------------------%>          



                         <%-----------------------------------------------------Start 05 TAB-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="tab-pane" id="TAB05">
                     <!-- Post -->
               <div class="row">
                       <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">                                                     
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">From Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerFromDate_TAB05" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderFromDate_TAB05" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate_TAB05" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>
                                  <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">To Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate_TAB05" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderToDate_TAB05" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate_TAB05" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>  
                        
                                 <div class="form-group" >   
                                        <div class="col-sm-5"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnReport_TAB05" title="btnReport_TAB05" onserverclick="btnReport_TAB05_ServerClick">Report</button>
                                 </div>



                                     <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                                     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>--%>


                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>
                </div>
     <!-- /.post -->
       </div>
 <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End 05 TAB-------------------------------------------------------%> 



                <%-----------------------------------------------------Start 06 TAB-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="tab-pane" id="TAB06">
                     <!-- Post -->
               <div class="row">
                       <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">                                                     
                                  <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">Remain Product:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerRemainProduct_TAB06" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderRemainProduct_TAB06" runat="server" Enabled="True" TargetControlID="txtdatepickerRemainProduct_TAB06" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>  
                        
                                 <div class="form-group" >   
                                        <div class="col-sm-5"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnReport_TAB06" title="btnReport_TAB06" onserverclick="btnReport_TAB06_ServerClick">Report</button>
                                 </div>



                                     <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                                     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>--%>


                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>
                </div>
     <!-- /.post -->
       </div>
 <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End 06 TAB-------------------------------------------------------%>

                         <%-----------------------------------------------------Start 07 TAB-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="tab-pane" id="TAB07">
                     <!-- Post -->
               <div class="row">
                       <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">                                                     
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">From Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerFromDate_TAB07" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderFromDate_TAB07" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate_TAB07" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>
                                  <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">To Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate_TAB07" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderToDate_TAB07" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate_TAB07" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>  
                        
                                 <div class="form-group" >   
                                        <div class="col-sm-5"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnReport_TAB07" title="btnReport_TAB07" onserverclick="btnReport_TAB07_ServerClick">Report</button>
                                 </div>



                                     <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                                     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>--%>


                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>
                </div>
     <!-- /.post -->
       </div>
 <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End 07 TAB-------------------------------------------------------%> 

                         <%-----------------------------------------------------Start 08 TAB-----------------------------------------------------------%>
             <!------- Import Goods ------->
            <div class="tab-pane" id="TAB08">
                     <!-- Post -->
               <div class="row">
                       <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">                                                     
                                <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">From Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerFromDate_TAB08" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderFromDate_TAB08" runat="server" Enabled="True" TargetControlID="txtdatepickerFromDate_TAB08" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>
                                  <div class="form-group" >                                    
                                        <label for="txtCode" class="col-sm-3 control-label">To Date:</label>
                                         <div class="col-sm-5">                                            
                                             <asp:TextBox CssClass="form-control" ID="txtdatepickerToDate_TAB08" runat="server" placeholder="DD/MM/YYYY">
                                             </asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtenderToDate_TAB08" runat="server" Enabled="True" TargetControlID="txtdatepickerToDate_TAB08" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         </div>
                                 </div>  
                        
                                 <div class="form-group" >   
                                        <div class="col-sm-5"></div>                                 
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnReport_TAB08" title="btnReport_TAB08" onserverclick="btnReport_TAB08_ServerClick">Report</button>
                                 </div>



                                     <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                                     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>--%>


                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </div>
                </div>
     <!-- /.post -->
       </div>
 <!------- /. Import Goods ------->
                            <%-------------------------------------------------------------End 08 TAB-------------------------------------------------------%> 
              
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