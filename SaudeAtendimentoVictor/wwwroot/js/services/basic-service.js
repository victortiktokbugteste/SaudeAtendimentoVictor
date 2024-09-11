app.factory("basicService", ["$http", function ($http) {

    const headers = {
        'Content-Type': 'application/json'
    };

    return {        
        salvarPaciente: function (param) {
            return $http.post("/Paciente/CadastrarPaciente", param, headers);
        },
        obterPacientes: function () {
            return $http.get("/Paciente/ObterPacientes");
        },
        excluirPaciente: function (param) {
            return $http.post("/Paciente/ExcluirPaciente", param, headers);
        },
        obterEspecialidades: function () {
            return $http.get("/Triagem/ObterEspecialidades");
        },
        salvarTriagem: function (param) {
            return $http.post("/Triagem/SalvarTriagem", param, headers);
        },
        obterTriagens: function () {
            return $http.get("/Triagem/ObterTriagens");
        },
        obterAtendimentos: function () {
            return $http.get("/Atendimento/ObterAtendimentos");
        },
        obterStatus: function () {
            return $http.get("/Atendimento/ObterStatus");
        },
        salvarAtendimento: function (param) {
            return $http.post("/Atendimento/SalvarAtendimento", param, headers);
        },
    };

}]);