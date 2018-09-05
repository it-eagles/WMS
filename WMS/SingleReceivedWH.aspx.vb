Option Strict On
Option Explicit On

Imports System.Globalization
Public Class SingleReceivedWH
    Inherits System.Web.UI.Page

    'Dim db As New LKBWarehouseEntities
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis
    Dim QTY(1) As Double
    Dim Status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmConfirmGoodsReceive"
        If Not Me.IsPostBack Then
            If ClassPermis.CheckRead(form, usename) = True Then
                If Not IsPostBack Then
                    showBox()
                    showBox1()
                    showCommodity()
                    showDiscrepencyUNIT()
                    showJobSite()
                    showQuantity3()
                    showQuatity1()
                    showQuatity2()
                    showSales()
                    showSales1()
                    showSource()
                    showUnitPallet()
                    showUnitWeightDetail()
                    showVolume()
                    showWeight()
                    showWeightINV()
                    btnSaveNew.Visible = False
                    btnSaveEdit.Visible = False
                    TabName.Value = Request.Form(TabName.UniqueID)
                    confirmgoodreceive_.Disabled = True
                    goodreceivedetail_.Disabled = True
                    btnSeletJobNew.Visible = False
                    btnSelectJobEdit.Visible = False
                    ClearDATA()
                    ClearDATA1()
                    rdbManual.Checked = True
                    'Response.Cache.SetExpires(DateTime.Now.AddSeconds(60))
                    'Response.Cache.SetCacheability(HttpCacheability.Public)
                    'Response.Cache.SetValidUntilExpires(True)
                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
                'Response.Redirect("HomeMain.aspx")
                btnAddNew.Disabled = True
                btnEdit.Disabled = True
            End If
            'cdbUnitPallet
        End If
    End Sub

    Protected Sub btnSumQTY_ConGoodRec_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSelectAll_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnCencelSelectAll_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnReceive_GoodRecDetail_ServerClick(sender As Object, e As EventArgs)
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmConfirmGoodsReceive"
        If classPermis.CheckSave(form, usename) = True Then
            If Status <> "2" And Status <> "3" Then
                CallculateGoods()
                SaveDetail_New()
            End If
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
        End If
    End Sub

    Protected Sub btnPutAway_ServerClick(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(dcbSite1.Text) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Site  ก่อน !!!');", True)
        Else
            If rdbManual.Checked = True Then
                PutAlway()
            Else
                PutAlwayAuto()
            End If
        End If
    End Sub
    Private Sub showUnitWeightDetail()
        'dcbQuantity1.Items.Clear()
        'dcbQuantity1.Items.Add(New ListItem("select Code"))
        'dcbQuantity1.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT"
                 Select q.Code, q.Type

        Try
            dcboUnitWeightDetail.DataSource = qt.ToList
            dcboUnitWeightDetail.DataTextField = "Code"
            dcboUnitWeightDetail.DataValueField = "Code"
            dcboUnitWeightDetail.DataBind()
            If dcboUnitWeightDetail.Items.Count > 1 Then
                dcboUnitWeightDetail.Enabled = True
            Else
                dcboUnitWeightDetail.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub showQuatity1()
        'dcbQuantity1.Items.Clear()
        'dcbQuantity1.Items.Add(New ListItem("select Code"))
        'dcbQuantity1.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT"
                 Select q.Code, q.Type

        Try
            dcbQuantity1.DataSource = qt.ToList
            dcbQuantity1.DataTextField = "Code"
            dcbQuantity1.DataValueField = "Code"
            dcbQuantity1.DataBind()
            If dcbQuantity1.Items.Count > 1 Then
                dcbQuantity1.Enabled = True
            Else
                dcbQuantity1.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub showQuatity2()
        'dcbQuantity2.Items.Clear()
        'dcbQuantity2.Items.Add(New ListItem("select Code"))
        'dcbQuantity2.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT"
                 Select q.Code, q.Type

        Try
            dcbQuantity2.DataSource = qt.ToList
            dcbQuantity2.DataTextField = "Code"
            dcbQuantity2.DataValueField = "Code"
            dcbQuantity2.DataBind()
            If dcbQuantity2.Items.Count > 1 Then
                dcbQuantity2.Enabled = True
            Else
                dcbQuantity2.Enabled = False

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub showWeight()
        'dcbWeight.Items.Clear()
        'dcbWeight.Items.Add(New ListItem("select Weight"))
        'dcbWeight.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT"
                 Select q.Code, q.Type

        Try
            dcbWeight.DataSource = qt.ToList
            dcbWeight.DataTextField = "Code"
            dcbWeight.DataValueField = "Code"
            dcbWeight.DataBind()
            If dcbWeight.Items.Count > 1 Then
                dcbWeight.Enabled = True
            Else
                dcbWeight.Enabled = False

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub showVolume()
        'dcbVolume.Items.Clear()
        'dcbVolume.Items.Add(New ListItem("select Volume"))
        'dcbVolume.AppendDataBoundItems = True
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "VOLUME" Select q.Code, q.Type

        Try
            dcbVolume.DataSource = qt.ToList
            dcbVolume.DataTextField = "Code"
            dcbVolume.DataValueField = "Code"
            dcbVolume.DataBind()
            If dcbVolume.Items.Count > 1 Then
                dcbVolume.Enabled = True
            Else
                dcbVolume.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub showQuantity3()
        'dcbSales.Items.Clear()
        'dcbSales.Items.Add(New ListItem("select Volume"))
        'dcbSales.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT" Select q.Code, q.Type

        Try

            ddlUnit4.DataSource = qt.ToList
            ddlUnit4.DataTextField = "Code"
            ddlUnit4.DataValueField = "Code"
            ddlUnit4.DataBind()
            If ddlUnit4.Items.Count > 1 Then
                ddlUnit4.Enabled = True
            Else
                ddlUnit4.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showSales()
        'dcbSales.Items.Clear()
        'dcbSales.Items.Add(New ListItem("select Volume"))
        'dcbSales.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "SITE" Select q.Code, q.Type

        Try

            dcbSite.DataSource = qt.ToList
            dcbSite.DataTextField = "Code"
            dcbSite.DataValueField = "Code"
            dcbSite.DataBind()
            If dcbSite.Items.Count > 1 Then
                dcbSite.Enabled = True
            Else
                dcbSite.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showSales1()
        'dcbSales.Items.Clear()
        'dcbSales.Items.Add(New ListItem("select Volume"))
        'dcbSales.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "SITE" Select q.Code, q.Type

        Try

            dcbSite1.DataSource = qt.ToList
            dcbSite1.DataTextField = "Code"
            dcbSite1.DataValueField = "Code"
            dcbSite1.DataBind()
            If dcbSite1.Items.Count > 1 Then
                dcbSite1.Enabled = True
            Else
                dcbSite1.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showSource()
        'cdbUnitQuantityDetail.Items.Clear()
        'cdbUnitQuantityDetail.Items.Add(New ListItem("select Unit"))
        'cdbUnitQuantityDetail.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "SOURCE-WH-FAC" Select q.Code, q.Type

        Try
            dcbSource.DataSource = qt.ToList
            dcbSource.DataTextField = "Code"
            dcbSource.DataValueField = "Code"
            dcbSource.DataBind()
            If dcbSource.Items.Count > 1 Then
                dcbSource.Enabled = True
            Else
                dcbSource.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showUnitPallet()
        'cdbUnitPallet.Items.Clear()
        'cdbUnitPallet.Items.Add(New ListItem("select Pallet"))
        'cdbUnitPallet.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY" Select q.Code, q.Type

        Try

            dcboCurrency.DataSource = qt.ToList
            dcboCurrency.DataTextField = "Code"
            dcboCurrency.DataValueField = "Code"
            dcboCurrency.DataBind()
            If dcboCurrency.Items.Count > 1 Then
                dcboCurrency.Enabled = True
            Else
                dcboCurrency.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showBox()
        'cdbBox.Items.Clear()
        'cdbBox.Items.Add(New ListItem("select Pallet"))
        'cdbBox.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT" Select q.Code, q.Type

        Try
            dcbPLT.DataSource = qt.ToList
            dcbPLT.DataTextField = "Code"
            dcbPLT.DataValueField = "Code"
            dcbPLT.DataBind()
            If dcbPLT.Items.Count > 1 Then
                dcbPLT.Enabled = True
            Else
                dcbPLT.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showWeightINV()
        'cdbUnitWeightInv.Items.Clear()
        'cdbUnitWeightInv.Items.Add(New ListItem("select Pallet"))
        'cdbUnitWeightInv.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "COMMODITY" Select q.Code, q.Type

        Try

            dolCommodity.DataSource = qt.ToList
            dolCommodity.DataTextField = "Code"
            dolCommodity.DataValueField = "Code"
            dolCommodity.DataBind()
            If dolCommodity.Items.Count > 1 Then
                dolCommodity.Enabled = True
            Else
                dolCommodity.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showBox1()
        'cdbBox1.Items.Clear()
        'cdbBox1.Items.Add(New ListItem("select Pallet"))
        'cdbBox1.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT" Select q.Code, q.Type

        Try
            cboReceivedUNIT.DataSource = qt.ToList
            cboReceivedUNIT.DataTextField = "Code"
            cboReceivedUNIT.DataValueField = "Code"
            cboReceivedUNIT.DataBind()
            If cboReceivedUNIT.Items.Count > 1 Then
                cboReceivedUNIT.Enabled = True
            Else
                cboReceivedUNIT.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showCommodity()
        'txtCommodity.Items.Clear()
        'txtCommodity.Items.Add(New ListItem("select Pallet"))
        'txtCommodity.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT" Select q.Code, q.Type

        Try
            cboWaitReceiveUNIT.DataSource = qt.ToList
            cboWaitReceiveUNIT.DataTextField = "Code"
            cboWaitReceiveUNIT.DataValueField = "Code"
            cboWaitReceiveUNIT.DataBind()
            If cboWaitReceiveUNIT.Items.Count > 1 Then
                cboWaitReceiveUNIT.Enabled = True
            Else
                cboWaitReceiveUNIT.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showJobSite()

        'cboJobSite.Items.Clear()
        'cboJobSite.Items.Add(New ListItem("select Pallet"))
        'cboJobSite.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT" Select q.Code, q.Type
        'Dim qt = From q In db.tblMasterCode2 Select q.CreateDate

        Try
            cboDamageUNIT.DataSource = qt.ToList
            cboDamageUNIT.DataTextField = "Code"
            cboDamageUNIT.DataValueField = "Code"
            cboDamageUNIT.DataBind()
            If cboDamageUNIT.Items.Count > 1 Then
                cboDamageUNIT.Enabled = True
            Else
                cboDamageUNIT.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showDiscrepencyUNIT()

        'cboJobSite.Items.Clear()
        'cboJobSite.Items.Add(New ListItem("select Pallet"))
        'cboJobSite.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT" Select q.Code, q.Type
        'Dim qt = From q In db.tblMasterCode2 Select q.CreateDate

        Try

            cboDiscrepencyUNIT.DataSource = qt.ToList
            cboDiscrepencyUNIT.DataTextField = "Code"
            cboDiscrepencyUNIT.DataValueField = "Code"
            cboDiscrepencyUNIT.DataBind()
            If cboDiscrepencyUNIT.Items.Count > 1 Then
                cboDiscrepencyUNIT.Enabled = True
            Else
                cboDiscrepencyUNIT.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddNew_ServerClick(sender As Object, e As EventArgs)
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmConfirmGoodsReceive"
        If classPermis.CheckSave(form, usename) = True Then
            confirmgoodreceive_.Disabled = False
            goodreceivedetail_.Disabled = True
            btnSeletJobNew.Visible = True
            btnSelectJobEdit.Visible = False
            btnSaveNew.Visible = True
            btnSaveEdit.Visible = False
            ClearDATA()
            ClearDATA1()
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ บันทึกในเมนูนี้' !!!');", True)
        End If
   
    End Sub

    Protected Sub btnEdit_ServerClick(sender As Object, e As EventArgs)
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmConfirmGoodsReceive"
        If classPermis.CheckEdit(form, usename) = True Then
            confirmgoodreceive_.Disabled = False
            goodreceivedetail_.Disabled = False
            btnSeletJobNew.Visible = False
            btnSelectJobEdit.Visible = True
            btnSaveNew.Visible = False
            btnSaveEdit.Visible = True
            ClearDATA()
            ClearDATA1()
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ แก้ไขในเมนูนี้' !!!');", True)
        End If
       
    End Sub

    Protected Sub btnSaveNew_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmConfirmGoodsReceive"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            Save_New()
            UpdateRead1()
            confirmgoodreceive_.Disabled = True
            goodreceivedetail_.Disabled = False
            btnSaveEdit.Visible = True
            btnSaveNew.Visible = False
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
       
    End Sub

    Protected Sub btnSaveEdit_ServerClick(sender As Object, e As EventArgs)
        Save_Modify()
        ReadDATA()
        ReadDATA1()
        ReadDATA()
        ReadDATA1()
        ReadDATAbefor()
        ReadDATAafter()
        confirmgoodreceive_.Disabled = True
        goodreceivedetail_.Disabled = True
        btnSaveEdit.Visible = False
        btnSaveNew.Visible = False
    End Sub

    Protected Sub btnSeletJobNew_ServerClick(sender As Object, e As EventArgs)
        selectPrepairGoodsReceive()
    End Sub

    Protected Sub Unnamed_ServerClick(sender As Object, e As EventArgs)
        selectOwnerCode()
    End Sub
    Private Sub selectOwnerCode()
        Dim cons_code As String
        Dim consignee As String = ""
        If String.IsNullOrEmpty(txtOwnerCode.Value.Trim) Then
            cons_code = ""
            consignee = "0"
        Else
            cons_code = txtOwnerCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = consignee
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvOwner.DataSource = cons.ToList
            dgvOwner.DataBind()
            ScriptManager.RegisterStartupScript(upOwner, upOwner.GetType(), "show", "$(function () { $('#" + plOwner.ClientID + "').modal('show'); });", True)
            upOwner.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Consignee Code นี้')", True)
            Exit Sub

        End If
    End Sub
    Private Sub selectBroker()
        Dim exp_code As String
        Dim shipper As String = ""
        If String.IsNullOrEmpty(txtBrokerCode.Value.Trim) Then
            exp_code = ""
            shipper = "0"
        Else
            exp_code = txtBrokerCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = exp_code And p.Warehouse = "0") Or p.Warehouse = shipper
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvBroker.DataSource = cons.ToList
            dgvBroker.DataBind()
            ScriptManager.RegisterStartupScript(upBroker, upBroker.GetType(), "show", "$(function () { $('#" + plBroker.ClientID + "').modal('show'); });", True)
            upBroker.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Exporter Code นี้')", True)
            Exit Sub
        End If
    End Sub
    Private Sub selectConsigneeCode()
        Dim code_code As String
        Dim consignee As String = ""
        Dim endCustomer As String = ""
        Dim shipper As String = ""
        If String.IsNullOrEmpty(txtConsigneeCode_.Value.Trim) Then
            code_code = ""
            consignee = "0"
            endCustomer = "0"
            shipper = "0"
        Else
            code_code = txtConsigneeCode_.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = code_code And p.Customer = "0") Or (p.Customer = consignee)
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvConsigneeCode.DataSource = cons.ToList
            dgvConsigneeCode.DataBind()
            ScriptManager.RegisterStartupScript(upConsigneeCode, upConsigneeCode.GetType(), "show", "$(function () { $('#" + plConsigneeCode.ClientID + "').modal('show'); });", True)
            upConsigneeCode.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Code นี้')", True)
            Exit Sub

        End If
    End Sub
    Private Sub selectExporterCode()
        Dim cum_code As String
        Dim consignee As String = ""
        If String.IsNullOrEmpty(txtExporterCode.Value.Trim) Then
            cum_code = ""
            consignee = "0"
        Else
            cum_code = txtExporterCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cum_code And p.Consignee = "0") Or p.Consignee = consignee
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvExporterCode.DataSource = cons.ToList
            dgvExporterCode.DataBind()
            ScriptManager.RegisterStartupScript(upExporterCode, upExporterCode.GetType(), "show", "$(function () { $('#" + plExporterCode.ClientID + "').modal('show'); });", True)
            upExporterCode.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
            Exit Sub

        End If
    End Sub
    Private Sub selectPickUpCode()
        Dim pick_code As String

        'If String.IsNullOrEmpty(txtPickUpCode.Value.Trim) Then
        '    pick_code = ""

        'Else
        '    pick_code = txtPickUpCode.Value.Trim
        'End If

        'Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        'Where p.PartyCode = pick_code Or p.Consignee = "0"
        'Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        'If cons.Count > 0 Then
        '    dgvPickUp.DataSource = cons.ToList
        '    dgvPickUp.DataBind()
        '    ScriptManager.RegisterStartupScript(upPickUpCode, upPickUpCode.GetType(), "show", "$(function () { $('#" + plPickUpCode.ClientID + "').modal('show'); });", True)
        '    upPickUpCode.Update()
        'Else
        '    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
        '    Exit Sub

        'End If
    End Sub


    Private Sub selectCustomerGroup()
        '    Dim gro_code As String

        '    If String.IsNullOrEmpty(txtCustomerCodeGroup.Value.Trim) Then
        '        gro_code = ""

        '    Else
        '        gro_code = txtCustomerCodeGroup.Value.Trim
        '    End If

        '    Dim cons = From p In db.tblParties
        '    Where p.PartyCode = gro_code Or p.Customer = "0"
        '    Select p.PartyCode, p.PartyFullName

        '    If cons.Count > 0 Then
        '        dgvCustomerGroup.DataSource = cons.ToList
        '        dgvCustomerGroup.DataBind()
        '        ScriptManager.RegisterStartupScript(upCustomerGroup, upCustomerGroup.GetType(), "show", "$(function () { $('#" + plCustomerGroup.ClientID + "').modal('show'); });", True)
        '        upCustomerGroup.Update()
        '    Else
        '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
        '        Exit Sub
        '    End If
    End Sub

    Protected Sub Unnamed_ServerClick1(sender As Object, e As EventArgs)
        selectBroker()
    End Sub

    Protected Sub Unnamed_ServerClick2(sender As Object, e As EventArgs)
        selectConsigneeCode()
    End Sub

    Protected Sub Unnamed_ServerClick3(sender As Object, e As EventArgs)
        selectExporterCode()
    End Sub

    Protected Sub dgvOwner_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyAdd As Label = CType(e.Item.FindControl("lblPartyAdd"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString
            End If
            If Not IsNothing(lblPartyAdd) Then
                lblPartyAdd.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString
            End If
            If Not IsNothing(lblPartyFullName) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString
            End If
            If Not IsNothing(lblAddress1) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString
            End If
            If Not IsNothing(lblAddress2) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString
            End If
        End If
    End Sub


    Protected Sub dgvBroker_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyAdd As Label = CType(e.Item.FindControl("lblPartyAdd"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString
            End If
            If Not IsNothing(lblPartyAdd) Then
                lblPartyAdd.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString
            End If
            If Not IsNothing(lblPartyFullName) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString
            End If
            If Not IsNothing(lblAddress1) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString
            End If
            If Not IsNothing(lblAddress2) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString
            End If
        End If
    End Sub

    Protected Sub dgvConsigneeCode_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyAdd As Label = CType(e.Item.FindControl("lblPartyAdd"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString
            End If
            If Not IsNothing(lblPartyAdd) Then
                lblPartyAdd.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString
            End If
            If Not IsNothing(lblPartyFullName) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString
            End If
            If Not IsNothing(lblAddress1) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString
            End If
            If Not IsNothing(lblAddress2) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString
            End If
        End If
    End Sub

    Protected Sub dgvExporterCode_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyAdd As Label = CType(e.Item.FindControl("lblPartyAdd"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString
            End If
            If Not IsNothing(lblPartyAdd) Then
                lblPartyAdd.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString
            End If
            If Not IsNothing(lblPartyFullName) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString
            End If
            If Not IsNothing(lblAddress1) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString
            End If
            If Not IsNothing(lblAddress2) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString
            End If
        End If
    End Sub

    Protected Sub lnkPartyCode_Owner_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtOwnerCode.Value = ""
        Else
            txtOwnerCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtOwnerEng.Value = ""
        Else
            txtOwnerEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtOwnerStreet_Number.Value = ""
        Else
            txtOwnerStreet_Number.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtOwnerDistrict.Value = ""
        Else
            txtOwnerDistrict.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtOwnerSubProvince.Value = ""
        Else
            txtOwnerSubProvince.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtOwnerProvince.Value = ""
        Else
            txtOwnerProvince.Value = eano.pa.Address4
        End If

    End Sub

    Protected Sub lnkPartyCode_Broker_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtBrokerCode.Value = ""
        Else
            txtBrokerCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtBrokerNameEng.Value = ""
        Else
            txtBrokerNameEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtBrokerStreet.Value = ""
        Else
            txtBrokerStreet.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtBrokerDistrict.Value = ""
        Else
            txtBrokerDistrict.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtBrokerSubProvince.Value = ""
        Else
            txtBrokerSubProvince.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtBrokerProvince.Value = ""
        Else
            txtBrokerProvince.Value = eano.pa.Address4
        End If
    End Sub

    Protected Sub lnkPartyCode_Con_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtConsigneeCode_.Value = ""
        Else
            txtConsigneeCode_.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtConsignneeEng.Value = ""
        Else
            txtConsignneeEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtConsignneeStreet_Number.Value = ""
        Else
            txtConsignneeStreet_Number.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtConsignneeDistrict.Value = ""
        Else
            txtConsignneeDistrict.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtConsignneeSubProvince.Value = ""
        Else
            txtConsignneeSubProvince.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtConsignneeProvince.Value = ""
        Else
            txtConsignneeProvince.Value = eano.pa.Address4
        End If
    End Sub

    Protected Sub lnkPartyCode_Ex_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtExporterCode.Value = ""
        Else
            txtExporterCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtExportEng.Value = ""
        Else
            txtExportEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtStreet_Number.Value = ""
        Else
            txtStreet_Number.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtDistrict.Value = ""
        Else
            txtDistrict.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtSubProvince.Value = ""
        Else
            txtSubProvince.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtProvince.Value = ""
        Else
            txtProvince.Value = eano.pa.Address4
        End If

    End Sub

    Private Sub selectPrepairGoodsReceive()
        Dim lotDate_ As Integer
        Dim consignee As String = ""
        Dim endCustomer As String = ""
        Dim shipper As String = ""
        If String.IsNullOrEmpty(txtLotNo_.Value.Trim) Then
            lotDate_ = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        End If
        Dim go = (From wh In db.tblWHPrepairGoodsReceives
                  Where (wh.LOTNo.Contains(txtLotNo_.Value.Trim) And wh.UsedStatus = 0 And Not wh.LOTNo.Contains("WIP")) _
                  Or wh.LOTDate.Year = lotDate_ And wh.UsedStatus = 0
                  Select wh.LOTNo, LOTDate = wh.LOTDate.Year, wh.CustREFNo, wh.OwnerCode).Take(100)

        If go.Count > 0 Then
            dgvPrepire.DataSource = go.ToList
            dgvPrepire.DataBind()
            ScriptManager.RegisterStartupScript(upPrepire, upPrepire.GetType(), "show", "$(function () { $('#" + plPrepire.ClientID + "').modal('show'); });", True)
            upPrepire.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
        End If

    End Sub

    Protected Sub btnSelectJobEdit_ServerClick(sender As Object, e As EventArgs)
        selectPrepairGoodsReceiveEdit()
        ReadDATA()
        ReadDATA1()
        ReadDATAbefor()
        ReadDATAafter()
    End Sub

    Protected Sub dgvPrepire_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblLOTDate As Label = CType(e.Item.FindControl("lblLOTDate"), Label)
            Dim lblCustREFNoe As Label = CType(e.Item.FindControl("lblCustREFNo"), Label)
            Dim lblOwnerCode As Label = CType(e.Item.FindControl("lblOwnerCode"), Label)

            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblLOTDate) Then
                lblLOTDate.Text = DataBinder.Eval(e.Item.DataItem, "LOTDate").ToString
            End If
            If Not IsNothing(lblCustREFNoe) Then
                lblCustREFNoe.Text = DataBinder.Eval(e.Item.DataItem, "CustREFNo").ToString
            End If
            If Not IsNothing(lblOwnerCode) Then
                lblOwnerCode.Text = DataBinder.Eval(e.Item.DataItem, "OwnerCode").ToString
            End If
          
        End If
    End Sub

    Protected Sub lnkPartyCode_LOTNo_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblLOTNo As String = TryCast(item.FindControl("lblLOTNo"), Label).Text.Trim
        'Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Try
            Dim wh = (From pg In db.tblWHPrepairGoodsReceives Where pg.LOTNo = lblLOTNo
              Select pg).FirstOrDefault

            If String.IsNullOrEmpty(txtLotNo_.Value.Trim) Then
                txtLotNo_.Value = ""
            Else
                txtLotNo_.Value = wh.LOTNo
            End If
            dtpInvoiceDate.Text = Convert.ToDateTime(wh.LOTDate).ToString("dd/MM/yyyy")
            txtCustomerLot.Value = wh.CustREFNo
            txtOwnerCode.Value = wh.OwnerCode
            txtOwnerEng.Value = wh.OwnerNameENG
            txtOwnerStreet_Number.Value = wh.OwnerStreet_Number
            txtOwnerDistrict.Value = wh.OwnerDistrict
            txtOwnerSubProvince.Value = wh.OwnerSubProvince
            txtOwnerProvince.Value = wh.OwnerProvince
            txtConsigneeCode_.Value = wh.CustomerCode
            txtConsignneeEng.Value = wh.CustomerNameENG
            txtConsignneeStreet_Number.Value = wh.CustomerStreet_Number
            txtConsignneeDistrict.Value = wh.CustomerDistrict
            txtConsignneeSubProvince.Value = wh.CustomerSubProvince
            txtConsignneeProvince.Value = wh.CustomerProvince
            txtBrokerCode.Value = wh.BrokerCode
            txtBrokerNameEng.Value = wh.BrokerNameENG
            txtBrokerStreet.Value = wh.BrokerStreet_Number
            txtBrokerDistrict.Value = wh.BrokerDistrict
            txtBrokerSubProvince.Value = wh.BrokerSubprovince
            txtBrokerProvince.Value = wh.BrokerProvince
            txtExporterCode.Value = wh.ENDUserCode
            txtExportEng.Value = wh.ENDNameENG
            txtStreet_Number.Value = wh.ENDStreet_Number
            txtDistrict.Value = wh.ENDDistrict
            txtSubProvince.Value = wh.ENDSubprovince
            txtProvince.Value = wh.ENDProvince
            dolCommodity.Text = wh.Commodity
            txtQuantityofPart.Value = String.Format("{0:0.00}", wh.QuantityOfPart)
            dcbQuantity1.Text = wh.QuantityUnit
            txtQuantityPackage.Value = String.Format("{0:0.00}", wh.QuantityPackage)
            dcbQuantity2.Text = wh.PackageUNIT
            txtPLT.Value = String.Format("{0:0.00}", wh.QuantityPLT)
            dcbPLT.Text = wh.QuantityPLTUnit
            txtWeight.Value = String.Format("{0:0.00}", wh.Weigth)
            dcbWeight.Text = wh.WeigthUnit
            txtVolume.Value = String.Format("{0:0.00}", wh.Volume)
            dcbVolume.Text = wh.VolumeUnit
            txtRamark.Value = wh.Remark
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('" & ex.Message & "')", True)
            Exit Sub
        End Try
      


    End Sub

    Private Sub selectPrepairGoodsReceiveEdit()

        Dim lotDate_ As Integer
        Dim consignee As String = ""
        Dim endCustomer As String = ""
        Dim shipper As String = ""
        If String.IsNullOrEmpty(txtLotNo_.Value.Trim) Then
            lotDate_ = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        End If
        Dim go = (From wh In db.tblWHConfirmGoodsReceives
                  Where wh.LOTNo.Contains(txtLotNo_.Value.Trim) Or wh.LOTDate.Year = lotDate_
                  Order By wh.LOTNo Ascending
                  Select wh.LOTNo, wh.LOTDate, wh.CustREFNo, wh.OwnerCode).Take(100)
        If go.Count > 0 Then
            dgvConfirmGood.DataSource = go.ToList
            dgvConfirmGood.DataBind()
            ScriptManager.RegisterStartupScript(upConfirmGood, upConfirmGood.GetType(), "show", "$(function () { $('#" + plConfirmGood.ClientID + "').modal('show'); });", True)
            upConfirmGood.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
        End If

    End Sub

    Private Sub ClearDATA()
        txtLotNo_.Value = ""
        txtOwnerCode.Value = ""
        txtOwnerEng.Value = ""
        txtOwnerStreet_Number.Value = ""
        txtOwnerDistrict.Value = ""
        txtOwnerSubProvince.Value = ""
        txtOwnerProvince.Value = ""
        txtConsigneeCode_.Value = ""
        txtConsignneeEng.Value = ""
        txtConsignneeStreet_Number.Value = ""
        txtConsignneeDistrict.Value = ""
        txtConsignneeSubProvince.Value = ""
        txtConsignneeProvince.Value = ""     
        txtRamark.Value = ""
        txtBrokerCode.Value = ""
        txtBrokerNameEng.Value = ""
        txtBrokerStreet.Value = ""
        txtBrokerDistrict.Value = ""
        txtBrokerSubProvince.Value = ""
        txtBrokerProvince.Value = ""
        txtExporterCode.Value = ""
        txtExportEng.Value = ""
        txtStreet_Number.Value = ""
        txtDistrict.Value = ""
        txtSubProvince.Value = ""
        txtProvince.Value = ""
        txtQuantityofPart.Value = "0.0"
        txtQuantityPackage.Value = "0.0"
        txtWeight.Value = "0.0"
        txtVolume.Value = "0.0"
        txtPLT.Value = "0.0"
        txtQtyReceived.Value = "0.0"
        txtQtyWaitReceive.Value = "0.0"
        txtQtyDamage.Value = "0.0"
        txtQtyDiscrepancy.Value = "0.0"
    End Sub

    Private Sub ClearDATA1()
       
        txtWeightDetail.Value = ""
        txtCustomer.Value = ""
        txtItemNo.Value = ""
        txtProductCode.Value = ""
        txtProductDesc1.Value = ""
        txtProductDesc2.Value = ""
        txtProductDesc3.Value = ""
        txtOrder.Value = ""
        txtReceive.Value = txtLotNo_.Value
        txtQuantity.Value = "0"
        txtCusLOTNo.Value = ""
        txtExchangeRate.Value = "0"
        txtPriceForeigh_.Text = "0"
        txtPriceForeighAmount.Value = "0"
        txtPriceBath.Value = "0"
        txtPriceBathAmount.Value = "0"
        'txtProductUni = ""
        txtProductWidth_.Text = "0"
        txtProductHeight_.Text = "0"
        txtProductLeng_.Text = "0"
        txtProductVolume.Value = "0"
        txtWeightDetail.Value = "0"
        txtSupplier.Value = ""
        txtBuyer.Value = ""
        txtExporter.Value = ""
        txtDestination.Value = ""
        txtConsignee.Value = ""
        txtShippingMark.Value = ""
        Txtpallet.Value = "0"
        LblInValume.Value = "0"
        LblInpallet.Value = "0"
        LblUseValume.Value = "0"
        LblUsePallet.Value = "0"
    End Sub

    Protected Sub lnk_Confirm_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblLOTNo As String = TryCast(item.FindControl("lblLOTNo"), Label).Text.Trim
        Try
            Dim comfirm = (From con In db.tblWHConfirmGoodsReceives
                       Where con.LOTNo = lblLOTNo
                       Select con).FirstOrDefault

            txtLotNo_.Value = comfirm.LOTNo
            dtpInvoiceDate.Text = Convert.ToDateTime(comfirm.LOTDate).ToString("dd/MM/yyyy")
            txtCustomerLot.Value = comfirm.CustREFNo
            txtOwnerCode.Value = comfirm.OwnerCode
            txtOwnerEng.Value = comfirm.OwnerNameENG
            txtOwnerStreet_Number.Value = comfirm.OwnerStreet_Number
            txtOwnerDistrict.Value = comfirm.OwnerDistrict
            txtOwnerSubProvince.Value = comfirm.OwnerSubProvince
            txtOwnerProvince.Value = comfirm.OwnerProvince
            txtConsigneeCode_.Value = comfirm.CustomerCode
            txtConsignneeEng.Value = comfirm.CustomerNameENG
            txtConsignneeStreet_Number.Value = comfirm.CustomerStreet_Number
            txtConsignneeDistrict.Value = comfirm.CustomerDistrict
            txtConsignneeSubProvince.Value = comfirm.CustomerSubProvince
            txtConsignneeProvince.Value = comfirm.CustomerProvince
            txtBrokerCode.Value = comfirm.BrokerCode
            txtBrokerNameEng.Value = comfirm.BrokerNameENG
            txtBrokerStreet.Value = comfirm.BrokerStreet_Number
            txtBrokerDistrict.Value = comfirm.BrokerDistrict
            txtBrokerSubProvince.Value = comfirm.BrokerSubprovince
            txtBrokerProvince.Value = comfirm.BrokerProvince
            txtExporterCode.Value = comfirm.ENDUserCode
            txtExportEng.Value = comfirm.ENDNameENG
            txtStreet_Number.Value = comfirm.ENDStreet_Number
            txtDistrict.Value = comfirm.ENDDistrict
            txtSubProvince.Value = comfirm.ENDSubprovince
            txtProvince.Value = comfirm.ENDProvince
            If String.IsNullOrEmpty(comfirm.Commodity) Then

            Else
                dolCommodity.Text = comfirm.Commodity
            End If

            txtQuantityofPart.Value = String.Format("{0:0.00}", comfirm.QuantityOfPart)

            If String.IsNullOrEmpty(comfirm.QuantityUnit) Then

            Else
                dcbQuantity1.Text = comfirm.QuantityUnit
            End If
            txtQuantityPackage.Value = String.Format("{0:0.00}", comfirm.QuantityPackage)

            If String.IsNullOrEmpty(comfirm.PackageUNIT) Then

            Else
                dcbQuantity2.Text = comfirm.PackageUNIT
            End If
            txtPLT.Value = String.Format("{0:0.00}", comfirm.QuantityPLT)

            If String.IsNullOrEmpty(comfirm.QuantityPLTUnit) Then

            Else
                dcbPLT.Text = comfirm.QuantityPLTUnit
            End If
            txtWeight.Value = String.Format("{0:0.00}", comfirm.Weigth)

            If String.IsNullOrEmpty(comfirm.WeigthUnit) Then

            Else
                dcbWeight.Text = comfirm.WeigthUnit
            End If
            txtVolume.Value = String.Format("{0:0.00}", comfirm.Volume)
            If String.IsNullOrEmpty(comfirm.VolumeUnit) Then

            Else
                dcbVolume.Text = comfirm.VolumeUnit
            End If
            txtRamark.Value = comfirm.Remark
            txtQtyReceived.Value = String.Format("{0:0.00}", comfirm.QuantityReceived)
            If String.IsNullOrEmpty(comfirm.ReceivedUNIT) Then

            Else
                cboReceivedUNIT.Text = comfirm.ReceivedUNIT
            End If
            txtQtyWaitReceive.Value = String.Format("{0:0.00}", comfirm.QuantityWaitReceive)

            If String.IsNullOrEmpty(comfirm.WaitUNIT) Then

            Else
                cboWaitReceiveUNIT.Text = comfirm.WaitUNIT
            End If
            txtQtyDamage.Value = String.Format("{0:0.00}", comfirm.QuantityDamage)

            If String.IsNullOrEmpty(comfirm.DamageUNIT) Then

            Else
                cboDamageUNIT.Text = comfirm.DamageUNIT
            End If
            txtQtyDiscrepancy.Value = String.Format("{0:0.00}", comfirm.QuantityDiscrepancy)

            If String.IsNullOrEmpty(comfirm.DiscrepancyUNIT) Then
            Else
                cboDiscrepencyUNIT.Text = comfirm.DiscrepancyUNIT
            End If


        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('" & ex.Message & "')", True)
            Exit Sub
        End Try

    End Sub

    Protected Sub dgvConfirmGood_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblLOTDate As Label = CType(e.Item.FindControl("lblLOTDate"), Label)
            Dim lblCustREFNoe As Label = CType(e.Item.FindControl("lblCustREFNo"), Label)
            Dim lblOwnerCode As Label = CType(e.Item.FindControl("lblOwnerCode"), Label)

            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblLOTDate) Then
                lblLOTDate.Text = DataBinder.Eval(e.Item.DataItem, "LOTDate").ToString
            End If
            If Not IsNothing(lblCustREFNoe) Then
                lblCustREFNoe.Text = DataBinder.Eval(e.Item.DataItem, "CustREFNo").ToString
            End If
            If Not IsNothing(lblOwnerCode) Then
                lblOwnerCode.Text = DataBinder.Eval(e.Item.DataItem, "OwnerCode").ToString
            End If

        End If
    End Sub

    Private Sub Save_New()
        Dim print As String = "0"
        If String.IsNullOrEmpty(txtLotNo_.Value.Trim) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ PrepairLOT ก่อน !!!')", True)
            txtLotNo_.Focus()
            Exit Sub

        Else
            Select Case MsgBox("คุณต้องการเพิ่มรายการ PrepairLOT ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
                Case MsgBoxResult.Yes
                    Try
                        db.Database.Connection.Open()

                        db.tblWHConfirmGoodsReceives.Add(New tblWHConfirmGoodsReceive With { _
                          .LOTNo = txtLotNo_.Value.Trim, _
                          .LOTDate = DateTime.ParseExact(dtpInvoiceDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                          .CustREFNo = txtCustomerLot.Value.Trim, _
                          .OwnerCode = txtOwnerCode.Value.Trim, _
                          .OwnerNameENG = txtOwnerEng.Value.Trim, _
                          .OwnerStreet_Number = txtOwnerStreet_Number.Value.Trim, _
                          .OwnerDistrict = txtOwnerDistrict.Value.Trim, _
                          .OwnerSubProvince = txtOwnerSubProvince.Value.Trim, _
                          .OwnerProvince = txtOwnerProvince.Value.Trim, _
                          .CustomerCode = txtConsigneeCode_.Value.Trim, _
                          .CustomerNameENG = txtConsignneeEng.Value.Trim, _
                          .CustomerStreet_Number = txtConsignneeStreet_Number.Value.Trim, _
                          .CustomerDistrict = txtConsignneeDistrict.Value.Trim, _
                          .CustomerSubProvince = txtConsignneeSubProvince.Value.Trim, _
                          .CustomerProvince = txtConsignneeProvince.Value.Trim, _
                          .BrokerCode = txtBrokerCode.Value.Trim, _
                          .BrokerNameENG = txtBrokerNameEng.Value.Trim, _
                          .BrokerStreet_Number = txtBrokerStreet.Value.Trim, _
                          .BrokerDistrict = txtBrokerDistrict.Value.Trim, _
                          .BrokerSubprovince = txtBrokerSubProvince.Value.Trim, _
                          .BrokerProvince = txtBrokerProvince.Value.Trim, _
                          .ENDUserCode = txtExporterCode.Value.Trim, _
                          .ENDNameENG = txtExportEng.Value.Trim, _
                          .ENDStreet_Number = txtStreet_Number.Value.Trim, _
                          .ENDDistrict = txtDistrict.Value.Trim, _
                          .ENDSubprovince = txtSubProvince.Value.Trim, _
                          .ENDProvince = txtProvince.Value.Trim, _
                          .Commodity = dolCommodity.Text.Trim, _
                          .QuantityOfPart = CType(CDbl(txtQuantityofPart.Value).ToString("#,##0.000"), Double?), _
                          .QuantityUnit = dcbQuantity1.Text.Trim, _
                          .QuantityPackage = CType(CDbl(txtQuantityPackage.Value).ToString("#,##0.000"), Double?), _
                          .PackageUNIT = dcbQuantity2.Text.Trim, _
                          .QuantityPLT = CType(CDbl(txtPLT.Value).ToString("#,##0.000"), Double?), _
                          .QuantityPLTUnit = dcbPLT.Text.Trim, _
                          .Weigth = CType(CDbl(txtWeight.Value).ToString("#,##0.000"), Double?), _
                          .WeigthUnit = dcbWeight.Text.Trim, _
                          .Volume = CType(CDbl(txtVolume.Value).ToString("#,##0.000"), Double?), _
                          .VolumeUnit = dcbVolume.Text.Trim, _
                          .UserBy = CStr(Session("UserName")), _
                          .LastUpdate = Now, _
                          .PrintCount = print, _
                          .Remark = txtRamark.Value, _
                          .QuantityReceived = CType(CDbl(txtQtyReceived.Value).ToString("#,##0.000"), Double?), _
                          .ReceivedUNIT = cboReceivedUNIT.Text.Trim, _
                          .QuantityWaitReceive = CType(CDbl(txtQtyWaitReceive.Value).ToString("#,##0.000"), Double?), _
                          .WaitUNIT = cboWaitReceiveUNIT.Text.Trim, _
                          .QuantityDamage = CType(CDbl(txtQtyDamage.Value).ToString("#,##0.000"), Double?), _
                          .DamageUNIT = cboDamageUNIT.Text.Trim, _
                          .QuantityDiscrepancy = CType(CDbl(txtQtyDiscrepancy.Value).ToString("#,##0.000"), Double?), _
                          .DiscrepancyUNIT = cboDiscrepencyUNIT.Text
                     })
                        db.SaveChanges()
                    Catch ex As Exception
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด !!!')", True)
                    End Try
            End Select
        End If


    End Sub

    Private Sub UpdateRead1()
        If txtLotNo_.Value.Trim() = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ PrepairLOT ก่อน !!!')", True)
            txtLotNo_.Focus()
            Exit Sub

        Else
            Dim wh As tblWHPrepairGoodsReceive = (From w In db.tblWHPrepairGoodsReceives Where w.LOTNo = txtLotNo_.Value.Trim).FirstOrDefault

            If wh IsNot Nothing Then
                Try
                    wh.LOTNo = txtLotNo_.Value.Trim
                    wh.UsedStatus = 1

                    db.SaveChanges()
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('" & ex.Message & "')", True)
                End Try
            End If
        End If

    End Sub

    Private Sub ReadDATA()
        Dim wh = (From h In db.tblWHPrepairGoodsReceiveDetails Where h.LOTNo = txtLotNo_.Value.Trim And h.Status <> 1
            Order By h.ItemNo Ascending
            Select h.LOTNo, h.WHSite, h.ENDCustomer, h.CustomerLOTNo, h.ItemNo, h.ProductCode, h.CustomerPN, h.Status).ToList

        If wh.Count > 0 Then
            dgvItemDetail.DataSource = wh
            dgvItemDetail.DataBind()
        End If
    End Sub

    Protected Sub dgvItemDetail_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblSite As Label = CType(e.Item.FindControl("lblSite"), Label)
            Dim lblEND As Label = CType(e.Item.FindControl("lblEND"), Label)
            Dim lblCus As Label = CType(e.Item.FindControl("lblCus"), Label)
            Dim lblItem As Label = CType(e.Item.FindControl("lblItem"), Label)
            Dim lblPc As Label = CType(e.Item.FindControl("lblPc"), Label)
            Dim lblPn As Label = CType(e.Item.FindControl("lblPn"), Label)
            Dim lblStatus As Label = CType(e.Item.FindControl("lblStatus"), Label)
            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblSite) Then
                lblSite.Text = DataBinder.Eval(e.Item.DataItem, "WHSite").ToString
            End If
            If Not IsNothing(lblEND) Then
                lblEND.Text = DataBinder.Eval(e.Item.DataItem, "ENDCustomer").ToString
            End If
            If Not IsNothing(lblCus) Then
                lblCus.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLOTNo").ToString
            End If
            If Not IsNothing(lblItem) Then
                lblItem.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString
            End If

            If Not IsNothing(lblPc) Then
                lblPc.Text = DataBinder.Eval(e.Item.DataItem, "ProductCode").ToString
            End If

            If Not IsNothing(lblPn) Then
                lblPn.Text = DataBinder.Eval(e.Item.DataItem, "CustomerPN").ToString
            End If
            If Not IsNothing(lblStatus) Then
                lblStatus.Text = DataBinder.Eval(e.Item.DataItem, "Status").ToString

                If lblStatus.Text = "2" Then
                    rbShort.Checked = True
                    rbOver.Checked = False
                ElseIf lblStatus.Text = "3" Then
                    rbShort.Checked = False
                    rbOver.Checked = True
                Else
                    rbOver.Checked = False
                    rbShort.Checked = False

                End If
            End If
        End If
    End Sub
    Private Sub ReadDATA1()
        Dim wh = (From h In db.tblWHConfirmGoodsReceiveDetails Where h.LOTNo = txtLotNo_.Value.Trim
            Order By h.ItemNo Ascending
            Select h.LOTNo, h.WHSite, h.ENDCustomer, h.CustomerLOTNo, h.ItemNo, h.ProductCode, h.CustomerPN).ToList

        If wh.Count > 0 Then
            dgvConfirmDetail.DataSource = wh
            dgvConfirmDetail.DataBind()
        End If
    End Sub

    Protected Sub dgvConfirmDetail_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblSite As Label = CType(e.Item.FindControl("lblSite"), Label)
            Dim lblEND As Label = CType(e.Item.FindControl("lblEND"), Label)
            Dim lblCus As Label = CType(e.Item.FindControl("lblCus"), Label)
            Dim lblItem As Label = CType(e.Item.FindControl("lblItem"), Label)
            Dim lblPc As Label = CType(e.Item.FindControl("lblPc"), Label)
            Dim lblPn As Label = CType(e.Item.FindControl("lblPn"), Label)

            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblSite) Then
                lblSite.Text = DataBinder.Eval(e.Item.DataItem, "WHSite").ToString
            End If
            If Not IsNothing(lblEND) Then
                lblEND.Text = DataBinder.Eval(e.Item.DataItem, "ENDCustomer").ToString
            End If
            If Not IsNothing(lblCus) Then
                lblCus.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLOTNo").ToString
            End If
            If Not IsNothing(lblItem) Then
                lblItem.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString
            End If

            If Not IsNothing(lblPc) Then
                lblPc.Text = DataBinder.Eval(e.Item.DataItem, "ProductCode").ToString
            End If

            If Not IsNothing(lblPn) Then
                lblPn.Text = DataBinder.Eval(e.Item.DataItem, "CustomerPN").ToString
            End If

        End If
    End Sub

    Private Sub Save_Modify()
        Dim print As String = "0"
        If String.IsNullOrEmpty(txtLotNo_.Value.Trim) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ PrepairLOT ก่อน !!!')", True)
            txtLotNo_.Focus()
            Exit Sub

        Else
            Select Case MsgBox("คุณต้องการแก้ไขข้อมูล PrepairLOT ใช่หรือไม่?", MsgBoxStyle.YesNo, "คำยืนยัน")
                Case MsgBoxResult.Yes
                    Try
                        db.Database.Connection.Open()
                        Dim wh As tblWHConfirmGoodsReceive = (From w In db.tblWHConfirmGoodsReceives Where w.LOTNo = txtLotNo_.Value.Trim).First

                        If wh IsNot Nothing Then
                            wh.LOTNo = txtLotNo_.Value.Trim
                            wh.LOTDate = DateTime.ParseExact(dtpInvoiceDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
                            wh.CustREFNo = txtCustomerLot.Value.Trim
                            wh.OwnerCode = txtOwnerCode.Value.Trim
                            wh.OwnerNameENG = txtOwnerEng.Value.Trim
                            wh.OwnerStreet_Number = txtOwnerStreet_Number.Value.Trim
                            wh.OwnerDistrict = txtOwnerDistrict.Value.Trim
                            wh.OwnerSubProvince = txtOwnerSubProvince.Value.Trim
                            wh.OwnerProvince = txtOwnerProvince.Value.Trim
                            wh.CustomerCode = txtConsigneeCode_.Value.Trim
                            wh.CustomerNameENG = txtConsignneeEng.Value.Trim
                            wh.CustomerStreet_Number = txtConsignneeStreet_Number.Value.Trim
                            wh.CustomerDistrict = txtConsignneeDistrict.Value.Trim
                            wh.CustomerSubProvince = txtConsignneeSubProvince.Value.Trim
                            wh.CustomerProvince = txtConsignneeProvince.Value.Trim
                            wh.BrokerCode = txtBrokerCode.Value.Trim
                            wh.BrokerNameENG = txtBrokerNameEng.Value.Trim
                            wh.BrokerStreet_Number = txtBrokerStreet.Value.Trim
                            wh.BrokerDistrict = txtBrokerDistrict.Value.Trim
                            wh.BrokerSubprovince = txtBrokerSubProvince.Value.Trim
                            wh.BrokerProvince = txtBrokerProvince.Value.Trim
                            wh.ENDUserCode = txtExporterCode.Value.Trim
                            wh.ENDNameENG = txtExportEng.Value.Trim
                            wh.ENDStreet_Number = txtStreet_Number.Value.Trim
                            wh.ENDDistrict = txtDistrict.Value.Trim
                            wh.ENDSubprovince = txtSubProvince.Value.Trim
                            wh.ENDProvince = txtProvince.Value.Trim
                            wh.Commodity = dolCommodity.Text.Trim
                            wh.QuantityOfPart = CType(CDbl(txtQuantityofPart.Value).ToString("#,##0.000"), Double?)
                            wh.QuantityUnit = dcbQuantity1.Text.Trim
                            wh.QuantityPackage = CType(CDbl(txtQuantityPackage.Value).ToString("#,##0.000"), Double?)
                            wh.PackageUNIT = dcbQuantity2.Text.Trim
                            wh.QuantityPLT = CType(CDbl(txtPLT.Value).ToString("#,##0.000"), Double?)
                            wh.QuantityPLTUnit = dcbPLT.Text.Trim
                            wh.Weigth = CType(CDbl(txtWeight.Value).ToString("#,##0.000"), Double?)
                            wh.WeigthUnit = dcbWeight.Text.Trim
                            wh.Volume = CType(CDbl(txtVolume.Value).ToString("#,##0.000"), Double?)
                            wh.VolumeUnit = dcbVolume.Text.Trim
                            wh.UserBy = CStr(Session("UserName"))
                            wh.LastUpdate = Now
                            wh.Remark = txtRamark.Value
                            wh.QuantityReceived = CType(CDbl(txtQtyReceived.Value).ToString("#,##0.000"), Double?)
                            wh.ReceivedUNIT = cboReceivedUNIT.Text.Trim
                            wh.QuantityWaitReceive = CType(CDbl(txtQtyWaitReceive.Value).ToString("#,##0.000"), Double?)
                            wh.WaitUNIT = cboWaitReceiveUNIT.Text.Trim
                            wh.QuantityDamage = CType(CDbl(txtQtyDamage.Value).ToString("#,##0.000"), Double?)
                            wh.DamageUNIT = cboDamageUNIT.Text.Trim
                            wh.QuantityDiscrepancy = CType(CDbl(txtQtyDiscrepancy.Value).ToString("#,##0.000"), Double?)
                            wh.DiscrepancyUNIT = cboDiscrepencyUNIT.Text
                            db.SaveChanges()
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไข สำเสร็จ !');", True)
                            Exit Sub
                        End If
                    Catch ex As Exception
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect", ex.Message, True)
                    End Try
            End Select
        End If
    End Sub

    Protected Sub chkLotNo_CheckedChanged(sender As Object, e As EventArgs)
        Dim chkName As CheckBox
        Dim lblLOTNo As String
        Dim lblItem As Integer
        Dim i As Integer
        Dim j As Integer
        Dim name As ArrayList
        name = New ArrayList
        For i = 0 To dgvItemDetail.Items.Count - 1
            chkName = CType(dgvItemDetail.Items(i).FindControl("chkLotNo"), CheckBox)
            lblLOTNo = CType(dgvItemDetail.Items(i).FindControl("lblLOTNo"), Label).Text.Trim
            lblItem = CInt(CType(dgvItemDetail.Items(i).FindControl("lblItem"), Label).Text.Trim)
            'lblName = CType(rptCustomers.Items(i).FindControl("lblName"), Label).Text.Trim
            'lblBranch = CType(rptCustomers.Items(i).FindControl("lblBrnch"), Label).Text.Trim
            If chkName.Checked = True Then
                Dim wh = (From h In db.tblWHPrepairGoodsReceiveDetails Where h.LOTNo = lblLOTNo And h.ItemNo = lblItem
                Select h).FirstOrDefault
                dcbSite.Text = wh.WHSite
                txtCustomer.Value = wh.ENDCustomer
                dcbSource.Text = wh.WHSource
                txtCusLOTNo.Value = wh.CustomerLOTNo
                txtItemNo.Value = String.Format("{0:0.00}", wh.ItemNo)
                txtProductCode.Value = wh.ProductCode
                txtProductDesc2.Value = wh.CustomerPN
                txtProductDesc3.Value = wh.OwnerPN
                txtProductDesc1.Value = wh.ProductDesc
                ddlProductUnit.Text = wh.Measurement
                txtProductWidth_.Text = String.Format("{0:0.00}", wh.ProductWidth)
                txtProductHeight_.Text = String.Format("{0:0.00}", wh.ProductLength)
                txtProductLeng_.Text = String.Format("{0:0.00}", wh.ProductHeight)
                txtProductVolume.Value = String.Format("{0:0.00}", wh.ProductVolume)
                txtOrder.Value = wh.OrderNo
                txtReceive.Value = wh.ReceiveNo
                dcbType.Text = wh.Type
                txtManufacturingDate.Text = Convert.ToDateTime(wh.ManufacturingDate).ToString("dd/MM/yyyy")
                If String.IsNullOrEmpty(txtManufacturingDate.Text) Then
                    CbNotDate.Checked = True
                Else
                    CbNotDate.Checked = False
                End If
                txtExpiredDate.Text = Convert.ToDateTime(wh.ExpiredDate).ToString("dd/MM/yyyy")
                txtExpectedDate.Text = Convert.ToDateTime(wh.ReceiveDate).ToString("dd/MM/yyyy")
                txtQuantity.Value = String.Format("{0:0.00}", wh.Quantity)
                ddlUnit4.Text = wh.QuantityUnit
                txtWeightDetail.Value = String.Format("{0:0.00}", wh.Weigth)
                dcboUnitWeightDetail.Text = wh.WeigthUnit
                dcboCurrency.Text = wh.Currency
                txtExchangeRate.Value = String.Format("{0:0.00}", wh.ExchangeRate)
                txtPriceForeigh_.Text = String.Format("{0:0.00}", wh.PriceForeigh)
                txtPriceBath.Value = String.Format("{0:0.00}", wh.PriceBath)
                txtPriceForeighAmount.Value = String.Format("{0:0.00}", wh.PriceForeighAmount)
                txtPriceBathAmount.Value = String.Format("{0:0.00}", wh.PriceBathAmount)
                txtPalletNo.Value = wh.PalletNo
                Status = CStr(wh.Status)
                txtSupplier.Value = wh.Supplier
                txtBuyer.Value = wh.Buyer
                txtExporter.Value = wh.Exporter
                txtDestination.Value = wh.Destination
                txtConsignee.Value = wh.Consignee
                txtShippingMark.Value = wh.ShippingMark
                txtEntryNo.Value = wh.EntryNo
                txtEntryItemNo.Value = CStr(wh.EntryItemNo)
                txtInvoice.Value = wh.Invoice
                If Status = "2" Then
                    rbShort.Checked = True
                    rbOver.Checked = False
                ElseIf Status = "3" Then
                    rbOver.Checked = True
                    rbShort.Checked = False
                Else
                    rbOver.Checked = False
                    rbShort.Checked = False
                End If
                'If lblLOTNo = wh.LOTNo Then
                '    chkName.Checked = False
                'End If

            End If
        Next
    End Sub

    Protected Sub dgvConfirmDetailbefor_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblSite As Label = CType(e.Item.FindControl("lblSite"), Label)
            Dim lblEND As Label = CType(e.Item.FindControl("lblEND"), Label)
            Dim lblCus As Label = CType(e.Item.FindControl("lblCus"), Label)
            Dim lblItem As Label = CType(e.Item.FindControl("lblItem"), Label)
            Dim lblPc As Label = CType(e.Item.FindControl("lblPc"), Label)
            Dim lblPn As Label = CType(e.Item.FindControl("lblPn"), Label)

            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblSite) Then
                lblSite.Text = DataBinder.Eval(e.Item.DataItem, "WHSite").ToString
            End If
            If Not IsNothing(lblEND) Then
                lblEND.Text = DataBinder.Eval(e.Item.DataItem, "ENDCustomer").ToString
            End If
            If Not IsNothing(lblCus) Then
                lblCus.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLOTNo").ToString
            End If
            If Not IsNothing(lblItem) Then
                lblItem.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString
            End If

            If Not IsNothing(lblPc) Then
                lblPc.Text = DataBinder.Eval(e.Item.DataItem, "ProductCode").ToString
            End If

            If Not IsNothing(lblPn) Then
                lblPn.Text = DataBinder.Eval(e.Item.DataItem, "CustomerPN").ToString
            End If
        End If

    End Sub

    Protected Sub dgvConfirmDetailafter_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblSite As Label = CType(e.Item.FindControl("lblSite"), Label)
            Dim lblEND As Label = CType(e.Item.FindControl("lblEND"), Label)
            Dim lblCus As Label = CType(e.Item.FindControl("lblCus"), Label)
            Dim lblItem As Label = CType(e.Item.FindControl("lblItem"), Label)
            Dim lblPc As Label = CType(e.Item.FindControl("lblPc"), Label)
            Dim lblPn As Label = CType(e.Item.FindControl("lblPn"), Label)

            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblSite) Then
                lblSite.Text = DataBinder.Eval(e.Item.DataItem, "WHSite").ToString
            End If
            If Not IsNothing(lblEND) Then
                lblEND.Text = DataBinder.Eval(e.Item.DataItem, "ENDCustomer").ToString
            End If
            If Not IsNothing(lblCus) Then
                lblCus.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLOTNo").ToString
            End If
            If Not IsNothing(lblItem) Then
                lblItem.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString
            End If

            If Not IsNothing(lblPc) Then
                lblPc.Text = DataBinder.Eval(e.Item.DataItem, "ProductCode").ToString
            End If

            If Not IsNothing(lblPn) Then
                lblPn.Text = DataBinder.Eval(e.Item.DataItem, "CustomerPN").ToString
            End If
        End If

    End Sub

    Private Sub ReadDATAbefor()

        Dim wh = (From h In db.tblWHConfirmGoodsReceiveDetails Where h.LOTNo = txtLotNo_.Value.Trim And
                h.StatusPutAlway = 0
                Order By h.ItemNo Ascending
                Select h.LOTNo, h.WHSite, h.ENDCustomer, h.CustomerLOTNo, h.ItemNo, h.ProductCode,
                h.CustomerPN).ToList

        If wh.Count > 0 Then
            dgvConfirmDetailbefor.DataSource = wh
            dgvConfirmDetailbefor.DataBind()
        End If

    End Sub

    Private Sub ReadDATAafter()

        Dim wh = (From h In db.tblWHConfirmGoodsReceiveDetails Where h.LOTNo = txtLotNo_.Value.Trim And
                h.StatusPutAlway = 1
                Order By h.ItemNo Ascending
                Select h.LOTNo, h.WHSite, h.ENDCustomer, h.CustomerLOTNo, h.ItemNo, h.ProductCode,
                h.CustomerPN).ToList

        If wh.Count > 0 Then
            dgvConfirmDetailafter.DataSource = wh
            dgvConfirmDetailafter.DataBind()
        End If
    End Sub
    Private Sub CallculateGoods()
        If dcbType.Text = "Goods Complete" Then
            txtQtyReceived.Value = CStr(CDbl(IIf(txtQtyReceived.Value = "", "0", txtQtyReceived.Value)) + CDbl(txtQuantity.Value))
            txtQtyDiscrepancy.Value = CStr(CDbl(IIf(txtQtyDiscrepancy.Value = "", "0", txtQtyDiscrepancy.Value)) + CDbl(txtQuantity.Value))
            cboReceivedUNIT.Text = ddlUnit4.Text
            cboDiscrepencyUNIT.Text = ddlUnit4.Text
        ElseIf dcbType.Text = "Wait Goods Received" Then
            txtQtyWaitReceive.Value = CStr(CDbl(txtQtyWaitReceive.Value) + CDbl(txtQuantity.Value))
            cboWaitReceiveUNIT.Text = ddlUnit4.Text
        ElseIf dcbType.Text = "Goods Damage" Then
            txtQtyDamage.Value = CStr(CDbl(txtQtyDamage.Value) + CDbl(txtQuantity.Value))
            cboDamageUNIT.Text = ddlUnit4.Text
            cboDiscrepencyUNIT.Text = ddlUnit4.Text
        End If
    End Sub

    Private Sub SaveDetail_New()
        Dim chkName As CheckBox
        Dim lblLOTNo As String
        Dim lblItem As Integer
        Dim availableQuantity As Integer
        Dim Quantity As Integer
        Dim ItemNo As Integer
        Dim i As Integer
        Dim j As Integer
        Dim ExpectedDate As Nullable(Of Date)
        Dim LOTNo As String
        Dim name As ArrayList
        name = New ArrayList
        If String.IsNullOrEmpty(txtLotNo_.Value.Trim) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ PrepairLOT ก่อน !!!')", True)
            txtLotNo_.Focus()
            Exit Sub

        Else
            For i = 0 To dgvItemDetail.Items.Count - 1
                chkName = CType(dgvItemDetail.Items(i).FindControl("chkLotNo"), CheckBox)
                lblLOTNo = CType(dgvItemDetail.Items(i).FindControl("lblLOTNo"), Label).Text.Trim
                lblItem = CInt(CType(dgvItemDetail.Items(i).FindControl("lblItem"), Label).Text.Trim)

                Try
                    If String.IsNullOrEmpty(txtExpectedDate.Text) Then
                        ExpectedDate = Nothing
                    Else
                        ExpectedDate = DateTime.ParseExact(txtExpectedDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
                    End If
                    If chkName.Checked = True Then
                        Dim wh = (From h In db.tblWHPrepairGoodsReceiveDetails Where h.LOTNo = lblLOTNo And h.ItemNo = lblItem
                        Select h).FirstOrDefault
                        If Not IsNothing(wh) Then
                            ItemNo = CInt(wh.ItemNo)
                            Quantity = CInt(wh.Quantity)
                            LOTNo = wh.LOTNo
                            If dcbType.Text = "Goods Complete" Then
                                availableQuantity = CInt(CDbl(Quantity).ToString("#,##0.000"))
                            ElseIf dcbType.Text = "Goods Damage" Then
                                availableQuantity = 0
                            ElseIf dcbType.Text = "Wait Goods Receive" Then
                                availableQuantity = 0
                            End If

                            db.tblWHConfirmGoodsReceiveDetails.Add(New tblWHConfirmGoodsReceiveDetail With { _
                                    .LOTNo = LOTNo, _
                                    .WHSite = wh.WHSite, _
                                    .WHLocation = dcbLocation.Text, _
                                    .ENDCustomer = wh.ENDCustomer, _
                                    .WHSource = wh.WHSource, _
                                    .CustomerLOTNo = wh.CustomerLOTNo, _
                                    .ItemNo = ItemNo, _
                                    .ProductCode = wh.ProductCode, _
                                    .CustomerPN = wh.CustomerPN, _
                                    .OwnerPN = wh.OwnerPN, _
                                    .ProductDesc = wh.ProductDesc, _
                                    .Measurement = wh.Measurement, _
                                    .ProductWidth = wh.ProductWidth, _
                                    .ProductLength = wh.ProductLength, _
                                    .ProductHeight = wh.ProductHeight, _
                                    .ProductVolume = wh.ProductVolume, _
                                    .OrderNo = wh.OrderNo, _
                                    .ReceiveNo = wh.ReceiveNo, _
                                    .Type = wh.Type, _
                                    .ManufacturingDate = wh.ManufacturingDate, _
                                    .ExpiredDate = wh.ExpiredDate, _
                                    .ReceiveDate = Now, _
                                    .Quantity = Quantity, _
                                    .QuantityUnit = wh.QuantityUnit, _
                                    .AvailableQuantity = availableQuantity, _
                                    .Weigth = wh.Weigth, _
                                    .WeigthUnit = wh.WeigthUnit, _
                                    .Currency = wh.Currency, _
                                    .ExchangeRate = wh.ExchangeRate, _
                                    .PriceForeigh = wh.PriceForeigh, _
                                    .PriceForeighAmount = wh.PriceForeighAmount, _
                                    .PriceBath = wh.PriceBath, _
                                    .PriceBathAmount = wh.PriceBathAmount, _
                                    .PalletNo = wh.PalletNo, _
                                    .UserBy = CStr(Session("UserName")), _
                                    .LastUpdate = Now, _
                                    .ExpectedDate = ExpectedDate, _
                                    .TypeDamage = dcbTypeDamage.Text.Trim, _
                                    .Supplier = wh.Supplier, _
                                    .Buyer = wh.Buyer, _
                                    .Exporter = wh.Exporter, _
                                    .Destination = wh.Destination, _
                                    .Consignee = wh.Consignee, _
                                    .ShippingMark = wh.ShippingMark, _
                                    .EntryNo = wh.EntryNo, _
                                    .EntryItemNo = CType(IIf(wh.EntryItemNo.ToString = "", 0, CInt(wh.EntryItemNo)), Integer?), _
                                    .Invoice = wh.Invoice
                                })

                            db.SaveChanges()

                            If SaveDetail_Modify1(ItemNo, Quantity) = False Then
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(' ItemNo  ที่คุณใส่ ไม่ถูกต้อง !!!')", True)
                            End If
                            SaveStockMovement_New(LOTNo, ItemNo)
                            'CountculateSubStockCtrl()
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Receive ข้อมูลเรียบร้อย !!')", True)

                        End If

                    End If
                Catch ex As Exception

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('" & ex.Message & "')", True)

                End Try

            Next
        End If
        ReadDATA()
        ReadDATA1()

    End Sub
    Private Function SaveDetail_Modify1(ByVal i As Integer, qty As Integer) As Boolean

        Dim wh As tblWHPrepairGoodsReceiveDetail = (From p In db.tblWHPrepairGoodsReceiveDetails
                                                    Where p.LOTNo = txtLotNo_.Value.Trim And p.ItemNo = i).First
        If Not IsNothing(wh) Then
            wh.LOTNo = txtLotNo_.Value.Trim
            wh.ItemNo = i
            wh.UserBy = CStr(Session("UserName"))
            wh.LastUpdate = Now
            If rbShort.Checked = True Then
                wh.Status = 2
            ElseIf rbOver.Checked = True Then
                wh.Status = 3
            Else
                wh.Status = 1
            End If
            wh.Quantity = CType((CDbl(qty) - CDbl(txtQuantity.Value)).ToString("#,##0.000"), Double?)
            db.SaveChanges()
            Return True

        End If

        Return False

    End Function

    Private Sub SaveStockMovement_New(LOTNo As String, Item As Integer)
        Dim ManufacturingDate As Nullable(Of Date)
        Dim ExpiredDate As Nullable(Of Date)
        Dim QuantityUnit As String
        Dim ReceivedQuantity As Integer
        Dim DamageQuantity As Integer
        Dim DamageUnit As String = ""
        Dim AvalableQuantity As Integer
        Dim wh = (From h In db.tblWHPrepairGoodsReceiveDetails Where h.LOTNo = LOTNo And h.ItemNo = Item
                       Select h).FirstOrDefault

        If Not IsNothing(wh) Then

            If CbNotDate.Checked = False Then
                ManufacturingDate = Nothing
                ExpiredDate = Nothing
            ElseIf CbNotDate.Checked = True Then
                ManufacturingDate = Convert.ToDateTime(wh.ManufacturingDate)
                ExpiredDate = Convert.ToDateTime(wh.ExpiredDate)
            End If

            If wh.Type = "Goods Complete" Then
                QuantityUnit = wh.QuantityUnit
                ReceivedQuantity = CInt(wh.Quantity)
                DamageQuantity = 0
                DamageUnit = wh.QuantityUnit
                AvalableQuantity = CInt(wh.Quantity)
            ElseIf wh.Type = "Goods Damage" Then
                QuantityUnit = wh.QuantityUnit
                ReceivedQuantity = CInt(wh.Quantity)
                DamageQuantity = CInt(wh.Quantity)
                DamageUnit = wh.QuantityUnit
                AvalableQuantity = 0
            End If

            db.tblWHStockMovements.Add(New tblWHStockMovement With { _
                    .LOTNo = wh.LOTNo, _
                    .WHSite = wh.WHSite, _
                    .OwnerCode = txtOwnerCode.Value.Trim, _
                    .WHLocation = wh.WHLocation, _
                    .ENDCustomer = wh.ENDCustomer, _
                    .WHSource = wh.WHSource, _
                    .CustomerLOTNo = wh.CustomerLOTNo, _
                    .ItemNo = wh.ItemNo, _
                    .ProductCode = wh.ProductCode, _
                    .CustomerPN = wh.CustomerPN, _
                    .OwnerPN = wh.OwnerPN, _
                    .ProductDesc = wh.ProductDesc, _
                    .Measurement = wh.Measurement, _
                    .ProductWidth = wh.ProductWidth, _
                    .ProductLength = wh.ProductLength, _
                    .ProductHeight = wh.ProductHeight, _
                    .ProductVolume = wh.ProductVolume, _
                    .OrderNo = wh.OrderNo, _
                    .ReceiveNo = wh.ReceiveNo, _
                    .Type = wh.Type, _
                    .ReceiveDate = wh.ReceiveDate, _
                    .StockType = "Received", _
                    .QuantityUnit = wh.QuantityUnit, _
                    .ReceivedQuantity = ReceivedQuantity, _
                    .DamageQuantity = DamageQuantity, _
                    .DamageUnit = DamageUnit, _
                    .AvalableQuantity = AvalableQuantity, _
                    .ManufacturingDate = wh.ManufacturingDate, _
                    .ExpiredDate = ExpiredDate, _
                    .Weigth = wh.Weigth, _
                    .WeigthUnit = wh.WeigthUnit, _
                    .Currency = wh.Currency, _
                    .ExchangeRate = wh.ExchangeRate, _
                    .PriceForeigh = wh.PriceForeigh, _
                    .PriceForeighAmount = wh.PriceForeighAmount, _
                    .PriceBath = wh.PriceBath, _
                    .PriceBathAmount = wh.PriceBathAmount, _
                    .PalletNo = wh.PalletNo, _
                    .UserBy = CStr(Session("UserName")), _
                    .LastUpdate = Now, _
                    .Status = 0, _
                    .TransactionDate = wh.ReceiveDate, _
                    .TypeDamage = dcbTypeDamage.Text.Trim, _
                    .item = 0,
                    .Supplier = wh.Supplier, _
                    .Buyer = wh.Buyer, _
                    .Exporter = wh.Exporter, _
                    .Destination = wh.Destination, _
                    .Consignee = wh.Consignee, _
                    .ShippingMark = wh.ShippingMark, _
                    .EntryNo = wh.EntryNo, _
                    .EntryItemNo = wh.EntryItemNo, _
                    .Invoice = wh.Invoice
               })
            db.SaveChanges()
        End If


    End Sub

    Protected Sub Unnamed_ServerClick4(sender As Object, e As EventArgs)
        selectProductCode()
    End Sub

    Protected Sub Unnamed_ServerClick5(sender As Object, e As EventArgs)
        selectEndCusCode()
    End Sub

    Private Sub selectProductCode()
        Dim testdate As Integer
        Dim ProCode As String = ""
        If String.IsNullOrEmpty(txtProductCode.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        End If

        Dim cons = (From u In db.tblProductDetails
                    Where (u.ProductCode.Contains(txtProductCode.Value.Trim)) Or u.CreateDate.Year = testdate And u.ImpProductCode <> ""
                   Select New With {u.ProductCode,
                                    u.ImpDesc1,
                                    u.PONo,
                                    u.CustomerPart,
                                    u.EndUserPart}).ToList()

        If cons.Count > 0 Then
            dgvProduct.DataSource = cons.ToList
            dgvProduct.DataBind()
            ScriptManager.RegisterStartupScript(ProductCodeUpdatePanel, ProductCodeUpdatePanel.GetType(), "show", "$(function () { $('#" + ProductCodePanel.ClientID + "').modal('show'); });", True)
            ProductCodeUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล ProductCode Code นี้')", True)
            Exit Sub

        End If
    End Sub

    Private Sub selectEndCusCode()
        Dim customer_ As String = ""
        If String.IsNullOrEmpty(txtCustomer.Value.Trim) Then
            customer_ = "0"
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode.Contains(txtCustomer.Value.Trim) And p.Customer = "0") Or p.Customer = customer_
        Select p.PartyCode, p.PartyFullName, pa.PartyAddressCode, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvCustomer.DataSource = cons.ToList
            dgvCustomer.DataBind()
            ScriptManager.RegisterStartupScript(EndCustomerUpdatePanel, EndCustomerUpdatePanel.GetType(), "show", "$(function () { $('#" + EndCustomerPanel.ClientID + "').modal('show'); });", True)
            EndCustomerUpdatePanel.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล End User Code นี้')", True)
            Exit Sub

        End If
    End Sub
    Protected Sub dgvCustomer_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
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
    Protected Sub dgvProduct_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim ProductCode As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectProductCode") Then

                If String.IsNullOrEmpty(ProductCode) Then

                    MsgBox("เป็นค่าว่าง")
                Else
                    Dim user = (From u In db.tblProductDetails Where u.ProductCode = ProductCode).SingleOrDefault

                    txtProductCode.Value = user.ProductCode
                    txtProductDesc1.Value = user.ImpDesc1
                    txtProductDesc2.Value = user.EndUserPart
                    txtProductDesc3.Value = user.CustomerPart
                    If String.IsNullOrEmpty(user.CartonSetUnit) Then
                    Else
                        ddlProductUnit.Text = user.CartonSetUnit
                    End If
                    txtProductWidth_.Text = String.Format("{0:0.00}", user.CartonWidth)
                    txtProductHeight_.Text = String.Format("{0:0.00}", user.CartonLenght)
                    txtProductLeng_.Text = String.Format("{0:0.00}", user.CartonHeight)
                    txtProductVolume.Value = String.Format("{0:0.00}", user.CartonVolume)
                    txtPriceForeigh_.Text = String.Format("{0:0.00}", user.ImpValueRate)

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub clickendcus_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblPartyCode As String = TryCast(Item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim lblPartyAddressCode As Double = CDbl(TryCast(Item.FindControl("lblPartyAddressCode"), Label).Text.Trim)

        Dim user = (From u In db.tblParties Join br In db.tblPartyAddresses On u.PartyCode Equals br.PartyCode
                    Where u.PartyCode = lblPartyCode And br.PartyAddressCode = lblPartyAddressCode).SingleOrDefault

        txtCustomer.Value = user.u.PartyCode
        'txtNameEndUser_PreGoodRec.Value = user.u.PartyFullName
        'txtAddress1EndUser_PreGoodRec.Value = user.br.Address1
        'txtAddress2EndUser_PreGoodRec.Value = user.br.Address2
        'txtAddress3EndUser_PreGoodRec.Value = user.br.Address3
        'txtAddress4EndUser_PreGoodRec.Value = user.br.Address4

    End Sub
    Private Sub PutAlway()

        If String.IsNullOrEmpty(dcbLocation.Text) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Location ก่อน !!!')", True)
            Exit Sub
        ElseIf String.IsNullOrEmpty(Txtpallet.Value.Trim) Or Txtpallet.Value.Trim = "0" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Location ก่อน !!!')", True)
            Exit Sub
        End If

    End Sub

    Private Sub PutAlwayAuto()

    End Sub

    Protected Sub dcbSite1_SelectedIndexChanged(sender As Object, e As EventArgs)
        checkLocation()
        Updatechange()
    End Sub
    Private Sub checkLocation()
        'Dim i As Integer

        If String.IsNullOrEmpty(dcbSite1.Text) Then
            Exit Sub
        Else
            Select Case MsgBox("คุณต้องการ Update Location ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")

                Case MsgBoxResult.Yes
                    Try
                        Dim l = (From lon In db.tblWHLocations Where lon.WHsite = dcbSite1.Text).ToList
                        If l.Count > 0 Then
                            For Each i In l
                                Dim co = (From c In db.tblWHConfirmGoodsReceiveDetails
                                     Where c.WHLocation = i.LocationNo And c.StatusPutAlway = 0 And c.WHSite = dcbSite1.Text
                                     Select c.WHLocation).ToList
                                If Not IsNothing(co) Then
                                    Dim upL As tblWHLocation = (From ln In db.tblWHLocations Where ln.LocationNo = i.LocationNo And ln.WHsite = dcbSite1.Text.Trim).FirstOrDefault
                                    If Not IsNothing(upL) Then
                                        upL.Usedstatus = 1
                                        db.SaveChanges()
                                    End If

                                Else
                                    Dim upL As tblWHLocation = (From ln In db.tblWHLocations Where ln.LocationNo = i.LocationNo And ln.WHsite = dcbSite1.Text.Trim).FirstOrDefault
                                    If Not IsNothing(upL) Then
                                        upL.Usedstatus = 0
                                        db.SaveChanges()
                                    End If
                                End If
                            Next

                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('อัพเดท Location Complete')", True)
                        End If
                    Catch ex As Exception
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('อัพเดท Location Error')", True)
                    End Try


            End Select
        End If

    End Sub

    Protected Sub rdbManual_CheckedChanged(sender As Object, e As EventArgs)
        dcbLocation1.Enabled = True
        Txtpallet.Disabled = False
    End Sub

    Protected Sub rdbAutoPallet_CheckedChanged(sender As Object, e As EventArgs)
        dcbLocation1.Enabled = False
        Txtpallet.Disabled = True
    End Sub
    Private Sub Updatechange()

        Dim l = From lo In db.tblWHLocations Where lo.LocationNo = dcbSite1.Text And lo.Usedstatus = 0
                Select lo.LocationNo

        Try
            dcbLocation1.DataSource = l.ToList
            dcbLocation1.DataTextField = "LocationNo"
            dcbLocation1.DataValueField = "LocationNo"
            dcbLocation1.DataBind()
            If dcbLocation1.Items.Count > 1 Then
                dcbLocation1.Enabled = True
            Else
                dcbLocation1.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub dcbLocation1_SelectedIndexChanged(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(dcbLocation1.Text.Trim) Then
            CheckStockIN()
            CheckStockUSE()
        Else
            LblInValume.Value = "0"
            LblInpallet.Value = "0"
            LblUseValume.Value = "0"
            LblUsePallet.Value = "0"
        End If
    End Sub
    Private Sub CheckStockIN()
        Dim l = (From lo In db.tblWHLocations Where lo.WHsite = dcbSite1.Text And lo.LocationNo = dcbLocation1.Text.Trim).FirstOrDefault
        If Not IsNothing(l) Then
            LblInValume.Value = String.Format("{0:0.00}", l.Valume)
            LblInpallet.Value = String.Format("{0:0.00}", l.Qtypallet)
        Else
            LblInValume.Value = "0"
            LblInpallet.Value = "0"
        End If

    End Sub

    Private Sub CheckStockUSE()


        'sb.Append("select sum(ProductVolume) as sumValume, 
        'count(DISTINCT  SUBSTRING(PalletNo,CHARINDEX('/',PalletNo)+1,len(PalletNo)-CHARINDEX('/',PalletNo))) as Countpallet   

        ' from tblWHConfirmGoodsReceiveDetail (NOLOCK)
        'WHERE WHsite  = @WHsite and  WHlocation = @location  and Lotno  <>  @Lotno and StatusAvailable = 0   ;")
        'Dim sb = (From wc In db.tblWHConfirmGoodsReceiveDetails Where wc.WHSite = dcbSite1.Text.Trim And wc.WHLocation = dcbLocation1.Text.Trim _
        '        And wc.LOTNo <> txtLotNo_.Value.Trim And wc.StatusAvailable = 0
        '        Group By wc.ProductVolume
        '        Into p = Sum(wc.ProductVolume)
        '        Select ProductVolume).ToList


        'If txtBrokerCode.Value = "" Then
        '    LblUseValume.Value = ""
        '    LblUsePallet.Value = ""
        'Else
        '    LblUseValume.Value = "0"
        '    LblUsePallet.Value = "0"
        'End If

    End Sub

    Protected Sub dcboCurrency_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim tmpMount As Single
        Dim Nmount As String
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = tmpMount.ToString("0#")

        Dim er = (From ex In db.tblExchangeRates Where ex.Currency = dcboCurrency.Text.Trim And ex.Status = "IMPORT" And ex.Mount = Nmount).FirstOrDefault
        If Not IsNothing(er) Then
            dcboCurrency.Text = er.Currency
            txtExchangeRate.Value = String.Format("{0:0.00}", er.BathAmount)
        End If
    End Sub

<<<<<<< HEAD
    Private Sub CallculateProductVolume()

        If (txtProductWidth_.Text.Trim() = "0") Then txtProductWidth_.Text = "0.0"
        If (txtProductHeight_.Text.Trim() = "0") Then txtProductHeight_.Text = "0.0"
        If (txtProductLeng_.Text.Trim() = "0") Then txtProductLeng_.Text = "0.0"
        If (txtProductVolume.Value.Trim() = "0") Then txtProductVolume.Value = "0.0"

        Dim VolumeAmount As Double
        If ddlProductUnit.Text = "CM" Then
            VolumeAmount = ((CDbl(txtProductWidth_.Text) * CDbl(txtProductHeight_.Text) * CDbl(txtProductLeng_.Text)) / 1000000)
            txtProductVolume.Value = VolumeAmount.ToString("#,##0.000")
        End If

        If ddlProductUnit.Text = "INC" Then
            VolumeAmount = (((CDbl(txtProductWidth_.Text) * CDbl(2.5)) * (CDbl(txtProductHeight_.Text) * CDbl(2.5)) * (CDbl(txtProductLeng_.Text) * CDbl(2.5))) / 1000000)
            txtProductVolume.Value = VolumeAmount.ToString("#,##0.000")
        End If

    End Sub

    Protected Sub txtPriceForeigh_TextChanged(sender As Object, e As EventArgs)
        CallculateValue()
        CallculateValueThai()
        CallculateValueThaiAmount()
    End Sub
    Private Sub CallculateValue()

        If (txtQuantity.Value.Trim() = "") Then txtQuantity.Value = "0.0"
        If (txtPriceForeigh_.Text.Trim() = "") Then txtPriceForeigh_.Text = "0.0"
        If (txtPriceForeighAmount.Value.Trim() = "") Then txtPriceForeighAmount.Value = "0.0"

        Dim ValueAmount As Double = 0.0
        ValueAmount = CSng(txtQuantity.Value) * CSng(txtPriceForeigh_.Text)
        txtPriceForeighAmount.Value = ValueAmount.ToString("#,##0.000")
    End Sub

    Private Sub CallculateValueThai()

        If (txtExchangeRate.Value.Trim() = "") Then txtExchangeRate.Value = "0.0"
        If (txtPriceForeigh_.Text.Trim() = "") Then txtPriceForeigh_.Text = "0.0"
        If (txtPriceBath.Value.Trim() = "") Then txtPriceBath.Value = "0.0"

        Dim ValueThaiAmount As Double = 0.0
        ValueThaiAmount = CSng(txtExchangeRate.Value) * CSng(txtPriceForeigh_.Text)
        txtPriceBath.Value = ValueThaiAmount.ToString("#,##0.000")
    End Sub

    Private Sub CallculateValueThaiAmount()
        If (txtQuantity.Value.Trim() = "") Then txtQuantity.Value = "0.0"
        If (txtPriceBath.Value.Trim() = "") Then txtPriceBath.Value = "0.0"
        If (txtPriceBathAmount.Value.Trim() = "") Then txtPriceBathAmount.Value = "0.0"

        Dim ValueThaiValueAmount As Double = 0.0

        ValueThaiValueAmount = CSng(txtQuantity.Value) * CSng(txtPriceBath.Value)
        txtPriceBathAmount.Value = ValueThaiValueAmount.ToString("#,##0.000")
    End Sub

    Protected Sub txtProductHeight_TextChanged(sender As Object, e As EventArgs)
        CallculateProductVolume()
    End Sub

    Protected Sub txtProductLeng_TextChanged(sender As Object, e As EventArgs)
        CallculateProductVolume()
    End Sub

    Protected Sub txtProductWidth_TextChanged(sender As Object, e As EventArgs)
        CallculateProductVolume()
=======
    Protected Sub chkLotNo1_CheckedChanged(sender As Object, e As EventArgs)
        Dim chkName As CheckBox
        Dim lblLOTNo As String
        Dim lblItem As Integer
        Dim i As Integer
        Dim j As Integer
        Dim name As ArrayList
        name = New ArrayList
        For i = 0 To dgvItemDetail.Items.Count - 1
            chkName = CType(dgvItemDetail.Items(i).FindControl("chkLotNo1"), CheckBox)
            lblLOTNo = CType(dgvItemDetail.Items(i).FindControl("lblLOTNo"), Label).Text.Trim
            lblItem = CInt(CType(dgvItemDetail.Items(i).FindControl("lblItem"), Label).Text.Trim)
            'lblName = CType(rptCustomers.Items(i).FindControl("lblName"), Label).Text.Trim
            'lblBranch = CType(rptCustomers.Items(i).FindControl("lblBrnch"), Label).Text.Trim
            If chkName.Checked = True Then
                Dim wh = (From h In db.tblWHPrepairGoodsReceiveDetails Where h.LOTNo = lblLOTNo And h.ItemNo = lblItem
                Select h).FirstOrDefault
                dcbSite.Text = wh.WHSite
                txtCustomer.Value = wh.ENDCustomer
                dcbSource.Text = wh.WHSource
                txtCusLOTNo.Value = wh.CustomerLOTNo
                txtItemNo.Value = String.Format("{0:0.00}", wh.ItemNo)
                txtProductCode.Value = wh.ProductCode
                txtProductDesc2.Value = wh.CustomerPN
                txtProductDesc3.Value = wh.OwnerPN
                txtProductDesc1.Value = wh.ProductDesc
                ddlProductUnit.Text = wh.Measurement
                txtProductWidth.Value = String.Format("{0:0.00}", wh.ProductWidth)
                txtProductHeight.Value = String.Format("{0:0.00}", wh.ProductLength)
                txtProductLeng.Value = String.Format("{0:0.00}", wh.ProductHeight)
                txtProductVolume.Value = String.Format("{0:0.00}", wh.ProductVolume)
                txtOrder.Value = wh.OrderNo
                txtReceive.Value = wh.ReceiveNo
                dcbType.Text = wh.Type
                txtManufacturingDate.Text = Convert.ToDateTime(wh.ManufacturingDate).ToString("dd/MM/yyyy")
                If String.IsNullOrEmpty(txtManufacturingDate.Text) Then
                    CbNotDate.Checked = True
                Else
                    CbNotDate.Checked = False
                End If
                txtExpiredDate.Text = Convert.ToDateTime(wh.ExpiredDate).ToString("dd/MM/yyyy")
                txtExpectedDate.Text = Convert.ToDateTime(wh.ReceiveDate).ToString("dd/MM/yyyy")
                txtQuantity.Value = String.Format("{0:0.00}", wh.Quantity)
                ddlUnit4.Text = wh.QuantityUnit
                txtWeightDetail.Value = String.Format("{0:0.00}", wh.Weigth)
                dcboUnitWeightDetail.Text = wh.WeigthUnit
                dcboCurrency.Text = wh.Currency
                txtExchangeRate.Value = String.Format("{0:0.00}", wh.ExchangeRate)
                txtPriceForeigh.Value = String.Format("{0:0.00}", wh.PriceForeigh)
                txtPriceBath.Value = String.Format("{0:0.00}", wh.PriceBath)
                txtPriceForeighAmount.Value = String.Format("{0:0.00}", wh.PriceForeighAmount)
                txtPriceBathAmount.Value = String.Format("{0:0.00}", wh.PriceBathAmount)
                txtPalletNo.Value = wh.PalletNo
                Status = CStr(wh.Status)
                txtSupplier.Value = wh.Supplier
                txtBuyer.Value = wh.Buyer
                txtExporter.Value = wh.Exporter
                txtDestination.Value = wh.Destination
                txtConsignee.Value = wh.Consignee
                txtShippingMark.Value = wh.ShippingMark
                txtEntryNo.Value = wh.EntryNo
                txtEntryItemNo.Value = CStr(wh.EntryItemNo)
                txtInvoice.Value = wh.Invoice
                If Status = "2" Then
                    rbShort.Checked = True
                    rbOver.Checked = False
                ElseIf Status = "3" Then
                    rbOver.Checked = True
                    rbShort.Checked = False
                Else
                    rbOver.Checked = False
                    rbShort.Checked = False
                End If
                'If lblLOTNo = wh.LOTNo Then
                '    chkName.Checked = False
                'End If

            End If
        Next
>>>>>>> 4c97da26cdb59ac74fb8dfa5a2a426dc0d2519d6
    End Sub
End Class