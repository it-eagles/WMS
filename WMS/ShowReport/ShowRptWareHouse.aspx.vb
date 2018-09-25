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
                        'rpt.Load(Server.MapPath("../Report/rptSummaryJOBOut.rpt"))
                    End If

                    'Dim r As New rptWHUnstuffingTallyReport
                    'Try
                    '    PV = New frmExpCustomsInvoiceRPT2
                    '    r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                    '    r.SetParameterValue("LotNoFrom", txtFromJobNo.Text)
                    '    r.SetParameterValue("LotNoTo", txtToJobNo.Text)
                    '    r.SetParameterValue("Type", dcbType.Text)
                    '    r.SetParameterValue("WarehouseSite", dcbWHSite.Text)
                    '    PV.ReportSorce = r
                    '    Cursor = Cursors.Default
                    '    PV.WindowState = FormWindowState.Maximized
                    '    PV.ShowDialog(Me)

                End If
            Catch ex As Exception

            End Try
        End If

    End Sub
End Class