Option Explicit On
Option Strict On
Option Infer On

Imports System.Linq
Imports System.Web
Imports System.Web.Configuration
Imports System.Security
Public Class LogIN
    Inherits System.Web.UI.Page
    'Dim db As New LKBWarehouseEntities
    Dim db As New LKBWarehouseEntities1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSigIN_Click1(sender As Object, e As EventArgs) Handles btnSigIN.Click

        Dim LoginCls As New LoginCls
        Dim menu As String = "wms"

        'txtusername.Value = txtusername.Value.ToUpper

        If LoginCls.chkUser(txtusername.Value.ToUpper, txtpassword.Value) = True Then
            Dim ds = (From c In db.tblUsers
                          Where c.UserName = txtusername.Value).FirstOrDefault()

            Session("UserName") = ds.UserName
            Session("Name") = ds.Name
            Session("UserGroup") = ds.UserGroup
            Session("StatusAdd") = ds.StatusAdd
            Session("StatusDelete") = ds.StatusDelete
            Session("StatusImport") = ds.StatusImport
            Session("StatusExport") = ds.StatusExport
            Session("StatusEdit") = ds.StatusModify
            Session("StatusExport") = ds.StatusExport
            Session("StatusPrint") = ds.StatusPrint
            ckeckMenu(ds.UserName)
        Else
            lblMsg.Text = "* Your Username and/or password  is not correct."
        End If

    End Sub
    Private Sub ckeckMenu(user As String)
        Dim dsq = (From c In db.tblUserMenus Where c.UserName = user).FirstOrDefault()
        If Not IsNothing(dsq) Then
            'checkID(ds.UserId)
            Response.Redirect("HomeMain.aspx")
        Else
            lblMsg.Text = "* You do not have access"
        End If
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