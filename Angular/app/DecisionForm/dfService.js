
angularFormsApp.factory('dfService',
    function () {
        return {
            decision: {
                sessionName: "testData",
                decisionArray: [
                    {
                        name: "iPhone",
                        criteriaArray: [
                            {
                                name: "design",
                                rate: 1,
                                value: "1",
                                valueRate: 1
                            },
                            {
                                name: "price",
                                rate: 1,
                                value: "1",
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
                                value: "1",
                                valueRate: 1
                            },
                            {
                                name: "price",
                                rate: 1,
                                value: "1",
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
                                value: "1",
                                valueRate: 1
                            },
                            {
                                name: "price",
                                rate: 1,
                                value: "1",
                                valueRate: 1
                            }
                        ]
                    }
                ]
            }
        };
    });