var app = angular.module("myApp", ['ngSanitize', 'ui.select', 'ngTouch', 'ui.bootstrap', 'angular-loading-bar', 'ngAnimate', 'ngAria', 'ngMaterial'])
    .config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
        cfpLoadingBarProvider.parentSelector = '#loading-bar-container';
        cfpLoadingBarProvider.spinnerTemplate = '<div style=text-align:center;><img src="/Spinerr.svg"/ height="100px"></div>';
    }]);


app.config(['uiSelectConfig', function (uiSelectConfig) {
    uiSelectConfig.theme = 'selectize';
}]);





