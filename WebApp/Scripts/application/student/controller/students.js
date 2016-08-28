(function () {
    'use strict';

    angular
       .module('TestApp.student.controllers')
       .controller('StudentController', [StudentsController]);

    function StudentsController() {

        var vm = this;
        vm.Name = 'Muna';
    }


})();
