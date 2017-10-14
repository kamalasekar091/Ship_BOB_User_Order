shipBobOrderApp.controller('userControllerMain', ['$scope', '$http', '$location', '$route', function ($scope, $http, $location, $route) {
    $scope.test = "hello";
    console.log($scope.test);
    $scope.firstName;
    $scope.lastName;
    $scope.userCreated = false;
    $scope.createdUser = false;
    $scope.placeorder = false;
    $scope.allorder = false;
    $scope.createUser = function (firstName, lastName) {
        $scope.user = {
            FirstName: firstName,
            LastName: lastName,
            id: null
        };
        console.log("Scope Users first Name " + $scope.user.firstName);
        if (firstName == null || lastName == null) {
            //alert("Please Enter the Required Fields");
            swal({
                title: "Not A valid Input!",
                text: "First Name or Last Name should not be null",
                icon: "error",
            });

        } else {


       

        $http({
            method: 'POST',
            url: '/Admin/Users/Create',
            data: {
                FirstName: firstName,
                LastName: lastName
            },
            headers: {
                "Content-Type": "application/json"
            }
        }).then(function (response) {
            //$route.reload();
            //$scope.userCreated = true;
            //$scope.createdUser = true;
            //console.log("Create User ----------->" + response.data.id);
            //$scope.theUser = response.data;
            //alert("User Created successfully");

            swal("Good job!","User Created Succesfully with First Name: " + response.data.firstName , "success", {
                buttons: {
                    newOrder: "Place Order",
                    allUser: "All Users",
                    
                },
            })
                .then((value) => {
                    switch (value) {

                        case "newOrder":
                            location.href = '#!/CreateOrder/' + response.data.id
                            //$route.reload();
                            break;
                        case "allUser":
                           
                            location.href = '#!/Users'
                            //$location.path('/Users');
                            break;
                        default:
                            $route.reload();
                    }
                });

            

            //Default Working Option to divert user to all user page
            //swal("Congraz!","User Created Succesfully", "success");
            //$location.path('/Users') 
        }), (function (response) {
            console.log("Error" + response);
        })
        };


    }

}]);