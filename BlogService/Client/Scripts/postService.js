(function (app) {
    var postService = function ($http, postsApiUrl) {
        var getAll = function () {
            return $http.get(postsApiUrl);
        };

        var getById = function (id) {
            return $http.get(postsApiUrl + id);
        };

        var update = function (post) {
            return $http.put(postsApiUrl + post.Id, post);
        };

        var create = function (post) {
            return $http.post(postsApiUrl, post);
        };

        var destroy = function (post) {
            return $http.delete(postsApiUrl + post.Id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destroy
        };
    };

    app.factory("postService", postService);
}(angular.module("blogInfo")));