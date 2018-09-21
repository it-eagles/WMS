Public Class RptIEAT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnPrint_ServerClick(sender As Object, e As EventArgs)
        Dim CheckImEx As String = ddlSelectImEx.Text.Trim
        Dim CheckBy As String = ""
        If rdbByDate.Checked = True Then
            If String.IsNullOrEmpty(txtdatepickerDate.Text.Trim) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Date Start ก่อน');", True)
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtdatepickerToDate.Text.Trim) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Date From ก่อน');", True)
                Exit Sub
            End If

            Dim _cultureEnInfo As New Globalization.CultureInfo("en-US")
            Dim formdate As String = CStr(Convert.ToDateTime(Me.txtdatepickerDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))
            Dim toDate As String = CStr(Convert.ToDateTime(Me.txtdatepickerToDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))
            CheckBy = "Bydate"

            Session("CheckBy") = CheckBy
            Session("CheckImEx") = CheckImEx
            Session("formdate") = formdate
            Session("toDate") = toDate
            Dim url As String = "ShowReport/ShowRptIEAT.aspx?Fromdate=" + formdate + "&Todate=" + toDate
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)
        ElseIf rdbByIEATNo.Checked = True Then
            If txtIEATNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ IEATNo ก่อน');", True)
                Exit Sub
            End If
            CheckBy = "ByIEATNo"

            Session("CheckBy") = CheckBy
            Session("CheckImEx") = CheckImEx
            Dim ieatno As String = txtIEATNo.Value.Trim

            Dim url As String = "ShowReport/ShowRptIEAT.aspx?IEATNo=" + ieatno
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)
        ElseIf rdbByIEATPermit.Checked = True Then
            If txtIEATPermit.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ IEATPermit ก่อน');", True)
                Exit Sub
            End If
            CheckBy = "ByIEATPermit"

            Session("CheckBy") = CheckBy
            Session("CheckImEx") = CheckImEx
            Dim ieatpermit As String = txtIEATPermit.Value.Trim

            Dim url As String = "ShowReport/ShowRptIEAT.aspx?IEATPermit=" + ieatpermit
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)
        End If
    End Sub

    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)
        Clear()
    End Sub
    Private Sub Clear()
        txtdatepickerDate.Text = ""
        txtdatepickerToDate.Text = ""
        txtIEATNo.Value = ""
        txtIEATPermit.Value = ""
    End Sub
End Class