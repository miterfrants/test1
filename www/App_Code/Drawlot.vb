Imports Microsoft.VisualBasic

Public Class Drawlot
    Public Class AliasMethod
        Public length As Int32 = 0
        Public dicProb As Generic.Dictionary(Of Int32, Decimal)
        Public dicAlias As Generic.Dictionary(Of Int32, Int32)

        Public Sub New(ByVal list As Generic.List(Of Decimal))
            Dim listSmall As New List(Of Int32)
            Dim listLarge As New List(Of Int32)
            dicProb = New Dictionary(Of Int32, Decimal)
            dicAlias = New Dictionary(Of Int32, Int32)
            Dim msg As String = ""
            length = list.Count
            For i As Int32 = 0 To list.Count - 1
                list(i) *= list.Count
                If list(i) < 1 Then
                    listSmall.Add(i)
                Else
                    listLarge.Add(i)
                End If
            Next
            Dim currIndex As Int32 = 0
            Dim checkCount As Int32 = 0
            Dim maxCount As Int32 = 100

            '拆比例到
            While (listSmall.Count <> 0 AndAlso listLarge.Count <> 0)
                Dim sIndex As Int32 = listSmall(currIndex)
                Dim lIndex As Int32 = listLarge(currIndex)
                dicProb.Add(sIndex, list(sIndex))
                listSmall.RemoveAt(currIndex)
                listLarge.RemoveAt(currIndex)
                dicAlias.Add(sIndex, lIndex)
                list(lIndex) -= 1.0 - list(sIndex)
                If list(lIndex) < 1 Then
                    listSmall.Add(lIndex)
                Else
                    listLarge.Add(lIndex)
                End If
            End While
            '抽簽
            While listSmall.Count > 0
                dicProb.Add(listSmall(0), 1.0)
                listSmall.RemoveAt(0)
            End While

            While listLarge.Count > 0
                dicProb.Add(listLarge(0), 1.0)
                listLarge.RemoveAt(0)
            End While
        End Sub

        Public Function nextRand() As Int32
            Dim columnIndex As Int32 = CInt(Math.Ceiling(Rnd() * length)) - 1
            Dim random As New Random()
            Dim rand As Decimal = random.Next(length * 2 ^ 20) / (length * 2 ^ 20)
            UW.WU.DebugWriteLine("column index:" & columnIndex)
            UW.WU.DebugWriteLine(rand & ":" & dicProb(columnIndex))
            If rand < dicProb(columnIndex) Then
                Return columnIndex
            Else
                Return dicAlias(columnIndex)
            End If
        End Function

    End Class
End Class
