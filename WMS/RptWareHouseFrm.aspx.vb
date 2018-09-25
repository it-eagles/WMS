Option Strict On
Option Explicit On
Option Infer On


Public Class RptWareHouseFrm
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            showSite()
            showPartyCode()
            txtdatepickerIssuedDate.Text = CStr(Now)
            txtdatepickerReceivedDate.Text = CStr(Now)
            txtdatepickerToIssuedDate.Text = CStr(Now)
            txtdatepickerToReceivedDate.Text = CStr(Now)
            txtdatepickerIssuedDate.Enabled = False
            txtdatepickerToIssuedDate.Enabled = False
            txtdatepickerReceivedDate.Enabled = False
            txtdatepickerToReceivedDate.Enabled = False
        End If
    End Sub
    '--------------------------------------------------------------------Show ddl Site----------------------------------------------------
    Private Sub showSite()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "SITE"
                  Select g.Type, g.Code
        Try
            ddlWHSite.DataSource = gg.ToList
            ddlWHSite.DataTextField = "Code"
            ddlWHSite.DataValueField = "Code"
            ddlWHSite.DataBind()

            If ddlWHSite.Items.Count > 1 Then
                ddlWHSite.Enabled = True
            Else
                ddlWHSite.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl Party Code----------------------------------------------------
    Private Sub showPartyCode()
        Dim gg = From g In db.tblParties
                  Select g.PartyCode, g.PartyFullName
        Try
            ddlCusCode.DataSource = gg.ToList
            ddlCusCode.DataTextField = "PartyCode"
            ddlCusCode.DataValueField = "PartyCode"
            ddlCusCode.DataBind()

            If ddlCusCode.Items.Count > 1 Then
                ddlCusCode.Enabled = True
            Else
                ddlCusCode.Enabled = False
            End If

            ddlToCusCode.DataSource = gg.ToList
            ddlToCusCode.DataTextField = "PartyCode"
            ddlToCusCode.DataValueField = "PartyCode"
            ddlToCusCode.DataBind()

            If ddlToCusCode.Items.Count > 1 Then
                ddlToCusCode.Enabled = True
            Else
                ddlToCusCode.Enabled = False
            End If

            ddlENDUserCode.DataSource = gg.ToList
            ddlENDUserCode.DataTextField = "PartyCode"
            ddlENDUserCode.DataValueField = "PartyCode"
            ddlENDUserCode.DataBind()

            If ddlENDUserCode.Items.Count > 1 Then
                ddlENDUserCode.Enabled = True
            Else
                ddlENDUserCode.Enabled = False
            End If

            ddlToENDUserCode.DataSource = gg.ToList
            ddlToENDUserCode.DataTextField = "PartyCode"
            ddlToENDUserCode.DataValueField = "PartyCode"
            ddlToENDUserCode.DataBind()

            If ddlToENDUserCode.Items.Count > 1 Then
                ddlToENDUserCode.Enabled = True
            Else
                ddlToENDUserCode.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnListData_ServerClick(sender As Object, e As EventArgs)

    End Sub
    'Private Sub ReadData()
    '    If ddlDocType.Text = "Unstuffing Tally Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHPrepairGoodsReceive WHERE LOTNo = '" & txtFromJobNo.Text & "' "

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Goods Receipt Note Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHConfirmGoodsReceive WHERE LOTNo = '" & txtFromJobNo.Text & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Putaway List Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHConfirmGoodsReceive WHERE LOTNo = '" & txtFromJobNo.Text & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Receipt Discrepancy Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHConfirmGoodsReceive WHERE LOTNo = '" & txtFromJobNo.Text & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Order Tally Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHPicking WHERE LOTNo = '" & txtFromJobNo.Text & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Issued Planned Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHISSUED WHERE ConfirmDate >= '" & dtpFromIssuedDate.Value & "' or ConfirmDate >= '" & dtpToIssuedDate.Value & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Receipt Planned Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHPrepairGoodsReceive "

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Pick List/Ticket Report for Pick" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHPicking WHERE LOTNo = '" & txtFromJobNo.Text & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Pick List/Ticket Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHPicking WHERE LOTNo = '" & txtFromJobNo.Text & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Picking Not Issued" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHPicking WHERE LOTNo = '" & txtFromJobNo.Text & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()


    '    ElseIf ddlDocType.Text = "Product Inventory Detail Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHConfirmGoodsReceive WHERE LOTNo = '" & txtFromJobNo.Text & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "WareHouse Activity Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHStockMovement WHERE TransactionDate >= '" & dtpFromIssuedDate.Value & "' or TransactionDate >= '" & dtpToIssuedDate.Value & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Delivery Summary Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHISSUED WHERE ConfirmDate >= '" & dtpFromIssuedDate.Value & "' or ConfirmDate >= '" & dtpToIssuedDate.Value & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Stock Out Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHPicking WHERE LOTNo = '" & txtFromJobNo.Text & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Receipt Summary Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHConfirmGoodsReceiveDetail WHERE ReceiveDate >= '" & dtpFromReceivedDate.Value & "' or ReceiveDate >= '" & dtpToReceivedDate.Value & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Stock Movement Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHStockMovement WHERE ProductCode = '" & txtFromPartNo.Text & "' AND TransactionDate >= '" & dtpFromReceivedDate.Value & "' or TransactionDate >= '" & dtpToReceivedDate.Value & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    ElseIf ddlDocType.Text = "Product Inventory Summary Report" Then

    '        Dim sqlCurrency As String
    '        sqlCurrency = "SELECT * FROM tblWHConfirmGoodsReceive WHERE OwnerCode = '" & dcbFromCusCode.Text & "'"

    '        Dim dr As SqlDataReader
    '        Dim dt As DataTable
    '        com = New SqlCommand()
    '        With com
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlCurrency
    '            .Connection = Conn
    '            dr = .ExecuteReader()
    '            If dr.HasRows Then
    '                dt = New DataTable()
    '                dt.Load(dr)
    '                dgvWHPrintReport.DataSource = dt
    '            Else
    '                dgvWHPrintReport.DataSource = Nothing
    '            End If
    '        End With
    '        dr.Close()

    '    End If
    'End Sub

    Protected Sub btnReport_ServerClick(sender As Object, e As EventArgs)
        PrintForm()
    End Sub
    Private Sub PrintForm()
        Dim CheckDocType As String = ddlDocType.Text.Trim
        Dim CheckWHStie As String = ddlWHSite.Text.Trim
        Dim CheckType As String = ddlTypeOfGoods.Text.Trim
        Dim CheckRecDate As String = ""
        Dim CheckIssueDate As String = ""
        Dim Jobno As String = txtJobno.Value.Trim
        Dim To_Jobno As String = txtJobno.Value.Trim
        Dim Partno As String = txtPartNo.Value.Trim
        Dim To_Partno As String = txtToPartNo.Value.Trim
        Dim Locationno As String = txtLocationNo.Value.Trim
        Dim To_Locationno As String = txtToLocationNo.Value.Trim
        Dim Cusrefno As String = txtCusRefNo.Value.Trim
        Dim To_Cusrefno As String = txtToCusRefNo.Value.Trim
        Dim Orderno As String = txtOrderNo.Value.Trim
        Dim WHsource As String = txtWHSource.Value.Trim

        Dim _cultureEnInfo As New Globalization.CultureInfo("en-US")
        Dim ReceivedDate As String = CStr(Convert.ToDateTime(Me.txtdatepickerReceivedDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))
        Dim To_ReceivedDate As String = CStr(Convert.ToDateTime(Me.txtdatepickerToReceivedDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))
        Dim IssuedDate As String = CStr(Convert.ToDateTime(Me.txtdatepickerIssuedDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))
        Dim To_IssuedDate As String = CStr(Convert.ToDateTime(Me.txtdatepickerToIssuedDate.Text, _cultureEnInfo).ToString("dd/MM/yyyy"))

        Dim Cuscode As String = ddlCusCode.Text.Trim
        Dim To_Cuscode As String = ddlToCusCode.Text.Trim
        Dim Endusercode As String = ddlENDUserCode.Text.Trim
        Dim To_Endusercode As String = ddlToENDUserCode.Text.Trim
        Dim Endcustomer As String = txtEndCustomer.Value.Trim
        Dim Checkallnjr As Integer

        If ddlDocType.Text = "Unstuffing Tally Report" Or ddlDocType.Text = "Goods Receipt Note Report" Or ddlDocType.Text = "Putaway List Report" _
        Or ddlDocType.Text = "Receipt Discrepancy Report" Or ddlDocType.Text = "Pick List/Ticket Report for Pick" Or ddlDocType.Text = "Pick List/Ticket Report" Then

            If txtJobno.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ JobNo ก่อน');", True)
                Exit Sub
            End If
            If txtToJobno.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To JobNo ก่อน');", True)
                Exit Sub
            End If
            If ddlTypeOfGoods.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Type ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Jobno") = Jobno
            Session("To_Jobno") = To_Jobno
            Session("CheckWHStie") = CheckWHStie
            Session("CheckType") = CheckType

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Order Tally Report" Or ddlDocType.Text = "Stock Out Report" Then

            If txtJobno.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ JobNo ก่อน');", True)
                Exit Sub
            End If
            If txtToJobno.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To JobNo ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Jobno") = Jobno
            Session("To_Jobno") = To_Jobno
            Session("CheckWHStie") = CheckWHStie

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Issued Planned Report" Then

            If txtdatepickerIssuedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Issued Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToIssuedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Issued Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("IssuedDate") = IssuedDate
            Session("To_IssuedDate") = To_IssuedDate
            Session("CheckWHStie") = CheckWHStie

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Receipt Planned Report" Then

            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Picking Not Issued" Then

            If txtJobno.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Job No ก่อน');", True)
                Exit Sub
            End If
            If txtToJobno.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Job No ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If ddlENDUserCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ END User Code ก่อน');", True)
                Exit Sub
            End If
            If ddlTypeOfGoods.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Type Of Good ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Jobno") = Jobno
            Session("To_Jobno") = To_Jobno
            Session("Partno") = Partno
            Session("Cuscode") = Cuscode
            Session("Endusercode") = Endusercode
            Session("CheckType") = CheckType
            Session("CheckWHStie") = CheckWHStie

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Product Inventory Detail Report" Or ddlDocType.Text = "Product Inventory Detail For Export Report" Then

            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtLocationNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Location No ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If

            If chkAllNJR.Checked = True Then
                Checkallnjr = 1
            Else
                Checkallnjr = 0
            End If

            Session("CheckDocType") = CheckDocType
            Session("Partno") = Partno
            Session("Cuscode") = Cuscode
            Session("Locationno") = Locationno
            Session("CheckWHStie") = CheckWHStie
            Session("Checkallnjr") = Checkallnjr

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "WareHouse Activity Report" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If ddlToCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("To_Cuscode") = To_Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Delivery Summary Report" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If ddlToCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerIssuedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Issued Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToIssuedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Issued Date ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtToPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Part No ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("To_Cuscode") = To_Cuscode
            Session("IssuedDate") = IssuedDate
            Session("To_IssuedDate") = To_IssuedDate
            Session("Partno") = Partno
            Session("To_Partno") = To_Partno
            Session("CheckWHStie") = CheckWHStie

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Receipt Summary Report" Then

            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            If chkAllNJR.Checked = True Then
                Checkallnjr = 1
            Else
                Checkallnjr = 0
            End If

            Session("CheckDocType") = CheckDocType
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie
            Session("Checkallnjr") = Checkallnjr

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Stock Movement Report" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtToPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Part No ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("Partno") = Partno
            Session("To_Partno") = To_Partno
            Session("CheckWHStie") = CheckWHStie

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Product Inventory Summary Report" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If ddlToCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtToPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Part No ก่อน');", True)
                Exit Sub
            End If
            If txtLocationNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Location No ก่อน');", True)
                Exit Sub
            End If
            If txtToLocationNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Location No ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("To_Cuscode") = To_Cuscode
            Session("Partno") = Partno
            Session("To_Partno") = To_Partno
            Session("Locationno") = Locationno
            Session("To_Locationno") = To_Locationno
            Session("CheckWHStie") = CheckWHStie

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "HTI Stock Report" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtWHSource.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Source ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If

            If chkReceivedDate.Checked = True Then
                CheckRecDate = "No"
            Else
                CheckRecDate = "Yes"
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("Partno") = Partno
            Session("WHsource") = WHsource
            Session("CheckWHStie") = CheckWHStie
            Session("CheckRecDate") = CheckRecDate

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Stock Report New" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtWHSource.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Source ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If ddlTypeOfGoods.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Type Of Good ก่อน');", True)
                Exit Sub
            End If

            If chkReceivedDate.Checked = True Then
                CheckRecDate = "No"
            Else
                CheckRecDate = "Yes"
            End If

            If chkAllNJR.Checked = True Then
                Checkallnjr = 1
            Else
                Checkallnjr = 0
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("Partno") = Partno
            Session("WHsource") = WHsource
            Session("Checkallnjr") = Checkallnjr
            Session("CheckType") = CheckType
            Session("CheckWHStie") = CheckWHStie
            Session("CheckRecDate") = CheckRecDate

        ElseIf ddlDocType.Text = "Summary Receipt" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtCusRefNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ CusRef No ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtOrderNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Order No ก่อน');", True)
                Exit Sub
            End If
            If txtEndCustomer.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ EndCustomer No ก่อน');", True)
                Exit Sub
            End If

            If chkAllNJR.Checked = True Then
                Checkallnjr = 1
            Else
                Checkallnjr = 0
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("Partno") = Partno
            Session("Cusrefno") = Cusrefno
            Session("Checkallnjr") = Checkallnjr
            Session("Orderno") = Orderno
            Session("Endcustomer") = Endcustomer
            Session("CheckWHStie") = CheckWHStie

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "General Stock Report" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtWHSource.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Source ก่อน');", True)
                Exit Sub
            End If
            If ddlTypeOfGoods.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Type Of Good ก่อน');", True)
                Exit Sub
            End If

            If chkReceivedDate.Checked = True Then
                CheckRecDate = "No"
            Else
                CheckRecDate = "Yes"
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie
            Session("Partno") = Partno
            Session("WHsource") = WHsource
            Session("CheckType") = CheckType
            Session("CheckRecDate") = CheckRecDate

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Check Summary Receipt" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtCusRefNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ CusRef No ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtOrderNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Order No ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie
            Session("Cusrefno") = Cusrefno
            Session("Partno") = Partno
            Session("Orderno") = Orderno


            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Summary Issue" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtCusRefNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ CusRef No ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtOrderNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Order No ก่อน');", True)
                Exit Sub
            End If
            If txtEndCustomer.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ EndCustomer No ก่อน');", True)
                Exit Sub
            End If

            If chkAllNJR.Checked = True Then
                Checkallnjr = 1
            Else
                Checkallnjr = 0
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie
            Session("Cusrefno") = Cusrefno
            Session("Partno") = Partno
            Session("Orderno") = Orderno
            Session("Endcustomer") = Endcustomer
            Session("Checkallnjr") = Checkallnjr

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Summary Unpicking Report" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtCusRefNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ CusRef No ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtOrderNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Order No ก่อน');", True)
                Exit Sub
            End If

            If chkAllNJR.Checked = True Then
                Checkallnjr = 1
            Else
                Checkallnjr = 0
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie
            Session("Cusrefno") = Cusrefno
            Session("Partno") = Partno
            Session("Orderno") = Orderno
            Session("Checkallnjr") = Checkallnjr

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "HTI Quarantine Stock Control" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtOrderNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Order No ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie
            Session("Partno") = Partno
            Session("Orderno") = Orderno

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Check HTI Quarantine Stock Control" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtOrderNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Order No ก่อน');", True)
                Exit Sub
            End If
            If ddlTypeOfGoods.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Type Of Good ก่อน');", True)
                Exit Sub
            End If

            If chkReceivedDate.Checked = True Then
                CheckRecDate = "No"
            Else
                CheckRecDate = "Yes"
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie
            Session("Partno") = Partno
            Session("Orderno") = Orderno
            Session("CheckType") = CheckType
            Session("CheckRecDate") = CheckRecDate

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Summary Job Receipt From LKB" Then

            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Summary Job Issued From LKB" Then

            If txtdatepickerIssuedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Issued Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToIssuedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Issued Date ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("IssuedDate") = IssuedDate
            Session("To_IssuedDate") = To_IssuedDate

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "HTI Stock Take" Then

            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtToLocationNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Location No ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("CheckWHStie") = CheckWHStie
            Session("Partno") = Partno
            Session("Locationno") = Locationno

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Other Summary Receipt" Or ddlDocType.Text = "Other Summary Issue" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtCusRefNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ CusRef No ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtOrderNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Order No ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie
            Session("Cusrefno") = Cusrefno
            Session("Partno") = Partno
            Session("Orderno") = Orderno

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)

        ElseIf ddlDocType.Text = "Other Quarantine Stock Control" Then

            If ddlCusCode.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Cus Code ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Received Date ก่อน');", True)
                Exit Sub
            End If
            If txtdatepickerToReceivedDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ To Received Date ก่อน');", True)
                Exit Sub
            End If
            If ddlWHSite.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ WH Site ก่อน');", True)
                Exit Sub
            End If
            If txtPartNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Part No ก่อน');", True)
                Exit Sub
            End If
            If txtOrderNo.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ Order No ก่อน');", True)
                Exit Sub
            End If

            Session("CheckDocType") = CheckDocType
            Session("Cuscode") = Cuscode
            Session("ReceivedDate") = ReceivedDate
            Session("To_ReceivedDate") = To_ReceivedDate
            Session("CheckWHStie") = CheckWHStie
            Session("Partno") = Partno
            Session("Orderno") = Orderno

            Dim url As String = "ShowReport/ShowRptWareHouse.aspx?Jonno=" + Jobno + "&WHSite=" + CheckWHStie
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "onclick", "javascript:window.open( '" + url + "','_blank','height=600px,width=1000px,scrollbars=1');", True)



        End If
    End Sub
End Class