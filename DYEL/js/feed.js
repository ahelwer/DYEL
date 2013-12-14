var dyelControllers = angular.module('dyelControllers');

// FEED CONTROLLER
dyelControllers.controller('FeedCtrl', function ($scope, $location, $routeParams, Utilities, Person, FitnessLocation, Follower, Post, Comment, Focus) {
    if (null == $scope.personId) {
        $location.url('/login');
        return;
    }

    $scope.people = [];
    $scope.following = Follower.following({ followerId: $scope.personId }, function () {
        $scope.people = Person.getAll();
    });
    $scope.followers = Follower.followers({ followeeId: $scope.personId });

    $scope.posts = [];
    $scope.comments = {};

    // Get all posts
    $scope.getPosts = function () {
        return Post.getAll({ personId: $scope.personId }, function () {
            $scope.posts.forEach(function (post) {
                $scope.comments[post.PostId] = Comment.getAll({ postId: post.PostId });
            });
        });
    }

    // Submit new post
    $scope.submitPost = function (newPost) {
        newPost.PersonId = $scope.personId;
        newPost.Focus = newPost.Focus.FocusId;
        Post.create(newPost, function () {
            Utilities.clear(newPost);
            $scope.posts = $scope.getPosts();
        });
    }

    // Submit new comment
    $scope.submitComment = function (newComment, postId) {
        newComment.PostId = postId;
        newComment.PersonId = $scope.personId;
        Comment.create(newComment, function () {
            Utilities.clear(newComment);
            $scope.comments[postId] = Comment.getAll({ postId: postId });
        });
    }

    $scope.posts = $scope.getPosts();
});