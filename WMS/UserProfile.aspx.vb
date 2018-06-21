Option Strict On
Option Explicit On

Imports System
Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Data.OleDb
Public Class UserProfile
    Inherits System.Web.UI.Page
    Dim dtAdapter As OleDbDataAdapter
    'Dim db As New LKBwarehouseEntities
    Dim db As New LKBWarehouseEntities1_Test
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            showList()
        End If
    End Sub
    Public Sub showList()

        Dim user = (From u In db.tblUsers Join br In db.Branches On u.Branch Equals br.BranchID
            Join de In db.Departments On u.Dept Equals de.DepartmentID
            Join ug In db.tblUserGroups On u.GroupName Equals ug.UserGroupName
                   Select New With {u.UserName,
                          u.Name,
                          ug.UserGroupCode,
                          ug.UserGroupName,
                          de.DepartmentName}).ToList()

        If user.Count > 0 Then
            Repeater1.DataSource = user.ToList
            Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If
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

End Class