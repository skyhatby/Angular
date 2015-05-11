
angularFormsApp.controller('dfController',
    function dfController($scope, $window, $routeParams, DataService) {

        if ($routeParams.id) {
            if ($routeParams.id2) {
                $scope.updatedCriterion = {
                    criterion: angular.copy(DataService.getCriterionToUpdateValueRate($routeParams.id, $routeParams.id2)),
                    ids: [$routeParams.id, $routeParams.id2]
                };
            } else {
                $scope.decision = DataService.getDecision($routeParams.id);
            }
        } else {
            $scope.decision = { id: 0 };
        }

        $scope.editableDecision = angular.copy($scope.decision);
        $scope.editableCriterion = { id: 0 };
        $scope.editableDecisionObject = { id: 0 };

        $scope.submitForm = function () {

            if ($scope.editableDecision.id === 0) {
                //insert new decision
                DataService.insertDecision($scope.editableDecision);
            } else {
                //update
                DataService.updateDecision($scope.editableDecision);
            }

            $scope.decision = angular.copy($scope.editableDecision);
            $window.history.back();
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };

        $scope.submitCriterionForm = function () {

            if ($scope.editableCriterion.id === 0) {
                //insert new Criteria
                DataService.insertCriteria($scope.editableCriterion);
            } else {
                //update
                DataService.updateCriteria($scope.editableDecision);
            }

            $window.history.back();
        };

        $scope.submitCriterionValueForm = function () {

            DataService.updateValueAndRate($scope.updatedCriterion.ids[0], $scope.updatedCriterion.ids[1], $scope.updatedCriterion.criterion);

            $window.history.back();
        };

        $scope.submitDecisionObjectForm = function () {
            if ($scope.editableDecisionObject.id === 0) {
                //insert new Decision object
                DataService.insertDecisionObject($scope.editableDecisionObject);
            } else {
                //update
                DataService.updateDecisionObject($scope.editableDecisionObject);
            }

            $window.history.back();
        };

    });