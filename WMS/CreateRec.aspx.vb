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
        showUnit()
        showVolume()
        showFreight()
        showIEATPermit()
        showunitdimension()
        showcurrency()
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
        ddlQuan.Items.Clear()
        ddlQuan.Items.Add(New ListItem("--Select Unit--", ""))
        ddlQuan.AppendDataBoundItems = True

        ddlquanbox.Items.Clear()
        ddlquanbox.Items.Add(New ListItem("--Select Unit--", ""))
        ddlquanbox.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "Unit"
                  Select g.Type, g.Code
        Try
            ddlQuan.DataSource = gg.ToList
            ddlQuan.DataTextField = "Code"
            ddlQuan.DataValueField = "Code"
            ddlQuan.DataBind()

            ddlquanbox.DataSource = gg.ToList
            ddlquanbox.DataTextField = "Code"
            ddlquanbox.DataValueField = "Code"
            ddlquanbox.DataBind()

            ddlQuantityOfParty.DataSource = gg.ToList
            ddlQuantityOfParty.DataTextField = "Code"
            ddlQuantityOfParty.DataValueField = "Code"
            ddlQuantityOfParty.DataBind()

            ddlWeight.DataSource = gg.ToList
            ddlWeight.DataTextField = "Code"
            ddlWeight.DataValueField = "Code"
            ddlWeight.DataBind()

            ddlQuantityInvoice.DataSource = gg.ToList
            ddlQuantityInvoice.DataTextField = "Code"
            ddlQuantityInvoice.DataValueField = "Code"
            ddlQuantityInvoice.DataBind()

            ddlWeightInvoice.DataSource = gg.ToList
            ddlWeightInvoice.DataTextField = "Code"
            ddlWeightInvoice.DataValueField = "Code"
            ddlWeightInvoice.DataBind()

            ddlPallet_SKIDInvoice.DataSource = gg.ToList
            ddlPallet_SKIDInvoice.DataTextField = "Code"
            ddlPallet_SKIDInvoice.DataValueField = "Code"
            ddlPallet_SKIDInvoice.DataBind()

            ddlBoxInvoice.DataSource = gg.ToList
            ddlBoxInvoice.DataTextField = "Code"
            ddlBoxInvoice.DataValueField = "Code"
            ddlBoxInvoice.DataBind()

            ddlQuantity_PLT_Skid_Invoice.DataSource = gg.ToList
            ddlQuantity_PLT_Skid_Invoice.DataTextField = "Code"
            ddlQuantity_PLT_Skid_Invoice.DataValueField = "Code"
            ddlQuantity_PLT_Skid_Invoice.DataBind()

            If ddlQuan.Items.Count > 1 Then
                ddlQuan.Enabled = True
            Else
                ddlQuan.Enabled = False
            End If

            If ddlquanbox.Items.Count > 1 Then
                ddlquanbox.Enabled = True
            Else
                ddlquanbox.Enabled = False
            End If

            If ddlQuantityOfParty.Items.Count > 1 Then
                ddlQuantityOfParty.Enabled = True
            Else
                ddlQuantityOfParty.Enabled = False
            End If

            If ddlWeight.Items.Count > 1 Then
                ddlWeight.Enabled = True
            Else
                ddlWeight.Enabled = False
            End If

            If ddlQuantityInvoice.Items.Count > 1 Then
                ddlQuantityInvoice.Enabled = True
            Else
                ddlQuantityInvoice.Enabled = False
            End If

            If ddlWeightInvoice.Items.Count > 1 Then
                ddlWeightInvoice.Enabled = True
            Else
                ddlWeightInvoice.Enabled = False
            End If

            If ddlPallet_SKIDInvoice.Items.Count > 1 Then
                ddlPallet_SKIDInvoice.Enabled = True
            Else
                ddlPallet_SKIDInvoice.Enabled = False
            End If

            If ddlBoxInvoice.Items.Count > 1 Then
                ddlBoxInvoice.Enabled = True
            Else
                ddlBoxInvoice.Enabled = False
            End If

            If ddlQuantity_PLT_Skid_Invoice.Items.Count > 1 Then
                ddlQuantity_PLT_Skid_Invoice.Enabled = True
            Else
                ddlQuantity_PLT_Skid_Invoice.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showVolume()
        ddlvolume.Items.Clear()
        ddlvolume.Items.Add(New ListItem("--Select Volume--", ""))
        ddlvolume.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "Volume"
                  Select g.Type, g.Code
        Try
            ddlvolume.DataSource = gg.ToList
            ddlvolume.DataTextField = "Code"
            ddlvolume.DataValueField = "Code"
            ddlvolume.DataBind()
            If ddlvolume.Items.Count > 1 Then
                ddlvolume.Enabled = True
            Else
                ddlvolume.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showFreight()
        ddlFreight.Items.Clear()
        ddlFreight.Items.Add(New ListItem("--Select Freight--", ""))
        ddlFreight.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "FREIGHTFORWARDER"
                  Select g.Type, g.Code
        Try
            ddlFreight.DataSource = gg.ToList
            ddlFreight.DataTextField = "Code"
            ddlFreight.DataValueField = "Code"
            ddlFreight.DataBind()
            If ddlFreight.Items.Count > 1 Then
                ddlFreight.Enabled = True
            Else
                ddlFreight.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showIEATPermit()
        ddlIEATPermit.Items.Clear()
        ddlIEATPermit.Items.Add(New ListItem("--Select Freight--", ""))
        ddlIEATPermit.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "IEATPERMIT"
                  Select g.Type, g.Code
        Try
            ddlIEATPermit.DataSource = gg.ToList
            ddlIEATPermit.DataTextField = "Code"
            ddlIEATPermit.DataValueField = "Code"
            ddlIEATPermit.DataBind()
            If ddlIEATPermit.Items.Count > 1 Then
                ddlIEATPermit.Enabled = True
            Else
                ddlIEATPermit.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showunitdimension()
        ddlUnitDimension.Items.Clear()
        ddlUnitDimension.Items.Add(New ListItem("--Select Unit--", ""))
        ddlUnitDimension.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Code = "CM" Or g.Code = "INC"
                  Select g.Type, g.Code
        Try
            ddlUnitDimension.DataSource = gg.ToList
            ddlUnitDimension.DataTextField = "Code"
            ddlUnitDimension.DataValueField = "Code"
            ddlUnitDimension.DataBind()
            If ddlUnitDimension.Items.Count > 1 Then
                ddlUnitDimension.Enabled = True
            Else
                ddlUnitDimension.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showcurrency()
        ddlCurrencyInvoice.Items.Clear()
        ddlCurrencyInvoice.Items.Add(New ListItem("--Select Currency--", ""))
        ddlCurrencyInvoice.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "Currency"
                  Select g.Type, g.Code
        Try
            ddlCurrencyInvoice.DataSource = gg.ToList
            ddlCurrencyInvoice.DataTextField = "Code"
            ddlCurrencyInvoice.DataValueField = "Code"
            ddlCurrencyInvoice.DataBind()
            If ddlCurrencyInvoice.Items.Count > 1 Then
                ddlCurrencyInvoice.Enabled = True
            Else
                ddlCurrencyInvoice.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class