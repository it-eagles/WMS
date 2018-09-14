Option Explicit On
Option Infer On
Option Strict On

Imports System.Transactions
Imports System.Globalization
Public Class RejectReceivedWH
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmDeteleConfirm"
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
        'Dim testdate As Integer
        'Dim jobno_code As String = ""
        'Dim status_ As Integer
        'If String.IsNullOrEmpty(txtJobNo.Value.Trim) And String.IsNullOrEmpty(txtPullSignal.Value.Trim) Then
        '    testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        '    status_ = 1
        'Else
        '    jobno_code = txtJobNo.Value.Trim
        'End If

        'Where (p.LOTNo.Contains(jobno_code) And p.Status <> 1) Or (p.Status <> status_ And p.LastUpdate.Year = testdate) Order By p.ItemNo Ascending
        Dim cons = (From p In db.tblWHPrepairGoodsReceiveDetails
                    Where (p.LOTNo = txtJobNo.Value.Trim And p.Status <> 1) Order By p.ItemNo Ascending
                   Select New With {p.LOTNo,
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

            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblItemNo As Label = CType(e.Item.FindControl("lblItemNo"), Label)
            Dim lblWHSite As Label = CType(e.Item.FindControl("lblWHSite"), Label)
            Dim lblENDCustomer As Label = CType(e.Item.FindControl("lblENDCustomer"), Label)
            Dim lblCustomerLOTNo As Label = CType(e.Item.FindControl("lblCustomerLOTNo"), Label)
            Dim lblProductCode As Label = CType(e.Item.FindControl("lblProductCode"), Label)


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
        'Dim testdate As Integer
        'Dim jobno_code As String = ""
        'Dim status_ As Double
        'If String.IsNullOrEmpty(txtJobNo.Value.Trim) Then
        '    testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        '    status_ = 0
        'Else
        '    jobno_code = txtJobNo.Value.Trim
        'End If

        Dim cons = (From p In db.tblWHConfirmGoodsReceiveDetails
                    Where p.LOTNo = txtJobNo.Value.Trim Order By p.ItemNo Ascending
                   Select New With {p.LOTNo,
                                    p.ItemNo,
                                    p.WHSite,
                                    p.WHLocation,
                                    p.ReceiveNo,
                                    p.Quantity}).ToList()

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
        Dim lblLOTNo As String
        Dim lblItemNo As Double
        Dim i As Integer

        For i = 0 To Repeater9.Items.Count - 1

            chkName = CType(Repeater9.Items(i).FindControl("chk_Pull"), CheckBox)
            lblItemNo = CDbl(CType(Repeater9.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
            lblLOTNo = CType(Repeater9.Items(i).FindControl("lblLOTNo"), Label).Text.Trim

            If chkName.Checked = True Then
                Dim u = (From us In db.tblWHConfirmGoodsReceiveDetails Where us.LOTNo = lblLOTNo And us.ItemNo = lblItemNo
                  Select us).FirstOrDefault

                txtJobNo.Value = u.LOTNo
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
                txtdatepickerETAARRDate.Text = Convert.ToDateTime(u.ExpectedDate).ToString("dd/MM/yyyy")
                txtQuantity.Value = CStr(u.Quantity)
                If u.QuantityUnit Is Nothing Then
                    ddlQuantity.Text = u.QuantityUnit
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
        Dim form As String = "frmDeteleConfirm"
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
                lblLOTNo = CType(Repeater9.Items(i).FindControl("lblLOTNo"), Label).Text.Trim

                Dim cur = (From us In db.tblWHConfirmGoodsReceiveDetails Where us.LOTNo = lblLOTNo And us.ItemNo = lblItemNo
                  Select us).FirstOrDefault

                If chkName.Checked = True Then

                    Try

                        Dim Delete As tblWHConfirmGoodsReceiveDetail = (From de In db.tblWHConfirmGoodsReceiveDetails Where de.LOTNo = cur.LOTNo And de.ItemNo = cur.ItemNo And de.Item = cur.Item Select de).First()

                        db.tblWHConfirmGoodsReceiveDetails.Remove(Delete)

                        If SaveModifyPrepair(i) = False Then
                            tran.Dispose()
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(เกิดข้อผิดพลาด เนื่องจาก SaveModifyPick);", True)
                            Exit Sub
                        End If

                        If SaveDeleteStockMovement_Confirm(i) = False Then
                            tran.Dispose()
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(เกิดข้อผิดพลาด เนื่องจาก Delete tblWHStockMovement);", True)
                            Exit Sub
                        End If

                        db.SaveChanges()
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
    Private Function SaveModifyPrepair(ByVal i As Integer) As Boolean

        Dim lblItemNo As Double
        Dim lblLOTNo As String

        lblItemNo = CDbl(CType(Repeater9.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
        lblLOTNo = CType(Repeater9.Items(i).FindControl("lblLOTNo"), Label).Text.Trim

        Try
            Dim u = (From us In db.tblWHConfirmGoodsReceiveDetails Where us.LOTNo = lblLOTNo And us.ItemNo = lblItemNo
                   Select us).FirstOrDefault

            db.Database.Connection.Open()
            Dim edit As tblWHPrepairGoodsReceiveDetail = (From c In db.tblWHPrepairGoodsReceiveDetails Where c.ItemNo = lblItemNo And c.LOTNo = lblLOTNo Select c).First()
            If edit IsNot Nothing Then
                edit.UserBy = CStr(Session("UserName"))
                edit.LastUpdate = Now
                edit.Status = 0
                edit.Quantity = u.Quantity
                db.SaveChanges()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function SaveDeleteStockMovement_Confirm(ByVal i As Integer) As Boolean
        Dim chkName As CheckBox
        Dim lblItemNo As Double
        Dim lblLOTNo As String
        Dim lblReceiveNo As String
        Dim lblQuantity As Double

        chkName = CType(Repeater9.Items(i).FindControl("chk_Pull"), CheckBox)
        lblItemNo = CDbl(CType(Repeater9.Items(i).FindControl("lblItemNo"), Label).Text.Trim)
        lblLOTNo = CType(Repeater9.Items(i).FindControl("lblLOTNo"), Label).Text.Trim
        lblReceiveNo = CType(Repeater9.Items(i).FindControl("lblReceiveNo"), Label).Text.Trim
        lblQuantity = CDbl(CType(Repeater9.Items(i).FindControl("lblQuantity"), Label).Text.Trim)

        Try
            'Dim u = (From us In db.tblWHConfirmGoodsReceiveDetails Where us.LOTNo = lblLOTNo And us.ItemNo = lblItemNo
            '     Select us).FirstOrDefault

            'Dim DeleteStockMovement As tblWHStockMovement = (From c In db.tblWHStockMovements Where c.LOTNo = u.LOTNo And c.ItemNo = u.ItemNo And c.item = u.Item And c.ReceiveNo = u.ReceiveNo And c.Type = u.Type And c.ReceivedQuantity = u.Quantity Select c).First()          

            Dim DeleteStockMovement As tblWHStockMovement = (From delsm In db.tblWHStockMovements Where delsm.LOTNo = lblLOTNo And delsm.ItemNo = lblItemNo _
              And delsm.ReceiveNo = lblReceiveNo Select delsm).SingleOrDefault

            db.tblWHStockMovements.Remove(DeleteStockMovement)
            db.SaveChanges()
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function
    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("RejectReceivedWH.aspx")
    End Sub
End Class