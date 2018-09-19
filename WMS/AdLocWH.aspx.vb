Option Explicit On
Option Strict On
Option Infer On

Public Class AdLocWH
    Inherits System.Web.UI.Page
    Dim OwnerPN As String
    Dim CustomerLOTNo As String
    Dim OrderNo As String
    Dim invoice As String
    Dim db As New LKBWarehouseEntities1
    'Dim db As New LKBWarehouseEntities


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

        End If
    End Sub

    Protected Sub btnFind_ServerClick(sender As Object, e As EventArgs)
        If rdbAdLoc.Checked = True Then
            If txtOwnerPN.Value <> "" And txtCustomerLotNo.Value <> "" And txtCusRefNo.Value <> "" Then
                OwnerPN = txtOwnerPN.Value.Trim
                CustomerLOTNo = txtCustomerLotNo.Value.Trim
                OrderNo = txtCusRefNo.Value.Trim
                ReadDATA()
            ElseIf txtOwnerPN.Value <> "" And txtCustomerLotNo.Value <> "" Then
                OwnerPN = txtOwnerPN.Value.Trim
                CustomerLOTNo = txtCustomerLotNo.Value.Trim
                ReadDATA()
            ElseIf txtOwnerPN.Value <> "" And txtCusRefNo.Value <> "" Then
                OwnerPN = txtOwnerPN.Value.Trim
                OrderNo = txtCusRefNo.Value.Trim
                ReadDATA1()
            ElseIf txtCustomerLotNo.Value <> "" And txtCusRefNo.Value <> "" Then
                CustomerLOTNo = txtCustomerLotNo.Value.Trim
                OrderNo = txtCusRefNo.Value.Trim
                ReadDATA1()
            ElseIf txtOwnerPN.Value <> "" And txtInvoice.Value <> "" Then
                OwnerPN = txtOwnerPN.Value.Trim
                invoice = txtInvoice.Value.Trim
                ReadDATA2()
                'Str = " tblWHStockMovement.OwnerPN = '" & txtFOwnerPN.Text & "' AND " & " tblWHStockMovement.invoice = '" & txtInvoice.Text.Trim & "'"
            ElseIf txtOwnerPN.Value <> "" Then
                OwnerPN = txtOwnerPN.Value.Trim
                ReadDATA2()
            ElseIf txtCustomerLotNo.Value <> "" Then
                CustomerLOTNo = txtCustomerLotNo.Value.Trim
                ReadDATA2()
            ElseIf txtCusRefNo.Value <> "" Then
                OrderNo = txtCusRefNo.Value.Trim
                ReadDATA2()
            ElseIf txtInvoice.Value <> "" Then

                invoice = txtInvoice.Value.Trim
                ReadDATA2()
            End If
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

        Dim cons = (From a In db.tblWHStockMovements Join b In db.tblWHConfirmGoodsReceiveDetails On b.LOTNo Equals a.LOTNo _
                  And b.ReceiveNo Equals a.ReceiveNo And b.ItemNo Equals a.ItemNo And b.OwnerPN Equals a.OwnerPN
        Where (((a.OwnerPN = OwnerPN And a.CustomerLOTNo = CustomerLOTNo And a.OrderNo = OrderNo) Or (a.OwnerPN = OwnerPN And a.CustomerLOTNo = CustomerLOTNo)) And (a.StockType = "Received" And b.StatusAvailable = "0"))
           Select New With {a.OwnerPN,
                            a.CustomerLOTNo,
                            a.LOTNo,
                            a.ItemNo,
                            a.ReceiveNo}).ToList()

        If cons.Count > 0 Then
            Repeater1.DataSource = cons
            Repeater1.DataBind()
        Else
            Repeater1.DataSource = Nothing
            Repeater1.DataBind()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รายการที่คุณค้นหาไม่มีในฐานข้อมูล กรุณาลองใหม่อีกครั้ง  !!!');", True)
            Exit Sub
        End If
    End Sub
    Private Sub ReadDATA1()

        Dim cons = (From a In db.tblWHStockMovements Join b In db.tblWHConfirmGoodsReceiveDetails On b.LOTNo Equals a.LOTNo And b.ReceiveNo Equals a.ReceiveNo And b.ItemNo Equals a.ItemNo _
                And b.OwnerPN Equals a.OwnerPN
            Where (((a.OwnerPN = OwnerPN And a.OrderNo = OrderNo) Or (a.OrderNo = OrderNo And a.CustomerLOTNo = CustomerLOTNo)) And (a.StockType = "Received" And b.StatusAvailable = "0"))
           Select New With {a.OwnerPN,
                            a.CustomerLOTNo,
                            a.LOTNo,
                            a.ItemNo,
                            a.ReceiveNo}).ToList()

        If cons.Count > 0 Then
            Repeater1.DataSource = cons
            Repeater1.DataBind()
        Else
            Repeater1.DataSource = Nothing
            Repeater1.DataBind()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รายการที่คุณค้นหาไม่มีในฐานข้อมูล กรุณาลองใหม่อีกครั้ง  !!!');", True)
            Exit Sub
        End If
    End Sub
    Private Sub ReadDATA2()

        Dim cons = (From a In db.tblWHStockMovements Join b In db.tblWHConfirmGoodsReceiveDetails On b.LOTNo Equals a.LOTNo _
                  And b.ReceiveNo Equals a.ReceiveNo And b.ItemNo Equals a.ItemNo And b.OwnerPN Equals a.OwnerPN
        Where (((a.OwnerPN = OwnerPN And a.Invoice = invoice) Or (a.OwnerPN = OwnerPN Or a.CustomerLOTNo = CustomerLOTNo Or a.OrderNo = OrderNo Or a.Invoice = invoice)) _
                 And (a.StockType = "Received" And b.StatusAvailable = "0"))
           Select New With {a.OwnerPN,
                            a.CustomerLOTNo,
                            a.LOTNo,
                            a.ItemNo,
                            a.ReceiveNo}).ToList()

        If cons.Count > 0 Then
            Repeater1.DataSource = cons
            Repeater1.DataBind()
        Else
            Repeater1.DataSource = Nothing
            Repeater1.DataBind()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('รายการที่คุณค้นหาไม่มีในฐานข้อมูล กรุณาลองใหม่อีกครั้ง  !!!');", True)
            Exit Sub
        End If
    End Sub
    Protected Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblOwnerPN As Label = CType(e.Item.FindControl("lblOwnerPN"), Label)
            Dim lblCustomerLOTNo As Label = CType(e.Item.FindControl("lblCustomerLOTNo"), Label)
            Dim lblLOTNo As Label = CType(e.Item.FindControl("lblLOTNo"), Label)
            Dim lblItemNo As Label = CType(e.Item.FindControl("lblItemNo"), Label)
            Dim lblReceiveNo As Label = CType(e.Item.FindControl("lblReceiveNo"), Label)

            If Not IsNothing(lblOwnerPN) Then
                lblOwnerPN.Text = DataBinder.Eval(e.Item.DataItem, "OwnerPN").ToString()
            End If
            If Not IsNothing(lblCustomerLOTNo) Then
                lblCustomerLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "CustomerLOTNo").ToString()
            End If
            If Not IsNothing(lblLOTNo) Then
                lblLOTNo.Text = DataBinder.Eval(e.Item.DataItem, "LOTNo").ToString()
            End If
            If Not IsNothing(lblItemNo) Then
                lblItemNo.Text = DataBinder.Eval(e.Item.DataItem, "ItemNo").ToString()
            End If
            If Not IsNothing(lblReceiveNo) Then
                lblReceiveNo.Text = DataBinder.Eval(e.Item.DataItem, "ReceiveNo").ToString()
            End If
        End If
    End Sub
    Protected Sub clickrpt_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblCustomerLOTNo As String = TryCast(Item.FindControl("lblCustomerLOTNo"), Label).Text.Trim
        Dim lblLOTNo As String = TryCast(Item.FindControl("lblLOTNo"), Label).Text.Trim
        Dim lblItemNo As Double = CDbl(TryCast(Item.FindControl("lblItemNo"), Label).Text.Trim)

        Dim user = (From u In db.tblWHConfirmGoodsReceiveDetails Join st In db.tblWHStockMovements On u.LOTNo Equals st.LOTNo And u.ItemNo Equals st.ItemNo
                  Where u.CustomerLOTNo = lblCustomerLOTNo And u.LOTNo = lblLOTNo And u.ItemNo = lblItemNo).SingleOrDefault

        If String.IsNullOrEmpty(user.u.OwnerPN) Then
            txtOwnerPN2.Value = ""
        Else
            txtOwnerPN2.Value = user.u.OwnerPN
        End If

        If String.IsNullOrEmpty(user.u.WHLocation) Then
            txtLocation.Value = ""
        Else
            txtLocation.Value = user.u.WHLocation
        End If

        If String.IsNullOrEmpty(user.u.CustomerLOTNo) Then
            txtCustomerLotNo.Value = ""
        Else
            txtCustomerLotNo.Value = user.u.CustomerLOTNo
        End If

        If String.IsNullOrEmpty(CStr(user.u.AvailableQuantity)) Then
            txtAvalibleQTY.Value = ""
        Else
            txtAvalibleQTY.Value = CStr(user.u.AvailableQuantity)
        End If

        If String.IsNullOrEmpty(user.u.TypeDamage) Then
            ddlType.Text = ""
        Else
            ddlType.Text = user.u.TypeDamage
        End If

        If String.IsNullOrEmpty(CStr(user.u.Weigth)) Then
            txtWeight.Value = ""
        Else
            txtWeight.Value = CStr(user.u.Weigth)
        End If

        If String.IsNullOrEmpty(user.u.Remark) Then
            txtRemark.Value = ""
        Else
            txtRemark.Value = user.u.Remark
        End If

        If String.IsNullOrEmpty(CStr(user.st.ReceivedQuantity)) Then
            txtRCVQuantity.Value = ""
        Else
            txtRCVQuantity.Value = CStr(user.st.ReceivedQuantity)
        End If

        If String.IsNullOrEmpty(CStr(user.st.DamageQuantity)) Then
            txtDamageQTY.Value = ""
        Else
            txtDamageQTY.Value = CStr(user.st.DamageQuantity)
        End If

        If String.IsNullOrEmpty(CStr(user.st.WeigthUnit)) Then
            txtUnit.Value = ""
        Else
            txtUnit.Value = CStr(user.st.WeigthUnit)
        End If


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
