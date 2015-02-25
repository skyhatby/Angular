
angularFormsApp.controller('dfController',
    function dfController($scope, dfService) {
        $scope.decision = dfService.employee;
    });