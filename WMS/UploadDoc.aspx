<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UploadDoc.aspx.vb" Inherits="WMS.UploadDoc" MasterPageFile="~/Home.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Master Exchange Rate
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>System</a></li>     
            <li><a href="MasterExchangeRate.aspx">MasterExchangeRate</a></li>                   
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">

        <div class="row">
            <!-- left column -->
            <div class="col-lg-12 col-md-12 ">

                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Master Exchange Rate</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <div class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
                                            
                               
                                    <!-- /.box-body -->
                                     <div class="form-group">
                                     <label for="txtDocName" class="col-sm-3 control-label">Doc Nane:</label>
                                         <div class="col-sm-5">
                                     <input type="text" class ="form-control input-sm" id="txtDocName" runat="server" autocomplete="off"/>
                                         </div>
                                          </div>

                                <div class="form-group">
                                    <label for="txtCusCode" class="col-sm-3 control-label">Cus Code:</label>
                                    <div class="col-sm-5">
                                        <input type="text" class="form-control input-sm" id="txtCusCode" runat="server" autocomplete="off"/>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="txtCusDate" class="col-sm-3 control-label">Cus Date:</label>
                                    <div class="col-sm-5">
                                        <%--<input type="text" class="form-control pull-right" id="datepickerJobdate"/>--%>
                                        <asp:TextBox CssClass="form-control input-sm" ID="txtdatepickerCusDate" runat="server" placeholder="DD/MM/YYYY" autocomplete="off">
                                        </asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtenderCusDate" runat="server" Enabled="True" TargetControlID="txtdatepickerCusDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                    </div>
                                </div>

                                      <div class="form-group" >
                                    
                                        <label for="txtSelect" class="col-sm-3 control-label">Select File For Import</label>                                          
                                         <div class="col-sm-5">
                                           <input type="file" class ="form-control input-sm" id="txtDirectory" runat="server" autocomplete="off"/>
                                        </div>
                                    <div class="col-sm-3">
                                        <button type="submit" runat="server" class="btn btn-success btn-sm" id="btnUpload" title="btnUpload" onserverclick="btnUpload_ServerClick">Upload</button>
                                       
                                    </div>
                                    
                                      </div>

                             </div>
                           </div>
                             
                       </div>
                          
                        <!--/.row-->
                    </div>
           
                         <!--/.row-->
                     </div>
                       
                    
                    <!--/.box box-primary-->
                </div>
                <!--/.col-lg-12 -->
            </div>

            <!--/.col (right) -->
        
        <!-- /.row -->
    </section>
    <!-- /.content -->

</form>
 </asp:Content>
