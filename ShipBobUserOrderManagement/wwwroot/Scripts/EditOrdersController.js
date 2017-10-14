shipBobOrderApp.controller('EditOrdersController', ['$scope', '$http', '$location', '$route', function ($scope, $http, $location, $route) {
    console.log("EditOrdersController");
    console.log("EditOrdersController" + window.location.href);
    var str = window.location.href;
    var idFromURL = str.substring(str.lastIndexOf("/") + 1);
    console.log("EditOrdersController ID:-----> " + idFromURL)


    $http({
        method: 'PUT',
        url: '/Admin/Orders/Update/',
        data: {
            UserId: data,
            Name: $scope.name,
            TrackingID: $scope.trackingId,
            StreetAddress: $scope.street,
            City: $scope.city,
            State: $scope.state,
            ZipCode: $scope.zipcode,
            id: $scope.id
        },
        headers: {
            "Content-Type": "application/json"
        }
    }).then(function (response) {
        $scope.ordersForAUser = response.data;
        console.log(response.data);
        $location.path('/ViewOrdersForUser/' + response.data.id)
    }), (function (responsedata) {
        console.log("Error");
    });



}]);