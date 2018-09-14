Option Strict On
Option Explicit On
Option Infer On

Imports System.Transactions

Public Class MasterLocationEdit
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showEdit()

        End If
    End Sub

    Private Sub showEdit()
        Dim LocationNo As String = Request.QueryString("LocationNo")
        Dim wsm As String = "eagles"

        Dim user = (From u In db.tblWHLocations Where u.LocationNo = LocationNo).SingleOrDefault
        txtWHsite.Value = user.WHsite
        txtLocationNo.Value = user.LocationNo
        txtWidth.Value = CStr(user.Width)
        txtLong.Value = CStr(user.Long)
        txtHeigth.Value = CStr(user.Height)
        txtValume.Value = CStr(user.Valume)
        txtUsedStatus.Value = CStr(user.Usedstatus)
        txtQTYPallet.Value = CStr(user.Qtypallet)
        txtRemark.Text = user.Remark
    End Sub

    '---------------------------------------------------------------btnAddClick-------------------------------------------------
    Protected Sub Button1_ServerClick(sender As Object, e As EventArgs)
        editParty()
    End Sub

    Private Sub editParty()
        Dim LocationNo As String = Request.QueryString("LocationNo")
        Dim UserName As String = Request.QueryString("UserName")
        If (String.IsNullOrEmpty(txtLocationNo.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน  LocationNo ก่อน !!!');", True)
            txtLocationNo.Focus()
        Else
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()

                    Dim edit As tblWHLocation = (From c In db.tblWHLocations Where c.LocationNo = LocationNo Select c).First()
                    edit.WHsite = txtWHsite.Value
                    edit.LocationNo = txtLocationNo.Value
                    edit.Width = CType(txtWidth.Value, Double?)
                    edit.Height = CType(txtHeigth.Value.Trim, Double?)
                    edit.Long = CType(txtLong.Value.Trim, Double?)
                    edit.Valume = CType(txtValume.Value.Trim, Double?)
                    edit.Usedstatus = CType(txtUsedStatus.Value.Trim, Integer?)
                    edit.Qtypallet = CType(txtQTYPallet.Value.Trim, Integer?)
                    edit.Remark = txtRemark.Text.Trim
                    edit.UpdateBy = CStr(Session("UserId"))
                    edit.UpdateDate = Now
                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไข Location สำเร็จ !');", True)
                    'Response.Write("<script>window.open('ViewUserProfile.aspx?UserName=" & LocationNo & "',target='_self');</script>")
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