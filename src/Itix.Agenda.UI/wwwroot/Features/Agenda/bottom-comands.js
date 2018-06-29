var bottomCommands = {
    template: `
  <div class='well well-sm'>
        <button class='btn btn-primary' ng-click="$ctrl.abrirCadastrarAtendimentoModal()"> 
            <i class='glyphicon glyphicon-plus-sign'></i> 
            Agendar novo Atendimento
        </button>
    </div>
            `,

    bindings: {
        currentDate: '<',
        cadastrarAtendimento:'&'
    },

    controller: function ($uibModal, $log)
    {
        var $ctrl = this

        $ctrl.$onInit = function () {

                $ctrl.dataForModal = {
                currentDate: $ctrl.currentDate
            }
        }

        

       

        $ctrl.animationsEnabled = true

       

        $ctrl.abrirCadastrarAtendimentoModal = function () {


            var modalInstance = $uibModal.open({
                animation: $ctrl.animationsEnabled,
                component: 'cadastrarAtendimento',
                resolve: {
                    modalData: function () {
                        return $ctrl.dataForModal;
                    }

                }
            });

            modalInstance.result.then(function (result) {
                $ctrl.modalResult = result;

                $ctrl.cadastrarAtendimento({ value: result })

                //$ctrl.dataForModal = angular.clone($ctrl.initialDataForModal)

            }, function () {
                $log.info('modal-component dismissed at: ' + new Date());

                //$ctrl.dataForModal = angular.clone($ctrl.initialDataForModal)


            });
        };
    }
}


mod.component('bottomCommands', bottomCommands);