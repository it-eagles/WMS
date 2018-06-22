Option Explicit On
Option Strict On

Imports System.Linq
Imports System.Management
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class UserMenu
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1_Test

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showUserlist()
            ShowCopyUser()
            showList()
            'Else
            '    MsgBox("เกิดความผิดพลาดในการทำงาน", MsgBoxStyle.OkCancel)
        End If
       
    End Sub
    '----------------------------------------------------Show Data Dropdown UserName Method in User Tab-------------------------------------
    Private Sub showUserlist()
        Dim user = From u In db.tblUsers
                   Select u.UserName, u.Name
        Try
           
            ddlUser.DataSource = user.ToList
            ddlUser.DataTextField = "UserName"
            ddlUser.DataValueField = "UserName"
            ddlUser.DataBind()
            If ddlUser.Items.Count > 1 Then
                ddlUser.Enabled = True
            Else
                ddlUser.Enabled = False
            End If

        Catch ex As Exception
            'MsgBox("เกิดเหตุผิดพลาด")
        End Try
    End Sub
    '----------------------------------------------------Show Data Dropdown CopyUser Method in User Tab-------------------------------------
    Private Sub ShowCopyUser()
        Dim user = From u In db.tblUsers
                  Select u.UserName, u.Name
        Try

            ddlCopyUser.DataSource = user.ToList
            ddlCopyUser.DataTextField = "UserName"
            ddlCopyUser.DataValueField = "UserName"
            ddlCopyUser.DataBind()
            If ddlCopyUser.Items.Count > 1 Then
                ddlCopyUser.Enabled = True
            Else
                ddlCopyUser.Enabled = False
            End If

        Catch ex As Exception
            'MsgBox("เกิดเหตุผิดพลาด")
        End Try
    End Sub

    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim id As String = Session("UserName").ToString
        Dim menu As String = "frmUserProfile"
        Dim index As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("edituser") Then
            Dim ds1 = From c In db.tblUserMenus Where c.UserName = id And c.Form = menu And c.Edit_ = 1
            If ds1.Any Then
                Response.Write("<script>window.open('UpdateUserProfile.aspx?UserName=" & index & "',target='_self');</script>")
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธ์การแก้ไข')", True)
            End If
        ElseIf e.CommandName.Equals("viewprofile") Then
            Dim ds1 = From c In db.tblUserMenus Where c.UserName = id And c.Form = menu And c.Read_ = 1
            If ds1.Any Then
                Response.Write("<script>window.open('ViewUserProfile.aspx?UserName=" & index & "',target='_self');</script>")
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธ์การแก้ไข')", True)
            End If
        End If
    End Sub
    '---------------------------------------------------Show Data Method in Menu Tab--------------------------------------
    Public Sub showList()
        Dim formlist = (From u In db.tblMenus
                    Select New With {u.Form,
                                     u.Menu,
                                     u.UserBy,
                                     u.UpdateBy}).ToList()

        If formlist.Count > 0 Then
            Repeater1.DataSource = formlist.ToList
            Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If
    End Sub
    '--------------------------------------Click Add Form Method in Menu Tab------------------------------------ 
    Protected Sub btnAddUp1_Click(sender As Object, e As EventArgs) Handles btnAddUp1.ServerClick

        Try
            Using db = New LKBWarehouseEntities1_Test
                Dim user = (From u In db.tblMenus Where u.Form = txtForm.Value
                Select u).FirstOrDefault

                If Not user Is Nothing Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('ชื่อ Form ซ้ำ กรุณาเปลี่ยนใหม่');", True)
                Else
                    'AddForm()
                End If
            End Using
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด');", True)
            Clear()

        End Try
    End Sub
    '-------------------------------------- Add Form Method in Menu Tab------------------------------------ 
    Private Sub AddForm()
        Try
            db.Database.Connection.Open()
            db.tblMenus.Add(New tblMenu() With { _
                            .Form = txtForm.Value.Trim, _
                            .Menu = txtMenu.Value.Trim, _
                            .UserBy = CStr(Session("UserName")), _
                            .UpdateBy = Now})
            db.SaveChanges()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เพิ่ม user สำเร็จ !');", True)
            Response.Redirect("UserProfile.aspx")
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
        Finally
            db.Database.Connection.Close()
            db.Dispose()
        End Try
    End Sub
    '----------------------------------------Clear Data Method------------------------------- 
    Private Sub Clear()
        txtForm.Value = ""
        txtMenu.Value = ""
    End Sub
End Class
