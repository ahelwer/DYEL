var dyelControllers = angular.module('dyelControllers');

// FOLLOWS CONTROLLER
dyelControllers.controller('FollowsCtrl', function ($scope, $location, Person, Follower, Utilities) {
    if (null == $scope.SessionId) {
        $location.url('/login');
        return;
    }

    $scope.people = [];
    $scope.followers = [];
    $scope.following = Follower.following({ SessionId: $scope.SessionId, SessionName: 'FollowerId' }, function () {
        $scope.followers = Follower.followers({ SessionId: $scope.SessionId, SessionName: 'FolloweeId' }, function () {
            $scope.people = Person.getAll();
        });
    });

    // Get person description
    $scope.description = function (person) {
        return Utilities.description(person);
    }

    // Follow someone
    $scope.follow = function (followeeId) {
        var newFollow = { SessionId: $scope.SessionId, SessionName: 'FollowerId', FolloweeId: followeeId };
        Follower.follow(newFollow, function () {
            $scope.following = Follower.following({ SessionId: $scope.SessionId, SessionName: 'FollowerId' });
        });
    };

    // Unfollow someone
    $scope.unfollow = function (followeeId) {
        var tempFollow = { SessionId: $scope.SessionId, SessionName: 'FollowerId', FolloweeId: followeeId };
        Follower.unfollow(tempFollow, function () {
            $scope.following = Follower.following({ SessionId: $scope.SessionId, SessionName: 'FollowerId' });
            $scope.followers = Follower.followers({ SessionId: $scope.SessionId, SessionName: 'FolloweeId' });
        });
    };

    // Filter for list of people you are following
    $scope.followingFilter = function (followee) {
        if (followee.PersonId == $scope.SessionName) { return false; }
        var followeeId = followee.PersonId;
        return $scope.following.reduce(function (prev, curr) {
            return prev || (followeeId == curr.FolloweeId);
        }, false);
    };

    // Filter for list of people you not following
    $scope.notFollowingFilter = function (followee) {
        if (followee.PersonId == $scope.SessionName) { return false; }
        return !$scope.followingFilter(followee);
    };

    // Filter for list of people you are followed by
    $scope.followedByFilter = function (follower) {
        if (follower.PersonId == $scope.SessionName) { return false; }
        var followerId = follower.PersonId;
        return $scope.followers.reduce(function (prev, curr) {
            return prev || (followerId == curr.FollowerId);
        }, false);
    };
});