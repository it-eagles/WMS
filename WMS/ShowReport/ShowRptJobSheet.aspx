﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ShowRptJobSheet.aspx.vb" Inherits="WMS.ShowRptJobSheet" EnableEventValidation="false" EnableViewState="true"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" Height="50px"  ToolPanelWidth="200px" Width="350px" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
        <%--<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Report\rptSummaryJOBOut.rpt">
            </Report>
        </CR:CrystalReportSource>--%>
   

    
        <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"  EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" AutoDataBind="true"/>--%>
        <%--<CR:CrystalReportSource ID="CrystalReportSource1" runat="server" >
            <Report FileName="Report\rptSummaryJobIn.rpt">
            </Report>
        </CR:CrystalReportSource>--%>
    </div>
    </form>
</body>
</html>
