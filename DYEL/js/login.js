var dyelControllers = angular.module('dyelControllers');

// LOGIN CONTROLLER
dyelControllers.controller('LoginCtrl', function ($rootScope, $scope, $location, Session) {
    // Submit login
    $scope.submitLogin = function (user) {
        $rootScope.SessionId = Session.login(user, function () {
            $rootScope.SessionName = $rootScope.SessionId.PersonId;
            $rootScope.SessionId = $rootScope.SessionId.SessionId;
            $location.url('/feed');
        });
    };
});