<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IEATOut.aspx.vb" Inherits="WMS.IEATOut" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Wrapper. Contains page content -->

        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Issue Process</h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a><i class="fa fa-file"></i>Issue Process</a></li>
                <li class="active">
                GEN IEATli
            </ol>
        </section>

        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-lg-12 col-xs-12">
                     
                    <div class="box box-primary">
                       
                        <div class="box-header">
                            <h3 class="box-title">IEATOut</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-horizontal">
                             <div class="col-lg-12 col-md-offset-2">
                                <div class="form-group">
                                    <label for="txtConsignneeCode" class="col-sm-2 control-label">Consignnees Code</label>
                                    <div class="col-sm-6">
                                        <input class="form-control" id="txtConsignneeCode" runat="server" />
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label for="txtConsignneesName" class="col-sm-2 control-label">Consignnees Name</label>
                                    <div class="col-sm-6">
                                        <input class="form-control" id="txtConsignneesName" runat="server"  />
                                    </div>
                                </div>

                                 <div class="form-group">
                                     <div class="col-md-offset-2">
                                            <div class="radio">
                                         <label class="radio-inline">
                                             <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                             <asp:RadioButton runat="server" ID="rdb107" class="flat-red col-sm-2" GroupName="Software"/>
                                             IEAT 107
                                         </label>
                                     </div>
                                      <div class="radio">
                                         <label class="radio-inline">
                                             <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                             <asp:RadioButton runat="server" ID="rdb108" class="flat-red col-sm-2" GroupName="Software"/>
                                             IEAT E 02 
                                         </label>
                                     </div>

                                      <div class="radio">
                                         <label class="radio-inline">
                                           <%--  <input type="radio" name="optionsRadios" runat="server" id ="rdbPermitTranfer_" value="option1" class="flat-red"/> 
                                             Permit Tranfer--%>
                                             <asp:RadioButton runat="server" ID="rdbPermitTranfer" class="col-sm-2" GroupName="Software"/>
                                             Permit Tranfer 
                                         </label>
                                     </div>
                                     </div>
                                  
                                 </div>
                            </div>
                                <div class="col-lg-12">
                                    <fieldset>
                                        <legend></legend>
                                               <div class="form-group">
                                                <label for="txtAmountInvoice" class="col-sm-2 control-label">Amount of Invoice</label>
                                                <div class="col-sm-6">
                                                    <input class="form-control" id="txtAmountInvoice" runat="server" />
                                                </div>
                                            </div>
                                        <div class="col-lg-5">
                                             <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-3 control-label">Invoice No1</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo1" runat="server" />
                                                </div>
                                            </div>
                                          <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-3 control-label">Invoice No3</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo3" runat="server" />
                                                </div>
                                            </div>
                                               <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-3 control-label">Invoice No5</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo5" runat="server" />
                                                </div>
                                            </div>
                                               <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-3 control-label">Invoice No7</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo7" runat="server" />
                                                </div>
                                            </div>
                                               <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-3 control-label">Invoice No9</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo9" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-3 control-label">Invoice No2</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo2" runat="server" />
                                                </div>
                                            </div>
                                               <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-3 control-label">Invoice No4</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo4" runat="server" />
                                                </div>
                                            </div>
                                               <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-3 control-label">Invoice No6</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo6" runat="server" />
                                                </div>
                                            </div>
                                               <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-3 control-label">Invoice No8</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo8" runat="server" />
                                                </div>
                                            </div>
                                               <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-3 control-label">Invoice No10</label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" id="txtInvoiceNo10" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>

                                </div>
                                <div class="col-lg-12">
                                    <fieldset>
                                        <legend></legend>
                                         <div class="form-group">
                                              
                                                <div class="col-sm-10 col-md-offset-8">
                                                         <button type="button" class="btn btn-primary">Preview</button>
                                                         <button type="button" class="btn btn-default">Print</button>
                                                     <button type="button" class="btn btn-default">Close</button>
                                                </div>
                                            </div>
                                    </fieldset>
                                </div>
                            </div>
                           
                        </div>
                        
                        <!-- /.box-header -->

                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </section>
        <!-- /.content -->

    </form>
</asp:Content>

