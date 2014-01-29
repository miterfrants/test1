<%@ Page Language="VB" AutoEventWireup="false" CodeFile="record.aspx.vb" Inherits="test_record" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:og="http://ogp.me/ns#" xmlns:fb="https://www.facebook.com/2008/fbml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>ibon售票系統</title>
<meta name="title" content="ibon售票系統" />
<meta property="og:site_name" content="ibon售票系統" />
<meta property="og:type" content="article" />
<meta property="og:title" content="ibon售票系統" />
<meta property="og:url" content="http://ticket.7net.com.tw/index.php?class&amp;#61&amp;#59;funcnav&amp;amp&amp;#59;func&amp;#61&amp;#59;news&amp;amp&amp;#59;work&amp;#61&amp;#59;detail&amp;amp&amp;#59;news_id&amp;#61&amp;#59;1925" />
<meta property="og:description" content="ibon ticekt information"/>
<link href="http://ticket.7net.com.tw/css/common.css" rel="stylesheet" type="text/css" />
<link href="http://ticket.7net.com.tw/css/ui.css" rel="stylesheet" type="text/css" />
<link href="http://ticket.7net.com.tw/css/jquery.ui.css" rel="stylesheet" type="text/css" />
<link href="http://ticket.7net.com.tw/css/impromptu.css" rel="stylesheet" type="text/css" />
<link href="http://ticket.7net.com.tw/js/jquery.fancybox/jquery.fancybox.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://ticket.7net.com.tw/js/system.js"></script>
<script type="text/javascript" src="http://ticket.7net.com.tw/js/jquery.js"></script>
<script type="text/javascript" src="http://ticket.7net.com.tw/js/jquery.ui.js"></script>
<script type="text/javascript" src="http://ticket.7net.com.tw/js/jquery.idTabs.js"></script>
<script type="text/javascript" src="http://ticket.7net.com.tw/js/jquery.impromptu.js"></script>
<script type="text/javascript" src="http://ticket.7net.com.tw/js/jquery.fancybox/jquery.fancybox.js"></script>
<script type="text/javascript">
    // <![CDATA[
    if (!window.XMLHttpRequest) {
        window.location.href = ('http://ticket.7net.com.tw/upgrade.html');
    }


    var t_page_start = Number(new Date());
    var t_page, t_done;

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-22604128-1']);
    _gaq.push(['_setDomainName', 'none']);
    _gaq.push(['_setAllowLinker', true]);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        //ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        ga.src = ('http://ticket.7net.com.tw/js/ga.js');
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

    $(document).ready(function () {
        // 節目日期搜尋
        var game_dates = $('#search_game_date, #search_game_end_date').datepicker({
            showOn: 'both',
            buttonImage: 'http://61.57.227.51/image/calendar.gif',
            buttonImageOnly: true,
            onSelect: function (selectedDate) {
                var option = (this.id == 'search_game_date') ? 'minDate' : 'maxDate',
                    instance = $(this).data('datepicker'),
                    date = $.datepicker.parseDate((instance.settings.dateFormat || $.datepicker._defaults.dateFormat), selectedDate, instance.settings);
                game_dates.not(this).datepicker('option', option, date);
            }
        });

        // 設定搜尋類型動作
        $('#search_type').idTabs(function (id, list, set) {
            $('a', set).removeClass('selected').filter('[href="' + id + '"]', set).addClass('selected');
            for (i in list)
                $(list[i]).hide().find('input, select').attr('disabled', true);
            $(id).fadeIn().find('input, select').attr('disabled', false);
            $('[name="search_type"]').val(id.replace('#', ''));
            return false;
        });

        // 建立圖片燈箱效果
        $('.fancybox').fancybox({
            fitToView: true,
            maxWidth: 1024,
            width: '85%',
            height: '85%',
            autoSize: false,
            openEffect: 'none',
            closeEffect: 'none'
        });
    });
    // ]]>
</script>
</head>

<body>
<!-- 192.168.66.201 -->
<div id='index'>
<!--表單與變數-->
<form name="funcnav_news" action="" method="get" enctype="multipart/form-data">
<input type="hidden" name="class" value="funcnav" />
<input type="hidden" name="func" value="news" />
<input type="hidden" name="work" value="detail" />
<input type="hidden" name="subwork" value="" />
<input type="hidden" name="offset" value="0" />
<input type="hidden" name="search_type" value="activity" />

