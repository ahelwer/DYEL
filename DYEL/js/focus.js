﻿var dyelControllers = angular.module('dyelControllers');

// FOCUS CONTROLLER
dyelControllers.controller('FocusCtrl', function ($scope, $location, Utilities, Focus, Person) {
    if (null == $scope.personId) {
        $location.url('/login');
        return;
    }

    $scope.foci = Focus.getAll();
    $scope.user = Person.get({ requestedPerson: $scope.personId });

    // Submit new focus
    $scope.submitNewFocus = function (newFocus) {
        Focus.create(newFocus, function () {
            Utilities.clear(newFocus);
            $scope.foci = Focus.getAll();
        });
    };
});