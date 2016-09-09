(function (app) {
    var PostController = function ($scope, $http) {
        $http.get("/api/posts")
             .success(function (data) {
                 $scope.posts = data;
             });
    };

    app.controller("PostController", PostController);
}(angular.module("blogInfo")));