/* global _: false, angular: false */

(function (_, ng) {
    'use strict';

    ng.module('TestApp.student.models').provider('blStudent', [Student]);

    function Student() {
        var url = 'api/students';

        this.$get = [
            '$http', function ($http) {
                return {
                    create: function (student) {
                        console.log(student);
                        console.log(url);
                        return $http.post(url, student);
                    }
                };
            }
        ];
    }

    

})(_, angular);