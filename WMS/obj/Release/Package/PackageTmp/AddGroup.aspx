<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddGroup.aspx.vb" MasterPageFile="~/Home.Master"  Inherits="WMS.AddGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
<!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Add Master Code
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i> Home</a></li>
             <li><a class="active"><i class="fa fa-file"></i>Master Files</a></li>
            <li><a href="MasterCode.aspx">Master Code</a></li>
            <li class="active">Add Group</li>
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">

      <div class="row">
            <!-- left column -->

             <div class="col-lg-12 col-xs-12">

                        <div class="box">
                            <!-- /.box-header -->
                            <div class="box-body">
                                <div class="form-horizontal">
                           <div class="box-body">   
                                <div class="form-group" >
                                        <label for="txtType" class="col-sm-3 control-label">Type</label>
                                         <div class="col-sm-6">
                                            <input class="form-control input-sm" id="txtType" runat="server" placeholder="Type" />
                                        </div>
                                    </div>               
                                    <div class="form-group" >
                                    
                                        <label for="txtCode" class="col-sm-3 control-label">Code</label>
                                       
                                         <div class="col-sm-6">
                                            <input class="form-control input-sm" id="txtCode" runat="server" placeholder="Code"/>
                                        </div>
                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtDescription" class="col-sm-3 control-label">Description</label>
                                      
                                      <div class="col-sm-6">
                                           <%--<input class="form-control input-sm" id="txtDescription" runat="server" placeholder="Description"/>--%>
                                          <asp:TextBox runat="server" Cssclass="form-control input-sm" TextMode="MultiLine" Height="135px"  ID="txtDescription2" ></asp:TextBox>
                                        </div>
                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtNotes" class="col-sm-3 control-label">Notes</label>
                                           <div class="col-sm-6">
                                                <asp:TextBox runat="server" Cssclass="form-control input-sm" TextMode="MultiLine" Height="135px"  ID="txtNotes2" ></asp:TextBox>
                                           </div>
                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtFilteringIndicator" class="col-sm-3 control-label">FilteringIndicator</label>
                                         <div class="col-sm-6">
                                        <input class="form-control input-sm" id="txtFilteringIndicator" runat="server"  placeholder="FilteringIndicator"/>
                                       </div>
                                   
                                    </div>

                                 <div class="text-right">
                                   <div class="text-center">
                                    <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnAddGroup" title="btnAddUser" onserverclick="btnAddGroup_click">Add</button>
                                    <button type="submit" runat="server" class="btn btn-primary btn-sm" id="btnClear" title="btnClear" onserverclick="btnClear_click">Clear</button>
                                   </div>
                                 </div>
                                    <!-- /.box-body -->
                             </div>
                          
                       </div>               

                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                     
                     
<%--               <div class="tab-pane" id="timeline">
                 <!-- Post -->
                <div class="post">
                  <div class="row margin-bottom">              
                    <div class="col-lg-8 col-md-8 col-md-offset-2">
                       <form class="form-horizontal">
                           <div class="box-body">   
                                                           
                                    <div class="form-group" >                                    
                                        <label for="txtUserName" class="col-sm-2 control-label">TypeName</label>                                       
                                         <div class="col-sm-10">
                                             <input class="form-control input-sm" id="txtTypeName" runat="server" placeholder="Type Name"/>
                                        </div>                      
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="txtBranch" class="col-sm-2 control-label">Description</label>
                                       
                                      <div class="col-sm-10">
                                             <input class="form-control input-sm" id="txtTypeDes" runat="server" placeholder="Description"/>
                                        </div>                      
                                    </div>
                                      <div class="form-group">
                                        <label for="txtFullName" class="col-sm-2 control-label">Notes</label>
                                           <div class="col-sm-10">
                                              <input class="form-control input-sm" id="txtTypeNotes" runat="server"  placeholder="Notes"/>
                                           </div>                                      
                                    </div>

                                    <div class="form-group">
                                        <label for="txtDept" class="col-sm-2 control-label">Indicator</label>
                                         <div class="col-sm-10">
                                          <input class="form-control input-sm" id="txtIndicator" runat="server"  placeholder="indicator"/>
                                           </div>                                   
                                    </div>
                                 <div class="text-right">
                                      <button type="submit" runat="server" class="btn btn-primary" id="Button1" title="btnAddUser" onserverclick="btnAddTypeGroup_click">Record</button>
                                </div>
                                    <!-- /.box-body -->
                                </div>                          
                       </form>                                
                            <!--/.col-lg-6 col-md-6--->
                        </div>               
                        <!--/.row-->
                      </div>                    
                </div>              
              <!-- /.post -->                   
                 </div> --%>  


          </div>
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
</form>
 </asp:Content>
