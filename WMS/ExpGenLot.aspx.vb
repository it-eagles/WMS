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

Public Class ExpGenLot
    Inherits System.Web.UI.Page
    'Dim Conn As SqlConnection
    'Dim com As SqlCommand
    'Dim tr As SqlTransaction
    Dim sb As StringBuilder
    'Dim dr As SqlDataReader
    Dim tmpButtonStatus As String
    Dim sqlDataComboList As String
    Dim JOB As String
    'Public PV As New frmExpCustomsInvoiceRPT
    'Dim ClassPermis As ClassPermis
   
    Dim classPermis As New ClassPermis

    Dim db As New LKBWarehouseEntities1_Test

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmExpGenLot"
        If Not Me.IsPostBack Then
            If classPermis.CheckRead(form, usename) Then
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
                    showVisible()
                    btnSaveNew.Visible = False
                    btnSaveEdit.Visible = False
                    btnSeletJob.Visible = False
                End If    
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
                Response.Redirect("HomeMain.aspx")
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
    Private Sub ReadDATA()

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
        Dim exl = (From e In db.tblExpGenLOTs Where e.EASLOTNo = txtLotNo.Value.Trim Or e.LOTDate.Year = testdate
                 Select New With {
                 e.EASLOTNo,
                 e.CustomerCode,
                 e.JobSite,
                 e.EndCusCode}).ToList


        Try

          
                If exl.Count > 0 Then
                    Me.dgvLotNo.DataSource = exl
                    Me.dgvLotNo.DataBind()
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "show", "$(function () { $('#" + Panel1.ClientID + "').modal('show'); });", True)
                    UpdatePanel1.Update()
                Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
                Exit Sub
                End If
          
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Unnamed_ServerClick(sender As Object, e As EventArgs)

            selectExpGenLOT()
    End Sub
    Private Sub selectConsigneeCode()
        Dim cons_code As String

        If String.IsNullOrEmpty(txtConsigneeCode.Value.Trim) Then
            cons_code = ""

        Else
            cons_code = txtConsigneeCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2

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

        If String.IsNullOrEmpty(txtExporterCode.Value.Trim) Then
            exp_code = ""

        Else
            exp_code = txtExporterCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = exp_code And p.Shipper = "0") Or p.Shipper = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2

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

        If String.IsNullOrEmpty(txtDOCode.Value.Trim) Then
            code_code = ""

        Else
            code_code = txtDOCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = code_code And p.Shipper = "0" And p.Consignee = "0" And p.EndCustomer = "0") Or
              (p.Consignee = "0" And p.EndCustomer = "0" And p.Shipper = "0")
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2

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
        selectExporterCode()
    End Sub
    Private Sub selectCustomerCode()
        Dim cum_code As String

        If String.IsNullOrEmpty(txtCustomerCode.Value.Trim) Then
            cum_code = ""

        Else
            cum_code = txtCustomerCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cum_code And p.Consignee = "0") Or p.Consignee = "0"
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2

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
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2

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
        Select p.PartyCode, p.PartyFullName, pa.Address1, pa.Address2

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

    Protected Sub dgvLotNo_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim EASLOTNo As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("selectLotNO") Then
            Dim exp = (From ex In db.tblExpGenLOTs Where ex.EASLOTNo = EASLOTNo).SingleOrDefault

            'Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
            'Where p.PartyCode = EASLOTNo Select p).SingleOrDefault
            If String.IsNullOrEmpty(exp.EASLOTNo) Then
                txtLotNo.Value = ""
            Else
                txtConsigneeCode.Value = exp.EASLOTNo
            End If
            dtpInvoiceDate.Text = Convert.ToDateTime(exp.LOTDate).ToString("dd/MM/yyyy")
            'Checkbox3.Checked = CBool(exp.LOTBy)
            dcbSales.Text = exp.SalesCode
            txtSalesName.Value = exp.SalesName
            txtConsigneeCode.Value = exp.ConsigneeCode
            txtConsignneeEng.Value = exp.ConsignNameEng
            txtConsignneeStreet_Number.Value = exp.ConsignAddress
            txtConsignneeDistrict.Value = exp.ConsignDistrict
            txtConsignneeSubProvince.Value = exp.ConsignSubProvince
            txtConsignneeProvince.Value = exp.ConsignProvince
            txtConsignneePostCode.Value = exp.ConsignPostCode
            txtConsignneeEMail.Value = exp.ConsignEmail
            txtExporterCode.Value = exp.ShipperCode
            txtExportEng.Value = exp.ShipperNameEng
            txtStreet_Number.Value = exp.ShipperAddress
            txtDistrict.Value = exp.ShipperDistrict
            txtSubProvince.Value = exp.ShipperSubprovince
            txtProvince.Value = exp.ShipperProvince
            txtPostCode.Value = exp.ShipperPostCode
            txtCompensateCode.Value = exp.ShipperReturnCode
            txtCommodity.Text = exp.Commodity
            txtQuantityofPart.Value = CStr(exp.QuantityofPart)
            dcbQuantity1.Text = exp.QuantityUnit
            txtQuantityPLT.Value = CStr(exp.QuantityPack)
            dcbQuantity2.Text = exp.QuantityUnitPack
            txtWeight.Value = CStr(exp.Weight)
            dcbWeight.Text = exp.WeightUnit
            txtVolume.Value = CStr(exp.Volume)
            dcbVolume.Text = exp.VolumeUnit
            txtMAWB.Value = exp.MAWB
            ComboBox7.Text = exp.DocType
            txtDocumentCode.Value = exp.DocCode
            txtFlight.Value = exp.Flight
            txtStatusFile.Value = exp.ScanPathFile
            txtDOCode.Value = exp.DOCode
            txtDONameENG.Value = exp.DONameENG
            txtDOStreet.Value = exp.DOStreet_Number
            txtDODistrict.Value = exp.DODistrict
            txtDOSubProvince.Value = exp.DOSubProvince
            txtDOProvince.Value = exp.DOProvince
            txtDOPostCode.Value = exp.DOPostCode
            txtDOEmail.Value = exp.DOEmail
            txtDOContactPerson.Value = exp.DOContactPerson
            txtIEATNo.Value = exp.IEATNo
            txtEntryNo.Value = exp.EntryNo
            dtpDeliveryDate.Text = Convert.ToDateTime(exp.DeliveryDate).ToString("dd/MM/yyyy")
            txtCustomerCode.Value = exp.CustomerCode
            txtCustomerENG.Value = exp.CustomerENG
            txtCustomerStreet.Value = exp.CustomerStreet
            txtCustomerDistrict.Value = exp.CustomerDistrict
            txtCustomerSub.Value = exp.CustomerSub
            txtCustomerProvince.Value = exp.CustomerProvince
            txtCustomerPostCode.Value = exp.CustomerPostCode
            txtCustomerEmail.Value = exp.CustomerEmail
            txtCustomerContact.Value = exp.CustomerContact
            txtPickUpCode.Value = exp.PickUpCode
            txtPickUpNameEng.Value = exp.PickUpENG
            txtPickUpAddress1.Value = exp.PickUpAddress1
            txtPickUpAddress2.Value = exp.PickUpAddress2
            txtPickUpAddress3.Value = exp.PickUpAddress3
            txtPickUpAddress4.Value = exp.PickUpAddress4
            txtPickUpAddress5.Value = exp.PickUpAddress5
            txtPickUpEmail.Value = exp.PickUpEmail
            txtPickUpContact.Value = exp.PickUpContact
            txtEndCusCode.Value = exp.EndCusCode
            txtEndCusNameEng.Value = exp.EndCusENG
            txtEndCusAddress1.Value = exp.EndCusAddress1
            txtEndCusAddress2.Value = exp.EndCusAddress2
            txtEndCusAddress3.Value = exp.EndCusAddress3
            txtEndCusAddress4.Value = exp.EndCusAddress4
            txtEndCusAddress5.Value = exp.EndCusAddress5
            txtEndCusEmail.Value = exp.EndCusEmail
            txtEndCusContact.Value = exp.EndCusContact
            txtFreigh.Value = exp.FreighForwarder
            txtIEATPermit.Value = exp.IEATPermit
            txtShipTo.Value = exp.ShipTo
            txtBox.Value = CStr(exp.Box)
            cdbBox1.Text = exp.UnitBox
            txtIEATDate.Text = Convert.ToDateTime(exp.IEATDate).ToString("dd/MM/yyyy")
            dcbStatus1.Text = exp.Status1
            dcbStatus2.Text = exp.Status2
            dcbStatus3.Text = exp.Status3
            txtJobRemark.Value = exp.Remark
            cboJobSite.Text = exp.JobSite
            txtBillingNo.Value = exp.BillingNo
            txtCustomerCodeGroup.Value = exp.CustomerCodeGroup
            txtCustomerENGGroup.Value = exp.CustomerENGGroup
            txtDeliveryTime.Value = exp.DeliveryTime
        End If
    End Sub

    Protected Sub dgvConsigneeCode_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim PartyCode As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("SelectPartyCoder") Then
            Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode).SingleOrDefault

            'Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
            'Where p.PartyCode = EASLOTNo Select p).SingleOrDefault
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

        End If
    End Sub

    Protected Sub dgvExporterCode_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim PartyCode As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("SelectPartyCoder") Then
            Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode).SingleOrDefault

            'Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
            'Where p.PartyCode = EASLOTNo Select p).SingleOrDefault
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

        End If
    End Sub

    Protected Sub dgvcodeconsignnee_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim PartyCode As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("SelectPartyCoder") Then
            Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode).SingleOrDefault

            'Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
            'Where p.PartyCode = EASLOTNo Select p).SingleOrDefault
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
        End If
    End Sub

    Protected Sub dgvCustomer_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim PartyCode As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("SelectPartyCoder") Then
            Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode).SingleOrDefault

            'Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
            'Where p.PartyCode = EASLOTNo Select p).SingleOrDefault
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
        End If
    End Sub

    Protected Sub dgvPickUp_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim PartyCode As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("SelectPartyCoder") Then
            Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode).SingleOrDefault

            'Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
            'Where p.PartyCode = EASLOTNo Select p).SingleOrDefault
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
        End If
    End Sub

    Protected Sub dgvEndCus_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim PartyCode As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("SelectPartyCoder") Then
            Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode).SingleOrDefault

            'Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
            'Where p.PartyCode = EASLOTNo Select p).SingleOrDefault
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
        End If
    End Sub

    Protected Sub dgvCustomerGroup_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim PartyCode As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("SelectPartyCoder") Then
            Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
                  Where p.PartyCode = PartyCode).SingleOrDefault

            'Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
            'Where p.PartyCode = EASLOTNo Select p).SingleOrDefault
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

        End If
    End Sub

    Protected Sub btnAddNew_ServerClick(sender As Object, e As EventArgs)
        showVisible()
        btnSeletJob.Visible = False
        btnSaveEdit.Visible = False
        btnSaveNew.Visible = True
    End Sub

    Protected Sub btnEdit_ServerClick(sender As Object, e As EventArgs)
        showVisibleEdit()
        btnSeletJob.Visible = True
        btnSaveEdit.Visible = True
        btnSaveNew.Visible = False
    End Sub
    Private Sub showVisible()
        txtIEATNo.Disabled = True
        Checkbox1.Disabled = True
        txtIEATPermit.Disabled = True
        txtEntryNo.Disabled = True
        txtDeliveryTime.Disabled = True
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
        dcbStatus1.Enabled = False
        dcbStatus2.Enabled = False
        dcbStatus3.Enabled = False
        dtpDeliveryDate.Enabled = False
        Gen.Enabled = False
        Button2.Enabled = False
        txtIEATDate.Enabled = False
    End Sub

    Private Sub showVisibleEdit()
        txtIEATNo.Disabled = False
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
        Gen.Enabled = True
        Button2.Enabled = True
        txtIEATDate.Enabled = True
    End Sub

    Protected Sub btnSaveNew_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim from As String = "frmExpGenLot"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = user And um.Save_ = 1
        If cu.Any Then

            If cboJobSite.Text = "LKB" Then
                GenNum()
            ElseIf cboJobSite.Text = "SBIA" Then
                GenNumSBIA()
            ElseIf cboJobSite.Text = "HCR" Then
                GenNumHCR()
            ElseIf cboJobSite.Text = "HTO" Then
                GenNumHTO()
            ElseIf cboJobSite.Text = "AEC" Then
                GenNumAEC()
            ElseIf cboJobSite.Text = "MJB" Then
                GenNumMJB()
            ElseIf cboJobSite.Text = "LEA" Then
                GenNumLEA()
            ElseIf cboJobSite.Text = "SPM" Then
                GenNumSPM()
            ElseIf cboJobSite.Text = "PTN" Then
                GenNumPTN()
            ElseIf cboJobSite.Text = "CKT" Then
                GenNumCKT()
            ElseIf cboJobSite.Text = "WIP" Then
                GenNumWIP()
            End If

        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If

    End Sub
    Private Sub GenNum()
        Dim tmpDate As Single
        Dim tmpMount As Single
        'Dim tmpYear As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single

        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy")) + 43

        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)

        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            ElseIf tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If

        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        LotNo = "LKB-" & "OUT-" & Nmount.ToString("0#") & tmpMount.ToString("0#") & Num.ToString("00#")

        txtLotNo.Value = LotNo

        txtTypeCode.Value = "ExpLOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("00#")

        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try
    End Sub
    Private Sub Gentbl()
        'Dim sqlSearch As String
        Dim Nmount As Single = CSng(Format(Now(), "MM"))
        Dim Nyear As Single = CSng(Format(Now(), "yy")) + 43
        Dim Nemount As String
        Dim Neyear As String
        Nemount = Nmount.ToString("0#")
        Neyear = Nyear.ToString("0#")
        If NextMonth.Checked = True Then
            Nmount = CSng(Format(Now(), "MM")) + 11
            Nemount = Nmount.ToString("0#")
            If Nemount > "12" Then
                Nmount = 1
                Nyear = CSng(Format(Now(), "yy")) + 44
                Nemount = Nmount.ToString("0#")
                Neyear = Nyear.ToString("0#")
            End If
        End If
        Dim sqlSearch = (From ep In db.tblGenAutoNoes Where ep.TypeCode = "ExpLOTOUT" And ep.MountNo = Nemount And ep.YearNo = Neyear
                Group By TypeCode = ep.TypeCode,
                MountNo = ep.MountNo,
                YearNo = ep.YearNo Into g = Group, Count())
        'Group By ep.TypeCode,ep.MountNo,ep.YearNo Into

    End Sub
    Private Sub GenNumSBIA()
        Dim tmpDate As Single
        Dim tmpMount As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single

        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy"))

        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)

        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If

        LotNo = "SVO-" & Nmount.ToString("0#") & "-" & tmpMount.ToString("0#") & "-" & Num.ToString("000#")
        txtLotNo.Value = LotNo

        txtTypeCode.Value = "SBIALOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("000#")
        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try
    End Sub
    Private Sub GentblSBIA()

    End Sub
    Private Sub GenNumHCR()
        Dim tmpDate As Single
        Dim tmpMount As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single

        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy")) + 43

        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)

        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        LotNo = "HCR-" & "OUT-" & Nmount.ToString("0#") & tmpMount.ToString("0#") & Num.ToString("00#")
        txtLotNo.Value = LotNo

        txtTypeCode.Value = "HCRLOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("00#")
        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try
    End Sub
    Private Sub GentblHCR()

    End Sub
    Private Sub GenNumHTO()
        Dim tmpDate As Single
        Dim tmpMount As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single

        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy")) + 43
        'tmpYear = Format(CDate(Nmount), "yy")
        'GentblHTO()
        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)
        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        LotNo = "HTO-" & "OUT-" & Nmount.ToString("0#") & tmpMount.ToString("0#") & Num.ToString("00#")
        txtLotNo.Value = LotNo

        txtTypeCode.Value = "HTOLOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("00#")
        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try
    End Sub
    Private Sub GentblHTO()

    End Sub
    Private Sub GenNumAEC()
        Dim tmpDate As Single
        Dim tmpMount As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single

        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy")) + 43
        'tmpYear = Format(CDate(Nmount), "yy")
        GentblAEC()
        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)
        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        LotNo = "AEC-" & "OUT-" & Nmount.ToString("0#") & tmpMount.ToString("0#") & Num.ToString("00#")
        txtLotNo.Value = LotNo

        txtTypeCode.Value = "AECLOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("00#")
        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try
    End Sub
    Private Sub GentblAEC()

    End Sub

    Private Sub GenNumMJB()
        Dim tmpDate As Single
        Dim tmpMount As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single

        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy")) + 43
        'tmpYear = Format(CDate(Nmount), "yy")
        GentblMJB()
        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)
        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        LotNo = "MJB-" & "OUT-" & Nmount.ToString("0#") & tmpMount.ToString("0#") & Num.ToString("00#")
        txtLotNo.Value = LotNo

        txtTypeCode.Value = "MJBLOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("00#")
        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try
    End Sub
    Private Sub GentblMJB()

    End Sub

    Private Sub GenNumLEA()
        Dim tmpDate As Single
        Dim tmpMount As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single
        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy")) + 43
        'tmpYear = Format(CDate(Nmount), "yy")
        GentblLEA()
        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)
        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        LotNo = "LEA-" & "OUT-" & Nmount.ToString("0#") & tmpMount.ToString("0#") & Num.ToString("00#")
        txtLotNo.Value = LotNo

        txtTypeCode.Value = "LEALOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("00#")
        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try

    End Sub
    Private Sub GentblLEA()

    End Sub
    Private Sub GenNumSPM()
        Dim tmpDate As Single
        Dim tmpMount As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single

        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy")) + 43
        'tmpYear = Format(CDate(Nmount), "yy")
        GentblSPM()
        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)
        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        LotNo = cboJobSite.Text & "-" & "OUT-" & Nmount.ToString("0#") & tmpMount.ToString("0#") & Num.ToString("00#")
        txtLotNo.Value = LotNo

        txtTypeCode.Value = "SPMLOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("00#")
        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try
    End Sub
    Private Sub GentblSPM()

    End Sub
    Private Sub GenNumPTN()
        Dim tmpDate As Single
        Dim tmpMount As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single

        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy")) + 43
        'tmpYear = Format(CDate(Nmount), "yy")
        GentblPTN()
        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)
        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        LotNo = CStr(cboJobSite.Text & "-" & "OUT-" & Nmount.ToString("0#") & tmpMount.ToString("0#") & Num.ToString("00#"))
        txtLotNo.Value = LotNo

        txtTypeCode.Value = "PTNLOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("00#")
        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try
    End Sub
    Private Sub GentblPTN()

    End Sub
    Private Sub GenNumCKT()
        Dim tmpDate As Single
        Dim tmpMount As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single

        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy")) + 43
        'tmpYear = Format(CDate(Nmount), "yy")
        GentblCKT()
        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)
        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        LotNo = CStr(cboJobSite.Text & "-" & "OUT-" & Nmount.ToString("0#") & tmpMount.ToString("0#") & Num.ToString("00#"))
        txtLotNo.Value = LotNo

        txtTypeCode.Value = "CKTLOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("00#")
        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try
    End Sub
    Private Sub GentblCKT()

    End Sub
    Private Sub GenNumWIP()
        Dim tmpDate As Single
        Dim tmpMount As Single
        Dim LotNo As String
        Dim Nmount As Single
        Dim Num As Single
        Dim Mount As Single
        Dim Year As Single
        Dim Digit As Single

        tmpDate = CSng(Format(Now(), "dd"))
        tmpMount = CSng(Format(Now(), "MM"))
        Nmount = CSng(Format(Now(), "yy")) + 43
        'tmpYear = Format(CDate(Nmount), "yy")
        GentblWIP()
        Mount = CSng(txtMountNo.Value)
        Year = CSng(txtYearNo.Value)
        Digit = CSng(txtDigitNo.Value)
        If Nmount = Year Then
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        If Nmount <> Year Then
            Nmount = Year
            If tmpMount = Mount Then
                Digit = Digit + 1
                Num = Digit
            End If

            If tmpMount <> Mount Then
                tmpMount = Mount
                Num = Digit + 1
            End If
        End If
        LotNo = cboJobSite.Text & "-" & "OUT-" & Nmount.ToString("0#") & tmpMount.ToString("0#") & Num.ToString("00#")
        txtLotNo.Value = LotNo

        txtTypeCode.Value = "WIPLOTOUT"
        txtRunNo.Value = LotNo
        txtMountNo.Value = tmpMount.ToString("0#")
        txtYearNo.Value = Nmount.ToString("0#")
        txtDigitNo.Value = Num.ToString("00#")
        Try
            db.tblGenAutoNoes.Add(New tblGenAutoNo With { _
                                .TypeCode = txtTypeCode.Value.Trim, _
                                .RunNo = txtRunNo.Value.Trim, _
                                .MountNo = txtMountNo.Value.Trim, _
                                .YearNo = txtYearNo.Value.Trim, _
                                .DigitNo = txtDigitNo.Value.Trim
                            })
            db.SaveChanges()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณป้อน ข้อมูล. ซ้ำ !!!')", True)
        End Try
    End Sub
    Private Sub GentblWIP()

    End Sub
End Class