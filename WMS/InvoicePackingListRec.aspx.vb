Imports System.Transactions

Public Class InvoicePackingListRec
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1_Test
    Dim DiffBy As String
    Dim TermTransport As String
    Dim OnbehalfStatus As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        showCountry()
        showpaymenterm()
        showincoterm()
        showcurrency()
        showtrucklicense()
        showtruckdriver()
        showshipmode()
        showdeliveryterm()
        showshipmark()

        Head_fieldset.Disabled = True
        invoiceheader_fieldset.Disabled = True
        easjob_fieldset.Disabled = True
        itemdetail_fieldset.Disabled = True
        packinglist_fieldset.Disabled = True

        'showListShipper()
        'showListConsignee()
        'showListCustomerCode()
        'showListCustomerCode_BillTo()
    End Sub

    Protected Sub NetWeight_PACKINGLIST_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '------------------------------------------------------------Click btn Add New Item PACKINGLIST TAB----------------------------------
    Protected Sub btnAddNewItem_PACKINGLIST_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpCustomsInvoice"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveDATANew_Packing()
            InsertDataPackingList()
            Clear_PackingDATA()

        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '------------------------------------------------------------Click btn Save Modify Item PACKINGLIST TAB----------------------------------
    Protected Sub btnSaveModify_PACKINGLIST_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpCustomsInvoice"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then


        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '------------------------------------------------------------Click btn Delete Item PACKINGLIST TAB----------------------------------
    Protected Sub btnDelete_PACKINGLIST_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '------------------------------------------------------------Click btn Add New Item ITEMDETAIL TAB----------------------------------
    Protected Sub btnAddNewItem_ItemDetail_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpCustomsInvoice"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveDATANew_Detail()
            InsertDataDetail()
            Clear_ItemDATA()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '------------------------------------------------------------Click btn Save Modify Item ITEMDETAIL TAB----------------------------------
    Protected Sub btnSaveModify_ItemDetail_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpCustomsInvoice"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then


        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '------------------------------------------------------------Click btn Delete Item ITEMDETAIL TAB----------------------------------
    Protected Sub btnDelete_ItemDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnCreatePacking_ItemDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnGen_BeforeTab_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '---------------------------------------------Show All dll Country--------------------------------------------
    Private Sub showCountry()
        'ddlOriginCountry_Invoice.Items.Clear()
        'ddlOriginCountry_Invoice.Items.Add(New ListItem("--Select Country--", ""))
        'ddlOriginCountry_Invoice.AppendDataBoundItems = True

        'ddlPurchaseCountry_Invoice.Items.Clear()
        'ddlPurchaseCountry_Invoice.Items.Add(New ListItem("--Select Country--", ""))
        'ddlPurchaseCountry_Invoice.AppendDataBoundItems = True

        'ddlDestinationCountry_Invoice.Items.Clear()
        'ddlDestinationCountry_Invoice.Items.Add(New ListItem("--Select Country--", ""))
        'ddlDestinationCountry_Invoice.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "Country"
                  Select g.Type, g.Code
        Try
            ddlOriginCountry_Invoice.DataSource = gg.ToList
            ddlOriginCountry_Invoice.DataTextField = "Code"
            ddlOriginCountry_Invoice.DataValueField = "Code"
            ddlOriginCountry_Invoice.DataBind()

            ddlPurchaseCountry_Invoice.DataSource = gg.ToList
            ddlPurchaseCountry_Invoice.DataTextField = "Code"
            ddlPurchaseCountry_Invoice.DataValueField = "Code"
            ddlPurchaseCountry_Invoice.DataBind()

            ddlDestinationCountry_Invoice.DataSource = gg.ToList
            ddlDestinationCountry_Invoice.DataTextField = "Code"
            ddlDestinationCountry_Invoice.DataValueField = "Code"
            ddlDestinationCountry_Invoice.DataBind()

            If ddlOriginCountry_Invoice.Items.Count > 1 Then
                ddlOriginCountry_Invoice.Enabled = True
            Else
                ddlOriginCountry_Invoice.Enabled = False
            End If

            If ddlPurchaseCountry_Invoice.Items.Count > 1 Then
                ddlPurchaseCountry_Invoice.Enabled = True
            Else
                ddlPurchaseCountry_Invoice.Enabled = False
            End If

            If ddlDestinationCountry_Invoice.Items.Count > 1 Then
                ddlDestinationCountry_Invoice.Enabled = True
            Else
                ddlDestinationCountry_Invoice.Enabled = False
            End If


        Catch ex As Exception

        End Try
    End Sub
    '------------------------------------------------------Show ddl PAYMENTTERM--------------------------------------------------
    Private Sub showpaymenterm()
        'ddlTermOfPayment_Invoice.Items.Clear()
        'ddlTermOfPayment_Invoice.Items.Add(New ListItem("--Select Payment--", ""))
        'ddlTermOfPayment_Invoice.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "PAYMENTTERM"
                  Select g.Type, g.Code
        Try
            ddlTermOfPayment_Invoice.DataSource = gg.ToList
            ddlTermOfPayment_Invoice.DataTextField = "Code"
            ddlTermOfPayment_Invoice.DataValueField = "Code"
            ddlTermOfPayment_Invoice.DataBind()

            If ddlTermOfPayment_Invoice.Items.Count > 1 Then
                ddlTermOfPayment_Invoice.Enabled = True
            Else
                ddlTermOfPayment_Invoice.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    '-----------------------------------------------------Show ddl INCOTERM------------------------------------------
    Private Sub showincoterm()
        'ddlTerm_Invoice.Items.Clear()
        'ddlTerm_Invoice.Items.Add(New ListItem("--Select Payment--", ""))
        'ddlTerm_Invoice.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "INCOTERM"
                  Select g.Type, g.Code
        Try
            ddlTerm_Invoice.DataSource = gg.ToList
            ddlTerm_Invoice.DataTextField = "Code"
            ddlTerm_Invoice.DataValueField = "Code"
            ddlTerm_Invoice.DataBind()

            If ddlTerm_Invoice.Items.Count > 1 Then
                ddlTerm_Invoice.Enabled = True
            Else
                ddlTerm_Invoice.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    '-------------------------------------------------------Show ddl Currency--------------------------------------------------
    Private Sub showcurrency()
        'ddlTotalInvoice_Invoice.Items.Clear()
        'ddlTotalInvoice_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        'ddlTotalInvoice_Invoice.AppendDataBoundItems = True

        'ddlForwarding_Invoice.Items.Clear()
        'ddlForwarding_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        'ddlForwarding_Invoice.AppendDataBoundItems = True

        'ddlFreight_Invoice.Items.Clear()
        'ddlFreight_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        'ddlFreight_Invoice.AppendDataBoundItems = True

        'ddlInsurance_Invoice.Items.Clear()
        'ddlInsurance_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        'ddlInsurance_Invoice.AppendDataBoundItems = True

        'ddlPackingCharge_Invoice.Items.Clear()
        'ddlPackingCharge_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        'ddlPackingCharge_Invoice.AppendDataBoundItems = True

        'ddlHandingCharge_Invoice.Items.Clear()
        'ddlHandingCharge_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        'ddlHandingCharge_Invoice.AppendDataBoundItems = True

        'ddlLandingCharge_Invoice.Items.Clear()
        'ddlLandingCharge_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        'ddlLandingCharge_Invoice.AppendDataBoundItems = True

        'ddlTotalInvoiceTHB_Invoice.Items.Clear()
        'ddlTotalInvoiceTHB_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        'ddlTotalInvoiceTHB_Invoice.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "Currency"
                  Select g.Type, g.Code
        Try
            ddlTotalInvoice_Invoice.DataSource = gg.ToList
            ddlTotalInvoice_Invoice.DataTextField = "Code"
            ddlTotalInvoice_Invoice.DataValueField = "Code"
            ddlTotalInvoice_Invoice.DataBind()

            ddlForwarding_Invoice.DataSource = gg.ToList
            ddlForwarding_Invoice.DataTextField = "Code"
            ddlForwarding_Invoice.DataValueField = "Code"
            ddlForwarding_Invoice.DataBind()

            ddlFreight_Invoice.DataSource = gg.ToList
            ddlFreight_Invoice.DataTextField = "Code"
            ddlFreight_Invoice.DataValueField = "Code"
            ddlFreight_Invoice.DataBind()

            ddlInsurance_Invoice.DataSource = gg.ToList
            ddlInsurance_Invoice.DataTextField = "Code"
            ddlInsurance_Invoice.DataValueField = "Code"
            ddlInsurance_Invoice.DataBind()

            ddlPackingCharge_Invoice.DataSource = gg.ToList
            ddlPackingCharge_Invoice.DataTextField = "Code"
            ddlPackingCharge_Invoice.DataValueField = "Code"
            ddlPackingCharge_Invoice.DataBind()

            ddlHandingCharge_Invoice.DataSource = gg.ToList
            ddlHandingCharge_Invoice.DataTextField = "Code"
            ddlHandingCharge_Invoice.DataValueField = "Code"
            ddlHandingCharge_Invoice.DataBind()

            ddlLandingCharge_Invoice.DataSource = gg.ToList
            ddlLandingCharge_Invoice.DataTextField = "Code"
            ddlLandingCharge_Invoice.DataValueField = "Code"
            ddlLandingCharge_Invoice.DataBind()

            ddlTotalInvoiceTHB_Invoice.DataSource = gg.ToList
            ddlTotalInvoiceTHB_Invoice.DataTextField = "Code"
            ddlTotalInvoiceTHB_Invoice.DataValueField = "Code"
            ddlTotalInvoiceTHB_Invoice.DataBind()

            If ddlTotalInvoice_Invoice.Items.Count > 1 Then
                ddlTotalInvoice_Invoice.Enabled = True
            Else
                ddlTotalInvoice_Invoice.Enabled = False
            End If

            If ddlForwarding_Invoice.Items.Count > 1 Then
                ddlForwarding_Invoice.Enabled = True
            Else
                ddlForwarding_Invoice.Enabled = False
            End If

            If ddlFreight_Invoice.Items.Count > 1 Then
                ddlFreight_Invoice.Enabled = True
            Else
                ddlFreight_Invoice.Enabled = False
            End If

            If ddlInsurance_Invoice.Items.Count > 1 Then
                ddlInsurance_Invoice.Enabled = True
            Else
                ddlInsurance_Invoice.Enabled = False
            End If

            If ddlPackingCharge_Invoice.Items.Count > 1 Then
                ddlPackingCharge_Invoice.Enabled = True
            Else
                ddlPackingCharge_Invoice.Enabled = False
            End If

            If ddlHandingCharge_Invoice.Items.Count > 1 Then
                ddlHandingCharge_Invoice.Enabled = True
            Else
                ddlHandingCharge_Invoice.Enabled = False
            End If

            If ddlLandingCharge_Invoice.Items.Count > 1 Then
                ddlLandingCharge_Invoice.Enabled = True
            Else
                ddlLandingCharge_Invoice.Enabled = False
            End If

            If ddlTotalInvoiceTHB_Invoice.Items.Count > 1 Then
                ddlTotalInvoiceTHB_Invoice.Enabled = True
            Else
                ddlTotalInvoiceTHB_Invoice.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    '-------------------------------------------------------------Show ddl TRUCKLICENSE--------------------------------------------
    Private Sub showtrucklicense()
        'ddlTruckLicense_Invoice.Items.Clear()
        'ddlTruckLicense_Invoice.Items.Add(New ListItem("--Select TruckLicense--", ""))
        'ddlTruckLicense_Invoice.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "TRUCKLICENSE"
                  Select g.Type, g.Code
        Try
            ddlTruckLicense_Invoice.DataSource = gg.ToList
            ddlTruckLicense_Invoice.DataTextField = "Code"
            ddlTruckLicense_Invoice.DataValueField = "Code"
            ddlTruckLicense_Invoice.DataBind()

            If ddlTruckLicense_Invoice.Items.Count > 1 Then
                ddlTruckLicense_Invoice.Enabled = True
            Else
                ddlTruckLicense_Invoice.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------Show ddl DRIVER--------------------------------------------
    Private Sub showtruckdriver()
        'ddlDriverName_Invoice.Items.Clear()
        'ddlDriverName_Invoice.Items.Add(New ListItem("--Select TruckDriver--", ""))
        'ddlDriverName_Invoice.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "DRIVER"
                  Select g.Type, g.Description
        Try
            ddlDriverName_Invoice.DataSource = gg.ToList
            ddlDriverName_Invoice.DataTextField = "Description"
            ddlDriverName_Invoice.DataValueField = "Description"
            ddlDriverName_Invoice.DataBind()

            If ddlDriverName_Invoice.Items.Count > 1 Then
                ddlDriverName_Invoice.Enabled = True
            Else
                ddlDriverName_Invoice.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------Show ddl  TRANSMODE-------------------------------------------
    Private Sub showshipmode()
        'ddlShipMode_EASJOB.Items.Clear()
        'ddlShipMode_EASJOB.Items.Add(New ListItem("--Select ShipMode--", ""))
        'ddlShipMode_EASJOB.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "TRANSMODE"
                  Select g.Type, g.Code
        Try
            ddlShipMode_EASJOB.DataSource = gg.ToList
            ddlShipMode_EASJOB.DataTextField = "Code"
            ddlShipMode_EASJOB.DataValueField = "Code"
            ddlShipMode_EASJOB.DataBind()

            If ddlShipMode_EASJOB.Items.Count > 1 Then
                ddlShipMode_EASJOB.Enabled = True
            Else
                ddlDriverName_Invoice.Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    '---------------------------------------------------------Show ddl PAYMENTTERM---------------------------------------------------
    Private Sub showdeliveryterm()
        'ddlDeliveryTerm_EASJOB.Items.Clear()
        'ddlDeliveryTerm_EASJOB.Items.Add(New ListItem("--Select Delivery--", ""))
        'ddlDeliveryTerm_EASJOB.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "PAYMENTTERM"
                  Select g.Type, g.Code
        Try
            ddlDeliveryTerm_EASJOB.DataSource = gg.ToList
            ddlDeliveryTerm_EASJOB.DataTextField = "Code"
            ddlDeliveryTerm_EASJOB.DataValueField = "Code"
            ddlDeliveryTerm_EASJOB.DataBind()

            If ddlDeliveryTerm_EASJOB.Items.Count > 1 Then
                ddlDeliveryTerm_EASJOB.Enabled = True
            Else
                ddlDeliveryTerm_EASJOB.Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    '------------------------------------------------------------Show ddl SHIPMARK-----------------------------------------------------
    Private Sub showshipmark()
        'ddlShippingMark_EASJOB.Items.Clear()
        'ddlShippingMark_EASJOB.Items.Add(New ListItem("--Select Delivery--", ""))
        'ddlShippingMark_EASJOB.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "SHIPMARK"
                  Select g.Type, g.Code
        Try
            ddlShippingMark_EASJOB.DataSource = gg.ToList
            ddlShippingMark_EASJOB.DataTextField = "Code"
            ddlShippingMark_EASJOB.DataValueField = "Code"
            ddlShippingMark_EASJOB.DataBind()

            If ddlShippingMark_EASJOB.Items.Count > 1 Then
                ddlShippingMark_EASJOB.Enabled = True
            Else
                ddlShippingMark_EASJOB.Enabled = False
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
        '    Repeater1.DataSource = user
        '    Repeater1.DataBind()
        'Else
        '    Me.Repeater1.DataSource = Nothing
        '    Me.Repeater1.DataBind()
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
            Repeater1.DataSource = cons.ToList
            Repeater1.DataBind()
            ScriptManager.RegisterStartupScript(ShipperUpdatePanel, ShipperUpdatePanel.GetType(), "show", "$(function () { $('#" + ShipperPanel.ClientID + "').modal('show'); });", True)
            ShipperUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Shipper Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Shipper-----------------------------------------------
    Protected Sub Unnamed_ServerClick(sender As Object, e As EventArgs)
        selectShipperCode()
    End Sub
    '--------------------------------------------------------Click Data Shipper In Modal-----------------------------------------
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectShipper") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtShippercode.Value = user.u.PartyCode
                    txtNameShipper_Invoice.Value = user.u.PartyFullName
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
    '--------------------------------------------------------Show Data Consignee In Modal-----------------------------------------
    Public Sub showListConsignee()

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
    '--------------------------------------------------------Show Data Consignee In Modal-----------------------------------------
    Private Sub selectConsigneeCode()
        Dim cons_code As String

        If String.IsNullOrEmpty(txtConsigneeCode.Value.Trim) Then
            cons_code = ""

        Else
            cons_code = txtConsigneeCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2, pa.Address3

        If cons.Count > 0 Then
            Repeater2.DataSource = cons.ToList
            Repeater2.DataBind()
            ScriptManager.RegisterStartupScript(ConsigneeUpdatePanel, ConsigneeUpdatePanel.GetType(), "show", "$(function () { $('#" + ConsigneePanel.ClientID + "').modal('show'); });", True)
            ConsigneeUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Consignee Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Consignee-----------------------------------------------
    Protected Sub Unnamed_ServerClick1(sender As Object, e As EventArgs)
        selectConsigneeCode()
    End Sub
    '--------------------------------------------------------Click Data Consignee In Modal-----------------------------------------
    Protected Sub Repeater2_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater2.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectConsignee") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtConsigneeCode.Value = user.u.PartyCode
                    txtNameConsignee_Invoice.Value = user.u.PartyFullName
                    txtAddress1Consignee.Value = user.br.Address1
                    txtAddress2Consignee.Value = user.br.Address2
                    txtAddress3Consignee.Value = user.br.Address3
                    txtAddress4Consignee.Value = user.br.Address4
                    txtAddress5Consignee.Value = user.br.ZipCode
                    txtEmailConsignee.Value = user.br.email

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data CustomerCode In Modal-----------------------------------------
    Public Sub showListCustomerCode()

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
    '--------------------------------------------------------Show Data CustomerCode In Modal-----------------------------------------
    Private Sub selectCustomerCode()
        Dim cus_code As String

        If String.IsNullOrEmpty(txtCustomerCode_EASJOB.Value.Trim) Then
            cus_code = ""

        Else
            cus_code = txtCustomerCode_EASJOB.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cus_code And p.Consignee = "0") Or p.Consignee = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2, pa.Address3

        If cons.Count > 0 Then
            Repeater3.DataSource = cons.ToList
            Repeater3.DataBind()
            ScriptManager.RegisterStartupScript(CustomerCodeUpdatePanel, CustomerCodeUpdatePanel.GetType(), "show", "$(function () { $('#" + CustomerCodePanel.ClientID + "').modal('show'); });", True)
            CustomerCodeUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search CustomerCode-----------------------------------------------
    Protected Sub Unnamed_ServerClick2(sender As Object, e As EventArgs)
        selectCustomerCode()
    End Sub
    '--------------------------------------------------------Click Data CustomerCode In Modal-----------------------------------------
    Protected Sub Repeater3_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater3.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectCustomerCode") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtCustomerCode_EASJOB.Value = user.u.PartyCode
                    txtNameCustomer_EASJOB.Value = user.u.PartyFullName
                    txtAddressCustomer_EASJOB.Value = user.br.Address1 + user.br.Address2 + user.br.Address3 + user.br.Address4 + user.br.ZipCode
                    txtEmailCustomer_EASJOB.Value = user.br.email
                    txtTelNoCustomer_EASJOB.Value = user.br.Tel
                    txtFaxNoCustomer_EASJOB.Value = user.br.Fax
                    txtContractPersonCustomer_EASJOB.Value = user.br.Attn
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data CustomerCode_BillTo In Modal-----------------------------------------
    Public Sub showListCustomerCode_BillTo()

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
    '--------------------------------------------------------Show Data CustomerCode_BillTo In Modal-----------------------------------------
    Private Sub selectCustomerCode_BillTo()
        Dim cus_billto_code As String

        If String.IsNullOrEmpty(txtCustomerCode_EASJOB.Value.Trim) Then
            cus_billto_code = ""

        Else
            cus_billto_code = txtCustomerCode_EASJOB.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cus_billto_code And p.Consignee = "0") Or p.Consignee = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2, pa.Address3

        If cons.Count > 0 Then
            Repeater4.DataSource = cons.ToList
            Repeater4.DataBind()
            ScriptManager.RegisterStartupScript(CustomerCode_BillToUpdatePanel, CustomerCode_BillToUpdatePanel.GetType(), "show", "$(function () { $('#" + CustomerCode_BillToPanel.ClientID + "').modal('show'); });", True)
            CustomerCode_BillToUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search CustomerCode_BillTo-----------------------------------------------
    Protected Sub Unnamed_ServerClick3(sender As Object, e As EventArgs)
        selectCustomerCode_BillTo()
    End Sub
    '--------------------------------------------------------Click Data CustomerCode_BillTo In Modal-----------------------------------------
    Protected Sub Repeater4_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater4.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectCustomerCode_BillTo") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtCustomerCode_BillTo_EASJOB.Value = user.u.PartyCode
                    txtNameCustomer_BillTo_EASJOB.Value = user.u.PartyFullName
                    txtAddressCustomer_BillTo_EASJOB.Value = user.br.Address1 + user.br.Address2 + user.br.Address3 + user.br.Address4 + user.br.ZipCode
                    txtEmailCustomer_BillTo_EASJOB.Value = user.br.email
                    txtTelNoCustomer_BillTo_EASJOB.Value = user.br.Tel
                    txtFaxNoCustomer_BillTo_EASJOB.Value = user.br.Fax
                    txtContractPersonCustomer_BillTo_EASJOB.Value = user.br.Attn
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '---------------------------------------------------------------------Click btn Add Method---------------------------------------------------
    Protected Sub btnAddHead_ServerClick(sender As Object, e As EventArgs)
        btnSaveAddHead.Visible = True
        btnSaveEditHead.Visible = False

        Head_fieldset.Disabled = False
        invoiceheader_fieldset.Disabled = False
        easjob_fieldset.Disabled = False
        itemdetail_fieldset.Disabled = True
        packinglist_fieldset.Disabled = True

        owner_easjob_fieldset.Disabled = True
        shipto_easjob_fieldset.Disabled = True
        easinv_easjob_fieldset.Disabled = True
        billto_easjob_fieldset.Disabled = True
    End Sub
    '---------------------------------------------------------------------Click btn Edit Method---------------------------------------------------
    Protected Sub btnEditHead_ServerClick(sender As Object, e As EventArgs)
        btnSaveEditHead.Visible = True
        btnSaveAddHead.Visible = False

        Head_fieldset.Disabled = False
        invoiceheader_fieldset.Disabled = False
        easjob_fieldset.Disabled = False
        itemdetail_fieldset.Disabled = False
        packinglist_fieldset.Disabled = False
    End Sub
    '---------------------------------------------------------------------Click btn SaveAdd Method---------------------------------------------------
    Protected Sub btnSaveAddHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpCustomsInvoice"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveDATA_New()
            ClearDATA()
            InsertData()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '---------------------------------------------------------------------Click btn SaveEdit Method---------------------------------------------------
    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmImpCustomsInvoice"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then


        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    Protected Sub Unnamed_ServerClick4(sender As Object, e As EventArgs)

    End Sub
    '---------------------------------------------------------------------SaveData Add Method---------------------------------------------------
    Private Sub SaveDATA_New()

        If txtInvoiceNo_BeforeTab.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Invoice No ก่อน !!!")
            txtInvoiceNo_BeforeTab.Focus()
            Exit Sub
        End If

        If txtShippercode.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Shipper Code ก่อน !!!")
            txtShippercode.Focus()
            Exit Sub
        End If

        If txtConsigneeCode.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Consignee Code ก่อน !!!")
            txtConsigneeCode.Focus()
            Exit Sub
        End If

        If rdbDiffAmount1.Checked = True Then
            DiffBy = "Diff by items-amount"
        End If

        If rdbDiffWeight1.Checked = True Then
            DiffBy = "Diff by items-Weight"
        End If

        If rdbNotifyParty1.Checked = True Then
            TermTransport = "Notfy Party"
        End If

        If rdbOnBehalfOf1.Checked = True Then
            TermTransport = "On Behalf of"
        End If

        If chkEnable.Checked = True Then
            OnbehalfStatus = "Enable On behalf of"
        Else
            OnbehalfStatus = "Disable On behalf of"
        End If

        'sb = New StringBuilder()
        'sb.Append("INSERT INTO tblImpInvoice (InvoiceNo,ReferenceNo,PurchaseOrderNo,InvoiceDate,DeliveryDate,ReferenceDate,ExporterCode,ExporterENG,Street_Number,District,Subprovince,Province,PostCode,CompensateCode,ConsignneeCode,ConsignneeENG,ConsignneeStreet_Number,ConsignneeDistrict,ConsignneeSubProvince,ConsignneeProvince,ConsignneePostCode,ConsignneeEMail,PurchaseCountryCode,PurchaseCountryName,DestinationCountryCode,")
        'sb.Append(" DestinationCountryName,CountryCode,CountryName,TermOfPayment,Term,TotalNetWeight,SumItemWeight,TotalInvoiceCurrency,TotalInvoiceAmount,TotalInvoiceAmount1,ForwardingCurrency,ForwardingAmount,ForwardingAmount1,FreightCurrency,FreightAmount,FreightAmount1,InsuranceCurrency,InsuranceAmount,InsuranceAmount1,PackingChargeCurrency,PackingChargeAmount,PackingChargeAmount1,ForeignInlandCurrency,ForeignInlandAmount,ForeignInlandAmount1,LandingChargeCurrency,")
        'sb.Append(" LandingChargeAmount,LandingChargeAmount1,OtherChargeCurrency,OtherChargeAmount,OtherChargeAmount1,TransmitDate,DiffBy,TermforShip,OnbehalfStatus,EASExporterCode,EASNameEng,StreetAndNumber,ESADistrict,EASSubProvince,EASProvince,EASPostCode,EASTCompensete,EASCustomerCode,EASCustomerENG,EASCustomerAddress,EASCustomerEMail,EASCustomerTelNo,EASCustomerFaxNo,")
        'sb.Append(" EASCustomerContactPerson,EASInvRefNo,EASLOTNo,EASCustomerRefNo,EASSpecialInstruction,EASShipMode,EASDeliveryTerm,EASShippingMark,EASShippingMarkCompany,EASShippingMarkAddress,EASRemark,EASTotalCurrency,EASBilltoCustomerCode,EASBilltoCustomerENG,EASBilltoCustomerAddress,EASBilltoCustomerEMail,EASBilltoCustomerTelNo,EASBilltoCustomerFaxNo,EASBilltoCustomerContactPerson,PLTNetAmount,UnitPLT,CTNPLTName,CTNNetAmount,UnitCTN,UnitCTNName,GrossWeightAmount,QountityAmount,VolumAmount,TotalTextPack,CarLicense,DriverName,PrintCountInv,PrintCountPack,PrintCount107,PrintCount108,PrintCountDoc,CustomsConfirmDate,App,CreateBy,CreateDate)")
        'sb.Append(" VALUES (@InvoiceNo,@ReferenceNo,@PurchaseOrderNo,@InvoiceDate,@DeliveryDate,@ReferenceDate,@ExporterCode,@ExporterENG,@Street_Number,@District,@Subprovince,@Province,@PostCode,@CompensateCode,@ConsignneeCode,@ConsignneeENG,@ConsignneeStreet_Number,@ConsignneeDistrict,@ConsignneeSubProvince,@ConsignneeProvince,@ConsignneePostCode,@ConsignneeEMail,@PurchaseCountryCode,@PurchaseCountryName,@DestinationCountryCode,")
        'sb.Append(" @DestinationCountryName,@CountryCode,@CountryName,@TermOfPayment,@Term,@TotalNetWeight,@SumItemWeight,@TotalInvoiceCurrency,@TotalInvoiceAmount,@TotalInvoiceAmount1,@ForwardingCurrency,@ForwardingAmount,@ForwardingAmount1,@FreightCurrency,@FreightAmount,@FreightAmount1,@InsuranceCurrency,@InsuranceAmount,@InsuranceAmount1,@PackingChargeCurrency,@PackingChargeAmount,@PackingChargeAmount1,@ForeignInlandCurrency,@ForeignInlandAmount,@ForeignInlandAmount1,@LandingChargeCurrency,")
        'sb.Append(" @LandingChargeAmount,@LandingChargeAmount1,@OtherChargeCurrency,@OtherChargeAmount,@OtherChargeAmount1,@TransmitDate,@DiffBy,@TermforShip,@OnbehalfStatus,@EASExporterCode,@EASNameEng,@StreetAndNumber,@ESADistrict,@EASSubProvince,@EASProvince,@EASPostCode,@EASTCompensete,@EASCustomerCode,@EASCustomerENG,@EASCustomerAddress,@EASCustomerEMail,@EASCustomerTelNo,@EASCustomerFaxNo,")
        'sb.Append(" @EASCustomerContactPerson,@EASInvRefNo,@EASLOTNo,@EASCustomerRefNo,@EASSpecialInstruction,@EASShipMode,@EASDeliveryTerm,@EASShippingMark,@EASShippingMarkCompany,@EASShippingMarkAddress,@EASRemark,@EASTotalCurrency,@EASBilltoCustomerCode,@EASBilltoCustomerENG,@EASBilltoCustomerAddress,@EASBilltoCustomerEMail,@EASBilltoCustomerTelNo,@EASBilltoCustomerFaxNo,@EASBilltoCustomerContactPerson,@PLTNetAmount,@UnitPLT,@CTNPLTName,@CTNNetAmount,@UnitCTN,@UnitCTNName,@GrossWeightAmount,@QountityAmount,@VolumAmount,@TotalTextPack,@CarLicense,@DriverName,@PrintCountInv,@PrintCountPack,@PrintCount107,@PrintCount108,@PrintCountDoc,@CustomsConfirmDate,@App,@CreateBy,@CreateDate)")

        If MsgBox("คุณต้องการเพิ่มรายการ LOT No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    db.tblImpInvoices.Add(New tblImpInvoice With { _
                    .InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim, _
                    .ReferenceNo = txtDeclaretion_BeforeTab.Value.Trim, _
                    .PurchaseOrderNo = txtJobNo_BeforeTab.Value.Trim, _
                    .InvoiceDate = txtdatepickerInvoiceDate_beforeTab.Text.Trim, _
                    .DeliveryDate = txtdatepickerDeliveryDate_beforeTab.Text.Trim, _
                    .ReferenceDate = txtdatepickerCustomsRefDate_beforeTab.Text.Trim, _
                    .ExporterCode = txtShippercode.Value.Trim, _
                    .ExporterENG = txtNameShipper_Invoice.Value.Trim, _
                    .Street_Number = txtAddress1Shipper.Value.Trim, _
                    .District = txtAddress2Shipper.Value.Trim, _
                    .Subprovince = txtAddress3Shipper.Value.Trim, _
                    .Province = txtAddress4Shipper.Value.Trim, _
                    .PostCode = txtAddress5Shipper.Value.Trim, _
                    .CompensateCode = txtEmailShipper.Value.Trim, _
                    .ConsignneeCode = txtConsigneeCode.Value.Trim, _
                    .ConsignneeENG = txtNameConsignee_Invoice.Value.Trim, _
                    .ConsignneeStreet_Number = txtAddress1Consignee.Value.Trim, _
                    .ConsignneeDistrict = txtAddress2Consignee.Value.Trim, _
                    .ConsignneeSubProvince = txtAddress3Consignee.Value.Trim, _
                    .ConsignneeProvince = txtAddress4Consignee.Value.Trim, _
                    .ConsignneePostCode = txtAddress5Consignee.Value.Trim, _
                    .ConsignneeEMail = txtEmailConsignee.Value.Trim, _
                    .PurchaseCountryCode = ddlPurchaseCountry_Invoice.Text.Trim, _
                    .PurchaseCountryName = txtPurchaseCountry_Invoice.Value.Trim, _
                    .DestinationCountryCode = ddlDestinationCountry_Invoice.Text.Trim, _
                    .DestinationCountryName = txtDestinationCountry_Invoice.Value.Trim, _
                    .CountryCode = ddlOriginCountry_Invoice.Text.Trim, _
                    .CountryName = txtOriginCountry_Invoice.Value.Trim, _
                    .TermOfPayment = ddlTermOfPayment_Invoice.Text.Trim, _
                    .Term = ddlTerm_Invoice.Text.Trim, _
                    .TotalNetWeight = CDbl(txtTotalNetWeight_Invoice.Value).ToString("#,##0.000"), _
                    .SumItemWeight = CDbl(txtSumItemWeight_Invoice.Value).ToString("#,##0.000"), _
                    .TotalInvoiceCurrency = ddlTotalInvoice_Invoice.Text.Trim, _
                    .TotalInvoiceAmount = CDbl(txtTotalInvoice1_Invoice.Value).ToString("#,##0.000"), _
                    .TotalInvoiceAmount1 = CDbl(txtTotalInvoice2_Invoice.Value).ToString("#,##0.000"), _
                    .ForwardingCurrency = ddlForwarding_Invoice.Text.Trim, _
                    .ForwardingAmount = CDbl(txtForwarding1_Invoice.Value).ToString("#,##0.000"), _
                    .ForwardingAmount1 = CDbl(txtForwarding2_Invoice.Value).ToString("#,##0.000"), _
                    .FreightCurrency = ddlFreight_Invoice.Text.Trim, _
                    .FreightAmount = CDbl(txtFreight1_Invoice.Value).ToString("#,##0.000"), _
                    .FreightAmount1 = CDbl(txtFreight2_Invoice.Value).ToString("#,##0.000"), _
                    .InsuranceCurrency = ddlInsurance_Invoice.Text.Trim, _
                    .InsuranceAmount = CDbl(txtInsurance1_Invoice.Value).ToString("#,##0.000"), _
                    .InsuranceAmount1 = CDbl(txtInsurance2_Invoice.Value).ToString("#,##0.000"), _
                    .PackingChargeCurrency = ddlPackingCharge_Invoice.Text.Trim, _
                    .PackingChargeAmount = CDbl(txtPackingCharge1_Invoice.Value).ToString("#,##0.000"), _
                    .PackingChargeAmount1 = CDbl(txtPackingCharge2_Invoice.Value).ToString("#,##0.000"), _
                    .ForeignInlandCurrency = ddlHandingCharge_Invoice.Text.Trim, _
                    .ForeignInlandAmount = CDbl(txtHandingCharge1_Invoice.Value).ToString("#,##0.000"), _
                    .ForeignInlandAmount1 = CDbl(txtHandingCharge2_invoice.Value).ToString("#,##0.000"), _
                    .LandingChargeCurrency = ddlLandingCharge_Invoice.Text.Trim, _
                    .LandingChargeAmount = CDbl(txtLandingCharge1_Invoice.Value).ToString("#,##0.000"), _
                    .LandingChargeAmount1 = CDbl(txtLandingCharge2_Invoice.Value).ToString("#,##0.000"), _
                    .OtherChargeCurrency = ddlTotalInvoiceTHB_Invoice.Text.Trim, _
                    .OtherChargeAmount = CDbl(txtTotalInvoiceTHB1_Invoice.Value).ToString("#,##0.000"), _
                    .OtherChargeAmount1 = CDbl(txtTotalInvoiceTHB2_Invoice.Value).ToString("#,##0.000"), _
                    .TransmitDate = txtdatepickerTransmitDate.Text.Trim, _
                    .DiffBy = DiffBy, _
                    .TermforShip = TermTransport, _
                    .OnbehalfStatus = OnbehalfStatus, _
                    .EASExporterCode = txtOwnerCode_EASJOB.Value.Trim, _
                    .EASNameEng = txtNameOwner_EASJOB.Value.Trim, _
                    .StreetAndNumber = txtAddress1Owner_EASJOB.Value.Trim, _
                    .ESADistrict = txtAddress2Owner_EASJOB.Value.Trim, _
                    .EASSubProvince = txtAddress3Owner_EASJOB.Value.Trim, _
                    .EASProvince = txtAddress4Owner_EASJOB.Value.Trim, _
                    .EASPostCode = txtAddress5Owner_EASJOB.Value.Trim, _
                    .EASTCompensete = txtEmailOwner_EASJOB.Value.Trim, _
                    .EASCustomerCode = txtCustomerCode_EASJOB.Value.Trim, _
                    .EASCustomerENG = txtNameCustomer_EASJOB.Value.Trim, _
                    .EASCustomerAddress = txtAddressCustomer_EASJOB.Value.Trim, _
                    .EASCustomerEMail = txtEmailCustomer_EASJOB.Value.Trim, _
                    .EASCustomerTelNo = txtTelNoCustomer_EASJOB.Value.Trim, _
                    .EASCustomerFaxNo = txtFaxNoCustomer_EASJOB.Value.Trim, _
                    .EASCustomerContactPerson = txtContractPersonCustomer_EASJOB.Value.Trim, _
                    .EASInvRefNo = txtEASINV_EASJOB.Value.Trim, _
                    .EASLOTNo = txtEASLOT_EASJOB.Value.Trim, _
                    .EASCustomerRefNo = txtReferenceLine_EASJOB.Value.Trim, _
                    .EASSpecialInstruction = txtTruckWaybill_EASJOB.Value.Trim, _
                    .EASShipMode = ddlShipMode_EASJOB.Text.Trim, _
                    .EASDeliveryTerm = ddlDeliveryTerm_EASJOB.Text.Trim, _
                    .EASShippingMark = ddlShippingMark_EASJOB.Text.Trim, _
                    .EASShippingMarkCompany = txtCompany_EASJOB.Value.Trim, _
                    .EASShippingMarkAddress = txtAddressEAS_EASJOB.Value.Trim, _
                    .EASRemark = txtRemarkEAS_EASJOB.Value.Trim, _
                    .EASTotalCurrency = txtTotal_EASJOB.Value.Trim, _
                    .EASBilltoCustomerCode = txtCustomerCode_BillTo_EASJOB.Value.Trim, _
                    .EASBilltoCustomerENG = txtNameCustomer_BillTo_EASJOB.Value.Trim, _
                    .EASBilltoCustomerAddress = txtAddressCustomer_BillTo_EASJOB.Value.Trim, _
                    .EASBilltoCustomerEMail = txtEmailCustomer_BillTo_EASJOB.Value.Trim, _
                    .EASBilltoCustomerTelNo = txtTelNoCustomer_BillTo_EASJOB.Value.Trim, _
                    .EASBilltoCustomerFaxNo = txtFaxNoCustomer_BillTo_EASJOB.Value.Trim, _
                    .EASBilltoCustomerContactPerson = txtContractPersonCustomer_BillTo_EASJOB.Value.Trim, _
                    .PLTNetAmount = CDbl(txtPLTNetAmount_PACKINGLIST.Value).ToString("#,##0.000"), _
                    .UnitPLT = ddlPLTNetAmount_PACKINGLIST.Text.Trim, _
                    .CTNPLTName = txtPLTNetAmount2_PACKINGLIST.Value.Trim, _
                    .CTNNetAmount = CDbl(txtCTNNetAmount_PACKINGLIST.Value).ToString("#,##0.000"), _
                    .UnitCTN = ddlCTNNetAmount_PACKINGLIST.Text.Trim, _
                    .UnitCTNName = txtCTNNetAmount2_PACKINGLIST.Value.Trim, _
                    .GrossWeightAmount = CDbl(txtTotalGrossWeight_Invoice.Value).ToString("#,##0.000"), _
                 .QountityAmount = CDbl(txtTotalQuantityPack_Invoice.Value).ToString("#,##0.000"), _
                 .VolumAmount = CDbl(txtTotalVolume_Invoice.Value).ToString("#,##0.000"), _
                 .TotalTextPack = txtTotal_PACKINGLIST.Value.Trim, _
                 .CarLicense = ddlTruckLicense_Invoice.Text.Trim, _
                 .DriverName = ddlDriverName_Invoice.Text.Trim, _
                 .PrintCountInv = "0", _
                 .PrintCountPack = "0", _
                 .PrintCount107 = "0", _
                 .PrintCount108 = "0", _
                 .PrintCountDoc = "0", _
                 .CustomsConfirmDate = txtdatepickerNoDate_beforeTab.Text.Trim, _
                 .App = "Wait", _
                 .CreateBy = CStr(Session("UserName")), _
                 .CreateDate = Now
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
        txtInvoiceNo_BeforeTab.Focus()
    End Sub 'saveเข้าtblImpInvoice
    Private Sub SaveDATANew_Detail()
        If txtItemNo_ItemDetail.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Item No ก่อน !!!")
            txtItemNo_ItemDetail.Focus()
            Exit Sub
        End If
        If txtProductDesc_ItemDetail.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Product Desc ก่อน !!!")
            txtProductDesc_ItemDetail.Focus()
            Exit Sub
        End If

        'sb.Append("INSERT INTO tblImpInvoiceDetail (ItemNo,InvoiceNo,ProductYear,Brand,Product,NatureofTrn,PurchaseCountry,OriginCountry,ProductDesc1,ProductDesc2,ProductDesc3,InvQty,InvUnit,InvUnitDetail,Weight,WeightUnit,WeightUnitDetail,Quantity,QuantityUnit,QuantityUnitDetail,TariffCode,StatisticalCode,TariffSequence,ProductAttribute1,ProductAttribute2,PriceIncreaseForeign,PriceIncreseBath,DeclarationLine,FormulaNo,BOILicenseNo,X19BisTransferNo,BondFormulaNo,Currency,ExchangeRate,PriceForeigh,")
        'sb.Append(" PriceForeighAmount,PriceBath,PriceBathAmount,ForwardingCurrency,ForwardingForiegnAmount,ForwardingExchangeRate,ForwardBathAmount,FreightCurrency,FreightForiegnAmount,FreightExchangeRate,FreightBathAmount,InsuranceCurrency,InsuranceForiegnAmount,InsuranceExchangeRate,InsuranceBathAmount,PackageChargeCurrency,PackageChargeForiegnAmount,PackageChargeExchangeRate,PackageChargeBathAmount,ForeighnInlandFreidgeCurrency,ForeighnInlandFreidgeForiegnAmount,ForeighnInlandFreidgeExchangeRate,ForeighnInlandFreidgeBathAmount,LandingChargeCurrency,LandingChargeForiegnAmount,LandingChargeExchangeRate,")
        'sb.Append(" LandingChargeBathAmount,OtherChargeCurrency,OtherChargeForiegnAmount,OtherChargeExchangeRate,OtherChargeBathAmount,ItemRemark)")
        'sb.Append(" VALUES (@ItemNo,@InvoiceNo,@ProductYear,@Brand,@Product,@NatureofTrn,@PurchaseCountry,@OriginCountry,@ProductDesc1,@ProductDesc2,@ProductDesc3,@InvQty,@InvUnit,@InvUnitDetail,@Weight,@WeightUnit,@WeightUnitDetail,@Quantity,@QuantityUnit,@QuantityUnitDetail,@TariffCode,@StatisticalCode,@TariffSequence,@ProductAttribute1,@ProductAttribute2,@PriceIncreaseForeign,@PriceIncreseBath,@DeclarationLine,@FormulaNo,@BOILicenseNo,@X19BisTransferNo,@BondFormulaNo,@Currency,@ExchangeRate,@PriceForeigh,")
        'sb.Append(" @PriceForeighAmount,@PriceBath,@PriceBathAmount,@ForwardingCurrency,@ForwardingForiegnAmount,@ForwardingExchangeRate,@ForwardBathAmount,@FreightCurrency,@FreightForiegnAmount,@FreightExchangeRate,@FreightBathAmount,@InsuranceCurrency,@InsuranceForiegnAmount,@InsuranceExchangeRate,@InsuranceBathAmount,@PackageChargeCurrency,@PackageChargeForiegnAmount,@PackageChargeExchangeRate,@PackageChargeBathAmount,@ForeighnInlandFreidgeCurrency,@ForeighnInlandFreidgeForiegnAmount,@ForeighnInlandFreidgeExchangeRate,@ForeighnInlandFreidgeBathAmount,@LandingChargeCurrency,@LandingChargeForiegnAmount,@LandingChargeExchangeRate,")
        'sb.Append(" @LandingChargeBathAmount,@OtherChargeCurrency,@OtherChargeForiegnAmount,@OtherChargeExchangeRate,@OtherChargeBathAmount,@ItemRemark)")

        If MsgBox("คุณต้องการเพิ่มรายการ Item No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    db.tblImpInvoiceDetails.Add(New tblImpInvoiceDetail With { _
                    .ItemNo = txtItemNo_ItemDetail.Value.Trim, _
                    .InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim, _
                    .ProductYear = txtProductYear_ItemDetail.Value.Trim, _
                    .Brand = ddlBrand_ItemDetail.Text.Trim, _
                    .Product = txtProductCode_ItemDetail.Value.Trim, _
                    .NatureofTrn = ddlNatureOfTRN_ItemDetail.Text.Trim, _
                    .PurchaseCountry = ddlPurchaseCtry_ItemDetail.Text.Trim, _
                    .OriginCountry = ddlOriginCtry_ItemDetail.Text.Trim, _
                    .ProductDesc1 = txtProductDesc_ItemDetail.Value.Trim, _
                    .ProductDesc2 = txtCustomerPN_ItemDetail.Value.Trim, _
                    .ProductDesc3 = txtOwnerPN_ItemDetail.Value.Trim, _
                    .InvQty = CDbl(txtInvQty_ItemDetail.Value).ToString("#,##0.00000"), _
                    .InvUnit = ddlUnit1_ItemDetail.Text.Trim, _
                    .InvUnitDetail = txtUnit1_ItemDetail.Value.Trim, _
                    .Weight = CDbl(txtWeight_ItemDetail.Value).ToString("#,##0.00000"), _
                    .WeightUnit = ddlUnit2_ItemDetail.Text.Trim, _
                    .WeightUnitDetail = txtUnit2_ItemDetail.Value.Trim, _
                    .Quantity = CDbl(txtQuantity_ItemDetail.Value).ToString("#,##0.00000"), _
                    .QuantityUnit = ddlUnit3_ItemDetail.Text.Trim, _
                    .QuantityUnitDetail = txtUnit3_ItemDetail.Value.Trim, _
                    .TariffCode = txtTariffCode_ItemDetail.Value.Trim, _
                    .StatisticalCode = txtStatisticalCode_ItemDetail.Value.Trim, _
                    .TariffSequence = txtTariffSequence_ItemDetail.Value.Trim, _
                    .ProductAttribute1 = txtProductAttribute1_ItemDetail.Value.Trim, _
                    .ProductAttribute2 = txtPONo_ItemDetail.Value.Trim, _
                    .PriceIncreaseForeign = txtPriceIncreaseForreign_ItemDetail.Value.Trim, _
                    .PriceIncreseBath = txtPriceIncreaseBath_ItemDetail.Value.Trim, _
                    .DeclarationLine = txtDeclaretionLine_ItemDetail.Value.Trim, _
                    .FormulaNo = txtFormulaNo_ItemDetail.Value.Trim, _
                    .BOILicenseNo = txtBOILicenseNo_ItemDetail.Value.Trim, _
                    .X19BisTransferNo = txt19BisTransferNo_ItemDetail.Value.Trim, _
                    .BondFormulaNo = txtBondFormulaNo_ItemDetail.Value.Trim, _
                    .Currency = ddlCurrency_ItemDetail.Text.Trim, _
                    .ExchangeRate = CDbl(txtExchangeRate_ItemDetail.Value).ToString("#,##0.0000"), _
                    .PriceForeigh = CDbl(txtPriceForeign_ItemDetail.Value).ToString("#,##0.000"), _
                    .PriceForeighAmount = CDbl(txtAmountForeign_ItemDetail.Value).ToString("#,##0.000"), _
                    .PriceBath = CDbl(txtPriceBath_ItemDetail.Value).ToString("#,##0.000"), _
                    .PriceBathAmount = txtAmountBath_ItemDetail.Value.Trim, _
                    .ForwardingCurrency = ddlForwarding_Currency_ItemDetail.Text.Trim, _
                    .ForwardingForiegnAmount = CDbl(txtForwarding_ForeignAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .ForwardingExchangeRate = CDbl(txtForwarding_Exchange_ItemDetail.Value).ToString("#,##0.0000"), _
                    .ForwardBathAmount = CDbl(txtForwarding_BathAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .FreightCurrency = ddlFreight_Currency_ItemDetail.Text.Trim, _
                    .FreightForiegnAmount = CDbl(txtFreight_ForeignAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .FreightExchangeRate = CDbl(txtFreight_Exchange_ItemDetail.Value).ToString("#,##0.0000"), _
                    .FreightBathAmount = CDbl(txtFreight_BathAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .InsuranceCurrency = ddlInsurance_Currency_ItemDetail.Text.Trim, _
                    .InsuranceForiegnAmount = CDbl(txtInsurance_ForeignAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .InsuranceExchangeRate = CDbl(txtInsurance_Exchange_ItemDetail.Value).ToString("#,##0.0000"), _
                    .InsuranceBathAmount = CDbl(txtInsurance_BathAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .PackageChargeCurrency = ddlPackageCharge_Currency_ItemDetail1.Text.Trim, _
                    .PackageChargeForiegnAmount = CDbl(txtPackageCharge_ForeignAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .PackageChargeExchangeRate = CDbl(txtPackageCharge_Exchange_ItemDetail.Value).ToString("#,##0.0000"), _
                    .PackageChargeBathAmount = CDbl(txtPackageCharge_BathAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .ForeighnInlandFreidgeCurrency = ddlForeignInlandFreidge_Currency_ItemDetail1.Text.Trim, _
                    .ForeighnInlandFreidgeForiegnAmount = CDbl(txtForeignInlandFreidge_ForeignAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .ForeighnInlandFreidgeExchangeRate = CDbl(txtForeignInlandFreidge_Exchange_ItemDetail.Value).ToString("#,##0.0000"), _
                    .ForeighnInlandFreidgeBathAmount = CDbl(txtForeignInlandFreidge_BathAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .LandingChargeCurrency = ddlLandingCharge_Currency_ItemDetail1.Text.Trim, _
                    .LandingChargeForiegnAmount = CDbl(txtLandingCharge_ForeignAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .LandingChargeExchangeRate = CDbl(txtLandingCharge_Exchange_ItemDetail.Value).ToString("#,##0.0000"), _
                    .LandingChargeBathAmount = CDbl(txtLandingCharge_BathAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .OtherChargeCurrency = ddlOtherCharge_Currency_ItemDetail1.Text.Trim, _
                    .OtherChargeForiegnAmount = CDbl(txtOtherCharge_ForeignAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .OtherChargeExchangeRate = CDbl(txtOtherCharge_Exchange_ItemDetail.Value).ToString("#,##0.0000"), _
                    .OtherChargeBathAmount = CDbl(txtOtherCharge_BathAmount_ItemDetail.Value).ToString("#,##0.000"), _
                    .ItemRemark = txtRemark_ItemDetail.Value.Trim
                    })

                    db.SaveChanges()
                    tran.Complete()

                    
                    Dim MtoT As New MoneyExt()

                    Select Case txtConsigneeCode.Value
                        Case "SG-1"
                            txtTotal_EASJOB.Value = "USD." & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                        Case "SG-2"
                            txtTotal_EASJOB.Value = "USD." & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                        Case "WD-1"
                            txtTotal_EASJOB.Value = "BAHT:" & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                        Case "WD-2"
                            txtTotal_EASJOB.Value = "USD." & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                        Case "HTI-01"
                            txtTotal_EASJOB.Value = "USD." & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                        Case "HTI"
                            txtTotal_EASJOB.Value = "USD." & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                    End Select

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Add สำเร็จ !');", True)

                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                Finally
                    db.Database.Connection.Close()
                    db.Dispose()
                    tran.Dispose()
                End Try
                txtProductCode_ItemDetail.Focus()
            End Using
        End If
        '    Clear_ItemDATA()

        '    ReadDATA()
        '    CalculateTotalInvoiceValue()


        'Catch
        '    MessageBox.Show("คุณป้อนข้อมูลผิดพลาด กรุณาตรวจสอบและแก้ไขใหม่อีกครั้ง !!!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    tr.Rollback()
        'End Try


    End Sub

    Private Sub SaveDATANew_Packing()
        If txtProductCode_PACKINGLIST.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Product Code ก่อน !!!")
            txtProductCode_PACKINGLIST.Focus()
            Exit Sub
        End If
        If txtProductDesc_ItemDetail.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Product Desc. ก่อน !!!")
            txtProductDesc_ItemDetail.Focus()
            Exit Sub
        End If
        Dim UnitStatus As String = ""

        If rdbCM.Checked = True Then
            UnitStatus = "CM"
        ElseIf rdbInch.Checked = True Then
            UnitStatus = "INC"
        End If

                    'sb.Append("INSERT INTO tblImpPackingList (InvoiceNo,PLTAmount,CTNAmount,PLTQuantity,PackProductCode,PackProductDesc,CustomerPN,OwnerPN,OriginCtry,OriginCtryName,PartUnitCode,PartUnitName,Quantity,NetWeight,GrossWeight,PackVolume,Unit,Width,Hight,Leng,PONo)")
                    'sb.Append(" VALUES (@InvoiceNo,@PLTAmount,@CTNAmount,@PLTQuantity,@PackProductCode,@PackProductDesc,@CustomerPN,@OwnerPN,@OriginCtry,@OriginCtryName,@PartUnitCode,@PartUnitName,@Quantity,@NetWeight,@GrossWeight,@PackVolume,@Unit,@Width,@Hight,@Leng,@PONo)")
        If MsgBox("คุณต้องการเพิ่มรายการ Item No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    db.tblImpPackingLists.Add(New tblImpPackingList With { _
                .InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim, _
                .PLTAmount = txtNumberOfPLT_PACKINGLIST.Value.Trim, _
                .CTNAmount = txtTotalCTN_PACKINGLIST.Value.Trim, _
                .PLTQuantity = CDbl(txtPLTQuantity_PACKINGLIST.Value).ToString("#,##0"), _
                .PackProductCode = txtProductCode_PACKINGLIST.Value.Trim, _
                .PackProductDesc = txtProductDesc_PACKINGLIST.Value.Trim, _
                .CustomerPN = txtCustomerPN_PACKINGLIST.Value.Trim, _
                .OwnerPN = txtOwnerPN_PACKINGLIST.Value.Trim, _
                .OriginCtry = txtOriginCtry_PACKINGLIST.Value.Trim, _
                .OriginCtryName = txtOriginCtry2_PACKINGLIST.Value.Trim, _
                .PartUnitCode = ddlUnit_PACKINGLIST.Text.Trim, _
                .PartUnitName = txtUnit_PACKINGLIST.Value.Trim, _
                .Quantity = CDbl(txtProductQuantity_PACKINGLIST.Value).ToString("#,##0"), _
                .NetWeight = CDbl(txtNetWeight_PACKINGLIST.Value).ToString("#,##0.00"), _
                .GrossWeight = CDbl(txtGrossWeight_PACKINGLIST.Value).ToString("#,##0.00"), _
                .PackVolume = CDbl(txtVolumeCBM_PACKINGLIST.Value).ToString("#,##0.000"), _
                .Unit = UnitStatus, _
                .Width = CDbl(txtMeasurement_Width_PACKINGLIST.Value).ToString("#,##0"), _
                .Hight = CDbl(txtMeasurement_Height_PACKINGLIST.Value).ToString("#,##0"), _
                .Leng = CDbl(txtLenght_PACKINGLIST.Value).ToString("#,##0"), _
                .PONo = txtPONo_PACKINGLIST.Value.Trim
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
                txtProductCode_ItemDetail.Focus()
            End Using
        End If


        '    End With
        '    tr.Commit()

        '    Read_PackingDATA()
        '    CalculateTotalAmount()
        '    Dim MtoT As New MoneyExt()
        '    Dim tmpNumToText1 As String
        '    Dim tmpNumToText2 As String
        'Dim Contain As String = " CONTAIN "
        'If txtPLTNetAmount_PACKINGLIST.Value = "1" Then
        '    Contain = " CONTAINS "
        'End If
        '    End If
        '    tmpNumToText1 = MoneyExt.NumToEngCarton(CDbl(txtPLTNetAmount.Text)) & "" & dcboUnitPLT.Text & Contain
        '    tmpNumToText2 = MoneyExt.NumToEngPallet(CDbl(txtCTNNetAmount.Text)) & " " & dcboCTN.Text
        '    txtTotalText.Text = tmpNumToText1 & tmpNumToText2

        'Catch
        '    MessageBox.Show("คุณป้อน ข้อมูล ซ้ำ !!!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    tr.Rollback()
        'End Try

        txtProductCode_PACKINGLIST.Focus()
    End Sub 'แก้ไข
    '---------------------------------------------------------------------SaveData Modify Method---------------------------------------------------
    Private Sub SaveDATA_Modify()

        If txtInvoiceNo_BeforeTab.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Invoice No ก่อน !!!")
            txtInvoiceNo_BeforeTab.Focus()
            Exit Sub
        End If

        If txtShippercode.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Shipper Code ก่อน !!!")
            txtShippercode.Focus()
            Exit Sub
        End If

        If txtConsigneeCode.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Consignee Code ก่อน !!!")
            txtConsigneeCode.Focus()
            Exit Sub
        End If

        If rdbDiffAmount1.Checked = True Then
            DiffBy = "Diff by items-amount"
        End If

        If rdbDiffWeight1.Checked = True Then
            DiffBy = "Diff by items-Weight"
        End If

        If rdbNotifyParty1.Checked = True Then
            TermTransport = "Notfy Party"
        End If

        If rdbOnBehalfOf1.Checked = True Then
            TermTransport = "On Behalf of"
        End If

        If chkEnable.Checked = True Then
            OnbehalfStatus = "Enable On behalf of"
        Else
            OnbehalfStatus = "Disable On behalf of"
        End If


        'sb.Append("UPDATE tblImpInvoice")
        'sb.Append(" SET InvoiceNo=@InvoiceNo,ReferenceNo=@ReferenceNo,PurchaseOrderNo=@PurchaseOrderNo,InvoiceDate=@InvoiceDate,DeliveryDate=@DeliveryDate,ReferenceDate=@ReferenceDate,ExporterCode=@ExporterCode,ExporterENG=@ExporterENG,Street_Number=@Street_Number,District=@District,Subprovince=@Subprovince,Province=@Province,PostCode=@PostCode,CompensateCode=@CompensateCode,ConsignneeCode=@ConsignneeCode,")
        'sb.Append(" ConsignneeENG=@ConsignneeENG,ConsignneeStreet_Number=@ConsignneeStreet_Number,ConsignneeDistrict=@ConsignneeDistrict,ConsignneeSubProvince=@ConsignneeSubProvince,ConsignneeProvince=@ConsignneeProvince,ConsignneePostCode=@ConsignneePostCode,ConsignneeEMail=@ConsignneeEMail,PurchaseCountryCode=@PurchaseCountryCode,PurchaseCountryName=@PurchaseCountryName,DestinationCountryCode=@DestinationCountryCode,")
        'sb.Append(" DestinationCountryName=@DestinationCountryName,CountryCode=@CountryCode,CountryName=@CountryName,TermOfPayment=@TermOfPayment,Term=@Term,TotalNetWeight=@TotalNetWeight,SumItemWeight=@SumItemWeight,TotalInvoiceCurrency=@TotalInvoiceCurrency,TotalInvoiceAmount=@TotalInvoiceAmount,TotalInvoiceAmount1=@TotalInvoiceAmount1,ForwardingCurrency=@ForwardingCurrency,ForwardingAmount=@ForwardingAmount,ForwardingAmount1=@ForwardingAmount1,FreightCurrency=@FreightCurrency,")
        'sb.Append(" FreightAmount=@FreightAmount,FreightAmount1=@FreightAmount1,InsuranceCurrency=@InsuranceCurrency,InsuranceAmount=@InsuranceAmount,InsuranceAmount1=@InsuranceAmount1,PackingChargeCurrency=@PackingChargeCurrency,PackingChargeAmount=@PackingChargeAmount,PackingChargeAmount1=@PackingChargeAmount1,ForeignInlandCurrency=@ForeignInlandCurrency,ForeignInlandAmount=@ForeignInlandAmount,ForeignInlandAmount1=@ForeignInlandAmount1,LandingChargeCurrency=@LandingChargeCurrency,")
        'sb.Append(" LandingChargeAmount=@LandingChargeAmount,LandingChargeAmount1=@LandingChargeAmount1,OtherChargeCurrency=@OtherChargeCurrency,OtherChargeAmount=@OtherChargeAmount,OtherChargeAmount1=@OtherChargeAmount1,TransmitDate=@TransmitDate,DiffBy=@DiffBy,TermforShip=@TermforShip,OnbehalfStatus=@OnbehalfStatus,EASExporterCode=@EASExporterCode,EASNameEng=@EASNameEng,StreetAndNumber=@StreetAndNumber,ESADistrict=@ESADistrict,EASSubProvince=@EASSubProvince,EASProvince=@EASProvince,")
        'sb.Append(" EASPostCode=@EASPostCode,EASTCompensete=@EASTCompensete,EASCustomerCode=@EASCustomerCode,EASCustomerENG=@EASCustomerENG,EASCustomerAddress=@EASCustomerAddress,EASCustomerEMail=@EASCustomerEMail,EASCustomerTelNo=@EASCustomerTelNo,EASCustomerFaxNo=@EASCustomerFaxNo,")
        'sb.Append(" EASCustomerContactPerson=@EASCustomerContactPerson,EASInvRefNo=@EASInvRefNo,EASLOTNo=@EASLOTNo,EASCustomerRefNo=@EASCustomerRefNo,EASSpecialInstruction=@EASSpecialInstruction,EASShipMode=@EASShipMode,EASDeliveryTerm=@EASDeliveryTerm,EASShippingMark=@EASShippingMark,EASShippingMarkCompany=@EASShippingMarkCompany,EASShippingMarkAddress=@EASShippingMarkAddress,EASRemark=@EASRemark,EASTotalCurrency=@EASTotalCurrency,EASBilltoCustomerCode=@EASBilltoCustomerCode,")
        'sb.Append(" EASBilltoCustomerENG=@EASBilltoCustomerENG,EASBilltoCustomerAddress=@EASBilltoCustomerAddress,EASBilltoCustomerEMail=@EASBilltoCustomerEMail,EASBilltoCustomerTelNo=@EASBilltoCustomerTelNo,EASBilltoCustomerFaxNo=@EASBilltoCustomerFaxNo,EASBilltoCustomerContactPerson=@EASBilltoCustomerContactPerson,PLTNetAmount=@PLTNetAmount,UnitPLT=@UnitPLT,CTNPLTName=@CTNPLTName,CTNNetAmount=@CTNNetAmount,UnitCTN=@UnitCTN,UnitCTNName=@UnitCTNName,GrossWeightAmount=@GrossWeightAmount,QountityAmount=@QountityAmount,VolumAmount=@VolumAmount,TotalTextPack=@TotalTextPack,CarLicense=@CarLicense,DriverName=@DriverName,CustomsConfirmDate=@CustomsConfirmDate,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate")
        'sb.Append(" WHERE (InvoiceNo=@InvoiceNo)")
        If MsgBox("คุณต้องการแก้ไขรายการ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    Dim edit As tblImpInvoice = (From c In db.tblImpInvoices Where c.InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim
                      Select c).First()
                    If edit IsNot Nothing Then
                        edit.InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim
                        edit.ReferenceNo = txtDeclaretion_BeforeTab.Value.Trim
                        edit.PurchaseOrderNo = txtJobNo_BeforeTab.Value.Trim
                        edit.InvoiceDate = txtdatepickerInvoiceDate_beforeTab.Text.Trim
                        edit.DeliveryDate = txtdatepickerDeliveryDate_beforeTab.Text.Trim
                        edit.ReferenceDate = txtdatepickerCustomsRefDate_beforeTab.Text.Trim
                        edit.ExporterCode = txtShippercode.Value.Trim
                        edit.ExporterENG = txtNameShipper_Invoice.Value.Trim
                        edit.Street_Number = txtAddress1Shipper.Value.Trim
                        edit.District = txtAddress2Shipper.Value.Trim
                        edit.Subprovince = txtAddress3Shipper.Value.Trim
                        edit.Province = txtAddress4Shipper.Value.Trim
                        edit.PostCode = txtAddress5Shipper.Value.Trim
                        edit.CompensateCode = txtEmailShipper.Value.Trim
                        edit.ConsignneeCode = txtConsigneeCode.Value.Trim
                        edit.ConsignneeENG = txtNameConsignee_Invoice.Value.Trim
                        edit.ConsignneeStreet_Number = txtAddress1Consignee.Value.Trim
                        edit.ConsignneeDistrict = txtAddress2Consignee.Value.Trim
                        edit.ConsignneeSubProvince = txtAddress3Consignee.Value.Trim
                        edit.ConsignneeProvince = txtAddress4Consignee.Value.Trim
                        edit.ConsignneePostCode = txtAddress5Consignee.Value.Trim
                        edit.ConsignneeEMail = txtEmailConsignee.Value.Trim
                        edit.PurchaseCountryCode = ddlPurchaseCountry_Invoice.Text.Trim
                        edit.PurchaseCountryName = txtPurchaseCountry_Invoice.Value.Trim
                        edit.DestinationCountryCode = ddlDestinationCountry_Invoice.Text.Trim
                        edit.DestinationCountryName = txtDestinationCountry_Invoice.Value.Trim
                        edit.CountryCode = ddlOriginCountry_Invoice.Text.Trim
                        edit.CountryName = txtOriginCountry_Invoice.Value.Trim
                        edit.TermOfPayment = ddlTermOfPayment_Invoice.Text.Trim
                        edit.Term = ddlTerm_Invoice.Text.Trim
                        edit.TotalNetWeight = CDbl(txtTotalNetWeight_Invoice.Value).ToString("#,##0.000")
                        edit.SumItemWeight = CDbl(txtSumItemWeight_Invoice.Value).ToString("#,##0.000")
                        edit.TotalInvoiceCurrency = ddlTotalInvoice_Invoice.Text.Trim
                        edit.TotalInvoiceAmount = CDbl(txtTotalInvoice1_Invoice.Value).ToString("#,##0.000")
                        edit.TotalInvoiceAmount1 = CDbl(txtTotalInvoice2_Invoice.Value).ToString("#,##0.000")
                        edit.ForwardingCurrency = ddlForwarding_Invoice.Text.Trim
                        edit.ForwardingAmount = CDbl(txtForwarding1_Invoice.Value).ToString("#,##0.000")
                        edit.ForwardingAmount1 = CDbl(txtForwarding2_Invoice.Value).ToString("#,##0.000")
                        edit.FreightCurrency = ddlFreight_Invoice.Text.Trim
                        edit.FreightAmount = CDbl(txtFreight1_Invoice.Value).ToString("#,##0.000")
                        edit.FreightAmount1 = CDbl(txtFreight2_Invoice.Value).ToString("#,##0.000")
                        edit.InsuranceCurrency = ddlInsurance_Invoice.Text.Trim
                        edit.InsuranceAmount = CDbl(txtInsurance1_Invoice.Value).ToString("#,##0.000")
                        edit.InsuranceAmount1 = CDbl(txtInsurance2_Invoice.Value).ToString("#,##0.000")
                        edit.PackingChargeCurrency = ddlPackingCharge_Invoice.Text.Trim
                        edit.PackingChargeAmount = CDbl(txtPackingCharge1_Invoice.Value).ToString("#,##0.000")
                        edit.PackingChargeAmount1 = CDbl(txtPackingCharge2_Invoice.Value).ToString("#,##0.000")
                        edit.ForeignInlandCurrency = ddlHandingCharge_Invoice.Text.Trim
                        edit.ForeignInlandAmount = CDbl(txtHandingCharge1_Invoice.Value).ToString("#,##0.000")
                        edit.ForeignInlandAmount1 = CDbl(txtHandingCharge2_invoice.Value).ToString("#,##0.000")
                        edit.LandingChargeCurrency = ddlLandingCharge_Invoice.Text.Trim
                        edit.LandingChargeAmount = CDbl(txtLandingCharge1_Invoice.Value).ToString("#,##0.000")
                        edit.LandingChargeAmount1 = CDbl(txtLandingCharge2_Invoice.Value).ToString("#,##0.000")
                        edit.OtherChargeCurrency = ddlTotalInvoiceTHB_Invoice.Text.Trim
                        edit.OtherChargeAmount = CDbl(txtTotalInvoiceTHB1_Invoice.Value).ToString("#,##0.000")
                        edit.OtherChargeAmount1 = CDbl(txtTotalInvoiceTHB2_Invoice.Value).ToString("#,##0.000")
                        edit.TransmitDate = txtdatepickerTransmitDate.Text.Trim
                        edit.DiffBy = DiffBy
                        edit.TermforShip = TermTransport
                        edit.OnbehalfStatus = OnbehalfStatus
                        edit.EASExporterCode = txtOwnerCode_EASJOB.Value.Trim
                        edit.EASNameEng = txtNameOwner_EASJOB.Value.Trim
                        edit.StreetAndNumber = txtAddress1Owner_EASJOB.Value.Trim
                        edit.ESADistrict = txtAddress2Owner_EASJOB.Value.Trim
                        edit.EASSubProvince = txtAddress3Owner_EASJOB.Value.Trim
                        edit.EASProvince = txtAddress4Owner_EASJOB.Value.Trim
                        edit.EASPostCode = txtAddress5Owner_EASJOB.Value.Trim
                        edit.EASTCompensete = txtEmailOwner_EASJOB.Value.Trim
                        edit.EASCustomerCode = txtCustomerCode_EASJOB.Value.Trim
                        edit.EASCustomerENG = txtNameCustomer_EASJOB.Value.Trim
                        edit.EASCustomerAddress = txtAddressCustomer_EASJOB.Value.Trim
                        edit.EASCustomerEMail = txtEmailCustomer_EASJOB.Value.Trim
                        edit.EASCustomerTelNo = txtTelNoCustomer_EASJOB.Value.Trim
                        edit.EASCustomerFaxNo = txtFaxNoCustomer_EASJOB.Value.Trim
                        edit.EASCustomerContactPerson = txtContractPersonCustomer_EASJOB.Value.Trim
                        edit.EASInvRefNo = txtEASINV_EASJOB.Value.Trim
                        edit.EASLOTNo = txtEASLOT_EASJOB.Value.Trim
                        edit.EASCustomerRefNo = txtReferenceLine_EASJOB.Value.Trim
                        edit.EASSpecialInstruction = txtTruckWaybill_EASJOB.Value.Trim
                        edit.EASShipMode = ddlShipMode_EASJOB.Text.Trim
                        edit.EASDeliveryTerm = ddlDeliveryTerm_EASJOB.Text.Trim
                        edit.EASShippingMark = ddlShippingMark_EASJOB.Text.Trim
                        edit.EASShippingMarkCompany = txtCompany_EASJOB.Value.Trim
                        edit.EASShippingMarkAddress = txtAddressEAS_EASJOB.Value.Trim
                        edit.EASRemark = txtRemarkEAS_EASJOB.Value.Trim
                        edit.EASTotalCurrency = txtTotal_EASJOB.Value.Trim
                        edit.EASBilltoCustomerCode = txtCustomerCode_BillTo_EASJOB.Value.Trim
                        edit.EASBilltoCustomerENG = txtNameCustomer_BillTo_EASJOB.Value.Trim
                        edit.EASBilltoCustomerAddress = txtAddressCustomer_BillTo_EASJOB.Value.Trim
                        edit.EASBilltoCustomerEMail = txtEmailCustomer_BillTo_EASJOB.Value.Trim
                        edit.EASBilltoCustomerTelNo = txtTelNoCustomer_BillTo_EASJOB.Value.Trim
                        edit.EASBilltoCustomerFaxNo = txtFaxNoCustomer_BillTo_EASJOB.Value.Trim
                        edit.EASBilltoCustomerContactPerson = txtContractPersonCustomer_BillTo_EASJOB.Value.Trim
                        edit.PLTNetAmount = CDbl(txtPLTNetAmount_PACKINGLIST.Value).ToString("#,##0.000")
                        edit.UnitPLT = ddlPLTNetAmount_PACKINGLIST.Text.Trim
                        edit.CTNPLTName = txtPLTNetAmount2_PACKINGLIST.Value.Trim
                        edit.CTNNetAmount = CDbl(txtCTNNetAmount_PACKINGLIST.Value).ToString("#,##0.000")
                        edit.UnitCTN = ddlCTNNetAmount_PACKINGLIST.Text.Trim
                        edit.UnitCTNName = txtCTNNetAmount2_PACKINGLIST.Value.Trim
                        edit.GrossWeightAmount = CDbl(txtTotalGrossWeight_Invoice.Value).ToString("#,##0.000")
                        edit.QountityAmount = CDbl(txtTotalQuantityPack_Invoice.Value).ToString("#,##0.000")
                        edit.VolumAmount = CDbl(txtTotalVolume_Invoice.Value).ToString("#,##0.000")
                        edit.TotalTextPack = txtTotal_PACKINGLIST.Value.Trim
                        edit.CarLicense = ddlTruckLicense_Invoice.Text.Trim
                        edit.DriverName = ddlDriverName_Invoice.Text.Trim
                        edit.CustomsConfirmDate = txtdatepickerNoDate_beforeTab.Text.Trim
                        edit.UpdateBy = CStr(Session("UserName"))
                        edit.UpdateDate = Now

                        db.SaveChanges()
                        tran.Complete()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                    End If
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        txtInvoiceNo_BeforeTab.Focus()
    End Sub
    Private Sub SaveItem_Modify()
        If txtProductCode_ItemDetail.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Product Code ก่อน !!!")
            txtProductCode_ItemDetail.Focus()
            Exit Sub
        End If

        If txtInvoiceNo_BeforeTab.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Invoice No ก่อน !!!")
            txtInvoiceNo_BeforeTab.Focus()
            Exit Sub
        End If

        If txtShippercode.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Exporter Code ก่อน !!!")
            txtShippercode.Focus()
            Exit Sub
        End If

        If txtConsigneeCode.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Consignnee Code ก่อน !!!")
            txtConsigneeCode.Focus()
            Exit Sub
        End If
        If txtItemNo_ItemDetail.Value.Trim = "" Then
            MsgBox("กรุณาป้อนรหัส Item No ก่อน !!!")
            txtItemNo_ItemDetail.Focus()
            Exit Sub
        End If

        'sb.Append("UPDATE tblImpInvoiceDetail")
        'sb.Append(" SET ProductYear=@ProductYear,Brand=@Brand,NatureofTrn=@NatureofTrn,PurchaseCountry=@PurchaseCountry,OriginCountry=@OriginCountry,ProductDesc1=@ProductDesc1,ProductDesc2=@ProductDesc2,ProductDesc3=@ProductDesc3,")
        'sb.Append(" InvQty=@InvQty,InvUnit=@InvUnit,InvUnitDetail=@InvUnitDetail, Weight=@Weight, WeightUnit=@WeightUnit, WeightUnitDetail=@WeightUnitDetail, Quantity=@Quantity, QuantityUnit=@QuantityUnit, QuantityUnitDetail=@QuantityUnitDetail, TariffCode=@TariffCode,")
        'sb.Append(" StatisticalCode=@StatisticalCode, TariffSequence=@TariffSequence, ProductAttribute1=@ProductAttribute1, ProductAttribute2=@ProductAttribute2, PriceIncreaseForeign=@PriceIncreaseForeign, PriceIncreseBath=@PriceIncreseBath, DeclarationLine=@DeclarationLine,")
        'sb.Append(" FormulaNo=@FormulaNo, BOILicenseNo=@BOILicenseNo, X19BisTransferNo=@X19BistransferNo, BondFormulaNo=@BondFormulaNo, Currency=@Currency, ExchangeRate=@ExchangeRate, PriceForeigh=@PriceForeigh, ")
        'sb.Append(" PriceForeighAmount=@PriceForeighAmount,PriceBath=@PriceBath,PriceBathAmount=@PriceBathAmount,ForwardingCurrency=@ForwardingCurrency,ForwardingForiegnAmount=@ForwardingForiegnAmount,ForwardingExchangeRate=@ForwardingExchangeRate,")
        'sb.Append(" ForwardBathAmount=@ForwardBathAmount, FreightCurrency=@FreightCurrency, FreightForiegnAmount=@FreightForiegnAmount, FreightExchangeRate=@FreightExchangeRate, FreightBathAmount=@FreightBathAmount, InsuranceCurrency=@InsuranceCurrency,")
        'sb.Append(" InsuranceForiegnAmount=@InsuranceForiegnAmount, InsuranceExchangeRate=@InsuranceExchangeRate, InsuranceBathAmount=@InsuranceBathAmount, PackageChargeCurrency=@PackageChargeCurrency, PackageChargeForiegnAmount=@PackageChargeForiegnAmount,")
        'sb.Append(" PackageChargeExchangeRate=@PackageChargeExchangeRate, PackageChargeBathAmount=@PackageChargeBathAmount, ForeighnInlandFreidgeCurrency=@ForeighnInlandFreidgeCurrency, ForeighnInlandFreidgeForiegnAmount=@ForeighnInlandFreidgeForiegnAmount,")
        'sb.Append(" ForeighnInlandFreidgeExchangeRate=@ForeighnInlandFreidgeExchangeRate, ForeighnInlandFreidgeBathAmount=@ForeighnInlandFreidgeBathAmount, LandingChargeCurrency=@LandingChargeCurrency, LandingChargeForiegnAmount=@LandingChargeForiegnAmount,")
        'sb.Append(" LandingChargeExchangeRate=@LandingChargeExchangeRate, LandingChargeBathAmount=@LandingChargeBathAmount,OtherChargeCurrency=@OtherChargeCurrency,OtherChargeForiegnAmount=@OtherChargeForiegnAmount,OtherChargeExchangeRate=@OtherChargeExchangeRate,")
        'sb.Append(" OtherChargeBathAmount=@OtherChargeBathAmount,ItemRemark=@ItemRemark")
        'sb.Append(" WHERE (InvoiceNo=@InvoiceNo AND Product=@Product AND ItemNo=@ItemNo)")

        If MsgBox("คุณต้องการแก้ไขรายการ Truck No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    Dim edit As tblImpInvoiceDetail = (From c In db.tblImpInvoiceDetails Where c.InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim And c.Product = txtProductCode_ItemDetail.Value.Trim And c.ItemNo = txtItemNo_ItemDetail.Value.Trim
                      Select c).First()
                    If edit IsNot Nothing Then
                        edit.ItemNo = txtItemNo_ItemDetail.Value.Trim
                        edit.InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim
                        edit.ProductYear = txtProductYear_ItemDetail.Value.Trim
                        edit.Brand = ddlBrand_ItemDetail.Text.Trim
                        edit.Product = txtProductCode_ItemDetail.Value.Trim
                        edit.NatureofTrn = ddlNatureOfTRN_ItemDetail.Text.Trim
                        edit.PurchaseCountry = ddlPurchaseCtry_ItemDetail.Text.Trim
                        edit.OriginCountry = ddlOriginCtry_ItemDetail.Text.Trim
                        edit.ProductDesc1 = txtProductDesc_ItemDetail.Value.Trim
                        edit.ProductDesc2 = txtCustomerPN_ItemDetail.Value.Trim
                        edit.ProductDesc3 = txtOwnerPN_ItemDetail.Value.Trim
                        edit.InvQty = CDbl(txtInvQty_ItemDetail.Value).ToString("#,##0.00000")
                        edit.InvUnit = ddlUnit1_ItemDetail.Text.Trim
                        edit.InvUnitDetail = txtUnit1_ItemDetail.Value.Trim
                        edit.Weight = CDbl(txtWeight_ItemDetail.Value).ToString("#,##0.00000")
                        edit.WeightUnit = ddlUnit2_ItemDetail.Text.Trim
                        edit.WeightUnitDetail = txtUnit2_ItemDetail.Value.Trim
                        edit.Quantity = CDbl(txtQuantity_ItemDetail.Value).ToString("#,##0.00000")
                        edit.QuantityUnit = ddlUnit3_ItemDetail.Text.Trim
                        edit.QuantityUnitDetail = txtUnit3_ItemDetail.Value.Trim
                        edit.TariffCode = txtTariffCode_ItemDetail.Value.Trim
                        edit.StatisticalCode = txtStatisticalCode_ItemDetail.Value.Trim
                        edit.TariffSequence = txtTariffSequence_ItemDetail.Value.Trim
                        edit.ProductAttribute1 = txtProductAttribute1_ItemDetail.Value.Trim
                        edit.ProductAttribute2 = txtPONo_ItemDetail.Value.Trim
                        edit.PriceIncreaseForeign = txtPriceIncreaseForreign_ItemDetail.Value.Trim
                        edit.PriceIncreseBath = txtPriceIncreaseBath_ItemDetail.Value.Trim
                        edit.DeclarationLine = txtDeclaretionLine_ItemDetail.Value.Trim
                        edit.FormulaNo = txtFormulaNo_ItemDetail.Value.Trim
                        edit.BOILicenseNo = txtBOILicenseNo_ItemDetail.Value.Trim
                        edit.X19BisTransferNo = txt19BisTransferNo_ItemDetail.Value.Trim
                        edit.BondFormulaNo = txtBondFormulaNo_ItemDetail.Value.Trim
                        edit.Currency = ddlCurrency_ItemDetail.Text.Trim
                        edit.ExchangeRate = CDbl(txtExchangeRate_ItemDetail.Value).ToString("#,##0.0000")
                        edit.PriceForeigh = CDbl(txtPriceForeign_ItemDetail.Value).ToString("#,##0.000")
                        edit.PriceForeighAmount = CDbl(txtAmountForeign_ItemDetail.Value).ToString("#,##0.000")
                        edit.PriceBath = CDbl(txtPriceBath_ItemDetail.Value).ToString("#,##0.000")
                        edit.PriceBathAmount = txtAmountBath_ItemDetail.Value.Trim
                        edit.ForwardingCurrency = ddlForwarding_Currency_ItemDetail.Text.Trim
                        edit.ForwardingForiegnAmount = CDbl(txtForwarding_ForeignAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.ForwardingExchangeRate = CDbl(txtForwarding_Exchange_ItemDetail.Value).ToString("#,##0.0000")
                        edit.ForwardBathAmount = CDbl(txtForwarding_BathAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.FreightCurrency = ddlFreight_Currency_ItemDetail.Text.Trim
                        edit.FreightForiegnAmount = CDbl(txtFreight_ForeignAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.FreightExchangeRate = CDbl(txtFreight_Exchange_ItemDetail.Value).ToString("#,##0.0000")
                        edit.FreightBathAmount = CDbl(txtFreight_BathAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.InsuranceCurrency = ddlInsurance_Currency_ItemDetail.Text.Trim
                        edit.InsuranceForiegnAmount = CDbl(txtInsurance_ForeignAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.InsuranceExchangeRate = CDbl(txtInsurance_Exchange_ItemDetail.Value).ToString("#,##0.0000")
                        edit.InsuranceBathAmount = CDbl(txtInsurance_BathAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.PackageChargeCurrency = ddlPackageCharge_Currency_ItemDetail1.Text.Trim
                        edit.PackageChargeForiegnAmount = CDbl(txtPackageCharge_ForeignAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.PackageChargeExchangeRate = CDbl(txtPackageCharge_Exchange_ItemDetail.Value).ToString("#,##0.0000")
                        edit.PackageChargeBathAmount = CDbl(txtPackageCharge_BathAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.ForeighnInlandFreidgeCurrency = ddlForeignInlandFreidge_Currency_ItemDetail1.Text.Trim
                        edit.ForeighnInlandFreidgeForiegnAmount = CDbl(txtForeignInlandFreidge_ForeignAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.ForeighnInlandFreidgeExchangeRate = CDbl(txtForeignInlandFreidge_Exchange_ItemDetail.Value).ToString("#,##0.0000")
                        edit.ForeighnInlandFreidgeBathAmount = CDbl(txtForeignInlandFreidge_BathAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.LandingChargeCurrency = ddlLandingCharge_Currency_ItemDetail1.Text.Trim
                        edit.LandingChargeForiegnAmount = CDbl(txtLandingCharge_ForeignAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.LandingChargeExchangeRate = CDbl(txtLandingCharge_Exchange_ItemDetail.Value).ToString("#,##0.0000")
                        edit.LandingChargeBathAmount = CDbl(txtLandingCharge_BathAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.OtherChargeCurrency = ddlOtherCharge_Currency_ItemDetail1.Text.Trim
                        edit.OtherChargeForiegnAmount = CDbl(txtOtherCharge_ForeignAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.OtherChargeExchangeRate = CDbl(txtOtherCharge_Exchange_ItemDetail.Value).ToString("#,##0.0000")
                        edit.OtherChargeBathAmount = CDbl(txtOtherCharge_BathAmount_ItemDetail.Value).ToString("#,##0.000")
                        edit.ItemRemark = txtRemark_ItemDetail.Value.Trim

                        db.SaveChanges()
                        tran.Complete()

                        Dim MtoT As New MoneyExt()
                        Select Case txtConsigneeCode.Value
                            Case "SG-1"
                                txtTotal_EASJOB.Value = "USD." & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                            Case "SG-2"
                                txtTotal_EASJOB.Value = "USD." & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                            Case "WD-1"
                                txtTotal_EASJOB.Value = "BAHT:" & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                            Case "WD-2"
                                txtTotal_EASJOB.Value = "USD." & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                            Case "HTI-01"
                                txtTotal_EASJOB.Value = "USD." & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                            Case "HTI"
                                txtTotal_EASJOB.Value = "USD." & MoneyExt.NumToEng(CDbl(txtTotalInvoice2_Invoice.Value))
                        End Select

                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                    End If
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        txtProductCode_ItemDetail.Focus()
    End Sub
    Private Sub InsertData()
        'sb.Append("INSERT INTO tblLogImpInvoice (InvoiceNo,InvoiceDate,ConsignneeCode,EASExporterCode,EASInvRefNo,EASLOTNo,EASShipMode,EASDeliveryTerm,ProductDesc1,ProductDesc2,ProductDesc3,OriginCountry,Quantity,PriceForeigh,PriceForeighAmount,PriceBathAmount,ExchangeRate,PLTNetAmount,CTNPLTName,CTNNetAmount,UnitCTNName,NetWeight,GrossWeight,UserBy,LastUpDate) ")
        'sb.Append(" VALUES (@InvoiceNo,@InvoiceDate,@ConsignneeCode,@EASExporterCode,@EASInvRefNo,@EASLOTNo,@EASShipMode,@EASDeliveryTerm,@ProductDesc1,@ProductDesc2,@ProductDesc3,@OriginCountry,@Quantity,@PriceForeigh,@PriceForeighAmount,@PriceBathAmount,@ExchangeRate,@PLTNetAmount,@CTNPLTName,@CTNNetAmount,@UnitCTNName,@NetWeight,@GrossWeight,@UserBy,@LastUpDate)")
        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()
                db.tblLogImpInvoices.Add(New tblLogImpInvoice With { _
                    .InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim, _
                    .InvoiceDate = txtdatepickerInvoiceDate_beforeTab.Text.Trim, _
                    .ConsignneeCode = txtConsigneeCode.Value.Trim, _
                    .EASExporterCode = txtOwnerCode_EASJOB.Value.Trim, _
                    .EASInvRefNo = txtEASINV_EASJOB.Value.Trim, _
                    .EASLOTNo = txtEASLOT_EASJOB.Value.Trim, _
                    .EASShipMode = ddlShipMode_EASJOB.Text.Trim, _
                    .EASDeliveryTerm = ddlDeliveryTerm_EASJOB.Text.Trim, _
                    .ProductDesc1 = txtProductDesc_ItemDetail.Value.Trim, _
                    .ProductDesc2 = txtCustomerPN_ItemDetail.Value.Trim, _
                    .ProductDesc3 = txtOwnerPN_ItemDetail.Value.Trim, _
                    .OriginCountry = ddlOriginCtry_ItemDetail.Text.Trim, _
                    .Quantity = CDbl(txtQuantity_ItemDetail.Value).ToString("#,##0.00000"), _
                    .PriceForeigh = CDbl(txtPriceForeign_ItemDetail.Value).ToString("#,##0.000"), _
                    .PriceForeighAmount = CDbl(txtAmountForeign_ItemDetail.Value).ToString("#,##0.000"), _
                    .PriceBathAmount = txtAmountBath_ItemDetail.Value.Trim, _
                    .ExchangeRate = CDbl(txtExchangeRate_ItemDetail.Value).ToString("#,##0.0000"), _
                    .PLTNetAmount = CDbl(txtPLTNetAmount_PACKINGLIST.Value).ToString("#,##0.000"), _
                    .CTNPLTName = txtPLTNetAmount2_PACKINGLIST.Value.Trim, _
                    .CTNNetAmount = CDbl(txtCTNNetAmount_PACKINGLIST.Value).ToString("#,##0.000"), _
                    .UnitCTNName = txtCTNNetAmount2_PACKINGLIST.Value.Trim, _
                    .NetWeight = CDbl(txtNetWeight_PACKINGLIST.Value).ToString("#,##0.00"), _
                    .GrossWeight = CDbl(txtGrossWeight_PACKINGLIST.Value).ToString("#,##0.00"), _
                    .UserBy = CStr(Session("UserId")), _
                    .LastUpDate = Now
                            })

                db.SaveChanges()
                tran.Complete()
            Catch ex As Exception
                'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try
        End Using
    End Sub

    Private Sub InsertDataDetail()
        'sb.Append("INSERT INTO tblLogImpInvoiceDetail (InvoiceNo,InvoiceDate,PLTAmount,CTNAmount,ProductDesc1,ProductDesc2,ProductDesc3,OriginCountry,Quantity,NetWeight,GrossWeight,Width,Hight,Leng,PackVolume,UserBy,LastUpDate) ")
        'sb.Append(" VALUES (@InvoiceNo,@InvoiceDate,@PLTAmount,@CTNAmount,@ProductDesc1,@ProductDesc2,@ProductDesc3,@OriginCountry,@Quantity,@NetWeight,@GrossWeight,@Width,@Hight,@Leng,@PackVolume,@UserBy,@LastUpDate)")
        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()
                db.tblLogImpInvoiceDetails.Add(New tblLogImpInvoiceDetail With { _
                    .InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim, _
                    .InvoiceDate = txtdatepickerInvoiceDate_beforeTab.Text.Trim, _
                    .PLTAmount = txtPLTNetAmount_PACKINGLIST.Value.Trim, _
                    .CTNAmount = txtTotalCTN_PACKINGLIST.Value.Trim, _
                    .ProductDesc1 = txtProductDesc_ItemDetail.Value.Trim, _
                    .ProductDesc2 = txtCustomerPN_ItemDetail.Value.Trim, _
                    .ProductDesc3 = txtOwnerPN_ItemDetail.Value.Trim, _
                    .OriginCountry = ddlOriginCtry_ItemDetail.Text.Trim, _
                    .Quantity = CDbl(txtQuantity_ItemDetail.Value).ToString("#,##0.00000"), _
                    .NetWeight = CDbl(txtNetWeight_PACKINGLIST.Value).ToString("#,##0.00"), _
                    .GrossWeight = CDbl(txtGrossWeight_PACKINGLIST.Value).ToString("#,##0.00"), _
                    .Width = CDbl(txtMeasurement_Width_PACKINGLIST.Value).ToString("#,##0"), _
                    .Hight = CDbl(txtMeasurement_Height_PACKINGLIST.Value).ToString("#,##0"), _
                    .Leng = CDbl(txtLenght_PACKINGLIST.Value).ToString("#,##0"), _
                    .PackVolume = CDbl(txtVolumeCBM_PACKINGLIST.Value).ToString("#,##0.000"), _
                    .UserBy = CStr(Session("UserId")), _
                    .LastUpDate = Now
                })

                db.SaveChanges()
                tran.Complete()
            Catch ex As Exception
                'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try
        End Using
    End Sub

    Private Sub InsertDataPackingList()
        'sb.Append("INSERT INTO tblLogImpPackingList (InvoiceNo,InvoiceDate,ConsignneeCode,EASExporterCode,EASInvRefNo,EASLOTNo,EASShipMode,EASDeliveryTerm,PLTAmount,CTNAmount,ProductDesc1,ProductDesc2,ProductDesc3,OriginCountry,Quantity,NetWeight,GrossWeight,Width,Hight,Leng,PackVolume,UserBy,LastUpDate) ")
        'sb.Append(" VALUES (@InvoiceNo,@InvoiceDate,@ConsignneeCode,@EASExporterCode,@EASInvRefNo,@EASLOTNo,@EASShipMode,@EASDeliveryTerm,@PLTAmount,@CTNAmount,@ProductDesc1,@ProductDesc2,@ProductDesc3,@OriginCountry,@Quantity,@NetWeight,@GrossWeight,@Width,@Hight,@Leng,@PackVolume,@UserBy,@LastUpDate)")
        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()
                db.tblLogImpPackingLists.Add(New tblLogImpPackingList With { _
                .InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim, _
                .InvoiceDate = txtdatepickerInvoiceDate_beforeTab.Text.Trim, _
                .ConsignneeCode = txtConsigneeCode.Value.Trim, _
                .EASExporterCode = txtOwnerCode_EASJOB.Value.Trim, _
                .EASInvRefNo = txtEASINV_EASJOB.Value.Trim, _
                .EASLOTNo = txtEASLOT_EASJOB.Value.Trim, _
                .EASShipMode = ddlShipMode_EASJOB.Text.Trim, _
                .EASDeliveryTerm = ddlDeliveryTerm_EASJOB.Text.Trim, _
                .PLTAmount = txtPLTNetAmount_PACKINGLIST.Value.Trim, _
                .CTNAmount = txtTotalCTN_PACKINGLIST.Value.Trim, _
                .ProductDesc1 = txtProductDesc_ItemDetail.Value.Trim, _
                .ProductDesc2 = txtCustomerPN_ItemDetail.Value.Trim, _
                .ProductDesc3 = txtOwnerPN_ItemDetail.Value.Trim, _
                .OriginCountry = ddlOriginCtry_ItemDetail.Text.Trim, _
                .Quantity = CDbl(txtQuantity_ItemDetail.Value).ToString("#,##0.00000"), _
                .NetWeight = CDbl(txtNetWeight_PACKINGLIST.Value).ToString("#,##0.00"), _
                .GrossWeight = CDbl(txtGrossWeight_PACKINGLIST.Value).ToString("#,##0.00"), _
                .Width = CDbl(txtMeasurement_Width_PACKINGLIST.Value).ToString("#,##0"), _
                .Hight = CDbl(txtMeasurement_Height_PACKINGLIST.Value).ToString("#,##0"), _
                .Leng = CDbl(txtLenght_PACKINGLIST.Value).ToString("#,##0"), _
                .PackVolume = CDbl(txtVolumeCBM_PACKINGLIST.Value).ToString("#,##0.000"), _
                .UserBy = CStr(Session("UserId")), _
                .LastUpDate = Now
                })

                db.SaveChanges()
                tran.Complete()
            Catch ex As Exception
                'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try
        End Using
    End Sub

    Private Sub ClearDATA()
        
        txtInvoiceNo_BeforeTab.Value = ""
        txtDeclaretion_BeforeTab.Value = ""
        txtJobNo_BeforeTab.Value = ""
        txtdatepickerInvoiceDate_beforeTab.Text = ""
        txtdatepickerDeliveryDate_beforeTab.Text = ""
        txtdatepickerCustomsRefDate_beforeTab.Text = ""
        txtShippercode.Value = ""
        txtNameShipper_Invoice.Value = ""
        txtAddress1Shipper.Value = ""
        txtAddress2Shipper.Value = ""
        txtAddress3Shipper.Value = ""
        txtAddress4Shipper.Value = ""
        txtAddress5Shipper.Value = ""
        txtEmailShipper.Value = ""
        txtConsigneeCode.Value = ""
        txtNameConsignee_Invoice.Value = ""
        txtAddress1Consignee.Value = ""
        txtAddress2Consignee.Value = ""
        txtAddress3Consignee.Value = ""
        txtAddress4Consignee.Value = ""
        txtAddress5Consignee.Value = ""
        txtEmailConsignee.Value = ""
        'ddlPurchaseCountry_Invoice.Text = ""
        txtPurchaseCountry_Invoice.Value = ""
        'ddlDestinationCountry_Invoice.Text = ""
        txtDestinationCountry_Invoice.Value = ""
        'ddlOriginCountry_Invoice.Text = ""
        txtOriginCountry_Invoice.Value = ""
        'ddlTermOfPayment_Invoice.Text = ""
        'ddlTerm_Invoice.Text = ""
        txtTotalNetWeight_Invoice.Value = ""
        txtSumItemWeight_Invoice.Value = ""
        'ddlTotalInvoice_Invoice.Text = ""
        txtTotalInvoice1_Invoice.Value = ""
        txtTotalInvoice2_Invoice.Value = ""
        'ddlForwarding_Invoice.Text = ""
        txtForwarding1_Invoice.Value = ""
        txtForwarding2_Invoice.Value = ""
        'ddlFreight_Invoice.Text = ""
        txtFreight1_Invoice.Value = ""
        txtFreight2_Invoice.Value = ""
        'ddlInsurance_Invoice.Text = ""
        txtInsurance1_Invoice.Value = ""
        txtInsurance2_Invoice.Value = ""
        'ddlPackingCharge_Invoice.Text = ""
        txtPackingCharge1_Invoice.Value = ""
        txtPackingCharge2_Invoice.Value = ""
        'ddlHandingCharge_Invoice.Text = ""
        txtHandingCharge1_Invoice.Value = ""
        txtHandingCharge2_invoice.Value = ""
        'ddlLandingCharge_Invoice.Text = ""
        txtLandingCharge1_Invoice.Value = ""
        txtLandingCharge2_Invoice.Value = ""
        'ddlTotalInvoiceTHB_Invoice.Text = ""
        txtTotalInvoiceTHB1_Invoice.Value = ""
        txtTotalInvoiceTHB2_Invoice.Value = ""
        txtdatepickerTransmitDate.Text = ""
        rdbDiffAmount1.Checked = False
        rdbDiffWeight1.Checked = False
        rdbNotifyParty1.Checked = False
        rdbOnBehalfOf1.Checked = False
        chkEnable.Checked = False
        txtOwnerCode_EASJOB.Value = ""
        txtNameOwner_EASJOB.Value = ""
        txtAddress1Owner_EASJOB.Value = ""
        txtAddress2Owner_EASJOB.Value = ""
        txtAddress3Owner_EASJOB.Value = ""
        txtAddress4Owner_EASJOB.Value = ""
        txtAddress5Owner_EASJOB.Value = ""
        txtEmailOwner_EASJOB.Value = ""
        txtCustomerCode_EASJOB.Value = ""
        txtNameCustomer_EASJOB.Value = ""
        txtAddressCustomer_EASJOB.Value = ""
        txtEmailCustomer_EASJOB.Value = ""
        txtTelNoCustomer_EASJOB.Value = ""
        txtFaxNoCustomer_EASJOB.Value = ""
        txtContractPersonCustomer_EASJOB.Value = ""
        txtEASINV_EASJOB.Value = ""
        txtEASLOT_EASJOB.Value = ""
        txtReferenceLine_EASJOB.Value = ""
        txtTruckWaybill_EASJOB.Value = ""
        'ddlShipMode_EASJOB.Text = ""
        'ddlDeliveryTerm_EASJOB.Text = ""
        'ddlShippingMark_EASJOB.Text = ""
        txtCompany_EASJOB.Value = ""
        txtAddressEAS_EASJOB.Value = ""
        txtRemarkEAS_EASJOB.Value = ""
        txtTotal_EASJOB.Value = ""
        txtCustomerCode_BillTo_EASJOB.Value = ""
        txtNameCustomer_BillTo_EASJOB.Value = ""
        txtAddressCustomer_BillTo_EASJOB.Value = ""
        txtEmailCustomer_BillTo_EASJOB.Value = ""
        txtTelNoCustomer_BillTo_EASJOB.Value = ""
        txtFaxNoCustomer_BillTo_EASJOB.Value = ""
        txtContractPersonCustomer_BillTo_EASJOB.Value = ""
        txtPLTNetAmount_PACKINGLIST.Value = ""
        'ddlPLTNetAmount_PACKINGLIST.Text = ""
        txtPLTNetAmount2_PACKINGLIST.Value = ""
        txtCTNNetAmount_PACKINGLIST.Value = ""
        'ddlCTNNetAmount_PACKINGLIST.Text = ""
        txtCTNNetAmount2_PACKINGLIST.Value = ""
        txtTotalGrossWeight_Invoice.Value = ""
        txtTotalQuantityPack_Invoice.Value = ""
        txtTotalVolume_Invoice.Value = ""
        txtTotal_PACKINGLIST.Value = ""
        'ddlTruckLicense_Invoice.Text = ""
        'ddlDriverName_Invoice.Text = ""
        txtdatepickerNoDate_beforeTab.Text = ""

    End Sub

    Private Sub Clear_ItemDATA()
        txtItemNo_ItemDetail.Value = ""
        txtInvoiceNo_BeforeTab.Value = ""
        txtProductYear_ItemDetail.Value = ""
        'ddlBrand_ItemDetail.Text = ""
        txtProductCode_ItemDetail.Value = ""
        'ddlNatureOfTRN_ItemDetail.Text = ""
        'ddlPurchaseCtry_ItemDetail.Text = ""
        'ddlOriginCtry_ItemDetail.Text = ""
        txtProductDesc_ItemDetail.Value = ""
        txtCustomerPN_ItemDetail.Value = ""
        txtOwnerPN_ItemDetail.Value = ""
        txtInvQty_ItemDetail.Value = ""
        'ddlUnit1_ItemDetail.Text = ""
        txtUnit1_ItemDetail.Value = ""
        txtWeight_ItemDetail.Value = ""
        'ddlUnit2_ItemDetail.Text = ""
        txtUnit2_ItemDetail.Value = ""
        txtQuantity_ItemDetail.Value = ""
        'ddlUnit3_ItemDetail.Text = ""
        txtUnit3_ItemDetail.Value = ""
        txtTariffCode_ItemDetail.Value = ""
        txtStatisticalCode_ItemDetail.Value = ""
        txtTariffSequence_ItemDetail.Value = ""
        txtProductAttribute1_ItemDetail.Value = ""
        txtPONo_ItemDetail.Value = ""
        txtPriceIncreaseForreign_ItemDetail.Value = ""
        txtPriceIncreaseBath_ItemDetail.Value = ""
        txtDeclaretionLine_ItemDetail.Value = ""
        txtFormulaNo_ItemDetail.Value = ""
        txtBOILicenseNo_ItemDetail.Value = ""
        txt19BisTransferNo_ItemDetail.Value = ""
        txtBondFormulaNo_ItemDetail.Value = ""
        'ddlCurrency_ItemDetail.Text = ""
        txtExchangeRate_ItemDetail.Value = ""
        txtPriceForeign_ItemDetail.Value = ""
        txtAmountForeign_ItemDetail.Value = ""
        txtPriceBath_ItemDetail.Value = ""
        txtAmountBath_ItemDetail.Value = ""
        'ddlForwarding_Currency_ItemDetail.Text = ""
        txtForwarding_ForeignAmount_ItemDetail.Value = ""
        txtForwarding_Exchange_ItemDetail.Value = ""
        txtForwarding_BathAmount_ItemDetail.Value = ""
        'ddlFreight_Currency_ItemDetail.Text = ""
        txtFreight_ForeignAmount_ItemDetail.Value = ""
        txtFreight_Exchange_ItemDetail.Value = ""
        txtFreight_BathAmount_ItemDetail.Value = ""
        'ddlInsurance_Currency_ItemDetail.Text = ""
        txtInsurance_ForeignAmount_ItemDetail.Value = ""
        txtInsurance_Exchange_ItemDetail.Value = ""
        txtInsurance_BathAmount_ItemDetail.Value = ""
        'ddlPackageCharge_Currency_ItemDetail1.Text = ""
        txtPackageCharge_ForeignAmount_ItemDetail.Value = ""
        txtPackageCharge_Exchange_ItemDetail.Value = ""
        txtPackageCharge_BathAmount_ItemDetail.Value = ""
        'ddlForeignInlandFreidge_Currency_ItemDetail1.Text = ""
        txtForeignInlandFreidge_ForeignAmount_ItemDetail.Value = ""
        txtForeignInlandFreidge_Exchange_ItemDetail.Value = ""
        txtForeignInlandFreidge_BathAmount_ItemDetail.Value = ""
        'ddlLandingCharge_Currency_ItemDetail1.Text = ""
        txtLandingCharge_ForeignAmount_ItemDetail.Value = ""
        txtLandingCharge_Exchange_ItemDetail.Value = ""
        txtLandingCharge_BathAmount_ItemDetail.Value = ""
        'ddlOtherCharge_Currency_ItemDetail1.Text = ""
        txtOtherCharge_ForeignAmount_ItemDetail.Value = ""
        txtOtherCharge_Exchange_ItemDetail.Value = ""
        txtOtherCharge_BathAmount_ItemDetail.Value = ""
        txtRemark_ItemDetail.Value = ""
    End Sub

    Private Sub Clear_PackingDATA()
        txtNumberOfPLT_PACKINGLIST.Value = "0"
        txtTotalCTN_PACKINGLIST.Value = "0"
        txtPLTQuantity_PACKINGLIST.Value = "0"
        txtProductCode_PACKINGLIST.Value = ""
        txtProductDesc_PACKINGLIST.Value = ""
        txtCustomerPN_PACKINGLIST.Value = ""
        txtOwnerPN_PACKINGLIST.Value = ""
        txtOriginCtry_PACKINGLIST.Value = ""
        txtOriginCtry2_PACKINGLIST.Value = ""
        'ddlUnit_PACKINGLIST.Text = ""
        txtUnit_PACKINGLIST.Value = ""
        txtProductQuantity_PACKINGLIST.Value = "0"
        txtNetWeight_PACKINGLIST.Value = "0.0"
        txtVolumeCBM_PACKINGLIST.Value = "0.0"
        txtGrossWeight_PACKINGLIST.Value = "0.0"
        txtMeasurement_Width_PACKINGLIST.Value = "0.0"
        txtMeasurement_Height_PACKINGLIST.Value = "0.0"
        txtLenght_PACKINGLIST.Value = "0.0"
        txtPONo_PACKINGLIST.Value = ""
        rdbCM.Checked = False
        rdbInch.Checked = False
    End Sub
    Protected Sub Unnamed_ServerClick5(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Unnamed_ServerClick6(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Unnamed_ServerClick7(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Unnamed_ServerClick8(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Unnamed_ServerClick9(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Unnamed_ServerClick10(sender As Object, e As EventArgs)

    End Sub
End Class