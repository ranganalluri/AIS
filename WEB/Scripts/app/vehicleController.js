﻿CA.Controllers.controller('vehicleController', ['$scope', '$http', function ($scope, $http) {

    $scope.resource = {};
    $scope.pageName = "Vehicle";
    $scope.vehicleSummary=null;
    $http.get('/api/values/Vehicle/iclicq').then(function (success) {
        $scope.resource = success.data.Resource.Vehicle;
        $scope.vehicleSummary = success.data.Resource.VehcileSummary;
        if ($scope.resource != null && $scope.resource.Vehicle != null && $scope.resource.Vehicle.Year != '') {
            $scope.getMakes();
        }
        
    }, function (error) {
        $scope.data = error.resource;
    });

    
    $scope.save = function () {
        $http.post('/api/values/Vehicle/iclicq', $scope.resource).then(function (success) {
            $scope.result = "Success";
            $scope.resource = success.data.Resource.Vehicle;
            $scope.vehicleSummary = success.data.Resource.VehcileSummary;
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