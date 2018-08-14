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

Partial Public Class LKBWarehouseEntities1_Test
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=LKBWarehouseEntities1_Test")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property Branches() As DbSet(Of Branch)
    Public Overridable Property Departments() As DbSet(Of Department)
    Public Overridable Property sysdiagrams() As DbSet(Of sysdiagram)
    Public Overridable Property tblGenAutoRunNoes() As DbSet(Of tblGenAutoRunNo)
    Public Overridable Property tblLogUsers() As DbSet(Of tblLogUser)
    Public Overridable Property tblMasterCode2() As DbSet(Of tblMasterCode2)
    Public Overridable Property tblMenus() As DbSet(Of tblMenu)
    Public Overridable Property tblMoneyConfigs() As DbSet(Of tblMoneyConfig)
    Public Overridable Property tblParties() As DbSet(Of tblParty)
    Public Overridable Property tblProductDetails() As DbSet(Of tblProductDetail)
    Public Overridable Property tblUsers() As DbSet(Of tblUser)
    Public Overridable Property tblUserMenus() As DbSet(Of tblUserMenu)
    Public Overridable Property tblWHLocations() As DbSet(Of tblWHLocation)
    Public Overridable Property tblWHStockCtrls() As DbSet(Of tblWHStockCtrl)
    Public Overridable Property tblBookingMessengers() As DbSet(Of tblBookingMessenger)
    Public Overridable Property tblCurrencies() As DbSet(Of tblCurrency)
    Public Overridable Property tblDocTrackings() As DbSet(Of tblDocTracking)
    Public Overridable Property tblEntryManagementWHs() As DbSet(Of tblEntryManagementWH)
    Public Overridable Property tblExchangeRates() As DbSet(Of tblExchangeRate)
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
    Public Overridable Property tblPartyAddresses() As DbSet(Of tblPartyAddress)
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
    Public Overridable Property tblUserGroups() As DbSet(Of tblUserGroup)
    Public Overridable Property tblUserWebClients() As DbSet(Of tblUserWebClient)
    Public Overridable Property tblWarehouseTypes() As DbSet(Of tblWarehouseType)
    Public Overridable Property tblWHConfirmGoodsReceives() As DbSet(Of tblWHConfirmGoodsReceive)
    Public Overridable Property tblWHConfirmGoodsReceiveDetails() As DbSet(Of tblWHConfirmGoodsReceiveDetail)
    Public Overridable Property tblWHPickPackMasters() As DbSet(Of tblWHPickPackMaster)
    Public Overridable Property tblWHPickPackNewProducts() As DbSet(Of tblWHPickPackNewProduct)
    Public Overridable Property tblWHPrepairGoodsReceives() As DbSet(Of tblWHPrepairGoodsReceive)
    Public Overridable Property tblWHPrepairGoodsReceiveDetails() As DbSet(Of tblWHPrepairGoodsReceiveDetail)
    Public Overridable Property tblWHReceiveScantoTemps() As DbSet(Of tblWHReceiveScantoTemp)
    Public Overridable Property tblWHRemarkMoveJobs() As DbSet(Of tblWHRemarkMoveJob)
    Public Overridable Property tblWHRequestedISSUEs() As DbSet(Of tblWHRequestedISSUE)
    Public Overridable Property tblWHStockMovements() As DbSet(Of tblWHStockMovement)
    Public Overridable Property tblExpGenLOTs() As DbSet(Of tblExpGenLOT)

End Class
