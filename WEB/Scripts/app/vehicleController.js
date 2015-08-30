CA.Controllers.controller('vehicleController', ['$scope', '$http', function ($scope, $http) {

    $scope.resource = {};
    $scope.pageName = "Vehicle";
    $http.get('/api/values/Vehicle/1').then(function (success) {
        $scope.resource = success.data.Resource;

        if ($scope.resource.Year!='') {
            $scope.getMakes();
        }
        
    }, function (error) {
        $scope.data = error.resource;
    });

    $scope.save = function () {
        $http.post('/api/values/Vehicle', $scope.resource).then(function (success) {
            $scope.result = "Success";
        }, function (error) {
            $scope.result = error;
        });
    };
   
    $scope.getMakes = function () {

        $http.get('/api/values/lookup/Getmakes/' + $scope.resource.Year).then(function (success) {
            $scope.yearMake = success;
        }, function (error) { console.log(error); });

    };

    $http.get('/api/values/lookup/GetYears').then(function (success) {
        $scope.yearLookup = success;
    }, function (error) { console.log(error); });

    $scope.getmodles = function () {
        $http.get('/api/values/lookup/GetModel/' + $scope.resource.Year + '/' + $scope.resource.Make).then(function (success) {
            $scope.YearMakeModel = success;
        }, function (error) { console.log(error); });
    };
    if ($scope.resource.Year) {
        getMakes();
    }


}]);