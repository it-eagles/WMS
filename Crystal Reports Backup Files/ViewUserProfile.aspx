<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ViewUserProfile.aspx.vb" MasterPageFile="~/Home.Master" Inherits="WMS.ViewUserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
<!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            User Profile
        </h1>
        <ol class="breadcrumb">
           <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>System</a></li>     
            <li><a href="UserProfile.aspx">User Profile</a></li>
            <li class="active">Proflie</li>
        </ol>
    </section>
    
          <!-- Main content -->
    <section class="content">

        <div class="row">
             <div class="col-md-3">

          <!-- Profile Image -->
          <div class="box box-primary">
            <div class="box-body box-profile">
              <img class="profile-user-img img-responsive img-circle" src="Scripts/dist/img/user4-128x128.jpg" alt="User profile picture"/>

              <h3 class="profile-username text-center" id="txtprofilename" runat="server" ></h3>
                <%--<input class="form-control" id="Text1" runat="server" placeholder="User ID" disabled="disabled"/>--%>
              <p class="text-muted text-center" id="txtdeptname" runat="server"></p>           

              <%--<ul class="list-group list-group-unbordered">
                <li class="list-group-item">
                  <b>Followers</b> <a class="pull-right">1,322</a>
                </li>
                <li class="list-group-item">
                  <b>Following</b> <a class="pull-right">543</a>
                </li>
                <li class="list-group-item">
                  <b>Friends</b> <a class="pull-right">13,287</a>
                </li>
              </ul>

              <a href="#" class="btn btn-primary btn-block"><b>Follow</b></a>--%>
              
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->

        
        </div>
        <!-- /.col -->
            <!-- left column -->
            <div class="col-lg-9 col-md-9 ">
                
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Personal Profile</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <from class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
                                            
                                <div class="form-group" >
                                    
                                        <label for="txtUserName" class="col-sm-2 control-label">User ID</label>
                                          
                                         <div class="col-sm-10">
                                           <input class="form-control" id="txtUserName" runat="server" placeholder="User ID" disabled="disabled"/>
                                        </div>
                                    </div>
                                  <div class="form-group">
                                        <label for="txtFullName" class="col-sm-2 control-label">Name</label>
                                           <div class="col-sm-10">
                                           <input class="form-control" id="txtFullName" runat="server"  placeholder="Name" disabled="disabled"/>
                                       </div>
                                      
                                    </div>
                                                 
                                    <div class="form-group" >
                                          <label class="col-sm-2 control-label">User Group</label>
                                                                        
                                       <div class="col-md-2">
                                            <input class="form-control" id="txtGroup" runat="server" placeholder="User ID" disabled="disabled" />
                                        
                                      </div>
                                
                                       <div class="col-md-8">
                                           
                                       
                                             <input class="form-control" id="txtUserGroup" runat="server" placeholder="Group" disabled="disabled"/>

                                        </div>
                                       </div>
                                  
                                   

                                    <div class="form-group">
                                        <label for="dcbBranch" class="col-sm-2 control-label">Branch</label>
                                                                  
                                      <div class="col-sm-10">
                                           <input class="form-control" id="txtBranch" runat="server" placeholder="Group" disabled="disabled"/>
                                           
                                     </div>
                      
                                    </div>
                                    

                                  <div class="form-group">
                                        <label for="dcbDept" class="col-sm-2 control-label">Dept</label>
                                                                   
                                      <div class="col-sm-10">
                                          <input class="form-control" id="txtDept" runat="server" placeholder="Group" disabled="disabled"/>
                                      
                                        </div>
                      
                                    </div>

                              
                              
                                    <!-- /.box-body -->
                             </div>
                           </div>
                             
                       </from>
                          
                        <!--/.row-->
                    </div>
                    <div class="box-header with-border">
                        <h3 class="box-title">Permission</h3>
                    </div>
                     <div class="row">
                         <div class="col-lg-8 col-md-8 col-md-offset-3">

                               <div class="form-group">
                                 <div class="col-lg-2 col-md-2">
                                     <!-- form start -->
                                   
                                         <div class="box-body">
                                             <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkAdd" disabled="disabled"/> Add
                                                 </label>
                                             </div>
                                             <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkImport" disabled="disabled"/> Import
                                                  
                                                 </label>
                                             </div>

                                             <!--/.box-body-->
                                         </div>
                                
                                     <!--/.col-lg-2 col-md-2--->
                                 </div>

                                 <div class="col-lg-2 col-md-2">
                                     <!-- form start -->
                                     
                                         <div class="box-body">

                                             <div class="checkbox">
                                                 <label>
                                                      <input type="checkbox" runat="server" id="chkModify" disabled="disabled"/>Modify
                                                    
                                                 </label>
                                             </div>
                                             <div class="checkbox">
                                                 <label>
                                                        <input  type="checkbox" runat ="server" id="chkExport" disabled="disabled"/>Export
                                              
                                                 </label>
                                             </div>

                                             <!--/.box-body-->
                                         </div>
                                 
                                     <!--/.col-lg-2 col-md-2--->
                                 </div>
                                 <div class="col-lg-2 col-md-2">
                                     <!-- form start -->
                                
                                         <div class="box-body">

                                             <div class="checkbox">
                                                 <label>
                                                      <input  type="checkbox" runat="server" id="chkDelete" disabled="disabled"/>Delete
                                                   
                                                 </label>
                                             </div>
                                             <div class="checkbox">
                                                 <label>
                                                       <input  type="checkbox" runat="server" id="chkWarehouse" disabled="disabled"/>Warehouse
                                                  
                                                 </label>
                                             </div>

                                             <!--/.box-body-->
                                         </div>
                              
                                     <!--/.col-lg-2 col-md-2--->
                                 </div>
                                 <div class="col-lg-2 col-md-2">
                                     <!-- form start -->
                                   
                                         <div class="box-body">

                                             <div class="checkbox">
                                                 <label>
                                                    <input  type="checkbox" runat="server" id="chkPrint" disabled="disabled"/>Print
                                                 
                                                 </label>
                                             </div>
                                             <!--/.box-body-->
                                         </div>
                                 
                                     <!--/.col-lg-2 col-md-2--->
                                 </div>
   
                             </div> 
                          </div>
                           
                        
                        </div>
                         <!--/.row-->

                    <div class="box-header with-border">
                        <h3 class="box-title">User Status</h3>
                    </div>
                     <div class="row">
                         <div class="col-lg-8 col-md-8 col-md-offset-3">
                             
                                 <!-- form start -->
                            
                                 <div class="form-group">
                                     <div class="radio">
                                         <label>
                                             <input type="radio" name="optionsRadios" runat="server" id ="rdbEnable" value="option1" disabled="disabled"/>
                                             Enable
                                         </label>
                                     </div>
                                  <div class="radio">
                                         <label>
                                             <input type="radio" name="optionsRadios" runat="server" id="rdbDisable" value="option2" disabled="disabled"/>
                                             Disable
                                         </label>
                                     </div>
                                 </div>
                                                
                             </div> 
                          </div>
                
                    </div>
                </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
</form>
 </asp:Content>

