<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterCode.aspx.vb" MasterPageFile="~/Home.Master"  Inherits="WMS.MasterCode" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form1">
       
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Wrapper. Contains page content -->

        <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Master Files
  
                </h1>
                <ol class="breadcrumb">
                    <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                    <li><a class="active"><i class="fa fa-file"></i>Master Files</a></li>
                    <li><a class="active">Master Code</a></li>
                </ol>
            </section>

            <!-- Main content -->
            <section class="content">
                <div class="row">
                    <div class="col-lg-12 col-xs-12">

                        <div class="box">
                            <div class="box-header">
                                <a href="AddGroup.aspx" target="_self" class="btn btn-info"><i class="fa fa-plus"></i> AddGroup</a>
                                </div>
                            <!-- /.box-header -->
                            <div class="box-body">

                                <asp:Repeater ID="Repeater1" runat="server">
                                    <HeaderTemplate>
                                        <table id="example1" class="table table-condensed table-striped">
                                            <thead>
                                                <tr>    
                                                    <th>ID</th>                                                
                                                    <th>Type</th>
                                                    <th>Code</th>
                                                    <th>Description</th>
                                                    <th>Note</th>                                                
                                                    <th>FilterInd</th>                                   
                                                    <th>Edit/Delete</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMasterCodeID" runat="server" Text='<%# Bind("MasterCodeID")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblType" runat="server" Text='<%# Bind("Type")%>'></asp:Label></td>                                         
                                            <td>
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description")%>'></asp:Label></td>
                                             <td>
                                                <asp:Label ID="lblNote" runat="server" Text='<%# Bind("Note")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblFilterInd" runat="server" Text='<%# Bind("FilterInd")%>'></asp:Label></td>
                                                 
                                            <td class="text-center" >
                                                  <asp:LinkButton ID="btnUpdateGroup" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="UpdateGroup" CommandArgument='<%# Eval("MasterCodeID")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                <a class="btn btn-danger"><i class="fa fa-trash"></i></a>
                                            </td>
                                           <%-- <td class="text-center">
                                                <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="viewGroup" CommandArgument='<%# Eval("MasterCodeID")%>'><i class="fa fa-search-plus"></i></asp:LinkButton>
                                            </td>--%>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                    <th>ID</th>                                          
                                                    <th>Type</th>
                                                    <th>Code</th>
                                                    <th>Description</th>
                                                    <th>Note</th>   
                                                    <th>FilterInd</th>                                   
                                                    <th>Edit/Delete</th>
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