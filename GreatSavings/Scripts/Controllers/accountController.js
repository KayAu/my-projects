bizModule.controller("accountController", function ($scope, $q, dataService) {

    $scope.loginFailed = false;

    $scope.model = {
        'UserName':'',
        'Password': ''
    }

    $scope.loadLoginModel = function () {
        return $scope.model;
    };

    $scope.login = function (event) {
        loginMerchant($scope.model).then(loadMerchantDirectories);    
    }

    var loginMerchant = function (accountinfo) {
        return dataService.merchangLogin($scope.model).then(
        //success
        function (merchantId) {
            // verfiy the merchant id returned
            if (merchantId != 0) {
                $scope.$parent.merchantId = merchantId;
                $scope.loginFailed = false;
                return merchantId;
            }
            else {
                $scope.loginFailed = true;
            }
        },
        //error
        function (error) {
            alert(error.data.Message);
        });
    },
    loadMerchantDirectories = function (merchantId) {

        if ($scope.loginFailed) return;
        
        // get an empty transaction model
        return dataService.directory.getByMerchant({ id: merchantId }).$promise.then(
            //success
            function (directories) {
                $scope.$parent.merchants = directories;
                $scope.$parent.loadOrderForm("orderForms", false);
                return directories;
            },
            //error
            function (error) {
                alert(error.data.Message);
            });
    };

});