﻿angularFormsApp.controller("homeController",
    function ($scope, $location, $http, DataService) {

        $scope.decision = DataService.getDecision(0);

        $scope.showCreateDecisionForm = function () {
            $location.path('/newDecision');
        };

        $scope.showUpdateDecisionForm = function (id) {
            $location.path('/updateDecisionForm/' + id);
        };

        $scope.showAddCriterionForm = function () {
            $location.path('/newCriterion');
        };

        $scope.showAddDecisionObjectForm = function () {
            $location.path('/newDecisionObject');
        };

        $scope.showCriteriaToUpdateValueRate = function (id, id2) {
            $location.path('/updateValue/' + id + '/' + id2);
        };

        $scope.submitForm = function () {
            $http.post('http://localhost:1200/api/Decision', JSON.stringify(DataService.getDecision(0))).success(function () {
                alert("ok");
            });
        }

    });