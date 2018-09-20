Option Explicit On
Option Strict On
Option Infer On

Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ShowRptJobSheet
    Inherits System.Web.UI.Page
    Private _ReportSource As Object
    Private crvReport As Object
    Private rpt As New ReportDocument

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            '    Dim index As Integer = CInt(Request.QueryString("recno"))

            '    Using db = New LKBWarehouseEntities1

            '        Dim results = (From c In db.tblBookingMessengers
            '              Where c.RecNo = index
            '              Select New With {
            '                    c.RecNo,
            '                    c.BookingTime,
            '                    c.CusTel,
            '                    c.ContactPerson,
            '                    c.CustomerName,
            '                    c.Location,
            '                    c.JobType1,
            '                    c.JobType2,
            '                    c.JobType3,
            '                    c.JobDesc,
            '                    c.ReceiveComback,
            '                    c.BookingBy,
            '                    c.Branch,
            '                    c.Messenger,
            '                    c.Status,
            '                    c.Remark,
            '                    c.ReceiveBy,
            '                    c.BookingDate,
            '                    c.CreateDate,
            '                    c.JobType4
            '                    }).ToList()

            '        rpt.Load(Server.MapPath("../Report/rptSummaryJobIn.rpt"))
            '        rpt.SetDataSource(results)

            '        CrystalReportViewer1.ReportSource = rpt
            '        CrystalReportViewer1 = Nothing


            '        'CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../PDF/" + CStr(index) + ".pdf"))

            '        'Dim path As String = Server.MapPath("../PDF/" + CStr(Request.QueryString("recno")) + ".pdf")
            '        'Dim client As New WebClient()
            '        'Dim buffer As [Byte]() = client.DownloadData(path)

            '        'If buffer IsNot Nothing Then
            '        '    Response.ContentType = "application/pdf"
            '        '    Response.AddHeader("content-length", buffer.Length.ToString())
            '        '    Response.BinaryWrite(buffer)
            '        '    Response.End()
            '        'End If
            '    End Using
            rpt.Load(Server.MapPath("../Report/rptSummaryJobIn.rpt"))
            rpt.SetDataSource(ReportSorce)

            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1 = Nothing
        End If


        'CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../PDF/" + CStr(ReportSorce) + ".pdf"))
    End Sub

    Public Property ReportSorce() As Object
        Get
            Return _ReportSource
        End Get
        Set(ByVal Value As Object)
            _ReportSource = Value
            crvReport = Value
        End Set
    End Property
End Class