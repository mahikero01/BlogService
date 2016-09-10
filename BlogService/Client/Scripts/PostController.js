(function (app) {
    var PostController = function ($scope, postService) {
        postService
            .getAll()
            .success(function (data) {
                $scope.posts = data;
            });

        $scope.delete = function (post) {
            postService.delete(post)
                .success(function () {
                    removePostById(post.Id);
                });
        };

        var removePostById = function (id) {
            for (var i = 0; i < $scope.posts.length; i++) {
                if ($scope.posts[i].Id == id){
                    $scope.posts.splice(i, 1);
                    break;
                }
            }
        };
    };

    app.controller("PostController", PostController);
}(angular.module("blogInfo")));