angularFormsApp.controller("homeController",
    function ($scope, $location, DataService) {

        $scope.decision = DataService.getDecision(0);

        $scope.showCreateDecisionForm = function () {
            $location.path('/newDecision');
        };

        $scope.showUpdateDecisionForm = function (id) {
            $location.path('/updateDecisionForm/' + id);
        };

        $scope.showAddCriterionForm = function() {
            $location.path('/newCriterion');
        };

        $scope.showAddDecisionObjectForm = function () {
            $location.path('/newDecisionObject');
        };

        $scope.showCriteriaToUpdateValueRate = function(id, id2) {
            $location.path('/updateValue/' + id + '/' + id2);
        };

    });