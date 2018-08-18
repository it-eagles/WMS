Option Explicit On
Option Strict On

Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data
Imports System.Security.Cryptography
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Transactions
Imports System.Text
Imports System.Nullable(Of Date)

Public Class ExpGenLot
    Inherits System.Web.UI.Page

    Dim sb As StringBuilder
    Dim tmpButtonStatus As String
    Dim sqlDataComboList As String
    Dim JOB As String
    Dim classPermis As New ClassPermis
    Dim db As New LKBWarehouseEntities1_Test

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmExpGenLot"
        If Not Me.IsPostBack Then
            If classPermis.CheckRead(form, usename) = True Then
                If Not IsPostBack Then
                    showQuatity1()
                    showBox()
                    showBox1()
                    showCommodity()
                    showJobSite()
                    showQuatity2()
                    showSales()
                    showUnitPallet()
                    showUnitQuantityDetail()
                    showVolume()
                    showWeight()
                    showWeightINV()
                    master_.Disabled = True
                    detail_.Disabled = True
                    'invoice_.Disabled = True
                    btnSaveNew.Visible = False
                    btnSaveEdit.Visible = False
                    btnSeletJob.Visible = False
                    showVisible()
                    TabName.Value = Request.Form(TabName.UniqueID)
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
    Private Sub showSales()
        'dcbSales.Items.Clear()
        'dcbSales.Items.Add(New ListItem("select Volume"))
        'dcbSales.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "SALES" Select q.Code, q.Type

        Try
            dcbSales.DataSource = qt.ToList
            dcbSales.DataTextField = "Code"
            dcbSales.DataValueField = "Code"
            dcbSales.DataBind()
            If dcbSales.Items.Count > 1 Then
                dcbSales.Enabled = True
            Else
                dcbSales.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showUnitQuantityDetail()
        'cdbUnitQuantityDetail.Items.Clear()
        'cdbUnitQuantityDetail.Items.Add(New ListItem("select Unit"))
        'cdbUnitQuantityDetail.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT" Select q.Code, q.Type

        Try
            cdbUnitQuantityDetail.DataSource = qt.ToList
            cdbUnitQuantityDetail.DataTextField = "Code"
            cdbUnitQuantityDetail.DataValueField = "Code"
            cdbUnitQuantityDetail.DataBind()
            If cdbUnitQuantityDetail.Items.Count > 1 Then
                cdbUnitQuantityDetail.Enabled = True
            Else
                cdbUnitQuantityDetail.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showUnitPallet()
        'cdbUnitPallet.Items.Clear()
        'cdbUnitPallet.Items.Add(New ListItem("select Pallet"))
        'cdbUnitPallet.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT" Select q.Code, q.Type

        Try
            cdbUnitPallet.DataSource = qt.ToList
            cdbUnitPallet.DataTextField = "Code"
            cdbUnitPallet.DataValueField = "Code"
            cdbUnitPallet.DataBind()
            If cdbUnitPallet.Items.Count > 1 Then
                cdbUnitPallet.Enabled = True
            Else
                cdbUnitPallet.Enabled = False

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
            cdbBox.DataSource = qt.ToList
            cdbBox.DataTextField = "Code"
            cdbBox.DataValueField = "Code"
            cdbBox.DataBind()
            If cdbBox.Items.Count > 1 Then
                cdbBox.Enabled = True
            Else
                cdbBox.Enabled = False

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
            cdbUnitWeightInv.DataSource = qt.ToList
            cdbUnitWeightInv.DataTextField = "Code"
            cdbUnitWeightInv.DataValueField = "Code"
            cdbUnitWeightInv.DataBind()
            If cdbUnitWeightInv.Items.Count > 1 Then
                cdbUnitWeightInv.Enabled = True
            Else
                cdbUnitWeightInv.Enabled = False

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
            cdbBox1.DataSource = qt.ToList
            cdbBox1.DataTextField = "Code"
            cdbBox1.DataValueField = "Code"
            cdbBox1.DataBind()
            If cdbBox1.Items.Count > 1 Then
                cdbBox1.Enabled = True
            Else
                cdbBox1.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    
    Private Sub showCommodity()
        'txtCommodity.Items.Clear()
        'txtCommodity.Items.Add(New ListItem("select Pallet"))
        'txtCommodity.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "COMMODITY" Select q.Code, q.Type

        Try
            txtCommodity.DataSource = qt.ToList
            txtCommodity.DataTextField = "Code"
            txtCommodity.DataValueField = "Code"
            txtCommodity.DataBind()
            If txtCommodity.Items.Count > 1 Then
                txtCommodity.Enabled = True
            Else
                txtCommodity.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    
    Private Sub showJobSite()

        'cboJobSite.Items.Clear()
        'cboJobSite.Items.Add(New ListItem("select Pallet"))
        'cboJobSite.AppendDataBoundItems = True

        Dim qt = From q In db.tblMasterCode2 Where q.Type = "JOBSITE" Select q.Code, q.Type
        'Dim qt = From q In db.tblMasterCode2 Select q.CreateDate

        Try
            cboJobSite.DataSource = qt.ToList
            cboJobSite.DataTextField = "Code"
            cboJobSite.DataValueField = "Code"
            cboJobSite.DataBind()
            If cboJobSite.Items.Count > 1 Then
                cboJobSite.Enabled = True
            Else
                cboJobSite.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub
   
 
    Private Sub selectExpGenLOT()
        Dim testdate As Integer
        Dim lot As String
        If String.IsNullOrEmpty(txtLotNo.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            lot = txtLotNo.Value.Trim
        End If

        'Where e.LOTDate.Year = testdate
        Dim exl = (From e In db.tblExpGenLOTs Where e.EASLOTNo = txtLotNo.Value.Trim Or e.LOTDate.Year = testdate Order By e.EASLOTNo Descending
                 Select New With {
                 e.EASLOTNo,
                 e.CustomerCode,
                 e.JobSite,
                 e.EndCusCode}).ToList
        Try
                If exl.Count > 0 Then
                Me.dgvLot.DataSource = exl
                Me.dgvLot.DataBind()
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "show", "$(function () { $('#" + Panel1.ClientID + "').modal('show'); });", True)
                    UpdatePanel1.Update()
                Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
                Exit Sub
                End If
          
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", ex.Message, True)
        End Try
    End Sub

    Protected Sub Unnamed_ServerClick(sender As Object, e As EventArgs)
            selectExpGenLOT()
    End Sub
    Private Sub selectConsigneeCode()
        Dim cons_code As String
        Dim consignee As String = ""
        If String.IsNullOrEmpty(txtConsigneeCode.Value.Trim) Then
            cons_code = ""
            consignee = "0"
        Else
            cons_code = txtConsigneeCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = consignee
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvConsigneeCode.DataSource = cons.ToList
            dgvConsigneeCode.DataBind()
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "show", "$(function () { $('#" + Panel2.ClientID + "').modal('show'); });", True)
            UpdatePanel2.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Consignee Code นี้')", True)
            Exit Sub

        End If
    End Sub

    Protected Sub Unnamed_ServerClick1(sender As Object, e As EventArgs)
        selectConsigneeCode()
    End Sub

    Private Sub selectExporterCode()
        Dim exp_code As String
        Dim shipper As String = ""
        If String.IsNullOrEmpty(txtExporterCode.Value.Trim) Then
            exp_code = ""
            shipper = "0"
        Else
            exp_code = txtExporterCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = exp_code And p.Shipper = "0") Or p.Shipper = shipper
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvExporterCode.DataSource = cons.ToList
            dgvExporterCode.DataBind()
            ScriptManager.RegisterStartupScript(upExporterCode, upExporterCode.GetType(), "show", "$(function () { $('#" + plExporterCode.ClientID + "').modal('show'); });", True)
            upExporterCode.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Exporter Code นี้')", True)
            Exit Sub
        End If
    End Sub

    Protected Sub Unnamed_ServerClick3(sender As Object, e As EventArgs)
        selectExporterCode()
    End Sub

    Private Sub codeconsignnee()
        Dim code_code As String
        Dim consignee As String = ""
        Dim endCustomer As String = ""
        Dim shipper As String = ""
        If String.IsNullOrEmpty(txtDOCode.Value.Trim) Then
            code_code = ""
            consignee = "0"
            endCustomer = "0"
            shipper = "0"
        Else
            code_code = txtDOCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = code_code And p.Shipper = "0" And p.Consignee = "0" And p.EndCustomer = "0") Or
              (p.Consignee = consignee And p.EndCustomer = endCustomer And p.Shipper = shipper)
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvcodeconsignnee.DataSource = cons.ToList
            dgvcodeconsignnee.DataBind()
            ScriptManager.RegisterStartupScript(upDOCod, upDOCod.GetType(), "show", "$(function () { $('#" + plDOCode.ClientID + "').modal('show'); });", True)
            upDOCod.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Code นี้')", True)
            Exit Sub

        End If
    End Sub
    Protected Sub Unnamed_ServerClick2(sender As Object, e As EventArgs)
        'selectExporterCode()
        codeconsignnee()
    End Sub
    Private Sub selectCustomerCode()
        Dim cum_code As String
        Dim consignee As String = ""
        If String.IsNullOrEmpty(txtCustomerCode.Value.Trim) Then
            cum_code = ""
            consignee = "0"
        Else
            cum_code = txtCustomerCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cum_code And p.Consignee = "0") Or p.Consignee = consignee
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvCustomer.DataSource = cons.ToList
            dgvCustomer.DataBind()
            ScriptManager.RegisterStartupScript(upCustomerCode, upCustomerCode.GetType(), "show", "$(function () { $('#" + plCustomerCode.ClientID + "').modal('show'); });", True)
            upCustomerCode.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
            Exit Sub

        End If
    End Sub

    Protected Sub Unnamed_ServerClick4(sender As Object, e As EventArgs)
        selectCustomerCode()
    End Sub
    Private Sub selectPickUpCode()
        Dim pick_code As String

        If String.IsNullOrEmpty(txtPickUpCode.Value.Trim) Then
            pick_code = ""

        Else
            pick_code = txtPickUpCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where p.PartyCode = pick_code Or p.Consignee = "0"
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvPickUp.DataSource = cons.ToList
            dgvPickUp.DataBind()
            ScriptManager.RegisterStartupScript(upPickUpCode, upPickUpCode.GetType(), "show", "$(function () { $('#" + plPickUpCode.ClientID + "').modal('show'); });", True)
            upPickUpCode.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
            Exit Sub

        End If
    End Sub
    Protected Sub Unnamed_ServerClick5(sender As Object, e As EventArgs)
        selectPickUpCode()
    End Sub
    Private Sub selectEndCusCode()
        Dim cus_code As String

        If String.IsNullOrEmpty(txtPickUpCode.Value.Trim) Then
            cus_code = ""

        Else
            cus_code = txtPickUpCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where p.PartyCode = cus_code Or p.EndCustomer = "0"
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvEndCus.DataSource = cons.ToList
            dgvEndCus.DataBind()
            ScriptManager.RegisterStartupScript(upEndCusCode, upEndCusCode.GetType(), "show", "$(function () { $('#" + plEndCusCode.ClientID + "').modal('show'); });", True)
            upEndCusCode.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
            Exit Sub
        End If
    End Sub

    Protected Sub Unnamed_ServerClick6(sender As Object, e As EventArgs)
        selectEndCusCode()
    End Sub

    Private Sub selectCustomerGroup()
        Dim gro_code As String

        If String.IsNullOrEmpty(txtCustomerCodeGroup.Value.Trim) Then
            gro_code = ""

        Else
            gro_code = txtCustomerCodeGroup.Value.Trim
        End If

        Dim cons = From p In db.tblParties
        Where p.PartyCode = gro_code Or p.Customer = "0"
        Select p.PartyCode, p.PartyFullName

        If cons.Count > 0 Then
            dgvCustomerGroup.DataSource = cons.ToList
            dgvCustomerGroup.DataBind()
            ScriptManager.RegisterStartupScript(upCustomerGroup, upCustomerGroup.GetType(), "show", "$(function () { $('#" + plCustomerGroup.ClientID + "').modal('show'); });", True)
            upCustomerGroup.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
            Exit Sub
        End If
    End Sub
    Protected Sub Unnamed_ServerClick7(sender As Object, e As EventArgs)
        selectCustomerGroup()
    End Sub

    Protected Sub dgvLot_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim EASLOTNo As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("selectLotNO") Then
            Dim exp = (From ex In db.tblExpGenLOTs Where ex.EASLOTNo = EASLOTNo).SingleOrDefault

            If String.IsNullOrEmpty(exp.EASLOTNo) Then
                txtLotNo.Value = ""
            Else
                txtLotNo.Value = exp.EASLOTNo
            End If

            dtpInvoiceDate.Text = Convert.ToDateTime(exp.LOTDate).ToString("dd/MM/yyyy")
            ComboBox2.Text = exp.LOTBy
            If String.IsNullOrEmpty(exp.SalesCode) Then
                dcbSales.Text = ""
            Else
                dcbSales.Text = exp.SalesCode
            End If
            If String.IsNullOrEmpty(exp.SalesName) Then
                txtSalesName.Value = ""
            Else
                txtSalesName.Value = exp.SalesName
            End If
            If String.IsNullOrEmpty(exp.ConsigneeCode) Then
                txtConsigneeCode.Value = ""
            Else
                txtConsigneeCode.Value = exp.ConsigneeCode
            End If
            If String.IsNullOrEmpty(exp.ConsignNameEng) Then
                txtConsignneeEng.Value = ""
            Else
                txtConsignneeEng.Value = exp.ConsignNameEng
            End If

            If String.IsNullOrEmpty(exp.ConsignAddress) Then
                txtConsignneeStreet_Number.Value = ""
            Else
                txtConsignneeStreet_Number.Value = exp.ConsignAddress
            End If

            If String.IsNullOrEmpty(exp.ConsignDistrict) Then
                txtConsignneeDistrict.Value = ""
            Else
                txtConsignneeDistrict.Value = exp.ConsignDistrict
            End If

            If String.IsNullOrEmpty(exp.ConsignSubProvince) Then
                txtConsignneeSubProvince.Value = ""
            Else
                txtConsignneeSubProvince.Value = exp.ConsignSubProvince
            End If
            If String.IsNullOrEmpty(exp.ConsignProvince) Then
                txtConsignneeProvince.Value = ""
            Else
                txtConsignneeProvince.Value = exp.ConsignProvince
            End If

            If String.IsNullOrEmpty(exp.ConsignPostCode) Then
                txtConsignneePostCode.Value = ""
            Else
                txtConsignneePostCode.Value = exp.ConsignPostCode
            End If

            If String.IsNullOrEmpty(exp.ConsignEmail) Then
                txtConsignneeEMail.Value = ""
            Else
                txtConsignneeEMail.Value = exp.ConsignEmail
            End If

            If String.IsNullOrEmpty(exp.ShipperCode) Then
                txtExporterCode.Value = ""
            Else
                txtExporterCode.Value = exp.ShipperCode
            End If

            If String.IsNullOrEmpty(exp.ShipperNameEng) Then
                txtExportEng.Value = ""
            Else
                txtExportEng.Value = exp.ShipperNameEng
            End If

            If String.IsNullOrEmpty(exp.ShipperAddress) Then
                txtStreet_Number.Value = ""
            Else
                txtStreet_Number.Value = exp.ShipperAddress
            End If
            If String.IsNullOrEmpty(exp.ShipperDistrict) Then
                txtDistrict.Value = ""
            Else
                txtDistrict.Value = exp.ShipperDistrict
            End If
            If String.IsNullOrEmpty(exp.ShipperSubprovince) Then
                txtSubProvince.Value = ""
            Else
                txtSubProvince.Value = exp.ShipperSubprovince
            End If
            If String.IsNullOrEmpty(exp.ShipperProvince) Then
                txtProvince.Value = ""
            Else
                txtProvince.Value = exp.ShipperProvince
            End If
            If String.IsNullOrEmpty(exp.ShipperPostCode) Then
                txtPostCode.Value = ""
            Else
                txtPostCode.Value = exp.ShipperPostCode
            End If

            If String.IsNullOrEmpty(exp.ShipperReturnCode) Then
                txtCompensateCode.Value = ""
            Else
                txtCompensateCode.Value = exp.ShipperReturnCode
            End If
            If String.IsNullOrEmpty(exp.Commodity) Then
                txtCommodity.Text = ""
            Else
                txtCommodity.Text = exp.Commodity
            End If

            If String.IsNullOrEmpty(CStr(exp.QuantityofPart)) Then
                txtQuantityofPart.Value = ""
            Else
                txtQuantityofPart.Value = CStr(exp.QuantityofPart)
            End If

            If String.IsNullOrEmpty(exp.QuantityUnit) Then
                dcbQuantity1.Text = ""
            Else
                dcbQuantity1.Text = exp.QuantityUnit
            End If

            If String.IsNullOrEmpty(CStr(exp.QuantityPack)) Then
                txtQuantityPLT.Value = ""
            Else
                txtQuantityPLT.Value = CStr(exp.QuantityPack)
            End If

            If String.IsNullOrEmpty(exp.QuantityUnitPack) Then
                dcbQuantity2.Text = ""
            Else
                dcbQuantity2.Text = exp.QuantityUnitPack
            End If

            If String.IsNullOrEmpty(CStr(exp.Weight)) Then
                txtWeight.Value = ""
            Else
                txtWeight.Value = String.Format("{0:0.00}", exp.Weight)
            End If

            If String.IsNullOrEmpty(exp.WeightUnit) Then
                dcbWeight.Text = ""
            Else
                dcbWeight.Text = exp.WeightUnit
            End If

            If String.IsNullOrEmpty(CStr(exp.Volume)) Then
                txtVolume.Value = ""
            Else
                txtVolume.Value = CStr(exp.Volume)
            End If

            If String.IsNullOrEmpty(exp.VolumeUnit) Then
                'dcbVolume.Text = ""
            Else
                dcbVolume.Text = exp.VolumeUnit
            End If

            If String.IsNullOrEmpty(exp.MAWB) Then
                txtMAWB.Value = ""
            Else
                txtMAWB.Value = exp.MAWB
            End If

            ComboBox7.Text = exp.DocType

            If String.IsNullOrEmpty(exp.DocCode) Then
                txtDocumentCode.Value = ""
            Else
                txtDocumentCode.Value = exp.DocCode
            End If

            If String.IsNullOrEmpty(exp.Flight) Then
                txtFlight.Value = ""
            Else
                txtFlight.Value = exp.Flight
            End If

            If String.IsNullOrEmpty(exp.ScanPathFile) Then
                txtStatusFile.Value = ""
            Else
                txtStatusFile.Value = exp.ScanPathFile
            End If

            If String.IsNullOrEmpty(exp.DOCode) Then
                txtDOCode.Value = ""
            Else
                txtDOCode.Value = exp.DOCode
            End If

            If String.IsNullOrEmpty(exp.DONameENG) Then
                txtDONameENG.Value = ""
            Else
                txtDONameENG.Value = exp.DONameENG
            End If

            If String.IsNullOrEmpty(exp.DOStreet_Number) Then
                txtDOStreet.Value = ""
            Else
                txtDOStreet.Value = exp.DOStreet_Number
            End If

            If String.IsNullOrEmpty(exp.DODistrict) Then
                txtDODistrict.Value = ""
            Else
                txtDODistrict.Value = exp.DODistrict
            End If

            If String.IsNullOrEmpty(exp.DOSubProvince) Then
                txtDOSubProvince.Value = ""
            Else
                txtDOSubProvince.Value = exp.DOSubProvince
            End If

            If String.IsNullOrEmpty(exp.DOProvince) Then
                txtDOProvince.Value = ""
            Else
                txtDOProvince.Value = exp.DOProvince
            End If

            If String.IsNullOrEmpty(exp.DOPostCode) Then
                txtDOPostCode.Value = ""
            Else
                txtDOPostCode.Value = exp.DOPostCode
            End If

            If String.IsNullOrEmpty(exp.DOEmail) Then
                txtDOEmail.Value = ""
            Else
                txtDOEmail.Value = exp.DOEmail
            End If

            If String.IsNullOrEmpty(exp.DOContactPerson) Then
                txtDOContactPerson.Value = ""
            Else
                txtDOContactPerson.Value = exp.DOContactPerson
            End If

            If String.IsNullOrEmpty(exp.IEATNo) Then
                txtIEATNo.Value = ""
            Else
                txtIEATNo.Value = exp.IEATNo
            End If

            If String.IsNullOrEmpty(exp.EntryNo) Then
                txtEntryNo.Value = ""
            Else
                txtEntryNo.Value = exp.EntryNo
            End If

            dtpDeliveryDate.Text = Convert.ToDateTime(exp.DeliveryDate).ToString("dd/MM/yyyy")

            If String.IsNullOrEmpty(exp.CustomerCode) Then
                txtCustomerCode.Value = ""
            Else
                txtCustomerCode.Value = exp.CustomerCode
            End If

            If String.IsNullOrEmpty(exp.CustomerENG) Then
                txtCustomerENG.Value = ""
            Else
                txtCustomerENG.Value = exp.CustomerENG
            End If

            If String.IsNullOrEmpty(exp.CustomerStreet) Then
                txtCustomerStreet.Value = ""
            Else
                txtCustomerStreet.Value = exp.CustomerStreet
            End If

            If String.IsNullOrEmpty(exp.CustomerDistrict) Then
                txtCustomerDistrict.Value = ""
            Else
                txtCustomerDistrict.Value = exp.CustomerDistrict
            End If

            If String.IsNullOrEmpty(exp.CustomerSub) Then
                txtCustomerSub.Value = ""
            Else
                txtCustomerSub.Value = exp.CustomerSub
            End If

            If String.IsNullOrEmpty(exp.CustomerProvince) Then
                txtCustomerProvince.Value = ""
            Else
                txtCustomerProvince.Value = exp.CustomerProvince
            End If

            If String.IsNullOrEmpty(exp.CustomerPostCode) Then
                txtCustomerPostCode.Value = ""
            Else
                txtCustomerPostCode.Value = exp.CustomerPostCode
            End If

            If String.IsNullOrEmpty(exp.CustomerEmail) Then
                txtCustomerEmail.Value = ""
            Else
                txtCustomerEmail.Value = exp.CustomerEmail
            End If

            If String.IsNullOrEmpty(exp.CustomerContact) Then
                txtCustomerContact.Value = ""
            Else
                txtCustomerContact.Value = exp.CustomerContact
            End If

            If String.IsNullOrEmpty(exp.PickUpCode) Then
                txtPickUpCode.Value = ""
            Else
                txtPickUpCode.Value = exp.PickUpCode
            End If

            If String.IsNullOrEmpty(exp.PickUpENG) Then
                txtPickUpNameEng.Value = ""
            Else
                txtPickUpNameEng.Value = exp.PickUpENG
            End If

            If String.IsNullOrEmpty(exp.PickUpAddress1) Then
                txtPickUpAddress1.Value = ""
            Else
                txtPickUpAddress1.Value = exp.PickUpAddress1
            End If

            If String.IsNullOrEmpty(exp.PickUpAddress2) Then
                txtPickUpAddress2.Value = ""
            Else
                txtPickUpAddress2.Value = exp.PickUpAddress2
            End If
            If String.IsNullOrEmpty(exp.PickUpAddress2) Then
                txtPickUpAddress2.Value = ""
            Else
                txtPickUpAddress2.Value = exp.PickUpAddress3
            End If

            If String.IsNullOrEmpty(exp.PickUpAddress3) Then
                txtPickUpAddress3.Value = ""
            Else
                txtPickUpAddress3.Value = exp.PickUpAddress3
            End If

            If String.IsNullOrEmpty(exp.PickUpAddress4) Then
                txtPickUpAddress4.Value = ""
            Else
                txtPickUpAddress4.Value = exp.PickUpAddress4
            End If

            If String.IsNullOrEmpty(exp.PickUpAddress5) Then
                txtPickUpAddress5.Value = ""
            Else
                txtPickUpAddress5.Value = exp.PickUpAddress5
            End If

            If String.IsNullOrEmpty(exp.PickUpEmail) Then
                txtPickUpEmail.Value = ""
            Else
                txtPickUpEmail.Value = exp.PickUpEmail
            End If

            If String.IsNullOrEmpty(exp.PickUpContact) Then
                txtPickUpContact.Value = ""
            Else
                txtPickUpContact.Value = exp.PickUpContact
            End If

            If String.IsNullOrEmpty(exp.EndCusCode) Then
                txtEndCusCode.Value = ""
            Else
                txtEndCusCode.Value = exp.EndCusCode
            End If

            If String.IsNullOrEmpty(exp.EndCusENG) Then
                txtEndCusNameEng.Value = ""
            Else
                txtEndCusNameEng.Value = exp.EndCusENG
            End If

            If String.IsNullOrEmpty(exp.EndCusAddress1) Then
                txtEndCusAddress1.Value = ""
            Else
                txtEndCusAddress1.Value = exp.EndCusAddress1
            End If

            If String.IsNullOrEmpty(exp.EndCusAddress2) Then
                txtEndCusAddress2.Value = ""
            Else
                txtEndCusAddress2.Value = exp.EndCusAddress2
            End If
            If String.IsNullOrEmpty(exp.EndCusAddress3) Then
                txtEndCusAddress3.Value = ""
            Else
                txtEndCusAddress3.Value = exp.EndCusAddress3
            End If
            If String.IsNullOrEmpty(exp.EndCusAddress4) Then
                txtEndCusAddress4.Value = ""
            Else
                txtEndCusAddress4.Value = exp.EndCusAddress4
            End If

            If String.IsNullOrEmpty(exp.EndCusAddress5) Then
                txtEndCusAddress5.Value = ""
            Else
                txtEndCusAddress5.Value = exp.EndCusAddress5
            End If

            If String.IsNullOrEmpty(exp.EndCusEmail) Then
                txtEndCusEmail.Value = ""
            Else
                txtEndCusEmail.Value = exp.EndCusEmail
            End If

            If String.IsNullOrEmpty(exp.EndCusContact) Then
                txtEndCusContact.Value = ""
            Else
                txtEndCusContact.Value = exp.EndCusContact
            End If

            If String.IsNullOrEmpty(exp.FreighForwarder) Then
                txtFreigh.Value = ""
            Else
                txtFreigh.Value = exp.FreighForwarder
            End If

            If String.IsNullOrEmpty(exp.IEATPermit) Then
                txtIEATPermit.Value = ""
            Else
                txtIEATPermit.Value = exp.IEATPermit
            End If

            If String.IsNullOrEmpty(exp.ShipTo) Then
                txtShipTo.Value = ""
            Else
                txtShipTo.Value = exp.ShipTo
            End If

            If String.IsNullOrEmpty(CStr(exp.Box)) Then
                txtBox.Value = ""
            Else
                txtBox.Value = CStr(exp.Box)
            End If

            If String.IsNullOrEmpty(CStr(exp.Box)) Then
                txtBox.Value = ""
            Else
                txtBox.Value = CStr(exp.Box)
            End If

            cdbBox1.Text = exp.UnitBox
            txtIEATDate.Text = Convert.ToDateTime(exp.IEATDate).ToString("dd/MM/yyyy")
            If String.IsNullOrEmpty(exp.Status1) Then
                dcbStatus1.Text = ""
            Else
                dcbStatus1.Text = exp.Status1
            End If
            If String.IsNullOrEmpty(exp.Status2) Then
                dcbStatus2.Text = ""
            Else
                dcbStatus2.Text = exp.Status2
            End If

            If String.IsNullOrEmpty(exp.Status2) Then
                dcbStatus2.Text = ""
            Else
                dcbStatus2.Text = exp.Status2
            End If
            If String.IsNullOrEmpty(exp.Remark) Then
                txtJobRemark.Value = ""
            Else
                txtJobRemark.Value = exp.Remark
            End If
            If String.IsNullOrEmpty(exp.JobSite) Then
                cboJobSite.Text = ""
            Else
                cboJobSite.Text = exp.JobSite
            End If
            If String.IsNullOrEmpty(exp.BillingNo) Then
                txtBillingNo.Value = ""
            Else
                txtBillingNo.Value = exp.BillingNo
            End If
            If String.IsNullOrEmpty(exp.CustomerCodeGroup) Then
                txtCustomerCodeGroup.Value = ""
            Else
                txtCustomerCodeGroup.Value = exp.CustomerCodeGroup
            End If
            If String.IsNullOrEmpty(exp.CustomerENGGroup) Then
                txtCustomerENGGroup.Value = ""
            Else
                txtCustomerENGGroup.Value = exp.CustomerENGGroup
            End If
            If String.IsNullOrEmpty(exp.DeliveryTime) Then
                txtDeliveryTime.Value = ""
            Else
                txtDeliveryTime.Value = exp.DeliveryTime
            End If
            ReadDATA()
            ReadDATA2()
            ReadDATAEAS()
        End If
    End Sub

    Protected Sub btnAddNew_ServerClick(sender As Object, e As EventArgs)
        master_.Disabled = False
        detail_.Disabled = True
        btnSeletJob.Visible = False
        btnSaveEdit.Visible = False
        btnSaveNew.Visible = True
        txtLotNo.Disabled = True
        showVisible()
        ClearDATA()
    End Sub

    Protected Sub btnEdit_ServerClick(sender As Object, e As EventArgs)
        master_.Disabled = False
        detail_.Disabled = False
        invoice_.Disabled = False
        btnSeletJob.Visible = True
        btnSaveEdit.Visible = True
        btnSaveNew.Visible = False
        txtLotNo.Disabled = False
        showVisibleEdit()
        ClearDATA()
    End Sub
    Private Sub showVisible()
        txtIEATNo.Disabled = True
        txtGenInvNo.Disabled = True
        txtEASInv.Disabled = True
        Checkbox3.Disabled = True
        txtPullSignal.Disabled = True
        txtCustomerINV.Disabled = True
        txtCancleIEAT.Disabled = True
        btnInv.Disabled = True
        btnInvoice.Disabled = True
        txtQuantityDetail.Disabled = True
        txtPallet.Disabled = True
        txtBoxINV.Disabled = True
        txtWeightInv.Disabled = True
        txtPullS.Disabled = True
        txtItemNo.Disabled = True
        txtShipment.Disabled = True
        txtPriceBath.Disabled = True
        txtPriceForeign.Disabled = True
        cmdDeleteInv.Disabled = True
        Button4.Disabled = True
        cmdGenInvNo.Disabled = True
        dtpInvoice.Enabled = False
        cdbUnitWeightInv.Enabled = False
        cdbBox.Enabled = False
        cdbUnitPallet.Enabled = False
        cdbUnitQuantityDetail.Enabled = False
        txtRemark.Enabled = False
        'dcbStatus1.Enabled = False
        'dcbStatus2.Enabled = False
        'dcbStatus3.Enabled = False
        'dtpDeliveryDate.Enabled = False
        Gen.Enabled = False
        Button2.Enabled = False
        'txtIEATDate.Enabled = False
        txtQuantityPLT.Value = "0.0"
        txtBox.Value = "0.0"
        txtVolume.Value = "0.0"
        txtQuantityofPart.Value = "0.0"
        txtWeight.Value = "0.0"
    End Sub

    Private Sub showVisibleEdit()
        'txtIEATNo.Disabled = False
        Checkbox1.Disabled = False
        txtIEATPermit.Disabled = False
        txtEntryNo.Disabled = False
        txtDeliveryTime.Disabled = False
        txtGenInvNo.Disabled = False
        txtEASInv.Disabled = False
        Checkbox3.Disabled = False
        txtPullSignal.Disabled = False
        txtCustomerINV.Disabled = False
        txtCancleIEAT.Disabled = False
        btnInv.Disabled = False
        btnInvoice.Disabled = False
        txtQuantityDetail.Disabled = False
        txtPallet.Disabled = False
        txtBoxINV.Disabled = False
        txtWeightInv.Disabled = False
        txtPullS.Disabled = False
        txtItemNo.Disabled = False
        txtShipment.Disabled = False
        txtPriceBath.Disabled = False
        txtPriceForeign.Disabled = False
        cmdDeleteInv.Disabled = False
        Button4.Disabled = False
        cmdGenInvNo.Disabled = False
        dtpInvoice.Enabled = True
        cdbUnitWeightInv.Enabled = True
        cdbBox.Enabled = True
        cdbUnitPallet.Enabled = True
        cdbUnitQuantityDetail.Enabled = True
        txtRemark.Enabled = True
        dcbStatus1.Enabled = True
        dcbStatus2.Enabled = True
        dcbStatus3.Enabled = True
        dtpDeliveryDate.Enabled = True
        Gen.Enabled = False
        Button2.Enabled = False
        txtIEATDate.Enabled = True
        txtQuantityPLT.Value = "0.0"
        txtBox.Value = "0.0"
        txtVolume.Value = "0.0"
        txtQuantityofPart.Value = "0.0"
        txtWeight.Value = "0.0"
    End Sub

    Protected Sub btnSaveNew_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmExpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
           
            If cboJobSite.Text = "LKB" Then
                Gentbl("ExpLOTOUT")
            ElseIf cboJobSite.Text = "SBIA" Then
                Gentbl("SBIALOTOUT")
            ElseIf cboJobSite.Text = "HCR" Then
                Gentbl("HCRLOTOUT")
            ElseIf cboJobSite.Text = "HTO" Then
                Gentbl("HTOLOTOUT")
            ElseIf cboJobSite.Text = "AEC" Then
                Gentbl("AECLOTOUT")
            ElseIf cboJobSite.Text = "MJB" Then
                Gentbl("MJBLOTOUT")
            ElseIf cboJobSite.Text = "LEA" Then
                Gentbl("LEALOTOUT")
            ElseIf cboJobSite.Text = "SPM" Then
                Gentbl("SPMLOTOUT")
            ElseIf cboJobSite.Text = "PTN" Then
                Gentbl("PTNLOTOUT")
            ElseIf cboJobSite.Text = "CKT" Then
                Gentbl("CKTLOTOUT")
            ElseIf cboJobSite.Text = "WIP" Then
                Gentbl("WIPLOTOUT")
            End If
            SaveDATA_New()
            InsertData()
            ClearDATA()
            ReadDATA()
            ReadDATA2()
            ReadDATAEAS()
          
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If

    End Sub

    Private Sub Gentbl(type As String)
        'Dim sqlSearch As String
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
        Dim JobSite As String
        Dim num_ As String
        Dim dunNo As String

        Nemount = Nmount.ToString("0#")
        Neyear = Nyear.ToString("0#")

        Mount = CSng(Nemount)
        Year = CSng(Neyear)
        Digit = CSng(DigitNo_)

        JobSite = cboJobSite.Text.Trim
        If JobSite = "SBIA" Then
            LotNo = JobSite & "-" & Nyear.ToString("0#") & Nmount.ToString("0#")
        Else
            LotNo = JobSite & "-" & "OUT-" & Nyear.ToString("0#") & Nmount.ToString("0#")
        End If

        If NextMonth.Checked = True Then
            Nmount = CSng(Format(Now(), "MM")) + 1
            Nemount = Nmount.ToString("0#")
            If Nemount > "12" Then
                Nmount = 1
                Nyear = CSng(Format(Now(), "yy")) + 44
                Nemount = Nmount.ToString("0#")
                Neyear = Nyear.ToString("0#")
            End If
        End If
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
            txtLotNo.Value = dunNo
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
            txtLotNo.Value = dunNo

        End If
    End Sub
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

    Protected Sub Gen_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtIEATNo.Value) Then
            GenNum1()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('Gen สามารถซ้ำได้ !!!')", True)
        End If
    End Sub
    Private Sub GenNum1()
        Dim tmpDate As Single = CSng(Format(Now(), "dd"))
        Dim Nmount As Single = CSng(Format(Now(), "MM"))
        Dim Nyear As Single = CSng(Format(Now(), "yy"))
        Dim Nemount As String
        Dim Neyear As String
        Dim DigitNo_ As String = "000"
        Dim LotNo As String
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single
        Dim Digit_ As Single
        Dim num_ As String
        Dim dunNo As String
        Dim Type As String = "IEAT"

        Nemount = Nmount.ToString("0#")
        Neyear = Nyear.ToString("0#")

        Mount = CSng(Nemount)
        Year = CSng(Neyear)
        Digit = CSng(DigitNo_)

        If NextMonth.Checked = True Then
            Nmount = CSng(Format(Now(), "MM")) + 1
            Nemount = Nmount.ToString("0#")
            If Nemount > "12" Then
                Nmount = 1
                Nyear = CSng(Format(Now(), "yy")) + 44
                Nemount = Nmount.ToString("0#")
                Neyear = Nyear.ToString("0#")
            End If
        End If
        
        LotNo = Nyear.ToString("0#") & Nmount.ToString("0#")

        Dim sqlSearch = (From ep In db.tblGenAutoRunNoes Where ep.TypeCode = Type And ep.MountNo = Nemount And ep.YearNo = Neyear And ep.RunNo = LotNo
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
            upDateGenNum(Type, Nemount, Neyear, num_)
            txtIEATNo.Value = dunNo
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
                                .TypeCode = Type, _
                                .RunNo = LotNo, _
                                .MountNo = Nemount, _
                                .YearNo = Neyear, _
                                .DigitNo = num_
                            })
            db.SaveChanges()
            txtIEATNo.Value = dunNo

        End If
    End Sub
    Private Sub upGenLot()
        Try
            Dim upGen As tblExpGenLOT = CType((From up In db.tblExpGenLOTs Where up.EASLOTNo = txtLotNo.Value.Trim
          Select up), tblExpGenLOT)
            upGen.IEATNo = txtIEATNo.Value.Trim

            db.SaveChanges()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ข้อมูล ที่คุณใส่ ไม่ถูกต้อง !!!')", True)
        End Try
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
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
        Dim num_ As String
        Dim dunNo As String
        Dim Type As String = "LKBEASOUT"
        Nemount = Nmount.ToString("0#")
        Neyear = Nyear.ToString("0#")

        Mount = CSng(Nemount)
        Year = CSng(Neyear)
        Digit = CSng(DigitNo_)

        LotNo = "LKB " & Nyear.ToString("0#") & Nmount.ToString("0#")


        If NextMonth.Checked = True Then
            Nmount = CSng(Format(Now(), "MM")) + 1
            Nemount = Nmount.ToString("0#")
            If Nemount > "12" Then
                Nmount = 1
                Nyear = CSng(Format(Now(), "yy")) + 44
                Nemount = Nmount.ToString("0#")
                Neyear = Nyear.ToString("0#")
            End If
        End If

        Dim sqlSearch = (From ep In db.tblGenAutoRunNoes Where ep.TypeCode = Type And ep.MountNo = Nemount And ep.YearNo = Neyear And ep.RunNo = LotNo
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
            upDateGenNum(Type, Nemount, Neyear, num_)
            txtEASInv.Value = dunNo
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
                                .TypeCode = Type, _
                                .RunNo = LotNo, _
                                .MountNo = Nemount, _
                                .YearNo = Neyear, _
                                .DigitNo = num_
                            })
            db.SaveChanges()
            txtEASInv.Value = dunNo
        End If
    End Sub
    Private Sub ReadDATA()
        Dim sqlCurrency = From exp In db.tblExpInvoices Where exp.EASLOTNo = txtLotNo.Value.Trim
          Select exp.InvoiceNo,
                 exp.ReferenceNo,
                 exp.ReferenceDate,
                 exp.PurchaseOrderNo,
                 exp.InvoiceDate,
                 exp.EASLOTNo
        Try
            If sqlCurrency.Count > 0 Then
                dgvLotNo.DataSource = sqlCurrency.ToList
                dgvLotNo.DataBind()
            Else
                dgvLotNo.DataSource = Nothing
                dgvLotNo.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ReadDATA2()
        Dim sqlCurrency = From exp In db.tblRecINVs Where exp.LOTNo = txtLotNo.Value.Trim
          Select exp.InvoiceNo,
                 exp.LOTNo,
                 exp.DateInv,
                 exp.Quantity
        Try
            If sqlCurrency.Count > 0 Then
                dgvInvNo.DataSource = sqlCurrency.ToList
                dgvInvNo.DataBind()
            Else
                dgvInvNo.DataSource = Nothing
                dgvInvNo.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ReadDATAEAS()
        Dim sqlCurrency = From exp In db.tblRecEASInvoices Where exp.LOTNo = txtLotNo.Value.Trim
          Select exp.InvoiceNo,
                 exp.LOTNo,
                 exp.PullSignal,
                 exp.Remark,
                 exp.CustomerINV
        Try
            If sqlCurrency.Count > 0 Then
                dgvEASInv.DataSource = sqlCurrency.ToList
                dgvEASInv.DataBind()
            Else
                dgvEASInv.DataSource = Nothing
                dgvEASInv.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SaveDATA_New()
        Dim LOTDate As Date
        Dim DeliveryDate As Date
        Dim IEATDate As Date
        Dim fwdstatus As String = "0"
        If String.IsNullOrEmpty(txtLotNo.Value.Trim) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน LOT No ก่อน !!!');", True)
        Else

            If dtpInvoiceDate.Text = "" Then
                LOTDate = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
            Else
                LOTDate = DateTime.ParseExact(dtpInvoiceDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
            End If
            If dtpDeliveryDate.Text = "" Then
                DeliveryDate = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
            Else
                DeliveryDate = DateTime.ParseExact(dtpDeliveryDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
            End If
            If txtIEATDate.Text = "" Then
                IEATDate = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
            Else
                IEATDate = DateTime.ParseExact(txtIEATDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
            End If

            Select Case MsgBox("คุณต้องการเพิ่มรายการ LOT No ใหม่ ของ " & cboJobSite.Text.Trim & " ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
                Case MsgBoxResult.Yes
                    Try
                        db.Database.Connection.Open()

                        db.tblExpGenLOTs.Add(New tblExpGenLOT() With { _
                                    .EASLOTNo = txtLotNo.Value.Trim, _
                                    .LOTDate = LOTDate, _
                                    .LOTBy = ComboBox2.Text.Trim, _
                                    .SalesCode = dcbSales.Text.Trim, _
                                    .SalesName = txtSalesName.Value.Trim, _
                                    .ConsigneeCode = txtConsigneeCode.Value.Trim, _
                                    .ConsignNameEng = txtConsignneeEng.Value.Trim, _
                                    .ConsignAddress = txtConsignneeStreet_Number.Value.Trim, _
                                    .ConsignDistrict = txtConsignneeDistrict.Value.Trim, _
                                    .ConsignSubProvince = txtConsignneeSubProvince.Value.Trim, _
                                    .ConsignProvince = txtConsignneeProvince.Value.Trim, _
                                    .ConsignPostCode = txtConsignneePostCode.Value.Trim, _
                                    .ConsignEmail = txtConsignneeEMail.Value.Trim, _
                                    .ShipperCode = txtExporterCode.Value.Trim, _
                                    .ShipperNameEng = txtExportEng.Value.Trim, _
                                    .ShipperAddress = txtStreet_Number.Value.Trim, _
                                    .ShipperDistrict = txtDistrict.Value.Trim, _
                                    .ShipperSubprovince = txtSubProvince.Value.Trim, _
                                    .ShipperProvince = txtProvince.Value.Trim, _
                                    .ShipperPostCode = txtPostCode.Value.Trim, _
                                    .ShipperReturnCode = txtCompensateCode.Value.Trim, _
                                    .Commodity = txtCommodity.Text.Trim(), _
                                    .QuantityofPart = CType(CDbl(txtQuantityofPart.Value).ToString("#,##0.000"), Decimal?), _
                                    .QuantityUnit = dcbQuantity1.Text.Trim, _
                                    .QuantityPack = CType(CDbl(txtQuantityPLT.Value).ToString("#,##0.000"), Decimal?), _
                                    .QuantityUnitPack = dcbQuantity2.Text.Trim, _
                                    .Weight = CType(CDbl(txtWeight.Value).ToString("#,##0.000"), Decimal?), _
                                    .WeightUnit = dcbWeight.Text.Trim, _
                                    .Volume = CType(CDbl(txtVolume.Value).ToString("#,##0.000"), Double?), _
                                    .VolumeUnit = dcbVolume.Text.Trim, _
                                    .MAWB = txtMAWB.Value.Trim, _
                                    .DocType = ComboBox7.Text.Trim, _
                                    .DocCode = txtDocumentCode.Value.Trim, _
                                    .Flight = txtFlight.Value.Trim, _
                                    .ScanPathFile = txtPathFile.Value.Trim, _
                                    .DOCode = txtDOCode.Value.Trim, _
                                    .DONameENG = txtDONameENG.Value.Trim, _
                                    .DOStreet_Number = txtDOStreet.Value.Trim, _
                                    .DODistrict = txtDODistrict.Value.Trim, _
                                    .DOSubProvince = txtDOSubProvince.Value.Trim, _
                                    .DOProvince = txtDOProvince.Value.Trim, _
                                    .DOPostCode = txtDOPostCode.Value.Trim, _
                                    .DOEmail = txtDOEmail.Value.Trim, _
                                    .DOContactPerson = txtDOContactPerson.Value.Trim, _
                                    .IEATNo = txtIEATNo.Value.Trim, _
                                    .EntryNo = txtEntryNo.Value.Trim, _
                                    .DeliveryDate = DeliveryDate, _
                                    .CustomerCode = txtCustomerCode.Value.Trim, _
                                    .CustomerENG = txtCustomerENG.Value.Trim, _
                                    .CustomerStreet = txtCustomerStreet.Value.Trim, _
                                    .CustomerDistrict = txtCustomerDistrict.Value.Trim, _
                                    .CustomerSub = txtCustomerSub.Value.Trim, _
                                    .CustomerProvince = txtCustomerProvince.Value.Trim, _
                                    .CustomerPostCode = txtCustomerPostCode.Value.Trim, _
                                    .CustomerEmail = txtCustomerEmail.Value.Trim, _
                                    .CustomerContact = txtCustomerContact.Value.Trim, _
                                    .PickUpCode = txtPickUpCode.Value.Trim, _
                                    .PickUpENG = txtPickUpNameEng.Value.Trim, _
                                    .PickUpAddress1 = txtPickUpAddress1.Value.Trim, _
                                    .PickUpAddress2 = txtPickUpAddress2.Value.Trim, _
                                    .PickUpAddress3 = txtPickUpAddress3.Value.Trim, _
                                    .PickUpAddress4 = txtPickUpAddress4.Value.Trim, _
                                    .PickUpAddress5 = txtPickUpAddress5.Value.Trim, _
                                    .PickUpEmail = txtPickUpEmail.Value.Trim, _
                                    .PickUpContact = txtPickUpContact.Value.Trim, _
                                    .EndCusCode = txtEndCusCode.Value.Trim, _
                                    .EndCusENG = txtEndCusNameEng.Value.Trim, _
                                    .EndCusAddress1 = txtEndCusAddress1.Value.Trim, _
                                    .EndCusAddress2 = txtEndCusAddress2.Value.Trim, _
                                    .EndCusAddress3 = txtEndCusAddress3.Value.Trim, _
                                    .EndCusAddress4 = txtEndCusAddress4.Value.Trim, _
                                    .EndCusAddress5 = txtEndCusAddress5.Value.Trim, _
                                    .EndCusEmail = txtEndCusEmail.Value.Trim, _
                                    .EndCusContact = txtEndCusContact.Value.Trim, _
                                    .FreighForwarder = txtFreigh.Value.Trim, _
                                    .Useby = CStr(Session("UserName")), _
                                    .IEATPermit = txtIEATPermit.Value.Trim, _
                                    .ShipTo = txtShipTo.Value.Trim, _
                                    .Box = CType(CDbl(txtBox.Value).ToString("#,##0.000"), Double?), _
                                    .UnitBox = cdbBox1.Text.Trim, _
                                    .JOBBranch = "JOB", _
                                    .IEATDate = IEATDate, _
                                    .Status1 = dcbStatus1.Text.Trim, _
                                    .Status2 = dcbStatus2.Text.Trim, _
                                    .Status3 = dcbStatus3.Text.Trim, _
                                    .Remark = txtJobRemark.Value.Trim, _
                                    .JobSite = cboJobSite.Text.Trim, _
                                    .BillingNo = txtBillingNo.Value.Trim, _
                                    .CustomerCodeGroup = txtCustomerCodeGroup.Value.Trim, _
                                    .CustomerENGGroup = txtCustomerENGGroup.Value.Trim, _
                                    .DeliveryTime = txtDeliveryTime.Value.Trim, _
                                    .fwdstatus = fwdstatus
                })
                        db.SaveChanges()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('บันทึกเสร็จเรียบร้อย !');", True)
                    Catch ex As Exception
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด !!!')", True)
                    End Try
                Case MsgBoxResult.No
            End Select
        End If
    End Sub
    Private Sub ClearDATA()
        NextMonth.Checked = False
        txtLotNo.Value = ""
        Checkbox3.Checked = False
        txtShipTo.Value = ""
        txtSalesName.Value = ""
        txtConsigneeCode.Value = ""
        txtConsignneeEng.Value = ""
        txtConsignneeStreet_Number.Value = ""
        txtConsignneeDistrict.Value = ""
        txtConsignneeSubProvince.Value = ""
        txtConsignneeProvince.Value = ""
        txtConsignneePostCode.Value = ""
        txtConsignneeEMail.Value = ""
        txtExporterCode.Value = ""
        txtExportEng.Value = ""
        txtStreet_Number.Value = ""
        txtDistrict.Value = ""
        txtSubProvince.Value = ""
        txtProvince.Value = ""
        txtPostCode.Value = ""
        txtCompensateCode.Value = ""
        txtQuantityofPart.Value = "0.0"
        txtQuantityPLT.Value = "0.0"
        txtWeight.Value = "0.0"
        txtVolume.Value = "0.0"
        txtMAWB.Value = ""
        txtDocumentCode.Value = ""
        txtFlight.Value = ""
        txtPathFile.Value = ""
        txtDOCode.Value = ""
        txtDONameENG.Value = ""
        txtDOStreet.Value = ""
        txtDODistrict.Value = ""
        txtDOSubProvince.Value = ""
        txtDOProvince.Value = ""
        txtDOPostCode.Value = ""
        txtDOEmail.Value = ""
        txtDOContactPerson.Value = ""
        txtIEATNo.Value = ""
        txtEntryNo.Value = ""
        txtGenInvNo.Value = ""
        txtEASInv.Value = ""
        txtPullSignal.Value = ""
        txtCustomerCode.Value = ""
        txtCustomerENG.Value = ""
        txtCustomerStreet.Value = ""
        txtCustomerDistrict.Value = ""
        txtCustomerSub.Value = ""
        txtCustomerProvince.Value = ""
        txtCustomerPostCode.Value = ""
        txtCustomerEmail.Value = ""
        txtCustomerContact.Value = ""
        txtPickUpCode.Value = ""
        txtPickUpNameEng.Value = ""
        txtPickUpAddress1.Value = ""
        txtPickUpAddress2.Value = ""
        txtPickUpAddress3.Value = ""
        txtPickUpAddress4.Value = ""
        txtPickUpAddress5.Value = ""
        txtPickUpEmail.Value = ""
        txtPickUpContact.Value = ""
        txtEndCusCode.Value = ""
        txtEndCusNameEng.Value = ""
        txtEndCusAddress1.Value = ""
        txtEndCusAddress2.Value = ""
        txtEndCusAddress3.Value = ""
        txtEndCusAddress4.Value = ""
        txtEndCusAddress5.Value = ""
        txtEndCusEmail.Value = ""
        txtEndCusContact.Value = ""
        txtFreigh.Value = ""
        txtBox.Value = "0"
        txtJobRemark.Value = ""
        txtBillingNo.Value = ""
        txtCustomerCodeGroup.Value = ""
        txtCustomerENGGroup.Value = ""

    End Sub

    Protected Sub dcbStatus2_SelectedIndexChanged(sender As Object, e As EventArgs)
        If dcbStatus2.Text = "ใช้หรือจำหน่ายภายในประเทศ" Then
            dcbStatus3.Enabled = True
        Else
            dcbStatus3.Enabled = False
        End If
    End Sub
    Private Sub CJob()
        If cboJobSite.Text = "LKB" Then
            JOB = "LKB"
        ElseIf cboJobSite.Text = "SBIA" Then
            JOB = "SBIA"
        ElseIf cboJobSite.Text = "HCR" Then
            JOB = "HCR"
        ElseIf cboJobSite.Text = "HTO" Then
            JOB = "HTO"
        ElseIf cboJobSite.Text = "AEC" Then
            JOB = "AEC"
        ElseIf cboJobSite.Text = "SPM" Then
            JOB = "SPM"
        ElseIf cboJobSite.Text = "PTN" Then
            JOB = "PTN"
        ElseIf cboJobSite.Text = "CKT" Then
            JOB = "CKT"
        ElseIf cboJobSite.Text = "WIP" Then
            JOB = "WIP"
        End If
    End Sub
    Private Sub SavaDATA_Modify()
        If txtLotNo.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน LOT No ก่อน !!!');", True)
        End If
        Select Case MsgBox("คุณต้องการแก้ไข LOT No ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
            Case MsgBoxResult.Yes
                Try
                    Dim upExp As tblExpGenLOT = (From up In db.tblExpGenLOTs Where up.EASLOTNo = txtLotNo.Value.Trim Select up).First

                    If upExp IsNot Nothing Then
                        upExp.EASLOTNo = txtLotNo.Value.Trim
                        upExp.LOTDate = DateTime.ParseExact(dtpInvoiceDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
                        upExp.LOTBy = ComboBox2.Text.Trim
                        upExp.SalesCode = dcbSales.Text.Trim
                        upExp.SalesName = txtSalesName.Value.Trim
                        upExp.ConsigneeCode = txtConsigneeCode.Value.Trim
                        upExp.ConsignNameEng = txtConsignneeEng.Value.Trim
                        upExp.ConsignAddress = txtConsignneeStreet_Number.Value.Trim
                        upExp.ConsignDistrict = txtConsignneeDistrict.Value.Trim
                        upExp.ConsignSubProvince = txtConsignneeSubProvince.Value.Trim
                        upExp.ConsignProvince = txtConsignneeProvince.Value.Trim
                        upExp.ConsignPostCode = txtConsignneePostCode.Value.Trim
                        upExp.ConsignEmail = txtConsignneeEMail.Value
                        upExp.ShipperCode = txtExporterCode.Value.Trim
                        upExp.ShipperNameEng = txtExportEng.Value.Trim
                        upExp.ShipperAddress = txtStreet_Number.Value.Trim
                        upExp.ShipperDistrict = txtDistrict.Value.Trim
                        upExp.ShipperSubprovince = txtSubProvince.Value.Trim
                        upExp.ShipperProvince = txtProvince.Value.Trim
                        upExp.ShipperPostCode = txtPostCode.Value.Trim
                        upExp.ShipperReturnCode = txtCompensateCode.Value.Trim
                        upExp.Commodity = txtCommodity.Text.Trim
                        upExp.QuantityofPart = CType(CDbl(txtQuantityofPart.Value).ToString("#,##0.000"), Decimal?)
                        upExp.QuantityUnit = dcbQuantity1.Text.Trim
                        upExp.QuantityPack = CType(CDbl(txtQuantityPLT.Value).ToString("#,##0.000"), Decimal?)
                        upExp.QuantityUnitPack = dcbQuantity2.Text.Trim
                        upExp.Weight = CType(CDbl(txtWeight.Value).ToString("#,##0.000"), Decimal?)
                        upExp.WeightUnit = dcbWeight.Text.Trim
                        upExp.Volume = CType(CDbl(txtVolume.Value).ToString("#,##0.000"), Double?)
                        upExp.VolumeUnit = dcbVolume.Text.Trim
                        upExp.MAWB = txtMAWB.Value.Trim
                        upExp.DocType = ComboBox7.Text.Trim
                        upExp.DocCode = txtDocumentCode.Value.Trim
                        upExp.Flight = txtFlight.Value.Trim
                        upExp.ScanPathFile = txtPathFile.Value
                        upExp.DOCode = txtDOCode.Value.Trim
                        upExp.DONameENG = txtDONameENG.Value.Trim
                        upExp.DOStreet_Number = txtDOStreet.Value.Trim
                        upExp.DODistrict = txtDODistrict.Value.Trim
                        upExp.DOSubProvince = txtDOSubProvince.Value.Trim
                        upExp.DOProvince = txtDOProvince.Value.Trim
                        upExp.DOPostCode = txtDOPostCode.Value.Trim
                        upExp.DOEmail = txtDOEmail.Value.Trim
                        upExp.DOContactPerson = txtDOContactPerson.Value.Trim
                        upExp.IEATNo = txtIEATNo.Value.Trim
                        upExp.EntryNo = txtEntryNo.Value.Trim
                        upExp.DeliveryDate = DateTime.ParseExact(dtpDeliveryDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
                        upExp.CustomerCode = txtCustomerCode.Value.Trim
                        upExp.CustomerENG = txtCustomerENG.Value.Trim
                        upExp.CustomerStreet = txtCustomerStreet.Value.Trim
                        upExp.CustomerDistrict = txtCustomerDistrict.Value.Trim
                        upExp.CustomerSub = txtCustomerSub.Value.Trim
                        upExp.CustomerProvince = txtCustomerProvince.Value.Trim
                        upExp.CustomerPostCode = txtCustomerPostCode.Value.Trim
                        upExp.CustomerEmail = txtCustomerEmail.Value.Trim
                        upExp.CustomerContact = txtCustomerContact.Value.Trim
                        upExp.PickUpCode = txtPickUpCode.Value.Trim
                        upExp.PickUpENG = txtPickUpNameEng.Value.Trim
                        upExp.PickUpAddress1 = txtPickUpAddress1.Value.Trim
                        upExp.PickUpAddress2 = txtPickUpAddress2.Value.Trim
                        upExp.PickUpAddress3 = txtPickUpAddress3.Value.Trim
                        upExp.PickUpAddress4 = txtPickUpAddress4.Value.Trim
                        upExp.PickUpAddress5 = txtPickUpAddress5.Value.Trim
                        upExp.PickUpEmail = txtPickUpEmail.Value.Trim
                        upExp.PickUpContact = txtPickUpContact.Value.Trim
                        upExp.EndCusCode = txtEndCusCode.Value.Trim
                        upExp.EndCusENG = txtEndCusNameEng.Value.Trim
                        upExp.EndCusAddress1 = txtEndCusAddress1.Value.Trim
                        upExp.EndCusAddress2 = txtEndCusAddress2.Value.Trim
                        upExp.EndCusAddress3 = txtEndCusAddress3.Value.Trim
                        upExp.EndCusAddress4 = txtEndCusAddress4.Value.Trim
                        upExp.EndCusAddress5 = txtEndCusAddress5.Value.Trim
                        upExp.EndCusEmail = txtEndCusEmail.Value.Trim
                        upExp.EndCusContact = txtEndCusContact.Value.Trim
                        upExp.FreighForwarder = txtFreigh.Value.Trim
                        upExp.Useby = CStr(Session("UserName"))
                        upExp.IEATPermit = txtIEATPermit.Value.Trim
                        upExp.ShipTo = txtShipTo.Value.Trim
                        upExp.Box = CType(CDbl(txtBox.Value).ToString("#,##0.000"), Double?)
                        upExp.UnitBox = cdbBox1.Text.Trim
                        upExp.IEATDate = DateTime.ParseExact(txtIEATDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
                        upExp.Status1 = dcbStatus1.Text.Trim
                        upExp.Status2 = dcbStatus2.Text.Trim
                        upExp.Status3 = dcbStatus3.Text.Trim
                        upExp.Remark = txtJobRemark.Value.Trim
                        upExp.JobSite = cboJobSite.Text.Trim
                        upExp.BillingNo = txtBillingNo.Value.Trim
                        upExp.CustomerCodeGroup = txtCustomerCodeGroup.Value.Trim
                        upExp.CustomerENGGroup = txtCustomerENGGroup.Value.Trim
                        upExp.DeliveryTime = txtDeliveryTime.Value.Trim

                        db.SaveChanges()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไข สำเสร็จ !');", True)
                        Exit Sub
                    End If

                Catch ex As Exception
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect", ex.Message, True)
                End Try
            Case MsgBoxResult.No

        End Select
    End Sub

    Protected Sub btnInvoice_ServerClick(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtLotNo.Value.Trim) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน LOT No ก่อน !!!');", True)
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtEASInv.Value.Trim) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน EASInv ก่อน !!!');", True)
            Exit Sub

        Else
            Select Case MsgBox("คุณต้องการเพิ่มรายการ LOT No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
                Case MsgBoxResult.Yes
                    Try
                        db.tblRecEASInvoices.Add(New tblRecEASInvoice With { _
                                             .InvoiceNo = txtEASInv.Value.Trim, _
                                             .LOTNo = txtLotNo.Value.Trim, _
                                             .PullSignal = txtPullSignal.Value.Trim, _
                                             .Remark = txtRemark.Text.Trim, _
                                             .CustomerINV = txtCustomerINV.Value.Trim, _
                                             .CancleIEAT = txtCancleIEAT.Value.Trim
                                         })
                        db.SaveChanges()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('บันทึก Rec EAS Invoices เสร็จ !!!');", True)
                    Catch ex As Exception
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", ex.Message, True)
                    End Try

                Case MsgBoxResult.No

            End Select
        End If
        ReadDATAEAS()
        txtEASInv.Focus()
    End Sub

    Protected Sub cmdGenInvNo_ServerClick(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtItemNo.Value.Trim) And chkAssign.Checked = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน ItemNo ก่อน !!!');", True)
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtLotNo.Value.Trim) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน LOT No ก่อน !!!');", True)
            txtLotNo.Focus()
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtGenInvNo.Value.Trim) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน GenInvNo ก่อน !!!');", True)
            txtGenInvNo.Focus()
            Exit Sub
        Else
            If String.IsNullOrEmpty(txtQuantityDetail.Value.Trim) Then
                txtQuantityDetail.Value = "0"
            ElseIf String.IsNullOrEmpty(txtPallet.Value.Trim) Then
                txtPallet.Value = "0"
            ElseIf String.IsNullOrEmpty(txtBoxINV.Value.Trim) Then
                txtBoxINV.Value = "0"
            ElseIf String.IsNullOrEmpty(txtWeightInv.Value.Trim) Then
                txtWeightInv.Value = "0"
            Else
                Select Case MsgBox("คุณต้องการเพิ่มรายการ LOT No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
                    Case MsgBoxResult.Yes
                        Try
                            db.tblRecINVs.Add(New tblRecINV With { _
                                                                     .InvoiceNo = txtGenInvNo.Value.Trim, _
                                                                     .LOTNo = txtLotNo.Value.Trim, _
                                                                     .DateInv = DateTime.ParseExact(dtpInvoice.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                                                                     .Quantity = CType(CDbl(txtQuantityDetail.Value.Trim).ToString("#,##0.000"), Double?), _
                                                                     .QuantityUnit = cdbUnitQuantityDetail.Text.Trim, _
                                                                     .Pallet = CType(CDbl(txtPallet.Value.Trim).ToString("#,##0.000"), Double?), _
                                                                     .PalletUnit = cdbUnitPallet.Text.Trim, _
                                                                     .Box = CType(CDbl(txtBoxINV.Value).ToString("#,##0.000"), Double?), _
                                                                     .BoxUnit = cdbBox.Text.Trim(), _
                                                                     .Weight = CType(CDbl(txtWeightInv.Value.Trim).ToString("#,##0.000"), Double?), _
                                                                     .WeightUnit = cdbUnitWeightInv.Text.Trim(), _
                                                                     .Pull = txtPullS.Value.Trim, _
                                                                     .Shipment = txtShipment.Value.Trim, _
                                                                     .PriceBath = CType(CDbl(txtPriceBath.Value.Trim).ToString("#,##0.000"), Double?), _
                                                                     .PriceForeign = CType(CDbl(txtPriceForeign.Value.Trim).ToString("#,##0.000"), Double?), _
                                                                     .ItemNo = CInt(txtItemNo.Value.Trim)
                                                                 })
                            db.SaveChanges()

                            If chkAssign.Checked = True Then
                                db.tblWHRequestedISSUEs.Add(New tblWHRequestedISSUE With { _
                                                            .PullSignal = txtPullS.Value.Trim, _
                                                            .LotNo = txtLotNo.Value.Trim, _
                                                            .ItemNo = CInt(txtItemNo.Value.Trim), _
                                                            .ProductNo = "", _
                                                            .CutomerPart = "", _
                                                            .OwnerPart = "", _
                                                            .ProductDesc = "",
                                                            .RequestQTY = CType(CDbl(txtQuantityDetail.Value.Trim).ToString("#,##0.000"), Double?), _
                                                            .QTYUnit = cdbUnitQuantityDetail.Text.Trim, _
                                                            .OrderNo = "", _
                                                            .PriceForeigh = CType(CDbl(txtPriceForeign.Value.Trim).ToString("#,##0.000"), Double?), _
                                                            .PriceBath = CType(CDbl(txtPriceBath.Value.Trim).ToString("#,##0.000"), Double?), _
                                                            .CustomerLot = txtShipment.Value.Trim, _
                                                            .ManufacturingDate = Nothing, _
                                                            .ExpiredDate = Nothing, _
                                                            .CreateBy = Session("UserName").ToString, _
                                                            .CreateDate = Now
                                                        })
                                db.SaveChanges()
                            End If
                        Catch ex As Exception
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", ex.Message, True)
                        End Try

                End Select
            End If

        End If
        ReadDATA2()
        txtLotNo.Focus()
        ClearDataInv()

    End Sub
    Private Sub ClearDataInv()
        txtGenInvNo.Value = ""
        dtpInvoice.Text = CStr(Now)
        txtQuantityDetail.Value = "0"
        cdbUnitQuantityDetail.Text = ""
        txtPallet.Value = "0"
        cdbUnitPallet.Text = ""
        txtBoxINV.Value = "0"
        cdbBox.Text = ""
        txtWeightInv.Value = "0"
        cdbUnitWeightInv.Text = ""
        txtPullS.Value = ""
        txtPriceBath.Value = ""
        txtPriceForeign.Value = ""
    End Sub

    Protected Sub Button4_ServerClick(sender As Object, e As EventArgs)

        If String.IsNullOrEmpty(txtLotNo.Value.Trim) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน LOT No ก่อน !!!');", True)
            txtLotNo.Focus()
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtGenInvNo.Value.Trim) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน INV ก่อน !!!');", True)
            txtGenInvNo.Focus()
            Exit Sub
        Else
            If String.IsNullOrEmpty(txtQuantityDetail.Value.Trim) Then
                txtQuantityDetail.Value = "0"
            ElseIf String.IsNullOrEmpty(txtPallet.Value.Trim) Then
                txtPallet.Value = "0"
            ElseIf String.IsNullOrEmpty(txtBoxINV.Value.Trim) Then
                txtBoxINV.Value = "0"
            ElseIf String.IsNullOrEmpty(txtWeightInv.Value.Trim) Then
                txtWeightInv.Value = "0"
            Else
                Select Case MsgBox("คุณต้องการเพิ่มรายการ INV ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
                    Case MsgBoxResult.Yes
                        Try
                            Dim upRec As tblRecINV = (From r In db.tblRecINVs Where r.InvoiceNo = txtGenInvNo.Value.Trim And r.LOTNo = txtLotNo.Value.Trim Select r).First
                            If upRec IsNot Nothing Then
                                upRec.InvoiceNo = txtGenInvNo.Value.Trim
                                upRec.LOTNo = txtLotNo.Value.Trim
                                upRec.DateInv = DateTime.ParseExact(dtpInvoice.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
                                upRec.Quantity = CType(CDbl(txtQuantityDetail.Value.Trim).ToString("#,##0.000"), Double?)
                                upRec.QuantityUnit = cdbUnitQuantityDetail.Text.Trim
                                upRec.Pallet = CType(CDbl(txtPallet.Value.Trim).ToString("#,##0.000"), Double?)
                                upRec.PalletUnit = cdbUnitPallet.Text.Trim
                                upRec.Box = CType(CDbl(txtBoxINV.Value).ToString("#,##0.000"), Double?)
                                upRec.BoxUnit = cdbBox.Text.Trim()
                                upRec.Weight = CType(CDbl(txtWeightInv.Value.Trim).ToString("#,##0.000"), Double?)
                                upRec.WeightUnit = cdbUnitWeightInv.Text.Trim()
                                upRec.Pull = txtPullS.Value.Trim
                                upRec.Shipment = txtShipment.Value.Trim
                                upRec.PriceBath = CType(CDbl(txtPriceBath.Value.Trim).ToString("#,##0.000"), Double?)
                                upRec.PriceForeign = CType(CDbl(txtPriceForeign.Value.Trim).ToString("#,##0.000"), Double?)
                                upRec.ItemNo = CInt(txtItemNo.Value.Trim)

                                db.SaveChanges()
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล INV เรียบร้อยแล้ว !!!')", True)
                            Else
                                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ข้อมูล ที่คุณใส่ ไม่ถูกต้อง !!')", True)
                            End If

                        Catch ex As Exception
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", ex.Message, True)
                        End Try

                End Select
            End If
            ReadDATA2()
            txtLotNo.Focus()
            ClearDataInv()
        End If
    End Sub
    Private Sub InsertData()
        Dim time As Date
        Dim NameUser As String
        time = CDate((Format(Now)))
        NameUser = CStr(Session("UserName"))
        Try
            db.tblLogExpGenLOTs.Add(New tblLogExpGenLOT With { _
                                .EASLOTNo = txtLotNo.Value.Trim, _
                                .ConsigneeCode = txtConsigneeCode.Value.Trim, _
                                .ShipperCode = txtExporterCode.Value.Trim, _
                                .UserBy = NameUser, _
                                .LastUpDate = time
                            })
            db.SaveChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnSaveEdit_ServerClick(sender As Object, e As EventArgs)
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmExpGenLot"
        If classPermis.CheckEdit(form, usename) = True Then
            SavaDATA_Modify()
            InsertData()
            ClearDATA()
            ReadDATA()
            ReadDATA2()
            ReadDATAEAS()
        Else

        End If
    End Sub

    Protected Sub Bsave_Click(sender As Object, e As EventArgs)
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmExpGenLot"
        If classPermis.CheckSave(form, usename) = True Then
            SavaDATA_Modify()
            ReadDATA()
            ReadDATA2()
        End If
    End Sub

    Private Sub DeleteInvEAS()
        If String.IsNullOrEmpty(txtLotNo.Value.Trim) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เลือกข้อมูลที่ต้องการ Delete ก่อน !!!')", True)
            txtLotNo.Focus()
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtEASInv.Value.Trim) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เลือกข้อมูลที่ต้องการ Delete ก่อน !!!')", True)
            txtEASInv.Focus()
            Exit Sub
        Else
            Select Case MsgBox("คุณต้องการลบข้อมูล Lot No. ใช่หรือไม่?", MsgBoxStyle.YesNo, "คำยืนยัน")
                Case MsgBoxResult.Yes

                    Dim deq = (From c In db.tblRecEASInvoices Where c.InvoiceNo = txtEASInv.Value.Trim)
                    If Not IsNothing(deq) Then
                        db.tblRecEASInvoices.Remove(CType(deq, tblRecEASInvoice))

                    End If
                    db.SaveChanges()

            End Select
        End If

    End Sub

    Protected Sub btnInv_ServerClick(sender As Object, e As EventArgs)
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmExpGenLot"
        If classPermis.CheckDelete(form, usename) = True Then
            DeleteInvEAS()
            ReadDATAEAS()
        End If
    End Sub

    Protected Sub cmdDeleteInv_ServerClick(sender As Object, e As EventArgs)

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
    Protected Sub lnkPartyCode_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
              Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtConsigneeCode.Value = ""
        Else
            txtConsigneeCode.Value = eano.p.PartyCode
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

        If String.IsNullOrEmpty(eano.pa.ZipCode) Then
            txtConsignneePostCode.Value = ""
        Else
            txtConsignneePostCode.Value = eano.pa.ZipCode
        End If

        If String.IsNullOrEmpty(eano.pa.email) Then
            txtConsignneeEMail.Value = ""
        Else
            txtConsignneeEMail.Value = eano.pa.email
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

        If String.IsNullOrEmpty(eano.pa.ZipCode) Then
            txtPostCode.Value = ""
        Else
            txtPostCode.Value = eano.pa.ZipCode
        End If

        If String.IsNullOrEmpty(eano.pa.email) Then
            txtCompensateCode.Value = ""
        Else
            txtCompensateCode.Value = eano.pa.email
        End If
    End Sub

    Protected Sub lnkPartyCode_code_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)

        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                 Where p.PartyCode = PartyCode).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtDOCode.Value = ""
        Else
            txtDOCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtDONameENG.Value = ""
        Else
            txtDONameENG.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtDOStreet.Value = ""
        Else
            txtDOStreet.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtDODistrict.Value = ""
        Else
            txtDODistrict.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtDOSubProvince.Value = ""
        Else
            txtDOSubProvince.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtDOProvince.Value = ""
        Else
            txtDOProvince.Value = eano.pa.Address4
        End If

        If String.IsNullOrEmpty(eano.pa.ZipCode) Then
            txtDOPostCode.Value = ""
        Else
            txtDOPostCode.Value = eano.pa.ZipCode
        End If

        If String.IsNullOrEmpty(eano.pa.email) Then
            txtDOEmail.Value = ""
        Else
            txtDOEmail.Value = eano.pa.email
        End If
        If String.IsNullOrEmpty(eano.pa.Attn) Then
            txtDOContactPerson.Value = ""
        Else
            txtDOContactPerson.Value = eano.pa.Attn
        End If
    End Sub

    Protected Sub dgvcodeconsignnee_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
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

    Protected Sub dgvCustomer_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
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

    Protected Sub lnkPartyCode_cus_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                 Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtCustomerCode.Value = ""
        Else
            txtCustomerCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtCustomerENG.Value = ""
        Else
            txtCustomerENG.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtCustomerStreet.Value = ""
        Else
            txtCustomerStreet.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtCustomerDistrict.Value = ""
        Else
            txtCustomerDistrict.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtCustomerSub.Value = ""
        Else
            txtCustomerSub.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtCustomerProvince.Value = ""
        Else
            txtCustomerProvince.Value = eano.pa.Address4
        End If

        If String.IsNullOrEmpty(eano.pa.ZipCode) Then
            txtCustomerPostCode.Value = ""
        Else
            txtCustomerPostCode.Value = eano.pa.ZipCode
        End If

        If String.IsNullOrEmpty(eano.pa.email) Then
            txtCustomerEmail.Value = ""
        Else
            txtCustomerEmail.Value = eano.pa.email
        End If
        If String.IsNullOrEmpty(eano.pa.Attn) Then
            txtCustomerContact.Value = ""
        Else
            txtCustomerContact.Value = eano.pa.Attn
        End If
    End Sub

    Protected Sub lnkPartyCode_pick_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                 Where p.PartyCode = PartyCode).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtPickUpCode.Value = ""
        Else
            txtPickUpCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtPickUpNameEng.Value = ""
        Else
            txtPickUpNameEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtPickUpAddress1.Value = ""
        Else
            txtPickUpAddress1.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtPickUpAddress2.Value = ""
        Else
            txtPickUpAddress2.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtPickUpAddress3.Value = ""
        Else
            txtPickUpAddress3.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtPickUpAddress4.Value = ""
        Else
            txtPickUpAddress4.Value = eano.pa.Address4
        End If

        If String.IsNullOrEmpty(eano.pa.ZipCode) Then
            txtPickUpAddress5.Value = ""
        Else
            txtPickUpAddress5.Value = eano.pa.ZipCode
        End If

        If String.IsNullOrEmpty(eano.pa.email) Then
            txtPickUpEmail.Value = ""
        Else
            txtPickUpEmail.Value = eano.pa.email
        End If

        If String.IsNullOrEmpty(eano.pa.Attn) Then
            txtPickUpContact.Value = ""
        Else
            txtPickUpContact.Value = eano.pa.Attn
        End If
    End Sub

    Protected Sub dgvPickUp_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
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

    Protected Sub dgvEndCus_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
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

    Protected Sub lnkPartyCode_End_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                 Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtEndCusCode.Value = ""
        Else
            txtEndCusCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtEndCusNameEng.Value = ""
        Else
            txtEndCusNameEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtEndCusAddress1.Value = ""
        Else
            txtEndCusAddress1.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtEndCusAddress2.Value = ""
        Else
            txtEndCusAddress2.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtEndCusAddress3.Value = ""
        Else
            txtEndCusAddress3.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtEndCusAddress4.Value = ""
        Else
            txtEndCusAddress4.Value = eano.pa.Address4
        End If

        If String.IsNullOrEmpty(eano.pa.ZipCode) Then
            txtEndCusAddress5.Value = ""
        Else
            txtEndCusAddress5.Value = eano.pa.ZipCode
        End If

        If String.IsNullOrEmpty(eano.pa.email) Then
            txtEndCusEmail.Value = ""
        Else
            txtEndCusEmail.Value = eano.pa.email
        End If

        If String.IsNullOrEmpty(eano.pa.Attn) Then
            txtEndCusContact.Value = ""
        Else
            txtEndCusContact.Value = eano.pa.Attn
        End If
    End Sub

    Protected Sub lnkPartyCode_Group_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                 Where p.PartyCode = PartyCode).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtCustomerCodeGroup.Value = ""
        Else
            txtCustomerCodeGroup.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtCustomerENGGroup.Value = ""
        Else
            txtCustomerENGGroup.Value = eano.p.PartyFullName
        End If

    End Sub

    Protected Sub dgvCustomerGroup_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyAdd As Label = CType(e.Item.FindControl("lblPartyAdd"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
           
            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString
            End If
            If Not IsNothing(lblPartyAdd) Then
                lblPartyAdd.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString
            End If
            If Not IsNothing(lblPartyFullName) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString
            End If
            
        End If
    End Sub

    Protected Sub dcbSales_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim mas = (From m In db.tblMasterCode2 Where m.Code = dcbSales.Text.Trim Select m.Code, m.Description).SingleOrDefault
        txtSalesName.Value = mas.Description
    End Sub
End Class