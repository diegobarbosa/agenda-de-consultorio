using Itix.Agenda.Core.Domain.Pacientes;
using Itix.Agenda.Core.Infra.AppService;
using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.Agenda.UI.Features.API.Pacientes
{
    public class RetornarPaciente : QueryHandler<RetornarPaciente.Command>
    {
        IPacienteRepo pacienteRepo;

        public RetornarPaciente(IPacienteRepo pacienteRepo)
        {
            this.pacienteRepo = pacienteRepo;
        }

        public override void Build(Command form)
        {
            throw new NotImplementedException();
        }

        public override void Query(Command command)
        {
            Assegure.Que(command.IdPaciente > 0, "Informe o IdPaciente");

            command.PacienteResult = pacienteRepo.ById(command.IdPaciente);
        }

        public class Command : IQueryCommand
        {
            public int IdPaciente { get; set; }

            public Paciente PacienteResult { get; set; }
        }
    }
}
