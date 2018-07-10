<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportIEAT-E-02.aspx.vb" Inherits="WMS.ReportIEAT_E_02" EnableEventValidation="false" EnableViewState="true" MasterPageFile="~/Home.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Wrapper. Contains page content -->

        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>ReportIEAT</h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a><i class="fa fa-file"></i>Issue Process</a></li>
                <li class="active">
                ReportIEAT
            </ol>
        </section>

        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-lg-12 col-xs-12">

                    <div class="box box-primary">

                        <div class="box-header">
                            <h3 class="box-title">ReportIEAT</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-horizontal">
                                <div class="col-lg-12 col-md-offset-1">
                                    <fieldset>
                                        <div class="form-group">
                                            <div class="col-md-offset-1">
                                                <div class="radio">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="rdb107" class="flat-red" GroupName="Software" />
                                                        รายงานการนำของออกจากเขตประกอบการเสรี
                                                    </label>
                                                </div>
                                                <div class="radio">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="rdb108" class="flat-red" GroupName="Software" />
                                                        รายงานการนำของออกจากเขตประกอบการเสรี For Internal Approve
                                                    </label>
                                                </div>

                                                <div class="radio">
                                                    <label class="radio">
                                                        <%--  <input type="radio" name="optionsRadios" runat="server" id ="rdbPermitTranfer_" value="option1" class="flat-red"/> 
                                             Permit Tranfer--%>
                                                        <asp:RadioButton runat="server" ID="rdbPermitTranfer" class="flat-red" GroupName="Software" />
                                                        รายงานการนำของออก เพื่อการอื่นเป็นการชั่วคราว และการนำกลับ
                                                    </label>
                                                </div>
                                            </div>

                                        </div>
                                    </fieldset>

                                </div>
                                <div class="col-lg-12">
                                    <fieldset>
                                        <legend></legend>

                                        <div class="col-lg-6 col-md-offset-1">
                                            <div class="form-group">
                                                <label for="txtConsignneeCode" class="col-sm-2 control-label">Consignee</label>
                                                <div class="col-sm-8">
                                                    <div class="form-group">
                                                        <div class="col-md-offset-1">
                                                            <div class="radio">
                                                                <label class="radio">
                                                                    <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                                    <asp:RadioButton runat="server" ID="RWD001" class="flat-red" GroupName="Software" />
                                                                    EAS001
                                                                </label>
                                                            </div>
                                                            <div class="radio">
                                                                <label class="radio">
                                                                    <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                                    <asp:RadioButton runat="server" ID="ROther" class="flat-red" GroupName="Software" />
                                                                    Other
                                                                </label>
                                                            </div>



                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                    <div class="form-group">
                                        <label for="dcbConsigneeCode" class="col-sm-2 control-label">Code</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="dcbConsigneeCode" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtConsigneeName" class="col-sm-2 control-label">Name</label>
                                        <div class="col-sm-6">
                                            <input class="form-control" id="txtConsigneeName" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtNotar" class="col-sm-2 control-label">Notar </label>
                                        <div class="col-sm-6">
                                            <input class="form-control" id="txtNotar" runat="server" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="cboJobSite" class="col-sm-2 control-label">JOB Site</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="cboJobSite" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="TypeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <fieldset>
                                        <legend></legend>
                                        <div class="form-group">
                                            <div class="col-md-offset-2">
                                                <div class="col-lg-1">

                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton1" class="flat-red" GroupName="Software" />
                                                        1,1
                                                    </label>

                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton6" class="flat-red" GroupName="Software" />
                                                        1,3
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton5" class="flat-red" GroupName="Software" />
                                                        1,4
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton7" class="flat-red" GroupName="Software" />
                                                        1,5
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton8" class="flat-red" GroupName="Software" />
                                                        1,6
                                                    </label>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-offset-2">
                                                <div class="col-lg-1">

                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton9" class="flat-red" GroupName="Software" />
                                                        1,2,1
                                                    </label>

                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton10" class="flat-red" GroupName="Software" />
                                                        1,2,2
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton11" class="flat-red" GroupName="Software" />
                                                        1,2,3
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton12" class="flat-red" GroupName="Software" />
                                                        1,2,4
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton13" class="flat-red" GroupName="Software" />
                                                        1,2,5
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton2" class="flat-red" GroupName="Software" />
                                                        1,2,6
                                                    </label>
                                                </div>

                                            </div>

                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-offset-2">


                                                <div class="col-lg-1">

                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton3" class="flat-red" GroupName="Software" />
                                                        2,2
                                                    </label>

                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton4" class="flat-red" GroupName="Software" />
                                                        2,3
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton14" class="flat-red" GroupName="Software" />
                                                        2,4
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton15" class="flat-red" GroupName="Software" />
                                                        2,5
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton16" class="flat-red" GroupName="Software" />
                                                        2,6
                                                    </label>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-offset-2">
                                                <div class="col-lg-1">

                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton17" class="flat-red" GroupName="Software" />
                                                        2,2,1
                                                    </label>

                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton18" class="flat-red" GroupName="Software" />
                                                        2,2,2
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton19" class="flat-red" GroupName="Software" />
                                                        2,2,3
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton20" class="flat-red" GroupName="Software" />
                                                        2,2,4
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton21" class="flat-red" GroupName="Software" />
                                                        2,2,5
                                                    </label>
                                                </div>
                                                <div class="col-lg-1">
                                                    <label class="radio">
                                                        <%--<input type="radio" name="optionsRadios" runat="server" id ="rdbConfirm" value="option1"/>Confirm--%>
                                                        <asp:RadioButton runat="server" ID="RadioButton22" class="flat-red" GroupName="Software" />
                                                        2,2,6
                                                    </label>
                                                </div>

                                            </div>

                                        </div>
                                    </fieldset>
                                </div>

                                <div class="col-lg-12">
                                    <fieldset>
                                        <legend></legend>
                                        <div class="col-lg-8 col-md-offset-1">
                                            <div class="form-group">
                                            <label for="dcbConsigneeCode" class="col-sm-2 control-label">From Date</label>
                                            <div class="input-group date col-lg-4">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calculator"></i>
                                                </div>
                                                <asp:TextBox CssClass="form-control" ID="txtDateIt_R" runat="server" placeholder="MM/DD/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtDateIt_R" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtConsigneeName" class="col-sm-2 control-label">To Date</label>
                                            <div class="input-group date col-lg-4">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calculator"></i>
                                                </div>
                                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="MM/DD/YYYY">
                                                </asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtDateIt_R" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
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