<!--表頭-->
<div id="header">
	<div id="section">
		<span id="logoibon"><a href="http://www.ibon.com.tw" title="7-ELEVEN ibon 便利生活站"></a></span>
		<span id="ad_header">
<ul><li class="first"><a href='http://ticket.7net.com.tw/index.php?class=funcnav&func=news&work=detail&news_id=1863' target='_self' title='102年ibon票券兌換辦法-新增CITY CAFÉ優惠'><img src='http://61.57.227.51/image/ad/ad_3bbda4a741057f74f9e6424a9320408f.gif' width='610' height='65' ></a></li></ul>		</span>
		<span id="logo711"><a href="http://www.7net.com.tw" title="7-ELEVEN 購物網站"></a></span>
	</div>
	<div id="ad_headertxt">
<a href='http://ticket.7net.com.tw/index.php?class=funcnav&func=news&work=detail&news_id=1944' target='_self' title='7/13(六)OPEN小將舞台劇-魔法星球的大冒險 退票說明'>7/13(六)OPEN小將舞台劇-魔法星球的大冒險 退票說明</a>　　　<a href='http://ticket.7net.com.tw/index.php?class=funcnav&func=news&work=detail&news_id=1942' target='_self' title='「相信音樂」劉若英演唱會 &五月天演唱會售票延期公告'>「相信音樂」劉若英演唱會 &五月天演唱會售票延期公告</a>	</div>
</div>

<!--本站功能選項-->

<style type="text/css">
#nav {
	float: left;
	width: 948px;
	height: 40px;
	color: #fff;
	background: url(http://61.57.227.51/image/navBg1201.gif) repeat-x;
	/*border-bottom: 1px solid #6ba20d;*/
	font-size: 16px;
	line-height: 38px;
}
/*nav*/
.nav {
	padding: 0px;
}
.nav a {
	padding: 0px 7px 0px 7px;
	color: #fff;
}
.nav a:hover, .navActive {
	padding: 4px 7px 5px 7px;
	color: #ffff00;
	background: #1f6e06;
	text-decoration: none;
}
.navActive a, .navActive a:hover {
	color: #ffff00;
	text-decoration: none;
}
</style>

<div id='nav'>
<span class='nav'><a href='http://ticket.7net.com.tw'>首頁</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=limit&amp;func=limit' target='_self'>限時搶購</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;category=ibon' target='_self'>ibon推薦</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;work=travel' target='_self'>旅遊</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;work=traffic' target='_self'>交通</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;category=concert' target='_self'>演唱會</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;category=exhibition' target='_self'>展覽</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;category=sport' target='_self'>運動</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;category=child' target='_self'>親子</a></span>│<span class='nav'><a href='/index.php?class=activity&amp;func=activity&amp;work=movie' target='_self'>電影</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;category=music' target='_self'>音樂</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;category=lecture' target='_self'>講座</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;category=dance' target='_self'>舞蹈</a></span>│<span class='nav'><a href='http://ticket.7net.com.tw/index.php?class=activity&amp;func=activity&amp;category=drama' target='_self'>戲劇</a></span></div>
<div class='content'></div>
<script type="text/javascript">
    // <![CDATA[
    var category_url_limit = 'http://ticket.7net.com.tw/index.php?class=limit&func=limit';
    var category_url_ibon = '';
    var category_url_travel = 'http://ticket.7net.com.tw/index.php?class=activity&func=activity&work=travel';
    var category_url_traffic = 'http://ticket.7net.com.tw/index.php?class=activity&func=activity&work=traffic';
    var category_url_concert = '';
    var category_url_exhibition = '';
    var category_url_sport = '';
    var category_url_child = '';
    var category_url_movie = '/index.php?class=activity&func=activity&work=movie';
    var category_url_music = '';
    var category_url_lecture = '';
    var category_url_dance = '';
    var category_url_drama = '';
    var category_url_others = '';

    function search_check(fObj, action) {
        switch (action) {
            case 'search':
                switch (fObj.search_type.value) {
                    case 'activity':
                        if (fObj.search_activity_category.value == '' && fObj.search_field_area.value == '' && fObj.search_game_date.value == '' && fObj.search_game_end_date.value == '' && fObj.search_activity_name.value == '') {
                            $.prompt('請至少輸入一組搜尋條件！');
                            return false;
                        }
                        fObj.elements['class'].value = 'activity';
                        fObj.func.value = 'activity';
                        fObj.work.value = '';
                        fObj.offset.value = '';
                        fObj.submit();
                        break;
                    case 'limit':
                        //if( fObj.search_limit_type.value == '' && fObj.search_limit_area.value == '' && fObj.search_limit_starttime.value == '' && fObj.search_limit_endtime.value == '' && fObj.search_limit_title.value == '' ) {
                        fObj.elements['class'].value = 'limit';
                        fObj.func.value = 'limit';
                        $('[name="work"]').val('');
                        fObj.offset.value = '';
                        fObj.submit();
                        break;
                }
                break;
            case 'clear_search':
                $('#' + fObj.func.value).find('input, select').val('');
                break;
        }
    }

    function change_category(fObj, category) {
        if (category != '' && eval('category_url_' + category) != '')
            window.location = eval('category_url_' + category);
    }
    // ]]>
