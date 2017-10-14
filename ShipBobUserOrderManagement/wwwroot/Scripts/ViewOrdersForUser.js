shipBobOrderApp.controller('ViewOrdersForUserController', ['$scope', '$http', '$location', '$route', function ($scope, $http, $location, $route) {
    console.log("ViewOrdersForUserController");
    console.log("createOrderController" + window.location.href);
    var str = window.location.href;
    var idFromURL = str.substring(str.lastIndexOf("/") + 1);
    console.log("ViewOrdersForUserController ID:-----> " + idFromURL)


    $http({
        method: 'GET',
        url: '/Admin/Orders/GetOrderForaUser/' + idFromURL,
        headers: {
            "Content-Type": "application/json"
        }
    }).then(function (response) {
        $scope.ordersForAUser = response.data;
        $scope.tableView = true;
        console.log(response.data);
    }), (function (responsedata) {
        console.log("Error");
    });


    $scope.delete = function(theOrder) {
        console.log("ViewOrdersForUserController Delete Function User ID:-----> " + theOrder.userId)
        console.log("ViewOrdersForUserController Delete Function ID:-----> " + theOrder.id)

        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover the Order!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {

                   $http({
            method: 'DELETE',
            url: '/Admin/Orders/Delete/' + theOrder.id

        }).then(function (response) {
            console.log("ViewOrdersForUserController Delete Functionsuccess function++++++++:-----> " + theOrder.id)
            swal("Success! Order has been deleted!", {
                icon: "success",
            });
            $route.reload();

           // $location.path('/ViewOrdersForUser/' + theOrder.userId);
        }), (function (errorResponse) {
        });

                    
                } else {
                    swal("Order has not been Deleted");
                }
            });

        //result = $http({
        //    method: 'DELETE',
        //    url: '/Admin/Orders/Delete/' + theOrder.id
           
        //}).then(function (response) {
        //    console.log("ViewOrdersForUserController Delete Functionsuccess function++++++++:-----> " + theOrder.id)
        //    $route.reload();

        //   // $location.path('/ViewOrdersForUser/' + theOrder.userId);
        //}), (function (errorResponse) {
        //});


    };


    $scope.editOrder = function (theOrder) {
        //$scope.stash = {
        //    'name': $scope.records[idx].name
        //};
        //$scope.current_record = idx;
        console.log("ViewOrdersForUserController edit Functionsuccess function++++++++:-----> " + theOrder.id)
        $scope.editor = theOrder;
        $scope.tableView = false;
        $scope.editform = true;
    }

    $scope.save = function (id, userId, trackingID, name, streetAddress, state, city, zipCode) {

        if (id == null || userId == null || trackingID == null || name == null || state == null || city == null || zipCode == null) {
            swal({
                title: "Not A valid Input!",
                text: "Please Enter All Values",
                icon: "error",
            });
        } else if (state.length != 2) {
            swal({
                title: "Not A valid Input!",
                text: "State should only be 2 character in Length example IL for Illinois",
                icon: "error",
            });
        }

        else if (!(/^[0-9]+$/.test(zipcode))) {
            swal({
                title: "Not A valid Input!",
                text: "Zip Code Can Contains Only numbers",
                icon: "error",
            });
        } else {



            //$scope.stash = {
            //    'name': $scope.records[idx].name
            //};
            //$scope.current_record = idx;
            console.log("ViewOrdersForUserController save Functionsuccess function++++++++:-----> " + id + " ---- " + userId + " ---- " + trackingID + " ---- " + name + " ---- " + streetAddress + " ---- " + state + " ---- " + city + " ---- " + zipCode)
            //$scope.editor = theOrder;
            //$scope.tableView = false;
            //$scope.editform = true;

            $http({
                method: 'PUT',
                url: '/Admin/Orders/Update',
                data: {
                    UserId: userId,
                    Name: name,
                    TrackingID: trackingID,
                    StreetAddress: streetAddress,
                    City: city,
                    State: state,
                    ZipCode: zipCode,
                    OrderId: id
                },

                headers: {
                    "Content-Type": "application/json"
                }

            }).then(function (response) {
                $scope.tableView = true;
                $scope.editform = false;
                //$location.path('/ViewOrdersForUser/' + userId);
            }), (function (response) {
                console.log("Error" + response);
            });
        }
    }

   
}]);