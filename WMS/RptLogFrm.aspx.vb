<<<<<<< HEAD
Option Explicit On
Option Strict On
Option Infer On

Public Class RptLogfrm
=======
Public Class RptlogFrm
>>>>>>> 8f9c1eba2d5077fd8b5eb134726eb9b44630a7ed
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