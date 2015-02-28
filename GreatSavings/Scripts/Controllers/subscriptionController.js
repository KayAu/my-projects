
bizModule.controller("subscriptionController", function ($scope, $http, $q, $timeout, dataService) {
    $scope.uploadedImage = {};
    $scope.currentIndex = 0;
    $scope.totalCompleted = 0;
    $scope.model = {};
    $scope.completed = false;

    $scope.loadModel = function (productId) {

        $scope.productId = productId;
        loadModelById(productId);

    };

    $scope.update = function (event) {

        $scope.completed = false;

        event.preventDefault();
        showLoading(event);
      
        if ($scope.listings[$scope.currentIndex] == null)
            $scope.totalCompleted++;

        $scope.listings[$scope.currentIndex] = $scope.model;

        showSuccess(event);

    };

    $scope.updateRecommendation = function (event) {

        showLoading(event);

        if ($scope.listings[$scope.currentIndex] == null)
            $scope.totalCompleted++;

        //$scope.model.Image = $scope.model.uploadedImage.imageObject;
        $scope.model.Image1 = $scope.model.uploadedImages.length > 0 ? $scope.model.uploadedImages[0].imageObject.replace(/data:image\/jpeg;base64,/g, '') : null;
        $scope.model.Image2 = $scope.model.uploadedImages.length > 1 ? $scope.model.uploadedImages[1].imageObject.replace(/data:image\/jpeg;base64,/g, '') : null;
        $scope.model.Image3 = $scope.model.uploadedImages.length > 2 ? $scope.model.uploadedImages[2].imageObject.replace(/data:image\/jpeg;base64,/g, '') : null;
        $scope.model.Image4 = $scope.model.uploadedImages.length > 3 ? $scope.model.uploadedImages[3].imageObject.replace(/data:image\/jpeg;base64,/g, '') : null;
        $scope.model.Image5 = $scope.model.uploadedImages.length > 4 ? $scope.model.uploadedImages[4].imageObject.replace(/data:image\/jpeg;base64,/g, '') : null;
        $scope.model.Image6 = $scope.model.uploadedImages.length > 5 ? $scope.model.uploadedImages[5].imageObject.replace(/data:image\/jpeg;base64,/g, '') : null;

        $scope.listings[$scope.currentIndex] = $scope.model;

        showSuccess(event);
    };

    $scope.updateDirectory = function (event) {

        showLoading(event);

        if ($scope.listings[$scope.currentIndex] == null) {

            dataService.getNewDirectoryId($scope.model.SelectedState.StateCode).then(function (newId) {
                // success
                $scope.model.Merchant.DirId = newId;
                $scope.model.Merchant.State = $scope.model.SelectedState.StateName;
                $scope.listings[$scope.currentIndex] = $scope.model;
                $scope.totalCompleted++;
            });
        }
        else {
            $scope.listings[$scope.currentIndex] = $scope.model;
        }

        showSuccess(event);
    }

    $scope.saveAll = function ($event) {

       // $scope.parentModel = $scope.listings;
        updateParentObject();

        var totalCompletedRecords = 0;
        var productIndex = 0;

        angular.forEach($scope.$parent.cartItems, function (product, index) {           
            if (product.id == $scope.productId) {
                product.dataCompleted = 1;
                productIndex = index;
            }

            if (product.dataCompleted == 1) {
                totalCompletedRecords++;
            }
        });

        if (totalCompletedRecords == $scope.$parent.cartItems.length) {
            $scope.$parent.loadPaymentForm();
        }
        else {
             var nextProduct = $scope.$parent.cartItems[productIndex+1].product.replace(' ', '-').toLowerCase();
             $('[href=#' + nextProduct + ']').tab('show');
        }
        //var button = $event.target;
        //showNextForm(button);
    }

    $scope.getSelectedForm = function (currentForm, index) {
        if ($scope.listings[index] == null) {
            $scope.model = angular.copy($scope.originForm); // Assign clear state to modified form 
            currentForm.$setPristine(); // this line will update status of your form, but will not clean your data, where `registrForm` - name of form.
        }
        else {
            $scope.model = $scope.listings[index];
        }
        $scope.currentIndex = index;
    };

    $scope.testing = function () {
        alert($scope.model.DirId);
    }

   
    function getOrderQty() {
        var cartItems = $scope.$parent.cartItems;
        for(var idx = 0; idx <  $scope.$parent.cartItems.length; idx++)
        {
            var product = $scope.$parent.cartItems[idx];
            if (product.id == $scope.productId) {
                $scope.orderQty = Number(product.qty);
                $scope.listings = new Array($scope.orderQty);
                break;
            }
        }
    }

    function loadModelById(productId) {
        //switch (productId) {
        //    case 0:
        //        return '/api/Register/GetEmptyModel'; //'/Account/LoadRegisterModel'
        //    case 1:
        //        return '/ProductSubmission/LoadAdvertisementModel';
        //    case 2:
        //        return '/ProductSubmission/LoadDealModel';
        //    case 3:
        //        return '/ProductSubmission/LoadDirectoryModel';
        //    case 4:
        //        return '/ProductSubmission/LoadNewOpeningModel';
        //    case 5:
        //        return '/ProductSubmission/LoadRecommendationModel';
        //}

        var promises;

        switch (productId) {
            case 0:
                //return '/api/Register/GetEmptyModel'; //'/Account/LoadRegisterModel'
                promise = dataService.account.getRegisterModel({}).$promise;
                break;
            case 1:
                return '/ProductSubmission/LoadAdvertisementModel';
            case 2:
                // return '/ProductSubmission/LoadDealModel';
                promise = dataService.newOpening.get({ id: 0 }).$promise;
                break;
            case 3:
                //return '/ProductSubmission/LoadDirectoryModel';
                promise = dataService.directory.get({ id: 0 }).$promise;
                break;
            case 4:
                promise = dataService.deals.get({ id: 0 }).$promise;
                break;
            case 5:
                promise = dataService.recommendation.get({ id: 0 }).$promise;
                break;
        }

        promise.then(function (modelObj) {
            // success
            $scope.model = modelObj;
            $scope.originForm = angular.copy($scope.model);

            getOrderQty();
        },
        function (error) {
            //error
            alert(error);
        });

     
    }

    function updateParentObject()
    {
        switch ($scope.productId) {
            case 0:
                if ($scope.listings.length > 0) {
                    //$scope.$parent.accountinfo = new Object();
                    $scope.$parent.accountinfo = $scope.listings[0];
                }
                break;
            case 1:
                $scope.$parent.advertisement = $scope.listings;
                break;
            case 2:
                $scope.$parent.deals = $scope.listings;
                break;
            case 3:
                $scope.$parent.directorylisting = $scope.listings;
                //var arrMerchant = [];
                //angular.forEach($scope.listings, function (directory, index) {
                //    arrMerchant.push(directory.Merchant);
                //});
                //$scope.$parent.merchants = arrMerchant;
                break;
            case 4:
                $scope.$parent.newopening = $scope.listings;
                break;
            case 5:
                $scope.$parent.recommedation = $scope.listings;
                break;
        }
    }

    function showLoading(buttonId) {

        var btnUpdate = $(event.target).find("button[type=submit]");

        // remove success class
        btnUpdate.removeClass('act-success');

        // show loading class
        btnUpdate.addClass('act-loading');
    }

    function showSuccess(buttonId) {
        var btnUpdate = $(event.target).find("button[type=submit]");
        var btnContinue = $(event.target).find(".continue");

        $timeout(function () {
            btnUpdate.addClass('act-success');
            btnUpdate.removeClass('act-loading');

            $timeout(function () {
                if ($scope.totalCompleted == $scope.orderQty)
                    $scope.completed = true;
            },2500);

        }, 800);
        //setTimeout(function () {
        //    btnUpdate.addClass('act-success');
        //    btnUpdate.removeClass('act-loading');

        //    if ($scope.totalCompleted == $scope.orderQty)
        //        $scope.completed = true;

        //}, 1500)
    }
});


