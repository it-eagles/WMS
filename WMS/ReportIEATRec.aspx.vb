Public Class ReportIEATRec
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        showCommodity()
        showCode()
    End Sub

    Protected Sub btnPrint_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub showCommodity()
        ddlJobSite_ReportIEATRec.Items.Clear()
        ddlJobSite_ReportIEATRec.Items.Add(New ListItem("--Select JobSite--", ""))
        ddlJobSite_ReportIEATRec.AppendDataBoundItems = True

        Dim gg = From g In db.tblMasterCodes Where g.Type = "Jobsite"
                  Select g.Type, g.Code
        Try
            ddlJobSite_ReportIEATRec.DataSource = gg.ToList
            ddlJobSite_ReportIEATRec.DataTextField = "Code"
            ddlJobSite_ReportIEATRec.DataValueField = "Code"
            ddlJobSite_ReportIEATRec.DataBind()
            If ddlJobSite_ReportIEATRec.Items.Count > 1 Then
                ddlJobSite_ReportIEATRec.Enabled = True
            Else
                ddlJobSite_ReportIEATRec.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub showCode()
        ddlCode.Items.Clear()
        ddlCode.Items.Add(New ListItem("--Select Code--", ""))
        ddlCode.AppendDataBoundItems = True

        Dim gg = From g In db.tblParties
                  Select g.PartyCode, g.PartyFullName
        Try
            ddlCode.DataSource = gg.ToList
            ddlCode.DataTextField = "PartyCode"
            ddlCode.DataValueField = "PartyCode"
            ddlCode.DataBind()
            If ddlCode.Items.Count > 1 Then
                ddlCode.Enabled = True
            Else
                ddlCode.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class