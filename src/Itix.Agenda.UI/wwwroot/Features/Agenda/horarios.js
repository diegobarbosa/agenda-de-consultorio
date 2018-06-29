//-------------------------HORARIOS-------------------------------------------//


const horarios = {
    template: `


<h2 style='margin-bottom:20px; padding-bottom:5px; border-bottom: 1px solid #e3e3e3;'> Consultas do Dia <b> {{ $ctrl.currentDate | date }} </b> </h2>    

    <span style='font-weight:bold;'  ng-show='$ctrl.atendimentos.length > 0'>{{$ctrl.atendimentos.length}} consulta(s)</span>
    
<table class='table table-striped table-condensed table-hover ' ng-show='$ctrl.atendimentos.length > 0'>
    <tr>
        <th class='center' style='width:100px'>Horário</th>
        <th class='center' style='width:70px'> Status </>        
        <th>Paciente</th>
        <th style='width:180px'>Observação</th>
        <th class='center' style='width:100px'> Ações </th>
    </tr>

    <tr ng-repeat="atendimento in $ctrl.atendimentos" >
        <td class='center'>{{atendimento.dataInicial | date:'HH:mm'}} - {{atendimento.dataFinal | date:'HH:mm'}} </td>
        <td class='center'> <span style="color:{{$ctrl.statusCor(atendimento.status)}}"> {{atendimento.status}} </span>   </td>    
        <td>{{atendimento.pacienteNome}}</td>
        <td>{{atendimento.observacao}}</td>

      
        <td class='center'> 

            <a href='#' ng-click="$ctrl.abrirAtendimentoModalParaEdicao({ atendimento: atendimento})"> 
                <i class='glyphicon glyphicon-edit'  uib-tooltip="Alterar" ></i> 
            </a> 

            <span style='padding-left:5px;padding-right:5px'>|</span>

             <a href='#' ng-click="$ctrl.compareceuAtendimento({ atendimento: atendimento})"> 
                <i class='glyphicon glyphicon-ok'  uib-tooltip="Compareceu" ></i> 
            </a> 

              <span style='padding-left:5px;padding-right:5px'>|</span>

            <a href='#' text='Cancelar' ng-click="$ctrl.cancelarAtendimento({ atendimento: atendimento})"> 
                <i class='glyphicon  glyphicon-trash' uib-tooltip="Cancelar" ></i> 
            </a> 


           </td>   
    </tr>


    </table>


        <div class='well' style='font-weight:bold; text-align:center ' ng-show='$ctrl.atendimentos.length == 0'>
            Nenhuma Consulta marcada para este dia.
        </div>





`
    ,
    bindings: {
        atendimentos: '<',
        currentDate: '<',
        cancelarAtendimento: '&',
        compareceuAtendimento: '&',
        abrirAtendimentoModalParaEdicao:'&'

    }

    , controller() {
        var $ctrl = this

        //$ctrl.$onInit = () => {

        //};

        $ctrl.statusCor = function (status) {

            if (status==='MARC') {
                return 'blue'
            }

            if (status === 'CANC') {
                return 'red'
            }

            if (status === 'COMP') {
                return 'green'
            }

        }



    }

}

mod.component('horarios', horarios);