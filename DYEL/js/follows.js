var dyelControllers = angular.module('dyelControllers');

// FOLLOWS CONTROLLER
dyelControllers.controller('FollowsCtrl', function ($scope, $location, Person, Follower, Utilities) {
    if (null == $scope.personId) {
        $location.url('/login');
        return;
    }

    $scope.people = [];
    $scope.followers = [];
    $scope.following = Follower.following({ followerId: $scope.personId }, function () {
        $scope.followers = Follower.followers({ followeeId: $scope.personId }, function () {
            $scope.people = Person.getAll();
        });
    });

    // Get person description
    $scope.description = function (person) {
        return Utilities.description(person);
    }

    // Follow someone
    $scope.follow = function (followeeId) {
        var newFollow = { FollowerId: $scope.personId, FolloweeId: followeeId };
        Follower.follow(newFollow, function () {
            $scope.following = Follower.following({ followerId: $scope.personId });
        });
    };

    // Unfollow someone
    $scope.unfollow = function (followeeId) {
        var tempFollow = { FollowerId: $scope.personId, FolloweeId: followeeId };
        Follower.unfollow(tempFollow, function () {
            $scope.following = Follower.following({ followerId: $scope.personId });
            $scope.followers = Follower.followers({ followeeId: $scope.personId });
        });
    };

    // Filter for list of people you are following
    $scope.followingFilter = function (followee) {
        if (followee.Id == $scope.personId) { return false; }
        var followeeId = followee.Id;
        return $scope.following.reduce(function (prev, curr) {
            return prev || (followeeId == curr.FolloweeId);
        }, false);
    };

    // Filter for list of people you not following
    $scope.notFollowingFilter = function (followee) {
        if (followee.Id == $scope.personId) { return false; }
        return !$scope.followingFilter(followee);
    };

    // Filter for list of people you are followed by
    $scope.followedByFilter = function (follower) {
        if (follower.Id == $scope.personId) { return false; }
        var followerId = follower.Id;
        return $scope.followers.reduce(function (prev, curr) {
            return prev || (followerId == curr.FollowerId);
        }, false);
    };
});