Option Explicit On
Option Strict On
Option Infer On

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports System.Linq
Imports Microsoft.Reporting.WebForms
Imports System.Net
Imports System.Globalization

Public Class ShowRptWareHouse
    Inherits System.Web.UI.Page
    Private r As New ReportDocument
    Dim path As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim CheckDocType As String = CStr(Session("CheckDocType"))
            Dim CheckWHStie As String = CStr(Session("CheckWHStie"))
            Dim CheckType As String = CStr(Session("CheckType"))
            Dim CheckRecDate As String = CStr(Session("CheckRecDate"))
            Dim CheckIssueDate As String = CStr(Session("CheckIssueDate"))
            Dim Jobno As String = CStr(Session("Jobno"))
            Dim To_Jobno As String = CStr(Session("To_Jobno"))
            Dim Partno As String = CStr(Session("Partno"))
            Dim To_Partno As String = CStr(Session("To_Partno"))
            Dim Locationno As String = CStr(Session("Locationno"))
            Dim To_Locationno As String = CStr(Session("To_Locationno"))
            Dim Cusrefno As String = CStr(Session("Cusrefno"))
            Dim To_Cusrefno As String = CStr(Session("To_Cusrefno"))
            Dim Orderno As String = CStr(Session("Orderno"))
            Dim WHsource As String = CStr(Session("WHsource"))

            Dim _cultureEnInfo As New Globalization.CultureInfo("en-US")
            Dim ReceivedDate As String = CStr(Session("ReceivedDate"))
            Dim To_ReceivedDate As String = CStr(Session("To_ReceivedDate"))
            Dim IssuedDate As String = CStr(Session("IssuedDate"))
            Dim To_IssuedDate As String = CStr(Session("To_IssuedDate"))

            Dim Cuscode As String = CStr(Session("Cuscode"))
            Dim To_Cuscode As String = CStr(Session("To_Cuscode"))
            Dim Endusercode As String = CStr(Session("Endusercode"))
            Dim To_Endusercode As String = CStr(Session("To_Endusercode"))
            Dim Endcustomer As String = CStr(Session("Endcustomer"))
            Dim Checkallnjr As Integer = CInt(Session("Checkallnjr"))
            Try
                If CheckDocType = "Unstuffing Tally Report" Or CheckDocType = "Goods Receipt Note Report" Or CheckDocType = "Putaway List Report" _
                Or CheckDocType = "Receipt Discrepancy Report" Or CheckDocType = "Pick List/Ticket Report for Pick" Or CheckDocType = "Pick List/Ticket Report" Then

                    If CheckDocType = "Unstuffing Tally Report" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptWHUnstuffingTallyReport.rpt"))
                    ElseIf CheckDocType = "Goods Receipt Note Report" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptWHGoodsReceiptNote.rpt"))
                    ElseIf CheckDocType = "Putaway List Report" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptWHPutawayList.rpt"))
                    ElseIf CheckDocType = "Receipt Discrepancy Report" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptWHReceiptDiscrepancyReport.rpt"))
                    ElseIf CheckDocType = "Pick List/Ticket Report for Pick" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptWHPickTicketforPick.rpt"))
                    ElseIf CheckDocType = "Pick List/Ticket Report" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptWHPickTicketReport.rpt"))
                    End If


                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("LotNoFrom", Jobno)
                    r.SetParameterValue("LotNoTo", To_Jobno)
                    r.SetParameterValue("Type", CheckType)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    CrystalReportViewer1.ReportSource = r

                    If CheckDocType = "Unstuffing Tally Report" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHUnstuffingTallyReport-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "WHUnstuffingTallyReport-" + CheckWHStie + ".pdf")
                    ElseIf CheckDocType = "Goods Receipt Note Report" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHGoodsReceiptNote-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "WHGoodsReceiptNote-" + CheckWHStie + ".pdf")
                    ElseIf CheckDocType = "Putaway List Report" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHPutawayList-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "WHPutawayList-" + CheckWHStie + ".pdf")
                    ElseIf CheckDocType = "Receipt Discrepancy Report" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHReceiptDiscrepancyReport-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "WHReceiptDiscrepancyReport-" + CheckWHStie + ".pdf")
                    ElseIf CheckDocType = "Pick List/Ticket Report for Pick" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHPickTicketforPick-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "WHPickTicketforPick-" + CheckWHStie + ".pdf")
                    ElseIf CheckDocType = "Pick List/Ticket Report" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHPickTicketReport-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "WHPickTicketReport-" + CheckWHStie + ".pdf")
                    End If


                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If


                ElseIf CheckDocType = "Order Tally Report" Or CheckDocType = "Stock Out Report" Then

                    If CheckDocType = "Order Tally Report" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptWHOrderTallyReport.rpt"))
                    ElseIf CheckDocType = "Stock Out Report" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptWHStockOutReport.rpt"))
                    End If

                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("LotNoForm", Jobno)
                    r.SetParameterValue("LotNoTo", To_Jobno)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    CrystalReportViewer1.ReportSource = r

                    If CheckDocType = "Order Tally Report" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHOrderTallyReport-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "WHOrderTallyReport-" + CheckWHStie + ".pdf")
                    ElseIf CheckDocType = "Stock Out Report" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHStockOutReport-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "WHStockOutReport-" + CheckWHStie + ".pdf")
                    End If

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If


                ElseIf CheckDocType = "Issued Planned Report" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptWHIssuePlanned.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("FormDate", IssuedDate)
                    r.SetParameterValue("ToDate", To_IssuedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHIssuePlanned-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "WHIssuePlanned-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Receipt Planned Report" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptWHReceiptPlanned.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHReceiptPlanned-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "WHReceiptPlanned-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Picking Not Issued" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptWHPickingNotIssued.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("LotNoForm", Jobno)
                    r.SetParameterValue("LotNoTo", To_Jobno)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("FromCusCode", Cuscode)
                    r.SetParameterValue("EndUserCode", Endusercode)
                    r.SetParameterValue("Type", CheckType)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHPickingNotIssued-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "WHPickingNotIssued-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Product Inventory Detail Report" Or CheckDocType = "Product Inventory Detail For Export Report" Then

                    If CheckDocType = "Product Inventory Detail Report" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptWHProductInventoryDetail.rpt"))
                    ElseIf CheckDocType = "Product Inventory Detail For Export Report" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptWHProductInventoryDetailExport.rpt"))
                    End If

                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("OwnerCode", Cuscode)
                    r.SetParameterValue("OwnerPN", Partno)
                    r.SetParameterValue("LocationFrom", Locationno)
                    r.SetParameterValue("NJR", Checkallnjr)
                    CrystalReportViewer1.ReportSource = r

                    If CheckDocType = "Product Inventory Detail Report" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHProductInventoryDetail-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "WHProductInventoryDetail-" + CheckWHStie + ".pdf")
                    ElseIf CheckDocType = "Product Inventory Detail For Export Report" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHProductInventoryDetailExport-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "WHProductInventoryDetailExport-" + CheckWHStie + ".pdf")
                    End If

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "WareHouse Activity Report" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptWHActivityReport.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("CustomerForm", Cuscode)
                    r.SetParameterValue("CustomerTo", To_Cuscode)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHActivityReport-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "WHActivityReport-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Delivery Summary Report" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptWHDeliverySummary.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("CustomerForm", Cuscode)
                    r.SetParameterValue("CustomerTo", To_Cuscode)
                    r.SetParameterValue("FormDate", IssuedDate)
                    r.SetParameterValue("ToDate", To_IssuedDate)
                    r.SetParameterValue("FormProduct", Partno)
                    r.SetParameterValue("ToProduct", To_Partno)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHDeliverySummary-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "WHDeliverySummary-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Receipt Summary Report" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptWHReceiptSummaryReport.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("NJR", Checkallnjr)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHReceiptSummaryReport-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "WHReceiptSummaryReport-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Stock Movement Report" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptWHStockMovementreport.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Customer", Cuscode)
                    r.SetParameterValue("FromDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("FromProduct", Partno)
                    r.SetParameterValue("ToProduct", To_Partno)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHStockMovementreport-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "WHStockMovementreport-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Product Inventory Summary Report" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptWHProductInventorySummary.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("CustomerF", Cuscode)
                    r.SetParameterValue("CustomerT", To_Cuscode)
                    r.SetParameterValue("ProductF", Partno)
                    r.SetParameterValue("ProductT", To_Partno)
                    r.SetParameterValue("LocationF", Locationno)
                    r.SetParameterValue("LocationT", To_Locationno)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "WHProductInventorySummary-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "WHProductInventorySummary-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "HTI Stock Report" Then

                    r.Load(Server.MapPath("../Report/ReportWH/HTIStockReport.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("SDate", CheckRecDate)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("WHSource", WHsource)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "HTIStockReport-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "HTIStockReport-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Stock Report New" Then

                    r.Load(Server.MapPath("../Report/ReportWH/HTIStockReport-New.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("SDate", CheckRecDate)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("WHSource", WHsource)
                    r.SetParameterValue("TypeDamage", CheckType)
                    r.SetParameterValue("NJR", Checkallnjr)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "HTIStockReport-New-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "HTIStockReport-New-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Summary Receipt" Then

                    r.Load(Server.MapPath("../Report/ReportWH/HTISummary_Receipt.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("CusRefNo", Cusrefno)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("OrderNo", Orderno)
                    r.SetParameterValue("ENDCustomer", Endcustomer)
                    r.SetParameterValue("NJR", Checkallnjr)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "HTISummary_Receipt-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "HTISummary_Receipt-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "General Stock Report" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptStockReport-New.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("SDate", CheckRecDate)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("WHSource", WHsource)
                    r.SetParameterValue("TypeDamage", CheckType)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "StockReport-New-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "StockReport-New-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Check Summary Receipt" Then

                    r.Load(Server.MapPath("../Report/ReportWH/HTISummary_Receipt-forCheck.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("CusRefNo", Cusrefno)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("OrderNo", Orderno)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "HTISummary_Receipt-forCheck-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "HTISummary_Receipt-forCheck-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Summary Issue" Then

                    r.Load(Server.MapPath("../Report/ReportWH/HTISummary_Issue.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("FormDate", IssuedDate)
                    r.SetParameterValue("ToDate", To_IssuedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("CusRefNo", Cusrefno)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("OrderNo", Orderno)
                    r.SetParameterValue("ENDCustomer", Endcustomer)
                    r.SetParameterValue("NJR", Checkallnjr)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "HTISummary_Issue-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "HTISummary_Issue-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Summary Unpicking Report" Then

                    r.Load(Server.MapPath("../Report/ReportWH/HTISummary_Unpick.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("CusRefNo", Cusrefno)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("OrderNo", Orderno)
                    r.SetParameterValue("NJR", Checkallnjr)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "HTISummary_Unpick-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "HTISummary_Unpick-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "HTI Quarantine Stock Control" Then

                    r.Load(Server.MapPath("../Report/ReportWH/HTIStockControl.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("OrderNo", Orderno)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "HTIStockControl-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "HTIStockControl-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Check HTI Quarantine Stock Control" Then

                    r.Load(Server.MapPath("../Report/ReportWH/HTIStockControlWithCheck.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("OrderNo", Orderno)
                    r.SetParameterValue("TypeDamage", CheckType)
                    r.SetParameterValue("UsedDate", CheckRecDate)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "HTIStockControlWithCheck-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "HTIStockControlWithCheck-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Summary Job Receipt From LKB" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptSummaryofReceiptBox.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Fromdate", ReceivedDate)
                    r.SetParameterValue("Todate", To_ReceivedDate)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "SummaryofReceiptBox-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "SummaryofReceiptBox-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Summary Job Issued From LKB" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptSummaryofIssuedBox.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Fromdate", IssuedDate)
                    r.SetParameterValue("Todate", To_IssuedDate)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "SummaryofIssuedBox-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "SummaryofIssuedBox-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "HTI Stock Take" Then

                    r.Load(Server.MapPath("../Report/ReportWH/HTIPhysicalCount.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("WHSite", CheckWHStie)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("Location", Locationno)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "HTIPhysicalCount-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "HTIPhysicalCount-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Other Summary Receipt" Or CheckDocType = "Other Summary Issue" Then

                    If CheckDocType = "Other Summary Receipt" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptSummary_Receipt.rpt"))
                    ElseIf CheckDocType = "Other Summary Issue" Then
                        r.Load(Server.MapPath("../Report/ReportWH/rptSummary_Issue.rpt"))
                    End If

                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("CusRefNo", Cusrefno)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("OrderNo", Orderno)
                    CrystalReportViewer1.ReportSource = r

                    If CheckDocType = "Other Summary Receipt" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "Summary_Receipt-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "Summary_Receipt-" + CheckWHStie + ".pdf")
                    ElseIf CheckDocType = "Other Summary Issue" Then
                        CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "Summary_Issue-" + CheckWHStie + ".pdf"))
                        path = Server.MapPath("../Files/" + "Summary_Issue-" + CheckWHStie + ".pdf")
                    End If

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                ElseIf CheckDocType = "Other Quarantine Stock Control" Then

                    r.Load(Server.MapPath("../Report/ReportWH/rptStockControl.rpt"))
                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    r.SetParameterValue("Owner", Cuscode)
                    r.SetParameterValue("WarehouseSite", CheckWHStie)
                    r.SetParameterValue("PartNo", Partno)
                    r.SetParameterValue("OrderNo", Orderno)
                    r.SetParameterValue("FormDate", ReceivedDate)
                    r.SetParameterValue("ToDate", To_ReceivedDate)
                    CrystalReportViewer1.ReportSource = r

                    CType(r, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "StockControl-" + CheckWHStie + ".pdf"))
                    path = Server.MapPath("../Files/" + "StockControl-" + CheckWHStie + ".pdf")

                    Dim client As New WebClient()
                    Dim buffer As Byte() = client.DownloadData(path)

                    If buffer IsNot Nothing Then
                        Response.ContentType = "application/pdf"
                        Response.AddHeader("content-length", buffer.Length.ToString())
                        Response.BinaryWrite(buffer)
                        Response.End()
                    End If

                End If
            Catch ex As Exception

            End Try
        End If

    End Sub
    Protected Sub CrystalReportViewer1_Unload(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Unload
        r.Close()
        r.Dispose()
        GC.Collect()
    End Sub
End Class