<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Test.aspx.vb" Inherits="WMS.Test" MasterPageFile="~/Home.Master" EnableEventValidation="false" EnableViewState="false" %>

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

                                
                                <asp:Repeater ID="cpRepeater" runat="server" OnItemCommand="cpRepeater_ItemCommand" OnItemDataBound="cpRepeater_ItemDataBound">
                                    <HeaderTemplate>
                                        <table id="example1" class="table table-bordered table-striped">
                                            <thead>
                                            <tr>
                                                <td>Check</td>
                                                <td>Form</td>
                                                <td>Type</td>
                                                <td>Options</td>
                                            </tr>
                                          </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                <asp:CheckBox ID="chkDelete" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Form")%>'></asp:Label>
                                                <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Form")%>'></asp:Label>
                                                <asp:TextBox ID="txtName" BackColor="#d4d0c8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Read_")%>' Visible="false"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlType" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <%--<asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Form")%>'>Edit</asp:LinkButton>
                                                <asp:LinkButton Visible="false" ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Form")%>'>Update</asp:LinkButton>
                                                <asp:LinkButton Visible="false" ID="lnkCancel" runat="server" CommandName="cancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Form")%>'>Cancel</asp:LinkButton>--%>
                                                <asp:LinkButton ID="LinkButton1" Text="Edit" runat="server" OnClick="OnEdit" />
                                                <asp:LinkButton ID="LinkButton2" Text="Update" runat="server" Visible="false" OnClick="OnUpdate" />
                                                <asp:LinkButton ID="LinkButton3" Text="Cancel" runat="server" Visible="false" OnClick="OnCancel" />
                                                <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete" OnClientClick="return confirm('Do you want to delete this row?');" />
                                              
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                <td>Check</td>
                                                <td>Form</td>
                                                <td>Type</td>
                                                <td>Options</td>
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
        
        
    </form>

</asp:Content>
