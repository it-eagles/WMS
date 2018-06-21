Option Explicit On
Option Strict On

Public Class UserMenu
    Inherits System.Web.UI.Page
    Dim db As LKBWarehouseEntities1_Test

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            'showUserlist()
        Else
            MsgBox("เกิดความผิดพลาดในการทำงาน", MsgBoxStyle.OkCancel)
        End If
       
    End Sub
    Private Sub showUserlist()

        Dim d = From ug In db.tblUserGroups
              Select ug.UserGroupName, ug.UserGroupCode

        'dcboUserGroup.DataSource = d.ToList
        'dcboUserGroup.DataTextField = "UserGroupCode"
        'dcboUserGroup.DataValueField = "UserGroupCode"
        'dcboUserGroup.DataBind()
        ''Dim dd As String = dcboUserGroup.Text
        ''showUserGroupName(dd)
        'If dcboUserGroup.Items.Count > 1 Then
        '    dcboUserGroup.Enabled = True
        'Else
        '    dcboUserGroup.Enabled = False

        'End If
        Try
            Dim user = From u In db.tblUsers
                    Select u.Name


            sltUser.DataSource = user.ToList
            sltUser.DataTextField = ""
            sltUser.DataValueField = ""
            sltUser.DataBind()

        Catch ex As Exception
            MsgBox("เกิดเหตุผิดพลาด")
        End Try

    End Sub
    Private Sub showUser()
        Try
            Dim user = (From u In db.tblUsers Where u.Name Like sltUser.Value & "%"
                    Select New With {u.Name}).ToList()


            If user.Count > 0 Then
                sltUser.DataSource = user
                sltUser.DataBind()
            Else
                sltUser.DataSource = Nothing
                sltUser.DataBind()

            End If
        Catch ex As Exception

        End Try
        
    End Sub
End Class