Option Explicit On
Option Strict On

Imports System.Linq
Imports System.Management
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Transactions

Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class UserMenu
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1_Test

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showUserlist()
            ShowCopyUser()
            showList()
            showGroupList()
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
        'Dim id As String = Session("UserName").ToString
        'Dim menu As String = "frmUserProfile"
        'Dim index As String = CStr(e.CommandArgument)
        'If e.CommandName.Equals("edituser") Then
        '    Dim ds1 = From c In db.tblUserMenus Where c.UserName = id And c.Form = menu And c.Edit_ = 1
        '    If ds1.Any Then
        '        Response.Write("<script>window.open('UpdateUserProfile.aspx?UserName=" & index & "',target='_self');</script>")
        '    Else
        '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธ์การแก้ไข')", True)
        '    End If
        'ElseIf e.CommandName.Equals("viewprofile") Then
        '    Dim ds1 = From c In db.tblUserMenus Where c.UserName = id And c.Form = menu And c.Read_ = 1
        '    If ds1.Any Then
        '        Response.Write("<script>window.open('ViewUserProfile.aspx?UserName=" & index & "',target='_self');</script>")
        '    Else
        '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธ์การแก้ไข')", True)
        '    End If
        'End If
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
                Dim Form = (From u In db.tblMenus Where u.Form = txtForm.Value
                Select u).FirstOrDefault

                Dim Menu = (From u In db.tblMenus Where u.Menu = txtMenu.Value
                Select u).FirstOrDefault

                If Not Form Is Nothing Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('ชื่อ Form ซ้ำ กรุณาเปลี่ยนใหม่');", True)
                ElseIf Not Menu Is Nothing Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('ชื่อ Menu ซ้ำ กรุณาเปลี่ยนใหม่');", True)
                Else
                    AddForm()
                End If
            End Using
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด');", True)
            Clear()

        End Try
    End Sub
    '-------------------------------------- Add Form Method in Menu Tab------------------------------------ 
    Private Sub AddForm()
        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()
                db.tblMenus.Add(New tblMenu() With { _
                                .Form = txtForm.Value.Trim, _
                                .Menu = txtMenu.Value.Trim, _
                                .UserBy = CStr(Session("UserName")), _
                                .UpdateBy = Now})
                db.SaveChanges()
                tran.Complete()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เพิ่ม user สำเร็จ !');", True)
                Response.Redirect("UserMenu.aspx")
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try
        End Using
    End Sub
    '----------------------------------------Clear Data Method------------------------------- 
    Private Sub Clear()
        txtForm.Value = ""
        txtMenu.Value = ""
    End Sub
    '-----------------------------------------------------Begin Group Tab Method----------------------------------------------
    '-----------------------------------------------------Show Group Data in Group Tab--------------------------------------
    Public Sub showGroupList()


        Dim grouplist = (From u In db.tblGroupMenus
                    Select New With {u.Form,
                                     u.Menu,
                                     u.Status}).ToList()

        If grouplist.Count > 0 Then
            Repeater2.DataSource = grouplist.ToList
            Repeater2.DataBind()

        Else
            Me.Repeater2.DataSource = Nothing
            Me.Repeater2.DataBind()
        End If
    End Sub

    Protected Sub Repeater2_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater2.ItemCommand

    End Sub

    Private Sub showStatuslist()
        'dcbBranch.Items.Clear()
        'dcbBranch.Items.Add(New ListItem("--select Branch--", ""))
        'dcbBranch.AppendDataBoundItems = True

        'Dim d = From p In db.tblGroupMenus
        '      Select p.Status
        'Try
        '    lblStatus.DataSource = d.ToList
        '    dcbBranch.DataTextField = "Status"
        '    dcbBranch.DataValueField = "Status"
        '    dcbBranch.DataBind()
        '    If dcbBranch.Items.Count > 1 Then
        '        dcbBranch.Enabled = True
        '    Else
        '        dcbBranch.Enabled = False
        '    End If
        'Catch ex As Exception
        '    'Throw ex
        'End Try
    End Sub
    Protected Sub Repeater2_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater2.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim m = (From n In db.tblGroupMenus
                     Select New With {n.Status}).ToList
            Dim lblStatus As DropDownList = (TryCast(e.Item.FindControl("lblStatus"), DropDownList))
            lblStatus.DataSource = m
            'ddlCountries.DataSource = Me.GetData("SELECT DISTINCT Country FROM Customers")
            lblStatus.DataTextField = "Status"
            lblStatus.DataValueField = "Status"
            lblStatus.DataBind()

            lblStatus.Items.Insert(0, New ListItem("Please select"))

            Dim status As String = (TryCast(e.Item.DataItem, DataRowView))("Status").ToString()
            'lblStatus.Items.FindByValue(status).Selected = True
        End If
    End Sub
    'Private Function GetData(ByVal query As String) As DataTable
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    '    Using con As SqlConnection = New SqlConnection(constr)
    '        Using cmd As SqlCommand = New SqlCommand(query, con)
    '            Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
    '                Dim dt As DataTable = New DataTable()
    '                sda.Fill(dt)
    '                Return dt
    '            End Using
    '        End Using
    '    End Using
    'End Function
    Private Sub Test()
        MsgBox("Tesจ้า")
    End Sub
End Class