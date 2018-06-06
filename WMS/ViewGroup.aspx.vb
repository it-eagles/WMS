Option Strict On
Option Explicit On

Public Class ViewGroup
    Inherits System.Web.UI.Page
    Dim db As New LKBwarehouseEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        showMasterCode()
    End Sub
    Private Sub showMasterCode()

        Dim idType As Integer = CInt(Request.QueryString("ID"))
     
            Dim codeType = (From ct In db.tblCodeMaster Join tm In db.tblTypeMasterCode On ct.TypeID Equals tm.TypeID
                      Join u In db.tblUser On ct.UserID Equals u.UserID
                       Where ct.MasterCodeID = idType).SingleOrDefault

            If Not codeType Is Nothing Then

                Dim typeName As String = codeType.ct.TypeID
                If (String.IsNullOrEmpty(typeName)) Then
                    txtTypeName.Value = ""
                Else
                    txtTypeName.Value = codeType.tm.TypeName
                End If

                txtCode.Value = codeType.ct.Code
                txtDescription.Value = codeType.ct.Description
                txtNotes.Value = codeType.ct.Note
                txtFilteringIndicator.Value = codeType.ct.FilterInd

                Dim crDate As String = String.Format("{0:dd/MM/yyyy}", codeType.ct.CreateDate)
                If (String.IsNullOrEmpty(crDate)) Then

                    txtCreateDate.Value = "ไม่มีวันที่บันทึกข้อมูล"

                Else
                    txtCreateDate.Value = crDate
                End If
                Dim username As String = CStr(codeType.ct.UserId)
                If (String.IsNullOrEmpty(username)) Then
                    txtReby.Value = ""
                Else
                    txtReby.Value = codeType.u.UserName
                End If


                Dim userUp As String = codeType.ct.UpdateBy

                If (String.IsNullOrEmpty(userUp)) Then
                    txtUpdateBy.Value = "ยังไม่มีการแก้ไขข้อมูล"
                Else
                    txtUpdateBy.Value = codeType.u.UserName
                End If


                Dim upDate As String = String.Format("{0:dd/MM/yyyy}", codeType.ct.UpdateDate)
                If (String.IsNullOrEmpty(upDate)) Then
                    txtUpdateDate.Value = "ยังไม่มีการแก้ไขข้อมูล"
                Else
                    txtUpdateDate.Value = upDate

                End If

            Else
                MsgBox("เป็นค่าว่าง")
            End If

    End Sub
End Class