</script>
<!--左側區塊-->
<div id="func">

<!--搜尋功能-->

<style type="text/css">
#search_type {
	margin-bottom: 40px;
}
#search_type a {
	border: 1px solid #333333;
	padding: 2px;
	margin: 0px 2px;
	width: 76px;
	float: left;
	font-weight: bold;
}
#search_type a.selected {
	background: #eeeeee;
}
</style>
<div class="searchtop"></div>
<div class="area">
	<div id="search_type" class="fcNote">
		<a href="#activity" class="selected">售票節目</a><a href="#limit">限時搶購</a>
	</div>
	<div id="activity">
		<div class="function">
			<label>節目類型</label>
			<select name="search_activity_category" onchange="change_category(this.form, this.value);">
				<option value="">不分類型</option>
				<option value="limit">限時搶購</option>
				<option value="ibon">ibon推薦</option>
				<option value="travel">旅遊</option>
				<option value="traffic">交通</option>
				<option value="concert">演唱會</option>
				<option value="exhibition">展覽</option>
				<option value="sport">運動</option>
				<option value="child">親子</option>
				<option value="movie">電影</option>
				<option value="music">音樂</option>
				<option value="lecture">講座</option>
				<option value="dance">舞蹈</option>
				<option value="drama">戲劇</option>
			</select>
		</div>
		<div class="function">
			<label>場地類別</label>
			<select name="search_field_area">
				<option value="">不限</option>
				<option value="基隆">基隆</option>
				<option value="臺北市">臺北市</option>
				<option value="新北市">新北市</option>
				<option value="桃園">桃園</option>
				<option value="新竹">新竹</option>
				<option value="苗栗">苗栗</option>
				<option value="臺中">臺中</option>
				<option value="彰化">彰化</option>
				<option value="南投">南投</option>
				<option value="雲林">雲林</option>
				<option value="嘉義">嘉義</option>
				<option value="臺南">臺南</option>
				<option value="高雄">高雄</option>
				<option value="屏東">屏東</option>
				<option value="宜蘭">宜蘭</option>
				<option value="花蓮">花蓮</option>
				<option value="臺東">臺東</option>
				<option value="澎湖">澎湖</option>
				<option value="金門">金門</option>
				<option value="連江">連江</option>
			</select>
		</div>
		<div class="function">
			<label>開始日期</label>
			<input type="text" id="search_game_date" name="search_game_date" value="" size="8" maxlength="10" />
		</div>
		<div class="function">
			<label>結束日期</label>
			<input type="text" id="search_game_end_date" name="search_game_end_date" value="" size="8" maxlength="10" />
		</div>
		<div class="function">
			<label>關&nbsp;鍵&nbsp;字</label>
			<input type="text" name="search_activity_name" value="" size="10" maxlength="30" />
		</div>
	</div>
	<div id="limit" style="display: none;">
		<div class="function">
			<label>商品類型</label>
			<select name="search_limit_type">
				<option value="">不分類型</option>
<option value="0">旅遊票</option>string(0) ""
<option value="1">活動票</option>string(0) ""
			</select>
		</div>
		<div class="function">
			<label>商品區域</label>
			<select name="search_limit_area">
				<option value="">不限</option>
