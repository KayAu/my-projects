
bizModule.controller("dealsController", function ($scope, $http, $compile, $q, $resource, $animate, dataService) {

    $scope.deals = [];
    $scope.testing = "Testing";
    $scope.pageSize = 8;
   // $scope.nextRecordStartAt = 0;

    $scope.loadDeals = function (count, dealsJsonString) {

        $scope.page = 1;
        $scope.nextRecordStartAt = 0;

        if (dealsJsonString == '' || dealsJsonString == null || dealsJsonString == undefined) {
            return dataService.deals.load({ totalReturn: count, skipRecord:0 }).$promise.then(
                //success
                function (dealsObj) {
                    $scope.deals = dealsObj;
                },
                //error
                function (error) {
                    alert(error.data.Message);
                    return false;
                }
           );
        }
        else {
            //$scope.deals = dealsJsonString;
        }

    }

    $scope.loadMoreDeals = function ()
    {
        if ($scope.loading) return;

        $scope.loading = true;

        return dataService.deals.load({ totalReturn: 8, skipRecord: $scope.nextRecordStartAt }).$promise.then(
               //success
               function (dealsObj) {
                   for (var index = 0 ; index < dealsObj.length ; index++)
                   {
                       $scope.deals.push(dealsObj[index]);
                   }

                   $scope.loading = false;
                   $scope.nextRecordStartAt = $scope.page * $scope.pageSize;
                   $scope.page = $scope.page + 1;
                  
               },
               //error
               function (error) {
                  // alert(error.data.Message);
               }
          );
    }
  
});