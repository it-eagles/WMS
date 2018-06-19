﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class LKBWarehouseEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=LKBWarehouseEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property dtproperties() As DbSet(Of dtproperty)
    Public Overridable Property tblBookingMessengers() As DbSet(Of tblBookingMessenger)
    Public Overridable Property tblCurrencies() As DbSet(Of tblCurrency)
    Public Overridable Property tblDocTrackings() As DbSet(Of tblDocTracking)
    Public Overridable Property tblEntryManagementWHs() As DbSet(Of tblEntryManagementWH)
    Public Overridable Property tblExchangeRates() As DbSet(Of tblExchangeRate)
    Public Overridable Property tblExpGenLOTs() As DbSet(Of tblExpGenLOT)
    Public Overridable Property tblExpInvoices() As DbSet(Of tblExpInvoice)
    Public Overridable Property tblExpInvoiceDetails() As DbSet(Of tblExpInvoiceDetail)
    Public Overridable Property tblExpPackingLists() As DbSet(Of tblExpPackingList)
    Public Overridable Property tblGenAutoNoes() As DbSet(Of tblGenAutoNo)
    Public Overridable Property tblGroupMenus() As DbSet(Of tblGroupMenu)
    Public Overridable Property tblHAWBDetails() As DbSet(Of tblHAWBDetail)
    Public Overridable Property tblImpBookingInvDetails() As DbSet(Of tblImpBookingInvDetail)
    Public Overridable Property tblImpGenLOTs() As DbSet(Of tblImpGenLOT)
    Public Overridable Property tblImpInvoices() As DbSet(Of tblImpInvoice)
    Public Overridable Property tblImpInvoiceDetails() As DbSet(Of tblImpInvoiceDetail)
    Public Overridable Property tblImpLogFlights() As DbSet(Of tblImpLogFlight)
    Public Overridable Property tblImpPackingLists() As DbSet(Of tblImpPackingList)
    Public Overridable Property tblInventoryItems() As DbSet(Of tblInventoryItem)
    Public Overridable Property tblLocations() As DbSet(Of tblLocation)
    Public Overridable Property tblLocationAreas() As DbSet(Of tblLocationArea)
    Public Overridable Property tblLocationMasters() As DbSet(Of tblLocationMaster)
    Public Overridable Property tblLogBrands() As DbSet(Of tblLogBrand)
    Public Overridable Property tblLogCarLicenses() As DbSet(Of tblLogCarLicense)
    Public Overridable Property tblLogConsignnees() As DbSet(Of tblLogConsignnee)
    Public Overridable Property tblLogCountries() As DbSet(Of tblLogCountry)
    Public Overridable Property tblLogCurrencies() As DbSet(Of tblLogCurrency)
    Public Overridable Property tblLogDeliveryTerms() As DbSet(Of tblLogDeliveryTerm)
    Public Overridable Property tblLogDrivers() As DbSet(Of tblLogDriver)
    Public Overridable Property tblLogExpGenLOTs() As DbSet(Of tblLogExpGenLOT)
    Public Overridable Property tblLogExpInvoices() As DbSet(Of tblLogExpInvoice)
    Public Overridable Property tblLogExpInvoiceDetails() As DbSet(Of tblLogExpInvoiceDetail)
    Public Overridable Property tblLogExpPackingLists() As DbSet(Of tblLogExpPackingList)
    Public Overridable Property tblLogImpGenLOTs() As DbSet(Of tblLogImpGenLOT)
    Public Overridable Property tblLogImpInvoices() As DbSet(Of tblLogImpInvoice)
    Public Overridable Property tblLogImpInvoiceDetails() As DbSet(Of tblLogImpInvoiceDetail)
    Public Overridable Property tblLogImpPackingLists() As DbSet(Of tblLogImpPackingList)
    Public Overridable Property tblLogLocationAreas() As DbSet(Of tblLogLocationArea)
    Public Overridable Property tblLogLocationMasters() As DbSet(Of tblLogLocationMaster)
    Public Overridable Property tblLogPackageUnits() As DbSet(Of tblLogPackageUnit)
    Public Overridable Property tblLogProductDetails() As DbSet(Of tblLogProductDetail)
    Public Overridable Property tblLogProductUnits() As DbSet(Of tblLogProductUnit)
    Public Overridable Property tblLogProvinces() As DbSet(Of tblLogProvince)
    Public Overridable Property tblLogReferenceTypes() As DbSet(Of tblLogReferenceType)
    Public Overridable Property tblLogShippers() As DbSet(Of tblLogShipper)
    Public Overridable Property tblLogShippingMarks() As DbSet(Of tblLogShippingMark)
    Public Overridable Property tblLogtransportationModes() As DbSet(Of tblLogtransportationMode)
    Public Overridable Property tblLogTruckManifests() As DbSet(Of tblLogTruckManifest)
    Public Overridable Property tblLogTruckManifestDetails() As DbSet(Of tblLogTruckManifestDetail)
    Public Overridable Property tblLogTruckOwners() As DbSet(Of tblLogTruckOwner)
    Public Overridable Property tblLogTruckTypes() As DbSet(Of tblLogTruckType)
    Public Overridable Property tblLogTruckWayBills() As DbSet(Of tblLogTruckWayBill)
    Public Overridable Property tblLogTruckWayBillDetails() As DbSet(Of tblLogTruckWayBillDetail)
    Public Overridable Property tblLogTruckWayBillDetailImps() As DbSet(Of tblLogTruckWayBillDetailImp)
    Public Overridable Property tblLogTruckWayBillImps() As DbSet(Of tblLogTruckWayBillImp)
    Public Overridable Property tblMasterCodes() As DbSet(Of tblMasterCode)
    Public Overridable Property tblMoneyConfigs() As DbSet(Of tblMoneyConfig)
    Public Overridable Property tblParties() As DbSet(Of tblParty)
    Public Overridable Property tblPartyAddresses() As DbSet(Of tblPartyAddress)
    Public Overridable Property tblProductDetails() As DbSet(Of tblProductDetail)
    Public Overridable Property tblRecEASInvoices() As DbSet(Of tblRecEASInvoice)
    Public Overridable Property tblRecINVs() As DbSet(Of tblRecINV)
    Public Overridable Property tblRunningNumbers() As DbSet(Of tblRunningNumber)
    Public Overridable Property tblShippingTranfers() As DbSet(Of tblShippingTranfer)
    Public Overridable Property tblStatusBalances() As DbSet(Of tblStatusBalance)
    Public Overridable Property tblStatusIEAT107() As DbSet(Of tblStatusIEAT107)
    Public Overridable Property tblStockBalances() As DbSet(Of tblStockBalance)
    Public Overridable Property tblStockWips() As DbSet(Of tblStockWip)
    Public Overridable Property tblStockWipDtls() As DbSet(Of tblStockWipDtl)
    Public Overridable Property tblSummaryReports() As DbSet(Of tblSummaryReport)
    Public Overridable Property tblTempExpGenLOTs() As DbSet(Of tblTempExpGenLOT)
    Public Overridable Property tblTempImpGenLOTs() As DbSet(Of tblTempImpGenLOT)
    Public Overridable Property tblTempItemNoes() As DbSet(Of tblTempItemNo)
    Public Overridable Property tblTruckManifests() As DbSet(Of tblTruckManifest)
    Public Overridable Property tblTruckManifestDetails() As DbSet(Of tblTruckManifestDetail)
    Public Overridable Property tblTruckWayBills() As DbSet(Of tblTruckWayBill)
    Public Overridable Property tblTruckWayBillDetails() As DbSet(Of tblTruckWayBillDetail)
    Public Overridable Property tblTruckWayBillDetailImps() As DbSet(Of tblTruckWayBillDetailImp)
    Public Overridable Property tblTruckWayBillImps() As DbSet(Of tblTruckWayBillImp)
    Public Overridable Property tblUsers() As DbSet(Of tblUser)
    Public Overridable Property tblUserGroups() As DbSet(Of tblUserGroup)
    Public Overridable Property tblUserWebClients() As DbSet(Of tblUserWebClient)
    Public Overridable Property tblWarehouseTypes() As DbSet(Of tblWarehouseType)
    Public Overridable Property tblWHConfirmGoodsReceives() As DbSet(Of tblWHConfirmGoodsReceive)
    Public Overridable Property tblWHConfirmGoodsReceiveDetails() As DbSet(Of tblWHConfirmGoodsReceiveDetail)
    Public Overridable Property tblWHEquipments() As DbSet(Of tblWHEquipment)
    Public Overridable Property tblWHHandlePresons() As DbSet(Of tblWHHandlePreson)
    Public Overridable Property tblWHISSUEDs() As DbSet(Of tblWHISSUED)
    Public Overridable Property tblWHISSUEDDetails() As DbSet(Of tblWHISSUEDDetail)
    Public Overridable Property tblWHIssueScantoTemps() As DbSet(Of tblWHIssueScantoTemp)
    Public Overridable Property tblWHLocations() As DbSet(Of tblWHLocation)
    Public Overridable Property tblWHPartNews() As DbSet(Of tblWHPartNew)
    Public Overridable Property tblWHPickings() As DbSet(Of tblWHPicking)
    Public Overridable Property tblWHPickingDetails() As DbSet(Of tblWHPickingDetail)
    Public Overridable Property tblWHPickPackCheckings() As DbSet(Of tblWHPickPackChecking)
    Public Overridable Property tblWHPickPackMasters() As DbSet(Of tblWHPickPackMaster)
    Public Overridable Property tblWHPickPackNewProducts() As DbSet(Of tblWHPickPackNewProduct)
    Public Overridable Property tblWHPrepairGoodsReceives() As DbSet(Of tblWHPrepairGoodsReceive)
    Public Overridable Property tblWHPrepairGoodsReceiveDetails() As DbSet(Of tblWHPrepairGoodsReceiveDetail)
    Public Overridable Property tblWHReceiveScantoTemps() As DbSet(Of tblWHReceiveScantoTemp)
    Public Overridable Property tblWHRemarkMoveJobs() As DbSet(Of tblWHRemarkMoveJob)
    Public Overridable Property tblWHRequestedISSUEs() As DbSet(Of tblWHRequestedISSUE)
    Public Overridable Property tblWHStockCtrls() As DbSet(Of tblWHStockCtrl)
    Public Overridable Property tblWHStockMovements() As DbSet(Of tblWHStockMovement)
    Public Overridable Property tblMenus() As DbSet(Of tblMenu)
    Public Overridable Property tblUserMenus() As DbSet(Of tblUserMenu)
    Public Overridable Property VInventoryDetailbyOrders() As DbSet(Of VInventoryDetailbyOrder)
    Public Overridable Property vIssueds() As DbSet(Of vIssued)
    Public Overridable Property vReceiveds() As DbSet(Of vReceived)
    Public Overridable Property vStockMovements() As DbSet(Of vStockMovement)
    Public Overridable Property vStockMovementAllViews() As DbSet(Of vStockMovementAllView)
    Public Overridable Property VtestLotImps() As DbSet(Of VtestLotImp)
    Public Overridable Property VTestLOtouts() As DbSet(Of VTestLOtout)

    Public Overridable Function dt_addtosourcecontrol(vchSourceSafeINI As String, vchProjectName As String, vchComment As String, vchLoginName As String, vchPassword As String) As Integer
        Dim vchSourceSafeINIParameter As ObjectParameter = If(vchSourceSafeINI IsNot Nothing, New ObjectParameter("vchSourceSafeINI", vchSourceSafeINI), New ObjectParameter("vchSourceSafeINI", GetType(String)))

        Dim vchProjectNameParameter As ObjectParameter = If(vchProjectName IsNot Nothing, New ObjectParameter("vchProjectName", vchProjectName), New ObjectParameter("vchProjectName", GetType(String)))

        Dim vchCommentParameter As ObjectParameter = If(vchComment IsNot Nothing, New ObjectParameter("vchComment", vchComment), New ObjectParameter("vchComment", GetType(String)))

        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_addtosourcecontrol", vchSourceSafeINIParameter, vchProjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter)
    End Function

    Public Overridable Function dt_addtosourcecontrol_u(vchSourceSafeINI As String, vchProjectName As String, vchComment As String, vchLoginName As String, vchPassword As String) As Integer
        Dim vchSourceSafeINIParameter As ObjectParameter = If(vchSourceSafeINI IsNot Nothing, New ObjectParameter("vchSourceSafeINI", vchSourceSafeINI), New ObjectParameter("vchSourceSafeINI", GetType(String)))

        Dim vchProjectNameParameter As ObjectParameter = If(vchProjectName IsNot Nothing, New ObjectParameter("vchProjectName", vchProjectName), New ObjectParameter("vchProjectName", GetType(String)))

        Dim vchCommentParameter As ObjectParameter = If(vchComment IsNot Nothing, New ObjectParameter("vchComment", vchComment), New ObjectParameter("vchComment", GetType(String)))

        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_addtosourcecontrol_u", vchSourceSafeINIParameter, vchProjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter)
    End Function

    Public Overridable Function dt_adduserobject() As Integer
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_adduserobject")
    End Function

    Public Overridable Function dt_adduserobject_vcs(vchProperty As String) As Integer
        Dim vchPropertyParameter As ObjectParameter = If(vchProperty IsNot Nothing, New ObjectParameter("vchProperty", vchProperty), New ObjectParameter("vchProperty", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_adduserobject_vcs", vchPropertyParameter)
    End Function

    Public Overridable Function dt_checkinobject(chObjectType As String, vchObjectName As String, vchComment As String, vchLoginName As String, vchPassword As String, iVCSFlags As Nullable(Of Integer), iActionFlag As Nullable(Of Integer), txStream1 As String, txStream2 As String, txStream3 As String) As Integer
        Dim chObjectTypeParameter As ObjectParameter = If(chObjectType IsNot Nothing, New ObjectParameter("chObjectType", chObjectType), New ObjectParameter("chObjectType", GetType(String)))

        Dim vchObjectNameParameter As ObjectParameter = If(vchObjectName IsNot Nothing, New ObjectParameter("vchObjectName", vchObjectName), New ObjectParameter("vchObjectName", GetType(String)))

        Dim vchCommentParameter As ObjectParameter = If(vchComment IsNot Nothing, New ObjectParameter("vchComment", vchComment), New ObjectParameter("vchComment", GetType(String)))

        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Dim iVCSFlagsParameter As ObjectParameter = If(iVCSFlags.HasValue, New ObjectParameter("iVCSFlags", iVCSFlags), New ObjectParameter("iVCSFlags", GetType(Integer)))

        Dim iActionFlagParameter As ObjectParameter = If(iActionFlag.HasValue, New ObjectParameter("iActionFlag", iActionFlag), New ObjectParameter("iActionFlag", GetType(Integer)))

        Dim txStream1Parameter As ObjectParameter = If(txStream1 IsNot Nothing, New ObjectParameter("txStream1", txStream1), New ObjectParameter("txStream1", GetType(String)))

        Dim txStream2Parameter As ObjectParameter = If(txStream2 IsNot Nothing, New ObjectParameter("txStream2", txStream2), New ObjectParameter("txStream2", GetType(String)))

        Dim txStream3Parameter As ObjectParameter = If(txStream3 IsNot Nothing, New ObjectParameter("txStream3", txStream3), New ObjectParameter("txStream3", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_checkinobject", chObjectTypeParameter, vchObjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter, iVCSFlagsParameter, iActionFlagParameter, txStream1Parameter, txStream2Parameter, txStream3Parameter)
    End Function

    Public Overridable Function dt_checkinobject_u(chObjectType As String, vchObjectName As String, vchComment As String, vchLoginName As String, vchPassword As String, iVCSFlags As Nullable(Of Integer), iActionFlag As Nullable(Of Integer), txStream1 As String, txStream2 As String, txStream3 As String) As Integer
        Dim chObjectTypeParameter As ObjectParameter = If(chObjectType IsNot Nothing, New ObjectParameter("chObjectType", chObjectType), New ObjectParameter("chObjectType", GetType(String)))

        Dim vchObjectNameParameter As ObjectParameter = If(vchObjectName IsNot Nothing, New ObjectParameter("vchObjectName", vchObjectName), New ObjectParameter("vchObjectName", GetType(String)))

        Dim vchCommentParameter As ObjectParameter = If(vchComment IsNot Nothing, New ObjectParameter("vchComment", vchComment), New ObjectParameter("vchComment", GetType(String)))

        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Dim iVCSFlagsParameter As ObjectParameter = If(iVCSFlags.HasValue, New ObjectParameter("iVCSFlags", iVCSFlags), New ObjectParameter("iVCSFlags", GetType(Integer)))

        Dim iActionFlagParameter As ObjectParameter = If(iActionFlag.HasValue, New ObjectParameter("iActionFlag", iActionFlag), New ObjectParameter("iActionFlag", GetType(Integer)))

        Dim txStream1Parameter As ObjectParameter = If(txStream1 IsNot Nothing, New ObjectParameter("txStream1", txStream1), New ObjectParameter("txStream1", GetType(String)))

        Dim txStream2Parameter As ObjectParameter = If(txStream2 IsNot Nothing, New ObjectParameter("txStream2", txStream2), New ObjectParameter("txStream2", GetType(String)))

        Dim txStream3Parameter As ObjectParameter = If(txStream3 IsNot Nothing, New ObjectParameter("txStream3", txStream3), New ObjectParameter("txStream3", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_checkinobject_u", chObjectTypeParameter, vchObjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter, iVCSFlagsParameter, iActionFlagParameter, txStream1Parameter, txStream2Parameter, txStream3Parameter)
    End Function

    Public Overridable Function dt_checkoutobject(chObjectType As String, vchObjectName As String, vchComment As String, vchLoginName As String, vchPassword As String, iVCSFlags As Nullable(Of Integer), iActionFlag As Nullable(Of Integer)) As Integer
        Dim chObjectTypeParameter As ObjectParameter = If(chObjectType IsNot Nothing, New ObjectParameter("chObjectType", chObjectType), New ObjectParameter("chObjectType", GetType(String)))

        Dim vchObjectNameParameter As ObjectParameter = If(vchObjectName IsNot Nothing, New ObjectParameter("vchObjectName", vchObjectName), New ObjectParameter("vchObjectName", GetType(String)))

        Dim vchCommentParameter As ObjectParameter = If(vchComment IsNot Nothing, New ObjectParameter("vchComment", vchComment), New ObjectParameter("vchComment", GetType(String)))

        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Dim iVCSFlagsParameter As ObjectParameter = If(iVCSFlags.HasValue, New ObjectParameter("iVCSFlags", iVCSFlags), New ObjectParameter("iVCSFlags", GetType(Integer)))

        Dim iActionFlagParameter As ObjectParameter = If(iActionFlag.HasValue, New ObjectParameter("iActionFlag", iActionFlag), New ObjectParameter("iActionFlag", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_checkoutobject", chObjectTypeParameter, vchObjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter, iVCSFlagsParameter, iActionFlagParameter)
    End Function

    Public Overridable Function dt_checkoutobject_u(chObjectType As String, vchObjectName As String, vchComment As String, vchLoginName As String, vchPassword As String, iVCSFlags As Nullable(Of Integer), iActionFlag As Nullable(Of Integer)) As Integer
        Dim chObjectTypeParameter As ObjectParameter = If(chObjectType IsNot Nothing, New ObjectParameter("chObjectType", chObjectType), New ObjectParameter("chObjectType", GetType(String)))

        Dim vchObjectNameParameter As ObjectParameter = If(vchObjectName IsNot Nothing, New ObjectParameter("vchObjectName", vchObjectName), New ObjectParameter("vchObjectName", GetType(String)))

        Dim vchCommentParameter As ObjectParameter = If(vchComment IsNot Nothing, New ObjectParameter("vchComment", vchComment), New ObjectParameter("vchComment", GetType(String)))

        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Dim iVCSFlagsParameter As ObjectParameter = If(iVCSFlags.HasValue, New ObjectParameter("iVCSFlags", iVCSFlags), New ObjectParameter("iVCSFlags", GetType(Integer)))

        Dim iActionFlagParameter As ObjectParameter = If(iActionFlag.HasValue, New ObjectParameter("iActionFlag", iActionFlag), New ObjectParameter("iActionFlag", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_checkoutobject_u", chObjectTypeParameter, vchObjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter, iVCSFlagsParameter, iActionFlagParameter)
    End Function

    Public Overridable Function dt_displayoaerror(iObject As Nullable(Of Integer), iresult As Nullable(Of Integer)) As Integer
        Dim iObjectParameter As ObjectParameter = If(iObject.HasValue, New ObjectParameter("iObject", iObject), New ObjectParameter("iObject", GetType(Integer)))

        Dim iresultParameter As ObjectParameter = If(iresult.HasValue, New ObjectParameter("iresult", iresult), New ObjectParameter("iresult", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_displayoaerror", iObjectParameter, iresultParameter)
    End Function

    Public Overridable Function dt_displayoaerror_u(iObject As Nullable(Of Integer), iresult As Nullable(Of Integer)) As Integer
        Dim iObjectParameter As ObjectParameter = If(iObject.HasValue, New ObjectParameter("iObject", iObject), New ObjectParameter("iObject", GetType(Integer)))

        Dim iresultParameter As ObjectParameter = If(iresult.HasValue, New ObjectParameter("iresult", iresult), New ObjectParameter("iresult", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_displayoaerror_u", iObjectParameter, iresultParameter)
    End Function

    Public Overridable Function dt_droppropertiesbyid(id As Nullable(Of Integer), [property] As String) As Integer
        Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("id", id), New ObjectParameter("id", GetType(Integer)))

        Dim propertyParameter As ObjectParameter = If([property] IsNot Nothing, New ObjectParameter("property", [property]), New ObjectParameter("property", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_droppropertiesbyid", idParameter, propertyParameter)
    End Function

    Public Overridable Function dt_dropuserobjectbyid(id As Nullable(Of Integer)) As Integer
        Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("id", id), New ObjectParameter("id", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_dropuserobjectbyid", idParameter)
    End Function

    Public Overridable Function dt_generateansiname(name As ObjectParameter) As Integer
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_generateansiname", name)
    End Function

    Public Overridable Function dt_getobjwithprop([property] As String, value As String) As ObjectResult(Of Nullable(Of Integer))
        Dim propertyParameter As ObjectParameter = If([property] IsNot Nothing, New ObjectParameter("property", [property]), New ObjectParameter("property", GetType(String)))

        Dim valueParameter As ObjectParameter = If(value IsNot Nothing, New ObjectParameter("value", value), New ObjectParameter("value", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Nullable(Of Integer))("dt_getobjwithprop", propertyParameter, valueParameter)
    End Function

    Public Overridable Function dt_getobjwithprop_u([property] As String, uvalue As String) As ObjectResult(Of Nullable(Of Integer))
        Dim propertyParameter As ObjectParameter = If([property] IsNot Nothing, New ObjectParameter("property", [property]), New ObjectParameter("property", GetType(String)))

        Dim uvalueParameter As ObjectParameter = If(uvalue IsNot Nothing, New ObjectParameter("uvalue", uvalue), New ObjectParameter("uvalue", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Nullable(Of Integer))("dt_getobjwithprop_u", propertyParameter, uvalueParameter)
    End Function

    Public Overridable Function dt_getpropertiesbyid(id As Nullable(Of Integer), [property] As String) As ObjectResult(Of dt_getpropertiesbyid_Result)
        Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("id", id), New ObjectParameter("id", GetType(Integer)))

        Dim propertyParameter As ObjectParameter = If([property] IsNot Nothing, New ObjectParameter("property", [property]), New ObjectParameter("property", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of dt_getpropertiesbyid_Result)("dt_getpropertiesbyid", idParameter, propertyParameter)
    End Function

    Public Overridable Function dt_getpropertiesbyid_u(id As Nullable(Of Integer), [property] As String) As ObjectResult(Of dt_getpropertiesbyid_u_Result)
        Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("id", id), New ObjectParameter("id", GetType(Integer)))

        Dim propertyParameter As ObjectParameter = If([property] IsNot Nothing, New ObjectParameter("property", [property]), New ObjectParameter("property", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of dt_getpropertiesbyid_u_Result)("dt_getpropertiesbyid_u", idParameter, propertyParameter)
    End Function

    Public Overridable Function dt_getpropertiesbyid_vcs(id As Nullable(Of Integer), [property] As String, value As ObjectParameter) As Integer
        Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("id", id), New ObjectParameter("id", GetType(Integer)))

        Dim propertyParameter As ObjectParameter = If([property] IsNot Nothing, New ObjectParameter("property", [property]), New ObjectParameter("property", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_getpropertiesbyid_vcs", idParameter, propertyParameter, value)
    End Function

    Public Overridable Function dt_getpropertiesbyid_vcs_u(id As Nullable(Of Integer), [property] As String, value As ObjectParameter) As Integer
        Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("id", id), New ObjectParameter("id", GetType(Integer)))

        Dim propertyParameter As ObjectParameter = If([property] IsNot Nothing, New ObjectParameter("property", [property]), New ObjectParameter("property", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_getpropertiesbyid_vcs_u", idParameter, propertyParameter, value)
    End Function

    Public Overridable Function dt_isundersourcecontrol(vchLoginName As String, vchPassword As String, iWhoToo As Nullable(Of Integer)) As Integer
        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Dim iWhoTooParameter As ObjectParameter = If(iWhoToo.HasValue, New ObjectParameter("iWhoToo", iWhoToo), New ObjectParameter("iWhoToo", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_isundersourcecontrol", vchLoginNameParameter, vchPasswordParameter, iWhoTooParameter)
    End Function

    Public Overridable Function dt_isundersourcecontrol_u(vchLoginName As String, vchPassword As String, iWhoToo As Nullable(Of Integer)) As Integer
        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Dim iWhoTooParameter As ObjectParameter = If(iWhoToo.HasValue, New ObjectParameter("iWhoToo", iWhoToo), New ObjectParameter("iWhoToo", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_isundersourcecontrol_u", vchLoginNameParameter, vchPasswordParameter, iWhoTooParameter)
    End Function

    Public Overridable Function dt_removefromsourcecontrol() As Integer
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_removefromsourcecontrol")
    End Function

    Public Overridable Function dt_setpropertybyid(id As Nullable(Of Integer), [property] As String, value As String, lvalue As Byte()) As Integer
        Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("id", id), New ObjectParameter("id", GetType(Integer)))

        Dim propertyParameter As ObjectParameter = If([property] IsNot Nothing, New ObjectParameter("property", [property]), New ObjectParameter("property", GetType(String)))

        Dim valueParameter As ObjectParameter = If(value IsNot Nothing, New ObjectParameter("value", value), New ObjectParameter("value", GetType(String)))

        Dim lvalueParameter As ObjectParameter = If(lvalue IsNot Nothing, New ObjectParameter("lvalue", lvalue), New ObjectParameter("lvalue", GetType(Byte())))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_setpropertybyid", idParameter, propertyParameter, valueParameter, lvalueParameter)
    End Function

    Public Overridable Function dt_setpropertybyid_u(id As Nullable(Of Integer), [property] As String, uvalue As String, lvalue As Byte()) As Integer
        Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("id", id), New ObjectParameter("id", GetType(Integer)))

        Dim propertyParameter As ObjectParameter = If([property] IsNot Nothing, New ObjectParameter("property", [property]), New ObjectParameter("property", GetType(String)))

        Dim uvalueParameter As ObjectParameter = If(uvalue IsNot Nothing, New ObjectParameter("uvalue", uvalue), New ObjectParameter("uvalue", GetType(String)))

        Dim lvalueParameter As ObjectParameter = If(lvalue IsNot Nothing, New ObjectParameter("lvalue", lvalue), New ObjectParameter("lvalue", GetType(Byte())))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_setpropertybyid_u", idParameter, propertyParameter, uvalueParameter, lvalueParameter)
    End Function

    Public Overridable Function dt_validateloginparams(vchLoginName As String, vchPassword As String) As Integer
        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_validateloginparams", vchLoginNameParameter, vchPasswordParameter)
    End Function

    Public Overridable Function dt_validateloginparams_u(vchLoginName As String, vchPassword As String) As Integer
        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_validateloginparams_u", vchLoginNameParameter, vchPasswordParameter)
    End Function

    Public Overridable Function dt_vcsenabled() As Integer
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_vcsenabled")
    End Function

    Public Overridable Function dt_verstamp006() As ObjectResult(Of Nullable(Of Integer))
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Nullable(Of Integer))("dt_verstamp006")
    End Function

    Public Overridable Function dt_verstamp007() As ObjectResult(Of Nullable(Of Integer))
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Nullable(Of Integer))("dt_verstamp007")
    End Function

    Public Overridable Function dt_whocheckedout(chObjectType As String, vchObjectName As String, vchLoginName As String, vchPassword As String) As Integer
        Dim chObjectTypeParameter As ObjectParameter = If(chObjectType IsNot Nothing, New ObjectParameter("chObjectType", chObjectType), New ObjectParameter("chObjectType", GetType(String)))

        Dim vchObjectNameParameter As ObjectParameter = If(vchObjectName IsNot Nothing, New ObjectParameter("vchObjectName", vchObjectName), New ObjectParameter("vchObjectName", GetType(String)))

        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_whocheckedout", chObjectTypeParameter, vchObjectNameParameter, vchLoginNameParameter, vchPasswordParameter)
    End Function

    Public Overridable Function dt_whocheckedout_u(chObjectType As String, vchObjectName As String, vchLoginName As String, vchPassword As String) As Integer
        Dim chObjectTypeParameter As ObjectParameter = If(chObjectType IsNot Nothing, New ObjectParameter("chObjectType", chObjectType), New ObjectParameter("chObjectType", GetType(String)))

        Dim vchObjectNameParameter As ObjectParameter = If(vchObjectName IsNot Nothing, New ObjectParameter("vchObjectName", vchObjectName), New ObjectParameter("vchObjectName", GetType(String)))

        Dim vchLoginNameParameter As ObjectParameter = If(vchLoginName IsNot Nothing, New ObjectParameter("vchLoginName", vchLoginName), New ObjectParameter("vchLoginName", GetType(String)))

        Dim vchPasswordParameter As ObjectParameter = If(vchPassword IsNot Nothing, New ObjectParameter("vchPassword", vchPassword), New ObjectParameter("vchPassword", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("dt_whocheckedout_u", chObjectTypeParameter, vchObjectNameParameter, vchLoginNameParameter, vchPasswordParameter)
    End Function

    Public Overridable Function HoldExpireLKB() As Integer
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("HoldExpireLKB")
    End Function

End Class
