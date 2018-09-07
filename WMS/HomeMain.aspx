<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HomeMain.aspx.vb" MasterPageFile="~/Home.Master" Inherits="WMS.HomeMain" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
            <!-- Content Wrapper. Contains page content -->
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Content Wrapper. Contains page content -->
        <!-- Content Wrapper. Contains page content -->

        <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Home 
  
                </h1>
                <ol class="breadcrumb">
                    <li><a href="HomeMain.aspx"><i class="fa fa-home"></i>Home</a></li>
                  
                </ol>
            </section>
      <!-- Main content -->
            <section class="content">
                <div class="row">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-aqua"><i class="ion ion-ios-gear-outline"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">CPU Traffic</span>
              <span class="info-box-number">90<small>%</small></span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red"><i class="fa fa-google-plus"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Likes</span>
              <span class="info-box-number">41,410</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->

        <!-- fix for small devices only -->
        <div class="clearfix visible-sm-block"></div>

        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-green"><i class="ion ion-ios-cart-outline"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Sales</span>
              <span class="info-box-number">760</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="ion ion-ios-people-outline"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">New Members</span>
              <span class="info-box-number">2,000</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
            <!-- /.content -->
          <%--     <div class="form-group" >
                                    
                
               <div class="box-footer text-right">
                   <label for="txtUserName" class="col-sm-2 control-label">User ID</label>
                                          
                <div class="col-sm-6">
                 <input class="form-control" id="txtUserName" runat="server" placeholder="User ID">
                </div>
                        <button type="submit" runat="server" class="btn btn-primary" id="btnAddUser" title="btnAddUser" onserverclick="btnAddUser_click">Submit</button>
                   
                    </div>    
                   </div>    --%>   

     <script>
        $(function () {

            // อัตราแลกเปลี่ยนเฉลี่ย (รายวัน)
            var daily_avg_exg_rate_chart = BotChartPlayer({
                elementID: 'chart_daily_avg_exg_rate',
                x_column: 'period',
                y_column: 'mid_rate',
               uri: 'https://iapi.bot.or.th/Stat/Stat-ExchangeRate/DAILY_AVG_EXG_RATE_V1'
           });

            $('#do-play').on('click', function () {
                daily_avg_exg_rate_chart.play($('#input-year').val(), $('#input-month').val());
            });
        })
    </script>

    </form>
</asp:Content>