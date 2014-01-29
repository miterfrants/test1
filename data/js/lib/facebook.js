var cookie = {
    getCookie: function (key) {
        if (document.cookie.length > 0) {
            c_start = document.cookie.indexOf(key + "=");
            if (c_start != -1) {
                c_start = c_start + key.length + 1;
                c_end = document.cookie.indexOf(";", c_start);
                if (c_end == -1) c_end = document.cookie.length;
                return unescape(document.cookie.substring(c_start, c_end));
            }
        }
        return "";
    },
    setCookie: function (key, value, exdays) {
        var exdate = new Date();
        exdate.setDate(exdate.getDate() + exdays);
        var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
        document.cookie = key + "=" + c_value;
    }
}
//var fbTokenKey = "ASUS_Event_VivoBook_FB_Token"
//var fbUIDKey = "ASUS_Event_VivoBook_FBID"
var Facebook = {
    fbTokenKey: "",
    fbUIDKey: "",
    getNearbyPlace: function (lat,long,diff,isMerge,callback) {
        var token = cookie.getCookie(this.fbTokenKey);
        //console.log(token)
        var q = "SELECT page_id,name,checkin_count,description FROM place WHERE distance(latitude, longitude, '" + lat + "', '" + long + "') < " + diff
        this._getFQLResult(q, token, function (e) {
            callback(e);
        })
    },
    auth: function (scope, notAuthAction, authAction) {
        FB.login($.proxy(function (r) {
            if (r.status === 'connected') {
                cookie.setCookie(this.fbTokenKey, r.authResponse.accessToken)
                cookie.setCookie(this.fbUIDKey, r.authResponse.userID)
                authAction()
            } else if (r.status === 'not_authorized') {
                notAuthAction(r)
            } else {
                notAuthAction(r)
            }
        }, this), { scope: scope });
    },
    _getFQLResult: function (q, ak, callback) {
        var fqlLikeURL = "https://graph.facebook.com/fql";
        $.ajax({
            url: fqlLikeURL + "?q=" + encodeURI(q) + "&access_token=" + ak + "&callback=?",
            dataType: "json",
            success: function (e) {
                callback(e, this)
            }
        })
    },
    getMyProfile: function (callback) {
        var token = cookie.getCookie(this.fbTokenKey);
        //console.log(token)
        var q = "select pic_big,pic_square,hometown_location,languages,education,contact_email,email,last_name,first_name,name,pic_big,profile_update_time,sex,subscriber_count,work,birthday from user where uid=me()"
        this._getFQLResult(q, token, function (e) {
            callback(e.data);
        })
    },
    getMyHometown: function (callback) {
        var token = cookie.getCookie(this.fbTokenKey);
        var q = "select hometown_location from user where uid=me()"
        this._getFQLResult(q, token, function (e) {
            callback(e.data);
        })
    },
    getFriendList: function (callback) {
        var token = cookie.getCookie(this.fbTokenKey);
        var q = "SELECT name, url, pic_big,pic_square FROM profile WHERE id in (SELECT uid2 FROM friend WHERE uid1=me())"
        this._getFQLResult(q, token, function (e) {
            callback(e.data);
        })
    },
    getRecentyPost: function (callback, limit) {
        var token = cookie.getCookie(this.fbTokenKey);
        //bug
        var q = "select type,message,place,created_time from stream where source_id=me() and type =46 and not (place  in (select place from stream where source_id=me()))  limit " + limit
        this._getFQLResult(q, token, function (e) {
            callback(e.data);
        })
    },
    getMoreLikePost: function (callback) {
        //console.log('fb.js getMoreLikePost');
        var token = cookie.getCookie(this.fbTokenKey);
        var q = "SELECT message,likes,type FROM stream WHERE source_id =me() and message !='' order by likes.count desc limit 5";
        this._getFQLResult(q, token, function (e) {
            callback(e.data);
        })
    },
    getRandomPhoto: function (callback) {
        var token = cookie.getCookie(this.fbTokenKey);
        var q = "SELECT src_big,src,src_small FROM photo WHERE owner=me() ORDER BY rand() limit 15";
        this._getFQLResult(q, token, function (e) {
            callback(e.data);
        })
    },
    getCheckInPhoto: function (callback) {
        var token = cookie.getCookie(this.fbTokenKey);
        var q = "select place_id,src_big,created from photo where owner=me() and place_id order by created desc limit 12";
        // console.log(q)
        var ob = { data: [] };
        this._getFQLResult(q, token, $.proxy(function (e) {
            var inId = "";
            for (var i = 0; i < e.data.length; i++) {
                ob.data[i] = { place_id: e.data[i].place_id, photo: e.data[i].src_big, name: null, country: null };
                inId += e.data[i].place_id + ",";
            }
            if (inId.substr(inId.length - 1, 1) == ",") {
                inId = inId.substr(0, inId.length - 1);
            }
            var q2 = "select name,page_id,location.country from page where page_id in (" + inId + ") "
            this._getFQLResult(q2, token, $.proxy(function (e2) {
                for (var i = 0; i < e2.data.length; i++) {
                    for (var j = 0; j < ob.data.length; j++) {
                        if (ob.data[j].place_id == e2.data[i].page_id) {
                            ob.data[j].name = e2.data[i].name;
                            ob.data[j].country = e2.data[i].location.country;
                        }
                    }
                }
                // console.log("a:" + ob.data.length);
                if (ob.data.length < 12) {
                    var q3 = "select name,page_id,location.country from page where (page_id in (select place_id from photo where owner=me() and place_id) or page_id in ( select place from stream where post_id in (select post_id from checkin where author_uid=me() ) )) and not (page_id in (" + inId + "))";
                    this._getFQLResult(q3, token, function (e3) {
                        var totalLen = ob.data.length;
                        for (var i = 0; i < e3.data.length; i++) {
                            //  console.log(totalLen + i);
                            ob.data[totalLen + i] = { place_id: e3.data[i].place_id, photo: null, name: e3.data[i].name, country: e3.data[i].location.country };
                        }
                        callback(ob.data);
                    })
                } else {
                    callback(ob.data);
                }

            }, this))

        }, this))
    },
    getCheckInCountry: function (callback, limit, loopLimit) {
        //tune
        if (limit == undefined) {
            limit = 5
        }
        if (loopLimit == undefined) {
            loopLimit = 10
        }
        var token = cookie.getCookie(this.fbTokenKey);
        var ob = { data: new Array() };
        this._regetCheckInCountry(token, ob, callback);
    },
    _regetCheckInCountry: function (token, ob, callback) {
        //var q = "select location.country from page where page_id in ( select place from stream where post_id in (select post_id from checkin where author_uid=me() ) ) or page_id  in (select page_id from place where page_id  in (select place from stream where source_id=me() )) order by release_date desc"
        var q = "select location.country,page_id from page where page_id in (select place_id from photo where owner=me() and place_id LIMIT  1000000)"
        this._getFQLResult(q, token, $.proxy(function (e) {
            var arr_country = new Array();
            for (var i = 0; i < e.data.length; i++) {
                if (arr_country.indexOf(e.data[i].location.country) == -1 && e.data[i].location.country != "" && e.data[i].location.country != undefined) {
                    arr_country.push(e.data[i].location.country);
                    ob.data[ob.data.length] = { photo: null, page_id: e.data[i].page_id, location: { country: e.data[i].location.country } }
                }
            }
            var appendPhotoQ = "select src_big,place_id from photo where owner=me() and place_id LIMIT  1000000"
            this._getFQLResult(appendPhotoQ, token, function (e2) {
                for (var i = 0; i < e2.data.length; i++) {
                    for (var j = 0; j < ob.data.length; j++) {
                        if (e2.data[i].place_id == ob.data[j].page_id) {
                            ob.data[j].photo = e2.data[i].src_big
                        }
                    }
                }
                callback(ob.data);
            })
        }, this))
    },
    getCheckIn: function (callback, limit, loopLimit) {
        if (limit == undefined) {
            limit = 5;
        }
        if (loopLimit == undefined) {
            loopLimit = 10
        }
        var token = cookie.getCookie(this.fbTokenKey);
        var ob = { isReturn: false, data: new Array() };
        this._getStreamPlaceMain(token, ob, limit, loopLimit, undefined, callback);
        //_getStreamPlaceMain>_getStreamPlace
        //                   >_appendPhoto>_appendGeoLocation
        callback(ob.data);
    },
    _getStreamPlaceMainCreatedTime: undefined,
    _getStreamPlaceMain: function (token, ob, limit, loopLimit, currentLoop, callback) {
        //var isReturn=-1;
        if (currentLoop == undefined) {
            currentLoop = 1
        }
        if (currentLoop >= loopLimit) {
            return;
        }
        var created_time = undefined
        if (ob.data.length > 0) {
            created_time = ob.data[ob.data.length - 1].created_time;
        } else if (this._getStreamPlaceMainCreatedTime != undefined) {
            created_time = this._getStreamPlaceMainCreatedTime;
        }
        this._getStreamPlace(token, created_time, $.proxy(function (e) {
            ob = this._checkStreamPlaceAndBuildOb(ob, e)
            if (ob.data.length < limit) {
                this._getStreamPlaceMain(token, ob, limit, loopLimit, currentLoop + 1, callback);
            } else {
                //finish to append photo
                this._appendPhoto(token, ob, callback);
            }
        }, this))
    },
    _getStreamPlace: function (token, created_time, callback) {
        var q = "";
        if (created_time != undefined) {
            q = "select place,message,created_time from stream where source_id=me() and created_time<" + created_time + " order by created_time desc"
        } else {
            q = "select place,message,created_time from stream where source_id=me() order by created_time desc"
        }
        var placeIdString = "";
        this._getFQLResult(q, token, callback);
    },
    _checkStreamPlaceAndBuildOb: function (ob, e) {
        var created_time = null
        var currentLimit = ob.data.length;
        var iniStart = ob.data.length;
        // console.log("_checkStreamPlaceAndBuildOb")
        for (var i = 0; i < e.data.length; i++) {
            if (e.data[i].place != null) {
                //console.log("arr length:" + currentLimit);
                ob.data[currentLimit] = { "created_time": null, "country": "", "place": "", "message": "", "photo": "", "name": "", position: null, "desc": "" };
                ob.data[currentLimit]["place"] = e.data[i].place;
                ob.data[currentLimit]["message"] = e.data[i].message;
                ob.data[currentLimit]["created_time"] = e.data[i].created_time;
                currentLimit += 1;
            }
            if (i == e.data.length - 1 && this._getStreamPlaceMainCreatedTime == undefined) {
                this._getStreamPlaceMainCreatedTime = e.data[0].created_time;
            }
        }
        return ob;
    },
    _appendPhoto: function (token, ob, callback) {
        var placeIdString = "";
        for (var i = 0; i < ob.data.length; i++) {
            placeIdString += ob.data[i].place + ",";
        }
        if (placeIdString.substr(placeIdString.length - 1, 1) == ",") {
            placeIdString = placeIdString.substr(0, placeIdString.length - 1);
        }
        q = "select link,place_id from photo where owner=me() and place_id in (" + placeIdString + ")";
        this._getFQLResult(q, token, $.proxy(function (e2) {
            for (var i = 0; i < e2.data.length; i++) {
                for (var j = 0; j < ob.data.length; j++) {
                    if (ob.data[j]["place"] == e2.data[i].place_id) {
                        ob.data[j]["photo"] = e2.data[i].link;
                    }
                }
            }
            this._appendGeoLocation(token, ob, callback, placeIdString)
        }, this))
    },
    _appendGeoLocation: function (token, ob, callback, placeIdString) {
        q = "select page_id,name,latitude,longitude,description from place where page_id in (" + placeIdString + ")";
        this._getFQLResult(q, token, function (e3) {
            for (var i = 0; i < e3.data.length; i++) {
                for (var j = 0; j < ob.data.length; j++) {
                    if (ob.data[j]["place"] == e3.data[i].page_id) {
                        ob.data[j]["name"] = e3.data[i].name;
                        ob.data[j]["position"] = { "lt": e3.data[i].latitude, "lg": e3.data[i].longitude };
                        ob.data[j]["desc"] = e3.data[i].description;
                    }
                }
            }
            //callback(ob.data);
        })
    }

}