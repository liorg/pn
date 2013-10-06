$(document).ready(function () {
    //Load results grid - Testing
    //LoadGridResults();

    //Set datepicker to dates filds 
    $(".date").datepicker();
    
    //Init comboboxes Data
    InitComboboxes();
});
 
function LoadEquipmentGridResults() {
    var data = new Object();
    data.method = 'searchequipment';
    data.mahoz = $(".eqMahoz").val();
    data.area = $(".eqArea").val();
    data.equip = $(".equip").val();
    $.ajax({
        url: 'WebHandler.ashx',
        type: "POST",
        data: JSON.stringify(data),
        success: function (data) {
            var gridData = JSON.parse(data);
            gridData.jqGridDataObject.jsonReader = {
                repeatitems: false,
                root: "datastr",
                total: "totalPagesNumber",
                page: "pageNumber",
                records: function (obj) { return obj.length; }
            };
            $("#gridEquipment").jqGrid(gridData.jqGridDataObject);
        },
        error: function (a, b, c) { debugger;}
    });
}

var isGroupHeaderSet = false;
function LoadEvacueesGridResults() {
    if (ValidateID()) {
        var data = new Object();
        data.method = 'searchEvacuees';
        data.AreaId = $("#comboboxAreas").val();
        data.City = $(".city").val();
        data.street = $(".street").val();
        data.EqMahozId = $("#comboboxMehozot").val();
        data.equipId = $("#comboboxEquipment").val();
        data.DateIncomeBegin = $("#txtFromDate").val();
        data.DateIncomeEnd = $("#txtToDate").val();
        data.IdNumber = $("#txtIdNumber").val();
        data.firstName = $("#txtFirstName").val();
        data.lastName = $("#txtLastName").val();
        data.fatherName = $("#txtFatherName").val();
        data.gender = $("#txtGender").val();

        $.ajax({
            url: 'WebHandler.ashx',
            type: "POST",
            data: JSON.stringify(data),
            success: function (data) {
                //debugger;
                var gridData = JSON.parse(data);
                if (isGroupHeaderSet)
                    $("#grid").jqGrid("destroyGroupHeader");
                gridData.jqGridDataObject.jsonReader = {
                    repeatitems: false,
                    root: "datastr",
                    total: "totalPagesNumber",
                    page: "pageNumber",
                    records: function (obj) { return obj.length; }
                };
                $("#grid").jqGrid(gridData.jqGridDataObject);
                $("#grid").jqGrid("setGroupHeaders", {
                    useColSpanStyle: false, 
                    groupHeaders: [
                        { startColumnName: "MfLastName", numberOfColumns: 10, titleText: "פרטי מפונה" },
                        { startColumnName: "Mitkan.Rashut.RashutName", numberOfColumns: 4, titleText: "פרטי מרכז קליטה" }
                    ]
                });
                $("#grid").jqGrid("setGroupHeaders", {
                    useColSpanStyle: false,
                    groupHeaders: [
                        { startColumnName: "MfFather", numberOfColumns: 4, titleText: "כתובת מגורים" }
                    ]
                });
                isGroupHeaderSet = true;
            }
        });
    }
}

function ClearAll() {
    $(".ui-autocomplete-input").val('');
    InitComboboxes();
    $(".city").val('');
    $(".street").val('');
    $("#txtFromDate").val('');
    $("#txtToDate").val('');
    $("#txtIdNumber").val('');
    $("#txtFirstName").val('');
    $("#txtLastName").val('');
    $("#txtFatherName").val('');
    $("#txtGender").val('');
}

//Init Comboboxes & AutoCompletes

function InitComboboxes() {
    //Init Mahos
    InitMahos();

    //Init Areas
    InitAreas();

    //Init equipment
    InitEquipments($(".area")[0]);

    //Init cities
    if ($(".area").length > 0) {
        InitCities($(".area")[0]);
    }

    //Init streets
    if ($(".city").length > 0) {
        InitStreets($(".city")[0]);
    }
}

function InitMahos() {
    var data = new Object();
    data.method = 'getMahos';
    $.ajax({
        url: "WebHandler.ashx",
        type: "POST",
        data: JSON.stringify(data),
        async: false,
        success: function (data) {
            var dataObj = JSON.parse(data);

            var $combo = $("#comboboxMehozot");
            $combo[0].options.length = 0;
            $combo.append("<option value='-1'></option>");
            for (var i in dataObj) {
                $combo.append("<option value='" + dataObj[i].MahozNum + "'>" + dataObj[i].MahozName + "</option>");
            }
            $combo.combobox();
        }
    });
}

