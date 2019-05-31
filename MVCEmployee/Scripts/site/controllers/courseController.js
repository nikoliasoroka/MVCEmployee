app.controller('courseController', function ($scope, courseService) {

    getCourses();
    function getCourses() {
        courseService.getCourses()
            .then(function (course) {
                $scope.courses = course.data;
                $scope.gridOptions.data = $scope.courses;
                console.log($scope.courses);
            }, function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }

    $scope.gridOptions = {
        enableSorting: true,
        columnDefs: [
            { name: 'Name', maxWidth: 120 },
            { name: 'Location', maxWidth: 120 },
            { name: 'Teachers', enableSorting: false, cellTemplate: '<span class="alert-info" ng-repeat="teacher in row.entity.Teachers">{{teacher.FirstName + \' \' + teacher.LastName}} | </span>' }]
    };
});

app.service('courseService', ['$http', function ($http) {

    var courseService = {};
    courseService.getCourses = function () {
        return $http.get('/Course/GetCourses');
    };
    return courseService;
}]);