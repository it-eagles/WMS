<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Test.aspx.vb" Inherits="WMS.Test" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="true" %>

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
                    <div class="col-lg-12 col-xs-12">

                        <div class="box">
                         
                            <!-- /.box-header -->
                            <div class="box-body">

                                <div id="div1">
                                    <h2>ผลลัพธ์ JSON จะแสดงไว้ตรงนี้</h2>
                                </div>
                                <br />
                                <button runat="server" id="button">ทดสอบ API แบงค์ชาติ</button>

                                <asp:Repeater ID="cpRepeater" runat="server">
                                    <HeaderTemplate>
                                        <table id="example1" class="table table-bordered table-striped">
                                            <thead>
                                            <tr>
                                                <td>Check</td>
                                                <td>Form</td>
                                                <td>Type</td>
                                                <td>Edit</td>
                                            </tr>
                                          </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                <asp:CheckBox ID="chkDelete" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Bind("Form")%>'></asp:Label>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Form")%>'></asp:Label>
                                                <asp:TextBox ID="txtName" BackColor="#d4d0c8" runat="server" Text='<%# Bind("Form")%>' Visible="false"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                                            </td>
                                            <td>
                                            
                                                <asp:LinkButton ID="lnkEdit" CssClass="btn btn-default" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
                                                <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" Visible="false" OnClick="LinkButton2_Click"></asp:LinkButton>
                                                <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" Visible="false" OnClick="LinkButton3_Click"></asp:LinkButton>
                                                <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="lnkDelete_Click" OnClientClick="return confirm('Do you want to delete this row?');" />
                                              
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                <td>Check</td>
                                                <td>Form</td>
                                                <td>Type</td>
                                                <td>Edit</td>
                                            </tr>
                                        </tfoot>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                   
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </section>
            <!-- /.content -->
        
        
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
                             $("#div1").html(JSON.stringify(result));
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
