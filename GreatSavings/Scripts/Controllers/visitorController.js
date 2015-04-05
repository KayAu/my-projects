
bizModule.controller("visitorController", function ($scope, $http, $compile, $q, $animate, dataService) {


    $scope.totalCouponSaved = 0;
    $scope.savedCoupons = [];

    $scope.init= function()
    {
        // read saved coupons from cookies
        if ($.cookie('my_fav_gh_coupons') != null) {

            // get the favourite coupons from existing cookie
            $scope.savedCoupons = angular.fromJson($.cookie("my_fav_gh_coupons"));

            // update the total coupons saved
            $scope.totalCouponSaved = $scope.savedCoupons.length;
        }
    }

    $scope.saveCoupon = function (couponId, couponTitle, couponCompany, couponExpiredOn) {

        var favCoupons = new Array();

        try{
            // add the newly save coupon to cookie 
            $scope.savedCoupons.push({ id: couponId, merchant: couponCompany, title: couponTitle, expDate: couponExpiredOn }); //, image: couponImage
            $.cookie('my_fav_gh_coupons', angular.toJson($scope.savedCoupons), { expires: 7, path: '/' });
            
            //$scope.savedCoupons = favCoupons;
            // update the total coupons saved
            $scope.totalCouponSaved = $scope.savedCoupons.length;
        }
        catch(ex)
        {
            alert(ex.message);
        }
    }

    $scope.removeSavedCoupon = function ()
    {
        var remItemId = this.item.id;

        // remove from saved coupon
        $scope.savedCoupons = $scope.savedCoupons.filter(function (item) {
            return item.id !== remItemId;
        });

        // update cookies with the change
        $.cookie('my_fav_gh_coupons', angular.toJson($scope.savedCoupons), { expires: 7, path: '/' });

        // update the total coupons saved
        $scope.totalCouponSaved = $scope.savedCoupons.length;
    }

    $scope.$watch('totalCouponSaved', function (newValue, oldValue) {

        if (newValue === oldValue) return;
        var element = $(".cart-items-number");

        $animate.addClass(element, 'animate-cart-items-number').then(function () {
            element.removeClass('animate-cart-items-number');
        });
    });

    $scope.extractDeals = function (dealsJsonString) {
        alert(dealsJsonString);
    }
});