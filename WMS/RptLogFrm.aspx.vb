<<<<<<< HEAD
﻿Public Class RptLogfrm
=======
﻿Public Class RptLogFrm
>>>>>>> 5c28d6f84ea2d8570db5f5f55311fad3b9b1d335
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