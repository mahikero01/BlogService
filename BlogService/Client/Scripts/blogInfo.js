(function () {
    var app = angular.module("blogInfo", ["ngRoute"]);

    var config = function ($routeProvider) {
        $routeProvider
            .when("/postlist",
                { templateUrl: "/client/views/postlist.html" })
            .when("/postdetails/:id",
                { templateUrl: "/client/views/postdetails.html" })
            .otherwise(
                { redirectTo: "/postlist" })
    };

    app.config(config);
    app.constant("postsApiUrl", "/api/posts/");
}());