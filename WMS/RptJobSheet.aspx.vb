Option Explicit On
Option Strict On
Option Infer On

Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
'Imports System.Windows.Forms.Design
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Globalization
Public Class RptJobSheet
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            showSite()

            Dim strConn As String
            strConn = DBConnString.strConn
            Conn = New SqlConnection()
            With Conn
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = strConn
                .Open()
            End With
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
        Dim _cultureEnInfo As New Globalization.CultureInfo("en-US")
        Dim formdate As String = CStr(Convert.ToDateTime(Me.txtdatepickerFromDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))
        Dim toDate As String = CStr(Convert.ToDateTime(Me.txtdatepickerToDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))
        If rdbExport.Checked = True Then
            'Dim ReportSourch As ReportClass
            Dim r As New rptSummaryJOBOut
            Try
                'PV = New frmExpCustomsInvoiceRPT2

                'r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                r.SetDatabaseLogon("sa", "36133HNVek", "LKBWarehouse", "LKBWarehouse")
                r.SetParameterValue("FromDate", formdate.Trim)
                r.SetParameterValue("ToDate", toDate.Trim)
                r.SetParameterValue("JOBSite", ddlJobSite.SelectedValue)
                PV.ReportSorce = r
                'Cursor = Cursors.Default

                'PV.WindowState = FormWindowState.Maximized
                'PV.ShowDialog(Me)
                Dim url As String = "ShowReport/ShowRptJobSheet.aspx"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

            Catch ex As Exception
            End Try
        End If

        If rdbImport.Checked = True Then
            'Dim ReportSourch As ReportClass
            Dim r As New rptSummaryJobIn
            Try
                'PV = New frmExpCustomsInvoiceRPT2
                r.SetDatabaseLogon("LKBWarehouse", "7tFCca6pzt", "LKBWarehouse", "LKBWarehouse")
                r.SetParameterValue("FromDate", formdate.Trim)
                r.SetParameterValue("ToDate", toDate.Trim)
                r.SetParameterValue("JOBSite", ddlJobSite.Text)
                'PV.ReportSorce = r
                'Cursor = Cursors.Default

                'PV.WindowState = FormWindowState.Maximized

                'PV.ShowDialog(Me)
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub ClearDATA()
        rdbImport.Checked = False
        rdbExport.Checked = False
        txtdatepickerFromDate.Text = ""
        txtdatepickerToDate.Text = ""
    End Sub


End Class