Option Explicit On
Option Strict On
Option Infer On

Public Class ConfirmGoodsReceiveDetail

    '
    Private LOTNo As String
    Public Property setLOTNo() As String
        Get
            Return LOTNo
        End Get
        Set(ByVal value As String)
            LOTNo = value
        End Set
    End Property

    Private WHSite As String
    Public Property setWHSite() As String
        Get
            Return WHSite
        End Get
        Set(ByVal value As String)
            WHSite = value
        End Set
    End Property

    'WHLocation
    Private WHLocation As String
    Public Property setWHLocation() As String
        Get
            Return WHLocation
        End Get
        Set(ByVal value As String)
            WHLocation = value
        End Set
    End Property

    'ENDCustomer
    Private ENDCustomer As String
    Public Property setENDCustomer() As String
        Get
            Return ENDCustomer
        End Get
        Set(ByVal value As String)
            ENDCustomer = value
        End Set
    End Property

    '
    Private WHSource As String
    Public Property setWHSource() As String
        Get
            Return WHSource
        End Get
        Set(ByVal value As String)
            WHSource = value
        End Set
    End Property

    '
    Private CustomerLOTNo As String
    Public Property setCustomerLOTNo() As String
        Get
            Return CustomerLOTNo
        End Get
        Set(ByVal value As String)
            CustomerLOTNo = value
        End Set
    End Property
    'ItemNo
    Private ItemNo As String
    Public Property setItemNo() As String
        Get
            Return ItemNo
        End Get
        Set(ByVal value As String)
            ItemNo = value
        End Set
    End Property
    'ProductCode
    Private ProductCode As String
    Public Property setProductCode() As String
        Get
            Return ProductCode
        End Get
        Set(ByVal value As String)
            ProductCode = value
        End Set
    End Property
    'CustomerPN
    Private CustomerPN As String
    Public Property setCustomerPN() As String
        Get
            Return CustomerPN
        End Get
        Set(ByVal value As String)
            CustomerPN = value
        End Set
    End Property
    'OwnerPN
    Private OwnerPN As String
    Public Property setOwnerPN() As String
        Get
            Return OwnerPN
        End Get
        Set(ByVal value As String)
            OwnerPN = value
        End Set
    End Property
    'ProductDesc
    Private ProductDesc As String
    Public Property setProductDesc() As String
        Get
            Return ProductDesc
        End Get
        Set(ByVal value As String)
            ProductDesc = value
        End Set
    End Property
    'Measurement
    Private Measurement As String
    Public Property setMeasurement() As String
        Get
            Return Measurement
        End Get
        Set(ByVal value As String)
            Measurement = value
        End Set
    End Property
    'ProductWidth
    Private ProductWidth As String
    Public Property setProductWidth() As String
        Get
            Return ProductWidth
        End Get
        Set(ByVal value As String)
            ProductWidth = value
        End Set
    End Property
    'ProductLength
    Private ProductLength As String
    Public Property setProductLength() As String
        Get
            Return ProductLength
        End Get
        Set(ByVal value As String)
            ProductLength = value
        End Set
    End Property
    'ProductHeight
    Private ProductHeight As String
    Public Property setProductHeight() As String
        Get
            Return ProductHeight
        End Get
        Set(ByVal value As String)
            ProductHeight = value
        End Set
    End Property
    'ProductVolume
    Private ProductVolume As String
    Public Property setProductVolume() As String
        Get
            Return ProductVolume
        End Get
        Set(ByVal value As String)
            ProductVolume = value
        End Set
    End Property
    'OrderNo
    Private OrderNo As String
    Public Property setOrderNo() As String
        Get
            Return OrderNo
        End Get
        Set(ByVal value As String)
            OrderNo = value
        End Set
    End Property
    'ReceiveNo
    Private ReceiveNo As String
    Public Property setReceiveNo() As String
        Get
            Return ReceiveNo
        End Get
        Set(ByVal value As String)
            ReceiveNo = value
        End Set
    End Property
    'Type
    Private Type As String
    Public Property setType() As String
        Get
            Return Type
        End Get
        Set(ByVal value As String)
            Type = value
        End Set
    End Property
    'ManufacturingDate
    Private ManufacturingDate As String
    Public Property setManufacturingDate() As String
        Get
            Return ManufacturingDate
        End Get
        Set(ByVal value As String)
            ManufacturingDate = value
        End Set
    End Property
    'ExpiredDate
    Private ExpiredDate As String
    Public Property setExpiredDate() As String
        Get
            Return ExpiredDate
        End Get
        Set(ByVal value As String)
            ExpiredDate = value
        End Set
    End Property
    'ReceiveDate
    Private ReceiveDate As String
    Public Property setReceiveDate() As String
        Get
            Return ReceiveDate
        End Get
        Set(ByVal value As String)
            ReceiveDate = value
        End Set
    End Property
    'Quantity
    Private Quantity As String
    Public Property setQuantity() As String
        Get
            Return Quantity
        End Get
        Set(ByVal value As String)
            Quantity = value
        End Set
    End Property
    'QuantityUnit
    Private QuantityUnit As String
    Public Property setQuantityUnit() As String
        Get
            Return QuantityUnit
        End Get
        Set(ByVal value As String)
            QuantityUnit = value
        End Set
    End Property
    'Weigth
    Private Weigth As String
    Public Property setWeigth() As String
        Get
            Return Weigth
        End Get
        Set(ByVal value As String)
            Weigth = value
        End Set
    End Property
    'WeigthUnit
    Private WeigthUnit As String
    Public Property setWeigthUnit() As String
        Get
            Return WeigthUnit
        End Get
        Set(ByVal value As String)
            WeigthUnit = value
        End Set
    End Property
    'Currency
    Private Currency As String
    Public Property setCurrency() As String
        Get
            Return Currency
        End Get
        Set(ByVal value As String)
            Currency = value
        End Set
    End Property
    'ExchangeRate
    Private ExchangeRate As String
    Public Property setExchangeRate() As String
        Get
            Return ExchangeRate
        End Get
        Set(ByVal value As String)
            ExchangeRate = value
        End Set
    End Property
    'PriceForeigh
    Private PriceForeigh As String
    Public Property setPriceForeigh() As String
        Get
            Return PriceForeigh
        End Get
        Set(ByVal value As String)
            PriceForeigh = value
        End Set
    End Property
    'PriceForeighAmount
    Private PriceForeighAmount As String
    Public Property setPriceForeighAmount() As String
        Get
            Return PriceForeighAmount
        End Get
        Set(ByVal value As String)
            PriceForeighAmount = value
        End Set
    End Property
    'PriceBath
    Private PriceBath As String
    Public Property setPriceBath() As String
        Get
            Return PriceBath
        End Get
        Set(ByVal value As String)
            PriceBath = value
        End Set
    End Property
    'PriceBathAmount
    Private PriceBathAmount As String
    Public Property setPriceBathAmount() As String
        Get
            Return PriceBathAmount
        End Get
        Set(ByVal value As String)
            PriceBathAmount = value
        End Set
    End Property
    'PalletNo
    Private PalletNo As String
    Public Property setPalletNo() As String
        Get
            Return PalletNo
        End Get
        Set(ByVal value As String)
            PalletNo = value
        End Set
    End Property
    'UserBy
    Private UserBy As String
    Public Property setUserBy() As String
        Get
            Return UserBy
        End Get
        Set(ByVal value As String)
            UserBy = value
        End Set
    End Property
    'LastUpdate
    Private LastUpdate As String
    Public Property setLastUpdate() As String
        Get
            Return LastUpdate
        End Get
        Set(ByVal value As String)
            LastUpdate = value
        End Set
    End Property
    'Status
    Private Status As String
    Public Property setStatus() As String
        Get
            Return Status
        End Get
        Set(ByVal value As String)
            Status = value
        End Set
    End Property
    'Supplier
    Private Supplier As String
    Public Property setSupplier() As String
        Get
            Return Supplier
        End Get
        Set(ByVal value As String)
            Supplier = value
        End Set
    End Property
    'Buyer
    Private Buyer As String
    Public Property setBuyer() As String
        Get
            Return Buyer
        End Get
        Set(ByVal value As String)
            Buyer = value
        End Set
    End Property
    'Exporter
    Private Exporter As String
    Public Property setExporter() As String
        Get
            Return Exporter
        End Get
        Set(ByVal value As String)
            Exporter = value
        End Set
    End Property
    'Destination
    Private Destination As String
    Public Property setDestination() As String
        Get
            Return Destination
        End Get
        Set(ByVal value As String)
            Destination = value
        End Set
    End Property
    'Consignee
    Private Consignee As String
    Public Property setConsignee() As String
        Get
            Return Consignee
        End Get
        Set(ByVal value As String)
            Consignee = value
        End Set
    End Property
    'ShippingMark
    Private ShippingMark As String
    Public Property setShippingMark() As String
        Get
            Return ShippingMark
        End Get
        Set(ByVal value As String)
            ShippingMark = value
        End Set
    End Property
    'EntryNo
    Private EntryNo As String
    Public Property setEntryNo() As String
        Get
            Return EntryNo
        End Get
        Set(ByVal value As String)
            EntryNo = value
        End Set
    End Property
    'EntryItemNo
    Private EntryItemNo As String
    Public Property setEntryItemNo() As String
        Get
            Return EntryItemNo
        End Get
        Set(ByVal value As String)
            EntryItemNo = value
        End Set
    End Property
    'Invoice
    Private Invoice As String
    Public Property setInvoice() As String
        Get
            Return Invoice
        End Get
        Set(ByVal value As String)
            Invoice = value
        End Set
    End Property

End Class
