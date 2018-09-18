<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestCode.aspx.vb" Inherits="WMS.TestCode"%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
  <title>Test : Project</title>
      <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.7 -->
  <link rel="stylesheet" href="Scripts/bootstrap/dist/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="Scripts/font-awesome/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="Scripts/Ionicons/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="Scripts/dist/css/AdminLTE.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="Scripts/plugins/iCheck/square/blue.css">
     <style>
        a img{border: none;}
        ol li{list-style: decimal outside;}
        div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
        div.side-by-side{width: 100%;margin-bottom: 1em;}
        div.side-by-side > div{float: left;width: 50%;}
        div.side-by-side > div > em{margin-bottom: 10px;display: block;}
        .clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
        
    </style>
</head>
<body class="hold-transition login-page">
    <form runat="server" id="form1">
        <div id="container">
            <a>TEST TEST</a>
            <h2>Selected Value :
                <asp:Label runat="server" ID="lblSelectedValue" Style="color: red"></asp:Label></h2>
            <div class="side-by-side clearfix">

                <div>

                    <asp:DropDownList data-placeholder="Choose a Country..." runat="server" ID="cboCountry" class="chzn-select" Style="width: 350px;">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="United States" Value="United States"></asp:ListItem>
                        <asp:ListItem Text="United Kingdom" Value="United Kingdom"></asp:ListItem>
                        <asp:ListItem Text="Albania" Value="Albania"></asp:ListItem>
                        <asp:ListItem Text="Algeria" Value="Algeria"></asp:ListItem>
                        <asp:ListItem Text="Angola" Value="Angola"></asp:ListItem>
                        <asp:ListItem Text="Bahamas" Value="Bahamas">Bahamas</asp:ListItem>
                        <asp:ListItem Text="Bahrain" Value="Bahrain"></asp:ListItem>
                        <asp:ListItem Text="Brazil" Value="Brazil"></asp:ListItem>
                        <asp:ListItem Text="Czech Republic" Value="Czech Republic"></asp:ListItem>
                        <asp:ListItem Text="Denmark" Value="Denmark"></asp:ListItem>
                        <asp:ListItem Text="Djibouti" Value="Djibouti"></asp:ListItem>
                        <asp:ListItem Text="Dominica" Value="Dominica"></asp:ListItem>
                        <asp:ListItem Text="Dominican Republic" Value="Dominican Republic"></asp:ListItem>

                    </asp:DropDownList><asp:Button runat="server" ID="btnSelect" Text="Get Selected" OnClick="btnSelect_Click" />

                </div>
            </div>

        </div>
        <script src="Scripts/jquery.min.js" type="text/javascript"></script>
        <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
        <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    </form>
</body>
</html>
