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
        cdbUnitQuantityDetail.Items.Clear()
        cdbUnitQuantityDetail.Items.Add(New ListItem("select Pallet"))
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

        Dim exl = From e In db.tblExpGenLOTs Where e.EASLOTNo = txtLotNo.Value.Trim
                 Select e.EASLOTNo, e.CustomerCode, e.JobSite, e.EndCusCode

        Try

            If exl Is Nothing Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
                Exit Sub
            Else
                If exl.Count > 0 Then
                    Me.dgvLotNo.DataSource = exl.ToList
                    Me.dgvLotNo.DataBind()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "EditModalScript", "openjobNoModal();", True)
                Else
                    Me.dgvLotNo.DataSource = Nothing
                    Me.dgvLotNo.DataBind()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub selectExpGenLOT1()

        Dim testdate As Integer = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        'Where e.LOTDate.Year = testdate
        Dim exl = From e In db.tblExpGenLOTs Where e.LOTDate.Year = testdate
                 Select e.EASLOTNo, e.CustomerCode, e.JobSite, e.EndCusCode

        Try

                If exl.Count > 0 Then
                    Me.dgvLotNo.DataSource = exl.ToList
                    Me.dgvLotNo.DataBind()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "EditModalScript", "openjobNoModal();", True)
                Else
                    Me.dgvLotNo.DataSource = Nothing
                    Me.dgvLotNo.DataBind()
                End If
          
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Unnamed_ServerClick(sender As Object, e As EventArgs)
        'Dim testdate As String = Mid(CStr(Now.Year), 3)

        'MsgBox(testdate)
        'If String.IsNullOrEmpty(txtLotNo.Value.Trim) Then
        '    'selectExpGenLOT1()

        'Else
        '    'selectExpGenLOT()

        'End If
        Dim sb As New StringBuilder
       
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ModalScript", "openjobNoModal();", True)
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "EditModalScript", sb.ToString(), False)

    End Sub

End Class