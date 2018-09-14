Option Strict On
Option Explicit On
Option Infer On

Public Class ViewUserProfile
    Inherits System.Web.UI.Page

    Dim db As New LKBWarehouseEntities1
    'Dim db As New LKBwarehouseEntities

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showViewUser()

        End If

    End Sub
    Private Sub showViewUser()
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

        txtprofilename.InnerText = user.u.Name
        txtdeptname.InnerText = user.de.DepartmentName

        txtUserName.Value = user.u.UserName
        txtFullName.Value = user.u.Name
        txtUserGroup.Value = user.ug.UserGroupName
        txtBranch.Value = user.br.BranchName
        txtGroup.Value = user.ug.UserGroupCode
        txtDept.Value = user.de.DepartmentName

    End Sub
End Class
