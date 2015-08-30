var CA = CA || {};

CA.App = angular.module("CA.App", ['ngRoute', 'CA.undescore', 'CA.Controllers', 'CA.Filters', 'CA.Factory']);

CA.undescore = angular.module("CA.undescore", []);

CA.undescore.service('_', function () {
    return window._;
});


CA.Services = angular.module("CA.Services",[]);

CA.Factory = angular.module("CA.Factory",[]);

CA.Controllers = angular.module("CA.Controllers",[]);

CA.Filters = angular.module("CA.Filters",[]);








