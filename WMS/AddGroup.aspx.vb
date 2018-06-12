Option Explicit On
Option Strict On

Imports System.Transactions

Public Class AddGroup
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            'showType()
        End If
    End Sub
    
    'Private Sub showType()
    '    dcboGroup.Items.Clear()
    '    dcboGroup.Items.Add(New ListItem("--Select Group--", ""))
    '    dcboGroup.AppendDataBoundItems = True

    '    Dim d = From ug In db.tblTypeMasterCode
    '            Select ug.TypeID, ug.TypeName
    '    Try
    '        dcboGroup.DataSource = d.ToList
    '        dcboGroup.DataTextField = "TypeName"
    '        dcboGroup.DataValueField = "TypeID"
    '        dcboGroup.DataBind()
    '        If dcboGroup.Items.Count > 1 Then
    '            dcboGroup.Enabled = True
    '        Else
    '            dcboGroup.Enabled = False

    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub
    Protected Sub btnAddGroup_click(sender As Object, e As EventArgs)

        checkID()

    End Sub
    Private Sub checkID()
        'Dim Key As String
        'Dim runno As Integer
        'Dim RJITno As String
        'Dim codeId As Integer
        'Key = Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM")))

        'Dim u = (From us In db.tblRunningNumber()
        '                         Where us.Name = Key Select us).FirstOrDefault

        'If Not u Is Nothing Then

        '    runno = CInt(u.RunNo)
        '    codeId = runno + 1
        '    RJITno = Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
        '    AddGroup(RJITno)
        '    upDateID(codeId, Key)
        'Else

        '    db.tblRunningNumber.Add(New tblRunningNumber With
        '                      {
        '                          .Name = Key, _
        '                          .RunNo = CType("0", Integer?) _
        '                      })

        '    db.SaveChanges()
        '    runno = CInt("0")
        '    codeId = runno + 1
        '    RJITno = Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
        '    AddGroup(RJITno)
        '    upDateID(codeId, Key)
        'End If

    End Sub
    Private Sub AddGroup(WSIT As String)


        'If (String.IsNullOrEmpty(txtCode.Value.Trim)) Then

        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Code ก่อน !');", True)

        'Else

        '    Using tran As New TransactionScope()

        '            Try

        '                db.Database.Connection.Open()

        '                db.tblCodeMaster.Add(New tblCodeMaster With {
        '                                  .MasterCodeID = CInt(WSIT), _
        '                                  .TypeID = dcboGroup.Text, _
        '                                  .Code = txtCode.Value.Trim, _
        '                                  .Note = txtNotes.Value.Trim, _
        '                                  .Description = txtDescription.Value.Trim, _
        '                                  .FilterInd = txtFilteringIndicator.Value.Trim, _
        '                                  .UserID = CInt(Session("UserId")), _
        '                                  .CreateDate = Now
        '                               })

        '                db.SaveChanges()
        '                tran.Complete()
        '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เพิ่ม Group สำเร็จ !');", True)
        '                check()

        '            Catch ex As Exception

        '                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)


        '            Finally
        '                db.Database.Connection.Close()
        '                db.Dispose()
        '                tran.Dispose()
        '            End Try

        '        End Using

        'End If
    End Sub

    Private Sub check()
        txtCode.Value = ""
        txtNotes.Value = ""
        txtDescription.Value = ""
        txtFilteringIndicator.Value = ""
    End Sub

    
    Protected Sub btnAddTypeGroup_click(sender As Object, e As EventArgs)
        checkTypeID()
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
        'Try
        '    db.Database.Connection.Open()
        '    Dim update = (From c In db.tblRunningNumber Where c.Name = key
        '         Select c).First
        '    If update IsNot Nothing Then

        '        update.RunNo = codeId

        '        db.SaveChanges()

        '    End If
        'Catch ex As Exception
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด !');", True)
        'End Try

    End Sub
    Private Sub checkType()
        txtTypeName.Value = ""
        txtTypeDes.Value = ""
        txtTypeNotes.Value = ""
        txtIndicator.Value = ""
    End Sub

End Class