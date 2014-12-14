
var app = angular.module('app', ["ui.router", "ngCookies", "ui.bootstrap"]);



app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/login');
    $stateProvider
        .state('login', {
            url: '/login',
            templateUrl: 'app/guest/login/login.html',
            controller:'loginController'
        })
        .state('registration', {
            url: '/registration',
        })
        .state('forgot', {
            url: '/forgot',
        })
        .state('admin', {
            url: '/admin',
            template:'<div ui-view></div>'
        })
        .state('admin.users', {
            url: '/users',
            template: '<div ui-view></div>'
        })
        .state('admin.users.list', {
            url: '/list',
            templateUrl: 'app/admin/list_of_users/usersList.html',
            controller: 'usersListController'
        })
        .state('admin.users.edit', {
            url: '/edit/:id',
        })
        .state('admin.users.add', {
            url: '/add',
        })
        .state('admin.users.remove', {
            url: '/remove/:id',
        });
});


app.run(function ($rootScope, $cookieStore, $http, $state) {

    $rootScope.setAuthorization=function(userProfile) {
        $cookieStore.put("userProfile", userProfile);
    }
    $rootScope.getAuthorization = function () {
        return $cookieStore.get("userProfile");
    }
    $rootScope.logout = function () {
        $cookieStore.remove("userProfile");
        $rootScope.userProfile = { isAuth: false };
        $state.go("login");
    }

    var cookieUser = $rootScope.getAuthorization();
    if (cookieUser) {
        $rootScope.user = cookieUser;
        $rootScope.user.isAuth = true;
    } else {
        $rootScope.userProfile = { isAuth: false };
    }


    $rootScope.credentials = {
        username: 'tkaldzija@devlogic.eu',
        passwordHash: 'ttare'
    };

    $rootScope.login = function () {
        $http.post('/api/access/token', $rootScope.credentials).success(function (data) {
            conosle.log('data', data);
        }).error(function (error) {

        });
    }


});