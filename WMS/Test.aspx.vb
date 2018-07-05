Option Strict On
Option Explicit On

Public Class Test
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1_Test
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblDisplayDate.Text = System.DateTime.Now.ToString("T")
        If Not Me.IsPostBack Then
           
            showUserList()
            'Else
            '    MsgBox("เกิดความผิดพลาดในการทำงาน", MsgBoxStyle.OkCancel)
        End If
    End Sub

   

    Protected Sub btnTest_ServerClick(sender As Object, e As EventArgs)
        Dim script As String = "<script type='text/javascript'> " & _
             " function CallConfirmBox() {" & _
              "   if (confirm('Confirm Proceed Further?')) {" & _
              "alert('You pressed OK!') } " & _
              "else { alert('You pressed Cancel!'); }}" & _
        " </script>"
            'MsgBox("!!!!!")

            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertMessage", rad)
        ScriptManager.RegisterStartupScript(Me, Page.GetType(), "CallConfirmBox", script, True)

    End Sub

    'Protected Sub btnPostback_Click(sender As Object, e As EventArgs)
    '    Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
    '    sb.Append("<script language='javascript'>")
    '    sb.Append("var lbl = document.getElementById('lblDisplayDate');")
    '    sb.Append("lbl.style.color='red';")
    '    sb.Append("</script>")

    '    ScriptManager.RegisterStartupScript(btnPostback, Me.GetType(), "JSCR", sb.ToString(), False)
    'End Sub

    Protected Sub cpRepeater_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        'If e.CommandName.Equals("edit") Then

        'End If
        'If e.CommandName.Equals("update") Then
        '    MsgBox("update")
        'End If
        'If e.CommandName.Equals("delete") Then
        '    MsgBox("dalete")
        'End If
    End Sub

    Protected Sub cpRepeater_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)

    End Sub

    Protected Sub lnkDelSelected_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub showUserList()

        'Dim formlist = (From u In db.tblMenus
        '                Group By Form = u.Form
        '                Into f = Group, Count())
        Dim formlist = (From u In db.tblUserMenus
                 Select New With {
                     u.Form,
                     u.Read_
                    }).ToList

        If formlist.Count > 0 Then
            Me.cpRepeater.DataSource = formlist
            Me.cpRepeater.DataBind()
        Else
            Me.cpRepeater.DataSource = Nothing
            Me.cpRepeater.DataBind()
        End If
    End Sub
End Class