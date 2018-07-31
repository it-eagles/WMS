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
        showListConsignee()
        showListShipper()
        showListDelivery()
        showListPickUp()
        showListCustomer()
        showListEndCustomer()
        showListCustomerGroup()
        showListProductCode()
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
    '--------------------------------------------------------Show Data Consignee In Modal-----------------------------------------
    Public Sub showListConsignee()

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                   Select New With {u.PartyCode,
                                    u.PartyFullName,
                                    br.Address1,
                                    br.Address2,
                                    br.Address3}).ToList()


        If user.Count > 0 Then
            Repeater1.DataSource = user
            Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If
    End Sub
    '--------------------------------------------------------Click Data Consignee In Modal-----------------------------------------
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectConsignee") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
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
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data Shipper In Modal-----------------------------------------
    Public Sub showListShipper()

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                   Select New With {u.PartyCode,
                                    u.PartyFullName,
                                    br.Address1,
                                    br.Address2,
                                    br.Address3}).ToList()


        If user.Count > 0 Then
            Repeater2.DataSource = user
            Repeater2.DataBind()
        Else
            Me.Repeater2.DataSource = Nothing
            Me.Repeater2.DataBind()
        End If
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

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                   Select New With {u.PartyCode,
                                    u.PartyFullName,
                                    br.Address1,
                                    br.Address2,
                                    br.Address3}).ToList()


        If user.Count > 0 Then
            Repeater3.DataSource = user
            Repeater3.DataBind()
        Else
            Me.Repeater3.DataSource = Nothing
            Me.Repeater3.DataBind()
        End If
    End Sub
    '--------------------------------------------------------Click Data Shipper In Modal-----------------------------------------
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

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                   Select New With {u.PartyCode,
                                    u.PartyFullName,
                                    br.Address1,
                                    br.Address2,
                                    br.Address3}).ToList()


        If user.Count > 0 Then
            Repeater4.DataSource = user
            Repeater4.DataBind()
        Else
            Me.Repeater4.DataSource = Nothing
            Me.Repeater4.DataBind()
        End If
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

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                   Select New With {u.PartyCode,
                                    u.PartyFullName,
                                    br.Address1,
                                    br.Address2,
                                    br.Address3}).ToList()


        If user.Count > 0 Then
            Repeater5.DataSource = user
            Repeater5.DataBind()
        Else
            Me.Repeater5.DataSource = Nothing
            Me.Repeater5.DataBind()
        End If
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

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                   Select New With {u.PartyCode,
                                    u.PartyFullName,
                                    br.Address1,
                                    br.Address2,
                                    br.Address3}).ToList()


        If user.Count > 0 Then
            Repeater6.DataSource = user
            Repeater6.DataBind()
        Else
            Me.Repeater6.DataSource = Nothing
            Me.Repeater6.DataBind()
        End If
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

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                   Select New With {u.PartyCode,
                                    u.PartyFullName}).ToList()


        If user.Count > 0 Then
            Repeater7.DataSource = user
            Repeater7.DataBind()
        Else
            Me.Repeater7.DataSource = Nothing
            Me.Repeater7.DataBind()
        End If
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
    '--------------------------------------------------------Click Data ProductCode In Modal-----------------------------------------
    Protected Sub Repeater8_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater8.ItemCommand
        'Dim ProductCode As String = CStr(e.CommandArgument)
        'Try
        '    If e.CommandName.Equals("SelectProductCode") Then

        '        If String.IsNullOrEmpty(ProductCode) Then

        '            MsgBox("เป็นค่าว่าง")
        '        Else
        '            Dim user = (From u In db.tblProductDetails Where u.ProductCode = ProductCode).SingleOrDefault

        '            txtProductCodeInvoice.Value = user.ProductCode
        '            txtProductNameInvoice.Value = user.ImpDesc1
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
End Class