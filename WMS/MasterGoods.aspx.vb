Option Explicit On
Option Strict On

Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data
Imports System.Security.Cryptography
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Transactions

Public Class MasterGoods
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1_Test
    Dim ImpStatus1 As String = "0"
    Dim ImpStatus2 As String = "0"
    Dim ImpStatus3 As String = "0"
    Dim ExpStatus1 As String = "0"
    Dim ExpStatus2 As String = "0"
    Dim ExpStatus3 As String = "0"
    'Dim db As New LKBwarehouseEntities


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showDATAStock()
            showExpCurrency()
            showGroupColor()
            showGroupGoods()
            showImpBrand()
            showImpCurrency()
            showPackageofUnit()
            showPackageUnit()
            showProductUnit()
            showUnitofVolume()
            show()
            showReapeaterStock()
        End If
    End Sub
    Private Sub showGroupGoods()
        cdbGroupGoods.Items.Clear()
        cdbGroupGoods.Items.Add(New ListItem("--Select Group--", ""))
        cdbGroupGoods.AppendDataBoundItems = True
        Dim gg = From g In db.tblMasterCode2 Where g.Type = "TYPEGOODS"
                         Select g.Description, g.Type
        Try
            'Dim gg = From g In db.tblMasterCode2 Where g.TypeID = "Type-039"
            '     Select g.TypeID, g.Description

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

        End Try
    End Sub

    Private Sub showGroupColor()
        cdbGroupColor.Items.Clear()
        cdbGroupColor.Items.Add(New ListItem("--Select Color--", ""))
        cdbGroupColor.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCode2 Where g.Type = "Color"
                  Select g.Type, g.Description
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


    Private Sub showImpBrand()
        dcboImpBrand.Items.Clear()
        dcboImpBrand.Items.Add(New ListItem("--Select Brand--", ""))
        dcboImpBrand.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCode2 Where g.Type = "BRAND"
                  Select g.Type, g.Description
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
    Private Sub showImpCurrency()
        cboImpCurrency.Items.Clear()
        cboImpCurrency.Items.Add(New ListItem("--Select Currency--", ""))
        cboImpCurrency.AppendDataBoundItems = True

        Dim cu = From c In db.tblMasterCode2 Where c.Type = "CURRENCY"
         Select c.Type, c.Code
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
    Private Sub showExpCurrency()
        cboExpCurrency.Items.Clear()
        cboExpCurrency.Items.Add(New ListItem("--Select Currency--", ""))
        cboExpCurrency.AppendDataBoundItems = True

        Dim cu = From c In db.tblMasterCode2 Where c.Type = "CURRENCY"
         Select c.Type, c.Code
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

    Private Sub showProductUnit()
        cboProductUnit.Items.Clear()
        cboProductUnit.Items.Add(New ListItem("--Select Unit--", ""))
        cboProductUnit.AppendDataBoundItems = True

        Dim cu = From c In db.tblMasterCode2 Where c.Type = "VOLUME"
         Select c.Type, c.Code
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

    Private Sub showUnitofVolume()
        cboUnitofVolume.Items.Clear()
        cboUnitofVolume.Items.Add(New ListItem("--Select Volume--", ""))
        cboUnitofVolume.AppendDataBoundItems = True

        Dim cu = From c In db.tblMasterCode2 Where c.Type = "VOLUME"
         Select c.Type, c.Code
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

    Private Sub showPackageUnit()
        cboPackageUnit.Items.Clear()
        cboPackageUnit.Items.Add(New ListItem("--Select Unit--", ""))
        cboPackageUnit.AppendDataBoundItems = True

        Dim cu = From c In db.tblMasterCode2 Where c.Type = "VOLUME"
         Select c.Type, c.Code
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

    Private Sub showPackageofUnit()
        cboPackageofUnit.Items.Clear()
        cboPackageofUnit.Items.Add(New ListItem("--Select Unit--", ""))
        cboPackageofUnit.AppendDataBoundItems = True

        Dim cu = From c In db.tblMasterCode2 Where c.Type = "VOLUME"
         Select c.Type, c.Code
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
    Protected Sub saveGoods_click(sender As Object, e As EventArgs)
        addGoods()
        Dim st As String = CStr(Convert.ToDecimal(txtImpSpeciticRate.Value))
        MsgBox(st)
    End Sub

    Protected Sub genCode_click(sender As Object, e As EventArgs)
        GenCode()
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

    Private Sub showDATAStock()

        'Dim sc = From ct In db.tblProductDetails
        '         Select ct.ProductCode,
        '         ct.PONo,
        '         ct.ImpProductCode,
        '         ct.EndUserPart,
        '         ct.ExpProductCode

        'If sc.Count > 0 Then
        '    Repeater1.DataSource = sc.ToList
        '    Repeater1.DataBind()

        'End If
      
    End Sub
    Private Sub show()
        txtMinimunStock.Value = "0"
        txtAdjustment.Value = "0"
        txtDamageQty.Value = "0"
        txtAvailableQTY.Value = "0"
        txtImpSpeciticRate.Value = "0"
        txtImpValueRateP.Value = "0"
        txtImpSpecificRateP.Value = "0"
        txtImpExemptVat.Value = "0"
        txtImpExemptDuty.Value = "0"
        txtImpSurchargeRate.Value = "0"
        txtImpExciseRatePay.Value = "0"
        txtImpExciseRate.Value = "0"
        txtImpExciseSpcRatePay.Value = "0"
        txtImpExciseSpcRate.Value = "0"
        txtImpValueRate.Value = "0"
        txtImpExchangeRate.Value = "0"
        txtImpValueRateAmount.Value = "0"
        txtExpQtyCarton.Value = "0"
        txtExpPriceForeight.Value = "0"
        txtExpWeightCarton.Value = "0"
        txtExpQtyPallet.Value = "0"
        txtExpValueRate.Value = "0"
        txtExpExchangeRate.Value = "0"
        txtExpValueRateAmount.Value = "0"
        txtProductWidth.Value = "0.0"
        txtProductHeight.Value = "0.0"
        txtProductLeng.Value = "0.0"
        txtProductVolume.Value = "0.0"
        txtPackageWidth.Value = "0.0"
        txtPackageHeigh.Value = "0.0"
        txtPackageLenght.Value = "0.0"
        txtPackageCarton.Value = "0.0"
        txtPackageVolume.Value = "0"
    End Sub
    Private Sub addGoods()
        Dim str As String = Me.txtRemarks.InnerText

        If (String.IsNullOrEmpty(txtProductCode.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
            Exit Sub
        Else
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()

                    db.tblProductDetails.Add(New tblProductDetail With { _
                       .ProductCode = txtProductCode.Value, _
                        .PONo = txtProductPO.Value, _
                        .CustomerPart = txtCustomerPart.Value, _
                        .EndUserPart = txtEndUserPart.Value, _
                        .ImpProductCode = txtImpProductCode.Value, _
                        .TariffCode = dcboImpTariffCode.Text, _
                        .ImpDesc1 = txtImpDesc1.Value, _
                        .ImpStatus1 = ImpStatus1, _
                        .ImpDesc2 = txtImpDesc2.Value, _
                        .ImpStatus2 = ImpStatus2, _
                        .ImpDesc3 = txtImpDesc3.Value, _
                        .ImpStatus3 = ImpStatus3, _
                        .ImpProductAttribute1 = txtImpProductAttribute1.Value, _
                        .ImpProductAttribute2 = txtImpProductAttribute2.Value, _
                        .ImpTariffSequence = dcboImpTariffSequence.Text, _
                        .ImpStatisticalCode = dcboImpStatisticalCode.Text, _
                        .ImpCustomsProductCode = txtImpCustomsProductCode.Value, _
                        .ImpProductYear = txtImpProductYear.Value, _
                        .ImpDutytype = txtImpDutyType.Value, _
                        .ImpSpeciticRate = CType(Convert.ToDouble(txtImpSpeciticRate.Value).ToString("#,##0.000"), Double?), _
                        .ImpValueRate_P = CType(Convert.ToDouble(txtImpValueRateP.Value).ToString("#,##0.000"), Double?), _
                        .ImpSpecificCal = txtImpSpecificCal.Value, _
                        .ImpSpecificRate_P = CType(Convert.ToDouble(txtImpSpecificRateP.Value).ToString("#,##0.000"), Double?), _
                        .ImpExemptVAT = CType(Convert.ToDouble(txtImpExemptVat.Value).ToString("#,##0.000"), Double?), _
                        .ImpExemptDuty = CType(Convert.ToDouble(txtImpExemptDuty.Value).ToString("#,##0.000"), Double?), _
                        .ImpExciseNo = txtImpExciseNo.Value, _
                        .ImpSurchargeRate = CType(CDbl(txtImpSurchargeRate.Value).ToString("#,##0.000"), Double?), _
                        .ImpExciseRatePay = CType(Convert.ToDouble(txtImpExciseRatePay.Value).ToString("#,##0.000"), Double?), _
                        .ImpExciseRate = CType(Convert.ToDouble(txtImpExciseRate.Value).ToString("#,##0.000"), Double?), _
                        .ImpExciseSpcRatePay = CType(Convert.ToDouble(txtImpExciseSpcRatePay.Value).ToString("#,##0.000"), Double?), _
                        .ImpExciseSpcRate = CType(Convert.ToDouble(txtImpExciseSpcRate.Value).ToString("#,##0.000"), Double?), _
                        .ImpPriviege = txtImpPriviege.Value, _
                        .ImpExemptExcise = txtImpExemptExcise.Value, _
                        .ImpBrand = dcboImpBrand.Text, _
                        .ImpValueRate = CType(Convert.ToDouble(txtImpValueRate.Value).ToString("#,##0.000"), Double?), _
                        .ImpCurrency = cboImpCurrency.Text, _
                        .ImpExchangeRate = CType(Convert.ToDouble(txtImpExchangeRate.Value).ToString("#,##0.000"), Double?), _
                        .ImpValueRateAmount = CType(Convert.ToDouble(txtImpValueRateAmount.Value).ToString("#,##0.000"), Double?), _
                        .ExpProductCode = txtExpProductCode.Value, _
                        .ExpDesc1 = txtExpDesc1.Value, _
                        .ExpStatus1 = ExpStatus1, _
                        .ExpDesc2 = txtExpDesc2.Value, _
                        .ExpStatus2 = ExpStatus2, _
                        .ExpDesc3 = txtExpDesc3.Value, _
                        .ExpStatus3 = ExpStatus3, _
                        .ExpProductAttribute1 = txtExpProductAttribute1.Value, _
                        .ExpProductAttribute2 = txtExpProductAttribute2.Value, _
                        .ExpTariffSequence = dcboExpTariffSequence.Text, _
                        .ExpTariffCode = dcboExpTariffCode.Text, _
                        .ExpCustomsProductCode = txtExpCustomsProductCode.Value, _
                        .ExpStatisticalCode = dcboExpStatisticalCode.Text, _
                        .ExpFomulaNo = txtExpFomulaNo.Value, _
                        .ExpProductYear = txtExpProductYear.Value, _
                        .ExpBOINo = txtExpBOINo.Value, _
                        .Exp19BisTranNo = txtExp19BisTranNo.Value, _
                        .ExpDutyType = txtExpDutyType.Value, _
                        .ExpBondFormulaNo = txtExpBondFormulaNo.Value, _
                        .ExpQTYCarton = CType(Convert.ToDouble(txtExpQtyCarton.Value).ToString("#,##0.000"), Double?), _
                        .ExpPriceForeight = CType(Convert.ToDouble(txtExpPriceForeight.Value).ToString("#,##0.000"), Double?), _
                        .ExpWeightCarton = CType(Convert.ToDouble(txtExpWeightCarton.Value).ToString("#,##0.000"), Double?), _
                        .ExpQTYPallet = CType(Convert.ToDouble(txtExpQtyPallet.Value).ToString("#,##0.000"), Double?), _
                        .ExpValueRate = CType(Convert.ToDouble(txtExpValueRate.Value).ToString("#,##0.000"), Double?), _
                        .ExpCurrency = cboExpCurrency.Text, _
                        .ExpExchangeRate = CType(Convert.ToDouble(txtExpExchangeRate.Value).ToString("#,##0.000"), Double?), _
                        .ExpValueRateAmount = CType(Convert.ToDouble(txtExpValueRateAmount.Value).ToString("#,##0.000"), Double?), _
                        .CartonSetUnit = cboPackageofUnit.Text, _
                        .CartonWidth = CType(Convert.ToDouble(txtProductWidth.Value).ToString("#,##0.000"), Double?), _
                        .CartonHeight = CType(Convert.ToDouble(txtProductHeight.Value).ToString("#,##0.000"), Double?), _
                        .CartonLenght = CType(Convert.ToDouble(txtProductLeng.Value).ToString("#,##0.000"), Double?), _
                        .CartonVolume = CType(Convert.ToDouble(txtProductVolume.Value).ToString("#,##0.000"), Double?), _
                        .CartonVolUnit = cboUnitofVolume.Text, _
                        .PalletSetUnit = cboPackageUnit.Text, _
                        .SpecialHandling = str, _
                        .PalletWidth = CType(Convert.ToDouble(txtPackageWidth.Value).ToString("#,##0.000"), Double?), _
                        .PalletHeight = CType(Convert.ToDouble(txtPackageHeigh.Value).ToString("#,##0.000"), Double?), _
                        .PalletLenght = CType(Convert.ToDouble(txtPackageLenght.Value).ToString("#,##0.000"), Double?), _
                        .PalletNoCarton = CType(Convert.ToDouble(txtPackageCarton.Value).ToString("#,##0.000"), Double?), _
                        .PalletVolume = CType(Convert.ToDouble(txtPackageVolume.Value).ToString("#,##0.000"), Double?), _
                        .PalletVolUnit = cboPackageUnit.Text, _
                        .ImpEstablishNo = txtImpEstablishNo.Value, _
                        .ImpFactoryNo = txtImpFactoryNo.Value, _
                        .ExpEstablishNo = txtExpEstablishNo.Value, _
                        .ExpFactoryNo = txtExpFactoryNo.Value, _
                        .CreateBy = CStr(Session("UserName")), _
                        .CreateDate = Now
                })

                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เพิ่ม Goods สำเร็จ !');", True)

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
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim index As String = CStr(e.CommandArgument)

        If e.CommandName.Equals("editGoods") Then
            Response.Write("<script>window.open('UpdateGoods.aspx?ProductCode=" & index & "',target='_self');</script>")
        ElseIf e.CommandName.Equals("viewGoods") Then

            Response.Write("<script>window.open('ViewGoods.aspx?ProductCode=" & index & "',target='_self');</script>")

        End If
    End Sub
    Public Sub showReapeaterStock()
        Dim formlist = (From u In db.tblWHStockCtrls)

        If formlist.Count > 0 Then
            Repeater1.DataSource = formlist.ToList
            Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If
    End Sub

End Class