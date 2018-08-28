Option Strict On
Option Explicit On


Public Class SingleReceivedWH
    Inherits System.Web.UI.Page

    'Dim db As New LKBWarehouseEntities
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmExpGenLot"
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
                    'invoice_.Disabled = True
                    btnSaveNew.Visible = False
                    btnSaveEdit.Visible = False
                    TabName.Value = Request.Form(TabName.UniqueID)
                    confirmgoodreceive_.Disabled = True
                    goodreceivedetail_.Disabled = True
                    btnSeletJobNew.Visible = False
                    btnSelectJobEdit.Visible = False
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

    End Sub

    Protected Sub btnPutAway_ServerClick(sender As Object, e As EventArgs)

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

            txtUnit4.DataSource = qt.ToList
            txtUnit4.DataTextField = "Code"
            txtUnit4.DataValueField = "Code"
            txtUnit4.DataBind()
            If txtUnit4.Items.Count > 1 Then
                txtUnit4.Enabled = True
            Else
                txtUnit4.Enabled = False

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



    Private Sub selectExpGenLOT()
        'Dim testdate As Integer
        'Dim lot As String
        'If String.IsNullOrEmpty(txtLotNo.Value.Trim) Then
        '    testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        'Else
        '    lot = txtLotNo.Value.Trim
        'End If

        ''Where e.LOTDate.Year = testdate
        'Dim exl = (From e In db.tblExpGenLOTs Where e.EASLOTNo = txtLotNo.Value.Trim Or e.LOTDate.Year = testdate Order By e.EASLOTNo Descending
        '         Select New With {
        '         e.EASLOTNo,
        '         e.CustomerCode,
        '         e.JobSite,
        '         e.EndCusCode}).ToList
        'Try
        '    If exl.Count > 0 Then
        '        Me.dgvLot.DataSource = exl
        '        Me.dgvLot.DataBind()
        '        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "show", "$(function () { $('#" + Panel1.ClientID + "').modal('show'); });", True)
        '        UpdatePanel1.Update()
        '    Else
        '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
        '        Exit Sub
        '    End If

        'Catch ex As Exception
        '    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", ex.Message, True)
        'End Try
    End Sub

    Protected Sub btnAddNew_ServerClick(sender As Object, e As EventArgs)
        confirmgoodreceive_.Disabled = False
        goodreceivedetail_.Disabled = True
        btnSeletJobNew.Visible = True
        btnSelectJobEdit.Visible = False
        btnSaveNew.Visible = True
        btnSaveEdit.Visible = False
    End Sub

    Protected Sub btnEdit_ServerClick(sender As Object, e As EventArgs)
        confirmgoodreceive_.Disabled = False
        goodreceivedetail_.Disabled = False
        btnSeletJobNew.Visible = False
        btnSelectJobEdit.Visible = True
        btnSaveNew.Visible = False
        btnSaveEdit.Visible = True
    End Sub

    Protected Sub btnSaveNew_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSaveEdit_ServerClick(sender As Object, e As EventArgs)

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

    Private Sub selectEndCusCode()
        Dim cus_code As String

        'If String.IsNullOrEmpty(txtPickUpCode.Value.Trim) Then
        '    cus_code = ""

        'Else
        '    cus_code = txtPickUpCode.Value.Trim
        'End If

        'Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        'Where p.PartyCode = cus_code Or p.EndCustomer = "0"
        'Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        'If cons.Count > 0 Then
        '    dgvEndCus.DataSource = cons.ToList
        '    dgvEndCus.DataBind()
        '    ScriptManager.RegisterStartupScript(upEndCusCode, upEndCusCode.GetType(), "show", "$(function () { $('#" + plEndCusCode.ClientID + "').modal('show'); });", True)
        '    upEndCusCode.Update()
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
        Dim lot As String
        Dim lotDate_ As Integer
        Dim consignee As String = ""
        Dim endCustomer As String = ""
        Dim shipper As String = ""
        If String.IsNullOrEmpty(txtLotNo_.Value.Trim) Then
            lot = ""
            lotDate_ = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            lot = txtConsigneeCode_.Value.Trim
        End If
        Dim go = (From wh In db.tblWHPrepairGoodsReceives
                  Where (wh.LOTNo.Contains(lot) And wh.UsedStatus = 0 And Not wh.LOTNo.Contains("WIP")) _
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

    End Sub

    Private Sub selectPrepairGoodsReceiveEdit()
        Dim go = (From wh In db.tblWHConfirmGoodsReceives
                  Where wh.LOTNo.Contains(txtLotNo_.Value.Trim)
                  Select wh.LOTNo, wh.LOTDate, wh.CustREFNo, wh.OwnerCode).Take(100)
        If go.Count > 0 Then
            dgvPrepire.DataSource = go.ToList
            dgvPrepire.DataBind()
            ScriptManager.RegisterStartupScript(upPrepire, upPrepire.GetType(), "show", "$(function () { $('#" + plPrepire.ClientID + "').modal('show'); });", True)
            upPrepire.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
        End If

    End Sub
End Class