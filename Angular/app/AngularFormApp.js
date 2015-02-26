
var angularFormsApp = angular.module('angularFormsApp', ["ngRoute"]);

angularFormsApp.config(function ($routeProvider) {
    $routeProvider
        .when("/home", {
            templateUrl: "app/Home.html",
            controller: "homeController"
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