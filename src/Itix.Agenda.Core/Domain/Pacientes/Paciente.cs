using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core.Domain.Pacientes
{
    public class Paciente
    {

        public virtual string Nome { get; protected set; }

        public virtual DateTime DataNascimento { get; protected set; }

        protected Paciente()
        {

        }

        public Paciente(string nome, DateTime? dataNascimento)
        {
            nome = nome?.Trim();

            Assegure.Que(nome.PossuiValor(), () => $"Informe o Nome");

            Assegure.Que(nome.Length <= 100, () => "Nome deve ter até 100 caracteres");

            Assegure.Que(dataNascimento != null, "Informe uma Data de Nascimento válida");

            Assegure.Que(dataNascimento >= DateTimeExtension.MenorDataPossivel, 
                $"Informe uma data maior ou igual a {dataNascimento.ToDateBr()}");

            Nome = nome;

            DataNascimento = dataNascimento.Value;
        }

    }
}
