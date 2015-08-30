CA.App.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
   
    $routeProvider.
         when('/customer/icliq', {
             templateUrl: '/Home/GetPartialView/?name=_customer',
             controller: 'userController'
         }).
        when('/routehandler', {
            templateUrl: '/Home/GetPartialView/?name=_routehandler',
            controller: 'baseController'
        }).
         when('/vehicle/icliq', {
             templateUrl: '/Home/GetPartialView/?name=_vehicle',
             controller: 'vehicleController'
         }).
        when('/vehicle/:id/icliq', {
            templateUrl: '/Home/GetPartialView/?name=_vehicle',
            controller: 'vehicleController'
        }).
       
        otherwise({ redirectTo: '/routehandler' });

    $locationProvider.html5Mode(false).hashPrefix('/sales');
}]);