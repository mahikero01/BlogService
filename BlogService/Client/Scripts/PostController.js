(function (app) {
    var PostController = function ($scope, postService) {
        postService
            .getAll()
            .success(function (data) {
                $scope.posts = data;
            });
    };

    app.controller("PostController", PostController);
}(angular.module("blogInfo")));