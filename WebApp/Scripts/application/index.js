
/* global angular: false */

(function(ng) {
    ng.module('TestApp', [
            'ngRoute',
            'ngAnimate',
            'ui.select2',
            'ui.bootstrap',
            'TestApp.student'
    ])
        .config([
            '$routeProvider', function($routeProvider) {
                $routeProvider.when('/', {
                    templateUrl: 'template/dashboard/dashboard.html',
                });
                $routeProvider.when('/contact', {
                    templateUrl: 'template/about/about.html',
                });
                $routeProvider.when('/aboutme', {
                    templateUrl: 'template/contact/contact.html',
                });
                $routeProvider.when('/student', {
                    templateUrl: 'template/student/studentList.html',
                    controller: 'StudentController',
                    controllerAs: 'Student'
                });
                
                $routeProvider.otherwise('/');
            }
        ]);
})(angular)