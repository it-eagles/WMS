Option Strict On
Option Explicit On

Imports System
Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Data.OleDb
Public Class UserFroile
    Inherits System.Web.UI.Page
    Dim dtAdapter As OleDbDataAdapter
    Dim db As New LKBwarehouseEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            showList()
        End If
    End Sub
    Public Sub showList()

        Dim user = From u In db.tblUser Join br In db.tblBranch On u.BranchID Equals br.BranchID
            Join de In db.tblDepartment On u.DepartmentID Equals de.DepartmentID
            Join ug In db.tblUserGroup On u.UserGroupID Equals ug.UserGroupID
                   Select u.UserName,
                          u.Name,
                          ug.UserGroupCode,
                          ug.UserGroupName,
                          de.DepartmentName

        If user.Count > 0 Then
            Repeater1.DataSource = user.ToList
            Repeater1.DataBind()

        End If
    End Sub
   

    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim index As String = CStr(e.CommandArgument)

        If e.CommandName.Equals("edituser") Then
            Response.Write("<script>window.open('UpdateUserfroile.aspx?UserName=" & index & "',target='_self');</script>")

        ElseIf e.CommandName.Equals("viewfroile") Then

            Response.Write("<script>window.open('ViewUserfroile.aspx?UserName=" & index & "',target='_self');</script>")

        End If
    End Sub

End Class