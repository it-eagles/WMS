Option Explicit On
Option Strict On

Public Class MasterCode
    Inherits System.Web.UI.Page
    Dim db As New LKBwarehouseEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            showMasterCode()
        End If
    End Sub
    Private Sub showMasterCode()
       
        Dim codeType = From ct In db.tblCodeMaster Join tm In db.tblTypeMasterCode On ct.TypeID Equals tm.TypeID
         Select
             ct.MasterCodeID,
             tm.TypeName,
             ct.Code,
             ct.Description,
             ct.Note


            If codeType.Count > 0 Then
                Repeater1.DataSource = codeType.ToList
                Repeater1.DataBind()

            End If

    End Sub

    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim index As String = CStr(e.CommandArgument)

        If e.CommandName.Equals("editGroup") Then
            Response.Write("<script>window.open('UpdateGroup.aspx?ID=" & index & "',target='_self');</script>")
        ElseIf e.CommandName.Equals("viewGroup") Then

            Response.Write("<script>window.open('ViewGroup.aspx?ID=" & index & "',target='_self');</script>")

        End If
    End Sub
End Class