Option Explicit On
Option Strict On
Option Infer On

Public Class AdLocWH
    Inherits System.Web.UI.Page

    Dim db As New LKBWarehouseEntities1
    'Dim db As New LKBWarehouseEntities


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

        End If
    End Sub

    Protected Sub btnFind_ServerClick(sender As Object, e As EventArgs)
        If rdbAdLoc.Checked = True Then
            'If txtOwnerPN.Value <> "" And txtCustomerLotNo.Value <> "" And txtCusRefNo.Value <> "" Then
            '    Str = " tblWHStockMovement.OwnerPN = '" & txtOwnerPN.Value & "' AND " & " tblWHStockMovement.CustomerLOTNo = '" & txtCustomerLotNo.Value & "' AND " & " tblWHStockMovement.OrderNo = '" & txtCusRefNo.Value & "'"
            'ElseIf txtOwnerPN.Value <> "" And txtCustomerLotNo.Value <> "" Then
            '    Str = " tblWHStockMovement.OwnerPN = '" & txtOwnerPN.Value & "' AND " & " tblWHStockMovement.CustomerLOTNo = '" & txtCustomerLotNo.Value & "'"
            'ElseIf txtOwnerPN.Value <> "" And txtCusRefNo.Value <> "" Then
            '    Str = " tblWHStockMovement.OwnerPN = '" & txtOwnerPN.Value & "' AND " & " tblWHStockMovement.OrderNo = '" & txtCusRefNo.Value & "'"
            'ElseIf txtCusRefNo.Value <> "" And txtCusRefNo.Value <> "" Then
            '    Str = " tblWHStockMovement.CustomerLOTNo = '" & txtCustomerLotNo.Value & "' AND " & " tblWHStockMovement.OrderNo = '" & txtCusRefNo.Value & "'"
            'ElseIf txtOwnerPN.Value <> "" And txtInvoice.Value <> "" Then
            '    Str = " tblWHStockMovement.OwnerPN = '" & txtOwnerPN.Value & "' AND " & " tblWHStockMovement.invoice = '" & txtInvoice.Value.Trim & "'"
            'ElseIf txtOwnerPN.Value <> "" Then
            '    Str = " tblWHStockMovement.OwnerPN = '" & txtOwnerPN.Value & "'"
            'ElseIf txtCustomerLotNo.Value <> "" Then
            '    Str = " tblWHStockMovement.CustomerLOTNo = '" & txtCustomerLotNo.Value & "'"
            'ElseIf txtCusRefNo.Value <> "" Then
            '    Str = " tblWHStockMovement.OrderNo = '" & txtCusRefNo.Value & "'"
            'ElseIf txtInvoice.Value <> "" Then
            '    Str = " tblWHStockMovement.invoice = '" & txtInvoice.Value.Trim & "'"
            'End If
            ReadDATA()
        ElseIf rdbAdQTY.Checked = True Then
            'Str = "SELECT * From tblWHConfirmGoodsReceiveDetail WHERE LOTNo = '" & txtJobNo.Value & "'"
            showJobNo()
        Else
            'MessageBox.Show("กรุณาเลือกก่อนว่าจะทำงานอะไร !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOwnerPN.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub ReadDATA()

        Dim cons = (From a In db.tblWHStockMovements Join b In db.tblWHConfirmGoodsReceiveDetails On b.LOTNo Equals a.LOTNo And b.ReceiveNo Equals a.ReceiveNo And b.ItemNo Equals a.ItemNo _
                And b.OwnerPN Equals a.OwnerPN
            Where (a.StockType = "Received") And (b.StatusAvailable = "0")
           Select New With {a.OwnerPN,
                            a.CustomerLOTNo,
                            a.WHLocation,
                            a.PalletNo,
                            a.ItemNo,
                            a.CustomerPN,
                            a.ProductDesc,
                            a.Type,
                            a.ReceivedQuantity,
                            b.AvailableQuantity,
                            a.DamageQuantity,
                            b.TypeDamage,
                            a.LOTNo,
                            a.ReceiveNo,
                            a.Weigth,
                            a.WeigthUnit,
                            a.UserBy,
                            a.LastUpdate,
                            b.Remark,
                            b.Invoice,
                            b.ManufacturingDate,
                            b.ExpectedDate}).ToList()

        If cons.Count > 0 Then
            Repeater1.DataSource = cons.ToList
            Repeater1.DataBind()
        Else
            Repeater1.DataSource = Nothing
            Repeater1.DataBind()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รายการที่คุณค้นหาไม่มีในฐานข้อมูล กรุณาลองใหม่อีกครั้ง  !!!');", True)
            Exit Sub
        End If
    End Sub
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        'Dim id As String = Session("UserName").ToString
        'Dim menu As String = "frmUserProfile"
        'Dim index As String = CStr(e.CommandArgument)
        'If e.CommandName.Equals("edituser") Then
        '    Dim ds1 = From c In db.tblUserMenus Where c.UserName = id And c.Form = menu And c.Edit_ = 1
        '    If ds1.Any Then
        '        Response.Write("<script>window.open('UpdateUserProfile.aspx?UserName=" & index & "',target='_self');</script>")
        '    Else
        '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธ์การแก้ไข')", True)
        '    End If
        'ElseIf e.CommandName.Equals("viewprofile") Then
        '    Dim ds1 = From c In db.tblUserMenus Where c.UserName = id And c.Form = menu And c.Read_ = 1
        '    If ds1.Any Then
        '        Response.Write("<script>window.open('ViewUserProfile.aspx?UserName=" & index & "',target='_self');</script>")
        '    Else
        '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธ์การแก้ไข')", True)
        '    End If
        'End If
    End Sub
    Protected Sub btnSave_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)

    End Sub
    Private Sub showTest()
        'Dim sy = (From s In db.tblWHStockMovements)
    End Sub
    Public Function shwo(i As Integer, j As Integer) As Integer
        Dim d As Integer
        d = i + j
        Return d
    End Function
    Public Sub showJobNo()

        Dim user = (From u In db.tblWHConfirmGoodsReceiveDetails Where u.LOTNo = txtJobNo.Value.Trim
                   Select New With {u.LOTNo,
                          u.WHSite,
                          u.ENDCustomer,
                          u.CustomerLOTNo,
                          u.ItemNo}).ToList()
        If user.Count > 0 Then
            Repeater2.DataSource = user.ToList
            Repeater2.DataBind()
        Else
            Me.Repeater2.DataSource = Nothing
            Me.Repeater2.DataBind()
        End If
    End Sub
End Class