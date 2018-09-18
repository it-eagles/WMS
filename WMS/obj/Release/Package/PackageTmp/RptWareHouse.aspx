<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RptWareHouse.aspx.vb" Inherits="WMS.RptWareHouse" MasterPageFile="~/Home.Master" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Report Ware House   
        </h1>
        <ol class="breadcrumb">
            <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
            <li><a><i class="fa fa-file"></i>Report</a></li>     
            <li><a href="RptWareHouse.aspx">Report Ware House</a></li>
           
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
                        <h3 class="box-title">Report Ware House</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <div class="form-horizontal">
                                                   
                                                      <div class="box-body">   
                                                          <div class="col-md-4 col-sm-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtDocType" class="col-sm-4 control-label">Doc Type:</label>                                      
                                                                 <div class="col-sm-8">
                                                                    <asp:DropDownList ID="ddlDocType" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                 </div>
                                                              </div>
                                                              <div class="form-group">
                                                                  <label for="txtJobno" class="col-sm-4 control-label">Job No:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtJobno" runat="server" placeholder="Job No"/>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtPartNo" class="col-sm-4 control-label">Part No:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtPartNo" runat="server" placeholder="Job No"/>
                                                                </div>
                                                                  </div>  
                                                              <div class="form-group">
                                                                  <label for="txtLocationNo" class="col-sm-4 control-label">Location No:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtLocationNo" runat="server" placeholder="Job No"/>
                                                                </div>
                                                                  </div>       
                                                              <div class="form-group">
                                                                  <label for="txtCusRefNo" class="col-sm-4 control-label">CUSREF No:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtCusRefNo" runat="server" placeholder="Job No"/>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtOrderNo" class="col-sm-4 control-label">Order No:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtOrderNo" runat="server" placeholder="Job No"/>
                                                                </div>
                                                                  </div>      
                                                              <div class="form-group">
                                                                  <label for="txtReceivedDate" class="col-sm-5 control-label">Received Date:</label>    
                                                                  <div class="col-sm-1">
                                                                        <label>
                                                                           <input type="checkbox" runat="server" id="chkReceivedDate" />
                                                                      </label>            
                                                                  </div>                                    
                                                                <div class="col-sm-6">
                                                                    <input class="form-control" id="txtReceivedDate" runat="server" placeholder="Job No"/>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtIssuedDate" class="col-sm-5 control-label">Issued Date:</label>    
                                                                  <div class="col-sm-1">
                                                                        <label>
                                                                           <input type="checkbox" runat="server" id="chkIssuedDate" />
                                                                      </label>            
                                                                  </div>                                    
                                                                <div class="col-sm-6">
                                                                    <input class="form-control" id="txtIssuedDate" runat="server" placeholder="Job No"/>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtCusCode" class="col-sm-4 control-label">Cus Code:</label>                                       
                                                                <div class="col-sm-8">                                            
                                                                     <asp:DropDownList ID="ddlCusCode" CssClass="form-control" runat="server"></asp:DropDownList>  
                                                                 </div>
                                                               </div>
                                                              <div class="form-group">
                                                                  <label for="txtENDUserCode" class="col-sm-4 control-label">END User Code:</label>                                       
                                                                <div class="col-sm-8">                                            
                                                                     <asp:DropDownList ID="ddlENDUserCode" CssClass="form-control" runat="server"></asp:DropDownList>  
                                                                 </div>
                                                               </div>
                                                                                                            
                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group">
                                                                  <label for="txtWHSite" class="col-sm-4 control-label">WH Site:</label>                                       
                                                                <div class="col-sm-8">                                            
                                                                     <asp:DropDownList ID="ddlWHSite" CssClass="form-control" runat="server"></asp:DropDownList>  
                                                                 </div>
                                                               </div>
                                                              <div class="form-group">
                                                                  <label for="txtToJobno" class="col-sm-4 control-label">To:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtToJobno" runat="server"/>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtToPartNo" class="col-sm-4 control-label">To:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtToPartNo" runat="server"/>
                                                                </div>
                                                                  </div>  
                                                              <div class="form-group">
                                                                  <label for="txtToLocationNo" class="col-sm-4 control-label">To:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtToLocationNo" runat="server"/>
                                                                </div>
                                                                  </div>       
                                                              <div class="form-group">
                                                                  <label for="txtToCusRefNo" class="col-sm-4 control-label">To:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtToCusRefNo" runat="server"/>
                                                                </div>
                                                                  </div>    
                                                              <div class="form-group">
                                                                  <label for="txtWHSource" class="col-sm-4 control-label">WH Soucre:</label>                                       
                                                                <div class="col-sm-8">
                                                                    <input class="form-control" id="txtWHSource" runat="server"/>
                                                                </div>
                                                                  </div> 
                                                              <div class="form-group">
                                                                  <label for="txtToReceivedDate" class="col-sm-4 control-label">To:</label>    
                                                                  <div class="col-sm-1">
                                                                        <label>
                                                                           <input type="checkbox" runat="server" id="chkToReceivedDate" />
                                                                      </label>            
                                                                  </div>                                    
                                                                <div class="col-sm-7">
                                                                    <input class="form-control" id="txtToReceivedDate" runat="server"/>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtToIssuedDate" class="col-sm-4 control-label">To:</label>    
                                                                  <div class="col-sm-1">
                                                                        <label>
                                                                           <input type="checkbox" runat="server" id="chkToIssuedDate" />
                                                                      </label>            
                                                                  </div>                                    
                                                                <div class="col-sm-7">
                                                                    <input class="form-control" id="txtToIssuedDate" runat="server"/>
                                                                </div>
                                                                  </div>
                                                              <div class="form-group">
                                                                  <label for="txtToCusCode" class="col-sm-4 control-label">To:</label>                                       
                                                                <div class="col-sm-8">                                            
                                                                     <asp:DropDownList ID="ddlToCusCode" CssClass="form-control" runat="server"></asp:DropDownList>  
                                                                 </div>
                                                               </div>
                                                              <div class="form-group">
                                                                  <label for="txtToENDUserCode" class="col-sm-4 control-label">To:</label>                                       
                                                                <div class="col-sm-8">                                            
                                                                     <asp:DropDownList ID="ddlToENDUserCode" CssClass="form-control" runat="server"></asp:DropDownList>  
                                                                 </div>
                                                               </div>     
                                                                  

                                                          </div>

                                                          <div class="col-md-4"> 
                                                              <div class="form-group" style="height:34px;">
                                                                  <div class="col-sm-3"></div>
                                                                  <div class="col-sm-4">
                                                                        <label>
                                                                           <input type="checkbox" runat="server" id="chkAllNJR" />AllNJR
                                                                      </label>            
                                                                   </div>
                                                                  </div>
                                                                  <div class="form-group" style="height:34px;">
                                                                      <div class="col-sm-3"></div>
                                                                     <label for="txtLiveOfGoods" class="col-sm-4 control-label">Live Of Goods:</label>                                                           
                                                              </div>
                                                              <div class="form-group" style="height:34px;">
                                                                            <div class="col-sm-3"></div>
                                                                            <div class="col-sm-5">
                                                                            <div class="radio">
                                                                            <label>                                            
                                                                             <asp:RadioButton runat="server" ID ="rdbExpireDate" Text="Expire Date"  onclick="EnableDisableTextBox();"  GroupName="option1" />
                                                                          </label>
                                                                           </div>            
                                                                       </div>
                                                                  </div>
                                                             <div class="form-group" style="height:34px;">
                                                                            <div class="col-sm-3"></div>
                                                                            <div class="col-sm-5">
                                                                            <div class="radio">
                                                                            <label>                                            
                                                                             <asp:RadioButton runat="server" ID ="rdbNotExpire" Text="Not Expire" onclick="EnableDisableTextBox();" GroupName="option1"/>
                                                                          </label>
                                                                           </div>            
                                                                       </div>                                 
                                                            </div>
                                                              <div class="form-group">
                                                                  <label for="txtTypeOfGoods" class="col-sm-4 control-label">TypeOfGoods:</label>                                       
                                                                <div class="col-sm-8">                                            
                                                                     <asp:DropDownList ID="ddlTypeOfGoods" CssClass="form-control" runat="server"></asp:DropDownList>  
                                                                 </div>
                                                               </div>
                                                              <div class="form-group">
                                                                  <label for="txtEndCustomer" class="col-sm-4 control-label">End Customer:</label>                                       
                                                                <div class="col-sm-8">                                            
                                                                     <asp:DropDownList ID="ddlEndCustomer" CssClass="form-control" runat="server"></asp:DropDownList>  
                                                                 </div>
                                                               </div>
                                                              <div class="form-group" >   
                                                                    <div class="col-sm-3"></div>       
                                                                    <div class="col-sm-6">                       
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnListData" title="btnListData" onserverclick="btnListData_ServerClick">List Data</button>
                                                                    </div>   
                                                              </div>
                                                              <div class="form-group" >   
                                                                    <div class="col-sm-3"></div>    
                                                                    <div class="col-sm-6">                                
                                                                    <button type="submit" runat="server" class="btn btn-primary" id="btnReport" title="btnReport" onserverclick="btnReport_ServerClick">Report</button>
                                                                    </div>
                                                              </div>

                                                          </div>
                                                           
                                                                                                                                            
                                    <!-- /.box-body -->
                             </div>
                            <!-- /.box-header -->
                        
                       </div>
                          
                        <!--/.row-->
                    </div>
                    
                     
                         <!--/.row-->
                     </div>
                       
                    
                    <!--/.box box-primary-->
                </div>
                <!--/.col-lg-12 -->
            </div>

            <!--/.col (right) -->
        
        <!-- /.row -->
    </section>
    <!-- /.content -->

        <script type="text/javascript">
          function EnableDisableTextBox() {
              var status = document.getElementById('<%=rdbExpireDate.ClientID%>').checked;
             
              if (status == true) {
                <%--document.getElementById('<%=txtWidth.ClientID%>').disabled = true;
                document.getElementById('<%=txtLong.ClientID%>').disabled = true;
                document.getElementById('<%=txtHeigth.ClientID%>').disabled = true;
                document.getElementById('<%=txtValume.ClientID%>').disabled = true;
                document.getElementById('<%=txtUsedStatus.ClientID%>').disabled = true;        
                document.getElementById('<%=txtQTYPallet.ClientID%>').disabled = false;  --%>
            } else if (status == false){
               <%-- document.getElementById('<%=txtWidth.ClientID%>').disabled = false;
                document.getElementById('<%=txtLong.ClientID%>').disabled = false;
                document.getElementById('<%=txtHeigth.ClientID%>').disabled = false;
                document.getElementById('<%=txtValume.ClientID%>').disabled = false;
                document.getElementById('<%=txtUsedStatus.ClientID%>').disabled = false;
                document.getElementById('<%=txtQTYPallet.ClientID%>').disabled = true; --%> 
               
            }
             
        }
    </script>

</form>
 </asp:Content>