app.controller('teacherController', function ($scope, teacherService) {

    getTeachers();
    function getTeachers() {
        teacherService.getTeachers()
            .then(function (teacher) {
                $scope.teachers = teacher.data;
                $scope.gridOptions.data = $scope.teachers;
                console.log($scope.teachers);
            }, function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }

    $scope.gridOptions = {
        enableSorting: true,
        columnDefs: [
            { name: 'FirstName' },
            { name: 'LastName' },
            { name: 'PhoneNumber', enableSorting: false },
            { name: 'Courses', enableSorting: false, cellTemplate: '<span class="alert-info" ng-repeat="course in row.entity.Courses">{{course.Name }} | </span>' }]
    };
});

app.service('teacherService', ['$http', function ($http) {

    var teacherService = {};
    teacherService.getTeachers = function () {
        return $http.get('/Teacher/GetTeachers');
    };
    return teacherService;
}]);