//bizModule.directive('merchantSelector', function ($q) {

//    return {
//        restrict: 'E',
//        require: '?ngModel',
//        scope: {
//            datasource:'=datasource',
//            merchantSelected: '=merchantSelected'
//        },
//        template:
//            //  '<div class="form-group" ng-show="merchantList.length > 0">' +
//            //    '<label class="control-label col-xs-2">Merchant</label>' +
//            //    '<div class="col-xs-10">' +
//            //        '<select ng-model="merchantSelected" data-ng-options="list.Merchant.CompanyName for list in merchantList" class="form-control" >' +
//            //            '<option value="" selected>Please select a merchant...</option>' +
//            //        '</select>' +
//            //    '</div>' +
//            //'</div>'      + 
//            '<div class="form-group" ng-if="datasource.length > 0">' +
//                '<label class="control-label col-xs-2">Merchant</label>' +
//                '<div class="col-xs-10">' +
//                    '<select ng-model="merchantSelected" class="form-control" ng-init="merchantSelected=datasource[0].Merchant.DirId" >' +
//                        '<option value="" ng-if="datasource.length > 1" ng-selected="datasource.length > 1">Please select a merchant...</option>' +
//                        '<option ng-repeat="directory in datasource"  value="{{directory.Merchant.DirId}}" ng-selected="datasource.length == 1">{{directory.Merchant.CompanyName}}</option>' +
//                    '</select>' +
//                '</div>' +
//            '</div>',
//        link: function (scope, element, attrs, ngModel) {
//            if (!ngModel) return;

//            scope.$watch("datasource", function (newValue) {
//                //scope.merchantSelected = newValue;
//                alert(newValue);
//            });
//        },
//    }; 

//});


bizModule.directive('merchantSelector', function ($q, $parse) {

    return {
        restrict: 'E',
        require: '?ngModel',

        scope: {
            datasource: '=datasource',
            invalid: '=invalid',
        },
        template: 
            '<div class="form-group" ng-if="datasource.length > 0" >' +
                '<label class="control-label col-xs-2">Merchant</label>' +
                '<div class="col-xs-10">' +
                    '<select class="form-control" name="merchant" ng-model="merchantSelected" ng-change="updateMerchant(merchantSelected)" required validation-style> ' +
                        '<option value="" ng-if="datasource.length > 1" ng-selected="datasource.length > 1">Please select a merchant...</option>' +
                        '<option ng-repeat="directory in datasource" value="{{directory.DirId}}" ng-selected="datasource.length == 1">{{directory.CompanyName}}</option>' +
                    '</select>' +
                    '<validation-error has-error="invalid" show-icon="false" error-message="The merchant is required"></validation-error>' +
                '</div>' +
            '</div>',
        link: function (scope, element, attrs, ngModel) {
            if (!ngModel) return;

            
            scope.$watch("datasource", function (directory, oldDirectory) {

                // update the model value so that the empty option will not show in the dropdown list
                if (directory.length == 1) {
                    scope.merchantSelected = directory[0].DirId;
                    ngModel.$setViewValue(directory[0].DirId);
                } 
                else if (directory.length > 1) {
                   scope.merchantSelected = "";
                   ngModel.$setViewValue("");
                }

                ngModel.$render();
                scope.$apply();
            });

            scope.$parent.$watch(attrs.ngModel, function (value) {
                if (scope.datasource.length == 1) {
                    scope.$parent.model.DirId = scope.datasource[0].DirId;
                }

            });

            scope.updateMerchant = function (selectedItem) {
                ngModel.$setViewValue(selectedItem);
                ngModel.$render();

            }

            //attrs.$observe('datasource', function (directory) {
            //    if (directory) {

            //        if (scope.datasource.length == 1) {
                     
            //            scope.merchantSelected = scope.datasource[0].DirId;
            //            ngModel.$setViewValue(scope.datasource[0].DirId);
                     
            //        }
            //        else if (scope.datasource.length > 1) {
            //            ngModel.$setViewValue("");
            //        }
            //        ngModel.$render();
                   
            //    }
            //});
           
        },
    };

});
