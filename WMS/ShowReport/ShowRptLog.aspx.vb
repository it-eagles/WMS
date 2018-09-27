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

Public Class ShowRptLog
    Inherits System.Web.UI.Page
    Private r As New ReportDocument
    Dim path As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim CheckLog As String = CStr(Session("CheckLog"))
            Dim CheckBy As String = CStr(Session("CheckBy"))
            Dim InvoiceNo As String = CStr(Session("InvoiceNo"))
            Dim _cultureEnInfo As New Globalization.CultureInfo("en-US")
            Dim formdate As String = CStr(Session("formdate"))
            Dim toDate As String = CStr(Session("toDate"))
            Try

                If CheckLog = "LogInvoice" Or CheckLog = "LogInvoiceDetail" Or CheckLog = "LogPackingList" _
            Or CheckLog = "LogImpInvoice" Or CheckLog = "LogImpInvoiceDetail" Or CheckLog = "LogImpPackingList" Then

                    If CheckLog = "LogInvoice" Then
                        r.Load(Server.MapPath("../Report/LogReport/RptLogInvoice.rpt"))
                    ElseIf CheckLog = "LogInvoiceDetail" Then
                        r.Load(Server.MapPath("../Report/LogReport/RptLogInvoiceDetail.rpt"))
                    ElseIf CheckLog = "LogPackingList" Then
                        r.Load(Server.MapPath("../Report/LogReport/RptLogPackingList.rpt"))
                    ElseIf CheckLog = "LogImpInvoice" Then
                        r.Load(Server.MapPath("../Report/LogReport/RptLogImpInvoice.rpt"))
                    ElseIf CheckLog = "LogImpInvoiceDetail" Then
                        r.Load(Server.MapPath("../Report/LogReport/RptLogImpInvoiceDetail.rpt"))
                    ElseIf CheckLog = "LogImpPackingList" Then
                        r.Load(Server.MapPath("../Report/LogReport/RptLogImpPackingList.rpt"))
                    End If

                    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")

                    If CheckBy = "ByDate" Then
                        r.SetParameterValue("Date1", formdate)
                        r.SetParameterValue("Date2", toDate)
                        'r.SetParameterValue("Inv", txtInvoice.Text.Trim())
                    Else
                    End If


                End If

            Catch ex As Exception
            End Try

        End If
    End Sub

End Class