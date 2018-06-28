Option Explicit On
Option Strict On

Public Class MasterCode
    Inherits System.Web.UI.Page
    'Dim db As New LKBwarehouseEntities
    Dim db As New LKBWarehouseEntities1_Test
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            showMasterCode()
        End If
    End Sub
    Private Sub showMasterCode()
       
        Dim codeType = (From ct In db.tblMasterCodes
         Select New With {ct.Type,
                 ct.Code,
                 ct.Description,
                 ct.Note,
                 ct.FilterInd}).ToList()

        If codeType.Count > 0 Then
            Repeater1.DataSource = codeType
            Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If
    End Sub

    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        '    Dim index As String = CStr(e.CommandArgument)

        '    If e.CommandName.Equals("editGroup") Then
        '        Response.Write("<script>window.open('UpdateGroup.aspx?ID=" & index & "',target='_self');</script>")
        '    ElseIf e.CommandName.Equals("viewGroup") Then

        '        Response.Write("<script>window.open('ViewGroup.aspx?ID=" & index & "',target='_self');</script>")

        '    End If
    End Sub
End Class