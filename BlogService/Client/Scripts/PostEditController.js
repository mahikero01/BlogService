(function (app) {
    var PostEditController = function ($scope, postService) { 
        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.post;
        };

        $scope.cancel = function () {
            $scope.edit.post = null;
        };

        $scope.save = function () {
            if ($scope.edit.post.Id) {
                updatePost();
            } else {
                createPost();
            }
        };

        var updatePost = function () {
            postService.update($scope.edit.post)
                .success(function () {
                    angular.extend($scope.post, $scope.edit.post);
                    $scope.edit.post = null;
                });
        };

        var createPost = function () {
            postService.create($scope.edit.post)
            .success(function (post) {
                $scope.posts.push(post);
                $scope.edit.post = null;
            });
        };
    };

    app.controller("PostEditController", PostEditController);
}(angular.module("blogInfo")));