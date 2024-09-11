app.controller("triagemController", ["$scope", "$window", "$http", "$filter", "basicService", "utilidadesService", function ($scope, $window, $http, $filter, basicService, utilidadesService) {

    $scope.entity = {
        especialidadeID: {},
        atendimentoID: {}
    };
    $scope.list = {
        triagens: [],
        especialidades: [],
        atendimentos: []
    };

    $scope.save_click = function () {

        $(".spinerStyle").addClass('centerSpinner');
        $(".spinerBackground").addClass('overlay');

        basicService.salvarTriagem($scope.entity).then(function (data) {

            var result = data.data;

            $scope.closeModal();

            if (result.success == true) {
                utilidadesService.exibirMensagem('Sucesso!', 'Triagem cadastrada com sucesso.', true);
            }
            else {
                utilidadesService.exibirMensagem('Falha', result.error, true);
            }

            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');

            $scope.obterTriagens();

        }, function (error) {
            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');
        });
    }

    $scope.obterTriagens = function () {
        $(".spinerStyle").addClass('centerSpinner');
        $(".spinerBackground").addClass('overlay');

        basicService.obterTriagens().then(function (data) {

            $scope.list.triagens = data.data;

            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');

        }, function (error) {
            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');
        });
    }

    $scope.obterEspecialidades = function () {
        $(".spinerStyle").addClass('centerSpinner');
        $(".spinerBackground").addClass('overlay');

        basicService.obterEspecialidades().then(function (data) {

            $scope.list.especialidades = data.data;

            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');

        }, function (error) {
            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');
        });
    }

    $scope.obterAtendimentos = function () {
        $(".spinerStyle").addClass('centerSpinner');
        $(".spinerBackground").addClass('overlay');

        basicService.obterAtendimentos().then(function (data) {

            $scope.list.atendimentos = data.data;

            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');

        }, function (error) {
            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');
        });
    }

    $scope.adicionarTriagem = function () {
        $scope.entity = {};
        $('#myModal').modal('show');
    }


    $scope.closeModal = function () {
        $scope.entity = {};
        $('#myModal').modal('hide');
    }


    $scope.init = function () {
        $scope.obterTriagens();
        $scope.obterEspecialidades();
        $scope.obterAtendimentos();
    }

    $scope.init();

}]);