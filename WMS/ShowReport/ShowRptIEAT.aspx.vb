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

Public Class ShowRptIEAT
    Inherits System.Web.UI.Page
    Private rpt As New ReportDocument
    Dim path As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim IEATPermit As String = Request.QueryString("IEATPermit")
            Dim IEATNo As String = Request.QueryString("IEATNo")
            Dim formdate As String = CStr(Session("formdate"))
            Dim toDate As String = CStr(Session("toDate"))
            Dim CheckImEx As String = CStr(Session("CheckImEx"))
            Dim CheckBy As String = CStr(Session("CheckBy"))
            Try
                If CheckImEx = "Export" Then
                    rpt.Load(Server.MapPath("../Report/rptIEATExport.rpt"))
                ElseIf CheckImEx = "Import" Then
                    rpt.Load(Server.MapPath("../Report/rptIEATImport.rpt"))
                End If


                'rpt.SetDatabaseLogon("sa", "36133HNVek", "LKBWarehouseTESTServer", "LKBWarehouse")
                rpt.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")

                If CheckBy = "Bydate" Then
                    rpt.SetParameterValue("Hub", "1")

                    IEATNo = ""
                    IEATPermit = ""
                ElseIf CheckBy = "ByIEATNo" Then
                    rpt.SetParameterValue("Hub", "2")

                    formdate = CStr(Now)
                    toDate = CStr(Now)
                    IEATPermit = ""
                ElseIf CheckBy = "ByIEATPermit" Then
                    rpt.SetParameterValue("Hub", "3")

                    formdate = CStr(Now)
                    toDate = CStr(Now)
                    IEATNo = ""
                End If

                rpt.SetParameterValue("DateStart", toDate)
                rpt.SetParameterValue("DateStop", formdate)
                rpt.SetParameterValue("IEATNo", IEATNo)
                rpt.SetParameterValue("IEATPermit", IEATPermit)

                CrystalReportViewer1.ReportSource = rpt

                If CheckImEx = "Export" Then
                    If CheckBy = "Bydate" Then
                        Dim _cultureEnInfo As New Globalization.CultureInfo("en-US")
                        Dim todateeee As String = CStr(Convert.ToDateTime(toDate, _cultureEnInfo).ToString("dd.MM.yyyy"))
                        CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "IEATExport-" + todateeee + ".pdf"))
                        path = Server.MapPath("../Files/" + "IEATExport-" + todateeee + ".pdf")
                    ElseIf CheckBy = "ByIEATNo" Then
                        CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "IEATExport-" + IEATNo + ".pdf"))
                        path = Server.MapPath("../Files/" + "IEATExport-" + IEATNo + ".pdf")
                    ElseIf CheckBy = "ByIEATPermit" Then
                        CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "IEATExport-" + IEATPermit + ".pdf"))
                        path = Server.MapPath("../Files/" + "IEATExport-" + IEATPermit + ".pdf")
                    End If
                    
                ElseIf CheckImEx = "Import" Then
                    If CheckBy = "Bydate" Then
                        Dim _cultureEnInfo As New Globalization.CultureInfo("en-US")
                        Dim todateeee As String = CStr(Convert.ToDateTime(toDate, _cultureEnInfo).ToString("dd.MM.yyyy"))
                        CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "IEATImport-" + todateeee + ".pdf"))
                        path = Server.MapPath("../Files/" + "IEATImport-" + todateeee + ".pdf")
                    ElseIf CheckBy = "ByIEATNo" Then
                        CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "IEATImport-" + IEATNo + ".pdf"))
                        path = Server.MapPath("../Files/" + "IEATImport-" + IEATNo + ".pdf")
                    ElseIf CheckBy = "ByIEATPermit" Then
                        CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "IEATImport-" + IEATPermit + ".pdf"))
                        path = Server.MapPath("../Files/" + "IEATImport-" + IEATPermit + ".pdf")
                    End If

                End If

                Dim client As New WebClient()
                Dim buffer As Byte() = client.DownloadData(path)

                If buffer IsNot Nothing Then
                    Response.ContentType = "application/pdf"
                    Response.AddHeader("content-length", buffer.Length.ToString())
                    Response.BinaryWrite(buffer)
                    Response.End()
                End If

            Catch ex As Exception
            End Try

        End If

    End Sub

End Class