Option Explicit On
Option Strict On

Imports System.Transactions
Imports System.Globalization
Public Class RejectIssuedWH
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmDeleteIssued"
        If Not Me.IsPostBack Then
            If classPermis.CheckRead(form, usename) = True Then
                If Not IsPostBack Then
                    showSite_ConfirmIssue()
                    showLocation()
                    showSoucreWHFac()
                    showunitdimension()
                    showunitdimension()
                    showunit2()

                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
                'Response.Redirect("HomeMain.aspx")
            End If
        End If
    End Sub

    Protected Sub btnFind_ServerClick(sender As Object, e As EventArgs)
        DataPickingDetail()
        DataIssuedDetail()
    End Sub
    '--------------------------------------------------------------------Show ddl Site----------------------------------------------------
    Private Sub showSite_ConfirmIssue()
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
    '--------------------------------------------------------------------Show ddl Location----------------------------------------------------
    Private Sub showLocation()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "LOCATION"
                  Select g.Type, g.Code
        Try
            ddlWHLocation.DataSource = gg.ToList
            ddlWHLocation.DataTextField = "Code"
            ddlWHLocation.DataValueField = "Code"
            ddlWHLocation.DataBind()

            If ddlWHLocation.Items.Count > 1 Then
                ddlWHLocation.Enabled = True
            Else
                ddlWHLocation.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------------------------------------------Show ddl SOURCE-WH-FAC----------------------------------------------------
    Private Sub showSoucreWHFac()
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "SOURCE-WH-FAC"
                  Select g.Type, g.Code
        Try
            ddlCustWHFac.DataSource = gg.ToList
            ddlCustWHFac.DataTextField = "Code"
            ddlCustWHFac.DataValueField = "Code"
            ddlCustWHFac.DataBind()

            If ddlCustWHFac.Items.Count > 1 Then
                ddlCustWHFac.Enabled = True
            Else
                ddlCustWHFac.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------------Show ddl Unit CM INC-------------------------------------------------------
    Private Sub showunitdimension()
        Dim gg = From g In db.tblMasterCodes Where g.Code = "CM" Or g.Code = "INC"
                  Select g.Type, g.Code
        Try
            ddlMeasurement.DataSource = gg.ToList
            ddlMeasurement.DataTextField = "Code"
            ddlMeasurement.DataValueField = "Code"
            ddlMeasurement.DataBind()
            If ddlMeasurement.Items.Count > 1 Then
                ddlMeasurement.Enabled = True
            Else
                ddlMeasurement.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '----------------------------------------------------------------Show ddl Unit2-------------------------------------------------------
    Private Sub showunit2()
        Dim gg = From g In db.tblMasterCodes Where g.Type = "UNIT"
                  Select g.Type, g.Code
        Try
            ddlQuantity.DataSource = gg.ToList
            ddlQuantity.DataTextField = "Code"
            ddlQuantity.DataValueField = "Code"
            ddlQuantity.DataBind()

            If ddlQuantity.Items.Count > 1 Then
                ddlQuantity.Enabled = True
            Else
                ddlQuantity.Enabled = False
            End If

            ddlWeight2.DataSource = gg.ToList
            ddlWeight2.DataTextField = "Code"
            ddlWeight2.DataValueField = "Code"
            ddlWeight2.DataBind()

            If ddlWeight2.Items.Count > 1 Then
                ddlWeight2.Enabled = True
            Else
                ddlWeight2.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    '--------------------------------------------------------Show Data Picking Detail In Modal-----------------------------------------
    Private Sub DataPickingDetail()
        Dim testdate As Integer
        Dim jobno_code As String = ""
        Dim pullsignal_code As String = ""
        Dim status_ As String = ""
        If String.IsNullOrEmpty(txtJobNo.Value.Trim) And String.IsNullOrEmpty(txtPullSignal.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            status_ = "0"
        Else
            jobno_code = txtJobNo.Value.Trim
            pullsignal_code = txtPullSignal.Value.Trim
        End If

        Dim cons = (From p In db.tblWHPickingDetails
                    Where (p.LOTNo.Contains(jobno_code) And p.PullSignal.Contains(pullsignal_code) And p.StatusISSUED = "0") Or p.StatusISSUED = status_
                   Select New With {p.PullSignal,
                                    p.LOTNo,
                                    p.ItemNo,
                                    p.WHSite,
                                    p.ENDCustomer,
                                    p.CustomerLOTNo,
                                    p.ProductCode}).ToList()

        If cons.Count > 0 Then
            Repeater8.DataSource = cons.ToList
            Repeater8.DataBind()
        Else
            Repeater8.DataSource = Nothing
            Repeater8.DataBind()
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------Click Data Data Job Detail In Modal Edit In Modal-----------------------------------------
    Protected Sub Repeater8_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim lblPullSignal As Label = CType(e.Item.FindControl("lblPullSignal"), Label)
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblItemNo As Label = CType(e.Item.FindControl("lblItemNo"), Label)
            Dim lblWHSite As Label = CType(e.Item.FindControl("lblWHSite"), Label)
            Dim lblENDCustomer As Label = CType(e.Item.FindControl("lblENDCustomer"), Label)
            Dim lblCustomerLOTNo As Label = CType(e.Item.FindControl("lblCustomerLOTNo"), Label)
            Dim lblProductCode As Label = CType(e.Item.FindControl("lblProductCode"), Label)


            If Not IsNothing(lblPullSignal) Then
                lblPullSignal.Text = DataBinder.Eval(e.Item.DataItem, "PullSignal").ToString
            End If
            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString
            End If
            If Not IsNothing(lblItemNo) Then
                lblItemNo.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString
            End If
            If Not IsNothing(lblWHSite) Then
                lblWHSite.Text = DataBinder.Eval(e.Item.DataItem, "WHSite").ToString
            End If
            If Not IsNothing(lblENDCustomer) Then
                lblENDCustomer.Text = DataBinder.Eval(e.Item.DataItem, "ENDCustomer").ToString
            End If
            If Not IsNothing(lblCustomerLOTNo) Then
                lblCustomerLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLOTNo").ToString
            End If

            If Not IsNothing(lblProductCode) Then
                lblProductCode.Text = DataBinder.Eval(e.Item.DataItem, "ProductCode").ToString
            End If

        End If
    End Sub

    '--------------------------------------------------------Show Data Job Detail In Modal-----------------------------------------
    Private Sub DataIssuedDetail()
        Dim testdate As Integer
        Dim jobno_code As String = ""
        Dim pullsignal_code As String = ""
        Dim status_ As Double
        If String.IsNullOrEmpty(txtJobNo.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
            status_ = 0
        Else
            jobno_code = txtJobNo.Value.Trim
            pullsignal_code = txtPullSignal.Value.Trim
        End If

        Dim cons = (From p In db.tblWHISSUEDDetails
                    Where p.LOTNo.Contains(jobno_code) And p.PullSignal.Contains(pullsignal_code)
                   Select New With {p.PullSignal,
                                    p.LOTNo,
                                    p.ItemNo,
                                    p.WHSite,
                                    p.WHLocation,
                                    p.ENDCustomer,
                                    p.CustomerLOTNo}).ToList()

        If cons.Count > 0 Then
            Repeater9.DataSource = cons.ToList
            Repeater9.DataBind()
        Else
            Repeater9.DataSource = Nothing
            Repeater9.DataBind()
            Exit Sub

        End If
    End Sub

    Protected Sub chk_Pull_CheckedChanged(sender As Object, e As EventArgs)
        selectEdit()
    End Sub
    Protected Sub chkAll_CheckedChanged(sender As Object, e As EventArgs)
        selectEdit()
    End Sub
    Private Sub selectEdit()
        Dim chkName As CheckBox
        Dim lblPullSignal As String
        Dim lblLOTNo As String
        Dim lblItemNo As Integer
        Dim i As Integer

        For i = 0 To Repeater9.Items.Count - 1

            chkName = CType(Repeater9.Items(i).FindControl("chk_Pull"), CheckBox)
            lblItemNo = CInt(CType(Repeater9.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
            lblPullSignal = CType(Repeater9.Items(i).FindControl("lblPullSignal"), Label).Text.Trim
            lblLOTNo = CType(Repeater9.Items(i).FindControl("lblLOTNo"), Label).Text.Trim

            If chkName.Checked = True Then
                Dim u = (From us In db.tblWHISSUEDDetails Where us.PullSignal = lblPullSignal And us.LOTNo = lblLOTNo And us.ItemNo = lblItemNo
                  Select us).FirstOrDefault

                txtJobNo.Value = u.LOTNo
                txtPullSignal.Value = u.PullSignal
                'If Not IsNothing(u) Then
                If String.IsNullOrEmpty(u.WHSite) Then
                    'ddlWHSite.Text = ""
                Else
                    ddlWHSite.Text = u.WHSite
                End If

                If String.IsNullOrEmpty(u.WHLocation) Then
                    'ddlWHLocation.Text = ""
                Else
                    ddlWHLocation.Text = u.WHLocation
                End If

                txtENDCustomer.Value = u.ENDCustomer
                txtCusLOTNo.Value = u.CustomerLOTNo
                'ddlCustWHFac_ConfirmIssue.Text 
                txtItemNo.Value = CStr(u.ItemNo)
                txtEASPN.Value = u.ProductCode
                txtCustomerPN.Value = u.CustomerPN
                txtOwnerPN.Value = u.OwnerPN
                txtRemark.Value = u.ProductDesc
                If u.Measurement Is Nothing Then
                    ddlMeasurement.Text = u.Measurement
                End If
                txtWidth.Value = CStr(u.ProductWidth)
                txtHight.Value = CStr(u.ProductHeight)
                txtLength.Value = CStr(u.ProductLength)
                txtProductVolume.Value = CStr(u.ProductVolume)
                txtPalletNo.Value = u.PalletNo
                txtOrderNo.Value = u.OrderNo
                txtReceiveNo.Value = u.ReceiveNo
                ddlStatus.Text = u.Type
                'ddlType_ConfirmIssue.Text
                If u.ManufacturingDate Is Nothing Then
                    txtdatepickerManufacturing.Text = Nothing
                    txtdatepickerManufacturing.Enabled = False
                Else
                    txtdatepickerManufacturing.Text = CStr(u.ManufacturingDate)
                    txtdatepickerManufacturing.Enabled = True
                End If
                If u.ExpiredDate Is Nothing Then
                    txtdatepickerExpiredDate.Text = Nothing
                    txtdatepickerExpiredDate.Enabled = False
                Else
                    txtdatepickerExpiredDate.Text = CStr(u.ExpiredDate)
                    txtdatepickerExpiredDate.Enabled = True
                End If
                'txtdatepickerManufacturing.Text = Convert.ToDateTime(u.ManufacturingDate).ToString("dd/MM/yyyy")
                'txtdatepickerExpiredDate.Text = Convert.ToDateTime(u.ExpiredDate).ToString("dd/MM/yyyy")
                txtdatepickerReceiveDate.Text = Convert.ToDateTime(u.ReceiveDate).ToString("dd/MM/yyyy")
                If String.IsNullOrEmpty(txtdatepickerManufacturing.Text) Then
                    chkNotUseDate.Checked = True
                Else
                    chkNotUseDate.Checked = False
                End If
                txtQuantity.Value = CStr(u.ISSUEDQuantity)
                If u.ISSUEDUnit Is Nothing Then
                    ddlQuantity.Text = u.ISSUEDUnit
                End If
                txtWeight2.Value = CStr(u.Weigth)
                If u.WeigthUnit Is Nothing Then
                    ddlWeight2.Text = u.WeigthUnit
                End If
            End If
        Next
    End Sub

    Protected Sub btnDelete_ServerClick(sender As Object, e As EventArgs)

        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmDeleteIssued"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Delete_ = 1
        If cu.Any Then

            SaveIssuedDetail_Delete()
            DataPickingDetail()
            DataIssuedDetail()

        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    Private Sub SaveIssuedDetail_Delete()
        Dim chkName As CheckBox
        Dim lblItemNo As Double
        Dim lblLOTNo As String
        Dim lblPullSignal As String

        If txtPullSignal.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(กรุณาป้อน Pull Signal ก่อน !!!);", True)
            Exit Sub
        End If

        If txtJobNo.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(กรุณาป้อน Job No ก่อน !!!);", True)
            Exit Sub
        End If

        If txtItemNo.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(กรุณาป้อน ItemNo ก่อน !!!);", True)
            Exit Sub
        End If

        Using tran As New TransactionScope()


            Dim i As Integer

            For i = 0 To Repeater9.Items.Count - 1


                chkName = CType(Repeater9.Items(i).FindControl("chk_Pull"), CheckBox)
                lblItemNo = CDbl(CType(Repeater9.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
                lblPullSignal = CType(Repeater9.Items(i).FindControl("lblPullSignal"), Label).Text.Trim
                lblLOTNo = CType(Repeater9.Items(i).FindControl("lblLOTNo"), Label).Text.Trim

                Dim u = (From us In db.tblWHISSUEDDetails Where us.ItemNo = lblItemNo And us.LOTNo = lblLOTNo And us.PullSignal = lblPullSignal).FirstOrDefault

                If chkName.Checked = True Then

                    Try
                        If u.StatusISSUED = "2" Then
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รายการที่คุณเลือก" & u.LOTNo & " ItemNo: " & u.ItemNo & "ได้ถูกส่งออกไปจากคลังสินค้าแล้วคุณไม่สามารถยกเลิกรายการนี้ได้ !!!');", True)
                            Exit Try
                        Else
                            Dim Delete As tblWHISSUEDDetail = (From de In db.tblWHISSUEDDetails Where de.PullSignal = u.PullSignal And de.LOTNo = u.LOTNo And de.ItemNo = u.ItemNo _
                                                                And de.ReceiveNo = u.ReceiveNo And de.Item = u.Item And de.Type = u.Type And de.ISSUEDQuantity = u.ISSUEDQuantity Select de).First()

                            'db.tblWHISSUEDDetails.Remove(Delete)

                            'If SaveModifyPick(i) = False Then
                            '    tran.Dispose()
                            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(เกิดข้อผิดพลาด เนื่องจาก SaveModifyPick);", True)
                            '    Exit Sub
                            'End If

                            'If SaveDeleteStockMovement_Confirm(i) = False Then
                            '    tran.Dispose()
                            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(เกิดข้อผิดพลาด เนื่องจาก Delete tblWHStockMovement);", True)
                            '    Exit Sub
                            'End If

                            'db.SaveChanges()
                        End If
                    Catch ex As Exception
                        tran.Dispose()
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด เนื่องจาก ผลการทำงาน');", True)
                        Exit Sub
                    End Try
                End If
            Next
            tran.Complete()
        End Using
    End Sub
    Private Function SaveModifyPick(ByVal i As Integer) As Boolean
        Dim lblItemNo As Double
        Dim lblLOTNo As String
        Dim lblPullSignal As String

        lblItemNo = CDbl(CType(Repeater9.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
        lblPullSignal = CType(Repeater9.Items(i).FindControl("lblPullSignal"), Label).Text.Trim
        lblLOTNo = CType(Repeater9.Items(i).FindControl("lblLOTNo"), Label).Text.Trim
        'sb.Append("UPDATE tblWHPickingDetail")
        'sb.Append(" SET StatusISSUED=@StatusISSUED")
        'sb.Append(" WHERE (PullSignal=@PullSignal AND LOTNo=@LOTNo AND ItemNo=@ItemNo AND ReceiveNo=@ReceiveNo AND Item=@Item)")
        Try
            Dim u = (From us In db.tblWHISSUEDDetails Where us.ItemNo = lblItemNo And us.LOTNo = lblLOTNo And us.PullSignal = lblPullSignal).FirstOrDefault

            db.Database.Connection.Open()
            Dim edit As tblWHPickingDetail = (From c In db.tblWHPickingDetails Where c.ItemNo = lblItemNo And c.LOTNo = lblLOTNo And c.PullSignal = lblPullSignal
              Select c).First()
            If edit IsNot Nothing Then
                'edit.PullSignal = txtPullSignal.Value.Trim
                'edit.LOTNo = txtJobNo.Value.Trim
                'edit.ItemNo = u.ItemNo
                'edit.ReceiveNo = u.ReceiveNo
                edit.StatusISSUED = "0"
                'edit.Item = u.Item
                db.SaveChanges()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function SaveDeleteStockMovement_Confirm(ByVal i As Integer) As Boolean
        Dim lblItemNo As Double
        Dim lblLOTNo As String
        Dim lblPullSignal As String

        lblItemNo = CDbl(CType(Repeater9.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
        lblPullSignal = CType(Repeater9.Items(i).FindControl("lblPullSignal"), Label).Text.Trim
        lblLOTNo = CType(Repeater9.Items(i).FindControl("lblLOTNo"), Label).Text.Trim


        'sb.Append("Delete tblWHStockMovement")
        'sb.Append(" WHERE (LOTNo=@LOTNo and ItemNo=@ItemNo and Item=@Item and ISSUEQuantity=@ISSUEQuantity and Type=@Type)")
        Try
            Dim u = (From us In db.tblWHISSUEDDetails Where us.ItemNo = lblItemNo And us.LOTNo = lblLOTNo And us.PullSignal = lblPullSignal).FirstOrDefault

            Dim DeleteStockMovement As tblWHStockMovement = (From c In db.tblWHStockMovements Where c.LOTNo = u.LOTNo And c.ItemNo = u.ItemNo And c.item = u.Item _
                                                             And c.ISSUEQuantity = u.ISSUEDQuantity And c.Type = u.Type Select c).First()

            db.tblWHStockMovements.Remove(DeleteStockMovement)
            db.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Private Sub CheckStatus()
    '    Dim chkName As CheckBox
    '    Dim i As Integer
    '    Dim lblItemNo As Double
    '    Dim lblLOTNo As String
    '    Dim lblPullSignal As String
    '    Dim n(10) As Integer
    '    Dim n2(10) As String

    '    For i = 0 To Repeater9.Items.Count - 1

    '        chkName = CType(Repeater9.Items(i).FindControl("chk_Pull"), CheckBox)
    '        lblItemNo = CDbl(CType(Repeater9.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
    '        lblPullSignal = CType(Repeater9.Items(i).FindControl("lblPullSignal"), Label).Text.Trim
    '        lblLOTNo = CType(Repeater9.Items(i).FindControl("lblLOTNo"), Label).Text.Trim
    '        Dim u = (From us In db.tblWHISSUEDDetails Where us.ItemNo = lblItemNo And us.LOTNo = lblLOTNo And us.PullSignal = lblPullSignal).FirstOrDefault

    '        If chkName.Checked = True Then
    '            Try
    '                If u.StatusISSUED = "2" Then
    '                    n(i) = CInt(u.ItemNo)
    '                    n2(i) = u.LOTNo
    '                    Console.WriteLine("รายการที่คุณเลือก {0} และ ItemNo: {1} ได้ถูกส่งออกไปจากคลังสินค้าแล้วคุณไม่สามารถยกเลิกรายการนี้ได้", n2, n)
    '                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รายการที่คุณเลือก  {0}   ItemNo:  {1}  ได้ถูกส่งออกไปจากคลังสินค้าแล้วคุณไม่สามารถยกเลิกรายการนี้ได้ !!!', n2, n);", True)
    '                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รายการที่คุณเลือก" & u.LOTNo & " ItemNo: " & u.ItemNo & "ได้ถูกส่งออกไปจากคลังสินค้าแล้วคุณไม่สามารถยกเลิกรายการนี้ได้ !!!');", True)
    '                    Exit Try
    '                Else
    '                    SaveIssuedDetail_Delete()
    '                End If
    '            Catch ex As Exception

    '            End Try
    '        End If
    '    Next
    'End Sub

    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("RejectIssuedWH.aspx")
    End Sub
End Class