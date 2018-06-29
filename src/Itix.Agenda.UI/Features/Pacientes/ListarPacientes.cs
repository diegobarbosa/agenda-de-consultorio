using Itix.Agenda.Core.Domain.Pacientes;
using Itix.Agenda.Core.Infra.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.Agenda.UI.Features.API.Pacientes
{
    public class ListarPacientes : QueryHandler<ListarPacientes.Command>
    {
        IPacienteRepo pacienteRepo;

        public ListarPacientes(IPacienteRepo pacienteRepo)
        {
            this.pacienteRepo = pacienteRepo;
        }

        public override void Build(Command form)
        {
            throw new NotImplementedException();
        }

        public override void Query(Command command)
        {
            command.ListaPacientesResult = pacienteRepo.FindByNome(command.Nome);
        }

        public class Command : IQueryCommand
        {
            public string Nome { get; set; }

            public List<Paciente> ListaPacientesResult { get; set; }
        }
    }
}
