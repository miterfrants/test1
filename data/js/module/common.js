requirejs.config({
    "baseUrl": "../js",
    "shim": {
        "lib/jquery.lazyload.min": ["lib/jquery-2.0.2.min"]
    }
});

define(['lib/jquery.lazyload.min'], function () {
    return {
        loginURL: null,
        popupTimer: 1,
        //loginLink {fb,twitter}
        popupLogin: function () {
            var pop = "<div class=\"tri-angle\"></div><ul class=\"popup-login\"><li class=\"icon-circle-fb btn\" data-login-url=\"" + this.loginURL.fb + "\"></li><li class=\"icon-circle-google btn\" data-login-url=\""+this.loginURL.google+"\"></li><li class=\"icon-circle-twitter btn\" data-login-url=\"" + this.loginURL.twitter + "\"></li></ul>";
            $(".member-nav").addClass("active")
            $(".member-nav").append(pop);
            $(".popup-login").mouseout($.proxy(function(e){
                this.popupTimer=setTimeout($.proxy(function(){this.hidePopupLogin()},this),700);
            },this))
            $(".popup-login").mouseover($.proxy(function(e){
                clearTimeout(this.popupTimer);
            },this))
        },
        hidePopupLogin:function(){
            $(".popup-login").remove();
            $(".tri-angle").remove();
            $(".member-nav").removeClass("active");
        },
        onReady: function (loginURL, exp) {
            this.generateLevel(exp);
            this.loginURL = loginURL;
            $(".member-nav.unlogin").click($.proxy(function(e){
                this.popupLogin();
            }, this))
            $("body").delegate(".popup-login .btn", "click", function (e) {
                location.href=$(e.currentTarget).data("login-url")
            })
            $("img.lazy").lazyload({
                event: "winloaded"
            });
        },
        onLoad:function(){
        },
        generateLevel:function(exp){
            var level = 1;
            if (exp > 32) {
                level= Math.floor(Math.log(Number(exp)) / Math.log(2))-3;
            }
            $(".level").html(level);
            var m = Math.pow(2, level + 4);
            var prev_m=0
            if (level > 1) {
                prev_m = Math.pow(2, level - 1 + 4);
            }
            $(".exp-bar").css("width", ((Number(exp)-prev_m) * $(".exp-nav").width()) / (m-prev_m));
        }
  }
});
