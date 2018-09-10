Option Strict On
Option Explicit On

Imports System.Data
Imports LinqToExcel
Imports ExcelDataReader
Imports System.Data.OleDb
Imports System.IO
Imports System.Configuration




Public Class Test
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblDisplayDate.Text = System.DateTime.Now.ToString("T")
        If Not Me.IsPostBack Then
            'TabName.Value = Request.Form(TabName.UniqueID)

            showUserList()
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

    'Protected Sub cpRepeater_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
    '    'If e.CommandName.Equals("edit") Then

    '    'End If
    '    'If e.CommandName.Equals("update") Then
    '    '    MsgBox("update")
    '    'End If
    '    'If e.CommandName.Equals("delete") Then
    '    '    MsgBox("dalete")
    '    'End If
    'End Sub

    'Protected Sub cpRepeater_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)

    'End Sub

    Protected Sub lnkDelSelected_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub showUserList()

        'Dim formlist = (From u In db.tblMenus
        '                Group By Form = u.Form
        '                Into f = Group, Count())
        Dim formlist = (From u In db.tblUsers
                 Select New With {
                     u.UserName,
                     u.Name,
                     u.Branch,
                     u.Dept
                    }).Take(10)

        If formlist.Count > 0 Then
            Me.rptCustomers.DataSource = formlist.ToList
            Me.rptCustomers.DataBind()
        Else
            Me.rptCustomers.DataSource = Nothing
            Me.rptCustomers.DataBind()
            End If
    End Sub

    'Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)
    '    Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
    '    Me.ToggleElemnts(item, True)

    'End Sub
    'Private Sub ToggleElemnts(item As RepeaterItem, isEdit As Boolean)
    '    item.FindControl("lnkEdit").Visible = Not isEdit
    '    item.FindControl("lnkUpdate").Visible = isEdit
    '    item.FindControl("lnkCancel").Visible = isEdit
    '    item.FindControl("lnkDelete").Visible = Not isEdit

    '    item.FindControl("lblID").Visible = Not isEdit
    '    item.FindControl("lblName").Visible = Not isEdit
    'End Sub
    'Protected Sub LinkButton2_Click(sender As Object, e As EventArgs)

    'End Sub

    'Protected Sub LinkButton3_Click(sender As Object, e As EventArgs)
    '    Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
    '    Me.ToggleElemnts(item, False)
    'End Sub

    'Protected Sub lnkDelete_Click(sender As Object, e As EventArgs)

    'End Sub

    'Protected Sub cpRepeater_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles cpRepeater.ItemCommand

    '    Dim lblRead As Label = CType(e.Item.FindControl("lblRead"), Label)
    '    Dim lblUpdate As LinkButton = CType(e.Item.FindControl("lnkUpdate"), LinkButton)
    '    Dim lnkCancel As LinkButton = CType(e.Item.FindControl("lnkCancel"), LinkButton)
    '    Dim lnkEdit As LinkButton = CType(e.Item.FindControl("lnkEdit"), LinkButton)
    '    Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)
    '    If e.CommandName.Equals("editMenu") Then
    '        'MsgBox("อะไรว่ะ")
    '        'Response.Write("<script>window.open('ViewUserProfile.aspx?UserName,target='_self');</script>")
    '        lblUpdate.Visible = True
    '        lnkCancel.Visible = True
    '        lnkEdit.Visible = False
    '        lnkDelete.Visible = False
    '        'showUserList()
    '    End If
    'End Sub

    Protected Sub btnOpenModal_Click(sender As Object, e As EventArgs)
        'ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "show", "$(function () { $('#" + Panel2.ClientID + "').modal('show'); });", True)
        'UpdatePanel2.Update()
        '.RegisterStartupScript(Me, Me.GetType(), "myModal", "openjobNoModal();", True)
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#myModal').hide();", True)

    End Sub

    Protected Sub btnCloseModal_Click(sender As Object, e As EventArgs)

    End Sub

    'Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    mp1.Show()
    'End Sub

    'Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
    '    GridView1.PageIndex = e.NewPageIndex
    '    showUserList()

    'End Sub

    Protected Sub rptCustomers_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
       
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblUserName As Label = CType(e.Item.FindControl("lblUserName"), Label)
            Dim lblName As Label = CType(e.Item.FindControl("lblName"), Label)
            Dim lblBranch As Label = CType(e.Item.FindControl("lblBrnch"), Label)
            Dim lblDept As Label = CType(e.Item.FindControl("lblDept"), Label)
            'Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)

            If Not IsNothing(lblUserName) Then
                lblUserName.Text = DataBinder.Eval(e.Item.DataItem, "UserName").ToString
            End If
            If Not IsNothing(lblName) Then
                lblName.Text = DataBinder.Eval(e.Item.DataItem, "Name").ToString
            End If
            If Not IsNothing(lblBranch) Then
                lblBranch.Text = DataBinder.Eval(e.Item.DataItem, "Branch").ToString
            End If
            If Not IsNothing(lblDept) Then
                lblDept.Text = DataBinder.Eval(e.Item.DataItem, "Dept").ToString
            End If
        End If
      
    End Sub

    Protected Sub btntest_ServerClick1(sender As Object, e As EventArgs)
        'Dim item As RepeaterItem = TryCast(TryCast(sender, CheckBox).Parent, RepeaterItem)
        Dim chkName As CheckBox
        Dim lblUserName As String
        'Dim lblName As String
        'Dim lblBranch As String
        Dim i As Integer
        Dim j As Integer
        Dim name As ArrayList
        name = New ArrayList
        For i = 0 To rptCustomers.Items.Count - 1
            chkName = CType(rptCustomers.Items(i).FindControl("chkRowData"), CheckBox)
            lblUserName = CType(rptCustomers.Items(i).FindControl("lblUserName"), Label).Text.Trim

            'lblName = CType(rptCustomers.Items(i).FindControl("lblName"), Label).Text.Trim
            'lblBranch = CType(rptCustomers.Items(i).FindControl("lblBrnch"), Label).Text.Trim
            If chkName.Checked = True Then
                Dim u = (From us In db.tblUsers Where us.UserName = lblUserName).FirstOrDefault
                If Not IsNothing(u) Then
                    db.tblUser_test.Add(New tblUser_test With { _
                                   .UserName = u.UserName, _
                                   .Name = u.Name, _
                                   .UserGroup = u.UserGroup, _
                                   .GroupName = u.UserGroup, _
                                   .Dept = u.Dept, _
                                   .Branch = u.Branch, _
                                   .StatusAdd = u.StatusAdd, _
                                   .StatusModify = u.StatusAdd, _
                                   .StatusDelete = u.StatusAdd, _
                                   .StatusPrint = u.StatusAdd, _
                                   .StatusImport = u.StatusAdd, _
                                   .StatusExport = u.StatusAdd, _
                                   .StatusWarehouse = u.StatusAdd, _
                                   .UserStatus = u.StatusAdd, _
                                   .RejectStatus = u.StatusAdd
                                   })
                    db.SaveChanges()
                End If
            End If
        Next
        ''MsgBox(lblUserName)
        'name.Add(lblUserName)
        ''name.Add(lblName)
        ''name.Add(lblBranch)
        ''For j = 0 To name.Count - 1

        ''Next
        'GridView1.DataSource = name
        'GridView1.DataBind()
    End Sub

    Protected Sub chkAll_CheckedChanged(sender As Object, e As EventArgs)
        Dim chkName As CheckBox
        Dim lblUserName As String
        Dim i As Integer
        Dim j As Integer
        Dim name As ArrayList
        name = New ArrayList
        For i = 0 To rptCustomers.Items.Count - 1
            chkName = CType(rptCustomers.Items(i).FindControl("chkRowData"), CheckBox)
            lblUserName = CType(rptCustomers.Items(i).FindControl("lblUserName"), Label).Text.Trim
            'lblName = CType(rptCustomers.Items(i).FindControl("lblName"), Label).Text.Trim
            'lblBranch = CType(rptCustomers.Items(i).FindControl("lblBrnch"), Label).Text.Trim
            If chkName.Checked = True Then
                Dim us = (From u In db.tblUsers Where u.UserName = lblUserName).FirstOrDefault
                'txttest.Text = us.UserName
                'txtName.Value = us.Name
                'txtDept.Value = us.Dept
                'txtBranch.Value = us.Branch
            End If
        Next
    End Sub

    'Protected Sub txttest_TextChanged(sender As Object, e As EventArgs) Handles txttest.TextChanged
    '    MsgBox(txttest.Text)
    '

    Protected Sub btnAdd_ServerClick(sender As Object, e As EventArgs)
        'Dim StrWer As StreamReader
        'Dim readLine As String
        'Dim fileE As Boolean
        'fileE = My.Computer.FileSystem.FileExists(txtFile.Value.Trim)

        'StrWer = file.OpenText(txtFile.Value.Trim)

        'Do Until StrWer.EndOfStream
        '    readLine = StrWer.ReadLine

        '    Dim S As String = Split(readLine, ",")(0)
        'Loop

        If FileUpload1.HasFile Then
            ' Path ที่ฮยู่ไฟล์
            Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            ' นามสกุล
            Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
            ' Path ที่เก็บไฟล์ 
            Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
            ' save ไฟล์ลง path
            Dim FilePath As String = Server.MapPath(FolderPath + FileName)
            FileUpload1.SaveAs(FilePath)
            Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)
        End If
    End Sub
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
        Dim conStr As String = ""
        Select Case Extension
            Case ".xls"
                conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                Exit Select
            Case ".xlsx"
                conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString
                Exit Select
        End Select

        conStr = String.Format(conStr, FilePath, isHDR)

        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand
        Dim oda As New OleDbDataAdapter
        Dim dt As New DataTable

        cmdExcel.Connection = connExcel
        connExcel.Open()
        Dim dtExeelSchema As DataTable
        dtExeelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim SheetName As String = dtExeelSchema.Rows(0)("TABLE_NAME").ToString
        connExcel.Close()

        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        connExcel.Close()

        For i = 0 To dt.Rows.Count - 1
            txtCompanyName.Text = dt.Rows(i)("CompanyName").ToString

        Next
        'GridView1.Caption = Path.GetFileName(FilePath)
        'GridView1.DataSource = dt
        'GridView1.DataBind()
        'dt.Columns.Add()

    End Sub

    Protected Sub PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
        Dim FileName As String = GridView1.Caption
        Dim Extension As String = Path.GetExtension(FileName)
        Dim FilePath As String = Server.MapPath(FolderPath + FileName)

        Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub
End Class