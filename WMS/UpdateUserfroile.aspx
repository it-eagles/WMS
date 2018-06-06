<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UpdateUserfroile.aspx.vb" MasterPageFile="~/Home.Master" Inherits="WMS.UpdateUserfroile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
      
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <section class="content-header">
        <h1>
            User Profile
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>System</a></li>     
            <li><a href="UserFroile.aspx">User Profile</a></li>
            <li class="active">Update Userfrolie</li>
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">

        <div class="row">
            <!-- left column -->
            <div class="col-lg-12 col-md-12 ">

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
                                           <input class="form-control" id="txtUserName" runat="server" placeholder="User ID">
                                        </div>
                                    </div>
                                  <div class="form-group">
                                        <label for="txtFullName" class="col-sm-2 control-label">Name</label>
                                           <div class="col-sm-10">
                                           <input class="form-control" id="txtFullName" runat="server"  placeholder="Name">
                                       </div>
                                      
                                    </div>
                                                 
                                    <div class="form-group" >
                                          <label class="col-sm-2 control-label">User Group</label>
                                                                        
                                       <div class="col-md-2">
                                 
                                            <asp:DropDownList ID="dcboUserGroup" CssClass="form-control" runat="server" AutoPostBack="true" DataTextField="UserGroupCode" DataValueField="UserGroupID"></asp:DropDownList>
                                     
                                      </div>
                                
                                       <div class="col-md-8">
                                           
                                       
                                             <input class="form-control" id="txtUserGroup" runat="server" placeholder="Group" disabled>

                                        </div>
                                       </div>
                                  
                                   

                                    <div class="form-group">
                                        <label for="dcbBranch" class="col-sm-2 control-label">Branch</label>
                                                                  
                                      <div class="col-sm-10">
                                           <asp:DropDownList ID="dcbBranch" CssClass="form-control" runat="server" DataTextField="BranchName" DataValueField="BranchID"></asp:DropDownList>
                                        </div>
                      
                                    </div>
                                    

                                  <div class="form-group">
                                        <label for="dcbDept" class="col-sm-2 control-label">Dept</label>
                                                                   
                                      <div class="col-sm-10">
                                       <asp:DropDownList ID="dcbDept" CssClass="form-control" runat="server" DataTextField="DepartmentName" DataValueField="DepartmentID"></asp:DropDownList>
                                        </div>
                      
                                    </div>

                                <div class="form-group">
                                        <label for="txtPassword" class="col-sm-2 control-label">Password</label>
                                                      
                                      <div class="col-sm-10">
                                         <input type="password" class="form-control" id="txtPassword" runat="server" placeholder="Password">
                                        </div>
                      
                                    </div>
                               <div class="form-group">
                                        <label for="txtConfirmPassword" class="col-sm-2 control-label">Password Again</label>
                                                             
                                      <div class="col-sm-10">
                                        <input type="password" class="form-control" id="txtConfirmPassword" runat="server"  placeholder="Password Again">
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
                                                     <input type="checkbox" runat="server" id="chkAdd"> Add
                                                 </label>
                                             </div>
                                             <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkImport"> Import
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
                                                     <input type="checkbox" runat="server" id="chkModify"> Modify

                                                 </label>
                                             </div>
                                             <div class="checkbox">
                                                 <label>

                                                     <input type="checkbox" runat="server" id="chkExport"> Export
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
                                                     <input type="checkbox" runat="server" id="chkDelete"> Delete

                                                 </label>
                                             </div>
                                             <div class="checkbox">
                                                 <label>
                                                     <input type="checkbox" runat="server" id="chkWarehouse"> Warehouse
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
                                                     <input type="checkbox" runat="server" id="chkPrint"> Print
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
                                             <input type="radio" name="optionsRadios" runat="server" id ="rdbEnable" value="option1" checked>
                                             Enable
                                         </label>
                                     </div>
                                     <div class="radio">
                                         <label>
                                             <input type="radio" name="optionsRadios" runat="server" id="rdbDisable" value="option2">
                                             Disable
                                         </label>
                                     </div>
                                 </div>
                                                
                             </div> 
                          </div>

                    <div class="box-footer text-right">
                        <button type="submit" runat="server" class="btn btn-primary" id="btnUpdateUser" title="btnUpdateUser" onserverclick="btnUpdateUser_Click">Update</button>
                    </div>
                     </div>
                       
                    
                    <!--/.box box-primary-->
                </div>
                <!--/.col-lg-12 -->
            </div>

            <!--/.col (right) -->
        
        <!-- /.row -->
    </section>
    <!-- /.content -->


    </form>
</asp:Content>