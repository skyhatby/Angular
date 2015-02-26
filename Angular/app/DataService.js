
angularFormsApp.factory('DataService',
    function () {
        var getDecision = function (id) {
            if (id == 123) {
                return {
                    id: 123,
                    sessionName: "testData",
                    decisionArray: []
                };
            }
            return undefined;
        };

        var insertDecision = function (newDecision) {
            return true;
        };
        var updateDecision = function (decision) {
            return true;
        };

        return {
            insertDecision: insertDecision,
            updateDecision: updateDecision,
            getDecision: getDecision
        };
    });