(function (app) {
    var postService = function ($http, postsApiUrl) {
        var getAll = function () {
            return $http.get(postsApiUrl);
        };

        var getById = function (id) {
            return $http.get(postsApiUrl + id);
        };

        return {
            getAll: getAll,
            getById: getById
        };
    };

    app.factory("postService", postService);
}(angular.module("blogInfo")));