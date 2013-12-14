var dyelControllers = angular.module('dyelControllers');

// LOGIN CONTROLLER
dyelControllers.controller('LoginCtrl', function ($rootScope, $scope, $location, Person) {
    // Submit login
    $scope.submitLogin = function (user) {
        Person.login(user, function () {
            $rootScope.personId = user.Id;
            user = null;
            $location.url('/feed');
        });
    };
});