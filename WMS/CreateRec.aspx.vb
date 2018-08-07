﻿Option Explicit On
Option Strict On

Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Transactions


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
        'showListConsignee()
        'showListShipper()
        'showListDelivery()
        'showListPickUp()
        'showListCustomer()
        'showListEndCustomer()
        'showListCustomerGroup()
        'showListProductCode()
    End Sub
    'Private Sub Test_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconsigneecode.Init

    '    If String.IsNullOrEmpty(txtConsigneecode.Value) Then
    '        showListConsignee()

    '        'Else
    '        '    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode Like "%" & txtConsigneecode.Value & "%" And u.Consignee = "0"
    '        '          Select New With {u.PartyCode,
    '        '                           u.PartyFullName,
    '        '                           br.Address1,
    '        '                           br.Address2,
    '        '                           br.Address3}).ToList()
    '        '    If user.Count > 0 Then
    '        '        Repeater1.DataSource = user
    '        '        Repeater1.DataBind()
    '        '    Else
    '        '        Me.Repeater1.DataSource = Nothing
    '        '        Me.Repeater1.DataBind()
    '        '    End If

    '    End If
    'End Sub
    'Protected Sub Test_Load2(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProductCode.Init
    '    'If String.IsNullOrEmpty(txtConsigneecode.Value) Then
    '    '    showListProductCode()
    '    'End If
    'End Sub
    '---------------------------------------------------------Show ddl Site----------------------------------------------------
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
    '----------------------------------------------------------------Show ddl Sales--------------------------------------------------------
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
    '----------------------------------------------------------------Show ddl LotOf----------------------------------------------------------------
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
    '----------------------------------------------------------------Show ddl Commodity----------------------------------------------------------------
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
    '----------------------------------------------------------------Show All ddl Unit-------------------------------------------------------
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
    '----------------------------------------------------------------Show ddl Volume---------------------------------------------------
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
    '----------------------------------------------------------------Show ddl FREIGHTFORWARDER --------------------------------------------
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
    '----------------------------------------------------------------Show ddl IEATPERMIT----------------------------------------------------------
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
    '----------------------------------------------------------------Show ddl Unit CM INC-------------------------------------------------------
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
    '----------------------------------------------------------------Show ddl Currency-----------------------------------------------------
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
    '--------------------------------------------------------Show Data Consignee In Modal-----------------------------------------
    Public Sub showListConsignee()
        'Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
        '           Select New With {u.PartyCode,
        '                            u.PartyFullName,
        '                            br.Address1,
        '                            br.Address2,
        '                            br.Address3}).ToList()
        'If user.Count > 0 Then
        '    Repeater1.DataSource = user
        '    Repeater1.DataBind()
        'Else
        '    Me.Repeater1.DataSource = Nothing
        '    Me.Repeater1.DataBind()
        'End If
    End Sub
    '--------------------------------------------------------Show Data Consignee In Modal-----------------------------------------
    Private Sub selectConsigneeCode()
        Dim cons_code As String

        If String.IsNullOrEmpty(txtConsigneecode.Value.Trim) Then
            cons_code = ""

        Else
            cons_code = txtConsigneecode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2, pa.Address3

        If cons.Count > 0 Then
            Repeater1.DataSource = cons.ToList
            Repeater1.DataBind()
            ScriptManager.RegisterStartupScript(ConsigneeUpdatePanel, ConsigneeUpdatePanel.GetType(), "show", "$(function () { $('#" + ConsigneePanel.ClientID + "').modal('show'); });", True)
            ConsigneeUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Consignee Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Consignee-----------------------------------------------
    Protected Sub Unnamed_ServerClick(sender As Object, e As EventArgs)
        selectConsigneeCode()
    End Sub
    '--------------------------------------------------------Click Data Consignee In Modal-----------------------------------------
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectConsignee") Then
                Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                txtConsigneecode.Value = user.u.PartyCode
                txtNameEngConsign.Value = user.u.PartyFullName
                txtAddress1.Value = user.br.Address1
                txtAddress2.Value = user.br.Address2
                txtAddress3.Value = user.br.Address3
                txtAddress4.Value = user.br.Address4
                txtAddress5.Value = user.br.ZipCode
                txtEmail.Value = user.br.email
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data Shipper In Modal-----------------------------------------
    Public Sub showListShipper()
        'Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
        '           Select New With {u.PartyCode,
        '                            u.PartyFullName,
        '                            br.Address1,
        '                            br.Address2,
        '                            br.Address3}).ToList()


        'If user.Count > 0 Then
        '    Repeater2.DataSource = user
        '    Repeater2.DataBind()
        'Else
        '    Me.Repeater2.DataSource = Nothing
        '    Me.Repeater2.DataBind()
        'End If
    End Sub
    '--------------------------------------------------------Show Data Shipper In Modal-----------------------------------------
    Private Sub selectShipperCode()
        Dim Ship_code As String

        If String.IsNullOrEmpty(txtShippercode.Value.Trim) Then
            Ship_code = ""

        Else
            Ship_code = txtShippercode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Ship_code And p.Shipper = "0") Or p.Shipper = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2, pa.Address3

        If cons.Count > 0 Then
            Repeater2.DataSource = cons.ToList
            Repeater2.DataBind()
            ScriptManager.RegisterStartupScript(ShipperUpdatePanel, ShipperUpdatePanel.GetType(), "show", "$(function () { $('#" + ShipperPanel.ClientID + "').modal('show'); });", True)
            ShipperUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Shipper Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Shipper-----------------------------------------------
    Protected Sub Unnamed_ServerClick1(sender As Object, e As EventArgs)
        selectShipperCode()
    End Sub
    '--------------------------------------------------------Click Data Shipper In Modal-----------------------------------------
    Protected Sub Repeater2_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater2.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectShipper") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtShippercode.Value = user.u.PartyCode
                    txtNameEngShipper.Value = user.u.PartyFullName
                    txtAddress1Shipper.Value = user.br.Address1
                    txtAddress2Shipper.Value = user.br.Address2
                    txtAddress3Shipper.Value = user.br.Address3
                    txtAddress4Shipper.Value = user.br.Address4
                    txtAddress5Shipper.Value = user.br.ZipCode
                    txtEmailShipper.Value = user.br.email

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data Delivery In Modal-----------------------------------------
    Public Sub showListDelivery()
        'Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
        '           Select New With {u.PartyCode,
        '                            u.PartyFullName,
        '                            br.Address1,
        '                            br.Address2,
        '                            br.Address3}).ToList()


        'If user.Count > 0 Then
        '    Repeater3.DataSource = user
        '    Repeater3.DataBind()
        'Else
        '    Me.Repeater3.DataSource = Nothing
        '    Me.Repeater3.DataBind()
        'End If
    End Sub
    '--------------------------------------------------------Show Data Delivery In Modal-----------------------------------------
    Private Sub selectDeliveryCode()
        Dim Delivery_code As String

        If String.IsNullOrEmpty(txtDeliverycode.Value.Trim) Then
            Delivery_code = ""

        Else
            Delivery_code = txtDeliverycode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Delivery_code And p.Shipper = "0") Or p.Shipper = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2, pa.Address3

        If cons.Count > 0 Then
            Repeater3.DataSource = cons.ToList
            Repeater3.DataBind()
            ScriptManager.RegisterStartupScript(DeliveryUpdatePanel, DeliveryUpdatePanel.GetType(), "show", "$(function () { $('#" + DeliveryPanel.ClientID + "').modal('show'); });", True)
            DeliveryUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Delivery Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Delivery-----------------------------------------------
    Protected Sub Unnamed_ServerClick2(sender As Object, e As EventArgs)
        selectDeliveryCode()
    End Sub
    '--------------------------------------------------------Click Data Delivery In Modal-----------------------------------------
    Protected Sub Repeater3_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater3.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectDelivery") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtDeliverycode.Value = user.u.PartyCode
                    txtNameEngDelivery.Value = user.u.PartyFullName
                    txtAddress1Delivery.Value = user.br.Address1
                    txtAddress2Delivery.Value = user.br.Address2
                    txtAddress3Delivery.Value = user.br.Address3
                    txtAddress4Delivery.Value = user.br.Address4
                    txtAddress5Delivery.Value = user.br.ZipCode
                    txtEmailDelivery.Value = user.br.email
                    txtContractPersonDelivery.Value = user.br.Attn

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data PickUp In Modal-----------------------------------------
    Public Sub showListPickUp()
        'Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
        '           Select New With {u.PartyCode,
        '                            u.PartyFullName,
        '                            br.Address1,
        '                            br.Address2,
        '                            br.Address3}).ToList()


        'If user.Count > 0 Then
        '    Repeater4.DataSource = user
        '    Repeater4.DataBind()
        'Else
        '    Me.Repeater4.DataSource = Nothing
        '    Me.Repeater4.DataBind()
        'End If
    End Sub
    '--------------------------------------------------------Show Data PickUp In Modal-----------------------------------------
    Private Sub selectPickUpCode()
        Dim Pickup_code As String

        If String.IsNullOrEmpty(txtCodePickUpPlace.Value.Trim) Then
            Pickup_code = ""

        Else
            Pickup_code = txtCodePickUpPlace.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Pickup_code And p.Shipper = "0") Or p.Shipper = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2, pa.Address3

        If cons.Count > 0 Then
            Repeater4.DataSource = cons.ToList
            Repeater4.DataBind()
            ScriptManager.RegisterStartupScript(PickUpUpdatePanel, PickUpUpdatePanel.GetType(), "show", "$(function () { $('#" + PickUpPanel.ClientID + "').modal('show'); });", True)
            PickUpUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล PickUp Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search PickUp-----------------------------------------------
    Protected Sub Unnamed_ServerClick3(sender As Object, e As EventArgs)
        selectPickUpCode()
    End Sub
    '--------------------------------------------------------Click Data PickUp In Modal-----------------------------------------
    Protected Sub Repeater4_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater4.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectPickUp") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtCodePickUpPlace.Value = user.u.PartyCode
                    txtNamePickUpPlace.Value = user.u.PartyFullName
                    txtAddress1PickUpPlace.Value = user.br.Address1
                    txtAddress2PickUpPlace.Value = user.br.Address2
                    txtAddress3PickUpPlace.Value = user.br.Address3
                    txtAddress4PickUpPlace.Value = user.br.Address4
                    txtAddress5PickUpPlace.Value = user.br.ZipCode
                    txtEmailPickUpPlace.Value = user.br.email
                    txtContractPersonPickUpPlace.Value = user.br.Attn

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data Customer In Modal-----------------------------------------
    Public Sub showListCustomer()
        'Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
        '           Select New With {u.PartyCode,
        '                            u.PartyFullName,
        '                            br.Address1,
        '                            br.Address2,
        '                            br.Address3}).ToList()


        'If user.Count > 0 Then
        '    Repeater5.DataSource = user
        '    Repeater5.DataBind()
        'Else
        '    Me.Repeater5.DataSource = Nothing
        '    Me.Repeater5.DataBind()
        'End If
    End Sub
    '--------------------------------------------------------Show Data Customer In Modal-----------------------------------------
    Private Sub selectCustomerCode()
        Dim Customer_code As String

        If String.IsNullOrEmpty(txtCustomercode.Value.Trim) Then
            Customer_code = ""

        Else
            Customer_code = txtCustomercode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Customer_code And p.Shipper = "0") Or p.Shipper = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2, pa.Address3

        If cons.Count > 0 Then
            Repeater5.DataSource = cons.ToList
            Repeater5.DataBind()
            ScriptManager.RegisterStartupScript(CustomerUpdatePanel, CustomerUpdatePanel.GetType(), "show", "$(function () { $('#" + CustomerPanel.ClientID + "').modal('show'); });", True)
            CustomerUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search CustomerCode-----------------------------------------------
    Protected Sub Unnamed_ServerClick4(sender As Object, e As EventArgs)
        selectCustomerCode()
    End Sub
    '--------------------------------------------------------Click Data Customer In Modal-----------------------------------------
    Protected Sub Repeater5_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater5.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectCustomer") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtCustomercode.Value = user.u.PartyCode
                    txtNameEngCustomer.Value = user.u.PartyFullName
                    txtAddress1Custommer.Value = user.br.Address1
                    txtAddress2Custommer.Value = user.br.Address2
                    txtAddress3Custommer.Value = user.br.Address3
                    txtAddress4Custommer.Value = user.br.Address4
                    txtAddress5Custommer.Value = user.br.ZipCode
                    txtEmailCustommer.Value = user.br.email
                    txtContractPersonCustommer.Value = user.br.Attn

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data Customer In Modal-----------------------------------------
    Public Sub showListEndCustomer()
        'Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
        '           Select New With {u.PartyCode,
        '                            u.PartyFullName,
        '                            br.Address1,
        '                            br.Address2,
        '                            br.Address3}).ToList()


        'If user.Count > 0 Then
        '    Repeater6.DataSource = user
        '    Repeater6.DataBind()
        'Else
        '    Me.Repeater6.DataSource = Nothing
        '    Me.Repeater6.DataBind()
        'End If
    End Sub
    '--------------------------------------------------------Show Data EndCustomer In Modal-----------------------------------------
    Private Sub selectEndCustomerCode()
        Dim EndCustomer_code As String

        If String.IsNullOrEmpty(txtCodeEndCustomer.Value.Trim) Then
            EndCustomer_code = ""

        Else
            EndCustomer_code = txtCodeEndCustomer.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = EndCustomer_code And p.Shipper = "0") Or p.Shipper = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2, pa.Address3

        If cons.Count > 0 Then
            Repeater6.DataSource = cons.ToList
            Repeater6.DataBind()
            ScriptManager.RegisterStartupScript(EndCustomerUpdatePanel, EndCustomerUpdatePanel.GetType(), "show", "$(function () { $('#" + EndCustomerPanel.ClientID + "').modal('show'); });", True)
            EndCustomerUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล EndCustomer Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search EndCustomer-----------------------------------------------
    Protected Sub Unnamed_ServerClick5(sender As Object, e As EventArgs)
        selectEndCustomerCode()
    End Sub

    '--------------------------------------------------------Click Data EndCustomer In Modal-----------------------------------------
    Protected Sub Repeater6_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater6.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectEndCustomer") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtCodeEndCustomer.Value = user.u.PartyCode
                    txtNameEndCustomer.Value = user.u.PartyFullName
                    txtAddress1EndCustomer.Value = user.br.Address1
                    txtAddress2EndCustomer.Value = user.br.Address2
                    txtAddress3EndCustomer.Value = user.br.Address3
                    txtAddress4EndCustomer.Value = user.br.Address4
                    txtAddress5EndCustomer.Value = user.br.ZipCode
                    txtEmailEndCustomer.Value = user.br.email
                    txtContractPersonEndCustomer.Value = user.br.Attn

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data CustomerGroup In Modal-----------------------------------------
    Public Sub showListCustomerGroup()

        'Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
        '           Select New With {u.PartyCode,
        '                            u.PartyFullName}).ToList()


        'If user.Count > 0 Then
        '    Repeater7.DataSource = user
        '    Repeater7.DataBind()
        'Else
        '    Me.Repeater7.DataSource = Nothing
        '    Me.Repeater7.DataBind()
        'End If
    End Sub
    '--------------------------------------------------------Show Data CustomerGroup In Modal-----------------------------------------
    Private Sub selectCustomerGroupCode()
        Dim CustomerGroup_code As String

        If String.IsNullOrEmpty(txtCodeCustommerGroup.Value.Trim) Then
            CustomerGroup_code = ""

        Else
            CustomerGroup_code = txtCodeCustommerGroup.Value.Trim
        End If

        Dim cons = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                   Select New With {u.PartyCode,
                                    u.PartyFullName}).ToList()

        If cons.Count > 0 Then
            Repeater7.DataSource = cons.ToList
            Repeater7.DataBind()
            ScriptManager.RegisterStartupScript(CustomerGroupUpdatePanel, CustomerGroupUpdatePanel.GetType(), "show", "$(function () { $('#" + CustomerGroupPanel.ClientID + "').modal('show'); });", True)
            CustomerGroupUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล CustomerGroup Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search CustomerGroup-----------------------------------------------
    Protected Sub Unnamed_ServerClick6(sender As Object, e As EventArgs)
        selectCustomerGroupCode()
    End Sub
    '--------------------------------------------------------Click Data CustomerGroup In Modal-----------------------------------------
    Protected Sub Repeater7_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater7.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectCustomerGroup") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtCodeCustommerGroup.Value = user.u.PartyCode
                    txtNameCustommerGroup.Value = user.u.PartyFullName
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data ProductCode In Modal-----------------------------------------
    Public Sub showListProductCode()
        'Dim user = (From u In db.tblProductDetails
        '           Select New With {u.ProductCode,
        '                            u.ImpDesc1,
        '                            u.PONo,
        '                            u.CustomerPart,
        '                            u.EndUserPart}).ToList()

        'If user.Count > 0 Then
        '    Repeater8.DataSource = user
        '    Repeater8.DataBind()
        'Else
        '    Me.Repeater8.DataSource = Nothing
        '    Me.Repeater8.DataBind()
        'End If
    End Sub
    '--------------------------------------------------------Show Data ProductCode In Modal-----------------------------------------
    Private Sub selectProductCode()
        Dim ProductCode_code As String

        If String.IsNullOrEmpty(txtCodeCustommerGroup.Value.Trim) Then
            ProductCode_code = ""

        Else
            ProductCode_code = txtCodeCustommerGroup.Value.Trim
        End If

        Dim cons = (From u In db.tblProductDetails
                    Where (u.ProductCode = ProductCode_code) Or ProductCode_code = ""
                   Select New With {u.ProductCode,
                                    u.ImpDesc1,
                                    u.PONo,
                                    u.CustomerPart,
                                    u.EndUserPart}).ToList()

        If cons.Count > 0 Then
            Repeater8.DataSource = cons.ToList
            Repeater8.DataBind()
            ScriptManager.RegisterStartupScript(ProductCodeUpdatePanel, ProductCodeUpdatePanel.GetType(), "show", "$(function () { $('#" + ProductCodePanel.ClientID + "').modal('show'); });", True)
            ProductCodeUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล ProductCode Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search ProductCode-----------------------------------------------
    Protected Sub Unnamed_ServerClick7(sender As Object, e As EventArgs)
        selectProductCode()
    End Sub
    '--------------------------------------------------------Click Data ProductCode In Modal-----------------------------------------
    Protected Sub Repeater8_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater8.ItemCommand
        Dim ProductCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectProductCode") Then

                If String.IsNullOrEmpty(ProductCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblProductDetails Where u.ProductCode = ProductCode).SingleOrDefault

                    txtProductCodeInvoice.Value = user.ProductCode
                    txtProductNameInvoice.Value = user.ImpDesc1
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub SaveDATA_New()

    '    If txtJobno.Value.Trim() = "" Then
    '        MsgBox("กรุณาป้อน LOT No ก่อน !!!")
    '        'UnlockDATA()
    '        txtJobno.Focus()
    '        Exit Sub
    '    End If
    '    'CJob()
    '    If MsgBox("คุณต้องการเพิ่มรายการ LOT No ใหม่ ใช่หรือไม่ ?", "คำยืนยัน", MsgBoxStyle.YesNo, MsgBoxStyle.Question) = Windows.Forms.DialogResult.Yes Then

    '        Using tran As New TransactionScope()

    '            Try
    '                db.Database.Connection.Open()

    '                db.tblImpGenLOTs.Add(New tblImpGenLOT With { _
    '                                     .EASLOTNo = txtJobno.Value.Trim, _
    '                                     .JobSite = ddlJobsite.Text.Trim, _
    '                                     .LOTDate = CType(txtdatepickerJobdate.Text.Trim, Date?), _
    '                                     .LOTBy = ddlLotof.Text.Trim, _
    '                                     .SalesCode = ddlSaleman.Text.Trim, _
    '                                     .SalesName = txtsalemandis.Value.Trim, _
    '                                     .ConsigneeCode = txtConsigneecode.Value.Trim, _
    '                                     .ConsignNameEng = txtNameEngConsign.Value.Trim, _
    '                                     .ConsignAddress = txtAddress1.Value.Trim, _
    '                                     .ConsignDistrict = txtAddress2.Value.Trim, _
    '                                     .ConsignSubProvince = txtAddress3.Value.Trim, _
    '                                     .ConsignProvince = txtAddress4.Value.Trim, _
    '                                     .ConsignPostCode = txtAddress5.Value.Trim, _
    '                                     .ConsignEmail = txtEmail.Value.Trim, _
    '                                     .ShipperCode = txtShippercode.Value.Trim, _
    '                                     .ShipperNameEng = txtNameEngShipper.Value.Trim, _
    '                                     .ShipperAddress = txtAddress1Shipper.Value.Trim, _
    '                                     .ShipperDistrict = txtAddress2Shipper.Value.Trim, _
    '                                     .ShipperSubprovince = txtAddress3Shipper.Value.Trim, _
    '                                     .ShipperProvince = txtAddress4Shipper.Value.Trim, _
    '                                     .ShipperPostCode = txtAddress5Shipper.Value.Trim, _
    '                                     .ShipperReturnCode = txtEmailShipper.Value.Trim, _
    '                                     .Commodity = ddlCommodity.Text.Trim, _
    '                                     .QuantityofPart = CType(txtQuantityOfPart.Value.Trim, Double?), _
    '                                     .QuantityUnit = ddlQuantityOfParty.Text.Trim, _
    '                                     .QuantityPack = CType(txtQuantity.Value.Trim, Double?), _
    '                                     .QuantityUnitPack = ddlQuan.Text.Trim, _
    '                                     .Weight = CType(txtWeight.Value.Trim, Double?), _
    '                                     .WeightUnit = ddlWeight.Text.Trim, _
    '                                     .QuantityPack1 = CType(txtQuantityBox.Value.Trim, Double?), _
    '                                     .QuantityUnitPack1 = ddlquanbox.Text.Trim, _
    '                                     .Volume = CType(txtVolume.Value.Trim, Double?), _
    '                                     .VolumeUnit = ddlvolume.Text.Trim, _
    '                                     .MAWB = txtMAWB_BL_TWB.Value.Trim, _
    '                                     .Flight = txtFLT_Voy_TruckDate.Value.Trim, _
    '                                     .DocType = ddlvolume2.Text.Trim, _
    '                                     .DocCode = txtVolume2.Value.Trim, _
    '                                     .FreighForwarder = ddlFreight.Text.Trim, _
    '                                     .ShipTo = txtShipto.Value.Trim, _
    '                                     .BillingNo = txtBilling.Value.Trim, _
    '                                     .FLT1 = txtActual1.Value.Trim, _
    '                                     .FLT2 = txtActual2.Value.Trim, _
    '                                     .FLT3 = txtActual3.Value.Trim, _
    '                                     .FLT4 = txtActual4.Value.Trim, _
    '                                     .DateFLT1 = CType(txtdatepickerActualDate1.Text.Trim, Date?), _
    '                                     .DateFLT2 = CType(txtdatepickerActualDate2.Text.Trim, Date?), _
    '                                     .DateFLT3 = CType(txtdatepickerActualDate3.Text.Trim, Date?), _
    '                                     .DateFLT4 = CType(txtdatepickerActualDate4.Text.Trim, Date?), _
    '                                     .ORGN1 = txtORGN1.Value.Trim, _
    '                                     .ORGN2 = txtORGN2.Value.Trim, _
    '                                     .ORGN3 = txtORGN3.Value.Trim, _
    '                                     .ORGN4 = txtORGN4.Value.Trim, _
    '                                     .DSTN1 = txtDSTN1.Value.Trim, _
    '                                     .DSTN2 = txtDSTN2.Value.Trim, _
    '                                     .DSTN3 = txtDSTN3.Value.Trim, _
    '                                     .DSTN4 = txtDSTN4.Value.Trim, _
    '                                     .ETD1 = txtpickupETD.Value.Trim, _
    '                                     .ETD2 = txtpickupETD2.Value.Trim, _
    '                                     .ETD3 = txtpickupETD3.Value.Trim, _
    '                                     .ETD4 = txtpickupETD4.Value.Trim, _
    '                                     .ETA1 = txtpickupETA.Value.Trim, _
    '                                     .ETA2 = txtpickupETA2.Value.Trim, _
    '                                     .ETA3 = txtpickupETA3.Value.Trim, _
    '                                     .ETA4 = txtpickupETA4.Value.Trim, _
    '                                     .PCS1 = CType(txtPacket.Value.Trim, Double?), _
    '                                     .PCS2 = CType(txtPacket2.Value.Trim, Double?), _
    '                                     .PCS3 = CType(txtPacket3.Value.Trim, Double?), _
    '                                     .PCS4 = CType(txtPacket4.Value.Trim, Double?), _
    '                                     .Weight1 = CType(txtWeightActual.Value.Trim, Double?), _
    '                                     .Weight2 = CType(txtWeightActual2.Value.Trim, Double?), _
    '                                     .Weight3 = CType(txtWeightActual3.Value.Trim, Double?), _
    '                                     .Weight4 = CType(txtWeightActual4.Value.Trim, Double?), _
    '                                     .TimeDTE = txtTimePickUp.Value.Trim, _
    '                                     .DateDTE = CType(txtdatepickerActualPickUp.Text.Trim, Date?), _
    '                                     .TimeATT = txtArrivalToEAS.Value.Trim, _
    '                                     .DateATT = CType(txtdatepickerArrivalToEAS.Text.Trim, Date?), _
    '                                     .Remark = txtRamarkActual.Value.Trim, _
    '                                     .DOCode = txtDeliverycode.Value.Trim, _
    '                                     .DONameENG = txtNameEngDelivery.Value.Trim, _
    '                                     .DOStreet_Number = txtAddress1Delivery.Value.Trim, _
    '                                     .DODistrict = txtAddress2Delivery.Value.Trim, _
    '                                     .DOSubProvince = txtAddress3Delivery.Value.Trim, _
    '                                     .DOProvince = txtAddress4Delivery.Value.Trim, _
    '                                     .DOPostCode = txtAddress5Delivery.Value.Trim, _
    '                                     .DOEmail = txtEmailDelivery.Value.Trim, _
    '                                     .DOContactPerson = txtContractPersonDelivery.Value.Trim, _
    '                                     .PickUpCode = txtCodePickUpPlace.Value.Trim, _
    '                                     .PickUpENG  = txtNamePickUpPlace.Value.Trim, _
    '                                     .PickUpAddress1 = txtAddress1PickUpPlace.Value.Trim, _
    '                                     .PickUpAddress2 = txtAddress2PickUpPlace.Value.Trim, _
    '                                     .PickUpAddress3 = txtAddress3PickUpPlace.Value.Trim, _
    '                                     .PickUpAddress4 = txtAddress4PickUpPlace.Value.Trim, _
    '                                     .PickUpAddress5 = txtAddress5PickUpPlace.Value.Trim, _
    '                                     .PickUpEmail = txtEmailPickUpPlace.Value.Trim, _
    '                                     .PickUpContact = txtContractPersonPickUpPlace.Value.Trim, _
    '                                     .CustomerCode = txtCustomercode.Value.Trim, _
    '                                     .CustomerENG = txtNameEngCustomer.Value.Trim, _
    '                                     .CustomerStreet = txtAddress1Custommer.Value.Trim, _
    '                                     .CustomerDistrict = txtAddress2Custommer.Value.Trim, _
    '                                     .CustomerSub = txtAddress3Custommer.Value.Trim, _
    '                                     .CustomerProvince = txtAddress4Custommer.Value.Trim, _
    '                                     .CustomerPostCode = txtAddress5Custommer.Value.Trim, _
    '                                     .CustomerEmail = txtEmailCustommer.Value.Trim, _
    '                                     .CustomerContact = txtContractPersonCustommer.Value.Trim, _
    '                                     .EndCusCode = txtCodeEndCustomer.Value.Trim, _
    '                                     .EndCusENG = txtNameEndCustomer.Value.Trim, _
    '                                     .EndCusAddress1 = txtAddress1EndCustomer.Value.Trim, _
    '                                     .EndCusAddress2 = txtAddress2EndCustomer.Value.Trim, _
    '                                     .EndCusAddress3 = txtAddress3EndCustomer.Value.Trim, _
    '                                     .EndCusAddress4 = txtAddress4EndCustomer.Value.Trim, _
    '                                     .EndCusAddress5 = txtAddress5EndCustomer.Value.Trim, _
    '                                     .EndCusEmail = txtEmailEndCustomer.Value.Trim, _
    '                                     .EndCusContact = txtContractPersonEndCustomer.Value.Trim, _
    '                                     .CustomerCodeGroup = txtCodeCustommerGroup.Value.Trim, _
    '                                     .CustomerENGGroup = txtNameCustommerGroup.Value.Trim, _
    '                                     .IEATNo = txtIEATNo.Value.Trim, _
    '                                     .IEATPermit = ddlIEATPermit.Text.Trim, _
    '                                     .EntryNo = txtImportEntryNo.Value.Trim, _
    '                                     .DeliveryDate = CType(txtdatepickerImportEntryDate.Text.Trim, Date?), _
    '                                     .Status1 = ddlStatusIEAT1.Text.Trim, _
    '                                     .Status2 = ddlStatusIEAT2.Text.Trim, _
    '                                     .Useby = CStr(Session("UserId")), _

    '                .Parameters.Add("@JOBBranch", SqlDbType.VarChar).Value = JOB



    '                .ExecuteNonQuery()

    '                End With
    '                tr.Commit()

    '            Catch ex As Exception
    '                tr.Rollback()
    '                MessageBox.Show(ex.Message, "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                UnlockDATA()
    '            End Try

    '        End Using
    '    End If
    '    txtLotNo.Focus()

    'End Sub 'saveเข้าtblExpGenLOT
End Class