Public Class RptLogFrm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtdatepickerDate.Text = Now
        txtdatepickerToDate.Text = Now
    End Sub

    Protected Sub btnPrint_ServerClick(sender As Object, e As EventArgs)
        Dim CheckLog As String = ddlSelectImEx.Text.Trim
        Dim CheckBy As String = ""
        Dim InvoiceNo As String = txtInvoiceNo.Value.Trim
        Dim _cultureEnInfo As New Globalization.CultureInfo("en-US")
        Dim formdate As String = CStr(Convert.ToDateTime(Me.txtdatepickerDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))
        Dim toDate As String = CStr(Convert.ToDateTime(Me.txtdatepickerToDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))

        If ddlSelectImEx.Text.Trim = "LogInvoice" Or ddlSelectImEx.Text.Trim = "LogInvoiceDetail" Or ddlSelectImEx.Text.Trim = "LogPackingList" _
            Or ddlSelectImEx.Text.Trim = "LogImpInvoice" Or ddlSelectImEx.Text.Trim = "LogImpInvoiceDetail" Or ddlSelectImEx.Text.Trim = "LogImpPackingList" Then
            If rdbByDate.Checked = True Then
                If String.IsNullOrEmpty(txtdatepickerDate.Text.Trim) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Date Start ก่อน');", True)
                    Exit Sub
                End If
                If String.IsNullOrEmpty(txtdatepickerToDate.Text.Trim) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Date From ก่อน');", True)
                    Exit Sub
                End If

                CheckBy = "ByDate"

                Session("CheckLog") = CheckLog
                Session("CheckBy") = CheckBy
                Session("formdate") = formdate
                Session("toDate") = toDate
                'Session("InvoiceNo") = InvoiceNo

                Dim url As String = "ShowReport/ShowRptLog.aspx?Fromdate=" + formdate + "&Todate=" + toDate
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

            ElseIf rdbByInvoice.Checked = True Then
                If txtInvoiceNo.Value.Trim = "" Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Invoice No ก่อน');", True)
                    Exit Sub
                End If
                CheckBy = "ByInv"

                Session("CheckLog") = CheckLog
                Session("CheckBy") = CheckBy
                'Session("formdate") = formdate
                'Session("toDate") = toDate
                Session("InvoiceNo") = InvoiceNo

                Dim url As String = "ShowReport/ShowRptLog.aspx?InvNo=" + InvoiceNo
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)
            End If

        ElseIf ddlSelectImEx.Text.Trim = "LogBrand" Or ddlSelectImEx.Text.Trim = "LogCarLicense" Or ddlSelectImEx.Text.Trim = "LogCountry" Or ddlSelectImEx.Text.Trim = "LogConsignnee" _
            Or ddlSelectImEx.Text.Trim = "LogCurrency" Or ddlSelectImEx.Text.Trim = "LogDeliveryTerm" Or ddlSelectImEx.Text.Trim = "LogDriver" Or ddlSelectImEx.Text.Trim = "LogExpGenLOT" _
            Or ddlSelectImEx.Text.Trim = "LogImpGenLOT" Or ddlSelectImEx.Text.Trim = "LogProductDetail" Or ddlSelectImEx.Text.Trim = "LogProductUnit" _
            Or ddlSelectImEx.Text.Trim = "LogProvince" Or ddlSelectImEx.Text.Trim = "LogReferenceType" Or ddlSelectImEx.Text.Trim = "LogShipper" _
            Or ddlSelectImEx.Text.Trim = "LogShippingMark" Or ddlSelectImEx.Text.Trim = "LogtransprotationMode" Or ddlSelectImEx.Text.Trim = "LogTruckWayBill" _
            Or ddlSelectImEx.Text.Trim = "LogTruckWayBillDetail" Or ddlSelectImEx.Text.Trim = "LogWarehouseType" Or ddlSelectImEx.Text.Trim = "LogUser" _
            Or ddlSelectImEx.Text.Trim = "LogTruckManifest" Or ddlSelectImEx.Text.Trim = "LogTruckManifestDetail" Or ddlSelectImEx.Text.Trim = "LogTruckOwner" _
            Or ddlSelectImEx.Text.Trim = "LogTruckType" Then

            If rdbByDate.Checked = True Then
                If String.IsNullOrEmpty(txtdatepickerDate.Text.Trim) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Date Start ก่อน');", True)
                    Exit Sub
                End If
                If String.IsNullOrEmpty(txtdatepickerToDate.Text.Trim) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Date From ก่อน');", True)
                    Exit Sub
                End If

                CheckBy = "ByDate"

                Session("CheckLog") = CheckLog
                Session("CheckBy") = CheckBy
                Session("formdate") = formdate
                Session("toDate") = toDate
                'Session("InvoiceNo") = InvoiceNo

                Dim url As String = "ShowReport/ShowRptLog.aspx?Fromdate=" + formdate + "&Todate=" + toDate
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

            ElseIf rdbByInvoice.Checked = True Then

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Invoice No ก่อน');", True)
                Exit Sub
               
            End If

        End If

    End Sub

    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)
        Clear()
    End Sub
    Private Sub Clear()
        txtdatepickerDate.Text = ""
        txtdatepickerToDate.Text = ""
        txtInvoiceNo.Value = ""
    End Sub
End Class