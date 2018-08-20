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

    Protected Sub btnAddNewItem_PACKINGLIST_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSaveModify_PACKINGLIST_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnDelete_PACKINGLIST_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnAddNewItem_ItemDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSaveModify_ItemDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnDelete_ItemDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnCreatePacking_ItemDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnGen_BeforeTab_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '---------------------------------------------Show All dll Country--------------------------------------------
    Private Sub showCountry()
        ddlOriginCountry_Invoice.Items.Clear()
        ddlOriginCountry_Invoice.Items.Add(New ListItem("--Select Country--", ""))
        ddlOriginCountry_Invoice.AppendDataBoundItems = True

        ddlPurchaseCountry_Invoice.Items.Clear()
        ddlPurchaseCountry_Invoice.Items.Add(New ListItem("--Select Country--", ""))
        ddlPurchaseCountry_Invoice.AppendDataBoundItems = True

        ddlDestinationCountry_Invoice.Items.Clear()
        ddlDestinationCountry_Invoice.Items.Add(New ListItem("--Select Country--", ""))
        ddlDestinationCountry_Invoice.AppendDataBoundItems = True

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
        ddlTermOfPayment_Invoice.Items.Clear()
        ddlTermOfPayment_Invoice.Items.Add(New ListItem("--Select Payment--", ""))
        ddlTermOfPayment_Invoice.AppendDataBoundItems = True

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
        ddlTerm_Invoice.Items.Clear()
        ddlTerm_Invoice.Items.Add(New ListItem("--Select Payment--", ""))
        ddlTerm_Invoice.AppendDataBoundItems = True

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
        ddlTotalInvoice_Invoice.Items.Clear()
        ddlTotalInvoice_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        ddlTotalInvoice_Invoice.AppendDataBoundItems = True

        ddlForwarding_Invoice.Items.Clear()
        ddlForwarding_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        ddlForwarding_Invoice.AppendDataBoundItems = True

        ddlFreight_Invoice.Items.Clear()
        ddlFreight_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        ddlFreight_Invoice.AppendDataBoundItems = True

        ddlInsurance_Invoice.Items.Clear()
        ddlInsurance_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        ddlInsurance_Invoice.AppendDataBoundItems = True

        ddlPackingCharge_Invoice.Items.Clear()
        ddlPackingCharge_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        ddlPackingCharge_Invoice.AppendDataBoundItems = True

        ddlHandingCharge_Invoice.Items.Clear()
        ddlHandingCharge_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        ddlHandingCharge_Invoice.AppendDataBoundItems = True

        ddlLandingCharge_Invoice.Items.Clear()
        ddlLandingCharge_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        ddlLandingCharge_Invoice.AppendDataBoundItems = True

        ddlTotalInvoiceTHB_Invoice.Items.Clear()
        ddlTotalInvoiceTHB_Invoice.Items.Add(New ListItem("--Select Currency--", ""))
        ddlTotalInvoiceTHB_Invoice.AppendDataBoundItems = True

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
        ddlTruckLicense_Invoice.Items.Clear()
        ddlTruckLicense_Invoice.Items.Add(New ListItem("--Select TruckLicense--", ""))
        ddlTruckLicense_Invoice.AppendDataBoundItems = True

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
        ddlDriverName_Invoice.Items.Clear()
        ddlDriverName_Invoice.Items.Add(New ListItem("--Select TruckDriver--", ""))
        ddlDriverName_Invoice.AppendDataBoundItems = True

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
        ddlShipMode_EASJOB.Items.Clear()
        ddlShipMode_EASJOB.Items.Add(New ListItem("--Select ShipMode--", ""))
        ddlShipMode_EASJOB.AppendDataBoundItems = True

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
        ddlDeliveryTerm_EASJOB.Items.Clear()
        ddlDeliveryTerm_EASJOB.Items.Add(New ListItem("--Select Delivery--", ""))
        ddlDeliveryTerm_EASJOB.AppendDataBoundItems = True

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
        ddlShippingMark_EASJOB.Items.Clear()
        ddlShippingMark_EASJOB.Items.Add(New ListItem("--Select Delivery--", ""))
        ddlShippingMark_EASJOB.AppendDataBoundItems = True

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

    End Sub
    '---------------------------------------------------------------------Click btn SaveEdit Method---------------------------------------------------
    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '---------------------------------------------------------------------SaveData Add Method---------------------------------------------------
    '   Private Sub SaveDATA_New()

    '       If txtInvoiceNo_BeforeTab.Value.Trim, _ = "" Then
    '           MsgBox("กรุณาป้อนรหัส Invoice No ก่อน !!!")
    '           txtInvoiceNo_BeforeTab.Focus()
    '           Exit Sub
    '       End If

    '       If txtShippercode.Value.Trim, _ = "" Then
    '           MsgBox("กรุณาป้อนรหัส Shipper Code ก่อน !!!")
    '           txtShippercode.Focus()
    '           Exit Sub
    '       End If

    '       If txtConsigneeCode.Value.Trim, _ = "" Then
    '           MsgBox("กรุณาป้อนรหัส Consignee Code ก่อน !!!")
    '           txtConsigneeCode.Focus()
    '           Exit Sub
    '       End If

    '       If rdbDiffAmount1.Checked = True Then
    '           DiffBy = "Diff by items-amount"
    '       End If

    '       If rdbDiffWeight1.Checked = True Then
    '           DiffBy = "Diff by items-Weight"
    '       End If

    '       If rdbNotifyParty1.Checked = True Then
    '           TermTransport = "Notfy Party"
    '       End If

    '       If rdbOnBehalfOf1.Checked = True Then
    '           TermTransport = "On Behalf of"
    '       End If

    '       If chkEnable.Checked = True Then
    '           OnbehalfStatus = "Enable On behalf of"
    '       Else
    '           OnbehalfStatus = "Disable On behalf of"
    '       End If

    '       'sb = New StringBuilder()
    '       'sb.Append("INSERT INTO tblImpInvoice (InvoiceNo,ReferenceNo,PurchaseOrderNo,InvoiceDate,DeliveryDate,ReferenceDate,ExporterCode,ExporterENG,Street_Number,District,Subprovince,Province,PostCode,CompensateCode,ConsignneeCode,ConsignneeENG,ConsignneeStreet_Number,ConsignneeDistrict,ConsignneeSubProvince,ConsignneeProvince,ConsignneePostCode,ConsignneeEMail,PurchaseCountryCode,PurchaseCountryName,DestinationCountryCode,")
    '       'sb.Append(" DestinationCountryName,CountryCode,CountryName,TermOfPayment,Term,TotalNetWeight,SumItemWeight,TotalInvoiceCurrency,TotalInvoiceAmount,TotalInvoiceAmount1,ForwardingCurrency,ForwardingAmount,ForwardingAmount1,FreightCurrency,FreightAmount,FreightAmount1,InsuranceCurrency,InsuranceAmount,InsuranceAmount1,PackingChargeCurrency,PackingChargeAmount,PackingChargeAmount1,ForeignInlandCurrency,ForeignInlandAmount,ForeignInlandAmount1,LandingChargeCurrency,")
    '       'sb.Append(" LandingChargeAmount,LandingChargeAmount1,OtherChargeCurrency,OtherChargeAmount,OtherChargeAmount1,TransmitDate,DiffBy,TermforShip,OnbehalfStatus,EASExporterCode,EASNameEng,StreetAndNumber,ESADistrict,EASSubProvince,EASProvince,EASPostCode,EASTCompensete,EASCustomerCode,EASCustomerENG,EASCustomerAddress,EASCustomerEMail,EASCustomerTelNo,EASCustomerFaxNo,")
    '       'sb.Append(" EASCustomerContactPerson,EASInvRefNo,EASLOTNo,EASCustomerRefNo,EASSpecialInstruction,EASShipMode,EASDeliveryTerm,EASShippingMark,EASShippingMarkCompany,EASShippingMarkAddress,EASRemark,EASTotalCurrency,EASBilltoCustomerCode,EASBilltoCustomerENG,EASBilltoCustomerAddress,EASBilltoCustomerEMail,EASBilltoCustomerTelNo,EASBilltoCustomerFaxNo,EASBilltoCustomerContactPerson,PLTNetAmount,UnitPLT,CTNPLTName,CTNNetAmount,UnitCTN,UnitCTNName,GrossWeightAmount,QountityAmount,VolumAmount,TotalTextPack,CarLicense,DriverName,PrintCountInv,PrintCountPack,PrintCount107,PrintCount108,PrintCountDoc,CustomsConfirmDate,App,CreateBy,CreateDate)")
    '       'sb.Append(" VALUES (@InvoiceNo,@ReferenceNo,@PurchaseOrderNo,@InvoiceDate,@DeliveryDate,@ReferenceDate,@ExporterCode,@ExporterENG,@Street_Number,@District,@Subprovince,@Province,@PostCode,@CompensateCode,@ConsignneeCode,@ConsignneeENG,@ConsignneeStreet_Number,@ConsignneeDistrict,@ConsignneeSubProvince,@ConsignneeProvince,@ConsignneePostCode,@ConsignneeEMail,@PurchaseCountryCode,@PurchaseCountryName,@DestinationCountryCode,")
    '       'sb.Append(" @DestinationCountryName,@CountryCode,@CountryName,@TermOfPayment,@Term,@TotalNetWeight,@SumItemWeight,@TotalInvoiceCurrency,@TotalInvoiceAmount,@TotalInvoiceAmount1,@ForwardingCurrency,@ForwardingAmount,@ForwardingAmount1,@FreightCurrency,@FreightAmount,@FreightAmount1,@InsuranceCurrency,@InsuranceAmount,@InsuranceAmount1,@PackingChargeCurrency,@PackingChargeAmount,@PackingChargeAmount1,@ForeignInlandCurrency,@ForeignInlandAmount,@ForeignInlandAmount1,@LandingChargeCurrency,")
    '       'sb.Append(" @LandingChargeAmount,@LandingChargeAmount1,@OtherChargeCurrency,@OtherChargeAmount,@OtherChargeAmount1,@TransmitDate,@DiffBy,@TermforShip,@OnbehalfStatus,@EASExporterCode,@EASNameEng,@StreetAndNumber,@ESADistrict,@EASSubProvince,@EASProvince,@EASPostCode,@EASTCompensete,@EASCustomerCode,@EASCustomerENG,@EASCustomerAddress,@EASCustomerEMail,@EASCustomerTelNo,@EASCustomerFaxNo,")
    '       'sb.Append(" @EASCustomerContactPerson,@EASInvRefNo,@EASLOTNo,@EASCustomerRefNo,@EASSpecialInstruction,@EASShipMode,@EASDeliveryTerm,@EASShippingMark,@EASShippingMarkCompany,@EASShippingMarkAddress,@EASRemark,@EASTotalCurrency,@EASBilltoCustomerCode,@EASBilltoCustomerENG,@EASBilltoCustomerAddress,@EASBilltoCustomerEMail,@EASBilltoCustomerTelNo,@EASBilltoCustomerFaxNo,@EASBilltoCustomerContactPerson,@PLTNetAmount,@UnitPLT,@CTNPLTName,@CTNNetAmount,@UnitCTN,@UnitCTNName,@GrossWeightAmount,@QountityAmount,@VolumAmount,@TotalTextPack,@CarLicense,@DriverName,@PrintCountInv,@PrintCountPack,@PrintCount107,@PrintCount108,@PrintCountDoc,@CustomsConfirmDate,@App,@CreateBy,@CreateDate)")

    '       If MsgBox("คุณต้องการเพิ่มรายการ LOT No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '           Using tran As New TransactionScope()
    '               Try
    '                   db.Database.Connection.Open()
    '                   db.tblImpInvoices.Add(New tblImpInvoice With { _
    '                   .InvoiceNo = txtInvoiceNo_BeforeTab.Value.Trim, _
    '                   .ReferenceNo  = txtDeclaretion_BeforeTab.Value.Trim, _
    '                   .PurchaseOrderNo  = txtJobNo_BeforeTab.Value.Trim, _
    '                   .InvoiceDate  = txtdatepickerInvoiceDate_beforeTab.Text.Trim, _
    '                   .DeliveryDate  = txtdatepickerDeliveryDate_beforeTab.Text.Trim, _
    '                   .ReferenceDate  = txtdatepickerCustomsRefDate_beforeTab.Text.Trim, _
    '                   .ExporterCode  = txtShippercode.Value.Trim, _
    '                   .ExporterENG  = txtNameShipper_Invoice.Value.Trim, _
    '                   .Street_Number  = txtAddress1Shipper.Value.Trim, _
    '                   .District  = txtAddress2Shipper.Value.Trim, _
    '                   .Subprovince  = txtAddress3Shipper.Value.Trim, _
    '                   .Province  = txtAddress4Shipper.Value.Trim, _
    '                   .PostCode  = txtAddress5Shipper.Value.Trim, _
    '                   .CompensateCode  = txtEmailShipper.Value.Trim, _
    '                   .ConsignneeCode  = txtConsigneeCode.Value.Trim, _
    '                   .ConsignneeENG  = txtNameConsignee_Invoice.Value.Trim, _
    '                   .ConsignneeStreet_Number  = txtAddress1Consignee.Value.Trim, _
    '                   .ConsignneeDistrict  = txtAddress2Consignee.Value.Trim, _
    '                   .ConsignneeSubProvince  = txtAddress3Consignee.Value.Trim, _
    '                   .ConsignneeProvince  = txtAddress4Consignee.Value.Trim, _
    '                   .ConsignneePostCode  = txtAddress5Consignee.Value.Trim, _
    '                   .ConsignneeEMail  = txtEmailConsignee.Value.Trim, _
    '                   .PurchaseCountryCode  = ddlPurchaseCountry_Invoice.Text.Trim, _
    '                   .PurchaseCountryName  = txtPurchaseCountry_Invoice.Value.Trim, _
    '                   .DestinationCountryCode  = ddlDestinationCountry_Invoice.Text.Trim, _
    '                   .DestinationCountryName  = txtDestinationCountry_Invoice.Value.Trim, _
    '                   .CountryCode  = ddlOriginCountry_Invoice.Text.Trim, _
    '                   .CountryName  = txtOriginCountry_Invoice.Value.Trim, _
    '                   .TermOfPayment  = ddlTermOfPayment_Invoice.Text.Trim, _
    '                   .Term  = ddlTerm_Invoice.Text.Trim, _
    '                   .TotalNetWeight = CDbl(txtTotalNetWeight_Invoice.Value).ToString("#,##0.000"), _
    '                   .SumItemWeight = CDbl(txtSumItemWeight_Invoice.Value).ToString("#,##0.000"), _
    '                   .TotalInvoiceCurrency  = ddlTotalInvoice_Invoice.Text.Trim, _
    '                   .TotalInvoiceAmount = CDbl(txtTotalInvoice1_Invoice.Value).ToString("#,##0.000"), _
    '                   .TotalInvoiceAmount1 = CDbl(txtTotalInvoice2_Invoice.Value).ToString("#,##0.000"), _
    '                   .ForwardingCurrency  = ddlForwarding_Invoice.Text.Trim, _
    '                   .ForwardingAmount = CDbl(txtForwarding1_Invoice.Value).ToString("#,##0.000"), _
    '                   .ForwardingAmount1 = CDbl(txtForwarding2_Invoice.Value).ToString("#,##0.000"), _
    '                   .FreightCurrency  = ddlFreight_Invoice.Text.Trim, _
    '                   .FreightAmount = CDbl(txtFreight1_Invoice.Value).ToString("#,##0.000"), _
    '                   .FreightAmount1 = CDbl(txtFreight2_Invoice.Value).ToString("#,##0.000"), _
    '                   .InsuranceCurrency  = ddlInsurance_Invoice.Text.Trim, _
    '                   .InsuranceAmount = CDbl(txtInsurance1_Invoice.Value).ToString("#,##0.000"), _
    '                   .InsuranceAmount1 = CDbl(txtInsurance2_Invoice.Value).ToString("#,##0.000"), _
    '                   .PackingChargeCurrency  = ddlPackingCharge_Invoice.Text.Trim, _
    '                   .PackingChargeAmount = CDbl(txtPackingCharge1_Invoice.Value).ToString("#,##0.000"), _
    '                   .PackingChargeAmount1 = CDbl(txtPackingCharge2_Invoice.Value).ToString("#,##0.000"), _
    '                   .ForeignInlandCurrency  = ddlHandingCharge_Invoice.Text.Trim, _
    '                   .ForeignInlandAmount = CDbl(txtHandingCharge1_Invoice.Value).ToString("#,##0.000"), _
    '                   .ForeignInlandAmount1 = CDbl(txtHandingCharge2_invoice.Value).ToString("#,##0.000"), _
    '                   .LandingChargeCurrency  = ddlLandingCharge_Invoice.Text.Trim, _
    '                   .LandingChargeAmount = CDbl(txtLandingCharge1_Invoice.Value).ToString("#,##0.000"), _
    '                   .LandingChargeAmount1 = CDbl(txtLandingCharge2_Invoice.Value).ToString("#,##0.000"), _
    '                   .OtherChargeCurrency  = ddlTotalInvoiceTHB_Invoice.Text.Trim, _
    '                   .OtherChargeAmount = CDbl(txtTotalInvoiceTHB1_Invoice.Value).ToString("#,##0.000"), _
    '                   .OtherChargeAmount1  = CDbl(txtTotalInvoiceTHB2_Invoice.Value).ToString("#,##0.000"), _
    '                   .TransmitDate  = txtdatepickerTransmitDate.Text.Trim, _
    '                   .DiffBy  = DiffBy, _
    '                   .TermforShip  = TermTransport, _
    '                   .OnbehalfStatus  = OnbehalfStatus, _
    '                   .EASExporterCode  = txtOwnerCode_EASJOB.Value.Trim, _
    '                   .EASNameEng  = txtNameOwner_EASJOB.Value.Trim, _
    '                   .StreetAndNumber  = txtAddress1Owner_EASJOB.Value.Trim, _
    '                   .ESADistrict  = txtAddress2Owner_EASJOB.Value.Trim, _
    '                   .EASSubProvince  = txtAddress3Owner_EASJOB.Value.Trim, _
    '                   .EASProvince  = txtAddress4Owner_EASJOB.Value.Trim, _
    '                   .EASPostCode  = txtAddress5Owner_EASJOB.Value.Trim, _
    '                   .EASTCompensete  = txtEmailOwner_EASJOB.Value.Trim, _
    '                   .EASCustomerCode  = txtCustomerCode_EASJOB.Value.Trim, _
    '                   .EASCustomerENG  = txtNameCustomer_EASJOB.Value.Trim, _
    '                   .EASCustomerAddress  = txtAddressCustomer_EASJOB.Value.Trim, _
    '                   .EASCustomerEMail  = txtEmailCustomer_EASJOB.Value.Trim, _
    '                   .EASCustomerTelNo  = txtTelNoCustomer_EASJOB.Value.Trim, _
    '                   .EASCustomerFaxNo  = txtFaxNoCustomer_EASJOB.Value.Trim, _
    '                   .EASCustomerContactPerson  = txtContractPersonCustomer_EASJOB.Value.Trim, _
    '                   .EASInvRefNo  = txtEASINV_EASJOB.Value.Trim, _
    '                   .EASLOTNo  = txtEASLOT_EASJOB.Value.Trim, _
    '                   .EASCustomerRefNo  = txtReferenceLine_EASJOB.Value.Trim, _
    '                   .EASSpecialInstruction  = txtTruckWaybill_EASJOB.Value.Trim, _
    '                   .EASShipMode  = ddlShipMode_EASJOB.Text.Trim, _
    '                   .EASDeliveryTerm  = ddlDeliveryTerm_EASJOB.Text.Trim, _
    '                   .EASShippingMark  = ddlShippingMark_EASJOB.Text.Trim, _
    '                   .EASShippingMarkCompany  = txtCompany_EASJOB.Value.Trim, _
    '                   .EASShippingMarkAddress  = txtAddressEAS_EASJOB.Value.Trim, _
    '                   .EASRemark  = txtRemarkEAS_EASJOB.Value.Trim, _
    '                   .EASTotalCurrency  = txtTotal_EASJOB.Value.Trim, _
    '                   .EASBilltoCustomerCode  = txtCustomerCode_BillTo_EASJOB.Value.Trim, _
    '                   .EASBilltoCustomerENG  = txtNameCustomer_BillTo_EASJOB.Value.Trim, _
    '                   .EASBilltoCustomerAddress  = txtAddressCustomer_BillTo_EASJOB.Value.Trim, _
    '                   .EASBilltoCustomerEMail  = txtEmailCustomer_BillTo_EASJOB.Value.Trim, _
    '                   .EASBilltoCustomerTelNo  = txtTelNoCustomer_BillTo_EASJOB.Value.Trim, _
    '                   .EASBilltoCustomerFaxNo  = txtFaxNoCustomer_BillTo_EASJOB.Value.Trim, _
    '                   .EASBilltoCustomerContactPerson  = txtContractPersonCustomer_BillTo_EASJOB.Value.Trim, _
    '                   .PLTNetAmount = CDbl(txtPLTNetAmount_PACKINGLIST.Value).ToString("#,##0.000"), _
    '                   .UnitPLT  = ddlPLTNetAmount_PACKINGLIST.Text.Trim, _
    '                   .CTNPLTName  = txtPLTNetAmount2_PACKINGLIST.Value.Trim, _
    '                   .CTNNetAmount = CDbl(txtCTNNetAmount_PACKINGLIST.Value).ToString("#,##0.000"), _
    '                   .UnitCTN  = ddlCTNNetAmount_PACKINGLIST.Text.Trim, _
    '                   .UnitCTNName  = txtCTNNetAmount2_PACKINGLIST.Value.Trim, _
    '                   '.GrossWeightAmount = CDbl(txtTotalGrossWeight.Text).ToString("#,##0.000"), _
    '                   '.QountityAmount = CDbl(txtTotalQuantity.Text).ToString("#,##0.000"), _
    '                   '.VolumAmount = CDbl(txtVolumAmount.Text).ToString("#,##0.000"), _
    '                   '.TotalTextPack  = txtTotalText.Text.Trim, _
    '                   '.CarLicense  = dcboCarLicense.Text.Trim, _
    '                   '.DriverName  = dcboDriverName.Text.Trim, _
    '                   '.PrintCountInv = "0"
    '                   '.PrintCountPack = "0"
    '                   '.PrintCount107 = "0"
    '                   '.PrintCount108 = "0"
    '                   '.PrintCountDoc = "0"
    '                   '.CustomsConfirmDate  = CustomsConfirmDate.Value.Trim, _
    '                   '.App = "Wait"
    '                   '.CreateBy  = DBConnString.UserName"
    '                   '.CreateDate  = Now"
    '                   '.ExecuteNonQuery()
    '})

    '                   db.SaveChanges()
    '                   tran.Complete()
    '                   ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Add สำเร็จ !');", True)

    '               Catch ex As Exception
    '                   ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
    '               Finally
    '                   db.Database.Connection.Close()
    '                   db.Dispose()
    '                   tran.Dispose()
    '               End Try
    '           End Using
    '       End If
    '       txtInvoiceNo_BeforeTab.Focus()
    '   End Sub 'saveเข้าtblImpInvoice

    Protected Sub Unnamed_ServerClick4(sender As Object, e As EventArgs)

    End Sub
End Class