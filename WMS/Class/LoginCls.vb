Option Strict On
Option Explicit On

Imports System.Linq
Imports System.Data
Imports System.Management
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class LoginCls




    Private Shared DES As New TripleDESCryptoServiceProvider
    Private Shared MD5 As New MD5CryptoServiceProvider
    Public Shared EncryptPass As String = "eagles"
    'Dim db As New LKBwarehouseEntities

    Public Shared Function chkUser(_UserName As String, _Password As String) As Boolean
        Dim ms As MemoryStream
        Dim desCrypt As DESCryptoServiceProvider
        Dim cs As CryptoStream
        'Dim dtUser As DataTable
        Dim PwdWithEncrypt As String

        Dim CurrentIV As Byte() = New Byte() {51, 52, 53, 54, 55, 56, 57, 58}
        Dim CurrentKey As Byte() = {}

        If _UserName.Length = 8 Then
            CurrentKey = Encoding.ASCII.GetBytes(_UserName)
        ElseIf _UserName.Length > 8 Then
            CurrentKey = Encoding.ASCII.GetBytes(_UserName.Substring(0, 8))
        Else
            Dim i As Integer
            Dim AddString As String = _UserName.Substring(0, 1)
            Dim TotalLoop As Integer = 8 - CInt(_UserName.Length)
            Dim tmpKey As String = _UserName

            For i = 1 To TotalLoop
                tmpKey = tmpKey & AddString
            Next

            CurrentKey = Encoding.ASCII.GetBytes(tmpKey)
        End If

        desCrypt = New DESCryptoServiceProvider
        With desCrypt
            .IV = CurrentIV
            .Key = CurrentKey
        End With

        ms = New MemoryStream
        ms.Position = 0

        cs = New CryptoStream(ms, desCrypt.CreateEncryptor, CryptoStreamMode.Write)
        Dim arrByte As Byte() = Encoding.ASCII.GetBytes(_Password)
        cs.Write(arrByte, 0, arrByte.Length)
        cs.FlushFinalBlock()
        cs.Close()

        PwdWithEncrypt = Convert.ToBase64String(ms.ToArray())
        'Dim passEn As String = Encrypt(password, EncryptPass)

        Using db As New LKBWarehouseEntities1
            Try
                'Using db As New LKBWarehouseEntities
                Dim q = (From p In db.tblUsers _
                        Where p.UserName.ToUpper() = _UserName And p.Password = PwdWithEncrypt
                        Select p).Count()

                If (q > 0) Then
                    Return True
                Else
                    Return False

                End If
            Catch ex As Exception

                MsgBox("เกิกข้อผิดพลาดในการเข้าสู่ระบบ", MsgBoxStyle.Critical)
            End Try

        End Using

    End Function

    Public Shared Function MD5Hash(ByVal value As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function

    Public Shared Function Encrypt(ByVal stringToEncrypt As String, ByVal key As String) As String
        DES.Key = MD5Hash(key)
        DES.Mode = CipherMode.ECB
        Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt)
        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function
    Public Shared Function Decrypt(ByVal encryptedString As String, ByVal key As String) As String
        Try
            DES.Key = MD5Hash(key)
            DES.Mode = CipherMode.ECB
            Dim Buffer As Byte() = Convert.FromBase64String(encryptedString)
            Return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception

            Return ""
        End Try
    End Function


    Public Shared Function ReturnASCII(_UserName As String, _Password As String) As String
        Dim ms As MemoryStream
        Dim desCrypt As DESCryptoServiceProvider
        Dim cs As CryptoStream
        'Dim dtUser As DataTable
        Dim PwdWithEncrypt As String

        Dim CurrentIV As Byte() = New Byte() {51, 52, 53, 54, 55, 56, 57, 58}
        Dim CurrentKey As Byte() = {}

        If _UserName.Length = 8 Then
            CurrentKey = Encoding.ASCII.GetBytes(_UserName)
        ElseIf _UserName.Length > 8 Then
            CurrentKey = Encoding.ASCII.GetBytes(_UserName.Substring(0, 8))
        Else
            Dim i As Integer
            Dim AddString As String = _UserName.Substring(0, 1)
            Dim TotalLoop As Integer = 8 - CInt(_UserName.Length)
            Dim tmpKey As String = _UserName

            For i = 1 To TotalLoop
                tmpKey = tmpKey & AddString
            Next

            CurrentKey = Encoding.ASCII.GetBytes(tmpKey)
        End If

        desCrypt = New DESCryptoServiceProvider
        With desCrypt
            .IV = CurrentIV
            .Key = CurrentKey
        End With

        ms = New MemoryStream
        ms.Position = 0

        cs = New CryptoStream(ms, desCrypt.CreateEncryptor, CryptoStreamMode.Write)
        Dim arrByte As Byte() = Encoding.ASCII.GetBytes(_Password)
        cs.Write(arrByte, 0, arrByte.Length)
        cs.FlushFinalBlock()
        cs.Close()

        PwdWithEncrypt = Convert.ToBase64String(ms.ToArray())

        Return PwdWithEncrypt

    End Function
End Class