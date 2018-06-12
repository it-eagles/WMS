Option Explicit On
Option Strict On

Imports System.Linq
Imports System.Web
Imports System.Web.Configuration
Imports System.Security
Public Class LogIN
    Inherits System.Web.UI.Page
    'Dim db As New LKBwarehouseEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSigIN_Click1(sender As Object, e As EventArgs) Handles btnSigIN.Click


        'Dim LoginCls As New LoginCls
        'Dim menu As String = "wms"


        'If LoginCls.chkUser(txtusername.Value, txtpassword.Value) Then
        '        Dim ds = (From c In db.tblUser
        '                  Where c.UserName = txtusername.Value.Trim
        '                  Select New With
        '                         {
        '                             c.UserId,
        '                             c.UserName,
        '                             c.Name,
        '                             c.UserGroupID,
        '                             c.StatusDelete
        '                             }).FirstOrDefault()
        '        Dim dsq = (From c In db.tblUser Where c.UserName = ds.UserName).FirstOrDefault()
        '        If Not IsNothing(dsq) Then
        '            Session("UserId") = ds.UserId
        '            Session("UserName") = txtusername.Value.Trim
        '            Session("Name") = ds.Name
        '            Session("StatusDelete") = ds.StatusDelete
        '            'checkID(ds.UserId)
        '            Response.Redirect("HomeMain.aspx")
        '        Else
        '            lblMsg.Text = "* You do not have access"
        '        End If

        'Else
        '    lblMsg.Text = "* Your Username and/or password  is not correct."
        'End If
    End Sub
    Private Sub checkID(userid As Integer)
        'Dim Key As String
        'Dim runno As Integer
        'Dim RJITno As String
        'Dim codeId As Integer
        'Key = "ass-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM")))

        'Dim u = (From us In db.tblRunningNumber()
        '                    Where us.Name = Key Select us).FirstOrDefault

        'If Not u Is Nothing Then

        '    runno = CInt(u.RunNo)
        '    codeId = runno + 1
        '    RJITno = "ass-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
        '    addAccess(userid, RJITno)
        '    upDateID(codeId, Key)
        '    showUserIDAss(RJITno)
        'Else

        '    db.tblRunningNumber.Add(New tblRunningNumber With
        '                      {
        '                          .Name = Key, _
        '                          .RunNo = CType("0", Integer?) _
        '                      })

        '    db.SaveChanges()
        '    runno = CInt("0")
        '    codeId = runno + 1
        '    RJITno = "ass-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
        '    addAccess(userid, RJITno)
        '    upDateID(codeId, Key)
        '    showUserIDAss(RJITno)
        'End If

     
    End Sub
    Private Sub addAccess(userid As Integer, assID As String)

      
        'db.Database.Connection.Open()

        'db.AccessSystem.Add(New AccessSystem With { _
        '                 .AccessID = assID,
        '                 .UserId = userid,
        '                 .Accesstime = Now
        '             })

        'db.SaveChanges()

    End Sub

    Private Sub upDateID(codeId As Integer, key As String)
       
        'db.Database.Connection.Open()
        'Dim update = (From c In db.tblRunningNumber Where c.Name = key
        '     Select c).First
        'If update IsNot Nothing Then

        '    update.RunNo = codeId

        '    db.SaveChanges()

        'End If

      
    End Sub
    Private Sub showUserIDAss(id As String)

        'Dim u = (From c In db.AccessSystem Where c.AccessID = id
        '         Select c).SingleOrDefault
        'Session("AssId") = u.AccessID

    End Sub
End Class