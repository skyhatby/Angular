﻿
angularFormsApp.factory('DataService',
    function () {

        var workingDecision = {
            id: 0,
            sessionName: "testData",
            decisionArray: [
                    {
                        name: "iPhone",
                        criteriaArray: [
                            {
                                name: "design",
                                rate: 1,
                                value: "brand",
                                valueRate: 1
                            },
                            {
                                name: "price",
                                rate: 1,
                                value: "1000",
                                valueRate: 1
                            }
                        ]
                    },
                    {
                        name: "Nokia Lumia 930",
                        criteriaArray: [
                            {
                                name: "design",
                                rate: 1,
                                value: "brand",
                                valueRate: 1
                            },
                            {
                                name: "price",
                                rate: 1,
                                value: "400",
                                valueRate: 1
                            }
                        ]
                    },
                    {
                        name: "Samsung Galaxy S5",
                        criteriaArray: [
                            {
                                name: "design",
                                rate: 1,
                                value: "brand",
                                valueRate: 1
                            },
                            {
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
                        id: 1,
                        criteriaArray: []
                    }
                ];
            }
            for (var decisionId in workingDecision.decisionArray) {
                if (workingDecision.decisionArray[decisionId].criteriaArray == undefined) {
                    workingDecision.decisionArray[decisionId].criteriaArray = [];
                }
                workingDecision.decisionArray[decisionId]
                .criteriaArray.push(newCriteria);
            }
            return true;
        };
        var insertDecisionObject = function (newDecisionObject) {
            if (workingDecision.decisionArray == undefined) {
                workingDecision.decisionArray = [newDecisionObject];
            }
            else {
                workingDecision.decisionArray.push(newDecisionObject);
            }
            return true;
        };

        return {
            insertDecision: insertDecision,
            updateDecision: updateDecision,
            getDecision: getDecision,
            insertCriteria: insertCriteria,
            insertDecisionObject: insertDecisionObject
        };
    });