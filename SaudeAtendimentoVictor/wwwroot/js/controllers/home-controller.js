app.controller("HomeController", ["$scope", "$window", function ($scope, $window) {

    $scope.filter = {
        Category: {},
    };

    $scope.list = {
        categories: [
            {
                id: 1,
                name: 'Pacientes',
                icon: '/img/paciente.png'
            },
            {
                id: 2,
                name: 'Atendimento',
                icon: '/img/linha.png'
            },
            {
                id: 3,
                name: 'Triagens',
                icon: '/img/candidato.png'
            },
        ]
    };  

    $scope.EntrarNaTela = function () {
        if ($scope.filter.Category.id == 1) { 
            $window.location.href = "/Paciente/Index";
        }
        else if ($scope.filter.Category.id == 2) {
            $window.location.href = "/Atendimento/Index";
        }
        else { 
            $window.location.href = "/Triagem/Index";
        }
    }

}]);