var app = angular.module('myApp', ['ngMessages']);

app.controller('customCtrl', function ($scope) {
    $scope.newUser = {
        Password: ''
    };
});