requirejs.config({
    "baseUrl": "../js",
    "shim": {
        "lib/jquery.cookie": ["lib/jquery-2.0.2.min"]
    }
});
define(['lib/TweenMax','lib/jquery.cookie'], function () {
    return {
        loginURL: null,
        defaultComment: "",
        collactTimer:0,
        onReady: function (loginURL) {
            this.reposite();
            this.loginURL = loginURL;
            if ($(".lang>.btn.active").length=0 || $.cookie("lang") != $(".lang>.btn.active").data("lang")) {
                $(".lang>.btn.active").addClass("small-icon").removeClass("active").addClass("unactive");
                $(".lang>.btn[data-lang="+$.cookie("lang")+"]").removeClass("small-icon unactive").addClass("active");
                $(".lang>.btn:eq(0)").before($(".lang>.btn[data-lang=" + $.cookie("lang") + "]"));
                $(".lang>.btn.unactive").hide();
            }
            $("body").delegate(".lang>.btn.active","click", function (e) {
                if ($(".lang>.btn.unactive").css("display") != "none") {
                    $(".lang>.btn.unactive").hide();
                } else {
                    $(".lang>.btn.unactive").show();
                }
            })
            $("body").delegate(".lang>.btn.unactive", "click", function (e) {
                $(".lang>.btn.active").addClass("small-icon").removeClass("active").addClass("unactive");
                $(e.currentTarget).removeClass("small-icon unactive").addClass("active");
                $(".lang>.btn:eq(0)").before($(e.currentTarget));
                $(".lang>.btn.unactive").hide();
                $.cookie("lang", $(e.currentTarget).data("lang"));
                location.reload();
            })
            $(".schedule-process .point").bind("mouseenter", function (e) {
                $("dd", $(e.currentTarget)).show();
                $("dd", $(e.currentTarget)).css("opacity", 0);
                TweenMax.to($("dd", $(e.currentTarget)), 0.2, { opacity: 1,bottom:"73px" });
            })
            $(".schedule-process .point").bind("mouseleave", function (e) {
                //$("dd", $(e.currentTarget)).css("opacity", 1);
                $("dd", $(e.currentTarget)).hide();
                $("dd", $(e.currentTarget)).css("bottom", "50px");
                //TweenMax($("dd", $(e.currentTarget)), 0.26, { opacity: 0 });
            })
            $(".btn.login").bind("click", function (e) {
                location.href = loginURL[$(e.currentTarget).data("login")];
            })
            $("body").delegate(".icon-cancel", "click", function (e) {
                location.href = "/controller/member.aspx?action=logout";
            })
            $(".comment").focus(function(e){
                if ($(e.currentTarget).hasClass("no-data")) {
                    this.defaultComment = $(e.currentTarget).val();
                    $(e.currentTarget).val("");
                    $(e.currentTarget).removeClass("no-data");
                }
            })
            $(".comment").blur(function (e) {
                if ($(e.currentTarget).val() != this.defaultComment && $(e.currentTarget).val().replace(/\s/gi, "").length > 0) {
                    return;
                }
                if (!$(e.currentTarget).hasClass("no-data")) {
                    $(e.currentTarget).val(this.defaultComment);
                    $(e.currentTarget).addClass("no-data");
                }
            })
            $(".profile-img").mouseenter(function (e) {
                $(e.currentTarget).children().eq(0).before("<div class=\"icon-cancel\"></div>")
            })
            $(".profile-img").mouseleave(function (e) {
                $(".icon-cancel", $(e.currentTarget)).remove();
            })
            $(window).bind("resize", $.proxy(function (e) {
                this.reposite();
            }, this));

        },
        onLoad: function () {
            setTimeout(function () { $("img.lazy").trigger("winloaded") },100);
        },
        reposite: function () {
            //pose point 
            $(".schedule-process").css("width", $(window).width() - 200);
            console.log($(window).width() );
            var els = $(".schedule-process .point");
            
            var barWidth = $(".schedule-process").width();
            var perDist = barWidth/(els.length-1)
            for (var i = 1; i < els.length - 1; i++) {
                els.eq(i).css("left", perDist * i + "px");
                console.log(perDist * i);
                console.log($("dd", els.eq(i)).outerWidth(true ));
            }
        },
      

  }
});
