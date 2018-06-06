<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UpdateGroup.aspx.vb" MasterPageFile="~/Home.Master"  Inherits="WMS.UpdateGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
<!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            MasterCode
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i> Home</a></li>
             <li><a class="active"><i class="fa fa-file"></i>Master Files</a></li>
            <li><a href="MasterCode.aspx">Master Code</a></li>
            <li class="active">UpDate Group</li>
       
        </ol>
    </section>
    <!-- Main content -->
     <section class="content">

        <div class="row">
            <!-- left column -->
            <div class="col-lg-12 col-md-12">

                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Update Group</h3>
                    </div>
                    <!-- /.box-header -->
                <div class="row">
                      
                   <div class="col-lg-8 col-md-8 col-md-offset-2">
                            <!-- form start -->
                           
                       <from class="form-horizontal">
                           <div class="box-body">   
                                            
                                <div class="form-group" >
                                    
                                        <label for="txtUserName" class="col-sm-2 control-label">TypeGroup</label>
                                        
                                         <div class="col-sm-10">
                                           <input class="form-control" id="txtTypeName" runat="server" placeholder="TypeName" disabled>
                                        </div>
                      
                                    </div>               
                                    <div class="form-group" >
                                    
                                        <label for="txtUserName" class="col-sm-2 control-label">TypeName</label>
                                       
                                         <div class="col-sm-10">
                                            <input class="form-control" id="txtCode" runat="server" placeholder="Code">
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtBranch" class="col-sm-2 control-label">Description</label>
                                      
                                      <div class="col-sm-10">
                                           <input class="form-control" id="txtDescription" runat="server" placeholder="Description">
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtFullName" class="col-sm-2 control-label">Notes</label>
                                           <div class="col-sm-10">
                                            <input class="form-control" id="txtNotes" runat="server"  placeholder="Notes">
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtDept" class="col-sm-2 control-label">Indicator</label>
                                         <div class="col-sm-10">
                                        <input class="form-control" id="txtFilteringIndicator" runat="server"  placeholder="Notes">
                                       </div>
                                   
                                    </div>
                                <div class="text-right">
                        <button type="submit" runat="server" class="btn btn-primary" id="btnAddGroup" title="btnAddUser" onserverclick="btnUpdatGroup_Click">UpDate</button>
                             </div>
                                    <!-- /.box-body -->
                             </div>
                          
                       </from>
                          
                            <!--/.col-lg-6 col-md-6--->
                        </div>
                    
                        <!--/.row-->
                      </div>
           
                 </div>
                          <!--/.row-->
                       
    
                    <!--/.box box-primary-->
                </div>
                <!--/.col-lg-12 -->
            </div>

        <!-- /.row -->
    </section>
    <!-- /.content -->

</form>
 </asp:Content>