Option Explicit On
Option Strict On

Imports System.Globalization
Imports CrystalDecisions.CrystalReports.Engine


Public Class CustomsInvoice
    Inherits System.Web.UI.Page
    Dim classPermis As New ClassPermis
    Dim tmpButtonStatus As String
    Dim DiffBy As String
    Dim TermTransport As String
    Dim OnbehalfStatus As String
    Dim sqlDataComboList As String
    Dim TotalRecord As Integer
    Dim PageCount As Integer
    Dim CurrentPage As Integer
    Dim RecordToDisplay As Integer
    Dim PageSize As Integer
    Dim SumPLT As Integer = 0
    'Dim p As Point
    Dim CurrentProduct(10) As String
    Dim dtGenLotNo As DataTable
    'Public PV As New frmExpCustomsInvoiceRPT
    'Public PV1 As New frmExpCustomsInvoiceRPT1

    Dim formName As String = "frmCustomsInvoice"
    Dim db As New LKBWarehouseEntities1
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
                    Use.Disabled = True
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
        ClearDATA()
    End Sub

    Protected Sub btnEdit_ServerClick(sender As Object, e As EventArgs)
        btnSaveNew.Visible = False
        btnSaveEdit.Visible = True
        btnInvoice.Visible = True
        header_.Disabled = False
        job_1.Disabled = False
    End Sub
    Private Sub UnlockDATA()
        header_.Disabled = False
        job_1.Disabled = True
        deetail_.Disabled = True
        list_.Disabled = True
    End Sub

    Private Sub ClearDATA()
        'cdbFromprint. = ""
        'cbExchange.Checked = False
        'cbNoExchange.Checked = False
        'cbRefNo.Checked = False
        'cbNoRefNo.Checked = False
        'cbInland.Checked = False
        'cbNoInland.Checked = False
        'txtInland = ""
        'txtApp = ""
        txtReferenceNo.Value = ""
        txtInvoiceNo.Value = ""
        txtPurechaseOrderNo.Value = ""
        txtExporterCode.Value = ""
        txtExportEng.Value = ""
        txtStreet_Number.Value = ""
        txtDistrict.Value = ""
        txtSubProvince.Value = ""
        txtProvince.Value = ""
        txtPostCode.Value = ""
        txtCompensateCode.Value = ""
        txtConsigneeCode.Value = ""
        txtConsignneeEng.Value = ""
        txtConsignneeStreet_Number.Value = ""
        txtConsignneeDistrict.Value = ""
        txtConsignneeSubProvince.Value = ""
        txtConsignneeProvince.Value = ""
        txtConsignneePostCode.Value = ""
        txtConsignneeEMail.Value = ""
        'dcboPurchaseCountry.Text = ""
        txtPurchaseCountry.Value = ""
        'cboDestinationCountry.Text = ""
        txtDestinationCountry.Value = ""
        'dcboCountry.Text = ""
        txtCountry.Value = ""
        'dcboTermofPayment.Text = ""
        'dcboTerm.Text = ""
        txtTotalNetWeight.Value = "0.0"
        txtSumItemWeight.Value = "0.0"
        'dcboTotalInvoice.Text = ""
        txtTotalInvoiceAmount.Value = "0.0"
        txtTotalInvoiceAmount1.Value = "0.0"
        'dcboForwarding.Text = ""
        txtForwardingAmount.Value = "0.0"
        txtForwardingAmount1.Value = "0.0"
        'dcboFreight.Text = ""
        txtFreightAmount.Value = "0.0"
        txtFreightAmount1.Value = "0.0"
        'dcboInsurance.Text = ""
        txtInsuranceAmount.Value = "0.0"
        txtInsuranceAmount1.Value = "0.0"
        'dcboPackingCharge.Text = ""
        txtPackingChargeAmount.Value = "0.0"
        txtPackingChargeAmount1.Value = "0.0"
        'dcboForeignInland.Text = ""
        txtForeignInlandAmount.Value = "0.0"
        txtForeignInlandAmount1.Value = "0.0"
        'dcboLandingCharge.Text = ""
        txtLandingChargeAmount.Value = "0.0"
        txtLandingChargeAmount1.Value = "0.0"
        'dcboOtherCharge.Text = ""
        'txtOtherChargeAmount.Value = "0.0"
        'txtOtherChargeAmount1.Value = "0.0"
        txtEASExporterCode.Value = ""
        txtEASNameEng.Value = ""
        txtEASStreet_Number.Value = ""
        txtEASDistrict.Value = ""
        txtEASSubProvince.Value = ""
        txtEASProvince.Value = ""
        txtEASPostCode.Value = ""
        txtEASCompensateCode.Value = ""
        txtEASPostCode.Value = ""
        txtCustomerCode.Value = ""
        txtCustomerEng.Value = ""
        txtCustomerAddress.Value = ""
        txtCustomerEMail.Value = ""
        txtCustomerTelNo.Value = ""
        txtCustomerFaxNo.Value = ""
        txtCustomerContactPerson.Value = ""
        txtEASInvREFNo.Value = ""
        txtEASLOTNo.Value = ""
        txtCustomerRefNo.Value = "0"
        txtSpecialInstruction.Value = ""
        'dcboShipMode.Text = ""
        'dcboDeliveryTerm.Text = ""
        'dcboShippingMark.Text = ""
        txtEASRemark.Value = ""
        txtTotalCurrency.Value = ""
        txtEASCustomerCode.Value = ""
        txtEASCustomerEng1.Value = ""
        txtEASCustomerAddress.Value = ""
        txtEASEmail.Value = ""
        txtEASTelNo.Value = ""
        txtEASFaxNo.Value = ""
        txtEASContactPerson.Value = ""
        'dcboBrand.Text = ""
        'txtProductYear.Value = ""
        'dcboNatureOfTrn.Text = ""
        'dcboPurchaseCtry.Text = ""
        'dcboOriginCtry.Text = ""
        txtItemNo.Value = ""
        'txtProductCode.Value = ""
        txtProductDesc1.Value = ""
        txtProductDesc2.Value = ""
        txtProductDesc3.Value = ""
        txtInvQty.Value = ""
        'dcboInvQtyUnit.Text = ""
        txtInvQtyUnit.Value = ""
        'dcboCurrency.Text = ""
        txtExchangeRate.Value = "0.0"
        txtWeight.Value = "0.0"
        'dcboWeightUnit.Text = ""
        txtWeightUnit.Value = ""
        txtPriceForeigh.Value = "0.0"
        txtPriceForeighAmount.Value = "0.0"
        txtQuantity.Value = "0.0"
        'dcboQuantityUnit.Text = ""
        txtQuantityUnit.Value = ""
        txtPriceBath.Value = "0.0"
        txtPriceBathAmount.Value = "0.0"
        txtTariffCode.Value = ""
        txtStatisticalCode.Value = ""
        txtTariffSequence.Value = ""
        txtProductAttribute1.Value = ""
        txtProductAttribute2.Value = ""
        txtPriceIncreaseForeign.Value = "0.0"
        txtPriceIncreseBath.Value = "0.0"
        txtDeclarationLine.Value = ""
        'txtFormulaNo.Value = ""
        txtBOILicenseNo.Value = ""
        txt19BisTransferNo.Value = ""
        txtBondFurmulaNo.Value = ""
        'dcboForwardingCurrency.Text = ""
        txtForwardingForiegnAmount.Value = "0.0"
        txtForwardingExchangeRate.Value = "0.0"
        txtForwardingBathAmount.Value = "0.0"
        'dcboFreight.Text = ""
        'txtFreightForiegnAmount.Value = "0.0"
        txtFreightExchangeRate.Value = "0.0"
        txtFreightBathAmount.Value = "0.0"
        'dcboInsurance.Text = ""
        txtInsuranceForiegnAmount.Value = "0.0"
        txtInsuranceExchangeRate.Value = "0.0"
        txtInsuranceBathAmount.Value = "0.0"
        'dcboInsurance.Text = ""
        txtInsuranceForiegnAmount.Value = "0.0"
        txtInsuranceExchangeRate.Value = "0.0"
        txtInsuranceBathAmount.Value = "0.0"
        'dcboPackingCharge.Text = ""
        txtPackageChargeFoiegnAmount.Value = "0.0"
        txtPackageChargeExchangeRate.Value = "0.0"
        txtPackageChargeBathAmount.Value = "0.0"
        'dcboForeighnCurrency.Text = ""
        txtForeighnForiegnAmount.Value = "0.0"
        txtForeighnExchangeRate.Value = "0.0"
        txtForeighnBathAmount.Value = "0.0"
        'dcboLandingCharge.Text = ""
        txtLandingChargeForiegnAmount.Value = "0.0"
        txtLandingChargeExchangeRate.Value = "0.0"
        txtLandingChargeBathAmount.Value = "0.0"
        'dcboOtherCharge.Text = ""
        txtOtherChargeForiegnAmount.Value = "0.0"
        txtOtherChargeExchangeRate.Value = "0.0"
        txtOtherChargeBathAmount.Value = "0.0"
        txtItemRemark.Value = ""
        txtPLTNetAmount.Value = "0.0"
        'dcboUnitPLT.Text = ""
        txtPLTUnit.Value = ""
        txtCTNNetAmount.Value = "0.0"
        'dcboCTN.Text = ""
        txtCTNUnit.Value = ""
        txtTotalGrossWeight.Value = "0.0"
        txtTotalQuantity.Value = "0.0"
        txtTotalQuantityINV.Value = "0.0"
        txtVolumAmount.Value = "0.0"
        txtTotalText.Value = ""
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
        selectInvoiceNo()
    End Sub

    Protected Sub btnShipper_ServerClick(sender As Object, e As EventArgs)  
        selectExporter()
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
                ScriptManager.RegisterStartupScript(upSearch1, upSearch1.GetType(), "show", "$(function () { $('#" + plSearch1.ClientID + "').modal('show'); });", True)
                upSearch1.Update()
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
                ScriptManager.RegisterStartupScript(upSearch1, upSearch1.GetType(), "show", "$(function () { $('#" + plSearch1.ClientID + "').modal('show'); });", True)
                upSearch1.Update()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Customer Code นี้')", True)
                Exit Sub
            End If
        End If
    End Sub

    Protected Sub dgvSearch_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim referenceDate As String
        Dim Item As String
        Dim DiffBy As String
        Dim Notify As String
        Dim OnbehalfStatus As String
        Dim Invoice As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("selectInvoiceNo") Then
           
            Try
                Dim exp = (From ex In db.tblExpInvoices Where ex.InvoiceNo = Invoice Select ex).SingleOrDefault

                txtInvoiceNo.Value = exp.InvoiceNo
                txtReferenceNo.Value = exp.ReferenceNo
                referenceDate = Convert.ToDateTime(exp.ReferenceDate).ToString("dd/MM/yyyy")
                dtpReferenceDate.Text = CStr(DateTime.ParseExact(referenceDate, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")))
                txtPurechaseOrderNo.Value = exp.PurchaseOrderNo
                dtpInvoiceDate.Text = Convert.ToDateTime(exp.InvoiceDate).ToString("dd/MM/yyyy")
                dtpDeliveryDate.Text = Convert.ToDateTime(exp.DeliveryDate).ToString("dd/MM/yyyy")
                txtExporterCode.Value = exp.ExporterCode
                txtExportEng.Value = exp.ExporterENG
                txtStreet_Number.Value = exp.Street_Number
                txtDistrict.Value = exp.District
                txtSubProvince.Value = exp.Subprovince
                txtProvince.Value = exp.Province
                txtPostCode.Value = exp.PostCode
                txtCompensateCode.Value = exp.CompensateCode
                txtConsigneeCode.Value = exp.ConsignneeCode
                txtConsignneeEng.Value = exp.ConsignneeENG
                txtConsignneeStreet_Number.Value = exp.ConsignneeStreet_Number
                txtConsignneeDistrict.Value = exp.ConsignneeDistrict
                txtConsignneeSubProvince.Value = exp.ConsignneeSubProvince
                txtConsignneeProvince.Value = exp.ConsignneeProvince
                txtConsignneePostCode.Value = exp.ConsignneePostCode
                txtConsignneeEMail.Value = exp.ConsignneeEMail

                If String.IsNullOrEmpty(exp.PurchaseCountryCode) Then

                Else
                    dcboPurchaseCountry.Text = exp.PurchaseCountryCode
                End If
                txtPurchaseCountry.Value = exp.PurchaseCountryName

                If String.IsNullOrEmpty(exp.DestinationCountryCode) Then
                Else
                    cboDestinationCountry.Text = exp.DestinationCountryCode
                End If
                txtDestinationCountry.Value = exp.DestinationCountryName
                dcboCountry.Text = exp.CountryCode
                txtCountry.Value = exp.CountryName
                dcboTermofPayment.Text = exp.TermOfPayment
                dcboTerm.Text = exp.Term
                txtTotalNetWeight.Value = String.Format("{0:0.00}", exp.TotalNetWeight)
                txtSumItemWeight.Value = String.Format("{0:0.00}", exp.SumItemWeight)
                If String.IsNullOrWhiteSpace(exp.TotalInvoiceCurrency) Then

                Else
                    dcboTotalInvoice.Text = exp.TotalInvoiceCurrency
                End If

                txtTotalInvoiceAmount.Value = String.Format("{0:0.00}", exp.TotalInvoiceAmount)
                txtTotalInvoiceAmount1.Value = String.Format("{0:0.00}", exp.TotalInvoiceAmount1)

                If String.IsNullOrEmpty(exp.ForwardingCurrency) Then

                Else
                    dcboForwarding.Text = exp.ForwardingCurrency
                End If
                txtForwardingAmount.Value = String.Format("{0:0.00}", exp.ForwardingAmount)
                txtForwardingAmount1.Value = String.Format("{0:0.00}", exp.ForwardingAmount1)

                If String.IsNullOrEmpty(exp.FreightCurrency) Then

                Else

                    dcboFreight.Text = exp.FreightCurrency
                End If
                txtFreightAmount.Value = String.Format("{0:0.00}", exp.FreightAmount)
                txtFreightAmount1.Value = String.Format("{0:0.00}", exp.FreightAmount1)
                If String.IsNullOrEmpty(exp.InsuranceCurrency) Then

                Else
                    dcboInsurance.Text = exp.InsuranceCurrency
                End If
                txtInsuranceAmount.Value = String.Format("{0:0.00}", exp.InsuranceAmount)
                txtInsuranceAmount1.Value = String.Format("{0:0.00}", exp.InsuranceAmount1)

                If String.IsNullOrEmpty(exp.PackingChargeCurrency) Then

                Else
                    dcboPackingCharge.Text = exp.PackingChargeCurrency
                End If
                txtPackingChargeAmount.Value = String.Format("{0:0.00}", exp.PackingChargeAmount)
                txtPackingChargeAmount1.Value = String.Format("{0:0.00}", exp.PackingChargeAmount1)

                If String.IsNullOrEmpty(exp.ForeignInlandCurrency) Then

                Else
                    dcboForeignInland.Text = exp.ForeignInlandCurrency
                End If
                txtForeignInlandAmount.Value = String.Format("{0:0.00}", exp.ForeignInlandAmount)
                txtForeignInlandAmount1.Value = String.Format("{0:0.00}", exp.ForeignInlandAmount1)

                If String.IsNullOrEmpty(exp.LandingChargeCurrency) Then

                Else
                    dcboLandingCharge.Text = exp.LandingChargeCurrency
                End If
                txtLandingChargeAmount.Value = String.Format("{0:0.00}", exp.LandingChargeAmount)
                txtLandingChargeAmount1.Value = String.Format("{0:0.00}", exp.LandingChargeAmount1)

                If String.IsNullOrEmpty(exp.OtherChargeCurrency) Then

                Else
                    dcboOtherCharge.Text = exp.OtherChargeCurrency
                End If
                'txtOtherChargeAmount. = exp.OtherChargeAmount
                'txtOtherChargeAmount1.Value = exp.OtherChargeAmount1
                'dtpTransmitDate	TransmitDate
                DiffBy = exp.DiffBy
                If DiffBy = "Diff by items-amount" Then
                    rdbDiffAmount.Checked = True
                End If
                If DiffBy = "Diff by items-Weight" Then
                    rdbDiffWeight.Checked = True
                End If
                Notify = exp.TermforShip
                If Notify = "Notfy Party" Then
                    rdbNotifyParty.Checked = True
                End If
                If Notify = "On Behalf of" Then
                    rdbOnBehalfOf.Checked = True
                End If
                OnbehalfStatus = exp.OnbehalfStatus
                If OnbehalfStatus = "Enable On behalf of" Then
                    rdbOnBehalfOf.Checked = True
                Else
                    rdbOnBehalfOf.Checked = False
                End If

                txtEASExporterCode.Value = exp.EASExporterCode
                txtEASNameEng.Value = exp.EASNameEng
                txtEASStreet_Number.Value = exp.StreetAndNumber
                txtEASDistrict.Value = exp.ESADistrict
                txtEASSubProvince.Value = exp.EASSubProvince
                txtEASProvince.Value = exp.EASProvince
                txtEASPostCode.Value = exp.EASPostCode
                txtEASCompensateCode.Value = exp.EASTCompensete
                txtCustomerCode.Value = exp.EASCustomerCode
                txtCustomerEng.Value = exp.EASCustomerENG
                txtCustomerAddress.Value = exp.EASCustomerAddress
                txtCustomerEMail.Value = exp.EASCustomerEMail
                txtCustomerTelNo.Value = exp.EASCustomerTelNo
                txtCustomerFaxNo.Value = exp.EASCustomerFaxNo
                txtCustomerContactPerson.Value = exp.EASCustomerContactPerson
                txtEASInvREFNo.Value = exp.EASInvRefNo
                txtEASLOTNo.Value = exp.EASLOTNo
                txtCustomerRefNo.Value = String.Format("{0:0.00}", exp.EASCustomerRefNo)
                txtSpecialInstruction.Value = exp.EASSpecialInstruction

                If String.IsNullOrEmpty(exp.EASShipMode) Then

                Else
                    dcboShipMode.Text = exp.EASShipMode
                End If

                If String.IsNullOrEmpty(exp.EASDeliveryTerm) Then

                Else
                    dcboDeliveryTerm.Text = exp.EASDeliveryTerm
                End If

                If String.IsNullOrEmpty(exp.EASShippingMark) Then

                Else
                    dcboShippingMark.Text = exp.EASShippingMark
                End If
                txtShippingCompany.Value = exp.EASShippingMarkCompany
                txtShippingAddress.Value = exp.EASShippingMarkAddress
                txtEASRemark.Value = exp.EASRemark
                txtTotalCurrency.Value = exp.EASTotalCurrency
                txtEASCustomerCode.Value = exp.EASBilltoCustomerCode
                txtEASCustomerEng1.Value = exp.EASBilltoCustomerENG
                txtEASCustomerAddress.Value = exp.EASBilltoCustomerAddress
                txtEASEmail.Value = exp.EASBilltoCustomerEMail
                txtEASTelNo.Value = exp.EASBilltoCustomerTelNo
                txtEASFaxNo.Value = exp.EASBilltoCustomerFaxNo
                txtEASContactPerson.Value = exp.EASBilltoCustomerContactPerson
                txtPLTNetAmount.Value = String.Format("{0:0.00}", exp.PLTNetAmount)

                If String.IsNullOrEmpty(exp.UnitPLT) Then

                Else
                    dcboUnitPLT.Text = exp.UnitPLT
                End If
                txtPLTUnit.Value = exp.CTNPLTName
                txtCTNNetAmount.Value = String.Format("{0:0.00}", exp.CTNNetAmount)

                If String.IsNullOrEmpty(exp.UnitCTN) Then

                Else
                    dcboCTN.Text = exp.UnitCTN
                End If
                txtCTNUnit.Value = exp.UnitCTNName
                txtTotalGrossWeight.Value = String.Format("{0:0.00}", exp.GrossWeightAmount)
                txtTotalQuantity.Value = String.Format("{0:0.00}", exp.QountityAmount)
                txtVolumAmount.Value = String.Format("{0:0.00}", exp.VolumAmount)
                txtTotalText.Value = exp.TotalTextPack

                If String.IsNullOrEmpty(exp.CarLicense) Then

                Else
                    dcboCarLicense.Text = exp.CarLicense
                End If

                If String.IsNullOrEmpty(exp.DriverName) Then

                Else
                    dcboDriverName.Text = exp.DriverName
                End If
                CustomsConfirmDate.Text = Convert.ToDateTime(exp.CustomsConfirmDate).ToString("dd/MM/yyyy")
                'txtApp = exp.App
                Item = exp.OutItem
                If Item = "0" Then
                    CoutItem.Checked = False
                ElseIf Item = "1" Then
                    CoutItem.Checked = True
                End If

            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('" & ex.Message & "')", True)
            End Try
        End If
    End Sub
    Private Sub SavaDATA_New()
        If String.IsNullOrEmpty(txtInvoiceNo.Value.Trim) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Invoice No. ก่อน !!!')", True)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtExporterCode.Value.Trim) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Exporter Code ก่อน !!!')", True)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtConsigneeCode.Value.Trim) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Consignnee Code ก่อน !!!')", True)
            Exit Sub
        End If

        If rdbDiffAmount.Checked = True Then

            DiffBy = "Diff by items-amount"

        ElseIf rdbDiffWeight.Checked = True Then
            DiffBy = "Diff by items-Weight"
        Else
            DiffBy = ""
        End If

        If rdbNotifyParty.Checked = True Then
            TermTransport = "Notfy Party"
        ElseIf rdbOnBehalfOf.Checked = True Then
            TermTransport = "On Behalf of"
        Else
            TermTransport = ""
        End If
        If rdbOnBehalfOf.Checked = True Then
            OnbehalfStatus = "Enable On behalf of"
        Else
            OnbehalfStatus = "Disable On behalf of"
        End If

        Dim item As String
        If CoutItem.Checked = False Then
            item = "0"
        Else
            item = "1"
        End If

        Select Case MsgBox("คุณต้องการเพิ่มรายการ Export Customs Invoice ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
            Case MsgBoxResult.Yes
                checkExpInvoice(txtInvoiceNo.Value.Trim)
                Try

                    db.tblExpInvoices.Add(New tblExpInvoice With { _
                        .InvoiceNo = txtInvoiceNo.Value.Trim, _
                        .ReferenceNo = txtReferenceNo.Value.Trim, _
                        .PurchaseOrderNo = txtPurechaseOrderNo.Value.Trim, _
                        .InvoiceDate = DateTime.ParseExact(dtpInvoiceDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                        .DeliveryDate = DateTime.ParseExact(dtpDeliveryDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                        .ReferenceDate = DateTime.ParseExact(dtpReferenceDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                        .ExporterCode = txtExporterCode.Value.Trim, _
                        .ExporterENG = txtExportEng.Value.Trim, _
                        .Street_Number = txtStreet_Number.Value.Trim, _
                        .District = txtDistrict.Value.Trim, _
                        .Subprovince = txtSubProvince.Value.Trim, _
                        .Province = txtProvince.Value.Trim, _
                        .PostCode = txtPostCode.Value.Trim, _
                        .CompensateCode = txtCompensateCode.Value.Trim, _
                        .ConsignneeCode = txtConsigneeCode.Value.Trim, _
                        .ConsignneeENG = txtConsignneeEng.Value.Trim, _
                        .ConsignneeStreet_Number = txtConsignneeStreet_Number.Value.Trim, _
                        .ConsignneeDistrict = txtConsignneeDistrict.Value.Trim, _
                        .ConsignneeSubProvince = txtConsignneeSubProvince.Value.Trim, _
                        .ConsignneeProvince = txtConsignneeProvince.Value.Trim, _
                        .ConsignneePostCode = txtConsignneePostCode.Value.Trim, _
                        .ConsignneeEMail = txtConsignneeEMail.Value.Trim, _
                        .PurchaseCountryCode = dcboPurchaseCountry.Text.Trim, _
                        .PurchaseCountryName = txtPurchaseCountry.Value.Trim, _
                        .DestinationCountryCode = cboDestinationCountry.Text, _
                        .DestinationCountryName = txtDestinationCountry.Value.Trim, _
                        .CountryCode = dcboCountry.Text, _
                        .CountryName = txtCountry.Value.Trim, _
                        .TermOfPayment = dcboTermofPayment.Text.Trim, _
                        .Term = dcboTerm.Text, _
                        .TotalNetWeight = CType(CDbl(txtTotalNetWeight.Value.Trim).ToString("#,##0.000"), Double?), _
                        .SumItemWeight = CType(CDbl(txtSumItemWeight.Value.Trim).ToString("#,##0.000"), Double?), _
                        .TotalInvoiceCurrency = dcboTotalInvoice.Text.Trim, _
                        .TotalInvoiceAmount = CType(CDbl(txtTotalInvoiceAmount.Value.Trim).ToString("#,##0.000"), Double?), _
                        .TotalInvoiceAmount1 = CType(CDbl(txtTotalInvoiceAmount1.Value.Trim).ToString("#,##0.000"), Double?), _
                        .ForwardingCurrency = dcboForwarding.Text.Trim, _
                        .ForwardingAmount = CType(CDbl(txtForwardingAmount.Value.Trim).ToString("#,##0.000"), Double?), _
                        .ForwardingAmount1 = CType(CDbl(txtForwardingAmount1.Value.Trim).ToString("#,##0.000"), Double?), _
                        .FreightCurrency = dcboFreight.Text.Trim, _
                        .FreightAmount = CType(CDbl(txtFreightAmount.Value.Trim).ToString("#,##0.000"), Double?), _
                        .FreightAmount1 = CType(CDbl(txtFreightAmount1.Value.Trim).ToString("#,##0.000"), Double?), _
                        .InsuranceCurrency = dcboInsurance.Text.Trim, _
                        .InsuranceAmount = CType(CDbl(txtInsuranceAmount.Value.Trim).ToString("#,##0.000"), Double?), _
                        .InsuranceAmount1 = CType(CDbl(txtInsuranceAmount1.Value.Trim).ToString("#,##0.000"), Double?), _
                        .PackingChargeCurrency = dcboPackingCharge.Text.Trim, _
                        .PackingChargeAmount = CType(CDbl(txtPackingChargeAmount.Value.Trim).ToString("#,##0.0000"), Double?), _
                        .PackingChargeAmount1 = CType(CDbl(txtPackingChargeAmount1.Value.Trim).ToString("#,##0.0000"), Double?), _
                        .ForeignInlandCurrency = dcboForeignInland.Text.Trim, _
                        .ForeignInlandAmount = CType(CDbl(txtForeignInlandAmount.Value.Trim).ToString("#,##0.000"), Double?), _
                        .ForeignInlandAmount1 = CType(CDbl(txtForeignInlandAmount1.Value.Trim).ToString("#,##0.000"), Double?), _
                        .LandingChargeCurrency = dcboLandingCharge.Text.Trim, _
                        .LandingChargeAmount = CType(CDbl(txtLandingChargeAmount.Value.Trim).ToString("#,##0.000"), Double?), _
                        .LandingChargeAmount1 = CType(CDbl(txtLandingChargeAmount1.Value.Trim).ToString("#,##0.000"), Double?), _
                        .OtherChargeCurrency = dcboOtherCharge.Text.Trim, _
                        .DiffBy = DiffBy, _
                        .TermforShip = TermTransport, _
                        .OnbehalfStatus = OnbehalfStatus, _
                        .EASExporterCode = txtEASExporterCode.Value.Trim, _
                        .EASNameEng = txtEASNameEng.Value.Trim, _
                        .StreetAndNumber = txtEASStreet_Number.Value.Trim, _
                        .ESADistrict = txtEASDistrict.Value.Trim, _
                        .EASSubProvince = txtEASSubProvince.Value.Trim, _
                        .EASProvince = txtEASProvince.Value.Trim, _
                        .EASPostCode = txtEASPostCode.Value.Trim, _
                        .EASTCompensete = txtEASCompensateCode.Value.Trim, _
                        .EASCustomerCode = txtCustomerCode.Value.Trim, _
                        .EASCustomerENG = txtCustomerEng.Value.Trim, _
                        .EASCustomerAddress = txtCustomerAddress.Value.Trim, _
                        .EASCustomerEMail = txtCustomerEMail.Value.Trim, _
                        .EASCustomerTelNo = txtCustomerTelNo.Value.Trim, _
                        .EASCustomerFaxNo = txtCustomerFaxNo.Value.Trim, _
                        .EASCustomerContactPerson = txtCustomerContactPerson.Value.Trim, _
                        .EASInvRefNo = txtEASInvREFNo.Value.Trim, _
                        .EASLOTNo = txtEASLOTNo.Value.Trim, _
                        .EASCustomerRefNo = CInt(txtCustomerRefNo.Value.Trim), _
                        .EASSpecialInstruction = txtSpecialInstruction.Value.Trim, _
                        .EASShipMode = dcboShipMode.Text.Trim, _
                        .EASDeliveryTerm = dcboDeliveryTerm.Text.Trim, _
                        .EASShippingMark = dcboShippingMark.Text.Trim, _
                        .EASShippingMarkCompany = txtShippingCompany.Value.Trim, _
                        .EASShippingMarkAddress = txtShippingAddress.Value.Trim, _
                        .EASRemark = txtEASRemark.Value.Trim, _
                        .EASTotalCurrency = txtTotalCurrency.Value.Trim, _
                        .EASBilltoCustomerCode = txtEASCustomerCode.Value.Trim, _
                        .EASBilltoCustomerENG = txtEASCustomerEng1.Value.Trim, _
                        .EASBilltoCustomerAddress = txtEASCustomerAddress.Value.Trim, _
                        .EASBilltoCustomerEMail = txtEASEmail.Value.Trim, _
                        .EASBilltoCustomerTelNo = txtEASTelNo.Value.Trim, _
                        .EASBilltoCustomerFaxNo = txtEASFaxNo.Value.Trim, _
                        .EASBilltoCustomerContactPerson = txtEASContactPerson.Value.Trim, _
                        .PLTNetAmount = CType(CDbl(txtPLTNetAmount.Value.Trim).ToString("#,##0.000"), Double?), _
                        .UnitPLT = dcboUnitPLT.Text.Trim, _
                        .CTNPLTName = txtPLTUnit.Value.Trim, _
                        .CTNNetAmount = CType(CDbl(txtCTNNetAmount.Value.Trim).ToString("#,##0.000"), Double?), _
                        .UnitCTN = dcboCTN.Text.Trim, _
                        .UnitCTNName = txtCTNUnit.Value.Trim, _
                        .GrossWeightAmount = CType(CDbl(txtTotalGrossWeight.Value.Trim).ToString("#,##0.000"), Double?), _
                        .QountityAmount = CType(CDbl(txtTotalQuantity.Value.Trim).ToString("#,##0.000"), Double?), _
                        .VolumAmount = CType(CDbl(txtVolumAmount.Value.Trim).ToString("#,##0.000"), Double?), _
                        .TotalTextPack = txtTotalText.Value.Trim, _
                        .CarLicense = dcboCarLicense.Text.Trim, _
                        .DriverName = dcboDriverName.Text, _
                        .PrintCountInv = "0", _
                        .PrintCountPack = "0", _
                        .PrintCount107 = "0", _
                        .PrintCount108 = "0", _
                        .PrintCountDoc = "0", _
                        .CustomsConfirmDate = DateTime.ParseExact(CustomsConfirmDate.Text.Trim, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                        .App = "Wait", _
                        .CreateBy = Session("UserName").ToString, _
                        .CreateDate = Now, _
                        .OutItem = item
                })
                    db.SaveChanges()

                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('" & ex.Message & "')", True)
                End Try
            Case MsgBoxResult.No

        End Select

        '.OtherChargeAmount = CDbl(txtOtherChargeAmount.Value.Trim).ToString("#,##0.000"), _
        '     .OtherChargeAmount1  = txtOtherChargeAmount1.Value.Trim, _
        '     .TransmitDate  = dtpTransmitDate.Value.Date, _
    End Sub
    Private Sub checkExpInvoice(InvoiceNo As String)

        Dim invoiec = (From exp In db.tblExpInvoices Where exp.InvoiceNo = InvoiceNo Select exp).FirstOrDefault

        If Not IsNothing(invoiec) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert(' มี Invoice No นี้" & invoiec.InvoiceNo & " อยู่แล้ว')", True)
        End If
    End Sub
    Private Sub InsertData()
        Dim time As Date
        Dim NameUser As String
        time = CDate((Format(Now)))
        NameUser = Session("UserName").ToString

        db.tblLogExpInvoices.Add(New tblLogExpInvoice With { _
                                 .InvoiceNo = txtInvoiceNo.Value.Trim, _
                                 .InvoiceDate = CType(dtpInvoiceDate.Text, Date?), _
                                 .ConsignneeCode = txtConsigneeCode.Value.Trim, _
                                 .EASExporterCode = txtEASExporterCode.Value.Trim, _
                                 .EASInvRefNo = txtEASInvREFNo.Value.Trim, _
                                 .EASLOTNo = txtEASLOTNo.Value.Trim, _
                                 .EASShipMode = dcboShipMode.Text.Trim, _
                                 .EASDeliveryTerm = dcboDeliveryTerm.Text.Trim, _
                                 .ProductDesc1 = txtProductDesc1.Value.Trim, _
                                 .ProductDesc2 = txtProductDesc2.Value.Trim, _
                                 .ProductDesc3 = txtProductDesc3.Value.Trim, _
                                 .OriginCountry = dcboOriginCtry.Text.Trim, _
                                 .Quantity = CType(CDbl(txtQuantity.Value.Trim).ToString("#,##0.00000"), Decimal?), _
                                 .PriceForeigh = CType(CDbl(txtPriceForeigh.Value.Trim).ToString("#,##0.000"), Decimal?), _
                                 .PriceForeighAmount = CType(CDbl(txtPriceForeighAmount.Value).ToString("#,##0.000"), Decimal?), _
                                 .PriceBathAmount = CType(txtPriceBathAmount.Value.Trim, Decimal?), _
                                 .ExchangeRate = CType(CDbl(txtExchangeRate.Value.Trim).ToString("#,##0.0000"), Decimal?), _
                                 .PLTNetAmount = CType(CDbl(txtPLTNetAmount.Value.Trim).ToString("#,##0.000"), Decimal?), _
                                 .CTNPLTName = txtPLTUnit.Value.Trim, _
                                 .CTNNetAmount = CType(CDbl(txtCTNNetAmount.Value.Trim).ToString("#,##0.000"), Decimal?), _
                                 .UnitCTNName = txtCTNUnit.Value.Trim, _
                                 .NetWeight = CType(CDbl(txtPackWeight.Text).ToString("#,##0.00"), Decimal?), _
                                 .GrossWeight = CType(CDbl(txtPackGross.Value.Trim).ToString("#,##0.00"), Decimal?), _
                                 .UserBy = NameUser, _
                                 .LastUpDate = time
                                })
        db.SaveChanges()

    End Sub

    Protected Sub dcboPurchaseCountry_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim pu = (From p In db.tblMasterCode2 Where p.Code = dcboPurchaseCountry.Text.Trim).FirstOrDefault
        txtPurchaseCountry.Value = pu.Description
    End Sub

    Protected Sub dcboCountry_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim pu = (From p In db.tblMasterCode2 Where p.Code = dcboCountry.Text.Trim).FirstOrDefault
        txtCountry.Value = pu.Description
    End Sub

    Protected Sub cboDestinationCountry_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim pu = (From p In db.tblMasterCode2 Where p.Code = cboDestinationCountry.Text.Trim).FirstOrDefault
        txtDestinationCountry.Value = pu.Description
    End Sub

    Protected Sub Use_ServerClick(sender As Object, e As EventArgs)
        selectcompany()
        ScriptManager.RegisterStartupScript(upIEAT107, upIEAT107.GetType(), "show", "$(function () { $('#" + plIEAT107.ClientID + "').modal('show'); });", True)
        upIEAT107.Update()
    End Sub

    Protected Sub btnSCon_ServerClick(sender As Object, e As EventArgs)
        selectConsigneeCode()
    End Sub

    Protected Sub btnOwner_ServerClick(sender As Object, e As EventArgs)
        selectEASExporterCode()
    End Sub

    Protected Sub btnShip_ServerClick(sender As Object, e As EventArgs)
         selectCustomerCode()
    End Sub

    Protected Sub btnBill_ServerClick(sender As Object, e As EventArgs)
            selectEASCustomerCode()
    End Sub

    Protected Sub dgvExporter_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
         If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyAdd As Label = CType(e.Item.FindControl("lblPartyAdd"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString
            End If
            If Not IsNothing(lblPartyAdd) Then
                lblPartyAdd.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString
            End If
            If Not IsNothing(lblPartyFullName) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString
            End If
            If Not IsNothing(lblAddress1) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString
            End If
            If Not IsNothing(lblAddress2) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString
            End If
        End If
    End Sub

    Protected Sub lnkPartyCode_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
              Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtExporterCode.Value = ""
        Else
            txtExporterCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtExportEng.Value = ""
        Else
            txtExportEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtStreet_Number.Value = ""
        Else
            txtStreet_Number.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtDistrict.Value = ""
        Else
            txtDistrict.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtSubProvince.Value = ""
        Else
            txtSubProvince.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtProvince.Value = ""
        Else
            txtProvince.Value = eano.pa.Address4
        End If

        If String.IsNullOrEmpty(eano.pa.ZipCode) Then
            txtPostCode.Value = ""
        Else
            txtPostCode.Value = eano.pa.ZipCode
        End If

        If String.IsNullOrEmpty(eano.pa.email) Then
            txtCompensateCode.Value = ""
        Else
            txtCompensateCode.Value = eano.pa.email
        End If
    End Sub

    Protected Sub dgvConsignnee_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyAdd As Label = CType(e.Item.FindControl("lblPartyAdd"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString
            End If
            If Not IsNothing(lblPartyAdd) Then
                lblPartyAdd.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString
            End If
            If Not IsNothing(lblPartyFullName) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString
            End If
            If Not IsNothing(lblAddress1) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString
            End If
            If Not IsNothing(lblAddress2) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString
            End If
        End If
    End Sub

    Protected Sub lnkPartyCode_Con_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
              Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtConsigneeCode.Value = ""
        Else
            txtConsigneeCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtConsignneeEng.Value = ""
        Else
            txtConsignneeEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtConsignneeStreet_Number.Value = ""
        Else
            txtConsignneeStreet_Number.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtConsignneeDistrict.Value = ""
        Else
            txtConsignneeDistrict.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtConsignneeSubProvince.Value = ""
        Else
            txtConsignneeSubProvince.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtConsignneeProvince.Value = ""
        Else
            txtConsignneeProvince.Value = eano.pa.Address4
        End If

        If String.IsNullOrEmpty(eano.pa.ZipCode) Then
            txtConsignneePostCode.Value = ""
        Else
            txtConsignneePostCode.Value = eano.pa.ZipCode
        End If

        If String.IsNullOrEmpty(eano.pa.email) Then
            txtConsignneeEMail.Value = ""
        Else
            txtConsignneeEMail.Value = eano.pa.email
        End If
    End Sub

    Protected Sub lnkPartyCode_Exp1_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
              Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtEASExporterCode.Value = ""
        Else
            txtEASExporterCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtEASNameEng.Value = ""
        Else
            txtEASNameEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtEASStreet_Number.Value = ""
        Else
            txtEASStreet_Number.Value = eano.pa.Address1
        End If

        If String.IsNullOrEmpty(eano.pa.Address2) Then
            txtEASDistrict.Value = ""
        Else
            txtEASDistrict.Value = eano.pa.Address2
        End If

        If String.IsNullOrEmpty(eano.pa.Address3) Then
            txtEASSubProvince.Value = ""
        Else
            txtEASSubProvince.Value = eano.pa.Address3
        End If

        If String.IsNullOrEmpty(eano.pa.Address4) Then
            txtEASProvince.Value = ""
        Else
            txtEASProvince.Value = eano.pa.Address4
        End If

        If String.IsNullOrEmpty(eano.pa.ZipCode) Then
            txtEASPostCode.Value = ""
        Else
            txtEASPostCode.Value = eano.pa.ZipCode
        End If

        If String.IsNullOrEmpty(eano.pa.email) Then
            txtEASCompensateCode.Value = ""
        Else
            txtEASCompensateCode.Value = eano.pa.email
        End If
    End Sub

    Protected Sub dgvShipTo_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyAdd As Label = CType(e.Item.FindControl("lblPartyAdd"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString
            End If
            If Not IsNothing(lblPartyAdd) Then
                lblPartyAdd.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString
            End If
            If Not IsNothing(lblPartyFullName) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString
            End If
            If Not IsNothing(lblAddress1) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString
            End If
            If Not IsNothing(lblAddress2) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString
            End If
        End If
    End Sub

    Protected Sub lnkPartyCode_ShipTo_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
              Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtCustomerCode.Value = ""
        Else
            txtCustomerCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtCustomerEng.Value = ""
        Else
            txtCustomerEng.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtCustomerAddress.Value = ""
        Else
            txtCustomerAddress.Value = eano.pa.Address1 + eano.pa.Address2 + eano.pa.Address3 + eano.pa.Address4 + eano.pa.ZipCode
        End If

        If String.IsNullOrEmpty(eano.pa.email) Then
            txtCustomerEMail.Value = ""
        Else
            txtCustomerEMail.Value = eano.pa.email
        End If

        If String.IsNullOrEmpty(eano.pa.Tel) Then
            txtCustomerTelNo.Value = ""
        Else
            txtCustomerTelNo.Value = eano.pa.Tel
        End If

        If String.IsNullOrEmpty(eano.pa.Fax) Then
            txtCustomerFaxNo.Value = ""
        Else
            txtCustomerFaxNo.Value = eano.pa.Fax
        End If

        If String.IsNullOrEmpty(eano.pa.Attn) Then
            txtCustomerContactPerson.Value = ""
        Else
            txtCustomerContactPerson.Value = eano.pa.Attn
        End If

        'If String.IsNullOrEmpty(eano.pa.email) Then
        '   txtEASCompensateCode.Value = ""
        'Else
        '    txtEASCompensateCode.Value = eano.pa.email
        'End If
    End Sub

    Protected Sub dgvBillTo_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyAdd As Label = CType(e.Item.FindControl("lblPartyAdd"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString
            End If
            If Not IsNothing(lblPartyAdd) Then
                lblPartyAdd.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString
            End If
            If Not IsNothing(lblPartyFullName) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString
            End If
            If Not IsNothing(lblAddress1) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString
            End If
            If Not IsNothing(lblAddress2) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString
            End If
        End If
    End Sub

    Protected Sub dgvExporter1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblPartyCode As Label = CType(e.Item.FindControl("lblPartyCode"), Label)
            Dim lblPartyAdd As Label = CType(e.Item.FindControl("lblPartyAdd"), Label)
            Dim lblPartyFullName As Label = CType(e.Item.FindControl("lblPartyFullName"), Label)
            Dim lblAddress1 As Label = CType(e.Item.FindControl("lblAddress1"), Label)
            Dim lblAddress2 As Label = CType(e.Item.FindControl("lblAddress2"), Label)

            If Not IsNothing(lblPartyCode) Then
                lblPartyCode.Text = DataBinder.Eval(e.Item.DataItem, "PartyCode").ToString
            End If
            If Not IsNothing(lblPartyAdd) Then
                lblPartyAdd.Text = DataBinder.Eval(e.Item.DataItem, "PartyAddressCode").ToString
            End If
            If Not IsNothing(lblPartyFullName) Then
                lblPartyFullName.Text = DataBinder.Eval(e.Item.DataItem, "PartyFullName").ToString
            End If
            If Not IsNothing(lblAddress1) Then
                lblAddress1.Text = DataBinder.Eval(e.Item.DataItem, "Address1").ToString
            End If
            If Not IsNothing(lblAddress2) Then
                lblAddress2.Text = DataBinder.Eval(e.Item.DataItem, "Address2").ToString
            End If
        End If
    End Sub

    Private Sub selectExporter()
        Dim exp_code As String
        Dim shipper As String = ""
        If String.IsNullOrEmpty(txtExporterCode.Value.Trim) Then
            exp_code = ""
            shipper = "0"
        Else
            exp_code = txtExporterCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = exp_code And p.Shipper = "0") Or p.Shipper = shipper
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvExporter.DataSource = cons.ToList
            dgvExporter.DataBind()
            ScriptManager.RegisterStartupScript(upExporter, upExporter.GetType(), "show", "$(function () { $('#" + plExporter.ClientID + "').modal('show'); });", True)
            upExporter.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Exporter Code นี้')", True)
            Exit Sub
        End If

    End Sub

    Private Sub selectConsigneeCode()
        Dim cons_code As String
        Dim consignee As String = ""
        If String.IsNullOrEmpty(txtConsigneeCode.Value.Trim) Then
            cons_code = ""
            consignee = "0"
        Else
            cons_code = txtConsigneeCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = consignee
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvConsignnee.DataSource = cons.ToList
            dgvConsignnee.DataBind()
            ScriptManager.RegisterStartupScript(upConsignnee, upConsignnee.GetType(), "show", "$(function () { $('#" + plConsignnee.ClientID + "').modal('show'); });", True)
            upConsignnee.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Consignee Code นี้')", True)
            Exit Sub

        End If
    End Sub

    Private Sub selectEASExporterCode()
        Dim cons_code As String
        Dim consignee As String = ""
        If String.IsNullOrEmpty(txtEASExporterCode.Value.Trim) Then
            cons_code = ""
            consignee = "0"
        Else
            cons_code = txtEASExporterCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = consignee
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvExporter1.DataSource = cons.ToList
            dgvExporter1.DataBind()
            ScriptManager.RegisterStartupScript(upExporter1, upExporter1.GetType(), "show", "$(function () { $('#" + plExporter1.ClientID + "').modal('show'); });", True)
            upExporter1.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Consignee Code นี้')", True)
            Exit Sub

        End If
    End Sub
    Private Sub selectCustomerCode()
        Dim cons_code As String
        Dim consignee As String = ""
        If String.IsNullOrEmpty(txtCustomerCode.Value.Trim) Then
            cons_code = ""
            consignee = "0"
        Else
            cons_code = txtCustomerCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = consignee
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvShipTo.DataSource = cons.ToList
            dgvShipTo.DataBind()
            ScriptManager.RegisterStartupScript(upShipTo, upShipTo.GetType(), "show", "$(function () { $('#" + plShipTo.ClientID + "').modal('show'); });", True)
            upShipTo.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Consignee Code นี้')", True)
            Exit Sub

        End If
    End Sub

    Private Sub selectEASCustomerCode()
        Dim cons_code As String
        Dim consignee As String = ""
        If String.IsNullOrEmpty(txtEASCustomerCode.Value.Trim) Then
            cons_code = ""
            consignee = "0"
        Else
            cons_code = txtEASCustomerCode.Value.Trim
        End If

        Dim cons = From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
        Where (p.PartyCode = cons_code And p.Consignee = "0") Or p.Consignee = consignee
        Select p.PartyCode, pa.PartyAddressCode, p.PartyFullName, pa.Address1, pa.Address2

        If cons.Count > 0 Then
            dgvBillTo.DataSource = cons.ToList
            dgvBillTo.DataBind()
            ScriptManager.RegisterStartupScript(upBillTo, upBillTo.GetType(), "show", "$(function () { $('#" + plBillTo.ClientID + "').modal('show'); });", True)
            upBillTo.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Consignee Code นี้')", True)
            Exit Sub

        End If
    End Sub

    Protected Sub lnkPartyCode_BillTo_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim PartyCode As String = TryCast(item.FindControl("lblPartyCode"), Label).Text.Trim
        Dim PartyAdd As Double = CDbl(TryCast(item.FindControl("lblPartyAdd"), Label).Text.Trim)
        Dim eano = (From p In db.tblParties Join pa In db.tblPartyAddresses On p.PartyCode Equals pa.PartyCode
              Where p.PartyCode = PartyCode And pa.PartyAddressCode = PartyAdd).SingleOrDefault

        If String.IsNullOrEmpty(eano.p.PartyCode) Then
            txtEASCustomerCode.Value = ""
        Else
            txtEASCustomerCode.Value = eano.p.PartyCode
        End If

        If String.IsNullOrEmpty(eano.p.PartyFullName) Then
            txtEASCustomerEng1.Value = ""
        Else
            txtEASCustomerEng1.Value = eano.p.PartyFullName
        End If

        If String.IsNullOrEmpty(eano.pa.Address1) Then
            txtEASCustomerAddress.Value = ""
        Else
            txtEASCustomerAddress.Value = eano.pa.Address1 + eano.pa.Address2 + eano.pa.Address3 + eano.pa.Address4 + eano.pa.ZipCode
        End If
         If String.IsNullOrEmpty(eano.pa.email) Then
           txtEASEmail.Value = ""
        Else
            txtEASEmail.Value  = eano.pa.email
        End If

        If String.IsNullOrEmpty(eano.pa.Tel) Then
            txtEASTelNo.Value = ""
        Else
            txtEASTelNo.Value = eano.pa.Tel
        End If

        If String.IsNullOrEmpty(eano.pa.Fax) Then
             txtEASFaxNo.Value = ""
        Else
             txtEASFaxNo.Value = eano.pa.Fax
        End If

        If String.IsNullOrEmpty(eano.pa.Attn) Then
            txtEASContactPerson.Value = ""
        Else
            txtEASContactPerson.Value = eano.pa.Attn
        End If
    
    End Sub
    
    Private Sub ReadDATAIEAT107(Invoice As String)

        Dim cons = From p In db.tblStatusBalances Where p.InvoiceNo = Invoice
             Order By p.InvoiceNo Descending
             Select p.PartyCode, p.InvoiceNo, p.JobNo, p.Status
        If cons.Count > 0 Then
            dgvIEAT107.DataSource = cons.ToList
            dgvIEAT107.DataBind()
            ScriptManager.RegisterStartupScript(upIEAT107, upIEAT107.GetType(), "show", "$(function () { $('#" + plIEAT107.ClientID + "').modal('show'); });", True)
            upIEAT107.Update()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Invoice ก่อน !!!')", True)
            Exit Sub
        End If

    End Sub
    Private Sub selectcompany()
        Dim com = (From c In db.tblCompanyGuarantee1 Select c).SingleOrDefault
        txtTotalAmonut.Value = String.Format("{0:0.00}", com.AmountGuarantee)
        txtTotalUseAmonut.Value = String.Format("{0:0.00}", com.AmountUsed)
        txtAmonut.Value = String.Format("{0:0.00}", com.Balance)
    End Sub

    Protected Sub AddIEAT107_Click(sender As Object, e As EventArgs)
        savaStatusBalance()
    End Sub
    Private Sub ClareDataIEAT107()
        txtUseAmonut.Value = "0"
        txtTotalUseAmonut.Value = "0"
        txtTotalAmonut.Value = "0"
        txtAmonut.Value = "0"
    End Sub
    Private Sub SavaAmountGuarantee()
        db.tblCompanyGuarantee1.Add(New tblCompanyGuarantee1 With { _
                                    .AmountGuarantee = CType(txtTotalAmonut.Value, Decimal?), _
                                    .AmountUsed = CType(txtTotalUseAmonut.Value, Decimal?), _
                                    .Balance = CType(txtAmonut.Value, Decimal?), _
                                    .InvoiceNo = txtInvoiceNo.Value.Trim
                                    })
        db.SaveChanges()
    End Sub

    Private Sub savaStatusBalance()
        Dim StatusRenew As Integer = 0
        Dim UseAmonut As String = ""
        If String.IsNullOrEmpty(txtInvoiceNo.Value.Trim) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน Invoice ก่อน !!!')", True)
            Exit Sub
        Else
            If Checkbox1.Checked = True Then
                StatusRenew = 1
            Else
                StatusRenew = 0
            End If
            Select Case MsgBox("คุณต้องการเพิ่มรายการ Invoice ใหม่ ใช่หรือไม่ ?", MsgBoxStyle.YesNo, "คำยืนยัน")
                Case MsgBoxResult.Yes

                    db.tblStatusBalances.Add(New tblStatusBalance With { _
                                    .PartyCode = txtCustomerCode.Value.Trim, _
                                    .JobNo = txtPurechaseOrderNo.Value.Trim, _
                                    .InvoiceNo = txtInvoiceNo.Value.Trim, _
                                    .InvoiceDate = DateTime.ParseExact(dtpInvoiceDate.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                                    .UseAmount = CType(CDbl(txtUseAmonut.Value.Trim).ToString("#,##0.000"), Decimal?), _
                                    .DeliveryDate = DateTime.ParseExact(dtpForm.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                                    .ReturnDate = DateTime.ParseExact(dtpTo.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                                    .RenewDate = DateTime.ParseExact(dtpEx.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), _
                                    .CreateBy = Session("UserName").ToString, _
                                    .CreateDate = Now, _
                                    .StatusRenew = StatusRenew
                                     })
                    db.SaveChanges()
                    SavaAmountGuarantee()
                    ReadDATAIEAT107(txtInvoiceNo.Value.Trim)
            End Select
        End If
    End Sub

    Protected Sub btnadd__ServerClick(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtStartInvoiceNo.Value.Trim) Then
            MsgBox("1")
        Else
            MsgBox("2")
        End If
    End Sub
End Class