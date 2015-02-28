
bizModule.directive('validSubmission', function ($parse) {
    return {
        compile: function compile(tElement, tAttrs, transclude) {
            return {
                post: function postLink(scope, element, iAttrs, controller) {
                    var form = element.controller('form');
                    form.$submitted = false;
                    var fn = $parse(iAttrs.validSubmission);
                    element.on('submit', function (event) {
                        scope.$apply(function () {
                            element.addClass('ng-submitted');
                            form.$submitted = true;
                            if (form.$valid) {
                                fn(scope, { $event: event });
                            }
                        });
                    });
                }
            }
        }
    };
});

bizModule.directive('validationError', function ($q) {

    return {
        restrict: 'E',
        scope: {
            hasError: '=hasError',
            showIcon: '=showIcon',
            errorMessage: '@errorMessage'
        },
        template:
                '<i class="form-control-feedback glyphicon glyphicon-remove" ng-show="showIcon && hasError"></i>' +
                '<span class="control-error-msg" ng-show="hasError">{{errorMessage}}</span>'

    }; //return

});

bizModule.directive('validationStyle', function () {
    return {
        scope: {
            hasError: '=hasError',
            showIcon: '=showIcon',
            errorMessage: '@errorMessage'
        },
        require: '?ngModel',
        link: function (scope, element, attr, ngModel) {
            if (!ngModel) return;

            var currentForm = element.controller('form');
            var ctrlName = attr.name;

            scope.$watch(
               function () { return currentForm.$submitted && ngModel.$invalid }
                , function (newValue, oldValue)
                {
                    if (newValue != oldValue) {
                        if (currentForm.$submitted && ngModel.$invalid) {  // formSubmitted && ngModel.$invalid
                           
                            //element.parent().addClass("has-error");
                            element.closest('.form-group').addClass("has-error");
                            
                        }
                        else {
                            element.closest('.form-group').removeClass("has-error");
                           // element.parent().removeClass("has-error");
                        };
                    }
                }
            )}
        };
});

bizModule.directive('confirmPassword', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ctrl) {

            var validate = function (confirmPwd) {
                var actualPwd = attr.confirmPassword;

                if (!confirmPwd || !actualPwd) {
                    // It's valid because we have nothing to compare against
                    ctrl.$setValidity('confirmPassword', true);
                }
                else {
                    // It's valid if model is lower than the model we're comparing against
                    var isCorrect = (actualPwd.substring(0, confirmPwd.length) == confirmPwd);
                    ctrl.$setValidity('confirmPassword', isCorrect);
                }
                return confirmPwd;
            };

            ctrl.$parsers.unshift(validate);
            ctrl.$formatters.push(validate);

            attr.$observe('confirmPassword', function (comparisonModel) {
                return validate(ctrl.$viewValue);
            });
        }
    };
});


bizModule.directive('uniqueEmail', function (dataService,$q,$http, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attr, ctrl) {
            ctrl.$asyncValidators.uniqueEmail = function (modelValue, viewValue) {
                var def = $q.defer();

                $timeout(function () {

                    $http.get('/api/Account/CheckEmailAlreadyExist?email=' + modelValue).success(function (hasExist) {
                        if (!hasExist) {
                            def.resolve();
                        }
                        else {
                            def.reject();
                        }
                    }).error(function (data) {
                        var error = "An Error has occured while verifying the email! " + data;
                        def.reject(error);
                    });
                }, 2000);

                return def.promise;

            }
        }
    };
});
