<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterPartyAdd.aspx.vb" MasterPageFile="~/Home.Master" Inherits="WMS.MasterPartyAdd" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>System</h1>
                <ol class="breadcrumb">
                    <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                    <li><a><i class="fa fa-file"></i>System</a></li>
                    <li class="active">User Profile</li>
                </ol>
            </section>

            <!-- Main content -->
            <section class="content">
                <div class="row">
                    <div class="col-lg-12 col-xs-12">

                        <div class="box">
                            <div class="box-header">
                                <a href="PartyMaster.aspx" target="_self" class="btn btn-info"><i class="fa fa-plus"></i> AddParty</a>
                                </div>
                            <!-- /.box-header -->
                            <div class="box-body">

                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example1" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>PartyCode</th>
                                                    <th>PartyFullName</th>
                                                    <th>PartyLocalCode</th>
                                                    <th>PartyLocalName</th>
                                                    <th>PartyLocation</th>
                                                    <th>PartyCountry</th>
                                                    <th>Edit/Delete</th>
                                                    <th>view</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>

                                    <ItemTemplate>


                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyFullName" runat="server" Text='<%# Bind("PartyFullName")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyLocalCode" runat="server" Text='<%# Bind("PartyLocalCode")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyLocalName" runat="server" Text='<%# Bind("PartyLocalName")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPartyLocation" runat="server" Text='<%# Bind("PartyLocation")%>'></asp:Label></td>
                                             <td>
                                                <asp:Label ID="lblPartyCountry" runat="server" Text='<%# Bind("PartyCountry")%>'></asp:Label></td>                                            
                                            <td class="text-center" >
                                                  <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="editCode" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                <a class="btn btn-danger"><i class="fa fa-trash"></i></a>
                                            </td>
                                            <td class="text-center">
                                                 <asp:LinkButton ID="LinkButton2" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="viewprofile" CommandArgument='<%# Eval("PartyCode")%>'><i class="fa fa-search-plus"></i></asp:LinkButton>
                                                
                                            </td>
                                        </tr>

                                    </ItemTemplate>

                                    <FooterTemplate>
                                        <tfoot>
                                            <tr>
                                                    <th>PartyCode</th>
                                                    <th>PartyFullName</th>
                                                    <th>PartyLocalCode</th>
                                                    <th>PartyLocalName</th>
                                                    <th>PartyLocation</th>
                                                    <th>PartyCountry</th>
                                                    <th>Edit/Delete</th>
                                                    <th>view</th>
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
