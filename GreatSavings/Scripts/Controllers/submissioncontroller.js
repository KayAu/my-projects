//bizModule.controller("subscriptionController", function ($scope, $http, subscribeFactory) {
//    $scope.deals = {};
//    $scope.directorylisting = {};
//    $scope.advertisement = {};
//    $scope.newopening = {};
//    $scope.recommedation = {};

//    $scope.getModel = function (productId, modelName, form) {
        
//        $http({
//            method: 'GET',
//            url: '/ProductSubmission/GetForm',
//            params: {
//                productId: productId
//            }
//        }).success(function (data) {
//            form.html(data);    //jQuery code to load the content
//            return true;
//        }).error(function (data, status, headers, config) {
//            alert(data);
//        });
//    }

//    $scope.init = function (dataKey) {
//        $scope.subscriptions = subscribeFactory.getSubscriptions();
//        //angular.forEach($scope.subscriptions, function (product) {
//        //    var container_id = product.product.replace(' ', '-').toLowerCase();
//        //    var container_ele = $("<div id='" + container_id + "'>" + product.product + "</div>");
//        //    var model_name = product.product.replace(' ', '').toLowerCase();

//        //    $("#subs-form-wrapper").append(container_ele);

//        //    $scope.getModel(product.id, model_name, container_id);
//        //});
//    };



//});

