<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Test.aspx.vb" Inherits="WMS.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="box-body">
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <HeaderTemplate>
                                    <table id="example1" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>รหัสพนักงาน</th>
                                                <th>ชื่อ</th>
                                                <th>นามสกุล</th>
                                                <th>อีเมล์</th>
                                                <th>ตำแหน่ง</th>
                                                <th>แผนก</th>
                                                <th>ฝ่าย</th>
                                                <th>สาขา</th>
                                                <th>Edit</th>

                                            </tr>
                                        </thead>
                                </HeaderTemplate>

                                <ItemTemplate>


                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserId") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Name_thai")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Surname_thai")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Email") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Position") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Labelsec" runat="server" Text='<%# Bind("Dept")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Section") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Branch") %>'></asp:Label></td>
                                        <td class="text-center">

                                            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="edituser" CommandArgument='<%# Eval("UserID")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                        </td>

                                    </tr>

                                </ItemTemplate>

                                <FooterTemplate>
                                    <tfoot>
                                        <tr>
                                            <th>รหัสพนักงาน</th>
                                            <th>ชื่อ</th>
                                            <th>นามสกุล</th>
                                            <th>อีเมล์</th>
                                            <th>ตำแหน่ง</th>
                                            <th>แผนก</th>
                                            <th>ฝ่าย</th>
                                            <th>สาขา</th>
                                            <th>Edit</th>
                                        </tr>
                                    </tfoot>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
    </div>
    </form>
</body>
</html>
