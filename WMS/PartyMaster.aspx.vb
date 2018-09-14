Option Explicit On
Option Strict On
Option Infer On


Imports System.Transactions

Public Class PartyMaster
    Inherits System.Web.UI.Page
   
    Dim tmpButtonStatus As String
    Dim sqlDataComboList As String
    Dim CommissionToSales As String = "1"
    Dim PartyStatus As String
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
    Dim db As New LKBWarehouseEntities1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            showAddressType()
            showAreaCode()
            showCity()
            showLocation()
            showPartyType()
        End If
    End Sub
    Private Sub showLocation()
        cboLocationID.Items.Clear()
        cboLocationID.Items.Add(New ListItem("--Select Country-", ""))
        cboLocationID.AppendDataBoundItems = True

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
        cboCity.Items.Clear()
        cboCity.Items.Add(New ListItem("--Select City--", ""))
        cboCity.AppendDataBoundItems = True

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
        cboPartyType.Items.Clear()
        cboPartyType.Items.Add(New ListItem("--Select Type--", ""))
        cboPartyType.AppendDataBoundItems = True

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
        cboAddressType.Items.Clear()
        cboAddressType.Items.Add(New ListItem("--Select Address--", ""))
        cboAddressType.AppendDataBoundItems = True
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
        cboAreaCode.Items.Clear()
        cboAreaCode.Items.Add(New ListItem("--Select Area--", ""))
        cboAreaCode.AppendDataBoundItems = True

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
    Private Sub addParty()

        'If chkCommissiontoSale.Checked = True Then
        '    CommissionToSales = "0"
        'Else
        '    CommissionToSales = "1"
        'End If
        '<---------------- เริ่ม ------------->

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

        'If rdbConfirm.Checked = True Then
        '    PartyStatus = "0"
        'Else
        '    PartyStatus = "4"
        'End If

        'If rdbPending.Checked = True Then
        '    PartyStatus = "1"
        'Else
        '    PartyStatus = "4"
        'End If


        'If rdbBlacklisted.Checked = True Then
        '    PartyStatus = "2"
        'Else
        '    PartyStatus = "4"
        'End If


        'If rdbRevoke.Checked = True Then
        '    PartyStatus = "3"
        'Else
        '    PartyStatus = "4"
        'End If
        '<------------- ถึงนี้ ------------>
       


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
                    db.tblParties.Add(New tblParty With { _
                                .PartyCode = txtPartyCode.Value, _
                                .PartyFullName = txtFullName.Value, _
                                .PartyLocalCode = txtLocalCode.Value, _
                                .PartyLocalName = txtLocalName.Value, _
                                .PartyLocation = cboLocationID.Text.Trim, _
                                .PartyCountry = cboCity.Text.Trim(), _
                                .RegistrationNo = txtRegistrationNo.Value, _
                                .PartyTypeCode = cboPartyType.Text.Trim, _
                                .PartyTypeName = txtTypeName.Value, _
                                .CommissionToSales = CommissionToSales, _
                                .IATACode = txtIATACode.Value, _
                                .Remarks = txtRemarks.Value, _
                                .PartyStatus = PartyStatus, _
                                .MessageHubID = txtMessageHubID.Value, _
                                .OtherSystemPartyID = txtOtherSystemPartyID.Value, _
                                .FormID = txtFormID.Value, _
                                .Shipper = RoleShipper, _
                                .Consignee = RoleConsignee, _
                                .Branch_Agent = RoleBranch_Agent, _
                                .Co_Loader = RoleCoLoader, _
                                .Trucking = RoleTrucking, _
                                .ShippingLine = RoleShippingLine, _
                                .Vendor = RoleVendor, _
                                .ContainerYard = RoleContainerYard, _
                                .Warehouse = RoleWarehouse, _
                                .Bank = RoleBank, _
                                .Factory = RoleFactory, _
                                .Customer = RoleConference, _
                                .Broker = RoleBroker, _
                                .AirLine = RoleAirline, _
                                .EndCustomer = RoleEndCustomer, _
                                .CreateBy = CStr(Session("UserName")), _
                                .CreateDate = Now(), _
                                .AmountGuarantee = CType(txtAmountGuarantee.Value, Decimal?)
                                      })
                    db.SaveChanges()
                    tran.Complete()
                    ClearDATA()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เพิ่ม Party สำเร็จ !');", True)
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                Finally
                    db.Database.Connection.Close()
                    db.Dispose()
                    tran.Dispose()
                End Try

            End Using

            Exit Sub
        End If

    End Sub

    Protected Sub btnAddParty_click(sender As Object, e As EventArgs)
        SaveDATA_New()
    End Sub

    Private Sub SaveDATA_New()
        Try
            Dim user = (From u In db.tblParties Where u.PartyCode = txtPartyCode.Value
          Select u).FirstOrDefault

            If Not user Is Nothing Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Party Code ซ้ำ กรุณาเปลี่ยนใหม่');", True)
            Else
                addParty()
                Response.Write("<script>window.open('UserProlie.aspx,target='_self');</script>")
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด');", True)
        End Try
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs)
        ClearDATA()
    End Sub
End Class