<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ViewGroup.aspx.vb" MasterPageFile="~/Home.Master" Inherits="WMS.ViewGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
<!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Master Code
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i> Home</a></li>
            <li><a class="active"><i class="fa fa-file"></i>Master Files</a></li>
            <li><a href="MasterCode.aspx">Master Code</a></li>
            <li class="active">View Group</li>
         
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">

      <div class="row">
            <!-- left column -->

        <div class="col-md-12">
          <div class="nav-tabs-custom">
       
             
            <div class="tab-content">
              <div class="active tab-pane" id="activity">
               
                <!-- Post -->
                <div class="post">
                  <div class="row margin-bottom">
                   
                   <div class="col-lg-8 col-md-8 col-md-offset-2">
                            <!-- form start -->
                           
                       <from class="form-horizontal">
                           <div class="box-body">   
                                            
                        
                                    <div class="form-group" >
                                    
                                        <label for="txtUserName" class="col-sm-2 control-label">TypeName</label>
                                    
                                         <div class="col-sm-10">
                                            <input class="form-control" id="txtTypeName" runat="server" placeholder="Code" disabled>
                                        </div>
                      
                               </div>
                               <div class="form-group" >
                                    
                                        <label for="txtUserName" class="col-sm-2 control-label">Code</label>
                                    
                                         <div class="col-sm-10">
                                            <input class="form-control" id="txtCode" runat="server" placeholder="Code" disabled>
                                        </div>
                      
                               </div>
                                    
                                    <div class="form-group">
                                        <label for="txtBranch" class="col-sm-2 control-label">Description</label>
                                      
                                      <div class="col-sm-10">
                                           <input class="form-control" id="txtDescription" runat="server" placeholder="Description" disabled>
                                        </div>
                      
                                    </div>

                                   <div class="form-group">
                                        <label for="txtFullName" class="col-sm-2 control-label">Notes</label>
                                           <div class="col-sm-10">
                                            <input class="form-control" id="txtNotes" runat="server"  placeholder="Notes" disabled>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtDept" class="col-sm-2 control-label">Indicator</label>
                                         <div class="col-sm-10">
                                        <input class="form-control" id="txtFilteringIndicator" runat="server"  placeholder="Notes" disabled>
                                       </div>
                                   
                                    </div>

                                 <div class="form-group">
                                        <label for="txtDept" class="col-sm-2 control-label">Recorded by</label>
                                         <div class="col-sm-10">
                                        <input class="form-control" id="txtReby" runat="server"  placeholder="Notes" disabled>
                                       </div>
                                   
                                    </div>

                                 <div class="form-group">
                                        <label for="txtDept" class="col-sm-2 control-label">Create Date</label>
                                       <div class="col-sm-10">
                                        <input class="form-control" id="txtCreateDate" runat="server"  placeholder="Notes" disabled>
                                       </div>
                                   
                                 </div>
                               
                                 <div class="form-group">
                                        <label for="txtDept" class="col-sm-2 control-label">Update By</label>
                                       <div class="col-sm-10">
                                        <input class="form-control" id="txtUpdateBy" runat="server"  placeholder="Notes" disabled>
                                       </div>
                                   
                                 </div>


                               <div class="form-group">
                                        <label for="txtDept" class="col-sm-2 control-label">Update Date</label>
                                       <div class="col-sm-10">
                                        <input class="form-control" id="txtUpdateDate" runat="server"  placeholder="Notes" disabled>
                                       </div>
                                   
                                 </div>
                                    <!-- /.box-body -->
                             </div>
                          
                       </from>
                          
                            <!--/.col-lg-6 col-md-6--->
                        </div>
                    
                        <!--/.row-->
                      </div>
             </div>
                </div>
                 
                <!-- /.post -->
              </div>
              <!-- /.tab-pane -->
                       
             
          </div>
              <!-- /.tab-pane -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
</form>
 </asp:Content>