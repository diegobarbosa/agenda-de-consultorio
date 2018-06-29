var dateComp = {
    template: `
<p class="input-group">

<input 
    type="text" 
    class="form-control"  
    ng-model="$ctrl.ngModel" 
    uib-datepicker-popup="dd/MM/yyyy" 
    is-open="$ctrl.isOpen"
    datepicker-options="$ctrl.dateOptions"
    clear-text="Limpar"
    close-text="Fechar"
    current-text="Hoje"
/>

<span class="input-group-btn">
   <button type="button" class="btn btn-default" 
    ng-click="$ctrl.open()">
    <i class="glyphicon glyphicon-calendar"></i>
    </button>
 </span>

</p>
`,
    bindings: {
        ngModel:'='
    },

    controller: function () {
        var $ctrl = this

        $ctrl.$onInit = function () {

            $ctrl.dateOptions = {
                initDate: $ctrl.ngModel,
                startingDay: 1
            };

                    }

      


        $ctrl.isOpen = false

        $ctrl.open = function () {
            $ctrl.isOpen = !$ctrl.isOpen
        }

    }
}


mod.component('date', dateComp);