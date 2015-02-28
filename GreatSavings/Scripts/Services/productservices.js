//bizModule.service('transactionService',  ['$http', function ($http) {
//    this.create = function (model) {
//        $http.post('/api/Transaction/', model).success(function (data) {
//            alert("Transaction Added Successfully!! " + data);
//            newMerchandId = data;

//        }).error(function (data) {
//            var error = "An Error has occured while registering account! " + data;
//            alert(error);
//        });

//    };
//}]);


bizModule.service('dataService', ['$http', '$q', '$resource',  '$timeout', function ($http, $q, $resource, $timeout) {


    this.getNewDirectoryId = function (stateId) {
        var def = $q.defer();

        $http.get('/api/Directory/GenerateId/' + stateId).success(function (data) {
   
            def.resolve(data);
        }).error(function (data) {
            var error = "An Error has occured while registering account! " + data;
            def.reject(error);
        });

        return def.promise;
    };

    this.register = function (accountinfo) {
        var def = $q.defer();

        $http.post('/api/Account/Register', accountinfo).success(function (data) {

            def.resolve(data);
        }).error(function (data) {
            var error = "An Error has occured while registering account! " + data;
            def.reject(error);
        });

        return def.promise;
    };


    this.merchangLogin = function (accountinfo) {
        var def = $q.defer();

        $http.post('/api/Account/MerchantLogin', accountinfo).success(function (data) {

            def.resolve(data);
        }).error(function (data) {
            var error = "An Error has occured while registering account! " + data;
            def.reject(error);
        });

        return def.promise;
    };


    this.account = $resource('/api/Account', {},
    {
        getRegisterModel:
        {
            method: 'Get',
            url: '/api/Account/GetRegisterModel',
            isArray: false
        },
        register:
        {
            method: 'POST',
            url: '/api/Account/Register',
            isArray: false
        },
        checkEmailIsUnique:
        {
            method: 'Get',
            url: '/api/Account/CheckEmailAlreadyExist',
            isArray: false,
            params: { email: '@email' }
        }
    
    });


    this.transaction = $resource('/api/Transaction/Get/:id', { id: '@id' },
    {
        save:
        {
            method: 'POST',
            url: '/api/Transaction',
            isArray: false
        }
    });

    this.directory = $resource('/api/Directory/Get/:id', { id: '@id' },
    {
        getNewId:
        {
            method: 'GET',
            url: '/api/Directory/GenerateId/:id',
            isArray: false,
            params: { id: '@id' }
        },
        getByMerchant:
        {
            method: 'GET',
            url: '/api/Directory/GetByMerchant/:id',
            isArray: true,
            params: { id: '@id' }
        },
        saveAll:
        {
            method: 'POST',
            url: '/api/Directory/AddDirectories',
            isArray: true,
            params: { transactionId: '@transactionId', transactionId: '@transactionId' }
        }
    });


    this.deals = $resource('/api/Deals/Get/:id', { id: '@id' },
    {
        saveAll:
        {
            method: 'POST',
            url: '/api/Deals/AddDeals',
            isArray: true,
            params: { transactionId: '@transactionId' }
        },
        load:
        {
            method: 'GET',
            url: '/api/Deals/Load',
            isArray: true,
            params: { totalReturn: '@totalReturn' }
        }
    });

    this.newOpening = $resource('/api/NewOpening/Get/:id', { id: '@id' },
    {
        saveAll:
        {
            method: 'POST',
            url: '/api/NewOpening',
            isArray: true,
            params: { transactionId: '@transactionId' }
        }
    });

    this.recommendation = $resource('/api/Recommendation/Get/:id', { id: '@id' },
 {
     saveAll:
     {
         method: 'POST',
         url: '/api/Recommendation/AddRecommendations',
         isArray: true,
         params: { transactionId: '@transactionId' }
     }
 });
    //this.getTransaction = function (id) {
    //    var def = $q.defer();
   
    //    $http.get('/api/Transaction/'+ id).success(function (data) {
    //        def.resolve(data);

    //    }).error(function (data) {
    //        var error = "An Error has occured while registering account! " + data;
    //        alert(error);
    //        def.reject(error);
    //    });
    //    return def.promise;
    //};

    //this.getDeals = function () {
    //    var def = $q.defer();

    //    $http.get('/api/Deals/').success(function (data) {
    //        def.resolve(data);

    //    }).error(function (data) {
    //        var error = "An Error has occured while registering account! " + data;
    //        alert(error);
    //        def.reject(error);
    //    });
    //    return def.promise;
    //};

    
    //this.createTransaction = function (transaction) {
    //    var def = $q.defer();
    //    $http.post('/api/Transaction/', transaction).success(function (data) {
    //        alert("Transaction Added Successfully!! " + data);
    //        def.resolve(data);

    //    }).error(function (data) {
    //        var error = "An Error has occured while creating transaction! " + data;
    //        alert(error);
    //        def.reject(error);
    //    });
    //    return def.promise;
    //};

    //this.createDirectories = function (directories, transactionId) {
    //    if (directories.length > 0) {
    //        var def = $q.defer();
    //        $http.post('/api/Directory/', directories).success(function (data) {
    //            alert("Directory Added Successfully!! " + data);
    //            def.resolve(data);

    //        }).error(function (data) {
    //            var error = "An Error has occured while creating directory! " + data;
    //            alert(error);
    //            def.reject(error);
    //        });
    //        return def.promise;
    //    }
    //};

}]);