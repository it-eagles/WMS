Public Class InvoicePackingListRec
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1_Test

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
        showListShipper()
        showListConsignee()
        showListCustomerCode()
        showListCustomerCode_BillTo()
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
End Class