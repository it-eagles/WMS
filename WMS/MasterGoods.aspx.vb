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
    Dim db As New LKBWarehouseEntities1
    Dim ImpStatus1 As String = "0"
    Dim ImpStatus2 As String = "0"
    Dim ImpStatus3 As String = "0"
    Dim ExpStatus1 As String = "0"
    Dim ExpStatus2 As String = "0"
    Dim ExpStatus3 As String = "0"
    'Dim db As New LKBwarehouseEntities


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ReadDATAStock()
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


            beforecustomtab_fieldset.Disabled = True
            stockqty_fieldset.Disabled = True
            importgoods_fieldset.Disabled = True
            exportgoods_fieldset.Disabled = True
            detailofgoods_fieldset.Disabled = True
            assembly_fieldset.Disabled = True

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
        Dim TariffCodee As String
        Dim ImpTariffSequencee As String
        Dim ImpStatisticalCodee As String
        Dim ImpBrandd As String
        Dim ExpTariffSequencee As String
        Dim ExpTariffCode As String
        Dim ExpStatisticalCode As String

        Dim str As String = Me.txtRemarks.InnerText
        Dim chkproductcode = (From z In db.tblProductDetails Where z.ProductCode = txtProductCode.Value Select z).FirstOrDefault
        If (String.IsNullOrEmpty(txtProductCode.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
            Exit Sub
        ElseIf Not chkproductcode Is Nothing Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('ชื่อ Productcode ซ้ำ กรุณาเปลี่ยนใหม่');", True)
        Else

            If String.IsNullOrEmpty(dcboImpTariffCode.Text) Then
                TariffCodee = Nothing
            Else
                TariffCodee = dcboImpTariffCode.Text
            End If

            If String.IsNullOrEmpty(dcboImpTariffSequence.Text) Then
                ImpTariffSequencee = Nothing
            Else
                ImpTariffSequencee = dcboImpTariffSequence.Text
            End If

            If String.IsNullOrEmpty(dcboImpStatisticalCode.Text) Then
                ImpStatisticalCodee = Nothing
            Else
                ImpStatisticalCodee = dcboImpStatisticalCode.Text
            End If

            If String.IsNullOrEmpty(dcboImpBrand.Text) Then
                ImpBrandd = Nothing
            Else
                ImpBrandd = dcboImpBrand.Text
            End If

            If String.IsNullOrEmpty(dcboExpTariffSequence.Text) Then
                ExpTariffSequencee = Nothing
            Else
                ExpTariffSequencee = dcboExpTariffSequence.Text
            End If

            If String.IsNullOrEmpty(dcboExpTariffCode.Text) Then
                ExpTariffCode = Nothing
            Else
                ExpTariffCode = dcboExpTariffCode.Text
            End If

            If String.IsNullOrEmpty(dcboExpStatisticalCode.Text) Then
                ExpStatisticalCode = Nothing
            Else
                ExpStatisticalCode = dcboExpStatisticalCode.Text
            End If

            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()

                    db.tblProductDetails.Add(New tblProductDetail With { _
                       .ProductCode = txtProductCode.Value
                })
                    db.SaveChanges()
                    '.PONo = txtProductPO.Value, _
                    '    .CustomerPart = txtCustomerPart.Value, _
                    '    .EndUserPart = txtEndUserPart.Value, _
                    '    .ImpProductCode = txtImpProductCode.Value, _
                    '    .TariffCode = TariffCodee, _
                    '    .ImpDesc1 = txtImpDesc1.Value, _
                    '    .ImpStatus1 = ImpStatus1, _
                    '    .ImpDesc2 = txtImpDesc2.Value, _
                    '    .ImpStatus2 = ImpStatus2, _
                    '    .ImpDesc3 = txtImpDesc3.Value, _
                    '    .ImpStatus3 = ImpStatus3, _
                    '    .ImpProductAttribute1 = txtImpProductAttribute1.Value, _
                    '    .ImpProductAttribute2 = txtImpProductAttribute2.Value, _
                    '    .ImpTariffSequence = ImpTariffSequencee, _
                    '    .ImpStatisticalCode = ImpStatisticalCodee, _
                    '    .ImpCustomsProductCode = txtImpCustomsProductCode.Value, _
                    '    .ImpProductYear = txtImpProductYear.Value, _
                    '    .ImpDutytype = txtImpDutyType.Value, _
                    '.ImpSpeciticRate = CType(Convert.ToDouble(txtImpSpeciticRate.Value).ToString("#,##0.000"), Double?), _
                    '.ImpValueRate_P = CType(Convert.ToDouble(txtImpValueRateP.Value).ToString("#,##0.000"), Double?), _
                    '.ImpSpecificCal = txtImpSpecificCal.Value, _
                    '.ImpSpecificRate_P = CType(Convert.ToDouble(txtImpSpecificRateP.Value).ToString("#,##0.000"), Double?), _
                    '.ImpExemptVAT = CType(Convert.ToDouble(txtImpExemptVat.Value).ToString("#,##0.000"), Double?), _
                    '.ImpExemptDuty = CType(Convert.ToDouble(txtImpExemptDuty.Value).ToString("#,##0.000"), Double?), _
                    '.ImpExciseNo = txtImpExciseNo.Value, _
                    '.ImpSurchargeRate = CType(CDbl(txtImpSurchargeRate.Value).ToString("#,##0.000"), Double?), _
                    '.ImpExciseRatePay = CType(Convert.ToDouble(txtImpExciseRatePay.Value).ToString("#,##0.000"), Double?), _
                    '.ImpExciseRate = CType(Convert.ToDouble(txtImpExciseRate.Value).ToString("#,##0.000"), Double?), _
                    '.ImpExciseSpcRatePay = CType(Convert.ToDouble(txtImpExciseSpcRatePay.Value).ToString("#,##0.000"), Double?), _
                    '.ImpExciseSpcRate = CType(Convert.ToDouble(txtImpExciseSpcRate.Value).ToString("#,##0.000"), Double?), _
                    '.ImpPriviege = txtImpPriviege.Value, _
                    '.ImpExemptExcise = txtImpExemptExcise.Value, _
                    '.ImpBrand = ImpBrandd, _
                    '.ImpValueRate = CType(Convert.ToDouble(txtImpValueRate.Value).ToString("#,##0.000"), Double?), _
                    '.ImpCurrency = cboImpCurrency.Text, _
                    '.ImpExchangeRate = CType(Convert.ToDouble(txtImpExchangeRate.Value).ToString("#,##0.000"), Double?), _
                    '.ImpValueRateAmount = CType(Convert.ToDouble(txtImpValueRateAmount.Value).ToString("#,##0.000"), Double?), _
                    '.ExpProductCode = txtExpProductCode.Value, _
                    '.ExpDesc1 = txtExpDesc1.Value, _
                    '.ExpStatus1 = ExpStatus1, _
                    '.ExpDesc2 = txtExpDesc2.Value, _
                    '.ExpStatus2 = ExpStatus2, _
                    '.ExpDesc3 = txtExpDesc3.Value, _
                    '.ExpStatus3 = ExpStatus3, _
                    '.ExpProductAttribute1 = txtExpProductAttribute1.Value, _
                    '.ExpProductAttribute2 = txtExpProductAttribute2.Value, _
                    '.ExpTariffSequence = ExpTariffSequencee, _
                    '.ExpTariffCode = ExpTariffCode, _
                    '.ExpCustomsProductCode = txtExpCustomsProductCode.Value, _
                    '.ExpStatisticalCode = ExpStatisticalCode, _
                    '.ExpFomulaNo = txtExpFomulaNo.Value, _
                    '.ExpProductYear = txtExpProductYear.Value, _
                    '.ExpBOINo = txtExpBOINo.Value, _
                    '.Exp19BisTranNo = txtExp19BisTranNo.Value, _
                    '.ExpDutyType = txtExpDutyType.Value, _
                    '.ExpBondFormulaNo = txtExpBondFormulaNo.Value, _
                    '.ExpQTYCarton = CType(Convert.ToDouble(txtExpQtyCarton.Value).ToString("#,##0.000"), Double?), _
                    '.ExpPriceForeight = CType(Convert.ToDouble(txtExpPriceForeight.Value).ToString("#,##0.000"), Double?), _
                    '.ExpWeightCarton = CType(Convert.ToDouble(txtExpWeightCarton.Value).ToString("#,##0.000"), Double?), _
                    '.ExpQTYPallet = CType(Convert.ToDouble(txtExpQtyPallet.Value).ToString("#,##0.000"), Double?), _
                    '.ExpValueRate = CType(Convert.ToDouble(txtExpValueRate.Value).ToString("#,##0.000"), Double?), _
                    '.ExpCurrency = cboExpCurrency.Text, _
                    '.ExpExchangeRate = CType(Convert.ToDouble(txtExpExchangeRate.Value).ToString("#,##0.000"), Double?), _
                    '.ExpValueRateAmount = CType(Convert.ToDouble(txtExpValueRateAmount.Value).ToString("#,##0.000"), Double?), _
                    '.CartonSetUnit = cboPackageofUnit.Text, _
                    '.CartonWidth = CType(Convert.ToDouble(txtProductWidth.Value).ToString("#,##0.000"), Double?), _
                    '.CartonHeight = CType(Convert.ToDouble(txtProductHeight.Value).ToString("#,##0.000"), Double?), _
                    '.CartonLenght = CType(Convert.ToDouble(txtProductLeng.Value).ToString("#,##0.000"), Double?), _
                    '.CartonVolume = CType(Convert.ToDouble(txtProductVolume.Value).ToString("#,##0.000"), Double?), _
                    '.CartonVolUnit = cboUnitofVolume.Text, _
                    '.PalletSetUnit = cboPackageUnit.Text, _
                    '.SpecialHandling = str, _
                    '.PalletWidth = CType(Convert.ToDouble(txtPackageWidth.Value).ToString("#,##0.000"), Double?), _
                    '.PalletHeight = CType(Convert.ToDouble(txtPackageHeigh.Value).ToString("#,##0.000"), Double?), _
                    '.PalletLenght = CType(Convert.ToDouble(txtPackageLenght.Value).ToString("#,##0.000"), Double?), _
                    '.PalletNoCarton = CType(Convert.ToDouble(txtPackageCarton.Value).ToString("#,##0.000"), Double?), _
                    '.PalletVolume = CType(Convert.ToDouble(txtPackageVolume.Value).ToString("#,##0.000"), Double?), _
                    '.PalletVolUnit = cboPackageUnit.Text, _
                    '.ImpEstablishNo = txtImpEstablishNo.Value, _
                    '.ImpFactoryNo = txtImpFactoryNo.Value, _
                    '.ExpEstablishNo = txtExpEstablishNo.Value, _
                    '.ExpFactoryNo = txtExpFactoryNo.Value, _
                    '.CreateBy = CStr(Session("UserName")), _
                    '.CreateDate = Now


                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เพิ่ม Goods สำเร็จ !');", True)

                Catch ex As Exception
                    tran.Dispose()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)

                End Try

            End Using

        End If

    End Sub
    '--------------------------------------------------------Show Data Flight In Modal-----------------------------------------
    Private Sub ReadDATAStock()
        Dim testdate As Integer
        Dim Pro As String
        If String.IsNullOrEmpty(txtProductCode.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            Pro = txtProductCode.Value.Trim
        End If

        Dim cons = (From p In db.tblWHStockCtrls
                    Where p.ProductCode = txtProductCode.Value.Trim Order By p.CreateDate Descending
                   Select New With {p.ProductCode,
                                    p.OwnerPart,
                                    p.ENDUserPart,
                                    p.ProductDescription}).ToList()

        If cons.Count > 0 Then
            Repeater10.DataSource = cons.ToList
            Repeater10.DataBind()
        Else
            Repeater10.DataSource = Nothing
            Repeater10.DataBind()
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------Click Data Data Flight -----------------------------------------
    Protected Sub Repeater10_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater10.ItemCommand
        'Dim Numberr As Double = CDbl(e.CommandArgument)
        'Try
        '    If e.CommandName.Equals("Selectdataflight") Then

        '        If String.IsNullOrEmpty(CStr(Numberr)) Then
        '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เป็นค่าว่าง');", True)
        '        Else
        '            Dim user = (From u In db.tblImpLogFlights Where u.LotNo = txtJobno.Value.Trim And u.Number = Numberr).SingleOrDefault

        '            txtFlightNo.Value = user.FlightNo
        '            NumberFlight = user.Number
        '            txtdatepickerFlightDateInvoice.Text = CStr(user.DateFlight)
        '            txtQuantity_PLT_Skid_Invoice.Value = CStr(user.Quantity)
        '            txtQuantity_PLT_Skid_Invoice2.Value = user.HouseNo
        '            If String.IsNullOrEmpty(user.UnitQuantity) Then
        '                'ddlQuantity_PLT_Skid_Invoice.Text = ""
        '            Else
        '                ddlQuantity_PLT_Skid_Invoice.Text = user.UnitQuantity
        '            End If
        '            If String.IsNullOrEmpty(user.House) Then
        '                'ddlQuantity_PLT_Skid_Invoice2.Text = ""
        '            Else
        '                ddlQuantity_PLT_Skid_Invoice2.Text = user.House
        '            End If

        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Protected Sub btnAddHead_ServerClick(sender As Object, e As EventArgs)
        btnAddGoods.Visible = True
        btnSaveEditHead.Visible = False
        btnDelete.Visible = False
        btnmodal.Visible = True
        btnSearchProduct.Visible = False
        txtProductCode.Disabled = True

        beforecustomtab_fieldset.Disabled = False
        stockqty_fieldset.Disabled = False
        importgoods_fieldset.Disabled = False
        exportgoods_fieldset.Disabled = False
        detailofgoods_fieldset.Disabled = False
        assembly_fieldset.Disabled = True

    End Sub

    Protected Sub btnEditHead_ServerClick(sender As Object, e As EventArgs)
        btnAddGoods.Visible = False
        btnSaveEditHead.Visible = True
        btnDelete.Visible = True
        btnmodal.Visible = False
        btnSearchProduct.Visible = True
        txtProductCode.Disabled = False

        beforecustomtab_fieldset.Disabled = False
        stockqty_fieldset.Disabled = False
        importgoods_fieldset.Disabled = False
        exportgoods_fieldset.Disabled = False
        detailofgoods_fieldset.Disabled = False
        assembly_fieldset.Disabled = True
    End Sub
    Protected Sub saveGoods_click(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmProductDetail"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            'CallculateProductVolume()
            'CallculatePackageVolume()
            addGoods()
            SaveDATAStock_New()
            InsertData()
            FinishGood()
            Dim st As String = txtImpSpeciticRate.Value
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If

    End Sub

    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmProductDetail"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            CallculateProductVolume()
            CallculatePackageVolume()
            SaveDATA_Modify()
            SaveDATAStock_Modify()
            InsertData()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub

    Protected Sub cdbGroupGoods_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim mas = (From m In db.tblMasterCode2 Where m.Description = cdbGroupGoods.Text.Trim Select m.Code, m.Description).SingleOrDefault
        txtCodeGoods.Value = mas.Code

    End Sub

    Protected Sub cdbGroupColor_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim mas = (From m In db.tblMasterCode2 Where m.Description = cdbGroupColor.Text.Trim Select m.Code, m.Description).SingleOrDefault
        txtCodeColor.Value = mas.Code
    End Sub
    Private Sub SaveDATAStock_New() 'Save Data New
        Dim ChkDes1 As String = ""
        If txtProductCode.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
            txtProductCode.Focus()
            Exit Sub
        End If
        'sb.Append("INSERT INTO tblWHStockCtrl (ProductCode,OwnerPart,EndUserPart,ProductDescription,MinimumStock,Adjustment,DamageQTY,AvailableQTY,CreateBy,CreateDate)")
        'sb.Append(" VALUES (@ProductCode,@OwnerPart,@EndUserPart,@ProductDescription,@MinimumStock,@Adjustment,@DamageQTY,@AvailableQTY,@CreateBy,@CreateDate)")

        If String.IsNullOrEmpty(txtImpDesc1.Value.Trim) Then
            ChkDes1 = txtExpDesc1.Value.Trim
        Else
            ChkDes1 = txtImpDesc1.Value.Trim
        End If

        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()

                db.tblWHStockCtrls.Add(New tblWHStockCtrl With { _
                .ProductCode = txtProductCode.Value.Trim, _
                .OwnerPart = txtCustomerPart.Value.Trim, _
                .ENDUserPart = txtEndUserPart.Value.Trim, _
                .ProductDescription = ChkDes1, _
                .MinimumStock = CType(txtMinimunStock.Value.Trim, Double?), _
                .Adjustment = CType(txtAdjustment.Value.Trim, Double?), _
                .DamageQTY = CType(txtDamageQty.Value.Trim, Double?), _
                .AvailableQTY = CType(txtAvailableQTY.Value.Trim, Double?), _
                .CreateBy = CStr(Session("UserName")), _
                .CreateDate = Now
                })
                db.SaveChanges()
                tran.Complete()

            Catch ex As Exception
                tran.Dispose()
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดที่ SaveDATAStock_New กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            End Try
        End Using

        'MessageBox.Show("คุณป้อน Product Code ซ้ำ !!!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        txtProductCode.Focus()
    End Sub
    Private Sub InsertData()
        Using tran As New TransactionScope()
            Try
                db.tblLogProductDetails.Add(New tblLogProductDetail With { _
                                    .ProductCode = txtProductCode.Value.Trim, _
                                    .UserBy = CStr(Session("UserName")), _
                                    .LastUpDate = Now
                                })
                db.SaveChanges()
                tran.Complete()
            Catch ex As Exception
                tran.Dispose()
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด Function: InsertData กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            End Try
        End Using
    End Sub
    Private Sub SaveDATA_Modify()
        If txtProductCode.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
            txtProductCode.Focus()
            Exit Sub
        End If

        If MsgBox("คุณต้องการแก้ไขข้อมูล Product Item ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using tran As New TransactionScope()
                Try
                    db.Database.Connection.Open()

                    Dim edit As tblProductDetail = (From c In db.tblProductDetails Where c.ProductCode = txtProductCode.Value.Trim
                      Select c).First()
                    If edit IsNot Nothing Then
                        edit.PONo = txtProductPO.Value
                        edit.CustomerPart = txtCustomerPart.Value
                        edit.EndUserPart = txtEndUserPart.Value
                        edit.ImpProductCode = txtImpProductCode.Value
                        edit.TariffCode = dcboImpTariffCode.Text
                        edit.ImpDesc1 = txtImpDesc1.Value
                        edit.ImpStatus1 = ImpStatus1
                        edit.ImpDesc2 = txtImpDesc2.Value
                        edit.ImpStatus2 = ImpStatus2
                        edit.ImpDesc3 = txtImpDesc3.Value
                        edit.ImpStatus3 = ImpStatus3
                        edit.ImpProductAttribute1 = txtImpProductAttribute1.Value
                        edit.ImpProductAttribute2 = txtImpProductAttribute2.Value
                        edit.ImpTariffSequence = dcboImpTariffSequence.Text
                        edit.ImpStatisticalCode = dcboImpStatisticalCode.Text
                        edit.ImpCustomsProductCode = txtImpCustomsProductCode.Value
                        edit.ImpProductYear = txtImpProductYear.Value
                        edit.ImpDutytype = txtImpDutyType.Value
                        edit.ImpSpeciticRate = CType(Convert.ToDouble(txtImpSpeciticRate.Value).ToString("#,##0.000"), Double?)
                        edit.ImpValueRate_P = CType(Convert.ToDouble(txtImpValueRateP.Value).ToString("#,##0.000"), Double?)
                        edit.ImpSpecificCal = txtImpSpecificCal.Value
                        edit.ImpSpecificRate_P = CType(Convert.ToDouble(txtImpSpecificRateP.Value).ToString("#,##0.000"), Double?)
                        edit.ImpExemptVAT = CType(Convert.ToDouble(txtImpExemptVat.Value).ToString("#,##0.000"), Double?)
                        edit.ImpExemptDuty = CType(Convert.ToDouble(txtImpExemptDuty.Value).ToString("#,##0.000"), Double?)
                        edit.ImpExciseNo = txtImpExciseNo.Value
                        edit.ImpSurchargeRate = CType(CDbl(txtImpSurchargeRate.Value).ToString("#,##0.000"), Double?)
                        edit.ImpExciseRatePay = CType(Convert.ToDouble(txtImpExciseRatePay.Value).ToString("#,##0.000"), Double?)
                        edit.ImpExciseRate = CType(Convert.ToDouble(txtImpExciseRate.Value).ToString("#,##0.000"), Double?)
                        edit.ImpExciseSpcRatePay = CType(Convert.ToDouble(txtImpExciseSpcRatePay.Value).ToString("#,##0.000"), Double?)
                        edit.ImpExciseSpcRate = CType(Convert.ToDouble(txtImpExciseSpcRate.Value).ToString("#,##0.000"), Double?)
                        edit.ImpPriviege = txtImpPriviege.Value
                        edit.ImpExemptExcise = txtImpExemptExcise.Value
                        edit.ImpBrand = dcboImpBrand.Text
                        edit.ImpValueRate = CType(Convert.ToDouble(txtImpValueRate.Value).ToString("#,##0.000"), Double?)
                        edit.ImpCurrency = cboImpCurrency.Text
                        edit.ImpExchangeRate = CType(Convert.ToDouble(txtImpExchangeRate.Value).ToString("#,##0.000"), Double?)
                        edit.ImpValueRateAmount = CType(Convert.ToDouble(txtImpValueRateAmount.Value).ToString("#,##0.000"), Double?)
                        edit.ExpProductCode = txtExpProductCode.Value
                        edit.ExpDesc1 = txtExpDesc1.Value
                        edit.ExpStatus1 = ExpStatus1
                        edit.ExpDesc2 = txtExpDesc2.Value
                        edit.ExpStatus2 = ExpStatus2
                        edit.ExpDesc3 = txtExpDesc3.Value
                        edit.ExpStatus3 = ExpStatus3
                        edit.ExpProductAttribute1 = txtExpProductAttribute1.Value
                        edit.ExpProductAttribute2 = txtExpProductAttribute2.Value
                        edit.ExpTariffSequence = dcboExpTariffSequence.Text
                        edit.ExpTariffCode = dcboExpTariffCode.Text
                        edit.ExpCustomsProductCode = txtExpCustomsProductCode.Value
                        edit.ExpStatisticalCode = dcboExpStatisticalCode.Text
                        edit.ExpFomulaNo = txtExpFomulaNo.Value
                        edit.ExpProductYear = txtExpProductYear.Value
                        edit.ExpBOINo = txtExpBOINo.Value
                        edit.Exp19BisTranNo = txtExp19BisTranNo.Value
                        edit.ExpDutyType = txtExpDutyType.Value
                        edit.ExpBondFormulaNo = txtExpBondFormulaNo.Value
                        edit.ExpQTYCarton = CType(Convert.ToDouble(txtExpQtyCarton.Value).ToString("#,##0.000"), Double?)
                        edit.ExpPriceForeight = CType(Convert.ToDouble(txtExpPriceForeight.Value).ToString("#,##0.000"), Double?)
                        edit.ExpWeightCarton = CType(Convert.ToDouble(txtExpWeightCarton.Value).ToString("#,##0.000"), Double?)
                        edit.ExpQTYPallet = CType(Convert.ToDouble(txtExpQtyPallet.Value).ToString("#,##0.000"), Double?)
                        edit.ExpValueRate = CType(Convert.ToDouble(txtExpValueRate.Value).ToString("#,##0.000"), Double?)
                        edit.ExpCurrency = cboExpCurrency.Text
                        edit.ExpExchangeRate = CType(Convert.ToDouble(txtExpExchangeRate.Value).ToString("#,##0.000"), Double?)
                        edit.ExpValueRateAmount = CType(Convert.ToDouble(txtExpValueRateAmount.Value).ToString("#,##0.000"), Double?)
                        edit.CartonSetUnit = cboPackageofUnit.Text
                        edit.CartonWidth = CType(Convert.ToDouble(txtProductWidth.Value).ToString("#,##0.000"), Double?)
                        edit.CartonHeight = CType(Convert.ToDouble(txtProductHeight.Value).ToString("#,##0.000"), Double?)
                        edit.CartonLenght = CType(Convert.ToDouble(txtProductLeng.Value).ToString("#,##0.000"), Double?)
                        edit.CartonVolume = CType(Convert.ToDouble(txtProductVolume.Value).ToString("#,##0.000"), Double?)
                        edit.CartonVolUnit = cboUnitofVolume.Text
                        edit.PalletSetUnit = cboPackageUnit.Text
                        edit.SpecialHandling = txtRemarks.Value.Trim
                        edit.PalletWidth = CType(Convert.ToDouble(txtPackageWidth.Value).ToString("#,##0.000"), Double?)
                        edit.PalletHeight = CType(Convert.ToDouble(txtPackageHeigh.Value).ToString("#,##0.000"), Double?)
                        edit.PalletLenght = CType(Convert.ToDouble(txtPackageLenght.Value).ToString("#,##0.000"), Double?)
                        edit.PalletNoCarton = CType(Convert.ToDouble(txtPackageCarton.Value).ToString("#,##0.000"), Double?)
                        edit.PalletVolume = CType(Convert.ToDouble(txtPackageVolume.Value).ToString("#,##0.000"), Double?)
                        edit.PalletVolUnit = cboPackageUnit.Text
                        edit.ImpEstablishNo = txtImpEstablishNo.Value
                        edit.ImpFactoryNo = txtImpFactoryNo.Value
                        edit.ExpEstablishNo = txtExpEstablishNo.Value
                        edit.ExpFactoryNo = txtExpFactoryNo.Value
                        edit.UpdateBy = CStr(Session("UserName"))
                        edit.UpdateDate = Now

                        db.SaveChanges()
                        tran.Complete()
                    End If
                Catch ex As Exception
                    tran.Dispose()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดจาก SaveDATA_Modify กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
    End Sub
    Private Sub SaveDATAStock_Modify()
        Dim chkDes1 As String = ""
        If txtProductCode.Value.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
            txtProductCode.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtImpDesc1.Value.Trim) Then
            ChkDes1 = txtExpDesc1.Value.Trim
        Else
            ChkDes1 = txtImpDesc1.Value.Trim
        End If

        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()

                Dim edit As tblWHStockCtrl = (From c In db.tblWHStockCtrls Where c.ProductCode = txtProductCode.Value.Trim
                  Select c).First()
                If edit IsNot Nothing Then
                    edit.ProductCode = txtProductCode.Value.Trim
                    edit.OwnerPart = txtCustomerPart.Value.Trim
                    edit.ENDUserPart = txtEndUserPart.Value.Trim
                    edit.ProductDescription = ChkDes1
                    edit.MinimumStock = CType(txtMinimunStock.Value.Trim, Double?)
                    edit.Adjustment = CType(txtAdjustment.Value.Trim, Double?)
                    edit.DamageQTY = CType(txtDamageQty.Value.Trim, Double?)
                    edit.AvailableQTY = CType(txtAvailableQTY.Value.Trim, Double?)
                    edit.UpdateBy = CStr(Session("UserName"))
                    edit.UpdateDate = Now

                    db.SaveChanges()
                    tran.Complete()
                End If
            Catch ex As Exception
                tran.Dispose()
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดจาก SaveDATAStock_Modify กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            End Try
        End Using

    End Sub

    Private Sub ReadDATA()
        Dim testdate As Integer
        Dim Proo As String
        If String.IsNullOrEmpty(txtProductCode.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            Proo = txtProductCode.Value.Trim
        End If

        'Where e.LOTDate.Year = testdate
        Dim exl = (From e In db.tblProductDetails Where e.ProductCode.Contains(txtProductCode.Value.Trim) Or (e.CreateDate.Year = testdate)
                 Select New With {
                 e.ProductCode,
                 e.CustomerPart,
                 e.EndUserPart,
                 e.ImpDesc1}).ToList
        Try
            If exl.Count > 0 Then
                Me.Repeater9.DataSource = exl
                Me.Repeater9.DataBind()
                ScriptManager.RegisterStartupScript(ProductUpdatePanel, ProductUpdatePanel.GetType(), "show", "$(function () { $('#" + ProductPanel.ClientID + "').modal('show'); });", True)
                ProductUpdatePanel.Update()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล Product นี้')", True)
                Exit Sub
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", ex.Message, True)
        End Try
    End Sub
    '--------------------------------------------------------------Click Search JobSite--------------------------------------------------
    Protected Sub btnSearchProduct_ServerClick(sender As Object, e As EventArgs)
        ReadDATA()
    End Sub
    Protected Sub Repeater9_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim str As String = Me.txtRemarks.InnerText
        Dim ProductCode As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("selectProductCode") Then
            Dim exp = (From ex In db.tblProductDetails Where ex.ProductCode = ProductCode).SingleOrDefault

            txtProductCode.Value = exp.ProductCode
            txtProductPO.Value = exp.PONo
            txtCustomerPart.Value = exp.CustomerPart
            txtEndUserPart.Value = exp.EndUserPart
            txtImpProductCode.Value = exp.ImpProductCode
            If String.IsNullOrEmpty(exp.TariffCode) Then
            Else
                dcboImpTariffCode.Text = exp.TariffCode
            End If
            txtImpDesc1.Value = exp.ImpDesc1
            ImpStatus1 = exp.ImpStatus1
            txtImpDesc2.Value = exp.ImpDesc2
            ImpStatus2 = exp.ImpStatus2
            txtImpDesc3.Value = exp.ImpDesc3
            ImpStatus3 = exp.ImpStatus3
            txtImpProductAttribute1.Value = exp.ImpProductAttribute1
            txtImpProductAttribute2.Value = exp.ImpProductAttribute2
            If String.IsNullOrEmpty(exp.ImpTariffSequence) Then
            Else
                dcboImpTariffSequence.Text = exp.ImpTariffSequence
            End If

            If String.IsNullOrEmpty(exp.ImpStatisticalCode) Then
            Else
                dcboImpStatisticalCode.Text = exp.ImpStatisticalCode
            End If

            txtImpCustomsProductCode.Value = exp.ImpCustomsProductCode
            txtImpProductYear.Value = exp.ImpProductYear
            txtImpDutyType.Value = exp.ImpDutytype
            txtImpSpeciticRate.Value = CStr(exp.ImpSpeciticRate)
            txtImpValueRateP.Value = CStr(exp.ImpValueRate_P)
            txtImpSpecificCal.Value = exp.ImpSpecificCal
            txtImpSpecificRateP.Value = CStr(exp.ImpSpecificRate_P)
            txtImpExemptVat.Value = CStr(exp.ImpExemptVAT)
            txtImpExemptDuty.Value = CStr(exp.ImpExemptDuty)
            txtImpExciseNo.Value = exp.ImpExciseNo
            txtImpSurchargeRate.Value = CStr(exp.ImpSurchargeRate)
            txtImpExciseRatePay.Value = CStr(exp.ImpExciseRatePay)
            txtImpExciseRate.Value = CStr(exp.ImpExciseRate)
            txtImpExciseSpcRatePay.Value = CStr(exp.ImpExciseSpcRatePay)
            txtImpExciseSpcRate.Value = CStr(exp.ImpExciseSpcRate)
            txtImpPriviege.Value = exp.ImpPriviege
            txtImpExemptExcise.Value = exp.ImpExemptExcise
            If String.IsNullOrEmpty(exp.ImpBrand) Then
            Else
                dcboImpBrand.Text = exp.ImpBrand
            End If

            txtImpValueRate.Value = CStr(exp.ImpValueRate)
            cboImpCurrency.Text = exp.ImpCurrency
            txtImpExchangeRate.Value = CStr(exp.ImpExchangeRate)
            txtImpValueRateAmount.Value = CStr(exp.ImpValueRateAmount)
            txtExpProductCode.Value = exp.ExpProductCode
            txtExpDesc1.Value = exp.ExpDesc1
            ExpStatus1 = exp.ExpStatus1
            txtExpDesc2.Value = exp.ExpDesc2
            ExpStatus2 = exp.ExpStatus2
            txtExpDesc3.Value = exp.ExpDesc3
            ExpStatus3 = exp.ExpStatus3
            txtExpProductAttribute1.Value = exp.ExpProductAttribute1
            txtExpProductAttribute2.Value = exp.ExpProductAttribute2
            If String.IsNullOrEmpty(exp.ExpTariffSequence) Then
            Else
                dcboExpTariffSequence.Text = exp.ExpTariffSequence
            End If

            If String.IsNullOrEmpty(exp.ExpTariffCode) Then
            Else
                dcboExpTariffCode.Text = exp.ExpTariffCode
            End If

            txtExpCustomsProductCode.Value = exp.ExpCustomsProductCode
            If String.IsNullOrEmpty(exp.ExpStatisticalCode) Then
            Else
                dcboExpStatisticalCode.Text = exp.ExpStatisticalCode
            End If

            txtExpFomulaNo.Value = exp.ExpFomulaNo
            txtExpProductYear.Value = exp.ExpProductYear
            txtExpBOINo.Value = exp.ExpBOINo
            txtExp19BisTranNo.Value = exp.Exp19BisTranNo
            txtExpDutyType.Value = exp.ExpDutyType
            txtExpBondFormulaNo.Value = exp.ExpBondFormulaNo
            txtExpQtyCarton.Value = CStr(exp.ExpQTYCarton)
            txtExpPriceForeight.Value = CStr(exp.ExpPriceForeight)
            txtExpWeightCarton.Value = CStr(exp.ExpWeightCarton)
            txtExpQtyPallet.Value = CStr(exp.ExpQTYPallet)
            txtExpValueRate.Value = CStr(exp.ExpValueRate)
            cboExpCurrency.Text = exp.ExpCurrency
            txtExpExchangeRate.Value = CStr(exp.ExpExchangeRate)
            txtExpValueRateAmount.Value = CStr(exp.ExpValueRateAmount)
            cboPackageofUnit.Text = exp.CartonSetUnit
            txtProductWidth.Value = CStr(exp.CartonWidth)
            txtProductHeight.Value = CStr(exp.CartonHeight)
            txtProductLeng.Value = CStr(exp.CartonLenght)
            txtProductVolume.Value = CStr(exp.CartonVolume)
            cboUnitofVolume.Text = exp.CartonVolUnit
            cboPackageUnit.Text = exp.PalletSetUnit
            str = exp.SpecialHandling
            txtPackageWidth.Value = CStr(exp.PalletWidth)
            txtPackageHeigh.Value = CStr(exp.PalletHeight)
            txtPackageLenght.Value = CStr(exp.PalletLenght)
            txtPackageCarton.Value = CStr(exp.PalletNoCarton)
            txtPackageVolume.Value = CStr(exp.PalletVolume)
            cboPackageUnit.Text = exp.PalletVolUnit
            txtImpEstablishNo.Value = exp.ImpEstablishNo
            txtImpFactoryNo.Value = exp.ImpFactoryNo
            txtExpEstablishNo.Value = exp.ExpEstablishNo
            txtExpFactoryNo.Value = exp.ExpFactoryNo

            ValidateCloseEdit()
            ReadDATAStock()
            FinishGood()
        End If
    End Sub
    Private Sub ValidateCloseEdit()
        '*********** Validate Import **************
        If chkImpEnable1.Checked = False Then
            txtImpDesc1.Disabled = True
        Else
            txtImpDesc1.Disabled = False
        End If
        If chkImpEnable2.Checked = False Then
            txtImpDesc2.Disabled = True
        Else
            txtImpDesc2.Disabled = False
        End If
        If chkImpEnable3.Checked = False Then
            txtImpDesc3.Disabled = True
        Else
            txtImpDesc3.Disabled = False
        End If
        '*******************************************
        '************* Validate Export *************
        If chkExpEnable1.Checked = False Then
            txtExpDesc1.Disabled = True
        Else
            txtExpDesc1.Disabled = False
        End If
        If chkExpEnable2.Checked = False Then
            txtExpDesc2.Disabled = True
        Else
            txtExpDesc2.Disabled = False
        End If
        If chkExpEnable3.Checked = False Then
            txtExpDesc3.Disabled = True
        Else
            txtExpDesc3.Disabled = False
        End If
        '*******************************************
    End Sub
    Private Sub FinishGood()
        If MsgBox("คุณต้องการทำงานในส่วน Finish Good Detail ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            assembly_fieldset.Disabled = False
            ReadData4()

        Else
            ClearDataFinish()
        End If
    End Sub
    Private Sub ClearDataFinish()
        txtEAS.Value = ""
        txtCustomer.Value = ""
        txtOwner.Value = ""
        txtQty.Value = ""
    End Sub
    '--------------------------------------------------------Show Data Flight In Modal-----------------------------------------
    Private Sub ReadData4()

        Dim cons = (From p In db.tblWHPartNews Join s In db.tblProductDetails On p.SubProductCode Equals s.ProductCode Where p.ProductCode = txtProductCode.Value.Trim
                   Select New With {p.ProductCode,
                                    p.SubProductCode,
                                    s.ImpProductAttribute1,
                                    p.Customer,
                                    p.Owner,
                                    p.QuantityProduct}).ToList()
        If cons.Count > 0 Then
            Repeater1.DataSource = cons.ToList
            Repeater1.DataBind()
        Else
            Repeater1.DataSource = Nothing
            Repeater1.DataBind()
            Exit Sub

        End If
    End Sub
    '--------------------------------------------------------Click Data Data Flight -----------------------------------------
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim SubProductCodeee As String = CStr(e.CommandArgument)
        Try
            If e.CommandName.Equals("SelectdataSubProductCode") Then

                If String.IsNullOrEmpty(SubProductCodeee) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เป็นค่าว่าง');", True)
                Else
                    Dim user = (From u In db.tblWHPartNews Where u.ProductCode = txtProductCode.Value.Trim And u.SubProductCode = SubProductCodeee).SingleOrDefault

                    txtEAS.Value = user.SubProductCode
                    txtOwner.Value = user.Owner
                    txtCustomer.Value = user.Customer
                    txtQty.Value = CStr(user.QuantityProduct)

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ReadEAS()
        Dim testdate As Integer
        Dim Proo As String = ""
        If String.IsNullOrEmpty(txtProductCode.Value.Trim) Then
            testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        Else
            Proo = txtProductCode.Value.Trim
        End If

        'Where e.LOTDate.Year = testdate
        Dim exl = (From e In db.tblProductDetails Where e.ProductCode.Contains(Proo) Or (e.CreateDate.Year = testdate)
                 Select New With {
                 e.ProductCode,
                 e.CustomerPart,
                 e.EndUserPart,
                 e.PONo}).ToList
        Try
            If exl.Count > 0 Then
                Me.Repeater2.DataSource = exl
                Me.Repeater2.DataBind()
                ScriptManager.RegisterStartupScript(EASUpdatePanel, EASUpdatePanel.GetType(), "show", "$(function () { $('#" + EASPanel.ClientID + "').modal('show'); });", True)
                EASUpdatePanel.Update()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล EAS นี้')", True)
                Exit Sub
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", ex.Message, True)
        End Try
    End Sub
    '--------------------------------------------------------------Click Search EAS--------------------------------------------------
    Protected Sub btnEAS_ServerClick(sender As Object, e As EventArgs)
        ReadEAS()
    End Sub
    Protected Sub Repeater2_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim ProductCode As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("selectProductCodeee") Then
            Dim exp = (From ex In db.tblProductDetails Where ex.ProductCode = ProductCode).SingleOrDefault

            txtEAS.Value = exp.ProductCode
            txtOwner.Value = exp.CustomerPart
            txtCustomer.Value = exp.EndUserPart

        End If
    End Sub

    Protected Sub btnAddAssembly_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmProductDetail"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then

            If txtProductCode.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
                Exit Sub
            End If
            If txtEAS.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส EAS P/N ก่อน !!!');", True)
                Exit Sub
            End If
            If txtOwner.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Owner P/N ก่อน !!!');", True)
                Exit Sub
            End If
            If txtQty.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน จำนวนของQTY ก่อน !!!');", True)
                Exit Sub
            End If
            Dim ChkDupli = (From u In db.tblWHPartNews Where u.ProductCode = txtProductCode.Value.Trim And u.SubProductCode = txtEAS.Value.Trim
            Select u).FirstOrDefault

            If Not ChkDupli Is Nothing Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('ชื่อ SubProductCode ซ้ำ กรุณาเปลี่ยนใหม่');", True)
            Else
                addDataPart()
                ReadData4()
            End If
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    Private Sub addDataPart()
        '    If PartStatus = "Addnew" Then
        '    sb.Append("INSERT INTO tblWHPartNew (ProductCode,SubProductCode,Customer,Owner,QuantityProduct,CreateUser,CreateDate)")
        '    sb.Append(" VALUES (@ProductCode,@SubProductCode,@Customer,@Owner,@QuantityProduct,@CreateUser,@CreateDate)")
        'ElseIf PartStatus = "Modify" Then
        '    sb.Append("UPDATE tblWHPartNew")
        '    sb.Append(" SET ProductCode=@ProductCode,SubProductCode=@SubProductCode,Customer=@Customer,Owner=@Owner,QuantityProduct=@QuantityProduct,UpdateUser=@UpdateUser,UpdateDate=@UpdateDate")
        '    sb.Append(" WHERE ProductCode=@ProductCode AND SubProductCode=@SubProductCode")
        'End If
        Using tran As New TransactionScope()
            Try
                    db.Database.Connection.Open()

                    db.tblWHPartNews.Add(New tblWHPartNew With { _
                        .ProductCode = txtProductCode.Value.Trim, _
                        .Customer = txtOwner.Value.Trim, _
                        .Owner = txtCustomer.Value.Trim, _
                        .SubProductCode = txtEAS.Value.Trim, _
                        .QuantityProduct = CInt(txtQty.Value.Trim), _
                        .CreateUser = CStr(Session("UserName")), _
                        .CreateDate = Now
                        })
                    db.SaveChanges()
                    tran.Complete()

            Catch ex As Exception
                tran.Dispose()
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดที่ SaveDATAStock_New กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            End Try
        End Using
        ClearDataFinish()
    End Sub

    Protected Sub btnModifyAssembly_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmProductDetail"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then

            If txtProductCode.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
                Exit Sub
            End If
            If txtEAS.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส EAS P/N ก่อน !!!');", True)
                Exit Sub
            End If
            If txtOwner.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Owner P/N ก่อน !!!');", True)
                Exit Sub
            End If
            If txtQty.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน จำนวนของQTY ก่อน !!!');", True)
                Exit Sub
            End If

            ModifyDataPart()
            ReadData4()
        Else
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    Private Sub ModifyDataPart()

        Using tran As New TransactionScope()
            Try
                db.Database.Connection.Open()

                Dim edit As tblWHPartNew = (From c In db.tblWHPartNews Where c.ProductCode = txtProductCode.Value.Trim And c.SubProductCode = txtEAS.Value.Trim
                  Select c).First()
                If edit IsNot Nothing Then
                    'edit.ProductCode = txtProductCode.Value.Trim
                    edit.Customer = txtOwner.Value.Trim
                    edit.Owner = txtCustomer.Value.Trim
                    'edit.SubProductCode = txtEAS.Value.Trim
                    edit.QuantityProduct = CInt(txtQty.Value.Trim)
                    edit.UpdateUser = CStr(Session("UserName"))
                    edit.UpdateDate = Now

                    db.SaveChanges()
                    tran.Complete()
                End If
            Catch ex As Exception
                tran.Dispose()
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดจาก Modify กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            End Try
        End Using

    End Sub

    Protected Sub btnDeleteAssembly_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmProductDetail"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Delete_ = 1
        If cu.Any Then

            If txtProductCode.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
                Exit Sub
            End If
            If txtEAS.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส EAS P/N ก่อน !!!');", True)
                Exit Sub
            End If
            DeletePart()
            ReadData4()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    Private Sub DeletePart()
        If MsgBox("คุณต้องการลบข้อมูลใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Using tran As New TransactionScope()
                Try
                    Dim DeleteEAS As tblWHPartNew = (From c In db.tblWHPartNews Where c.ProductCode = txtProductCode.Value.Trim And c.SubProductCode = txtEAS.Value.Trim
                    Select c).First()

                    db.tblWHPartNews.Remove(DeleteEAS)
                    db.SaveChanges()
                    tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete สำเร็จ !!!');", True)
                Catch ex As Exception
                    tran.Dispose()
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดจาก Delete กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                End Try
            End Using
        End If
        ClearDataFinish()
    End Sub
    Private Sub ClearDATA()
        '************ TAB Import ****************
        txtProductCode.Value = ""
        txtProductPO.Value = ""
        txtCustomerPart.Value = ""
        txtEndUserPart.Value = ""
        txtImpProductCode.Value = ""
        dcboImpTariffCode.Text = ""
        txtImpDesc1.Value = ""
        txtImpDesc1.Disabled = False
        chkImpEnable1.Checked = False
        txtImpDesc2.Value = ""
        txtImpDesc2.Disabled = False
        chkImpEnable2.Checked = False
        txtImpDesc3.Value = ""
        txtImpDesc3.Disabled = False
        chkImpEnable3.Checked = False
        txtImpProductAttribute1.Value = ""
        txtImpProductAttribute2.Value = ""
        dcboImpTariffSequence.Text = ""
        dcboImpStatisticalCode.Text = ""
        txtImpCustomsProductCode.Value = ""
        txtImpProductYear.Value = ""
        txtImpDutyType.Value = ""
        txtImpSpeciticRate.Value = "0"
        txtImpValueRateP.Value = "0"
        txtImpSpecificCal.Value = ""
        txtImpSpecificRateP.Value = "0"
        txtImpExemptVat.Value = "0"
        txtImpSurchargeRate.Value = "0"
        txtImpExciseNo.Value = ""
        txtImpSurchargeRate.Value = "0"
        txtImpExciseRatePay.Value = "0"
        txtImpExciseRate.Value = "0"
        txtImpExciseSpcRatePay.Value = "0"
        txtImpExciseSpcRate.Value = "0"
        txtImpPriviege.Value = ""
        txtImpExemptExcise.Value = "0"
        dcboImpBrand.Text = ""
        txtImpValueRate.Value = "0"
        cboImpCurrency.Text = ""
        txtImpExchangeRate.Value = "0"
        txtImpValueRateAmount.Value = "0"
        '*************** TAB Export *****************
        txtExpProductCode.Value = ""
        txtExpDesc1.Value = ""
        txtExpDesc1.Disabled = False
        chkExpEnable1.Checked = False
        txtExpDesc2.Value = ""
        txtExpDesc2.Disabled = False
        chkExpEnable2.Checked = False
        txtExpDesc3.Value = ""
        txtExpDesc3.Disabled = False
        chkExpEnable3.Checked = False
        txtExpProductAttribute1.Value = ""
        txtExpProductAttribute2.Value = ""
        dcboExpTariffSequence.Text = ""
        dcboExpTariffCode.Text = ""
        txtExpCustomsProductCode.Value = ""
        dcboExpStatisticalCode.Text = ""
        txtExpFomulaNo.Value = ""
        txtExpProductYear.Value = ""
        txtExpBOINo.Value = ""
        txtExp19BisTranNo.Value = ""
        txtExpDutyType.Value = ""
        txtExpBondFormulaNo.Value = ""
        txtExpQtyCarton.Value = "0"
        txtExpPriceForeight.Value = "0"
        txtExpWeightCarton.Value = "0"
        txtExpQtyPallet.Value = "0"
        txtExpValueRate.Value = "0"
        cboExpCurrency.Text = ""
        txtExpExchangeRate.Value = "0"
        txtExpValueRateAmount.Value = "0"
        '**************** TAB Detail of Goods *************
        cboProductUnit.Text = ""
        txtProductWidth.Value = "0"
        txtProductHeight.Value = "0"
        txtProductLeng.Value = "0"
        txtProductVolume.Value = "0"
        cboUnitofVolume.Text = ""
        cboPackageUnit.Text = ""
        txtPackageWidth.Value = "0"
        txtPackageHeigh.Value = "0"
        txtPackageLenght.Value = "0"
        txtPackageCarton.Value = "0"
        txtPackageVolume.Value = "0"
        cboPackageofUnit.Text = ""
        txtRemarks.Value = ""

        '**************** END of Function *****************

        txtMinimunStock.Value = "0"
        txtAdjustment.Value = "0"
        txtDamageQty.Value = "0"
        txtAvailableQTY.Value = "0"
        '**************** ConfirmGood *****************
        txtEAS.Value = ""
        txtCustomer.Value = ""
        txtOwner.Value = ""
        txtQty.Value = ""
    End Sub
    Private Sub CallculateProductVolume()

        If (txtProductWidth.Value.Trim = "0") Then txtProductWidth.Value = "0.0"
        If (txtProductHeight.Value.Trim = "0") Then txtProductHeight.Value = "0.0"
        If (txtProductLeng.Value.Trim = "0") Then txtProductLeng.Value = "0.0"
        If (txtProductVolume.Value.Trim = "0") Then txtProductVolume.Value = "0.0"

        Dim VolumeAmount As Double
        If cboProductUnit.Text = "CM" Then
            VolumeAmount = ((CDbl(txtProductWidth.Value) * CDbl(txtProductHeight.Value) * CDbl(txtProductLeng.Value)) / 1000000)
            txtProductVolume.Value = VolumeAmount.ToString("#,##0.000")
        End If

        If cboProductUnit.Text = "INC" Then
            VolumeAmount = (((CDbl(txtProductWidth.Value) * CDbl(2.5)) * (CDbl(txtProductHeight.Value) * CDbl(2.5)) * (CDbl(txtProductLeng.Value) * CDbl(2.5))) / 1000000)
            txtProductVolume.Value = VolumeAmount.ToString("#,##0.000")
        End If

    End Sub

    Private Sub CallculatePackageVolume()

        If (txtPackageWidth.Value.Trim = "0") Then txtPackageWidth.Value = "0.0"
        If (txtPackageHeigh.Value.Trim = "0") Then txtPackageHeigh.Value = "0.0"
        If (txtPackageLenght.Value.Trim = "0") Then txtPackageLenght.Value = "0.0"
        If (txtPackageCarton.Value.Trim = "0") Then txtPackageCarton.Value = "0.0"
        If (txtPackageVolume.Value.Trim = "0") Then txtPackageVolume.Value = "0.0"

        Dim VolumeAmount As Double
        If cboPackageUnit.Text = "CM" Then
            VolumeAmount = ((CDbl(txtPackageWidth.Value) * CDbl(txtPackageHeigh.Value) * CDbl(txtPackageLenght.Value)) / 1000000) * CDbl(txtPackageCarton.Value)
            txtPackageVolume.Value = VolumeAmount.ToString("#,##0.000")
        End If

        If cboPackageUnit.Text = "INC" Then
            VolumeAmount = (((CDbl(txtPackageWidth.Value) * CDbl(2.5)) * (CDbl(txtPackageHeigh.Value) * CDbl(2.5)) * (CDbl(txtPackageLenght.Value) * CDbl(2.5))) / 1000000) * CDbl(txtPackageCarton.Value)
            txtPackageVolume.Value = VolumeAmount.ToString("#,##0.000")
        End If

    End Sub

    Protected Sub btnDelete_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmProductDetail"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Delete_ = 1
        If cu.Any Then

            If txtProductCode.Value.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
                Exit Sub
            End If

            SaveDATA_Delete()
            SaveDATAStosk_Delete()
            InsertData()
            ClearDATA()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If
    End Sub
    Private Sub SaveDATA_Delete()
            If MsgBox("คุณต้องการลบข้อมูล Product Item ใช่หรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Using tran As New TransactionScope()
                    Try
                    Dim DeleteProduct As tblProductDetail = (From c In db.tblProductDetails Where c.ProductCode = txtProductCode.Value.Trim Select c).First()

                    db.tblProductDetails.Remove(DeleteProduct)
                        db.SaveChanges()
                        tran.Complete()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete Product Item นี้เรียบร้อยแล้ว !!!');", True)
                    Catch ex As Exception
                        tran.Dispose()
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดจาก Delete กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
                    End Try
                End Using
            End If
    End Sub
    Private Sub SaveDATAStosk_Delete()

        Using tran As New TransactionScope()
            Try
                Dim DeleteWHStockCtrls As tblWHStockCtrl = (From c In db.tblWHStockCtrls Where c.ProductCode = txtProductCode.Value.Trim Select c).First()

                db.tblWHStockCtrls.Remove(DeleteWHStockCtrls)
                db.SaveChanges()
                tran.Complete()

            Catch ex As Exception
                tran.Dispose()
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาดจาก SaveDATAStosk_Delete() กรุณาบันทึกข้อมูลใหม่อีกครั้ง');", True)
            End Try
        End Using


    End Sub
End Class