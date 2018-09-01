Option Explicit On
Option Strict On

Imports System.Transactions
Imports System.Globalization

Public Class SingleIssuedWH
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis
    Dim strIssuedJobNo As String
    Dim strReceivedJobNo As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmIssuedWithBarcode"
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
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then

            strIssuedJobNo = Mid(txtJobNo_BeforeTab.Value.Trim, 1, 7) 'เลข Job out 
            strReceivedJobNo = Mid(txtJobNo_IssueCon.Value.Trim, 1, 6) 'เลข Job ที่ย้ายเข้าไปใหม่

            If txtJobNo_BeforeTab.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Job No ก่อน !!!');", True)
                txtJobNo_BeforeTab.Focus()
                Exit Sub
            End If

            If txtPullSignal_BeforeTab.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Pull Signal ก่อน !!!');", True)
                txtPullSignal_BeforeTab.Focus()
                Exit Sub
            End If

            If MsgBox("คุณต้องการเพิ่มรายการ Job No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                'tr = Conn.BeginTransaction()

                If SaveIssued_New() = False Then
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveIssued_New');", True)
                    Exit Sub
                End If

                If SaveNew_RemarkMoveJob() = False Then
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_RemarkMoveJob');", True)
                    Exit Sub
                End If

                If chkMoveTo.Checked = True Then
                    If txtJobNo_IssueCon.Value.Trim = "" Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Job No ก่อน !!!');", True)
                        Exit Sub
                    End If

                    CheckMoveTo()

                End If

                If UpdateRead1() = False Then
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก UpdateRead1');", True)
                    Exit Sub
                End If

                'tr.Commit()
                'LockMain()
                'NNew.Enabled = False
                'Modify.Enabled = False
                'Save.Enabled = True
                'GroupBox6.Enabled = True
                issuecondition_fieldset.Disabled = True
                confirmissue_fieldset.Disabled = False
                'ClearDATADetail()

            End If




        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '-----------------------------------------------------------Click btn Save Edit Head--------------------------------------
    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then

            SaveIssued_Modify()

        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If

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
        CountWHIssued()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Sum QTY. เรียบร้อยแล้ว' !!!');", True)
    End Sub

    Protected Sub btnRejectMoveTo_IssueCon_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            ReadDataMove()
            'LockMain()
            'NNew.Enabled = False
            'Modify.Enabled = False
            'Save.Enabled = True
            'GroupBox6.Enabled = True
            'tmpButtonStatus = "Modify"
            'ClearDATADetail()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub

    Protected Sub btnConfirmIssued_IssueCon_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            ConfirmDelivery()
            'ReadDataIsseudDetail()
            'CheckLocation()

        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub

    Protected Sub btnRejectConfirm_IssueCon_ServerClick(sender As Object, e As EventArgs)

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
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Owner Code นี้')", True)
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
        Dim testdate As Integer
        Dim jobno_code As String = ""
        Dim status_ As Double
        If String.IsNullOrEmpty(txtJobNo_BeforeTab.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            status_ = 0
        Else
            jobno_code = txtJobNo_BeforeTab.Value.Trim

        End If

        ' Where (u.ProductCode = ProCode) Or u.CreateDate.Year = testdate And u.ImpProductCode <> ""
        Dim cons = (From u In db.tblWHPickings
                    Where (u.LOTNo.Contains(txtJobNo_BeforeTab.Value.Trim) And u.UsedStatus = 0) Or (u.UsedStatus = status_ And u.PullDate.Year = testdate)
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
                    txtdatepickertxtPullDateTime_beforeTab.Text = Convert.ToDateTime(user.PullDate).ToString("dd/MM/yyyy")
                    txtTimePickUpPullDateTime.Value = user.PullTime
                    txtdatepickerDeliveryDateTime_beforeTab.Text = Convert.ToDateTime(user.DeliveryDate).ToString("dd/MM/yyyy")
                    txtTimePickUpDeliveryDateTime.Value = user.DeliveryTime
                    txtdatepickerComfirmDateTime_beforeTab.Text = Convert.ToDateTime(user.ConfirmDate).ToString("dd/MM/yyyy")
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
    '--------------------------------------------------------Show Data JobNoEdit In Modal-----------------------------------------
    Private Sub selectJobNoEdit()
        Dim testdate As Integer
        Dim jobno_code As String = ""
        Dim status_ As Double
        If String.IsNullOrEmpty(txtJobNo_BeforeTab.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            status_ = 0
        Else
            jobno_code = txtJobNo_BeforeTab.Value.Trim

        End If

        ' Where (u.ProductCode = ProCode) Or u.CreateDate.Year = testdate And u.ImpProductCode <> ""
        Dim cons = (From u In db.tblWHISSUEDs
                    Where (u.LOTNo.Contains(txtJobNo_BeforeTab.Value.Trim)) Or (u.PullDate.Year = testdate)
                   Select New With {u.LOTNo,
                                    u.PullSignal,
                                    u.PullDate,
                                    u.PullTime,
                                    u.DeliveryDate}).ToList()

        If cons.Count > 0 Then
            Repeater7.DataSource = cons.ToList
            Repeater7.DataBind()
            ScriptManager.RegisterStartupScript(JobNoEditUpdatePanel, JobNoEditUpdatePanel.GetType(), "show", "$(function () { $('#" + JobNoEditPanel.ClientID + "').modal('show'); });", True)
            JobNoEditUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Job No นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search JobNoEdit-----------------------------------------------
    Protected Sub btnJobNoHead_Edit_ServerClick(sender As Object, e As EventArgs)
        selectJobNoEdit()
    End Sub
    '--------------------------------------------------------Click Data JobNoEdit In Modal-----------------------------------------
    Protected Sub Repeater7_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater7.ItemCommand
        Dim LOTNo As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("Selectjobnoedit") Then

                If String.IsNullOrEmpty(LOTNo) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblWHISSUEDs Where u.LOTNo = LOTNo).SingleOrDefault

                    txtPullSignal_BeforeTab.Value = user.PullSignal
                    txtJobNo_BeforeTab.Value = user.LOTNo
                    txtdatepickertxtPullDateTime_beforeTab.Text = Convert.ToDateTime(user.PullDate).ToString("dd/MM/yyyy")
                    txtTimePickUpPullDateTime.Value = user.PullTime
                    txtdatepickerDeliveryDateTime_beforeTab.Text = Convert.ToDateTime(user.DeliveryDate).ToString("dd/MM/yyyy")
                    txtTimePickUpDeliveryDateTime.Value = user.DeliveryTime
                    txtdatepickerComfirmDateTime_beforeTab.Text = Convert.ToDateTime(user.ConfirmDate).ToString("dd/MM/yyyy")
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

                    DataPickingDetail()
                    DataIssuedDetail()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data Picking Detail In Modal-----------------------------------------
    Private Sub DataPickingDetail()
        Dim testdate As Integer
        Dim jobno_code As String = ""
        Dim pullsignal_code As String = ""
        Dim status_ As Double
        If String.IsNullOrEmpty(txtJobNo_BeforeTab.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            status_ = 0
        Else
            jobno_code = txtJobNo_BeforeTab.Value.Trim
            pullsignal_code = txtPullSignal_BeforeTab.Value.Trim
        End If

        Dim cons = (From p In db.tblWHPickingDetails
                    Where p.LOTNo = jobno_code And p.PullSignal = pullsignal_code And p.StatusISSUED = "0"
                   Select New With {p.PullSignal,
                                    p.LOTNo,
                                    p.ItemNo,
                                    p.WHSite,
                                    p.ENDCustomer,
                                    p.CustomerLOTNo,
                                    p.ProductCode}).ToList()

        If cons.Count > 0 Then
            Repeater8.DataSource = cons.ToList
            Repeater8.DataBind()
            DataIssuedDetailUpdatePanel.Update()
        Else
            Repeater8.DataSource = Nothing
            Repeater8.DataBind()
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------Click Data Data Job Detail In Modal Edit In Modal-----------------------------------------
    Protected Sub Repeater8_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater8.ItemCommand
        Dim ItemNooo As Double = CDbl(e.CommandArgument)
        Try
            If e.CommandName.Equals("Selectdatapickigdetail") Then

                If String.IsNullOrEmpty(CStr(ItemNooo)) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblWHPickingDetails Where u.LOTNo = txtJobNo_BeforeTab.Value.Trim And u.PullSignal = txtPullSignal_BeforeTab.Value.Trim And u.ItemNo = ItemNooo).SingleOrDefault

                    ddlWHSite_ConfirmIssue.Text = user.WHSite

                    If String.IsNullOrEmpty(user.WHLocation) Then
                        'ddlWHLocation_ConfirmIssue.Text = ""
                    Else
                        ddlWHLocation_ConfirmIssue.Text = user.WHLocation
                    End If

                    txtENDCustomer_ConfirmIssue.Value = user.ENDCustomer
                    txtCusLOTNo_ConfirmIssue.Value = user.CustomerLOTNo
                    txtItemNo_ConfirmIssue.Value = CStr(user.ItemNo)
                    txtEASPN_ConfirmIssue.Value = user.ProductCode
                    txtCustomerPN_ConfirmIssue.Value = user.CustomerPN
                    txtOwnerPN_ConfirmIssue.Value = user.OwnerPN
                    txtProductDesc_ConfirmIssue.Value = user.ProductDesc

                    If String.IsNullOrEmpty(user.WHLocation) Then
                        'ddlMeasurement_ConfirmIssue.Text = ""
                    Else
                        ddlMeasurement_ConfirmIssue.Text = user.Measurement
                    End If

                    txtWidth_ConfirmIssue.Value = CStr(user.ProductWidth)
                    txtHight_ConfirmIssue.Value = CStr(user.ProductHeight)
                    txtLength_ConfirmIssue.Value = CStr(user.ProductLength)
                    txtProductVolume_ConfirmIssue.Value = CStr(user.ProductVolume)
                    txtOrderNo_ConfirmIssue.Value = user.OrderNo
                    txtReceiveNo_ConfirmIssue.Value = user.ReceiveNo

                    If String.IsNullOrEmpty(user.WHLocation) Then
                        'ddlStatus_ConfirmIssue.Text = ""
                    Else
                        ddlStatus_ConfirmIssue.Text = user.Type
                    End If


                    txtdatepickerManufacturing_ConfirmIssue.Text = Convert.ToDateTime(user.ManufacturingDate).ToString("dd/MM/yyyy")
                    txtdatepickerExpiredDate_ConfirmIssue.Text = Convert.ToDateTime(user.ExpiredDate).ToString("dd/MM/yyyy")
                    txtdatepickerReceiveDate_ConfirmIssue.Text = Convert.ToDateTime(user.ReceiveDate).ToString("dd/MM/yyyy")
                    'txtQuantity_ConfirmIssue.Value = CStr(user.ISSUEDQuantity)
                    'ddlQuantity_ConfirmIssue.Text = user.ISSUEDUnit
                    txtWeight_ConfirmIssue.Value = CStr(user.Weigth)
                    ddlWeight_ConfirmIssue.Text = user.WeigthUnit
                    ddlCurrency_ConfirmIssue.Text = user.Currency
                    txtPriceForeign_ConfirmIssue.Value = CStr(user.PriceForeigh)
                    txtPriceBath_ConfirmIssue.Value = CStr(user.PriceBath)
                    txtExchangeRate_ConfirmIssue.Value = CStr(user.ExchangeRate)
                    txtAmount_ConfirmIssue.Value = CStr(user.PriceForeighAmount)
                    txtBathAmount_ConfirmIssue.Value = CStr(user.PriceBathAmount)
                    txtPalletNo_ConfirmIssue.Value = user.PalletNo

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data Job Detail In Modal-----------------------------------------
    Private Sub DataIssuedDetail()
        Dim testdate As Integer
        Dim jobno_code As String = ""
        Dim pullsignal_code As String = ""
        Dim status_ As Double
        If String.IsNullOrEmpty(txtJobNo_BeforeTab.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            status_ = 0
        Else
            jobno_code = txtJobNo_BeforeTab.Value.Trim
            pullsignal_code = txtPullSignal_BeforeTab.Value.Trim
        End If

        Dim cons = (From p In db.tblWHISSUEDDetails
                    Where p.LOTNo = jobno_code And p.PullSignal = pullsignal_code
                   Select New With {p.PullSignal,
                                    p.LOTNo,
                                    p.ItemNo,
                                    p.WHSite,
                                    p.WHLocation,
                                    p.ENDCustomer,
                                    p.CustomerLOTNo}).ToList()

        If cons.Count > 0 Then
            Repeater9.DataSource = cons.ToList
            Repeater9.DataBind()
            DataIssuedDetailUpdatePanel.Update()
        Else
            Repeater9.DataSource = Nothing
            Repeater9.DataBind()
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------Click Data Data Job Detail In Modal Edit In Modal-----------------------------------------
    Protected Sub Repeater9_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater9.ItemCommand
        Dim ItemNooo As Double = CDbl(e.CommandArgument)
        Try
            If e.CommandName.Equals("Selectdataissueddetail") Then

                If String.IsNullOrEmpty(CStr(ItemNooo)) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblWHISSUEDDetails Where u.LOTNo = txtJobNo_BeforeTab.Value.Trim And u.PullSignal = txtPullSignal_BeforeTab.Value.Trim And u.ItemNo = ItemNooo).SingleOrDefault

                    ddlWHSite_ConfirmIssue.Text = user.WHSite

                    If String.IsNullOrEmpty(user.WHLocation) Then
                        'ddlWHLocation_ConfirmIssue.Text = ""
                    Else
                        ddlWHLocation_ConfirmIssue.Text = user.WHLocation
                    End If

                    txtENDCustomer_ConfirmIssue.Value = user.ENDCustomer
                    txtCusLOTNo_ConfirmIssue.Value = user.CustomerLOTNo
                    txtItemNo_ConfirmIssue.Value = CStr(user.ItemNo)
                    txtEASPN_ConfirmIssue.Value = user.ProductCode
                    txtCustomerPN_ConfirmIssue.Value = user.CustomerPN
                    txtOwnerPN_ConfirmIssue.Value = user.OwnerPN
                    txtProductDesc_ConfirmIssue.Value = user.ProductDesc

                    If String.IsNullOrEmpty(user.WHLocation) Then
                        'ddlMeasurement_ConfirmIssue.Text = ""
                    Else
                        ddlMeasurement_ConfirmIssue.Text = user.Measurement
                    End If

                    txtWidth_ConfirmIssue.Value = CStr(user.ProductWidth)
                    txtHight_ConfirmIssue.Value = CStr(user.ProductHeight)
                    txtLength_ConfirmIssue.Value = CStr(user.ProductLength)
                    txtProductVolume_ConfirmIssue.Value = CStr(user.ProductVolume)
                    txtOrderNo_ConfirmIssue.Value = user.OrderNo
                    txtReceiveNo_ConfirmIssue.Value = user.ReceiveNo

                    If String.IsNullOrEmpty(user.WHLocation) Then
                        'ddlStatus_ConfirmIssue.Text = ""
                    Else
                        ddlStatus_ConfirmIssue.Text = user.Type
                    End If


                    txtdatepickerManufacturing_ConfirmIssue.Text = Convert.ToDateTime(user.ManufacturingDate).ToString("dd/MM/yyyy")
                    txtdatepickerExpiredDate_ConfirmIssue.Text = Convert.ToDateTime(user.ExpiredDate).ToString("dd/MM/yyyy")
                    txtdatepickerReceiveDate_ConfirmIssue.Text = Convert.ToDateTime(user.ReceiveDate).ToString("dd/MM/yyyy")
                    txtQuantity_ConfirmIssue.Value = CStr(user.ISSUEDQuantity)
                    ddlQuantity_ConfirmIssue.Text = user.ISSUEDUnit
                    txtWeight_ConfirmIssue.Value = CStr(user.Weigth)
                    ddlWeight_ConfirmIssue.Text = user.WeigthUnit
                    ddlCurrency_ConfirmIssue.Text = user.Currency
                    txtPriceForeign_ConfirmIssue.Value = CStr(user.PriceForeigh)
                    txtPriceBath_ConfirmIssue.Value = CStr(user.PriceBath)
                    txtExchangeRate_ConfirmIssue.Value = CStr(user.ExchangeRate)
                    txtAmount_ConfirmIssue.Value = CStr(user.PriceForeighAmount)
                    txtBathAmount_ConfirmIssue.Value = CStr(user.PriceBathAmount)
                    txtPalletNo_ConfirmIssue.Value = user.PalletNo

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function SaveIssued_New() As Boolean

        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()
                db.tblWHISSUEDs.Add(New tblWHISSUED With { _
            .PullSignal = txtPullSignal_BeforeTab.Value.Trim, _
            .LOTNo = txtJobNo_BeforeTab.Value.Trim, _
            .PullDate = CDate(txtdatepickertxtPullDateTime_beforeTab.Text.Trim), _
            .PullTime = txtTimePickUpPullDateTime.Value.Trim, _
            .DeliveryDate = CType(txtdatepickerDeliveryDateTime_beforeTab.Text.Trim, Date?), _
            .DeliveryTime = txtTimePickUpDeliveryDateTime.Value.Trim, _
            .ConfirmDate = CType(txtdatepickerComfirmDateTime_beforeTab.Text.Trim, Date?), _
            .ConfirmTime = txtTimePickUpConfirmDateTime.Value.Trim, _
            .ExporterCode = txtExporterCode_IssueCon.Value.Trim, _
            .ExporterName = txtNameExporter_IssueCon.Value.Trim, _
            .ExporterAddress1 = txtAddress1Exporter_IssueCon.Value.Trim, _
            .ExporterAddress2 = txtAddress2Exporter_IssueCon.Value.Trim, _
            .ExporterAddress3 = txtAddress3Exporter_IssueCon.Value.Trim, _
            .ExporterAddress4 = txtAddress4Exporter_IssueCon.Value.Trim, _
            .ConsigneeCode = txtConsigneeCode01_IssueCon.Value.Trim, _
            .ConsigneeName = txtNameConsignee_IssueCon.Value.Trim, _
            .ConsigneeAddress1 = txtAddress1Consignee_IssueCon.Value.Trim, _
            .ConsigneeAddress2 = txtAddress2Consignee_IssueCon.Value.Trim, _
            .ConsigneeAddress3 = txtAddress3Consignee_IssueCon.Value.Trim, _
            .ConsigneeAddress4 = txtAddress4Consignee_IssueCon.Value.Trim, _
            .OwnerCode = txtOwnerCode_IssueCon.Value.Trim, _
            .OwnerName = txtNameOwner_IssueCon.Value.Trim, _
            .OwnerAddress1 = txtAddress1Owner_IssueCon.Value.Trim, _
            .OwnerAddress2 = txtAddress2Owner_IssueCon.Value.Trim, _
            .OwnerAddress3 = txtAddress3Owner_IssueCon.Value.Trim, _
            .OwnerAddress4 = txtAddress4Owner_IssueCon.Value.Trim, _
            .ShipToCode = txtShipToCode_IssueCon.Value.Trim, _
            .ShipToName = txtNameShipTo_IssueCon.Value.Trim, _
            .ShipToAddress1 = txtAddress1ShipTo_IssueCon.Value.Trim, _
            .ShipToAddress2 = txtAddress2ShipTo_IssueCon.Value.Trim, _
            .ShipToAddress3 = txtAddress3ShipTo_IssueCon.Value.Trim, _
            .ShipToAddress4 = txtAddress4ShipTo_IssueCon.Value.Trim, _
            .Commodity = ddlCommodity_IssueCon.Text.Trim, _
            .QuantityOfPart = CType(txtQuantityOfGood_IssueCon.Value.Trim, Double?), _
            .QuantityUnit = ddlQuantityOfGood_IssueCon.Text.Trim, _
            .QuantityPackage = CType(txtQuantityPackage_IssueCon.Value.Trim, Double?), _
            .PackageUNIT = ddlQuantityPackage_IssueCon.Text.Trim, _
            .QuantityPLT = CType(txtQuantityPLTSkid_IssueCon.Value.Trim, Double?), _
            .QuantityPLTUnit = ddlQuantityPLTSkid_IssueCon.Text.Trim, _
            .Weight = CType(txtWeight_IssueCon.Value.Trim, Double?), _
            .WeightUnit = ddlWeight_IssueCon.Text.Trim, _
            .Volume = CType(txtVolume_IssueCon.Value.Trim, Double?), _
            .VolumeUnit = ddlVolume_IssueCon.Text.Trim, _
            .QuantityPicked = CType(txtQuantityPicked_IssueCon.Value.Trim, Double?), _
            .PickedUNIT = ddlQuantityPicked_IssueCon.Text.Trim, _
            .QuantityDiscrepancy = CType(txtQTYDiscrepancy_IssueCon.Value.Trim, Double?), _
            .DiscrepancyUNIT = ddlQTYDiscrepancy_IssueCon.Text.Trim, _
            .Remark = txtRemark_IssueCon.Value.Trim, _
            .PrintCount = "0", _
            .UserBy = CStr(Session("UserName")), _
            .LastUpdate = Now
                })
                db.SaveChanges()
                tran.Complete()
                Return True
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Add สำเร็จ !');", True)
            Catch ex As Exception
                Return False
                'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try
        End Using
    End Function
    Private Function SaveNew_RemarkMoveJob() As Boolean
        Dim S As String = "0"
        If chkMoveTo.Checked = False Then
            S = "NO"
        ElseIf chkMoveTo.Checked = True Then
            S = "YES"
        End If

        'sb.Append("INSERT INTO tblWHRemarkMoveJob (PullSignal,LOTNo,MovetoLot,CustREFNo,WHSite,Status1,UserBy,LastUpdate)")
        'sb.Append(" VALUES (@PullSignal,@LOTNo,@MovetoLot,@CustREFNo,@WHSite,@Status1,@UserBy,@LastUpdate)")

        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()
                db.tblWHRemarkMoveJobs.Add(New tblWHRemarkMoveJob With { _
            .PullSignal = txtPullSignal_BeforeTab.Value.Trim, _
                .LOTNo = txtJobNo_BeforeTab.Value.Trim, _
                .MovetoLot = txtJobNo_IssueCon.Value.Trim, _
                .CustREFNo = txtCustRefNo_IssueCon.Value.Trim, _
                .WHSite = ddlWHSite_IssueCon.Text.Trim, _
                .Status1 = S, _
                .UserBy = CStr(Session("UserName")), _
                .LastUpdate = Now
                })
                db.SaveChanges()
                tran.Complete()
                Return True
            Catch ex As Exception
                Return False
            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try
        End Using

    End Function
    Private Function SaveNew_Confirm() As Boolean

        'sb.Append("INSERT INTO tblWHConfirmGoodsReceive (LOTNo,LOTDate,CustREFNo,OwnerCode,OwnerNameENG,OwnerStreet_Number,OwnerDistrict,OwnerSubProvince,OwnerProvince,Commodity,QuantityOfPart,QuantityUnit,QuantityPackage,PackageUNIT,QuantityPLT,QuantityPLTUnit,Weigth,WeigthUnit,Volume,VolumeUnit,Remark,PrintCount,UserBy,LastUpdate)")
        'sb.Append(" VALUES (@LOTNo,@LOTDate,@CustREFNo,@OwnerCode,@OwnerNameENG,@OwnerStreet_Number,@OwnerDistrict,@OwnerSubProvince,@OwnerProvince,@Commodity,@QuantityOfPart,@QuantityUnit,@QuantityPackage,@PackageUNIT,@QuantityPLT,@QuantityPLTUnit,@Weigth,@WeigthUnit,@Volume,@VolumeUnit,@Remark,@PrintCount,@UserBy,@LastUpdate)")

        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()
                db.tblWHConfirmGoodsReceives.Add(New tblWHConfirmGoodsReceive With { _
                .LOTNo = txtJobNo_IssueCon.Value.Trim, _
                .LOTDate = Now, _
                .CustREFNo = txtCustRefNo_IssueCon.Value.Trim, _
                .OwnerCode = txtOwnerCode_IssueCon.Value.Trim, _
                .OwnerNameENG = txtNameOwner_IssueCon.Value.Trim, _
                .OwnerStreet_Number = txtAddress1Owner_IssueCon.Value.Trim, _
                .OwnerDistrict = txtAddress2Owner_IssueCon.Value.Trim, _
                .OwnerSubProvince = txtAddress3Owner_IssueCon.Value.Trim, _
                .OwnerProvince = txtAddress4Owner_IssueCon.Value.Trim, _
                .Commodity = ddlCommodity_IssueCon.Text.Trim, _
                .QuantityOfPart = CType(txtQuantityOfGood_IssueCon.Value.Trim, Double?), _
                .QuantityUnit = ddlQuantityOfGood_IssueCon.Text.Trim, _
                .QuantityPackage = CType(txtQuantityPackage_IssueCon.Value.Trim, Double?), _
                .PackageUNIT = ddlQuantityPackage_IssueCon.Text.Trim, _
                .QuantityPLT = CType(txtQuantityPLTSkid_IssueCon.Value.Trim, Double?), _
                .QuantityPLTUnit = ddlQuantityPLTSkid_IssueCon.Text.Trim, _
                .Weigth = CType(txtWeight_IssueCon.Value.Trim, Double?), _
                .WeigthUnit = ddlWeight_IssueCon.Text.Trim, _
                .Volume = CType(txtVolume_IssueCon.Value.Trim, Double?), _
                .VolumeUnit = ddlVolume_IssueCon.Text.Trim, _
                .Remark = txtRemark_IssueCon.Value.Trim, _
                .PrintCount = "0", _
                .UserBy = CStr(Session("UserName")), _
                .LastUpdate = Now
                })

                db.SaveChanges()
                tran.Complete()
                Return True
            Catch ex As Exception
                Return False
            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try
        End Using

    End Function
    Private Function SaveNew_ConfirmNJR() As Boolean

        'sb.Append("INSERT INTO tblWHConfirmGoodsReceive (LOTNo,LOTDate,CustREFNo,OwnerCode,OwnerNameENG,OwnerStreet_Number,OwnerDistrict,OwnerSubProvince,OwnerProvince,Commodity,QuantityOfPart,QuantityUnit,QuantityPackage,PackageUNIT,QuantityPLT,QuantityPLTUnit,Weigth,WeigthUnit,Volume,VolumeUnit,Remark,PrintCount,UserBy,LastUpdate)")
        'sb.Append(" VALUES (@LOTNo,@LOTDate,@CustREFNo,@OwnerCode,@OwnerNameENG,@OwnerStreet_Number,@OwnerDistrict,@OwnerSubProvince,@OwnerProvince,@Commodity,@QuantityOfPart,@QuantityUnit,@QuantityPackage,@PackageUNIT,@QuantityPLT,@QuantityPLTUnit,@Weigth,@WeigthUnit,@Volume,@VolumeUnit,@Remark,@PrintCount,@UserBy,@LastUpdate)")

        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()
                db.tblWHConfirmGoodsReceives.Add(New tblWHConfirmGoodsReceive With { _
                .LOTNo = txtJobNo_IssueCon.Value.Trim, _
                .LOTDate = Now, _
                .CustREFNo = txtCustRefNo_IssueCon.Value.Trim, _
                .OwnerCode = txtOwnerCode_IssueCon.Value.Trim, _
                .OwnerNameENG = txtNameOwner_IssueCon.Value.Trim, _
                .OwnerStreet_Number = txtAddress1Owner_IssueCon.Value.Trim, _
                .OwnerDistrict = txtAddress2Owner_IssueCon.Value.Trim, _
                .OwnerSubProvince = txtAddress3Owner_IssueCon.Value.Trim, _
                .OwnerProvince = txtAddress4Owner_IssueCon.Value.Trim, _
                .Commodity = ddlCommodity_IssueCon.Text.Trim, _
                .QuantityOfPart = CType(txtQuantityOfGood_IssueCon.Value.Trim, Double?), _
                .QuantityUnit = ddlQuantityOfGood_IssueCon.Text.Trim, _
                .QuantityPackage = CType(txtQuantityPackage_IssueCon.Value.Trim, Double?), _
                .PackageUNIT = ddlQuantityPackage_IssueCon.Text.Trim, _
                .QuantityPLT = CType(txtQuantityPLTSkid_IssueCon.Value.Trim, Double?), _
                .QuantityPLTUnit = ddlQuantityPLTSkid_IssueCon.Text.Trim, _
                .Weigth = CType(txtWeight_IssueCon.Value.Trim, Double?), _
                .WeigthUnit = ddlWeight_IssueCon.Text.Trim, _
                .Volume = CType(txtVolume_IssueCon.Value.Trim, Double?), _
                .VolumeUnit = ddlVolume_IssueCon.Text.Trim, _
                .Remark = txtRemark_IssueCon.Value.Trim, _
                .PrintCount = "0", _
                .UserBy = CStr(Session("UserName")), _
                .LastUpdate = Now
                })

                db.SaveChanges()
                tran.Complete()
                Return True
            Catch ex As Exception
                Return False
            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try
        End Using

    End Function

    Private Sub CheckMoveTo()

        If strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "HCR-IN" Then
            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "HCR-OUT" And strReceivedJobNo = "LKB-IN" Then
            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "AEC-OUT" And strReceivedJobNo = "LKB-IN" Then
            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "AEC-IN" Then
            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "HTO-OUT" And strReceivedJobNo = "LKB-IN" Then
            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "HTO-IN" Then
            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "MJB-OUT" And strReceivedJobNo = "LKB-IN" Then
            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "MJB-IN" Then
            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "LEA-OUT" And strReceivedJobNo = "LKB-IN" Then
            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "LEA-IN" Then
            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "LKB-IN" Then
            If Not (ddlWHSite_IssueCon.Text.Trim = "NJR-US" Or ddlWHSite_IssueCon.Text.Trim = "NJR-CN" Or ddlWHSite_IssueCon.Text.Trim = "NJR-SG") Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('JOB LKB ย้ายไป LKB ได้เฉพาะงาน NJR !!!');", True)
                Exit Sub
            End If

            SaveNew_ConfirmNJR()

        ElseIf strIssuedJobNo = "CKT-OUT" And strReceivedJobNo = "CKT-IN" Then
            If Not (ddlWHSite_IssueCon.Text.Trim = "EPN-EVENT" Or ddlWHSite_IssueCon.Text.Trim = "EPN-ONLINE") Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('JOB CKT ย้ายไป CKT ได้เฉพาะงาน EPN !!!');", True)
                Exit Sub
            End If

            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        ElseIf strIssuedJobNo = "CKT-OUT" And strReceivedJobNo = "CKT-IN" Then
            If Not (ddlWHSite_IssueCon.Text.Trim = "EPN-EVENT" Or ddlWHSite_IssueCon.Text.Trim = "EPN-ONLINE") Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('JOB CKT ย้ายไป CKT ได้เฉพาะงาน EPN !!!');", True)
                Exit Sub
            End If

            If SaveNew_Confirm() = False Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveNew_Confirm');", True)
                Exit Sub
            End If

        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('รายการ Move To Clean Room JOB ที่คุณใส่ไม่ถูกต้อง , ระบบจะไม่บันทึกข้อมูลให้คุณ , กรุณาแก้ไขข้อมูลอีกครั้งก่อนบันทึก !!!');", True)
            Exit Sub
        End If
    End Sub

    Private Function UpdateRead1() As Boolean

        'sb.Append("UPDATE tblWHPicking")
        'sb.Append(" SET UsedStatus=@UsedStatus")
        'sb.Append(" WHERE (PullSignal=@PullSignal AND LOTNo=@LOTNo)")

        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()
                Dim edit As tblWHPicking = (From c In db.tblWHPickings Where c.LOTNo = txtJobNo_BeforeTab.Value.Trim And c.PullSignal = txtPullSignal_BeforeTab.Value.Trim
                  Select c).First()
                If edit IsNot Nothing Then
                    edit.PullSignal = txtPullSignal_BeforeTab.Value.Trim
                    edit.LOTNo = txtJobNo_BeforeTab.Value.Trim
                    edit.UsedStatus = 1

                    db.SaveChanges()
                    tran.Complete()
                End If
                Return True

            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

    Private Sub SaveIssued_Modify()
        If txtJobNo_BeforeTab.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(กรุณาป้อน Job No ก่อน !!!);", True)
            txtJobNo_BeforeTab.Focus()
            Exit Sub
        End If

        If txtPullSignal_BeforeTab.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(กรุณาป้อน Pull Signal ก่อน !!!);", True)
            txtPullSignal_BeforeTab.Focus()
            Exit Sub
        End If

        'sb.Append("UPDATE tblWHISSUED")
        'sb.Append(" SET PullDate=@PullDate,PullTime=@PullTime,DeliveryDate=@DeliveryDate,DeliveryTime=@DeliveryTime,ConfirmDate=@ConfirmDate,ConfirmTime=@ConfirmTime,ExporterCode=@ExporterCode,ExporterName=@ExporterName,ExporterAddress1=@ExporterAddress1,ExporterAddress2=@ExporterAddress2,ExporterAddress3=@ExporterAddress3,ExporterAddress4=@ExporterAddress4,ConsigneeCode=@ConsigneeCode,ConsigneeName=@ConsigneeName,ConsigneeAddress1=@ConsigneeAddress1,ConsigneeAddress2=@ConsigneeAddress2,ConsigneeAddress3=@ConsigneeAddress3,ConsigneeAddress4=@ConsigneeAddress4,OwnerCode=@OwnerCode,OwnerName=@OwnerName,OwnerAddress1=@OwnerAddress1,OwnerAddress2=@OwnerAddress2,OwnerAddress3=@OwnerAddress3,OwnerAddress4=@OwnerAddress4,ShipToCode=@ShipToCode,ShipToName=@ShipToName,ShipToAddress1=@ShipToAddress1,ShipToAddress2=@ShipToAddress2,ShipToAddress3=@ShipToAddress3,ShipToAddress4=@ShipToAddress4,Commodity=@Commodity,QuantityOfPart=@QuantityOfPart,QuantityUnit=@QuantityUnit,QuantityPackage=@QuantityPackage,PackageUNIT=@PackageUNIT,QuantityPLT=@QuantityPLT,QuantityPLTUnit=@QuantityPLTUnit,Weight=@Weight,WeightUnit=@WeightUnit,Volume=@Volume,VolumeUnit=@VolumeUnit,QuantityPicked=@QuantityPicked,PickedUNIT=@PickedUNIT,QuantityDiscrepancy=@QuantityDiscrepancy,DiscrepancyUNIT=@DiscrepancyUNIT,Remark=@Remark,UserBy=@UserBy,LastUpdate=@LastUpdate")
        'sb.Append(" WHERE (PullSignal=@PullSignal AND LOTNo=@LOTNo)")
        If MsgBox("คุณต้องการแก้ไขรายการ Issued ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    Dim edit As tblWHISSUED = (From c In db.tblWHISSUEDs Where c.LOTNo = txtJobNo_BeforeTab.Value.Trim And c.PullSignal = txtPullSignal_BeforeTab.Value.Trim
                          Select c).First()
                    If edit IsNot Nothing Then
                        edit.PullSignal = txtPullSignal_BeforeTab.Value.Trim
                        edit.LOTNo = txtJobNo_BeforeTab.Value.Trim
                        edit.PullDate = CDate(txtdatepickertxtPullDateTime_beforeTab.Text.Trim)
                        edit.PullTime = txtTimePickUpPullDateTime.Value.Trim
                        edit.DeliveryDate = CType(txtdatepickerDeliveryDateTime_beforeTab.Text.Trim, Date?)
                        edit.DeliveryTime = txtTimePickUpDeliveryDateTime.Value.Trim
                        edit.ConfirmDate = CType(txtdatepickerComfirmDateTime_beforeTab.Text.Trim, Date?)
                        edit.ConfirmTime = txtTimePickUpConfirmDateTime.Value.Trim
                        edit.ExporterCode = txtExporterCode_IssueCon.Value.Trim
                        edit.ExporterName = txtNameExporter_IssueCon.Value.Trim
                        edit.ExporterAddress1 = txtAddress1Exporter_IssueCon.Value.Trim
                        edit.ExporterAddress2 = txtAddress2Exporter_IssueCon.Value.Trim
                        edit.ExporterAddress3 = txtAddress3Exporter_IssueCon.Value.Trim
                        edit.ExporterAddress4 = txtAddress4Exporter_IssueCon.Value.Trim
                        edit.ConsigneeCode = txtConsigneeCode01_IssueCon.Value.Trim
                        edit.ConsigneeName = txtNameConsignee_IssueCon.Value.Trim
                        edit.ConsigneeAddress1 = txtAddress1Consignee_IssueCon.Value.Trim
                        edit.ConsigneeAddress2 = txtAddress2Consignee_IssueCon.Value.Trim
                        edit.ConsigneeAddress3 = txtAddress3Consignee_IssueCon.Value.Trim
                        edit.ConsigneeAddress4 = txtAddress4Consignee_IssueCon.Value.Trim
                        edit.OwnerCode = txtOwnerCode_IssueCon.Value.Trim
                        edit.OwnerName = txtNameOwner_IssueCon.Value.Trim
                        edit.OwnerAddress1 = txtAddress1Owner_IssueCon.Value.Trim
                        edit.OwnerAddress2 = txtAddress2Owner_IssueCon.Value.Trim
                        edit.OwnerAddress3 = txtAddress3Owner_IssueCon.Value.Trim
                        edit.OwnerAddress4 = txtAddress4Owner_IssueCon.Value.Trim
                        edit.ShipToCode = txtShipToCode_IssueCon.Value.Trim
                        edit.ShipToName = txtNameShipTo_IssueCon.Value.Trim
                        edit.ShipToAddress1 = txtAddress1ShipTo_IssueCon.Value.Trim
                        edit.ShipToAddress2 = txtAddress2ShipTo_IssueCon.Value.Trim
                        edit.ShipToAddress3 = txtAddress3ShipTo_IssueCon.Value.Trim
                        edit.ShipToAddress4 = txtAddress4ShipTo_IssueCon.Value.Trim
                        edit.Commodity = ddlCommodity_IssueCon.Text.Trim
                        edit.QuantityOfPart = CType(txtQuantityOfGood_IssueCon.Value.Trim, Double?)
                        edit.QuantityUnit = ddlQuantityOfGood_IssueCon.Text.Trim
                        edit.QuantityPackage = CType(txtQuantityPackage_IssueCon.Value.Trim, Double?)
                        edit.PackageUNIT = ddlQuantityPackage_IssueCon.Text.Trim
                        edit.QuantityPLT = CType(txtQuantityPLTSkid_IssueCon.Value.Trim, Double?)
                        edit.QuantityPLTUnit = ddlQuantityPLTSkid_IssueCon.Text.Trim
                        edit.Weight = CType(txtWeight_IssueCon.Value.Trim, Double?)
                        edit.WeightUnit = ddlWeight_IssueCon.Text.Trim
                        edit.Volume = CType(txtVolume_IssueCon.Value.Trim, Double?)
                        edit.VolumeUnit = ddlVolume_IssueCon.Text.Trim
                        edit.QuantityPicked = CType(txtQuantityPicked_IssueCon.Value.Trim, Double?)
                        edit.PickedUNIT = ddlQuantityPicked_IssueCon.Text.Trim
                        edit.QuantityDiscrepancy = CType(txtQTYDiscrepancy_IssueCon.Value.Trim, Double?)
                        edit.DiscrepancyUNIT = ddlQTYDiscrepancy_IssueCon.Text.Trim
                        edit.Remark = txtRemark_IssueCon.Value.Trim
                        edit.UserBy = CStr(Session("UserName"))
                        edit.LastUpdate = Now

                        db.SaveChanges()
                        tran.Complete()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                    End If
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        txtJobNo_BeforeTab.Focus()
    End Sub
    Private Sub CountWHIssued()

        'Dim i As Integer
        'Dim Goods As Double
        'With Repeater9
        '    For i = 0 To Repeater9.Items.Count - 1

        '        Goods = Goods + CDbl(.Rows(i).Cells(24).Value)

        '    Next
        'End With
        'txtQtyReceived.Text = CStr(Goods)
        'txtQtyDiscrepancy.Text = CStr(CDbl(txtQuantityofPart.Text) - Goods)

    End Sub

    Private Sub ReadDataMove()
        'Dim LotIn As String
        'Dim sql As String
        'sql = "SELECT * FROM tblWHRemarkMoveJob(nolock) WHERE LOTNo = '" & txtLOTNo.Text & "' and PullSignal = '" & txtPullSignal.Text & "'"

        'Dim dr As SqlDataReader
        'com = New SqlCommand()
        'With com
        '    .CommandType = CommandType.Text
        '    .CommandText = sql
        '    .Connection = Conn
        '    dr = .ExecuteReader()
        '    If dr.HasRows Then
        '        dr.Read()
        '        LotIn = dr.Item("MovetoLot").ToString
        '        dr.Close()
        '        Dim sqlRead As String
        '        sqlRead = "SELECT * FROM tblWHISSUEDDetail (nolock) WHERE LOTNo = '" & txtLOTNo.Text & "' and PullSignal = '" & txtPullSignal.Text & "'  "

        '        Dim dr1 As SqlDataReader
        '        Dim dt As DataTable
        '        com = New SqlCommand()
        '        With com
        '            .CommandType = CommandType.Text
        '            .CommandText = sqlRead
        '            .Connection = Conn
        '            dr1 = .ExecuteReader()
        '            If dr1.HasRows Then
        '                dr1.Close()
        '                MessageBox.Show("กรุณา Reject Confirm หรือ Reject Issue ก่อนครับ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Else
        '                dr1.Close()
        '                If MessageBox.Show("คุณต้องการ Reject Moveto ใช่หรือไม่?", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        '                    tr = Conn.BeginTransaction()
        '                    Try
        '                        sb = New StringBuilder()
        '                        sb.Append("Delete tblWHConfirmGoodsReceive")
        '                        sb.Append(" WHERE (LOTNo=@LOTNo  )")
        '                        Dim sqlDelete As String
        '                        sqlDelete = sb.ToString()

        '                        With com
        '                            .CommandText = sqlDelete
        '                            .CommandType = CommandType.Text
        '                            .Connection = Conn
        '                            .Transaction = tr
        '                            .Parameters.Clear()
        '                            .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = LotIn
        '                            .ExecuteNonQuery()
        '                        End With

        '                        sb = New StringBuilder()
        '                        sb.Append("Delete tblWHConfirmGoodsReceiveDetail")
        '                        sb.Append(" WHERE (LOTNo=@LOTNo and StatusAvailable = 0 )")
        '                        Dim sqlDelete1 As String
        '                        sqlDelete1 = sb.ToString()

        '                        With com
        '                            .CommandText = sqlDelete1
        '                            .CommandType = CommandType.Text
        '                            .Connection = Conn
        '                            .Transaction = tr
        '                            .Parameters.Clear()
        '                            .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = LotIn
        '                            .ExecuteNonQuery()
        '                        End With

        '                        sb = New StringBuilder()
        '                        sb.Append("Delete tblWHStockMovement")
        '                        sb.Append(" WHERE (LOTNo=@LOTNo and Status = 0 )")
        '                        Dim sqlDelete2 As String
        '                        sqlDelete2 = sb.ToString()

        '                        With com
        '                            .CommandText = sqlDelete2
        '                            .CommandType = CommandType.Text
        '                            .Connection = Conn
        '                            .Transaction = tr
        '                            .Parameters.Clear()
        '                            .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = LotIn
        '                            .ExecuteNonQuery()
        '                        End With

        '                        sb = New StringBuilder()
        '                        sb.Append("Delete tblWHRemarkMoveJob")
        '                        sb.Append(" WHERE (LOTNo=@LOTNo and PullSignal = @PullSignal )")
        '                        Dim sqlDelete3 As String
        '                        sqlDelete3 = sb.ToString()

        '                        With com
        '                            .CommandText = sqlDelete3
        '                            .CommandType = CommandType.Text
        '                            .Connection = Conn
        '                            .Transaction = tr
        '                            .Parameters.Clear()
        '                            .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = txtLOTNo.Text.Trim
        '                            .Parameters.Add("@PullSignal", SqlDbType.NVarChar).Value = txtPullSignal.Text.Trim
        '                            .ExecuteNonQuery()
        '                        End With

        '                        sb = New StringBuilder()
        '                        sb.Append("Delete tblWHISSUED")
        '                        sb.Append(" WHERE (LOTNo=@LOTNo and PullSignal = @PullSignal )")
        '                        Dim sqlDelete4 As String
        '                        sqlDelete4 = sb.ToString()

        '                        With com
        '                            .CommandText = sqlDelete4
        '                            .CommandType = CommandType.Text
        '                            .Connection = Conn
        '                            .Transaction = tr
        '                            .Parameters.Clear()
        '                            .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = txtLOTNo.Text.Trim
        '                            .Parameters.Add("@PullSignal", SqlDbType.NVarChar).Value = txtPullSignal.Text.Trim
        '                            .ExecuteNonQuery()
        '                        End With

        '                        sb = New StringBuilder()
        '                        sb.Append("UPDATE tblWHPicking")
        '                        sb.Append(" SET UsedStatus=0 ")
        '                        sb.Append(" WHERE (LOTNo=@LOTNo and PullSignal = @PullSignal)")
        '                        Dim sqlEdit As String
        '                        sqlEdit = sb.ToString()

        '                        With com
        '                            .CommandText = sqlEdit
        '                            .CommandType = CommandType.Text
        '                            .Connection = Conn
        '                            .Transaction = tr
        '                            .Parameters.Clear()
        '                            .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = txtLOTNo.Text.Trim
        '                            .Parameters.Add("@PullSignal", SqlDbType.NVarChar).Value = txtPullSignal.Text.Trim

        '                            Dim result As Integer
        '                            result = .ExecuteNonQuery()
        '                            If result = 0 Then
        '                                tr.Rollback()
        '                                MessageBox.Show("tblWHPicking  ไม่ถูกต้อง !!!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '                            Else
        '                                tr.Commit()
        '                                MessageBox.Show("Reject Moveto เรียบร้อยแล้วครับ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '                            End If
        '                        End With

        '                    Catch ex As Exception
        '                        tr.Rollback()
        '                        MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก " & ex.Message, "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    End Try
        '                End If
        '            End If
        '        End With
        '    Else
        '        dr.Close()
        '        MessageBox.Show("คุณยังไม่ได้บันทึกข้อมูล", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        '    End If
        'End With

    End Sub

    Protected Sub btnIssue_ConfirmIssue_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            'CallculateProductQuantiy()
            SaveIsseudDetail_New()
            'ClearDATADetail()
            DataPickingDetail()
            DataIssuedDetail()
            CountWHIssued()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub

    Private Sub SaveIsseudDetail_New()
        Dim chkName As CheckBox
        Dim lblUserName As String
        'If txtPullSignal.Text.Trim() = "" Then
        '    MessageBox.Show("กรุณาใส่ Pull Signal ก่อน !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtPullSignal.Focus()
        '    Exit Sub
        'End If

        'If txtLOTNo.Text.Trim() = "" Then
        '    MessageBox.Show("กรุณาป้อน รหัส LOTNo ก่อน !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtLOTNo.Focus()
        '    Exit Sub
        'End If

        'If txtItemNo.Text.Trim() = "" Then
        '    MessageBox.Show("กรุณาใส่ ItemNo ก่อน !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtItemNo.Focus()
        '    Exit Sub
        'End If

        Dim i As Integer = 0

        For i = 0 To Repeater8.Items.Count - 1

            chkName = CType(Repeater8.Items(i).FindControl("chkRowData"), CheckBox)
            lblUserName = CType(Repeater8.Items(i).FindControl("lblItemNo"), Label).Text.Trim

            If chkName.Checked = True Then
                'If CBool(Repeater8.Items(i).Cells(0).FormattedValue) = True Then

                Try
                    'If SaveIssued(i) = False Then
                    '    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveIssued');", True)
                    '    Exit Sub
                    'End If

                    If SavePickDetail1_Modify(i) = False Then
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SavePickDetail1');", True)
                        Exit Sub
                    End If

                    If SaveStockMovement_New(i) = False Then
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก SaveStockMovement');", True)
                        Exit Sub
                    End If

                    If chkMoveTo.Checked = True Then
                        If strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "HCR-IN" Then
                            If ConfirmMove(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด ConfirmMove');", True)
                                Exit Sub
                            End If

                        ElseIf strIssuedJobNo = "HCR-OUT" And strReceivedJobNo = "LKB-IN" Then
                            If ConfirmMove(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด ConfirmMove');", True)
                                Exit Sub
                            End If
                        ElseIf strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "AEC-IN" Then
                            If ConfirmMove(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด ConfirmMove');", True)
                                Exit Sub
                            End If
                        ElseIf strIssuedJobNo = "AEC-OUT" And strReceivedJobNo = "LKB-IN" Then
                            If ConfirmMove(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด ConfirmMove');", True)
                                Exit Sub
                            End If
                        ElseIf strIssuedJobNo = "HTO-OUT" And strReceivedJobNo = "LKB-IN" Then
                            If ConfirmMove(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด ConfirmMove');", True)
                                Exit Sub
                            End If
                        ElseIf strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "HTO-IN" Then
                            If ConfirmMove(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด ConfirmMove');", True)
                                Exit Sub
                            End If
                        ElseIf strIssuedJobNo = "MJB-OUT" And strReceivedJobNo = "LKB-IN" Then
                            If ConfirmMove(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด ConfirmMove');", True)
                                Exit Sub
                            End If
                        ElseIf strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "MJB-IN" Then
                            If ConfirmMove(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด ConfirmMove');", True)
                                Exit Sub
                            End If
                        ElseIf strIssuedJobNo = "LEA-OUT" And strReceivedJobNo = "LKB-IN" Then
                            If ConfirmMove(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด ConfirmMove');", True)
                                Exit Sub
                            End If
                        ElseIf strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "LEA-IN" Then
                            If ConfirmMove(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด ConfirmMove');", True)
                                Exit Sub
                            End If
                        ElseIf strIssuedJobNo = "LKB-OUT" And strReceivedJobNo = "LKB-IN" Then
                            If SaveDetail_ConfirmNewNJR(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด SaveDetail_ConfirmNewNJR');", True)
                                Exit Sub
                            End If
                            If SaveStockMovement_ConfirmNewNJR(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด SaveStockMovement_ConfirmNewNJR');", True)
                                Exit Sub
                            End If
                        ElseIf strIssuedJobNo = "CKT-OUT" And strReceivedJobNo = "CKT-IN" Then
                            If SaveDetail_ConfirmNewNJR(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด SaveDetail_ConfirmNewEPN');", True)
                                Exit Sub
                            End If
                            If SaveStockMovement_ConfirmNewNJR(i) = False Then
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด SaveStockMovement_ConfirmNewEPN');", True)
                                Exit Sub
                            End If
                        Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('รายการ Move To Clean Room JOB ที่คุณใส่ไม่ถูกต้อง , ระบบจะไม่บันทึกข้อมูลให้คุณ , กรุณาแก้ไขข้อมูลอีกครั้งก่อนบันทึก !!!');", True)
                            Exit Sub
                        End If
                    End If

                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก ผลการทำงาน');", True)
                    Exit Sub
                End Try
            End If
        Next

    End Sub
    Private Function SaveIssued(ByVal i As Integer) As Boolean
        Dim chkName As CheckBox
        Dim lblItemNo As Double

        chkName = CType(Repeater8.Items(i).FindControl("chkRowData"), CheckBox)
        lblItemNo = CDbl(CType(Repeater8.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
        Try

            Dim u = (From us In db.tblWHPickingDetails Where us.ItemNo = lblItemNo And us.LOTNo = txtJobNo_BeforeTab.Value.Trim And us.PalletNo = txtPullSignal_BeforeTab.Value.Trim).FirstOrDefault
            If Not IsNothing(u) Then

                db.tblWHISSUEDDetails.Add(New tblWHISSUEDDetail With { _
                    .PullSignal = u.PalletNo, _
                .LOTNo = u.LOTNo, _
                .WHSite = u.WHSite, _
                .WHLocation = u.WHLocation, _
                .ENDCustomer = u.ENDCustomer, _
                .CustomerLOTNo = u.CustomerLOTNo, _
                .WHSource = u.WHSource, _
                .ItemNo = u.ItemNo, _
                .ProductCode = u.ProductCode, _
                .CustomerPN = u.CustomerPN, _
                .OwnerPN = u.OwnerPN, _
                .ProductDesc = u.ProductDesc, _
                .Measurement = u.Measurement, _
                .ProductWidth = u.ProductWidth, _
                .ProductLength = u.ProductLength, _
                .ProductHeight = u.ProductHeight, _
                .ProductVolume = u.ProductVolume, _
                .OrderNo = u.OrderNo, _
                .ReceiveNo = u.ReceiveNo, _
                .Type = u.Type, _
                .ManufacturingDate = u.ManufacturingDate, _
                .ExpiredDate = u.ExpiredDate, _
                .ReceiveDate = u.ReceiveDate, _
                .ISSUEDDate = CType(txtdatepickerComfirmDateTime_beforeTab.Text.Trim, Date?), _
                .ISSUEDQuantity = u.PickQuantity, _
                .ISSUEDUnit = u.PickUnit, _
                .STKBeforISSUED = 0, _
                .STKLastISSUED = 0, _
                .Weigth = u.Weigth, _
                .WeigthUnit = u.WeigthUnit, _
                .Currency = u.Currency, _
                .ExchangeRate = u.ExchangeRate, _
                .PriceForeigh = u.PriceForeigh, _
                .PriceForeighAmount = u.PriceForeighAmount, _
                .PriceBath = u.PriceBath, _
                .PriceBathAmount = u.PriceBathAmount, _
                .StatusISSUED = "1", _
                .PalletNo = u.PalletNo, _
                .UserBy = CStr(Session("UserName")), _
                .LastUpdate = Now, _
                .TypeDamage = "", _
                .Item = u.Item, _
                .Supplier = u.Supplier, _
                .Buyer = u.Buyer, _
                .Exporter = u.Exporter, _
                .Destination = u.Destination, _
                .Consignee = u.Consignee, _
                .ShippingMark = u.ShippingMark, _
                .ExpInvNo = u.ExpInvNo, _
                .PONo = u.PONo, _
                .EntryNo = u.EntryNo, _
                .EntryItemNo = u.EntryItemNo
                    })
                db.SaveChanges()
            End If
            Return True
        Catch
            Return False
        Finally

        End Try
    End Function
    Private Function SavePickDetail1_Modify(ByVal i As Integer) As Boolean
        Dim lblItemNo As Double

        lblItemNo = CDbl(CType(Repeater8.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
        'sb.Append("UPDATE tblWHPickingDetail")
        'sb.Append(" SET StatusISSUED=@StatusISSUED")
        'sb.Append(" WHERE (PullSignal=@PullSignal AND LOTNo=@LOTNo AND ItemNo=@ItemNo AND ReceiveNo=@ReceiveNo AND Item=@Item)")
        Try
            Dim u = (From us In db.tblWHPickingDetails Where us.ItemNo = lblItemNo And us.LOTNo = txtJobNo_BeforeTab.Value.Trim And us.PalletNo = txtPullSignal_BeforeTab.Value.Trim).FirstOrDefault

            db.Database.Connection.Open()
            Dim edit As tblWHPickingDetail = (From c In db.tblWHPickingDetails Where c.ItemNo = lblItemNo And c.LOTNo = txtJobNo_BeforeTab.Value.Trim And c.PullSignal = txtPullSignal_BeforeTab.Value.Trim
              Select c).First()
            If edit IsNot Nothing Then
                'edit.PullSignal = txtPullSignal_BeforeTab.Value.Trim
                'edit.LOTNo = txtJobNo_BeforeTab.Value.Trim
                'edit.ItemNo = u.ItemNo
                'edit.ReceiveNo = u.ReceiveNo
                edit.StatusISSUED = "1"
                'edit.Item = u.Item

                db.SaveChanges()
            End If
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Function SaveStockMovement_New(ByVal i As Integer) As Boolean
        Dim lblItemNo As Double
        Dim ManuDate As Nullable(Of Date)
        Dim ExpDate As Nullable(Of Date)

        lblItemNo = CDbl(CType(Repeater8.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
        Try

            strIssuedJobNo = Mid(txtJobNo_BeforeTab.Value.Trim, 1, 7)
            strReceivedJobNo = Mid(txtJobNo_IssueCon.Value.Trim, 1, 6)

            'sb.Append("INSERT INTO tblWHStockMovement (LOTNo,WHSite,WHLocation,OwnerCode,ENDCustomer,WHSource,CustomerLOTNo,ItemNo,ProductCode,CustomerPN,OwnerPN,ProductDesc,Measurement,ProductWidth,ProductLength,ProductHeight,ProductVolume,OrderNo,ReceiveNo,Type,ManufacturingDate,ExpiredDate,ReceiveDate,ISSUEDate,StockType,ISSUEQuantity,ISSUEUnit,AvalableQuantity,Weigth,WeigthUnit,Currency,ExchangeRate,PriceForeigh,PriceForeighAmount,PriceBath,PriceBathAmount,PalletNo,UserBy,LastUpdate,Status,TransactionDate,TypeDamage,Item,Supplier,Buyer,Exporter,Destination,Consignee,ShippingMark)")
            'sb.Append(" VALUES (@LOTNo,@WHSite,@WHLocation,@OwnerCode,@ENDCustomer,@WHSource,@CustomerLOTNo,@ItemNo,@ProductCode,@CustomerPN,@OwnerPN,@ProductDesc,@Measurement,@ProductWidth,@ProductLength,@ProductHeight,@ProductVolume,@OrderNo,@ReceiveNo,@Type,@ManufacturingDate,@ExpiredDate,@ReceiveDate,@ISSUEDate,@StockType,@ISSUEQuantity,@ISSUEUnit,@AvalableQuantity,@Weigth,@WeigthUnit,@Currency,@ExchangeRate,@PriceForeigh,@PriceForeighAmount,@PriceBath,@PriceBathAmount,@PalletNo,@UserBy,@LastUpdate,@Status,@TransactionDate,@TypeDamage,@Item,@Supplier,@Buyer,@Exporter,@Destination,@Consignee,@ShippingMark)")

            Dim u = (From us In db.tblWHPickingDetails Where us.ItemNo = lblItemNo And us.LOTNo = txtJobNo_BeforeTab.Value.Trim And us.PalletNo = txtPullSignal_BeforeTab.Value.Trim).FirstOrDefault

            If String.IsNullOrEmpty(CStr(u.ManufacturingDate)) Then
                ManuDate = Nothing
            Else
                ManuDate = u.ManufacturingDate
            End If

            If String.IsNullOrEmpty(CStr(u.ExpiredDate)) Then
                ExpDate = Nothing
            Else
                ExpDate = u.ExpiredDate
            End If

            'If u.ManufacturingDate Is Nothing Then
            '    ManuDate = Nothing
            'Else
            '    ManuDate = u.ManufacturingDate
            'End If

            'If u.ManufacturingDate Is Nothing Then
            '    ExpDate = Nothing
            'Else
            '    ExpDate = u.ExpiredDate
            'End If

            If Not IsNothing(u) Then

                db.tblWHStockMovements.Add(New tblWHStockMovement With { _
                .LOTNo = txtJobNo_BeforeTab.Value.Trim, _
                .WHSite = u.WHSite, _
                .WHLocation = u.WHLocation, _
                .OwnerCode = txtOwnerCode_IssueCon.Value.Trim, _
                .ENDCustomer = u.ENDCustomer, _
                .WHSource = u.WHSource, _
                .CustomerLOTNo = u.CustomerLOTNo, _
                .ItemNo = u.ItemNo, _
                .ProductCode = u.ProductCode, _
                .CustomerPN = u.CustomerPN, _
                .OwnerPN = u.OwnerPN, _
                .ProductDesc = u.ProductDesc, _
                .Measurement = u.Measurement, _
                .ProductWidth = u.ProductWidth, _
                .ProductLength = u.ProductLength, _
                .ProductHeight = u.ProductHeight, _
                .ProductVolume = u.ProductVolume, _
                .OrderNo = u.OrderNo, _
                .ReceiveNo = u.ReceiveNo, _
                .Type = u.Type, _
                .ManufacturingDate = ManuDate, _
                .ExpiredDate = ExpDate, _
                .ReceiveDate = u.ReceiveDate, _
                .ISSUEDate = CType(txtdatepickerComfirmDateTime_beforeTab.Text.Trim, Date?), _
                .StockType = "Issued", _
                .ISSUEQuantity = u.PickQuantity, _
                .ISSUEUnit = u.PickUnit, _
                .AvalableQuantity = 0, _
                .Weigth = u.Weigth, _
                .WeigthUnit = u.WeigthUnit, _
                .Currency = u.Currency, _
                .ExchangeRate = u.ExchangeRate, _
                .PriceForeigh = u.PriceForeigh, _
                .PriceForeighAmount = u.PriceForeighAmount, _
                .PriceBath = u.PriceBath, _
                .PriceBathAmount = u.PriceBathAmount, _
                .PalletNo = u.PalletNo, _
                .UserBy = CStr(Session("UserName")), _
                .LastUpdate = Now, _
                .Status = 1, _
                .TransactionDate = CType(txtdatepickerComfirmDateTime_beforeTab.Text.Trim, Date?), _
                .TypeDamage = "", _
                .item = u.Item, _
                .Supplier = u.Supplier, _
                .Buyer = u.Buyer, _
                .Exporter = u.Exporter, _
                .Destination = u.Destination, _
                .Consignee = u.Consignee, _
                .ShippingMark = u.ShippingMark
                })
                db.SaveChanges()
            End If
            Return True
        Catch
            Return False
        End Try
    End Function
    Private Function ConfirmMove(ByVal i As Integer) As Boolean
            If SaveDetail_ConfirmNew(i) = False Then
                Return False
            End If
            If SaveStockMovement_ConfirmNew(i) = False Then
                Return False
            End If
    End Function
    Private Function SaveDetail_ConfirmNew(ByVal i As Integer) As Boolean
        Dim lblItemNo As Double
        Dim ManuDate As Nullable(Of Date)
        Dim ExpDate As Nullable(Of Date)
        Dim AvailQuan As Double
        lblItemNo = CDbl(CType(Repeater8.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
        Try
            'sb.Append("INSERT INTO tblWHConfirmGoodsReceiveDetail (LOTNo,WHSite,WHLocation,ENDCustomer,WHSource,CustomerLOTNo,ItemNo,ProductCode,CustomerPN,OwnerPN,ProductDesc,Measurement,ProductWidth,ProductLength,ProductHeight,ProductVolume,OrderNo,ReceiveNo,Type,ManufacturingDate,ExpiredDate,ReceiveDate,Quantity,QuantityUnit,AvailableQuantity,Weigth,WeigthUnit,Currency,ExchangeRate,PriceForeigh,PriceForeighAmount,PriceBath,PriceBathAmount,PalletNo,UserBy,LastUpdate,TypeDamage,Supplier,Buyer,Exporter,Destination,Consignee,ShippingMark)")
            'sb.Append(" VALUES (@LOTNo,@WHSite,@WHLocation,@ENDCustomer,@WHSource,@CustomerLOTNo,@ItemNo,@ProductCode,@CustomerPN,@OwnerPN,@ProductDesc,@Measurement,@ProductWidth,@ProductLength,@ProductHeight,@ProductVolume,@OrderNo,@ReceiveNo,@Type,@ManufacturingDate,@ExpiredDate,@ReceiveDate,@Quantity,@QuantityUnit,@AvailableQuantity,@Weigth,@WeigthUnit,@Currency,@ExchangeRate,@PriceForeigh,@PriceForeighAmount,@PriceBath,@PriceBathAmount,@PalletNo,@UserBy,@LastUpdate,@TypeDamage,@Supplier,@Buyer,@Exporter,@Destination,@Consignee,@ShippingMark)")

            Dim u = (From us In db.tblWHPickingDetails Where us.ItemNo = lblItemNo And us.LOTNo = txtJobNo_BeforeTab.Value.Trim And us.PalletNo = txtPullSignal_BeforeTab.Value.Trim).FirstOrDefault

            If chkNotUseDate_ConfirmIssue.Checked = True Then
                ManuDate = Nothing
                ExpDate = Nothing
            ElseIf chkNotUseDate_ConfirmIssue.Checked = False Then
                If u.ManufacturingDate Is Nothing Then
                    ManuDate = Nothing
                Else
                    ManuDate = u.ManufacturingDate
                End If

                If u.ManufacturingDate Is Nothing Then
                    ExpDate = Nothing
                Else
                    ExpDate = u.ExpiredDate
                End If
            End If

            If ddlStatus_ConfirmIssue.Text = "Goods Complete" Then
                AvailQuan = CDbl(u.PickQuantity)
            ElseIf ddlStatus_ConfirmIssue.Text = "Goods Damage" Then
                AvailQuan = 0
            End If

            If Not IsNothing(u) Then
                db.tblWHConfirmGoodsReceiveDetails.Add(New tblWHConfirmGoodsReceiveDetail With { _
                .LOTNo = txtJobNo_IssueCon.Value.Trim, _
                .WHSite = ddlWHSite_IssueCon.Text.Trim, _
                .WHLocation = txtWHLocation_ConfirmIssue.Value.Trim, _
                .ENDCustomer = u.ENDCustomer, _
                .WHSource = u.WHSource, _
                .CustomerLOTNo = u.CustomerLOTNo, _
                .ItemNo = u.ItemNo, _
                .ProductCode = u.ProductCode, _
                .CustomerPN = u.CustomerPN, _
                .OwnerPN = u.OwnerPN, _
                .ProductDesc = u.ProductDesc, _
                .Measurement = u.Measurement, _
                .ProductWidth = u.ProductWidth, _
                .ProductLength = u.ProductLength, _
                .ProductHeight = u.ProductHeight, _
                .ProductVolume = u.ProductVolume, _
                .OrderNo = txtCustRefNo_IssueCon.Value.Trim, _
                .ReceiveNo = txtJobNo_IssueCon.Value.Trim, _
                .Type = u.Type, _
                .ManufacturingDate = ManuDate, _
                .ExpiredDate = ExpDate, _
                .ReceiveDate = CType(txtdatepickerReceiveDate_Button_ConfirmIssue.Text.Trim, Date?), _
                .Quantity = u.PickQuantity, _
                .QuantityUnit = u.PickUnit, _
                .AvailableQuantity = AvailQuan, _
                .Weigth = u.Weigth, _
                .WeigthUnit = u.WeigthUnit, _
                .Currency = u.Currency, _
                .ExchangeRate = u.ExchangeRate, _
                .PriceForeigh = u.PriceForeigh, _
                .PriceForeighAmount = u.PriceForeighAmount, _
                .PriceBath = u.PriceBath, _
                .PriceBathAmount = u.PriceBathAmount, _
                .PalletNo = u.PalletNo, _
                .UserBy = CStr(Session("UserName")), _
                .LastUpdate = Now, _
                .TypeDamage = "", _
                .Supplier = u.Supplier, _
                .Buyer = u.Buyer, _
                .Exporter = u.Exporter, _
                .Destination = u.Destination, _
                .Consignee = u.Consignee, _
                .ShippingMark = u.ShippingMark
                })
                db.SaveChanges()
            End If
            Return True
        Catch
            Return False
        End Try

    End Function
    Private Function SaveStockMovement_ConfirmNew(ByVal i As Integer) As Boolean
        Dim lblItemNo As Double
        Dim ManuDate As Nullable(Of Date)
        Dim ExpDate As Nullable(Of Date)
        Dim AvailQuan As Double
        Dim DamageQuan As Double
        lblItemNo = CDbl(CType(Repeater8.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
        Try

            'sb.Append("INSERT INTO tblWHStockMovement (LOTNo,WHSite,WHLocation,OwnerCode,ENDCustomer,WHSource,CustomerLOTNo,ItemNo,ProductCode,CustomerPN,OwnerPN,ProductDesc,Measurement,ProductWidth,ProductLength,ProductHeight,ProductVolume,OrderNo,ReceiveNo,Type,ManufacturingDate,ExpiredDate,ReceiveDate,StockType,ReceivedQuantity,QuantityUnit,DamageQuantity,DamageUnit,AvalableQuantity,Weigth,WeigthUnit,Currency,ExchangeRate,PriceForeigh,PriceForeighAmount,PriceBath,PriceBathAmount,PalletNo,UserBy,LastUpdate,Status,TransactionDate,TypeDamage,Item,Supplier,Buyer,Exporter,Destination,Consignee,ShippingMark)")
            'sb.Append(" VALUES (@LOTNo,@WHSite,@WHLocation,@OwnerCode,@ENDCustomer,@WHSource,@CustomerLOTNo,@ItemNo,@ProductCode,@CustomerPN,@OwnerPN,@ProductDesc,@Measurement,@ProductWidth,@ProductLength,@ProductHeight,@ProductVolume,@OrderNo,@ReceiveNo,@Type,@ManufacturingDate,@ExpiredDate,@ReceiveDate,@StockType,@ReceivedQuantity,@QuantityUnit,@DamageQuantity,@DamageUnit,@AvalableQuantity,@Weigth,@WeigthUnit,@Currency,@ExchangeRate,@PriceForeigh,@PriceForeighAmount,@PriceBath,@PriceBathAmount,@PalletNo,@UserBy,@LastUpdate,@Status,@TransactionDate,@TypeDamage,@Item,@Supplier,@Buyer,@Exporter,@Destination,@Consignee,@ShippingMark)")

            Dim u = (From us In db.tblWHPickingDetails Where us.ItemNo = lblItemNo And us.LOTNo = txtJobNo_BeforeTab.Value.Trim And us.PalletNo = txtPullSignal_BeforeTab.Value.Trim).FirstOrDefault

            If chkNotUseDate_ConfirmIssue.Checked = True Then
                ManuDate = Nothing
                ExpDate = Nothing
            ElseIf chkNotUseDate_ConfirmIssue.Checked = False Then
                If u.ManufacturingDate Is Nothing Then
                    ManuDate = Nothing
                Else
                    ManuDate = u.ManufacturingDate
                End If

                If u.ManufacturingDate Is Nothing Then
                    ExpDate = Nothing
                Else
                    ExpDate = u.ExpiredDate
                End If
            End If


            If ddlStatus_ConfirmIssue.Text = "Goods Complete" Then
                AvailQuan = CDbl(u.PickQuantity)
                DamageQuan = 0
            ElseIf ddlStatus_ConfirmIssue.Text = "Goods Damage" Then
                AvailQuan = 0
                DamageQuan = CDbl(u.PickQuantity)
            End If

                If Not IsNothing(u) Then
                db.tblWHStockMovements.Add(New tblWHStockMovement With { _
                .LOTNo = txtJobNo_IssueCon.Value.Trim, _
                .WHSite = ddlWHSite_IssueCon.Text.Trim, _
                .WHLocation = txtWHLocation_ConfirmIssue.Value.Trim, _
                .OwnerCode = txtOwnerCode_IssueCon.Value.Trim, _
                .ENDCustomer = u.ENDCustomer, _
                .WHSource = u.WHSource, _
                .CustomerLOTNo = u.CustomerLOTNo, _
                .ItemNo = u.ItemNo, _
                .ProductCode = u.ProductCode, _
                .CustomerPN = u.CustomerPN, _
                .OwnerPN = u.OwnerPN, _
                .ProductDesc = u.ProductDesc, _
                .Measurement = u.Measurement, _
                .ProductWidth = u.ProductWidth, _
                .ProductLength = u.ProductLength, _
                .ProductHeight = u.ProductHeight, _
                .ProductVolume = u.ProductVolume, _
                .OrderNo = txtCustRefNo_IssueCon.Value.Trim, _
                .ReceiveNo = txtJobNo_IssueCon.Value.Trim, _
                .Type = u.Type, _
                .ManufacturingDate = ManuDate, _
                .ExpiredDate = ExpDate, _
                .ReceiveDate = CType(txtdatepickerReceiveDate_Button_ConfirmIssue.Text.Trim, Date?), _
                .StockType = "Received", _
                .ReceivedQuantity = u.PickQuantity, _
                .QuantityUnit = u.PickUnit, _
                .DamageQuantity = DamageQuan, _
                .DamageUnit = u.PickUnit, _
                .AvalableQuantity = AvailQuan, _
                .Weigth = u.Weigth, _
                .WeigthUnit = u.WeigthUnit, _
                .Currency = u.Currency, _
                .ExchangeRate = u.ExchangeRate, _
                .PriceForeigh = u.PriceForeigh, _
                .PriceForeighAmount = u.PriceForeighAmount, _
                .PriceBath = u.PriceBath, _
                .PriceBathAmount = u.PriceBathAmount, _
                .PalletNo = u.PalletNo, _
                .UserBy = CStr(Session("UserName")), _
                .LastUpdate = Now, _
                .Status = 0, _
                .TransactionDate = u.ReceiveDate, _
                .TypeDamage = "", _
                .item = u.Item, _
                .Supplier = u.Supplier, _
                .Buyer = u.Buyer, _
                .Exporter = u.Exporter, _
                .Destination = u.Destination, _
                .Consignee = u.Consignee, _
                .ShippingMark = u.ShippingMark
                })
                db.SaveChanges()
            End If
            Return True
        Catch
            Return False
        End Try

    End Function
    Function SaveDetail_ConfirmNewNJR(ByVal i As Integer) As Boolean
        Dim lblItemNo As Double
        Dim ManuDate As Nullable(Of Date)
        Dim ExpDate As Nullable(Of Date)
        Dim AvailQuan As Double
        Dim DamageQuan As Double
        lblItemNo = CDbl(CType(Repeater8.Items(i).FindControl("lblItemNo"), Label).Text.Trim)

        Try

            'sb.Append("INSERT INTO tblWHConfirmGoodsReceiveDetail (LOTNo,WHSite,WHLocation,ENDCustomer,WHSource,CustomerLOTNo,ItemNo,ProductCode,CustomerPN,OwnerPN,ProductDesc,Measurement,ProductWidth,ProductLength,ProductHeight,ProductVolume,OrderNo,ReceiveNo,Type,ManufacturingDate,ExpiredDate,ReceiveDate,Quantity,QuantityUnit,AvailableQuantity,Weigth,WeigthUnit,Currency,ExchangeRate,PriceForeigh,PriceForeighAmount,PriceBath,PriceBathAmount,PalletNo,UserBy,LastUpdate,TypeDamage,Supplier,Buyer,Exporter,Destination,Consignee,ShippingMark,EntryNo,EntryItemNo)")
            'sb.Append(" VALUES (@LOTNo,@WHSite,@WHLocation,@ENDCustomer,@WHSource,@CustomerLOTNo,@ItemNo,@ProductCode,@CustomerPN,@OwnerPN,@ProductDesc,@Measurement,@ProductWidth,@ProductLength,@ProductHeight,@ProductVolume,@OrderNo,@ReceiveNo,@Type,@ManufacturingDate,@ExpiredDate,@ReceiveDate,@Quantity,@QuantityUnit,@AvailableQuantity,@Weigth,@WeigthUnit,@Currency,@ExchangeRate,@PriceForeigh,@PriceForeighAmount,@PriceBath,@PriceBathAmount,@PalletNo,@UserBy,@LastUpdate,@TypeDamage,@Supplier,@Buyer,@Exporter,@Destination,@Consignee,@ShippingMark,@EntryNo,@EntryItemNo)")
            
            Dim u = (From us In db.tblWHPickingDetails Where us.ItemNo = lblItemNo And us.LOTNo = txtJobNo_BeforeTab.Value.Trim And us.PalletNo = txtPullSignal_BeforeTab.Value.Trim).FirstOrDefault

            If u.ManufacturingDate Is Nothing Then
                ManuDate = Nothing
            Else
                ManuDate = u.ManufacturingDate
            End If

            If u.ManufacturingDate Is Nothing Then
                ExpDate = Nothing
            Else
                ExpDate = u.ExpiredDate
            End If


            If ddlStatus_ConfirmIssue.Text = "Goods Complete" Then
                AvailQuan = CDbl(u.PickQuantity)
                DamageQuan = 0
            ElseIf ddlStatus_ConfirmIssue.Text = "Goods Damage" Then
                AvailQuan = 0
                DamageQuan = CDbl(u.PickQuantity)
            End If

            If Not IsNothing(u) Then
                db.tblWHConfirmGoodsReceiveDetails.Add(New tblWHConfirmGoodsReceiveDetail With { _
                .LOTNo = txtJobNo_IssueCon.Value.Trim, _
                .WHSite = ddlWHSite_IssueCon.Text.Trim, _
                .WHLocation = txtWHLocation_ConfirmIssue.Value.Trim, _
                .ENDCustomer = txtShipToCode_IssueCon.Value.Trim, _
                .WHSource = u.WHSourceIN, _
                .CustomerLOTNo = u.CustomerLOTNo, _
                .ItemNo = u.ItemNo, _
                .ProductCode = u.ProductCode, _
                .CustomerPN = u.CustomerPN, _
                .OwnerPN = u.OwnerPN, _
                .ProductDesc = u.ProductDesc, _
                .Measurement = u.Measurement, _
                .ProductWidth = u.ProductWidth, _
                .ProductLength = u.ProductLength, _
                .ProductHeight = u.ProductHeight, _
                .ProductVolume = u.ProductVolume, _
                .OrderNo = txtCustRefNo_IssueCon.Value.Trim, _
                .ReceiveNo = txtJobNo_BeforeTab.Value.Trim, _
                .Type = u.Type, _
                .ManufacturingDate = ManuDate, _
                .ExpiredDate = ExpDate, _
                .ReceiveDate = CType(txtdatepickerReceiveDate_Button_ConfirmIssue.Text.Trim, Date?), _
                .Quantity = u.PickQuantity, _
                .QuantityUnit = u.PickUnit, _
                .AvailableQuantity = u.PickQuantity, _
                .Weigth = u.Weigth, _
                .WeigthUnit = u.WeigthUnit, _
                .Currency = u.Currency, _
                .ExchangeRate = u.ExchangeRate, _
                .PriceForeigh = u.PriceForeigh, _
                .PriceForeighAmount = u.PriceForeighAmount, _
                .PriceBath = u.PriceBath, _
                .PriceBathAmount = u.PriceBathAmount, _
                .PalletNo = u.PalletNo, _
                .UserBy = CStr(Session("UserName")), _
                .LastUpdate = Now, _
                .TypeDamage = "", _
                .Supplier = u.Supplier, _
                .Buyer = u.Buyer, _
                .Exporter = u.Exporter, _
                .Destination = u.Destination, _
                .Consignee = u.Consignee, _
                .ShippingMark = u.ShippingMark, _
                .EntryNo = u.EntryNo, _
                .EntryItemNo = u.EntryItemNo
                })
                db.SaveChanges()
            End If
            Return True
        Catch
            Return False
        End Try

    End Function
    Function SaveStockMovement_ConfirmNewNJR(ByVal i As Integer) As Boolean
        Dim lblItemNo As Double
        Dim ManuDate As Nullable(Of Date)
        Dim ExpDate As Nullable(Of Date)
        lblItemNo = CDbl(CType(Repeater8.Items(i).FindControl("lblItemNo"), Label).Text.Trim)

        Try

            'sb.Append("INSERT INTO tblWHStockMovement (LOTNo,WHSite,WHLocation,OwnerCode,ENDCustomer,WHSource,CustomerLOTNo,ItemNo,ProductCode,CustomerPN,OwnerPN,ProductDesc,Measurement,ProductWidth,ProductLength,ProductHeight,ProductVolume,OrderNo,ReceiveNo,Type,ManufacturingDate,ExpiredDate,ReceiveDate,StockType,ReceivedQuantity,QuantityUnit,DamageQuantity,DamageUnit,AvalableQuantity,Weigth,WeigthUnit,Currency,ExchangeRate,PriceForeigh,PriceForeighAmount,PriceBath,PriceBathAmount,PalletNo,UserBy,LastUpdate,Status,TransactionDate,TypeDamage,Item,Supplier,Buyer,Exporter,Destination,Consignee,ShippingMark,EntryNo,EntryItemNo)")
            'sb.Append(" VALUES (@LOTNo,@WHSite,@WHLocation,@OwnerCode,@ENDCustomer,@WHSource,@CustomerLOTNo,@ItemNo,@ProductCode,@CustomerPN,@OwnerPN,@ProductDesc,@Measurement,@ProductWidth,@ProductLength,@ProductHeight,@ProductVolume,@OrderNo,@ReceiveNo,@Type,@ManufacturingDate,@ExpiredDate,@ReceiveDate,@StockType,@ReceivedQuantity,@QuantityUnit,@DamageQuantity,@DamageUnit,@AvalableQuantity,@Weigth,@WeigthUnit,@Currency,@ExchangeRate,@PriceForeigh,@PriceForeighAmount,@PriceBath,@PriceBathAmount,@PalletNo,@UserBy,@LastUpdate,@Status,@TransactionDate,@TypeDamage,@Item,@Supplier,@Buyer,@Exporter,@Destination,@Consignee,@ShippingMark,@EntryNo,@EntryItemNo)")

            Dim u = (From us In db.tblWHPickingDetails Where us.ItemNo = lblItemNo And us.LOTNo = txtJobNo_BeforeTab.Value.Trim And us.PalletNo = txtPullSignal_BeforeTab.Value.Trim).FirstOrDefault

            If u.ManufacturingDate Is Nothing Then
                ManuDate = Nothing
            Else
                ManuDate = u.ManufacturingDate
            End If

            If u.ManufacturingDate Is Nothing Then
                ExpDate = Nothing
            Else
                ExpDate = u.ExpiredDate
            End If

            If Not IsNothing(u) Then
                db.tblWHStockMovements.Add(New tblWHStockMovement With { _
                .LOTNo = txtJobNo_IssueCon.Value.Trim, _
                .WHSite = ddlWHSite_IssueCon.Text.Trim, _
                .WHLocation = txtWHLocation_ConfirmIssue.Value.Trim, _
                .OwnerCode = txtShipToCode_IssueCon.Value.Trim, _
                .ENDCustomer = txtShipToCode_IssueCon.Value.Trim, _
                .WHSource = u.WHSource, _
                .CustomerLOTNo = u.CustomerLOTNo, _
                .ItemNo = u.ItemNo, _
                .ProductCode = u.ProductCode, _
                .CustomerPN = u.CustomerPN, _
                .OwnerPN = u.OwnerPN, _
                .ProductDesc = u.ProductDesc, _
                .Measurement = u.Measurement, _
                .ProductWidth = u.ProductWidth, _
                .ProductLength = u.ProductLength, _
                .ProductHeight = u.ProductHeight, _
                .ProductVolume = u.ProductVolume, _
                .OrderNo = txtCustRefNo_IssueCon.Value.Trim, _
                .ReceiveNo = txtJobNo_BeforeTab.Value.Trim, _
                .Type = u.Type, _
                .ManufacturingDate = ManuDate, _
                .ExpiredDate = ExpDate, _
                .ReceiveDate = CType(txtdatepickerReceiveDate_Button_ConfirmIssue.Text.Trim, Date?), _
                .StockType = "Received", _
                .ReceivedQuantity = u.PickQuantity, _
                .QuantityUnit = u.PickUnit, _
                .DamageQuantity = 0, _
                .DamageUnit = u.PickUnit, _
                .AvalableQuantity = u.PickQuantity, _
                .Weigth = u.Weigth, _
                .WeigthUnit = u.WeigthUnit, _
                .Currency = u.Currency, _
                .ExchangeRate = u.ExchangeRate, _
                .PriceForeigh = u.PriceForeigh, _
                .PriceForeighAmount = u.PriceForeighAmount, _
                .PriceBath = u.PriceBath, _
                .PriceBathAmount = u.PriceBathAmount, _
                .PalletNo = u.PalletNo, _
                .UserBy = CStr(Session("UserName")), _
                .LastUpdate = Now, _
                .Status = 0, _
                .TransactionDate = u.ReceiveDate, _
                .TypeDamage = "", _
                .item = u.Item, _
                .Supplier = u.Supplier, _
                .Buyer = u.Buyer, _
                .Exporter = u.Exporter, _
                .Destination = u.Destination, _
                .Consignee = u.Consignee, _
                .ShippingMark = u.ShippingMark, _
                .EntryNo = u.EntryNo, _
                .EntryItemNo = u.EntryItemNo
                })
                db.SaveChanges()
            End If
            Return True
        Catch
            Return False
        End Try
    End Function
    Private Sub ConfirmDelivery()

        'Dim chkName As CheckBox
        'Dim lblItemNo As Double



        'Dim u = (From us In db.tblWHPickingDetails Where us.ItemNo = lblItemNo And us.LOTNo = txtJobNo_BeforeTab.Value.Trim And us.PalletNo = txtPullSignal_BeforeTab.Value.Trim).FirstOrDefault
        'Dim i As Integer
        'Dim strWHSite As String
        'tr = Conn.BeginTransaction()

        'With dgvIssued
        '    For i = 0 To .Rows.Count - 1

        '        chkName = CType(Repeater8.Items(i).FindControl("chkRowData"), CheckBox)
        '        lblItemNo = CDbl(CType(Repeater8.Items(i).FindControl("lblItemNo"), Label).Text.Trim)

        '        txtRPullSignal.Text = CStr(.Rows(i).Cells(0).Value)
        '        txtRLotNo.Text = CStr(.Rows(i).Cells(1).Value)
        '        strWHSite = CStr(.Rows(i).Cells(2).Value)
        '        txtRItemIssued.Text = CStr(.Rows(i).Cells(7).Value)
        '        txtRReceiveNO.Text = CStr(.Rows(i).Cells(18).Value)
        '        txtRItemNo.Text = CStr(.Rows(i).Cells(41).Value)
        '        txtROwnerPN.Text = CStr(.Rows(i).Cells(10).Value)
        '        txtRCustomerLotNo.Text = CStr(.Rows(i).Cells(5).Value)
        '        txtRIssuedQTY.Text = CStr(.Rows(i).Cells(24).Value)
        '        txtRStatusIssued.Text = CStr(.Rows(i).Cells(36).Value)

        '        If txtRStatusIssued.Text = "1" Then

        '            ReadStockMovement()

        '            If txtRReceiveNO.Text.Trim() = "" Then
        '                MessageBox.Show("กรุณาเลือก Item ก่อน !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                txtRReceiveNO.Focus()
        '                Exit Sub
        '            End If

        '            If txtRItemNo.Text.Trim() = "" Then
        '                MessageBox.Show("กรุณาเลือก Item ก่อน !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                txtRItemNo.Focus()
        '                Exit Sub
        '            End If

        '            Try
        '                sb = New StringBuilder()
        '                sb.Append("UPDATE tblWHStockMovement")
        '                sb.Append(" SET ISSUEQuantity=@ISSUEQuantity,Status=@Status ")
        '                sb.Append(" WHERE (LOTNo=@LOTNo AND ItemNo=@ItemNo AND OwnerPN=@OwnerPN AND CustomerLotNo=@CustomerLotNo AND WHSite=@WHSite)")
        '                Dim sqlEdit As String
        '                sqlEdit = sb.ToString()

        '                With com
        '                    .CommandText = sqlEdit
        '                    .CommandType = CommandType.Text
        '                    .Connection = Conn
        '                    .Transaction = tr
        '                    .Parameters.Clear()
        '                    .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = txtRReceiveNO.Text.Trim()
        '                    .Parameters.Add("@WHSite", SqlDbType.NVarChar).Value = strWHSite
        '                    .Parameters.Add("@OwnerPN", SqlDbType.NVarChar).Value = txtROwnerPN.Text.Trim()
        '                    .Parameters.Add("@CustomerLotNo", SqlDbType.NVarChar).Value = txtRCustomerLotNo.Text.Trim()
        '                    .Parameters.Add("@ItemNo", SqlDbType.Decimal).Value = CDbl(txtRItemNo.Text).ToString("#,##0")
        '                    If CDbl(txtIssuedMovement.Text) = 0 Then
        '                        .Parameters.Add("@ISSUEQuantity", SqlDbType.Float).Value = 0
        '                        txtIssuedMovement.Text = "0"
        '                    Else
        '                        'If CDbl(txtIssuedMovement.Text) > CDbl(txtRIssuedQTY.Text) Then
        '                        .Parameters.Add("@ISSUEQuantity", SqlDbType.Float).Value = (CDbl(txtIssuedMovement.Text) - CDbl(txtRIssuedQTY.Text)).ToString("#,##0.00")
        '                        txtIssuedMovement.Text = CStr((CDbl(txtIssuedMovement.Text) - CDbl(txtRIssuedQTY.Text)).ToString("#,##0.00"))
        '                        'Else
        '                        '.Parameters.Add("@ISSUEQuantity", SqlDbType.Float).Value = (CDbl(txtRIssuedQTY.Text) - CDbl(txtIssuedMovement.Text)).ToString("#,##0.00")
        '                        'txtIssuedMovement.Text = CStr((CDbl(txtRIssuedQTY.Text) - CDbl(txtIssuedMovement.Text)).ToString("#,##0.00"))
        '                        'End If
        '                    End If

        '                    If CDbl(txtIssuedMovement.Text) <= 0 And CDbl(txtDamageMovement.Text) <= 0 And CDbl(txtAvailableMovement.Text) <= 0 Then
        '                        .Parameters.Add("@Status", SqlDbType.Decimal).Value = 1
        '                    Else
        '                        .Parameters.Add("@Status", SqlDbType.Decimal).Value = 0
        '                    End If

        '                    Dim result As Integer
        '                    result = .ExecuteNonQuery()
        '                    If result = 0 Then
        '                        tr.Rollback()
        '                        MessageBox.Show("ไม่พบ StockMovement ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                        Exit Sub
        '                    Else

        '                        'ReadStockMovementforUpdateStatus()

        '                        'If UpdateStatusMovement() = False Then
        '                        '    tr.Rollback()
        '                        '    MessageBox.Show("เกิดข้อผิดพลาด SaveIssued ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                        '    Exit Sub
        '                        'End If
        '                    End If
        '                End With

        '                If UpdateStatusIssuedConfirmDelivery() = False Then
        '                    Exit Sub
        '                End If

        '            Catch ex As Exception
        '                tr.Rollback()
        '                MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก " & ex.Message, "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                Exit Sub
        '            End Try
        '        End If

        '    Next
        'End With
        'tr.Commit()

        'MessageBox.Show(" JOB งาน เบอร์ " & txtRLotNo.Text & " ออกโดย  Pull Signal No. " & txtRPullSignal.Text & " งานนี้ถูก Confirm เรียบร้อยแล้ว", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
End Class