<option value="N">北區</option><option value="C">中區</option><option value="S">南區</option><option value="E">東區</option><option value="O">不區分</option>			</select>
		</div>
		<div class="function">
			<label>關&nbsp;鍵&nbsp;字</label>
			<input type="text" id="search_limit_title" name="search_limit_title" value="" size="10" maxlength="30" />
		</div>
	</div>
	<div class="padTop10"></div>
	<div class="funcBtn"><input type="button" value="查詢" onclick="search_check(this.form, 'search')" /> <input type="button" value="重設" onclick="    search_check(this.form, 'clear_search')" /></div>
</div>
<div class="funcBw"></div>

<!--會員專區-->
<style type="text/css">
/*
#func .area_mem {
	float: left;
	width: 202px;
	padding: 10px 0px 0px 0px;
	border-left: 1px solid #cccccc; /*基本線條色*/
	border-right: 1px solid #cccccc; /*基本線條色*/
	font-size: 12px;
}
*/
</style>
<div class="memtop"></div>
<div class="area">
	<a href="http://ticket.7net.com.tw/index.php?class=member&amp;func=login&amp;urlnow=http%3A%2F%2Fticket.7net.com.tw%2F%3Fclass%26%2361%3Bfuncnav%26amp%3Bfunc%26%2361%3Bnews%26amp%3Bwork%26%2361%3Bdetail%26amp%3Bnews_id%26%2361%3B1925">登入會員</a><br />[ <a href="https://www.7net.com.tw/7net/rui012.faces">立即申請成為7net會員</a> ]
</div>
<div class="funcBw"></div>
<!--ibon社群-->
<div class="clear"></div>
<iframe src="http://www.facebook.com/plugins/likebox.php?id=117731398245673&width=202&connections=0&stream=false&header=true&height=62" scrolling="no" frameborder="0" style="border: 1px solid #ccc; overflow: hidden; width: 202px; height: 62px;" allowtransparency="true"></iframe>

<!--左側‧招商banner-->
<div class="clear"></div>
<a href='http://www.ibon.com.tw/0000/sponsor.aspx' target='_blank'><img src='http://61.57.227.51/image/banner_proposal.gif' width='204' height='80' /></a>


