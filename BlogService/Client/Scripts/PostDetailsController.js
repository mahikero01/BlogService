(function (app) {
    var PostDetailsController = function ($scope, postService, $routeParams) {
        var id = $routeParams.id;

        postService
            .getById(id)
            .success(function (data) {
                $scope.post = data;
            });

        $scope.edit = function () {
            $scope.edit.post = angular.copy($scope.post);
        };
    };

    app.controller("PostDetailsController", PostDetailsController)
}(angular.module("blogInfo")));