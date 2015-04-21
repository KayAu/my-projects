var bizModule = angular.module("businessModule", ['ngAnimate', 'ngRoute', 'ngResource', 'ngMessages', 'infinite-scroll']);


//bizModule.factory('companyProfileSvc', function ($http, $q) {

//        var fac = {};
//        fac.getModel = function () {  
//             $http({
//                method: 'GET',
//                url: '/ProductSubmission/LoadDirectoryModel',
//            }).success(function (data) {
//                alert('Successfully Get Model');
//                deferred.resolve(data);
//            }).error(function () {
//                deferred.resolve(null);
//            });

//            return deferred.promise; 
//        }
//        return fac;

//});

//bizModule.controller('DirectoryController', DirectoryController);

//var configFunction = function ($routeProvider, $httpProvider) {
//    $routeProvider.
//        when('/deals', {
//            templateUrl: '/ProductSubmission/Deals'
//        })
//        .when('/directory-listing', {
//            templateUrl: '/ProductSubmission/Directory'
//            ,controller: "DirectoryController"
//            //,resolve: {
//            //    directoryModel: function (companyProfileSvc) {
//            //        return companyProfileSvc.getModel();
//            //    }

//            //}
//        });

//}
//configFunction.$inject = ['$routeProvider', '$httpProvider'];

//bizModule.config(configFunction);


