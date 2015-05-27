﻿function isEmpty(str) {
    return (!str || 0 === str.length);
}

$(document).ready(function () {
    var originalURL = window.location.href;
    var q = getQueryStringParameter(originalURL, "GridPageSize");
    if (!isEmpty(q)) {
        $("#GridListItemSize").val(q);
    }



    $("#DeselectAll").click(function () {
        console.log("DeselectAll is clicked.");
        var i = 0;
        $("input[name=checkboxGrid]").each(function () {
            var m = $(this).prop('checked', false);
        });
    });
    $("#SelectAll").click(function () {
        console.log("SelectAll is clicked.");
        var i = 0;
        $("input[name=checkboxGrid]").each(function () {
            var m = $(this).prop('checked', true);
        });
    });
    function GetSelectedCheckBoxValues() {
        var stringArray = new Array();
        var i = 0;
        $("input[name=checkboxGrid]").each(function () {
            var m = $(this).is(':checked');
            if (m) {
                stringArray[i++] = $(this).attr("gridkey-id");
            }
        });
        var jsonRequest = JSON.stringify({ "values": stringArray });
        return jsonRequest;
    }
    function OrderingItem() {
        var item = this;
        item.Id = "";
        item.Ordering = "";
        return item;
    }
    function GetSelectedOrderingValues() {
        var itemArray = new Array();
        var i = 0;
        $("input[name=gridOrdering]").each(function () {
            var id = $(this).attr("gridkey-id");
            //var m = $("input[name=checkboxGrid]").find('[gridkey-id='+id+']').is(':checked');
            //if (m) {
                var item = new OrderingItem();
                item.Id = id;
                item.Ordering=$(this).val();
                itemArray[i++] = item;
            //}
        });
     
        var jsonRequest = JSON.stringify({ "values": itemArray });
        return jsonRequest;
    }
    $("#DeleteAll").click(function () {
        console.log("DeleteAll is clicked.");
        var postData = GetSelectedCheckBoxValues();
        var parsedPostData = jQuery.parseJSON(postData);
        if (parsedPostData.values.length > 0) {
            var tableName = $("[data-gridname]").attr("data-gridname");
            if (tableName == "imagesGrid") {
                ajaxMethodCall(postData, "/FileManager/DeleteAll", deleteItemsSuccess);
            } else if (tableName == "contentGrid") {
                ajaxMethodCall(postData, "/Ajax/DeleteContentItem", deleteItemsSuccess);
            }
        }
        
    });
    $("#OrderingAll").click(function () {
        console.log("OrderingAll is clicked.");
        var postData = GetSelectedOrderingValues();
        console.log(postData);
        var tableName = $("[data-gridname]").attr("data-gridname");
        if (tableName == "imagesGrid") {
            ajaxMethodCall(postData, "/Ajax/ChangeContentGridOrderingOrState", changeOrderingSuccess);
        } else if (tableName == "contentGrid") {
            ajaxMethodCall(postData, "/Ajax/ChangeContentGridOrderingOrState", changeOrderingSuccess);
        }
    });

    function GetSelectedStateValues(checkboxName,state) {
        var itemArray = new Array();
        var i = 0;
        $('span[name=' + checkboxName + ']').each(function () {
            var id = $(this).attr("gridkey-id");
            var m = $('input[name="checkboxGrid"]').filter('[gridkey-id="' + id + '"]').is(':checked');
            if (m) {
            var item = new OrderingItem();
            item.Id = id;
            item.Ordering = 0;
            item.State = state;
            itemArray[i++] = item;
            }
        });
      
        return itemArray;
    }
    $("#SetStateOffAll").click(function () {
        console.log("SetStateOffAll is clicked.");
        changeState(false);
    });
    $("#SetStateOnAll").click(function () {
        console.log("SetStateOnAll is clicked.");
        changeState(true);
    });
    function changeState(state) {
        var ppp = $("#ItemStateSelection").val();
        var selectedValues = GetSelectedStateValues("span" + ppp, state);
        var postData = JSON.stringify({ "values": selectedValues, "checkbox": ppp });
        console.log(postData);
        var tableName = $("[data-gridname]").attr("data-gridname");
        if (tableName == "imagesGrid") {
            ajaxMethodCall(postData, "/Ajax/ChangeContentGridOrderingOrState", changeStateSuccess);
        } else if (tableName == "contentGrid") {
            ajaxMethodCall(postData, "/Ajax/ChangeContentGridOrderingOrState", changeStateSuccess);
        }
    }
    $("#GridListItemSize").change(function (e) {
        var originalURL = window.location.href;
        if (originalURL.split('?').length > 1) {
            window.location.href = updateUrlParameter(originalURL, 'GridPageSize', $('#GridListItemSize option:selected').val())
        } else {
            window.location.href = window.location.href + "?GridPageSize=" + $('#GridListItemSize option:selected').val();
        }
    });
    function updateUrlParameter(originalURL, param, value)
    {
        console.log(value);
        var windowUrl = originalURL.split('?')[0];
        var qs = originalURL.split('?')[1];
        //3- get list of query strings
        var qsArray = qs.split('&');
        var flag = false;
        //4- try to find query string key
        for (var i = 0; i < qsArray.length; i++) {
            if (qsArray[i].split('=').length > 0) {
                if (param == qsArray[i].split('=')[0]) {
                    //exists key
                    qsArray[i] = param + '=' + value;
                    flag = true;
                    break;
                }  
            }
        }
         
        var finalQs = qsArray.join('&');
        return windowUrl + '?' + finalQs;
        //6- prepare final url
       // window.location = windowUrl + '?' + finalQs;
    }
    function getQueryStringParameter(originalURL, param) {
   
        if (originalURL.split('?').length > 1) {
            var qs = originalURL.split('?')[1];
            //3- get list of query strings
            var qsArray = qs.split('&');
            var flag = false;
            //4- try to find query string key
            for (var i = 0; i < qsArray.length; i++) {
                if (qsArray[i].split('=').length > 0) {
                    if (param == qsArray[i].split('=')[0]) {
                        //exists key
                        return qsArray[i].split('=')[1];
                    }
                }
            }

        }
        return "";
    }
});

function ajaxMethodCall(postData,ajaxUrl, successFunction) {

    $.ajax({
        type: "POST",
        url: ajaxUrl,
        data: postData,
        success: successFunction,
        contentType:"application/json",
        dataType: "json",
        traditional: true
    });
}
function deleteItemsSuccess(data) {

    data.forEach(function (entry) {
        console.log(entry);
        var pp = $('[gridkey-id=' + entry + ']');
        pp.parent().parent().remove();
        console.log(pp);
    });
}
function changeStateSuccess(data) {
    //var parsedPostData = jQuery.parseJSON(data);
    console.log(data);
    data.values.forEach(function (entry) {
        console.log(entry.Id);
        if (entry.State) {
            $('span[name=span' + data.checkbox + ']').find('[gridkey-state-id="' + entry.Id + '"]').attr('src', "/Images/OK.ico");
        } else {
            $('span[name=span' + data.checkbox + ']').find('[gridkey-state-id="' + entry.Id + '"]').attr('src', "/Images/Close.ico");
        }
       

    });
}
function changeOrderingSuccess(data) {
    console.log(data);
}