using Itix.Agenda.Core.Agenda;
using Itix.Agenda.Core.Infra.AppService;
using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.Agenda.UI.Features.Agenda
{
    public class RetornarAtendimentosDoDia : QueryHandler<RetornarAtendimentosDoDia.Command>
    {
        IAgendamentosDoDiaQuery agendamentosDoDiaQuery;

        public RetornarAtendimentosDoDia(IAgendamentosDoDiaQuery agendamentosDoDiaQuery)
        {
            this.agendamentosDoDiaQuery = agendamentosDoDiaQuery;
        }

        public override void Build(Command form)
        {
            throw new NotImplementedException();
        }

        public override void Query(Command command)
        {
            Assegure.Que(command.Date != null, "Informe uma Data");


            command.Result = agendamentosDoDiaQuery.Executar(command.Date.Value);
        }

        public class Command : IQueryCommand
        {
            public DateTime? Date { get; set; }

            public List<AtendimentosDoDiaQuery.Item> Result { get; set; }
        }
    }
}
