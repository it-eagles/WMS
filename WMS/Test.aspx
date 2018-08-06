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
                <div class="col-lg-12 col-xs-12">

                    <div class="box">

                        <!-- /.box-header -->
                        <div class="box-body">

                            <div id="div1">
                                <h2>ผลลัพธ์ JSON จะแสดงไว้ตรงนี้</h2>
                            </div>
                            <br />
                            <button runat="server" id="button">ทดสอบ API แบงค์ชาติ</button>
                            <h2>Modal Example</h2>
                            <!-- Trigger the modal with a button -->
                            <button type="button" class="btn btn-info btn-lg" id="myBtn" data-toggle="modal">Open Modal</button>
                            <%--  <a class="btn" data-toggle="modal" href="#myModal" >Launch Modal</a>--%>
                            <!--ASP.NET Button -->

                            <asp:Button ID="btnOpenModal" runat="server" CssClass="btn btn-info btn-lg" Text="Open with ASP Button" OnClick="btnOpenModal_Click" />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <ul>
                                       
                                        <%--<asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:LinkButton ID="Button1" runat="server" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Title") %>'></asp:LinkButton></li>
                                                </ItemTemplate>
                                            </asp:Repeater>--%>
                                    </ul>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:Panel ID="Panel2" runat="server" CssClass="modal" TabIndex="-1" role="dialog" aria-labelledby="myLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="modal-header">
                                                    <h4 class="modal-title" id=" myLabel ">Edit</h4>
                                                </div>
                                                <div class="modal-body">
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                <HeaderTemplate>
                                                    <table id="example1" class="table table-bordered table-striped">
                                                        <thead>
                                                            <tr>
                                                                <th>Form</th>
                                                                <th>Read</th>
                                                                <th>Save</th>
                                                                <th>Edit</th>
                                                                <th>Delete</th>
                                                                <th>Permissions</th>
                                                                <th>Edit</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblForm" runat="server"></asp:Label></td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblRead" runat="server">
                                                     <i class="fa  fa-check-square-o fa-2x" aria-hidden="true"></i></asp:Label>
                                                            <asp:Label ID="lblRead2" runat="server">
                                                     <i class="fa  fa-close fa-2x" aria-hidden="true"></i></asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblSave" runat="server">
                                                     <i class="fa  fa-check-square-o fa-2x" aria-hidden="true"></i></asp:Label>
                                                            <asp:Label ID="lblSave2" runat="server">
                                                     <i class="fa  fa-close fa-2x" aria-hidden="true"></i></asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblEdit" runat="server">
                                                      <i class="fa  fa-check-square-o fa-2x" aria-hidden="true"></i> </asp:Label>
                                                            <asp:Label ID="lblEdit2" runat="server">
                                                      <i class="fa  fa-close fa-2x" aria-hidden="true"></i></asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblDelete" runat="server"><i class="fa  fa-check-square-o fa-2x" aria-hidden="true"></i></asp:Label>
                                                            <asp:Label ID="lblDelete2" runat="server"><i class="fa fa-close fa-2x" aria-hidden="true"></i></asp:Label>
                                                        </td>

                                                        <td class="text-center">
                                                            <asp:DropDownList ID="lblStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="lnkEdit" CssClass="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" Visible="false"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" Visible="false"></asp:LinkButton>
                                                        </td>


                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Form</th>
                                                            <th>Read</th>
                                                            <th>Save</th>
                                                            <th>Edit</th>
                                                            <th>Delete</th>
                                                            <th>Permissions</th>
                                                            <th>Edit</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Submit" />
                                                    <asp:LinkButton ID="Button3" runat="server" CssClass="btn btn-link" Text="Cancel"></asp:LinkButton>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </asp:Panel>
                            <%--<asp:Repeater ID="cpRepeater" runat="server">
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
                                </asp:Repeater>--%>
                            <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" />
                            <!-- ModalPopupExtender -->
                            <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
                                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
                                <div style="height: 100px">
                                    Do you like this product?&nbsp;
                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            <asp:ListItem Text="Please Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <asp:Button ID="btnClose" runat="server" Text="Close" />
                            </asp:Panel>
                            <!-- ModalPopupExtender -->
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

    </form>

</asp:Content>
