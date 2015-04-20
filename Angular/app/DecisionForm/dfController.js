
angularFormsApp.controller('dfController',
    function dfController($scope, $window, $routeParams, DataService) {

        if ($routeParams.id) {
            if ($routeParams.id2) {
                $scope.updatedCriteria = {
                    criteria: angular.copy(DataService.getCriteriaToUpdateValueRate($routeParams.id, $routeParams.id2)),
                    ids: [$routeParams.id, $routeParams.id2]
                };
            } else {
                $scope.decision = DataService.getDecision($routeParams.id);
            }
        } else {
            $scope.decision = { id: 0 };
        }

        $scope.editableDecision = angular.copy($scope.decision);
        $scope.editableCriteria = { id: 0 };
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

        $scope.submitCriteriaForm = function () {

            if ($scope.editableCriteria.id === 0) {
                //insert new Criteria
                DataService.insertCriteria($scope.editableCriteria);
            } else {
                //update
                DataService.updateCriteria($scope.editableDecision);
            }

            $window.history.back();
        };

        $scope.submitCriteriaValueForm = function () {

            DataService.updateValueAndRate($scope.updatedCriteria.ids[0], $scope.updatedCriteria.ids[1], $scope.updatedCriteria.criteria);

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