$(document).ready(function () {
    //Load results grid - Testing
    LoadGridResults();

    //Set datepicker to dates filds 
    $(".date").datepicker();

    //Init comboboxes Data
    //InitComboboxes();
});

function createXMLHttpRequest() {
    try { return new XMLHttpRequest(); } catch (e) { }
    try { return new ActiveXObject("Msxml2.XMLHTTP"); } catch (e) { }
    try { return new ActiveXObject("Microsoft.XMLHTTP"); } catch (e) { }
    alert("XMLHttpRequest not supported");
    return null;
}

function LoadGridResults() {
    var xmlHttpReq = createXMLHttpRequest();
    var url = 'WebHandler.ashx?method=searchequipment';
    xmlHttpReq.open("GET", url, false);
    xmlHttpReq.onreadystatechange = function () {
        if (xmlHttpReq.readyState == 4) {
            var serverResponse = xmlHttpReq.responseText;
            debugger;
            var resultObj = JSON.parse(serverResponse);
            resultObj.jqGridDataObject.jsonReader = {
                repeatitems: false,
                id: "LastName",
                root: "rows",
                total: "totalPagesNumber", 
                page: "pageNumber",
                records: function (obj) { return obj.length; }
            };
            $("#grid").jqGrid(resultObj.jqGridDataObject);
            $("#grid").jqGrid("setGroupHeaders", resultObj.groupHeaders);
        }
    };
    xmlHttpReq.send(null);

    //    var mystr =
    //"<?xml version='1.0' encoding='utf-8'?>\
    //<invoices>\
    //    <rows>\
    //        <row>\
    //            <cell>1</cell>\
    //            <cell>2010-03-01</cell>\
    //            <cell>3</cell>\
    //            <cell>4</cell>\
    //            <cell>5</cell>\
    //            <cell>data6</cell>\
    //        </row>\
    //        <row>\
    //            <cell>2</cell>\
    //            <cell>2010-04-01</cell>\
    //            <cell>5</cell>\
    //            <cell>6</cell>\
    //            <cell>7</cell>\
    //            <cell>data8</cell>\
    //        </row>\
    //    </rows>\
    //</invoices>";
}

//function AddOption(text, value, ddl) {
//    var option = document.createElement('<option value="' + value + '">');
//    ddl.options.add(option);
//    option.innerText = text;
//}

function InitComboboxes() {
    //Init Areas
//    ddlAreas = $(".area")[0];
    var xmlHttpReq = createXMLHttpRequest();
    var url = 'WebHandler.ashx?method=getAreas';
    xmlHttpReq.open("GET", url, false);
    xmlHttpReq.onreadystatechange = function () {
        if (xmlHttpReq.readyState == 4) {
            var responseText = xmlHttpReq.responseText;
            var areas = JSON.parse(responseText);

            //            ddlAreas.options.length = 0;
            //            AddOption("בחר רשות מקומית", "-1", ddlAreas);
            //            for (var i in areas) {
            //                AddOption(areas[i].Value, areas[i].Key, ddlAreas);
            //            }


            var $combo = $("#comboboxAreas");
            $combo[0].options.length = 0;
            $combo.append("<option value='-1'>בחר איזור</option>");
            for (var i in areas) {
                $combo.append("<option value='" + areas[i].Key + "'>" + areas[i].Value + "</option>");
            }

            $combo.combobox();

            //Init cities
            InitCities($combo[0]);
        }
    };
    xmlHttpReq.send(null);
}

function InitCities(areaObj) {
    var areaId = $(areaObj).val();
    
    var $combo = $("#comboboxCities");
    $combo[0].options.length = 0;
    $combo.append("<option value='-1'>בחר עיר</option>");

//    ddlCities = $(".city")[0];
//    ddlCities.options.length = 0;
//    AddOption("בחר עיר", "-1", ddlCities);

    if (areaId != '' && areaId != '-1') {
        var xmlHttpReq = createXMLHttpRequest();
        var url = 'WebHandler.ashx?method=getcities&area=' + areaId;
        xmlHttpReq.open("GET", url, false);
        xmlHttpReq.onreadystatechange = function () {
            if (xmlHttpReq.readyState == 4) {
                var responseText = xmlHttpReq.responseText;
                var cities = JSON.parse(responseText);

//                for (var i in cities) {
//                    AddOption(cities[i].Value, cities[i].Key, ddlCities);
                //                }
                for (var i in cities) {
                    $combo.append("<option value='" + cities[i].Key + "'>" + cities[i].Value + "</option>");
                }
            }
        };
        xmlHttpReq.send(null);
    }

    $combo.combobox();
}