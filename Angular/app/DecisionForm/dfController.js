
angularFormsApp.controller('dfController',
    function dfController($scope, $window, $routeParams, DataService) {

        if ($routeParams.id) {
            $scope.decision = DataService.getDecision($routeParams.id);
        } else {
            $scope.decision = { id: 0 };
        }

        $scope.editableDecision = angular.copy($scope.decision);

        $scope.submitForm = function () {

            if ($scope.editableDecision.id == 0) {
                //insert new employee
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

    });