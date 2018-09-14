
Imports System.Transactions
Imports System.Globalization

Public Class TruckWaybillRec
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmTruckWayBillImp"
        If Not Me.IsPostBack Then
            If classPermis.CheckRead(form, usename) = True Then
                If Not IsPostBack Then
                    showUnit()
                    showCounOfOri()
                    btnSaveAddHead.Visible = False
                    btnSaveEditHead.Visible = False
                    btnSearchTruck.Visible = False

                    truckwaybillhead_fieldset.Disabled = True
                    truckwaybilldetail_fieldset.Disabled = True


                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
            End If
        End If
        'showListNotifyParty()
        'showListShipper()
        'showListConsignee()
        'showListInvoiceNo()
        'showListProductCode()
    End Sub
    '----------------------------------------------------------------Show ddl Unit--------------------------------------------------------
    Private Sub showUnit()

        Dim gg = From g In db.tblMasterCodes Where g.Type = "Unit"
                  Select g.Type, g.Code
        Try
            ddlUnit_GrossWeight.DataSource = gg.ToList
            ddlUnit_GrossWeight.DataTextField = "Code"
            ddlUnit_GrossWeight.DataValueField = "Code"
            ddlUnit_GrossWeight.DataBind()

            ddlUnitQuantity_Detail.DataSource = gg.ToList
            ddlUnitQuantity_Detail.DataTextField = "Code"
            ddlUnitQuantity_Detail.DataValueField = "Code"
            ddlUnitQuantity_Detail.DataBind()

            If ddlUnit_GrossWeight.Items.Count > 1 Then
                ddlUnit_GrossWeight.Enabled = True
            Else
                ddlUnit_GrossWeight.Enabled = False
            End If

            If ddlUnitQuantity_Detail.Items.Count > 1 Then
                ddlUnitQuantity_Detail.Enabled = True
            Else
                ddlUnitQuantity_Detail.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------------Show ddl Country Of Origin--------------------------------------------------------
    Private Sub showCounOfOri()
        Dim gg = From g In db.tblMasterCodes Where g.Type = "COUNTRY"
                  Select g.Type, g.Code
        Try
            ddlCountryOfOrigin.DataSource = gg.ToList
            ddlCountryOfOrigin.DataTextField = "Code"
            ddlCountryOfOrigin.DataValueField = "Code"
            ddlCountryOfOrigin.DataBind()
            If ddlCountryOfOrigin.Items.Count > 1 Then
                ddlCountryOfOrigin.Enabled = True
            Else
                ddlCountryOfOrigin.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    '--------------------------------------------------------Show Data NotifyParty In Modal-----------------------------------------
    Public Sub showListNotifyParty()

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
    '--------------------------------------------------------Show Data NotifyParty In Modal-----------------------------------------
    Private Sub selectNotifyPartyCode()
        Dim Nottify_code As String
        Dim shipper_ As String = ""
        If String.IsNullOrEmpty(txtNotifyPartyCode.Value.Trim) Then
            Nottify_code = ""
            shipper_ = "0"
        Else
            Nottify_code = txtNotifyPartyCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Nottify_code And p.Consignee = "0") Or p.Consignee = shipper_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater1.DataSource = cons.ToList
            Repeater1.DataBind()
            ScriptManager.RegisterStartupScript(NofityPartyUpdatePanel, NofityPartyUpdatePanel.GetType(), "show", "$(function () { $('#" + NofityPartyPanel.ClientID + "').modal('show'); });", True)
            NofityPartyUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล NofityParty Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search NofityParty Code-----------------------------------------------
    Protected Sub Unnamed_ServerClick(sender As Object, e As EventArgs)
        selectNotifyPartyCode()
    End Sub
    '--------------------------------------------------------Click Data NotifyParty In Modal-----------------------------------------
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        'Dim PartyCode As String = CStr(e.CommandArgument)
        'Try
        '    If e.CommandName.Equals("SelectNotifyParty") Then

        '        If String.IsNullOrEmpty(PartyCode) Then

        '            MsgBox("เป็นค่าว่าง")
        '        Else
        '            Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

        '            txtNotifyPartyCode.Value = user.u.PartyFullName
        '            txtNotifyPartyName.Value = user.br.Address1


        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Protected Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound

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
    Protected Sub clicknotifyparty_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As String = TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = lblPartyCode And u.Consignee = "0" And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault
        txtNotifyPartyCode.Value = user.u.PartyFullName
        txtNotifyPartyName.Value = user.br.Address1
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
    '--------------------------------------------------------------Click Search Shipper Code-----------------------------------------------
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
        '            txtNameShipper.Value = user.u.PartyFullName
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
        Dim lblPartyAddressCode As String = TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = lblPartyCode And u.Consignee = "0").SingleOrDefault
        txtShippercode.Value = user.u.PartyCode
        txtNameShipper.Value = user.u.PartyFullName
        txtAddress1Shipper.Value = user.br.Address1
        txtAddress2Shipper.Value = user.br.Address2
        txtAddress3Shipper.Value = user.br.Address3
        txtAddress4Shipper.Value = user.br.Address4
        txtAddress5Shipper.Value = user.br.ZipCode
        txtEmailShipper.Value = user.br.email
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
        '    Repeater3.DataSource = user
        '    Repeater3.DataBind()
        'Else
        '    Me.Repeater3.DataSource = Nothing
        '    Me.Repeater3.DataBind()
        'End If
    End Sub
    '--------------------------------------------------------Show Data Consignee In Modal-----------------------------------------
    Private Sub selectConsigneeCode()
        Dim cons_code As String
        Dim shipper_ As String = ""
        If String.IsNullOrEmpty(txtConsigneeCodee.Value.Trim) Then
            cons_code = ""
            shipper_ = "0"
        Else
            cons_code = txtConsigneeCodee.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = shipper_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater3.DataSource = cons.ToList
            Repeater3.DataBind()
            ScriptManager.RegisterStartupScript(ConsigneeUpdatePanel, ConsigneeUpdatePanel.GetType(), "show", "$(function () { $('#" + ConsigneePanel.ClientID + "').modal('show'); });", True)
            ConsigneeUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Consignee Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Consignee Code-----------------------------------------------
    Protected Sub Unnamed_ServerClick2(sender As Object, e As EventArgs)
        selectConsigneeCode()
    End Sub
    '--------------------------------------------------------Click Data Consignee In Modal-----------------------------------------
    Protected Sub Repeater3_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater3.ItemCommand
        'Dim PartyCode As String = CStr(e.CommandArgument)
        'Try
        '    If e.CommandName.Equals("SelectConsignee") Then

        '        If String.IsNullOrEmpty(PartyCode) Then

        '            MsgBox("เป็นค่าว่าง")
        '        Else
        '            Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = PartyCode And u.Consignee = "0").SingleOrDefault

        '            txtConsigneeCodee.Value = user.u.PartyCode
        '            txtNameConsignee.Value = user.u.PartyFullName
        '            txtAddress1Consignee.Value = user.br.Address1
        '            txtAddress2Consignee.Value = user.br.Address2
        '            txtAddress3Consignee.Value = user.br.Address3
        '            txtAddress4Consignee.Value = user.br.Address4
        '            txtAddress5Consignee.Value = user.br.ZipCode
        '            txtEmailConsignee.Value = user.br.email

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
    Protected Sub clickconsignee_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As String = TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode Where u.PartyCode = lblPartyCode And u.Consignee = "0" And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault
        txtConsigneeCodee.Value = user.u.PartyCode
        txtNameConsignee.Value = user.u.PartyFullName
        txtAddress1Consignee.Value = user.br.Address1
        txtAddress2Consignee.Value = user.br.Address2
        txtAddress3Consignee.Value = user.br.Address3
        txtAddress4Consignee.Value = user.br.Address4
        txtAddress5Consignee.Value = user.br.ZipCode
        txtEmailConsignee.Value = user.br.email
    End Sub
    '--------------------------------------------------------Show Data InvoiceNo In Modal-----------------------------------------
    Public Sub showListInvoiceNo()

        'Dim user = (From u In db.tblExpInvoices
        '           Select New With {u.InvoiceNo,
        '                            u.PLTNetAmount,
        '                            u.GrossWeightAmount,
        '                            u.VolumAmount,
        '                            u.EASLOTNo}).ToList()


        'If user.Count > 0 Then
        '    Repeater4.DataSource = user
        '    Repeater4.DataBind()
        'Else
        '    Me.Repeater4.DataSource = Nothing
        '    Me.Repeater4.DataBind()
        'End If
    End Sub
    '--------------------------------------------------------Show Data InvoiceNo In Modal-----------------------------------------
    Private Sub selectInvoiceNoCode()
        Dim intvoice_code As Integer
        Dim textinv As String = ""
        If String.IsNullOrEmpty(txtInvoiceNoo.Value.Trim) Then
            intvoice_code = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))

        Else
            textinv = txtInvoiceNoo.Value.Trim
        End If
        'Where u.InvoiceNo = textinv Or u.CreateDate.Year = intvoice_code
        'Where u.InvoiceNo = textinv
        Dim cons = (From u In db.tblExpInvoices
                    Where u.InvoiceNo = textinv Or u.CreateDate.Year = intvoice_code
                   Select New With {u.InvoiceNo,
                                    u.PLTNetAmount,
                                    u.GrossWeightAmount,
                                    u.VolumAmount,
                                    u.EASLOTNo}).ToList()

        If cons.Count > 0 Then
            Repeater4.DataSource = cons.ToList
            Repeater4.DataBind()
            ScriptManager.RegisterStartupScript(InvoiceUpdatePanel, InvoiceUpdatePanel.GetType(), "show", "$(function () { $('#" + InvoicePanel.ClientID + "').modal('show'); });", True)
            InvoiceUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Consignee Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search InvoiceNo Code-----------------------------------------------
    Protected Sub Unnamed_ServerClick3(sender As Object, e As EventArgs)
        selectInvoiceNoCode()
    End Sub
    '--------------------------------------------------------Click Data InvoiceNo In Modal-----------------------------------------
    Protected Sub Repeater4_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater4.ItemCommand
        Dim InvoiceNo As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectInvoiceNo") Then

                If String.IsNullOrEmpty(InvoiceNo) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เป็นค่าว่าง');", True)
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
        Dim testdate As Integer
        Dim ProCode As String = ""
        If String.IsNullOrEmpty(txtPartDesc.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            ProCode = txtPartDesc.Value.Trim
        End If

        Dim user = (From u In db.tblProductDetails
                    Where u.ProductCode = ProCode Or u.CreateDate.Year = testdate
                   Select New With {u.ProductCode,
                                    u.ImpDesc1,
                                    u.PONo,
                                    u.CustomerPart,
                                    u.EndUserPart}).ToList()

        If user.Count > 0 Then
            Repeater5.DataSource = user
            Repeater5.DataBind()
            ScriptManager.RegisterStartupScript(PartDescUpdatePanel, PartDescUpdatePanel.GetType(), "show", "$(function () { $('#" + PartDescPanel.ClientID + "').modal('show'); });", True)
            PartDescUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Part Desc Code นี้')", True)
        End If
    End Sub
    Protected Sub btnPartDesc_ServerClick(sender As Object, e As EventArgs)
        showListProductCode()
    End Sub
    '--------------------------------------------------------Click Data ProductCode In Modal-----------------------------------------
    Protected Sub Repeater5_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater5.ItemCommand
        Dim ProductCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectProductCode") Then

                If String.IsNullOrEmpty(ProductCode) Then

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เป็นค่าว่าง');", True)
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

    Private Sub selecttruckno()
        Dim testdate As Integer
        Dim lot As String
        If String.IsNullOrEmpty(txtTruckW_B.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            lot = txtTruckW_B.Value.Trim
        End If

        'Where e.LOTDate.Year = testdate
        Dim exl = (From e In db.tblTruckWayBillImps Where e.TruckWayBillNo = txtTruckW_B.Value.Trim Or e.ReceivedDate.Year = testdate Order By e.TruckWayBillNo Descending
                 Select New With {
                 e.TruckWayBillNo,
                 e.PlaceCode,
                 e.ExporterCode,
                 e.ConsignneeCode}).ToList
        Try
            If exl.Count > 0 Then
                Me.Repeater6.DataSource = exl
                Me.Repeater6.DataBind()
                ScriptManager.RegisterStartupScript(TrucknoUpdatePanel, TrucknoUpdatePanel.GetType(), "show", "$(function () { $('#" + TrucknoPanel.ClientID + "').modal('show'); });", True)
                TrucknoUpdatePanel.Update()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล TruckNo นี้')", True)
                Exit Sub
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", ex.Message, True)
        End Try
    End Sub
    '--------------------------------------------------------------Click Search Truck NO--------------------------------------------------
    Protected Sub btnSearchTruck_ServerClick(sender As Object, e As EventArgs)
        selecttruckno()
    End Sub
    Protected Sub Repeater6_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim TruckWayBillNo As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("selectTruckNO") Then
            Dim exp = (From ex In db.tblTruckWayBillImps Where ex.TruckWayBillNo = TruckWayBillNo).SingleOrDefault
            txtTruckW_B.Value = exp.TruckWayBillNo
            txtdatepickerReceivedDate.Text = exp.ReceivedDate
            txtdatepickerDateOfIssue.Text = exp.Dateofissue
            txtNoOfOriginals.Value = exp.NoofOriginals
            txtNotifyParty.Value = exp.NotifyPatty
            txtDeliveryOfGoods.Value = exp.DeliveryofGoods
            txtCarLicense.Value = exp.CarLicense
            txtDriverName.Value = exp.DriverName
            txtFreightCharges.Value = exp.FreightCharges
            txtPrepaid.Value = exp.Prepaid
            txtQuantityAmount.Value = exp.QuantityAmount
            txtGrossWeight.Value = exp.GrossWeightAmount
            txtMeasurement.Value = exp.Measurement
            txtShippercode.Value = exp.ExporterCode
            txtNameShipper.Value = exp.NameEng
            txtAddress1Shipper.Value = exp.StreetAddress
            txtAddress2Shipper.Value = exp.District
            txtAddress3Shipper.Value = exp.SubProvince
            txtAddress4Shipper.Value = exp.Province
            txtAddress5Shipper.Value = exp.PostCode
            txtEmailShipper.Value = exp.CodeReturn
            txtConsigneeCodee.Value = exp.ConsignneeCode
            txtNameConsignee.Value = exp.ConsignNameEng
            txtAddress1Consignee.Value = exp.ConsingStreetNumber
            txtAddress2Consignee.Value = exp.ConsignDistrict
            txtAddress3Consignee.Value = exp.ConsignSubProvince
            txtAddress4Consignee.Value = exp.ConsgnProvince
            txtAddress5Consignee.Value = exp.ConsignPostCode
            txtEmailConsignee.Value = exp.ConsignEmail
            txtNotifyPartyCode.Value = exp.PlaceCode
            txtNotifyPartyName.Value = exp.PlaceName
            txtNotifyPartyAddress.Value = exp.PlaceAddress
            txtPlaceOfReceipt.Value = exp.PlaceofReceipt

            ReadDATA()
            CalculateTotalTruckWaybill()
            txtTruckW_B.Focus()
        End If
    End Sub
    '---------------------------------------------------------------Save Data New---------------------------------------------
    Private Sub SaveDATA_New()
        Dim ReceivedDate As Date
        Dim DateOfIssue As Date


        'If txtTruckW_B.Value.Trim() = "" Then
        '    MsgBox("กรุณาป้อน TruckWayBill No ก่อน !!!")
        '    'UnlockDATA()
        '    txtTruckW_B.Focus()
        '    Exit Sub
        'End If

        If txtShippercode.Value.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Exporter No ก่อน !!!');", True)
            'UnlockDATA()
            txtShippercode.Focus()
            Exit Sub
        End If

        If txtConsigneeCodee.Value.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Consignnee No ก่อน !!!');", True)
            'UnlockDATA()
            txtConsigneeCodee.Focus()
            Exit Sub
        End If

        If txtdatepickerReceivedDate.Text = "" Then
            ReceivedDate = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            ReceivedDate = DateTime.ParseExact(txtdatepickerReceivedDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If txtdatepickerDateOfIssue.Text = "" Then
            DateOfIssue = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            DateOfIssue = DateTime.ParseExact(txtdatepickerDateOfIssue.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If

        If MsgBox("คุณต้องการเพิ่มรายการ TruckWayBillImp ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    'sb = New StringBuilder()
                    'sb.Append("INSERT INTO tblTruckWayBillImp (TruckWayBillNo,ReceivedDate,Dateofissue,NoofOriginals,NotifyPatty,DeliveryofGoods,CarLicense,DriverName,FreightCharges,Prepaid,QuantityAmount,GrossWeightAmount,Measurement,ExporterCode,NameEng,StreetAddress,District,SubProvince,Province,PostCode,CodeReturn,ConsignneeCode,ConsignNameEng,ConsingStreetNumber,ConsignDistrict,ConsignSubProvince,ConsgnProvince,ConsignPostCode,ConsignEmail,PlaceCode,PlaceName,PlaceAddress,PlaceofReceipt)")
                    'sb.Append(" VALUES (@TruckWayBillNo,@ReceivedDate,@Dateofissue,@NoofOriginals,@NotifyPatty,@DeliveryofGoods,@CarLicense,@DriverName,@FreightCharges,@Prepaid,@QuantityAmount,@GrossWeightAmount,@Measurement,@ExporterCode,@NameEng,@StreetAddress,@District,@SubProvince,@Province,@PostCode,@CodeReturn,@ConsignneeCode,@ConsignNameEng,@ConsingStreetNumber,@ConsignDistrict,@ConsignSubProvince,@ConsgnProvince,@ConsignPostCode,@ConsignEmail,@PlaceCode,@PlaceName,@PlaceAddress,PlaceofReceipt)"
                    db.tblTruckWayBillImps.Add(New tblTruckWayBillImp With { _
                   .TruckWayBillNo = txtTruckW_B.Value.Trim, _
                   .ReceivedDate = ReceivedDate, _
                   .Dateofissue = DateOfIssue, _
                   .NoofOriginals = txtNoOfOriginals.Value.Trim, _
                   .NotifyPatty = txtNotifyParty.Value.Trim, _
                   .DeliveryofGoods = txtDeliveryOfGoods.Value.Trim, _
                   .CarLicense = txtCarLicense.Value.Trim, _
                   .DriverName = txtDriverName.Value.Trim, _
                   .FreightCharges = txtFreightCharges.Value.Trim, _
                   .Prepaid = txtPrepaid.Value.Trim, _
                   .QuantityAmount = txtQuantityAmount.Value.Trim, _
                   .GrossWeightAmount = txtGrossWeight.Value.Trim, _
                   .Measurement = txtMeasurement.Value.Trim, _
                   .ExporterCode = txtShippercode.Value.Trim, _
                   .NameEng = txtNameShipper.Value.Trim, _
                   .StreetAddress = txtAddress1Shipper.Value.Trim, _
                   .District = txtAddress2Shipper.Value.Trim, _
                   .SubProvince = txtAddress3Shipper.Value.Trim, _
                   .Province = txtAddress4Shipper.Value.Trim, _
                   .PostCode = txtAddress5Shipper.Value.Trim, _
                   .CodeReturn = txtEmailShipper.Value.Trim, _
                   .ConsignneeCode = txtConsigneeCodee.Value.Trim, _
                   .ConsignNameEng = txtNameConsignee.Value.Trim, _
                   .ConsingStreetNumber = txtAddress1Consignee.Value.Trim, _
                   .ConsignDistrict = txtAddress2Consignee.Value.Trim, _
                   .ConsignSubProvince = txtAddress3Consignee.Value.Trim, _
                   .ConsgnProvince = txtAddress4Consignee.Value.Trim, _
                   .ConsignPostCode = txtAddress5Consignee.Value.Trim, _
                   .ConsignEmail = txtEmailConsignee.Value.Trim, _
                   .PlaceCode = txtNotifyPartyCode.Value.Trim, _
                   .PlaceName = txtNotifyPartyName.Value.Trim, _
                   .PlaceAddress = txtNotifyPartyAddress.Value.Trim, _
                   .PlaceofReceipt = txtPlaceOfReceipt.Value.Trim
                   })

                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Add สำเร็จ !');", True)

                Catch
                    'MessageBox.Show("คุณป้อน ข้อมูล. ซ้ำ !!!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'tr.Rollback()
                    'UnlockDATA()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)

                Finally

                    'db.Dispose()
                    'tran.Dispose()
                End Try
            End Using
        End If
        txtTruckW_B.Focus()
    End Sub
    '--------------------------------------------------Save Data Modify-----------------------------------------------
    Private Sub SaveDATA_Modify()
        'Dim ReceivedDate As Date
        'Dim DateOfIssue As Date
        Dim TruckNooo As String = Request.QueryString("TruckWayBillNo")
        If txtTruckW_B.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาเลือก Truck No ก่อน !!!');", True)
            'UnlockDATA()
            txtTruckW_B.Focus()
            Exit Sub
        End If

        'If txtdatepickerReceivedDate.Text = "" Then
        '    ReceivedDate = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        'Else
        '    ReceivedDate = DateTime.ParseExact(txtdatepickerReceivedDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        'End If
        'If txtdatepickerDateOfIssue.Text = "" Then
        '    DateOfIssue = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        'Else
        '    DateOfIssue = DateTime.ParseExact(txtdatepickerDateOfIssue.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        'End If

        If MsgBox("คุณต้องการแก้ไขรายการ Truck No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    'sb = New StringBuilder()
                    'sb.Append("UPDATE tblImpGenLOT")
                    'sb.Append(" SET EASLOTNo=@EASLOTNo,LOTDate=@LOTDate,LOTBy=@LOTBy,SalesCode=@SalesCode,SalesName=@SalesName,ConsigneeCode=@ConsigneeCode,ConsignNameEng=@ConsignNameEng,ConsignAddress=@ConsignAddress,ConsignDistrict=@ConsignDistrict,ConsignSubProvince=@ConsignSubProvince,ConsignProvince=@ConsignProvince,ConsignPostCode=@ConsignPostCode,ConsignEmail=@ConsignEmail,ShipperCode=@ShipperCode,ShipperNameEng=@ShipperNameEng,ShipperAddress=@ShipperAddress,ShipperDistrict=@ShipperDistrict,ShipperSubprovince=@ShipperSubprovince,ShipperProvince=@ShipperProvince,ShipperPostCode=@ShipperPostCode,ShipperReturnCode=@ShipperReturnCode,Commodity=@Commodity,QuantityofPart=@QuantityofPart,QuantityUnit=@QuantityUnit,QuantityPack=@QuantityPack,QuantityUnitPack=@QuantityUnitPack,Weight=@Weight,WeightUnit=@WeightUnit,Volume=@Volume,VolumeUnit=@VolumeUnit,MAWB=@MAWB,DocType=@DocType,DocCode=@DocCode,Flight=@Flight,DOCode=@DOCode,DONameENG=@DONameENG,DOStreet_Number=@DOStreet_Number,DODistrict=@DODistrict,DOSubProvince=@DOSubProvince,DOProvince=@DOProvince,DOPostCode=@DOPostCode,DOEmail=@DOEmail,DOContactPerson=@DOContactPerson,IEATNo=@IEATNo,EntryNo=@EntryNo,DeliveryDate=@DeliveryDate,CustomerCode=@CustomerCode,CustomerENG=@CustomerENG,CustomerStreet=@CustomerStreet,CustomerDistrict=@CustomerDistrict,CustomerSub=@CustomerSub,CustomerProvince=@CustomerProvince,CustomerPostCode=@CustomerPostCode,CustomerEmail=@CustomerEmail,CustomerContact=@CustomerContact,PickUpCode=@PickUpCode,PickUpENG=@PickUpENG,PickUpAddress1=@PickUpAddress1,PickUpAddress2=@PickUpAddress2,PickUpAddress3=@PickUpAddress3,PickUpAddress4=@PickUpAddress4,PickUpAddress5=@PickUpAddress5,PickUpEmail=@PickUpEmail,PickUpContact=@PickUpContact,EndCusCode=@EndCusCode,EndCusENG=@EndCusENG,EndCusAddress1=@EndCusAddress1,EndCusAddress2=@EndCusAddress2,EndCusAddress3=@EndCusAddress3,EndCusAddress4=@EndCusAddress4,EndCusAddress5=@EndCusAddress5,EndCusEmail=@EndCusEmail,EndCusContact=@EndCusContact,FreighForwarder=@FreighForwarder,Useby=@Useby,IEATPermit=@IEATPermit,ShipTo=@ShipTo,Remark=@Remark,FLT1=@FLT1,FLT2=@FLT2,FLT3=@FLT3,FLT4=@FLT4,DateFLT1=@DateFLT1,DateFLT2=@DateFLT2,DateFLT3=@DateFLT3,DateFLT4=@DateFLT4,ORGN1=@ORGN1,ORGN2=@ORGN2,ORGN3=@ORGN3,ORGN4=@ORGN4,DSTN1=@DSTN1,DSTN2=@DSTN2,DSTN3=@DSTN3,DSTN4=@DSTN4,ETD1=@ETD1,ETD2=@ETD2,ETD3=@ETD3,ETD4=@ETD4,ETA1=@ETA1,ETA2=@ETA2,ETA3=@ETA3,ETA4=@ETA4,PCS1=@PCS1,PCS2=@PCS2,PCS3=@PCS3,PCS4=@PCS4,Weight1=@Weight1,Weight2=@Weight2,Weight3=@Weight3,Weight4=@Weight4,QuantityPack1=@QuantityPack1,QuantityUnitPack1=@QuantityUnitPack1,TimeDTE=@TimeDTE,DateDTE=@DateDTE,TimeATT=@TimeATT,DateATT=@DateATT,Status1=@Status1,Status2=@Status2,JobSite=@JobSite,BillingNo=@BillingNo,CustomerCodeGroup=@CustomerCodeGroup,CustomerENGGroup=@CustomerENGGroup")
                    'sb.Append(" WHERE (EASLOTNo=@EASLOTNo)")
                    Dim edit As tblTruckWayBillImp = (From c In db.tblTruckWayBillImps Where c.TruckWayBillNo = txtTruckW_B.Value.Trim
                      Select c).First()
                    If edit IsNot Nothing Then
                        edit.TruckWayBillNo = txtTruckW_B.Value.Trim
                        edit.ReceivedDate = CDate(txtdatepickerReceivedDate.Text.Trim)
                        edit.Dateofissue = CDate(txtdatepickerDateOfIssue.Text.Trim)
                        edit.NoofOriginals = txtNoOfOriginals.Value.Trim
                        edit.NotifyPatty = txtNotifyParty.Value.Trim
                        edit.DeliveryofGoods = txtDeliveryOfGoods.Value.Trim
                        edit.CarLicense = txtCarLicense.Value.Trim
                        edit.DriverName = txtDriverName.Value.Trim
                        edit.FreightCharges = txtFreightCharges.Value.Trim
                        edit.Prepaid = txtPrepaid.Value.Trim
                        edit.QuantityAmount = txtQuantityAmount.Value.Trim
                        edit.GrossWeightAmount = txtGrossWeight.Value.Trim
                        edit.Measurement = txtMeasurement.Value.Trim
                        edit.ExporterCode = txtShippercode.Value.Trim
                        edit.NameEng = txtNameShipper.Value.Trim
                        edit.StreetAddress = txtAddress1Shipper.Value.Trim
                        edit.District = txtAddress2Shipper.Value.Trim
                        edit.SubProvince = txtAddress3Shipper.Value.Trim
                        edit.Province = txtAddress4Shipper.Value.Trim
                        edit.PostCode = txtAddress5Shipper.Value.Trim
                        edit.CodeReturn = txtEmailShipper.Value.Trim
                        edit.ConsignneeCode = txtConsigneeCodee.Value.Trim
                        edit.ConsignNameEng = txtNameConsignee.Value.Trim
                        edit.ConsingStreetNumber = txtAddress1Consignee.Value.Trim
                        edit.ConsignDistrict = txtAddress2Consignee.Value.Trim
                        edit.ConsignSubProvince = txtAddress3Consignee.Value.Trim
                        edit.ConsgnProvince = txtAddress4Consignee.Value.Trim
                        edit.ConsignPostCode = txtAddress5Consignee.Value.Trim
                        edit.ConsignEmail = txtEmailConsignee.Value.Trim
                        edit.PlaceCode = txtNotifyPartyCode.Value.Trim
                        edit.PlaceName = txtNotifyPartyName.Value.Trim
                        edit.PlaceAddress = txtNotifyPartyAddress.Value.Trim
                        edit.PlaceofReceipt = txtPlaceOfReceipt.Value.Trim

                        db.SaveChanges()
                        tran.Complete()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                    End If
                Catch ex As Exception
                    tran.Dispose()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        txtTruckW_B.Focus()
    End Sub 'saveModifyเข้าที่[tblTruckWayBillImp]
    '-------------------------------------------------------------Gen Truck No Method------------------------------------------------
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
        Dim TruckWB As String
        Dim num_ As String
        Dim dunNo As String

        Nemount = Nmount.ToString("0#")
        Neyear = Nyear.ToString("0#")

        Mount = CSng(Nemount)
        Year = CSng(Neyear)
        Digit = CSng(DigitNo_)

        TruckWB = "TWB"
        LotNo = TruckWB & "-" & "IN-" & Nyear.ToString("0#") & Nmount.ToString("0#")

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
            txtTruckW_B.Value = dunNo
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
            txtTruckW_B.Value = dunNo

        End If
    End Sub
    '-------------------------------------------------------------Gen Truck No Method Continue------------------------------------------------
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
    '-------------------------------------------------------------------Clear DATA Method----------------------------------------
    Private Sub ClearDATA()
        txtTruckW_B.Value = ""
        txtdatepickerReceivedDate.Text = ""
        txtdatepickerDateOfIssue.Text = ""
        txtNoOfOriginals.Value = ""
        txtNotifyParty.Value = ""
        txtDeliveryOfGoods.Value = ""
        txtCarLicense.Value = ""
        txtDriverName.Value = ""
        txtFreightCharges.Value = ""
        txtPrepaid.Value = ""
        txtQuantityAmount.Value = "0.0"
        txtGrossWeight.Value = "0.0"
        txtMeasurement.Value = "0.0"
        txtShippercode.Value = ""
        txtNameShipper.Value = ""
        txtAddress1Shipper.Value = ""
        txtAddress2Shipper.Value = ""
        txtAddress3Shipper.Value = ""
        txtAddress4Shipper.Value = ""
        txtAddress5Shipper.Value = ""
        txtEmailShipper.Value = ""
        txtConsigneeCodee.Value = ""
        txtNameConsignee.Value = ""
        txtAddress1Consignee.Value = ""
        txtAddress2Consignee.Value = ""
        txtAddress3Consignee.Value = ""
        txtAddress4Consignee.Value = ""
        txtAddress5Consignee.Value = ""
        txtEmailConsignee.Value = ""
        txtNotifyPartyCode.Value = ""
        txtNotifyPartyName.Value = ""
        txtNotifyPartyAddress.Value = ""
        txtPlaceOfReceipt.Value = ""

    End Sub
    '--------------------------------------------------------------Click btn Add Truck Way Bill Head-----------------------------------
    Protected Sub btnAddHead_ServerClick(sender As Object, e As EventArgs)
        truckwaybillhead_fieldset.Disabled = False
        truckwaybilldetail_fieldset.Disabled = True

        txtTruckW_B.Disabled = True
        btnSaveAddHead.Visible = True
        btnSaveEditHead.Visible = False
        btnSearchTruck.Visible = False

        ClearDATA()
    End Sub
    '--------------------------------------------------------------Click btn Edit Truck Way Bill Head-----------------------------------
    Protected Sub btnEditHead_ServerClick(sender As Object, e As EventArgs)
        truckwaybillhead_fieldset.Disabled = False
        truckwaybilldetail_fieldset.Disabled = False

        txtTruckW_B.Disabled = False
        btnSaveAddHead.Visible = False
        btnSaveEditHead.Visible = True
        btnSearchTruck.Visible = True

        ClearDATA()
    End Sub
    '--------------------------------------------------------------Click btn SaveNew Truck Way Bill Head-----------------------------------
    Protected Sub btnSaveAddHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmTruckWayBillImp"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then

            If txtTruckW_B.Value.Trim = "" Then
                Gentbl("TWBLOTIN")
            End If
            SaveDATA_New()
            InsertData()
            ReadDATA()
            'ClearDATA()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If

    End Sub
    '------------------------------------------------------------Click btn SaveEdit Truck Way Bill Head--------------------------------------
    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmTruckWayBillImp"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then

            SaveDATA_Modify()
            InsertData()
            'ClearDATA()
            ReadDATA()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If

    End Sub
    '------------------------------------------------------------Click btn SaveNew Truck Way Bill Datail--------------------------------------
    Protected Sub btnSaveNew_Detail_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmTruckWayBillImp"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveDATADetail_New()
            InsertDataDetail()
            ReadDATA()
            CalculateTotalTruckWaybill()
            ClearDATADetail()
            txtInvoiceNoo.Focus()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If

    End Sub
    '------------------------------------------------------------Click btn SaveModify Truck Way Bill Datail--------------------------------------
    Protected Sub btnSaveModify_Detail_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmTruckWayBillImp"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveDATADetail_Modify()
            InsertDataDetail()
            ReadDATA()
            CalculateTotalTruckWaybill()
            ClearDATADetail()
            txtInvoiceNoo.Focus()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '------------------------------------------------------------Click btn Delete Truck Way Bill Datail--------------------------------------
    Protected Sub btnDelete_Detail_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmTruckWayBillImp"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Delete_ = 1
        If cu.Any Then
            SaveDATADetail_Delete()
            InsertDataDetail()
            ReadDATA()
            CalculateTotalTruckWaybill()
            ClearDATADetail()
            txtInvoiceNoo.Focus()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If

    End Sub
    '------------------------------------------------------------Click btn Cencel Truck Way Bill Datail--------------------------------------
    Protected Sub btnCencel_Detail_ServerClick(sender As Object, e As EventArgs)
        ClearDATADetail()
    End Sub
    '----------------------------------------------------------Save Data New Detail Method-------------------------------------------
    Private Sub SaveDATADetail_New()
        If txtTruckW_B.Value.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน TruckWayBill No ก่อน !!!');", True)
            txtTruckW_B.Focus()
            Exit Sub
        End If

        If txtInvoiceNoo.Value.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Invoice No ก่อน !!!');", True)
            txtInvoiceNoo.Focus()
            Exit Sub
        End If

        If MsgBox("คุณต้องการเพิ่มรายการ TruckWayBillDetailImp ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    'sb = New StringBuilder()
                    'sb.Append("INSERT INTO tblTruckWayBillDetailImp (TruckWayBillNo,InvoiceNo,LOTNo,PartDesc,OwnerPN,CustomerPN,Quantity,QuantityUnit,GrossWeight,WeightUnit,Measurement,CountryofOrigin)")
                    'sb.Append(" VALUES (@TruckWayBillNo,@InvoiceNo,@LOTNo,@PartDesc,@OwnerPN,@CustomerPN,@Quantity,@QuantityUnit,@GrossWeight,@WeightUnit,@Measurement,@CountryofOrigin)")

                    db.tblTruckWayBillDetailImps.Add(New tblTruckWayBillDetailImp With { _
                    .TruckWayBillNo = txtTruckW_B.Value.Trim, _
                    .InvoiceNo = txtInvoiceNoo.Value.Trim, _
                    .LOTNo = txtLOTNo.Value.Trim, _
                    .PartDesc = txtPartDesc.Value.Trim, _
                    .OwnerPN = txtOwnP_N.Value.Trim, _
                    .CustomerPN = txtCustomerP_N.Value.Trim, _
                    .Quantity = txtQuantity_Detail.Value.Trim, _
                    .QuantityUnit = ddlUnitQuantity_Detail.Text.Trim, _
                    .GrossWeight = txtGrossWeight_Detail.Value.Trim, _
                    .WeightUnit = ddlUnit_GrossWeight.Text.Trim, _
                    .Measurement = txtMeasurement_Detail.Value.Trim, _
                    .CountryofOrigin = ddlCountryOfOrigin.Text.Trim
                   })

                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)

                Catch ex As Exception
                    tran.Dispose()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        txtInvoiceNoo.Focus()
    End Sub
    '----------------------------------------------------------Save Data Modify Detail Method-------------------------------------------
    Private Sub SaveDATADetail_Modify()

        If txtTruckW_B.Value.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน TruckWayBill No ก่อน !!!');", True)
            txtTruckW_B.Focus()
            Exit Sub
        End If

        If txtInvoiceNoo.Value.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Invoice No ก่อน !!!');", True)
            txtInvoiceNoo.Focus()
            Exit Sub
        End If

        If MsgBox("คุณต้องการแก้ไขรายการ Truck No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    'sb.Append("UPDATE tblTruckWayBillDetailImp")
                    'sb.Append(" SET TruckWayBillNo=@TruckWayBillNo,InvoiceNo=@InvoiceNo,LOTNo=@LOTNo,PartDesc=@PartDesc,OwnerPN=@OwnerPN,CustomerPN=@CustomerPN,Quantity=@Quantity,QuantityUnit=@QuantityUnit,GrossWeight=@GrossWeight,WeightUnit=@WeightUnit,Measurement=@Measurement,CountryofOrigin=@CountryofOrigin")
                    'sb.Append(" WHERE (TruckWayBillNo=@TruckWayBillNo) AND (InvoiceNo = @InvoiceNo) AND (CodeNo=@CodeNo)")

                    Dim edit As tblTruckWayBillDetailImp = (From c In db.tblTruckWayBillDetailImps Where c.TruckWayBillNo = txtTruckW_B.Value.Trim
                      Select c).First()
                    If edit IsNot Nothing Then
                        edit.TruckWayBillNo = txtTruckW_B.Value.Trim
                        edit.InvoiceNo = txtInvoiceNoo.Value.Trim
                        edit.LOTNo = txtLOTNo.Value.Trim
                        edit.PartDesc = txtPartDesc.Value.Trim
                        edit.OwnerPN = txtOwnP_N.Value.Trim
                        edit.CustomerPN = txtCustomerP_N.Value.Trim
                        edit.Quantity = txtQuantity_Detail.Value.Trim
                        edit.QuantityUnit = ddlUnitQuantity_Detail.Text.Trim
                        edit.GrossWeight = txtGrossWeight_Detail.Value.Trim
                        edit.WeightUnit = ddlUnit_GrossWeight.Text.Trim
                        edit.Measurement = txtMeasurement_Detail.Value.Trim
                        edit.CountryofOrigin = ddlCountryOfOrigin.Text.Trim

                        db.SaveChanges()
                        tran.Complete()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                    End If
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        txtInvoiceNoo.Focus()
    End Sub
    '-----------------------------------------------------------Clear Data Detail---------------------------------------------
    Private Sub ClearDATADetail()

        txtInvoiceNoo.Value = ""
        txtLOTNo.Value = ""
        txtPartDesc.Value = ""
        txtMeasurement_Detail.Value = ""
        txtOwnP_N.Value = ""
        txtCustomerP_N.Value = ""
        txtQuantity_Detail.Value = ""
        txtGrossWeight_Detail.Value = ""

    End Sub
    Private Sub InsertDataDetail()
        Using tran As New TransactionScope()
            Try
                db.tblLogTruckWayBillDetailImps.Add(New tblLogTruckWayBillDetailImp With { _
                                    .TruckWayBillNo = txtTruckW_B.Value.Trim, _
                                    .InvoiceNo = txtInvoiceNoo.Value.Trim, _
                                    .UserBy = CStr(Session("UserName")), _
                                    .LastUpDate = Now
                                })
                db.SaveChanges()
                tran.Complete()
            Catch ex As Exception
                tran.Dispose()
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด Function: InsertDataDetail กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            End Try
        End Using
    End Sub
    '-----------------------------------------------------------------Show Repeater in Invoice TAB------------------------------------------
    Private Sub ReadDATA()
        Dim sqlConsignnee = From ab In db.tblTruckWayBillDetailImps Where ab.TruckWayBillNo = txtTruckW_B.Value.Trim Order By ab.TruckWayBillNo
        Select ab.TruckWayBillNo,
                 ab.InvoiceNo,
                 ab.LOTNo,
                 ab.PartDesc,
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
        Dim TruckWayBillNo As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectTruckWayBillNo") Then

                If String.IsNullOrEmpty(TruckWayBillNo) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เป็นค่าว่าง');", True)
                Else
                    Dim user = (From u In db.tblTruckWayBillDetailImps Where u.TruckWayBillNo = TruckWayBillNo).SingleOrDefault

                    txtInvoiceNoo.Value = user.InvoiceNo
                    txtLOTNo.Value = user.LOTNo
                    txtPartDesc.Value = user.PartDesc
                    txtMeasurement_Detail.Value = user.Measurement
                    txtOwnP_N.Value = user.OwnerPN
                    txtCustomerP_N.Value = user.CustomerPN
                    txtQuantity_Detail.Value = user.Quantity
                    txtGrossWeight_Detail.Value = user.GrossWeight
                    ddlUnitQuantity_Detail.Text = user.QuantityUnit
                    ddlUnit_GrossWeight.Text = user.WeightUnit
                    ddlCountryOfOrigin.Text = user.CountryofOrigin
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CalculateTotalTruckWaybill()
        Dim lblInvoiceNo As String
        Dim lblTruckWayBillNo As String
        Dim i As Integer

        Dim AmountQuantity As Double = 0.0
        Dim AmountNetWeight As Double = 0.0
        Dim AmountMeasurement As Double = 0.0

        With Repea2_Invoice
            For i = 0 To Repea2_Invoice.Items.Count - 1

                lblInvoiceNo = CType(Repea2_Invoice.Items(i).FindControl("lblInvoiceNo"), Label).Text.Trim
                lblTruckWayBillNo = CType(Repea2_Invoice.Items(i).FindControl("lblTruckWayBillNo"), Label).Text.Trim

                Dim u = (From us In db.tblTruckWayBillDetailImps Where us.TruckWayBillNo = lblTruckWayBillNo And us.InvoiceNo = lblInvoiceNo).FirstOrDefault

                AmountQuantity = AmountQuantity + u.Quantity
                AmountNetWeight = AmountNetWeight + u.GrossWeight
                AmountMeasurement = AmountMeasurement + u.Measurement
            Next
        End With

        txtQuantityAmount.Value = AmountQuantity.ToString("#,##0.000")
        txtGrossWeight.Value = AmountNetWeight.ToString("#,##0.000")
        txtMeasurement.Value = AmountMeasurement.ToString("#,##0.000")
    End Sub
    Private Sub InsertData()

        Using tran As New TransactionScope()
            Try
                db.tblLogTruckWayBillImps.Add(New tblLogTruckWayBillImp With { _
                                    .TruckWayBillNo = txtTruckW_B.Value.Trim, _
                                    .UserBy = CStr(Session("UserName")), _
                                    .LastUpDate = Now
                                })
                db.SaveChanges()
                tran.Complete()
                db.Database.Connection.Close()
            Catch ex As Exception
                tran.Dispose()
                db.Database.Connection.Close()
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด Function: InsertData กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            End Try
        End Using
    End Sub
    Private Sub SaveDATADetail_Delete()

        If txtInvoiceNoo.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เลือกข้อมูลที่ต้องการ Delete ก่อน !!!');", True)
            txtInvoiceNoo.Focus()
            Exit Sub
        End If

        If MsgBox("คุณต้องการลบข้อมูล Invoice No. ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Using tran As New TransactionScope()
                Try

                    Dim DeleteTruckBillDetailImp As tblTruckWayBillDetailImp = (From c In db.tblTruckWayBillDetailImps Where c.InvoiceNo = txtInvoiceNoo.Value.Trim Select c).First()

                    db.tblTruckWayBillDetailImps.Remove(DeleteTruckBillDetailImp)

                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete Delete Invoice No. นี้เรียบร้อยแล้ว !!');", True)
                Catch ex As Exception
                    tran.Dispose()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using

        End If
    End Sub
End Class