<!--廣告‧左側-->
<div class="clear"></div>
<ul>
<li class='ad'><a  href='http://ticket.7net.com.tw/index.php?class=funcnav&func=news&work=detail&news_id=1950' target='_self'><img src='http://61.57.227.51/image/ad/ad_30ed683ded04b50d11ec8735da3ade34.jpg' width='204' height='80' title='2013大彩虹音樂節高鐵套票' alt='2013大彩虹音樂節高鐵套票' /></a></li>
<li class='ad'><a  href='http://ticket.7net.com.tw/index.php?class=funcnav&func=news&work=detail&news_id=1910' target='_self'><img src='http://61.57.227.51/image/ad/ad_9184d2f98d3012797e6e2dddb4964d2a.jpg' width='204' height='80' title='犀利口舍小趴 演唱會' alt='犀利口舍小趴 演唱會' /></a></li>
<li class='ad'><a  href='http://ticket.7net.com.tw/index.php?class=funcnav&func=news&work=detail&news_id=1896' target='_self'><img src='http://61.57.227.51/image/ad/ad_5f5b56f05a48394fe04c771d6aad4f6c.jpg' width='204' height='80' title='嚴爵鋼鐵情人PIANO MAN演唱會' alt='嚴爵鋼鐵情人PIANO MAN演唱會' /></a></li>
</ul>
</div>
<!--內容-->
<div id='content'>
<div id='pageguide'>目前位置：<a href='http://ticket.7net.com.tw'>首頁</a> > <a href='http://ticket.7net.com.tw/index.php?class=funcnav&func=news'>最新消息</a> > 最新消息內容</div>
<div class='area'>
<h3 class='fcSpot'>TOYOTA X 五月天諾亞方舟航空母艦版-明日重生版</h3><div class='fcLight clear'>2013/07/20</div><img src='http://61.57.227.51/image/news/news_f3967694e76c73e3bfff877d1719f4c4.jpg' class='insert' align='left' /><div style='clear:both;'></div><p><a title="購票流程" href="http://www.ibon.com.tw/steps/1020720_01.html" target="_blank"><img src="http://61.57.227.51/image/news/upload/news_007226d1e054e32bb5e4e14999b9fa1f.jpg" alt="" /></a><a title="取票流程" href="http://www.ibon.com.tw/steps/1020720_02.html" target="_blank"><img src="http://61.57.227.51/image/news/upload/news_b06eeb2cc59781f79f652618761c3a78.jpg" alt="" /></a><a title="網路購票唬程" href="http://www.ibon.com.tw/steps/1020720_03.html" target="_blank"><img src="http://61.57.227.51/image/news/upload/news_becdcb4677088ae5ad807af994bf64cd.jpg" alt="" /></a><a title="身障傳真" href="http://210.61.8.93/doc/2013MD-fax-0705.doc" target="_blank"><img src="http://61.57.227.51/image/news/upload/news_c161bf6c6f33b1671fedbd6beb75239e.jpg" alt="" /></a><a href="http://ticket.7net.com.tw/index.php?class=activity&func=activity&work=detail&activity_id=19847&category=ibon" target="blank"><img src="http://61.57.227.51/image/news/upload/news_6ed812eed33892f1aaee4b20c547771b.jpg" alt="" /></a></p>
<p style="text-align: left;"><img src="http://61.57.227.51/image/news/upload/news_570838b4de3c063fc23e93d76f4817ab.jpg" alt="" /></p>
<p><span style="font-size: small; color: #000000;"><strong>開賣時間：</strong>2013/7/20(六)上午11:00</span><br /><span style="font-size: small; color: #000000;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ibon售票系統機台及網站同步開賣(未開放行動裝置購票)</span><br /><br /><span style="color: #ff0000;">原定7/13(六) am11:00 五月天「諾亞方舟」演唱會-台中場售票延期一週，售票時間更改為7/20(六)am11:00，售票地點不變（全台7-ELEVEN ibon售票系統門市&網站 http://ticket.7net.com.tw/）<br /><br />11:00售票時-每張繳費單繳款期限延長為三十分鐘。<br />清票後再次開賣時-每張繳費單繳款期限恢復將為十分鐘。<br /> <br /></span><span style="font-size: small; color: #000000;"><strong>演出時間：</strong>2013/9/6、9/7、9/14、9/15</span> 19:30開唱<br /><span style="font-size: small; color: #000000;"><strong>演出地點：</strong>台中 國立台灣體育運動大學 台中校區 田徑場</span><br /><span style="font-size: small; color: #000000;"><strong>票價說明：</strong>3880/3280/2880/2580/2280/1880/1280/480(票價480區為視線不良區，購買前請再三思考)</span><br /><span style="color: #000000;"><strong>場地圖：</strong></span><br /><br /><a href="http://61.57.227.51/image/news/upload/news_d0de2955de15eb691e45c459cc44b7d3.jpg" target="_blank"><img src="http://61.57.227.51/image/news/upload/news_77762e3ae522018c2ef84c1929151350.jpg" alt="" /></a><br /><br /><strong><span style="font-size: small; color: #000000;">購票前請詳閱注意事項：</span></strong><br /><span style="font-size: small;">(01.每人每次限購四張。(為維護歌迷購票權益，敬請遵守，造成不便亦請見諒。)</span><br /><span style="font-size: small;">(02.請確實核對訂購內容，本票劵一經列印售出，表示台端同意支付本次交易的內容與價格，台端不得以任何理由拒付</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp; &nbsp; 本次交易費用。</span><br /><span style="font-size: small;">(03.</span>看台綠區因區域角度偏斜，觀看演出時會產生視線阻隔跟障礙，購買前務必三思再行購買。購買時即表示您已了解<br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp; </span>並同意主辦單位公告之內容。<br /><span style="font-size: small;">(04.購買各種優惠票劵者，需於購票與使用時依主辦單位規定出示相關證明文件。</span><br /><span style="font-size: small;">(05.入場卷請小心保管，如發生遺失、損毀、破損等情形，一律不予重新開票。</span><br /><span style="font-size: small;">(06.任意塗改、影印或套印、掃描複製票劵，均屬無效票。</span><br /><span style="font-size: small;">(07.每張票劵限一人及使用一次。退票須酌收票面金額10%手續費，</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp; 詳洽票務洽詢：(02)2659-9900/0800-016-138。</span><br /><span style="font-size: small;">(08.為維護您的入場權益，請持票人確實遵守各演出場館之規定。</span><br /><span style="font-size: small;">(09.持卡人與訂購人需為同一人，若非同一人，導致台端訂購內容發生錯誤，請台端自行負責。</span><br /><span style="font-size: small;">(10.為維護安全，看台座位區身高未滿110公分之兒童請勿入場。及為維護體育場之草皮，搖滾區請勿穿高跟鞋入場。</span><br /><span style="font-size: small;">(11.若因節目取消、延期，已取票劵者恕不退還取票服務費。</span><br /><span style="font-size: small;">(12.攝錄影器材：活動現場嚴禁攝影、拍照、錄音，不得攜帶相機、攝影機入場，如經查獲，將由工作人員留置器材</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp; 保管並刪除拍攝內容，但損壞與遺失概不負責，現場工作人員亦有權將底片與記憶卡加以強制曝光或強制刪除，</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp; 並保留法律追訴權，謝謝您的合作。</span><br /><span style="font-size: small;">(13.主辦單位保留加場及相關演出內容之權益。</span><br /><span style="font-size: small;">(14.請您於購票前確認購票細節。並呼籲您不要購買來路不明的票劵，以免自身權益受損，主辦單位將保留認定票券</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp; 合法性之權利。其他購票相關問題請您電洽ibon客服諮詢專線0800-016-138或02-2659-9900（24小時）由</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp; 客服人員為您服務解說。</span><br /><br /><strong><span style="font-size: small; color: #000000;">ibon機台購票提醒：</span></strong><br /><span style="font-size: small;">&nbsp; (1.每人每筆交易僅限四張。</span><br /><span style="font-size: small;">&nbsp; (2.快速購票：</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A.快捷鍵：點選ibon機台左下方【TOYOTA X 五月天諾亞方舟航空母艦版-明日重生版】快捷鍵進入購票須</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 知頁面進行購票。</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B.代碼輸入：代碼輸入【BEI】進入購票須知頁面進行購票。</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C.活動票券：點選【活動票券】進入選擇【TOYOTA X 五月天諾亞方舟航空母艦版-明日重生版】節目按鈕</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 後詳閱購票須知進行購票。</span><br /><span style="font-size: small;">&nbsp; (3. ibon購票時可選擇【電腦配位】加速購票流程。</span><br /><span style="font-size: small;">&nbsp; (4.選擇【電腦配位】該區若無連續座位將顯示「此區無連續座位，請重新再試」。</span><br /><span style="font-size: small;">&nbsp; (5.購票流程中若出現小綠人及流量控管中，請耐心等候重新再試。</span><br /><br /><strong><span style="font-size: small; color: #000000;">網站購票提醒：</span></strong><br /><span style="font-size: small;">&nbsp; (1.每人每筆交易僅限四張。</span><br /><span style="font-size: small;">&nbsp; (2.網站購票前需先加入7-net會員並完成驗證手續。</span><br /><span style="font-size: small;">&nbsp; (3.線上購票限使用信用卡交易。</span><br /><span style="font-size: small;">&nbsp; (4.線上刷卡購票的取票序號及驗證碼將於訂票完成後</span><span style="font-size: small;">下一個工作日中午12點產生，請利用【<a href="http://ticket.7net.com.tw/index.php?class=member&func=order" target="_blank">訂單查詢</a>】</span><span style="font-size: small;">功能確認取票</span><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="font-size: small;">資料</span><span style="font-size: small;">。</span><br /><span style="font-size: small;">&nbsp; (5.線上刷卡購票於ibon機台取票，每筆將酌收$30手續費，於門市取票時以現金方式支付。</span><br /><span style="font-size: small;">&nbsp; (6.海外人士請多利用ibon售票系統網站進行刷卡購票，海外刷卡僅限VISA、MasterCard、JCB</span><span style="font-size: small;">、銀聯卡</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; （無法使用：AE、大來）。</span><br /><span style="font-size: small;">&nbsp; (7.身心障礙人士請透過【身心障礙傳真】按鈕下載傳真表單，並於7/20 (六) 上午11:00起連同「身心障礙</span><span style="font-size: small;">手冊</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 影本」傳真到02-2627-9787進行購票，將於收到傳真三個工作天內，告知購票者取票相關資訊 (若身心</span><span style="font-size: small;">障礙</span><span style="font-size: small;">席</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 已售罄亦一併通知，數量有限售完為止)。</span><br /><span style="font-size: small;">&nbsp; (8.取票截止時間為各場次開演當天中午12點前，請利用7-ELEVEN門市ibon取出正式票券，代碼輸入【BEJ】進入</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 購票須知頁面進行取票。</span><br /><br /><strong><span style="font-size: small; color: #000000;">退票方式說明：</span></strong><br /><span style="font-size: small;">&nbsp; (1.個人因素退票者須酌收票面金額10%手續費，請於各場次開演前十日寄回，演出前十日內恕不接受退票。</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ex：2013/9/6場次於2013/8/27(含)截止，以收件郵戳日期為憑。</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2013/9/7場次於2013/8/28(含)截止，</span><span style="font-size: small;"><span style="font-size: small;">以</span>收件郵戳日期為憑。</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2013/9/14場次於2013/9/4(含)截止，</span><span style="font-size: small;"><span style="font-size: small;">以</span>收件郵戳日期為憑。</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2013/9/15場次於2013/9/5(含)截止，</span><span style="font-size: small;"><span style="font-size: small;">以</span>收件郵戳日期為憑。</span><br /><span style="font-size: small;">&nbsp; (2.退票方式：</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A.『TOYOTA X 五月天諾亞方舟航空母艦版-明日重生版』完整票券正本連同姓名、連絡電話、發票寄送地址。</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B.滙款銀行存摺封面影本(包括銀行名、分行名、戶名及帳號)以台灣本地銀行為限。</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C.以郵寄方式掛號或快遞寄至「114台北市內湖區洲子街81號9樓，安源資訊客服部收」。</span><br /><span style="font-size: small;">&nbsp; (3.ibon票務資訊網刷卡購票者，可依下列方式辦理退票：</span><br /><span style="font-size: small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (A. 已經取得正式票券者，請將完整票券連同上述相關資料(A)一併寄回申請退票。</span><br />&nbsp; &nbsp;&nbsp;&nbsp; (B. 尚未取得正式票券者，可致電ibon客服中心提供訂單編號、持卡人全名與聯絡資訊申請退票。<br />&nbsp;&nbsp;&nbsp; &nbsp; (C. 原使用刷卡購票者退票款項將退回原刷卡銀行，請主動向銀行端查詢退費進度。<br /><span style="font-size: small;">&nbsp; (4.退款流程需約20個工作天（收到退票申請起計算）。</span><br /><span style="font-size: small;">&nbsp; (5. ibon客服諮詢專線0800-016-138或02-2659-9900（24小時）</span></p></div>
<div id='pagination'>
<a href='http://ticket.7net.com.tw/index.php?class=funcnav&func=news&work=detail&news_id=1950'>下一筆</a></div>
</div>
<script type="text/javascript">
    // <![CDATA[
    function open_superdom() {
        window.open("http://www.ibon.com.tw/Test_confirm.asp", "supersom", "status=no, toolbar=no, scrollbars=yes, location=no, height=250");
    }
    // ]]>
