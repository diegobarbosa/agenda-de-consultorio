using Itix.Agenda.Core.Agenda;
using Itix.Agenda.Core.Domain.Pacientes;
using Itix.Agenda.Core.Infra.AppService;
using Itix.Agenda.Core.Infra.UI;
using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.Agenda.UI.Features.Agenda
{
    public class MarcarAtendimento : CommandHandler<MarcarAtendimento.Command>
    {
        IAtendimentoRepo atendimentoRepo;

        ITimeProvider timeProvider;

        public MarcarAtendimento(
            IAtendimentoRepo atendimentoRepo,
            ITimeProvider timeProvider
            )
        {
            this.atendimentoRepo = atendimentoRepo;

            this.timeProvider = timeProvider;
        }

        protected override void Executar(Command command)
        {
            Assegure.Que(command.Horario != null, "Informe o Horário");

            command.Horario.Validar();


            var atendimento = new Atendimento(
                atendimentoRepo,
                timeProvider,
                command.Horario.ToPeriodoFechado(),
                new Paciente(command.PacienteNome, command.PacienteDataNascimento.ToDateTimeOrNull()),
                command.Observacao);


            atendimentoRepo.Insert(atendimento);

            command.IdAtendimento = atendimento.IdAtendimento;
        }

        public class Command : ICommand
        {

            public PeriodoFechadoDTO Horario { get; set; }


            public string PacienteNome { get; set; }

            public string PacienteDataNascimento { get; set; }


            public string Observacao { get; set; }



            public int IdAtendimento { get; set; }
        }
    }
}
