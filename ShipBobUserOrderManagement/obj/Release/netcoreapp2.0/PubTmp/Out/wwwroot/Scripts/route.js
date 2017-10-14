shipBobOrderApp.config(function ($routeProvider, $locationProvider) {
    $routeProvider.
        when('/', {
            templateUrl: '/Pages/user.html',
            controller: 'userControllerMain',
        })
        .when('/CreateOrder/:data', {
            templateUrl: '/Pages/createOrders.html',
            controller: 'createOrderController'
        })
        .when('/ViewOrdersForUser/:data', {
            templateUrl: '/Pages/ViewOrdersForUser.html',
            controller: 'ViewOrdersForUserController'
        })
        .when('/Users', {
            templateUrl: '/Pages/viewUsers.html',
            controller: 'viewUserController'
        });
     
});