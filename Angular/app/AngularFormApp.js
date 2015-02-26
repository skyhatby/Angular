
var angularFormsApp = angular.module('angularFormsApp', ["ngRoute"]);

angularFormsApp.config(function ($routeProvider) {
    $routeProvider
        .when("/home", {
            templateUrl: "app/Home.html",
            controller: "HomeController"
        })
        .when("/newDecision", {
            templateUrl: "app/DecisionForm/dfTemplate.html",
            controller: "dfController"
        })
        .when("/updateDecisionForm/:id", {
            templateUrl: "app/DecisionForm/dfTemplate.html",
            controller: "dfController"
        })
        .otherwise({
            redirectTo: "/home"
        });
});

angularFormsApp.controller("HomeController",
    function ($scope, $location, DataService) {

        $scope.showCreateDecisionForm = function () {
            $location.path('/newDecision');
        };

        $scope.showUpdateDecisionForm = function (id) {
            $location.path('/updateDecisionForm/' + id);
        };

    });