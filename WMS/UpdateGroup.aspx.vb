Option Strict On
Option Explicit On

Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Transactions
Public Class UpdateGroup
    Inherits System.Web.UI.Page
    'Dim db As New LKBwarehouseEntities
    Dim db As New LKBWarehouseEntities1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showMasterCode()
        End If
    End Sub
    Private Sub showMasterCode()
        Dim idType As Integer = CInt(Request.QueryString("ID"))
        'Dim codeType = (From ct In db.tblCodeMaster Join tm In db.tblTypeMasterCode On ct.TypeID Equals tm.TypeID
        '           Where ct.MasterCodeID = idType).SingleOrDefault

        Dim codeType = (From ct In db.tblMasterCode2 Where ct.MasterCodeID = idType).SingleOrDefault

        

        txtType.Value = codeType.Type
        txtCode.Value = codeType.Code
        txtDescription.Text = codeType.Description
        txtNotes.Text = codeType.Note
        txtFilteringIndicator.Value = codeType.FilterInd

    End Sub
    Protected Sub btnUpdatGroup_Click(sender As Object, e As EventArgs)
        upDateGroup()
    End Sub

    Private Sub upDateGroup()
        Dim idType As Integer = CInt(Request.QueryString("ID"))
        Using tran As New TransactionScope()

            Try
                db.Database.Connection.Open()
                Dim edit As tblMasterCode2 = (From c In db.tblMasterCode2 Where c.MasterCodeID = idType
            Select c).First
                If edit IsNot Nothing Then

                    edit.Type = txtType.Value.Trim
                    edit.Code = txtCode.Value.Trim
                    edit.Description = txtDescription.Text.Trim
                    edit.Note = txtNotes.Text.Trim
                    edit.FilterInd = txtCode.Value.Trim
                    edit.UpdateBy = CStr(Session("UserId"))
                    edit.UpdateDate = Now

                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                    Response.Redirect("MasterCode.aspx")
                End If
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            Finally
                db.Database.Connection.Close()
                db.Dispose()
                tran.Dispose()
            End Try
        End Using
    End Sub
End Class