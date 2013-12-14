var dyelControllers = angular.module('dyelControllers');

// FITNESS LOCATIONS CONTROLLER
dyelControllers.controller('LocationsCtrl', function ($scope, $location, Utilities, FitnessLocation, Attends, Focus) {
    if (null == $scope.personId) {
        $location.url('/login');
        return;
    }

    $scope.locations = FitnessLocation.getAll();
    $scope.attends = Attends.attends({ personId: $scope.personId });
    $scope.foci = Focus.getAll();

    // Filter for locations attended
    $scope.attendsFilter = function (location) {
        return $scope.attends.reduce(function (prev, curr) {
            return prev || (location.FitnessLocationId == curr.LocationId);
        }, false);
    }

    // Filter for locations not attended
    $scope.notAttendsFilter = function (location) {
        return !$scope.attendsFilter(location);
    }

    // Mark location as attended
    $scope.submitNewAttend = function (fitnessLocationId) {
        Attends.add({ personId: $scope.personId, locationId: fitnessLocationId }, function () {
            $scope.attends = Attends.attends({ personId: $scope.personId })
        });
    }

    // Remove location from attended
    $scope.removeAttend = function (fitnessLocationId) {
        Attends.remove({ personId: $scope.personId, locationId: fitnessLocationId }, function () {
            $scope.attends = Attends.attends({ personId: $scope.personId })
        });
    }

    // Submit new location
    $scope.submitNewLocation = function (newLocation) {
        newLocation.focus = newLocation.Focus.FocusId;
        FitnessLocation.create(newLocation, function () {
            Utilities.clear(newLocation);
            $scope.locations = FitnessLocation.getAll();
        });
    }
});
