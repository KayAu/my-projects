//eventModule.controller("cartController", function ($scope, productFactory) {
//    $scope.products = productFactory.products;

//    $scope.itemsInCart = [];
//    $scope.addToCart = function () {

//        alert(this.name);
//    }
//});



bizModule.controller("productController", function ($scope, $http, $compile, $q, $resource, dataService) {

   // $scope.products = productFactory.getProducts();
    $scope.itemsInCart = [];
    $scope.totalPayment = 0;
    $scope.cartIsEmpty = false;
    $scope.deals = [];
    $scope.directorylisting = [];
    $scope.advertisement = [];
    $scope.newopening = [];
    $scope.recommedation = [];
    $scope.merchantId = 0;
    $scope.merchants = [];
    //$scope.transactionCode = '';
    //$scope.acknowledged = 0;

    //$scope.transaction = dataService.getTransaction(0);

    $scope.getProducts = function (prodModel) {
        $scope.products = prodModel;
    }

    $scope.addToCart = function (itmIdx) {
        var product = this.item;
        var priceElem = $(".price-block").eq(itmIdx);

        $scope.itemsInCart.push({
            'id': product.id,
            'product': product.name,
            'price': product.price,
            'qty': 1,
            'maxTerm': product.maxTerm,
            'term': product.term,
            'termSelected': 1,
            'currency': product.currency,
            'dataCompleted': 0,
            'subTotal': product.price,
            'position': product.position
        });
        // $scope.totalPrice += product.price;

        priceElem.addClass('price-block-selected');
        priceElem.removeClass('buy');

        this.item.selected = true;

    }

    $scope.removeItemFromCart = function (itmIdx) {
        var removeProd = this.item;
        var priceElem = $(".price-block").eq(itmIdx);

        priceElem.removeClass('price-block-selected');
        priceElem.addClass('buy');
        
        $scope.itemsInCart = $scope.itemsInCart.filter(function (item) {
            return item.product !== removeProd.name;
        });

        this.item.selected = false;
    }

    $scope.removeFromCart = function () {
        var removeProd = this.item;
        //var priceElem = $(".price-block").eq(itmIdx);

        //priceElem.removeClass('price-block-selected');
        //priceElem.addClass('buy');

        $scope.cartItems = $scope.cartItems.filter(function (item) {
            return item.product !== removeProd.product;
        });

        updateTotal();
        //this.item.selected = false;
    }

    $scope.subscribe = function () {
        var selectedProducts = angular.toJson($scope.itemsInCart);
        $("#selectedProducts").val(selectedProducts);
    }

    $scope.getCartItems = function (dataKey) {
        $scope.cartItems = dataKey; //$scope.products; //cartFactory.getCartItems();

        updateTotal();
    }

    $scope.getMaxTerm = function (num) {
        return new Array(num);
    }

    $scope.updateSubTotal = function () {
        var item = this.item;
        item.subTotal = item.qty * item.price;

        updateTotal();
    }

    function updateTotal() {
        var total = 0;
        angular.forEach($scope.cartItems, function (product) {
            total += product.qty * product.price;
        });

        $scope.totalPayment = "RM " + total;
    }

    $scope.checkout = function (nextFrameId) {
        var next_fs = $("#" + nextFrameId);
        showNextForm(next_fs);

    }

    $scope.loadOrderForm = function (mainformId, showRegisterAccount) {

        
        if (showRegisterAccount) {
            var registerItem = {
                'id': 0,
                'product': 'Account Info',
                'price': 0,
                'qty': 1,
                'maxTerm': '',
                'term': '',
                'termSelected': 1,
                'currency': '',
                'dataCompleted': 0,
                'subTotal': 0,
                'position': 0
            }

            // add account registration form into the cart items
            $scope.cartItems.splice(0, 0, registerItem);

        }

        // sort the cart items by position
        $scope.cartItems.sort(function (itm1, itm2) {
            return itm1.position - itm2.position;
        })

        // load the form for each cart items
        angular.forEach($scope.cartItems, function (product, index) {
            var container_id = product.product.replace(' ', '-').toLowerCase();
            var container_ele = $("<div id='" + container_id + "' class='orderform-section tab-pane fade " + (index == 0 ? 'active in' : '') + "'>" + product.product + "</div>");
            var mainForm = $("#" + mainformId).find(".tab-content");

            mainForm.append(container_ele);

            try
            {
                $http({
                    method: 'GET',
                    url: '/ProductSubmission/GetForm',
                    params: {
                        productId: product.id
                    }
                }).success(function (data, status, headers, config) {
                    container_ele.html(data);    //jQuery code to load the content
                    $compile(container_ele.contents())($scope);
                }).error(function (data, status, headers, config) {
                    alert(data);
                });
            }
            catch (err) {
                alert(err);
            }
        });

        updateProgressTracker();
        showNextForm($("#" + mainformId));
    }

    $scope.loadPaymentForm = function () {
        var next_fs = $("#subs-form-wrapper #paymentForm");
        showNextForm(next_fs);
        updateProgressTracker();
    }

    $scope.paymentCompleted = function () {
        var newMerchandId;

        // save all the subdcriptios details into database
        if ($scope.merchantId == 0) {
                       
           registerMember($scope.accountinfo).then(loadTransaction).then(createTransaction).then(addAllSubscriptionInfo).catch(reportProblems);
        }
        else {
            loadTransaction($scope.merchantId).then(createTransaction).then(addAllSubscriptionInfo).catch(reportProblems);
        }
    }

    $scope.$watch("directorylisting", function (newValue, oldValue)
    {
        if (newValue != oldValue) {
            var arrMerchant = [];
            angular.forEach(newValue, function (directory, index) {
                arrMerchant.push(directory.Merchant);
            });
            $scope.merchants = $scope.merchants.concat(arrMerchant);
        }
    });

    var registerMember = function (accountinfo) {
       
        return dataService.register($scope.accountinfo);
        },
        loadTransaction = function(merchantId)
        {
            // get an empty transaction model
            return dataService.transaction.get({ id: 0 }).$promise.then(
                //success
                function (transactionObj)
                {
                    transactionObj.MerchantId = merchantId;
                    return transactionObj;
                },
                //error
                function (error) {
                    alert(error.data.Message);
                }
              );
        },
        createTransaction = function (transactionObj) {
            transactionObj.TotalPymt = parseFloat($scope.totalPayment.replace("RM ", ""));
            transactionObj.TransCode = $scope.transactionCode;

            return dataService.transaction.save({}, transactionObj).$promise.then(
                //success
                function (newTransactionObj) {
                    $scope.transactionId = newTransactionObj.TransId;
                    return newTransactionObj.TransId;
                },
                //error
                function (data) {
                    alert(error.data.Message);
                }
              );
        },
        addAllSubscriptionInfo = function(newTransId)
        {
           // $q.all([resource1.query().$promise, resource2.query().$promise, resource3.query().$promise])
           //.then( function(result) {
           //        $scope.data1 = result[1];
           //        $scope.data2 = result1[2];
           //        $scope.data3 = result[3];

           //        console.log($scope.data1);

           //        doSomething($scope.data1,$scope.data2); 
           //    })
           // }
            var func = [];
            if ($scope.directorylisting.length > 0) func.push(dataService.directory.saveAll({ transactionId: newTransId }, $scope.directorylisting).$promise);
            if ($scope.deals.length > 0) func.push(dataService.deals.saveAll({ transactionId: newTransId }, $scope.deals).$promise);
            if ($scope.newopening.length > 0) func.push(dataService.newOpening.saveAll({ transactionId: newTransId }, $scope.newopening).$promise);
            if ($scope.recommedation.length > 0) func.push(dataService.recommendation.saveAll({ transactionId: newTransId }, $scope.recommedation).$promise);

            return $q.all(func)
            .then(function(result) 
            {
                //throw (new Error("Just to prove catch() works! "));

                var next_fs = $("#subs-form-wrapper #thankyouForm");
                showNextForm(next_fs);
                updateProgressTracker();
            });
        },
        reportProblems = function( fault )
        {
            alert(fault.data.Message);
            $log.error( String(fault) );
        };

    var deals = $resource('/api/Deals/:dealsId', { dealsId: '@dealsId' },
    {
        saveAll:
        {
            method: 'POST',
            url: '/api/Deals/AddDeals',
            isArray: true,
            params: { transactionId: '@transactionId' }
        }
    })

    function showNextForm(next_fs) {
        var current_fs = $(".form-container:visible");

        //show the next fieldset
        next_fs.show();

        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now, mx) {
                //as the opacity of currenth_fs reduces to 0 - stored in "now"
                //1. scale previous_fs from 80% to 100%
                scale = 0.8 + (1 - now) * 0.2;
                //2. bring next_fs from the right(50%)
                left = ((1 - now) * 50) + "%";
                //3. increase opacity of next_fs to 1 as it moves in
                opacity = 1 - now;
                current_fs.css({ 'left': left });
                next_fs.css({ 'transform': 'scale(' + scale + ')', 'opacity': opacity });
            },
            duration: 800,
            complete: function () {
                current_fs.hide();
                animating = false;
            },
            //this comes from the custom easing plugin
            easing: 'easeInOutBack'
        });
    }

    function updateProgressTracker() {
        var next_act_task = $("#progressbar li.active:last").next();

        //activate next step on progressbar using the index of next_fs
        next_act_task.addClass("active");
    }


});


