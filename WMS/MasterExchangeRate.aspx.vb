Imports System.Transactions
Imports System.IO

Public Class MasterExchangeRate
    Inherits System.Web.UI.Page
    Dim tmpSQLScript As String
    Dim db As New LKBWarehouseEntities1_Test

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            showListExchange()
            showEdit()
        End If
    End Sub

    Protected Sub btnAdd_ServerClick(sender As Object, e As EventArgs)
        editMoneyConfig()
    End Sub

    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)
        clear()
    End Sub
    '-------------------------------------------------------------------Clear Data-------------------------------------------------
    Private Sub clear()
        'txtSelect.Value = ""
        'txt.Value = ""
        'txtTotalAmount.Value = ""
        'txtRemark.Text = ""
        'dcbStatus.Text = ""
    End Sub
    '----------------------------------------------------------Show Edit Data-------------------------------------------
    Private Sub showEdit()
        'Dim Code As String = Request.QueryString("Code")
        'Dim wsm As String = "eagles"

        'Dim user = (From u In db.tblMoneyConfigs Where u.Code = Code).SingleOrDefault
        'txtSelect.Value = user.Code
        'txtAmount.Value = user.Amonut
        'txtTotalAmount.Value = user.TotalAmonut
        'txtRemark.Text = user.Remark
        'dcbStatus.Text = user.Status

    End Sub
    '------------------------------------------------------Show DataExchangeList in Repeater--------------------------------------------
    Public Sub showListExchange()

        Dim user = (From u In db.tblExchangeRates
                   Select New With {u.Currency,
                          u.StartDate,
                          u.EndDate,
                          u.ExchangeRate,
                          u.BathAmount,
                          u.Status})

        If user.Count > 0 Then
            Repeater1.DataSource = user.ToList
            Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If
    End Sub
    '------------------------------------------------------------Repeater Method---------------------------------------------
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim id As String = Session("UserName").ToString
        Dim menu As String = "frmUserProfile"
        Dim index As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("editcode") Then
            Dim ds1 = From c In db.tblUserMenus Where c.UserName = id And c.Form = menu And c.Edit_ = 1
            If ds1.Any Then
                Response.Write("<script>window.open('MasterMoneyConfigEdit.aspx?Code=" & index & "',target='_self');</script>")
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธ์การแก้ไข')", True)
            End If
        ElseIf e.CommandName.Equals("viewprofile") Then
            Dim ds1 = From c In db.tblUserMenus Where c.UserName = id And c.Form = menu And c.Read_ = 1
            If ds1.Any Then
                Response.Write("<script>window.open('ViewUserProfile.aspx?UserName=" & index & "',target='_self');</script>")
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธ์การแก้ไข')", True)
            End If
        End If
    End Sub
    '-----------------------------------------------------------------------Add User Method-------------------------------------------
    Private Sub editMoneyConfig()
        'Dim Code As String = Request.QueryString("Code")
        'If (String.IsNullOrEmpty(txtCode.Value)) Then
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน  LocationNo ก่อน !!!');", True)
        '    txtCode.Focus()
        'Else
        '    Using tran As New TransactionScope()
        '        Try
        '            db.Database.Connection.Open()

        '            Dim edit As tblMoneyConfig = (From c In db.tblMoneyConfigs Where c.Code = Code Select c).First()

        '            edit.Code = txtCode.Value.Trim
        '            edit.Amonut = txtAmount.Value.Trim
        '            edit.TotalAmonut = txtAmount.Value.Trim
        '            edit.Remark = txtRemark.Text.Trim
        '            edit.Status = dcbStatus.Text.Trim
        '            edit.UpdateBy = CStr(Session("UserName"))
        '            edit.UpdateDate = Now

        '            db.SaveChanges()
        '            tran.Complete()
        '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไข Code Config สำเร็จ !');", True)
        '            Response.Redirect("MasterMoneyConfig.aspx")
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

    'Private Sub SaveDATA_New()
    '    Try
    '        Dim user = (From u In db.tblMoneyConfigs Where u.Code = txtCode.Value
    '      Select u).FirstOrDefault

    '        If Not user Is Nothing Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Code ซ้ำ กรุณาเปลี่ยนใหม่');", True)
    '        Else
    '            EditMoneyConfig()
    '            Response.Write("<script>window.open('MasterMoneyConfig.aspx,target='_self');</script>")
    '        End If
    '    Catch ex As Exception
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด');", True)
    '    End Try
    'End Sub

    Protected Sub btnAdd_ServerClick1(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnGenScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ClassPermis.CheckSave("frmExchangeRate") = False Then Exit Sub

        Dim strFileNames() As String
        Dim strFileName As String
        Dim intCount As Integer
        Dim objStreamReader As StreamReader

        Dim strScript As String
        Dim objFileStream As FileStream
        Dim objStreamWriter As StreamWriter
        Try
            If String.IsNullOrEmpty(Me.txtDirectory.Value) Then

                Exit Sub
            End If

            strFileNames = Directory.GetFiles(Me.txtDirectory.Value)

            For Each strFileName In strFileNames

                objStreamReader = New StreamReader(strFileName)
                strScript = String.Empty
                intCount += 1

                While objStreamReader.Peek <> -1
                    strScript &= GenScript(objStreamReader.ReadLine)
                End While
                objStreamReader.Close()
                objStreamReader = Nothing

                tmpSQLScript = strScript

                objStreamWriter = Nothing
                objFileStream = Nothing

                'Me.ProgressBar.Value = (intCount * 100) / strFileNames.Length

            Next
            'SaveDATA_New()
            'ReadDATA()
            'MessageBox.Show("Exchange rate import is successfully ", "Done.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

        End Try
    End Sub
    Private Function GenScript(ByVal pStrData As String)
        Dim strCurrency As String
        Dim strStartDate As String
        Dim dateStart As Date
        Dim strEndDate As String
        Dim dateEnd As Date
        Dim dblBathAmount As Double
        Dim strTempText As String
        Dim strMount As String

        Dim strReturn As String
        Try

            strCurrency = pStrData.Substring(0, 3)
            strStartDate = pStrData.Substring(3, 8)
            strMount = pStrData.Substring(5, 2)
            dateStart = New Date(strStartDate.Substring(4), strStartDate.Substring(2, 2), strStartDate.Substring(0, 2))
            strEndDate = pStrData.Substring(11, 8)
            dateEnd = New Date(strEndDate.Substring(4), strEndDate.Substring(2, 2), strEndDate.Substring(0, 2))
            dblBathAmount = pStrData.Substring(19, 11)
            strTempText = pStrData.Substring(30)

            'strReturn = "INSERT INTO tblExchangeRate (Currency, StartDate, EndDate, ExchangeRate, BathAmount, TempText, Status, Mount)" & vbCrLf
            'strReturn &= "VALUES ('" & strCurrency & "', '" & dateStart.ToShortDateString & "', '" & dateEnd.ToShortDateString & "', 1," & dblBathAmount & ", '" & strTempText & "','" & tmpCheckInOrOut & "','" & strMount & "')" & vbCrLf

            db.tblExchangeRates.Add(New tblExchangeRate With {.Currency = strCurrency, _
                                                              .StartDate = dateStart.ToShortDateString, _
                                                              .EndDate = dateEnd.ToShortDateString, _
                                                              .ExchangeRate = "1", _
                                                              .BathAmount = dblBathAmount, _
                                                              .TempText = strTempText, _
                                                              .Status = dcbStatus.Text, _
                                                              .Mount = strMount
                                                             })
            db.SaveChanges()

            'Return strReturn
            Return True
        Catch ex As Exception
            'Return "/* """ & pStrData & """. It has something wrong. */" & vbCrLf
            Return False
        End Try
    End Function
End Class