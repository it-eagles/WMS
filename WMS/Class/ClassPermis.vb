Option Explicit On
Option Strict On

Public Class ClassPermis
    Dim db As New LKBWarehouseEntities1_Test
    'Dim usename As String = Session("UserName")

    Public Function CheckRead(NameFrom As String, userName As String) As Boolean

        Dim um = (From u In db.tblUserMenus
                  Where u.UserName = userName.ToUpper And u.Form = NameFrom And u.Read_ = 1 Select u).Count()

        If (um > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
