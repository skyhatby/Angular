angularFormsApp.controller("homeController",
    function ($scope, $location, DataService) {

        $scope.decision = DataService.getDecision(0);

        $scope.showCreateDecisionForm = function () {
            $location.path('/newDecision');
        };

        $scope.showUpdateDecisionForm = function (id) {
            $location.path('/updateDecisionForm/' + id);
        };

        $scope.showAddCriteriaForm = function() {
            $location.path('/newCriteria');
        };

        $scope.showAddDecisionObjectForm = function () {
            $location.path('/newDecisionObject');
        };

    });