//bizModule.controller("cartController", function ($scope, $http, $compile, cartFactory) {

//    $scope.directory = {};
//    $scope.deals = {};

//    $scope.loadForm = function (productId, form) {

//        $http({
//            method: 'GET',
//            url: '/ProductSubmission/GetForm',
//            params: {
//                productId: productId
//            }
//        }).success(function (data, status, headers, config) {
//            form.html(data);    //jQuery code to load the content
//            $compile(form.contents())($scope);
//            return true;
//        });
//    }

//    $scope.showForm = function (formId) {
//        //alert('Hi');
//        showForm(formId);
//    }

//    $scope.init = function (dataKey) {
//        $scope.cartItems = cartFactory.getSubscriptions();
//        angular.forEach($scope.cartItems, function (product) {
//            var container_id = product.product.replace(' ', '-').toLowerCase();
//            var container_ele = $("<div id='" + container_id + "' class='form-container'>" + product.product + "</div>");

//            $("#subs-form-container").append(container_ele);
//            $scope.loadForm(product.id, container_ele);
//        });

//    }

//    $scope.getMaxTerm = function (num) {
//        return new Array(num);
//    }

//    $scope.getSubTotal = function () {
//        var item = this.item;

//        item.subTotal = item.termSelected * item.price;
//    }
//});
