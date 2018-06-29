Option Explicit On
Option Strict On

Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data
Imports System.Security.Cryptography
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Transactions



Public Class AddUser
    Inherits System.Web.UI.Page
   
    'Dim db As New LKBWarehouseEntities
    Dim db As New LKBWarehouseEntities1_Test
    
    'Dim ClassPermis As ClassPermis
    Dim PassEncrypt As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            showuserGroup()
            showBranch()
            showDepartment()
        End If
    End Sub
    Private Sub showuserGroup()
        dcboUserGroup.Items.Clear()
        dcboUserGroup.Items.Add(New ListItem("--Select Group--", ""))
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
    Private Sub showBranch()
        dcbBranch.Items.Clear()
        dcbBranch.Items.Add(New ListItem("--Select Branch--", ""))
        dcbBranch.AppendDataBoundItems = True

        Dim d = From p In db.Branches
              Select p.BranchName, p.BranchID
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
    Private Sub showDepartment()
        dcbDept.Items.Clear()
        dcbDept.Items.Add(New ListItem("--Select Department--", ""))
        dcbDept.AppendDataBoundItems = True

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
            Throw ex
        End Try


    End Sub
    Private Sub showUserGroupName(groupName As String)
        Dim d = (From p In db.tblUserGroups Where p.UserGroupCode = groupName).SingleOrDefault
        txtUserGroup.Value = d.UserGroupName
    End Sub
    Protected Sub dcboUserGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dcboUserGroup.SelectedIndexChanged
        Dim dd As String = dcboUserGroup.Text
        showUserGroupName(dd)
    End Sub
    Protected Sub btnAddUser_click(sender As Object, e As EventArgs)
        SaveDATA_New()
    End Sub
    Private Sub SaveDATA_New()

        Dim LoginCls As New LoginCls
        Dim key As String = LoginCls.EncryptPass

        If (String.IsNullOrEmpty(txtUserName.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน UserName ก่อน !');", True)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(txtPassword.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อนรหัส Password !!!');", True)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(txtConfirmPassword.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อนรหัส Password ซ้ำอีกครั้ง');", True)

            Exit Sub
        End If

        If txtFullName.Value.Length < 2 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('UserName ต้องมีจำนวนตัวอักษรระหว่าง 2-16 ตัวอักษร');", True)

            Exit Sub
        End If

        If txtPassword.Value.Length < 4 And txtPassword.Value.Length <= 16 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รหัส Password ต้องมีจำนวนตัวอักษรระหว่าง 4-16 ตัวอักษร');", True)
            Exit Sub
        End If

        If txtConfirmPassword.Value.Length < 4 And txtConfirmPassword.Value.Length <= 16 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รหัส Password ต้องมีจำนวนตัวอักษรระหว่าง 4-16 ตัวอักษร');", True)
            Exit Sub
        End If
        addUser()
        Try
            Dim user = (From u In db.tblUsers Where u.UserName = txtUserName.Value
          Select u).FirstOrDefault

            If Not user Is Nothing Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('ชื่อ user ซ้ำ กรุณาเปลี่ยนใหม่');", True)
            Else
                addUser()
                checkID()
                'check()
                Response.Write("<script>window.open('UserProlie.aspx,target='_self');</script>")
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด');", True)
        End Try

    End Sub
    Private Sub addUser()

        Dim usernameupper As String = txtUserName.Value.ToUpper
        Dim key As String = LoginCls.EncryptPass

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
        PassEncrypt = LoginCls.ReturnASCII(usernameupper, txtPassword.Value.Trim)
        'MsgBox(PassEncrypt)

        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()

                db.tblUsers.Add(New tblUser With { _
                             .UserName = usernameupper.Trim, _
                             .Name = txtFullName.Value.Trim, _
                             .UserGroup = dcboUserGroup.Text, _
                             .GroupName = txtUserGroup.Value.Trim, _
                             .Dept = dcbDept.Text.Trim, _
                             .Branch = dcbBranch.Text.Trim, _
                             .Password = PassEncrypt, _
                             .StatusAdd = StatusAdd, _
                             .StatusModify = StatusModify, _
                             .StatusDelete = StatusDelete, _
                             .StatusPrint = StatusPrint, _
                             .StatusImport = StatusImport, _
                             .StatusExport = StatusExport, _
                             .StatusWarehouse = StatusWareHouse, _
                             .UserStatus = UserStatus
                         })

                db.SaveChanges()
                tran.Complete()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เพิ่ม user สำเร็จ !');", True)
                Response.Redirect("UserProfile.aspx")
            Catch ex As Exception

                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)

            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try

        End Using
    End Sub
    Private Sub checkID()

        Dim runno As Integer
        Dim RJITno As String
        Dim codeId As Integer
        Dim Key As String = "log-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM")))

        Dim id = (From log In db.tblRunningNumbers Where log.Name = Key Select log).FirstOrDefault

        If Not id Is Nothing Then

            runno = CInt(id.RunNo)
            codeId = runno + 1
            RJITno = "log-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
            InsertData(RJITno)
            upDateID(codeId, Key)
        Else

            db.tblRunningNumbers.Add(New tblRunningNumber With
                          {
                              .Name = Key, _
                              .RunNo = CType("0", Integer?) _
                          })

            db.SaveChanges()
            runno = CInt("0")
            codeId = runno + 1
            RJITno = "log-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
            InsertData(RJITno)
            upDateID(codeId, Key)
        End If
       
    End Sub

    Private Sub InsertData(LowNumber As String)

        'Dim StatusAdd As String = "0"
        'Dim StatusModify As String = "0"
        'Dim StatusDelete As String = "0"
        'Dim StatusPrint As String = "0"
        'Dim StatusImport As String = "0"
        'Dim StatusExport As String = "0"
        'Dim StatusWareHouse As String = "0"
        'Dim UserStatus As String = "0"


        'If chkAdd.Checked = True Then
        '    StatusAdd = "0"
        'End If
        'If chkAdd.Checked = False Then
        '    StatusAdd = "1"
        'End If

        'If chkModify.Checked = True Then
        '    StatusModify = "0"
        'End If
        'If chkModify.Checked = False Then
        '    StatusModify = "1"
        'End If

        'If chkDelete.Checked = True Then
        '    StatusDelete = "0"
        'End If
        'If chkDelete.Checked = False Then
        '    StatusDelete = "1"
        'End If

        'If chkPrint.Checked = True Then
        '    StatusPrint = "0"
        'End If
        'If chkPrint.Checked = False Then
        '    StatusPrint = "1"
        'End If


        'If chkImport.Checked = True Then
        '    StatusImport = "0"
        'End If
        'If chkImport.Checked = False Then
        '    StatusImport = "1"
        'End If

        'If chkExport.Checked = True Then
        '    StatusExport = "0"
        'End If
        'If chkExport.Checked = False Then
        '    StatusExport = "1"
        'End If

        'If chkWarehouse.Checked = True Then
        '    StatusWareHouse = "0"
        'End If
        'If chkWarehouse.Checked = False Then
        '    StatusWareHouse = "1"
        'End If

        'If rdbEnable.Checked = True Then
        '    UserStatus = "0"
        'End If
        'If rdbDisable.Checked = True Then
        '    UserStatus = "1"
        'End If

        'Using tran As New TransactionScope()
        '        Try
        '            db.Database.Connection.Open()

        '            db.tblLogUser.Add(New tblLogUser With { _
        '                         .LowNumber = LowNumber, _
        '                         .UserName = txtUserName.Value, _
        '                         .UserGroupID = CType(dcboUserGroup.Text, Integer?), _
        '                         .StatusAdd = StatusAdd, _
        '                         .StatusModify = StatusModify, _
        '                         .StatusDelete = StatusDelete, _
        '                         .StatusPrint = StatusPrint, _
        '                         .StatusImport = StatusImport, _
        '                         .StatusExport = StatusExport, _
        '                         .StatusWarehouse = StatusWareHouse, _
        '                         .UserStatus = UserStatus, _
        '                         .LastUpDate = Now, _
        '                         .userId = CInt(Session("UserId"))
        '                     })

        '            db.SaveChanges()
        '            tran.Complete()

        '        Catch ex As Exception
        '            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)

        '        Finally
        '            db.Database.Connection.Close()
        '            db.Dispose()
        '            tran.Dispose()
        '        End Try
        '    End Using
    End Sub

    Private Sub upDateID(codeId As Integer, key As String)

        Try
            db.Database.Connection.Open()
            Dim update = (From c In db.tblRunningNumbers Where c.Name = key
                 Select c).First
            If update IsNot Nothing Then

                update.RunNo = codeId

                db.SaveChanges()

            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด !');", True)
        End Try
       
    End Sub
    Private Sub clear()
        txtUserName.Value = ""
        txtFullName.Value = ""
        dcboUserGroup.Text = ""
        txtUserGroup.Value = ""
        dcbBranch.Text = ""
        dcbDept.Text = ""
        txtPassword.Value = ""
        txtConfirmPassword.Value = ""
        chkAdd.Checked = False
        chkModify.Checked = False
        chkDelete.Checked = False
        chkPrint.Checked = False
        chkImport.Checked = False
        chkExport.Checked = False
        chkWarehouse.Checked = False
        'rdbEnable.Checked = True
    End Sub
    Protected Sub btnReset_Click(sender As Object, e As EventArgs)
        clear()
    End Sub
End Class