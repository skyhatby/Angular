
angularFormsApp.factory('DataService',
    function () {

        var workingDecision = {
            id: 0,
            sessionName: "testData",
            decisionArray: [
                    {
                        id: 0,
                        name: "iPhone",
                        criteriaArray: [
                            {
                                id: 0,
                                name: "design",
                                rate: 1,
                                value: "brand",
                                valueRate: 1
                            },
                            {
                                id: 1,
                                name: "price",
                                rate: 1,
                                value: "1000",
                                valueRate: 1
                            }
                        ]
                    },
                    {
                        id: 1,
                        name: "Nokia Lumia 930",
                        criteriaArray: [
                            {
                                id: 0,
                                name: "design",
                                rate: 1,
                                value: "brand",
                                valueRate: 1
                            },
                            {
                                id: 1,
                                name: "price",
                                rate: 1,
                                value: "400",
                                valueRate: 1
                            }
                        ]
                    },
                    {
                        id: 2,
                        name: "Samsung Galaxy S5",
                        criteriaArray: [
                            {
                                id: 0,
                                name: "design",
                                rate: 1,
                                value: "brand",
                                valueRate: 1
                            },
                            {
                                id: 1,
                                name: "price",
                                rate: 1,
                                value: "700",
                                valueRate: 1
                            }
                        ]
                    }
            ]
        };

        var getDecision = function (id) {
            if (id == 0) {
                return workingDecision;
            }
            return undefined;
        };

        var insertDecision = function (newDecision) {
            workingDecision = newDecision;
            return true;
        };
        var updateDecision = function (decision) {
            workingDecision = decision;
            return true;
        };
        var insertCriteria = function (newCriteria) {
            if (workingDecision.decisionArray == undefined) {
                workingDecision.decisionArray = [
                    {
                        id: 0,
                        name: "undefined",
                        criteriaArray: []
                    }
                ];
            }
            for (var decisionId in workingDecision.decisionArray) {
                if (workingDecision.decisionArray[decisionId].criteriaArray == undefined) {
                    workingDecision.decisionArray[decisionId].criteriaArray = [];
                }
                newCriteria.id = workingDecision.decisionArray[decisionId].criteriaArray.length;
                workingDecision.decisionArray[decisionId]
                .criteriaArray.push(newCriteria);
            }
            return true;
        };
        var insertDecisionObject = function (newDecisionObject) {
            if (workingDecision.decisionArray == undefined) {
                newDecisionObject.id = 0;
                workingDecision.decisionArray = [newDecisionObject];
            }
            else {
                newDecisionObject.id = workingDecision.decisionArray.length;
                newDecisionObject.criteriaArray = angular.copy(workingDecision.decisionArray[0].criteriaArray);
                workingDecision.decisionArray.push(newDecisionObject);
            }
            return true;
        };

        var getCriteriaToUpdateValueRate = function (id, id2) {
            return workingDecision.decisionArray[id].criteriaArray[id2];
        };

        var updateValueAndRate = function (id, id2, updateCriteria) {
            workingDecision.decisionArray[id].criteriaArray[id2] = updateCriteria;
            return true;
        };

        return {
            insertDecision: insertDecision,
            updateDecision: updateDecision,
            getDecision: getDecision,
            insertCriteria: insertCriteria,
            insertDecisionObject: insertDecisionObject,
            getCriteriaToUpdateValueRate: getCriteriaToUpdateValueRate,
            updateValueAndRate: updateValueAndRate
        };
    });