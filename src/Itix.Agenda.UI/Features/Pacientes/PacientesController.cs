using Itix.Agenda.Core.Infra.AppService;
using Itix.Agenda.Core.Infra.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.Agenda.UI.Features.API.Pacientes
{
    public class PacientesController : BaseController
    {
        AppMediator mediator;

        public PacientesController(AppMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("api/pacientes")]
        public IActionResult Cadastrar(CadastrarPaciente.Command command)
        {
            var result = mediator.Execute(command);

            if (result.Erro)
            {
                return JsonFail(result.Messages);
            }

            return JsonSuccess(new { command.IdPaciente });
        }

        [HttpGet]
        [Route("api/pacientes/{idPaciente}")]
        public IActionResult ById(int idPaciente)
        {
            var command = new RetornarPaciente.Command { IdPaciente = idPaciente };

            var result = mediator.Query(command);

            if (result.Erro)
            {
                return JsonFail(result.Messages);
            }

            return JsonSuccess(command.PacienteResult);
        }

        [HttpGet]
        [Route("api/pacientes")]
        public IActionResult Listar(ListarPacientes.Command command)
        {
            var result = mediator.Query(command);

            if (result.Erro)
            {
                return JsonFail(result.Messages);
            }

            return JsonSuccess(command.ListaPacientesResult);
        }


    }
}
