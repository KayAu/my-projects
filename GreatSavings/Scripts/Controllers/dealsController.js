
bizModule.controller("dealsController", function ($scope, $http, $compile, $q, $resource, $animate, dataService) {

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

    //$scope.saveCoupon = function (couponId) {

    //    var favCoupons = new Array();

    //    // check if the cookie storing user favourite coupons already exists
    //    if($.cookie('my_fav_gh_coupons') != null)
    //    {
    //        // get the favourite coupons from existing cookie
    //        favCoupons = $.cookie('my_fav_gh_coupons');

    //        if(favCoupons.length > 0)
    //        {
    //            // check if the coupon has been saved before
    //            if ($.inArray(couponId, favCoupons) >= 0)
    //            {
    //                // if so abort this function
    //                return;
    //            }
    //        }
    //    }

    //    // add the newly save coupon to cookie 
    //    favCoupon.push(couponId);
    //    $.cookie('the_cookie', favCoupon, { expires: 7, path: '/'});
    //}
});