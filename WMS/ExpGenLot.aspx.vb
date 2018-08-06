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
                End If    
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
                Response.Redirect("HomeMain.aspx")
            End If
            'cdbUnitPallet
        End If
    End Sub
    Private Sub showQuatity1()
        dcbQuantity1.Items.Clear()
        dcbQuantity1.Items.Add(New ListItem("select Code"))
        dcbQuantity1.AppendDataBoundItems = True

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
        dcbQuantity2.Items.Clear()
        dcbQuantity2.Items.Add(New ListItem("select Code"))
        dcbQuantity2.AppendDataBoundItems = True

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
        dcbWeight.Items.Clear()
        dcbWeight.Items.Add(New ListItem("select Weight"))
        dcbWeight.AppendDataBoundItems = True

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
        dcbVolume.Items.Clear()
        dcbVolume.Items.Add(New ListItem("select Volume"))
        dcbVolume.AppendDataBoundItems = True

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
        dcbSales.Items.Clear()
        dcbSales.Items.Add(New ListItem("select Volume"))
        dcbSales.AppendDataBoundItems = True

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
        cdbUnitQuantityDetail.Items.Clear()
        cdbUnitQuantityDetail.Items.Add(New ListItem("select Unit"))
        cdbUnitQuantityDetail.AppendDataBoundItems = True

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
        cdbUnitPallet.Items.Clear()
        cdbUnitPallet.Items.Add(New ListItem("select Pallet"))
        cdbUnitPallet.AppendDataBoundItems = True

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
        cdbBox.Items.Clear()
        cdbBox.Items.Add(New ListItem("select Pallet"))
        cdbBox.AppendDataBoundItems = True

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
        cdbUnitWeightInv.Items.Clear()
        cdbUnitWeightInv.Items.Add(New ListItem("select Pallet"))
        cdbUnitWeightInv.AppendDataBoundItems = True

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
        cdbBox1.Items.Clear()
        cdbBox1.Items.Add(New ListItem("select Pallet"))
        cdbBox1.AppendDataBoundItems = True

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
        txtCommodity.Items.Clear()
        txtCommodity.Items.Add(New ListItem("select Pallet"))
        txtCommodity.AppendDataBoundItems = True

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

        cboJobSite.Items.Clear()
        cboJobSite.Items.Add(New ListItem("select Pallet"))
        cboJobSite.AppendDataBoundItems = True

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
End Class