﻿Option Explicit On
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

Public Class ShowRptJobSheet
    Inherits System.Web.UI.Page
    Private _ReportSource As Object
    Private crvReport As Object
    Private rpt As New ReportDocument
    Dim path As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim WHSite As String = Request.QueryString("WHSite")
            Dim formdate As String = CStr(Session("formdate"))
            Dim toDate As String = CStr(Session("toDate"))
            Dim Export As Boolean = CBool(Session("Export"))
            Try
                'PV = New frmExpCustomsInvoiceRPT2
                If Export = True Then
                    rpt.Load(Server.MapPath("../Report/rptSummaryJOBOut.rpt"))
                Else
                    rpt.Load(Server.MapPath("../Report/rptSummaryJOBIn.rpt"))
                End If


                'rpt.SetDatabaseLogon("sa", "36133HNVek", "LKBWarehouseTESTServer", "LKBWarehouse")
                rpt.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                rpt.SetParameterValue("FromDate", formdate)
                rpt.SetParameterValue("ToDate", toDate)
                rpt.SetParameterValue("JOBSite", WHSite)
                CrystalReportViewer1.ReportSource = rpt
<<<<<<< HEAD

                'CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "SummaryJOBOut-" + WHSite + ".pdf"))
                'Dim path As String = Server.MapPath("../Files/" + "SummaryJOBOut-" + WHSite + ".pdf")
                'Dim client As New WebClient()
                'Dim buffer As Byte() = client.DownloadData(path)
=======
>>>>>>> 84fdd0a79da4d2dced63e746bcf8c0a3c7f98e97

                If Export = True Then
                    CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "SummaryJOBOut-" + WHSite + ".pdf"))
                    path = Server.MapPath("../Files/" + "SummaryJOBOut-" + WHSite + ".pdf")
                Else
                    CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Files/" + "SummaryJOBIn-" + WHSite + ".pdf"))
                    path = Server.MapPath("../Files/" + "SummaryJOBIn-" + WHSite + ".pdf")
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


        'CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../PDF/" + CStr(ReportSorce) + ".pdf"))
    End Sub
    Protected Sub CrystalReportViewer1_Unload(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Unload
        rpt.Close()
        rpt.Dispose()
        GC.Collect()
    End Sub
<<<<<<< HEAD
    Public Property ReportSorce() As Object
        Get
            Return _ReportSource
        End Get
        Set(ByVal Value As Object)
            _ReportSource = Value
            crvReport = Value
        End Set
    End Property


=======
>>>>>>> 84fdd0a79da4d2dced63e746bcf8c0a3c7f98e97
End Class