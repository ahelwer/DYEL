var dyelControllers = angular.module('dyelControllers');

// FITNESS LOCATIONS CONTROLLER
dyelControllers.controller('LocationsCtrl', function ($scope, $location, Utilities, FitnessLocation, Attends, Focus) {
    if (null == $scope.SessionId) {
        $location.url('/login');
        return;
    }

    $scope.locations = FitnessLocation.getAll();
    $scope.attends = Attends.attends({ SessionId: $scope.SessionId });
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
        Attends.add({ SessionId: $scope.SessionId, LocationId: fitnessLocationId }, function () {
            $scope.attends = Attends.attends({ SessionId: $scope.SessionId })
        });
    }

    // Remove location from attended
    $scope.removeAttend = function (fitnessLocationId) {
        Attends.remove({ SessionId: $scope.SessionId, LocationId: fitnessLocationId }, function () {
            $scope.attends = Attends.attends({ SessionId: $scope.SessionId })
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
