using Itix.Agenda.Core.Agenda;
using Itix.Agenda.Core.Infra.AppService;
using Itix.Agenda.Core.Infra.UI;
using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.Agenda.UI.Features.Agenda
{
    public class CompareceuAtendimento : CommandHandler<CompareceuAtendimento.Command>
    {
        IAtendimentoRepo atendimentoRepo;

        ITimeProvider timeProvider;

        public CompareceuAtendimento(
            IAtendimentoRepo atendimentoRepo,
            ITimeProvider timeProvider
            )
        {
            this.atendimentoRepo = atendimentoRepo;

            this.timeProvider = timeProvider;
        }

        protected override void Executar(Command command)
        {
            Assegure.Que(command.IdAtendimento > 0, "Informe o IdAtendimento");

            var atendimento = atendimentoRepo.ById(command.IdAtendimento);

            atendimento.Compareceu();
        }

        public class Command : ICommand
        {
            public int IdAtendimento { get; set; }
        }
    }
}
