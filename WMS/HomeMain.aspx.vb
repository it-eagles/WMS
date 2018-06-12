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
Public Class HomeMain
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnAddUser_click(sender As Object, e As EventArgs)
        Dim dd = New LoginCls
        Dim wsm As String = "eagles"

        'Dim CurrentIV As Byte() = New Byte() {51, 52, 53, 54, 55, 56, 57, 58}
        'Dim CurrentKey As Byte() = {}

        'If txtFullName.Value.Length = 8 Then
        '    CurrentKey = Encoding.ASCII.GetBytes(txtFullName.Value)
        'ElseIf txtFullName.Value.Length > 8 Then
        '    CurrentKey = Encoding.ASCII.GetBytes(txtFullName.Value.Substring(0, 8))
        'Else
        '    Dim AddString As String = txtFullName.Value.Substring(0, 1)
        '    Dim TotalLoop As Integer = 8 - CInt(txtFullName.Value.Length)

        '    Dim tmpKey As String = txtFullName.Value

        '    Dim i As Integer
        '    For i = 1 To TotalLoop
        '        tmpKey = tmpKey & AddString
        '    Next

        '    CurrentKey = Encoding.ASCII.GetBytes(tmpKey)
        'End If

        'Dim desCrypt As DESCryptoServiceProvider
        'desCrypt = New DESCryptoServiceProvider
        'With desCrypt
        '    .IV = CurrentIV
        '    .Key = CurrentKey
        'End With

        'Dim ms As MemoryStream
        'ms = New MemoryStream
        'ms.Position = 0

        'Dim cs As CryptoStream
        'cs = New CryptoStream(ms, desCrypt.CreateEncryptor, CryptoStreamMode.Write)

        'Dim arrByte As Byte() = Encoding.ASCII.GetBytes(txtFullName.Value)
        'cs.Write(arrByte, 0, arrByte.Length)
        'cs.FlushFinalBlock()
        'cs.Close()

        'Dim PwdWithEncrypt As String
        'PwdWithEncrypt = Convert.ToBase64String(ms.ToArray())

        'Dim show As String = LoginCls.Decrypt(txtUserName.Value, wsm)
        'MsgBox(show)

    End Sub

   
    
End Class