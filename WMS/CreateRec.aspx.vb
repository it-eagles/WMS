Option Explicit On
Option Strict On

Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine


Public Class CreateRec
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1_Test

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        showJobSite()
        showSaleMan()
        showLotof()
        showCommodity()
    End Sub

    Private Sub showJobSite()
        ddlJobsite.Items.Clear()
        ddlJobsite.Items.Add(New ListItem("--Select Site--", ""))
        ddlJobsite.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "Site"
                  Select g.Type, g.Code
        Try
            ddlJobsite.DataSource = gg.ToList
            ddlJobsite.DataTextField = "Code"
            ddlJobsite.DataValueField = "Code"
            ddlJobsite.DataBind()
            If ddlJobsite.Items.Count > 1 Then
                ddlJobsite.Enabled = True
            Else
                ddlJobsite.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showSaleMan()
        ddlSaleman.Items.Clear()
        ddlSaleman.Items.Add(New ListItem("--Select SaleMan--", ""))
        ddlSaleman.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "Sales"
                  Select g.Type, g.Code
        Try
            ddlSaleman.DataSource = gg.ToList
            ddlSaleman.DataTextField = "Code"
            ddlSaleman.DataValueField = "Code"
            ddlSaleman.DataBind()
            If ddlSaleman.Items.Count > 1 Then
                ddlSaleman.Enabled = True
            Else
                ddlSaleman.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showLotof()
        ddlLotof.Items.Clear()
        ddlLotof.Items.Add(New ListItem("--Select LotOf--", ""))
        ddlLotof.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "jobbt-in"
                  Select g.Type, g.Code
        Try
            ddlLotof.DataSource = gg.ToList
            ddlLotof.DataTextField = "Code"
            ddlLotof.DataValueField = "Code"
            ddlLotof.DataBind()
            If ddlLotof.Items.Count > 1 Then
                ddlLotof.Enabled = True
            Else
                ddlLotof.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showCommodity()
        ddlCommodity.Items.Clear()
        ddlCommodity.Items.Add(New ListItem("--Select Commodity--", ""))
        ddlCommodity.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "Commodity"
                  Select g.Type, g.Code
        Try
            ddlCommodity.DataSource = gg.ToList
            ddlCommodity.DataTextField = "Code"
            ddlCommodity.DataValueField = "Code"
            ddlCommodity.DataBind()
            If ddlCommodity.Items.Count > 1 Then
                ddlCommodity.Enabled = True
            Else
                ddlCommodity.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showUnit()
        '    ddlq.Items.Clear()
        '    ddlCommodity.Items.Add(New ListItem("--Select Unit--", ""))
        '    ddlCommodity.AppendDataBoundItems = True

        '    Dim gg = From g In db.tblMasterCodes Where g.Type = "Unit"
        '              Select g.Type, g.Code
        '    Try
        '        ddlCommodity.DataSource = gg.ToList
        '        ddlCommodity.DataTextField = "Code"
        '        ddlCommodity.DataValueField = "Code"
        '        ddlCommodity.DataBind()
        '        If ddlCommodity.Items.Count > 1 Then
        '            ddlCommodity.Enabled = True
        '        Else
        '            ddlCommodity.Enabled = False
        '        End If
        '    Catch ex As Exception

        '    End Try
        'End Sub
End Class