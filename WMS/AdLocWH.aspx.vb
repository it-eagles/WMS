Option Explicit On
Option Strict On


Public Class AdLocWH
    Inherits System.Web.UI.Page

    Dim db As New LKBWarehouseEntities1
    'Dim db As New LKBWarehouseEntities


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

        End If
    End Sub

    Protected Sub btnFind_ServerClick(sender As Object, e As EventArgs)
        If rdbAdLoc.Checked = True Then
            If txtOwnerPN.Value.Trim <> "" And txtCustomerLotNo.Value.Trim <> "" And txtCusRefNo.Value.Trim <> "" Then


            End If
        End If
    End Sub
    Protected Sub btnSave_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)

    End Sub
    Private Sub showTest()
        Dim sy = (From s In db.tblWHStockMovements)
    End Sub
    Public Function shwo(i As Integer, j As Integer) As Integer
        Dim d As Integer
        d = i + j
        Return d
    End Function
End Class