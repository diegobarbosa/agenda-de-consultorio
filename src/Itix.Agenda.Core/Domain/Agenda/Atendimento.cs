using Itix.Agenda.Core.Domain.Pacientes;
using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core.Agenda
{
    public class Atendimento
    {
        public virtual int IdAtendimento { get; protected set; }

        public virtual Paciente Paciente { get; protected set; }

        public virtual string Observacao { get; protected set; }

        public virtual PeriodoFechado Horario { get; protected set; }


        public virtual TipoStatus Status { get; protected set; }

        public virtual DateTime DataCadastro { get; protected set; }

        public virtual DateTime? DataCancelamento { get; protected set; }


        protected Atendimento()
        {

        }

        public Atendimento(
            IAtendimentoRepo atendimentoRepo,
            ITimeProvider timeProvider,
            PeriodoFechado horario,
            Paciente paciente,
            string observacao
            )
        {
            observacao = observacao?.Trim();

            Assegure.Que(atendimentoRepo != null, () => $"{nameof(atendimentoRepo)} é null");

            Assegure.Que(timeProvider != null, () => $"{nameof(timeProvider)} é null");

            Assegure.Que(horario != null, () => $"{nameof(horario)} é null");

            Assegure.Que(paciente != null, "Informe o Paciente");

            Assegure.Que((observacao?.Length ?? 0) <= 500, () => "Observação deve ter no máximo 500 caracteres");


            Assegure.Que(horario.DataInicial >= timeProvider.Now, () => "Informe um Horário com data maior ou igual a de agora");


            var atendimento = atendimentoRepo.ExisteAtendimentoNoHorario(horario);

            Assegure.Que(atendimento == null, () => $"Já existe um Atendimento marcado para o Horário informado");


            Horario = horario;

            Paciente = paciente;

            Observacao = observacao;



            Status = TipoStatus.MARC;

            DataCadastro = timeProvider.Now;
        }



        public virtual void Cancelar(ITimeProvider timeProvider)
        {
            Assegure.Que(Status == TipoStatus.MARC, $"Não é possível Cancelar no Status {Status}");

            Status = TipoStatus.CANC;

            DataCancelamento = timeProvider.Now;
        }

        public virtual void Alterar(
            IAtendimentoRepo atendimentoRepo,
             ITimeProvider timeProvider,
             PeriodoFechado horario,
             Paciente paciente,
             string observacao
            )
        {
            observacao = observacao?.Trim();

            Assegure.Que(Status == TipoStatus.MARC, "Só é possível Editar os dados no Status MARC");

            Assegure.Que(atendimentoRepo != null, () => $"{nameof(atendimentoRepo)} é null");

            Assegure.Que(timeProvider != null, () => $"{nameof(timeProvider)} é null");

            Assegure.Que(horario != null, () => $"{nameof(horario)} é null");

            Assegure.Que(paciente != null, "Informe o Paciente");

            Assegure.Que((observacao?.Length ?? 0) <= 500, () => "Observação deve ter no máximo 500 caracteres");


            Assegure.Que(horario.DataInicial >= timeProvider.Now, () => "Informe um Horário com data maior ou igual a de agora");



            var atendimento = atendimentoRepo.ExisteAtendimentoNoHorario(horario, this.IdAtendimento);

            Assegure.Que(atendimento == null, () => $"Já existe um Atendimento marcado para o Horário informado");


            Paciente = paciente;

            Observacao = observacao;

            Horario = horario;
        }


        public virtual void Compareceu()
        {
            Assegure.Que(Status == TipoStatus.MARC, $"Não é possível estar como Compareceu no Status {Status}");

            Status = TipoStatus.COMP;
        }


    }
    public enum TipoStatus
    {
        MARC,
        CANC,
        COMP
    }
}
