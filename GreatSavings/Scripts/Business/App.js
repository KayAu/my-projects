var bizModule = angular.module("businessModule", ['ngAnimate', 'ngRoute', 'ngResource']);

bizModule.controller('DirectoryController', DirectoryController);

var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
        when('/deals', {
            templateUrl: '/ProductSubmission/Deals'
        })
        .when('/directory-listing', {
            templateUrl: '/ProductSubmission/Directory',
            controller: DirectoryController
        });

}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

bizModule.config(configFunction);