
bizModule.controller("dealsController", function ($scope, $http, $compile, $q, $resource, dataService) {

    $scope.deals = [];
    $scope.testing = "Testing";

    $scope.loadDeals = function (count) {
        return dataService.deals.load({ totalReturn: count }).$promise.then(
            //success
            function (dealsObj) {
                $scope.deals = dealsObj;
            },
            //error
            function (error) {
                alert(error.data.Message);
            }
       );
    }

});