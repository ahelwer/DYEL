var dyelControllers = angular.module('dyelControllers');

// FEED CONTROLLER
dyelControllers.controller('FeedCtrl', function ($scope, $location, $routeParams, Utilities, Person, FitnessLocation, Follower, Post, Comment, Focus) {
    if (null == $scope.SessionId) {
        $location.url('/login');
        return;
    }

    $scope.people = [];
    $scope.foci = Focus.getAll();
    $scope.following = Follower.following({ SessionId: $scope.SessionId, SessionName: 'FollowerId' }, function () {
        $scope.people = Person.getAll();
    });
    $scope.followers = Follower.followers({ SessionId: $scope.SessionId, SessionName: 'FolloweeId' });

    $scope.posts = [];
    $scope.comments = {};

    // Get all posts
    $scope.getPosts = function () {
        return Post.getAll({ SessionId: $scope.SessionId }, function () {
            $scope.posts.forEach(function (post) {
                $scope.comments[post.PostId] = Comment.getAll({ SessionId: $scope.SessionId, PostId: post.PostId });
            });
        });
    }

    // Submit new post
    $scope.submitPost = function (newPost) {
        newPost.SessionId = $scope.SessionId;
        newPost.Focus = newPost.Focus.FocusId;
        Post.create(newPost, function () {
            Utilities.clear(newPost);
            $scope.posts = $scope.getPosts();
        });
    }

    // Submit new comment
    $scope.submitComment = function (newComment, postId) {
        newComment.PostId = postId;
        newComment.SessionId = $scope.SessionId;
        Comment.create(newComment, function () {
            Utilities.clear(newComment);
            $scope.comments[postId] = Comment.getAll({ SessionId: $scope.SessionId, PostId: postId });
        });
    }

    $scope.posts = $scope.getPosts();
});