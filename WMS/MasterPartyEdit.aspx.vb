
Imports System.Transactions
Public Class MasterPartyEdit
    Inherits System.Web.UI.Page

    Dim tmpButtonStatus As String
    Dim sqlDataComboList As String
    Dim CommissionToSales As String = "1"
    Dim PartyStatus As String = "4"
    Dim RoleShipper As String = "1"
    Dim RoleConsignee As String = "1"
    Dim RoleBranch_Agent As String = "1"
    Dim RoleCoLoader As String = "1"
    Dim RoleTrucking As String = "1"
    Dim RoleShippingLine As String = "1"
    Dim RoleVendor As String = "1"
    Dim RoleContainerYard As String = "1"
    Dim RoleWarehouse As String = "1"
    Dim RoleBank As String = "1"
    Dim RoleFactory As String = "1"
    Dim RoleConference As String = "1"
    Dim RoleBroker As String = "1"
    Dim RoleAirline As String = "1"
    Dim RoleEndCustomer As String = "1"
    'Dim db As New LKBwarehouseEntities
    Dim db As New LKBWarehouseEntities1_Test
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            showAddressType()
            showAreaCode()
            showCity()
            showLocation()
            showPartyType()
            showTxt()
        End If
    End Sub
    Private Sub showTxt()
        Dim PartyCode As String = Request.QueryString("PartyCode")
        Dim code = (From u In db.tblParties Where u.PartyCode = PartyCode).SingleOrDefault

        If code.CommissionToSales = "0" Then
            chkCommissiontoSale.Checked = True
        End If
        If code.CommissionToSales = "1" Then
            chkCommissiontoSale.Checked = False
        End If

        If code.PartyStatus = "0" Then
            rdbConfirm_.Checked = True
        End If
        If code.PartyStatus = "4" Then
            rdbConfirm_.Checked = False
        End If

        If code.PartyStatus = "1" Then
            rdbPending_.Checked = True
        End If
        If code.PartyStatus = "4" Then
            rdbPending_.Checked = False
        End If

        If code.PartyStatus = "2" Then
            rdbBlacklisted_.Checked = True
        End If
        If code.PartyStatus = "4" Then
            rdbBlacklisted_.Checked = False
        End If

        If code.PartyStatus = "3" Then
            rdbRevoke_.Checked = True
        End If
        If code.PartyStatus = "4" Then
            rdbRevoke_.Checked = False
        End If

        If code.Shipper = "0" Then
            chkShipper.Checked = True
        Else
        End If
        If code.Shipper = "1" Then
            chkShipper.Checked = False
        End If

        If code.Consignee = "0" Then
            chkConsignee.Checked = True
        Else
        End If
        If code.Consignee = "1" Then
            chkConsignee.Checked = False
        End If

        If code.Branch_Agent = "0" Then
            chkBranch.Checked = True
        Else
        End If
        If code.Branch_Agent = "1" Then
            chkBranch.Checked = False
        End If


        If code.Co_Loader = "0" Then
            chkCoLoader.Checked = True
        End If
        If code.Co_Loader = "1" Then
            chkCoLoader.Checked = False
        End If

        If code.Trucking = "0" Then
            chkTrucking.Checked = True
        End If
        If code.Trucking = "1" Then
            chkTrucking.Checked = False
        End If


        If code.ShippingLine = "0" Then
            chkShippingLine.Checked = True
        End If
        If code.ShippingLine = "1" Then
            chkShippingLine.Checked = False
        End If

        If code.Vendor = "0" Then
            chkVendor.Checked = True
        Else
        End If
        If code.Vendor = "1" Then
            chkVendor.Checked = False
        End If


        If code.ContainerYard = "0" Then
            chkContainerYard.Checked = True
        End If
        If code.ContainerYard = "1" Then
            chkContainerYard.Checked = False
        End If

        If code.Warehouse = "0" Then
            chkWarehouse.Checked = True
        End If
        If code.Warehouse = "1" Then
            chkWarehouse.Checked = False
        End If

        If code.Bank = "0" Then
            chkBank.Checked = True
        End If
        If code.Bank = "1" Then
            chkBank.Checked = False
        End If

        If code.Factory = "0" Then
            chkFactory.Checked = True
        End If
        If code.Factory = "1" Then
            chkFactory.Checked = False
        End If

        If code.Customer = "0" Then
            chkConference.Checked = True
        End If
        If code.Customer = "1" Then
            chkConference.Checked = False
        End If

        If code.Broker = "0" Then
            chkBroker.Checked = True
        End If
        If code.Broker = "1" Then
            chkBroker.Checked = False
        End If

        If code.AirLine = "0" Then
            chkAirLine.Checked = True
        End If
        If code.AirLine = "1" Then
            chkAirLine.Checked = False

        End If

        If code.EndCustomer = "0" Then
            chkEndCustomer.Checked = True
        End If
        If code.EndCustomer = "1" Then
            chkEndCustomer.Checked = False
        End If

        txtPartyCode.Value = code.PartyCode
        txtFullName.Value = code.PartyFullName
        txtLocalCode.Value = code.PartyLocalCode
        txtLocalName.Value = code.PartyLocalName

        txtRegistrationNo.Value = code.RegistrationNo

        txtTypeName.Value = code.PartyTypeName

        txtIATACode.Value = code.IATACode
        txtRemarks.Value = code.Remarks

        txtMessageHubID.Value = code.MessageHubID
        txtOtherSystemPartyID.Value = code.OtherSystemPartyID
        txtFormID.Value = code.FormID
   
        '.CreateBy = CStr(Session("UserName"))
        '.CreateDate = Now()
        txtAmountGuarantee.Value = code.AmountGuarantee

    End Sub

    Private Sub showLocation()
        'cboLocationID.Items.Clear()
        'cboLocationID.Items.Add(New ListItem("--Select Country-", ""))
        'cboLocationID.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCode2 Where g.Type = "COUNTRY"
                  Select g.Type, g.Code

        Try

            cboLocationID.DataSource = gg.ToList
            cboLocationID.DataTextField = "Code"
            cboLocationID.DataValueField = "Code"
            cboLocationID.DataBind()

            If cboLocationID.Items.Count > 1 Then
                cboLocationID.Enabled = True
            Else
                cboLocationID.Enabled = False

            End If
        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub showCity()
        'cboCity.Items.Clear()
        'cboCity.Items.Add(New ListItem("--Select City--", ""))
        'cboCity.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCode2 Where g.Type = "CITY"
                  Select g.Type, g.Code
        Try
            cboCity.DataSource = gg.ToList
            cboCity.DataTextField = "Code"
            cboCity.DataValueField = "Code"
            cboCity.DataBind()
            If cboCity.Items.Count > 1 Then
                cboCity.Enabled = True
            Else
                cboCity.Enabled = False

            End If
        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub showPartyType()
        'cboPartyType.Items.Clear()
        'cboPartyType.Items.Add(New ListItem("--Select Type--", ""))
        'cboPartyType.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCode2 Where g.Type = "PARTYTYPE"
                  Select g.Type, g.Code
        Try
            cboPartyType.DataSource = gg.ToList
            cboPartyType.DataTextField = "Code"
            cboPartyType.DataValueField = "Code"
            cboPartyType.DataBind()
            If cboPartyType.Items.Count > 1 Then
                cboPartyType.Enabled = True

            Else
                cboPartyType.Enabled = False

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub showAddressType()
        'cboAddressType.Items.Clear()
        'cboAddressType.Items.Add(New ListItem("--Select Address--", ""))
        'cboAddressType.AppendDataBoundItems = True
        Dim cu = From c In db.tblMasterCode2 Where c.Type = "PARTYTYPE"
         Select c.Type, c.Code
        Try
            cboAddressType.DataSource = cu.ToList
            cboAddressType.DataTextField = "Code"
            cboAddressType.DataValueField = "Code"
            cboAddressType.DataBind()
            If cboAddressType.Items.Count > 1 Then
                cboAddressType.Enabled = True
            Else
                cboAddressType.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub showAreaCode()
        'cboAreaCode.Items.Clear()
        'cboAreaCode.Items.Add(New ListItem("--Select Area--", ""))
        'cboAreaCode.AppendDataBoundItems = True

        Dim cu = From c In db.tblMasterCode2 Where c.Type = "AREACODE"
         Select c.Type, c.Code
        Try
            cboAreaCode.DataSource = cu.ToList
            cboAreaCode.DataTextField = "Code"
            cboAreaCode.DataValueField = "Code"
            cboAreaCode.DataBind()
            If cboAreaCode.Items.Count > 1 Then
                cboAreaCode.Enabled = True
            Else
                cboAreaCode.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub ClearDATA()
        '************ TAB Information ****************
        txtPartyCode.Value = ""
        txtFullName.Value = ""
        txtLocalCode.Value = ""
        txtLocalName.Value = ""
        cboLocationID.Text = ""
        cboCity.Text = ""
        txtRegistrationNo.Value = ""
        cboPartyType.Text = ""
        txtTypeName.Value = ""
        chkCommissiontoSale.Checked = False
        txtIATACode.Value = ""
        txtRemarks.Value = ""
        rdbConfirm_.Checked = False
        rdbPending_.Checked = False
        rdbBlacklisted_.Checked = False
        rdbRevoke_.Checked = False
        txtMessageHubID.Value = ""
        txtOtherSystemPartyID.Value = ""
        txtFormID.Value = ""
        chkShipper.Checked = False
        chkConsignee.Checked = False
        chkBranch.Checked = False
        chkCoLoader.Checked = False
        chkTrucking.Checked = False
        chkShippingLine.Checked = False
        chkVendor.Checked = False
        chkContainerYard.Checked = False
        chkWarehouse.Checked = False
        chkBank.Checked = False
        chkFactory.Checked = False
        chkConference.Checked = False
        chkBroker.Checked = False
        chkAirLine.Checked = False
        chkEndCustomer.Checked = False
        cboAddressType.Text = ""
        txtAddress1.Value = ""
        txtAddress2.Value = ""
        txtAddress3.Value = ""
        txtAddress4.Value = ""
        txtZipCode.Value = ""
        cboAreaCode.Text = ""
        txtAttn.Value = ""
        txtTel.Value = ""
        txtFax.Value = ""
        txtWebsite.Value = ""
        txtEmail.Value = ""
        txtAmountGuarantee.Value = "0"
        txtAmountUsed.Value = "0"
        txtBalance.Value = "0"
        '**************** END of Function *****************

    End Sub

    Private Sub editParty()

        Dim PartyCode As String = Request.QueryString("PartyCode")

        If chkCommissiontoSale.Checked = True Then
            CommissionToSales = "0"
        Else
            CommissionToSales = "1"
        End If

        If rdbConfirm_.Checked = True Then
            PartyStatus = "0"
        ElseIf rdbPending_.Checked = True Then
            PartyStatus = "1"
        ElseIf rdbBlacklisted_.Checked = True Then
            PartyStatus = "2"
        ElseIf rdbRevoke_.Checked = True Then
            PartyStatus = "3"
        Else
            PartyStatus = "4"
        End If



        If chkShipper.Checked = True Then
            RoleShipper = "0"
        Else
            RoleShipper = "1"
        End If


        If chkConsignee.Checked = True Then
            RoleConsignee = "0"
        Else
            RoleConsignee = "1"
        End If

        If chkBranch.Checked = True Then
            RoleBranch_Agent = "0"
        Else
            RoleBranch_Agent = "1"
        End If


        If chkCoLoader.Checked = True Then
            RoleCoLoader = "0"
        Else
            RoleCoLoader = "1"
        End If



        If chkTrucking.Checked = True Then
            RoleTrucking = "0"
        Else
            RoleTrucking = "1"
        End If


        If chkShippingLine.Checked = True Then
            RoleShippingLine = "0"
        Else
            RoleShippingLine = "1"
        End If



        If chkVendor.Checked = True Then
            RoleVendor = "0"
        Else
            RoleVendor = "1"
        End If


        If chkContainerYard.Checked = True Then
            RoleContainerYard = "0"
        Else
            RoleContainerYard = "1"
        End If


        If chkWarehouse.Checked = True Then
            RoleWarehouse = "0"
        Else
            RoleWarehouse = "1"
        End If


        If chkBank.Checked = True Then
            RoleBank = "0"
        Else
            RoleBank = "1"
        End If



        If chkFactory.Checked = True Then
            RoleFactory = "0"
        Else
            RoleFactory = "1"
        End If



        If chkConference.Checked = True Then
            RoleConference = "0"
        Else
            RoleConference = "1"
        End If

        If chkBroker.Checked = True Then
            RoleBroker = "0"
        Else
            RoleBroker = "1"
        End If

        If chkAirLine.Checked = True Then
            RoleAirline = "0"
        Else
            RoleAirline = "1"
        End If

        If chkEndCustomer.Checked = True Then
            RoleEndCustomer = "0"
        Else
            RoleEndCustomer = "1"
        End If
        If (String.IsNullOrEmpty(txtPartyCode.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Party Code ก่อน !!!');", True)
            txtPartyCode.Focus()
        Else
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()
                    'db.tblParties.Add(New tblParty With {
                    '            .PartyCode = txtPartyCode.Value, _
                    '            .PartyFullName = txtFullName.Value, _
                    '            .PartyLocalCode = txtLocalCode.Value, _
                    '            .PartyLocalName = txtLocalName.Value, _
                    '            .PartyLocation = cboLocationID.Text.Trim, _
                    '            .PartyCountry = cboCity.Text.Trim(), _
                    '            .RegistrationNo = txtRegistrationNo.Value, _
                    '            .PartyTypeCode = cboPartyType.Text.Trim, _
                    '            .PartyTypeName = txtTypeName.Value, _
                    '            .CommissionToSales = CommissionToSales, _
                    '            .IATACode = txtIATACode.Value, _
                    '            .Remarks = txtRemarks.Value, _
                    '            .PartyStatus = PartyStatus, _
                    '            .MessageHubID = txtMessageHubID.Value, _
                    '            .OtherSystemPartyID = txtOtherSystemPartyID.Value, _
                    '            .FormID = txtFormID.Value, _
                    '            .Shipper = RoleShipper, _
                    '            .Consignee = RoleConsignee, _
                    '            .Branch_Agent = RoleBranch_Agent, _
                    '            .Co_Loader = RoleCoLoader, _
                    '            .Trucking = RoleTrucking, _
                    '            .ShippingLine = RoleShippingLine, _
                    '            .Vendor = RoleVendor, _
                    '            .ContainerYard = RoleContainerYard, _
                    '            .Warehouse = RoleWarehouse, _
                    '            .Bank = RoleBank, _
                    '            .Factory = RoleFactory, _
                    '            .Customer = RoleConference, _
                    '            .Broker = RoleBroker, _
                    '            .AirLine = RoleAirline, _
                    '            .EndCustomer = RoleEndCustomer, _
                    '            .CreateBy = CStr(Session("UserName")), _
                    '            .CreateDate = Now(), _
                    '            .AmountGuarantee = CType(txtAmountGuarantee.Value, Decimal?)
                    '                  })
                    Dim edit As tblParty = (From c In db.tblParties Where c.PartyCode = PartyCode Select c).First()
                    edit.PartyCode = txtPartyCode.Value
                    edit.PartyFullName = txtFullName.Value
                    edit.PartyLocalCode = txtLocalCode.Value
                    edit.PartyLocalName = txtLocalName.Value
                    edit.PartyLocation = cboLocationID.Text.Trim
                    edit.PartyCountry = cboCity.Text.Trim()
                    edit.RegistrationNo = txtRegistrationNo.Value
                    edit.PartyTypeCode = cboPartyType.Text.Trim
                    edit.PartyTypeName = txtTypeName.Value
                    edit.CommissionToSales = CommissionToSales
                    edit.IATACode = txtIATACode.Value
                    edit.Remarks = txtRemarks.Value
                    edit.PartyStatus = PartyStatus
                    edit.MessageHubID = txtMessageHubID.Value
                    edit.OtherSystemPartyID = txtOtherSystemPartyID.Value
                    edit.FormID = txtFormID.Value
                    edit.Shipper = RoleShipper
                    edit.Consignee = RoleConsignee
                    edit.Branch_Agent = RoleBranch_Agent
                    edit.Co_Loader = RoleCoLoader
                    edit.Trucking = RoleTrucking
                    edit.ShippingLine = RoleShippingLine
                    edit.Vendor = RoleVendor
                    edit.ContainerYard = RoleContainerYard
                    edit.Warehouse = RoleWarehouse
                    edit.Bank = RoleBank
                    edit.Factory = RoleFactory
                    edit.Customer = RoleConference
                    edit.Broker = RoleBroker
                    edit.AirLine = RoleAirline
                    edit.EndCustomer = RoleEndCustomer
                    'edit.CreateBy = CStr(Session("UserName"))
                    'edit.CreateDate = Now()
                    edit.AmountGuarantee = CType(txtAmountGuarantee.Value, Decimal?)
                    edit.UpdateBy = CStr(Session("UserId"))
                    edit.UpdateDate = Now
                    db.SaveChanges()
                    tran.Complete()
                    'ClearDATA()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไข Party สำเร็จ !');", True)
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                Finally
                    db.Database.Connection.Close()
                    db.Dispose()
                    tran.Dispose()
                End Try

            End Using


        End If

    End Sub
    Protected Sub btnAddParty_click(sender As Object, e As EventArgs)
        SaveDATA_New()
    End Sub

    Private Sub SaveDATA_New()
        Try
            '  Dim user = (From u In db.tblParties Where u.PartyCode = txtPartyCode.Value
            'Select u).FirstOrDefault

            '  If Not user Is Nothing Then
            '      ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Party Code ซ้ำ กรุณาเปลี่ยนใหม่');", True)
            '  Else
            editParty()
            Response.Write("<script>window.open('MasterPartyAdd.aspx');</script>")
            'End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด');", True)
        End Try
    End Sub
End Class