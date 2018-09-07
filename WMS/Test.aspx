<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Test.aspx.vb" Inherits="WMS.Test" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <section class="content-header">
            <h1>TEST</h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>TEST</a></li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-info">
                        <div class="box-header">
                            <h3 class="box-title">CK Editor
                           <small>Advanced and full of features</small>
                            </h3>

                            <!-- /. tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body pad">
                            <div class="form-group">
                                <label class="col-sm-2">Test</label>  
                                <div class="col-md-4">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                       <%-- <input class="form-control input-sm" runat="server" id="txtFile" type="file" />--%>
                                </div>   
                               <div class="colmd-2">
                                   <button runat="server" id="btnAdd" class="btn btn-pinterest btn-block" onserverclick="btnAdd_ServerClick"></button>
                               </div>
                                <div>
                                    <label>Has Header ?</label>
                                    <asp:RadioButtonList ID="rbHDR" runat="server">
                                        <asp:ListItem Text = "Yes" Value = "Yes" Selected = "True" ></asp:ListItem>
                                        <asp:ListItem Text = "No" Value = "No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <fieldset>
                                      <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="PageIndexChanging" AllowPaging = "true"  >
                                  </asp:GridView>

                                    <div >
                                          <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control input-sm"></asp:TextBox>
                                       
                                    </div>
                                    <br />
                                    <button id="button">ทดสอบ API แบงค์ชาติ</button>
                                </fieldset>
                               
                                <%--<asp:TextBox runat="server" ID="txttest" CssClass="form-control input-sm" AutoPostBack="true" OnTextChanged="txttest_TextChanged"></asp:TextBox>--%>
                            </div>

                            <asp:Repeater ID="rptCustomers" runat="server" OnItemDataBound="rptCustomers_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="tblCustomers" class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th style="width: 5px">
                                                    <asp:CheckBox ID="chkAll" runat="server" Checked="false" /></th>
                                                <th>UserName</th>
                                                <th>Name</th>
                                                <th>Branch</th>
                                                <th>Dept</th>

                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkRowData" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" /></td>
                                        <td>
                                            <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblName" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblBrnch" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDept" runat="server"></asp:Label></td>
                                    </tr>

                                </ItemTemplate>

                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                    <!-- /.box -->

                </div>
                <!-- /.col-->
            </div>
            <!-- ./row -->
        </section>
        <!-- /.content -->

        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Modal Header</h4>
                    </div>
                    <div class="modal-body">
                        <p>Some text in the modal.</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnCloseModal" CssClass="btn btn-default" runat="server" Text="Close & Reopen"
                            OnClick="btnCloseModal_Click" />
                    </div>
                </div>

            </div>
        </div>
        <%--      <script type="text/javascript">
            $(function () {
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "personal";
                $('#Tabs a[href="#' + tabName + '"]').tab('show');
                $("#Tabs a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });
            });
        </script>
    </form>--%>
        <%--      <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    
        <script type="text/javascript">
        $(function () {
            $("#tblCustomers [id*=chkHeader]").click(function () {
                if ($(this).is(":checked")) {
                    $("#tblCustomers [id*=chkRow]").attr("checked", "checked");
                } else {
                    $("#tblCustomers [id*=chkRow]").removeAttr("checked");
                }
            });
            $("#tblCustomers [id*=chkRow]").click(function () {
                if ($("#tblCustomers [id*=chkRow]").length == $("#tblCustomers [id*=chkRow]:checked").length) {
                    $("#tblCustomers [id*=chkHeader]").attr("checked", "checked");
                } else {
                    $("#tblCustomers [id*=chkHeader]").removeAttr("checked");
                }
            });
        });
       

</script>--%>
        <script>
            $(document).ready(function () {
                // CHECK-UNCHECK ALL CHECKBOXES IN THE REPEATER 
                // WHEN USER CLICKS THE HEADER CHECKBOX.
                $('table [id*=chkAll]').click(function () {
                    if ($(this).is(':checked'))
                        $('table [id*=chkRowData]').prop('checked', true)
                    else
                        $('table [id*=chkRowData]').prop('checked', false)
                });

                // NOW CHECK THE HEADER CHECKBOX, IF ALL THE ROW CHECKBOXES ARE CHECKED.
                $('table [id*=chkRowData]').click(function () {

                    var total_rows = $('table [id*=chkRowData]').length;
                    var checked_Rows = $('table [id*=chkRowData]:checked').length;

                    if (checked_Rows == total_rows)
                        $('table [id*=chkAll]').prop('checked', true);
                    else
                        $('table [id*=chkAll]').prop('checked', false);
                });
            });
        </script>

        <script type="text/javascript">
            $(document).ready(function () {
                $('#tblCustomers').dataTable({
                    'paging': true,
                    'lengthChange': false,
                    'searching': false,
                    'ordering': true,
                    'info': true,
                    'autoWidth': false
                })
            });
        </script>
        <script>
            $(document).ready(function () {
                //อ้างอิงคู่มือ ตามลิงค์นี้ https://iapi.bot.or.th/Developer?lang=th 
                // ตัวอย่างดู อัตราแลกเปลี่ยนถัวเฉลี่ยถ่วงน้ำหนักระหว่างธนาคาร (รายวัน)
                $("button").click(function () {
                    $.ajax({
                        type: "GET",
                        url: "https://iapi.bot.or.th/Stat/Stat-ReferenceRate/DAILY_REF_RATE_V1/?start_period=2002-01-12&end_period=2002-01-15",
                        beforeSend: function (xhr) { xhr.setRequestHeader('api-key', 'U9G1L457H6DCugT7VmBaEacbHV9RX0PySO05cYaGsm'); },
                        success: function (result) {
                            $("#lblText").html(JSON.stringify(result));
                            console.log(JSON.stringify(result));
                        },
                        error: function (result) {
                            //handle the error 
                        }
                    });
                });
            });
</script>
    </form>
</asp:Content>