</script>
<!--表尾-->
<div id='footer'>
	<div id='ad_footer'>
<ul><li class="first"><a href='http://ticket.7net.com.tw/index.php?class=activity&func=activity&work=detail&activity_id=19908&category=ibon' target='_self' title='高雄哆啦A夢'><img src='http://61.57.227.51/image/ad/ad_9b352df6b25b174d828a65694d51a854.jpg' width='228' height='64' ></a></li><li><a href='http://ticket.7net.com.tw/index.php?class=funcnav&func=news&work=detail&news_id=1904' target='_self' title='Robot Kitty未來樂園'><img src='http://61.57.227.51/image/ad/ad_3aab7edf446b53bf4edf39b12a2999d0.jpg' width='228' height='64' ></a></li><li><a href='http://ticket.7net.com.tw/index.php?class=activity&func=activity&work=detail&activity_id=19660&category=ibon' target='_self' title='高雄啤酒節'><img src='http://61.57.227.51/image/ad/ad_54e42aeb56f49da52e6af06d66bbcb0c.jpg' width='228' height='64' ></a></li><li><a href='http://ticket.7net.com.tw/index.php?class=activity&func=activity&work=detail&activity_id=19657&category=ibon' target='_self' title='彩色音樂節'><img src='http://61.57.227.51/image/ad/ad_e2b39758fc444d431e435d71463a184e.jpg' width='228' height='64' ></a></li></ul>	</div>
	<div id='info'>
		<div class="footer2">
			<div id="footmenu" style="text-align:right;">
            <a href="http://www.ibon.com.tw/0600/ticket.aspx">ibon退票說明</a> | 
            <span>票務客服專線: 0800-016-138</span> | 
                        <a href="http://www.7-11.com.tw/">7-ELEVEN首頁</a> | <a href="http://www.ibon.com.tw/">ibon首頁</a></div>
			<!--<div class="menu">| <a href="http://www.7net.com.tw/knowledge/knowledgeA1.html" target="_blank">關於7net</a> | <a href="http://www.7net.com.tw/7net/rui064.faces" target="_blank">隱私權政策</a> | <a href="http://www.7net.com.tw/knowledge/knowledgeA2.html" target="_blank">會員權益條款</a> |<a href="http://www.7net.com.tw/7net/rui030.faces" target="_blank"> 廠商提案專區</a> | <a href="http://www.7net.com.tw/knowledge/knowledgeD2.html" target="_blank">折價券說明</a> | <a href="http://www.7net.com.tw/7net/rui031.faces?qType=1101" target="_blank">Q&amp;A</a> | <a href="http://www.7net.com.tw/7net/rui030.faces" target="_blank">客服中心</a> | <a href="http://www.7net.com.tw/7net/rui032.faces" target="_blank">購物需知</a> | <span class='red'>票務客服專線 0800-016-138</span> |</div>-->
			<div class="logo"><img src="http://61.57.227.51/image/footer/down_logo.gif" width="127" height="51" title="7-ELEVEN" alt="7-ELEVEN" /></div>
			<div class="other">
			<img src="http://61.57.227.51/image/footer/footer_logo1.gif" width="90" height="65" title="2011年企業網站50強" alt="2011年企業網站50強" />
			<img src="http://61.57.227.51/image/footer/footer_logo2.gif" width="120" height="65" title="2011年數位時代Web 100強" alt="2011年數位時代Web 100強" />
			<!--<img src="http://61.57.227.51/image/footer/footer_logo3.gif" width="100" height="65">-->
			</div>
			<div class="copyright">&copy;2010 President Chain Store Corporation. All rights reserved.</div>
		</div>
	</div>
