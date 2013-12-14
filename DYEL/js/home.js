var dyelControllers = angular.module('dyelControllers');

// HOME CONTROLLER
dyelControllers.controller('HomeCtrl', function ($rootScope, $scope, $location, Utilities, Person, Focus) {
    $scope.foci = Focus.getAll();

    // Submit new user
    $scope.submitNewUser = function (newUser) {
        newUser.Focus = newUser.Focus.FocusId;
        Person.create(newUser, function () {
            $rootScope.personId = newUser.Id;
            Utilities.clear(newUser);
            $location.url('/feed');
        });
    };

    // Submit new focus
    $scope.submitNewFocus = function (newFocus) {
        Focus.create(newFocus, function () {
            Utilities.clear(newFocus);
            $scope.foci = Focus.getAll();
        });
    };
});