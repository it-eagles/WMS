Option Strict On
Option Explicit On

Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Transactions
Public Class UpdateGroup
    Inherits System.Web.UI.Page
    Dim db As New LKBwarehouseEntities

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            showMasterCode()
        End If
    End Sub
    Private Sub showMasterCode()
        Dim idType As Integer = CInt(Request.QueryString("ID"))
   
            Dim codeType = (From ct In db.tblCodeMaster Join tm In db.tblTypeMasterCode On ct.TypeID Equals tm.TypeID
                       Where ct.MasterCodeID = idType).SingleOrDefault

            txtTypeName.Value = codeType.tm.TypeName
            txtCode.Value = codeType.ct.Code
            txtDescription.Value = codeType.ct.Description
            txtNotes.Value = codeType.ct.Note
            txtFilteringIndicator.Value = codeType.ct.FilterInd

    End Sub
    Protected Sub btnUpdatGroup_Click(sender As Object, e As EventArgs)
        upDateGroup()
    End Sub
    

    Private Sub upDateGroup()
        Dim idType As Integer = CInt(Request.QueryString("ID"))
            Using tran As New TransactionScope()

            Try
                db.Database.Connection.Open()
                Dim edit As tblCodeMaster = (From c In db.tblCodeMaster Where c.MasterCodeID = idType
            Select c).First
                If edit IsNot Nothing Then

                    edit.Code = txtCode.Value.Trim
                    edit.Description = txtDescription.Value.Trim
                    edit.FilterInd = txtCode.Value.Trim
                    edit.Note = txtNotes.Value.Trim
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