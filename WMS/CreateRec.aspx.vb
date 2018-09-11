Option Explicit On
Option Strict On

Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Transactions
Imports System.Globalization

Public Class CreateRec
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis
    Dim checkclicksave As String
    Dim txtMountNo As String
    Dim txtYearNo As String
    Dim txtDigitNo As String
    Dim txtTypeCode As String
    Dim txtRunNo As String
    Dim checkjobsite As String
    Dim endpart As String
    Dim cuspart As String
    Dim Prodes As String
    Dim NumberFlight As Double

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmImpGenLot"
        If Not Me.IsPostBack Then
            If classPermis.CheckRead(form, usename) = True Then
                If Not IsPostBack Then

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
                    TabName.Value = Request.Form(TabName.UniqueID)

                    stockqty_fieldset.Disabled = True
                    importgoods_fieldset.Disabled = True
                    exportgoods_fieldset.Disabled = True
                    detailofgoods_fieldset.Disabled = True
                    assembly_fieldset.Disabled = True

                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
                'Response.Redirect("HomeMain.aspx")
                'btnAddNew.Disabled = True
                'btnEdit.Disabled = True
            End If
        End If

        'showListConsignee()
        'showListShipper()
        'showListDelivery()
        'showListPickUp()
        'showListCustomer()
        'showListEndCustomer()
        'showListCustomerGroup()
        'showListProductCode()
    End Sub
    '---------------------------------------------------------Show ddl Site----------------------------------------------------
    Private Sub showJobSite()
        'ddlJobsite.Items.Clear()
        'ddlJobsite.Items.Add(New ListItem("--Select Site--", ""))
        'ddlJobsite.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "JOBSITE"
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
        'ddlSaleman.Items.Clear()
        'ddlSaleman.Items.Add(New ListItem("--Select SaleMan--", ""))
        'ddlSaleman.AppendDataBoundItems = True

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
        'ddlLotof.Items.Clear()
        'ddlLotof.Items.Add(New ListItem("--Select LotOf--", ""))
        'ddlLotof.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "jobby-in"
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
        'ddlCommodity.Items.Clear()
        'ddlCommodity.Items.Add(New ListItem("--Select Commodity--", ""))
        'ddlCommodity.AppendDataBoundItems = True

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
        'ddlQuan.Items.Clear()
        'ddlQuan.Items.Add(New ListItem("--Select Unit--", ""))
        'ddlQuan.AppendDataBoundItems = True

        'ddlquanbox.Items.Clear()
        'ddlquanbox.Items.Add(New ListItem("--Select Unit--", ""))
        'ddlquanbox.AppendDataBoundItems = True

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
        'ddlvolume.Items.Clear()
        'ddlvolume.Items.Add(New ListItem("--Select Volume--", ""))
        'ddlvolume.AppendDataBoundItems = True

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
        'ddlFreight.Items.Clear()
        'ddlFreight.Items.Add(New ListItem("--Select Freight--", ""))
        'ddlFreight.AppendDataBoundItems = True

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
        'ddlIEATPermit.Items.Clear()
        'ddlIEATPermit.Items.Add(New ListItem("--Select Freight--", ""))
        'ddlIEATPermit.AppendDataBoundItems = True

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
        'ddlUnitDimension.Items.Clear()
        'ddlUnitDimension.Items.Add(New ListItem("--Select Unit--", ""))
        'ddlUnitDimension.AppendDataBoundItems = True

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
        'ddlCurrencyInvoice.Items.Clear()
        'ddlCurrencyInvoice.Items.Add(New ListItem("--Select Currency--", ""))
        'ddlCurrencyInvoice.AppendDataBoundItems = True

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
        Dim shipper_ As String = ""
        If String.IsNullOrEmpty(txtConsigneecode.Value.Trim) Then
            cons_code = ""
            shipper_ = "0"
        Else
            cons_code = txtConsigneecode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = shipper_
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

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
        '    Dim PartyCode As String = CStr(e.CommandArgument)
        '    Try
        '        If e.CommandName.Equals("SelectConsignee") Then
        '            Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

        '            txtConsigneecode.Value = user.u.PartyCode
        '            txtNameEngConsign.Value = user.u.PartyFullName
        '            txtAddress1.Value = user.br.Address1
        '            txtAddress2.Value = user.br.Address2
        '            txtAddress3.Value = user.br.Address3
        '            txtAddress4.Value = user.br.Address4
        '            txtAddress5.Value = user.br.ZipCode
        '            txtEmail.Value = user.br.email
        '        End If
        '    Catch ex As Exception
        '    End Try
    End Sub

    '--------------------------------------------------------Click Data Consignee In Modal-----------------------------------------
    Protected Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)
            'Dim lblAddress3 As Label = CType(e.Item.FindControl("lblAddress3"), Label)
            Dim lblPartyAddressCode As Label = CType(e.Item.FindControl("lblPartyAddressCode"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString()
            End If
            'If Not IsNothing(lblPartyCode) Then
            '    lblAddress3.Text = DataBinder.Eval(e.Item.DataItem, "Address3").ToString()
            'End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyAddressCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString()
            End If
        End If

    End Sub
    Protected Sub clickconsignee_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)
        'Dim lblPartyAddressCode As String = TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        If String.IsNullOrEmpty(user.u.PartyCode) Then
            txtConsigneecode.Value = ""
        Else
            txtConsigneecode.Value = user.u.PartyCode
        End If

        If String.IsNullOrEmpty(user.u.PartyFullName) Then
            txtNameEngConsign.Value = ""
        Else
            txtNameEngConsign.Value = user.u.PartyFullName
        End If

        If String.IsNullOrEmpty(user.br.Address1) Then
            txtAddress1.Value = ""
        Else
            txtAddress1.Value = user.br.Address1
        End If

        If String.IsNullOrEmpty(user.br.Address2) Then
            txtAddress2.Value = ""
        Else
            txtAddress2.Value = user.br.Address2
        End If

        If String.IsNullOrEmpty(user.br.Address3) Then
            txtAddress3.Value = ""
        Else
            txtAddress3.Value = user.br.Address3
        End If

        If String.IsNullOrEmpty(user.br.Address4) Then
            txtAddress4.Value = ""
        Else
            txtAddress4.Value = user.br.Address4
        End If

        If String.IsNullOrEmpty(user.br.ZipCode) Then
            txtAddress5.Value = ""
        Else
            txtAddress5.Value = user.br.ZipCode
        End If

        If String.IsNullOrEmpty(user.br.email) Then
            txtEmail.Value = ""
        Else
            txtEmail.Value = user.br.email
        End If

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
        Dim shipper_ As String = ""
        If String.IsNullOrEmpty(txtShippercode.Value.Trim) Then
            Ship_code = ""
            shipper_ = "0"
        Else
            Ship_code = txtShippercode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Ship_code And p.Shipper = "0") Or p.Shipper = shipper_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

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
        'Dim PartyCode As String = CStr(e.CommandArgument)
        'Try
        '    If e.CommandName.Equals("SelectShipper") Then

        '        If String.IsNullOrEmpty(PartyCode) Then

        '            MsgBox("เป็นค่าว่าง")
        '        Else
        '            Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

        '            txtShippercode.Value = user.u.PartyCode
        '            txtNameEngShipper.Value = user.u.PartyFullName
        '            txtAddress1Shipper.Value = user.br.Address1
        '            txtAddress2Shipper.Value = user.br.Address2
        '            txtAddress3Shipper.Value = user.br.Address3
        '            txtAddress4Shipper.Value = user.br.Address4
        '            txtAddress5Shipper.Value = user.br.ZipCode
        '            txtEmailShipper.Value = user.br.email

        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Protected Sub Repeater2_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater2.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)

            Dim lblPartyAddressCode As Label = CType(e.Item.FindControl("lblPartyAddressCode"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyAddressCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString()
            End If
        End If

    End Sub
    Protected Sub clickshipper_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault
        If String.IsNullOrEmpty(user.u.PartyCode) Then
            txtShippercode.Value = ""
        Else
            txtShippercode.Value = user.u.PartyCode
        End If

        If String.IsNullOrEmpty(user.u.PartyFullName) Then
            txtNameEngShipper.Value = ""
        Else
            txtNameEngShipper.Value = user.u.PartyFullName
        End If

        If String.IsNullOrEmpty(user.br.Address1) Then
            txtAddress1Shipper.Value = ""
        Else
            txtAddress1Shipper.Value = user.br.Address1
        End If

        If String.IsNullOrEmpty(user.br.Address2) Then
            txtAddress2Shipper.Value = ""
        Else
            txtAddress2Shipper.Value = user.br.Address2
        End If

        If String.IsNullOrEmpty(user.br.Address3) Then
            txtAddress3Shipper.Value = ""
        Else
            txtAddress3Shipper.Value = user.br.Address3
        End If

        If String.IsNullOrEmpty(user.br.Address4) Then
            txtAddress4Shipper.Value = ""
        Else
            txtAddress4Shipper.Value = user.br.Address4
        End If

        If String.IsNullOrEmpty(user.br.ZipCode) Then
            txtAddress5Shipper.Value = ""
        Else
            txtAddress5Shipper.Value = user.br.ZipCode
        End If

        If String.IsNullOrEmpty(user.br.email) Then
            txtEmailShipper.Value = ""
        Else
            txtEmailShipper.Value = user.br.email
        End If

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
        Dim shipper_ As String = ""
        If String.IsNullOrEmpty(txtDeliverycode.Value.Trim) Then
            Delivery_code = ""
            shipper_ = "0"
        Else
            Delivery_code = txtDeliverycode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Delivery_code And p.Shipper = "0") Or p.Shipper = shipper_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

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
        'Dim PartyCode As String = CStr(e.CommandArgument)
        'Try
        '    If e.CommandName.Equals("SelectDelivery") Then

        '        If String.IsNullOrEmpty(PartyCode) Then

        '            MsgBox("เป็นค่าว่าง")
        '        Else
        '            Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

        '            txtDeliverycode.Value = user.u.PartyCode
        '            txtNameEngDelivery.Value = user.u.PartyFullName
        '            txtAddress1Delivery.Value = user.br.Address1
        '            txtAddress2Delivery.Value = user.br.Address2
        '            txtAddress3Delivery.Value = user.br.Address3
        '            txtAddress4Delivery.Value = user.br.Address4
        '            txtAddress5Delivery.Value = user.br.ZipCode
        '            txtEmailDelivery.Value = user.br.email
        '            txtContractPersonDelivery.Value = user.br.Attn

        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Protected Sub Repeater3_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater3.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)
            Dim lblPartyAddressCode As Label = CType(e.Item.FindControl("lblPartyAddressCode"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyAddressCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString()
            End If
        End If

    End Sub
    Protected Sub clickdelivery_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        If String.IsNullOrEmpty(user.u.PartyCode) Then
            txtDeliverycode.Value = ""
        Else
            txtDeliverycode.Value = user.u.PartyCode
        End If

        If String.IsNullOrEmpty(user.u.PartyFullName) Then
            txtNameEngDelivery.Value = ""
        Else
            txtNameEngDelivery.Value = user.u.PartyFullName
        End If

        If String.IsNullOrEmpty(user.br.Address1) Then
            txtAddress1Delivery.Value = ""
        Else
            txtAddress1Delivery.Value = user.br.Address1
        End If

        If String.IsNullOrEmpty(user.br.Address2) Then
            txtAddress2Delivery.Value = ""
        Else
            txtAddress2Delivery.Value = user.br.Address2
        End If

        If String.IsNullOrEmpty(user.br.Address3) Then
            txtAddress3Delivery.Value = ""
        Else
            txtAddress3Delivery.Value = user.br.Address3
        End If

        If String.IsNullOrEmpty(user.br.Address4) Then
            txtAddress4Delivery.Value = ""
        Else
            txtAddress4Delivery.Value = user.br.Address4
        End If

        If String.IsNullOrEmpty(user.br.ZipCode) Then
            txtAddress5Delivery.Value = ""
        Else
            txtAddress5Delivery.Value = user.br.ZipCode
        End If

        If String.IsNullOrEmpty(user.br.email) Then
            txtEmailDelivery.Value = ""
        Else
            txtEmailDelivery.Value = user.br.email
        End If
        If String.IsNullOrEmpty(user.br.Attn) Then
            txtContractPersonDelivery.Value = ""
        Else
            txtContractPersonDelivery.Value = user.br.Attn
        End If

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
        Dim shipper_ As String = ""
        If String.IsNullOrEmpty(txtCodePickUpPlace.Value.Trim) Then
            Pickup_code = ""
            shipper_ = "0"
        Else
            Pickup_code = txtCodePickUpPlace.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Pickup_code And p.Shipper = "0") Or p.Shipper = shipper_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

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
        'Dim PartyCode As String = CStr(e.CommandArgument)
        'Try
        '    If e.CommandName.Equals("SelectPickUp") Then

        '        If String.IsNullOrEmpty(PartyCode) Then

        '            MsgBox("เป็นค่าว่าง")
        '        Else
        '            Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

        '            txtCodePickUpPlace.Value = user.u.PartyCode
        '            txtNamePickUpPlace.Value = user.u.PartyFullName
        '            txtAddress1PickUpPlace.Value = user.br.Address1
        '            txtAddress2PickUpPlace.Value = user.br.Address2
        '            txtAddress3PickUpPlace.Value = user.br.Address3
        '            txtAddress4PickUpPlace.Value = user.br.Address4
        '            txtAddress5PickUpPlace.Value = user.br.ZipCode
        '            txtEmailPickUpPlace.Value = user.br.email
        '            txtContractPersonPickUpPlace.Value = user.br.Attn

        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Protected Sub Repeater4_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater4.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)
            Dim lblPartyAddressCode As Label = CType(e.Item.FindControl("lblPartyAddressCode"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyAddressCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString()
            End If
        End If

    End Sub
    Protected Sub clickpickup_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        If String.IsNullOrEmpty(user.u.PartyCode) Then
            txtCodePickUpPlace.Value = ""
        Else
            txtCodePickUpPlace.Value = user.u.PartyCode
        End If

        If String.IsNullOrEmpty(user.u.PartyFullName) Then
            txtNamePickUpPlace.Value = ""
        Else
            txtNamePickUpPlace.Value = user.u.PartyFullName
        End If

        If String.IsNullOrEmpty(user.br.Address1) Then
            txtAddress1PickUpPlace.Value = ""
        Else
            txtAddress1PickUpPlace.Value = user.br.Address1
        End If

        If String.IsNullOrEmpty(user.br.Address2) Then
            txtAddress2PickUpPlace.Value = ""
        Else
            txtAddress2PickUpPlace.Value = user.br.Address2
        End If

        If String.IsNullOrEmpty(user.br.Address3) Then
            txtAddress3PickUpPlace.Value = ""
        Else
            txtAddress3PickUpPlace.Value = user.br.Address3
        End If

        If String.IsNullOrEmpty(user.br.Address4) Then
            txtAddress4PickUpPlace.Value = ""
        Else
            txtAddress4PickUpPlace.Value = user.br.Address4
        End If

        If String.IsNullOrEmpty(user.br.ZipCode) Then
            txtAddress5PickUpPlace.Value = ""
        Else
            txtAddress5PickUpPlace.Value = user.br.ZipCode
        End If

        If String.IsNullOrEmpty(user.br.email) Then
            txtEmailPickUpPlace.Value = ""
        Else
            txtEmailPickUpPlace.Value = user.br.email
        End If
        If String.IsNullOrEmpty(user.br.Attn) Then
            txtContractPersonPickUpPlace.Value = ""
        Else
            txtContractPersonPickUpPlace.Value = user.br.Attn
        End If

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
        Dim shipper_ As String = ""
        If String.IsNullOrEmpty(txtCustomercode.Value.Trim) Then
            Customer_code = ""
            shipper_ = "0"
        Else
            Customer_code = txtCustomercode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Customer_code And p.Shipper = "0") Or p.Shipper = shipper_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

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
        'Dim PartyCode As String = CStr(e.CommandArgument)
        'Try
        '    If e.CommandName.Equals("SelectCustomer") Then

        '        If String.IsNullOrEmpty(PartyCode) Then

        '            MsgBox("เป็นค่าว่าง")
        '        Else
        '            Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

        '            txtCustomercode.Value = user.u.PartyCode
        '            txtNameEngCustomer.Value = user.u.PartyFullName
        '            txtAddress1Custommer.Value = user.br.Address1
        '            txtAddress2Custommer.Value = user.br.Address2
        '            txtAddress3Custommer.Value = user.br.Address3
        '            txtAddress4Custommer.Value = user.br.Address4
        '            txtAddress5Custommer.Value = user.br.ZipCode
        '            txtEmailCustommer.Value = user.br.email
        '            txtContractPersonCustommer.Value = user.br.Attn

        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Protected Sub Repeater5_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater5.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)
            Dim lblPartyAddressCode As Label = CType(e.Item.FindControl("lblPartyAddressCode"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyAddressCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString()
            End If
        End If

    End Sub
    Protected Sub clickcustomer_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        If String.IsNullOrEmpty(user.u.PartyCode) Then
            txtCustomercode.Value = ""
        Else
            txtCustomercode.Value = user.u.PartyCode
        End If

        If String.IsNullOrEmpty(user.u.PartyFullName) Then
            txtNameEngCustomer.Value = ""
        Else
            txtNameEngCustomer.Value = user.u.PartyFullName
        End If

        If String.IsNullOrEmpty(user.br.Address1) Then
            txtAddress1Custommer.Value = ""
        Else
            txtAddress1Custommer.Value = user.br.Address1
        End If

        If String.IsNullOrEmpty(user.br.Address2) Then
            txtAddress2Custommer.Value = ""
        Else
            txtAddress2Custommer.Value = user.br.Address2
        End If

        If String.IsNullOrEmpty(user.br.Address3) Then
            txtAddress3Custommer.Value = ""
        Else
            txtAddress3Custommer.Value = user.br.Address3
        End If

        If String.IsNullOrEmpty(user.br.Address4) Then
            txtAddress4Custommer.Value = ""
        Else
            txtAddress4Custommer.Value = user.br.Address4
        End If

        If String.IsNullOrEmpty(user.br.ZipCode) Then
            txtAddress5Custommer.Value = ""
        Else
            txtAddress5Custommer.Value = user.br.ZipCode
        End If

        If String.IsNullOrEmpty(user.br.email) Then
            txtEmailCustommer.Value = ""
        Else
            txtEmailCustommer.Value = user.br.email
        End If
        If String.IsNullOrEmpty(user.br.Attn) Then
            txtContractPersonCustommer.Value = ""
        Else
            txtContractPersonCustommer.Value = user.br.Attn
        End If

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
        Dim shipper_ As String = ""
        If String.IsNullOrEmpty(txtCodeEndCustomer.Value.Trim) Then
            EndCustomer_code = ""
            shipper_ = "0"
        Else
            EndCustomer_code = txtCodeEndCustomer.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = EndCustomer_code And p.Shipper = "0") Or p.Shipper = shipper_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

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
        'Dim PartyCode As String = CStr(e.CommandArgument)
        'Try
        '    If e.CommandName.Equals("SelectEndCustomer") Then

        '        If String.IsNullOrEmpty(PartyCode) Then

        '            MsgBox("เป็นค่าว่าง")
        '        Else
        '            Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

        '            txtCodeEndCustomer.Value = user.u.PartyCode
        '            txtNameEndCustomer.Value = user.u.PartyFullName
        '            txtAddress1EndCustomer.Value = user.br.Address1
        '            txtAddress2EndCustomer.Value = user.br.Address2
        '            txtAddress3EndCustomer.Value = user.br.Address3
        '            txtAddress4EndCustomer.Value = user.br.Address4
        '            txtAddress5EndCustomer.Value = user.br.ZipCode
        '            txtEmailEndCustomer.Value = user.br.email
        '            txtContractPersonEndCustomer.Value = user.br.Attn

        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Protected Sub Repeater6_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater6.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)
            Dim lblPartyAddressCode As Label = CType(e.Item.FindControl("lblPartyAddressCode"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString()
            End If
            If Not IsNothing(lblPartyCode) Then
                lblPartyAddressCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString()
            End If
        End If

    End Sub
    Protected Sub clickendcustomer_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        If String.IsNullOrEmpty(user.u.PartyCode) Then
            txtCodeEndCustomer.Value = ""
        Else
            txtCodeEndCustomer.Value = user.u.PartyCode
        End If

        If String.IsNullOrEmpty(user.u.PartyFullName) Then
            txtNameEndCustomer.Value = ""
        Else
            txtNameEndCustomer.Value = user.u.PartyFullName
        End If

        If String.IsNullOrEmpty(user.br.Address1) Then
            txtAddress1EndCustomer.Value = ""
        Else
            txtAddress1EndCustomer.Value = user.br.Address1
        End If

        If String.IsNullOrEmpty(user.br.Address2) Then
            txtAddress2EndCustomer.Value = ""
        Else
            txtAddress2EndCustomer.Value = user.br.Address2
        End If

        If String.IsNullOrEmpty(user.br.Address3) Then
            txtAddress3EndCustomer.Value = ""
        Else
            txtAddress3EndCustomer.Value = user.br.Address3
        End If

        If String.IsNullOrEmpty(user.br.Address4) Then
            txtAddress4EndCustomer.Value = ""
        Else
            txtAddress4EndCustomer.Value = user.br.Address4
        End If

        If String.IsNullOrEmpty(user.br.ZipCode) Then
            txtAddress5EndCustomer.Value = ""
        Else
            txtAddress5EndCustomer.Value = user.br.ZipCode
        End If

        If String.IsNullOrEmpty(user.br.email) Then
            txtEmailEndCustomer.Value = ""
        Else
            txtEmailEndCustomer.Value = user.br.email
        End If
        If String.IsNullOrEmpty(user.br.Attn) Then
            txtContractPersonEndCustomer.Value = ""
        Else
            txtContractPersonEndCustomer.Value = user.br.Attn
        End If

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
        Dim testdate As Integer
        Dim ProCode As String = ""
        If String.IsNullOrEmpty(txtCodeCustommerGroup.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            ProCode = txtCodeCustommerGroup.Value.Trim
        End If

        Dim cons = (From u In db.tblProductDetails
                    Where u.ProductCode = ProCode Or u.CreateDate.Year = testdate
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
    Private Sub selectJobno()
        Dim testdate As Integer
        Dim lot As String
        If String.IsNullOrEmpty(txtJobno.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            lot = txtJobno.Value.Trim
        End If

        'Where e.LOTDate.Year = testdate
        Dim exl = (From e In db.tblImpGenLOTs Where e.EASLOTNo = txtJobno.Value.Trim Or e.LOTDate.Year = testdate Order By e.EASLOTNo Descending
                 Select New With {
                 e.EASLOTNo,
                 e.CustomerCode,
                 e.JobSite,
                 e.EndCusCode}).ToList
        Try
            If exl.Count > 0 Then
                Me.Repeater9.DataSource = exl
                Me.Repeater9.DataBind()
                ScriptManager.RegisterStartupScript(JobnoUpdatePanel, JobnoUpdatePanel.GetType(), "show", "$(function () { $('#" + JobnoPanel.ClientID + "').modal('show'); });", True)
                JobnoUpdatePanel.Update()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
                Exit Sub
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", ex.Message, True)
        End Try
    End Sub
    '--------------------------------------------------------------Click Search JobSite--------------------------------------------------
    Protected Sub btnJobSiteSeacrh_ServerClick(sender As Object, e As EventArgs)
        selectJobno()
    End Sub
    Protected Sub Repeater9_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim EASLOTNo As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("selectLotNO") Then
            Dim exp = (From ex In db.tblImpGenLOTs Where ex.EASLOTNo = EASLOTNo).SingleOrDefault

            If String.IsNullOrEmpty(exp.EASLOTNo) Then
                txtJobno.Value = ""
            Else
                txtJobno.Value = exp.EASLOTNo
            End If

            txtdatepickerJobdate.Text = Convert.ToDateTime(exp.LOTDate).ToString("dd/MM/yyyy")
            ddlLotof.Text = exp.LOTBy
            If String.IsNullOrEmpty(exp.SalesCode) Then
                ddlSaleman.Text = ""
            Else
                ddlSaleman.Text = exp.SalesCode
            End If
            If String.IsNullOrEmpty(exp.SalesName) Then
                txtsalemandis.Value = ""
            Else
                txtsalemandis.Value = exp.SalesName
            End If
            If String.IsNullOrEmpty(exp.ConsigneeCode) Then
                txtConsigneecode.Value = ""
            Else
                txtConsigneecode.Value = exp.ConsigneeCode
            End If
            If String.IsNullOrEmpty(exp.ConsignNameEng) Then
                txtNameEngConsign.Value = ""
            Else
                txtNameEngConsign.Value = exp.ConsignNameEng
            End If

            If String.IsNullOrEmpty(exp.ConsignAddress) Then
                txtAddress1.Value = ""
            Else
                txtAddress1.Value = exp.ConsignAddress
            End If

            If String.IsNullOrEmpty(exp.ConsignDistrict) Then
                txtAddress2.Value = ""
            Else
                txtAddress2.Value = exp.ConsignDistrict
            End If

            If String.IsNullOrEmpty(exp.ConsignSubProvince) Then
                txtAddress3.Value = ""
            Else
                txtAddress3.Value = exp.ConsignSubProvince
            End If
            If String.IsNullOrEmpty(exp.ConsignProvince) Then
                txtAddress4.Value = ""
            Else
                txtAddress4.Value = exp.ConsignProvince
            End If

            If String.IsNullOrEmpty(exp.ConsignPostCode) Then
                txtAddress5.Value = ""
            Else
                txtAddress5.Value = exp.ConsignPostCode
            End If

            If String.IsNullOrEmpty(exp.ConsignEmail) Then
                txtEmail.Value = ""
            Else
                txtEmail.Value = exp.ConsignEmail
            End If

            If String.IsNullOrEmpty(exp.ShipperCode) Then
                txtShippercode.Value = ""
            Else
                txtShippercode.Value = exp.ShipperCode
            End If

            If String.IsNullOrEmpty(exp.ShipperNameEng) Then
                txtNameEngShipper.Value = ""
            Else
                txtNameEngShipper.Value = exp.ShipperNameEng
            End If

            If String.IsNullOrEmpty(exp.ShipperAddress) Then
                txtAddress1Shipper.Value = ""
            Else
                txtAddress1Shipper.Value = exp.ShipperAddress
            End If
            If String.IsNullOrEmpty(exp.ShipperDistrict) Then
                txtAddress2Shipper.Value = ""
            Else
                txtAddress2Shipper.Value = exp.ShipperDistrict
            End If
            If String.IsNullOrEmpty(exp.ShipperSubprovince) Then
                txtAddress3Shipper.Value = ""
            Else
                txtAddress3Shipper.Value = exp.ShipperSubprovince
            End If
            If String.IsNullOrEmpty(exp.ShipperProvince) Then
                txtAddress4Shipper.Value = ""
            Else
                txtAddress4Shipper.Value = exp.ShipperProvince
            End If
            If String.IsNullOrEmpty(exp.ShipperPostCode) Then
                txtAddress5Shipper.Value = ""
            Else
                txtAddress5Shipper.Value = exp.ShipperPostCode
            End If

            If String.IsNullOrEmpty(exp.ShipperReturnCode) Then
                txtEmailShipper.Value = ""
            Else
                txtEmailShipper.Value = exp.ShipperReturnCode
            End If
            If String.IsNullOrEmpty(exp.Commodity) Then
                'ddlCommodity.Text = ""
            Else
                ddlCommodity.Text = exp.Commodity
            End If

            If String.IsNullOrEmpty(CStr(exp.QuantityofPart)) Then
                txtQuantityOfPart.Value = ""
            Else
                txtQuantityOfPart.Value = CStr(exp.QuantityofPart)
            End If

            If String.IsNullOrEmpty(exp.QuantityUnit) Then
                'ddlQuantityOfParty.Text = ""
            Else
                ddlQuantityOfParty.Text = exp.QuantityUnit
            End If

            If String.IsNullOrEmpty(CStr(exp.QuantityPack)) Then
                txtQuantity.Value = ""
            Else
                txtQuantity.Value = CStr(exp.QuantityPack)
            End If

            If String.IsNullOrEmpty(exp.QuantityUnitPack) Then
                'ddlQuan.Text = ""
            Else
                ddlQuan.Text = exp.QuantityUnitPack
            End If

            If String.IsNullOrEmpty(CStr(exp.QuantityPack1)) Then
                txtQuantityBox.Value = ""
            Else
                txtQuantityBox.Value = CStr(exp.QuantityPack1)
            End If

            If String.IsNullOrEmpty(exp.QuantityUnitPack1) Then
                'ddlquanbox.Text = ""
            Else
                ddlquanbox.Text = exp.QuantityUnitPack1
            End If

            If String.IsNullOrEmpty(CStr(exp.Weight)) Then
                txtWeight.Value = ""
            Else
                txtWeight.Value = String.Format("{0:0.00}", exp.Weight)
            End If

            If String.IsNullOrEmpty(exp.WeightUnit) Then
                'ddlWeight.Text = ""
            Else
                ddlWeight.Text = exp.WeightUnit
            End If

            If String.IsNullOrEmpty(CStr(exp.Volume)) Then
                txtVolume.Value = ""
            Else
                txtVolume.Value = CStr(exp.Volume)
            End If

            If String.IsNullOrEmpty(exp.VolumeUnit) Then
                'ddlvolume.Text = ""
            Else
                ddlvolume.Text = exp.VolumeUnit
            End If

            If String.IsNullOrEmpty(exp.MAWB) Then
                txtMAWB_BL_TWB.Value = ""
            Else
                txtMAWB_BL_TWB.Value = exp.MAWB
            End If

            ddlvolume2.Text = exp.DocType

            If String.IsNullOrEmpty(exp.DocCode) Then
                txtVolume2.Value = ""
            Else
                txtVolume2.Value = exp.DocCode
            End If

            If String.IsNullOrEmpty(exp.Flight) Then
                txtFLT_Voy_TruckDate.Value = ""
            Else
                txtFLT_Voy_TruckDate.Value = exp.Flight
            End If

            If String.IsNullOrEmpty(exp.FreighForwarder) Then
                'ddlFreight.Text = ""
            Else
                ddlFreight.Text = exp.FreighForwarder
            End If

            If String.IsNullOrEmpty(exp.ShipTo) Then
                txtShipto.Value = ""
            Else
                txtShipto.Value = exp.ShipTo
            End If

            If String.IsNullOrEmpty(exp.BillingNo) Then
                txtBilling.Value = ""
            Else
                txtBilling.Value = exp.BillingNo
            End If

            If String.IsNullOrEmpty(exp.FLT1) Then
                txtActual1.Value = ""
            Else
                txtActual1.Value = exp.FLT1
            End If

            If String.IsNullOrEmpty(exp.FLT2) Then
                txtActual2.Value = ""
            Else
                txtActual2.Value = exp.FLT2
            End If

            If String.IsNullOrEmpty(exp.FLT3) Then
                txtActual3.Value = ""
            Else
                txtActual3.Value = exp.FLT3
            End If

            If String.IsNullOrEmpty(exp.FLT4) Then
                txtActual4.Value = ""
            Else
                txtActual4.Value = exp.FLT4
            End If

            If String.IsNullOrEmpty(CStr(exp.DateFLT1)) Then
                txtdatepickerActualDate1.Text = ""
            Else
                txtdatepickerActualDate1.Text = CStr(exp.DateFLT1)
            End If

            If String.IsNullOrEmpty(CStr(exp.DateFLT2)) Then
                txtdatepickerActualDate2.Text = ""
            Else
                txtdatepickerActualDate2.Text = CStr(exp.DateFLT2)
            End If

            If String.IsNullOrEmpty(CStr(exp.DateFLT3)) Then
                txtdatepickerActualDate3.Text = ""
            Else
                txtdatepickerActualDate3.Text = CStr(exp.DateFLT3)
            End If

            If String.IsNullOrEmpty(CStr(exp.DateFLT4)) Then
                txtdatepickerActualDate4.Text = ""
            Else
                txtdatepickerActualDate4.Text = CStr(exp.DateFLT4)
            End If

            If String.IsNullOrEmpty(exp.ORGN1) Then
                txtORGN1.Value = ""
            Else
                txtORGN1.Value = exp.ORGN1
            End If

            If String.IsNullOrEmpty(exp.ORGN2) Then
                txtORGN2.Value = ""
            Else
                txtORGN2.Value = exp.ORGN2
            End If

            If String.IsNullOrEmpty(exp.ORGN3) Then
                txtORGN3.Value = ""
            Else
                txtORGN3.Value = exp.ORGN3
            End If

            If String.IsNullOrEmpty(exp.ORGN4) Then
                txtORGN4.Value = ""
            Else
                txtORGN4.Value = exp.ORGN4
            End If

            If String.IsNullOrEmpty(exp.DSTN1) Then
                txtDSTN1.Value = ""
            Else
                txtDSTN1.Value = exp.DSTN1
            End If

            If String.IsNullOrEmpty(exp.DSTN2) Then
                txtDSTN2.Value = ""
            Else
                txtDSTN2.Value = exp.DSTN2
            End If

            If String.IsNullOrEmpty(exp.DSTN3) Then
                txtDSTN3.Value = ""
            Else
                txtDSTN3.Value = exp.DSTN3
            End If

            If String.IsNullOrEmpty(exp.DSTN4) Then
                txtDSTN4.Value = ""
            Else
                txtDSTN4.Value = exp.DSTN4
            End If

            If String.IsNullOrEmpty(exp.ETD1) Then
                txtpickupETD.Value = ""
            Else
                txtpickupETD.Value = exp.ETD1
            End If

            If String.IsNullOrEmpty(exp.ETD2) Then
                txtpickupETD2.Value = ""
            Else
                txtpickupETD2.Value = exp.ETD2
            End If

            If String.IsNullOrEmpty(exp.ETD3) Then
                txtpickupETD3.Value = ""
            Else
                txtpickupETD3.Value = exp.ETD3
            End If

            If String.IsNullOrEmpty(exp.ETD4) Then
                txtpickupETD4.Value = ""
            Else
                txtpickupETD4.Value = exp.ETD4
            End If

            If String.IsNullOrEmpty(exp.ETA1) Then
                txtpickupETA.Value = ""
            Else
                txtpickupETA.Value = exp.ETA1
            End If

            If String.IsNullOrEmpty(exp.ETA2) Then
                txtpickupETA2.Value = ""
            Else
                txtpickupETA2.Value = exp.ETA2
            End If

            If String.IsNullOrEmpty(exp.ETA3) Then
                txtpickupETA3.Value = ""
            Else
                txtpickupETA3.Value = exp.ETA3
            End If

            If String.IsNullOrEmpty(exp.ETA4) Then
                txtpickupETA4.Value = ""
            Else
                txtpickupETA4.Value = exp.ETA4
            End If

            If String.IsNullOrEmpty(CStr(exp.PCS1)) Then
                txtPacket.Value = ""
            Else
                txtPacket.Value = CStr(exp.PCS1)
            End If

            If String.IsNullOrEmpty(CStr(exp.PCS2)) Then
                txtPacket2.Value = ""
            Else
                txtPacket2.Value = CStr(exp.PCS2)
            End If

            If String.IsNullOrEmpty(CStr(exp.PCS3)) Then
                txtPacket3.Value = ""
            Else
                txtPacket3.Value = CStr(exp.PCS3)
            End If

            If String.IsNullOrEmpty(CStr(exp.PCS4)) Then
                txtPacket4.Value = ""
            Else
                txtPacket4.Value = CStr(exp.PCS4)
            End If

            If String.IsNullOrEmpty(CStr(exp.Weight1)) Then
                txtWeightActual.Value = ""
            Else
                txtWeightActual.Value = CStr(exp.Weight1)
            End If

            If String.IsNullOrEmpty(CStr(exp.Weight2)) Then
                txtWeightActual2.Value = ""
            Else
                txtWeightActual2.Value = CStr(exp.Weight2)
            End If

            If String.IsNullOrEmpty(CStr(exp.Weight3)) Then
                txtWeightActual3.Value = ""
            Else
                txtWeightActual3.Value = CStr(exp.Weight3)
            End If

            If String.IsNullOrEmpty(CStr(exp.Weight4)) Then
                txtWeightActual4.Value = ""
            Else
                txtWeightActual4.Value = CStr(exp.Weight4)
            End If

            If String.IsNullOrEmpty(CStr(exp.TimeDTE)) Then
                txtTimePickUp.Value = ""
            Else
                txtTimePickUp.Value = CStr(exp.TimeDTE)
            End If

            If String.IsNullOrEmpty(CStr(exp.DateDTE)) Then
                txtdatepickerActualPickUp.Text = ""
            Else
                txtdatepickerActualPickUp.Text = CStr(exp.DateDTE)
            End If

            If String.IsNullOrEmpty(CStr(exp.TimeATT)) Then
                txtArrivalToEAS.Value = ""
            Else
                txtArrivalToEAS.Value = CStr(exp.TimeATT)
            End If

            If String.IsNullOrEmpty(CStr(exp.DateATT)) Then
                txtdatepickerArrivalToEAS.Text = ""
            Else
                txtdatepickerArrivalToEAS.Text = CStr(exp.DateATT)
            End If

            If String.IsNullOrEmpty(exp.Remark) Then
                txtRemarkInvoice.Value = ""
            Else
                txtRemarkInvoice.Value = exp.Remark
            End If

            If String.IsNullOrEmpty(exp.DOCode) Then
                txtDeliverycode.Value = ""
            Else
                txtDeliverycode.Value = exp.DOCode
            End If

            If String.IsNullOrEmpty(exp.DONameENG) Then
                txtNameEngDelivery.Value = ""
            Else
                txtNameEngDelivery.Value = exp.DONameENG
            End If

            If String.IsNullOrEmpty(exp.DOStreet_Number) Then
                txtAddress1Delivery.Value = ""
            Else
                txtAddress1Delivery.Value = exp.DOStreet_Number
            End If

            If String.IsNullOrEmpty(exp.DODistrict) Then
                txtAddress2Delivery.Value = ""
            Else
                txtAddress2Delivery.Value = exp.DODistrict
            End If

            If String.IsNullOrEmpty(exp.DOSubProvince) Then
                txtAddress3Delivery.Value = ""
            Else
                txtAddress3Delivery.Value = exp.DOSubProvince
            End If

            If String.IsNullOrEmpty(exp.DOProvince) Then
                txtAddress4Delivery.Value = ""
            Else
                txtAddress4Delivery.Value = exp.DOProvince
            End If

            If String.IsNullOrEmpty(exp.DOPostCode) Then
                txtAddress5Delivery.Value = ""
            Else
                txtAddress5Delivery.Value = exp.DOPostCode
            End If

            If String.IsNullOrEmpty(exp.DOEmail) Then
                txtEmailDelivery.Value = ""
            Else
                txtEmailDelivery.Value = exp.DOEmail
            End If

            If String.IsNullOrEmpty(exp.DOContactPerson) Then
                txtContractPersonDelivery.Value = ""
            Else
                txtContractPersonDelivery.Value = exp.DOContactPerson
            End If

            If String.IsNullOrEmpty(exp.IEATNo) Then
                txtIEATNo.Value = ""
            Else
                txtIEATNo.Value = exp.IEATNo
            End If

            If String.IsNullOrEmpty(exp.EntryNo) Then
                txtImportEntryNo.Value = ""
            Else
                txtImportEntryNo.Value = exp.EntryNo
            End If

            txtdatepickerImportEntryDate.Text = Convert.ToDateTime(exp.DeliveryDate).ToString("dd/MM/yyyy")

            If String.IsNullOrEmpty(exp.CustomerCode) Then
                txtCustomercode.Value = ""
            Else
                txtCustomercode.Value = exp.CustomerCode
            End If

            If String.IsNullOrEmpty(exp.CustomerENG) Then
                txtNameEngCustomer.Value = ""
            Else
                txtNameEngCustomer.Value = exp.CustomerENG
            End If

            If String.IsNullOrEmpty(exp.CustomerStreet) Then
                txtAddress1Custommer.Value = ""
            Else
                txtAddress1Custommer.Value = exp.CustomerStreet
            End If

            If String.IsNullOrEmpty(exp.CustomerDistrict) Then
                txtAddress2Custommer.Value = ""
            Else
                txtAddress2Custommer.Value = exp.CustomerDistrict
            End If

            If String.IsNullOrEmpty(exp.CustomerSub) Then
                txtAddress3Custommer.Value = ""
            Else
                txtAddress3Custommer.Value = exp.CustomerSub
            End If

            If String.IsNullOrEmpty(exp.CustomerProvince) Then
                txtAddress4Custommer.Value = ""
            Else
                txtAddress4Custommer.Value = exp.CustomerProvince
            End If

            If String.IsNullOrEmpty(exp.CustomerPostCode) Then
                txtAddress5Custommer.Value = ""
            Else
                txtAddress5Custommer.Value = exp.CustomerPostCode
            End If

            If String.IsNullOrEmpty(exp.CustomerEmail) Then
                txtEmailCustommer.Value = ""
            Else
                txtEmailCustommer.Value = exp.CustomerEmail
            End If

            If String.IsNullOrEmpty(exp.CustomerContact) Then
                txtContractPersonCustommer.Value = ""
            Else
                txtContractPersonCustommer.Value = exp.CustomerContact
            End If

            If String.IsNullOrEmpty(exp.PickUpCode) Then
                txtCodePickUpPlace.Value = ""
            Else
                txtCodePickUpPlace.Value = exp.PickUpCode
            End If

            If String.IsNullOrEmpty(exp.PickUpENG) Then
                txtNamePickUpPlace.Value = ""
            Else
                txtNamePickUpPlace.Value = exp.PickUpENG
            End If

            If String.IsNullOrEmpty(exp.PickUpAddress1) Then
                txtAddress1PickUpPlace.Value = ""
            Else
                txtAddress1PickUpPlace.Value = exp.PickUpAddress1
            End If

            If String.IsNullOrEmpty(exp.PickUpAddress2) Then
                txtAddress2PickUpPlace.Value = ""
            Else
                txtAddress2PickUpPlace.Value = exp.PickUpAddress2
            End If
            If String.IsNullOrEmpty(exp.PickUpAddress3) Then
                txtAddress3PickUpPlace.Value = ""
            Else
                txtAddress3PickUpPlace.Value = exp.PickUpAddress3
            End If

            If String.IsNullOrEmpty(exp.PickUpAddress4) Then
                txtAddress4PickUpPlace.Value = ""
            Else
                txtAddress4PickUpPlace.Value = exp.PickUpAddress4
            End If

            If String.IsNullOrEmpty(exp.PickUpAddress5) Then
                txtAddress5PickUpPlace.Value = ""
            Else
                txtAddress5PickUpPlace.Value = exp.PickUpAddress5
            End If

            If String.IsNullOrEmpty(exp.PickUpEmail) Then
                txtEmailPickUpPlace.Value = ""
            Else
                txtEmailPickUpPlace.Value = exp.PickUpEmail
            End If

            If String.IsNullOrEmpty(exp.PickUpContact) Then
                txtContractPersonPickUpPlace.Value = ""
            Else
                txtContractPersonPickUpPlace.Value = exp.PickUpContact
            End If

            If String.IsNullOrEmpty(exp.EndCusCode) Then
                txtCodeEndCustomer.Value = ""
            Else
                txtCodeEndCustomer.Value = exp.EndCusCode
            End If

            If String.IsNullOrEmpty(exp.EndCusENG) Then
                txtNameEndCustomer.Value = ""
            Else
                txtNameEndCustomer.Value = exp.EndCusENG
            End If

            If String.IsNullOrEmpty(exp.EndCusAddress1) Then
                txtAddress1EndCustomer.Value = ""
            Else
                txtAddress1EndCustomer.Value = exp.EndCusAddress1
            End If

            If String.IsNullOrEmpty(exp.EndCusAddress2) Then
                txtAddress2EndCustomer.Value = ""
            Else
                txtAddress2EndCustomer.Value = exp.EndCusAddress2
            End If
            If String.IsNullOrEmpty(exp.EndCusAddress3) Then
                txtAddress3EndCustomer.Value = ""
            Else
                txtAddress3EndCustomer.Value = exp.EndCusAddress3
            End If
            If String.IsNullOrEmpty(exp.EndCusAddress4) Then
                txtAddress4EndCustomer.Value = ""
            Else
                txtAddress4EndCustomer.Value = exp.EndCusAddress4
            End If

            If String.IsNullOrEmpty(exp.EndCusAddress5) Then
                txtAddress5EndCustomer.Value = ""
            Else
                txtAddress5EndCustomer.Value = exp.EndCusAddress5
            End If

            If String.IsNullOrEmpty(exp.EndCusEmail) Then
                txtEmailEndCustomer.Value = ""
            Else
                txtEmailEndCustomer.Value = exp.EndCusEmail
            End If

            If String.IsNullOrEmpty(exp.EndCusContact) Then
                txtContractPersonEndCustomer.Value = ""
            Else
                txtContractPersonEndCustomer.Value = exp.EndCusContact
            End If


            If String.IsNullOrEmpty(exp.IEATPermit) Then
                'ddlIEATPermit.Text = ""
            Else
                ddlIEATPermit.Text = exp.IEATPermit
            End If

            If String.IsNullOrEmpty(exp.Status1) Then
                'ddlStatusIEAT1.Text = ""
            Else
                ddlStatusIEAT1.Text = exp.Status1
            End If
            If String.IsNullOrEmpty(exp.Status2) Then
                'ddlStatusIEAT2.Text = ""
            Else
                ddlStatusIEAT2.Text = exp.Status2
            End If

            If String.IsNullOrEmpty(exp.JobSite) Then
                'ddlJobsite.Text = ""
            Else
                ddlJobsite.Text = exp.JobSite
            End If

            If String.IsNullOrEmpty(exp.CustomerCodeGroup) Then
                txtCodeCustommerGroup.Value = ""
            Else
                txtCodeCustommerGroup.Value = exp.CustomerCodeGroup
            End If
            If String.IsNullOrEmpty(exp.CustomerENGGroup) Then
                txtNameCustommerGroup.Value = ""
            Else
                txtNameCustommerGroup.Value = exp.CustomerENGGroup
            End If

            'ReadDATA()
            ReadDATA2()
            'ReadDATAEAS()
            DataFlight()

        End If
    End Sub
    '--------------------------------------------------Save Data News-----------------------------------------------
    Private Sub SaveDATA_New()
        Dim Jobdate As Date
        Dim ActualDate1 As Date
        Dim ActualDate2 As Date
        Dim ActualDate3 As Date
        Dim ActualDate4 As Date
        Dim ActualPickUp As Date
        Dim ArrivalToEAS As Date
        Dim ReturnDate As Date
        Dim ReturnDate2 As Date
        Dim ImportEntryDate As Date

        Dim fwdstatus As String = "0"

        If txtJobno.Value.Trim() = "" Then
            MsgBox("กรุณาป้อน LOT No ก่อน !!!")
            txtJobno.Focus()
            Exit Sub
        End If

        If txtdatepickerJobdate.Text = "" Then
            Jobdate = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            Jobdate = DateTime.ParseExact(txtdatepickerJobdate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If txtdatepickerActualDate1.Text = "" Then
            ActualDate1 = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            ActualDate1 = DateTime.ParseExact(txtdatepickerActualDate1.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If txtdatepickerActualDate2.Text = "" Then
            ActualDate2 = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            ActualDate2 = DateTime.ParseExact(txtdatepickerActualDate2.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If txtdatepickerActualDate3.Text = "" Then
            ActualDate3 = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            ActualDate3 = DateTime.ParseExact(txtdatepickerActualDate3.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If txtdatepickerActualDate4.Text = "" Then
            ActualDate4 = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            ActualDate4 = DateTime.ParseExact(txtdatepickerActualDate4.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If txtdatepickerActualPickUp.Text = "" Then
            ActualPickUp = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            ActualPickUp = DateTime.ParseExact(txtdatepickerActualPickUp.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If txtdatepickerArrivalToEAS.Text = "" Then
            ArrivalToEAS = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            ArrivalToEAS = DateTime.ParseExact(txtdatepickerArrivalToEAS.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If txtdatepickerReturnDate.Text = "" Then
            ReturnDate = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            ReturnDate = DateTime.ParseExact(txtdatepickerReturnDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If txtdatepickerReturnDate2.Text = "" Then
            ReturnDate2 = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            ReturnDate2 = DateTime.ParseExact(txtdatepickerReturnDate2.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If txtdatepickerImportEntryDate.Text = "" Then
            ImportEntryDate = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            ImportEntryDate = DateTime.ParseExact(txtdatepickerImportEntryDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If

        If MsgBox("คุณต้องการเพิ่มรายการ LOT No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    db.tblImpGenLOTs.Add(New tblImpGenLOT With { _
                                         .EASLOTNo = txtJobno.Value.Trim, _
                                         .JobSite = ddlJobsite.Text.Trim, _
                                         .LOTDate = Jobdate, _
                                         .LOTBy = ddlLotof.Text.Trim, _
                                         .SalesCode = ddlSaleman.Text.Trim, _
                                         .SalesName = txtsalemandis.Value.Trim, _
                                         .ConsigneeCode = txtConsigneecode.Value.Trim, _
                                         .ConsignNameEng = txtNameEngConsign.Value.Trim, _
                                         .ConsignAddress = txtAddress1.Value.Trim, _
                                         .ConsignDistrict = txtAddress2.Value.Trim, _
                                         .ConsignSubProvince = txtAddress3.Value.Trim, _
                                         .ConsignProvince = txtAddress4.Value.Trim, _
                                         .ConsignPostCode = txtAddress5.Value.Trim, _
                                         .ConsignEmail = txtEmail.Value.Trim, _
                                         .ShipperCode = txtShippercode.Value.Trim, _
                                         .ShipperNameEng = txtNameEngShipper.Value.Trim, _
                                         .ShipperAddress = txtAddress1Shipper.Value.Trim, _
                                         .ShipperDistrict = txtAddress2Shipper.Value.Trim, _
                                         .ShipperSubprovince = txtAddress3Shipper.Value.Trim, _
                                         .ShipperProvince = txtAddress4Shipper.Value.Trim, _
                                         .ShipperPostCode = txtAddress5Shipper.Value.Trim, _
                                         .ShipperReturnCode = txtEmailShipper.Value.Trim, _
                                         .Commodity = ddlCommodity.Text.Trim, _
                                         .QuantityofPart = CType(txtQuantityOfPart.Value.Trim, Double?), _
                                         .QuantityUnit = ddlQuantityOfParty.Text.Trim, _
                                         .QuantityPack = CType(txtQuantity.Value.Trim, Double?), _
                                         .QuantityUnitPack = ddlQuan.Text.Trim, _
                                         .Weight = CType(txtWeight.Value.Trim, Double?), _
                                         .WeightUnit = ddlWeight.Text.Trim, _
                                         .QuantityPack1 = CType(txtQuantityBox.Value.Trim, Double?), _
                                         .QuantityUnitPack1 = ddlquanbox.Text.Trim, _
                                         .Volume = CType(txtVolume.Value.Trim, Double?), _
                                         .VolumeUnit = ddlvolume.Text.Trim, _
                                         .MAWB = txtMAWB_BL_TWB.Value.Trim, _
                                         .Flight = txtFLT_Voy_TruckDate.Value.Trim, _
                                         .DocType = ddlvolume2.Text.Trim, _
                                         .DocCode = txtVolume2.Value.Trim, _
                                         .FreighForwarder = ddlFreight.Text.Trim, _
                                         .ShipTo = txtShipto.Value.Trim, _
                                         .BillingNo = txtBilling.Value.Trim, _
                                         .FLT1 = txtActual1.Value.Trim, _
                                         .FLT2 = txtActual2.Value.Trim, _
                                         .FLT3 = txtActual3.Value.Trim, _
                                         .FLT4 = txtActual4.Value.Trim, _
                                         .DateFLT1 = ActualDate1, _
                                         .DateFLT2 = ActualDate2, _
                                         .DateFLT3 = ActualDate3, _
                                         .DateFLT4 = ActualDate4, _
                                         .ORGN1 = txtORGN1.Value.Trim, _
                                         .ORGN2 = txtORGN2.Value.Trim, _
                                         .ORGN3 = txtORGN3.Value.Trim, _
                                         .ORGN4 = txtORGN4.Value.Trim, _
                                         .DSTN1 = txtDSTN1.Value.Trim, _
                                         .DSTN2 = txtDSTN2.Value.Trim, _
                                         .DSTN3 = txtDSTN3.Value.Trim, _
                                         .DSTN4 = txtDSTN4.Value.Trim, _
                                         .ETD1 = txtpickupETD.Value.Trim, _
                                         .ETD2 = txtpickupETD2.Value.Trim, _
                                         .ETD3 = txtpickupETD3.Value.Trim, _
                                         .ETD4 = txtpickupETD4.Value.Trim, _
                                         .ETA1 = txtpickupETA.Value.Trim, _
                                         .ETA2 = txtpickupETA2.Value.Trim, _
                                         .ETA3 = txtpickupETA3.Value.Trim, _
                                         .ETA4 = txtpickupETA4.Value.Trim, _
                                         .PCS1 = CType(txtPacket.Value.Trim, Double?), _
                                         .PCS2 = CType(txtPacket2.Value.Trim, Double?), _
                                         .PCS3 = CType(txtPacket3.Value.Trim, Double?), _
                                         .PCS4 = CType(txtPacket4.Value.Trim, Double?), _
                                         .Weight1 = CType(txtWeightActual.Value.Trim, Double?), _
                                         .Weight2 = CType(txtWeightActual2.Value.Trim, Double?), _
                                         .Weight3 = CType(txtWeightActual3.Value.Trim, Double?), _
                                         .Weight4 = CType(txtWeightActual4.Value.Trim, Double?), _
                                         .TimeDTE = txtTimePickUp.Value.Trim, _
                                         .DateDTE = ActualPickUp, _
                                         .TimeATT = txtArrivalToEAS.Value.Trim, _
                                         .DateATT = ArrivalToEAS, _
                                         .Remark = txtRamarkActual.Value.Trim, _
                                         .DOCode = txtDeliverycode.Value.Trim, _
                                         .DONameENG = txtNameEngDelivery.Value.Trim, _
                                         .DOStreet_Number = txtAddress1Delivery.Value.Trim, _
                                         .DODistrict = txtAddress2Delivery.Value.Trim, _
                                         .DOSubProvince = txtAddress3Delivery.Value.Trim, _
                                         .DOProvince = txtAddress4Delivery.Value.Trim, _
                                         .DOPostCode = txtAddress5Delivery.Value.Trim, _
                                         .DOEmail = txtEmailDelivery.Value.Trim, _
                                         .DOContactPerson = txtContractPersonDelivery.Value.Trim, _
                                         .PickUpCode = txtCodePickUpPlace.Value.Trim, _
                                         .PickUpENG = txtNamePickUpPlace.Value.Trim, _
                                         .PickUpAddress1 = txtAddress1PickUpPlace.Value.Trim, _
                                         .PickUpAddress2 = txtAddress2PickUpPlace.Value.Trim, _
                                         .PickUpAddress3 = txtAddress3PickUpPlace.Value.Trim, _
                                         .PickUpAddress4 = txtAddress4PickUpPlace.Value.Trim, _
                                         .PickUpAddress5 = txtAddress5PickUpPlace.Value.Trim, _
                                         .PickUpEmail = txtEmailPickUpPlace.Value.Trim, _
                                         .PickUpContact = txtContractPersonPickUpPlace.Value.Trim, _
                                         .CustomerCode = txtCustomercode.Value.Trim, _
                                         .CustomerENG = txtNameEngCustomer.Value.Trim, _
                                         .CustomerStreet = txtAddress1Custommer.Value.Trim, _
                                         .CustomerDistrict = txtAddress2Custommer.Value.Trim, _
                                         .CustomerSub = txtAddress3Custommer.Value.Trim, _
                                         .CustomerProvince = txtAddress4Custommer.Value.Trim, _
                                         .CustomerPostCode = txtAddress5Custommer.Value.Trim, _
                                         .CustomerEmail = txtEmailCustommer.Value.Trim, _
                                         .CustomerContact = txtContractPersonCustommer.Value.Trim, _
                                         .EndCusCode = txtCodeEndCustomer.Value.Trim, _
                                         .EndCusENG = txtNameEndCustomer.Value.Trim, _
                                         .EndCusAddress1 = txtAddress1EndCustomer.Value.Trim, _
                                         .EndCusAddress2 = txtAddress2EndCustomer.Value.Trim, _
                                         .EndCusAddress3 = txtAddress3EndCustomer.Value.Trim, _
                                         .EndCusAddress4 = txtAddress4EndCustomer.Value.Trim, _
                                         .EndCusAddress5 = txtAddress5EndCustomer.Value.Trim, _
                                         .EndCusEmail = txtEmailEndCustomer.Value.Trim, _
                                         .EndCusContact = txtContractPersonEndCustomer.Value.Trim, _
                                         .CustomerCodeGroup = txtCodeCustommerGroup.Value.Trim, _
                                         .CustomerENGGroup = txtNameCustommerGroup.Value.Trim, _
                                         .IEATNo = txtIEATNo.Value.Trim, _
                                         .IEATPermit = ddlIEATPermit.Text.Trim, _
                                         .EntryNo = txtImportEntryNo.Value.Trim, _
                                         .DeliveryDate = ImportEntryDate, _
                                         .Status = 0, _
                                         .Status1 = ddlStatusIEAT1.Text.Trim, _
                                         .Status2 = ddlStatusIEAT2.Text.Trim, _
                                         .Useby = CStr(Session("UserName")), _
                                         .JOBBranch = ddlJobsite.Text.Trim, _
                                         .fwdstatus = fwdstatus
                                     })

                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Add สำเร็จ !');", True)

                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                    'Finally
                    '    db.Database.Connection.Close()
                    '    db.Dispose()
                    '    tran.Dispose()
                End Try
            End Using
        End If
        txtJobno.Focus()
    End Sub 'saveเข้าtblExpGenLOT
    '--------------------------------------------------Save Data Modify-----------------------------------------------
    Private Sub SaveDATA_Modify()
        Dim JobNooo As String = Request.QueryString("EASLOTNo")
        If txtJobno.Value.Trim = "" Then
            MsgBox("กรุณาป้อน LOT No ก่อน !!!")
            'UnlockDATA()
            txtJobno.Focus()
            Exit Sub
        End If

        If MsgBox("คุณต้องการแก้ไขรายการ LOT No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    Dim edit As tblImpGenLOT = (From c In db.tblImpGenLOTs Where c.EASLOTNo = txtJobno.Value.Trim
                      Select c).First()
                    If edit IsNot Nothing Then
                        edit.EASLOTNo = txtJobno.Value.Trim
                        edit.JobSite = ddlJobsite.Text.Trim
                        edit.LOTDate = CDate(txtdatepickerJobdate.Text.Trim)
                        edit.LOTBy = ddlLotof.Text.Trim
                        edit.SalesCode = ddlSaleman.Text.Trim
                        edit.SalesName = txtsalemandis.Value.Trim
                        edit.ConsigneeCode = txtConsigneecode.Value.Trim
                        edit.ConsignNameEng = txtNameEngConsign.Value.Trim
                        edit.ConsignAddress = txtAddress1.Value.Trim
                        edit.ConsignDistrict = txtAddress2.Value.Trim
                        edit.ConsignSubProvince = txtAddress3.Value.Trim
                        edit.ConsignProvince = txtAddress4.Value.Trim
                        edit.ConsignPostCode = txtAddress5.Value.Trim
                        edit.ConsignEmail = txtEmail.Value.Trim
                        edit.ShipperCode = txtShippercode.Value.Trim
                        edit.ShipperNameEng = txtNameEngShipper.Value.Trim
                        edit.ShipperAddress = txtAddress1Shipper.Value.Trim
                        edit.ShipperDistrict = txtAddress2Shipper.Value.Trim
                        edit.ShipperSubprovince = txtAddress3Shipper.Value.Trim
                        edit.ShipperProvince = txtAddress4Shipper.Value.Trim
                        edit.ShipperPostCode = txtAddress5Shipper.Value.Trim
                        edit.ShipperReturnCode = txtEmailShipper.Value.Trim
                        edit.Commodity = ddlCommodity.Text.Trim
                        edit.QuantityofPart = CType(txtQuantityOfPart.Value.Trim, Double?)
                        edit.QuantityUnit = ddlQuantityOfParty.Text.Trim
                        edit.QuantityPack = CType(txtQuantity.Value.Trim, Double?)
                        edit.QuantityUnitPack = ddlQuan.Text.Trim
                        edit.Weight = CType(txtWeight.Value.Trim, Double?)
                        edit.WeightUnit = ddlWeight.Text.Trim
                        edit.QuantityPack1 = CType(txtQuantityBox.Value.Trim, Double?)
                        edit.QuantityUnitPack1 = ddlquanbox.Text.Trim
                        edit.Volume = CType(txtVolume.Value.Trim, Double?)
                        edit.VolumeUnit = ddlvolume.Text.Trim
                        edit.MAWB = txtMAWB_BL_TWB.Value.Trim
                        edit.Flight = txtFLT_Voy_TruckDate.Value.Trim
                        edit.DocType = ddlvolume2.Text.Trim
                        edit.DocCode = txtVolume2.Value.Trim
                        edit.FreighForwarder = ddlFreight.Text.Trim
                        edit.ShipTo = txtShipto.Value.Trim
                        edit.BillingNo = txtBilling.Value.Trim
                        edit.FLT1 = txtActual1.Value.Trim
                        edit.FLT2 = txtActual2.Value.Trim
                        edit.FLT3 = txtActual3.Value.Trim
                        edit.FLT4 = txtActual4.Value.Trim
                        edit.DateFLT1 = CType(txtdatepickerActualDate1.Text.Trim, Date?)
                        edit.DateFLT2 = CType(txtdatepickerActualDate2.Text.Trim, Date?)
                        edit.DateFLT3 = CType(txtdatepickerActualDate3.Text.Trim, Date?)
                        edit.DateFLT4 = CType(txtdatepickerActualDate4.Text.Trim, Date?)
                        edit.ORGN1 = txtORGN1.Value.Trim
                        edit.ORGN2 = txtORGN2.Value.Trim
                        edit.ORGN3 = txtORGN3.Value.Trim
                        edit.ORGN4 = txtORGN4.Value.Trim
                        edit.DSTN1 = txtDSTN1.Value.Trim
                        edit.DSTN2 = txtDSTN2.Value.Trim
                        edit.DSTN3 = txtDSTN3.Value.Trim
                        edit.DSTN4 = txtDSTN4.Value.Trim
                        edit.ETD1 = txtpickupETD.Value.Trim
                        edit.ETD2 = txtpickupETD2.Value.Trim
                        edit.ETD3 = txtpickupETD3.Value.Trim
                        edit.ETD4 = txtpickupETD4.Value.Trim
                        edit.ETA1 = txtpickupETA.Value.Trim
                        edit.ETA2 = txtpickupETA2.Value.Trim
                        edit.ETA3 = txtpickupETA3.Value.Trim
                        edit.ETA4 = txtpickupETA4.Value.Trim
                        edit.PCS1 = CType(txtPacket.Value.Trim, Double?)
                        edit.PCS2 = CType(txtPacket2.Value.Trim, Double?)
                        edit.PCS3 = CType(txtPacket3.Value.Trim, Double?)
                        edit.PCS4 = CType(txtPacket4.Value.Trim, Double?)
                        edit.Weight1 = CType(txtWeightActual.Value.Trim, Double?)
                        edit.Weight2 = CType(txtWeightActual2.Value.Trim, Double?)
                        edit.Weight3 = CType(txtWeightActual3.Value.Trim, Double?)
                        edit.Weight4 = CType(txtWeightActual4.Value.Trim, Double?)
                        edit.TimeDTE = txtTimePickUp.Value.Trim
                        edit.DateDTE = CType(txtdatepickerActualPickUp.Text.Trim, Date?)
                        edit.TimeATT = txtArrivalToEAS.Value.Trim
                        edit.DateATT = CType(txtdatepickerArrivalToEAS.Text.Trim, Date?)
                        edit.Remark = txtRamarkActual.Value.Trim
                        edit.DOCode = txtDeliverycode.Value.Trim
                        edit.DONameENG = txtNameEngDelivery.Value.Trim
                        edit.DOStreet_Number = txtAddress1Delivery.Value.Trim
                        edit.DODistrict = txtAddress2Delivery.Value.Trim
                        edit.DOSubProvince = txtAddress3Delivery.Value.Trim
                        edit.DOProvince = txtAddress4Delivery.Value.Trim
                        edit.DOPostCode = txtAddress5Delivery.Value.Trim
                        edit.DOEmail = txtEmailDelivery.Value.Trim
                        edit.DOContactPerson = txtContractPersonDelivery.Value.Trim
                        edit.PickUpCode = txtCodePickUpPlace.Value.Trim
                        edit.PickUpENG = txtNamePickUpPlace.Value.Trim
                        edit.PickUpAddress1 = txtAddress1PickUpPlace.Value.Trim
                        edit.PickUpAddress2 = txtAddress2PickUpPlace.Value.Trim
                        edit.PickUpAddress3 = txtAddress3PickUpPlace.Value.Trim
                        edit.PickUpAddress4 = txtAddress4PickUpPlace.Value.Trim
                        edit.PickUpAddress5 = txtAddress5PickUpPlace.Value.Trim
                        edit.PickUpEmail = txtEmailPickUpPlace.Value.Trim
                        edit.PickUpContact = txtContractPersonPickUpPlace.Value.Trim
                        edit.CustomerCode = txtCustomercode.Value.Trim
                        edit.CustomerENG = txtNameEngCustomer.Value.Trim
                        edit.CustomerStreet = txtAddress1Custommer.Value.Trim
                        edit.CustomerDistrict = txtAddress2Custommer.Value.Trim
                        edit.CustomerSub = txtAddress3Custommer.Value.Trim
                        edit.CustomerProvince = txtAddress4Custommer.Value.Trim
                        edit.CustomerPostCode = txtAddress5Custommer.Value.Trim
                        edit.CustomerEmail = txtEmailCustommer.Value.Trim
                        edit.CustomerContact = txtContractPersonCustommer.Value.Trim
                        edit.EndCusCode = txtCodeEndCustomer.Value.Trim
                        edit.EndCusENG = txtNameEndCustomer.Value.Trim
                        edit.EndCusAddress1 = txtAddress1EndCustomer.Value.Trim
                        edit.EndCusAddress2 = txtAddress2EndCustomer.Value.Trim
                        edit.EndCusAddress3 = txtAddress3EndCustomer.Value.Trim
                        edit.EndCusAddress4 = txtAddress4EndCustomer.Value.Trim
                        edit.EndCusAddress5 = txtAddress5EndCustomer.Value.Trim
                        edit.EndCusEmail = txtEmailEndCustomer.Value.Trim
                        edit.EndCusContact = txtContractPersonEndCustomer.Value.Trim
                        edit.CustomerCodeGroup = txtCodeCustommerGroup.Value.Trim
                        edit.CustomerENGGroup = txtNameCustommerGroup.Value.Trim
                        edit.IEATNo = txtIEATNo.Value.Trim
                        edit.IEATPermit = ddlIEATPermit.Text.Trim
                        edit.EntryNo = txtImportEntryNo.Value.Trim
                        edit.DeliveryDate = CType(txtdatepickerImportEntryDate.Text.Trim, Date?)
                        edit.Status1 = ddlStatusIEAT1.Text.Trim
                        edit.Status2 = ddlStatusIEAT2.Text.Trim
                        edit.Useby = CStr(Session("UserId"))

                        db.SaveChanges()
                        tran.Complete()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                    End If
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        txtJobno.Focus()
    End Sub 'saveModifyเข้าที่tblExpGenLOT

    Protected Sub btnSaveAddHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then

            If ddlJobsite.Text = "LKB" Then
                Gentbl("ExpLOTIN")
            ElseIf ddlJobsite.Text = "SBIA" Then
                Gentbl("SBIALOTIN")
            ElseIf ddlJobsite.Text = "HCR" Then
                Gentbl("HCRLOTIN")
            ElseIf ddlJobsite.Text = "HTO" Then
                Gentbl("HTOLOTIN")
            ElseIf ddlJobsite.Text = "AEC" Then
                Gentbl("AECLOTIN")
            ElseIf ddlJobsite.Text = "MJB" Then
                Gentbl("MJBLOTIN")
            ElseIf ddlJobsite.Text = "LEA" Then
                Gentbl("LEALOTIN")
            ElseIf ddlJobsite.Text = "SPM" Then
                Gentbl("SPMLOTIN")
            ElseIf ddlJobsite.Text = "PTN" Then
                Gentbl("PTNLOTIN")
            ElseIf ddlJobsite.Text = "CKT" Then
                Gentbl("CKTLOTIN")
            ElseIf ddlJobsite.Text = "WIP" Then
                Gentbl("WIPLOTIN")
            End If
            SaveDATA_New()
            InsertData()
            ClearDATA()
            ReadDATA2()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub

    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveDATA_Modify()
            InsertData()
            ClearDATA()
            ReadDATA2()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    Protected Sub btnAddHead_ServerClick(sender As Object, e As EventArgs)
        stockqty_fieldset.Disabled = False
        importgoods_fieldset.Disabled = False
        exportgoods_fieldset.Disabled = True
        detailofgoods_fieldset.Disabled = True
        assembly_fieldset.Disabled = False

        btnSaveAddHead.Visible = True
        btnSaveEditHead.Visible = False
        btnJobSiteSeacrh.Visible = False

        showVisible()
        ClearDATA()
    End Sub

    Protected Sub btnEditHead_ServerClick(sender As Object, e As EventArgs)
        stockqty_fieldset.Disabled = False
        importgoods_fieldset.Disabled = False
        exportgoods_fieldset.Disabled = False
        detailofgoods_fieldset.Disabled = False
        assembly_fieldset.Disabled = False

        btnSaveEditHead.Visible = True
        btnSaveAddHead.Visible = False

        btnJobSiteSeacrh.Visible = True
        txtJobno.Disabled = False

        'txtInvoiceNo.Disabled = True
        'txtProductCodeInvoice.Disabled = True
        'txtItemNoInvoice.Disabled = True

        ClearDATA()
    End Sub
    Private Sub showVisible()
        'FormLeft_MasterJob.Visible = True
        'FormRight_MasterJob.Visible = True
        btnGenIEATNo.Disabled = True

        txtJobno.Disabled = True
        'txtInvoiceNo.Disabled = True
        'txtPONoProductCode.Disabled = True
        'txtQuantityInvoice.Disabled = True
        'ddlQuantityInvoice.Enabled = False
        'txtWeightInvoice.Disabled = True
        'txtdatepickerDataInvoice.Enabled = False
        'txtProductNameInvoice.Disabled = True
        'txtPallet_SKIDInvoice.Disabled = True
        'ddlPallet_SKIDInvoice.Enabled = False
        'txtBoxInvoice.Disabled = True
        'ddlBoxInvoice.Enabled = False
        'txtRemarkInvoice.Disabled = True
        'txtShipmentInvoice.Disabled = True
        'txtItemNoInvoice.Disabled = True
        'txtWidthInvoice.Disabled = True
        'txtHeightInvoice.Disabled = True
        'ddlUnitDimension.Enabled = False
        'txtPalletDimensionInvoice.Disabled = True
        'txtLenghtInvoice.Disabled = True
        'txtEntryItemNoInvoice.Disabled = True
        'ddlCurrencyInvoice.Enabled = False
        'txtExchangeRateInvoice.Disabled = True
        'txtPriceForeignInvoice.Disabled = True
        'txtPriceBathInvoice.Disabled = True
        'txtAmountBathInvoice.Disabled = True
        'txtAmountForeignInvoice.Disabled = True
        'txtFlightNo.Disabled = True
        'txtdatepickerFlightDateInvoice.Enabled = False
        'txtQuantity_PLT_Skid_Invoice.Disabled = True
        'ddlQuantity_PLT_Skid_Invoice.Enabled = False
        'ddlQuantity_PLT_Skid_Invoice2.Enabled = False
        'txtQuantity_PLT_Skid_Invoice2.Disabled = True
        'txtQTYExportInvoice.Disabled = True

        'txtSelectFileForImport_Import.Disabled = True
        'btnImport_Import.Disabled = True
    End Sub
    Private Sub Gentbl(type As String)
        Dim tmpDate As Single = CSng(Format(Now(), "dd"))
        Dim Nmount As Single = CSng(Format(Now(), "MM"))
        Dim Nyear As Single = CSng(Format(Now(), "yy")) + 43
        Dim Nemount As String
        Dim Neyear As String
        Dim DigitNo_ As String = "000"
        Dim LotNo As String
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single
        Dim Digit_ As Single
        Dim JobSite As String
        Dim num_ As String
        Dim dunNo As String

        Nemount = Nmount.ToString("0#")
        Neyear = Nyear.ToString("0#")

        Mount = CSng(Nemount)
        Year = CSng(Neyear)
        Digit = CSng(DigitNo_)

        JobSite = ddlJobsite.Text.Trim
        If JobSite = "SBIA" Then
            LotNo = JobSite & "-" & Nyear.ToString("0#") & Nmount.ToString("0#")
        Else
            LotNo = JobSite & "-" & "IN-" & Nyear.ToString("0#") & Nmount.ToString("0#")
        End If

        If chkNextmonth.Checked = True Then
            Nmount = CSng(Format(Now(), "MM")) + 1
            Nemount = Nmount.ToString("0#")
            If Nemount > "12" Then
                Nmount = 1
                Nyear = CSng(Format(Now(), "yy")) + 44
                Nemount = Nmount.ToString("0#")
                Neyear = Nyear.ToString("0#")
            End If
        End If
        Dim sqlSearch = (From ep In db.tblGenAutoRunNoes Where ep.TypeCode = type And ep.MountNo = Nemount And ep.YearNo = Neyear And ep.RunNo = LotNo
                Group By TypeCode = ep.TypeCode,
                MountNo = ep.MountNo,
                YearNo = ep.YearNo,
                DigitNo = ep.DigitNo Into g = Group, Count()).SingleOrDefault

        If Not sqlSearch Is Nothing Then
            Digit_ = CSng(sqlSearch.DigitNo)

            If Nyear = Year Then
                If Nmount = Mount Then
                    Num = Digit_ + 1
                ElseIf Nmount <> Mount Then
                    Nmount = Mount
                    Num = Digit_ + 1
                End If

            End If
            If Nyear <> Year Then
                Nmount = Year
                If Nmount = Mount Then
                    Num = Digit_ + 1
                End If

                If Nyear <> Mount Then
                    Nmount = Mount
                    Num = Digit + 1
                End If

            End If
            num_ = Num.ToString("00#")
            dunNo = LotNo & Num.ToString("00#")
            upDateGenNum(type, Nemount, Neyear, num_)
            txtJobno.Value = dunNo
        Else

            If Nyear = Year Then
                If Nmount = Mount Then
                    Digit = Digit + 1
                    Num = Digit
                ElseIf Nmount <> Mount Then
                    Nmount = Mount
                    Num = Digit + 1
                End If

            End If
            If Nyear <> Year Then
                Nmount = Year
                If Nmount = Mount Then
                    Digit = Digit + 1
                    Num = Digit
                End If

                If Nyear <> Mount Then
                    Nmount = Mount
                    Num = Digit + 1
                End If

            End If
            num_ = Num.ToString("00#")
            dunNo = LotNo & Num.ToString("00#")

            db.tblGenAutoRunNoes.Add(New tblGenAutoRunNo With { _
                                .TypeCode = type, _
                                .RunNo = LotNo, _
                                .MountNo = Nemount, _
                                .YearNo = Neyear, _
                                .DigitNo = num_
                            })
            db.SaveChanges()
            txtJobno.Value = dunNo

        End If
    End Sub
    Private Sub upDateGenNum(type As String, Nemount As String, Neyear As String, DigitNo As String)
        Try
            Dim up = (From g In db.tblGenAutoRunNoes Where g.TypeCode = type And g.MountNo = Nemount And g.YearNo = Neyear Select g).First
            If up IsNot Nothing Then

                up.DigitNo = DigitNo

                db.SaveChanges()
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", ex.Message, True)
        End Try
    End Sub

    Private Sub GenIEATNo()
        Dim tmpDate As Single = CSng(Format(Now(), "dd"))
        Dim Nmount As Single = CSng(Format(Now(), "MM"))
        Dim Nyear As Single = CSng(Format(Now(), "yy"))
        Dim Nemount As String
        Dim Neyear As String
        Dim DigitNo_ As String = "000"
        Dim LotNo As String
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single
        Dim Digit_ As Single
        Dim num_ As String
        Dim dunNo As String
        Dim Type As String = "IEAT"

        Nemount = Nmount.ToString("0#")
        Neyear = Nyear.ToString("0#")

        Mount = CSng(Nemount)
        Year = CSng(Neyear)
        Digit = CSng(DigitNo_)

        If chkNextmonth.Checked = True Then
            Nmount = CSng(Format(Now(), "MM")) + 1
            Nemount = Nmount.ToString("0#")
            If Nemount > "12" Then
                Nmount = 1
                Nyear = CSng(Format(Now(), "yy")) + 44
                Nemount = Nmount.ToString("0#")
                Neyear = Nyear.ToString("0#")
            End If
        End If

        LotNo = Nyear.ToString("0#") & Nmount.ToString("0#")

        Dim sqlSearch = (From ep In db.tblGenAutoRunNoes Where ep.TypeCode = Type And ep.MountNo = Nemount And ep.YearNo = Neyear And ep.RunNo = LotNo
               Group By TypeCode = ep.TypeCode,
               MountNo = ep.MountNo,
               YearNo = ep.YearNo,
               DigitNo = ep.DigitNo Into g = Group, Count()).SingleOrDefault

        If Not sqlSearch Is Nothing Then
            Digit_ = CSng(sqlSearch.DigitNo)

            If Nyear = Year Then
                If Nmount = Mount Then
                    Num = Digit_ + 1
                ElseIf Nmount <> Mount Then
                    Nmount = Mount
                    Num = Digit_ + 1
                End If

            End If
            If Nyear <> Year Then
                Nmount = Year
                If Nmount = Mount Then
                    Num = Digit_ + 1
                End If

                If Nyear <> Mount Then
                    Nmount = Mount
                    Num = Digit + 1
                End If

            End If
            num_ = Num.ToString("00#")
            dunNo = LotNo & Num.ToString("00#")
            upDateGenNum(Type, Nemount, Neyear, num_)
            txtIEATNo.Value = dunNo
        Else

            If Nyear = Year Then
                If Nmount = Mount Then
                    Digit = Digit + 1
                    Num = Digit
                ElseIf Nmount <> Mount Then
                    Nmount = Mount
                    Num = Digit + 1
                End If

            End If
            If Nyear <> Year Then
                Nmount = Year
                If Nmount = Mount Then
                    Digit = Digit + 1
                    Num = Digit
                End If

                If Nyear <> Mount Then
                    Nmount = Mount
                    Num = Digit + 1
                End If

            End If
            num_ = Num.ToString("00#")
            dunNo = LotNo & Num.ToString("00#")

            db.tblGenAutoRunNoes.Add(New tblGenAutoRunNo With { _
                                .TypeCode = Type, _
                                .RunNo = LotNo, _
                                .MountNo = Nemount, _
                                .YearNo = Neyear, _
                                .DigitNo = num_
                            })
            db.SaveChanges()
            txtIEATNo.Value = dunNo

        End If
    End Sub

    Private Sub GentblIEATNo()
        Dim Nmount As Single = CSng(Format(Now(), "MM"))
        Dim Nyear As Single = CSng(Format(Now(), "yy"))
        Dim Nemount As String
        Dim Neyear As String
        Nemount = Nmount.ToString("0#")
        Neyear = Nyear.ToString("0#")
        If chkNextmonth.Checked = True Then
            Nmount = CSng(Format(Now(), "MM")) + 1
            Nemount = Nmount.ToString("0#")
            If Nemount > "12" Then
                Nmount = 1
                Nyear = CSng(Format(Now(), "yy")) + 44
                Nemount = Nmount.ToString("0#")
                Neyear = Nyear.ToString("0#")
            End If
        End If
        Dim sqlSearch = (From ep In db.tblGenAutoRunNoes Where ep.TypeCode = "IEATIN" And ep.MountNo = Nemount And ep.YearNo = Neyear
                Group By TypeCode = ep.TypeCode,
                MountNo = ep.MountNo,
                YearNo = ep.YearNo,
                DigitNo = ep.DigitNo Into g = Group, Count()).SingleOrDefault
        'DigitNo = ep.DigitNo.Max Into g = Group, Count()).SingleOrDefault
        If sqlSearch.Count > 0 Then
            txtTypeCode = sqlSearch.TypeCode
            txtMountNo = sqlSearch.MountNo
            txtYearNo = sqlSearch.YearNo
            txtDigitNo = sqlSearch.DigitNo
        End If

        'sqlSearch = "SELECT TypeCode,MountNo,YearNo,max(DigitNo)DigitNo FROM tblGenAutoNo WHERE (TypeCode = 'IEATIN' and MountNo='" & Nemount & "'and YearNo='" & Neyear & "')group by TypeCode,MountNo,YearNo"
        If txtMountNo = "" Then
            txtMountNo = Nemount
        End If
        If txtYearNo = "" Then
            txtYearNo = Neyear
        End If
        If txtDigitNo = "" Then
            txtDigitNo = "000"
        End If
    End Sub

    Protected Sub btnGenIEATNo_ServerClick(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtIEATNo.Value) Then
            GenIEATNo()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('Gen สามารถซ้ำได้ !!!')", True)
        End If
    End Sub

    Private Sub ClearDATA()
        chkNextmonth.Checked = False
        chkGenerateIEATNo.Checked = False
        txtJobno.Value = ""
        'ddlJobsite.Text = ""
        txtdatepickerJobdate.Text = ""
        'ddlLotof.Text = ""
        'ddlSaleman.Text = ""
        txtsalemandis.Value = ""
        txtConsigneecode.Value = ""
        txtNameEngConsign.Value = ""
        txtAddress1.Value = ""
        txtAddress2.Value = ""
        txtAddress3.Value = ""
        txtAddress4.Value = ""
        txtAddress5.Value = ""
        txtEmail.Value = ""
        txtShippercode.Value = ""
        txtNameEngShipper.Value = ""
        txtAddress1Shipper.Value = ""
        txtAddress2Shipper.Value = ""
        txtAddress3Shipper.Value = ""
        txtAddress4Shipper.Value = ""
        txtAddress5Shipper.Value = ""
        txtEmailShipper.Value = ""
        'ddlCommodity.Text = ""
        txtQuantityOfPart.Value = "0.0"
        'ddlQuantityOfParty.Text = ""
        txtQuantity.Value = "0.0"
        'ddlQuan.Text = ""
        txtWeight.Value = "0.0"
        'ddlWeight.Text = ""
        txtQuantityBox.Value = "0.0"
        'ddlquanbox.Text = ""
        txtVolume.Value = "0.0"
        'ddlvolume.Text = ""
        txtMAWB_BL_TWB.Value = ""
        txtFLT_Voy_TruckDate.Value = ""
        'ddlvolume2.Text = ""
        txtVolume2.Value = ""
        'ddlFreight.Text = ""
        txtShipto.Value = ""
        txtBilling.Value = ""
        txtActual1.Value = ""
        txtActual2.Value = ""
        txtActual3.Value = ""
        txtActual4.Value = ""
        'txtdatepickerActualDate1.Text = ""
        'txtdatepickerActualDate2.Text = ""
        'txtdatepickerActualDate3.Text = ""
        'txtdatepickerActualDate4.Text = ""
        txtORGN1.Value = ""
        txtORGN2.Value = ""
        txtORGN3.Value = ""
        txtORGN4.Value = ""
        txtDSTN1.Value = ""
        txtDSTN2.Value = ""
        txtDSTN3.Value = ""
        txtDSTN4.Value = ""
        txtpickupETD.Value = ""
        txtpickupETD2.Value = ""
        txtpickupETD3.Value = ""
        txtpickupETD4.Value = ""
        txtpickupETA.Value = ""
        txtpickupETA2.Value = ""
        txtpickupETA3.Value = ""
        txtpickupETA4.Value = ""
        txtPacket.Value = "0"
        txtPacket2.Value = "0"
        txtPacket3.Value = "0"
        txtPacket4.Value = "0"
        txtWeightActual.Value = "0"
        txtWeightActual2.Value = "0"
        txtWeightActual3.Value = "0"
        txtWeightActual4.Value = "0"
        txtTimePickUp.Value = ""
        'txtdatepickerActualPickUp.Text = ""
        txtArrivalToEAS.Value = ""
        'txtdatepickerArrivalToEAS.Text = ""
        txtRamarkActual.Value = ""
        txtDeliverycode.Value = ""
        txtNameEngDelivery.Value = ""
        txtAddress1Delivery.Value = ""
        txtAddress2Delivery.Value = ""
        txtAddress3Delivery.Value = ""
        txtAddress4Delivery.Value = ""
        txtAddress5Delivery.Value = ""
        txtEmailDelivery.Value = ""
        txtContractPersonDelivery.Value = ""
        txtCodePickUpPlace.Value = ""
        txtNamePickUpPlace.Value = ""
        txtAddress1PickUpPlace.Value = ""
        txtAddress2PickUpPlace.Value = ""
        txtAddress3PickUpPlace.Value = ""
        txtAddress4PickUpPlace.Value = ""
        txtAddress5PickUpPlace.Value = ""
        txtEmailPickUpPlace.Value = ""
        txtContractPersonPickUpPlace.Value = ""
        txtCustomercode.Value = ""
        txtNameEngCustomer.Value = ""
        txtAddress1Custommer.Value = ""
        txtAddress2Custommer.Value = ""
        txtAddress3Custommer.Value = ""
        txtAddress4Custommer.Value = ""
        txtAddress5Custommer.Value = ""
        txtEmailCustommer.Value = ""
        txtContractPersonCustommer.Value = ""
        txtCodeEndCustomer.Value = ""
        txtNameEndCustomer.Value = ""
        txtAddress1EndCustomer.Value = ""
        txtAddress2EndCustomer.Value = ""
        txtAddress3EndCustomer.Value = ""
        txtAddress4EndCustomer.Value = ""
        txtAddress5EndCustomer.Value = ""
        txtEmailEndCustomer.Value = ""
        txtContractPersonEndCustomer.Value = ""
        txtCodeCustommerGroup.Value = ""
        txtNameCustommerGroup.Value = ""
        txtIEATNo.Value = ""
        'ddlIEATPermit.Text = ""
        txtImportEntryNo.Value = ""
        'txtdatepickerImportEntryDate.Text = ""
        'ddlStatusIEAT1.Text = ""
        'ddlStatusIEAT2.Text = ""
        'ddlJobsite.Text = ""

    End Sub
    '---------------------------------------------------------------Show txt saleman when select ddl saleman---------------------------------------------
    Protected Sub dllSaleman_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim mas = (From m In db.tblMasterCode2 Where m.Code = ddlSaleman.Text.Trim Select m.Code, m.Description).SingleOrDefault
        txtsalemandis.Value = mas.Description
    End Sub
    Private Sub InsertData()
        Try
            db.tblLogImpGenLOTs.Add(New tblLogImpGenLOT With { _
                                .EASLOTNo = txtJobno.Value.Trim, _
                                .ConsigneeCode = txtConsigneecode.Value.Trim, _
                                .ShipperCode = txtShippercode.Value.Trim, _
                                .UserBy = CStr(Session("UserName")), _
                                .LastUpDate = Now
                            })
            db.SaveChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '-----------------------------------------------------------------Calculete Value in Invoice TAB------------------------------------------
    Private Sub CallculateValue()

        If (txtQuantityInvoice.Value.Trim() = "") Then txtQuantityInvoice.Value = "0.0"
        If (txtPriceForeignInvoice.Value.Trim() = "") Then txtPriceForeignInvoice.Value = "0.0"
        If (txtAmountForeignInvoice.Value.Trim() = "") Then txtAmountForeignInvoice.Value = "0.0"

        Dim ValueAmount As Double = 0.0
        ValueAmount = CSng(txtQuantityInvoice.Value) * CSng(txtPriceForeignInvoice.Value)
        txtAmountForeignInvoice.Value = ValueAmount.ToString("#,##0.00")
    End Sub
    '-----------------------------------------------------------------Calculete Value in Invoice TAB------------------------------------------
    Private Sub CallculateValueThai()

        If (txtExchangeRateInvoice.Value.Trim() = "") Then txtExchangeRateInvoice.Value = "0.0"
        If (txtPriceForeignInvoice.Value.Trim() = "") Then txtPriceForeignInvoice.Value = "0.0"
        If (txtPriceBathInvoice.Value.Trim() = "") Then txtPriceBathInvoice.Value = "0.0"

        Dim ValueThaiAmount As Double = 0.0
        ValueThaiAmount = CSng(txtExchangeRateInvoice.Value) * CSng(txtPriceForeignInvoice.Value)
        txtPriceBathInvoice.Value = ValueThaiAmount.ToString("#,##0.00")
    End Sub
    '-----------------------------------------------------------------Calculete Value in Invoice TAB------------------------------------------
    Private Sub CallculateValueThaiAmount()
        If (txtQuantityInvoice.Value.Trim() = "") Then txtQuantityInvoice.Value = "0.0"
        If (txtPriceBathInvoice.Value.Trim() = "") Then txtPriceBathInvoice.Value = "0.0"
        If (txtAmountBathInvoice.Value.Trim() = "") Then txtAmountBathInvoice.Value = "0.0"

        Dim ValueThaiValueAmount As Double = 0.0

        ValueThaiValueAmount = CSng(txtQuantityInvoice.Value) * CSng(txtPriceBathInvoice.Value)
        txtAmountBathInvoice.Value = ValueThaiValueAmount.ToString("#,##0.00")
    End Sub
    '-----------------------------------------------------------------Calculete Value in Invoice TAB------------------------------------------
    Private Sub txtPriceForeignInvoice_KeyUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPriceForeignInvoice.Init
        CallculateValue()
        CallculateValueThai()
        CallculateValueThaiAmount()
    End Sub
    Private Sub txtQuantityInvoice_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantityInvoice.Init
        'Select Case Asc(e.ToString)
        '    Case 48 To 57 ' key โค๊ด ของตัวเลขจะอยู่ระหว่าง48-57ครับ 48คือเลข0 57คือเลข9ตามลำดับ
        '        e.Equals = False
        '    Case 8, 13, 46 ' ปุ่ม Backspace = 8,ปุ่ม Enter = 13, ปุ่มDelete = 46
        '        e.Equals = False

        '    Case Else
        '        e.Handled = True
        '        MessageBox.Show("สามารถกดได้แค่ตัวเลข")
        '        Exit Sub
        'End Select
    End Sub
    '----------------------------------------------------------------Save New Invoice Data-----------------------------------------------
    Private Sub SaveImpBookingInvDetail()
        Dim DateInv As Date

        If txtdatepickerDataInvoice.Text = "" Then
            DateInv = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            DateInv = DateTime.ParseExact(txtdatepickerDataInvoice.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If

        If txtJobno.Value.Trim() = "" Then
            MsgBox("กรุณาป้อน LOT No ก่อน !!!")
            txtJobno.Focus()
            Exit Sub
        End If

        If txtInvoiceNo.Value.Trim() = "" Then
            MsgBox("กรุณาป้อน Invoice No ก่อน !!!")
            txtInvoiceNo.Focus()
            Exit Sub
        End If

        If txtProductCodeInvoice.Value.Trim() = "" Then
            MsgBox("กรุณาป้อน Product No ก่อน !!!")
            txtProductCodeInvoice.Focus()
            Exit Sub
        End If

        If MsgBox("คุณต้องการเพิ่มรายการ LOT No Invoice ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Using tran As New TransactionScope()

                Try
                    'sb = New StringBuilder()
                    'sb.Append("INSERT INTO tblImpBookingInvDetail (InvoiceNo,LOTNo,DateInv,ProductCode,ProductName,Quantity,QuantityUnit,RemarkInv,PO,Pallet,UnitPallet,Weight,UnitWeight,Pallet1,UnitPallet1,UnitDimension,AmountPallet,Width,Height,Lenght,ExchangeRate,PriceForeigh,PriceForeighAmount,PriceBath,PriceBathAmount,UserBy,LastUpdate,Shipment,ItemNo,OwnerPN,CustomerPN,Prodes,EntryItemNo)")
                    'sb.Append(" VALUES (@InvoiceNo,@LOTNo,@DateInv,@ProductCode,@ProductName,@Quantity,@QuantityUnit,@RemarkInv,@PO,@Pallet,@UnitPallet,@Weight,@UnitWeight,@Pallet1,@UnitPallet1,@UnitDimension,@AmountPallet,@Width,@Height,@Lenght,@ExchangeRate,@PriceForeigh,@PriceForeighAmount,@PriceBath,@PriceBathAmount,@UserBy,@LastUpdate,@Shipment,@ItemNo,@OwnerPN,@CustomerPN,@Prodes,@EntryItemNo )")
                    db.Database.Connection.Open()

                    db.tblImpBookingInvDetails.Add(New tblImpBookingInvDetail With { _
                    .InvoiceNo = txtInvoiceNo.Value.Trim, _
                    .LOTNo = txtJobno.Value.Trim, _
                    .DateInv = DateInv, _
                    .ProductCode = txtProductCodeInvoice.Value.Trim, _
                    .ProductName = txtProductNameInvoice.Value.Trim, _
                    .Quantity = CType(txtQuantityInvoice.Value.Trim, Double?), _
                    .QuantityUnit = ddlQuantityInvoice.Text.Trim, _
                    .RemarkInv = txtRemarkInvoice.Value.Trim, _
                    .PO = txtPONoProductCode.Value.Trim, _
                    .Pallet = CType(txtPallet_SKIDInvoice.Value.Trim, Double?), _
                    .UnitPallet = ddlPallet_SKIDInvoice.Text.Trim, _
                    .Weight = CType(txtWeightInvoice.Value.Trim, Double?), _
                    .UnitWeight = ddlWeightInvoice.Text.Trim, _
                    .Pallet1 = CType(txtBoxInvoice.Value.Trim, Double?), _
                    .UnitPallet1 = ddlBoxInvoice.Text.Trim, _
                    .UnitDimension = ddlUnitDimension.Text.Trim, _
                    .AmountPallet = CType(txtPalletDimensionInvoice.Value.Trim, Double?), _
                    .Width = CType(txtWidthInvoice.Value.Trim, Double?), _
                    .Height = CType(txtHeightInvoice.Value.Trim, Double?), _
                    .Lenght = CType(txtLenghtInvoice.Value.Trim, Double?), _
                    .EntryItemNo = CType(txtEntryItemNoInvoice.Value.Trim, Integer?), _
                    .Currency = ddlCurrencyInvoice.Text.Trim, _
                    .ExchangeRate = CType(txtExchangeRateInvoice.Value.Trim, Double?), _
                    .PriceForeigh = CType(txtPriceForeignInvoice.Value.Trim, Double?), _
                    .PriceForeighAmount = CType(txtAmountForeignInvoice.Value.Trim, Double?), _
                    .PriceBath = CType(txtPriceBathInvoice.Value.Trim, Double?), _
                    .PriceBathAmount = CType(txtAmountBathInvoice.Value.Trim, Double?), _
                    .UserBy = CStr(Session("UserId")), _
                    .LastUpdate = Now, _
                    .Shipment = txtShipmentInvoice.Value.Trim, _
                    .ItemNo = CDec(txtItemNoInvoice.Value.Trim), _
                    .OwnerPN = cuspart, _
                    .CustomerPN = endpart, _
                    .Prodes = Prodes
                    })
                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Add สำเร็จ !');", True)

                Catch ex As Exception

                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)

                Finally
                    db.Database.Connection.Close()
                    db.Dispose()
                    tran.Dispose()
                End Try
            End Using
        End If
        txtJobno.Focus()
    End Sub
    '----------------------------------------------------------------Save Invoice Data Modify-----------------------------------------------
    Private Sub SaveImpBookingInvDetail_Modify()

        If txtJobno.Value.Trim() = "" Then
            MsgBox("กรุณาป้อน LOT No ก่อน !!!")
            txtJobno.Focus()
            Exit Sub
        End If

        If txtInvoiceNo.Value.Trim() = "" Then
            MsgBox("กรุณาป้อน Invoice No ก่อน !!!")
            txtInvoiceNo.Focus()
            Exit Sub
        End If

        If txtProductCodeInvoice.Value.Trim() = "" Then
            MsgBox("กรุณาป้อน Product No ก่อน !!!")
            txtProductCodeInvoice.Focus()
            Exit Sub
        End If

        If MsgBox("คุณต้องการแก้ไขรายการ Invoice No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    'sb = New StringBuilder()
                    'sb.Append("UPDATE tblImpGenLOT")
                    'sb.Append(" SET EASLOTNo=@EASLOTNo,LOTDate=@LOTDate,LOTBy=@LOTBy,SalesCode=@SalesCode,SalesName=@SalesName,ConsigneeCode=@ConsigneeCode,ConsignNameEng=@ConsignNameEng,ConsignAddress=@ConsignAddress,ConsignDistrict=@ConsignDistrict,ConsignSubProvince=@ConsignSubProvince,ConsignProvince=@ConsignProvince,ConsignPostCode=@ConsignPostCode,ConsignEmail=@ConsignEmail,ShipperCode=@ShipperCode,ShipperNameEng=@ShipperNameEng,ShipperAddress=@ShipperAddress,ShipperDistrict=@ShipperDistrict,ShipperSubprovince=@ShipperSubprovince,ShipperProvince=@ShipperProvince,ShipperPostCode=@ShipperPostCode,ShipperReturnCode=@ShipperReturnCode,Commodity=@Commodity,QuantityofPart=@QuantityofPart,QuantityUnit=@QuantityUnit,QuantityPack=@QuantityPack,QuantityUnitPack=@QuantityUnitPack,Weight=@Weight,WeightUnit=@WeightUnit,Volume=@Volume,VolumeUnit=@VolumeUnit,MAWB=@MAWB,DocType=@DocType,DocCode=@DocCode,Flight=@Flight,DOCode=@DOCode,DONameENG=@DONameENG,DOStreet_Number=@DOStreet_Number,DODistrict=@DODistrict,DOSubProvince=@DOSubProvince,DOProvince=@DOProvince,DOPostCode=@DOPostCode,DOEmail=@DOEmail,DOContactPerson=@DOContactPerson,IEATNo=@IEATNo,EntryNo=@EntryNo,DeliveryDate=@DeliveryDate,CustomerCode=@CustomerCode,CustomerENG=@CustomerENG,CustomerStreet=@CustomerStreet,CustomerDistrict=@CustomerDistrict,CustomerSub=@CustomerSub,CustomerProvince=@CustomerProvince,CustomerPostCode=@CustomerPostCode,CustomerEmail=@CustomerEmail,CustomerContact=@CustomerContact,PickUpCode=@PickUpCode,PickUpENG=@PickUpENG,PickUpAddress1=@PickUpAddress1,PickUpAddress2=@PickUpAddress2,PickUpAddress3=@PickUpAddress3,PickUpAddress4=@PickUpAddress4,PickUpAddress5=@PickUpAddress5,PickUpEmail=@PickUpEmail,PickUpContact=@PickUpContact,EndCusCode=@EndCusCode,EndCusENG=@EndCusENG,EndCusAddress1=@EndCusAddress1,EndCusAddress2=@EndCusAddress2,EndCusAddress3=@EndCusAddress3,EndCusAddress4=@EndCusAddress4,EndCusAddress5=@EndCusAddress5,EndCusEmail=@EndCusEmail,EndCusContact=@EndCusContact,FreighForwarder=@FreighForwarder,Useby=@Useby,IEATPermit=@IEATPermit,ShipTo=@ShipTo,Remark=@Remark,FLT1=@FLT1,FLT2=@FLT2,FLT3=@FLT3,FLT4=@FLT4,DateFLT1=@DateFLT1,DateFLT2=@DateFLT2,DateFLT3=@DateFLT3,DateFLT4=@DateFLT4,ORGN1=@ORGN1,ORGN2=@ORGN2,ORGN3=@ORGN3,ORGN4=@ORGN4,DSTN1=@DSTN1,DSTN2=@DSTN2,DSTN3=@DSTN3,DSTN4=@DSTN4,ETD1=@ETD1,ETD2=@ETD2,ETD3=@ETD3,ETD4=@ETD4,ETA1=@ETA1,ETA2=@ETA2,ETA3=@ETA3,ETA4=@ETA4,PCS1=@PCS1,PCS2=@PCS2,PCS3=@PCS3,PCS4=@PCS4,Weight1=@Weight1,Weight2=@Weight2,Weight3=@Weight3,Weight4=@Weight4,QuantityPack1=@QuantityPack1,QuantityUnitPack1=@QuantityUnitPack1,TimeDTE=@TimeDTE,DateDTE=@DateDTE,TimeATT=@TimeATT,DateATT=@DateATT,Status1=@Status1,Status2=@Status2,JobSite=@JobSite,BillingNo=@BillingNo,CustomerCodeGroup=@CustomerCodeGroup,CustomerENGGroup=@CustomerENGGroup")
                    'sb.Append(" WHERE (EASLOTNo=@EASLOTNo)")
                    Dim edit As tblImpBookingInvDetail = (From c In db.tblImpBookingInvDetails Join z In db.tblImpGenLOTs On z.EASLOTNo Equals c.LOTNo
                      Select c).First()
                    If edit IsNot Nothing Then
                        'edit.InvoiceNo = txtInvoiceNo.Value.Trim
                        'edit.LOTNo = txtJobno.Value.Trim
                        edit.DateInv = CType(txtdatepickerDataInvoice.Text.Trim, Date?)
                        'edit.ProductCode = txtProductCodeInvoice.Value.Trim
                        edit.ProductName = txtProductNameInvoice.Value.Trim
                        edit.Quantity = CType(txtQuantityInvoice.Value.Trim, Double?)
                        edit.QuantityUnit = ddlQuantityInvoice.Text.Trim
                        edit.RemarkInv = txtRemarkInvoice.Value.Trim
                        edit.PO = txtPONoProductCode.Value.Trim
                        edit.Pallet = CType(txtPallet_SKIDInvoice.Value.Trim, Double?)
                        edit.UnitPallet = ddlPallet_SKIDInvoice.Text.Trim
                        edit.Weight = CType(txtWeightInvoice.Value.Trim, Double?)
                        edit.UnitWeight = ddlWeightInvoice.Text.Trim
                        edit.Pallet1 = CType(txtBoxInvoice.Value.Trim, Double?)
                        edit.UnitPallet1 = ddlBoxInvoice.Text.Trim
                        edit.UnitDimension = ddlUnitDimension.Text.Trim
                        edit.AmountPallet = CType(txtPalletDimensionInvoice.Value.Trim, Double?)
                        edit.Width = CType(txtWidthInvoice.Value.Trim, Double?)
                        edit.Height = CType(txtHeightInvoice.Value.Trim, Double?)
                        edit.Lenght = CType(txtLenghtInvoice.Value.Trim, Double?)
                        edit.EntryItemNo = CType(txtEntryItemNoInvoice.Value.Trim, Integer?)
                        edit.Currency = ddlCurrencyInvoice.Text.Trim
                        edit.ExchangeRate = CType(txtExchangeRateInvoice.Value.Trim, Double?)
                        edit.PriceForeigh = CType(txtPriceForeignInvoice.Value.Trim, Double?)
                        edit.PriceForeighAmount = CType(txtAmountForeignInvoice.Value.Trim, Double?)
                        edit.PriceBath = CType(txtPriceBathInvoice.Value.Trim, Double?)
                        edit.PriceBathAmount = CType(txtAmountBathInvoice.Value.Trim, Double?)
                        edit.UserBy = CStr(Session("UserId"))
                        edit.LastUpdate = Now
                        edit.Shipment = txtShipmentInvoice.Value.Trim
                        'edit.ItemNo = CDec(txtItemNoInvoice.Value.Trim)
                        edit.OwnerPN = cuspart
                        edit.CustomerPN = endpart
                        edit.Prodes = Prodes
                        edit.UserBy = CStr(Session("UserId"))

                        db.SaveChanges()
                        tran.Complete()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                    End If
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        txtJobno.Focus()
    End Sub 'saveModifyเข้าที่tblImpBookingInvDetail
    '----------------------------------------------------------------Click btn Save Inv------------------------------------------
    Protected Sub btnSaveInvoice_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveImpBookingInvDetail()
            ReadDATA2()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '----------------------------------------------------------------Click btn Modify Inv------------------------------------------
    Protected Sub btnModifyInvoice_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveImpBookingInvDetail_Modify()
            ReadDATA2()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '----------------------------------------------------------------Click btn Delete Inv------------------------------------------
    Protected Sub btnDeleteInvoice_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            ReadDATA2()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '----------------------------------------------------------------Click btn DeleteAll Inv------------------------------------------
    Protected Sub btnDeleteAllInvoice_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            ReadDATA2()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '-----------------------------------------------------------------Show Repeater in Invoice TAB------------------------------------------
    Private Sub ReadDATA2()
        Dim sqlConsignnee = From ab In db.tblImpBookingInvDetails Where ab.LOTNo = txtJobno.Value.Trim Order By ab.ItemNo
        Select ab.InvoiceNo,
                 ab.LOTNo,
                 ab.DateInv,
                 ab.ProductCode,
                 ab.ProductName,
                 ab.Quantity,
                 ab.QuantityUnit
        Try
            If sqlConsignnee.Count > 0 Then
                Repea2_Invoice.DataSource = sqlConsignnee.ToList
                Repea2_Invoice.DataBind()
                'ScriptManager.RegisterStartupScript(Repea2UpdatePanel.GetType(), Repea2Panel.ClientID, True)
                Repea2UpdatePanel.Update()
            Else
                Repea2_Invoice.DataSource = Nothing
                Repea2_Invoice.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub Repea2_Invoice_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repea2_Invoice.ItemCommand
        Dim InvoiceNo As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectInvoiceNo") Then

                If String.IsNullOrEmpty(InvoiceNo) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblImpBookingInvDetails Where u.InvoiceNo = InvoiceNo).SingleOrDefault

                    txtInvoiceNo.Value = user.InvoiceNo
                    txtProductCodeInvoice.Value = user.ProductCode
                    txtPONoProductCode.Value = user.PO
                    txtdatepickerDataInvoice.Text = CStr(user.DateInv)
                    txtProductNameInvoice.Value = user.ProductName
                    txtQuantityInvoice.Value = CStr(user.Quantity)
                    ddlQuantityInvoice.Text = user.QuantityUnit
                    txtWeightInvoice.Value = CStr(user.Weight)
                    ddlWeightInvoice.Text = user.UnitWeight
                    txtPallet_SKIDInvoice.Value = CStr(user.Pallet)
                    ddlPallet_SKIDInvoice.Text = user.UnitPallet
                    txtBoxInvoice.Value = CStr(user.Pallet1)
                    ddlBoxInvoice.Text = user.UnitPallet1
                    txtRemarkInvoice.Value = user.RemarkInv
                    txtShipmentInvoice.Value = user.Shipment
                    txtItemNoInvoice.Value = CStr(user.ItemNo)
                    ddlUnitDimension.Text = user.UnitDimension
                    txtPalletDimensionInvoice.Value = CStr(user.AmountPallet)
                    txtWidthInvoice.Value = CStr(user.Width)
                    txtHeightInvoice.Value = CStr(user.Height)
                    txtLenghtInvoice.Value = CStr(user.Lenght)
                    txtEntryItemNoInvoice.Value = CStr(user.EntryItemNo)
                    ddlCurrencyInvoice.Text = user.Currency
                    txtExchangeRateInvoice.Value = CStr(user.ExchangeRate)
                    txtPriceForeignInvoice.Value = CStr(user.PriceForeigh)
                    txtAmountForeignInvoice.Value = CStr(user.PriceForeighAmount)
                    txtPriceBathInvoice.Value = CStr(user.PriceBath)
                    txtAmountBathInvoice.Value = CStr(user.PriceBathAmount)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '---------------------------------------------------------------------Click btn SaveFlight--------------------------------------------
    Protected Sub btnSaveFlightNoInvoice_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveFlightInvDetail()
            DataFlight()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '---------------------------------------------------------------------Click btn DeleteFlight--------------------------------------------
    Protected Sub btnDeleteFlightNoInvoice_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Delete_ = 1
        If cu.Any Then
            DeleteFlightInvDetail()
            DataFlight()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If

    End Sub
    '----------------------------------------------------------------Save New Flight Data-----------------------------------------------
    Private Sub SaveFlightInvDetail()
        Dim FlightDate As Date

        If txtdatepickerDataInvoice.Text = "" Then
            FlightDate = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            FlightDate = DateTime.ParseExact(txtdatepickerFlightDateInvoice.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If

        If txtJobno.Value.Trim() = "" Then
            MsgBox("กรุณาป้อน LOT No ก่อน !!!")
            txtJobno.Focus()
            Exit Sub
        End If

        If txtFlightNo.Value.Trim() = "" Then
            MsgBox("กรุณาป้อน Flight No ก่อน !!!")
            txtFlightNo.Focus()
            Exit Sub
        End If

        If MsgBox("คุณต้องการเพิ่มรายการ Flight No Invoice ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Using tran As New TransactionScope()

                Try
                    db.Database.Connection.Open()

                    db.tblImpLogFlights.Add(New tblImpLogFlight With { _
                    .LotNo = txtJobno.Value.Trim, _
                    .FlightNo = txtFlightNo.Value.Trim, _
                    .DateFlight = FlightDate, _
                    .House = ddlQuantity_PLT_Skid_Invoice2.Text.Trim, _
                    .HouseNo = txtQuantity_PLT_Skid_Invoice2.Value.Trim, _
                    .Quantity = CType(txtQuantity_PLT_Skid_Invoice.Value.Trim, Double?), _
                    .UnitQuantity = ddlQuantity_PLT_Skid_Invoice.Text.Trim, _
                    .Userby = CStr(Session("UserId"))
                    })
                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Add สำเร็จ !');", True)

                Catch ex As Exception
                    tran.Dispose()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        txtJobno.Focus()
    End Sub
    '----------------------------------------------------------------Delete Flight Data-----------------------------------------------
    Private Sub DeleteFlightInvDetail()
        If txtJobno.Value.Trim() = "" Then
            MsgBox("เลือกข้อมูลที่ต้องการ Delete ก่อน !!!")
            txtJobno.Focus()
            Exit Sub
        End If

        If txtFlightNo.Value.Trim() = "" Then
            MsgBox("เลือกข้อมูลที่ต้องการ Delete ก่อน !!!")
            txtFlightNo.Focus()
            Exit Sub
        End If

        If MsgBox("คุณต้องการลบรายการ Flight No Invoice นี้ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Using tran As New TransactionScope()
                Try

                    Dim DeleteFlight As tblImpLogFlight = (From c In db.tblImpLogFlights Where c.LotNo = txtJobno.Value.Trim And c.FlightNo = txtFlightNo.Value.Trim _
                    And c.Number = NumberFlight Select c).First()

                    db.tblImpLogFlights.Remove(DeleteFlight)

                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete Flight สำเร็จ !');", True)
                Catch ex As Exception
                    tran.Dispose()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
    End Sub
    '--------------------------------------------------------Show Data Flight In Modal-----------------------------------------
    Private Sub DataFlight()

        Dim cons = (From p In db.tblImpLogFlights
                    Where p.LotNo = txtJobno.Value.Trim Order By p.Number Ascending
                   Select New With {p.LotNo,
                                    p.Number,
                                    p.FlightNo,
                                    p.DateFlight}).ToList()

        If cons.Count > 0 Then
            Repeater10.DataSource = cons.ToList
            Repeater10.DataBind()
        Else
            Repeater10.DataSource = Nothing
            Repeater10.DataBind()
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------Click Data Data Flight -----------------------------------------
    Protected Sub Repeater10_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater10.ItemCommand
        Dim Numberr As Double = CDbl(e.CommandArgument)
        Try
            If e.CommandName.Equals("Selectdataflight") Then

                If String.IsNullOrEmpty(CStr(Numberr)) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblImpLogFlights Where u.LotNo = txtJobno.Value.Trim And u.Number = Numberr).SingleOrDefault

                    txtFlightNo.Value = user.FlightNo
                    NumberFlight = user.Number
                    txtdatepickerFlightDateInvoice.Text = CStr(user.DateFlight)
                    txtQuantity_PLT_Skid_Invoice.Value = CStr(user.Quantity)
                    txtQuantity_PLT_Skid_Invoice2.Value = user.HouseNo
                    If String.IsNullOrEmpty(user.UnitQuantity) Then
                        'ddlQuantity_PLT_Skid_Invoice.Text = ""
                    Else
                        ddlQuantity_PLT_Skid_Invoice.Text = user.UnitQuantity
                    End If
                    If String.IsNullOrEmpty(user.House) Then
                        'ddlQuantity_PLT_Skid_Invoice2.Text = ""
                    Else
                        ddlQuantity_PLT_Skid_Invoice2.Text = user.House
                    End If

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSumQTYInvoice_ServerClick(sender As Object, e As EventArgs)
        Dim lblInvoiceNo As String
        Dim lblLotNo As String
        Dim i As Integer = 0
        Dim qty As Integer = 0

        If Repea2_Invoice.Items.Count > 0 Then

            For i = 0 To Repea2_Invoice.Items.Count - 1

                lblInvoiceNo = CType(Repea2_Invoice.Items(i).FindControl("lblInvoiceNo"), Label).Text.Trim
                lblLotNo = CType(Repea2_Invoice.Items(i).FindControl("lblLOTNo"), Label).Text.Trim

                Dim u = (From us In db.tblImpBookingInvDetails Where us.LOTNo = lblLotNo And us.InvoiceNo = lblInvoiceNo).FirstOrDefault

                qty = CInt(qty + u.Quantity.Value)

            Next
            txtQTYExportInvoice.Value = CStr(qty)
        Else
            txtQTYExportInvoice.Value = "0"
        End If
    End Sub

    Protected Sub btnSaveToPrepairInvoice_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            If txtImportEntryNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณากรอกใบขนในช่อง ImportEntryNo ใน Tab ก่อนหน้า');", True)
                Exit Sub
            End If

            If txtImportEntryNo.Value.Length <> 14 Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณากรอกใบขนให้ครบ 14 หลัก');", True)
                Exit Sub
            End If

            SaveToPrepair()

        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    Private Sub SaveToPrepair()
        Dim lblInvoiceNo As String
        Dim lblLotNo As String
        Dim i As Integer

        If Repea2_Invoice.Items.Count > 0 Then

            Using tran As New TransactionScope()


                For i = 0 To Repea2_Invoice.Items.Count - 1

                    lblInvoiceNo = CType(Repea2_Invoice.Items(i).FindControl("lblInvoiceNo"), Label).Text.Trim
                    lblLotNo = CType(Repea2_Invoice.Items(i).FindControl("lblLOTNo"), Label).Text.Trim

                    Dim u = (From us In db.tblImpBookingInvDetails Where us.LOTNo = lblLotNo And us.InvoiceNo = lblInvoiceNo).FirstOrDefault

                    'sb.Append("INSERT INTO tblWHPrepairGoodsReceiveDetail (LOTNo,WHSite,WHLocation,ENDCustomer,WHSource,CustomerLOTNo,ItemNo,ProductCode,CustomerPN,OwnerPN,ProductDesc,Measurement,ProductWidth,ProductLength,ProductHeight,ProductVolume,OrderNo,ReceiveNo,Type,ManufacturingDate,ExpiredDate,ReceiveDate,Quantity,QuantityUnit,Weigth,WeigthUnit,Currency,ExchangeRate,PriceForeigh,PriceForeighAmount,PriceBath,PriceBathAmount,PalletNo,UserBy,LastUpdate,Status,Supplier,Buyer,Exporter,Destination,Consignee,ShippingMark,EntryNo,EntryItemNo)")
                    'sb.Append(" VALUES (@LOTNo,@WHSite,@WHLocation,@ENDCustomer,@WHSource,@CustomerLOTNo,@ItemNo,@ProductCode,@CustomerPN,@OwnerPN,@ProductDesc,@Measurement,@ProductWidth,@ProductLength,@ProductHeight,@ProductVolume,@OrderNo,@ReceiveNo,@Type,@ManufacturingDate,@ExpiredDate,@ReceiveDate,@Quantity,@QuantityUnit,@Weigth,@WeigthUnit,@Currency,@ExchangeRate,@PriceForeigh,@PriceForeighAmount,@PriceBath,@PriceBathAmount,@PalletNo,@UserBy,@LastUpdate,@Status,@Supplier,@Buyer,@Exporter,@Destination,@Consignee,@ShippingMark,@EntryNo,@EntryItemNo)")
                    Try
                        db.Database.Connection.Open()
                        db.tblWHPrepairGoodsReceiveDetails.Add(New tblWHPrepairGoodsReceiveDetail With { _
                                .LOTNo = txtJobno.Value.Trim, _
                                .WHSite = "LKB", _
                                .WHLocation = "", _
                                .ENDCustomer = "MJ001", _
                                .WHSource = "", _
                                .CustomerLOTNo = u.Shipment, _
                                .ItemNo = i + 1, _
                                .ProductCode = u.ProductCode, _
                                .CustomerPN = u.CustomerPN, _
                                .OwnerPN = u.OwnerPN, _
                                .ProductDesc = u.ProductName, _
                                .Measurement = "", _
                                .ProductWidth = u.Width, _
                                .ProductLength = u.Lenght, _
                                .ProductHeight = u.Height, _
                                .ProductVolume = 0, _
                                .OrderNo = u.PO, _
                                .ReceiveNo = txtJobno.Value.Trim, _
                                .Type = "Goods Complete", _
                                .ManufacturingDate = Nothing, _
                                .ExpiredDate = Nothing, _
                                .ReceiveDate = Now, _
                                .Quantity = u.Quantity, _
                                .QuantityUnit = u.QuantityUnit, _
                                .Weigth = u.Weight, _
                                .WeigthUnit = u.UnitWeight, _
                                .Currency = u.Currency, _
                                .ExchangeRate = u.ExchangeRate, _
                                .PriceForeigh = u.PriceForeigh, _
                                .PriceForeighAmount = u.PriceForeighAmount, _
                                .PriceBath = u.PriceBath, _
                                .PriceBathAmount = u.PriceBathAmount, _
                                .PalletNo = "", _
                                .UserBy = CStr(Session("UserName")), _
                                .LastUpdate = Now, _
                                .Status = 0, _
                                .Supplier = "", _
                                .Buyer = "", _
                                .Exporter = "", _
                                .Destination = "", _
                                .Consignee = "", _
                                .ShippingMark = "", _
                                .EntryNo = txtImportEntryNo.Value.Trim, _
                                .EntryItemNo = u.EntryItemNo
                            })
                        db.SaveChanges()
                    Catch ex As Exception
                        tran.Dispose()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดในการ Save To PrePair');", True)
                    End Try

                Next
                tran.Complete()
            End Using
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('ไม่มีข้อมูล');", True)
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Sent To Prepair เรียบร้อยแล้วครับ');", True)
    End Sub
End Class