function InitAreas(mahozObj) {
    var data = new Object();
    data.method = 'getAreas';
    data.mahoz = $("#comboboxMehozot").val();
    $.ajax({
        url: "WebHandler.ashx",
        type: "POST",
        data: JSON.stringify(data),
        async: false,
        success: function (data) {
            var dataObj = JSON.parse(data);

            var $combo = $(".area");
            for (var i = 0; i < $combo.length; i++) {
                $combo[i].options.length = 0;
            }
            $combo.append("<option value='-1'></option>");
            for (var i in dataObj) {
                $combo.append("<option value='" + dataObj[i].RashutID + "'>" + dataObj[i].RashutName + "</option>");
            }
            $combo.combobox();
        }
    });
    //$(".area").autocomplete({
    //    source: function (request, response) {
    //        var data = new Object();
    //        data.letters = request.term;
    //        data.method = 'getAreas';
    //        data.mahoz = $("#comboboxMehozot").val();
    //        $.ajax({
    //            url: "WebHandler.ashx",
    //            type: "POST",
    //            data: JSON.stringify(data),
    //            success: function (data) {
    //                var dataObj = JSON.parse(data);
    //                response($.map(dataObj, function (item) {
    //                    return {
    //                        label: item.RashutName,
    //                        value: item.RashutNum
    //                    }
    //                }));
    //            }
    //        });
    //    },
    //    minLength: 2
    //});
}

function InitEquipments(areaObj) {
    var data = new Object();
    data.method = 'getEquipment';
    data.area = $("#comboboxAreas").val();

    var $combo = $(".equip");
    for (var i = 0; i < $combo.length; i++) {
        $combo[i].options.length = 0;
    }
    $combo.append("<option value='-1'></option>");

    if (data.area != null && data.area != '') {
        $.ajax({
            url: "WebHandler.ashx",
            type: "POST",
            async: false,
            data: JSON.stringify(data),
            success: function (data) {
                var dataObj = JSON.parse(data);

                for (var i in dataObj) {
                    $combo.append("<option value='" + dataObj[i].MitkanNum + "'>" + dataObj[i].MitkanName + "</option>");
                }
            }
        });
    }

    $combo.combobox();
}

function InitCities(areaObj) {
    $(".city").autocomplete({
        source: function (request, response) {
            var data = new Object();
            data.letters = request.term;
            data.area = $(areaObj).val();
            data.method = 'getcities';
            $.ajax({
                url: "WebHandler.ashx",
                type: "POST",
                data: JSON.stringify(data),
                success: function (data) {
                    var dataObj = JSON.parse(data);
                    response($.map(dataObj, function (item) {
                        return {
                            label: item.YeshuvName,
                            value: item.YeshuvName
                        }
                    }));
                }
            });
        },
        minLength: 2
    });
}

function InitStreets(cityObj) {
    $(".street").autocomplete({
        source: function (request, response) {
            var data = new Object();
            data.letters = request.term;
            data.city = $(cityObj).val();
            data.method = 'getstreets';
            $.ajax({
                url: "WebHandler.ashx",
                type: "POST",
                data: JSON.stringify(data),
                success: function (data) {
                    var dataObj = JSON.parse(data);
                    response($.map(dataObj, function (item) {
                        return {
                            label: item.StName,
                            value: item.StName
                        }
                    }));
                }
            });
        },
        minLength: 2
    });
}

//Validations
function ValidateID() {
    var str = $("#txtIdNumber").val();

    //There is no id number - valid
    if (str == null || str == '')
        return true;

    // Just in case -> convert to string
    var IDnum = String(str);

    // Validate correct input
    if ((IDnum.length > 9) || (IDnum.length < 5) || (isNaN(IDnum))) {
        $("#lblValidateIdNumber").text("מספר ת.ז. צריך להכיל ספרות בלבד ובאורך של 5 עם 9 תוים.");
        return false;
    }

    // The number is too short - add leading 0000
    if (IDnum.length < 9) {
        while (IDnum.length < 9) {
            IDnum = '0' + IDnum;
        }
    }

    // CHECK THE ID NUMBER
    var mone = 0, incNum;
    for (var i = 0; i < 9; i++) {
        incNum = Number(IDnum.charAt(i));
        incNum *= (i % 2) + 1;
        if (incNum > 9)
            incNum -= 9;
        mone += incNum;
    }
    if (mone % 10 == 0)
        return true;
    else {
        $("#lblValidateIdNumber").text("מספר ת.ז. לא תקין.");
        return false;
    }
}