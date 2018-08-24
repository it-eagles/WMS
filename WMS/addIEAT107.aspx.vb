Option Explicit On
Option Strict On

Imports System.Globalization

Public Class addIEAT107
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim ie As New Ieat107
    Dim InvoiceDate As String
    Dim InvoiceNo As String
    Dim CustomerCode As String
    Dim PurechaseOrderNo As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            selectcompany()
        End If
    End Sub

    Protected Sub btnaddIEAT107__ServerClick(sender As Object, e As EventArgs)
        selectExpInvoices()
    End Sub
    Public Sub getieat107()
        'ScriptManager.RegisterStartupScript(upieat107, upieat107.GetType(), "show", "$(function () { $('#" + plIeat107.ClientID + "').modal('show'); });", True)
        'upieat107.Update()
    End Sub

    Private Sub savaStatusBalance(CustomerCode As String, PurechaseOrderNo As String, InvoiceNo As String, InvoiceDate As String)
        Dim StatusRenew As Integer = 0
        Dim UseAmonut As String = ""
        Dim DateEX As Date

        If Checkbox1.Checked = True Then
            StatusRenew = 1
        Else
            StatusRenew = 0
        End If
        If dtpEx.Text = "" Then
            DateEX = CDate(Convert.ToDateTime(Date.Now).ToString("dd/MM/yyyy"))
        Else
            DateTime.ParseExact(dtpEx.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"))
        End If
        Select Case MsgBox("คุณต้องการเพิ่มรายการ Invoice ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
            Case MsgBoxResult.Yes
                Dim sb = (From s In db.tblStatusBalances Select s).FirstOrDefault
                If Not IsNothing(sb) Then
                    db.tblStatusBalances.Add(New tblStatusBalance With { _
                            .PartyCode = CustomerCode, _
                            .JobNo = PurechaseOrderNo, _
                            .InvoiceNo = InvoiceNo, _
                            .InvoiceDate = DateTime.ParseExact(InvoiceDate, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                            .UseAmount = CType(CDbl(txtUseAmonut.Value.Trim).ToString("#,##0.000"), Decimal?), _
                            .DeliveryDate = DateTime.ParseExact(dtpForm.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                            .ReturnDate = DateTime.ParseExact(dtpTo.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                            .RenewDate = DateEX, _
                            .CreateBy = Session("UserName").ToString, _
                            .CreateDate = Now, _
                            .StatusRenew = StatusRenew
                             })
                    db.SaveChanges()
                    SavaAmountGuarantee(InvoiceNo)
                    ReadDATAIEAT107(InvoiceNo)
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('มี InvoiceNo ก่อน " & sb.InvoiceNo & "')", True)
                End If
            
        End Select
    End Sub

    Private Sub ReadDATAIEAT107(Invoice As String)

        Dim cons = From p In db.tblStatusBalances Where p.InvoiceNo = Invoice
             Order By p.InvoiceNo Descending
             Select p.PartyCode, p.InvoiceNo, p.JobNo, p.Status
        If cons.Count > 0 Then
            dgvIeat107.DataSource = cons.ToList
            dgvIeat107.DataBind()
        End If

    End Sub
    Private Sub selectcompany()
        Dim com = (From c In db.tblCompanyGuarantee1 Select c).SingleOrDefault
        txtTotalAmonut.Value = String.Format("{0:0.00}", com.AmountGuarantee)
        txtTotalUseAmonut.Value = String.Format("{0:0.00}", com.AmountUsed)
        txtAmonut.Value = String.Format("{0:0.00}", com.Balance)     
    End Sub

    Private Sub ClareDataIEAT107()
        txtUseAmonut.Value = "0"
        txtTotalUseAmonut.Value = "0"
        txtTotalAmonut.Value = "0"
        txtAmonut.Value = "0"
    End Sub
    Private Sub SavaAmountGuarantee(Invoice As String)
        db.tblCompanyGuarantee1.Add(New tblCompanyGuarantee1 With { _
                                    .AmountGuarantee = CType(CDbl(txtTotalAmonut.Value.Trim).ToString("#,##0.000"), Decimal?), _
                                    .AmountUsed = CType(CDbl(txtTotalUseAmonut.Value.Trim).ToString("#,##0.000"), Decimal?), _
                                    .Balance = CType(CDbl(txtAmonut.Value.Trim).ToString("#,##0.000"), Decimal?), _
                                    .InvoiceNo = Invoice
                                    })
        db.SaveChanges()
    End Sub

    Protected Sub btntest_ServerClick(sender As Object, e As EventArgs)
        'ScriptManager.RegisterStartupScript(upieat107, upieat107.GetType(), "show", "$(function () { $('#" + plIeat107.ClientID + "').modal('show'); });", True)
        'upieat107.Update()
    End Sub

    Private Sub selectExpInvoices()
        Dim Invoice As String = Request.QueryString("InvoiceNo")

        Dim cons = (From p In db.tblExpInvoices Where (p.InvoiceNo = Invoice And p.App = "Wait")
               Select p).SingleOrDefault
        ie.getInvoiceNo = cons.InvoiceNo
        ie.getCustomerCode = cons.EASCustomerCode
        ie.getPurechaseOrderNo = cons.PurchaseOrderNo
        InvoiceDate = Convert.ToDateTime(cons.InvoiceDate).ToString("dd/MM/yyyy")
        InvoiceNo = ie.getInvoiceNo
        CustomerCode = ie.getCustomerCode
        PurechaseOrderNo = ie.getPurechaseOrderNo
        savaStatusBalance(InvoiceNo, CustomerCode, PurechaseOrderNo, InvoiceDate)
    End Sub
   
End Class