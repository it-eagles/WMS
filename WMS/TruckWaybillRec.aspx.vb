Public Class TruckWaybillRec
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1_Test

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        showListNotifyParty()
        showListShipper()
        showListConsignee()
        showListInvoiceNo()
        showListProductCode()
    End Sub


    '--------------------------------------------------------Show Data NotifyParty In Modal-----------------------------------------
    Public Sub showListNotifyParty()

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
    '--------------------------------------------------------Click Data NotifyParty In Modal-----------------------------------------
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectNotifyParty") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtNotifyPartyCode.Value = user.u.PartyFullName
                    txtNotifyPartyName.Value = user.br.Address1


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
                    txtNameShipper.Value = user.u.PartyFullName
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
            Repeater3.DataSource = user
            Repeater3.DataBind()
        Else
            Me.Repeater3.DataSource = Nothing
            Me.Repeater3.DataBind()
        End If
    End Sub
    '--------------------------------------------------------Click Data Consignee In Modal-----------------------------------------
    Protected Sub Repeater3_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater3.ItemCommand
        Dim PartyCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectConsignee") Then

                If String.IsNullOrEmpty(PartyCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

                    txtConsigneeCodee.Value = user.u.PartyCode
                    txtNameConsignee.Value = user.u.PartyFullName
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
    '--------------------------------------------------------Show Data InvoiceNo In Modal-----------------------------------------
    Public Sub showListInvoiceNo()

        Dim user = (From u In db.tblExpInvoices
                   Select New With {u.InvoiceNo,
                                    u.PLTNetAmount,
                                    u.GrossWeightAmount,
                                    u.VolumAmount,
                                    u.EASLOTNo}).ToList()


        If user.Count > 0 Then
            Repeater4.DataSource = user
            Repeater4.DataBind()
        Else
            Me.Repeater4.DataSource = Nothing
            Me.Repeater4.DataBind()
        End If
    End Sub
    '--------------------------------------------------------Click Data InvoiceNo In Modal-----------------------------------------
    Protected Sub Repeater4_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater4.ItemCommand
        Dim InvoiceNo As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectInvoiceNo") Then

                If String.IsNullOrEmpty(InvoiceNo) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblExpInvoices Where u.InvoiceNo = InvoiceNo).SingleOrDefault

                    txtInvoiceNoo.Value = user.InvoiceNo
                    txtLOTNo.Value = user.EASLOTNo
                    txtQuantity_Detail.Value = user.PLTNetAmount
                    txtGrossWeight_Detail.Value = user.GrossWeightAmount
                    txtMeasurement_Detail.Value = user.VolumAmount

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data ProductCode In Modal-----------------------------------------
    Public Sub showListProductCode()

        Dim user = (From u In db.tblProductDetails
                   Select New With {u.ProductCode,
                                    u.ImpDesc1,
                                    u.PONo,
                                    u.CustomerPart,
                                    u.EndUserPart}).ToList()

        If user.Count > 0 Then
            Repeater5.DataSource = user
            Repeater5.DataBind()
        Else
            Me.Repeater5.DataSource = Nothing
            Me.Repeater5.DataBind()
        End If
    End Sub
    '--------------------------------------------------------Click Data ProductCode In Modal-----------------------------------------
    Protected Sub Repeater5_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater5.ItemCommand
        Dim ProductCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectProductCode") Then

                If String.IsNullOrEmpty(ProductCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblProductDetails Where u.ProductCode = ProductCode).SingleOrDefault

                    txtPartDesc.Value = user.ImpDesc1
                    txtOwnP_N.Value = user.CustomerPart
                    txtCustomerP_N.Value = user.EndUserPart
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class