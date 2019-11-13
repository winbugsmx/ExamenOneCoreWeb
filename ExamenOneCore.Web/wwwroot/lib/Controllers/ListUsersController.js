var app = angular.module('myApp', []);
var editUser;

app.controller('customCtrl', function ($scope, $http) {
    $http.get("user/GetUsers")
        .then(function (response) {
            $scope.users = response.data;
        });

    $scope.GetUser = function (index) {
        editUser = $scope.users[index]
        var status = (editUser.Estatus == true) ? 'True' : 'False';
        $("#Username").val(editUser.Usuario);
        $("#Password").val(editUser.Password);
        $("#Email").val(editUser.Email);
        $('#Sexo').val(editUser.Sexo).attr("selected", "selected");
        $("#UserId").val(editUser.UserId);
        $("#Estatus").val(status).attr("selected", "selected");
    }

    $scope.Delete = function (index) {
        editUser = $scope.users[index]
        var status = (editUser.Estatus == true) ? 'True' : 'False';
        $("#Id").val(editUser.UserId);
    }
});

app.directive("compareTo", function () {
    return {
        require: "ngModel",
        scope: {
            confirmPassword: "=compareTo"
        },
        link: function (scope, element, attributes, modelVal) {
            modelVal.$validators.compareTo = function (val) {
                return val == scope.confirmPassword;
            };
            scope.$watch("ConfirmPassword", function () {
                modelVal.$validate();
            });
        }
    }
});