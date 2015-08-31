CA.Controllers.controller('userController', ['$scope', '$http', '$location', function ($scope, $http, $location) {

    $scope.resource = {};
    $scope.pageName = "Customer";

    $http.get('/api/values/Customer/iclicq').then(function (success) {
        $scope.resource = success.data.Resource;

    }, function (error) {
        $scope.data = error.resource;
    });

    $scope.save = function () {
        $http.post('/api/values/Customer/iclicq', $scope.resource).then(function (success) {
            $scope.result = "Success";
            $location.path('/vehicle/icliq');
        }, function (error) {
            $scope.result = error;
        });
    };   
}]);



