Option Explicit On
Option Strict Off
Option Infer On
Imports System.Transactions

Public Class AddGroup
    Inherits System.Web.UI.Page

    Dim db As New LKBWarehouseEntities1


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            'showType()
        End If
    End Sub
    'Private Sub showType()
    '    dcboTypeGroup.Items.Clear()
    '    dcboTypeGroup.Items.Add(New ListItem("--Select Group--", ""))
    '    dcboTypeGroup.AppendDataBoundItems = True

    '    Dim d = From ug In db.tblTypeMasterCode
    '            Select ug.TypeID, ug.TypeName
    '    Try
    '        dcboTypeGroup.DataSource = d.ToList
    '        dcboTypeGroup.DataTextField = "TypeName"
    '        dcboTypeGroup.DataValueField = "TypeID"
    '        dcboTypeGroup.DataBind()
    '        If dcboTypeGroup.Items.Count > 1 Then
    '            dcboTypeGroup.Enabled = True
    '        Else
    '            dcboTypeGroup.Enabled = False
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Protected Sub btnAddGroup_click(sender As Object, e As EventArgs)
        AddGroup()
    End Sub
    Private Sub checkID()
        '    Dim Key As String
        '    Dim runno As Integer
        '    Dim RJITno As String
        '    Dim codeId As Integer
        '    Key = "log-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM")))

        '    Dim u = (From log In db.tblRunningNumbers Where log.Name = Key Select log).FirstOrDefault

        '    If Not u Is Nothing Then

        '        runno = CInt(u.RunNo)
        '        codeId = runno + 1
        '        RJITno = "log-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
        '        AddGroup()
        '        upDateID(codeId, Key)
        '    Else

        '        db.tblRunningNumbers.Add(New tblRunningNumber With
        '                          {
        '                              .Name = Key, _
        '                              .RunNo = CType("0", Integer?) _
        '                          })

        '        db.SaveChanges()
        '        runno = CInt("0")
        '        codeId = runno + 1
        '        RJITno = "log-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
        '        AddGroup()
        '        upDateID(codeId, Key)
        '    End If
    End Sub
    '-------------------------------------------------------Add Group Method --------------------------------------
    Private Sub AddGroup()
        If (String.IsNullOrEmpty(txtCode.Value.Trim)) Then

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Code ก่อน !');", True)

        Else

            Using tran As New TransactionScope()

                Try
                    db.Database.Connection.Open()
                    db.tblMasterCode2.Add(New tblMasterCode2() With {
                                      .Type = txtType.Value.Trim, _
                                      .Code = txtCode.Value.Trim, _
                                      .Note = txtNotes2.Text.Trim, _
                                      .Description = txtDescription2.Text.Trim, _
                                      .FilterInd = txtFilteringIndicator.Value.Trim, _
                                      .CreateBy = CStr(Session("UserId")), _
                                      .CreateDate = Now})

                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เพิ่ม Group สำเร็จ !');", True)
                    clearType()

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


    Protected Sub btnAddTypeGroup_click(sender As Object, e As EventArgs)
        'checkTypeID()
    End Sub
    Private Sub checkTypeID()

        'Dim keyType As String
        'Dim runno As Integer
        'Dim RJITno As String
        'Dim codeId As Integer
        'keyType = "Type" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM")))

        'Dim u = (From us In db.tblRunningNumber
        '                         Where us.Name = keyType Select us).FirstOrDefault

        'If Not u Is Nothing Then

        '    runno = CInt(u.RunNo)
        '    codeId = runno + 1
        '    RJITno = "Type" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
        '    AddGroupType(RJITno)
        '    upDateID(codeId, keyType)

        'Else
        '    db.tblRunningNumber.Add(New tblRunningNumber With
        '                          {
        '                              .Name = keyType, _
        '                              .RunNo = CType("0", Integer?) _
        '                          })

        '    db.SaveChanges()
        '    runno = CInt("0")
        '    codeId = runno + 1
        '    RJITno = "Type" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
        '    MsgBox(RJITno)
        '    AddGroupType(RJITno)
        '    upDateID(codeId, keyType)

        'End If

    End Sub
    Private Sub AddGroupType(typrID As String)
        'If (String.IsNullOrEmpty(txtTypeName.Value.Trim)) Then

        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน TypeNam ก่อน !');", True)

        'Else
        '    Using tran As New TransactionScope()
        '        Try

        '            db.Database.Connection.Open()

        '            db.tblTypeMasterCode.Add(New tblTypeMasterCode With {
        '                                 .TypeID = typrID, _
        '                                 .TypeName = txtTypeName.Value.Trim, _
        '                                 .Description = txtTypeDes.Value.Trim, _
        '                                 .Note = txtTypeNotes.Value.Trim, _
        '                                 .FilterInd = txtIndicator.Value.Trim, _
        '                                 .CreateBy = CType(Session("UserId"), Integer?), _
        '                                 .CreateDate = Now
        '                             })
        '            db.SaveChanges()
        '            tran.Complete()
        '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เพิ่ม TypeGroup สำเร็จ !');", True)
        '            checkType()
        '        Catch ex As Exception

        '            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
        '        Finally
        '            db.Database.Connection.Close()
        '            db.Dispose()
        '            tran.Dispose()

        '        End Try
        '    End Using

        'End If

    End Sub

    Private Sub upDateID(codeId As Integer, key As String)
        Try
            db.Database.Connection.Open()
            Dim update = (From c In db.tblRunningNumbers Where c.Name = key
                 Select c).First
            If update IsNot Nothing Then

                update.RunNo = codeId

                db.SaveChanges()

            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด !');", True)
        End Try

    End Sub
    Private Sub clearType()
        txtType.Value = ""
        txtDescription2.Text = ""
        txtNotes2.Text = ""
        txtFilteringIndicator.Value = ""
        txtCode.Value = ""
    End Sub
    Protected Sub btnClear_Click(sender As Object, e As EventArgs)
        clearType()
    End Sub

End Class