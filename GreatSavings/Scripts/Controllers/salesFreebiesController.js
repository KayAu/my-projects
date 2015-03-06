bizModule.controller("salesFreebiesController", function ($scope, $http, $compile, $q, $resource, dataService) {
    $scope.model = {};
    $scope.completed = false;

    $scope.loadModel = function (productId) {

        $scope.productId = productId;
        loadModelById(productId);

    };

    $scope.update = function () {

        dataService.directory.saveAll().$promise.then(
                //success
                function (newPromotionObj) {
              
                    return newTransactionObj.PromotionId;
                },
                //error
                function (data) {
                    alert(error.data.Message);
                }
              );


    };


    function loadModelById(productId) {

        var promises;

        switch (productId) {
            case 6: // Promotion
                //return '/api/Register/GetEmptyModel'; //'/Account/LoadRegisterModel'
                promise = dataService.promotion.get({ id: 0 }).$promise;
                break;
            case 7: // Coupons
                return '/ProductSubmission/LoadAdvertisementModel';
            case 8: // Freebies
                promise = dataService.freebies.get({ id: 0 }).$promise;
                break;
        }

        promise.then(function (modelObj) {
            // success
            $scope.model = modelObj;
            $scope.originForm = angular.copy($scope.model);
        },
        function (error) {
            //error
            alert(error);
        });


    }

});