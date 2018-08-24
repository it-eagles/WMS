Option Explicit On
Option Strict On


Public Class PrepareLotWH
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis
    Dim ChkStatus As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmPrepairLOT"
        If Not Me.IsPostBack Then
            If ClassPermis.CheckRead(form, usename) = True Then
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

                    ChkStatus = ChkStatus

                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
                'Response.Redirect("HomeMain.aspx")
            End If
        End If
    End Sub
    '-----------------------------------------------------------Click btn Add New GOODRECDETAIL TAB--------------------------------------
    Protected Sub btnAddNew_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '-----------------------------------------------------------Click btn Save Modify GOODRECDETAIL TAB--------------------------------------
    Protected Sub btnSaveModify_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '-----------------------------------------------------------Click btn Delete GOODRECDETAIL TAB--------------------------------------
    Protected Sub btnDelete_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '-----------------------------------------------------------Click btn Delecte All GOODRECDETAIL TAB--------------------------------------
    Protected Sub btnDeleteAll_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '-----------------------------------------------------------Click btn Add New Head PREPAREGOODREC TAB--------------------------------------
    Protected Sub btnAddHead_ServerClick(sender As Object, e As EventArgs)
        ChkStatus = "Add"
    End Sub
    '-----------------------------------------------------------Click btn Edit Head PREPAREGOODREC TAB--------------------------------------
    Protected Sub btnEditHead_ServerClick(sender As Object, e As EventArgs)
        ChkStatus = "Edit"
    End Sub
    '-----------------------------------------------------------Click btn Save New Head PREPAREGOODREC TAB--------------------------------------
    Protected Sub btnSaveAddHead_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '-----------------------------------------------------------Click btn Save Edit Head PREPAREGOODREC TAB--------------------------------------
    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)

    End Sub
    '-----------------------------------------------------------Click btn Job No Search PREPAREGOODREC TAB--------------------------------------
    Protected Sub btnJobNoSearch_ServerClick(sender As Object, e As EventArgs)
        If ChkStatus = "Add" Then
            SelectJobnoCode()
        ElseIf ChkStatus = "Edit" Then
        Else
            SelectJobnoCode()
        End If
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

        Dim cons = (From p In db.tblImpGenLOTs
                    Where (p.EASLOTNo = jobno_code And p.Status = 0) Or p.Status = status_ And p.LOTDate.Year = testdate
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
    '--------------------------------------------------------Click Data ProductCode In Modal-----------------------------------------
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
        If String.IsNullOrEmpty(txtEndUserCode_PreGoodRec.Value.Trim) Then
            tEndUser = ""
            customer_ = "0"
        Else
            tEndUser = txtEndUserCode_PreGoodRec.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = tEndUser And p.Customer = "0") Or p.Customer = customer_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            Repeater5.DataSource = cons.ToList
            Repeater5.DataBind()
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

End Class