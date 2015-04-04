
bizModule.controller("dealsController", function ($scope, $http, $compile, $q, $resource, $animate, dataService) {

    $scope.deals = [];
    $scope.testing = "Testing";

    $scope.loadDeals = function (count, dealsJsonString) {
        if (dealsJsonString == null || dealsJsonString == undefined) {
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
        else {
            $scope.deals = dealsJsonString;
        }
    }

    $scope.extractDeals = function (dealsJsonString)
    {
        return dealsJsonString;
    }
});