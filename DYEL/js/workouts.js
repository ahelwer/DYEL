var dyelControllers = angular.module('dyelControllers');

// WORKOUTS CONTROLLER
dyelControllers.controller('WorkoutsCtrl', function ($scope, $location, $routeParams, Utilities, Person, FitnessLocation, Follower, Workout, Joiner, Focus) {
    if (null == $scope.personId) {
        $location.url('/login');
        return;
    }

    $scope.newWorkout = {};
    $scope.foci = Focus.getAll(function () {
        $scope.locations = FitnessLocation.getAll(function () {
            if (null != $routeParams.locationId) {
                $scope.newWorkout.LocationId = $scope.getLocationDetails($routeParams.locationId);
                $scope.newWorkout.Focus = $scope.getFocusDetails($scope.newWorkout.LocationId.Focus);
            }
        });
    });

    $scope.following = Follower.following({ followerId: $scope.personId });
    $scope.followers = Follower.followers({ followeeId: $scope.personId });

    $scope.workouts = [];
    $scope.joiners = {};

    // Get location details
    $scope.getLocationDetails = function (locationId) {
        for (var key in $scope.locations) {
            var location = $scope.locations[key];
            if (location.FitnessLocationId == locationId) {
                return location;
            }
        }
        return null;
    }

    // Get focus details
    $scope.getFocusDetails = function (focusId) {
        for (var key in $scope.foci) {
            var focus = $scope.foci[key];
            if (focus.FocusId == focusId) {
                return focus;
            }
        }
        return null;
    }

    // Get all workouts
    $scope.getWorkouts = function () {
        return Workout.getAll({ personId: $scope.personId }, function () {
            $scope.workouts.forEach(function (workout) {
                $scope.joiners[workout.WorkoutId] = Joiner.getJoiners({ workoutId: workout.WorkoutId });
            });
        });
    }

    // Broadcast new workout
    $scope.broadcastWorkout = function (newWorkout) {
        newWorkout.PersonId = $scope.personId;
        newWorkout.LocationId = newWorkout.LocationId.FitnessLocationId;
        newWorkout.Focus = newWorkout.Focus.FocusId;
        Workout.create(newWorkout, function () {
            $scope.workouts = $scope.getWorkouts();
        });
    }

    // Request to join a workout
    $scope.requestJoin = function (workoutId) {
        var newRequest = { PersonId: $scope.personId, WorkoutId: workoutId };
        Joiner.postRequest(newRequest, function () {
            $scope.joiners[workoutId] = Joiner.getJoiners({ WorkoutId: workoutId });
        });
    }

    // Removes user's join request from workout
    $scope.removeJoin = function (workoutId) {
        var temp = { PersonId: $scope.personId, WorkoutId: workoutId };
        Joiner.removeRequest(temp, function () {
            $scope.joiners[workoutId] = Joiner.getJoiners({ WorkoutId: workoutId });
        })
    }

    // Respond to join request
    $scope.respond = function (join, status) {
        var temp = { PersonId: join.PersonId, WorkoutId: join.WorkoutId, Status: status };
        Joiner.respond(temp, function () {
            $scope.joiners[join.WorkoutId] = Joiner.getJoiners({ WorkoutId: join.WorkoutId });
        });
    }

    // Filter for list of attending workouts
    $scope.attendingWorkouts = function (workout) {
        var joiners = $scope.joiners[workout.WorkoutId];
        return joiners.reduce(function (prev, curr) {
            return prev || (curr.PersonId == $scope.personId && curr.Status == 1);
        }, false);
    }

    // Filter for list of suggested workouts
    $scope.suggestedWorkouts = function (workout) {
        var joiners = $scope.joiners[workout.WorkoutId];
        return !joiners.reduce(function (prev, curr) {
            return prev || (curr.PersonId == $scope.personId);
        }, false);
    }

    // Tests whether user has sent join request for workout
    $scope.hasSentRequest = function (workout) {
        var joiners = $scope.joiners[workout.WorkoutId];
        return joiners.reduce(function (prev, curr) {
            return prev || (curr.PersonId == $scope.personId);
        }, false);
    }

    // Tests whether join request has been accepted
    $scope.joinRequestAccepted = function (request) {
        return request.Status == 1;
    }

    // Tests whether join request has been rejected
    $scope.joinRequestNotRejected = function (request) {
        return request.Status != 2;
    }

    // Get person description
    $scope.description = function (person) {
        return Utilities.description(person);
    }

    $scope.workouts = $scope.getWorkouts();
});