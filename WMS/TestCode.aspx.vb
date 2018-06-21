Public Class TestCode
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        lblSelectedValue.Text = cboCountry.SelectedValue
    End Sub
End Class