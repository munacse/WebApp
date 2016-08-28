
(function () {
    'use strict';

    angular
   .module('TestApp.student.controllers')
   .controller('StudentCreateController', ['blStudent', StudentCreateController]);

    function StudentCreateController(Student) {

        var vm = this;
        vm.submitForm = function () {
            

            if (vm.userForm.$invalid) {
                return;
            }
            Student.create(vm.user).then(function () {
                alert(vm.user.username + ',' + vm.user.phone + ',' + vm.user.email);
            }, function (response) {
                //$scope.modelStates = response &&
                //    response.status === 400 &&
                //    response.data &&
                //    response.data.modelState;
            });
        }
    }

})();
