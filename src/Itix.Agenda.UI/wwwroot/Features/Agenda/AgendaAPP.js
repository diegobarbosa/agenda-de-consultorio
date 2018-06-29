
var mod = angular.module('agenda',
    ['ui.bootstrap',
        'angular-ladda',
        'ui-notification',
        //'ngMask',
        'ui.mask',
        'ui.dateTimeInput',
        'ngLocale'
    ])

mod.directive('enter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                event.preventDefault();
                var fields = $(this).parents('form:eq(0),body').find('input, textarea, select');
                var index = fields.index(this);
                if (index > -1 && (index + 1) < fields.length)
                    fields.eq(index + 1).focus();
            }
        });
    };
});


mod.config(function (NotificationProvider) {
    NotificationProvider.setOptions({
        delay: 5000,
        startTop: 20,
        startRight: 10,
        verticalSpacing: 20,
        horizontalSpacing: 20,
        positionX: 'right',
        positionY: 'top'
    });
});

//-------------------------AGENDA-------------------------------------------//

const agenda = {
    template: `
<div class="row">

<div class="col-sm-4" style='padding-left:40px;'>
    <calendario date="$ctrl.initialDate" on-selected-date="$ctrl.onSelectedDate(date)" > </calendario>
</div>

<div class="col-sm-8">


<div style="padding-left:30px; border-left: 1px solid #ddd; min-height:500px">

    <horarios 
        current-date="$ctrl.currentDate" 
        atendimentos="$ctrl.atendimentos" 
        cancelar-atendimento="$ctrl.cancelarAtendimento(atendimento)"
        cadastrar-atendimento ="$ctrl.cadastrarAtendimento($value)"
        compareceu-atendimento = "$ctrl.compareceuAtendimento(atendimento)"
        abrir-atendimento-modal-para-edicao = "$ctrl.abrirAtendimentoModalParaEdicao(atendimento)"

        > </horarios>

<br/>
<br/>
        
    <div class='well well-sm'>
        <button class='btn btn-primary' ng-click="$ctrl.abrirAtendimentoModalParaCadastro()"> 
            <i class='glyphicon glyphicon-plus-sign'></i> 
            Marcar nova Consulta
        </button>
    </div>


</div>


        
</div>

</div>

`,

    controller($http, Notification, $uibModal) {
        var $ctrl = this

        $ctrl.currentDate = $ctrl.initialDate = new Date()


        $ctrl.onSelectedDate = (date) => {

            $ctrl.loadHorarios(date)
            $ctrl.currentDate = date
           
        };


        $ctrl.cancelarAtendimento = function (atendimento) {
          

            $http({
                method: 'PUT',
                url: '/api/atendimentos/' + atendimento.idAtendimento + '/cancelar/',
                ngSpin: true

            }).then(function successCallback(response) {

                Notification.success({ message: 'Seus dados foram salvos com sucesso' });

                $ctrl.loadHorarios($ctrl.currentDate)


            }, function errorCallback(response) {
              

                Notification.error({ message: response.data[0].message });

            });

        }


        $ctrl.compareceuAtendimento = function (atendimento) {
            $http({
                method: 'PUT',
                url: '/api/atendimentos/' + atendimento.idAtendimento + '/compareceu/',
                ngSpin: true

            }).then(function successCallback(response) {

                Notification.success({ message: 'Seus dados foram salvos com sucesso' });

                $ctrl.loadHorarios($ctrl.currentDate)


            }, function errorCallback(response) {
              

                Notification.error({ message: response.data[0].message });

            });
        }


        $ctrl.cadastrarAtendimento = function (value) {

           

            var command = {
                pacienteNome: value.pacienteNome,
                pacienteDataNascimento: setHoras(value.pacienteDataNascimento, "00:00"),
                horario: {
                    dataInicial: setHoras(value.dataInicial, value.horaInicial),
                    dataFinal: setHoras(value.dataFinal, value.horaFinal)
                },
                observacao: value.observacao
            }

           


            return new Promise((resolve, reject) => {

                $http({
                    method: 'POST',
                    url: '/api/atendimentos/',
                    data: command

                }).then(function successCallback(response) {

                    Notification.success({ message: 'Seus dados foram salvos com sucesso' });

                    resolve()

                    $ctrl.loadHorarios($ctrl.currentDate)

                }, function errorCallback(response) {

                    reject()

                    Notification.error({ message: response.data[0].message });
                });

            });


        }


        $ctrl.alterarAtendimento = function (value, successCallBack) {


            var command = {

                pacienteNome: value.pacienteNome,
                pacienteDataNascimento: moment(value.pacienteDataNascimento).format(),
                horario: {
                    dataInicial: setHoras(value.dataInicial, value.horaInicial),
                    dataFinal: setHoras(value.dataFinal, value.horaFinal)
                },
                observacao: value.observacao
            }

          

            return new Promise((resolve, reject) => {

                $http({
                    method: 'PUT',
                    url: '/api/atendimentos/' + value.idAtendimento,
                    data: command

                }).then(function successCallback(response) {

                    Notification.success({ message: 'Seus dados foram salvos com sucesso' });

                    resolve()

                    $ctrl.loadHorarios($ctrl.currentDate)

                }, function errorCallback(response) {

                    reject()

                    Notification.error({ message: response.data[0].message });
                });

            });


        }


        $ctrl.loadHorarios = function (date) {


            $http({
                method: 'GET',
                url: '/api/atendimentos/dia/' + moment(date).format('YYYY-MM-DD'),
                ngSpin: true

            }).then(function successCallback(response) {
                $ctrl.atendimentos = response.data


            }, function errorCallback(response) {
               
                Notification.error({ message: response.data[0].message });
            });



        }


        $ctrl.abrirAtendimentoModalParaCadastro = function () {

            var atendimentoVM = {
                currentDate: $ctrl.currentDate
            }

            $ctrl.abrirAtendimentoModal(atendimentoVM, $ctrl.cadastrarAtendimento)
        }


        $ctrl.abrirAtendimentoModalParaEdicao = function (atendimento) {



            var atendimentoVM = {
                idAtendimento: atendimento.idAtendimento,
                currentDate: $ctrl.currentDate,
                pacienteNome: atendimento.pacienteNome,
                pacienteDataNascimento: atendimento.pacienteDataNascimento,
                horaInicial: moment(atendimento.dataInicial).format("HH:mm"),
                horaFinal: moment(atendimento.dataFinal).format("HH:mm"),
                observacao: atendimento.observacao
            }

            $ctrl.abrirAtendimentoModal(atendimentoVM, $ctrl.alterarAtendimento)
        }


        $ctrl.abrirAtendimentoModal = function (atendimentoVM, salvar) {


            var modalInstance = $uibModal.open({
                animation: $ctrl.animationsEnabled,
                //component: 'cadastrarAtendimento',
                template: `<cadastrar-atendimento 
                            modal-instance = "$modal.modalInstance"
                          
                            salvar="$modal.salvar(atendimentoVM)"
                            atendimento-model="$modal.atendimentoModel"            
                            
                            >
                            </cadastrar-atendimento>`,

                controllerAs: '$modal',
                controller: function ($uibModalInstance) {
                    var $modal = this
                    $modal.modalInstance = $uibModalInstance

                    $modal.atendimentoModel = atendimentoVM
                   
                    $modal.salvar = salvar

                },

            });

        };




        function setHoras(data, hora) {
            hora = hora == undefined ? "00:00" : hora
            var time = hora.split(':')
            
           // return moment(data, "DD/MM/YYYY").set({ hour: time[0], minute: time[1], second: 0, millisecond: 0 }).format()

            var data = moment(data, "DD/MM/YYYY")

            var result = moment(data.format("YYYY-MM-DD") + ' ' + hora)
           
            return result.isValid() ? result.format() : "invalid";
        }



    }

}


mod.component('agenda', agenda);

//mod.value('$routerRootComponent', 'agenda');