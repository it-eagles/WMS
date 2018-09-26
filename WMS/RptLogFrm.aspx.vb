Public Class RptlogFrm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnPrint_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)
        Clear()
    End Sub
    Private Sub Clear()
        txtdatepickerDate.Text = ""
        txtdatepickerToDate.Text = ""
        txtInvoiceNo.Value = ""
    End Sub
End Class