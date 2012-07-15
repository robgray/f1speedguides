//this is to convert hex to rgb if the skin configuration is run
function HexToR(h) { return parseInt((cutHex(h)).substring(0, 2), 16) }
function HexToG(h) { return parseInt((cutHex(h)).substring(2, 4), 16) }
function HexToB(h) { return parseInt((cutHex(h)).substring(4, 6), 16) }
function cutHex(h) { return (h.charAt(0) == "#") ? h.substring(1, 7) : h }



 function includeCSS(p_file) {
        var v_css = document.createElement('link');
        v_css.rel = 'stylesheet'
        v_css.type = 'text/css';
        v_css.href = p_file;
        document.getElementsByTagName('head')[0].appendChild(v_css);
}


$(document).ready(function () {
  
        $(".tagcloud a").hover(function(){
          normal = $(this).css("background");
          $(this).css({
            'padding' : '4px 6px',
            'margin-bottom' : '-3px',
            'margin-top' : '-3px',
            'background' : 'rgba(54, 136, 175, 1)'
          })
        }, function(){
          $(this).css({
            'padding' : '1px 6px',
            'margin' : '4px 1px',
            'background' : normal
          })
        });
          // was using :before psuedo selectors but IE9 decided it didn't want to apply border-radius pseudo elements :(
        $("li.current").append("<span class=\"marker\"></span>");

    });

function ConvertUtcTimeToLocalTime() {
    var timeElements = getElementsByAttribute(document, '*', 'utctime');
    if (timeElements != 'undefined' && timeElements) {
        var oAttribute;
        var oCurrent;
        for (var i = 0; i < timeElements.length; i++) {
            oCurrent = timeElements[i];
            oAttribute = oCurrent.getAttribute && oCurrent.getAttribute('utctime');

            var d = new Date();
            var utcTime = new Date(oAttribute);
            var localTime = new Date(utcTime + ' GMT');
            var localTimeString = pad(localTime.getDate(), 2) + ' ' + getMonthText(localTime) + ', ' + pad(localTime.getHours(), 2) + ':' + pad(localTime.getMinutes(), 2)

            timeElements[i].innerHTML = localTimeString;
        }
    }                 
};

function getElementsByAttribute(oElm, strTagName, strAttributeName, strAttributeValue) {
    var arrElements = (strTagName == "*" && oElm.all) ? oElm.all : oElm.getElementsByTagName(strTagName);
    var arrReturnElements = new Array();
    var oAttributeValue = (typeof strAttributeValue != "undefined") ? new RegExp("(^|\\s)" + strAttributeValue + "(\\s|$)", "i") : null;
    var oCurrent;
    var oAttribute;
    for (var i = 0; i < arrElements.length; i++) {
        oCurrent = arrElements[i];
        oAttribute = oCurrent.getAttribute && oCurrent.getAttribute(strAttributeName);
        if (typeof oAttribute == "string" && oAttribute.length > 0) {
            if (typeof strAttributeValue == "undefined" || (oAttributeValue && oAttributeValue.test(oAttribute))) {
                arrReturnElements.push(oCurrent);
            }
        }
    }
    return arrReturnElements;
}

function pad(number, length) {

    var str = '' + number;
    while (str.length < length) {
        str = '0' + str;
    }

    return str;
}

function getMonthText(theDate) {
var month=new Array(12);
month[0]="Jan";
month[1]="Feb";
month[2]="Mar";
month[3]="Apr";
month[4]="May";
month[5]="Jun";
month[6]="Jul";
month[7]="Aug";
month[8]="Sep";
month[9]="Oct";
month[10]="Nov";
month[11]="Dec";
return month[theDate.getMonth()];
}