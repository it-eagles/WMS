Option Explicit On
Option Strict On


Imports System.Transactions
Imports System.Globalization
Public Class PickingWH
    Inherits System.Web.UI.Page
    Dim db As New LKBWarehouseEntities1
    Dim classPermis As New ClassPermis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usename As String = CStr(Session("UserName"))
        Dim form As String = "frmIssued"
        If Not Me.IsPostBack Then
            If classPermis.CheckRead(form, usename) = True Then
                If Not IsPostBack Then
                    'showSite_IssueCondition()
                    'showCommodity()
                    'showUnit()
                    'showVolume()
                    'showSite_ConfirmIssue()
                    'showLocation()
                    'showSoucreWHFac()
                    'showunitdimension()
                    'showunit2()
                    'showcurrency()
                    'TabName.Value = Request.Form(TabName.UniqueID)
                    beforecustomtab_fieldset.Disabled = True
                    
                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ เข้าโปรแกรมนี้' !!!');", True)
                'Response.Redirect("HomeMain.aspx")
            End If
        End If
    End Sub

    Protected Sub btnPick_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnCancel_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnCancelSelectAll_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSelectAll_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnAutoPickNJR_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnAutoPickPallet_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnAddHead_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnEditHead_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSaveAddHead_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSaveEditHead_ServerClick(sender As Object, e As EventArgs)

    End Sub
End Class