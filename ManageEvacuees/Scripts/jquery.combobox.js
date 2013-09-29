﻿(function ($) {
    $.widget("ui.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
  .addClass("ui-combobox")
  .insertAfter(this.element);
            this._createAutocomplete();
            this._createShowAllButton();
        },
        _createAutocomplete: function () {
            //debugger;
            var selected = this.element.children(":selected"),
            value = selected.val() ? selected.text() : "";
            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("combobox-no" + this.uuid) //ui-state-default ui-combobox-input ui-widget ui-widget-content ui-corner-left
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source")
                })
                .tooltip({
                    tooltipClass: "ui-state-highlight"
                });
            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    if ($(ui.item.option).parent()[0].onchange) {
                        $(ui.item.option).parent()[0].onchange();
                    }
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },
                autocompletechange: "_removeIfInvalid"
            });
        },
        _createShowAllButton: function () {
            var uuid = this.uuid;
            var wasOpen = false;
            $("<a>")
             .attr("tabIndex", -1)
             .attr("title", "")
             .attr("style", "width:50px !important; height: 1.2em !important")
             .tooltip()
             .appendTo(this.wrapper)
            //.button({
            //                 icons: {
            //                     primary: "ui-icon-triangle-1-s"
            //                 },
            //                 text: true
            //             })
             .text('...')
             .removeClass("ui-corner-all")
             .addClass("ui-corner-right ui-combobox-toggle ms-ButtonHeightWidth")
             .mousedown(function () {
                 wasOpen = $(".combobox-no" + uuid).autocomplete("widget").is(":visible");
             })
             .click(function () {
                 $(".combobox-no" + uuid).focus();
                 // Close if already visible            
                 if (wasOpen) {
                     return;
                 }
                 // Pass empty string as value to search for, displaying all results            
                 $(".combobox-no" + uuid).autocomplete("search", "");
             });
        },
        _source: function (request, response) {
            //debugger;
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {
                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
        },
        _removeIfInvalid: function (event, ui) {
            // Selected an item, nothing to do        
            if (ui.item) {
                return;
            }
            // Search for a match (case-insensitive)        
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;
            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });
            // Found a match, nothing to do        
            if (valid) {
                return;
            }
            // Remove invalid value        
            this.input
            //.val("")
            .attr("title", value + " לא קיים ברשימה")
            .tooltip("open");
            //this.element.val("");
            this._delay(function () {
                this.input.tooltip("close").attr("title", "");
            }, 2500);
            //this.input.data("ui-autocomplete").term = "";
        },
        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });
})(jQuery);