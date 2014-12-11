app.controller('loginController', function ($rootScope, $scope, $state, $http) {
    $scope.registrationModel = {
        firstName:'',
        lastName:'',
        birthDate:'',
        email:'',
        passwordHash:'',
        userRole:1,
    };

    $scope.signUp = function () {

        $http.post('/api/registration', $scope.registrationModel).success(function (data) {

        }).error(function (error) {

        });
    }




    $scope.opened = false;


    $scope.clear = function () {
        $scope.birthDate = null;
    };

    $scope.open = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();
        $scope.opened = !$scope.opened;
    };

    $scope.dateOptions = {
        startingDay: 1
    };

    $scope.format = 'yyyy-MM-dd';

});