Option Explicit On
Option Strict On
Option Infer On

Public Class AdLocWH
    Inherits System.Web.UI.Page
    Dim OwnerPN As String
    Dim CustomerLOTNo As String
    Dim OrderNo As String
    Dim invoice As String
    Dim itemNo As Integer
    Dim db As New LKBWarehouseEntities1
    Dim ClassPermis As New ClassPermis
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

        If String.IsNullOrEmpty(CStr(user.u.ItemNo)) Then
            itemNo = 0
        Else
            itemNo = CInt(user.st.ItemNo)

        End If


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
        If txtOwnerPN.Value.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ OwnerPN' ผลการตรวจสอบ!!');", True)
            txtOwnerPN.Focus()
            Exit Sub
        End If
        If IsNothing(itemNo) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาใส่ ItemNo' ผลการตรวจสอบ!!');", True)
            Exit Sub
        Else

            If MsgBox("คุณต้องการแก้ไขรายการ LOT No ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Using tran As New Transactionsscope()
                    Try
                        db.Database.Connection.Open()
                        Dim edit As tblImpGenLOT = (From c In db.tblImpGenLOTs Where c.EASLOTNo = txtJobNo.Value.Trim
                        Select c).First()
                        If edit IsNot Nothing Then
                            edit.EASLOTNo = txtJobNo.Value.Trim
                            edit.JobSite = ddlJobsite.Text.Trim
                            edit.LOTDate = CDate(txtdatepickerJobdate.Text.Trim)
                            edit.LOTBy = ddlLotof.Text.Trim
                            edit.SalesCode = ddlSaleman.Text.Trim
                            edit.SalesName = txtsalemandis.Value.Trim
                            edit.ConsigneeCode = txtConsigneecode.Value.Trim
                            edit.ConsignNameEng = txtNameEngConsign.Value.Trim
                            edit.ConsignAddress = txtAddress1.Value.Trim
                            edit.ConsignDistrict = txtAddress2.Value.Trim
                            edit.ConsignSubProvince = txtAddress3.Value.Trim
                            edit.ConsignProvince = txtAddress4.Value.Trim
                            edit.ConsignPostCode = txtAddress5.Value.Trim
                            edit.ConsignEmail = txtEmail.Value.Trim
                            edit.ShipperCode = txtShippercode.Value.Trim
                            edit.ShipperNameEng = txtNameEngShipper.Value.Trim
                            edit.ShipperAddress = txtAddress1Shipper.Value.Trim
                            edit.ShipperDistrict = txtAddress2Shipper.Value.Trim
                            edit.ShipperSubprovince = txtAddress3Shipper.Value.Trim
                            edit.ShipperProvince = txtAddress4Shipper.Value.Trim
                            edit.ShipperPostCode = txtAddress5Shipper.Value.Trim
                            edit.ShipperReturnCode = txtEmailShipper.Value.Trim
                            edit.Commodity = ddlCommodity.Text.Trim
                            edit.QuantityofPart = CType(txtQuantityOfPart.Value.Trim, Double?)
                            edit.QuantityUnit = ddlQuantityOfParty.Text.Trim
                            edit.QuantityPack = CType(txtQuantity.Value.Trim, Double?)
                            edit.QuantityUnitPack = ddlQuan.Text.Trim
                            edit.Weight = CType(txtWeight.Value.Trim, Double?)
                            edit.WeightUnit = ddlWeight.Text.Trim
                            edit.QuantityPack1 = CType(txtQuantityBox.Value.Trim, Double?)
                            edit.QuantityUnitPack1 = ddlquanbox.Text.Trim
                            edit.Volume = CType(txtVolume.Value.Trim, Double?)
                            edit.VolumeUnit = ddlvolume.Text.Trim
                            edit.MAWB = txtMAWB_BL_TWB.Value.Trim
                            edit.Flight = txtFLT_Voy_TruckDate.Value.Trim
                            edit.DocType = ddlvolume2.Text.Trim
                            edit.DocCode = txtVolume2.Value.Trim
                            edit.FreighForwarder = ddlFreight.Text.Trim
                            edit.ShipTo = txtShipto.Value.Trim
                            edit.BillingNo = txtBilling.Value.Trim
                            edit.FLT1 = txtActual1.Value.Trim
                            edit.FLT2 = txtActual2.Value.Trim
                            edit.FLT3 = txtActual3.Value.Trim
                            edit.FLT4 = txtActual4.Value.Trim
                            edit.DateFLT1 = CType(txtdatepickerActualDate1.Text.Trim, Date?)
                            edit.DateFLT2 = CType(txtdatepickerActualDate2.Text.Trim, Date?)
                            edit.DateFLT3 = CType(txtdatepickerActualDate3.Text.Trim, Date?)
                            edit.DateFLT4 = CType(txtdatepickerActualDate4.Text.Trim, Date?)
                            edit.ORGN1 = txtORGN1.Value.Trim
                            edit.ORGN2 = txtORGN2.Value.Trim
                            edit.ORGN3 = txtORGN3.Value.Trim
                            edit.ORGN4 = txtORGN4.Value.Trim
                            edit.DSTN1 = txtDSTN1.Value.Trim
                            edit.DSTN2 = txtDSTN2.Value.Trim
                            edit.DSTN3 = txtDSTN3.Value.Trim
                            edit.DSTN4 = txtDSTN4.Value.Trim
                            edit.ETD1 = txtpickupETD.Value.Trim
                            edit.ETD2 = txtpickupETD2.Value.Trim
                            edit.ETD3 = txtpickupETD3.Value.Trim
                            edit.ETD4 = txtpickupETD4.Value.Trim
                            edit.ETA1 = txtpickupETA.Value.Trim
                            edit.ETA2 = txtpickupETA2.Value.Trim
                            edit.ETA3 = txtpickupETA3.Value.Trim
                            edit.ETA4 = txtpickupETA4.Value.Trim
                            edit.PCS1 = CType(txtPacket.Value.Trim, Double?)
                            edit.PCS2 = CType(txtPacket2.Value.Trim, Double?)
                            edit.PCS3 = CType(txtPacket3.Value.Trim, Double?)
                            edit.PCS4 = CType(txtPacket4.Value.Trim, Double?)
                            edit.Weight1 = CType(txtWeightActual.Value.Trim, Double?)
                            edit.Weight2 = CType(txtWeightActual2.Value.Trim, Double?)
                            edit.Weight3 = CType(txtWeightActual3.Value.Trim, Double?)
                            edit.Weight4 = CType(txtWeightActual4.Value.Trim, Double?)
                            edit.TimeDTE = txtTimePickUp.Value.Trim
                            edit.DateDTE = CType(txtdatepickerActualPickUp.Text.Trim, Date?)
                            edit.TimeATT = txtArrivalToEAS.Value.Trim
                            edit.DateATT = CType(txtdatepickerArrivalToEAS.Text.Trim, Date?)
                            edit.Remark = txtRamarkActual.Value.Trim
                            edit.DOCode = txtDeliverycode.Value.Trim
                            edit.DONameENG = txtNameEngDelivery.Value.Trim
                            edit.DOStreet_Number = txtAddress1Delivery.Value.Trim
                            edit.DODistrict = txtAddress2Delivery.Value.Trim
                            edit.DOSubProvince = txtAddress3Delivery.Value.Trim
                            edit.DOProvince = txtAddress4Delivery.Value.Trim
                            edit.DOPostCode = txtAddress5Delivery.Value.Trim
                            edit.DOEmail = txtEmailDelivery.Value.Trim
                            edit.DOContactPerson = txtContractPersonDelivery.Value.Trim
                            edit.PickUpCode = txtCodePickUpPlace.Value.Trim
                            edit.PickUpENG = txtNamePickUpPlace.Value.Trim
                            edit.PickUpAddress1 = txtAddress1PickUpPlace.Value.Trim
                            edit.PickUpAddress2 = txtAddress2PickUpPlace.Value.Trim
                            edit.PickUpAddress3 = txtAddress3PickUpPlace.Value.Trim
                            edit.PickUpAddress4 = txtAddress4PickUpPlace.Value.Trim
                            edit.PickUpAddress5 = txtAddress5PickUpPlace.Value.Trim
                            edit.PickUpEmail = txtEmailPickUpPlace.Value.Trim
                            edit.PickUpContact = txtContractPersonPickUpPlace.Value.Trim
                            edit.CustomerCode = txtCustomercode.Value.Trim
                            edit.CustomerENG = txtNameEngCustomer.Value.Trim
                            edit.CustomerStreet = txtAddress1Custommer.Value.Trim
                            edit.CustomerDistrict = txtAddress2Custommer.Value.Trim
                            edit.CustomerSub = txtAddress3Custommer.Value.Trim
                            edit.CustomerProvince = txtAddress4Custommer.Value.Trim
                            edit.CustomerPostCode = txtAddress5Custommer.Value.Trim
                            edit.CustomerEmail = txtEmailCustommer.Value.Trim
                            edit.CustomerContact = txtContractPersonCustommer.Value.Trim
                            edit.EndCusCode = txtCodeEndCustomer.Value.Trim
                            edit.EndCusENG = txtNameEndCustomer.Value.Trim
                            edit.EndCusAddress1 = txtAddress1EndCustomer.Value.Trim
                            edit.EndCusAddress2 = txtAddress2EndCustomer.Value.Trim
                            edit.EndCusAddress3 = txtAddress3EndCustomer.Value.Trim
                            edit.EndCusAddress4 = txtAddress4EndCustomer.Value.Trim
                            edit.EndCusAddress5 = txtAddress5EndCustomer.Value.Trim
                            edit.EndCusEmail = txtEmailEndCustomer.Value.Trim
                            edit.EndCusContact = txtContractPersonEndCustomer.Value.Trim
                            edit.CustomerCodeGroup = txtCodeCustommerGroup.Value.Trim
                            edit.CustomerENGGroup = txtNameCustommerGroup.Value.Trim
                            edit.IEATNo = txtIEATNo.Value.Trim
                            edit.IEATPermit = ddlIEATPermit.Text.Trim
                            edit.EntryNo = txtImportEntryNo.Value.Trim
                            edit.DeliveryDate = CType(txtdatepickerImportEntryDate.Text.Trim, Date?)
                            edit.Status1 = ddlStatusIEAT1.Text.Trim
                            edit.Status2 = ddlStatusIEAT2.Text.Trim
                            edit.Useby = CStr(Session("UserId"))

                            db.SaveChanges()
                            tran.Complete()
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล สำเร็จ !');", True)
                        End If
                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                    End Try
                End Using
            End If
            txtJobNo.Focus()
                End Using
            End If
            Exit Sub
        End If


        'If MessageBox.Show("คุณต้องการแก้ไขข้อมูล WHGoodsReceiveDetail ใช่หรือไม่?", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        'tr = Conn.BeginTransaction()
        'Try
        '    sb = New StringBuilder()
        '    sb.Append("UPDATE tblWHStockMovement")
        '    sb.Append(" SET UserBy=@UserBy,LastUpdate=@LastUpdate,WHLocation=@WHLocation,DamageQuantity=@DamageQuantity,AvalableQuantity=@AvalableQuantity,Type=@Type,TypeDamage=@TypeDamage,Weigth=@Weigth,WeigthUnit=@WeigthUnit")
        '    sb.Append(" WHERE (LOTNo=@LOTNo and ItemNo=@ItemNo AND OwnerPN=@OwnerPN AND CustomerLOTNo=@CustomerLOTNo AND ReceiveNo=@ReceiveNo)")
        '    Dim sqlEdit As String
        '    sqlEdit = sb.ToString()

        '    With com
        '        .CommandText = sqlEdit
        '        .CommandType = CommandType.Text
        '        .Connection = Conn
        '        .Transaction = tr
        '        .Parameters.Clear()
        '        .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = txtLotNo.Text.Trim()
        '        .Parameters.Add("@OwnerPN", SqlDbType.NVarChar).Value = txtOwnerPN.Text.Trim()
        '        .Parameters.Add("@CustomerLOTNo", SqlDbType.NVarChar).Value = txtCustomerLotNo.Text.Trim()
        '        .Parameters.Add("@ItemNo", SqlDbType.Decimal).Value = CDbl(txtItemNo.Text).ToString("#,##0")
        '        .Parameters.Add("@UserBy", SqlDbType.NVarChar).Value = DBConnString.UserName
        '        .Parameters.Add("@LastUpdate", SqlDbType.DateTime).Value = Now
        '        .Parameters.Add("@WHLocation", SqlDbType.NVarChar).Value = txtOldLocation.Text.Trim()
        '        .Parameters.Add("@ReceiveNo", SqlDbType.NVarChar).Value = txtReceiveNo.Text.Trim()
        '        .Parameters.Add("@Weigth", SqlDbType.NVarChar).Value = txtWeight.Text.Trim()
        '        .Parameters.Add("@WeigthUnit", SqlDbType.NVarChar).Value = txtWeightUnit.Text.Trim()
        '        If dcbStatus.Text = "Goods Complete" Then
        '            .Parameters.Add("@DamageQuantity", SqlDbType.Decimal).Value = 0
        '            .Parameters.Add("@AvalableQuantity", SqlDbType.Decimal).Value = CDbl(txtAQty.Text).ToString("#,##0.000")
        '        ElseIf dcbStatus.Text = "Goods Damage" Then
        '            .Parameters.Add("@DamageQuantity", SqlDbType.Decimal).Value = CDbl(txtDamageQTY.Text).ToString("#,##0.000")
        '            .Parameters.Add("@AvalableQuantity", SqlDbType.Decimal).Value = 0
        '        End If
        '        .Parameters.Add("@Type", SqlDbType.NVarChar).Value = dcbStatus.Text.Trim()
        '        .Parameters.Add("@TypeDamage", SqlDbType.NVarChar).Value = dcbTypeDamage.Text.Trim()
        '        Dim result As Integer
        '        result = .ExecuteNonQuery()
        '        If result = 0 Then
        '            tr.Rollback()
        '            MessageBox.Show("WHStockMovement ที่คุณใส่ ไม่ถูกต้อง !!!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            txtLotNo.SelectAll()
        '        Else
        '            tr.Commit()
        '        End If
        '    End With
        'Catch ex As Exception
        '    tr.Rollback()
        '    MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก " & ex.Message, "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
        ''End If
        'txtLotNo.Focus()
    End Sub
    Private Sub SaveDetailStockMoveMent_Modify()
        'If txtLotNo.Text.Trim() = "" Then
        '    MessageBox.Show("กรุณาใส่ PrepairLOT ก่อน !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtLotNo.Focus()
        '    Exit Sub
        'End If

        'If txtItemNo.Text.Trim() = "" Then
        '    MessageBox.Show("กรุณาใส่ ItemNo ก่อน !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtItemNo.Focus()
        '    Exit Sub
        'End If

        ''If MessageBox.Show("คุณต้องการแก้ไขข้อมูล WHStockMovement ใช่หรือไม่?", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        'tr = Conn.BeginTransaction()
        'Try
        '    sb = New StringBuilder()
        '    sb.Append("UPDATE tblWHStockMovement")
        '    sb.Append(" SET UserBy=@UserBy,LastUpdate=@LastUpdate,WHLocation=@WHLocation,DamageQuantity=@DamageQuantity,AvalableQuantity=@AvalableQuantity,Type=@Type,TypeDamage=@TypeDamage,Weigth=@Weigth,WeigthUnit=@WeigthUnit")
        '    sb.Append(" WHERE (LOTNo=@LOTNo and ItemNo=@ItemNo AND OwnerPN=@OwnerPN AND CustomerLOTNo=@CustomerLOTNo AND ReceiveNo=@ReceiveNo)")
        '    Dim sqlEdit As String
        '    sqlEdit = sb.ToString()

        '    With com
        '        .CommandText = sqlEdit
        '        .CommandType = CommandType.Text
        '        .Connection = Conn
        '        .Transaction = tr
        '        .Parameters.Clear()
        '        .Parameters.Add("@LOTNo", SqlDbType.NVarChar).Value = txtLotNo.Text.Trim()
        '        .Parameters.Add("@OwnerPN", SqlDbType.NVarChar).Value = txtOwnerPN.Text.Trim()
        '        .Parameters.Add("@CustomerLOTNo", SqlDbType.NVarChar).Value = txtCustomerLotNo.Text.Trim()
        '        .Parameters.Add("@ItemNo", SqlDbType.Decimal).Value = CDbl(txtItemNo.Text).ToString("#,##0")
        '        .Parameters.Add("@UserBy", SqlDbType.NVarChar).Value = DBConnString.UserName
        '        .Parameters.Add("@LastUpdate", SqlDbType.DateTime).Value = Now
        '        .Parameters.Add("@WHLocation", SqlDbType.NVarChar).Value = txtOldLocation.Text.Trim()
        '        .Parameters.Add("@ReceiveNo", SqlDbType.NVarChar).Value = txtReceiveNo.Text.Trim()
        '        .Parameters.Add("@Weigth", SqlDbType.NVarChar).Value = txtWeight.Text.Trim()
        '        .Parameters.Add("@WeigthUnit", SqlDbType.NVarChar).Value = txtWeightUnit.Text.Trim()
        '        If dcbStatus.Text = "Goods Complete" Then
        '            .Parameters.Add("@DamageQuantity", SqlDbType.Decimal).Value = 0
        '            .Parameters.Add("@AvalableQuantity", SqlDbType.Decimal).Value = CDbl(txtAQty.Text).ToString("#,##0.000")
        '        ElseIf dcbStatus.Text = "Goods Damage" Then
        '            .Parameters.Add("@DamageQuantity", SqlDbType.Decimal).Value = CDbl(txtDamageQTY.Text).ToString("#,##0.000")
        '            .Parameters.Add("@AvalableQuantity", SqlDbType.Decimal).Value = 0
        '        End If
        '        .Parameters.Add("@Type", SqlDbType.NVarChar).Value = dcbStatus.Text.Trim()
        '        .Parameters.Add("@TypeDamage", SqlDbType.NVarChar).Value = dcbTypeDamage.Text.Trim()
        '        Dim result As Integer
        '        result = .ExecuteNonQuery()
        '        If result = 0 Then
        '            tr.Rollback()
        '            MessageBox.Show("WHStockMovement ที่คุณใส่ ไม่ถูกต้อง !!!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            txtLotNo.SelectAll()
        '        Else
        '            tr.Commit()
        '        End If
        '    End With
        'Catch ex As Exception
        '    tr.Rollback()
        '    MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก " & ex.Message, "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
        ''End If
        'txtLotNo.Focus()

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
