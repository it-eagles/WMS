Option Explicit On
Option Strict On


Imports System.Transactions
Imports System.Globalization
Public Class PickingWH
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        If Not Me.IsPostBack Then
            If classPermis.CheckRead(form, usename) = True Then
                If Not IsPostBack Then               
                    showDiscrepencyUNIT()
                    showQuantity3()
                    showQuatity1()
                    showQuatity2()
                    showSales()                 
                    showSource()                
                    showUnitWeightDetail()
                    showVolume()
                    showWeight()
                    showWeightINV()
                    TabName.Value = Request.Form(TabName.UniqueID)
                    LockMain()
                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
                'Response.Redirect("HomeMain.aspx")
            End If
        End If
    End Sub
    Private Sub LockMain()
        pickinghead_fieldset.Disabled = True
        importfiles_fieldset.Disabled = True
        assigndetailofpullsignal_fieldset.Disabled = True
        pickpack_fieldset.Disabled = True
        picknjr_fieldset.Disabled = True
        pickautopallet_fieldset.Disabled = True
        btnSaveNew.Visible = False
        btnSaveEdit.Visible = False
        btnSeletJobNew.Visible = False
        btnSelectJobEdit.Visible = False
    End Sub
    Protected Sub btnAddNew_ServerClick(sender As Object, e As EventArgs)
        btnSaveNew.Visible = True
        btnSaveEdit.Visible = False
        btnSeletJobNew.Visible = True
        btnSelectJobEdit.Visible = False
        pickinghead_fieldset.Disabled = False
        importfiles_fieldset.Disabled = True
        assigndetailofpullsignal_fieldset.Disabled = False
        pickpack_fieldset.Disabled = False
        picknjr_fieldset.Disabled = False
        pickautopallet_fieldset.Disabled = False
    End Sub

    Protected Sub btnEdit_ServerClick(sender As Object, e As EventArgs)
        btnSaveNew.Visible = False
        btnSaveEdit.Visible = True
        btnSeletJobNew.Visible = False
        btnSelectJobEdit.Visible = True
        pickinghead_fieldset.Disabled = False
        importfiles_fieldset.Disabled = False
        assigndetailofpullsignal_fieldset.Disabled = False
        pickpack_fieldset.Disabled = False
        picknjr_fieldset.Disabled = False
        pickautopallet_fieldset.Disabled = False
    End Sub

    Protected Sub btnSeletJobNew_ServerClick(sender As Object, e As EventArgs)
        selectExpGenLOT()
    End Sub

    Protected Sub btnSelectJobEdit_ServerClick(sender As Object, e As EventArgs)
        ReadDataPicklist()
    End Sub

    Protected Sub btnJobNoHead_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Unnamed_ServerClick(sender As Object, e As EventArgs)
        selectExporterCode()
    End Sub

    Protected Sub Unnamed_ServerClick1(sender As Object, e As EventArgs)
        selectOwnerCode()
    End Sub

    Protected Sub Unnamed_ServerClick2(sender As Object, e As EventArgs)
        selectConsigneeCode()
    End Sub

    Private Sub showUnitWeightDetail()
        'dcbQuantity1.Items.Clear()
        'dcbQuantity1.Items.Add(New ListItem("select Code"))
        'dcbQuantity1.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "COMMODITY"
                 Select q.Code, q.Type

        Try
            cboCommodity.DataSource = qt.ToList
            cboCommodity.DataTextField = "Code"
            cboCommodity.DataValueField = "Code"
            cboCommodity.DataBind()
            If cboCommodity.Items.Count > 1 Then
                cboCommodity.Enabled = True
            Else
                cboCommodity.Enabled = False
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
            dcbQuantityofPart.DataSource = qt.ToList
            dcbQuantityofPart.DataTextField = "Code"
            dcbQuantityofPart.DataValueField = "Code"
            dcbQuantityofPart.DataBind()
            If dcbQuantityofPart.Items.Count > 1 Then
                dcbQuantityofPart.Enabled = True
            Else
                dcbQuantityofPart.Enabled = False
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
            dcbQuantityPLT.DataSource = qt.ToList
            dcbQuantityPLT.DataTextField = "Code"
            dcbQuantityPLT.DataValueField = "Code"
            dcbQuantityPLT.DataBind()
            If dcbQuantityPLT.Items.Count > 1 Then
                dcbQuantityPLT.Enabled = True
            Else
                dcbQuantityPLT.Enabled = False

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
    Private Sub showSource()
        'cdbUnitQuantityDetail.Items.Clear()
        'cdbUnitQuantityDetail.Items.Add(New ListItem("select Unit"))
        'cdbUnitQuantityDetail.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT" Select q.Code, q.Type

        Try
            dcbQuantityPackage.DataSource = qt.ToList
            dcbQuantityPackage.DataTextField = "Code"
            dcbQuantityPackage.DataValueField = "Code"
            dcbQuantityPackage.DataBind()
            If dcbQuantityPackage.Items.Count > 1 Then
                dcbQuantityPackage.Enabled = True
            Else
                dcbQuantityPackage.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub showWeightINV()
        'cdbUnitWeightInv.Items.Clear()
        'cdbUnitWeightInv.Items.Add(New ListItem("select Pallet"))
        'cdbUnitWeightInv.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT" Select q.Code, q.Type

        Try

            cboRequestUnit.DataSource = qt.ToList
            cboRequestUnit.DataTextField = "Code"
            cboRequestUnit.DataValueField = "Code"
            cboRequestUnit.DataBind()
            If cboRequestUnit.Items.Count > 1 Then
                cboRequestUnit.Enabled = True
            Else
                cboRequestUnit.Enabled = False

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

    Protected Sub Unnamed_ServerClick3(sender As Object, e As EventArgs)
        selectShipto()
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
    Private Sub selectConsigneeCode()
        Dim code_code As String
        Dim consignee As String = ""
        Dim endCustomer As String = ""
        Dim shipper As String = ""
        If String.IsNullOrEmpty(txtConsignneeCode.Value.Trim) Then
            code_code = ""
            consignee = "0"
            endCustomer = "0"
            shipper = "0"
        Else
            code_code = txtConsignneeCode.Value.Trim
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
    Private Sub selectShipto()
        Dim exp_code As String
        Dim shipper As String = ""
        If String.IsNullOrEmpty(txtShiptoName.Value.Trim) Then
            exp_code = ""
            shipper = "0"
        Else
            exp_code = txtShiptoName.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = exp_code And p.Warehouse = "0") Or p.Warehouse = shipper
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvShipto.DataSource = cons.ToList
            dgvShipto.DataBind()
            ScriptManager.RegisterStartupScript(upShipto, upShipto.GetType(), "show", "$(function () { $('#" + plShipto.ClientID + "').modal('show'); });", True)
            upShipto.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Exporter Code นี้')", True)
            Exit Sub
        End If
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
            txtOwnerName.Value = ""
        Else
            txtOwnerName.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtOwnerAddress1.Value = ""
        Else
            txtOwnerAddress1.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtOwnerAddress2.Value = ""
        Else
            txtOwnerAddress2.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtOwnerAddress3.Value = ""
        Else
            txtOwnerAddress3.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtOwnerAddress4.Value = ""
        Else
            txtOwnerAddress4.Value = eano.pa.Address4
        End If

    End Sub
    Protected Sub lnkPartyCode_Con_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtConsignneeCode.Value = ""
        Else
            txtConsignneeCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtConsignneeEng.Value = ""
        Else
            txtConsignneeEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtConsignneeAddress1.Value = ""
        Else
            txtConsignneeAddress1.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtConsignneeAddress2.Value = ""
        Else
            txtConsignneeAddress2.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtConsignneeAddress3.Value = ""
        Else
            txtConsignneeAddress3.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtConsignneeAddress4.Value = ""
        Else
            txtConsignneeAddress4.Value = eano.pa.Address4
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
            txtExporterAddress1.Value = ""
        Else
            txtExporterAddress1.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtExporterAddress2.Value = ""
        Else
            txtExporterAddress2.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtExporterAddress3.Value = ""
        Else
            txtExporterAddress3.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtExporterAddress4.Value = ""
        Else
            txtExporterAddress4.Value = eano.pa.Address4
        End If

    End Sub

    Protected Sub dgvShipto_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
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
    Protected Sub lnkPartyCode_LOTNo_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtShipToCode.Value = ""
        Else
            txtShipToCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtShiptoName.Value = ""
        Else
            txtShiptoName.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtShiptoAddress1.Value = ""
        Else
            txtShiptoAddress1.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtShiptoAddress2.Value = ""
        Else
            txtShiptoAddress2.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtShiptoAddress3.Value = ""
        Else
            txtShiptoAddress3.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtShiptoAddress4.Value = ""
        Else
            txtShiptoAddress4.Value = eano.pa.Address4
        End If
    End Sub

    Protected Sub btnSaveNew_ServerClick(sender As Object, e As EventArgs)
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        If classPermis.CheckSave(form, usename) = True Then
            SavePicking_New()
            UpdateLOTOUT1()
            LockMain()
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ บันทึกในเมนูนี้ ' !!!');", True)
        End If
    End Sub

    Protected Sub btnSaveEdit_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub lnk_EAS_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim EASLOTNo As String = TryCast(item.FindControl("lblEASLOTNo"), Label).Text.Trim
        Dim exp = (From ex In db.tblExpGenLOTs Where ex.EASLOTNo = EASLOTNo).SingleOrDefault
        If Not IsNothing(exp) Then
            Try

                If String.IsNullOrEmpty(exp.EASLOTNo) Then
                    txtLOtNo.Value = ""
                Else
                    txtLOtNo.Value = exp.EASLOTNo
                End If
                txtExporterCode.Value = exp.EndCusCode
                txtExportEng.Value = exp.EndCusENG
                txtExporterAddress1.Value = exp.EndCusAddress1
                txtExporterAddress2.Value = exp.EndCusAddress2
                txtExporterAddress3.Value = exp.EndCusAddress3
                txtExporterAddress4.Value = exp.EndCusAddress4
                txtConsignneeCode.Value = exp.ConsigneeCode
                txtConsignneeEng.Value = exp.ConsignNameEng
                txtConsignneeAddress1.Value = exp.ConsignAddress
                txtConsignneeAddress2.Value = exp.ConsignDistrict
                txtConsignneeAddress3.Value = exp.ConsignSubProvince
                txtConsignneeAddress4.Value = exp.ConsignProvince
                txtOwnerCode.Value = exp.CustomerCode
                txtOwnerName.Value = exp.CustomerENG
                txtOwnerAddress1.Value = exp.CustomerStreet
                txtOwnerAddress2.Value = exp.CustomerDistrict
                txtOwnerAddress3.Value = exp.CustomerSub
                txtOwnerAddress4.Value = exp.CustomerProvince
                txtShipToCode.Value = exp.ShipperCode
                txtShiptoName.Value = exp.ShipperNameEng
                txtShiptoAddress1.Value = exp.ShipperAddress
                txtShiptoAddress2.Value = exp.ShipperDistrict
                txtShiptoAddress3.Value = exp.ShipperSubprovince
                txtShiptoAddress4.Value = exp.ShipperProvince

                If Not IsNothing(exp.Commodity) Then
                    cboCommodity.Text = exp.Commodity
                End If
                txtQuantityofPart.Value = String.Format("{0:0.00}", exp.QuantityofPart)

                If Not IsNothing(exp.QuantityUnit) Then
                    dcbQuantityofPart.Text = exp.QuantityUnit
                End If
                txtQuantityPackage.Value = String.Format("{0:0.00}", exp.Box)

                If Not IsNothing(exp.UnitBox) Then
                    dcbQuantityPackage.Text = exp.UnitBox
                End If
                txtQuantityPLT.Value = String.Format("{0:0.00}", exp.QuantityPack)

                If Not IsNothing(exp.QuantityUnitPack) Then
                    dcbQuantityPLT.Text = exp.QuantityUnitPack
                End If
                txtWeight.Value = String.Format("{0:0.00}", exp.Weight)

                If Not IsNothing(exp.WeightUnit) Then
                    dcbWeight.Text = exp.WeightUnit
                End If
                txtVolume.Value = String.Format("{0:0.00}", exp.Volume)

                If Not IsNothing(exp.VolumeUnit) Then
                    dcbVolume.Text = exp.VolumeUnit
                End If
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('" & ex.Message & "')", True)
                Exit Try
            End Try

        End If
    End Sub
    Protected Sub dgvGenExp_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblEASLOTNo As Label = CType(e.Item.FindControl("lblEASLOTNo"), Label)
            Dim lblCustomer As Label = CType(e.Item.FindControl("lblCustomer"), Label)
            Dim lblSales As Label = CType(e.Item.FindControl("lblSales"), Label)
            Dim lblSite As Label = CType(e.Item.FindControl("lblSite"), Label)
            Dim lblCus As Label = CType(e.Item.FindControl("lblCus"), Label)
            
            If Not IsNothing(lblEASLOTNo) Then
                lblEASLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "EASLOTNo").ToString
            End If
            If Not IsNothing(lblCustomer) Then
                lblCustomer.Text = DataBinder.Eval(e.Item.DataItem, "CustomerCode").ToString
            End If
            If Not IsNothing(lblSales) Then
                lblSales.Text = DataBinder.Eval(e.Item.DataItem, "SalesCode").ToString
            End If
            If Not IsNothing(lblSite) Then
                lblSite.Text = DataBinder.Eval(e.Item.DataItem, "JobSite").ToString
            End If
            If Not IsNothing(lblCus) Then
                lblCus.Text = DataBinder.Eval(e.Item.DataItem, "EndCusCode").ToString
            End If
        End If
    End Sub
    Private Sub selectExpGenLOT()
        Dim testdate As Integer
        Dim dataMon As Integer
        If String.IsNullOrEmpty(txtLotNo.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            dataMon = CInt(Convert.ToDateTime(Date.Now).ToString("MM"))
        End If

        'Where e.LOTDate.Year = testdate
        Dim exl = (From e In db.tblExpGenLOTs Where (e.EASLOTNo.Contains(txtLOtNo.Value.Trim) And e.Status = 0) Or (e.LOTDate.Year = testdate And e.LOTDate.Month = dataMon And e.Status = 0) Order By e.EASLOTNo Descending
                 Select New With {
                 e.EASLOTNo,
                 e.CustomerCode,
                 e.SalesCode,
                 e.JobSite,
                 e.EndCusCode}).ToList
        Try
            If exl.Count > 0 Then
                Me.dgvGenExp.DataSource = exl
                Me.dgvGenExp.DataBind()
                ScriptManager.RegisterStartupScript(upGenExp, upGenExp.GetType(), "show", "$(function () { $('#" + plGenExp.ClientID + "').modal('show'); });", True)
                upGenExp.Update()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
                Exit Sub
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", ex.Message, True)
        End Try
    End Sub

    Private Sub SavePicking_New()
        Dim pull_d As Nullable(Of Date)
        Dim DeliveryDate As Nullable(Of Date)
        Dim ConfirmDate As Nullable(Of Date)
        If txtLOtNo.Value.Trim() = "" Then
            'MessageBox.Show("กรุณาใส่ LOT NO ก่อน !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ LOT NO ก่อน !!!')", True)
            txtLOtNo.Focus()
            Exit Sub
        End If

        If txtPullSignal.Value.Trim() = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Pull Signal ก่อน !!!')", True)
            txtPullSignal.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(dtpPullDate.Text) Then
            pull_d = Nothing
        Else
            pull_d = DateTime.ParseExact(dtpPullDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If

        If String.IsNullOrEmpty(dtpDeliveryDate.Text) Then
            DeliveryDate = Nothing
        Else
            DeliveryDate = DateTime.ParseExact(dtpPullDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If

        If String.IsNullOrEmpty(dtpConfirmDate.Text) Then
            ConfirmDate = Nothing
        Else
            ConfirmDate = DateTime.ParseExact(dtpPullDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        Select Case MsgBox("คุณต้องการเพิ่มรายการ Pick List ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
            Case MsgBoxResult.Yes
                Try
                    db.tblWHPickings.Add(New tblWHPicking With { _
                                       .PullSignal = txtPullSignal.Value.Trim, _
                                       .LOTNo = txtLOtNo.Value.Trim, _
                                       .PullDate = CDate(pull_d), _
                                       .PullTime = txtPullTime.Value.Trim, _
                                       .DeliveryDate = DeliveryDate, _
                                       .DeliveryTime = txtDeliveryTime.Value.Trim, _
                                       .ConfirmDate = ConfirmDate, _
                                       .ConfirmTime = txtComfirmTime.Value.Trim, _
                                       .ExporterCode = txtExporterCode.Value.Trim, _
                                       .ExporterName = txtExportEng.Value.Trim, _
                                       .ExporterAddress1 = txtExporterAddress1.Value.Trim, _
                                       .ExporterAddress2 = txtExporterAddress2.Value.Trim, _
                                       .ExporterAddress3 = txtExporterAddress3.Value.Trim, _
                                       .ExporterAddress4 = txtExporterAddress4.Value.Trim, _
                                       .ConsigneeCode = txtConsignneeCode.Value.Trim, _
                                       .ConsigneeName = txtConsignneeEng.Value.Trim, _
                                       .ConsigneeAddress1 = txtConsignneeAddress1.Value.Trim, _
                                       .ConsigneeAddress2 = txtConsignneeAddress2.Value.Trim, _
                                       .ConsigneeAddress3 = txtConsignneeAddress3.Value.Trim, _
                                       .ConsigneeAddress4 = txtConsignneeAddress4.Value.Trim, _
                                       .OwnerCode = txtOwnerCode.Value.Trim, _
                                       .OwnerName = txtOwnerName.Value.Trim, _
                                       .OwnerAddress1 = txtOwnerAddress1.Value.Trim, _
                                       .OwnerAddress2 = txtOwnerAddress2.Value.Trim, _
                                       .OwnerAddress3 = txtOwnerAddress3.Value.Trim, _
                                       .OwnerAddress4 = txtOwnerAddress4.Value.Trim, _
                                       .ShipToCode = txtShipToCode.Value.Trim, _
                                       .ShipToName = txtShiptoName.Value.Trim, _
                                       .ShipToAddress1 = txtShiptoAddress1.Value.Trim, _
                                       .ShipToAddress2 = txtShiptoAddress2.Value.Trim, _
                                       .ShipToAddress3 = txtShiptoAddress3.Value.Trim, _
                                       .ShipToAddress4 = txtShiptoAddress4.Value.Trim, _
                                       .Commodity = cboCommodity.Text.Trim, _
                                       .QuantityOfPart = CType(CDbl(txtQuantityofPart.Value).ToString("#,##0.000"), Double?), _
                                       .QuantityUnit = dcbQuantityofPart.Text.Trim, _
                                       .QuantityPackage = CType(CDbl(txtQuantityPackage.Value).ToString("#,##0.000"), Double?), _
                                       .PackageUNIT = dcbQuantityPackage.Text.Trim, _
                                       .QuantityPLT = CType(CDbl(txtQuantityPLT.Value).ToString("#,##0.000"), Double?), _
                                       .QuantityPLTUnit = dcbQuantityPLT.Text.Trim, _
                                       .Weight = CType(CDbl(txtWeight.Value).ToString("#,##0.000"), Double?), _
                                       .WeightUnit = dcbWeight.Text.Trim, _
                                       .Volume = CType(CDbl(txtVolume.Value).ToString("#,##0.000"), Double?), _
                                       .VolumeUnit = dcbVolume.Text.Trim, _
                                       .QuantityPicked = CType(CDbl(txtQtyReceived.Value).ToString("#,##0.000"), Double?), _
                                       .PickedUNIT = cboReceivedUNIT.Text.Trim, _
                                       .QuantityDiscrepancy = CType(CDbl(txtQTYDiscrepancy.Value).ToString("#,##0.000"), Double?), _
                                       .DiscrepancyUNIT = cboDiscrepencyUNIT.Text.Trim, _
                                       .Remark = txtRemark_PickingHead.Value.Trim, _
                                       .PrintCount = "0", _
                                       .UserBy = CStr(Session("UserName")), _
                                       .LastUpdate = Now
                    })
                    db.SaveChanges()
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก " & ex.Message & "')", True)
                    Exit Select
                End Try

        End Select

        txtLOtNo.Focus()
    End Sub

    Private Sub UpdateLOTOUT1()
        If txtLOtNo.Value.Trim() = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ PrepairLOT ก่อน !!!')", True)
            txtLOtNo.Focus()
            Exit Sub
        Else
            Try

                Dim upExp As tblExpGenLOT = (From e In db.tblExpGenLOTs Where e.EASLOTNo = txtLOtNo.Value.Trim).First
                If upExp IsNot Nothing Then
                    upExp.Status = 1
                    db.SaveChanges()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('บันทึก เสร็จเรียบร้อย !');", True)
                    Exit Sub
                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('PrepairLOT ที่คุณใส่ ไม่ถูกต้อง !!!');", True)
                End If
              
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก " & ex.Message & "')", True)
            End Try
        End If
        txtLOTNo.Focus()
    End Sub

    Private Sub ReadDataPicklist()
        Dim testdate As Integer
        Dim dataMon As Integer
        If String.IsNullOrEmpty(txtLOtNo.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            dataMon = CInt(Convert.ToDateTime(Date.Now).ToString("MM"))
        End If
 
        'Where e.LOTDate.Year = testdate
        Dim exl = (From e In db.tblWHPickings Where e.LOTNo.Contains(txtLOtNo.Value.Trim) Or (e.LastUpdate.Year = testdate And e.LastUpdate.Month = dataMon) Order By e.LOTNo Descending
                 Select New With {
                 e.PullSignal,
                 e.LOTNo,
                 e.PullDate,
                 e.DeliveryDate}).ToList
        Try
            If exl.Count > 0 Then
                Me.dgvPicklist.DataSource = exl
                Me.dgvPicklist.DataBind()
                ScriptManager.RegisterStartupScript(upPicklist, upPicklist.GetType(), "show", "$(function () { $('#" + plPicklist.ClientID + "').modal('show'); });", True)
                upPicklist.Update()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
                Exit Sub
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", ex.Message, True)
        End Try
    End Sub

    Protected Sub btnPullSignal_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub dgvPicklist_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPullSignal As Label = CType(e.Item.FindControl("lblPullSignal"), Label)
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblPullDate As Label = CType(e.Item.FindControl("lblPullDate"), Label)
            Dim lblDelivery As Label = CType(e.Item.FindControl("lblDelivery"), Label)
        
            If Not IsNothing(lblPullSignal) Then
                lblPullSignal.Text = DataBinder.Eval(e.Item.DataItem, "PullSignal").ToString
            End If
            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblPullDate) Then
                lblPullDate.Text = DataBinder.Eval(e.Item.DataItem, "PullDate", "{0:dd/MM/yyyy}").ToString
            End If
            If Not IsNothing(lblDelivery) Then
                lblDelivery.Text = DataBinder.Eval(e.Item.DataItem, "DeliveryDate", "{0:dd/MM/yyyy}").ToString
            End If
           
        End If
    End Sub
End Class