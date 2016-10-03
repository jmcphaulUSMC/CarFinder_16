﻿app.service('svcAppCar', ['$http', function ($http) {
    this.HCLYears = function () {
        return $http.get('/api/Cars/Years')
            .then(function (response) { return response.data; });
    };

    this.HCLMakes = function (year) {
        var options = { params: { _year: year } };
        return $http.get('/api/Cars/Makes', options)
            .then(function (response) { return response.data; });
    };

    this.HCLModels = function (year, make) {
        var options = { params: { _year: year, _make: make } };
        return $http.get('/api/Cars/Model', options)
            .then(function (response) { return response.data; });
    };

    this.HCLTrims = function (year, make, model) {
        var options = { params: { _year: year, _make: make, _model_name: model } };
        return $http.get('/api/Cars/GetTrim', options)
            .then(function (response) { return response.data; });
    };

    this.HCLCars = function (year, make, model, trim) {
        var options = { params: { _year: year, _make: make, _model_name: model, _model_trim: trim } };
        return $http.get('/api/Cars/GetCar', options)
            .then(function (response) {
                return response.data;
            });
    };

    this.HCLCar = function (year, make, model, trim) {
        var options = { params: { year: year, make: make, model: model, trim: trim } };
        return $http.get('/api/Cars/Car', options)
            .then(function (response) {
                return response.data;
            });
    };

}]);