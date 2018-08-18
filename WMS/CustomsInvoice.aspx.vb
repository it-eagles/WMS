Option Explicit On
Option Strict On


Public Class CustomsInvoice
    Inherits System.Web.UI.Page
    Dim classPermis As New ClassPermis

    Dim formName As String = "frmCustomsInvoice"
    Dim db As New LKBWarehouseEntities1_Test
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        If Not Me.IsPostBack Then
            If classPermis.CheckRead(formName, usename) = True Then
                If Not Me.IsPostBack Then
                    header_.Disabled = True
                    job_1.Disabled = True
                    deetail_.Disabled = True
                    list_.Disabled = True
                    btnSaveNew.Visible = False
                    btnSaveEdit.Visible = False
                    PurchaseCountry()
                    DestinationCountry()
                    Country()
                    TermofPayment()
                    Term()
                    TotalInvoice()
                    FreightCurrency()
                    ForwardingCurrency()
                    InsuranceCurrency()
                    PackingChargeCurrency()
                    ForeignInlandCurrency()
                    LandingChargeCharg()
                    OtherChargeCurrency()
                    ShipMode()
                    DeliveryTerm()
                    Brand()
                    NatureOfTrn()
                    PurchaseCtry()
                    OriginCtry()
                    InvUnit()
                    WeightUnit()
                    QuantityUnit()
                    Currency()
                    ForwardingCurrency1()
                    FreightCurrency1()
                    InsuranceCurrency1()
                    PackageChargeCurrency1()
                    ForeighnCurrency()
                    LandingChargeCurrency()
                    OtherChargeCurrency1()
                    ShippingMark()
                    ProductUnit1()
                    DriverName()
                    CarLicense()
                    UnitPLT()
                    CTN()
                    btnInvoice.Visible = False
                    TabName.Value = Request.Form(TabName.UniqueID)
                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
            End If
        End If
       
    End Sub

    Protected Sub btnAddNew_ServerClick(sender As Object, e As EventArgs)
        UnlockDATA()
        btnSaveNew.Visible = True
        btnSaveEdit.Visible = False
        btnInvoice.Visible = False
    End Sub

    Protected Sub btnEdit_ServerClick(sender As Object, e As EventArgs)
        btnSaveNew.Visible = False
        btnSaveEdit.Visible = True
        btnInvoice.Visible = True
    End Sub
    Private Sub UnlockDATA()
        header_.Disabled = False

    End Sub

    Private Sub ClearDATA()
        'cdbFromprint.Text = ""
        'cbExchange.Checked = False
        'cbNoExchange.Checked = False
        'cbRefNo.Checked = False
        'cbNoRefNo.Checked = False
        'cbInland.Checked = False
        'cbNoInland.Checked = False
        'txtInland.Text = ""
        'txtApp.Text = ""
        'txtReferenceNo.Text = ""
        'txtInvoiceNo.Text = ""
        'txtPurechaseOrderNo.Text = ""
        'txtExporterCode.Text = ""
        'txtExportEng.Text = ""
        'txtStreet_Number.Text = ""
        'txtDistrict.Text = ""
        'txtSubProvince.Text = ""
        'txtProvince.Text = ""
        'txtPostCode.Text = ""
        'txtCompensateCode.Text = ""
        'txtConsignneeCode.Text = ""
        'txtConsignneeEng.Text = ""
        'txtConsignneeStreet_Number.Text = ""
        'txtConsignneeDistrict.Text = ""
        'txtConsignneeSubProvince.Text = ""
        'txtConsignneeProvince.Text = ""
        'txtConsignneePostCode.Text = ""
        'txtConsignneeEMail.Text = ""
        'dcboPurchaseCountry.Text = ""
        'txtPurchaseCountry.Text = ""
        'cboDestinationCountry.Text = ""
        'txtDestinationCountry.Text = ""
        'dcboCountry.Text = ""
        'txtCountry.Text = ""
        'dcboTermofPayment.Text = ""
        'dcboTerm.Text = ""
        'txtTotalNetWeight.Text = "0.0"
        'txtSumItemWeight.Text = "0.0"
        'dcboTotalInvoice.Text = ""
        'txtTotalInvoiceAmount.Text = "0.0"
        'txtTotalInvoiceAmount1.Text = "0.0"
        'dcboForwarding.Text = ""
        'txtForwardingAmount.Text = "0.0"
        'txtForwardingAmount1.Text = "0.0"
        'dcboFreight.Text = ""
        'txtFreightAmount.Text = "0.0"
        'txtFreightAmount1.Text = "0.0"
        'dcboInsurance.Text = ""
        'txtInsuranceAmount.Text = "0.0"
        'txtInsuranceAmount1.Text = "0.0"
        'dcboPackingCharge.Text = ""
        'txtPackingChargeAmount.Text = "0.0"
        'txtPackingChargeAmount1.Text = "0.0"
        'dcboForeignInland.Text = ""
        'txtForeignInlandAmount.Text = "0.0"
        'txtForeignInlandAmount1.Text = "0.0"
        'dcboLandingCharge.Text = ""
        'txtLandingChargeAmount.Text = "0.0"
        'txtLandingChargeAmount1.Text = "0.0"
        'dcboOtherCharge.Text = ""
        'txtOtherChargeAmount.Text = "0.0"
        'txtOtherChargeAmount1.Text = "0.0"
        'txtEASExporterCode.Text = ""
        'txtEASNameEng.Text = ""
        'txtEASStreet_Number.Text = ""
        'txtEASDistrict.Text = ""
        'txtEASSubProvince.Text = ""
        'txtEASProvince.Text = ""
        'txtEASPostCode.Text = ""
        'txtEASCompensateCode.Text = ""
        'txtEASPostCode.Text = ""
        'txtCustomerCode.Text = ""
        'txtCustomerEng.Text = ""
        'txtCustomerAddress.Text = ""
        'txtCustomerEMail.Text = ""
        'txtCustomerTelNo.Text = ""
        'txtCustomerFaxNo.Text = ""
        'txtCustomerContactPerson.Text = ""
        'txtEASInvREFNo.Text = ""
        'txtEASLOTNo.Text = ""
        'txtCustomerRefNo.Text = "0"
        'txtSpecialInstruction.Text = ""
        'dcboShipMode.Text = ""
        'dcboDeliveryTerm.Text = ""
        'dcboShippingMark.Text = ""
        'txtEASRemark.Text = ""
        'txtTotalCurrency.Text = ""
        'txtEASCustomerCode.Text = ""
        'txtEASCustomerEng1.Text = ""
        'txtEASCustomerAddress.Text = ""
        'txtEASEmail.Text = ""
        'txtEASTelNo.Text = ""
        'txtEASFaxNo.Text = ""
        'txtEASContactPerson.Text = ""
        'dcboBrand.Text = ""
        'txtProductYear.Text = ""
        'dcboNatureOfTrn.Text = ""
        'dcboPurchaseCtry.Text = ""
        'dcboOriginCtry.Text = ""
        'txtItemNo.Text = ""
        'txtProductCode.Text = ""
        'txtProductDesc1.Text = ""
        'txtProductDesc2.Text = ""
        'txtProductDesc3.Text = ""
        'txtInvQty.Text = ""
        'dcboInvQtyUnit.Text = ""
        'txtInvQtyUnit.Text = ""
        'dcboCurrency.Text = ""
        'txtExchangeRate.Text = "0.0"
        'txtWeight.Text = "0.0"
        'dcboWeightUnit.Text = ""
        'txtWeightUnit.Text = ""
        'txtPriceForeigh.Text = "0.0"
        'txtPriceForeighAmount.Text = "0.0"
        'txtQuantity.Text = "0.0"
        'dcboQuantityUnit.Text = ""
        'txtQuantityUnit.Text = ""
        'txtPriceBath.Text = "0.0"
        'txtPriceBathAmount.Text = "0.0"
        'txtTariffCode.Text = ""
        'txtStatisticalCode.Text = ""
        'txtTariffSequence.Text = ""
        'txtProductAttribute1.Text = ""
        'txtProductAttribute2.Text = ""
        'txtPriceIncreaseForeign.Text = "0.0"
        'txtPriceIncreseBath.Text = "0.0"
        'txtDeclarationLine.Text = ""
        'txtFormulaNo.Text = ""
        'txtBOILicenseNo.Text = ""
        'txt19BisTransferNo.Text = ""
        'txtBondFurmulaNo.Text = ""
        'dcboForwardingCurrency.Text = ""
        'txtForwardingForiegnAmount.Text = "0.0"
        'txtForwardingExchangeRate.Text = "0.0"
        'txtForwardingBathAmount.Text = "0.0"
        'dcboFreight.Text = ""
        'txtFreightForiegnAmount.Text = "0.0"
        'txtFreightExchangeRate.Text = "0.0"
        'txtFreightBathAmount.Text = "0.0"
        'dcboInsurance.Text = ""
        'txtInsuranceForiegnAmount.Text = "0.0"
        'txtInsuranceExchangeRate.Text = "0.0"
        'txtInsuranceBathAmount.Text = "0.0"
        'dcboInsurance.Text = ""
        'txtInsuranceForiegnAmount.Text = "0.0"
        'txtInsuranceExchangeRate.Text = "0.0"
        'txtInsuranceBathAmount.Text = "0.0"
        'dcboPackingCharge.Text = ""
        'txtPackageChargeFoiegnAmount.Text = "0.0"
        'txtPackageChargeExchangeRate.Text = "0.0"
        'txtPackageChargeBathAmount.Text = "0.0"
        'dcboForeighnCurrency.Text = ""
        'txtForeighnForiegnAmount.Text = "0.0"
        'txtForeighnExchangeRate.Text = "0.0"
        'txtForeighnBathAmount.Text = "0.0"
        'dcboLandingCharge.Text = ""
        'txtLandingChargeForiegnAmount.Text = "0.0"
        'txtLandingChargeExchangeRate.Text = "0.0"
        'txtLandingChargeBathAmount.Text = "0.0"
        'dcboOtherCharge.Text = ""
        'txtOtherChargeForiegnAmount.Text = "0.0"
        'txtOtherChargeExchangeRate.Text = "0.0"
        'txtOtherChargeBathAmount.Text = "0.0"
        'txtItemRemark.Text = ""
        'txtPLTNetAmount.Text = "0.0"
        'dcboUnitPLT.Text = ""
        'txtPLTUnit.Text = ""
        'txtCTNNetAmount.Text = "0.0"
        'dcboCTN.Text = ""
        'txtCTNUnit.Text = ""
        'txtTotalGrossWeight.Text = "0.0"
        'txtTotalQuantity.Text = "0.0"
        'txtTotalQuantityINV.Text = "0.0"
        'txtVolumAmount.Text = "0.0"
        'txtTotalText.Text = ""
    End Sub
    Private Sub PurchaseCountry()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "COUNTRY"
                 Select q.Code, q.Type

        Try
            dcboPurchaseCountry.DataSource = qt.ToList
            dcboPurchaseCountry.DataTextField = "Code"
            dcboPurchaseCountry.DataValueField = "Code"
            dcboPurchaseCountry.DataBind()
            If dcboPurchaseCountry.Items.Count > 1 Then
                dcboPurchaseCountry.Enabled = True
            Else
                dcboPurchaseCountry.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DestinationCountry()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "COUNTRY"
                 Select q.Code, q.Type

        Try
            cboDestinationCountry.DataSource = qt.ToList
            cboDestinationCountry.DataTextField = "Code"
            cboDestinationCountry.DataValueField = "Code"
            cboDestinationCountry.DataBind()
            If cboDestinationCountry.Items.Count > 1 Then
                cboDestinationCountry.Enabled = True
            Else
                cboDestinationCountry.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Country()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "COUNTRY"
         Select q.Code, q.Type

        Try

            dcboCountry.DataSource = qt.ToList
            dcboCountry.DataTextField = "Code"
            dcboCountry.DataValueField = "Code"
            dcboCountry.DataBind()
            If dcboCountry.Items.Count > 1 Then
                dcboCountry.Enabled = True
            Else
                dcboCountry.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TermofPayment()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "PAYMENTTERM"
                        Select q.Code, q.Type

        Try

            dcboTermofPayment.DataSource = qt.ToList
            dcboTermofPayment.DataTextField = "Code"
            dcboTermofPayment.DataValueField = "Code"
            dcboTermofPayment.DataBind()
            If dcboTermofPayment.Items.Count > 1 Then
                dcboTermofPayment.Enabled = True
            Else
                dcboTermofPayment.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Term()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "INCOTERM"
                   Select q.Code, q.Type
        Try

            dcboTerm.DataSource = qt.ToList
            dcboTerm.DataTextField = "Code"
            dcboTerm.DataValueField = "Code"
            dcboTerm.DataBind()
            If dcboTerm.Items.Count > 1 Then
                dcboTerm.Enabled = True
            Else
                dcboTerm.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TotalInvoice()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
              Select q.Code, q.Type
        Try

            dcboTotalInvoice.DataSource = qt.ToList
            dcboTotalInvoice.DataTextField = "Code"
            dcboTotalInvoice.DataValueField = "Code"
            dcboTotalInvoice.DataBind()
            If dcboTotalInvoice.Items.Count > 1 Then
                dcboTotalInvoice.Enabled = True
            Else
                dcboTotalInvoice.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FreightCurrency()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
              Select q.Code, q.Type
        Try

            dcboFreight.DataSource = qt.ToList
            dcboFreight.DataTextField = "Code"
            dcboFreight.DataValueField = "Code"
            dcboFreight.DataBind()
            If dcboFreight.Items.Count > 1 Then
                dcboFreight.Enabled = True
            Else
                dcboFreight.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ForwardingCurrency()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
          Select q.Code, q.Type
        Try

            dcboForwarding.DataSource = qt.ToList
            dcboForwarding.DataTextField = "Code"
            dcboForwarding.DataValueField = "Code"
            dcboForwarding.DataBind()
            If dcboForwarding.Items.Count > 1 Then
                dcboForwarding.Enabled = True
            Else
                dcboForwarding.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InsuranceCurrency()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
         Select q.Code, q.Type
        Try

            dcboInsurance.DataSource = qt.ToList
            dcboInsurance.DataTextField = "Code"
            dcboInsurance.DataValueField = "Code"
            dcboInsurance.DataBind()
            If dcboInsurance.Items.Count > 1 Then
                dcboInsurance.Enabled = True
            Else
                dcboInsurance.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PackingChargeCurrency()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
        Select q.Code, q.Type
        Try

            dcboPackingCharge.DataSource = qt.ToList
            dcboPackingCharge.DataTextField = "Code"
            dcboPackingCharge.DataValueField = "Code"
            dcboPackingCharge.DataBind()
            If dcboPackingCharge.Items.Count > 1 Then
                dcboPackingCharge.Enabled = True
            Else
                dcboPackingCharge.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ForeignInlandCurrency()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
       Select q.Code, q.Type
        Try

            dcboForeignInland.DataSource = qt.ToList
            dcboForeignInland.DataTextField = "Code"
            dcboForeignInland.DataValueField = "Code"
            dcboForeignInland.DataBind()
            If dcboForeignInland.Items.Count > 1 Then
                dcboForeignInland.Enabled = True
            Else
                dcboForeignInland.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LandingChargeCharg()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
       Select q.Code, q.Type
        Try

            dcboLandingCharge.DataSource = qt.ToList
            dcboLandingCharge.DataTextField = "Code"
            dcboLandingCharge.DataValueField = "Code"
            dcboLandingCharge.DataBind()
            If dcboLandingCharge.Items.Count > 1 Then
                dcboLandingCharge.Enabled = True
            Else
                dcboLandingCharge.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OtherChargeCurrency()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
       Select q.Code, q.Type
        Try

            dcboOtherCharge.DataSource = qt.ToList
            dcboOtherCharge.DataTextField = "Code"
            dcboOtherCharge.DataValueField = "Code"
            dcboOtherCharge.DataBind()
            If dcboOtherCharge.Items.Count > 1 Then
                dcboOtherCharge.Enabled = True
            Else
                dcboOtherCharge.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ShipMode()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "TRANSMODE"
      Select q.Code, q.Type
        Try

            dcboShipMode.DataSource = qt.ToList
            dcboShipMode.DataTextField = "Code"
            dcboShipMode.DataValueField = "Code"
            dcboShipMode.DataBind()
            If dcboShipMode.Items.Count > 1 Then
                dcboShipMode.Enabled = True
            Else
                dcboShipMode.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DeliveryTerm()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "PAYMENTTERM"
      Select q.Code, q.Type
        Try

            dcboDeliveryTerm.DataSource = qt.ToList
            dcboDeliveryTerm.DataTextField = "Code"
            dcboDeliveryTerm.DataValueField = "Code"
            dcboDeliveryTerm.DataBind()
            If dcboDeliveryTerm.Items.Count > 1 Then
                dcboDeliveryTerm.Enabled = True
            Else
                dcboDeliveryTerm.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Brand()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "BRAND"
            Select q.Code, q.Type
        Try

            dcboBrand.DataSource = qt.ToList
            dcboBrand.DataTextField = "Code"
            dcboBrand.DataValueField = "Code"
            dcboBrand.DataBind()
            If dcboBrand.Items.Count > 1 Then
                dcboBrand.Enabled = True
            Else
                dcboBrand.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub NatureOfTrn()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "PAYMENTTERM"
            Select q.Code, q.Type
        Try

            dcboNatureOfTrn.DataSource = qt.ToList
            dcboNatureOfTrn.DataTextField = "Code"
            dcboNatureOfTrn.DataValueField = "Code"
            dcboNatureOfTrn.DataBind()
            If dcboNatureOfTrn.Items.Count > 1 Then
                dcboNatureOfTrn.Enabled = True
            Else
                dcboNatureOfTrn.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PurchaseCtry()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "COUNTRY"
           Select q.Code, q.Type
        Try

            dcboPurchaseCtry.DataSource = qt.ToList
            dcboPurchaseCtry.DataTextField = "Code"
            dcboPurchaseCtry.DataValueField = "Code"
            dcboPurchaseCtry.DataBind()
            If dcboPurchaseCtry.Items.Count > 1 Then
                dcboPurchaseCtry.Enabled = True
            Else
                dcboPurchaseCtry.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OriginCtry()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "COUNTRY"
           Select q.Code, q.Type
        Try

            dcboOriginCtry.DataSource = qt.ToList
            dcboOriginCtry.DataTextField = "Code"
            dcboOriginCtry.DataValueField = "Code"
            dcboOriginCtry.DataBind()
            If dcboOriginCtry.Items.Count > 1 Then
                dcboOriginCtry.Enabled = True
            Else
                dcboOriginCtry.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InvUnit()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT"
           Select q.Code, q.Type
        Try

            dcboInvQtyUnit.DataSource = qt.ToList
            dcboInvQtyUnit.DataTextField = "Code"
            dcboInvQtyUnit.DataValueField = "Code"
            dcboInvQtyUnit.DataBind()
            If dcboInvQtyUnit.Items.Count > 1 Then
                dcboInvQtyUnit.Enabled = True
            Else
                dcboInvQtyUnit.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub WeightUnit()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT"
          Select q.Code, q.Type
        Try

            dcboWeightUnit.DataSource = qt.ToList
            dcboWeightUnit.DataTextField = "Code"
            dcboWeightUnit.DataValueField = "Code"
            dcboWeightUnit.DataBind()
            If dcboWeightUnit.Items.Count > 1 Then
                dcboWeightUnit.Enabled = True
            Else
                dcboWeightUnit.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub QuantityUnit()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT"
          Select q.Code, q.Type
        Try

            dcboQuantityUnit.DataSource = qt.ToList
            dcboQuantityUnit.DataTextField = "Code"
            dcboQuantityUnit.DataValueField = "Code"
            dcboQuantityUnit.DataBind()
            If dcboQuantityUnit.Items.Count > 1 Then
                dcboQuantityUnit.Enabled = True
            Else
                dcboQuantityUnit.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Currency()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
         Select q.Code, q.Type
        Try

            dcboCurrency.DataSource = qt.ToList
            dcboCurrency.DataTextField = "Code"
            dcboCurrency.DataValueField = "Code"
            dcboCurrency.DataBind()
            If dcboCurrency.Items.Count > 1 Then
                dcboCurrency.Enabled = True
            Else
                dcboCurrency.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ForwardingCurrency1()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
         Select q.Code, q.Type
        Try

            dcboForwardingCurrency.DataSource = qt.ToList
            dcboForwardingCurrency.DataTextField = "Code"
            dcboForwardingCurrency.DataValueField = "Code"
            dcboForwardingCurrency.DataBind()
            If dcboForwardingCurrency.Items.Count > 1 Then
                dcboForwardingCurrency.Enabled = True
            Else
                dcboForwardingCurrency.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FreightCurrency1()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
        Select q.Code, q.Type
        Try

            dcboFreightCurrency.DataSource = qt.ToList
            dcboFreightCurrency.DataTextField = "Code"
            dcboFreightCurrency.DataValueField = "Code"
            dcboFreightCurrency.DataBind()
            If dcboFreightCurrency.Items.Count > 1 Then
                dcboFreightCurrency.Enabled = True
            Else
                dcboFreightCurrency.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InsuranceCurrency1()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
        Select q.Code, q.Type
        Try

            dcboInsuranceCurrency.DataSource = qt.ToList
            dcboInsuranceCurrency.DataTextField = "Code"
            dcboInsuranceCurrency.DataValueField = "Code"
            dcboInsuranceCurrency.DataBind()
            If dcboInsuranceCurrency.Items.Count > 1 Then
                dcboInsuranceCurrency.Enabled = True
            Else
                dcboInsuranceCurrency.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PackageChargeCurrency1()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
        Select q.Code, q.Type
        Try

            dcboPackageChargeCurrency.DataSource = qt.ToList
            dcboPackageChargeCurrency.DataTextField = "Code"
            dcboPackageChargeCurrency.DataValueField = "Code"
            dcboPackageChargeCurrency.DataBind()
            If dcboPackageChargeCurrency.Items.Count > 1 Then
                dcboPackageChargeCurrency.Enabled = True
            Else
                dcboPackageChargeCurrency.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ForeighnCurrency()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
            Select q.Code, q.Type
        Try

            dcboForeighnCurrency.DataSource = qt.ToList
            dcboForeighnCurrency.DataTextField = "Code"
            dcboForeighnCurrency.DataValueField = "Code"
            dcboForeighnCurrency.DataBind()
            If dcboForeighnCurrency.Items.Count > 1 Then
                dcboForeighnCurrency.Enabled = True
            Else
                dcboForeighnCurrency.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LandingChargeCurrency()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
            Select q.Code, q.Type
        Try

            dcboLandingChargeCurrency.DataSource = qt.ToList
            dcboLandingChargeCurrency.DataTextField = "Code"
            dcboLandingChargeCurrency.DataValueField = "Code"
            dcboLandingChargeCurrency.DataBind()
            If dcboLandingChargeCurrency.Items.Count > 1 Then
                dcboLandingChargeCurrency.Enabled = True
            Else
                dcboLandingChargeCurrency.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OtherChargeCurrency1()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "CURRENCY"
           Select q.Code, q.Type
        Try

            dcboOtherChargeCurrency.DataSource = qt.ToList
            dcboOtherChargeCurrency.DataTextField = "Code"
            dcboOtherChargeCurrency.DataValueField = "Code"
            dcboOtherChargeCurrency.DataBind()
            If dcboOtherChargeCurrency.Items.Count > 1 Then
                dcboOtherChargeCurrency.Enabled = True
            Else
                dcboOtherChargeCurrency.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ShippingMark()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "SHIPMARK"
                Select q.Code, q.Type
        Try

            dcboShippingMark.DataSource = qt.ToList
            dcboShippingMark.DataTextField = "Code"
            dcboShippingMark.DataValueField = "Code"
            dcboShippingMark.DataBind()
            If dcboShippingMark.Items.Count > 1 Then
                dcboShippingMark.Enabled = True
            Else
                dcboShippingMark.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProductUnit1()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT"
                Select q.Code, q.Type
        Try

            dcboPackUnit.DataSource = qt.ToList
            dcboPackUnit.DataTextField = "Code"
            dcboPackUnit.DataValueField = "Code"
            dcboPackUnit.DataBind()
            If dcboPackUnit.Items.Count > 1 Then
                dcboPackUnit.Enabled = True
            Else
                dcboPackUnit.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DriverName()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "DRIVER"
               Select q.Description, q.Type
        Try

            dcboDriverName.DataSource = qt.ToList
            dcboDriverName.DataTextField = "Description"
            dcboDriverName.DataValueField = "Description"
            dcboDriverName.DataBind()
            If dcboDriverName.Items.Count > 1 Then
                dcboDriverName.Enabled = True
            Else
                dcboDriverName.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CarLicense()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "TRUCKLICENSE"
               Select q.Code, q.Type
        Try

            dcboCarLicense.DataSource = qt.ToList
            dcboCarLicense.DataTextField = "Code"
            dcboCarLicense.DataValueField = "Code"
            dcboCarLicense.DataBind()
            If dcboCarLicense.Items.Count > 1 Then
                dcboCarLicense.Enabled = True
            Else
                dcboCarLicense.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FromInvoice()
        'Dim qt = From q In db.tblMasterCode2 Where q.Type = "TRUCKLICENSE"
        '      Select q.Code, q.Type
        'Try

        '    dcboFromInvoice.DataSource = qt.ToList
        '    dcboFromInvoice.DataTextField = "InvoiceNo"
        '    dcboFromInvoice.DataValueField = "InvoiceNo"
        '    dcboFromInvoice.DataBind()
        '    If dcboFromInvoice.Items.Count > 1 Then
        '        dcboFromInvoice.Enabled = True
        '    Else
        '        dcboFromInvoice.Enabled = False
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
    Private Sub ToInvoice()
        'Dim qt = From q In db.tblMasterCode2 Where q.Type = "TRUCKLICENSE"
        '      Select q.Code, q.Type
        'Try

        '    dcboToInvoice.DataSource = qt.ToList
        '    dcboToInvoice.DataTextField = "InvoiceNo"
        '    dcboToInvoice.DataValueField = "InvoiceNo"
        '    dcboToInvoice.DataBind()
        '    If dcboToInvoice.Items.Count > 1 Then
        '        dcboToInvoice.Enabled = True
        '    Else
        '        dcboToInvoice.Enabled = False
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
    Private Sub UnitPLT()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT"
              Select q.Code, q.Type
        Try

            dcboUnitPLT.DataSource = qt.ToList
            dcboUnitPLT.DataTextField = "Code"
            dcboUnitPLT.DataValueField = "Code"
            dcboUnitPLT.DataBind()
            If dcboUnitPLT.Items.Count > 1 Then
                dcboUnitPLT.Enabled = True
            Else
                dcboUnitPLT.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CTN()
        Dim qt = From q In db.tblMasterCode2 Where q.Type = "UNIT"
              Select q.Code, q.Type
        Try

            dcboCTN.DataSource = qt.ToList
            dcboCTN.DataTextField = "Code"
            dcboCTN.DataValueField = "Code"
            dcboCTN.DataBind()
            If dcboCTN.Items.Count > 1 Then
                dcboCTN.Enabled = True
            Else
                dcboCTN.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnInvoice_ServerClick(sender As Object, e As EventArgs)

        'ScriptManager.RegisterStartupScript(upSearch1, upSearch1.GetType(), "show", "$(function () { $('#" + Search1.ClientID + "').modal('show'); });", True)
        'upSearch1.Update()
        selectInvoiceNo()
    End Sub

    Protected Sub btnShipper_ServerClick(sender As Object, e As EventArgs)

    End Sub
    Private Sub selectInvoiceNo()
        Dim gro_code As String
        Dim UserGroup As String = CStr(Session("UserGroup"))
        Dim cra As Integer
        If String.IsNullOrEmpty(txtInvoiceNo.Value.Trim) Then
            gro_code = ""
            cra = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            gro_code = txtInvoiceNo.Value.Trim

        End If
        If UserGroup = "SA" Then
            Dim cons = From p In db.tblExpInvoices Where p.InvoiceNo = gro_code Or p.CreateDate.Year = cra
                 Order By p.InvoiceNo Descending
                 Select p.InvoiceNo, p.ReferenceNo, p.PurchaseOrderNo, p.ExporterCode
            If cons.Count > 0 Then
                dgvSearch.DataSource = cons.ToList
                dgvSearch.DataBind()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
                Exit Sub
            End If
        Else
            Dim cons = From p In db.tblExpInvoices Where (p.InvoiceNo = gro_code And p.App = "Wait") Or p.App = "Wait" And p.CreateDate.Year = cra
               Order By p.InvoiceNo Descending
               Select p.InvoiceNo, p.ReferenceNo, p.PurchaseOrderNo, p.ExporterCode
            If cons.Count > 0 Then
                dgvSearch.DataSource = cons.ToList
                dgvSearch.DataBind()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
                Exit Sub
            End If
        End If
    End Sub

   
    Protected Sub dgvSearch_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim Invoice As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("selectInvoiceNo") Then
            Dim exp = (From ex In db.tblExpInvoices Where ex.InvoiceNo = Invoice Select ex).SingleOrDefault

            txtInvoiceNo.Value = exp.InvoiceNo
            txtReferenceNo.Value = exp.ReferenceNo
            'txtReferenceDate
            dtpReferenceDate.Text = CStr(exp.ReferenceDate)
            txtPurechaseOrderNo.Value = exp.PurchaseOrderNo
            'txtInvoiceDate()
            dtpInvoiceDate.Text = CStr(exp.InvoiceDate)
            'txtDeliveryDate()
            dtpDeliveryDate.Text = CStr(exp.DeliveryDate)
            txtExporterCode.Value = exp.ExporterCode

            txtExportEng.Value = exp.ExporterENG
            txtStreet_Number.Value = exp.Street_Number
            txtDistrict.Value = exp.District
            'txtSubProvince = exp.Subprovince

            txtProvince.Value = exp.Province
            txtPostCode.Value = exp.PostCode
            txtCompensateCode.Value = exp.CompensateCode
            txtConsigneeCode.Value = exp.CompensateCode
            'txtConsignneeCode.Value = exp.ConsignneeCode
            'txtConsignneeEng.Value=exp.ConsignneeENG
            '=exp.ConsignneeStreet_Number
            '=exp.ConsignneeDistrict
            '=exp.ConsignneeSubProvince
            '=exp.ConsignneeProvince
            '=exp.ConsignneePostCode
            '=exp.ConsignneeEMail
            '=exp.PurchaseCountryCode
            '=exp.PurchaseCountryName
            '=exp.DestinationCountryCode
            '=exp.DestinationCountryName
            '=exp.CountryCode
            '=exp.CountryName
            '=exp.TermOfPayment
            '=exp.Term
            '=exp.TotalNetWeight
            '=exp.SumItemWeight
            '=exp.TotalInvoiceCurrency
            '=exp.TotalInvoiceAmount
            '=exp.TotalInvoiceAmount1
            '=exp.ForwardingCurrency
            '=exp.ForwardingAmount
            '=exp.ForwardingAmount1
            '=exp.FreightCurrency
            '=exp.FreightAmount
            '=exp.FreightAmount1
            '=exp.InsuranceCurrency
            '=exp.InsuranceAmount
            '=exp.InsuranceAmount1
            '=exp.PackingChargeCurrency
            '=exp.PackingChargeAmount
            '=exp.PackingChargeAmount1
            '=exp.ForeignInlandCurrency
            '=exp.ForeignInlandAmount
            '=exp.ForeignInlandAmount1
            '=exp.LandingChargeCurrency
            '=exp.LandingChargeAmount
            '=exp.LandingChargeAmount1
            '=exp.OtherChargeCurrency
            '=exp.OtherChargeAmount
            '=exp.OtherChargeAmount1
            '=exp.TransmitDate
            '=exp.DiffBy
            '=exp.TermforShip
            '=exp.OnbehalfStatus
            '=exp.EASExporterCode
            '=exp.EASNameEng
            '=exp.StreetAndNumber
            '=exp.ESADistrict
            '=exp.EASSubProvince
            '=exp.EASProvince
            '=exp.EASPostCode
            '=exp.EASTCompensete
            '=exp.EASCustomerCode
            '=exp.EASCustomerENG
            '=exp.EASCustomerAddress
            '=exp.EASCustomerEMail
            '=exp.EASCustomerTelNo
            '=exp.EASCustomerFaxNo
            '=exp.EASCustomerContactPerson
            '=exp.EASInvRefNo
            '=exp.EASLOTNo
            '=exp.EASCustomerRefNo
            '=exp.EASSpecialInstruction
            '=exp.EASDeliveryTerm
            '=exp.EASShippingMark
            '=exp.EASShippingMarkCompany
            '=exp.EASShippingMarkAddress
            '=exp.EASRemark
            '=exp.EASTotalCurrency
            '=exp.EASBilltoCustomerCode
            '=exp.EASBilltoCustomerENG
            '=exp.EASBilltoCustomerAddress
            '=exp.EASBilltoCustomerEMail
            '=exp.EASBilltoCustomerTelNo
            '=exp.EASBilltoCustomerFaxNo
            '=exp.EASBilltoCustomerContactPerson
            '=exp.PLTNetAmount
            '=exp.UnitPLT
            '=exp.CTNPLTName
            '=exp.CTNNetAmount
            '=exp.UnitCTN
            '=exp.UnitCTNName
            '=exp.GrossWeightAmount
            '=exp.QountityAmount
            '=exp.VolumAmount
            '=exp.TotalTextPackL()
            '=exp.CarLicense
            '=exp.DriverName
            '=exp.PrintCountInv
            '=exp.PrintCountPack
            '=exp.PrintCount107
            '=exp.PrintCount108
            '=exp.PrintCountDoc
            '=exp.CustomsConfirmDate
            '=exp.App
            '=exp.CreateBy
            '=exp.CreateDate
            '=exp.UpdateBy
            '=exp.UpdateDate
            '=exp.OutItem
            '=exp.PullSignal
            '=exp.UnitQuantity
            '=exp.UnitWeight


            'txtConsignneeStreet_Number.Value
            'txtConsignneeDistrict.Value
            'txtConsignneeSubProvince.Value
            'txtConsignneeProvince.Value
            'txtConsignneePostCode.Value
            'txtConsignneeEMail.Value
            'dcboPurchaseCountry.Value
            'txtPurchaseCountry.Value
            'cboDestinationCountry.Text
            'txtDestinationCountry.Value
            'dcboCountry.Text
            'txtCountry.Value
            'dcboTermofPayment.Value
            'dcboTerm.Text 
            'txtTotalNetWeight.Value
            'txtSumItemWeight.Value
            'dcboTotalInvoice.Value 
            'txtTotalInvoiceAmount.Value 
            'txtTotalInvoiceAmount1.Value
            'dcboForwarding.Value
            'txtForwardingAmount.Value
            'txtForwardingAmount1.Value
            'dcboFreight.Value
            'txtFreightAmount.Value 
            'txtFreightAmount1.Value
            'dcboInsurance.Value
            'txtInsuranceAmount.Value
            'txtInsuranceAmount1.Value
            'dcboPackingCharge.Value
            'txtPackingChargeAmount.Value
            'txtPackingChargeAmount1.Value
            'dcboForeignInland.Value
            'txtForeignInlandAmount.Value 
            'txtForeignInlandAmount1.Value
            'dcboLandingCharge.Value
            'txtLandingChargeAmount.Value
            'txtLandingChargeAmount1.Value
            'dcboOtherCharge.Value
            'txtOtherChargeAmount.Value
            'txtOtherChargeAmount1..Value
            'txtTransmitDate.Value
            'dtpTransmitDate.Text
            'txtDiffBy.Value
            'If txtDiffBy.Text = "Diff by items-amount" Then
            '    optDiffAmount.Checked = True
            'End If
            'If txtDiffBy.Text = "Diff by items-Weight" Then
            '    optDiffweight.Checked = True
            'End If
            'txtNotify.Text = .Rows.Item(e.RowIndex).Cells(58).Value.ToString()
            'If txtNotify.Text = "Notfy Party" Then
            '    optNotifyParty.Checked = True
            'End If
            'If txtNotify.Text = "On Behalf of" Then
            '    optOnbehalfOf.Checked = True
            'End If
            'txtOnbehalfStatus.Text = .Rows.Item(e.RowIndex).Cells(59).Value.ToString()
            'If txtOnbehalfStatus.Text = "Enable On behalf of" Then
            '    ckbOnbehalfof.Checked = True
            'Else
            '    ckbOnbehalfof.Checked = False
            'End If
            'txtEASExporterCode.Text
            'txtEASNameEng.Text 
            'txtEASStreet_Number.Text
            'txtEASDistrict.Text 
            'txtEASSubProvince.Text
            'txtEASProvince.Text 
            'txtEASPostCode.Text 
            'txtEASCompensateCode.Text 
            'txtCustomerCode.Text 
            'txtCustomerEng.Text 
            'txtCustomerAddress.Text
            'txtCustomerEMail.Text 
            'txtCustomerTelNo.Text 
            'txtCustomerFaxNo.Text 
            'txtCustomerContactPerson.Text 
            'txtEASInvREFNo.Text 
            'txtEASLOTNo.Text 
            'txtCustomerRefNo.Text 
            'txtSpecialInstruction.Text
            'dcboShipMode.Text 
            'dcboDeliveryTerm.Text
            'dcboShippingMark.Text 
            'txtShippingCompany.Text 
            'txtShippingAddress.Text 
            'txtEASRemark.Text 
            'txtTotalCurrency.Text 
            'txtEASCustomerCode.Text 
            'txtEASCustomerEng1.Text 
            'txtEASCustomerAddress.Text 
            'txtEASEmail.Text 
            'txtEASTelNo.Text
            'txtEASFaxNo.Text 
            'txtEASContactPerson.Text
            'txtPLTNetAmount.Text 
            'dcboUnitPLT.Text 
            'txtPLTUnit.Text
            'txtCTNNetAmount.Text
            'dcboCTN.Text 
            'txtCTNUnit.Text 
            'txtTotalGrossWeight.Text 
            'txtTotalQuantity.Text 
            'txtVolumAmount.Text
            'txtTotalText.Text 
            'dcboCarLicense.Text 
            'dcboDriverName.Text 
            'txtCustomsConfirmDate.Text
            'CustomsConfirmDate.Value
            'txtApp.Text 
            'Item 
            'If Item = "0" Then
            '    CoutItem.Checked = False
            'ElseIf Item = "1" Then
            '    CoutItem.Checked = True
            'End If

        End If
    End Sub
End Class