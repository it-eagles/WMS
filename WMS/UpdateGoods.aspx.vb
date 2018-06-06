Option Strict On
Option Explicit On

Imports System.Transactions

Public Class UpdateGoods
    Inherits System.Web.UI.Page
    Dim ImpStatus1 As String = "0"
    Dim ImpStatus2 As String = "0"
    Dim ImpStatus3 As String = "0"
    Dim ExpStatus1 As String = "0"
    Dim ExpStatus2 As String = "0"
    Dim ExpStatus3 As String = "0"
    Dim db As New LKBwarehouseEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            showEditGoods()
            showGroupColor()
            showGroupGoods()

        End If
    End Sub
    Private Sub showEditGoods()
        Dim idPC As String = Request.QueryString("ProductCode")
     
            Dim goods = (From go In db.tblProductDetail
          Where go.ProductCode = idPC).SingleOrDefault

            txtMinimunStock.Value = "0"
            txtAdjustment.Value = "0"
            txtDamageQty.Value = "0"
            txtAvailableQTY.Value = "0"

            txtProductCode.Value = goods.ProductCode
            txtProductPO.Value = goods.PONo
            txtCustomerPart.Value = goods.CustomerPart
            txtEndUserPart.Value = goods.EndUserPart
            txtImpProductCode.Value = goods.ImpProductCode
            dcboImpTariffCode.Text = goods.TariffCode
            txtImpDesc1.Value = goods.ImpDesc1
            txtImpDesc2.Value = goods.ImpDesc2
            txtImpDesc3.Value = goods.ImpDesc3
            txtImpProductAttribute1.Value = goods.ImpProductAttribute1
            txtImpProductAttribute2.Value = goods.ImpProductAttribute2
            dcboImpTariffSequence.Text = goods.ImpTariffSequence
            dcboImpStatisticalCode.Text = goods.ImpStatisticalCode
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


            If Not goods.ImpValueRate Is Nothing Then
                Dim imp As String = CStr(goods.ImpValueRate)
                txtImpValueRate.Value = imp
            Else
                txtImpValueRate.Value = "0"
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
            dcboExpTariffSequence.Text = goods.ExpTariffSequence
            dcboExpTariffCode.Text = goods.ExpTariffCode
            txtExpCustomsProductCode.Value = goods.ExpCustomsProductCode
            dcboExpStatisticalCode.Text = goods.ExpStatisticalCode
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
            txtImpValueRateP.Value = CStr(goods.ImpValueRate_P)

            txtImpEstablishNo.Value = goods.ImpEstablishNo
            txtImpFactoryNo.Value = goods.ImpFactoryNo
            txtExpEstablishNo.Value = goods.ExpEstablishNo
            txtExpFactoryNo.Value = goods.ExpFactoryNo

            Dim Brand As String = goods.ImpBrand
            showImpBrand(Brand)

            Dim iCurrency As String = goods.ImpCurrency
            showImpCurrency(iCurrency)

            Dim fUnit As String = goods.CartonVolUnit
            showPackageofUnit(fUnit)

            Dim Volume As String = goods.PalletVolUnit
            showUnitofVolume(Volume)

            Dim eCurrency As String = goods.ExpCurrency
            showExpCurrency(eCurrency)
            Dim pUnit As String = goods.PalletSetUnit
            showPackageUnit(pUnit)

            Dim tUnit As String = goods.CartonSetUnit
            showProductUnit(tUnit)

     
    End Sub

    Private Sub showGroupGoods()
        cdbGroupGoods.Items.Clear()
        cdbGroupGoods.Items.Add(New ListItem("--Select Group--", ""))
        cdbGroupGoods.AppendDataBoundItems = True

        Try
            Dim gg = From g In db.tblCodeMaster Where g.TypeID = "Type-039"
                 Select g.TypeID, g.Description
            cdbGroupGoods.DataSource = gg.ToList
            cdbGroupGoods.DataTextField = "Description"
            cdbGroupGoods.DataValueField = "Description"
            cdbGroupGoods.DataBind()
            If cdbGroupGoods.Items.Count > 1 Then
                cdbGroupGoods.Enabled = True
            Else
                cdbGroupGoods.Enabled = False

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub showGroupColor()
        cdbGroupColor.Items.Clear()
        cdbGroupColor.Items.Add(New ListItem("--Select Color--", ""))
        cdbGroupColor.AppendDataBoundItems = True
            Dim gg = From g In db.tblCodeMaster Where g.TypeID = "Type-006"
                      Select g.TypeID, g.Description
            Try
                cdbGroupColor.DataSource = gg.ToList
                cdbGroupColor.DataTextField = "Description"
                cdbGroupColor.DataValueField = "Description"
                cdbGroupColor.DataBind()
                If cdbGroupColor.Items.Count > 1 Then
                    cdbGroupColor.Enabled = True
                Else
                    cdbGroupColor.Enabled = False
                End If
            Catch ex As Exception
                Throw ex
            End Try

    End Sub


    Private Sub showImpBrand(Brand As String)
        dcboImpBrand.Items.Clear()
        dcboImpBrand.Items.Add(New ListItem(Brand, ""))
        dcboImpBrand.AppendDataBoundItems = True

        Dim gg = From g In db.tblCodeMaster Where g.TypeID = "Type-004"
                  Select g.TypeID, g.Description
        Try
            dcboImpBrand.DataSource = gg.ToList
            dcboImpBrand.DataTextField = "Description"
            dcboImpBrand.DataValueField = "Description"
            dcboImpBrand.DataBind()
            If dcboImpBrand.Items.Count > 1 Then
                dcboImpBrand.Enabled = True
            Else
                dcboImpBrand.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub showImpCurrency(Currency As String)
        cboImpCurrency.Items.Clear()
        cboImpCurrency.Items.Add(New ListItem(Currency, ""))
        cboImpCurrency.AppendDataBoundItems = True

        Dim cu = From c In db.tblCodeMaster Where c.TypeID = "Type-009"
         Select c.TypeID, c.Code
        Try
            cboImpCurrency.DataSource = cu.ToList
            cboImpCurrency.DataTextField = "Code"
            cboImpCurrency.DataValueField = "Code"
            cboImpCurrency.DataBind()
            If cboImpCurrency.Items.Count > 1 Then
                cboImpCurrency.Enabled = True
            Else
                cboImpCurrency.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub showExpCurrency(eCurrency As String)
        cboExpCurrency.Items.Clear()
        cboExpCurrency.Items.Add(New ListItem(eCurrency, ""))
        cboExpCurrency.AppendDataBoundItems = True

        Dim cu = From c In db.tblCodeMaster Where c.TypeID = "Type-009"
         Select c.TypeID, c.Code
        Try
            cboExpCurrency.DataSource = cu.ToList
            cboExpCurrency.DataTextField = "Code"
            cboExpCurrency.DataValueField = "Code"
            cboExpCurrency.DataBind()
            If cboExpCurrency.Items.Count > 1 Then
                cboExpCurrency.Enabled = True
            Else
                cboExpCurrency.Enabled = False

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub showProductUnit(Unit As String)
        cboProductUnit.Items.Clear()
        cboProductUnit.Items.Add(New ListItem(Unit, ""))
        cboProductUnit.AppendDataBoundItems = True

        Dim cu = From c In db.tblCodeMaster Where c.TypeID = "Type-043"
         Select c.TypeID, c.Code
        Try
            cboProductUnit.DataSource = cu.ToList
            cboProductUnit.DataTextField = "Code"
            cboProductUnit.DataValueField = "Code"
            cboProductUnit.DataBind()

            If cboPackageofUnit.Items.Count > 1 Then
                cboPackageofUnit.Enabled = True
            Else
                cboPackageofUnit.Enabled = True

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub showUnitofVolume(Volume As String)
        cboUnitofVolume.Items.Clear()
        cboUnitofVolume.Items.Add(New ListItem(Volume, ""))
        cboUnitofVolume.AppendDataBoundItems = True

        Dim cu = From c In db.tblCodeMaster Where c.TypeID = "Type-043"
         Select c.TypeID, c.Code
        Try
            cboUnitofVolume.DataSource = cu.ToList
            cboUnitofVolume.DataTextField = "Code"
            cboUnitofVolume.DataValueField = "Code"
            cboUnitofVolume.DataBind()
            If cboUnitofVolume.Items.Count > 1 Then
                cboUnitofVolume.Enabled = True
            Else
                cboUnitofVolume.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub showPackageUnit(Unit As String)
        cboPackageUnit.Items.Clear()
        cboPackageUnit.Items.Add(New ListItem(Unit, ""))
        cboPackageUnit.AppendDataBoundItems = True

        Dim cu = From c In db.tblCodeMaster Where c.TypeID = "Type-043"
         Select c.TypeID, c.Code
        Try
            cboPackageUnit.DataSource = cu.ToList
            cboPackageUnit.DataTextField = "Code"
            cboPackageUnit.DataValueField = "Code"
            cboPackageUnit.DataBind()

            If cboPackageUnit.Items.Count > 1 Then
                cboPackageUnit.Enabled = True
            Else
                cboPackageUnit.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub showPackageofUnit(Unit As String)
        cboPackageofUnit.Items.Clear()
        cboPackageofUnit.Items.Add(New ListItem(Unit, ""))
        cboPackageofUnit.AppendDataBoundItems = True

        Dim cu = From c In db.tblCodeMaster Where c.TypeID = "Type-043"
         Select c.TypeID, c.Code
        Try
            cboPackageofUnit.DataSource = cu.ToList
            cboPackageofUnit.DataTextField = "Code"
            cboPackageofUnit.DataValueField = "Code"
            cboPackageofUnit.DataBind()

            If cboPackageofUnit.Items.Count > 1 Then
                cboPackageofUnit.Enabled = True
            Else
                cboPackageofUnit.Enabled = False

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub GenCode()
        Dim Code As String
        If rbtEnable.Checked = True Then
            Code = CStr(txtGenCode.Value) & "-" & CStr(txtCodeGoods.Value) & "-" & CStr(txtCodeCustomers.Value)
            txtProductCode.Value = Code
        ElseIf rbtDisable.Checked = True Then
            Code = CStr(txtGenCode.Value) & "-" & CStr(txtCodeGoods.Value) & "-" & CStr(txtNoCodeGoods.Value) & CStr(txtCodeSize.Value) & CStr(txtCodeColor.Value)
            txtProductCode.Value = Code
        End If
    End Sub
    Protected Sub EditGoods_click(sender As Object, e As EventArgs)
        editGoods()
    End Sub
    Private Sub editGoods()
        Dim str As String = Me.txtRemarks.InnerText
        Dim idPC As String = Request.QueryString("ProductCode")

        If (String.IsNullOrEmpty(txtProductCode.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
          
        Else

            Using tran As New TransactionScope()



                Try
                    db.Database.Connection.Open()
                    Dim editGoods As tblProductDetail = (From goods In db.tblProductDetail Where goods.ProductCode = idPC
                       Select goods).First

                    editGoods.ProductCode = txtProductCode.Value
                    editGoods.PONo = txtProductPO.Value
                    editGoods.CustomerPart = txtCustomerPart.Value
                    editGoods.EndUserPart = txtEndUserPart.Value
                    editGoods.ImpProductCode = txtImpProductCode.Value
                    editGoods.TariffCode = dcboImpTariffCode.Text
                    editGoods.ImpDesc1 = txtImpDesc1.Value
                    editGoods.ImpStatus1 = ImpStatus1
                    editGoods.ImpDesc2 = txtImpDesc2.Value
                    editGoods.ImpStatus2 = ImpStatus2
                    editGoods.ImpDesc3 = txtImpDesc3.Value
                    editGoods.ImpStatus3 = ImpStatus3
                    editGoods.ImpProductAttribute1 = txtImpProductAttribute1.Value
                    editGoods.ImpProductAttribute2 = txtImpProductAttribute2.Value
                    editGoods.ImpTariffSequence = dcboImpTariffSequence.Text
                    editGoods.ImpStatisticalCode = dcboImpStatisticalCode.Text
                    editGoods.ImpCustomsProductCode = txtImpCustomsProductCode.Value
                    editGoods.ImpProductYear = txtImpProductYear.Value
                    editGoods.ImpDutytype = txtImpDutyType.Value
                    editGoods.ImpSpeciticRate = CType(Convert.ToDouble(txtImpSpeciticRate.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpValueRate_P = CType(Convert.ToDouble(txtImpValueRateP.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpSpecificCal = txtImpSpecificCal.Value
                    editGoods.ImpSpecificRate_P = CType(Convert.ToDouble(txtImpSpecificRateP.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpExemptVAT = CType(Convert.ToDouble(txtImpExemptVat.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpExemptDuty = CType(Convert.ToDouble(txtImpExemptDuty.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpExciseNo = txtImpExciseNo.Value
                    editGoods.ImpSurchargeRate = CType(CDbl(txtImpSurchargeRate.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpExciseRatePay = CType(Convert.ToDouble(txtImpExciseRatePay.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpExciseRate = CType(Convert.ToDouble(txtImpExciseRate.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpExciseSpcRatePay = CType(Convert.ToDouble(txtImpExciseSpcRatePay.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpExciseSpcRate = CType(Convert.ToDouble(txtImpExciseSpcRate.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpPriviege = txtImpPriviege.Value
                    editGoods.ImpExemptExcise = txtImpExemptExcise.Value
                    editGoods.ImpBrand = dcboImpBrand.Text
                    editGoods.ImpValueRate = CType(Convert.ToDouble(txtImpValueRate.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpCurrency = cboImpCurrency.Text
                    editGoods.ImpExchangeRate = CType(Convert.ToDouble(txtImpExchangeRate.Value).ToString("#,##0.000"), Double?)
                    editGoods.ImpValueRateAmount = CType(Convert.ToDouble(txtImpValueRateAmount.Value).ToString("#,##0.000"), Double?)
                    editGoods.ExpProductCode = txtExpProductCode.Value
                    editGoods.ExpDesc1 = txtExpDesc1.Value
                    editGoods.ExpStatus1 = ExpStatus1
                    editGoods.ExpDesc2 = txtExpDesc2.Value
                    editGoods.ExpStatus2 = ExpStatus2
                    editGoods.ExpDesc3 = txtExpDesc3.Value
                    editGoods.ExpStatus3 = ExpStatus3
                    editGoods.ExpProductAttribute1 = txtExpProductAttribute1.Value
                    editGoods.ExpProductAttribute2 = txtExpProductAttribute2.Value
                    editGoods.ExpTariffSequence = dcboExpTariffSequence.Text
                    editGoods.ExpTariffCode = dcboExpTariffCode.Text
                    editGoods.ExpCustomsProductCode = txtExpCustomsProductCode.Value
                    editGoods.ExpStatisticalCode = dcboExpStatisticalCode.Text
                    editGoods.ExpFomulaNo = txtExpFomulaNo.Value
                    editGoods.ExpProductYear = txtExpProductYear.Value
                    editGoods.ExpBOINo = txtExpBOINo.Value
                    editGoods.Exp19BisTranNo = txtExp19BisTranNo.Value
                    editGoods.ExpDutyType = txtExpDutyType.Value
                    editGoods.ExpBondFormulaNo = txtExpBondFormulaNo.Value
                    editGoods.ExpQTYCarton = CType(Convert.ToDouble(txtExpQtyCarton.Value).ToString("#,##0.000"), Double?)
                    editGoods.ExpPriceForeight = CType(Convert.ToDouble(txtExpPriceForeight.Value).ToString("#,##0.000"), Double?)
                    editGoods.ExpWeightCarton = CType(Convert.ToDouble(txtExpWeightCarton.Value).ToString("#,##0.000"), Double?)
                    editGoods.ExpQTYPallet = CType(Convert.ToDouble(txtExpQtyPallet.Value).ToString("#,##0.000"), Double?)
                    editGoods.ExpValueRate = CType(Convert.ToDouble(txtExpValueRate.Value).ToString("#,##0.000"), Double?)
                    editGoods.ExpCurrency = cboExpCurrency.Text
                    editGoods.ExpExchangeRate = CType(Convert.ToDouble(txtExpExchangeRate.Value).ToString("#,##0.000"), Double?)
                    editGoods.ExpValueRateAmount = CType(Convert.ToDouble(txtExpValueRateAmount.Value).ToString("#,##0.000"), Double?)
                    editGoods.CartonSetUnit = cboPackageofUnit.Text
                    editGoods.CartonWidth = CType(Convert.ToDouble(txtProductWidth.Value).ToString("#,##0.000"), Double?)
                    editGoods.CartonHeight = CType(Convert.ToDouble(txtProductHeight.Value).ToString("#,##0.000"), Double?)
                    editGoods.CartonLenght = CType(Convert.ToDouble(txtProductLeng.Value).ToString("#,##0.000"), Double?)
                    editGoods.CartonVolume = CType(Convert.ToDouble(txtProductVolume.Value).ToString("#,##0.000"), Double?)
                    editGoods.CartonVolUnit = cboUnitofVolume.Text
                    editGoods.PalletSetUnit = cboPackageUnit.Text
                    editGoods.SpecialHandling = str
                    editGoods.PalletWidth = CType(Convert.ToDouble(txtPackageWidth.Value).ToString("#,##0.000"), Double?)
                    editGoods.PalletHeight = CType(Convert.ToDouble(txtPackageHeigh.Value).ToString("#,##0.000"), Double?)
                    editGoods.PalletLenght = CType(Convert.ToDouble(txtPackageLenght.Value).ToString("#,##0.000"), Double?)
                    editGoods.PalletNoCarton = CType(Convert.ToDouble(txtPackageCarton.Value).ToString("#,##0.000"), Double?)
                    editGoods.PalletVolume = CType(Convert.ToDouble(txtPackageVolume.Value).ToString("#,##0.000"), Double?)
                    editGoods.PalletVolUnit = cboPackageUnit.Text
                    editGoods.ImpEstablishNo = txtImpEstablishNo.Value
                    editGoods.ImpFactoryNo = txtImpFactoryNo.Value
                    editGoods.ExpEstablishNo = txtExpEstablishNo.Value
                    editGoods.ExpFactoryNo = txtExpFactoryNo.Value
                    editGoods.UpdateBy = CStr(Session("UserName"))
                    editGoods.UpdateDate = Now

                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('แก้ไข Goods สำเร็จ !');", True)

                Catch ex As Exception

                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาแก้ไขข้อมูลใหม่อีกครั้ง');", True)

                Finally
                    db.Database.Connection.Close()
                    db.Dispose()
                    tran.Dispose()
                End Try

            End Using
        End If
    End Sub
End Class