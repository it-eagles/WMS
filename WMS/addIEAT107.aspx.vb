Option Explicit On
Option Strict On

Imports System.Globalization

Public Class addIEAT107
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'selectcompany()
        End If
    End Sub

    Protected Sub btnaddIEAT107__ServerClick(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtUseAmonut.Value.Trim) Then
            MsgBox("เป็นค่าว่าง")
        Else
            MsgBox(txtUseAmonut.Value.Trim)
        End If
        'savaStatusBalance()
    End Sub
    Public Sub getieat107()
        ScriptManager.RegisterStartupScript(upieat107, upieat107.GetType(), "show", "$(function () { $('#" + plIeat107.ClientID + "').modal('show'); });", True)
        upieat107.Update()
    End Sub



    'Private Sub savaStatusBalance()
    '    Dim StatusRenew As Integer = 0
    '    Dim UseAmonut As String = ""
    '    Dim DateEX As Date
    '    If String.IsNullOrEmpty(txtInvoiceNo.Value.Trim) Then
    '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Invoice ก่อน !!!')", True)
    '        Exit Sub
    '    Else

    '        If Checkbox1.Checked = True Then
    '            StatusRenew = 1
    '        Else
    '            StatusRenew = 0
    '        End If
    '        If dtpEx.Text = "" Then
    '            DateEX = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
    '        Else
    '            DateTime.ParseExact(dtpEx.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
    '        End If
    '        Select Case MsgBox("คุณต้องการเพิ่มรายการ Invoice ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
    '            Case MsgBoxResult.Yes

    '                db.tblStatusBalances.Add(New tblStatusBalance With { _
    '                                .PartyCode = txtCustomerCode.Value.Trim, _
    '                                .JobNo = txtPurechaseOrderNo.Value.Trim, _
    '                                .InvoiceNo = txtInvoiceNo.Value.Trim, _
    '                                .InvoiceDate = DateTime.ParseExact(dtpInvoiceDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
    '                                .UseAmount = CType(CDbl(txtUseAmonut.Value.Trim).ToString("#,##0.000"), Decimal?), _
    '                                .DeliveryDate = DateTime.ParseExact(dtpForm.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
    '                                .ReturnDate = DateTime.ParseExact(dtpTo.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
    '                                .RenewDate = DateEX, _
    '                                .CreateBy = Session("UserName").ToString, _
    '                                .CreateDate = Now, _
    '                                .StatusRenew = StatusRenew
    '                                 })
    '                db.SaveChanges()
    '                SavaAmountGuarantee()
    '                ReadDATAIEAT107(txtInvoiceNo.Value.Trim)
    '        End Select
    '    End If
    'End Sub


    'Private Sub ReadDATAIEAT107(Invoice As String)

    '    Dim cons = From p In db.tblStatusBalances Where p.InvoiceNo = Invoice
    '         Order By p.InvoiceNo Descending
    '         Select p.PartyCode, p.InvoiceNo, p.JobNo, p.Status
    '    If cons.Count > 0 Then
    '        dgvIeat107.DataSource = cons.ToList
    '        dgvIeat107.DataBind()
    '        ScriptManager.RegisterStartupScript(upieat107, upieat107.GetType(), "show", "$(function () { $('#" + plIeat107.ClientID + "').modal('show'); });", True)
    '        upieat107.Update()
    '    Else
    '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Invoice ก่อน !!!')", True)
    '        Exit Sub
    '    End If

    'End Sub
    Private Sub selectcompany()
        Dim com = (From c In db.tblCompanyGuarantee1 Select c).SingleOrDefault
        txtTotalAmonut.Value = String.Format("{0:0.00}", com.AmountGuarantee)
        txtTotalUseAmonut.Value = String.Format("{0:0.00}", com.AmountUsed)
        txtAmonut.Value = String.Format("{0:0.00}", com.Balance)
    End Sub

    'Private Sub ClareDataIEAT107()
    '    txtUseAmonut.Value = "0"
    '    txtTotalUseAmonut.Value = "0"
    '    txtTotalAmonut.Value = "0"
    '    txtAmonut.Value = "0"
    'End Sub
    'Private Sub SavaAmountGuarantee()
    '    db.tblCompanyGuarantee1.Add(New tblCompanyGuarantee1 With { _
    '                                .AmountGuarantee = CType(txtTotalAmonut.Value, Decimal?), _
    '                                .AmountUsed = CType(txtTotalUseAmonut.Value, Decimal?), _
    '                                .Balance = CType(txtAmonut.Value, Decimal?), _
    '                                .InvoiceNo = txtInvoiceNo.Value.Trim
    '                                })
    '    db.SaveChanges()
    'End Sub
End Class