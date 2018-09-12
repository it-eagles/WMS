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
        Dim str As String = Me.txtRemarks.InnerText
        Dim chkproductcode = (From z In db.tblProductDetails Where z.ProductCode = txtProductCode.Value Select z).FirstOrDefault
        If (String.IsNullOrEmpty(txtProductCode.Value)) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('กรุณาป้อน รหัส Product Code ก่อน !!!');", True)
            Exit Sub
        ElseIf Not chkproductcode Is Nothing Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('ชื่อ Productcode ซ้ำ กรุณาเปลี่ยนใหม่');", True)
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
        btnmodal.Visible = True
        btnSearchProduct.Visible = False
    End Sub

    Protected Sub btnEditHead_ServerClick(sender As Object, e As EventArgs)
        btnAddGoods.Visible = False
        btnSaveEditHead.Visible = True
        btnmodal.Visible = False
        btnSearchProduct.Visible = True
    End Sub
    Protected Sub saveGoods_click(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmProductDetail"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
            addGoods()
            SaveDATAStock_New()
            InsertData()
            Dim st As String = CStr(Convert.ToDecimal(txtImpSpeciticRate.Value))
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เมนูนี้ !!!')", True)
        End If



    End Sub

    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)
        Dim user As String = CStr(Session("UserName"))
        Dim form As String = "frmProductDetail"
        Dim cu = From um In db.tblUserMenus Where um.UserName = user And um.Form = form And um.Save_ = 1
        If cu.Any Then
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
                db.Database.Connection.Close()
            Catch ex As Exception
                tran.Dispose()
                db.Database.Connection.Close()
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
        'Dim testdate As Integer
        'Dim lot As String
        'If String.IsNullOrEmpty(txtJobno.Value.Trim) Then
        '    testdate = CInt(Convert.ToDateTime(Date.Now).ToString("yyyy"))
        'Else
        '    lot = txtJobno.Value.Trim
        'End If

        ''Where e.LOTDate.Year = testdate
        'Dim exl = (From e In db.tblImpGenLOTs Where e.EASLOTNo = txtJobno.Value.Trim Or (e.LOTDate.Year = testdate) Order By e.EASLOTNo Descending
        '         Select New With {
        '         e.EASLOTNo,
        '         e.CustomerCode,
        '         e.JobSite,
        '         e.EndCusCode}).ToList
        'Try
        '    If exl.Count > 0 Then
        '        Me.Repeater9.DataSource = exl
        '        Me.Repeater9.DataBind()
        '        ScriptManager.RegisterStartupScript(JobnoUpdatePanel, JobnoUpdatePanel.GetType(), "show", "$(function () { $('#" + JobnoPanel.ClientID + "').modal('show'); });", True)
        '        JobnoUpdatePanel.Update()
        '    Else
        '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล LOTNo นี้')", True)
        '        Exit Sub
        '    End If

        'Catch ex As Exception
        '    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", ex.Message, True)
        'End Try
    End Sub
    '--------------------------------------------------------------Click Search JobSite--------------------------------------------------
    Protected Sub btnSearchProduct_ServerClick(sender As Object, e As EventArgs)
        ReadDATA()
    End Sub
    Protected Sub Repeater9_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        'Dim EASLOTNo As String = CStr(e.CommandArgument)
        'If e.CommandName.Equals("selectLotNO") Then
        '    Dim exp = (From ex In db.tblImpGenLOTs Where ex.EASLOTNo = EASLOTNo).SingleOrDefault

        '    If String.IsNullOrEmpty(exp.EASLOTNo) Then
        '        txtJobno.Value = ""
        '    Else
        '        txtJobno.Value = exp.EASLOTNo
        '    End If

        '    txtdatepickerJobdate.Text = Convert.ToDateTime(exp.LOTDate).ToString("dd/MM/yyyy")
        '    ddlLotof.Text = exp.LOTBy
        '    If String.IsNullOrEmpty(exp.SalesCode) Then
        '        ddlSaleman.Text = ""
        '    Else
        '        ddlSaleman.Text = exp.SalesCode
        '    End If
        '    If String.IsNullOrEmpty(exp.SalesName) Then
        '        txtsalemandis.Value = ""
        '    Else
        '        txtsalemandis.Value = exp.SalesName
        '    End If
        '    If String.IsNullOrEmpty(exp.ConsigneeCode) Then
        '        txtConsigneecode.Value = ""
        '    Else
        '        txtConsigneecode.Value = exp.ConsigneeCode
        '    End If


        'End If
    End Sub


End Class