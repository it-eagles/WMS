﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="UserMenu.aspx.vb" Inherits="WMS.UserMenu" MasterPageFile="~/Home.Master" EnableViewState="true" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>User Menu</h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>System</a></li>
                <li class="active">User Menu</li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->

                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#user" data-toggle="tab">User</a></li>
                            <li><a href="#menu" data-toggle="tab">Menu</a></li>
                            <li><a href="#group" data-toggle="tab">Group</a></li>
                        </ul>

                        <div class="tab-content">

                            <div class="active tab-pane" id="user">

                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">

                                        <div class="col-lg-8 col-md-8 col-md-offset-2">
                                            <!-- form start -->
                                            <div class="form-horizontal">
                                                <div class="box-body">

                                                    <div class="form-group">

                                                        <label for="txtUserName" class="col-sm-3 control-label">UserName</label>

                                                        <div class="col-sm-9">
                                                         <asp:DropDownList ID="ddlUser" CssClass="form-control select2" runat="server" DataTextField="Name" DataValueField="UserName"  AutoPostBack="true"></asp:DropDownList>
                                                           <%-- <input class="form-control" id="txtUserName" runat="server" placeholder="User Name" />--%>
                                                        </div>

                                                    </div>
                                                    <div class="form-group">

                                                        <label for="txtUserName" class="col-sm-3 control-label">Copy From UserName</label>

                                                        <div class="col-sm-9">

                                                            <asp:DropDownList ID="ddlCopyUser" CssClass="form-control select2" runat="server" AutoPostBack="true" DataTextField="Name" DataValueField="UserName"></asp:DropDownList>
                                                           <%-- <input class="form-control" id="txtCode" runat="server" placeholder="Copy From UserName" />--%>
                                                        </div>

                                                    </div>

                                                    <div class="form-group">
                                                        <label for="txtBranch" class="col-sm-3 control-label">Copy From Group</label>

                                                        <div class="col-sm-9">
                                                            <input class="form-control" id="txtDescription" runat="server" placeholder="Copy From Group" />
                                                        </div>

                                                    </div>


                                                    <div class="text-right">
                                                       <%-- <button type="submit" runat="server" class="btn btn-primary" id="btnSave" title="btnSave" onserverclick="btnSave_ServerClick">Save</button>--%>

                                                    <button type="submit" runat="server" class="btn btn-reddit" id="btnCopy" title="btnCopy" onserverclick="btnCopy_ServerClick">Copy</button>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-lg-10 col-md-offset-1">
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
                                                            <asp:LinkButton ID="lnkEdit" CssClass="btn btn-default" runat="server" OnClick="lnkEdit_Click"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" Visible="false" OnClick="lnkUpdate_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" Visible="false" OnClick="lnkCancel_Click"></asp:LinkButton>
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


                                        <!--/.row-->
                                    </div>

                                </div>

                                <!-- /.post -->
                            </div>
                            <!-- /.tab-pane -->



                            <div class="tab-pane" id="menu">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">

                                        <div class="col-lg-8 col-md-8 col-md-offset-2">
                                            <div class="form-horizontal">
                                                <div class="box-body">

                                                    <div class="form-group">

                                                        <label for="txtForm" class="col-sm-2 control-label">Form</label>

                                                        <div class="col-sm-10">
                                                            <input class="form-control" id="txtForm" runat="server" placeholder="Form" />
                                                        </div>

                                                    </div>

                                                    <div class="form-group">
                                                        <label for="txtMenu" class="col-sm-2 control-label">Menu</label>

                                                        <div class="col-sm-10">
                                                            <input class="form-control" id="txtMenu" runat="server" placeholder="Menu" />
                                                        </div>

                                                    </div>

                                                    <div class="text-right">
                                                        <button type="submit" runat="server" class="btn btn-primary" id="btnAddUp1" title="btnAddUp1">Add up</button>
                                                        <button type="submit" runat="server" class="btn btn-danger" id="btnDelete1" title="btnDelete1">Delete</button>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </div>

                                            </div>

                                            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example2" class="table table-bordered table-hover">
                                                        <thead>
                                                            <tr>
                                                                <th>Form</th>
                                                                <th>Menu</th>
                                                                <th>UserBy</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblForm" runat="server" Text='<%# Bind("Form")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblMenu" runat="server" Text='<%# Bind("Menu")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblUserBy" runat="server" Text='<%# Bind("UserBy")%>'></asp:Label></td>
                                                        
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>Form</th>
                                                            <th>Menu</th>
                                                            <th>UserBy</th>
                                                           
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <!--/.col-lg-6 col-md-6--->
                                        </div>

                                        <!--/.row-->
                                    </div>

                                </div>

                                <!-- /.post -->

                            </div>

                            <div class="tab-pane" id="group">
                                <!-- Post -->
                                <div class="post">
                                    <div class="row margin-bottom">

                                        <div class="col-lg-8 col-md-8 col-md-offset-2">
                                            <div class="form-horizontal">
                                                <div class="box-body">

                                                    <div class="form-group">

                                                        <label for="txtUserName" class="col-sm-2 control-label">Group Name</label>

                                                        <div class="col-sm-10">
                                                            <input class="form-control" id="Text1" runat="server" placeholder="Group Name" />
                                                        </div>

                                                    </div>
                                                    <div class="text-right">
                                                        <button type="submit" runat="server" class="btn btn-primary" id="btnAddUp2" title="btnAddUp2">Add up</button>
                                                        <button type="submit" runat="server" class="btn btn-danger" id="btnDelete2" title="btnDelete2">Delete</button>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </div>
                                            </div>

                                            <asp:Repeater ID="Repeater3" runat="server" OnItemDataBound="Repeater3_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table id="exa" class="table table-bordered table-striped">
                                                        <thead>
                                                            <tr>
                                                                <th>Form</th>
                                                                <th>Menu</th>
                                                                <th>Status</th>
                                                                <th>Edit</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblForm" runat="server" Text='<%# Bind("Form")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblMenu" runat="server" Text='<%# Bind("Menu")%>'></asp:Label></td>
                                                        <td class="text-center">
                                                            <asp:DropDownList ID="lblStatus" CssClass="form-control" runat="server">
                          
                                                            </asp:DropDownList>
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
                                                            <th>Menu</th>
                                                            <th>Status</th>
                                                            <th>Edit</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <!--/.col-lg-6 col-md-6--->
                                        </div>

                                        <!--/.row-->
                                    </div>

                                </div>

                                <!-- /.post -->

                            </div>
                        </div>
                        <!-- /.tab-pane -->
                    </div>
                    <!-- /.tab-pane -->
                </div>
            </div>
            <!-- /.row -->
        </section>
        <!-- /.content -->
    </form>

    <!-- ./wrapper -->
</asp:Content>
