Option Strict On
Option Explicit On
Option Infer On

Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Transactions

Public Class UpdateUserProfile
    Inherits System.Web.UI.Page
    Dim userg As Integer
    'Dim db As New LKBwarehouseEntities
    Dim db As New LKBWarehouseEntities1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showEdit()
            showBranchlist()
            showDepartmentlist()
            showuserGrouplist()
        End If
    End Sub

    Protected Sub btnUpdateUser_Click(sender As Object, e As EventArgs)
        upDateUser(getBranch)
        showEdit()

    End Sub

    Private Sub showEdit()
        Dim UserName As String = Request.QueryString("UserName")
        Dim wsm As String = "eagles"

        Dim user = (From u In db.tblUsers Join br In db.Branches On u.Branch Equals br.BranchID
            Join de In db.Departments On u.Dept Equals de.DepartmentID
            Join ug In db.tblUserGroups On u.GroupName Equals ug.UserGroupName Where u.UserName = UserName).SingleOrDefault


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
        dcboUserGroup.Text = user.u.UserGroup
        txtUserGroup.Value = user.ug.UserGroupName

        dcbBranch.Text = user.u.Branch
        dcbDept.Text = user.u.Dept
        
        'showBranch(_branch)
        'Dim userG As String = user.ug.UserGroupCode
        'showuserGroup(userG)
        'Dim dep As String = user.de.DepartmentName
        'showDepartment(dep)

        'show password ถอนรหัส ASCII 
        'Dim PassEncrypt = LoginCls.ReturnASCII(txtUserName.Value.Trim, txtPassword.Value.Trim)
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
    Private Sub showuserGrouplist()
        'dcboUserGroup.Items.Clear()
        'dcboUserGroup.Items.Add(New ListItem(userG, ""))
        'dcboUserGroup.AppendDataBoundItems = True

        Dim d = From ug In db.tblUserGroups
                Select ug.UserGroupName, ug.UserGroupCode
        Try
            dcboUserGroup.DataSource = d.ToList
            dcboUserGroup.DataTextField = "UserGroupCode"
            dcboUserGroup.DataValueField = "UserGroupCode"
            dcboUserGroup.DataBind()

            'Dim dd As String = dcboUserGroup.Text
            'showUserGroupName(dd)
            If dcboUserGroup.Items.Count > 1 Then
                dcboUserGroup.Enabled = True
            Else
                dcboUserGroup.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub showuserGroup(userG As String)
        dcboUserGroup.Items.Clear()
        dcboUserGroup.Items.Add(New ListItem("--select UserGroup--", ""))
        dcboUserGroup.AppendDataBoundItems = True

        Dim d = From ug In db.tblUserGroups
                Select ug.UserGroupName, ug.UserGroupCode
        Try
            dcboUserGroup.DataSource = d.ToList
            dcboUserGroup.DataTextField = "UserGroupCode"
            dcboUserGroup.DataValueField = "UserGroupCode"
            dcboUserGroup.DataBind()

            'Dim dd As String = dcboUserGroup.Text
            'showUserGroupName(dd)
            If dcboUserGroup.Items.Count > 1 Then
                dcboUserGroup.Enabled = True
            Else
                dcboUserGroup.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub showBranchlist()
        'dcbBranch.Items.Clear()
        'dcbBranch.Items.Add(New ListItem("--select Branch--", ""))
        'dcbBranch.AppendDataBoundItems = True

        Dim d = From p In db.Branches
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
            'Throw ex
        End Try
    End Sub
    'Private Sub showBranch(Branch As String)
    '    dcbBranch.Items.Clear()
    '    dcbBranch.Items.Add(New ListItem("--select Branch--", ""))
    '    dcbBranch.AppendDataBoundItems = True

    '    Dim d = From p In db.Branches
    '          Select p.BranchID, p.BranchName
    '    Try
    '        dcbBranch.DataSource = d.ToList
    '        dcbBranch.DataTextField = "BranchName"
    '        dcbBranch.DataValueField = "BranchID"
    '        dcbBranch.DataBind()
    '        If dcbBranch.Items.Count > 1 Then
    '            dcbBranch.Enabled = True
    '        Else
    '            dcbBranch.Enabled = False
    '        End If
    '    Catch ex As Exception
    '        'Throw ex
    '    End Try
    'End Sub
    Private Sub showDepartmentlist()
        'dcbDept.Items.Clear()
        'dcbDept.Items.Add(New ListItem(Dep, ""))
        'dcbDept.AppendDataBoundItems = True

        Dim d = From p In db.Departments
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
            'Throw ex
        End Try
    End Sub
    'Private Sub showDepartment(Dep As String)
    '    dcbDept.Items.Clear()
    '    dcbDept.Items.Add(New ListItem("--select Dep--", ""))
    '    dcbDept.AppendDataBoundItems = True

    '    Dim d = From p In db.Departments
    '            Select p.DepartmentID,
    '            p.DepartmentName
    '    Try
    '        dcbDept.DataSource = d.ToList
    '        dcbDept.DataTextField = "DepartmentName"
    '        dcbDept.DataValueField = "DepartmentID"
    '        dcbDept.DataBind()
    '        If dcbDept.Items.Count > 1 Then
    '            dcbDept.Enabled = True
    '        Else
    '            dcbDept.Enabled = False
    '        End If
    '    Catch ex As Exception
    '        'Throw ex
    '    End Try
    'End Sub
    Private Sub showUserGroupName(groupName As String)

        Dim d = (From p In db.tblUserGroups Where p.UserGroupCode = groupName).SingleOrDefault
        txtUserGroup.Value = d.UserGroupName

    End Sub

    Protected Sub dcboUserGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dcboUserGroup.SelectedIndexChanged
        Dim dd As String = dcboUserGroup.Text
        showUserGroupName(dd)
    End Sub
    Private Sub upDateUser(branch As String)
        'Dim PassEncrypt As String
        Dim UserName As String = Request.QueryString("UserName")
        Dim LoginCls As New LoginCls
        Dim key As String = LoginCls.EncryptPass

        If (String.IsNullOrEmpty(txtUserName.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน UserName ก่อน !');", True)
            'Exit Sub
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

            'Exit Sub

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
            'If String.IsNullOrEmpty(dcbBranch.Text) Then
            '    'edit.Branch = ""
            '    MsgBox(_branch)
            'Else
            '    'edit.Branch = dcbBranch.Text
            '    MsgBox(dcbBranch.Text)
            'End If
            'PassEncrypt = LoginCls.Encrypt(txtPassword.Value.Trim, key)
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    Dim edit As tblUser = (From c In db.tblUsers Where c.UserName = UserName
            Select c).First()
                    If edit IsNot Nothing Then
                        edit.UserName = txtUserName.Value.Trim
                        edit.Name = txtFullName.Value.Trim
                        If String.IsNullOrEmpty(dcbBranch.Text) Then
                            edit.Branch = ""
                        Else
                            edit.Branch = dcbBranch.Text
                        End If
                        edit.UserGroup = dcboUserGroup.Text
                        edit.GroupName = txtUserGroup.Value.Trim
                        edit.Dept = dcbDept.Text
                        edit.Branch = dcbBranch.Text
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
                        Response.Redirect("UserProfile.aspx")
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

    Dim _branch As String
    Public Property getBranch() As String
        Get
            Return _branch
        End Get
        Set(ByVal value As String)
            _branch = value
        End Set
    End Property

End Class