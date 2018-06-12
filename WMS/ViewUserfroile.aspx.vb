Option Strict On
Option Explicit On


Public Class ViewUserfroile
    Inherits System.Web.UI.Page


    'Dim db As New LKBwarehouseEntities

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showViewUser()

        End If

    End Sub
    Private Sub showViewUser()

        'Dim UserName As String = Request.QueryString("UserName")
        'Dim wsm As String = "eagles"

        'Dim user = (From u In db.tblUser Join br In db.tblBranch On u.BranchID Equals br.BranchID
        '    Join de In db.tblDepartment On u.DepartmentID Equals de.DepartmentID
        '    Join ug In db.tblUserGroup On u.UserGroupID Equals ug.UserGroupID Where u.UserName = UserName).SingleOrDefault


        'If user.u.StatusAdd = "0" Then
        '    chkAdd.InnerText = "Add"

        'End If

        'If user.u.StatusModify = "0" Then
        '    chkModify.InnerText = "Modify"
        'End If

        'If user.u.StatusDelete = "0" Then
        '    chkDelete.InnerText = "Delete"
        'End If

        'If user.u.StatusPrint = "0" Then
        '    chkPrint.InnerText = "Print"
        'End If


        'If user.u.StatusImport = "0" Then
        '    chkImport.InnerText = "Import"
        'End If

        'If user.u.StatusExport = "0" Then
        '    chkExport.InnerText = "Export"
        'End If

        'If user.u.StatusWarehouse = "0" Then
        '    chkWarehouse.InnerText = "Warehouse"
        'End If


        'If user.u.UserStatus = "0" Then
        '    rdbEnable.InnerText = "Enable"
        'Else
        '    rdbEnable.InnerText = "Disable"
        'End If

        'txtUserName.Value = user.u.UserName
        'txtFullName.Value = user.u.Name
        'txtUserGroup.Value = user.ug.UserGroupName
        'txtBranch.Value = user.br.BranchName
        'txtGroup.Value = user.ug.UserGroupCode
        'txtDept.Value = user.de.DepartmentName



    End Sub
End Class