</div>
</form>
</div>
<link href="http://ticket.7net.com.tw/css/footer.css" rel="stylesheet" type="text/css">

<script language="javascript">
    $(function () {
        $("input[type='button']").bind('mousemove', function () {
            $(this).css('color', '#000000');
            $(this).css('backgroundColor', '#8FC31F');
        });
        $("input[type='button']").bind('mouseout', function () {
            $(this).css('color', '');
            $(this).css('backgroundColor', '');
        });
        $("input[type='submit']").bind('mousemove', function () {
            $(this).css('color', '#000000');
            $(this).css('backgroundColor', '#8FC31F');
        });
        $("input[type='submit']").bind('mouseout', function () {
            $(this).css('color', '');
            $(this).css('backgroundColor', '');
        });
    })
</script>
<script type="text/javascript">
    // <![CDATA[
    var trueLeft, trueTop, objx;

    function getPoint(obj, id, tp) {
        var addL, addT;
        var target = document.getElementById(id);
        var SearchElfather = obj.parentNode;
        var poL = SearchElfather.offsetLeft;
        var poT = SearchElfather.offsetTop;

        while (SearchElfather = SearchElfather.offsetParent) {
            poT += SearchElfather.offsetTop;
            poL += SearchElfather.offsetLeft;
        }

        if (navigator.appName == "Netscape") { addL = 0; addT = 26; } else { addL = 0; addT = 26; }
        trueLeft = poL + addL;
        trueTop = poT + addT;
        objx = target;

        if (tp) {
            target.style.display = 'inline';
            target.style.top = trueTop + 'px';
            target.style.left = trueLeft + 'px';
        } else { target.style.display = 'none'; }
    }

    function keepDiv(tp) {
        if (tp) {
            objx.style.display = 'inline';
            objx.style.top = trueTop + 'px';
            objx.style.left = trueLeft + 'px';
        } else { objx.style.display = 'none'; }
    }

    function chgMainProdIMG(id, value) { document.images[id].src = value; }

    function chgCatalogue(id, value, text) {
        document.getElementById('cataTitle').innerHTML = text;
        chgMainProdIMG(id, value);
    }
    function chgBlockShow(id, sw, end) { var st; for (var i = 1; i <= end; i++) { st = (i == sw) ? 'inline' : 'none'; document.getElementById(id + i).style.display = st; } }
    // ]]>
</script>
</body>
</html>
