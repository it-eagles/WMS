Option Explicit On
Option Strict On
Option Infer On

Imports System.Transactions
Imports System.Globalization
Public Class PickingWH
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis
    Dim ProductNo As String
    Dim Owner As String
    Dim CustomerLots As String
    'ManufacturingDates = .Rows.Item(e.RowIndex).Cells(11).Value.ToString()
    'ExpiredDates = .Rows.Item(e.RowIndex).Cells(12).Value.ToString()
    Dim RowRequest1 As Integer
    Dim zInvoice As String
    Dim QtyRequest As Double
    Dim OrderFrmOnline As String
    Dim CustFrmOnline As String
    Dim listArray As New ArrayList
    Dim ItemTotal As Double
    Dim ManufacturingDate As String
    Dim ExpiredDate As String
    Dim con As ConfirmGoodsReceiveDetail

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
        picking_.Disabled = True
    End Sub
    Protected Sub btnAddNew_ServerClick(sender As Object, e As EventArgs)
        btnSaveNew.Visible = True
        btnSaveEdit.Visible = False
        btnSeletJobNew.Visible = True
        btnSelectJobEdit.Visible = False
        pickinghead_fieldset.Disabled = False
        importfiles_fieldset.Disabled = False
        assigndetailofpullsignal_fieldset.Disabled = True
        pickpack_fieldset.Disabled = False
        picknjr_fieldset.Disabled = False
        pickautopallet_fieldset.Disabled = False
        ClearDataHead()
        picking_.Disabled = False
        rdbOwner.Checked = True
        rdbIMP.Checked = True
        rcbFIFO.Checked = True
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
        ClearDataHead()
        picking_.Disabled = False
        chkNotUseDate_AssignDetail.Checked = True
        txtdatepickerExpiredDate_AssignDetail.Attributes.Add("disabled", "disabled")
        txtdatepickerManufacturing_AssignDetail.Attributes.Add("disabled", "disabled")
        rdbOwner.Checked = True
        rdbIMP.Checked = True
        rcbFIFO.Checked = True
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
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        If classPermis.CheckEdit(form, usename) Then
            savePicking_Modify()
            LockMain()
            ReadDataRequestedISSUE()
            ReadDataRequestedISSUE_PickPack()
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ แก้ไขในเมนูนี้ ' !!!');", True)
        End If
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
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim EASLOTNo As String = TryCast(item.FindControl("lblLOTNo"), Label).Text.Trim
        Dim pull As String = TryCast(item.FindControl("lblPullSignal"), Label).Text.Trim
        Dim exp = (From ex In db.tblWHPickings Where ex.LOTNo = EASLOTNo And ex.PullSignal = pull).SingleOrDefault
        If Not IsNothing(exp) Then
            Try
                txtPullSignal.Value = exp.PullSignal
                txtLOtNo.Value = exp.LOTNo
                dtpPullDate.Text = Convert.ToDateTime(exp.PullDate).ToString("dd/MM/yyyy")
                txtPullTime.Value = exp.PullTime
                dtpDeliveryDate.Text = Convert.ToDateTime(exp.DeliveryDate).ToString("dd/MM/yyyy")
                txtDeliveryTime.Value = exp.DeliveryTime
                dtpConfirmDate.Text = Convert.ToDateTime(exp.ConfirmDate).ToString("dd/MM/yyyy")
                txtComfirmTime.Value = exp.ConfirmTime
                txtExporterCode.Value = exp.ExporterCode
                txtExportEng.Value = exp.ExporterName
                txtExporterAddress1.Value = exp.ExporterAddress1
                txtExporterAddress2.Value = exp.ExporterAddress2
                txtExporterAddress3.Value = exp.ExporterAddress3
                txtExporterAddress4.Value = exp.ExporterAddress4
                txtConsignneeCode.Value = exp.ConsigneeCode
                txtConsignneeEng.Value = exp.ConsigneeName
                txtConsignneeAddress1.Value = exp.ConsigneeAddress1
                txtConsignneeAddress2.Value = exp.ConsigneeAddress2
                txtConsignneeAddress3.Value = exp.ConsigneeAddress3
                txtConsignneeAddress4.Value = exp.ConsigneeAddress4
                txtOwnerCode.Value = exp.OwnerCode
                txtOwnerName.Value = exp.OwnerName
                txtOwnerAddress1.Value = exp.OwnerAddress1
                txtOwnerAddress2.Value = exp.OwnerAddress2
                txtOwnerAddress3.Value = exp.OwnerAddress3
                txtOwnerAddress4.Value = exp.OwnerAddress4
                txtShipToCode.Value = exp.ShipToCode
                txtShiptoName.Value = exp.ShipToName
                txtShiptoAddress1.Value = exp.ShipToAddress1
                txtShiptoAddress2.Value = exp.ShipToAddress2
                txtShiptoAddress3.Value = exp.ShipToAddress3
                txtShiptoAddress4.Value = exp.ShipToAddress4
                If Not IsNothing(exp.Commodity) Then
                    cboCommodity.Text = exp.Commodity
                End If
                txtQuantityofPart.Value = String.Format("{0:0.00}", exp.QuantityOfPart)
                If Not IsNothing(exp.QuantityUnit) Then
                    dcbQuantityofPart.Text = exp.QuantityUnit
                End If

                txtQuantityPackage.Value = String.Format("{0:0.00}", exp.QuantityPackage)
                txtQuantityPLT.Value = String.Format("{0:0.00}", exp.QuantityPLT)

                If Not IsNothing(exp.QuantityPLTUnit) Then
                    dcbQuantityPLT.Text = exp.QuantityPLTUnit
                End If
                txtWeight.Value = String.Format("{0:0.00}", exp.Weight)
                dcbWeight.Text = exp.WeightUnit
                txtVolume.Value = String.Format("{0:0.00}", exp.Volume)

                If Not IsNothing(exp.VolumeUnit) Then
                    dcbVolume.Text = exp.VolumeUnit
                End If
                txtQtyReceived.Value = String.Format("{0:0.00}", exp.QuantityPicked)
                If Not IsNothing(exp.PickedUNIT) Then
                    cboReceivedUNIT.Text = exp.PickedUNIT
                End If
                txtQTYDiscrepancy.Value = String.Format("{0:0.00}", exp.QuantityDiscrepancy)

                If Not IsNothing(exp.DiscrepancyUNIT) Then
                    cboDiscrepencyUNIT.Text = exp.DiscrepancyUNIT
                End If
                txtRemark_PickingHead.Value = exp.Remark
                ReadDataRequestedISSUE()
                ReadDataRequestedISSUE_PickPack()
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('" & ex.Message & "')", True)
                Exit Try
            End Try

        End If
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
    Private Sub savePicking_Modify()
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
        Select Case MsgBox("คุณต้องการแก้ไขข้อมูล  Pick List ใช่หรือไม่?", MsgBoxStyle.YesNo, "คำยืนยัน")
            Case MsgBoxResult.Yes
                Try
                    Dim exp As tblWHPicking = (From p In db.tblWHPickings Where p.LOTNo = txtLOtNo.Value.Trim And p.PullSignal = txtPullSignal.Value.Trim).FirstOrDefault
                    If exp IsNot Nothing Then
                        exp.PullSignal = txtPullSignal.Value.Trim
                        exp.LOTNo = txtLOtNo.Value.Trim
                        exp.PullDate = CDate(pull_d)
                        exp.PullTime = txtPullTime.Value.Trim
                        exp.DeliveryDate = DeliveryDate
                        exp.DeliveryTime = txtDeliveryTime.Value.Trim
                        exp.ConfirmDate = ConfirmDate
                        exp.ConfirmTime = txtComfirmTime.Value.Trim
                        exp.ExporterCode = txtExporterCode.Value.Trim
                        exp.ExporterName = txtExportEng.Value.Trim
                        exp.ExporterAddress1 = txtExporterAddress1.Value.Trim
                        exp.ExporterAddress2 = txtExporterAddress2.Value.Trim
                        exp.ExporterAddress3 = txtExporterAddress3.Value.Trim
                        exp.ExporterAddress4 = txtExporterAddress4.Value.Trim
                        exp.ConsigneeCode = txtConsignneeCode.Value.Trim
                        exp.ConsigneeName = txtConsignneeEng.Value.Trim
                        exp.ConsigneeAddress1 = txtConsignneeAddress1.Value.Trim
                        exp.ConsigneeAddress2 = txtConsignneeAddress2.Value.Trim
                        exp.ConsigneeAddress3 = txtConsignneeAddress3.Value.Trim
                        exp.ConsigneeAddress4 = txtConsignneeAddress4.Value.Trim
                        exp.OwnerCode = txtOwnerCode.Value.Trim
                        exp.OwnerName = txtOwnerName.Value.Trim
                        exp.OwnerAddress1 = txtOwnerAddress1.Value.Trim
                        exp.OwnerAddress2 = txtOwnerAddress2.Value.Trim
                        exp.OwnerAddress3 = txtOwnerAddress3.Value.Trim
                        exp.OwnerAddress4 = txtOwnerAddress4.Value.Trim
                        exp.ShipToCode = txtShipToCode.Value.Trim
                        exp.ShipToName = txtShiptoName.Value.Trim
                        exp.ShipToAddress1 = txtShiptoAddress1.Value.Trim
                        exp.ShipToAddress2 = txtShiptoAddress2.Value.Trim
                        exp.ShipToAddress3 = txtShiptoAddress3.Value.Trim
                        exp.ShipToAddress4 = txtShiptoAddress4.Value.Trim
                        exp.Commodity = cboCommodity.Text.Trim
                        exp.QuantityOfPart = CType(CDbl(txtQuantityofPart.Value.Trim).ToString("#,##0.000"), Double?)
                        exp.QuantityUnit = dcbQuantityofPart.Text.Trim
                        exp.QuantityPackage = CType(CDbl(txtQuantityPackage.Value.Trim).ToString("#,##0.000"), Double?)
                        exp.QuantityPLT = CType(CDbl(txtQuantityPLT.Value.Trim).ToString("#,##0.000"), Double?)
                        exp.QuantityPLTUnit = dcbQuantityPLT.Text.Trim
                        exp.Weight = CType(CDbl(txtWeight.Value.Trim).ToString("#,##0.000"), Double?)
                        exp.WeightUnit = dcbWeight.Text.Trim
                        exp.Volume = CType(CDbl(txtVolume.Value.Trim).ToString("#,##0.000"), Double?)
                        exp.VolumeUnit = dcbVolume.Text.Trim
                        exp.QuantityPicked = CType(CDbl(txtQtyReceived.Value.Trim).ToString("#,##0.000"), Double?)
                        exp.PickedUNIT = cboReceivedUNIT.Text.Trim
                        exp.QuantityDiscrepancy = CType(CDbl(txtQTYDiscrepancy.Value.Trim).ToString("#,##0.000"), Double?)
                        exp.DiscrepancyUNIT = cboDiscrepencyUNIT.Text.Trim
                        exp.Remark = txtRemark_PickingHead.Value.Trim
                        exp.UserBy = CStr(Session("UserName"))
                        exp.LastUpdate = Now
                        db.SaveChanges()
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล Pick List เรียบร้อยแล้ว !!!')", True)
                        Exit Sub
                    Else
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('Pick List ที่คุณใส่ ไม่ถูกต้อง !!!')", True)
                        Exit Sub
                    End If

                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก " & ex.Message & "')", True)
                    Exit Select
                End Try

        End Select

        txtLOtNo.Focus()
    End Sub

    Protected Sub lbCode_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblProductCode As String = CType(item.FindControl("lblProductCode"), Label).Text.Trim
        Dim lblExpDesc As String = CType(item.FindControl("lblExpDesc"), Label).Text.Trim
        Dim lblimpDesc As String = CType(item.FindControl("lblimpDesc"), Label).Text.Trim
        Dim lblUserPart As String = CType(item.FindControl("lblUserPart"), Label).Text.Trim
        Dim lblPart As String = CType(item.FindControl("lblPart"), Label).Text.Trim
        txtProductCode.Value = lblProductCode
        txtCustomerPart.Value = lblUserPart
        txtOwnerPart.Value = lblPart
        If rdbEXP.Checked = True Then
            txtProductDesc.Value = lblExpDesc
        Else
            txtProductDesc.Value = lblimpDesc
        End If
    End Sub

    Protected Sub dgvProduct_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim expDesc As String = ""
        Dim impDesc As String = ""
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblProductCode As Label = CType(e.Item.FindControl("lblProductCode"), Label)
            Dim lblExpDesc As Label = CType(e.Item.FindControl("lblExpDesc"), Label)
            Dim lblimpDesc As Label = CType(e.Item.FindControl("lblimpDesc"), Label)
            Dim lblUserPart As Label = CType(e.Item.FindControl("lblUserPart"), Label)
            Dim lblPart As Label = CType(e.Item.FindControl("lblPart"), Label)
            expDesc = DataBinder.Eval(e.Item.DataItem, "ExpDesc1").ToString
            impDesc = DataBinder.Eval(e.Item.DataItem, "impDesc1").ToString
            If rdbEXP.Checked = True Then
                lblExpDesc.Text = expDesc
                lblimpDesc.Visible = True
            Else
                lblimpDesc.Text = impDesc
                lblExpDesc.Visible = True
            End If
            If Not IsNothing(lblProductCode) Then
                lblProductCode.Text = DataBinder.Eval(e.Item.DataItem, "ProductCode").ToString
            End If
            If Not IsNothing(lblUserPart) Then
                lblUserPart.Text = DataBinder.Eval(e.Item.DataItem, "EndUserPart").ToString
            End If
            If Not IsNothing(lblPart) Then
                lblPart.Text = DataBinder.Eval(e.Item.DataItem, "CustomerPart").ToString
            End If
        End If
    End Sub

    Protected Sub Unnamed_ServerClick4(sender As Object, e As EventArgs)
        If rdbEXP.Checked = True Then
            selectProuctCode_Exp()
        ElseIf rdbIMP.Checked = True Then
            selectProuctCode_Imp()
        End If
    End Sub

    Private Sub selectProuctCode_Exp()

        Dim exp = (From p In db.tblProductDetails Where p.ProductCode = txtProductCode.Value.Trim And p.ExpProductCode <> ""
                  Select p.ProductCode, p.ExpDesc1, p.ImpDesc1, p.EndUserPart, p.CustomerPart).ToList
        If exp.Count > 0 Then
            Me.dgvProduct.DataSource = exp
            Me.dgvProduct.DataBind()
            ScriptManager.RegisterStartupScript(upProduct, upProduct.GetType(), "show", "$(function () { $('#" + plProduct.ClientID + "').modal('show'); });", True)
            upProduct.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล ProductCode นี้')", True)
            Exit Sub
        End If
    End Sub
    Private Sub selectProuctCode_Imp()

        Dim exp = (From p In db.tblProductDetails Where p.ProductCode = txtProductCode.Value.Trim And p.ImpProductCode <> ""
                  Select p.ProductCode, p.ExpDesc1, p.ImpDesc1, p.EndUserPart, p.CustomerPart).ToList
        If exp.Count > 0 Then
            Me.dgvProduct.DataSource = exp
            Me.dgvProduct.DataBind()
            ScriptManager.RegisterStartupScript(upProduct, upProduct.GetType(), "show", "$(function () { $('#" + plProduct.ClientID + "').modal('show'); });", True)
            upProduct.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล ProductCode นี้')", True)
            Exit Sub
        End If
    End Sub

    Protected Sub dgvItemDetail_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPull As Label = CType(e.Item.FindControl("lblPull"), Label)
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblItemNo As Label = CType(e.Item.FindControl("lblItemNo"), Label)
            Dim lblProduct As Label = CType(e.Item.FindControl("lblProduct"), Label)
            Dim lblPart As Label = CType(e.Item.FindControl("lblPart"), Label)
            Dim lblDesc As Label = CType(e.Item.FindControl("lblDesc"), Label)
            Dim lblPn As Label = CType(e.Item.FindControl("lblPn"), Label)
            Dim lblLot As Label = CType(e.Item.FindControl("lblLot"), Label)
                                                     
            If Not IsNothing(lblPull) Then
                lblPull.Text = DataBinder.Eval(e.Item.DataItem, "PullSignal").ToString
            End If
            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblItemNo) Then
                lblItemNo.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString
            End If
            If Not IsNothing(lblProduct) Then
                lblProduct.Text = DataBinder.Eval(e.Item.DataItem, "ProductNo").ToString
            End If
            If Not IsNothing(lblPart) Then
                lblPart.Text = DataBinder.Eval(e.Item.DataItem, "CutomerPart").ToString
            End If
            If Not IsNothing(lblDesc) Then
                lblDesc.Text = DataBinder.Eval(e.Item.DataItem, "OwnerPart").ToString
            End If         
            If Not IsNothing(lblPn) Then
                lblPn.Text = DataBinder.Eval(e.Item.DataItem, "OrderNo").ToString
            End If
            If Not IsNothing(lblLot) Then
                lblLot.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLot").ToString
            End If
        End If
    End Sub
    Private Sub ReadDataRequestedISSUE()

        Dim imp = (From i In db.tblWHRequestedISSUEs Where i.LotNo = txtLOtNo.Value.Trim And i.PullSignal = txtPullSignal.Value.Trim Order By i.ItemNo1 Ascending
                  Select i.PullSignal, i.LotNo, i.ItemNo, i.ProductNo, i.CutomerPart, i.OwnerPart, i.OrderNo, i.CustomerLot).ToList
        If imp.Count > 0 Then
            Me.dgvImported.DataSource = imp
            Me.dgvImported.DataBind()
        Else
            Me.dgvImported.DataSource = Nothing
            Me.dgvImported.DataBind()
        End If
    End Sub
    Private Sub ReadDataRequestedISSUE_PickPack()

        Dim imp = (From i In db.tblWHRequestedISSUEs Where i.LotNo = txtLOtNo.Value.Trim And i.PullSignal = txtPullSignal.Value.Trim And i.AvailableRequestQTY <> 0 Order By i.ItemNo1 Ascending
                 Select i.PullSignal, i.LotNo, i.ItemNo, i.ProductNo, i.CutomerPart, i.OwnerPart, i.OrderNo, i.CustomerLot).ToList
        If imp.Count > 0 Then
            Me.dgvReadWHIssuedRequest.DataSource = imp
            Me.dgvReadWHIssuedRequest.DataBind()
            Me.dgvReadWHIssuedRequestNJR.DataSource = imp
            Me.dgvReadWHIssuedRequestNJR.DataBind()
            Me.dgvReadAssign.DataSource = imp
            Me.dgvReadAssign.DataBind()

            FormatDgvReadWHIssuedRequest()
            FormatDgvReadWHIssuedRequestNJR()
            FormatDgvReadAssign()
        Else
            dgvReadWHIssuedRequest.DataSource = Nothing
            dgvReadWHIssuedRequestNJR.DataSource = Nothing
            dgvReadAssign.DataSource = Nothing
        End If

    End Sub
    Private Sub ClearDataHead()
        txtPullSignal.Value = ""
        txtLOtNo.Value = ""
        txtExporterCode.Value = ""
        txtExportEng.Value = ""
        txtExporterAddress1.Value = ""
        txtExporterAddress2.Value = ""
        txtExporterAddress3.Value = ""
        txtExporterAddress4.Value = ""
        txtConsignneeCode.Value = ""
        txtConsignneeEng.Value = ""
        txtConsignneeAddress1.Value = ""
        txtConsignneeAddress2.Value = ""
        txtConsignneeAddress3.Value = ""
        txtConsignneeAddress4.Value = ""
        txtOwnerCode.Value = ""
        txtOwnerName.Value = ""
        txtOwnerAddress1.Value = ""
        txtOwnerAddress2.Value = ""
        txtOwnerAddress3.Value = ""
        txtOwnerAddress4.Value = ""
        txtShipToCode.Value = ""
        txtShiptoName.Value = ""
        txtShiptoAddress1.Value = ""
        txtShiptoAddress2.Value = ""
        txtShiptoAddress3.Value = ""
        txtShiptoAddress4.Value = ""
        txtQuantityofPart.Value = "0.0"
        txtQuantityPackage.Value = "0.0"
        txtQuantityPLT.Value = "0.0"
        txtWeight.Value = "0.0"
        txtVolume.Value = "0.0"
        txtQtyReceived.Value = "0.0"
        txtQTYDiscrepancy.Value = "0.0"
        txtRemark_PickingHead.Value = ""
    End Sub

    Private Sub ClearDataPull()
        txtItemNo.Value = ""
        txtProductCode.Value = ""
        txtCustomerPart.Value = ""
        txtOwnerPart.Value = ""
        txtProductDesc.Value = ""
        txtRequestedQuantity.Value = "0.0"
        txtOrder.Value = ""
        txtPriceForeigh.Value = "0.0"
        txtPriceBath.Value = "0.0"
        'txtDirectorySEQ = ""
        'txtDirectoryDetail = ""
        'txtImportPallet = ""
        'txtImport = ""
        'txtDirecShip = ""
        txtCustomerLot.Value = ""
        txtPalletNoAssign.Value = ""
        txtOrderFrmOnline.Value = ""
        txtCustFrmOnline.Value = ""
    End Sub

    Private Sub FormatDgvReadWHIssuedRequest()
        'With dgvReadWHIssuedRequest
        '    If .RowCount > 0 Then
        '        .Columns(0).HeaderText = "PullSignal"
        '        .Columns(1).HeaderText = "LotNo"
        '        .Columns(2).HeaderText = "ItemNo"
        '        .Columns(3).HeaderText = "ProductNo"
        '        .Columns(4).HeaderText = "CutomerPart"
        '        .Columns(5).HeaderText = "OwnerPart"
        '        .Columns(6).HeaderText = "ProductDesc"
        '        .Columns(7).HeaderText = "RequestQTY"
        '        .Columns(8).HeaderText = "QTYUnit"
        '        .Columns(9).HeaderText = "OrderNo"
        '        .Columns(10).HeaderText = "CustomerLot"
        '        .Columns(11).HeaderText = "ManuFacturingDate"
        '        .Columns(12).HeaderText = "ExpireDate"

        '        .Columns(0).Width = 100
        '        .Columns(1).Width = 100
        '        .Columns(2).Width = 100
        '        .Columns(3).Width = 100
        '        .Columns(4).Width = 100
        '        .Columns(5).Width = 100
        '        .Columns(6).Width = 200
        '        .Columns(7).Width = 100
        '        .Columns(8).Width = 100
        '        .Columns(9).Width = 100
        '        .Columns(10).Width = 100
        '        .Columns(11).Width = 100
        '        .Columns(12).Width = 100


        '        .Columns(0).ReadOnly = True
        '        .Columns(1).ReadOnly = True
        '        .Columns(2).ReadOnly = True
        '        .Columns(3).ReadOnly = True
        '        .Columns(4).ReadOnly = True
        '        .Columns(5).ReadOnly = True
        '        .Columns(6).ReadOnly = True
        '        .Columns(7).ReadOnly = True
        '        .Columns(8).ReadOnly = True
        '        .Columns(9).ReadOnly = True
        '        .Columns(10).ReadOnly = True
        '        .Columns(11).ReadOnly = True
        '        .Columns(12).ReadOnly = True


        '    End If
        'End With
    End Sub

    Private Sub FormatDgvReadAssign()
        'With dgvReadAssign
        '    If .RowCount > 0 Then
        '        .Columns(0).HeaderText = "PullSignal"
        '        .Columns(1).HeaderText = "LotNo"
        '        .Columns(2).HeaderText = "ItemNo"
        '        .Columns(3).HeaderText = "ProductNo"
        '        .Columns(4).HeaderText = "CutomerPart"
        '        .Columns(5).HeaderText = "OwnerPart"
        '        .Columns(6).HeaderText = "ProductDesc"
        '        .Columns(7).HeaderText = "RequestQTY"
        '        .Columns(8).HeaderText = "QTYUnit"
        '        .Columns(9).HeaderText = "OrderNo"
        '        .Columns(10).HeaderText = "CustomerLot"
        '        .Columns(11).HeaderText = "ManuFacturingDate"
        '        .Columns(12).HeaderText = "ExpireDate"
        '        '.Columns(13).HeaderText = "OrderFrmOnline"
        '        '.Columns(14).HeaderText = "CustFrmOnline"

        '        .Columns(0).Width = 100
        '        .Columns(1).Width = 100
        '        .Columns(2).Width = 100
        '        .Columns(3).Width = 100
        '        .Columns(4).Width = 100
        '        .Columns(5).Width = 100
        '        .Columns(6).Width = 200
        '        .Columns(7).Width = 100
        '        .Columns(8).Width = 100
        '        .Columns(9).Width = 100
        '        .Columns(10).Width = 100
        '        .Columns(11).Width = 100
        '        .Columns(12).Width = 100
        '        '.Columns(13).Width = 100
        '        '.Columns(14).Width = 100

        '        .Columns(0).ReadOnly = True
        '        .Columns(1).ReadOnly = True
        '        .Columns(2).ReadOnly = True
        '        .Columns(3).ReadOnly = True
        '        .Columns(4).ReadOnly = True
        '        .Columns(5).ReadOnly = True
        '        .Columns(6).ReadOnly = True
        '        .Columns(7).ReadOnly = True
        '        .Columns(8).ReadOnly = True
        '        .Columns(9).ReadOnly = True
        '        .Columns(10).ReadOnly = True
        '        .Columns(11).ReadOnly = True
        '        .Columns(12).ReadOnly = True
        '        '.Columns(13).ReadOnly = True
        '        '.Columns(14).ReadOnly = True

        '    End If
        'End With
    End Sub

    Private Sub FormatDgvReadWHIssuedRequestNJR()
        'With dgvReadWHIssuedRequestNJR
        '    If .RowCount > 0 Then
        '        .Columns(0).HeaderText = "PullSignal"
        '        .Columns(1).HeaderText = "LotNo"
        '        .Columns(2).HeaderText = "ItemNo"
        '        .Columns(3).HeaderText = "ProductNo"
        '        .Columns(4).HeaderText = "CutomerPart"
        '        .Columns(5).HeaderText = "OwnerPart"
        '        .Columns(6).HeaderText = "ProductDesc"
        '        .Columns(7).HeaderText = "RequestQTY"
        '        .Columns(8).HeaderText = "QTYUnit"
        '        .Columns(9).HeaderText = "OrderNo"
        '        .Columns(10).HeaderText = "CustomerLot"
        '        .Columns(11).HeaderText = "ManuFacturingDate"
        '        .Columns(12).HeaderText = "ExpireDate"


        '        .Columns(0).Width = 100
        '        .Columns(1).Width = 100
        '        .Columns(2).Width = 100
        '        .Columns(3).Width = 100
        '        .Columns(4).Width = 100
        '        .Columns(5).Width = 100
        '        .Columns(6).Width = 200
        '        .Columns(7).Width = 100
        '        .Columns(8).Width = 100
        '        .Columns(9).Width = 100
        '        .Columns(10).Width = 100
        '        .Columns(11).Width = 100
        '        .Columns(12).Width = 100



        '        .Columns(0).ReadOnly = True
        '        .Columns(1).ReadOnly = True
        '        .Columns(2).ReadOnly = True
        '        .Columns(3).ReadOnly = True
        '        .Columns(4).ReadOnly = True
        '        .Columns(5).ReadOnly = True
        '        .Columns(6).ReadOnly = True
        '        .Columns(7).ReadOnly = True
        '        .Columns(8).ReadOnly = True
        '        .Columns(9).ReadOnly = True
        '        .Columns(10).ReadOnly = True
        '        .Columns(11).ReadOnly = True
        '        .Columns(12).ReadOnly = True


        '    End If
        'End With
    End Sub

    Protected Sub btnSaveNew_AssignDetail_ServerClick(sender As Object, e As EventArgs)
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        If classPermis.CheckSave(form, usename) = True Then
            SaveRequestedISSUE_New()
            ReadDataRequestedISSUE()
            ReadDataRequestedISSUE_PickPack()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์บันทึก ในเมนูนี้ !!!')", True)
        End If
    End Sub
    Private Sub SaveRequestedISSUE_New()
        Dim ManufacturingDate As Nullable(Of Date)
        Dim ExpiredDate As Nullable(Of Date)
        Dim RequestedQuantity As String
        Dim PriceForeigh As String
        Dim PriceBath As String
        If txtLOtNo.Value.Trim() = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ LOT NO ก่อน !!!')", True)
            txtLOtNo.Focus()
            Exit Sub
        End If

        If txtPullSignal.Value.Trim() = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Pull Signal ก่อน !!!')", True)
            txtPullSignal.Focus()
            Exit Sub
        End If

        If txtItemNo.Value.Trim() = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Item No ก่อน !!!')", True)
            txtItemNo.Focus()
            Exit Sub
        End If
        If chkNotUseDate_AssignDetail.Checked = False Then         
            ManufacturingDate = DateTime.ParseExact(txtdatepickerManufacturing_AssignDetail.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
            ExpiredDate = DateTime.ParseExact(txtdatepickerExpiredDate_AssignDetail.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        ElseIf chkNotUseDate_AssignDetail.Checked = True Then
            ManufacturingDate = Nothing
            ExpiredDate = Nothing
        End If
        If String.IsNullOrEmpty(txtRequestedQuantity.Value.Trim) Then
            RequestedQuantity = "0.0"
        Else
            RequestedQuantity = txtRequestedQuantity.Value.Trim
        End If
        If String.IsNullOrEmpty(txtPriceForeigh.Value.Trim) Then
            PriceForeigh = "0.0"
        Else
            PriceForeigh = txtPriceForeigh.Value.Trim
        End If
        If String.IsNullOrEmpty(txtPriceBath.Value.Trim) Then
            PriceBath = "0.0"
        Else
            PriceBath = txtPriceBath.Value.Trim
        End If
       
        If MsgBox("คุณต้องการเพิ่มรายการ RequestedISSUE ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน") = MsgBoxResult.Yes Then

            Try
                db.tblWHRequestedISSUEs.Add(New tblWHRequestedISSUE With { _
                                    .PullSignal = txtPullSignal.Value.Trim, _
                                    .LotNo = txtLOtNo.Value.Trim, _
                                    .ItemNo = CInt(txtItemNo.Value.Trim), _
                                    .ProductNo = txtProductCode.Value.Trim, _
                                    .CutomerPart = txtCustomerPart.Value.Trim, _
                                    .OwnerPart = txtOwnerPart.Value.Trim, _
                                    .ProductDesc = txtProductDesc.Value.Trim, _
                                    .RequestQTY = CType(CDbl(RequestedQuantity).ToString("#,##0.000"), Double?), _
                                    .QTYUnit = cboRequestUnit.Text.Trim, _
                                    .OrderNo = txtOrder.Value.Trim, _
                                    .ManufacturingDate = ManufacturingDate, _
                                    .ExpiredDate = ExpiredDate, _
                                    .PriceForeigh = CType(CDbl(PriceForeigh).ToString("#,##0.0000"), Double?), _
                                    .PriceBath = CType(CDbl(PriceBath).ToString("#,##0.0000"), Double?), _
                                    .CustomerLot = txtCustomerLot.Value.Trim, _
                                    .CreateBy = CStr(Session("UserName")), _
                                    .CreateDate = Now, _
                                    .AvailableRequestQTY = CType(CDbl(RequestedQuantity).ToString("#,##0.000"), Double?), _
                                    .ItemNo1 = CType(txtItemNo.Value.Trim, Double?), _
                                    .PalletNo = txtPalletNoAssign.Value.Trim, _
                                    .OrderFrmOnline = txtOrderFrmOnline.Value.Trim, _
                                    .CustFrmOnline = txtCustFrmOnline.Value.Trim
                                            })
                db.SaveChanges()
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('บันทึก RequestedISSUE เรียบร้อยแล้ว !!!')", True)
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('" & ex.Message & "')", True)
            End Try
        End If
        txtItemNo.Focus()
    End Sub

    Protected Sub dgvReadAssign_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPull As Label = CType(e.Item.FindControl("lblPull"), Label)
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblItemNo As Label = CType(e.Item.FindControl("lblItemNo"), Label)
            Dim lblProduct As Label = CType(e.Item.FindControl("lblProduct"), Label)
            Dim lblPart As Label = CType(e.Item.FindControl("lblPart"), Label)
            Dim lblDesc As Label = CType(e.Item.FindControl("lblDesc"), Label)
            Dim lblPn As Label = CType(e.Item.FindControl("lblPn"), Label)
            Dim lblLot As Label = CType(e.Item.FindControl("lblLot"), Label)

            If Not IsNothing(lblPull) Then
                lblPull.Text = DataBinder.Eval(e.Item.DataItem, "PullSignal").ToString
            End If
            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblItemNo) Then
                lblItemNo.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString
            End If
            If Not IsNothing(lblProduct) Then
                lblProduct.Text = DataBinder.Eval(e.Item.DataItem, "ProductNo").ToString
            End If
            If Not IsNothing(lblPart) Then
                lblPart.Text = DataBinder.Eval(e.Item.DataItem, "CutomerPart").ToString
            End If
            If Not IsNothing(lblDesc) Then
                lblDesc.Text = DataBinder.Eval(e.Item.DataItem, "OwnerPart").ToString
            End If
            If Not IsNothing(lblPn) Then
                lblPn.Text = DataBinder.Eval(e.Item.DataItem, "OrderNo").ToString
            End If
            If Not IsNothing(lblLot) Then
                lblLot.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLot").ToString
            End If
        End If
    End Sub

    Protected Sub dgvReadWHIssuedRequestNJR_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPull As Label = CType(e.Item.FindControl("lblPull"), Label)
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblItemNo As Label = CType(e.Item.FindControl("lblItemNo"), Label)
            Dim lblProduct As Label = CType(e.Item.FindControl("lblProduct"), Label)
            Dim lblPart As Label = CType(e.Item.FindControl("lblPart"), Label)
            Dim lblDesc As Label = CType(e.Item.FindControl("lblDesc"), Label)
            Dim lblPn As Label = CType(e.Item.FindControl("lblPn"), Label)
            Dim lblLot As Label = CType(e.Item.FindControl("lblLot"), Label)

            If Not IsNothing(lblPull) Then
                lblPull.Text = DataBinder.Eval(e.Item.DataItem, "PullSignal").ToString
            End If
            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblItemNo) Then
                lblItemNo.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString
            End If
            If Not IsNothing(lblProduct) Then
                lblProduct.Text = DataBinder.Eval(e.Item.DataItem, "ProductNo").ToString
            End If
            If Not IsNothing(lblPart) Then
                lblPart.Text = DataBinder.Eval(e.Item.DataItem, "CutomerPart").ToString
            End If
            If Not IsNothing(lblDesc) Then
                lblDesc.Text = DataBinder.Eval(e.Item.DataItem, "OwnerPart").ToString
            End If
            If Not IsNothing(lblPn) Then
                lblPn.Text = DataBinder.Eval(e.Item.DataItem, "OrderNo").ToString
            End If
            If Not IsNothing(lblLot) Then
                lblLot.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLot").ToString
            End If
        End If
    End Sub

    Protected Sub dgvReadWHIssuedRequest_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPull As Label = CType(e.Item.FindControl("lblPull"), Label)
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblItemNo As Label = CType(e.Item.FindControl("lblItemNo"), Label)
            Dim lblProduct As Label = CType(e.Item.FindControl("lblProduct"), Label)
            Dim lblPart As Label = CType(e.Item.FindControl("lblPart"), Label)
            Dim lblDesc As Label = CType(e.Item.FindControl("lblDesc"), Label)
            Dim lblPn As Label = CType(e.Item.FindControl("lblPn"), Label)
            Dim lblLot As Label = CType(e.Item.FindControl("lblLot"), Label)

            If Not IsNothing(lblPull) Then
                lblPull.Text = DataBinder.Eval(e.Item.DataItem, "PullSignal").ToString
            End If
            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblItemNo) Then
                lblItemNo.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString
            End If
            If Not IsNothing(lblProduct) Then
                lblProduct.Text = DataBinder.Eval(e.Item.DataItem, "ProductNo").ToString
            End If
            If Not IsNothing(lblPart) Then
                lblPart.Text = DataBinder.Eval(e.Item.DataItem, "CutomerPart").ToString
            End If
            If Not IsNothing(lblDesc) Then
                lblDesc.Text = DataBinder.Eval(e.Item.DataItem, "OwnerPart").ToString
            End If
            If Not IsNothing(lblPn) Then
                lblPn.Text = DataBinder.Eval(e.Item.DataItem, "OrderNo").ToString
            End If
            If Not IsNothing(lblLot) Then
                lblLot.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLot").ToString
            End If
        End If
    End Sub

    Protected Sub chkpull_CheckedChanged(sender As Object, e As EventArgs)
        Dim chkName As CheckBox
        Dim lblLOTNo As String
        Dim lblPull As String
        Dim i As Integer
        Dim ManufacturingDate As Nullable(Of Date)
        Dim ExpiredDate As Nullable(Of Date)
        For i = 0 To dgvImported.Items.Count - 1
            chkName = CType(dgvImported.Items(i).FindControl("chkpull"), CheckBox)
            lblLOTNo = CType(dgvImported.Items(i).FindControl("lblLOTNo"), Label).Text.Trim
            lblPull = CType(dgvImported.Items(i).FindControl("lblPull"), Label).Text.Trim
            If chkName.Checked = True Then

                Dim imp = (From im In db.tblWHRequestedISSUEs Where im.LotNo = lblLOTNo And im.PullSignal = lblPull
                          Select im).FirstOrDefault
                If imp IsNot Nothing Then
                    If Not IsNothing(imp.ManufacturingDate) Then
                        ManufacturingDate = imp.ManufacturingDate
                    Else
                        ManufacturingDate = Date.Now
                    End If
                    If Not IsNothing(imp.ExpiredDate) Then
                        ExpiredDate = imp.ExpiredDate
                    Else
                        ExpiredDate = Date.Now
                    End If
                    txtItemNo.Value = CStr(imp.ItemNo)
                    txtProductCode.Value = imp.ProductNo
                    txtCustomerPart.Value = String.Format("{0:0.00}", imp.CutomerPart)
                    txtOwnerPart.Value = imp.OwnerPart
                    txtProductDesc.Value = imp.ProductDesc
                    txtRequestedQuantity.Value = String.Format("{0:0.00}", imp.RequestQTY)
                    If Not IsNothing(imp.QTYUnit) Then
                        cboRequestUnit.Text = imp.QTYUnit
                    End If
                    txtOrder.Value = imp.OrderNo
                    txtPriceForeigh.Value = String.Format("{0:0.00}", imp.PriceForeigh)
                    txtPriceBath.Value = String.Format("{0:0.00}", imp.PriceBath)
                    txtCustomerLot.Value = imp.CustomerLot
                    txtdatepickerExpiredDate_AssignDetail.Text = Convert.ToDateTime(ManufacturingDate).ToString("dd/MM/yyyy")
                    txtdatepickerManufacturing_AssignDetail.Text = Convert.ToDateTime(ExpiredDate).ToString("dd/MM/yyyy")
                    txtAvailableQuantity.Value = String.Format("{0:0.00}", imp.AvailableRequestQTY)
                    txtPalletNoAssign.Value = imp.PalletNo
                    txtOrderFrmOnline.Value = imp.OrderFrmOnline
                    txtCustFrmOnline.Value = imp.CustFrmOnline

                End If
            End If
        Next
    End Sub

    Protected Sub btnSaveModify_AssignDetail_ServerClick(sender As Object, e As EventArgs)

        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        If classPermis.CheckEdit(form, usename) = True Then
            SaveRequestedISSUE_Edit()
            ReadDataRequestedISSUE()
            ReadDataRequestedISSUE_PickPack()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์แก้ไข ในเมนูนี้ !!!')", True)
        End If
    End Sub
    Private Sub SaveRequestedISSUE_Edit()
        Dim ManufacturingDate As Nullable(Of Date)
        Dim ExpiredDate As Nullable(Of Date)
        Dim RequestedQuantity As String
        Dim PriceForeigh As String
        Dim PriceBath As String
        Dim ItemNo As Integer
        If txtLOtNo.Value.Trim() = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ LOT NO ก่อน !!!')", True)
            txtLOtNo.Focus()
            Exit Sub
        End If

        If txtPullSignal.Value.Trim() = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Pull Signal ก่อน !!!')", True)
            txtPullSignal.Focus()
            Exit Sub
        End If

        If txtItemNo.Value.Trim() = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Item No ก่อน !!!')", True)
            txtItemNo.Focus()
            Exit Sub
        End If
        If chkNotUseDate_AssignDetail.Checked = False Then
            ManufacturingDate = DateTime.ParseExact(txtdatepickerManufacturing_AssignDetail.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
            ExpiredDate = DateTime.ParseExact(txtdatepickerExpiredDate_AssignDetail.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        ElseIf chkNotUseDate_AssignDetail.Checked = True Then
            ManufacturingDate = Nothing
            ExpiredDate = Nothing
        End If
        If String.IsNullOrEmpty(txtRequestedQuantity.Value.Trim) Then
            RequestedQuantity = "0.0"
        Else
            RequestedQuantity = txtRequestedQuantity.Value.Trim
        End If
        If String.IsNullOrEmpty(txtPriceForeigh.Value.Trim) Then
            PriceForeigh = "0.0"
        Else
            PriceForeigh = txtPriceForeigh.Value.Trim
        End If
        If String.IsNullOrEmpty(txtPriceBath.Value.Trim) Then
            PriceBath = "0.0"
        Else
            PriceBath = txtPriceBath.Value.Trim
        End If
        ItemNo = CInt(txtItemNo.Value.Trim)
        If MsgBox("คุณต้องการแก้ไขรายการ RequestedISSUE ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน") = MsgBoxResult.Yes Then

            Try
                Dim ei As tblWHRequestedISSUE = (From r In db.tblWHRequestedISSUEs Where r.PullSignal = txtPullSignal.Value.Trim And r.LotNo = txtLOtNo.Value.Trim And r.ItemNo = ItemNo).SingleOrDefault
                If ei IsNot Nothing Then
                    ei.PullSignal = txtPullSignal.Value.Trim
                    ei.LotNo = txtLOtNo.Value.Trim
                    ei.ItemNo = CInt(txtItemNo.Value.Trim)
                    ei.ProductNo = txtProductCode.Value.Trim
                    ei.CutomerPart = txtCustomerPart.Value.Trim
                    ei.OwnerPart = txtOwnerPart.Value.Trim
                    ei.ProductDesc = txtProductDesc.Value.Trim
                    ei.RequestQTY = CType(CDbl(RequestedQuantity).ToString("#,##0.000"), Double?)
                    ei.QTYUnit = cboRequestUnit.Text.Trim
                    ei.OrderNo = txtOrder.Value.Trim
                    ei.ManufacturingDate = ManufacturingDate
                    ei.ExpiredDate = ExpiredDate
                    ei.PriceForeigh = CType(CDbl(PriceForeigh).ToString("#,##0.0000"), Double?)
                    ei.PriceBath = CType(CDbl(PriceBath).ToString("#,##0.0000"), Double?)
                    ei.CustomerLot = txtCustomerLot.Value.Trim
                    ei.CreateBy = CStr(Session("UserName"))
                    ei.CreateDate = Now
                    ei.AvailableRequestQTY = CType(CDbl(RequestedQuantity).ToString("#,##0.000"), Double?)
                    ei.ItemNo1 = CType(txtItemNo.Value.Trim, Double?)
                    ei.PalletNo = txtPalletNoAssign.Value.Trim
                    ei.OrderFrmOnline = txtOrderFrmOnline.Value.Trim
                    ei.CustFrmOnline = txtCustFrmOnline.Value.Trim
                    db.SaveChanges()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล RequestedISSUE เรียบร้อยแล้ว !!!')", True)
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('RequestedISSUE ที่คุณใส่ ไม่ถูกต้อง !!!')", True)
                End If
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('" & ex.Message & "')", True)
            End Try
        End If
        txtItemNo.Focus()
    End Sub
    Private Sub ReadDataComfrimGoods()
        Dim Site As String = ""
        Dim CustomerLOTNo_ As String = ""
        Dim ENDc As String = ""
        Dim Ow As String = ""
        If rdbSpecific.Checked = True And chkSCRAP.Checked = False Then
            If rdbSpecific.Checked = True Then
                Site = dcbSite.Text.Trim
                CustomerLOTNo_ = txtCUL.Value.Trim()
            Else
                Site = dcbSite.Text.Trim
                CustomerLOTNo_ = txtCUL.Value.Trim()
                ENDc = txtENDCustomer.Value.Trim
                Ow = txtOW.Value.Trim
            End If
            Dim sqlSearchInvoice = (From c In db.tblWHConfirmGoodsReceiveDetails Join pd In db.tblProductDetails On c.ProductCode Equals pd.ProductCode _
                 And c.OwnerPN Equals pd.CustomerPart Where ((c.WHSite = Site And c.OwnerPN = Owner And c.ProductCode = ProductNo And c.CustomerLOTNo = CustomerLOTNo_) _
                 Or (c.WHSite = Site And c.OwnerPN = Ow And c.ProductCode = ProductNo And c.CustomerLOTNo = CustomerLOTNo_ And c.ENDCustomer = ENDc) _
                 And c.StatusAvailable = "0" And c.Type = "Goods Complete") Order By c.ReceiveDate Ascending _
                 Select c.LOTNo, c.WHSite, c.CustomerLOTNo, c.ItemNo, c.ProductCode, c.CustomerPN, c.OwnerPN, c.Quantity).ToList

            If sqlSearchInvoice.Count > 0 Then
                dgvReadWHIssuedDetail.DataSource = sqlSearchInvoice
                dgvReadWHIssuedDetail.DataBind()

            Else
                dgvReadWHIssuedDetail.DataSource = Nothing
                dgvReadWHIssuedDetail.DataBind()
            End If

        ElseIf rdbSpecific.Checked = True And chkSCRAP.Checked = True Then
            Dim sqlSearchInvoice = (From c In db.tblWHConfirmGoodsReceiveDetails Join pd In db.tblProductDetails On c.ProductCode Equals pd.ProductCode And c.OwnerPN Equals pd.CustomerPart _
            Where c.WHSite = dcbSite.Text.Trim And c.OwnerPN = txtOW.Value.Trim And c.ProductCode = ProductNo And c.StatusAvailable = "0" And c.Type = "Goods Complete" _
            And c.WHLocation.Contains(txtCUL.Value.Trim) And c.TypeDamage = "Q-SCRAP" Order By c.ReceiveDate Ascending _
            Select c.LOTNo, c.WHSite, c.CustomerLOTNo, c.ItemNo, c.ProductCode, c.CustomerPN, c.OwnerPN, c.Quantity).ToList
            If sqlSearchInvoice.Count > 0 Then
                dgvReadWHIssuedDetail.DataSource = sqlSearchInvoice
                dgvReadWHIssuedDetail.DataBind()

            Else
                dgvReadWHIssuedDetail.DataSource = Nothing
                dgvReadWHIssuedDetail.DataBind()
            End If
        ElseIf rdbOwner.Checked = True Then
            If rcbFIFO.Checked = True Then
                Site = dcbSite.Text.Trim
            ElseIf rcbLIFO.Checked = True Then
                Site = dcbSite.Text.Trim
            End If
            Dim sqlSearchInvoice = (From c In db.tblWHConfirmGoodsReceiveDetails Join pd In db.tblProductDetails On c.ProductCode Equals pd.ProductCode And c.OwnerPN Equals pd.CustomerPart _
           Where (c.WHSite = Site And c.OwnerPN = Owner And c.ProductCode = ProductNo And c.StatusAvailable = "0" And c.Type = "Goods Complete")
           Order By c.ReceiveDate Ascending Select c.LOTNo, c.WHSite, c.CustomerLOTNo, c.ItemNo, c.ProductCode, c.CustomerPN, c.OwnerPN, c.Quantity).ToList

            If sqlSearchInvoice.Count > 0 Then
                dgvReadWHIssuedDetail.DataSource = sqlSearchInvoice
                dgvReadWHIssuedDetail.DataBind()

            Else
                dgvReadWHIssuedDetail.DataSource = Nothing
                dgvReadWHIssuedDetail.DataBind()
            End If
        End If  
        SumQTYCanPick()
    End Sub

    Protected Sub dgvReadWHIssuedDetail_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblSite As Label = CType(e.Item.FindControl("lblSite"), Label)
            'Dim lblLocation As Label = CType(e.Item.FindControl("lblLocation"), Label)
            Dim lblCustomer As Label = CType(e.Item.FindControl("lblCustomer"), Label)
            'Dim lblSource As Label = CType(e.Item.FindControl("lblSource"), Label)
            Dim lblItemNo As Label = CType(e.Item.FindControl("lblItemNo"), Label)
            Dim lblPn As Label = CType(e.Item.FindControl("lblPn"), Label)
            Dim lblProduct As Label = CType(e.Item.FindControl("lblProduct"), Label)
            Dim lblOwner As Label = CType(e.Item.FindControl("lblOwner"), Label)
            Dim lblEntry As Label = CType(e.Item.FindControl("lblEntry"), Label)

            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblSite) Then
                lblSite.Text = DataBinder.Eval(e.Item.DataItem, "WHSite").ToString
            End If
            'If Not IsNothing(lblLocation) Then
            '    lblLocation.Text = DataBinder.Eval(e.Item.DataItem, "WHLocation").ToString
            'End If
            If Not IsNothing(lblCustomer) Then
                lblCustomer.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLOTNo").ToString
            End If
            'If Not IsNothing(lblSource) Then
            '    lblSource.Text = DataBinder.Eval(e.Item.DataItem, "WHSource").ToString
            'End If
            If Not IsNothing(lblItemNo) Then
                lblItemNo.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString
            End If

            If Not IsNothing(lblProduct) Then
                lblProduct.Text = DataBinder.Eval(e.Item.DataItem, "ProductCode").ToString
            End If
            If Not IsNothing(lblPn) Then
                lblPn.Text = DataBinder.Eval(e.Item.DataItem, "CustomerPN").ToString
            End If
            If Not IsNothing(lblOwner) Then
                lblOwner.Text = DataBinder.Eval(e.Item.DataItem, "OwnerPN").ToString
            End If

            If Not IsNothing(lblEntry) Then
                lblEntry.Text = DataBinder.Eval(e.Item.DataItem, "Quantity").ToString
            End If
        End If
    End Sub
    Private Sub SumQTYCanPick()
        Dim i As Integer
        Dim Available As Double
        Dim Quantity As Double
        For i = 0 To dgvReadWHIssuedDetail.Items.Count - 1
            Quantity = CDbl(CType(dgvReadWHIssuedDetail.Items(i).FindControl("lblEntry"), Label).Text.Trim)

            Available = Available + Quantity
        Next
        txtSumQTYPick1.Value = CStr(Available)
    End Sub

    Protected Sub chkpull_Issud_CheckedChanged(sender As Object, e As EventArgs)
        Dim chkName As CheckBox
        Dim lblLOTNo As String
        Dim i As Integer
        For i = 0 To dgvReadWHIssuedRequest.Items.Count - 1
            chkName = CType(dgvReadWHIssuedRequest.Items(i).FindControl("chkpull_Issud"), CheckBox)
            lblLOTNo = CType(dgvReadWHIssuedRequest.Items(i).FindControl("lblLOTNo"), Label).Text.Trim
            Dim lblPull As String = CType(dgvReadWHIssuedRequest.Items(i).FindControl("lblPull"), Label).Text.Trim
            If chkName.Checked = True Then
                Dim imp = (From im In db.tblWHRequestedISSUEs Where im.LotNo = lblLOTNo And im.PullSignal = lblPull
                          Select im).FirstOrDefault
                ProductNo = imp.ProductNo
                Owner = imp.OwnerPart
                CustomerLots = imp.CustomerLot
                'ManufacturingDates = .Rows.Item(e.RowIndex).Cells(11).Value.ToString()
                'ExpiredDates = .Rows.Item(e.RowIndex).Cells(12).Value.ToString()
                RowRequest1 = imp.ItemNo
                zInvoice = imp.OrderNo
                QtyRequest = CDbl(CDbl(imp.AvailableRequestQTY).ToString("#,##0.000"))
                OrderFrmOnline = imp.OrderFrmOnline
                CustFrmOnline = imp.CustFrmOnline

            End If
        Next
        ReadDataComfrimGoods()
    End Sub

    Protected Sub btnPick_ServerClick(sender As Object, e As EventArgs)
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        If classPermis.CheckSave(form, usename) = True Then
            If chkSCRAP.Checked = False Then
                SavePickDetail_New()
            Else

            End If
        End If
    End Sub
    Protected Sub chkLotNo_CheckedChanged(sender As Object, e As EventArgs)
        con = New ConfirmGoodsReceiveDetail
        Dim chkName As CheckBox
        For i = 0 To dgvReadWHIssuedDetail.Items.Count - 1
            chkName = CType(dgvReadWHIssuedDetail.Items(i).FindControl("chkLotNo"), CheckBox)
            Dim lblLOTNo As String = CType(dgvReadWHIssuedDetail.Items(i).FindControl("lblLOTNo"), Label).Text.Trim
            Dim lblItemNo As Integer = CInt(CType(dgvReadWHIssuedDetail.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
            Dim lblProduct As String = CType(dgvReadWHIssuedDetail.Items(i).FindControl("lblProduct"), Label).Text.Trim
            Dim lblOwner As String = CType(dgvReadWHIssuedDetail.Items(i).FindControl("lblOwner"), Label).Text.Trim

            If chkName.Checked = True Then
                Dim sI = (From c In db.tblWHConfirmGoodsReceiveDetails Join pds In db.tblProductDetails On c.ProductCode Equals pds.ProductCode And c.OwnerPN Equals pds.CustomerPart _
              Where c.LOTNo = lblLOTNo And c.OwnerPN = lblOwner And c.ProductCode = lblProduct And c.ItemNo = lblItemNo And c.StatusAvailable = "0" And c.Type = "Goods Complete").FirstOrDefault
                If sI IsNot Nothing Then

                    con.setLOTNo = sI.c.LOTNo
                    con.setWHSite = sI.c.WHSite
                    con.setWHLocation = sI.c.WHLocation
                    con.setENDCustomer = sI.c.ENDCustomer
                    con.setCustomerLOTNo = sI.c.CustomerLOTNo
                    con.setWHSource = sI.c.WHSource
                    con.setItemNo = CStr(sI.c.ItemNo)
                    con.setProductCode = sI.c.ProductCode
                    con.setCustomerPN = sI.c.CustomerPN
                    con.setOwnerPN = sI.c.OwnerPN
                    con.setProductDesc = sI.c.ProductDesc
                    con.setMeasurement = sI.c.Measurement
                    con.setProductWidth = CStr(sI.c.ProductWidth)
                    con.setProductLength = CStr(sI.c.ProductLength)
                    con.setProductHeight = CStr(sI.c.ProductHeight)
                    con.setProductVolume = CStr(sI.c.ProductVolume)
                    con.setOrderNo = sI.c.OrderNo
                    con.setReceiveNo = sI.c.ReceiveNo
                    con.setType = sI.c.Type
                    con.setQuantity = CStr(sI.c.Quantity)
                    con.setReceiveDate = CStr(sI.c.ReceiveDate)
                    con.setQuantityUnit = sI.c.QuantityUnit
                    con.setWeigth = CStr(sI.c.Weigth)
                    con.setWeigthUnit = sI.c.WeigthUnit
                    con.setCurrency = sI.c.Currency
                    con.setExchangeRate = CStr(sI.c.ExchangeRate)
                    con.setPriceForeigh = CStr(sI.c.PriceForeigh)
                    con.setPriceForeighAmount = CStr(sI.c.PriceForeighAmount)
                    con.setPriceBath = CStr(sI.c.PriceBath)
                    con.setPriceBathAmount = CStr(sI.c.PriceBathAmount)
                    con.setEntryNo = sI.c.EntryNo
                    con.setEntryItemNo = CStr(sI.c.EntryItemNo)
                    con.setManufacturingDate = CStr(sI.c.ManufacturingDate)
                    con.setExpiredDate = CStr(sI.c.ExpectedDate)

                    Session("LOTNo") = con.setLOTNo
                    Session("WHSite") = con.setWHSite
                    Session("WHLocation") = con.setWHLocation
                    Session("ENDCustomer") = con.setENDCustomer
                    Session("CustomerLOTNo") = con.setCustomerLOTNo
                    Session("WHSource") = con.setWHSource
                    Session("ItemNo") = con.setItemNo
                    Session("ProductCode") = con.setProductCode
                    Session("CustomerPN") = con.setCustomerPN
                    Session("OwnerPN") = con.setOwnerPN
                    Session("ProductDesc") = con.setProductDesc
                    Session("Measurement") = con.setMeasurement
                    Session("ProductWidth") = con.setProductWidth
                    Session("ProductLength") = con.setProductLength
                    Session("ProductHeight") = con.setProductHeight
                    Session("ProductVolume") = con.setProductVolume
                    Session("OrderNo") = con.setOrderNo
                    Session("ReceiveNo") = con.setReceiveNo
                    Session("Type") = con.setType
                    Session("Quantity") = con.setQuantity
                    Session("ReceiveDate") = con.setReceiveDate
                    Session("QuantityUnit") = con.setQuantityUnit
                    Session("Weigth") = con.setWeigth
                    Session("WeigthUnit") = con.setWeigthUnit
                    Session("Currency") = con.setCurrency
                    Session("ExchangeRate") = con.setExchangeRate
                    Session("PriceForeigh") = con.setPriceForeigh
                    Session("PriceForeighAmount") = con.setPriceForeighAmount
                    Session("PriceBath") = con.setPriceBath
                    Session("PriceBathAmount") = con.setPriceBathAmount
                    Session("EntryNo") = con.setEntryNo
                    Session("EntryItemNo") = con.setEntryItemNo
                    ManufacturingDate = con.setManufacturingDate
                    ExpiredDate = con.setExpiredDate
                End If
            End If
        Next
        txtQTYOfPick.Value = CStr(Session("Quantity"))
        ItemTotal = CDbl(con.setQuantity)
        ReadStockMovement()

    End Sub
    Private Sub ReadStockMovement()
        con = New ConfirmGoodsReceiveDetail
        Dim lotNo As String = CStr(Session("LOTNo"))
        Dim ItemNo As Integer = CInt(Session("ItemNo"))
        Dim clotNO As String = CStr(Session("CustomerLOTNo"))
        Dim owner As String = CStr(Session("OwnerPN"))
       
  
        Dim sb = (From s In db.tblWHStockMovements Where s.LOTNo = lotNo And s.ItemNo = ItemNo And s.OwnerPN = owner And s.CustomerLOTNo = clotNO Select s.ISSUEQuantity).FirstOrDefault
        If sb IsNot Nothing Then
            txtIssuedQTY.Value = String.Format("{0:0.00}", sb)
        End If
        If txtIssuedQTY.Value = "" Then
            txtIssuedQTY.Value = "0"
        End If

    End Sub
    Private Sub SavePickDetail_New()
        Dim i As Integer
        Dim chkName As CheckBox
        Dim itemmax As Integer
        Dim ProductWidth As Double
        Dim ProductLength As Double
        Dim ProductHeight As Double
        Dim ProductVolume As Double
        Dim Weigth As Double
        Dim ExchangeRate As Double
        Dim PriceForeigh As Double
        Dim PriceForeighAmount As Double
        Dim PriceBath As Double
        Dim PriceBathAmount As Double
        Dim ItemNo_ As Integer
        Dim md As Nullable(Of Date)
        Dim exDate As Nullable(Of Date)
        Dim EntryNo As String
        Dim EntryItemNo As Integer

        If txtLOtNo.Value.Trim = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ LOT NO ก่อน !!!')", True)
            txtLOtNo.Focus()
            Exit Sub
        ElseIf txtPullSignal.Value.Trim() = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Pull Signal ก่อน !!!')", True)
            txtPullSignal.Focus()
            Exit Sub

        Else
            If QtyRequest = 0 Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ยอดงาน ReQuest ที่ท่านเลือกได้ถูกทำการ Pick หมดแล้วครับ !!!')", True)
                txtQTYOfPick.Focus()
            End If
            If QtyRequest < CInt(txtQTYOfPick.Value) Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ยอดงานที่ท่านใส่มีจำนวนมากกว่าที่ Request ครับ !!!')", True)
                txtQTYOfPick.Focus()
            End If
            If CInt(txtQTYOfPick.Value) > CInt(Session("Quantity")) Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ยอดงานเกิน Available ครับ !!!')", True)
                txtQTYOfPick.Focus()
            End If
            Session("RecCount") = "0"
            Session("CheckRec") = "0"
            Session("RecCount") = dgvWHPickDetail.Items()
            Session("ItemCount") = CStr(CDbl(Session("RecCount")) + 1)

            Dim pd = (From p In db.tblWHPickingDetails Where p.PullSignal = txtPullSignal.Value.Trim And p.LOTNo = txtLOtNo.Value.Trim _
                  Group By p.ItemNo
                  Into Item = Max(p.ItemNo) Select Item).First
            If pd.ToString IsNot Nothing Then
                itemmax = CInt(pd) + 1
            Else
                itemmax = 1
            End If
            'If txtRManuFacturingDate.Text = "" Then
            '    .Parameters.Add("@ManufacturingDate", SqlDbType.DateTime).Value = DBNull.Value
            'Else
            '    .Parameters.Add("@ManufacturingDate", SqlDbType.DateTime).Value = txtRManuFacturingDate.Text.Trim()
            'End If
            'If txtRExpireDate.Text = "" Then
            '    .Parameters.Add("@ExpiredDate", SqlDbType.DateTime).Value = DBNull.Value
            'Else
            '    .Parameters.Add("@ExpiredDate", SqlDbType.DateTime).Value = txtRExpireDate.Text.Trim()
            'End If
            For i = 0 To dgvReadWHIssuedDetail.Items.Count - 1
                chkName = CType(dgvReadWHIssuedDetail.Items(i).FindControl("chkpull_Issud"), CheckBox)
                Dim lblLOTNo As String = CType(dgvReadWHIssuedDetail.Items(i).FindControl("lblLOTNo"), Label).Text.Trim
                Dim lblItemNo As Integer = CInt(CType(dgvReadWHIssuedDetail.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
                Dim lblProduct As String = CType(dgvReadWHIssuedDetail.Items(i).FindControl("lblProduct"), Label).Text.Trim
                Dim lblOwner As String = CType(dgvReadWHIssuedDetail.Items(i).FindControl("lblOwner"), Label).Text.Trim

                Dim sI = (From c In db.tblWHConfirmGoodsReceiveDetails Join pds In db.tblProductDetails On c.ProductCode Equals pds.ProductCode And c.OwnerPN Equals pds.CustomerPart _
                    Where c.LOTNo = lblLOTNo And c.OwnerPN = lblOwner And c.ProductCode = lblProduct And c.ItemNo = lblItemNo And c.StatusAvailable = "0" And c.Type = "Goods Complete").FirstOrDefault
                If sI IsNot Nothing Then
                         
                    ProductWidth = CDbl(Session("ProductWidth"))
                    ProductLength = CDbl(Session("ProductLength"))
                    ProductHeight = CDbl(Session("ProductHeight"))
                    ProductVolume = CDbl(Session("ProductVolume"))
                    Weigth = CDbl(Session("Weigth"))
                    ExchangeRate = CDbl(Session("ExchangeRate"))
                    PriceForeigh = CDbl(Session("PriceForeigh"))
                    PriceForeighAmount = CDbl(Session("PriceForeighAmount"))
                    PriceBath = CDbl(Session("PriceBath"))
                    PriceBathAmount = CDbl(Session("PriceBathAmount"))
                    ItemNo_ = CInt(Session("ItemNO"))
                    EntryNo = CStr(Session("EntryNo"))
                    EntryItemNo = CInt(Session("EntryItemNo"))

                    If ManufacturingDate IsNot Nothing Then
                        md = DateTime.ParseExact(CStr(ManufacturingDate), "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))

                    Else
                        md = Nothing
                    End If
                    If ExpiredDate IsNot Nothing Then
                        exDate = DateTime.ParseExact(CStr(ExpiredDate), "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
                    Else
                        exDate = Nothing
                    End If
                    db.tblWHPickingDetails.Add(New tblWHPickingDetail With { _
                        .PullSignal = txtPullSignal.Value.Trim, _
                        .LOTNo = txtLOtNo.Value.Trim, _
                        .WHSite = CStr(Session("WHSite")), _
                        .WHLocation = CStr(Session("WHLocation")), _
                        .ENDCustomer = CStr(Session("ENDCustomer")), _
                        .CustomerLOTNo = CStr(Session("CustomerLOTNo")), _
                        .WHSource = CStr(Session("WHSource")), _
                        .ItemNo = CDbl(CDbl(itemmax).ToString("#,##0")), _
                        .ProductCode = CStr(Session("ProductCode")), _
                        .CustomerPN = CStr(Session("CustomerPN")), _
                        .OwnerPN = CStr(Session("OwnerPN")), _
                        .ProductDesc = CStr(Session("ProductDesc")), _
                        .Measurement = CStr(Session("Measurement")), _
                        .ProductWidth = CType(CDbl(ProductWidth).ToString("#,##0.000"), Double?), _
                        .ProductLength = CType(CDbl(ProductLength).ToString("#,##0.000"), Double?), _
                        .ProductHeight = CType(CDbl(ProductHeight).ToString("#,##0.000"), Double?), _
                        .ProductVolume = CType(CDbl(ProductVolume).ToString("#,##0.000"), Double?), _
                        .OrderNo = CStr(Session("OrderNo")), _
                        .ReceiveNo = CStr(Session("ReceiveNo")), _
                        .Type = CStr(Session("Type")), _
                        .ReceiveDate = DateTime.ParseExact(CStr(Session("ReceiveDate")), "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                        .PickQuantity = CType(CDbl(txtQTYOfPick.Value.Trim).ToString("#,##0.000"), Double?), _
                        .PickUnit = CStr(Session("QuantityUnit")), _
                        .Weigth = CType(CDbl(Weigth).ToString("#,##0.000"), Double?), _
                        .WeigthUnit = CStr(Session("WeigthUnit")), _
                        .Currency = CStr(Session("Currency")), _
                        .ManufacturingDate = md, _
                        .ExpiredDate = exDate, _
                        .ExchangeRate = CType(CDbl(ExchangeRate).ToString("#,##0.0000"), Double?), _
                        .PriceForeigh = CType(CDbl(PriceForeigh).ToString("#,##0.0000"), Double?), _
                        .PriceForeighAmount = CType(CDbl(PriceForeighAmount).ToString("#,##0.0000"), Double?), _
                        .PriceBath = CType(CDbl(PriceBath).ToString("#,##0.0000"), Double?), _
                        .PriceBathAmount = CType(CDbl(PriceBathAmount).ToString("#,##0.0000"), Double?), _
                        .PalletNo = txtPalletNo.Value.Trim, _
                        .UserBy = CStr(Session("userName")), _
                        .LastUpdate = Now, _
                        .Item = CDec(ItemNo_), _
                        .Reqno = RowRequest1, _
                        .ExpInvNo = zInvoice, _
                        .PONo = txtPONo_PickPack.Value.Trim, _
                        .EntryNo = EntryNo, _
                        .EntryItemNo = EntryItemNo, _
                        .OrderFrmOnline = OrderFrmOnline, _
                        .CustFrmOnline = CustFrmOnline
                     })
                    db.SaveChanges()

                    If txtIssuedQTY.Value = "" Then
                        txtIssuedQTY.Value = "0"
                    End If
                    Dim up As tblWHStockMovement = (From sm In db.tblWHStockMovements Where sm.LOTNo = sI.c.ReceiveNo And sm.ItemNo = ItemNo_ And sm.OwnerPN = sI.c.OwnerPN And sm.CustomerLOTNo = sI.c.CustomerLOTNo).FirstOrDefault

                    If up IsNot Nothing Then
                        up.AvalableQuantity = sI.c.Quantity - CType(CDbl(txtQTYOfPick.Value.Trim), Double?)
                        up.ISSUEQuantity = CType(CDbl(txtQTYOfPick.Value.Trim), Double?) + CType(CDbl(txtIssuedQTY.Value.Trim), Double?)
                        up.OrderFrmOnline = OrderFrmOnline
                        up.CustFrmOnline = CustFrmOnline
                        db.SaveChanges()
                    Else

                    End If

                    Dim upR As tblWHRequestedISSUE = (From ri In db.tblWHRequestedISSUEs Where ri.PullSignal = txtPullSignal.Value.Trim And ri.LotNo = txtLOtNo.Value.Trim And ri.ItemNo = RowRequest1).FirstOrDefault

                    If upR IsNot Nothing Then
                        upR.AvailableRequestQTY = QtyRequest - CInt(txtQTYOfPick.Value.Trim)
                        upR.OrderFrmOnline = OrderFrmOnline
                        upR.CustFrmOnline = CustFrmOnline
                        db.SaveChanges()
                    Else

                    End If

                    Dim upG As tblWHConfirmGoodsReceiveDetail = (From g In db.tblWHConfirmGoodsReceiveDetails Where g.LOTNo = sI.c.ReceiveNo And g.OwnerPN = sI.c.OwnerPN And g.CustomerLOTNo = sI.c.CustomerLOTNo).FirstOrDefault


                End If

            Next




            'Sql = "SELECT max(itemno) as ItemMax  FROM tblWHPickingDetail WHERE PullSignal = '" & txtPullSignal.Value.Trim & "'   and LOTNo = '" & txtLOtNo.Value.Trim & "'  "


            Try

                'If txtRManuFacturingDate.Text = "" Then
                '    .Parameters.Add("@ManufacturingDate", SqlDbType.DateTime).Value = DBNull.Value
                'Else
                '    .Parameters.Add("@ManufacturingDate", SqlDbType.DateTime).Value = txtRManuFacturingDate.Text.Trim()
                'End If

                '.PullSignal = txtPullSignal.Value.Trim, _
                '.LOTNo = txtLOtNo.Value.Trim, _
                '.WHSite = txtRWHSite.Text.Trim, _
                '.WHLocation = txtRWHLocation.Text.Trim, _
                '.ENDCustomer = txtREndCustomer.Text.Trim, _
                '.CustomerLOTNo = txtRCustomerLotNo.Text.Trim, _
                '.WHSource = txtRWHSoure.Text.Trim, _
                '.ItemNo = CDbl(itemmax).ToString("#,##0"), _
                '.ProductCode = txtRProductCode.Text.Trim, _
                '.CustomerPN = txtRCustomerPN.Text.Trim, _
                '.OwnerPN = txtROwnerPN.Text.Trim, _
                '.ProductDesc = txtRProductDesc.Text.Trim, _
                '.Measurement = txtRMeasurement.Text.Trim, _
                '.ProductWidth = CDbl(txtRProductWidth.Text).ToString("#,##0.000"), _
                '.ProductLength = CDbl(txtRProductLength.Text).ToString("#,##0.000", _
                '.ProductHeight = CDbl(txtRProductHeight.Text).ToString("#,##0.000"), _
                '.ProductVolume = CDbl(txtRProductVolume.Text).ToString("#,##0.000"), _
                '.OrderNo = txtROrderNo.Text.Trim, _
                '.ReceiveNo = txtRReceiveNo.Text.Trim, _
                '.Type = txtRType.Text.Trim, _
                '.ManufacturingDate  = DBNull.Value, _              
                '.ExpiredDate = DBNull.Value, _
                '.ReceiveDate = txtRReceiveDate.Text.Trim, _
                '.PickQuantity = CDbl(txtQTYOfPick.Text).ToString("#,##0.000"), _
                '.PickUnit = txtRQuantityUnit.Text.Trim, _
                '.Weigth = CDbl(txtRWeight.Text).ToString("#,##0.000"), _
                '.WeigthUnit = txtRWeightUnit.Text.Trim, _
                '.Currency = txtRCurrency.Text.Trim, _
                '.ExchangeRate = CDbl(txtRExchangeRate.Text).ToString("#,##0.0000"), _
                '.PriceForeigh = CDbl(txtRPriceForeight.Text).ToString("#,##0.0000"), _
                '.PriceForeighAmount = CDbl(txtRPriceForeightAmount.Text).ToString("#,##0.0000"), _
                '.PriceBath = CDbl(txtRBathForeight.Text).ToString("#,##0.0000"), _
                '.PriceBathAmount = CDbl(txtRBathForeightAmount.Text).ToString("#,##0.0000"), _
                '.PalletNo = txtPalletNo.Text.Trim, _
                '.UserBy = DBConnString.UserName, _
                '.LastUpdate = Now, _
                '.Item = CDbl(txtItemNoPick.Text).ToString("#,##0"), _
                '.ReqNo = RowRequest1, _
                '.ExpInvNo = zInvoice, _
                '.PONo = txtPONo.Text.Trim, _
                '.EntryNo = REntryNo, _
                '.EntryItemNo = REntryItemNo, _
                '.OrderFrmOnline = txtOrderFrmOnline.Text, _
                '.CustFrmOnline = txtCustFrmOnline.Text, _



                '    sb = New StringBuilder()
                '    sb.Append("UPDATE tblWHStockMovement")
                '    sb.Append(" SET AvalableQuantity=@AvalableQuantity, ISSUEQuantity=@ISSUEQuantity,OrderFrmOnline=@OrderFrmOnline,CustFrmOnline=@CustFrmOnline")
                '    sb.Append(" WHERE (LOTNo=@LOTNo AND ItemNo=@ItemNo AND OwnerPN=@OwnerPN AND CustomerLotNo=@CustomerLotNo)")
                '    Dim sqlEdit As String
                '    sqlEdit = sb.ToString()
                '    If txtIssuedQTY.Text = "" Then
                '        txtIssuedQTY.Text = "0"
                '    End If
                '    With com
                '        .CommandText = sqlEdit
                '        .CommandType = CommandType.Text
                '        .Connection = Conn
                '        .Transaction = tr
                '        .Parameters.Clear()
                '        .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = txtRReceiveNo.Text.Trim()
                '        .Parameters.Add("@OwnerPN", SqlDbType.NVarChar).Value = txtROwnerPN.Text.Trim()
                '        .Parameters.Add("@CustomerLotNo", SqlDbType.NVarChar).Value = txtRCustomerLotNo.Text.Trim()
                '        .Parameters.Add("@ItemNo", SqlDbType.Decimal).Value = CDbl(txtItemNoPick.Text).ToString("#,##0")
                '        .Parameters.Add("@ReceiveNo", SqlDbType.NVarChar).Value = txtRReceiveNo.Text.Trim()
                '        .Parameters.Add("@AvalableQuantity", SqlDbType.Float).Value = (ItemTotal - CDbl(txtQTYOfPick.Text)).ToString("#,##0.00")
                '        .Parameters.Add("@ISSUEQuantity", SqlDbType.Float).Value = (CDbl(txtQTYOfPick.Text) + CDbl(txtIssuedQTY.Text)).ToString("#,##0.00")
                '        .Parameters.Add("@OrderFrmOnline", SqlDbType.NVarChar).Value = txtOrderFrmOnline.Text.Trim()
                '        .Parameters.Add("@CustFrmOnline", SqlDbType.NVarChar).Value = txtCustFrmOnline.Text.Trim()
                '        Dim result As Integer
                '        result = .ExecuteNonQuery()
                '        If result = 0 Then
                '            tr.Rollback()
                '            MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก Update SaveMovement", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '            Exit Sub
                '        End If
                '    End With


                '    sb = New StringBuilder()
                '    sb.Append("UPDATE tblWHRequestedISSUE")
                '    sb.Append(" SET AvailableRequestQTY=@AvailableRequestQTY,OrderFrmOnline=@OrderFrmOnline,CustFrmOnline=@CustFrmOnline")
                '    sb.Append(" WHERE (PullSignal=@PullSignal AND LOTNo=@LOTNo AND ItemNo=@ItemNo)")
                '    Dim sqlEdit1 As String
                '    sqlEdit1 = sb.ToString()

                '    With com
                '        .CommandText = sqlEdit1
                '        .CommandType = CommandType.Text
                '        .Connection = Conn
                '        .Transaction = tr
                '        .Parameters.Clear()
                '        .Parameters.Add("@PullSignal", SqlDbType.NVarChar).Value = txtPullSignal.Text.Trim()
                '        .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = txtLOtNo.Text.Trim()
                '        .Parameters.Add("@ItemNo", SqlDbType.NVarChar).Value = RowRequest1
                '        .Parameters.Add("@AvailableRequestQTY", SqlDbType.Float).Value = QtyRequest - CInt(txtQTYOfPick.Text)
                '        .Parameters.Add("@OrderFrmOnline", SqlDbType.NVarChar).Value = txtOrderFrmOnline.Text.Trim()
                '        .Parameters.Add("@CustFrmOnline", SqlDbType.NVarChar).Value = txtCustFrmOnline.Text.Trim()

                '        Dim result As Integer
                '        result = .ExecuteNonQuery()
                '        If result = 0 Then
                '            tr.Rollback()
                '            MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก Update tblWHRequestedISSUE  ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '            Exit Sub
                '        End If
                '    End With

                '    sb = New StringBuilder()
                '    sb.Append("UPDATE tblWHConfirmGoodsReceiveDetail")
                '    sb.Append(" SET AvailableQuantity=@AvailableQuantity,StatusAvailable=@StatusAvailable,StatusPutAlway=@StatusPutAlway,OrderFrmOnline=@OrderFrmOnline,CustFrmOnline=@CustFrmOnline")
                '    sb.Append(" WHERE (LOTNo=@LOTNo AND ItemNo=@ItemNo AND OwnerPN=@OwnerPN AND CustomerLotNo=@CustomerLotNo)")
                '    Dim sqlEdit2 As String
                '    sqlEdit2 = sb.ToString()

                '    With com
                '        .CommandText = sqlEdit2
                '        .CommandType = CommandType.Text
                '        .Connection = Conn
                '        .Transaction = tr
                '        .Parameters.Clear()
                '        .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = txtRReceiveNo.Text
                '        .Parameters.Add("@OwnerPN", SqlDbType.NVarChar).Value = txtROwnerPN.Text
                '        .Parameters.Add("@CustomerLotNo", SqlDbType.NVarChar).Value = txtRCustomerLotNo.Text
                '        .Parameters.Add("@ItemNo", SqlDbType.Decimal).Value = CDbl(txtItemNoPick.Text).ToString("#,##0")
                '        .Parameters.Add("@AvailableQuantity", SqlDbType.Float).Value = (ItemTotal - CDbl(txtQTYOfPick.Text)).ToString("#,##0.00")
                '        .Parameters.Add("@OrderFrmOnline", SqlDbType.NVarChar).Value = txtOrderFrmOnline.Text.Trim()
                '        .Parameters.Add("@CustFrmOnline", SqlDbType.NVarChar).Value = txtCustFrmOnline.Text.Trim()
                '        If (ItemTotal - CDbl(txtQTYOfPick.Text)) = 0 Then
                '            .Parameters.Add("@StatusAvailable", SqlDbType.Decimal).Value = 1
                '        Else
                '            .Parameters.Add("@StatusAvailable", SqlDbType.Decimal).Value = 0
                '        End If
                '        .Parameters.Add("@StatusPutAlway", SqlDbType.Int).Value = 0
                '        Dim result As Integer
                '        result = .ExecuteNonQuery()
                '        If result = 0 Then
                '            tr.Rollback()
                '            MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก Update Confirm ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '            Exit Sub
                '        End If
                '    End With

                '    QtyRequest = QtyRequest - CInt(txtQTYOfPick.Text.Trim)

            Catch ex As Exception
                '    tr.Rollback()
                '    MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก " & ex.Message, "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Exit Sub
            End Try

            'tr.Commit()

            'If chkSCRAP.Checked = False Then
            '    ReadDataComfrimGoods()
            '    ReadDataPickDetail()
            'End If

            'ReadDataRequestedISSUE()
            'ReadDataRequestedISSUE_PickPack()
            'ClareDataPickDetail()
            'CountWHPickDetailTotal()

            ''dgvItemAuto.DataSource = Nothing
            ''dgvReadWHIssuedDetail.DataSource = Nothing
            ''ReadDataRequestedISSUE_PickPack()
            ''ReadDataPickDetail()
            ''ClareDataPickDetail()
            ''CountWHPickDetailTotal()
            'If dgvReadWHIssuedRequest.RowCount = 0 Then
            '    _LotnoPick = txtLOTNo.Text.Trim
            '    _PullPick = txtPullSignal.Text.Trim
            '    _DatePick = dtpPullDate.Text.Trim
            '    _TimePick = txtPullTime.Text.Trim

            '    'Dim f As New FrmRptMailPick()
            '    'f.MdiParent = frmMain
            '    'f.Show()

            '  End If

        End If
    End Sub


End Class