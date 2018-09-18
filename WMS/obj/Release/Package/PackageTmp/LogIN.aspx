﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LogIN.aspx.vb" Inherits="WMS.LogIN" %>

<%--<%@ OutputCache Duration="300" VaryByParam="none" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eaglesthai.com | WMS</title>

    <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
  <!-- Bootstrap 3.3.7 -->
  <link rel="stylesheet" href="Scripts/bootstrap/dist/css/bootstrap.min.css"/>
  <!-- Font Awesome -->
  <link rel="stylesheet" href="Scripts/font-awesome/css/font-awesome.min.css"/>
  <!-- Ionicons -->
  <link rel="stylesheet" href="Scripts/Ionicons/css/ionicons.min.css"/>
  <!-- Theme style -->
  <link rel="stylesheet" href="Scripts/dist/css/AdminLTE.min.css"/>
  <!-- iCheck -->
  <link rel="stylesheet" href="Scripts/plugins/iCheck/square/blue.css"/>

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

  <!-- Google Font -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"/>
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
    <div class="login-box">
  <div class="login-logo">
    <a><b>Eaglesthai</b>WMS</a>
  </div>
  <!-- /.login-logo -->
  <div class="login-box-body">
    <p class="login-box-msg">Sign in to start your session</p>

   
      <div class="form-group has-feedback">
        <input type="text" autocapitalize="off" class="form-control" placeholder="User Name" runat="server" id="txtusername" required="required" autofocus="autofocus" autocomplete="off" onkeyup="myFunction()"/>
        <span class="form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="password" class="form-control" placeholder="Password" runat="server" id="txtpassword" required="required" />
        <span class="form-control-feedback btn-sm"></span>
      </div>
      <div class="row">
        <div class="col-xs-8">
          <asp:Label ID="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />
        </div>
        <!-- /.col -->
        <div class="col-xs-4">
             <asp:Button CssClass="btn btn-primary btn-block btn-flat" ID="btnSigIN" runat="server" Text="Sign in"/>
        </div>
        <!-- /.col -->
      </div>
   

    <!-- /.social-auth-links -->

  </div>
  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->

<!-- jQuery 3 -->
<script src="Scripts/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap 3.3.7 -->
<script src="Scripts/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src="Scripts/plugins/iCheck/icheck.min.js"></script>
<script>
  $(function () {
    $('input').iCheck({
      checkboxClass: 'icheckbox_square-blue',
      radioClass: 'iradio_square-blue',
      increaseArea: '20%' /* optional */
    });
  });
</script>
 
 <script>
    function myFunction() {
    var x = document.getElementById("txtusername");
        x.value = x.value.toUpperCase();
      }
</script>
    </form>
</body>
</html>
