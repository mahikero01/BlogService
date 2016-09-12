(function (app) {
    var PostDetailsController = function ($scope, $routeParams, postService) {
        

        postService
            .getById($routeParams.id)
            .success(function (data) {
                $scope.post = data;
            });

        $scope.edit = function () {
            //$scope.rico = "haha";
            $scope.dumedit = {
                post: {
                    Id: $scope.post.Id,
                    Title: $scope.post.Title,
                    Comment: $scope.post.Comment,
                    PersonID: "b17977e6-6559-402a-909c-21856748165f"
                }
            };
            $scope.edit.post = angular.copy($scope.dumedit.post);
        };
    };

    //DetailsController.$inject = ["$scope", "$routeParams", "movieService"];

    app.controller("PostDetailsController", PostDetailsController)
}(angular.module("blogInfo")));