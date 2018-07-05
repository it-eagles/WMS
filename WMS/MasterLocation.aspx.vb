Imports System.Transactions
Public Class MasterLocation
    Inherits System.Web.UI.Page

    'Dim db As New LKBwarehouseEntities
    Dim db As New LKBWarehouseEntities1_Test

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showListLocation()
        End If
    End Sub
    '---------------------------------------------------------------btnAddClick-------------------------------------------------
    Protected Sub Button1_ServerClick(sender As Object, e As EventArgs)
        addLocation()
    End Sub
    '---------------------------------------------------------------------btnClearClick------------------------------------------------
    Protected Sub Button2_ServerClick(sender As Object, e As EventArgs)
        clear()
    End Sub
    '------------------------------------------------------Show DataLocation in Repeater--------------------------------------------
    Public Sub showListLocation()

        Dim user = (From u In db.tblWHLocations
                   Select New With {u.WHsite,
                          u.LocationNo,
                          u.Width,
                          u.Long,
                          u.Height,
                          u.Valume,
                          u.Qtypallet})


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
        If e.CommandName.Equals("editlocation") Then
            Dim ds1 = From c In db.tblUserMenus Where c.UserName = id And c.Form = menu And c.Edit_ = 1
            If ds1.Any Then
                Response.Write("<script>window.open('MasterLocationEdit.aspx?LocationNo=" & index & "',target='_self');</script>")
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
    Private Sub addLocation()
        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()

                db.tblWHLocations.Add(New tblWHLocation With { _
                             .WHsite = txtWHsite.Value.Trim, _
                             .LocationNo = txtLocationNo.Value.Trim, _
                             .Width = txtWidth.Value.Trim, _
                             .Long = txtLong.Value.Trim, _
                             .Height = txtHeigth.Value.Trim, _
                             .Valume = txtValume.Value.Trim, _
                             .Usedstatus = txtUsedStatus.Value.Trim, _
                             .Qtypallet = txtQTYPallet.Value.Trim, _
                             .Remark = txtRemark.Text.Trim, _
                             .CreateBy = CStr(Session("UserId")), _
                             .CreateDate = Now})

                db.SaveChanges()
                tran.Complete()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เพิ่ม Location สำเร็จ !');", True)
                Response.Redirect("MasterLocation.aspx")
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try
        End Using
    End Sub
    '-------------------------------------------------------------------Clear Data-------------------------------------------------
    Private Sub clear()
        txtWHsite.Value = ""
        txtLocationNo.Value = ""
        txtWidth.Value = ""
        txtHeigth.Value = ""
        txtValume.Value = ""
        txtUsedStatus.Value = ""
        txtQTYPallet.Value = ""
        txtRemark.Text = ""
    End Sub
End Class