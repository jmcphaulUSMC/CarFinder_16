
app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('cars', {
            url: '/',
            templateUrl: 'Index.html',
            controller: 'ctrAppCar'
        })
        .state('home', {
            url: '/home',
            templateUrl: 'App/Templates/Home.html',
            controller: 'HomeController' 
        })
        .state('about', {
            url: '/aboutpage',
            templateUrl: 'App/Templates/About.html',
            controller: 'AboutController'
        })
        .state('contact', {
            url: '/contactpage',
            templateUrl: 'App/Templates/Contact.html',
            controller: 'ContactController'
        })
        //.state('apiHelp', {
        //    url: '/apihelp',
        //    templateUrl: 'App_Data',
        //    controller: 'ApiHelpController'
        //})

}]);