CA.Controllers.controller("driverController",['$scope', '$http', '$location', function ($scope, $http, $location){

    $scope.resource = {};
    $scope.pageName = "Driver";

    $http.get('/api/values/Driver/iclicq').then(function (success) {
        $scope.resource = success.data.Resource;

    }, function (error) {
        $scope.data = error.resource;
    });
}]);