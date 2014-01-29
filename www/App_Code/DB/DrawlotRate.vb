Imports System.Web.HttpContext
Imports System.Web.Caching

Namespace DB
    Partial Public Class DrawlotRate
        Inherits UW.DB.Record2

        Sub SetMatchColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal StoreFilePath As String = "", Optional ByVal IsCreatePath As Boolean = True, Optional ByVal Extension As String = "", Optional ByVal IsKeepOriginalFileName As UW.EN.ThreeSatatBoolean_ForConfig = UW.EN.ThreeSatatBoolean_ForConfig.預設, Optional ByVal FieldsToSetNullWithEmptyString As String = ",,", Optional ByVal FieldsToIgnore As String = ",,", Optional ByVal IsAddTimeStampBeforeOriiginalFileName As Boolean = False, Optional ByVal IsThrowException As Boolean = False)
            UW.FormUtil.SetMatchedColunm(oPH, Me, StoreFilePath, IsCreatePath, Extension, IsKeepOriginalFileName, FieldsToSetNullWithEmptyString, FieldsToIgnore, IsAddTimeStampBeforeOriiginalFileName, IsThrowException)
        End Sub

        Sub LoadMatchedColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal IsThrowExceptionForDDLNotMatch As Boolean = True, Optional ByVal ImageFolderURL As String = "")
            UW.FormUtil.LoadMatchedColumn(oPH, Me, IsThrowExceptionForDDLNotMatch, ImageFolderURL)
        End Sub

        Shared Function GetTotalCount() As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select count(*) from " & DB.DrawlotRate.BaseTableName_Const)
        End Function

        Shared Function GetSum(ByVal FieldNames As String) As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select sum(" & FieldNames & ") from " & DB.DrawlotRate.BaseTableName_Const)
        End Function

        Public Overrides ReadOnly Property DBC() As String
            Get
                Return Nothing
            End Get
        End Property




        Shared SyncLocker_GetAllDataFromBaseTableWithCache As New Object
        Shared Function GetAllDataFromBaseTableWithCache(Optional ByVal OrderFields As String = "_Default", Optional ByVal IsCopy As Boolean = True) As DataTable
            Dim CacheName As String = "GetAllDataFromBaseTableWithCache_DrawlotRate_" & OrderFields
            If OrderFields = "_Default" Then
                OrderFields = GetDefaultSortFieldName()
            End If
            Dim obj As DataTable = System.Web.HttpContext.Current.Cache(CacheName)
            If obj Is Nothing Then
                SyncLock SyncLocker_GetAllDataFromBaseTableWithCache
                    obj = System.Web.HttpContext.Current.Cache(CacheName)
                    If obj Is Nothing Then
                        Dim SQL As String = "select * from " & BaseTableName_Const
                        If OrderFields.Length > 0 Then
                            SQL = SQL & " Order By " & OrderFields
                        End If
                        obj = UW.SQL.DTFromSQL(SQL)
                        Dim SC As New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, BaseTableName_Const)
                        System.Web.HttpContext.Current.Cache.Insert(CacheName, obj, SC)
                    End If
                End SyncLock
            End If
            If IsCopy Then
                Return obj.Copy
            Else
                Return obj
            End If
        End Function


        Shared Function GetDrawlotRateFromCachedDT(ByVal Key As String) As DB.DrawlotRate
            Dim DT As DataTable = GetAllDataFromBaseTableWithCache()
            Dim Rows As DataRow() = DT.Select(IdField_Const & " = '" & Key.Replace("'", "''") & "'")
            If Rows.Length > 0 Then
                Return New DrawlotRate(Rows(0))
            Else
                Return Nothing
            End If
        End Function

        Shared Function drawLot(ByVal place As String, ByVal check_date As DateTime, ByVal member_id As Int32) As DB.Goods
            Dim dicRate As Dictionary(Of Int32, Decimal) = New Dictionary(Of Int32, Decimal)
            Dim dicHadGoods As New Dictionary(Of Int32, String)
            'place name
            Dim oDR As New DB.DrawlotRate()
            Dim sql As String = "select * from V_drawlot_rate "
            sql &= "where "
            'date 
            sql &= "(date_condition='" & check_date.ToString("MM/dd") & "') or "
            'place name 
            sql &= "('" & place.Replace("'", "''") & "' like place_name_condition) or "
            'no criteria
            sql &= "(len(date_condition)=0 and len(place_name_condition)=0) "


            Dim dtDR As DataTable = UW.SQL.DTFromSQL(sql)
            UW.WU.DebugWriteLine("goods count:" & dtDR.Rows.Count)
            Dim rate As Decimal = 0
            Dim msg As String = ""
            For i As Int32 = 0 To dtDR.Rows.Count - 1

                If Not dicRate.ContainsKey(dtDR.Rows(i)("goods_id")) Then
                    dicRate.Add(CDec(dtDR.Rows(i)("goods_id")), 1 / (2 ^ (dtDR.Rows(i)("rate_level") + 3)))
                    rate += 1 / (2 ^ (dtDR.Rows(i)("rate_level") + 3))
                Else
                    dicRate(dtDR.Rows(i)("goods_id")) = CDec(dicRate(dtDR.Rows(i)("goods_id"))) + 1 / (2 ^ (dtDR.Rows(i)("rate_level") + 3))
                    rate += 1 / (2 ^ (dtDR.Rows(i)("rate_level") + 3))
                End If
                UW.WU.DebugWriteLine("goods_name:" & dtDR.Rows(i)("name") & " , rate:" & 1 / 2 ^ (dtDR.Rows(i)("rate_level") + 3))
            Next
            UW.WU.DebugWriteLine("get goods rate:" & rate)
            dicRate.Add(-1, 1 - rate)
            Dim listIndexAndRate As New List(Of Decimal)
            Dim listIndexAndGoodsId As New List(Of Int32)
            For Each key As Int32 In dicRate.Keys
                listIndexAndGoodsId.Add(key)
                listIndexAndRate.Add(dicRate(key))
            Next
            If Current.Session("lucky") Is Nothing OrElse UW.WU.GetValueFromQueryStringOrForm("clear_session").Length > 0 Then
                Current.Session("lucky") = 0
                Current.Session("draw_count") = 0
            End If
            Current.Session("draw_count") += 1
            UW.WU.DebugWriteLine("draw_count:" & Current.Session("draw_count"))
            Dim drawlotMachine As New Drawlot.AliasMethod(listIndexAndRate)
            Dim drawGoodsId As Int32 = listIndexAndGoodsId(drawlotMachine.nextRand())
            If drawGoodsId = -1 Then
                UW.WU.DebugWriteLine("lucky-0:" & Current.Session("lucky"))
                Return Nothing
            Else
                UW.WU.DebugWriteLine("draw goods id:" & drawGoodsId)
                Dim drsDR As DataRow() = dtDR.Select("goods_id=" & drawGoodsId.ToString())

                Dim hadGoodsId As String = "-1"
                '這個理論上不會發生，因為drawGoodsId是從dtDR來的
                If drsDR.Length > 0 Then
                    If drsDR(0)("goods_condition").ToString.Length > 0 Then
                        hadGoodsId = drsDR(0)("goods_condition")
                    Else
                        Current.Session("lucky") += 1
                        UW.WU.DebugWriteLine("lucky:" & Current.Session("lucky"))
                        Return New DB.Goods(drsDR(0))
                    End If
                Else
                    UW.WU.DebugWriteLine("lucky-1:" & Current.Session("lucky"))
                    Return Nothing
                End If
                Dim oMG As New DB.MemberAndGoods()
                oMG.member_id = member_id
                oMG.AddCriteria("goods_id in (" & hadGoodsId & ")")
                Dim checkMG As Int32 = oMG.GetCount()
                If checkMG = hadGoodsId.Split(",").Length Then
                    UW.WU.DebugWriteLine("lucky-2:" & Current.Session("lucky"))
                    Return Nothing
                End If
                oMG = New DB.MemberAndGoods()
                oMG.member_id = member_id
                oMG.goods_id = drawGoodsId
                oMG.Insert()
                Current.Session("lucky") += 1
                UW.WU.DebugWriteLine("lucky:" & Current.Session("lucky"))
                UW.WU.DebugWriteLine("draw_count:" & Current.Session("draw_count"))
                Return New DB.Goods(drawGoodsId)
            End If
        End Function





        Shared SyncLocker_GetDicDrawLotRateDependOnGoods As New Object
        Shared Function GetDicDrawLotRateDependOnGoods() As Dictionary(Of String, DB.DrawlotRate)
            Dim CacheName As String = "GetDicDrawLotRateDependOnGoods"

            Dim obj As Dictionary(Of String, DB.DrawlotRate) = Current.Cache(CacheName)
            If obj Is Nothing Then
                SyncLock SyncLocker_GetDicDrawLotRateDependOnGoods
                    obj = Current.Cache(CacheName)
                    If obj Is Nothing Then
                        obj = New Dictionary(Of String, DB.DrawlotRate)
                        Dim dt As DataTable = UW.SQL.DTFromSQL("select * from V_drawlot_rate ")
                        For i As Int32 = 0 To dt.Rows.Count - 1
                            If Not obj.ContainsKey(dt.Rows(i)("goods_id")) Then
                                obj.Add(dt.Rows(i)("goods_id"), New DB.DrawlotRate(dt.Rows(i)))
                            End If
                        Next
                        Dim DepArray() As CacheDependency = {New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "drawlot_rate"), _
                                                             New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "goods")}
                        Dim AC As New AggregateCacheDependency
                        AC.Add(DepArray)

                        'Dim SC As New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "V_drawlot_rate")
                        Current.Cache.Insert(CacheName, obj, AC)
                    End If
                End SyncLock
            End If

            Return obj
        End Function
        ''' <summary>
        '''  key is date 
        '''  value is 1,2,3,4 goods_id
        '''  get id 1 and 
        ''' </summary>
        ''' <remarks></remarks>
        Shared SyncLocker_GetDicDrawLotRateIdDependOnDate As New Object
        Shared Function GetDicDrawLotRateIdDependOnDate() As Dictionary(Of String, String)
            Dim CacheName As String = "GetDicDrawLotRateIdDependOnDate"

            Dim obj As Dictionary(Of String, String) = Current.Cache(CacheName)
            If obj Is Nothing Then
                SyncLock SyncLocker_GetDicDrawLotRateIdDependOnDate
                    obj = Current.Cache(CacheName)
                    If obj Is Nothing Then
                        obj = New Dictionary(Of String, String)
                        Dim dt As DataTable = UW.SQL.DTFromSQL("select * from V_drawlot_rate ")
                        For i As Int32 = 0 To dt.Rows.Count - 1
                            If Not obj.ContainsKey(dt.Rows(i)("date")) Then
                                obj.Add(dt.Rows(i)("date"), dt.Rows(i)("goods_id"))
                            Else
                                obj(dt.Rows(i)("date")) = obj(dt.Rows(i)("date")) & "," & dt.Rows(i)("goods_id")
                            End If
                        Next
                        Dim DepArray() As CacheDependency = {New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "drawlot_rate"), _
                                                             New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "goods")}
                        Dim AC As New AggregateCacheDependency
                        AC.Add(DepArray)

                        'Dim SC As New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "V_drawlot_rate")
                        Current.Cache.Insert(CacheName, obj, AC)
                    End If
                End SyncLock
            End If

            Return obj
        End Function





        Shared Function GetDefaultSortFieldName() As String
            Dim Ht As Hashtable = htTypeDefines
            For Each key As String In Ht.Keys
                If key.ToLower = "orderno" Then
                    Return key
                End If
                If key.ToLower = "order_no" Then
                    Return key
                End If
            Next
            Return ""
        End Function
    End Class
End Namespace
