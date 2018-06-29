using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Itix.Agenda.Core.Infra.AppService;
using Itix.Agenda.UI.Features.Agenda;
using Itix.Agenda.Core.Infra.UI;

namespace Itix.Agenda.Features.API.Atendimentos
{
    //[Produces("application/json")]
    //[Route("api/Agenda")]
    public class AtendimentosController : BaseController
    {
        AppMediator mediator;

        public AtendimentosController(AppMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("agenda")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("api/atendimentos")]
        public IActionResult SalvarNovoAtendimento([FromBody] MarcarAtendimento.Command command)
        {
            var result = mediator.Execute(command);

            if (result.Erro)
            {
                return JsonFail(result.Messages);
            }

            return Json(new { command.IdAtendimento });
        }

        [HttpPut]
        [Route("api/atendimentos/{idAtendimento}")]
        public IActionResult Editar(int idAtendimento, [FromBody]  AlterarAtendimento.Command command)
        {
            command.IdAtendimento = idAtendimento;


            var result = mediator.Execute(command);

            if (result.Erro)
            {
                return JsonFail(result.Messages);
            }

            return JsonSuccess();
        }


        [HttpPut]
        [Route("api/atendimentos/{idAtendimento}/compareceu")]
        public IActionResult compareceu(int idAtendimento)
        {
            var command = new CompareceuAtendimento.Command { IdAtendimento = idAtendimento };


            var result = mediator.Execute(command);

            if (result.Erro)
            {
                return JsonFail(result.Messages);
            }

            return JsonSuccess();
        }

        [HttpPut]
        [Route("api/atendimentos/{idAtendimento}/cancelar")]
        public IActionResult Cancelar(int idAtendimento)
        {
            var command = new CancelarAtendimento.Command { IdAtendimento = idAtendimento };


            var result = mediator.Execute(command);

            if (result.Erro)
            {
                return JsonFail(result.Messages);
            }

            return JsonSuccess();
        }

        [HttpGet]
        [Route("api/atendimentos/dia/{date}")]
        public IActionResult ListarAtendimentosDoDia(DateTime date)
        {
            var command = new RetornarAtendimentosDoDia.Command { Date = date };


            var result = mediator.Query(command);

            if (result.Erro)
            {
                return JsonFail(result.Messages);
            }

            return Json(command.Result);
        }


    }
}