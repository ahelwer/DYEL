<!DOCTYPE html>
<html lang="en" ng-app="dyelApp">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Do you even lift?</title>

    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/angular-route.min.js"></script>
    <script src="Scripts/angular-resource.min.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/respond.min.js"></script>

    <link rel="stylesheet" type="text/css" href="Content/bootstrap-theme.min.css">
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="Content/site.css">
    <script>
        var dyelApp = angular.module('dyelApp', ['ngRoute', 'ngResource', 'dyelControllers']);
        var dyelControllers = angular.module('dyelControllers', []);

        // HEADER CONTROLLER
        dyelControllers.controller('HeaderCtrl', function ($scope, $location) {

            // Determine if view location is active
            $scope.isActive = function (viewLocation) {
                return viewLocation === $location.path().split('/')[1];
            };
        });
    </script>
    
    <script src="js/config.js"></script>
    <script src="js/services.js"></script>
    <script src="js/home.js"></script>
    <script src="js/login.js"></script>
    <script src="js/feed.js"></script>
    <script src="js/workouts.js"></script>
    <script src="js/location.js"></script>
    <script src="js/focus.js"></script>
    <script src="js/follows.js"></script>

</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="/">DYEL</a>
            </div>
            <div class="collapse navbar-collapse" ng-controller="HeaderCtrl">
                <ul class="nav navbar-nav">
                    <li ng-class="{active: isActive('/home')}"><a ng-href="/home">Home</a></li>
                    <li ng-class="{active: isActive('/login')}"><a ng-href="/login">Login</a></li>
                    <li ng-class="{active: isActive('/feed')}"><a ng-href="/feed">Feed</a></li>
                    <li ng-class="{active: isActive('/workouts')}"><a ng-href="/workouts">Workouts</a></li>
                    <li ng-class="{active: isActive('/locations')}"><a ng-href="/locations">Locations</a></li>
                    <li ng-class="{active: isActive('/focus')}"><a ng-href="/focus">Focus</a></li>
                    <li ng-class="{active: isActive('/follows')}"><a ng-href="/follows">Follows</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        <div ng-view></div>
        <footer>
            <p>2013 - DYEL Corporation</p>
        </footer>
    </div>
</body>
</html>
