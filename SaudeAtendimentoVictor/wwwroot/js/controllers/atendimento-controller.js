app.controller("atendimentoController", ["$scope", "$window", "$http", "$filter", "basicService", "utilidadesService", function ($scope, $window, $http, $filter, basicService, utilidadesService) {

    $scope.entity = {
        pacienteID: {},
        statusID: {}
    };

    $scope.list = {
        atendimentos: [],
        pacientes: [],
        status: []
    };


    $scope.obterPacientes = function () {
        $(".spinerStyle").addClass('centerSpinner');
        $(".spinerBackground").addClass('overlay');

        basicService.obterPacientes().then(function (data) {

            $scope.list.pacientes = data.data;

            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');

        }, function (error) {
            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');
        });
    }

    $scope.obterStatus = function () {
        $(".spinerStyle").addClass('centerSpinner');
        $(".spinerBackground").addClass('overlay');

        basicService.obterStatus().then(function (data) {

            $scope.list.status = data.data;

            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');

        }, function (error) {
            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');
        });
    }

    $scope.save_click = function () {

        $(".spinerStyle").addClass('centerSpinner');
        $(".spinerBackground").addClass('overlay');

        basicService.salvarAtendimento($scope.entity).then(function (data) {

            var result = data.data;
            $scope.closeModal();

            if (result.success == true) {
                utilidadesService.exibirMensagem('Sucesso!', 'Atendimento cadastrado com sucesso.', true);
            }
            else {
                utilidadesService.exibirMensagem('Falha', result.error, true);
            }

            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');

            $scope.obterAtendimentos();

        }, function (error) {
            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');
        });
    }

    $scope.pintarLinha = function (atendimento) {
        return {
            'background-color': atendimento.status.nome == "Crítico" ? '#ffcccc' : '#B0E57C'
        };
    }

    $scope.obterAtendimentos = function () {
        $(".spinerStyle").addClass('centerSpinner');
        $(".spinerBackground").addClass('overlay');

        basicService.obterAtendimentos().then(function (data) {

            $scope.list.atendimentos = data.data;
            console.log($scope.list.atendimentos);

            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');

        }, function (error) {
            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');
        });
    }

    $scope.adicionarAtendimento = function () {
        $scope.entity = {};
        $('#myModal').modal('show');
    }


    $scope.closeModal = function () {
        $scope.entity = {};
        $('#myModal').modal('hide');
    }

    $scope.init = function () {
        $scope.obterPacientes();
        $scope.obterStatus();
        $scope.obterAtendimentos();
    }

    $scope.init();

}]);