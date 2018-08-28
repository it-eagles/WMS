Option Explicit On
Option Strict On

Imports System.Transactions

Public Class SingleIssuedWH
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        If Not Me.IsPostBack Then
            If classPermis.CheckRead(form, usename) = True Then
                If Not IsPostBack Then
                    showSite_IssueCondition()
                    showCommodity()
                    showUnit()
                    showVolume()
                    showSite_ConfirmIssue()
                    showLocation()
                    showSoucreWHFac()
                    showunitdimension()
                    showunit2()
                    showcurrency()

                    beforecustomtab_fieldset.Disabled = True
                    issuecondition_fieldset.Disabled = True
                    confirmissue_fieldset.Disabled = True
                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
                'Response.Redirect("HomeMain.aspx")
            End If
        End If
    End Sub
    '-----------------------------------------------------------Click btn Add New Head--------------------------------------
    Protected Sub btnAddHead_ServerClick(sender As Object, e As EventArgs)
        UnlockAddData()
    End Sub
    '-----------------------------------------------------------Click btn Edit Head--------------------------------------
    Protected Sub btnEditHead_ServerClick(sender As Object, e As EventArgs)
        UnlockEditData()
    End Sub
    '-----------------------------------------------------------Click btn Save New Head--------------------------------------
    Protected Sub btnSaveAddHead_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '-----------------------------------------------------------Click btn Save Edit Head--------------------------------------
    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '-------------------------------------------------------------Unlock Add Data When Click btn Add---------------------------------------
    Private Sub UnlockAddData()
        btnSaveAddHead.Visible = True
        btnSaveEditHead.Visible = False
        btnJobNoHead.Visible = True
        btnJobNoHead_Edit.Visible = False

        beforecustomtab_fieldset.Disabled = False
        issuecondition_fieldset.Disabled = False
        confirmissue_fieldset.Disabled = True
    End Sub
    '-------------------------------------------------------------Unlock Edit Data When Click btn Edit---------------------------------------
    Private Sub UnlockEditData()
        btnSaveAddHead.Visible = False
        btnSaveEditHead.Visible = True
        btnJobNoHead.Visible = False
        btnJobNoHead_Edit.Visible = True

        beforecustomtab_fieldset.Disabled = False
        issuecondition_fieldset.Disabled = False
        confirmissue_fieldset.Disabled = False
    End Sub

    Protected Sub btnSumQTY_IssueCon_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnRejectMoveTo_IssueCon_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnConfirmIssued_IssueCon_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnRejectConfirm_IssueCon_ServerClick(sender As Object, e As EventArgs)

    End Sub



    Protected Sub btnJobNoHead_Edit_ServerClick(sender As Object, e As EventArgs)

    End Sub







    '--------------------------------------------------------------------Show ddl Site----------------------------------------------------
    Private Sub showSite_IssueCondition()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "SITE"
                  Select g.Type, g.Code
        Try
            ddlWHSite_IssueCon.DataSource = gg.ToList
            ddlWHSite_IssueCon.DataTextField = "Code"
            ddlWHSite_IssueCon.DataValueField = "Code"
            ddlWHSite_IssueCon.DataBind()

            If ddlWHSite_IssueCon.Items.Count > 1 Then
                ddlWHSite_IssueCon.Enabled = True
            Else
                ddlWHSite_IssueCon.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl COMMODITY----------------------------------------------------
    Private Sub showCommodity()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "COMMODITY"
                  Select g.Type, g.Code
        Try
            ddlCommodity_IssueCon.DataSource = gg.ToList
            ddlCommodity_IssueCon.DataTextField = "Code"
            ddlCommodity_IssueCon.DataValueField = "Code"
            ddlCommodity_IssueCon.DataBind()

            If ddlCommodity_IssueCon.Items.Count > 1 Then
                ddlCommodity_IssueCon.Enabled = True
            Else
                ddlCommodity_IssueCon.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl UNIT----------------------------------------------------
    Private Sub showUnit()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "UNIT"
                  Select g.Type, g.Code
        Try
            ddlQuantityPackage_IssueCon.DataSource = gg.ToList
            ddlQuantityPackage_IssueCon.DataTextField = "Code"
            ddlQuantityPackage_IssueCon.DataValueField = "Code"
            ddlQuantityPackage_IssueCon.DataBind()

            If ddlQuantityPackage_IssueCon.Items.Count > 1 Then
                ddlQuantityPackage_IssueCon.Enabled = True
            Else
                ddlQuantityPackage_IssueCon.Enabled = False
            End If

            ddlQuantityPLTSkid_IssueCon.DataSource = gg.ToList
            ddlQuantityPLTSkid_IssueCon.DataTextField = "Code"
            ddlQuantityPLTSkid_IssueCon.DataValueField = "Code"
            ddlQuantityPLTSkid_IssueCon.DataBind()

            If ddlQuantityPLTSkid_IssueCon.Items.Count > 1 Then
                ddlQuantityPLTSkid_IssueCon.Enabled = True
            Else
                ddlQuantityPLTSkid_IssueCon.Enabled = False
            End If

            ddlQuantityOfGood_IssueCon.DataSource = gg.ToList
            ddlQuantityOfGood_IssueCon.DataTextField = "Code"
            ddlQuantityOfGood_IssueCon.DataValueField = "Code"
            ddlQuantityOfGood_IssueCon.DataBind()

            If ddlQuantityOfGood_IssueCon.Items.Count > 1 Then
                ddlQuantityOfGood_IssueCon.Enabled = True
            Else
                ddlQuantityOfGood_IssueCon.Enabled = False
            End If

            ddlWeight_IssueCon.DataSource = gg.ToList
            ddlWeight_IssueCon.DataTextField = "Code"
            ddlWeight_IssueCon.DataValueField = "Code"
            ddlWeight_IssueCon.DataBind()

            If ddlWeight_IssueCon.Items.Count > 1 Then
                ddlWeight_IssueCon.Enabled = True
            Else
                ddlWeight_IssueCon.Enabled = False
            End If

            ddlQuantityPicked_IssueCon.DataSource = gg.ToList
            ddlQuantityPicked_IssueCon.DataTextField = "Code"
            ddlQuantityPicked_IssueCon.DataValueField = "Code"
            ddlQuantityPicked_IssueCon.DataBind()

            If ddlQuantityPicked_IssueCon.Items.Count > 1 Then
                ddlQuantityPicked_IssueCon.Enabled = True
            Else
                ddlQuantityPicked_IssueCon.Enabled = False
            End If

            ddlQTYDiscrepancy_IssueCon.DataSource = gg.ToList
            ddlQTYDiscrepancy_IssueCon.DataTextField = "Code"
            ddlQTYDiscrepancy_IssueCon.DataValueField = "Code"
            ddlQTYDiscrepancy_IssueCon.DataBind()

            If ddlQTYDiscrepancy_IssueCon.Items.Count > 1 Then
                ddlQTYDiscrepancy_IssueCon.Enabled = True
            Else
                ddlQTYDiscrepancy_IssueCon.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl Volume----------------------------------------------------
    Private Sub showVolume()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "VOLUME"
                  Select g.Type, g.Code
        Try
            ddlVolume_IssueCon.DataSource = gg.ToList
            ddlVolume_IssueCon.DataTextField = "Code"
            ddlVolume_IssueCon.DataValueField = "Code"
            ddlVolume_IssueCon.DataBind()

            If ddlVolume_IssueCon.Items.Count > 1 Then
                ddlVolume_IssueCon.Enabled = True
            Else
                ddlVolume_IssueCon.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub


    '--------------------------------------------------------------------Show ddl Site----------------------------------------------------
    Private Sub showSite_ConfirmIssue()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "SITE"
                  Select g.Type, g.Code
        Try
            ddlWHSite_ConfirmIssue.DataSource = gg.ToList
            ddlWHSite_ConfirmIssue.DataTextField = "Code"
            ddlWHSite_ConfirmIssue.DataValueField = "Code"
            ddlWHSite_ConfirmIssue.DataBind()

            If ddlWHSite_ConfirmIssue.Items.Count > 1 Then
                ddlWHSite_ConfirmIssue.Enabled = True
            Else
                ddlWHSite_ConfirmIssue.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl Location----------------------------------------------------
    Private Sub showLocation()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "LOCATION"
                  Select g.Type, g.Code
        Try
            ddlWHLocation_ConfirmIssue.DataSource = gg.ToList
            ddlWHLocation_ConfirmIssue.DataTextField = "Code"
            ddlWHLocation_ConfirmIssue.DataValueField = "Code"
            ddlWHLocation_ConfirmIssue.DataBind()

            If ddlWHLocation_ConfirmIssue.Items.Count > 1 Then
                ddlWHLocation_ConfirmIssue.Enabled = True
            Else
                ddlWHLocation_ConfirmIssue.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl SOURCE-WH-FAC----------------------------------------------------
    Private Sub showSoucreWHFac()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "SOURCE-WH-FAC"
                  Select g.Type, g.Code
        Try
            ddlCustWHFac_ConfirmIssue.DataSource = gg.ToList
            ddlCustWHFac_ConfirmIssue.DataTextField = "Code"
            ddlCustWHFac_ConfirmIssue.DataValueField = "Code"
            ddlCustWHFac_ConfirmIssue.DataBind()

            If ddlCustWHFac_ConfirmIssue.Items.Count > 1 Then
                ddlCustWHFac_ConfirmIssue.Enabled = True
            Else
                ddlCustWHFac_ConfirmIssue.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------------Show ddl Unit CM INC-------------------------------------------------------
    Private Sub showunitdimension()
        Dim gg = From g In db.tblMasterCodes Where g.Code = "CM" Or g.Code = "INC"
                  Select g.Type, g.Code
        Try
            ddlMeasurement_ConfirmIssue.DataSource = gg.ToList
            ddlMeasurement_ConfirmIssue.DataTextField = "Code"
            ddlMeasurement_ConfirmIssue.DataValueField = "Code"
            ddlMeasurement_ConfirmIssue.DataBind()
            If ddlMeasurement_ConfirmIssue.Items.Count > 1 Then
                ddlMeasurement_ConfirmIssue.Enabled = True
            Else
                ddlMeasurement_ConfirmIssue.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------------Show ddl Unit2-------------------------------------------------------
    Private Sub showunit2()
        Dim gg = From g In db.tblMasterCodes Where g.Type = "UNIT"
                  Select g.Type, g.Code
        Try
            ddlQuantity_ConfirmIssue.DataSource = gg.ToList
            ddlQuantity_ConfirmIssue.DataTextField = "Code"
            ddlQuantity_ConfirmIssue.DataValueField = "Code"
            ddlQuantity_ConfirmIssue.DataBind()

            If ddlQuantity_ConfirmIssue.Items.Count > 1 Then
                ddlQuantity_ConfirmIssue.Enabled = True
            Else
                ddlQuantity_ConfirmIssue.Enabled = False
            End If

            ddlWeight_ConfirmIssue.DataSource = gg.ToList
            ddlWeight_ConfirmIssue.DataTextField = "Code"
            ddlWeight_ConfirmIssue.DataValueField = "Code"
            ddlWeight_ConfirmIssue.DataBind()

            If ddlWeight_ConfirmIssue.Items.Count > 1 Then
                ddlWeight_ConfirmIssue.Enabled = True
            Else
                ddlWeight_ConfirmIssue.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------------Show ddl Currency-------------------------------------------------------
    Private Sub showcurrency()
        Dim gg = From g In db.tblMasterCodes Where g.Type = "CURRENCY"
                  Select g.Type, g.Code
        Try
            ddlCurrency_ConfirmIssue.DataSource = gg.ToList
            ddlCurrency_ConfirmIssue.DataTextField = "Code"
            ddlCurrency_ConfirmIssue.DataValueField = "Code"
            ddlCurrency_ConfirmIssue.DataBind()
            If ddlCurrency_ConfirmIssue.Items.Count > 1 Then
                ddlCurrency_ConfirmIssue.Enabled = True
            Else
                ddlCurrency_ConfirmIssue.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------Show Data Exporter In Modal-----------------------------------------
    Private Sub selectExporterCode()
        Dim tEndUser As String
        Dim Exporter_ As String = ""
        If String.IsNullOrEmpty(txtExporterCode_IssueCon.Value.Trim) Then
            tEndUser = ""
            Exporter_ = "0"
        Else
            tEndUser = txtExporterCode_IssueCon.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = tEndUser And p.EndCustomer = "0") Or p.EndCustomer = Exporter_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater1.DataSource = cons.ToList
            Repeater1.DataBind()
            ScriptManager.RegisterStartupScript(ExporterUpdatePanel, ExporterUpdatePanel.GetType(), "show", "$(function () { $('#" + ExporterPanel.ClientID + "').modal('show'); });", True)
            ExporterUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Exporter Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Exporter-----------------------------------------------
    Protected Sub btnExporterCode_IssueCon_ServerClick(sender As Object, e As EventArgs)
        selectExporterCode()
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
    '--------------------------------------------------------Click Data Exporter In Modal-----------------------------------------
    Protected Sub clickexporter_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        txtExporterCode_IssueCon.Value = user.u.PartyCode
        txtNameExporter_IssueCon.Value = user.u.PartyFullName
        txtAddress1Exporter_IssueCon.Value = user.br.Address1
        txtAddress2Exporter_IssueCon.Value = user.br.Address2
        txtAddress3Exporter_IssueCon.Value = user.br.Address3
        txtAddress4Exporter_IssueCon.Value = user.br.Address4

    End Sub
    '--------------------------------------------------------Show Data Owner In Modal-----------------------------------------
    Private Sub selectOwnerCode()
        Dim Owner_code As String
        Dim Consignee_ As String = ""
        If String.IsNullOrEmpty(txtOwnerCode_IssueCon.Value.Trim) Then
            Owner_code = ""
            Consignee_ = "0"
        Else
            Owner_code = txtOwnerCode_IssueCon.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Owner_code And p.Consignee = "0") Or p.Consignee = Consignee_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater2.DataSource = cons.ToList
            Repeater2.DataBind()
            ScriptManager.RegisterStartupScript(OwnerUpdatePanel, OwnerUpdatePanel.GetType(), "show", "$(function () { $('#" + OwnerPanel.ClientID + "').modal('show'); });", True)
            OwnerUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Delivery Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Owner-----------------------------------------------
    Protected Sub btnOwnerCode_IssueCon_ServerClick(sender As Object, e As EventArgs)
        selectOwnerCode()
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
    '--------------------------------------------------------Click Data Owner In Modal-----------------------------------------
    Protected Sub clickowner_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        txtOwnerCode_IssueCon.Value = user.u.PartyCode
        txtNameOwner_IssueCon.Value = user.u.PartyFullName
        txtAddress1Owner_IssueCon.Value = user.br.Address1
        txtAddress2Owner_IssueCon.Value = user.br.Address2
        txtAddress3Owner_IssueCon.Value = user.br.Address3
        txtAddress4Owner_IssueCon.Value = user.br.Address4

    End Sub
    '--------------------------------------------------------Show Data Consignee In Modal-----------------------------------------
    Private Sub selectConsigneeCode()
        Dim Ship_code As String
        Dim Customer_ As String = ""
        If String.IsNullOrEmpty(txtConsigneeCode01_IssueCon.Value.Trim) Then
            Ship_code = ""
            Customer_ = "0"
        Else
            Ship_code = txtConsigneeCode01_IssueCon.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Ship_code And p.Customer = "0") Or p.Customer = Customer_
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
    '--------------------------------------------------------------Click Search Consignee-----------------------------------------------
    Protected Sub btnConsigneeCode_IssueCon_ServerClick(sender As Object, e As EventArgs)
        selectConsigneeCode()
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
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault
        txtConsigneeCode01_IssueCon.Value = user.u.PartyCode
        txtNameConsignee_IssueCon.Value = user.u.PartyFullName
        txtAddress1Consignee_IssueCon.Value = user.br.Address1
        txtAddress2Consignee_IssueCon.Value = user.br.Address2
        txtAddress3Consignee_IssueCon.Value = user.br.Address3
        txtAddress4Consignee_IssueCon.Value = user.br.Address4

    End Sub
    '--------------------------------------------------------Show Data ShipTo In Modal-----------------------------------------
    Private Sub selectShipToCode()
        Dim Ship_code As String
        Dim EndCustomer_ As String = ""
        If String.IsNullOrEmpty(txtShipToCode_IssueCon.Value.Trim) Then
            Ship_code = ""
            EndCustomer_ = "0"
        Else
            Ship_code = txtShipToCode_IssueCon.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Ship_code And p.EndCustomer = "0") Or p.EndCustomer = EndCustomer_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater4.DataSource = cons.ToList
            Repeater4.DataBind()
            ScriptManager.RegisterStartupScript(ShipToUpdatePanel, ShipToUpdatePanel.GetType(), "show", "$(function () { $('#" + ShipToPanel.ClientID + "').modal('show'); });", True)
            ShipToUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Ship To Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search ShipTo-----------------------------------------------
    Protected Sub btnShipToCode_IssueCon_ServerClick(sender As Object, e As EventArgs)
        selectShipToCode()
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
    Protected Sub clickshipto_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        txtShipToCode_IssueCon.Value = user.u.PartyCode
        txtNameShipTo_IssueCon.Value = user.u.PartyFullName
        txtAddress1ShipTo_IssueCon.Value = user.br.Address1
        txtAddress2ShipTo_IssueCon.Value = user.br.Address2
        txtAddress3ShipTo_IssueCon.Value = user.br.Address3
        txtAddress4ShipTo_IssueCon.Value = user.br.Address4

    End Sub
    '--------------------------------------------------------Show Data ProductCode In Modal-----------------------------------------
    Private Sub selectProductCode()
        Dim testdate As Integer
        Dim ProCode As String = ""
        If String.IsNullOrEmpty(txtEASPN_ConfirmIssue.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            ProCode = txtEASPN_ConfirmIssue.Value.Trim
        End If

        Dim cons = (From u In db.tblProductDetails
                    Where (u.ProductCode = ProCode) Or u.CreateDate.Year = testdate And u.ImpProductCode <> ""
                   Select New With {u.ProductCode,
                                    u.ImpDesc1,
                                    u.PONo,
                                    u.CustomerPart,
                                    u.EndUserPart}).ToList()

        If cons.Count > 0 Then
            Repeater5.DataSource = cons.ToList
            Repeater5.DataBind()
            ScriptManager.RegisterStartupScript(ProductCodeUpdatePanel, ProductCodeUpdatePanel.GetType(), "show", "$(function () { $('#" + ProductCodePanel.ClientID + "').modal('show'); });", True)
            ProductCodeUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล ProductCode Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search ProductCode-----------------------------------------------
    Protected Sub btnEASPN_ConfirmIssue_ServerClick(sender As Object, e As EventArgs)
        selectProductCode()
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

                    txtEASPN_ConfirmIssue.Value = user.ProductCode
                    txtProductDesc_ConfirmIssue.Value = user.ImpDesc1
                    txtCustomerPN_ConfirmIssue.Value = user.EndUserPart
                    txtOwnerPN_ConfirmIssue.Value = user.CustomerPart

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data JobNoAdd In Modal-----------------------------------------
    Private Sub selectJobNoAdd()
        'Dim testdate As Integer
        'Dim ProCode As String = ""
        'If String.IsNullOrEmpty(txtJobNo_BeforeTab.Value.Trim) Then
        '    testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        'Else
        '    ProCode = txtJobNo_BeforeTab.Value.Trim
        'End If

        ' Where (u.ProductCode = ProCode) Or u.CreateDate.Year = testdate And u.ImpProductCode <> ""
        Dim cons = (From u In db.tblWHPickings
                    Where u.LOTNo = txtJobNo_BeforeTab.Value.Trim And u.UsedStatus = 0
                   Select New With {u.LOTNo,
                                    u.PullSignal,
                                    u.PullDate,
                                    u.PullTime,
                                    u.DeliveryDate}).ToList()

        If cons.Count > 0 Then
            Repeater6.DataSource = cons.ToList
            Repeater6.DataBind()
            ScriptManager.RegisterStartupScript(JobNoAddUpdatePanel, JobNoAddUpdatePanel.GetType(), "show", "$(function () { $('#" + JobNoAddPanel.ClientID + "').modal('show'); });", True)
            JobNoAddUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Job No นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search ProductCode-----------------------------------------------
    Protected Sub btnJobNoHead_ServerClick(sender As Object, e As EventArgs)
        selectJobNoAdd()
    End Sub
    '--------------------------------------------------------Click Data ProductCode In Modal-----------------------------------------
    Protected Sub Repeater6_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater6.ItemCommand
        Dim LOTNo As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("Selectjobnoadd") Then

                If String.IsNullOrEmpty(LOTNo) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblWHPickings Where u.LOTNo = LOTNo).SingleOrDefault

                    txtPullSignal_BeforeTab.Value = user.PullSignal
                    txtJobNo_BeforeTab.Value = user.LOTNo
                    txtdatepickertxtPullDateTime_beforeTab.Text = CStr(user.PullDate)
                    txtTimePickUpPullDateTime.Value = user.PullTime
                    txtdatepickerDeliveryDateTime_beforeTab.Text = CStr(user.DeliveryDate)
                    txtTimePickUpDeliveryDateTime.Value = user.DeliveryTime
                    txtdatepickerComfirmDateTime_beforeTab.Text = CStr(user.ConfirmDate)
                    txtTimePickUpConfirmDateTime.Value = user.ConfirmTime
                    txtExporterCode_IssueCon.Value = user.ExporterCode
                    txtNameExporter_IssueCon.Value = user.ExporterName
                    txtAddress1Exporter_IssueCon.Value = user.ExporterAddress1
                    txtAddress2Exporter_IssueCon.Value = user.ExporterAddress2
                    txtAddress3Exporter_IssueCon.Value = user.ExporterAddress3
                    txtAddress4Exporter_IssueCon.Value = user.ExporterAddress4
                    txtConsigneeCode01_IssueCon.Value = user.ConsigneeCode
                    txtNameConsignee_IssueCon.Value = user.ConsigneeName
                    txtAddress1Consignee_IssueCon.Value = user.ConsigneeAddress1
                    txtAddress2Consignee_IssueCon.Value = user.ConsigneeAddress2
                    txtAddress3Consignee_IssueCon.Value = user.ConsigneeAddress3
                    txtAddress4Consignee_IssueCon.Value = user.ConsigneeAddress4
                    txtOwnerCode_IssueCon.Value = user.OwnerCode
                    txtNameOwner_IssueCon.Value = user.OwnerName
                    txtAddress1Owner_IssueCon.Value = user.OwnerAddress1
                    txtAddress2Owner_IssueCon.Value = user.OwnerAddress2
                    txtAddress3Owner_IssueCon.Value = user.OwnerAddress3
                    txtAddress4Owner_IssueCon.Value = user.OwnerAddress4
                    txtShipToCode_IssueCon.Value = user.ShipToCode
                    txtNameShipTo_IssueCon.Value = user.ShipToName
                    txtAddress1ShipTo_IssueCon.Value = user.ShipToAddress1
                    txtAddress2ShipTo_IssueCon.Value = user.ShipToAddress2
                    txtAddress3ShipTo_IssueCon.Value = user.ShipToAddress3
                    txtAddress4ShipTo_IssueCon.Value = user.ShipToAddress4
                    ddlCommodity_IssueCon.Text = user.Commodity
                    txtQuantityOfGood_IssueCon.Value = CStr(user.QuantityOfPart)
                    ddlQuantityOfGood_IssueCon.Text = user.QuantityUnit
                    txtQuantityPackage_IssueCon.Value = CStr(user.QuantityPackage)
                    ddlQuantityPackage_IssueCon.Text = user.PackageUNIT
                    txtQuantityPLTSkid_IssueCon.Value = CStr(user.QuantityPLT)
                    ddlQuantityPLTSkid_IssueCon.Text = user.QuantityPLTUnit
                    txtWeight_IssueCon.Value = CStr(user.Weight)
                    ddlWeight_IssueCon.Text = user.WeightUnit
                    txtVolume_IssueCon.Value = CStr(user.Volume)
                    ddlVolume_IssueCon.Text = user.VolumeUnit
                    txtQuantityPicked_IssueCon.Value = CStr(user.QuantityPicked)
                    ddlQuantityPicked_IssueCon.Text = user.PickedUNIT
                    txtQTYDiscrepancy_IssueCon.Value = CStr(user.QuantityDiscrepancy)
                    ddlQTYDiscrepancy_IssueCon.Text = user.DiscrepancyUNIT
                    txtRemark_IssueCon.Value = user.Remark


                End If
            End If
        Catch ex As Exception
        End Try
    End Sub



End Class