<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="addIEAT107.aspx.vb" Inherits="WMS.addIEAT107" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:Panel ID="plIeat107" runat="server" CssClass="modal" TabIndex="-1" role="dialog">
                            <div class="modal-dialog modal-lg" role="dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title">Select Code</h4>
                                    </div>
                                    <asp:UpdatePanel ID="upieat107" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="modal-body">
                                                <section class="content">
                                                    <form class="form-horizontal">
                                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">

                                                            <asp:Repeater ID="dgvIeat107" runat="server" OnItemDataBound="dgvExporter_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table id="example2" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>select</th>
                                                                                <th>PartyCode</th>
                                                                                <th>InvoiceNo</th>
                                                                                <th>JobNo</th>
                                                                                <th>Status</th>
                                                                            </tr>
                                                                        </thead>
                                                                </HeaderTemplate>

                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td class="text-center">
                                                                            <asp:LinkButton ID="LinkButton1" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="selectInvoiceNo" CommandArgument='<%# Eval("InvoiceNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblInvoiceNo_" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("JobNo")%>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status")%>'></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <tfoot>
                                                                        <tr>
                                                                            <th>select</th>
                                                                            <th>PartyCode</th>
                                                                            <th>InvoiceNo</th>
                                                                            <th>JobNo</th>
                                                                            <th>Status</th>
                                                                        </tr>
                                                                    </tfoot>
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <fieldset>
                                                                <legend></legend>
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label for="txtTotalAmornut" class="col-sm-4 control-label">ยอดทั้งหมด</label>
                                                                        <div class="col-md-8">
                                                                            <input runat="server" id="txtTotalAmonut" type="text" autocomplete="off" class="form-control" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtTotalUseAmonut" class="col-sm-4 control-label">ยอดที่ใช้ไปทั้งหมด</label>
                                                                        <div class="col-sm-8">
                                                                            <input runat="server" class="form-control" id="txtTotalUseAmonut" type="text" autocomplete="off" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtAmonut" class="col-sm-4 control-label">ยอดคงเหลือ</label>
                                                                        <div class="col-sm-8">
                                                                            <input runat="server" class="form-control" id="txtAmonut" type="text" autocomplete="off" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="txtUseAmonut" class="col-sm-4 control-label">ยอดที่ใช้ Inv นี้</label>
                                                                        <div class="col-sm-8">
                                                                            <input runat="server" id="txtUseAmonut" class="form-control" type="text" autocomplete="off" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label for="dtpForm" class="col-sm-4 control-label">วันที่ของออก</label>
                                                                        <div class="col-sm-8">
                                                                            <asp:TextBox CssClass="form-control" ID="dtpForm" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                                            </asp:TextBox>
                                                                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True" TargetControlID="dtpForm" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="dtpTo" class="col-sm-4 control-label">วันที่ของกลับ</label>
                                                                        <div class="col-sm-8">
                                                                            <asp:TextBox CssClass="form-control" ID="dtpTo" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                                            </asp:TextBox>
                                                                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" Enabled="True" TargetControlID="dtpTo" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="checkbox col-sm-4">
                                                                            <label>
                                                                                <input type="checkbox" runat="server" id="Checkbox1" onclick="chkExpEnable3();" />ต่ออายุ
                                                                            </label>
                                                                        </div>
                                                                        <div class="col-sm-8">
                                                                            <asp:TextBox CssClass="form-control" ID="dtpEx" runat="server" placeholder="MM/DD/YYYY" autocomplete="off" disabled="disabled">
                                                                            </asp:TextBox>
                                                                            <asp:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True" TargetControlID="dtpEx" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </fieldset>
                                                        </div>
                                                    </form>
                                                </section>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" runat="server" class="btn btn-primary" id="Button1" onserverclick="btnaddIEAT107__ServerClick">Add</button>
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </asp:Panel>
    </form>

    
        <script type="text/javascript">
            function chkExpEnable3() {
                var status = document.getElementById('<%=Checkbox1.ClientID%>').checked;

                if (status == true) {
                    document.getElementById('<%=dtpEx.ClientID%>').disabled = false;

                } else if (status == false) {
                    document.getElementById('<%=dtpEx.ClientID%>').disabled = true;
                 }

         }
        </script>
</body>
</html>
