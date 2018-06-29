using System;
using Xunit;
using Shouldly;
using Itix.Agenda.Core.Infra.Utils;
using Itix.Agenda.Core.Agenda;
using NSubstitute;
using Itix.Agenda.Core.Domain.Pacientes;

namespace Itix.Agenda.Tests
{
    public class AtendimentoFacts
    {
        protected IAtendimentoRepo atendimentoRepo;
        protected ITimeProvider timeProvider;
        protected PeriodoFechado horario;
        protected Paciente paciente;
        protected string observacao;

        protected DateTime hoje;

        public AtendimentoFacts()
        {
            // hoje é:
            hoje = DateTime.Parse("2018-05-01 07:00");
            timeProvider = Substitute.For<ITimeProvider>();
            timeProvider.Now.Returns(hoje);

            // e vou agenda um horário em:
            horario = new PeriodoFechado(DateTime.Parse("2018-06-01 09:00"), DateTime.Parse("2018-06-01 09:30"));

            atendimentoRepo = Substitute.For<IAtendimentoRepo>();

            //Por padrão o atendimento não conflita com nenhum outro
            Atendimento atendimentoExistente = null;
            atendimentoRepo.ExisteAtendimentoNoHorario(null).ReturnsForAnyArgs(atendimentoExistente);//NAO



            paciente = Substitute.For<Paciente>();

            observacao = "uma observação";

        }



    }
}
