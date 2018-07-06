Imports System.Transactions
Public Class MasterMoneyConfigEdit
    Inherits System.Web.UI.Page

    Dim db As New LKBWarehouseEntities1_Test
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            showListMoney()
            showEdit()
        End If
    End Sub

    Protected Sub btnAdd_ServerClick(sender As Object, e As EventArgs)
        editMoneyConfig()
    End Sub

    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)
        clear()
    End Sub
    '-------------------------------------------------------------------Clear Data-------------------------------------------------
    Private Sub clear()
        txtCode.Value = ""
        txtAmount.Value = ""
        txtTotalAmount.Value = ""
        txtRemark.Text = ""
        dcbStatus.Text = ""
    End Sub
    '----------------------------------------------------------Show Edit Data-------------------------------------------
    Private Sub showEdit()
        Dim Code As String = Request.QueryString("Code")
        Dim wsm As String = "eagles"

        Dim user = (From u In db.tblMoneyConfigs Where u.Code = Code).SingleOrDefault
        txtCode.Value = user.Code
        txtAmount.Value = user.Amonut
        txtTotalAmount.Value = user.TotalAmonut
        txtRemark.Text = user.Remark
        dcbStatus.Text = user.Status

    End Sub
    '------------------------------------------------------Show DataLocation in Repeater--------------------------------------------
    Public Sub showListMoney()

        Dim user = (From u In db.tblMoneyConfigs
                   Select New With {u.Code,
                          u.Amonut,
                          u.TotalAmonut,
                          u.Remark,
                          u.Status})

        If user.Count > 0 Then
            Repeater1.DataSource = user.ToList
            Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If
    End Sub
    '------------------------------------------------------------Repeater Method---------------------------------------------
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim id As String = Session("UserName").ToString
        Dim menu As String = "frmUserProfile"
        Dim index As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("editcode") Then
            Dim ds1 = From c In db.tblUserMenus Where c.UserName = id And c.Form = menu And c.Edit_ = 1
            If ds1.Any Then
                Response.Write("<script>window.open('MasterMoneyConfigEdit.aspx?Code=" & index & "',target='_self');</script>")
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
    '-----------------------------------------------------------------------Add User Method-------------------------------------------
    Private Sub editMoneyConfig()
        Dim Code As String = Request.QueryString("Code")
        If (String.IsNullOrEmpty(txtCode.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน  LocationNo ก่อน !!!');", True)
            txtCode.Focus()
        Else
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()

                    Dim edit As tblMoneyConfig = (From c In db.tblMoneyConfigs Where c.Code = Code Select c).First()

                    edit.Code = txtCode.Value.Trim
                    edit.Amonut = txtAmount.Value.Trim
                    edit.TotalAmonut = txtAmount.Value.Trim
                    edit.Remark = txtRemark.Text.Trim
                    edit.Status = dcbStatus.Text.Trim
                    edit.UpdateBy = CStr(Session("UserName"))
                    edit.UpdateDate = Now

                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไข Code Config สำเร็จ !');", True)
                    Response.Redirect("MasterMoneyConfig.aspx")
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

    'Private Sub SaveDATA_New()
    '    Try
    '        Dim user = (From u In db.tblMoneyConfigs Where u.Code = txtCode.Value
    '      Select u).FirstOrDefault

    '        If Not user Is Nothing Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Code ซ้ำ กรุณาเปลี่ยนใหม่');", True)
    '        Else
    '            EditMoneyConfig()
    '            Response.Write("<script>window.open('MasterMoneyConfig.aspx,target='_self');</script>")
    '        End If
    '    Catch ex As Exception
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด');", True)
    '    End Try
    'End Sub
End Class