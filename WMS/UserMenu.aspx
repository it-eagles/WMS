<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserMenu.aspx.vb" Inherits="WMS.UserMenu" MasterPageFile="~/Home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Add Master Code </h1>
            <ol class="breadcrumb">
                <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Master Files</a></li>
                <li><a href="MasterCode.aspx">Master Code</a></li>
                <li><a href="Test.aspx">Master Code</a></li>
                <li class="active">Add Group</li>
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
                                            <formview class="form-horizontal">
                                                <div class="box-body">

                                                    <div class="form-group">

                                                        <label for="txtUserName" class="col-sm-3 control-label">UserName</label>

                                                        <div class="col-sm-9">
                                                                <%--<select class="form-control select2" style="width: 100%;" id="sltUser" runat="server"  datavaluefield="UserName" datatextfield="Name">
                                                              
                                                               </select>--%>
                                                            

                                                         <asp:DropDownList ID="ddlUser" CssClass="form-control select2" runat="server" AutoPostBack="true" DataTextField="UserName" DataValueField="UserName"></asp:DropDownList>
                                                           <%-- <input class="form-control" id="txtUserName" runat="server" placeholder="User Name" />--%>
                                                        </div>

                                                    </div>
                                                    <div class="form-group">

                                                        <label for="txtUserName" class="col-sm-3 control-label">Copy From UserName</label>

                                                        <div class="col-sm-9">

                                                            <asp:DropDownList ID="ddlCopyUser" CssClass="form-control select2" runat="server" AutoPostBack="true" DataTextField="UserName" DataValueField="UserName"></asp:DropDownList>
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
                                                        <button type="submit" runat="server" class="btn btn-primary" id="btnSave" title="btnSave">Save</button>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </div>

                                            </formview>

                                            <!--/.col-lg-6 col-md-6--->
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
                                            <formview class="form-horizontal">
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

                                            </formview>                                            
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example1" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Form</th>
                                                    <th>Menu</th>
                                                    <th>UserBy</th>
                                                    <th>UpdateBy</th>                                                    
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
                                            <td>
                                                <asp:Label ID="lblUpdateBy" runat="server" Text='<%# Bind("UpdateBy")%>'></asp:Label></td>                                   
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                    <th>Form</th>
                                                    <th>Menu</th>
                                                    <th>UserBy</th>
                                                    <th>UpdateBy</th>   
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
                                            <formview class="form-horizontal">
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
                                            </formview>
                                            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example1" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Form</th>
                                                    <th>Menu</th>
                                                    <th>Status</th>
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
                                                <asp:Label ID="lblStatus" runat="server" DataSourceID="tblGroupMenu" DataTextField="Form" 
                        DataValueField="Form" Text='<%# Bind("Status")%>'></asp:Label></td>           
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                <th>Form</th>
                                                <th>Menu</th>
                                                <th>Status</th>
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

<!-- jQuery 3 -->
<script src="../../bower_components/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap 3.3.7 -->
<script src="../../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- DataTables -->
<script src="../../bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
<script src="../../bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
<!-- SlimScroll -->
<script src="../../bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="../../bower_components/fastclick/lib/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="../../dist/js/demo.js"></script>
<!-- page script -->
<script>
    $(function () {
        $('#example1').DataTable()
        $('#example2').DataTable({
            'paging'      : true,
            'lengthChange': false,
            'searching'   : false,
            'ordering'    : true,
            'info'        : true,
            'autoWidth'   : false
        })
    })
    </script>
</asp:Content>
