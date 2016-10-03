app.controller('ctrAppCar', ['$scope', 'svcAppCar', function ($scope, svcAppCar) {
    var vm = this;

    $scope.selectedYear = '';
    $scope.selectedMake = '';
    $scope.selectedModel = '';
    $scope.selectedTrim = '';

    $scope.years = [];
    $scope.makes = [];
    $scope.models = [];
    $scope.trims = [];


    $scope.getYears = function () {
        svcAppCar.HCLYears().then(function (data) {
            $scope.years = data;
        });
    };

    //This line pre fills the years dropdown
    $scope.getYears();

    $scope.getMakes = function () {
        svcAppCar.HCLMakes($scope.selectedYear).then(function (data) {
            $scope.makes = data;
        });
    };

    $scope.getModels = function () {
        svcAppCar.HCLModels($scope.selectedYear, $scope.selectedMake).then(function (data) {
            $scope.models = data;
        });
    };

    $scope.getTrims = function () {
        svcAppCar.HCLTrims($scope.selectedYear, $scope.selectedMake, $scope.selectedModel).then(function (data) {
            $scope.trims = data;
        });
    };

    $scope.getCars = function () {
        svcAppCar.HCLCar($scope.selectedYear, $scope.selectedMake, $scope.selectedModel, $scope.selectedTrim).then(function (data) {
            $scope.cars = data;
        });
    };


}]);