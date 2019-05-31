app.controller('employeeController', ['$scope', '$http', function ($scope, $http) {

    $scope.getEmployees = function () {
        $http({
            method: 'POST',
            url: 'GetAllEmployees'
        }).
            then(function (response) {
                $scope.employees = response.data;
                $scope.gridOptions.data = $scope.employees;
            });
    };

    $scope.gridOptions = {
        enableSorting: true,
        enableFiltering: true,
        paginationPageSizes: [5, 10, 20],
        paginationPageSize: 5,
        columnDefs: [
            { name: 'EmpId', visible: false },
            { name: '#', maxWidth: 80, enableFiltering: false, enableSorting: false, cellTemplate: '<span>{{rowRenderIndex+1}}</span>' },
            { name: 'Name' },
            { name: 'Address', enableFiltering: false, cellTemplate: '<city-is></city-is>' },
            { name: 'PhoneNumber', enableFiltering: false, },
            { name: 'DeptId', enableFiltering: false, cellTemplate: '<span>{{ row.entity.DeptId | getDeptName }}</span>' },
            { name: 'Department.Name', displayName: 'Department' },
            {
                name: 'Actions',
                enableFiltering: false, enableSorting: false,
                cellTemplate: '<span ng-click="grid.appScope.details(row)" class="glyphicon glyphicon-search"></span> | <span ng-click="grid.appScope.edit(row)" class= "glyphicon glyphicon-edit" ></span> | <span ng-click="grid.appScope.delete(row)" class="glyphicon glyphicon-trash"></span>'
            }
        ]
    };
    
    $scope.create = function () {
        $http({
            method: 'GET',
            url: 'Create'
        })
            .then(function () {
                window.location = 'Create';
            });
    };

    $scope.details = function (row) {
        $http({
            method: 'GET',
            url: 'Details?id=' + row.entity.EmpId
        })
            .then(function () {
                window.location = 'Details?id=' + row.entity.EmpId;
            });
    };

    $scope.edit = function (row) {
        $http({
            method: 'GET',
            url: 'Edit?id=' + row.entity.EmpId
        })
            .then(function () {
                window.location = 'Edit?id=' + row.entity.EmpId;
            });
    };

    $scope.delete = function (row) {
        $http({
            method: 'GET',
            url: 'Delete?id=' + row.entity.EmpId
        })
            .then(function () {
                window.location = 'Delete?id=' + row.entity.EmpId;
            });
    };
}]);

app.filter('getDeptName', function () {
    return function (DeptId) {
        switch (DeptId) {
            case 1:
                return DeptId + '- IT';
            case 2:
                return DeptId + '- HR';
            case 3:
                return DeptId + '- Payroll';
        }
    };
});

app.directive('cityIs', function () {
    var directive = {};

    directive.restrict = 'E';
    directive.template = "<span class='text-info'><i>City - {{row.entity.Address}}</i></span>";

    return directive;
});