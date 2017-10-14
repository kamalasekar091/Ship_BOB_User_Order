shipBobOrderApp.controller('viewUserController', ['$scope', '$http', '$location', '$route', function ($scope, $http, $location, $route) {

    
    console.log("ViewUserController");
    $http({
        method: 'GET',
        url: '/Admin/Users/GetAll',
        headers: {
            "Content-Type": "application/json"
        }
    }).then(function (response) {
        $scope.users = response.data;
        console.log(response.data);
    }), (function (responsedata) {
        console.log("Error");
        });

    $scope.placeOrder = function (userID) {
        $scope.UserIDinScope = userID;
        console.log("In Place Order Function: " + userID);
        $location.path('/CreateOrder/' + userID)
    }

    $scope.viewOrders = function (userID) {
        $scope.UserIDinScope = userID;
        console.log("In View Order Function: " + userID);
        $location.path('/ViewOrdersForUser/' + userID)
    }

}]);