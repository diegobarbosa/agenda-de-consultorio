

var cadastrarAtendimento = {

    template: `
<div class=''>

<div class="modal-header">
    <h3 class="modal-title" id="modal-title"> Marcar Consulta em {{$ctrl.modalData.currentDate | date:'dd/MM/yyyy'}}
<div style='float:right; padding:0px;height: 35px;line-height: 10px;'>
 <span style='font-size:9px'>*Enter funciona como Tab</span> <br/>
 <span style='font-size:9px'>*Borda vemelha indica campo obrigatório </span> 
</div>

</h3>
</div>

<form name="frmConsulta" method="post">

<div class="modal-body" id="modal-body">

<table>
<tr>
    <td style='text-align:right; '>Paciente:</td> 
    <td> <input type="text" 
class='form-control obrigatorio' 
style='width:350px' 
ng-model="$ctrl.modalData.pacienteNome" 
id='pacienteNome' 
name = 'pacienteNome' 
enter
ng-required="true"
 ng-maxlength="100"
/> 


</td> 
</tr>

<tr> <td> </td> <td> <p ng-show="frmConsulta.pacienteNome.$invalid && !frmConsulta.pacienteNome.$pristine" class="help-block">Nome é obrigatório</p> </td></tr>


<tr>
    <td style='text-align:right'>Data de Nascimento:</td> 
    <td> 
<input type="text" 
name = 'pacienteDataNascimento'
class='form-control obrigatorio' 
style='width:100px' 

ui-mask="99/99/9999" 
ui-mask-placeholder-char="_"
model-view-value="true"  
ng-required="true"
data-date-time-input="DD/MM/YYYY"

ng-model="$ctrl.modalData.pacienteDataNascimento" 
enter
/>



</td> 

</tr>

<tr> <td></td> <td> 

<p ng-show="frmConsulta.pacienteDataNascimento.$invalid && !frmConsulta.pacienteDataNascimento.$pristine" 
    class="help-block">Data de Nascimento é obrigatório</p>
</td> </tr>

<tr><td style='text-align:right'> Horário:</td>  

    <td> <input type='text' 
            name='horaInicial' 
            class='campo center obrigatorio' 
            ng-model="$ctrl.modalData.horaInicial" 
            ui-mask="99:99"  
            model-view-value="true" 
            ui-mask-placeholder-char="_"
            ng-required="true"
            style='width:90px' 
            enter 
            
                /> 

até
         
<input type='text' 
            name='horaFinal' 
            class='campo center obrigatorio' 
            ng-model="$ctrl.modalData.horaFinal"  
            ui-mask="99:99"  
            model-view-value="true" 
            ui-mask-placeholder-char="_"
            ng-required="true"
            style='width:90px' 
enter/>

</td> </tr>

<tr>
<td></td>
<td>

<p ng-show="(frmConsulta.horaInicial.$invalid && !frmConsulta.horaInicial.$pristine) 
|| (frmConsulta.horaFinal.$invalid && !frmConsulta.horaFinal.$pristine)" 
class="help-block">Hora Inicial e Final são obrigatórios</p>

</td>

</tr>



</table>

<br/>


<br/>
Observação:<br/>
<textarea 
    name='observacao'
    class="form-control"  
    ng-model="$ctrl.modalData.observacao" 
    rows="4" 
    cols="50" 
    enter
    ng-maxlength="500"
></textarea>

<p ng-show="frmConsulta.observacao.$invalid && !frmConsulta.observacao.$pristine" 
class="help-block">Observação deve ter no máximo 500 caracteres</p>

</div>


<div class="modal-footer" style='background-color:#f5f5f5;'>
    <button class="btn btn-primary" 
    type="button" 
    ladda="$ctrl.processando" 
    ng-click="$ctrl.handleClose()" 
    ng-disabled="frmConsulta.$invalid">OK</button>
    
    
    <button class="btn btn-warning" type="button" ng-click="$ctrl.handleDismiss()">Cancelar</button>
</div>

</form>

</div>
`,
    bindings: {
        modalInstance: "<",
        salvar: "&",
        atendimentoModel : '<'
    },
    controller: function ($timeout) {
        var $ctrl = this;

        $ctrl.$onInit = function () {
           
            $ctrl.modalData = angular.copy($ctrl.atendimentoModel)

           
            $ctrl.modalData.dataInicial = angular.copy($ctrl.modalData.currentDate)
            $ctrl.modalData.dataFinal = angular.copy($ctrl.modalData.currentDate)
                
            $timeout(function () {
                window.document.getElementById("pacienteNome").focus()
            });
           
        }

      


        $ctrl.limparTela = function () {
            $ctrl.modalData.pacienteNome = ''
            $ctrl.modalData.pacienteDataNascimento = ''
            $ctrl.modalData.horaInicial = ''
            $ctrl.modalData.horaFinal = ''
            $ctrl.modalData.observacao = ''

          
        }


        $ctrl.handleClose = function () {

            $ctrl.processando = true

            $ctrl.salvar({
                    atendimentoVM: $ctrl.modalData

            }).then(function () {
                $ctrl.limparTela()

             
                
                $ctrl.modalInstance.close();

                $ctrl.processando = false

                

                }
                , function () {
                    $ctrl.processando = false
                }

            )

            

        };

        $ctrl.handleDismiss = function () {
            $ctrl.limparTela()

           

            $ctrl.modalInstance.dismiss("cancel");
        };
    }
};


mod.component('cadastrarAtendimento', cadastrarAtendimento);