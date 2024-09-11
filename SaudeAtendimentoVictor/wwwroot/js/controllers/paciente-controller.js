app.controller("pacienteController", ["$scope", "$window", "$http", "$filter", "basicService", "utilidadesService", function ($scope, $window, $http, $filter, basicService, utilidadesService) {

    $scope.entity = {};
    $scope.list = {
        pacientes: []
    };

    $scope.save_click = function () {
        $(".spinerStyle").addClass('centerSpinner');
        $(".spinerBackground").addClass('overlay');

        basicService.salvarPaciente($scope.entity).then(function (data) {

            var result = data.data;

            $scope.closeModal();

            if (result.success == true) {
                utilidadesService.exibirMensagem('Sucesso!', 'Paciente cadastrado com sucesso.', true);
            }
            else {
                utilidadesService.exibirMensagem('Falha', result.error, true);
            }

            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');

            $scope.obterPacientes();

        }, function (error) {
            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');
        });
    }

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

    $scope.adicionarPaciente = function () {
        $scope.entity = {};
        $('#myModal').modal('show');
    }


    $scope.closeModal = function () {
        $scope.entity = {};
        $('#myModal').modal('hide');
    }

    $scope.excluirPaciente = function (paciente) {

        $(".spinerStyle").addClass('centerSpinner');
        $(".spinerBackground").addClass('overlay');

        basicService.excluirPaciente(paciente).then(function (data) {

            var result = data.data;
            if (result.success == true) {
                utilidadesService.exibirMensagem('Sucesso!', 'Paciente excluído com sucesso.', true);
            }
            else {
                utilidadesService.exibirMensagem('Falha', result.error, true);
            }

            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');

            $scope.obterPacientes();

        }, function (error) {
            $(".spinerStyle").removeClass('centerSpinner');
            $(".spinerBackground").removeClass('overlay');
        });
    }


    $scope.init = function () {
        $scope.obterPacientes();
    }

    $scope.init();

}]);