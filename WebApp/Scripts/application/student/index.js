/* global angular: false */

(function (ng) {
    'use strict';

    ng.module('TestApp.student', [
        'ngRoute',
        'TestApp.student.controllers',
        'TestApp.student.models'
    ])
        .config([
            '$routeProvider',
            function ($routes) {
                $routes.when('/student/create', {
                    templateUrl: 'template/student/create.html',
                    controller: 'StudentCreateController',
                    controllerAs: 'StudentCreate'
                });
            }
        ]);

})(angular);