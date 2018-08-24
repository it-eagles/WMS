Option Explicit On
Option Strict On

Public Class Ieat107

    Private CustomerCode(1) As String
    Public Property getCustomerCode() As String
        Get
            Return CustomerCode(0)
        End Get
        Set(ByVal value As String)
            CustomerCode(0) = value
        End Set
    End Property
    Private PurechaseOrderNo(1) As String
    Public Property getPurechaseOrderNo() As String
        Get
            Return PurechaseOrderNo(0)
        End Get
        Set(ByVal value As String)
            PurechaseOrderNo(0) = value
        End Set
    End Property
    Private InvoiceNo(1) As String
    Public Property getInvoiceNo() As String
        Get
            Return InvoiceNo(0)
        End Get
        Set(ByVal value As String)
            InvoiceNo(0) = value
        End Set
    End Property

End Class
