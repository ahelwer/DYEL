var dyelApp = angular.module('dyelApp');

// ROUTE PROVIDER CONFIG

dyelApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/home', {
            templateUrl: '/home.aspx',
            controller: 'HomeCtrl'
        }).
        when('/login', {
            templateUrl: '/login.aspx',
            controller: 'LoginCtrl'
        }).
        when('/feed', {
            templateUrl: '/feed.aspx',
            controller: 'FeedCtrl'
        }).
        when('/workouts/:locationId?', {
            templateUrl: '/workouts.aspx',
            controller: 'WorkoutsCtrl'
        }).
        when('/focus', {
            templateUrl: '/focus.aspx',
            controller: 'FocusCtrl'
        }).
        when('/follows', {
            templateUrl: '/follows.aspx',
            controller: 'FollowsCtrl'
        }).
        when('/locations', {
            templateUrl: '/locations.aspx',
            controller: 'LocationsCtrl'
        }).
        otherwise({
            redirectTo: '/home'
        });
}]);

// LOCATION PROVIDER CONFIG

dyelApp.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.html5Mode(true);
}]);