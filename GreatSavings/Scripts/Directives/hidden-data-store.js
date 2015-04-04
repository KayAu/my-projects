
bizModule.directive('hiddenDataStore', function ($q, $parse) {
    return {
        restrict: 'A',
        link: function ($scope, ele, attrs) {
            var btn = $(ele).find('.btn'),
                dropdown = $(ele).find('.dropdown-menu'),
                hiddenInput = angular.element.find("#" + attrs.hiddenDataStore);


            dropdown.find('a').on('click', function () {
                var selText = $(this).text();
                btn.html(selText + ' <span class="fa fa-angle-down pull-right"></span>');
                if ($(this).parent().find(".selectedValue").length > 0) {
                    var value = $(this).parent().find(".selectedValue").text();
                    $(hiddenInput).val(value);
                }
                else {
                    $(hiddenInput).val(selText);
                }
            });
   
        }
    }
});
