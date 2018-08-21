Option Explicit On

Public Class MoneyExt
    Public Shared Function NumToEng(ByVal dblValue As Decimal) As String
        Static ones(9) As String
        Static teens(9) As String
        Static tens(9) As String
        Static thousands(4) As String
        Dim i As Integer, nPosition As Integer
        Dim nDigit As Integer, bAllZeros As Integer
        Dim strResult As String, strTemp As String
        Dim tmpBuff As String
        Try
            ones(0) = "ZERO"
            ones(1) = "ONE"
            ones(2) = "TWO"
            ones(3) = "THREE"
            ones(4) = "FOUR"
            ones(5) = "FIVE"
            ones(6) = "SIX"
            ones(7) = "SEVEN"
            ones(8) = "EIGHT"
            ones(9) = "NINE"

            teens(0) = "TEN"
            teens(1) = "ELEVEN"
            teens(2) = "TWELVE"
            teens(3) = "THIRTEEN"
            teens(4) = "FOURTEEN"
            teens(5) = "FIFTEEN"
            teens(6) = "SIXTEEN"
            teens(7) = "SEVENTEEN"
            teens(8) = "EIGHTEEN"
            teens(9) = "NINETEEN"

            tens(0) = ""
            tens(1) = "TEN"
            tens(2) = "TWENTY"
            tens(3) = "THIRTY"
            tens(4) = "FORTY"
            tens(5) = "FIFTY"
            tens(6) = "SIXTY"
            tens(7) = "SEVENTY"
            tens(8) = "EIGHTY"
            tens(9) = "NINETY"

            thousands(0) = ""
            thousands(1) = "THOUSAND"
            thousands(2) = "MILLION"
            thousands(3) = "BILLION"
            thousands(4) = "TRILLION"

            'Get fractional part 
            strResult = "AND " & Format((dblValue - Int(dblValue)) * 100, "00") & "/100"
            'Convert rest to string and process each digit 
            strTemp = CStr(Int(dblValue))
            'Iterate through string 
            For i = Len(strTemp) To 1 Step -1
                'Get value of this digit 
                nDigit = CDbl(Mid$(strTemp, i, 1))
                'Get column position 
                nPosition = (Len(strTemp) - i) + 1
                'Action depends on 1's, 10's or 100's column 
                Select Case (nPosition Mod 3)
                    Case 1 '1's position 
                        bAllZeros = False
                        If i = 1 Then
                            tmpBuff = ones(nDigit) & " "
                        ElseIf Mid$(strTemp, i - 1, 1) = "1" Then
                            tmpBuff = teens(nDigit) & " "
                            i = i - 1 'Skip tens position 
                        ElseIf nDigit > 0 Then
                            tmpBuff = ones(nDigit) & " "
                        Else
                            'If next 10s & 100s columns are also 
                            'zero, then don't show 'thousands' 
                            bAllZeros = True
                            If i > 1 Then
                                If Mid$(strTemp, i - 1, 1) <> "0" Then
                                    bAllZeros = False
                                End If
                            End If
                            If i > 2 Then
                                If Mid$(strTemp, i - 2, 1) <> "0" Then
                                    bAllZeros = False
                                End If
                            End If
                            tmpBuff = ""
                        End If
                        If bAllZeros = False And nPosition > 1 Then
                            tmpBuff = tmpBuff & thousands(nPosition / 3) & " "
                        End If
                        strResult = tmpBuff & strResult
                    Case 2 'Tens position 
                        If nDigit > 0 Then
                            strResult = tens(nDigit) & " " & strResult
                        End If
                    Case 0 'Hundreds position 
                        If nDigit > 0 Then
                            strResult = ones(nDigit) & " HUNDRED " & strResult
                        End If
                End Select
            Next i
            'Convert first letter to upper case 
            If Len(strResult) > 0 Then
                strResult = UCase$(Left$(strResult, 1)) & Mid$(strResult, 2)
            End If
            'Return result 
            Return strResult
        Catch ex As Exception
        End Try

    End Function

    Public Shared Function NumToEngCarton(ByVal dblValue As Decimal) As String
        Static ones(9) As String
        Static teens(9) As String
        Static tens(9) As String
        Static thousands(4) As String
        Dim i As Integer, nPosition As Integer
        Dim nDigit As Integer, bAllZeros As Integer
        Dim strResult As String, strTemp As String
        Dim tmpBuff As String
        Try
            ones(0) = "ZERO"
            ones(1) = "ONE"
            ones(2) = "TWO"
            ones(3) = "THREE"
            ones(4) = "FOUR"
            ones(5) = "FIVE"
            ones(6) = "SIX"
            ones(7) = "SEVEN"
            ones(8) = "EIGHT"
            ones(9) = "NINE"

            teens(0) = "TEN"
            teens(1) = "ELEVEN"
            teens(2) = "TWELVE"
            teens(3) = "THIRTEEN"
            teens(4) = "FOURTEEN"
            teens(5) = "FIFTEEN"
            teens(6) = "SIXTEEN"
            teens(7) = "SEVENTEEN"
            teens(8) = "EIGHTEEN"
            teens(9) = "NINETEEN"

            tens(0) = ""
            tens(1) = "TEN"
            tens(2) = "TWENTY"
            tens(3) = "THIRTY"
            tens(4) = "FORTY"
            tens(5) = "FIFTY"
            tens(6) = "SIXTY"
            tens(7) = "SEVENTY"
            tens(8) = "EIGHTY"
            tens(9) = "NINETY"

            thousands(0) = ""
            thousands(1) = "THOUSAND"
            thousands(2) = "MILLION"
            thousands(3) = "BILLION"
            thousands(4) = "TRILLION"

            'Get fractional part 
            strResult = "" '& Format((dblValue - Int(dblValue)) * 100, "00") & "/100"
            'Convert rest to string and process each digit 
            strTemp = CStr(Int(dblValue))
            'Iterate through string 
            For i = Len(strTemp) To 1 Step -1
                'Get value of this digit 
                nDigit = CDbl(Mid$(strTemp, i, 1))
                'Get column position 
                nPosition = (Len(strTemp) - i) + 1
                'Action depends on 1's, 10's or 100's column 
                Select Case (nPosition Mod 3)
                    Case 1 '1's position 
                        bAllZeros = False
                        If i = 1 Then
                            tmpBuff = ones(nDigit) & " "
                        ElseIf Mid$(strTemp, i - 1, 1) = "1" Then
                            tmpBuff = teens(nDigit) & " "
                            i = i - 1 'Skip tens position 
                        ElseIf nDigit > 0 Then
                            tmpBuff = ones(nDigit) & " "
                        Else
                            'If next 10s & 100s columns are also 
                            'zero, then don't show 'thousands' 
                            bAllZeros = True
                            If i > 1 Then
                                If Mid$(strTemp, i - 1, 1) <> "0" Then
                                    bAllZeros = False
                                End If
                            End If
                            If i > 2 Then
                                If Mid$(strTemp, i - 2, 1) <> "0" Then
                                    bAllZeros = False
                                End If
                            End If
                            tmpBuff = ""
                        End If
                        If bAllZeros = False And nPosition > 1 Then
                            tmpBuff = tmpBuff & thousands(nPosition / 3) & " "
                        End If
                        strResult = tmpBuff & strResult
                    Case 2 'Tens position 
                        If nDigit > 0 Then
                            strResult = tens(nDigit) & " " & strResult
                        End If
                    Case 0 'Hundreds position 
                        If nDigit > 0 Then
                            strResult = ones(nDigit) & " HUNDRED " & strResult
                        End If
                End Select
            Next i
            'Convert first letter to upper case 
            If Len(strResult) > 0 Then
                strResult = UCase$(Left$(strResult, 1)) & Mid$(strResult, 2)
            End If
            'Return result 
            NumToEngCarton = strResult
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function NumToEngPallet(ByVal dblValue As Decimal) As String
        Static ones(9) As String
        Static teens(9) As String
        Static tens(9) As String
        Static thousands(4) As String
        Dim i As Integer, nPosition As Integer
        Dim nDigit As Integer, bAllZeros As Integer
        Dim strResult As String, strTemp As String
        Dim tmpBuff As String
        Try
            ones(0) = "ZERO"
            ones(1) = "ONE"
            ones(2) = "TWO"
            ones(3) = "THREE"
            ones(4) = "FOUR"
            ones(5) = "FIVE"
            ones(6) = "SIX"
            ones(7) = "SEVEN"
            ones(8) = "EIGHT"
            ones(9) = "NINE"

            teens(0) = "TEN"
            teens(1) = "ELEVEN"
            teens(2) = "TWELVE"
            teens(3) = "THIRTEEN"
            teens(4) = "FOURTEEN"
            teens(5) = "FIFTEEN"
            teens(6) = "SIXTEEN"
            teens(7) = "SEVENTEEN"
            teens(8) = "EIGHTEEN"
            teens(9) = "NINETEEN"

            tens(0) = ""
            tens(1) = "TEN"
            tens(2) = "TWENTY"
            tens(3) = "THIRTY"
            tens(4) = "FORTY"
            tens(5) = "FIFTY"
            tens(6) = "SIXTY"
            tens(7) = "SEVENTY"
            tens(8) = "EIGHTY"
            tens(9) = "NINETY"

            thousands(0) = ""
            thousands(1) = "THOUSAND"
            thousands(2) = "MILLION"
            thousands(3) = "BILLION"
            thousands(4) = "TRILLION"

            'Get fractional part 
            strResult = "" '& Format((dblValue - Int(dblValue)) * 100, "00") & "/100"
            'Convert rest to string and process each digit 
            strTemp = CStr(Int(dblValue))
            'Iterate through string 
            For i = Len(strTemp) To 1 Step -1
                'Get value of this digit 
                nDigit = CDbl(Mid$(strTemp, i, 1))
                'Get column position 
                nPosition = (Len(strTemp) - i) + 1
                'Action depends on 1's, 10's or 100's column 
                Select Case (nPosition Mod 3)
                    Case 1 '1's position 
                        bAllZeros = False
                        If i = 1 Then
                            tmpBuff = ones(nDigit) & " "
                        ElseIf Mid$(strTemp, i - 1, 1) = "1" Then
                            tmpBuff = teens(nDigit) & " "
                            i = i - 1 'Skip tens position 
                        ElseIf nDigit > 0 Then
                            tmpBuff = ones(nDigit) & " "
                        Else
                            'If next 10s & 100s columns are also 
                            'zero, then don't show 'thousands' 
                            bAllZeros = True
                            If i > 1 Then
                                If Mid$(strTemp, i - 1, 1) <> "0" Then
                                    bAllZeros = False
                                End If
                            End If
                            If i > 2 Then
                                If Mid$(strTemp, i - 2, 1) <> "0" Then
                                    bAllZeros = False
                                End If
                            End If
                            tmpBuff = ""
                        End If
                        If bAllZeros = False And nPosition > 1 Then
                            tmpBuff = tmpBuff & thousands(nPosition / 3) & " "
                        End If
                        strResult = tmpBuff & strResult
                    Case 2 'Tens position 
                        If nDigit > 0 Then
                            strResult = tens(nDigit) & " " & strResult
                        End If
                    Case 0 'Hundreds position 
                        If nDigit > 0 Then
                            strResult = ones(nDigit) & " HUNDRED " & strResult
                        End If
                End Select
            Next i
            'Convert first letter to upper case 
            If Len(strResult) > 0 Then
                strResult = UCase$(Left$(strResult, 1)) & Mid$(strResult, 2)
            End If
            'Return result 
            NumToEngPallet = strResult
        Catch ex As Exception
        End Try
    End Function
End Class
