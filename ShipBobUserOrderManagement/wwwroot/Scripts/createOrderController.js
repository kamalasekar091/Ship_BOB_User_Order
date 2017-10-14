shipBobOrderApp.controller('createOrderController', ['$scope', '$routeParams', '$http', '$location', function ($scope, $routeParams, $http, $location) {

    console.log("createOrderController" + window.location.href);
    var str = window.location.href;
    var idFromURL = str.substring(str.lastIndexOf("/") + 1);
    console.log("ID:-----> " + idFromURL)

    var data = $routeParams.data;

    $scope.$watch('trackingID', function () {
        $scope.trackingId = $scope.trackingID;
    });
    $scope.$watch('name', function () {
        $scope.name = $scope.name;
    });
    $scope.$watch('streetAddress', function () {
        $scope.street = $scope.streetAddress;
    });

    $scope.$watch('city', function () {
        $scope.city = $scope.city;

    });
    $scope.$watch('state', function () {
        $scope.state = $scope.state;
    });

    $scope.$watch('zipCode', function () {
        $scope.zipcode = $scope.zipCode;
    });

    $scope.addOrder = function () {


        if ($scope.trackingID == null || $scope.state == null || $scope.zipCode == null || $scope.city == null || $scope.name == null || $scope.streetAddress == null) {
            swal({
                title: "Not A valid Input!",
                text: "Please Enter All Values",
                icon: "error",
            });
        } else if ($scope.state.length != 2){
            swal({
                title: "Not A valid Input!",
                text: "State should only be 2 character in Length example IL for Illinois",
                icon: "error",
            });
        }

        else if (!(/^[0-9]+$/.test($scope.zipcode))) {
            swal({
                title: "Not A valid Input!",
                text: "Zip Code Can Contains Only numbers",
                icon: "error",
            });
        }
        else {
            $scope.orderDetails = {
                TrackingID: $scope.trackingId,
                Name: $scope.name,
                StreetAddress: $scope.street,
                City: $scope.city,
                State: $scope.state,
                ZipCode: $scope.zipcode,
                UserId: data
            };
            console.log($scope.orderDetails);
            result = $http({
                method: 'POST',
                url: '/Admin/Orders/Create',
                data: {
                    UserId: data,
                    Name: $scope.name,
                    TrackingID: $scope.trackingId,
                    StreetAddress: $scope.street,
                    City: $scope.city,
                    State: $scope.state,
                    ZipCode: $scope.zipcode
                },

                headers: {
                    "Content-Type": "application/json"
                }

            }).then(function (response) {
                swal("Success!", "Order Created Succesfully", "success");
                $location.path("/ViewOrdersForUser/" + idFromURL);


            }), (function (response) {
                console.log("Error" + response);
                swal({
                    title: "Issue",
                    text: "error occured while saving Order, Please try after some time",
                    icon: "error",
                });
            });
        }

    }

}]);
