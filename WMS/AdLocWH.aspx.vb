Option Explicit On
Option Strict On
Option Infer On

Imports System.Transactions

Public Class AdLocWH
    Inherits System.Web.UI.Page
    Dim OwnerPN As String
    Dim CustomerLOTNo As String
    Dim OrderNo As String
    Dim invoice As String
    Dim itemNo As Integer
    Dim ReceiveNo As String
    Dim LotNo As String
    Dim db As New LKBWarehouseEntities1
    Dim ClassPermis As New ClassPermis
    'Dim db As New LKBWarehouseEntities
    Dim AQty As Double
    Dim Status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            txtLocation.Disabled = True
            txtAvalibleQTY.Disabled = True
            txtDamageQTY.Disabled = True
            rdbGoodComplete.Enabled = False
            rdbGoodDamage.Enabled = False
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
        Dim lblItemNo As Double = CDbl(TryCast(Item.FindControl("lblItemNo"), Label).Text.Trim)
        Dim lblOwnerPN As String = TryCast(Item.FindControl("lblOwnerPN"), Label).Text.Trim



        Dim user = (From u In db.tblWHConfirmGoodsReceiveDetails Join st In db.tblWHStockMovements On u.LOTNo Equals st.LOTNo And u.ItemNo Equals st.ItemNo
                  Where u.CustomerLOTNo = lblCustomerLOTNo And u.ItemNo = lblItemNo And u.OwnerPN = lblOwnerPN).SingleOrDefault

        If String.IsNullOrEmpty(user.u.OwnerPN) Then
            txtOwnerPN.Value = ""
        Else
            txtOwnerPN.Value = user.u.OwnerPN
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
        Session("LotNo") = user.st.LOTNo
        Session("itemNo") = CInt(user.st.ItemNo)
        Session("AQty") = CDbl(user.st.AvalableQuantity)
        Session("Status") = user.st.Type
        Session("ReceiveNo") = user.st.ReceiveNo

    End Sub
    Protected Sub btnSave_ServerClick(sender As Object, e As EventArgs) Handles btnSave.ServerClick
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmAdjiustLocation"
        If ClassPermis.CheckSave(form, usename) = True Then
            SaveDetailConfirm_Modify()
            'ClearData1()
            ReadDATA()

        Else

        End If



    End Sub
    Private Sub SaveDetailConfirm_Modify()
        LotNo = CStr(Session("LotNo"))
        itemNo = CInt(Session("itemNo"))
        AQty = CDbl(Session("AQty"))
        Status = CStr(Session("Status"))
        ReceiveNo = CStr(Session("ReceiveNo"))
        If txtOwnerPN.Value.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ OwnerPN' ผลการตรวจสอบ!!');", True)
            txtOwnerPN.Focus()
            Exit Sub
        End If
        If IsNothing(itemNo) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ ItemNo' ผลการตรวจสอบ!!');", True)
            Exit Sub
        End If
        'sb.Append(" SET UserBy=@UserBy,LastUpdate=@LastUpdate,WHLocation=@WHLocation,AvailableQuantity=@AvailableQuantity,Type=@Type,TypeDamage=@TypeDamage,Weigth=@Weigth,WeigthUnit=@WeigthUnit,StatusAvailable=@StatusAvailable,Remark=@Remark")
        'sb.Append(" WHERE (LOTNo=@LOTNo and ItemNo=@ItemNo AND OwnerPN=@OwnerPN AND CustomerLOTNo=@CustomerLOTNo AND ReceiveNo=@ReceiveNo)")
        If MsgBox("คุณต้องการแก้ไขรายการ LOT No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    Dim edit As tblWHConfirmGoodsReceiveDetail = (From c In db.tblWHConfirmGoodsReceiveDetails Where c.LOTNo = LotNo And c.ItemNo = itemNo And c.OwnerPN = txtOwnerPN.Value.Trim And c.CustomerLOTNo = txtCustomerLotNo.Value.Trim And c.ReceiveNo = ReceiveNo
                    Select c).FirstOrDefault
                    If edit IsNot Nothing Then                 
                        edit.OwnerPN = txtOwnerPN.Value.Trim
                        edit.CustomerLOTNo = txtCustomerLotNo.Value.Trim
                        edit.ReceiveNo = ReceiveNo
                        edit.UserBy = CStr(Session("UserName"))
                        edit.LastUpdate = Now
                        edit.WHLocation = txtLocation.Value.Trim
                        edit.AvailableQuantity = CType(CDbl(AQty).ToString("#,##0.000"), Double?)
                        edit.Type = Status
                        edit.Weigth = CType(txtWeight.Value.Trim, Double?)
                        edit.WeigthUnit = txtUnit.Value.Trim
                        edit.StatusAvailable = CStr(0)
                        edit.Remark = txtRemark.InnerText
                        db.SaveChanges()
                        tran.Complete()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                    End If
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using


        End If
        Exit Sub

    End Sub
    Private Sub SaveDetailStockMoveMent_Modify()
        
    End Sub

    Protected Sub btnClear_ServerClick(sender As Object, e As EventArgs)
        txtOwnerPN.Value = ""
        txtCustomerLotNo.Value = ""
        txtCusRefNo.Value = ""
        txtJobNo.Value = ""
        txtInvoice.Value = ""



    End Sub
    
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
