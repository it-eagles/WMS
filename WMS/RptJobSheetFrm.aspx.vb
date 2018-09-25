Option Explicit On
Option Strict On
Option Infer On

Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Globalization
Public Class RptJobSheetFrm
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim tr As SqlTransaction
    Dim sb As StringBuilder
    Dim dr As SqlDataReader
    Dim dtshipper As DataTable
    Dim tmpButtonStatus As String
    Dim sqlDataComboList As String
    Public PV As New ShowRptJobSheet
    Private rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            showSite()
            ClearDATA()
        End If
    End Sub
    '--------------------------------------------------------------------Show ddl Site----------------------------------------------------
    Private Sub showSite()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "SITE"
                  Select g.Type, g.Code
        Try
            ddlJobSite.DataSource = gg.ToList
            ddlJobSite.DataTextField = "Code"
            ddlJobSite.DataValueField = "Code"
            ddlJobSite.DataBind()

            If ddlJobSite.Items.Count > 1 Then
                ddlJobSite.Enabled = True
            Else
                ddlJobSite.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)
        ClearDATA()
    End Sub

    Protected Sub btnPrint_ServerClick(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtdatepickerFromDate.Text.Trim) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ FromDate ก่อน');", True)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtdatepickerToDate.Text.Trim) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ ToDate ก่อน');", True)
            Exit Sub
        End If

        Dim _cultureEnInfo As New Globalization.CultureInfo("en-US")
        Dim site As String = ddlJobSite.Text.Trim
        Dim formdate As String = CStr(Convert.ToDateTime(Me.txtdatepickerFromDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))
        Dim toDate As String = CStr(Convert.ToDateTime(Me.txtdatepickerToDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))
        Dim Export As Boolean
        If rdbExport.Checked = True Then
            Export = True
        Else
            Export = False
        End If
        Session("Export") = Export
        Session("formdate") = formdate
        Session("toDate") = toDate
        Dim url As String = "ShowReport/ShowRptJobSheet.aspx?WHSite=" + site + "&test=" + formdate
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)
    End Sub
    Private Sub ClearDATA()
        rdbImport.Checked = False
        rdbExport.Checked = False
        txtdatepickerFromDate.Text = ""
        txtdatepickerToDate.Text = ""
    End Sub
End Class