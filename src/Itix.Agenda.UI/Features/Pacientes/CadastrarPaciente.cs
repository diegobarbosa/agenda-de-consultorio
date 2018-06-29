using Itix.Agenda.Core.Domain.Pacientes;
using Itix.Agenda.Core.Infra.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.Agenda.UI.Features.API.Pacientes
{
    //public class CadastrarPaciente : CommandHandler<CadastrarPaciente.Command>
    //{
    //    IPacienteRepo pacienteRepo;

    //    public CadastrarPaciente(IPacienteRepo pacienteRepo)
    //    {
    //        this.pacienteRepo = pacienteRepo;
    //    }


    //    protected override void Executar(Command command)
    //    {
    //        var paciente = new Paciente(command.Nome, command.DataNascimento);

    //        pacienteRepo.Insert(paciente);

    //        command.IdPaciente = paciente.IdPaciente;
    //    }

    //    public class Command : ICommand
    //    {
    //        public int IdPaciente { get; set; }

    //        public string Nome { get; set; }

    //        public DateTime DataNascimento { get; set; }
    //    }
    //}
}
