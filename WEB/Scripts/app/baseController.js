CA.Controllers.controller('baseController', ['$scope', '$http', '$location', function ($scope, $http, $location) {

    var url = $('#baseUrl').val();
    console.log(url);
    $location.path(url);
    // $location.path('/customer/icliq');
}]);