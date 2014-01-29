
Partial Class admin_upload
    Inherits System.Web.UI.Page

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If fuGoodsCsv.FileBytes.Length = 0 Then
            UW.WU.ShowMessage("請上傳檔案")
        End If
        Dim path As String = DB.SysConfig.Path.GoodsCSV & "\" & Now.ToString("yyyyMM") & "\"
        If Not IO.Directory.Exists(path) Then
            IO.Directory.CreateDirectory(path)
        End If
        Dim filename As String = Now.ToString("HHmmss") & ".csv"
        fuGoodsCsv.SaveAs(path & filename)
        Dim arrData As String() = UW.FileUtil.TextFromFile(path & filename).Split(vbLf)
        Dim arrColumn As String() = arrData(0).Split(",")
        Dim dicColumnToIndex As New Dictionary(Of String, Int32)
        For i As Int32 = 0 To arrColumn.Length - 1
            dicColumnToIndex.Add(arrColumn(i), i)
        Next
        Dim dicGoods As Dictionary(Of String, DB.Goods) = DB.Goods.getGoodsDic()
        Dim goodsId As Int32 = 0
        Dim goodsName As String = ""
        Response.Buffer = False
        For i As Int32 = 1 To arrData.Length - 1
            Dim arrItem As String() = arrData(i).Split(",")
            goodsName = arrItem(dicColumnToIndex("name"))
            If dicGoods.ContainsKey(arrItem(0)) Then
                Dim oGoods As DB.Goods = dicGoods(arrItem(0))
                goodsId = dicGoods(arrItem(0)).Id
                oGoods.name = arrItem(dicColumnToIndex("name"))
                oGoods.description = arrItem(dicColumnToIndex("description"))
                If dicColumnToIndex.ContainsKey("pic") Then
                    oGoods.pic = arrItem(dicColumnToIndex("pic"))
                End If
                If dicColumnToIndex.ContainsKey("size") Then
                    oGoods.pic = arrItem(dicColumnToIndex("size"))
                End If
                If dicColumnToIndex.ContainsKey("weight") Then
                    oGoods.pic = arrItem(dicColumnToIndex("weight"))
                End If
                oGoods.Update()
                Response.Write(oGoods.name & " 更新基本資料成功!<br/>")
                Response.Flush()
            Else
                Dim oGoods As New DB.Goods()
                oGoods.name = arrItem(dicColumnToIndex("name"))
                oGoods.description = arrItem(dicColumnToIndex("description"))
                If dicColumnToIndex.ContainsKey("pic") Then
                    oGoods.pic = arrItem(dicColumnToIndex("pic"))
                End If
                If dicColumnToIndex.ContainsKey("size") Then
                    oGoods.pic = arrItem(dicColumnToIndex("size"))
                End If
                If dicColumnToIndex.ContainsKey("weight") Then
                    oGoods.pic = arrItem(dicColumnToIndex("weight"))
                End If
                goodsId = oGoods.Insert()
                Response.Write(oGoods.name & " 新增基本資料成功!<br/>")
                Response.Flush()
            End If

            Dim oDR As New DB.DrawlotRate()
            oDR.goods_id = goodsId
            Dim count As Int32 = oDR.GetCount()
            If count > 0 Then
                UW.SQL.executeSQL("delete drawlot_rate where goods_id=" & goodsId)
                Response.Write(goodsName & " 已刪除舊的掉寶機率資料!<br/>")
            End If

            'goods condition
            Dim inGoodsId As String = ""
            Dim arrGoodsName = arrItem(dicColumnToIndex("goods_condition")).Split("&")
            Dim checkGoodsNameCount As Int32 = 0
            For j As Int32 = 0 To arrGoodsName.Length - 1
                If dicGoods.ContainsKey(arrGoodsName(j)) Then
                    checkGoodsNameCount += 1
                End If
            Next
            If arrItem(dicColumnToIndex("goods_condition")).Length > 0 AndAlso arrGoodsName.Length = checkGoodsNameCount Then
                For j As Int32 = 0 To arrGoodsName.Length - 1
                    If dicGoods.ContainsKey(arrGoodsName(j)) Then
                        inGoodsId &= dicGoods(arrGoodsName(j)).Id & ","
                    End If
                Next
            End If
            If arrItem(dicColumnToIndex("goods_condition")).Length > 0 AndAlso inGoodsId.Length = 0 Then
                Response.Write("<span style=""color:red"">" & goodsName & ":" & arrItem(dicColumnToIndex("goods_condition")) & ": 物品條件中有找不到的物件，請確定在資料庫已有此物件! </span><br/><br/>")
                Response.Flush()
                Continue For
            End If
            If inGoodsId.EndsWith(",") Then
                inGoodsId = inGoodsId.Substring(0, inGoodsId.Length - 1)
            End If

            Dim arrPlaceName = arrItem(dicColumnToIndex("place_name_condition")).Split("|")
            If arrPlaceName.Length > 0 Then
                For j As Int32 = 0 To arrPlaceName.Length - 1
                    oDR = New DB.DrawlotRate()
                    oDR.goods_id = goodsId
                    oDR.place_name_condition = arrPlaceName(j)
                    oDR.goods_condition = inGoodsId
                    oDR.date_condition = arrItem(dicColumnToIndex("date_condition"))
                    oDR.division = arrPlaceName.Length
                    oDR.rate_level = arrItem(dicColumnToIndex("rate_level"))
                    oDR.Insert()
                    Response.Write(goodsName & ": 符合地點條件為 " & arrPlaceName(j) & " 新增掉寶機率資料!<br/>")
                    If inGoodsId.Length > 0 Then
                        Response.Write(goodsName & ": 符合物品條件為 " & inGoodsId & " 新增掉寶機率資料!<br/>")
                    End If
                    If arrItem(dicColumnToIndex("date_condition")).Length > 0 Then
                        Response.Write(goodsName & ": 符合日期條件為 " & arrItem(dicColumnToIndex("date_condition")) & " 新增掉寶機率資料!<br/>")
                    End If
                    Response.Flush()
                Next
            Else
                oDR = New DB.DrawlotRate()
                oDR.goods_id = goodsId
                oDR.place_name_condition = arrItem(dicColumnToIndex("place_name_condition"))
                oDR.goods_condition = inGoodsId
                oDR.date_condition = arrItem(dicColumnToIndex("date_condition"))
                oDR.division = 1
                oDR.rate_level = arrItem(dicColumnToIndex("rate_level"))
                oDR.Insert()
                Response.Write(goodsName & ": 符合地點條件為 " & arrItem(dicColumnToIndex("place_name_condition")) & " 新增掉寶機率資料!<br/>")
                If inGoodsId.Length > 0 Then
                    Response.Write(goodsName & ": 符合物品條件為 " & inGoodsId & " 新增掉寶機率資料!<br/>")
                End If
                If arrItem(dicColumnToIndex("date_condition")).Length > 0 Then
                    Response.Write(goodsName & ": 符合日期條件為 " & arrItem(dicColumnToIndex("date_condition")) & " 新增掉寶機率資料!<br/>")
                End If
                Response.Flush()
            End If
            Response.Write("<br/>")
            Response.Flush()
        Next
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.GetValueFromQueryStringOrForm("pw") <> "1azxp09" Then
            Response.End()
        End If

    End Sub
End Class
