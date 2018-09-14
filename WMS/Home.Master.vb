Option Explicit On
Option Strict Off
Option Infer On

Public Class Home
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UserName").ToString = "" Then
            Response.Redirect("Login.aspx")
            Response.End()
        Else

            lblUser.InnerText = Session("Name").ToString
            userName.InnerText = Session("Name").ToString

        End If
    End Sub
    Protected Sub signout_click(sender As Object, e As EventArgs)
        signout()
        Session.Clear()
        Session.RemoveAll()
        Session.Abandon()
        Response.Redirect("LogIN.aspx")
        Response.End()
    End Sub

    Private Sub signout()
        'Dim id As String = CStr(Session("AssId"))

        'Using db As New LKBwarehouseTestEntities
        '    db.Database.Connection.Open()
        '    Dim update = (From c In db.AccessSystem Where c.AccessID = id
        '     Select c).First
        '    If update IsNot Nothing Then

        '        update.TimeOut = Now

        '        db.SaveChanges()

        '    End If
        'End Using
    End Sub
End Class