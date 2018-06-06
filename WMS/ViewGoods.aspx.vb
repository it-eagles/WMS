Option Strict On
Option Explicit On

Public Class ViewGoods
    Inherits System.Web.UI.Page
    Dim db As New LKBwarehouseEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        showGoods()

    End Sub
    Private Sub showGoods()
        Dim idPC As String = Request.QueryString("ProductCode")
      
            Dim goods = (From go In db.tblProductDetail
          Where go.ProductCode = idPC).SingleOrDefault

            txtProductCode.Value = goods.ProductCode
            txtProductPO.Value = goods.PONo
            txtCustomerPart.Value = goods.CustomerPart
            txtEndUserPart.Value = goods.EndUserPart
            txtImpProductCode.Value = goods.ImpProductCode
            txtImpTariffCode.Value = goods.TariffCode

            txtImpDesc1.Value = goods.ImpDesc1
            txtImpDesc2.Value = goods.ImpDesc2
            txtImpDesc3.Value = goods.ImpDesc3
            txtImpProductAttribute1.Value = goods.ImpProductAttribute1
            txtImpProductAttribute2.Value = goods.ImpProductAttribute2
            txtImpTariffSequence.Value = goods.ImpTariffSequence
            txtImpStatisticalCode.Value = goods.ImpStatisticalCode
            txtImpCustomsProductCode.Value = goods.ImpCustomsProductCode
            txtImpProductYear.Value = goods.ImpProductYear
            txtImpDutyType.Value = goods.ImpDutytype

            If Not goods.ImpSpeciticRate Is Nothing Then
                Dim impR As String = CStr(goods.ImpSpeciticRate)
                txtImpSpeciticRate.Value = impR
            Else
                txtImpSpeciticRate.Value = "0"
            End If

            txtImpSpecificCal.Value = goods.ImpSpecificCal
            If Not goods.ImpSpecificRate_P Is Nothing Then
                Dim sr_p As String = CStr(goods.ImpSpecificRate_P)

                txtImpSpecificRateP.Value = sr_p

            Else
                txtImpSpecificRateP.Value = "0"
            End If

            If Not goods.ImpExemptVAT Is Nothing Then
                Dim imp As String = CStr(goods.ImpExemptVAT)
                txtImpExemptVat.Value = imp
            Else
                txtImpExemptVat.Value = "0"
            End If

            If Not goods.ImpExemptDuty Is Nothing Then
                Dim imp As String = CStr(goods.ImpExemptDuty)
                txtImpExemptDuty.Value = imp
            Else
                txtImpExemptDuty.Value = "0"
            End If

            txtImpExciseNo.Value = goods.ImpExciseNo


            If Not goods.ImpSurchargeRate Is Nothing Then
                Dim imp As String = CStr(goods.ImpSurchargeRate)
                txtImpSurchargeRate.Value = imp
            Else
                txtImpSurchargeRate.Value = "0"
            End If


            If Not goods.ImpSurchargeRate Is Nothing Then
                Dim imp As String = CStr(goods.ImpExciseRatePay)
                txtImpExciseRatePay.Value = imp
            Else
                txtImpExciseRatePay.Value = "0"
            End If

            If Not goods.ImpExciseRate Is Nothing Then
                Dim imp As String = CStr(goods.ImpExciseRate)
                txtImpExciseRate.Value = imp
            Else
                txtImpExciseRate.Value = "0"
            End If

            If Not goods.ImpExciseSpcRatePay Is Nothing Then
                Dim impSP As String = CStr(goods.ImpExciseSpcRatePay)
                txtImpExciseSpcRatePay.Value = impSP

            Else
                txtImpExciseSpcRatePay.Value = "0"
            End If


            If Not goods.ImpExciseSpcRate Is Nothing Then
                Dim impSP As String = CStr(goods.ImpExciseSpcRate)
                txtImpExciseSpcRate.Value = impSP

            Else
                txtImpExciseSpcRate.Value = "0"
            End If

            txtImpPriviege.Value = goods.ImpPriviege
            txtImpExemptExcise.Value = goods.ImpExemptExcise

            txtImpBrand.Value = goods.ImpBrand

            If Not goods.ImpValueRate Is Nothing Then
                Dim imp As String = CStr(goods.ImpValueRate)
                txtImpValueRate.Value = imp
            Else
                txtImpValueRate.Value = "0"
            End If

            If Not goods.ImpCurrency Is Nothing Then
                Dim imp As String = goods.ImpCurrency
                txtImpCurrency.Value = imp
            Else
                txtImpCurrency.Value = "เป็นค่าว่าง"
            End If



            If Not goods.ImpExchangeRate Is Nothing Then
                Dim imp As String = CStr(goods.ImpExchangeRate)
                txtImpExchangeRate.Value = imp
            Else
                txtImpExchangeRate.Value = "0"
            End If



            If Not goods.ImpValueRateAmount Is Nothing Then
                Dim imp As String = CStr(goods.ImpValueRateAmount)
                txtImpValueRateAmount.Value = imp
            Else
                txtImpValueRateAmount.Value = "0"
            End If


            txtExpProductCode.Value = goods.ExpProductCode
            txtExpDesc1.Value = goods.ExpDesc1
            txtExpDesc2.Value = goods.ExpDesc2
            txtExpDesc3.Value = goods.ExpDesc3
            txtExpProductAttribute1.Value = goods.ExpProductAttribute1
            txtExpProductAttribute2.Value = goods.ExpProductAttribute2
            txtExpTariffSequence.Value = goods.ExpTariffSequence
            txtExpTariffCode.Value = goods.ExpTariffCode
            txtExpCustomsProductCode.Value = goods.ExpCustomsProductCode
            txtExpStatisticalCode.Value = goods.ExpStatisticalCode
            txtExpFomulaNo.Value = goods.ExpFomulaNo
            txtExpProductYear.Value = goods.ExpProductYear
            txtExpBOINo.Value = goods.ExpBOINo
            txtExp19BisTranNo.Value = goods.Exp19BisTranNo
            txtExpDutyType.Value = goods.ExpDutyType
            txtExpBondFormulaNo.Value = goods.ExpBondFormulaNo

            If Not goods.ExpQTYCarton Is Nothing Then
                Dim imp As String = CStr(goods.ExpQTYCarton)
                txtExpQtyCarton.Value = imp
            Else
                txtExpQtyCarton.Value = "0"
            End If

            If Not goods.ExpPriceForeight Is Nothing Then
                Dim imp As String = CStr(goods.ExpPriceForeight)
                txtExpPriceForeight.Value = imp
            Else
                txtExpPriceForeight.Value = "0"
            End If

            If Not goods.ExpWeightCarton Is Nothing Then
                Dim imp As String = CStr(goods.ExpWeightCarton)
                txtExpWeightCarton.Value = imp
            Else
                txtExpWeightCarton.Value = "0"
            End If

            If Not goods.ExpQTYPallet Is Nothing Then
                Dim imp As String = CStr(goods.ExpQTYPallet)
                txtExpQtyPallet.Value = imp
            Else
                txtExpQtyPallet.Value = "0"
            End If

            If Not goods.ExpValueRate Is Nothing Then
                Dim imp As String = CStr(goods.ExpValueRate)
                txtExpValueRate.Value = imp
            Else
                txtExpValueRate.Value = "0"
            End If

            If Not goods.ExpCurrency Is Nothing Then
                Dim imp As String = goods.ExpCurrency
                txtExpCurrency.Value = imp
            Else
                txtExpCurrency.Value = "เป็นค่าว่าง"
            End If

            If Not goods.ExpExchangeRate Is Nothing Then
                Dim imp As String = CStr(goods.ExpExchangeRate)
                txtExpExchangeRate.Value = imp
            Else
                txtExpExchangeRate.Value = "0"
            End If

            If Not goods.ExpValueRateAmount Is Nothing Then
                Dim imp As String = CStr(goods.ExpValueRateAmount)
                txtExpValueRateAmount.Value = imp
            Else
                txtExpValueRateAmount.Value = "0"
            End If


            If Not goods.CartonSetUnit Is Nothing Then
                Dim imp As String = goods.CartonSetUnit
                txtPackageofUnit.Value = imp
            Else
                txtPackageofUnit.Value = "เป็นค่าว่าง"
            End If

            If Not goods.CartonWidth Is Nothing Then
                Dim imp As String = CStr(goods.CartonWidth)
                txtProductWidth.Value = imp
            Else
                txtProductWidth.Value = "0"
            End If

            If Not goods.CartonHeight Is Nothing Then
                Dim imp As String = CStr(goods.CartonHeight)
                txtProductHeight.Value = imp
            Else
                txtProductHeight.Value = "0"
            End If

            If Not goods.CartonLenght Is Nothing Then
                Dim imp As String = CStr(goods.CartonLenght)
                txtProductLeng.Value = imp
            Else
                txtProductLeng.Value = "0"
            End If

            If Not goods.CartonVolume Is Nothing Then
                Dim imp As String = CStr(goods.CartonVolume)
                txtProductVolume.Value = imp
            Else
                txtProductVolume.Value = "0"
            End If
            txtUnitofVolume.Value = goods.CartonVolUnit
            txtPackageUnit.Value = goods.PalletSetUnit
            txtRemarks.InnerText = goods.SpecialHandling

            If Not goods.PalletWidth Is Nothing Then
                Dim imp As String = CStr(goods.PalletWidth)
                txtPackageWidth.Value = imp
            Else
                txtPackageWidth.Value = "0"
            End If

            If Not goods.PalletHeight Is Nothing Then
                Dim imp As String = CStr(goods.PalletHeight)
                txtPackageHeigh.Value = imp
            Else
                txtPackageHeigh.Value = "0"
            End If

            If Not goods.PalletLenght Is Nothing Then
                Dim imp As String = CStr(goods.PalletLenght)
                txtPackageLenght.Value = imp
            Else
                txtPackageLenght.Value = "0"
            End If

            If Not goods.PalletLenght Is Nothing Then
                Dim imp As String = CStr(goods.PalletNoCarton)
                txtPackageCarton.Value = imp
            Else
                txtPackageCarton.Value = "0"
            End If

            If Not goods.PalletVolume Is Nothing Then
                Dim imp As String = CStr(goods.PalletVolume)
                txtPackageVolume.Value = imp
            Else
                txtPackageVolume.Value = "0"
            End If

            If Not goods.PalletVolUnit Is Nothing Then
                Dim imp As String = goods.PalletVolUnit
                txtPackageUnit.Value = imp
            Else
                txtPackageUnit.Value = "เป็นค่าว่าง"
            End If
            txtImpEstablishNo.Value = goods.ImpEstablishNo
            txtImpFactoryNo.Value = goods.ImpFactoryNo
            txtExpEstablishNo.Value = goods.ExpEstablishNo
            txtExpFactoryNo.Value = goods.ExpFactoryNo
            txtCreateBy.Value = goods.CreateBy
            txtCreateDate.Value = String.Format("{0:dd/MM/yyyy}", goods.CreateDate)


            If (String.IsNullOrEmpty(goods.UpdateBy)) Then
                Dim GoodsUp As String = goods.UpdateBy
                txtUpdateBy.Value = "ยังไม่มีการแก้ไขข้อมูล"
            Else
                txtUpdateBy.Value = goods.UpdateBy
            End If


            Dim upDate As String = String.Format("{0:dd/MM/yyyy}", goods.UpdateDate)
            If (String.IsNullOrEmpty(upDate)) Then
                txtUpdateDate.Value = "ยังไม่มีการแก้ไขข้อมูล"
            Else
                txtUpdateDate.Value = upDate

            End If
    
    End Sub

End Class