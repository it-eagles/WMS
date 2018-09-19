Public Class ShowRptJobSheet
    Inherits System.Web.UI.Page
    Private _ReportSource As Object
    Private crvReport As Object
    'Private rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'rpt.Load(Server.MapPath("../Report/crMessenger.rpt"))
        'rpt.SetDataSource(results)

        'CrystalReportViewer1.ReportSource = rpt
        'CrystalReportViewer1 = Nothing
        'CType(rpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../PDF/" + CStr(index) + ".pdf"))
    End Sub

    Public Property ReportSorce() As Object
        Get
            Return _ReportSource
        End Get
        Set(ByVal Value As Object)
            _ReportSource = Value
            crvReport.ReportSource = Value
        End Set
    End Property
End Class