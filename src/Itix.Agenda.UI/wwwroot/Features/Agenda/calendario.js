
const calendario = {
    template: `<div>
                
        <h3 class='center'>Selecione o Dia</h3>

            <div uib-datepicker ng-model="$ctrl.date" ng-change="$ctrl._onSelectedDate()"  ></div>

        </div>`,

    bindings: {
        date: '<',
        onSelectedDate: '&'
    },


    controller($scope) {
        var $ctrl = this

        //$ctrl.$onInit = () => {
        //    $scope.$watch(() => '$ctrl.date', () => $ctrl._onSelectedDate());
        //};

        $ctrl.$onInit = () => {
            $ctrl._onSelectedDate() // Dispara o evento pois uma data inicial é obrigatória.
                                    // Assim, o componete já incia um evento com o valor inicial
        };

        $ctrl._onSelectedDate = function () {//Ocorre quando uma data é selecionada
           
            $ctrl.onSelectedDate({ date: $ctrl.date })

        }

    }
};


mod.component('calendario', calendario);