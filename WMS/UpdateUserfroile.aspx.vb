Option Strict On
Option Explicit On

Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Transactions

Public Class UpdateUserfroile
    Inherits System.Web.UI.Page
   Dim userg As Integer
    Dim db As New LKBwarehouseEntities

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Me.IsPostBack Then
           
            showEdit()

        End If

    End Sub

    Protected Sub btnUpdateUser_Click(sender As Object, e As EventArgs)
        'upDateUser()
    End Sub

    Private Sub showEdit()
        Dim UserName As String = Request.QueryString("UserName")
        Dim wsm As String = "eagles"

        Dim user = (From u In db.tblUser Join br In db.tblBranch On u.BranchID Equals br.BranchID
            Join de In db.tblDepartment On u.DepartmentID Equals de.DepartmentID
            Join ug In db.tblUserGroup On u.UserGroupID Equals ug.UserGroupID Where u.UserName = UserName).SingleOrDefault


        If user.u.StatusAdd = "0" Then
            chkAdd.Checked = True
        End If
        If user.u.StatusAdd = "1" Then
            chkAdd.Checked = False
        End If

        If user.u.StatusModify = "0" Then
            chkModify.Checked = True
        End If
        If user.u.StatusModify = "1" Then
            chkModify.Checked = False
        End If

        If user.u.StatusDelete = "0" Then
            chkDelete.Checked = True
        End If
        If user.u.StatusDelete = "1" Then
            chkDelete.Checked = False
        End If

        If user.u.StatusPrint = "0" Then
            chkPrint.Checked = True
        End If
        If user.u.StatusPrint = "1" Then
            chkPrint.Checked = False
        End If

        If user.u.StatusImport = "0" Then
            chkImport.Checked = True
        End If
        If user.u.StatusImport = "1" Then
            chkImport.Checked = False
        End If

        If user.u.StatusExport = "0" Then
            chkExport.Checked = True
        End If
        If user.u.StatusExport = "1" Then
            chkExport.Checked = False
        End If

        If user.u.StatusWarehouse = "0" Then
            chkWarehouse.Checked = True
        End If
        If user.u.StatusWarehouse = "1" Then
            chkWarehouse.Checked = False
        End If

        If user.u.UserStatus = "0" Then
            rdbEnable.Checked = True
        End If
        If user.u.UserStatus = "1" Then
            rdbDisable.Checked = True
        End If

        txtUserName.Value = user.u.UserName
        txtFullName.Value = user.u.Name
        txtUserGroup.Value = user.ug.UserGroupName


        Dim Branch As String = user.br.BranchName
        showBranch(Branch)
        Dim userG As String = user.ug.UserGroupCode
        showuserGroup(userG)
        Dim dep As String = user.de.DepartmentName
        showDepartment(dep)

        'show password ถอนรหัส ASCII 
        'Dim pass As String = user.u.Password

        'Dim show As String = LoginCls.Decrypt(pass, wsm)
        'txtPassword.Value = show
        'txtConfirmPassword.Value = show

        '.Password = PassEncrypt, _
        '.StatusAdd = StatusAdd, _
        '.StatusModify = StatusModify, _
        '.StatusDelete = StatusDelete, _
        '.StatusPrint = StatusPrint, _
        '.StatusImport = StatusImport, _
        '.StatusExport = StatusExport, _
        '.StatusWarehouse = StatusWareHouse, _
        '.UserStatus = UserStatus


    End Sub
    Private Sub showuserGroup(userG As String)
        dcboUserGroup.Items.Clear()
        dcboUserGroup.Items.Add(New ListItem(userG, ""))
        dcboUserGroup.AppendDataBoundItems = True

        Dim d = From ug In db.tblUserGroup
                Select ug.UserGroupID, ug.UserGroupCode
        Try
            dcboUserGroup.DataSource = d.ToList
            dcboUserGroup.DataTextField = "UserGroupCode"
            dcboUserGroup.DataValueField = "UserGroupID"
            dcboUserGroup.DataBind()

            Dim dd As Integer = CInt(dcboUserGroup.Text)
            showUserGroupName(dd)
            If dcboUserGroup.Items.Count > 1 Then
                dcboUserGroup.Enabled = True
            Else
                dcboUserGroup.Enabled = False

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub showBranch(Branch As String)
        dcbBranch.Items.Clear()
        dcbBranch.Items.Add(New ListItem(Branch, ""))
        dcbBranch.AppendDataBoundItems = True

        Dim d = From p In db.tblBranch
              Select p.BranchID,
              p.BranchName
        Try
            dcbBranch.DataSource = d.ToList
            dcbBranch.DataTextField = "BranchName"
            dcbBranch.DataValueField = "BranchID"
            dcbBranch.DataBind()
            If dcbBranch.Items.Count > 1 Then
                dcbBranch.Enabled = True
            Else
                dcbBranch.Enabled = False

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub showDepartment(Dep As String)
        dcbDept.Items.Clear()
        dcbDept.Items.Add(New ListItem(Dep, ""))
        dcbDept.AppendDataBoundItems = True

        Dim d = From p In db.tblDepartment
                Select p.DepartmentID,
                p.DepartmentName
        Try
            dcbDept.DataSource = d.ToList
            dcbDept.DataTextField = "DepartmentName"
            dcbDept.DataValueField = "DepartmentID"
            dcbDept.DataBind()
            If dcbDept.Items.Count > 1 Then
                dcbDept.Enabled = True
            Else
                dcbDept.Enabled = False

            End If
        Catch ex As Exception
            Throw ex
        End Try


    End Sub
    Private Sub showUserGroupName(groupName As Integer)

        Dim d = (From p In db.tblUserGroup Where p.UserGroupID = groupName).SingleOrDefault
        txtUserGroup.Value = d.UserGroupName

    End Sub

    Protected Sub dcboUserGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dcboUserGroup.SelectedIndexChanged
        Dim dd As Integer = CInt(dcboUserGroup.Text)
        showUserGroupName(dd)
    End Sub
    Private Sub upDateUser()
        'Dim PassEncrypt As String
        Dim UserName As String = Request.QueryString("UserName")
        Dim LoginCls As New LoginCls
        Dim key As String = LoginCls.EncryptPass

        If (String.IsNullOrEmpty(txtUserName.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน UserName ก่อน !');", True)
            Exit Sub
        End If

        'If (String.IsNullOrEmpty(txtPassword.Value)) Then
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อนรหัส Password !!!');", True)
        '    Exit Sub
        'End If

        'If (String.IsNullOrEmpty(txtConfirmPassword.Value)) Then
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อนรหัส Password ซ้ำอีกครั้ง');", True)

        '    Exit Sub
        'End If

        If txtFullName.Value.Length < 2 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('UserName ต้องมีจำนวนตัวอักษรระหว่าง 2-16 ตัวอักษร');", True)

            Exit Sub
    
        'If txtPassword.Value.Length < 4 And txtPassword.Value.Length <= 16 Then
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รหัส Password ต้องมีจำนวนตัวอักษรระหว่าง 4-16 ตัวอักษร');", True)
        '    Exit Sub
        'End If

        'If txtConfirmPassword.Value.Length < 4 And txtConfirmPassword.Value.Length <= 16 Then
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รหัส Password ต้องมีจำนวนตัวอักษรระหว่าง 4-16 ตัวอักษร');", True)
        '    Exit Sub

        Else
        Dim StatusAdd As String = "0"
        Dim StatusModify As String = "0"
        Dim StatusDelete As String = "0"
        Dim StatusPrint As String = "0"
        Dim StatusImport As String = "0"
        Dim StatusExport As String = "0"
        Dim StatusWareHouse As String = "0"
        Dim UserStatus As String = "0"

        If chkAdd.Checked = True Then
            StatusAdd = "0"
        End If
        If chkAdd.Checked = False Then
            StatusAdd = "1"
        End If

        If chkModify.Checked = True Then
            StatusModify = "0"
        End If
        If chkModify.Checked = False Then
            StatusModify = "1"
        End If

        If chkDelete.Checked = True Then
            StatusDelete = "0"
        End If
        If chkDelete.Checked = False Then
            StatusDelete = "1"
        End If

        If chkPrint.Checked = True Then
            StatusPrint = "0"
        End If
        If chkPrint.Checked = False Then
            StatusPrint = "1"
        End If


        If chkImport.Checked = True Then
            StatusImport = "0"
        End If
        If chkImport.Checked = False Then
            StatusImport = "1"
        End If

        If chkExport.Checked = True Then
            StatusExport = "0"
        End If
        If chkExport.Checked = False Then
            StatusExport = "1"
        End If

        If chkWarehouse.Checked = True Then
            StatusWareHouse = "0"
        End If
        If chkWarehouse.Checked = False Then
            StatusWareHouse = "1"
        End If

        If rdbEnable.Checked = True Then
            UserStatus = "0"
        End If
        If rdbDisable.Checked = True Then
            UserStatus = "1"
        End If

        'PassEncrypt = LoginCls.Encrypt(txtPassword.Value.Trim, key)
        Using tran As New TransactionScope()

           
                    Try
                        db.Database.Connection.Open()
                        Dim edit As tblUser = (From c In db.tblUser Where c.UserName = UserName
                Select c).First
                        If edit IsNot Nothing Then
                            edit.UserName = txtUserName.Value.Trim
                            edit.Name = txtFullName.Value.Trim
                            edit.UserGroupID = CType(dcboUserGroup.Text.Trim, Integer?)
                            edit.DepartmentID = CType(dcbDept.Text, Integer?)
                            edit.BranchID = CType(dcbBranch.Text.Trim, Integer?)
                            edit.StatusAdd = StatusAdd
                            edit.StatusModify = StatusModify
                            edit.StatusDelete = StatusDelete
                            edit.StatusPrint = StatusPrint
                            edit.StatusImport = StatusImport
                            edit.StatusExport = StatusExport
                            edit.StatusWarehouse = StatusWareHouse
                            edit.UserStatus = UserStatus

                            db.SaveChanges()
                            tran.Complete()
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                            Response.Redirect("Userfroile.aspx")
                        End If
                    Catch ex As Exception

                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)

                    Finally
                        db.Database.Connection.Close()
                        db.Dispose()
                        tran.Dispose()
                    End Try

                End Using

        End If


    End Sub
End Class