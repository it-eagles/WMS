Option Explicit On
Option Strict On

Imports System.Transactions
Imports System.Globalization


Public Class PrepareLotWH
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmPrepairLOT"
        If Not Me.IsPostBack Then
            If classPermis.CheckRead(form, usename) = True Then
                If Not IsPostBack Then

                    showCommodity()
                    showUnit()
                    showVolume()
                    showSite()
                    showLocation()
                    showSoucreWHFac()
                    showunitdimension()
                    showunit2()
                    showcurrency()

                    preparegoodsreceive_fieldset.Disabled = True
                    goodreceivedetail_fieldset.Disabled = True
                    TabName.Value = Request.Form(TabName.UniqueID)
                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
                'Response.Redirect("HomeMain.aspx")
            End If
        End If
    End Sub
    '-----------------------------------------------------------Click btn Add New GOODRECDETAIL TAB--------------------------------------
    Protected Sub btnAddNew_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmPrepairLOT"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveDetail_New()
            ClearDATA1()
            SelectJobDetail()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
        
    End Sub
    '-----------------------------------------------------------Click btn Save Modify GOODRECDETAIL TAB--------------------------------------
    Protected Sub btnSaveModify_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmPrepairLOT"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            SaveDetail_Modify()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '-----------------------------------------------------------Click btn Delete GOODRECDETAIL TAB--------------------------------------
    Protected Sub btnDelete_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmPrepairLOT"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Delete_ = 1
        If cu.Any Then
            SaveDeleteDetail()
            ClearDATA1()
            SelectJobDetail()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '-----------------------------------------------------------Click btn Delecte All GOODRECDETAIL TAB--------------------------------------
    Protected Sub btnDeleteAll_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmPrepairLOT"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Delete_ = 1
        If cu.Any Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('ไม่สามารถใช้งาน Function นี้ได้');", True)
            'SaveDeleteDetailALL()
            'ClearDATA1()
            'SelectJobDetail()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '-----------------------------------------------------------Click btn Add New Head PREPAREGOODREC TAB--------------------------------------
    Protected Sub btnAddHead_ServerClick(sender As Object, e As EventArgs)
        UnlockAddData()
        ClearDATA()
        ClearDATA1()
    End Sub
    '-----------------------------------------------------------Click btn Edit Head PREPAREGOODREC TAB--------------------------------------
    Protected Sub btnEditHead_ServerClick(sender As Object, e As EventArgs)
        UnlockEditData()
        ClearDATA1()
        chkNotUseDate_GoodRecDetail.Checked = True
    End Sub
    '-----------------------------------------------------------Click btn Save New Head PREPAREGOODREC TAB--------------------------------------
    Protected Sub btnSaveAddHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmPrepairLOT"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            Save_New()
            UpdateStatus()
            SelectJobDetail()
            UnlockEditData()
            ClearDATA1()
            chkNotUseDate_GoodRecDetail.Checked = True
            'ClearDATA1()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '-----------------------------------------------------------Click btn Save Edit Head PREPAREGOODREC TAB--------------------------------------
    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmPrepairLOT"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            Save_Modify()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    '-------------------------------------------------------------Unlock Add Data When Click btn Add---------------------------------------
    Private Sub UnlockAddData()
        btnSaveAddHead.Visible = True
        btnSaveEditHead.Visible = False
        btnJobNoSearch.Visible = True
        btnJobNoSearch_Edit.Visible = False

        preparegoodsreceive_fieldset.Disabled = False
        goodreceivedetail_fieldset.Disabled = True
    End Sub
    '-------------------------------------------------------------Unlock Edit Data When Click btn Edit---------------------------------------
    Private Sub UnlockEditData()
        btnSaveAddHead.Visible = False
        btnSaveEditHead.Visible = True
        btnJobNoSearch.Visible = False
        btnJobNoSearch_Edit.Visible = True

        preparegoodsreceive_fieldset.Disabled = False
        goodreceivedetail_fieldset.Disabled = False
    End Sub
    '----------------------------------------------------------------Start Method Show ddl PREPAREGOODREC TAB---------------------------
    '--------------------------------------------------------------------Show ddl COMMODITY----------------------------------------------------
    Private Sub showCommodity()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "COMMODITY"
                  Select g.Type, g.Code
        Try
            ddlCommodity_PreGoodRec.DataSource = gg.ToList
            ddlCommodity_PreGoodRec.DataTextField = "Code"
            ddlCommodity_PreGoodRec.DataValueField = "Code"
            ddlCommodity_PreGoodRec.DataBind()

            If ddlCommodity_PreGoodRec.Items.Count > 1 Then
                ddlCommodity_PreGoodRec.Enabled = True
            Else
                ddlCommodity_PreGoodRec.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl UNIT----------------------------------------------------
    Private Sub showUnit()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "UNIT"
                  Select g.Type, g.Code
        Try
            ddlQuantityPackage_PreGoodRec.DataSource = gg.ToList
            ddlQuantityPackage_PreGoodRec.DataTextField = "Code"
            ddlQuantityPackage_PreGoodRec.DataValueField = "Code"
            ddlQuantityPackage_PreGoodRec.DataBind()

            If ddlQuantityPackage_PreGoodRec.Items.Count > 1 Then
                ddlQuantityPackage_PreGoodRec.Enabled = True
            Else
                ddlQuantityPackage_PreGoodRec.Enabled = False
            End If

            ddlQuantityPLTSkid_PreGoodRec.DataSource = gg.ToList
            ddlQuantityPLTSkid_PreGoodRec.DataTextField = "Code"
            ddlQuantityPLTSkid_PreGoodRec.DataValueField = "Code"
            ddlQuantityPLTSkid_PreGoodRec.DataBind()

            If ddlQuantityPLTSkid_PreGoodRec.Items.Count > 1 Then
                ddlQuantityPLTSkid_PreGoodRec.Enabled = True
            Else
                ddlQuantityPLTSkid_PreGoodRec.Enabled = False
            End If

            ddlQuantityOfGood_PreGoodRec.DataSource = gg.ToList
            ddlQuantityOfGood_PreGoodRec.DataTextField = "Code"
            ddlQuantityOfGood_PreGoodRec.DataValueField = "Code"
            ddlQuantityOfGood_PreGoodRec.DataBind()

            If ddlQuantityOfGood_PreGoodRec.Items.Count > 1 Then
                ddlQuantityOfGood_PreGoodRec.Enabled = True
            Else
                ddlQuantityOfGood_PreGoodRec.Enabled = False
            End If

            ddlWeight_PreGoodRec.DataSource = gg.ToList
            ddlWeight_PreGoodRec.DataTextField = "Code"
            ddlWeight_PreGoodRec.DataValueField = "Code"
            ddlWeight_PreGoodRec.DataBind()

            If ddlWeight_PreGoodRec.Items.Count > 1 Then
                ddlWeight_PreGoodRec.Enabled = True
            Else
                ddlWeight_PreGoodRec.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl Volume----------------------------------------------------
    Private Sub showVolume()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "VOLUME"
                  Select g.Type, g.Code
        Try
            ddlVolume_PreGoodRec.DataSource = gg.ToList
            ddlVolume_PreGoodRec.DataTextField = "Code"
            ddlVolume_PreGoodRec.DataValueField = "Code"
            ddlVolume_PreGoodRec.DataBind()

            If ddlVolume_PreGoodRec.Items.Count > 1 Then
                ddlVolume_PreGoodRec.Enabled = True
            Else
                ddlVolume_PreGoodRec.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------------End Method Show ddl PREPAREGOODREC TAB---------------------------

    '----------------------------------------------------------------Start Method Show ddl GOODRECDETAIL TAB---------------------------
    '--------------------------------------------------------------------Show ddl Site----------------------------------------------------
    Private Sub showSite()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "SITE"
                  Select g.Type, g.Code
        Try
            ddlWHSite_GoodRecDetail.DataSource = gg.ToList
            ddlWHSite_GoodRecDetail.DataTextField = "Code"
            ddlWHSite_GoodRecDetail.DataValueField = "Code"
            ddlWHSite_GoodRecDetail.DataBind()

            If ddlWHSite_GoodRecDetail.Items.Count > 1 Then
                ddlWHSite_GoodRecDetail.Enabled = True
            Else
                ddlWHSite_GoodRecDetail.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl Location----------------------------------------------------
    Private Sub showLocation()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "LOCATION"
                  Select g.Type, g.Code
        Try
            ddlWHLocation_GoodRecDetail.DataSource = gg.ToList
            ddlWHLocation_GoodRecDetail.DataTextField = "Code"
            ddlWHLocation_GoodRecDetail.DataValueField = "Code"
            ddlWHLocation_GoodRecDetail.DataBind()

            If ddlWHLocation_GoodRecDetail.Items.Count > 1 Then
                ddlWHLocation_GoodRecDetail.Enabled = True
            Else
                ddlWHLocation_GoodRecDetail.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl SOURCE-WH-FAC----------------------------------------------------
    Private Sub showSoucreWHFac()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "SOURCE-WH-FAC"
                  Select g.Type, g.Code
        Try
            ddlCustWHFac_GoodRecDetail.DataSource = gg.ToList
            ddlCustWHFac_GoodRecDetail.DataTextField = "Code"
            ddlCustWHFac_GoodRecDetail.DataValueField = "Code"
            ddlCustWHFac_GoodRecDetail.DataBind()

            If ddlCustWHFac_GoodRecDetail.Items.Count > 1 Then
                ddlCustWHFac_GoodRecDetail.Enabled = True
            Else
                ddlCustWHFac_GoodRecDetail.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------------Show ddl Unit CM INC-------------------------------------------------------
    Private Sub showunitdimension()
        Dim gg = From g In db.tblMasterCodes Where g.Code = "CM" Or g.Code = "INC"
                  Select g.Type, g.Code
        Try
            ddlMeasurement_GoodRecDetail.DataSource = gg.ToList
            ddlMeasurement_GoodRecDetail.DataTextField = "Code"
            ddlMeasurement_GoodRecDetail.DataValueField = "Code"
            ddlMeasurement_GoodRecDetail.DataBind()
            If ddlMeasurement_GoodRecDetail.Items.Count > 1 Then
                ddlMeasurement_GoodRecDetail.Enabled = True
            Else
                ddlMeasurement_GoodRecDetail.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------------Show ddl Unit2-------------------------------------------------------
    Private Sub showunit2()
        Dim gg = From g In db.tblMasterCodes Where g.Type = "UNIT"
                  Select g.Type, g.Code
        Try
            ddlQuantity_GoodRecDetail.DataSource = gg.ToList
            ddlQuantity_GoodRecDetail.DataTextField = "Code"
            ddlQuantity_GoodRecDetail.DataValueField = "Code"
            ddlQuantity_GoodRecDetail.DataBind()

            If ddlQuantity_GoodRecDetail.Items.Count > 1 Then
                ddlQuantity_GoodRecDetail.Enabled = True
            Else
                ddlQuantity_GoodRecDetail.Enabled = False
            End If

            ddlWeight_GoodRecDetail.DataSource = gg.ToList
            ddlWeight_GoodRecDetail.DataTextField = "Code"
            ddlWeight_GoodRecDetail.DataValueField = "Code"
            ddlWeight_GoodRecDetail.DataBind()

            If ddlWeight_GoodRecDetail.Items.Count > 1 Then
                ddlWeight_GoodRecDetail.Enabled = True
            Else
                ddlWeight_GoodRecDetail.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------------Show ddl Currency-------------------------------------------------------
    Private Sub showcurrency()
        Dim gg = From g In db.tblMasterCodes Where g.Type = "CURRENCY"
                  Select g.Type, g.Code
        Try
            ddlCurrency_GoodRecDetail.DataSource = gg.ToList
            ddlCurrency_GoodRecDetail.DataTextField = "Code"
            ddlCurrency_GoodRecDetail.DataValueField = "Code"
            ddlCurrency_GoodRecDetail.DataBind()
            If ddlCurrency_GoodRecDetail.Items.Count > 1 Then
                ddlCurrency_GoodRecDetail.Enabled = True
            Else
                ddlCurrency_GoodRecDetail.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------Show Data Jobno Code In Modal-----------------------------------------
    Private Sub SelectJobnoCode()
        Dim testdate As Integer
        Dim jobno_code As String = ""
        Dim status_ As Double
        If String.IsNullOrEmpty(txtJobNo_PreGoodRec.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            status_ = 0
        Else
            jobno_code = txtJobNo_PreGoodRec.Value.Trim

        End If



        'Dim cons = (From p In db.tblImpGenLOTs (If (String.IsNullOrEmpty(txtJobNo_PreGoodRec.Value.Trim)) Then)
        '                                        Where p.Status = status_ And p.LOTDate.Year = testdate
        'Else
        'Where(Not p.EASLOTNo.Contains(jobno_code) And p.Status = 0)
        'End If 
        '          Select New With {p.EASLOTNo,
        '                           p.CustomerCode,
        '                           p.EndCusCode,
        '                           p.Commodity}).ToList()

        Dim cons = (From p In db.tblImpGenLOTs
                    Where (p.EASLOTNo.Contains(txtJobNo_PreGoodRec.Value.Trim) And p.Status = 0) Or (p.Status = status_ And p.LOTDate.Year = testdate)
                   Select New With {p.EASLOTNo,
                                    p.CustomerCode,
                                    p.EndCusCode,
                                    p.Commodity}).ToList()

        If cons.Count > 0 Then
            Repeater1.DataSource = cons.ToList
            Repeater1.DataBind()
            ScriptManager.RegisterStartupScript(JobNoAddUpdatePanel, JobNoAddUpdatePanel.GetType(), "show", "$(function () { $('#" + JobNoAddPanel.ClientID + "').modal('show'); });", True)
            JobNoAddUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล ProductCode Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '-----------------------------------------------------------Click btn Job No Search PREPAREGOODREC TAB--------------------------------------
    Protected Sub btnJobNoSearch_ServerClick(sender As Object, e As EventArgs)
        SelectJobnoCode()
    End Sub
    '--------------------------------------------------------Click Data JobNo In Modal-----------------------------------------
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim JobnoCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectJobnoCode") Then

                If String.IsNullOrEmpty(JobnoCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblImpGenLOTs Where u.EASLOTNo = JobnoCode).SingleOrDefault

                    txtJobNo_PreGoodRec.Value = user.EASLOTNo
                    txtdatepickerJobdate_PreGoodRec.Text = CStr(user.LOTDate)
                    txtCustomerCode0_PreGoodRec.Value = user.CustomerCode
                    txtNameCustomer_PreGoodRec.Value = user.CustomerENG
                    txtAddress1Customer_PreGoodRec.Value = user.CustomerStreet
                    txtAddress2Customer_PreGoodRec.Value = user.CustomerDistrict
                    txtAddress3Customer_PreGoodRec.Value = user.CustomerSub
                    txtAddress4Customer_PreGoodRec.Value = user.CustomerProvince
                    txtEndUserCode_PreGoodRec.Value = user.EndCusCode
                    txtNameEndUser_PreGoodRec.Value = user.EndCusENG
                    txtAddress1Customer_PreGoodRec.Value = user.EndCusAddress1
                    txtAddress2EndUser_PreGoodRec.Value = user.EndCusAddress2
                    txtAddress3EndUser_PreGoodRec.Value = user.EndCusAddress3
                    txtAddress4Customer_PreGoodRec.Value = user.EndCusAddress4
                    ddlCommodity_PreGoodRec.Text = user.Commodity
                    txtQuantityOfGood_PreGoodRec.Value = CStr(user.QuantityofPart)
                    ddlQuantityOfGood_PreGoodRec.Text = user.QuantityUnit
                    txtQuantityPackage_PreGoodRec.Value = CStr(user.QuantityPack1)
                    ddlQuantityPackage_PreGoodRec.Text = user.QuantityUnitPack1
                    txtWeight_PreGoodRec.Value = CStr(user.Weight)
                    ddlWeight_PreGoodRec.Text = user.WeightUnit
                    txtQuantityPLTSkid_PreGoodRec.Value = CStr(user.QuantityPack)
                    ddlQuantityPLTSkid_PreGoodRec.Text = user.QuantityUnitPack
                    txtVolume_PreGoodRec.Value = CStr(user.Volume)
                    ddlVolume_PreGoodRec.Text = user.VolumeUnit
                    txtRemark_PreGoodRec.Value = user.Remark

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data Shipper In Modal-----------------------------------------
    Private Sub selectCustomerCode()
        Dim Ship_code As String
        Dim Customer_ As String = ""
        If String.IsNullOrEmpty(txtCustomerCode0_PreGoodRec.Value.Trim) Then
            Ship_code = ""
            Customer_ = "0"
        Else
            Ship_code = txtCustomerCode0_PreGoodRec.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Ship_code And p.Customer = "0") Or p.Customer = Customer_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater2.DataSource = cons.ToList
            Repeater2.DataBind()
            ScriptManager.RegisterStartupScript(CustomerUpdatePanel, CustomerUpdatePanel.GetType(), "show", "$(function () { $('#" + CustomerPanel.ClientID + "').modal('show'); });", True)
            CustomerUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Shipper-----------------------------------------------
    Protected Sub btnCustomerCode_PreGoodRec_ServerClick(sender As Object, e As EventArgs)
        selectCustomerCode()
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
    Protected Sub clickcustomer_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault
        txtCustomerCode0_PreGoodRec.Value = user.u.PartyCode
        txtNameCustomer_PreGoodRec.Value = user.u.PartyFullName
        txtAddress1Customer_PreGoodRec.Value = user.br.Address1
        txtAddress2Customer_PreGoodRec.Value = user.br.Address2
        txtAddress3Customer_PreGoodRec.Value = user.br.Address3
        txtAddress4Customer_PreGoodRec.Value = user.br.Address4

    End Sub
    '--------------------------------------------------------Show Data Owner In Modal-----------------------------------------
    Private Sub selectOwnerCode()
        Dim Owner_code As String
        Dim Consignee_ As String = ""
        If String.IsNullOrEmpty(txtOwnerCode_PreGoodRec.Value.Trim) Then
            Owner_code = ""
            Consignee_ = "0"
        Else
            Owner_code = txtOwnerCode_PreGoodRec.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = Owner_code And p.Consignee = "0") Or p.Consignee = Consignee_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater3.DataSource = cons.ToList
            Repeater3.DataBind()
            ScriptManager.RegisterStartupScript(OwnerUpdatePanel, OwnerUpdatePanel.GetType(), "show", "$(function () { $('#" + OwnerPanel.ClientID + "').modal('show'); });", True)
            OwnerUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Delivery Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Owner-----------------------------------------------
    Protected Sub btnOwnerCode_PreGoodRec_ServerClick(sender As Object, e As EventArgs)
        selectOwnerCode()
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
    '--------------------------------------------------------Click Data Owner In Modal-----------------------------------------
    Protected Sub clickowner_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        txtOwnerCode_PreGoodRec.Value = user.u.PartyCode
        txtNameOwner_PreGoodRec.Value = user.u.PartyFullName
        txtAddress1Owner_PreGoodRec.Value = user.br.Address1
        txtAddress2Owner_PreGoodRec.Value = user.br.Address2
        txtAddress3Owner_PreGoodRec.Value = user.br.Address3
        txtAddress4Owner_PreGoodRec.Value = user.br.Address4

    End Sub
    '--------------------------------------------------------Show Data WH Manage In Modal-----------------------------------------
    Private Sub selectWHManageCode()
        Dim WHManage_code As String
        Dim Warehouse_ As String = ""
        If String.IsNullOrEmpty(txtWHManagement_PreGoodRec.Value.Trim) Then
            WHManage_code = ""
            Warehouse_ = "0"
        Else
            WHManage_code = txtWHManagement_PreGoodRec.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = WHManage_code And p.Warehouse = "0") Or p.Warehouse = Warehouse_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater4.DataSource = cons.ToList
            Repeater4.DataBind()
            ScriptManager.RegisterStartupScript(WHManageUpdatePanel, WHManageUpdatePanel.GetType(), "show", "$(function () { $('#" + WHManagePanel.ClientID + "').modal('show'); });", True)
            WHManageUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล WH Manage Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search WH Manage-----------------------------------------------
    Protected Sub btnWHManagement_PreGoodRec_ServerClick(sender As Object, e As EventArgs)
        selectWHManageCode()
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
    '--------------------------------------------------------Click Data WH Manage In Modal-----------------------------------------
    Protected Sub clickwhmanage_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        txtWHManagement_PreGoodRec.Value = user.u.PartyCode
        txtNameWHManage_PreGoodRec.Value = user.u.PartyFullName
        txtAddress1WHManage_PreGoodRec.Value = user.br.Address1
        txtAddress2WHManage_PreGoodRec.Value = user.br.Address2
        txtAddress3WHManage_PreGoodRec.Value = user.br.Address3
        txtAddress4WHManage_PreGoodRec.Value = user.br.Address4

    End Sub
    '--------------------------------------------------------Show Data End User In Modal-----------------------------------------
    Private Sub selectEndUserCode()
        Dim tEndUser As String
        Dim EndCustomer_ As String = ""
        If String.IsNullOrEmpty(txtEndUserCode_PreGoodRec.Value.Trim) Then
            tEndUser = ""
            EndCustomer_ = "0"
        Else
            tEndUser = txtEndUserCode_PreGoodRec.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = tEndUser And p.EndCustomer = "0") Or p.EndCustomer = EndCustomer_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater5.DataSource = cons.ToList
            Repeater5.DataBind()
            ScriptManager.RegisterStartupScript(EndUserUpdatePanel, EndUserUpdatePanel.GetType(), "show", "$(function () { $('#" + EndUserPanel.ClientID + "').modal('show'); });", True)
            EndUserUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล End User Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search End User-----------------------------------------------
    Protected Sub btnEndUserCode_PreGoodRec_ServerClick(sender As Object, e As EventArgs)
        selectEndUserCode()
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
    '--------------------------------------------------------Click Data End User In Modal-----------------------------------------
    Protected Sub clickenduser_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        txtEndUserCode_PreGoodRec.Value = user.u.PartyCode
        txtNameEndUser_PreGoodRec.Value = user.u.PartyFullName
        txtAddress1EndUser_PreGoodRec.Value = user.br.Address1
        txtAddress2EndUser_PreGoodRec.Value = user.br.Address2
        txtAddress3EndUser_PreGoodRec.Value = user.br.Address3
        txtAddress4EndUser_PreGoodRec.Value = user.br.Address4

    End Sub
    '--------------------------------------------------------Show Data End Customer In Modal-----------------------------------------
    Private Sub selectEndCusCode()
        Dim tEndUser As String
        Dim customer_ As String = ""
        If String.IsNullOrEmpty(txtENDCustomer_GoodRecDetail.Value.Trim) Then
            tEndUser = ""
            customer_ = "0"
        Else
            tEndUser = txtENDCustomer_GoodRecDetail.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = tEndUser And p.Customer = "0") Or p.Customer = customer_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater6.DataSource = cons.ToList
            Repeater6.DataBind()
            ScriptManager.RegisterStartupScript(EndCustomerUpdatePanel, EndCustomerUpdatePanel.GetType(), "show", "$(function () { $('#" + EndCustomerPanel.ClientID + "').modal('show'); });", True)
            EndCustomerUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล End User Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search End Customer-----------------------------------------------
    Protected Sub btnENDCustomer_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)
        selectEndCusCode()
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
    '--------------------------------------------------------Click Data End Customer In Modal-----------------------------------------
    Protected Sub clickendcus_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        txtENDCustomer_GoodRecDetail.Value = user.u.PartyCode
        'txtNameEndUser_PreGoodRec.Value = user.u.PartyFullName
        'txtAddress1EndUser_PreGoodRec.Value = user.br.Address1
        'txtAddress2EndUser_PreGoodRec.Value = user.br.Address2
        'txtAddress3EndUser_PreGoodRec.Value = user.br.Address3
        'txtAddress4EndUser_PreGoodRec.Value = user.br.Address4

    End Sub
    '--------------------------------------------------------Show Data ProductCode In Modal-----------------------------------------
    Private Sub selectProductCode()
        Dim testdate As Integer
        Dim ProCode As String = ""
        If String.IsNullOrEmpty(txtEASPN_GoodRecDetail.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            ProCode = txtEASPN_GoodRecDetail.Value.Trim
        End If

        Dim cons = (From u In db.tblProductDetails
                    Where (u.ProductCode = ProCode) Or u.CreateDate.Year = testdate And u.ImpProductCode <> ""
                   Select New With {u.ProductCode,
                                    u.ImpDesc1,
                                    u.PONo,
                                    u.CustomerPart,
                                    u.EndUserPart}).ToList()

        If cons.Count > 0 Then
            Repeater7.DataSource = cons.ToList
            Repeater7.DataBind()
            ScriptManager.RegisterStartupScript(ProductCodeUpdatePanel, ProductCodeUpdatePanel.GetType(), "show", "$(function () { $('#" + ProductCodePanel.ClientID + "').modal('show'); });", True)
            ProductCodeUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล ProductCode Code นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search ProductCode-----------------------------------------------
    Protected Sub btnEASPN_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)
        selectProductCode()
    End Sub
    '--------------------------------------------------------Click Data ProductCode In Modal-----------------------------------------
    Protected Sub Repeater7_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater7.ItemCommand
        Dim ProductCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectProductCode") Then

                If String.IsNullOrEmpty(ProductCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblProductDetails Where u.ProductCode = ProductCode).SingleOrDefault

                    txtEASPN_GoodRecDetail.Value = user.ProductCode
                    txtProductDesc_GoodRecDetail.Value = user.ImpDesc1
                    txtCustomerPN_GoodRecDetail.Value = user.EndUserPart
                    txtOwnerPN_GoodRecDetail.Value = user.CustomerPart

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    '--------------------------------------------------------Show Data Jobno Edit In Modal-----------------------------------------
    Private Sub SelectJobnoEdit()
        Dim testdate As Integer
        Dim jobno_code As String = ""
        Dim status_ As Double
        If String.IsNullOrEmpty(txtJobNo_PreGoodRec.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            status_ = 0
        End If

        Dim cons = (From p In db.tblWHPrepairGoodsReceives
                    Where p.LOTNo.Contains(txtJobNo_PreGoodRec.Value.Trim) Or p.LOTDate.Year = testdate
                   Select New With {p.LOTNo,
                                    p.CustREFNo,
                                    p.OwnerNameENG,
                                    p.CustomerNameENG,
                                    p.BrokerNameENG}).ToList()

        If cons.Count > 0 Then
            Repeater8.DataSource = cons.ToList
            Repeater8.DataBind()
            ScriptManager.RegisterStartupScript(JobNoEditUpdatePanel, JobNoEditUpdatePanel.GetType(), "show", "$(function () { $('#" + JobNoEditPanel.ClientID + "').modal('show'); });", True)
            JobNoEditUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Job No นี้')", True)
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------------Click Search Job No Edit-----------------------------------------------
    Protected Sub btnJobNoSearch_Edit_ServerClick(sender As Object, e As EventArgs)
        SelectJobnoEdit()
    End Sub
    '--------------------------------------------------------Click Data JobNo Edit In Modal-----------------------------------------
    Protected Sub Repeater8_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater8.ItemCommand
        Dim JobnoCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectJobNoEdit") Then

                If String.IsNullOrEmpty(JobnoCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblWHPrepairGoodsReceives Where u.LOTNo = JobnoCode).SingleOrDefault

                    If String.IsNullOrEmpty(user.LOTNo) Then
                        txtJobNo_PreGoodRec.Value = ""
                    Else
                        txtJobNo_PreGoodRec.Value = user.LOTNo
                    End If
                    txtdatepickerJobdate_PreGoodRec.Text = Convert.ToDateTime(user.LOTDate).ToString("dd/MM/yyyy")
                    txtCustRefNo_PreGoodRec.Value = user.CustREFNo

                    txtOwnerCode_PreGoodRec.Value = user.OwnerCode
                    txtNameOwner_PreGoodRec.Value = user.OwnerNameENG
                    txtAddress1Owner_PreGoodRec.Value = user.OwnerStreet_Number
                    txtAddress2Owner_PreGoodRec.Value = user.OwnerDistrict
                    txtAddress3Owner_PreGoodRec.Value = user.OwnerSubProvince
                    txtAddress4Owner_PreGoodRec.Value = user.OwnerProvince

                    txtCustomerCode0_PreGoodRec.Value = user.CustomerCode
                    txtNameCustomer_PreGoodRec.Value = user.CustomerNameENG
                    txtAddress1Customer_PreGoodRec.Value = user.CustomerStreet_Number
                    txtAddress2Customer_PreGoodRec.Value = user.CustomerDistrict
                    txtAddress3Customer_PreGoodRec.Value = user.CustomerSubProvince
                    txtAddress4Customer_PreGoodRec.Value = user.CustomerProvince

                    txtWHManagement_PreGoodRec.Value = user.BrokerCode
                    txtNameWHManage_PreGoodRec.Value = user.BrokerNameENG
                    txtAddress1WHManage_PreGoodRec.Value = user.BrokerStreet_Number
                    txtAddress2WHManage_PreGoodRec.Value = user.BrokerDistrict
                    txtAddress3WHManage_PreGoodRec.Value = user.BrokerSubprovince
                    txtAddress4WHManage_PreGoodRec.Value = user.BrokerProvince

                    txtEndUserCode_PreGoodRec.Value = user.ENDUserCode
                    txtNameEndUser_PreGoodRec.Value = user.ENDNameENG
                    txtAddress1Customer_PreGoodRec.Value = user.ENDStreet_Number
                    txtAddress2EndUser_PreGoodRec.Value = user.ENDDistrict
                    txtAddress3EndUser_PreGoodRec.Value = user.ENDSubprovince
                    txtAddress4Customer_PreGoodRec.Value = user.ENDProvince

                    If String.IsNullOrEmpty(user.Commodity) Then
                        'ddlCommodity_PreGoodRec.Text = ""
                    Else
                        ddlCommodity_PreGoodRec.Text = user.Commodity
                    End If

                    txtQuantityOfGood_PreGoodRec.Value = String.Format("{0:0.00}", user.QuantityOfPart)

                    If String.IsNullOrEmpty(user.QuantityUnit) Then
                        'ddlQuantityOfGood_PreGoodRec.Text = ""
                    Else
                        ddlQuantityOfGood_PreGoodRec.Text = user.QuantityUnit
                    End If

                    txtQuantityPackage_PreGoodRec.Value = String.Format("{0:0.00}", user.QuantityPackage)

                    If String.IsNullOrEmpty(user.PackageUNIT) Then
                        'ddlQuantityPackage_PreGoodRec.Text = ""
                    Else
                        ddlQuantityPackage_PreGoodRec.Text = user.PackageUNIT
                    End If

                    txtWeight_PreGoodRec.Value = String.Format("{0:0.00}", user.Weigth)

                    If String.IsNullOrEmpty(user.WeigthUnit) Then
                        'ddlWeight_PreGoodRec.Text = ""
                    Else
                        ddlWeight_PreGoodRec.Text = user.WeigthUnit
                    End If

                    txtQuantityPLTSkid_PreGoodRec.Value = String.Format("{0:0.00}", user.QuantityPLT)

                    If String.IsNullOrEmpty(user.QuantityPLTUnit) Then
                        'ddlQuantityPLTSkid_PreGoodRec.Text = ""
                    Else
                        ddlQuantityPLTSkid_PreGoodRec.Text = user.QuantityPLTUnit
                    End If

                    txtVolume_PreGoodRec.Value = String.Format("{0:0.00}", user.Volume)

                    If String.IsNullOrEmpty(user.VolumeUnit) Then
                    Else
                        ddlVolume_PreGoodRec.Text = user.VolumeUnit
                    End If

                    txtRemark_PreGoodRec.Value = user.Remark

                    SelectJobDetail()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '--------------------------------------------------------Show Data Job Detail In Modal-----------------------------------------
    Private Sub SelectJobDetail()
        Dim testdate As Integer
        Dim jobno_code As String = ""
        Dim status_ As Double
        If String.IsNullOrEmpty(txtJobNo_PreGoodRec.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            status_ = 0
        Else
            jobno_code = txtJobNo_PreGoodRec.Value.Trim
        End If

        Dim cons = (From p In db.tblWHPrepairGoodsReceiveDetails
                    Where p.LOTNo = jobno_code Order By p.ItemNo Ascending
                   Select New With {p.LOTNo,
                                    p.ItemNo,
                                    p.WHSite,
                                    p.WHLocation,
                                    p.ENDCustomer,
                                    p.CustomerLOTNo}).ToList()

        If cons.Count > 0 Then
            Repeater9.DataSource = cons.ToList
            Repeater9.DataBind()
            JobDetailUpdatePanel.Update()
        Else
            Repeater9.DataSource = Nothing
            Repeater9.DataBind()
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------Click Data JobNo Edit In Modal-----------------------------------------
    Protected Sub Repeater9_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater9.ItemCommand
        Dim ItemNoo As Double = CDbl(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectJobNoDetail") Then

                If String.IsNullOrEmpty(CStr(ItemNoo)) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblWHPrepairGoodsReceiveDetails Where u.LOTNo = txtJobNo_PreGoodRec.Value.Trim And u.ItemNo = ItemNoo).SingleOrDefault

                    'txtJobNo_PreGoodRec.Value = user.LOTNo
                    ddlWHSite_GoodRecDetail.Text = user.WHSite
                    ddlWHLocation_GoodRecDetail.Text = user.WHLocation
                    txtENDCustomer_GoodRecDetail.Value = user.ENDCustomer
                    txtCusLOTNo_GoodRecDetail.Value = user.CustomerLOTNo
                    txtItemNo_GoodRecDetail.Value = CStr(user.ItemNo)
                    txtEASPN_GoodRecDetail.Value = user.ProductCode
                    txtCustomerPN_GoodRecDetail.Value = user.CustomerPN
                    txtOwnerPN_GoodRecDetail.Value = user.OwnerPN
                    txtProductDesc_GoodRecDetail.Value = user.ProductDesc
                    ddlMeasurement_GoodRecDetail.Text = user.Measurement
                    txtWidth_GoodRecDetail.Value = CStr(user.ProductWidth)
                    txtHight_GoodRecDetail.Value = CStr(user.ProductHeight)
                    txtLength_GoodRecDetail.Value = CStr(user.ProductLength)
                    txtProductVolume_GoodRecDetail.Value = CStr(user.ProductVolume)
                    txtOrderNo_GoodRecDetail.Value = user.OrderNo
                    txtReceiveNo_GoodRecDetail.Value = user.ReceiveNo
                    ddlStatus_GoodRecDetail.Text = user.Type
                    If user.ManufacturingDate Is Nothing Then
                        txtdatepickerManufacturing_GoodRecDetail.Text = Nothing
                    Else
                        txtdatepickerManufacturing_GoodRecDetail.Text = CStr(user.ManufacturingDate)
                    End If
                    'txtdatepickerManufacturing_GoodRecDetail.Text = CStr(user.ManufacturingDate)
                    If user.ManufacturingDate Is Nothing Then
                        txtdatepickerExpiredDate_GoodRecDetail.Text = Nothing
                    Else
                        txtdatepickerExpiredDate_GoodRecDetail.Text = CStr(user.ExpiredDate)
                    End If
                    'txtdatepickerExpiredDate_GoodRecDetail.Text = CStr(user.ExpiredDate)
                    txtdatepickerReceiveDate_GoodRecDetail.Text = CStr(user.ReceiveDate)
                    txtQuantity_GoodRecDetail.Value = CStr(user.Quantity)
                    ddlQuantity_GoodRecDetail.Text = user.QuantityUnit
                    txtWeight_GoodRecDetail.Value = CStr(user.Weigth)
                    ddlWeight_GoodRecDetail.Text = user.WeigthUnit
                    ddlCurrency_GoodRecDetail.Text = user.Currency
                    txtExchangeRate_GoodRecDetail.Value = CStr(user.ExchangeRate)
                    txtPriceForeign_GoodRecDetail.Value = CStr(user.PriceForeigh)
                    txtPriceBath_GoodRecDetail.Value = CStr(user.PriceBath)
                    txtAmount_GoodRecDetail.Value = CStr(user.PriceForeighAmount)
                    txtBathAmount_GoodRecDetail.Value = CStr(user.PriceBathAmount)
                    txtPalletNo_GoodRecDetail.Value = user.PalletNo
                    txtSupplier_GoodRecDetail.Value = user.Supplier
                    txtBuyer_GoodRecDetail.Value = user.Buyer
                    txtExporter_GoodRecDetail.Value = user.Exporter
                    txtDestination_GoodRecDetail.Value = user.Destination
                    txtConsignee_GoodRecDetail.Value = user.Consignee
                    txtShippingMark_GoodRecDetail.Value = user.ShippingMark
                    txtEntryNo_GoodRecDetail.Value = user.EntryNo
                    txtEntryItemNo_GoodRecDetail.Value = CStr(user.EntryItemNo)
                    txtInvoice_GoodRecDetail.Value = user.Invoice

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Save_New()
        Dim print As String = "0"

        If txtJobNo_PreGoodRec.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ PrepairLOT ก่อน !!!');", True)
            txtJobNo_PreGoodRec.Focus()
            Exit Sub
        End If

        'sb = New StringBuilder()
        'sb.Append("INSERT INTO tblWHPrepairGoodsReceive (LOTNo,LOTDate,CustREFNo,OwnerCode,OwnerNameENG,OwnerStreet_Number,OwnerDistrict,OwnerSubProvince,OwnerProvince,CustomerCode,CustomerNameENG,CustomerStreet_Number,CustomerDistrict,CustomerSubProvince,CustomerProvince,BrokerCode,BrokerNameENG,BrokerStreet_Number,BrokerDistrict,BrokerSubprovince,BrokerProvince,ENDUserCode,ENDNameENG,ENDStreet_Number,ENDDistrict,ENDSubprovince,ENDProvince,Commodity,QuantityOfPart,QuantityUnit,QuantityPackage,PackageUNIT,QuantityPLT,QuantityPLTUnit,Weigth,WeigthUnit,Volume,VolumeUnit,UserBy,LastUpdate,PrintCount,Remark)")
        'sb.Append(" VALUES (@LOTNo,@LOTDate,@CustREFNo,@OwnerCode,@OwnerNameENG,@OwnerStreet_Number,@OwnerDistrict,@OwnerSubProvince,@OwnerProvince,@CustomerCode,@CustomerNameENG,@CustomerStreet_Number,@CustomerDistrict,@CustomerSubProvince,@CustomerProvince,@BrokerCode,@BrokerNameENG,@BrokerStreet_Number,@BrokerDistrict,@BrokerSubprovince,@BrokerProvince,@ENDUserCode,@ENDNameENG,@ENDStreet_Number,@ENDDistrict,@ENDSubprovince,@ENDProvince,@Commodity,@QuantityOfPart,@QuantityUnit,@QuantityPackage,@PackageUNIT,@QuantityPLT,@QuantityPLTUnit,@Weigth,@WeigthUnit,@Volume,@VolumeUnit,@UserBy,@LastUpdate,@PrintCount,@Remark)")
        If MsgBox("คุณต้องการเพิ่มรายการ Job No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Using tran As New TransactionScope()

                If investigate() = txtJobNo_PreGoodRec.Value.Trim Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('มีเลข JOBNo นี้อยู่แล้ว');", True)
                Else
                    Try
                        db.Database.Connection.Open()
                        db.tblWHPrepairGoodsReceives.Add(New tblWHPrepairGoodsReceive With { _
                         .LOTNo = txtJobNo_PreGoodRec.Value.Trim, _
                        .LOTDate = CDate(txtdatepickerJobdate_PreGoodRec.Text.Trim), _
                        .CustREFNo = txtCustRefNo_PreGoodRec.Value.Trim, _
                        .OwnerCode = txtOwnerCode_PreGoodRec.Value.Trim, _
                        .OwnerNameENG = txtNameOwner_PreGoodRec.Value.Trim, _
                        .OwnerStreet_Number = txtAddress1Owner_PreGoodRec.Value.Trim, _
                        .OwnerDistrict = txtAddress2Owner_PreGoodRec.Value.Trim, _
                        .OwnerSubProvince = txtAddress3Owner_PreGoodRec.Value.Trim, _
                        .OwnerProvince = txtAddress4Owner_PreGoodRec.Value.Trim, _
                        .CustomerCode = txtCustomerCode0_PreGoodRec.Value.Trim, _
                        .CustomerNameENG = txtNameCustomer_PreGoodRec.Value.Trim, _
                        .CustomerStreet_Number = txtAddress1Customer_PreGoodRec.Value.Trim, _
                        .CustomerDistrict = txtAddress2Customer_PreGoodRec.Value.Trim, _
                        .CustomerSubProvince = txtAddress3Customer_PreGoodRec.Value.Trim, _
                        .CustomerProvince = txtAddress4Customer_PreGoodRec.Value.Trim, _
                        .BrokerCode = txtWHManagement_PreGoodRec.Value.Trim, _
                        .BrokerNameENG = txtNameWHManage_PreGoodRec.Value.Trim, _
                        .BrokerStreet_Number = txtAddress1WHManage_PreGoodRec.Value.Trim, _
                        .BrokerDistrict = txtAddress2WHManage_PreGoodRec.Value.Trim, _
                        .BrokerSubprovince = txtAddress3WHManage_PreGoodRec.Value.Trim, _
                        .BrokerProvince = txtAddress4WHManage_PreGoodRec.Value.Trim, _
                        .ENDUserCode = txtEndUserCode_PreGoodRec.Value.Trim, _
                        .ENDNameENG = txtNameEndUser_PreGoodRec.Value.Trim, _
                        .ENDStreet_Number = txtAddress1Customer_PreGoodRec.Value.Trim, _
                        .ENDDistrict = txtAddress2EndUser_PreGoodRec.Value.Trim, _
                        .ENDSubprovince = txtAddress3EndUser_PreGoodRec.Value.Trim, _
                        .ENDProvince = txtAddress4Customer_PreGoodRec.Value.Trim, _
                        .Commodity = ddlCommodity_PreGoodRec.Text.Trim, _
                        .QuantityOfPart = CType(txtQuantityOfGood_PreGoodRec.Value.Trim, Double?), _
                        .QuantityUnit = ddlQuantityOfGood_PreGoodRec.Text.Trim, _
                        .QuantityPackage = CType(txtQuantityPackage_PreGoodRec.Value.Trim, Double?), _
                        .PackageUNIT = ddlQuantityPackage_PreGoodRec.Text.Trim, _
                        .Weigth = CType(txtWeight_PreGoodRec.Value.Trim, Double?), _
                        .WeigthUnit = ddlWeight_PreGoodRec.Text.Trim, _
                        .QuantityPLT = CType(txtQuantityPLTSkid_PreGoodRec.Value.Trim, Double?), _
                        .QuantityPLTUnit = ddlQuantityPLTSkid_PreGoodRec.Text.Trim, _
                        .Volume = CType(txtVolume_PreGoodRec.Value.Trim, Double?), _
                        .VolumeUnit = ddlVolume_PreGoodRec.Text.Trim, _
                        .Remark = txtRemark_PreGoodRec.Value.Trim, _
                        .UserBy = CStr(Session("UserName")), _
                        .LastUpdate = Now, _
                        .PrintCount = print, _
                        .UsedStatus = 0
                })

                        db.SaveChanges()
                        tran.Complete()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('บันทึกข้อมูล สำเร็จเรียบร้อย !');", True)

                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                        'Finally
                        '    db.Database.Connection.Close()
                        '    db.Dispose()
                        tran.Dispose()
                    End Try
                End If
               
            End Using
        End If
        txtJobNo_PreGoodRec.Focus()
    End Sub
    Private Sub Save_Modify()
        If txtJobNo_PreGoodRec.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ PrepairLOT ก่อน !!!');", True)
            txtJobNo_PreGoodRec.Focus()
            Exit Sub
        End If
        If MsgBox("คุณต้องการแก้ไขรายการ PrepairLOT ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    Dim edit As tblWHPrepairGoodsReceive = (From c In db.tblWHPrepairGoodsReceives Where c.LOTNo = txtJobNo_PreGoodRec.Value.Trim
                      Select c).First()
                    If edit IsNot Nothing Then
                        edit.LOTNo = txtJobNo_PreGoodRec.Value.Trim
                        edit.LOTDate = CDate(txtdatepickerJobdate_PreGoodRec.Text.Trim)
                        edit.CustREFNo = txtCustRefNo_PreGoodRec.Value.Trim
                        edit.OwnerCode = txtOwnerCode_PreGoodRec.Value.Trim
                        edit.OwnerNameENG = txtNameOwner_PreGoodRec.Value.Trim
                        edit.OwnerStreet_Number = txtAddress1Owner_PreGoodRec.Value.Trim
                        edit.OwnerDistrict = txtAddress2Owner_PreGoodRec.Value.Trim
                        edit.OwnerSubProvince = txtAddress3Owner_PreGoodRec.Value.Trim
                        edit.OwnerProvince = txtAddress4Owner_PreGoodRec.Value.Trim
                        edit.CustomerCode = txtCustomerCode0_PreGoodRec.Value.Trim
                        edit.CustomerNameENG = txtNameCustomer_PreGoodRec.Value.Trim
                        edit.CustomerStreet_Number = txtAddress1Customer_PreGoodRec.Value.Trim
                        edit.CustomerDistrict = txtAddress2Customer_PreGoodRec.Value.Trim
                        edit.CustomerSubProvince = txtAddress3Customer_PreGoodRec.Value.Trim
                        edit.CustomerProvince = txtAddress4Customer_PreGoodRec.Value.Trim
                        edit.BrokerCode = txtWHManagement_PreGoodRec.Value.Trim
                        edit.BrokerNameENG = txtNameWHManage_PreGoodRec.Value.Trim
                        edit.BrokerStreet_Number = txtAddress1WHManage_PreGoodRec.Value.Trim
                        edit.BrokerDistrict = txtAddress2WHManage_PreGoodRec.Value.Trim
                        edit.BrokerSubprovince = txtAddress3WHManage_PreGoodRec.Value.Trim
                        edit.BrokerProvince = txtAddress4WHManage_PreGoodRec.Value.Trim
                        edit.ENDUserCode = txtEndUserCode_PreGoodRec.Value.Trim
                        edit.ENDNameENG = txtNameEndUser_PreGoodRec.Value.Trim
                        edit.ENDStreet_Number = txtAddress1Customer_PreGoodRec.Value.Trim
                        edit.ENDDistrict = txtAddress2EndUser_PreGoodRec.Value.Trim
                        edit.ENDSubprovince = txtAddress3EndUser_PreGoodRec.Value.Trim
                        edit.ENDProvince = txtAddress4Customer_PreGoodRec.Value.Trim
                        edit.Commodity = ddlCommodity_PreGoodRec.Text.Trim
                        edit.QuantityOfPart = CType(txtQuantityOfGood_PreGoodRec.Value.Trim, Double?)
                        edit.QuantityUnit = ddlQuantityOfGood_PreGoodRec.Text.Trim
                        edit.QuantityPackage = CType(txtQuantityPackage_PreGoodRec.Value.Trim, Double?)
                        edit.PackageUNIT = ddlQuantityPackage_PreGoodRec.Text.Trim
                        edit.Weigth = CType(txtWeight_PreGoodRec.Value.Trim, Double?)
                        edit.WeigthUnit = ddlWeight_PreGoodRec.Text.Trim
                        edit.QuantityPLT = CType(txtQuantityPLTSkid_PreGoodRec.Value.Trim, Double?)
                        edit.QuantityPLTUnit = ddlQuantityPLTSkid_PreGoodRec.Text.Trim
                        edit.Volume = CType(txtVolume_PreGoodRec.Value.Trim, Double?)
                        edit.VolumeUnit = ddlVolume_PreGoodRec.Text.Trim
                        edit.Remark = txtRemark_PreGoodRec.Value.Trim
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
        txtJobNo_PreGoodRec.Focus()
    End Sub
    Private Sub SaveDetail_New()
        Dim ManuDate As Nullable(Of Date)
        Dim ExpDate As Nullable(Of Date)
        Dim receiveDate_ As Nullable(Of Date)
        If txtJobNo_PreGoodRec.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(กรุณาป้อน Job No ก่อน !!!);", True)
            txtJobNo_PreGoodRec.Focus()
            Exit Sub
        End If

        If txtItemNo_GoodRecDetail.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(กรุณาใส่ Item No ก่อน !!!);", True)
            txtItemNo_GoodRecDetail.Focus()
            Exit Sub
        End If

        If chkNotUseDate_GoodRecDetail.Checked = True Then
            ManuDate = Nothing
            ExpDate = Nothing
        ElseIf chkNotUseDate_GoodRecDetail.Checked = False Then
            ManuDate = DateTime.ParseExact(txtdatepickerManufacturing_GoodRecDetail.Text.Trim, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
            ExpDate = DateTime.ParseExact(txtdatepickerExpiredDate_GoodRecDetail.Text.Trim, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        If String.IsNullOrEmpty(txtdatepickerReceiveDate_GoodRecDetail.Text.Trim) Then
            receiveDate_ = Nothing
        Else
            receiveDate_ = DateTime.ParseExact(txtdatepickerReceiveDate_GoodRecDetail.Text.Trim, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If

        checkNull()

        If MsgBox("คุณต้องการเพิ่มรายการ WHGoodsReceiveDetail ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()

                    db.tblWHPrepairGoodsReceiveDetails.Add(New tblWHPrepairGoodsReceiveDetail With { _
                            .LOTNo = txtJobNo_PreGoodRec.Value.Trim, _
                            .WHSite = ddlWHSite_GoodRecDetail.Text.Trim, _
                            .WHLocation = ddlWHLocation_GoodRecDetail.Text.Trim, _
                            .ENDCustomer = txtENDCustomer_GoodRecDetail.Value.Trim, _
                            .CustomerLOTNo = txtCusLOTNo_GoodRecDetail.Value.Trim, _
                            .ItemNo = CDbl(txtItemNo_GoodRecDetail.Value.Trim), _
                            .ProductCode = txtEASPN_GoodRecDetail.Value.Trim, _
                            .CustomerPN = txtCustomerPN_GoodRecDetail.Value.Trim, _
                            .OwnerPN = txtOwnerPN_GoodRecDetail.Value.Trim, _
                            .ProductDesc = txtProductDesc_GoodRecDetail.Value.Trim, _
                            .Measurement = ddlMeasurement_GoodRecDetail.Text.Trim, _
                            .ProductWidth = CType(txtWidth_GoodRecDetail.Value.Trim, Double?), _
                            .ProductHeight = CType(txtHight_GoodRecDetail.Value.Trim, Double?), _
                            .ProductLength = CType(txtLength_GoodRecDetail.Value.Trim, Double?), _
                            .ProductVolume = CType(txtProductVolume_GoodRecDetail.Value.Trim, Double?), _
                            .OrderNo = txtOrderNo_GoodRecDetail.Value.Trim, _
                            .ReceiveNo = txtReceiveNo_GoodRecDetail.Value.Trim, _
                            .Type = ddlStatus_GoodRecDetail.Text.Trim, _
                            .ManufacturingDate = ManuDate, _
                            .ExpiredDate = ExpDate, _
                            .ReceiveDate = receiveDate_, _
                            .Quantity = CType(txtQuantity_GoodRecDetail.Value.Trim, Double?), _
                            .QuantityUnit = ddlQuantity_GoodRecDetail.Text.Trim, _
                            .Weigth = CType(txtWeight_GoodRecDetail.Value.Trim, Double?), _
                            .WeigthUnit = ddlWeight_GoodRecDetail.Text.Trim, _
                            .Currency = ddlCurrency_GoodRecDetail.Text.Trim, _
                            .ExchangeRate = CType(txtExchangeRate_GoodRecDetail.Value.Trim, Double?), _
                            .PriceForeigh = CType(txtPriceForeign_GoodRecDetail.Value.Trim, Double?), _
                            .PriceBath = CType(txtPriceBath_GoodRecDetail.Value.Trim, Double?), _
                            .PriceForeighAmount = CType(txtAmount_GoodRecDetail.Value.Trim, Double?), _
                            .PriceBathAmount = CType(txtBathAmount_GoodRecDetail.Value.Trim, Double?), _
                            .PalletNo = txtPalletNo_GoodRecDetail.Value.Trim, _
                            .Supplier = txtSupplier_GoodRecDetail.Value.Trim, _
                            .Buyer = txtBuyer_GoodRecDetail.Value.Trim, _
                            .Exporter = txtExporter_GoodRecDetail.Value.Trim, _
                            .Destination = txtDestination_GoodRecDetail.Value.Trim, _
                            .Consignee = txtConsignee_GoodRecDetail.Value.Trim, _
                            .ShippingMark = txtShippingMark_GoodRecDetail.Value.Trim, _
                            .EntryNo = txtEntryNo_GoodRecDetail.Value.Trim, _
                            .EntryItemNo = CType(txtEntryItemNo_GoodRecDetail.Value.Trim, Integer?), _
                            .Invoice = txtInvoice_GoodRecDetail.Value.Trim, _
                            .UserBy = CStr(Session("UserName")), _
                            .LastUpdate = Now, _
                            .Status = 0
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
        txtItemNo_GoodRecDetail.Focus()
    End Sub
    Private Sub SaveDetail_Modify()
        Dim ManuDate As Nullable(Of Date)
        Dim ExpDate As Nullable(Of Date)

        If txtJobNo_PreGoodRec.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(กรุณาป้อน Job No ก่อน !!!);", True)
            txtJobNo_PreGoodRec.Focus()
            Exit Sub
        End If

        If txtItemNo_GoodRecDetail.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(กรุณาใส่ Item No ก่อน !!!);", True)
            txtItemNo_GoodRecDetail.Focus()
            Exit Sub
        End If

        If chkNotUseDate_GoodRecDetail.Checked = True Then
            ManuDate = Nothing
            ExpDate = Nothing
        ElseIf chkNotUseDate_GoodRecDetail.Checked = False Then
            ManuDate = DateTime.ParseExact(txtdatepickerManufacturing_GoodRecDetail.Text.Trim, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
            ExpDate = DateTime.ParseExact(txtdatepickerExpiredDate_GoodRecDetail.Text.Trim, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If

        If MsgBox("คุณต้องการแก้ไขรายการ WHGoodsReceiveDetail ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    Dim edit As tblWHPrepairGoodsReceiveDetail = (From c In db.tblWHPrepairGoodsReceiveDetails Where c.LOTNo = txtJobNo_PreGoodRec.Value.Trim And c.ItemNo = CDbl(txtItemNo_GoodRecDetail.Value.Trim)
                      Select c).First()
                    If edit IsNot Nothing Then
                        edit.LOTNo = txtJobNo_PreGoodRec.Value.Trim
                        edit.WHSite = ddlWHSite_GoodRecDetail.Text.Trim
                        edit.WHLocation = ddlWHLocation_GoodRecDetail.Text.Trim
                        edit.ENDCustomer = txtENDCustomer_GoodRecDetail.Value.Trim
                        edit.CustomerLOTNo = txtCusLOTNo_GoodRecDetail.Value.Trim
                        edit.ItemNo = CDbl(txtItemNo_GoodRecDetail.Value.Trim)
                        edit.ProductCode = txtEASPN_GoodRecDetail.Value.Trim
                        edit.CustomerPN = txtCustomerPN_GoodRecDetail.Value.Trim
                        edit.OwnerPN = txtOwnerPN_GoodRecDetail.Value.Trim
                        edit.ProductDesc = txtProductDesc_GoodRecDetail.Value.Trim
                        edit.Measurement = ddlMeasurement_GoodRecDetail.Text.Trim
                        edit.ProductWidth = CType(txtWidth_GoodRecDetail.Value.Trim, Double?)
                        edit.ProductHeight = CType(txtHight_GoodRecDetail.Value.Trim, Double?)
                        edit.ProductLength = CType(txtLength_GoodRecDetail.Value.Trim, Double?)
                        edit.ProductVolume = CType(txtProductVolume_GoodRecDetail.Value.Trim, Double?)
                        edit.OrderNo = txtOrderNo_GoodRecDetail.Value.Trim
                        edit.ReceiveNo = txtReceiveNo_GoodRecDetail.Value.Trim
                        edit.Type = ddlStatus_GoodRecDetail.Text.Trim
                        edit.ManufacturingDate = ManuDate
                        edit.ExpiredDate = ExpDate
                        edit.ReceiveDate = CType(txtdatepickerReceiveDate_GoodRecDetail.Text.Trim, Date?)
                        edit.Quantity = CType(txtQuantity_GoodRecDetail.Value.Trim, Double?)
                        edit.QuantityUnit = ddlQuantity_GoodRecDetail.Text.Trim
                        edit.Weigth = CType(txtWeight_GoodRecDetail.Value.Trim, Double?)
                        edit.WeigthUnit = ddlWeight_GoodRecDetail.Text.Trim
                        edit.Currency = ddlCurrency_GoodRecDetail.Text.Trim
                        edit.ExchangeRate = CType(txtExchangeRate_GoodRecDetail.Value.Trim, Double?)
                        edit.PriceForeigh = CType(txtPriceForeign_GoodRecDetail.Value.Trim, Double?)
                        edit.PriceBath = CType(txtPriceBath_GoodRecDetail.Value.Trim, Double?)
                        edit.PriceForeighAmount = CType(txtAmount_GoodRecDetail.Value.Trim, Double?)
                        edit.PriceBathAmount = CType(txtBathAmount_GoodRecDetail.Value.Trim, Double?)
                        edit.PalletNo = txtPalletNo_GoodRecDetail.Value.Trim
                        edit.Supplier = txtSupplier_GoodRecDetail.Value.Trim
                        edit.Buyer = txtBuyer_GoodRecDetail.Value.Trim
                        edit.Exporter = txtExporter_GoodRecDetail.Value.Trim
                        edit.Destination = txtDestination_GoodRecDetail.Value.Trim
                        edit.Consignee = txtConsignee_GoodRecDetail.Value.Trim
                        edit.ShippingMark = txtShippingMark_GoodRecDetail.Value.Trim
                        edit.EntryNo = txtEntryNo_GoodRecDetail.Value.Trim
                        edit.EntryItemNo = CType(txtEntryItemNo_GoodRecDetail.Value.Trim, Integer?)
                        edit.Invoice = txtInvoice_GoodRecDetail.Value.Trim
                        edit.UserBy = CStr(Session("UserName"))
                        edit.LastUpdate = Now
                        edit.Status = 0

                        db.SaveChanges()
                        tran.Complete()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                    End If
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        txtItemNo_GoodRecDetail.Focus()
    End Sub
    '------------------------------------------------------------Update Status JobNo in tblImpGenLOT---------------------------------------
    Private Sub UpdateStatus()
        If txtJobNo_PreGoodRec.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(กรุณาป้อน Job No ก่อน !!!);", True)
            txtJobNo_PreGoodRec.Focus()
            Exit Sub
        End If
        Try

            Dim edit As tblImpGenLOT = (From c In db.tblImpGenLOTs Where c.EASLOTNo = txtJobNo_PreGoodRec.Value.Trim
              Select c).First()
            If edit IsNot Nothing Then
                'edit.EASLOTNo = txtJobNo_PreGoodRec.Value.Trim
                edit.Status = 1
                db.SaveChanges()

            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
        End Try
        txtJobNo_PreGoodRec.Focus()
    End Sub
    Private Sub ClearDATA()
        txtJobNo_PreGoodRec.Value = ""
        txtOwnerCode_PreGoodRec.Value = ""
        txtNameOwner_PreGoodRec.Value = ""
        txtAddress1Owner_PreGoodRec.Value = ""
        txtAddress2Owner_PreGoodRec.Value = ""
        txtAddress3Owner_PreGoodRec.Value = ""
        txtAddress4Owner_PreGoodRec.Value = ""
        txtCustomerCode0_PreGoodRec.Value = ""
        txtNameCustomer_PreGoodRec.Value = ""
        txtAddress1Customer_PreGoodRec.Value = ""
        txtAddress2Customer_PreGoodRec.Value = ""
        txtAddress3Customer_PreGoodRec.Value = ""
        txtAddress4Customer_PreGoodRec.Value = ""
        txtRemark_PreGoodRec.Value = ""
        txtWHManagement_PreGoodRec.Value = ""
        txtNameWHManage_PreGoodRec.Value = ""
        txtAddress1WHManage_PreGoodRec.Value = ""
        txtAddress2WHManage_PreGoodRec.Value = ""
        txtAddress3WHManage_PreGoodRec.Value = ""
        txtAddress4WHManage_PreGoodRec.Value = ""
        txtEndUserCode_PreGoodRec.Value = ""
        txtNameEndUser_PreGoodRec.Value = ""
        txtAddress1EndUser_PreGoodRec.Value = ""
        txtAddress2EndUser_PreGoodRec.Value = ""
        txtAddress3EndUser_PreGoodRec.Value = ""
        txtAddress4EndUser_PreGoodRec.Value = ""
        'ddlCommodity_PreGoodRec.Text = ""
        txtQuantityOfGood_PreGoodRec.Value = "0.0"
        'dcbQuantity1.Text = ""
        txtQuantityPackage_PreGoodRec.Value = "0.0"
        'dcbQuantity2.Text = ""
        txtQuantityPLTSkid_PreGoodRec.Value = "0.0"
        txtWeight_PreGoodRec.Value = "0.0"
        'ddlWeight_PreGoodRec.Text = ""
        txtVolume_PreGoodRec.Value = "0.0"
        'ddlVolume_PreGoodRec.Value = ""
        'ddlQuantityPLTSkid_PreGoodRec.Text = ""
        txtHandlePreson_PreGoodRec.Value = "0"
        'txtDirectory.Value = ""
        'ProgressBar.Value = 0
        'chbCustomer.Checked = False
        'dgvItemDetail.DataSource = Nothing
        'dgvImported.DataSource = Nothing

    End Sub
    Private Sub ClearDATA1()
        'ddlWHSite_GoodRecDetail.Text = ""
        'ddlWHLocation_GoodRecDetail.Text = ""
        txtENDCustomer_GoodRecDetail.Value = ""
        txtCusLOTNo_GoodRecDetail.Value = ""
        txtItemNo_GoodRecDetail.Value = ""
        txtEASPN_GoodRecDetail.Value = ""
        txtCustomerPN_GoodRecDetail.Value = ""
        txtOwnerPN_GoodRecDetail.Value = ""
        txtProductDesc_GoodRecDetail.Value = ""
        'ddlMeasurement_GoodRecDetail.Text = ""
        txtWidth_GoodRecDetail.Value = "0"
        txtHight_GoodRecDetail.Value = "0"
        txtLength_GoodRecDetail.Value = "0"
        txtProductVolume_GoodRecDetail.Value = "0"
        txtOrderNo_GoodRecDetail.Value = ""
        txtReceiveNo_GoodRecDetail.Value = ""
        'ddlStatus_GoodRecDetail.Text = ""
        txtdatepickerManufacturing_GoodRecDetail.Text = ""
        txtdatepickerExpiredDate_GoodRecDetail.Text = ""
        txtdatepickerReceiveDate_GoodRecDetail.Text = ""
        txtQuantity_GoodRecDetail.Value = "0"
        'ddlQuantity_GoodRecDetail.Text = ""
        txtWeight_GoodRecDetail.Value = "0"
        'ddlWeight_GoodRecDetail.Text = ""
        'ddlCurrency_GoodRecDetail.Text = ""
        txtExchangeRate_GoodRecDetail.Value = "0"
        txtPriceForeign_GoodRecDetail.Value = "0"
        txtPriceBath_GoodRecDetail.Value = "0"
        txtAmount_GoodRecDetail.Value = "0"
        txtBathAmount_GoodRecDetail.Value = "0"
        txtPalletNo_GoodRecDetail.Value = "0"
        txtSupplier_GoodRecDetail.Value = ""
        txtBuyer_GoodRecDetail.Value = ""
        txtExporter_GoodRecDetail.Value = ""
        txtDestination_GoodRecDetail.Value = ""
        txtConsignee_GoodRecDetail.Value = ""
        txtShippingMark_GoodRecDetail.Value = ""
        txtEntryNo_GoodRecDetail.Value = ""
        txtEntryItemNo_GoodRecDetail.Value = ""
        txtInvoice_GoodRecDetail.Value = ""
    End Sub
    Private Sub checkNull()

        If String.IsNullOrEmpty(txtItemNo_GoodRecDetail.Value.Trim) Then
            txtItemNo_GoodRecDetail.Value = "0.0"
        ElseIf String.IsNullOrEmpty(txtQuantity_GoodRecDetail.Value.Trim) Then
            txtQuantity_GoodRecDetail.Value = "0.0"
        ElseIf String.IsNullOrEmpty(txtWeight_GoodRecDetail.Value.Trim) Then
            txtWeight_GoodRecDetail.Value = "0.0"
        ElseIf String.IsNullOrEmpty(txtExchangeRate_GoodRecDetail.Value.Trim) Then
            txtExchangeRate_GoodRecDetail.Value = "0.0"
        ElseIf String.IsNullOrEmpty(txtPriceForeign_GoodRecDetail.Value.Trim) Then
            txtPriceForeign_GoodRecDetail.Value = "0.0"
        ElseIf String.IsNullOrEmpty(txtPriceBath_GoodRecDetail.Value.Trim) Then
            txtPriceBath_GoodRecDetail.Value = "0.0"
        ElseIf String.IsNullOrEmpty(txtAmount_GoodRecDetail.Value.Trim) Then
            txtAmount_GoodRecDetail.Value = "0.0"
        ElseIf String.IsNullOrEmpty(txtBathAmount_GoodRecDetail.Value.Trim) Then
            txtBathAmount_GoodRecDetail.Value = "0.0"
        ElseIf String.IsNullOrEmpty(txtEntryItemNo_GoodRecDetail.Value.Trim) Then
            txtEntryItemNo_GoodRecDetail.Value = "0"
        End If
    End Sub
    Private Function investigate() As String
        Dim pc = (From p In db.tblWHPrepairGoodsReceives Where p.LOTNo = txtJobNo_PreGoodRec.Value.Trim).FirstOrDefault
        If Not IsNothing(pc) Then
            Return pc.LOTNo
        Else
            Return ""
        End If
    End Function
    Private Sub SaveDeleteDetail()
        If txtJobNo_PreGoodRec.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เลือกข้อมูลที่ต้องการ Delete ก่อน !!!');", True)
            Exit Sub
        End If

        If txtItemNo_GoodRecDetail.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ ItemNo ก่อน !!!');", True)
            Exit Sub
        End If

        If MsgBox("คุณต้องการลบข้อมูล PrepairLOT ใช่หรือไม่?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    'sb.Append("Delete tblWHPrepairGoodsReceiveDetail")
                    'sb.Append(" WHERE (LOTNo=@LOTNo and ItemNo=@ItemNo)")
                    Dim Delete As tblWHPrepairGoodsReceiveDetail = (From de In db.tblWHPrepairGoodsReceiveDetails Where de.LOTNo = txtJobNo_PreGoodRec.Value.Trim And
                                                                    de.ItemNo = CDbl(txtItemNo_GoodRecDetail.Value.Trim) Select de).First()

                    db.tblWHPrepairGoodsReceiveDetails.Remove(Delete)

                    db.SaveChanges()
                    tran.Complete()
                Catch ex As Exception
                    tran.Dispose()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดในการ Delete');", True)
                End Try
            End Using
        End If
    End Sub
    '--------------------------------------------------------------DeleteAll Method ยังใช้ไม่ได้และไม่ให้ใช้ป้องกันUserDeleteผิดทั้งหมด-----------------------------
    Private Sub SaveDeleteDetailALL()
        '    If txtJobNo_PreGoodRec.Value.Trim = "" Then
        '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เลือกข้อมูลที่ต้องการ Delete ก่อน !!!');", True)
        '        Exit Sub
        '    End If

        '    If MsgBox("คุณต้องการลบข้อมูล PrepairLOT All ใช่หรือไม่?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Using tran As New TransactionScope()
        '            Try
        '                'sb.Append("Delete tblWHPrepairGoodsReceiveDetail")
        '                'sb.Append(" WHERE (LOTNo=@LOTNo and Status = 0)")
        '                Dim DeleteAll As tblWHPrepairGoodsReceiveDetail = (From de In db.tblWHPrepairGoodsReceiveDetails Where de.LOTNo = txtJobNo_PreGoodRec.Value.Trim And
        '                                                                de.Status = 0 Select de).SingleOrDefault()

        '                db.tblWHPrepairGoodsReceiveDetails.Remove(DeleteAll)

        '                db.SaveChanges()
        '                tran.Complete()

        '            Catch ex As Exception
        '                tran.Dispose()
        '                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดในการ Delete All');", True)
        '            End Try
        '        End Using
        '    End If
    End Sub
End Class