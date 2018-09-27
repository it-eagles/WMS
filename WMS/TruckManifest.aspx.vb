Option Explicit On
Option Strict On
Option Infer On

Public Class TruckManifest
    Inherits System.Web.UI.Page
    Dim tmpButtonStatus As String
    Dim LotNoTruckManifestCode As String
    Dim InvoiceNo As String
    Dim TruckWayBill As String
    Dim Remark As String
    Dim db As New LKBWarehouseEntities1
    Dim ClassPermis As ClassPermis





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)


    End Sub
    Protected Sub Unlockdata()
        btnAdd.Visible = False
        btnModify.Visible = True
        btnDelete.Visible = True
        btnFind.Visible = False
        btnprint.Visible = True
        btnCancel.Visible = True
        btnSave.Visible = True
        btnClose.Visible = True

    End Sub
    Protected Sub Cleardata()
        txtTuckManifestCode.Value = ""
        txtTruckOwner.Value = "0"
        txtOrigin.Value = ""
        txtDestination.Value = ""
        txtConsigneeCode.Value = ""
        txtContactName.Value = ""
        txtContactTel.Value = ""
        txtIssuedBy.Value = ""
        txtEasName.Value = ""
        txtEasTel.Value = ""
        txtInvoiceNo.Value = ""
        txtTruckWaybill.Value = ""
        txtQuantity.Value = "0.0"
        txtWeight.Value = "0.0"
        txtQuantityFull.Value = ""

    End Sub
    Private Sub ClearDATADetail()
        txtInvoiceNo.Value = ""
        txtTruckWaybill.Value = ""
        txtQuantity.Value = "0.0"
        dcboUnitQuantity.Text = ""
        txtQuantityFull.Value = "0.0"
        dcboUnitQuantity1.Text = ""
        txtWeight.Value = "0.0"
        dcboUnitWeight.Text = ""

    End Sub
    Protected Sub btnAdd_ServerClick(sender As Object, e As EventArgs) Handles btnAdd.ServerClick
        tmpButtonStatus = "AddNew"
        Unlockdata()
        Cleardata()

    End Sub

    Protected Sub btnModify_ServerClick(sender As Object, e As EventArgs) Handles btnModify.ServerClick
        tmpButtonStatus = "Modify"
        Unlockdata()

    End Sub

    Protected Sub btnDelete_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnFind_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnprint_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnCancel_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSave_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnClose_ServerClick(sender As Object, e As EventArgs) Handles btnClose.ServerClick

    End Sub
    Private Sub ReadDATA()

        Dim cons = (From a In db.tblTruckManifestDetails
        Where a.TruckManifestCode.Contains(txtTuckManifestCode.Value.Trim) Order By a.TruckManifestCode
           Select New With {a.TruckManifestCode,
                            a.InvoiceNo,
                            a.TruckWayBill,
                            a.Remark,
                            a.RowTruckNo}).ToList()

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
            Dim lblTruckManifestCode As Label = CType(e.Item.FindControl("lblTruckManifestCode"), Label)
            Dim lblInvoiceNo As Label = CType(e.Item.FindControl("lblInvoiceNo"), Label)
            Dim lblTruckWayBill As Label = CType(e.Item.FindControl("lblTruckWayBill"), Label)
            Dim lblRemark As Label = CType(e.Item.FindControl("lblRemark"), Label)
            Dim lblRowTruckNo As Label = CType(e.Item.FindControl("lblRowTruckNo"), Label)

            If Not IsNothing(lblTruckManifestCode) Then
                lblTruckManifestCode.Text = DataBinder.Eval(e.Item.DataItem, "TruckManifestCode").ToString()
            End If
            If Not IsNothing(lblInvoiceNo) Then
                lblInvoiceNo.Text = DataBinder.Eval(e.Item.DataItem, "InvoiceNo").ToString()
            End If
            If Not IsNothing(lblTruckWayBill) Then
                lblTruckWayBill.Text = DataBinder.Eval(e.Item.DataItem, "TruckWayBill").ToString()
            End If
            If Not IsNothing(lblRemark) Then
                lblRemark.Text = DataBinder.Eval(e.Item.DataItem, "Remark").ToString()
            End If
            If Not IsNothing(lblRowTruckNo) Then
                lblRowTruckNo.Text = DataBinder.Eval(e.Item.DataItem, "RowTruckNo").ToString()
            End If

        End If
    End Sub

    Protected Sub clickrpt_Click(sender As Object, e As EventArgs)
        Dim Item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim lblTruckManifestCode As String = TryCast(Item.FindControl("lblTruckManifestCode"), Label).Text.Trim
        Dim lblRowTruckNo As Double = CDbl(TryCast(Item.FindControl("lblRowTruckNo"), Label).Text.Trim)

        Dim user = (From u In db.tblTruckManifestDetails Where u.TruckManifestCode = lblTruckManifestCode And u.RowTruckNo = lblRowTruckNo).SingleOrDefault

        If String.IsNullOrEmpty(user.InvoiceNo) Then
            txtInvoiceNo.Value = ""
        Else
            txtInvoiceNo.Value = user.InvoiceNo
        End If
        'If String.IsNullOrEmpty(user.) Then
        '    lblRowTruckNo = 
        'Else
        '    txtOwnerPN.Value = user.u.OwnerPN
        'End If
        'If String.IsNullOrEmpty(user.u.OwnerPN) Then
        '    txtOwnerPN.Value = ""
        'Else
        '    txtOwnerPN.Value = user.u.OwnerPN
        'End If
        'If String.IsNullOrEmpty(user.u.OwnerPN) Then
        '    txtOwnerPN.Value = ""
        'Else
        '    txtOwnerPN.Value = user.u.OwnerPN
        'End If

    End Sub
End Class