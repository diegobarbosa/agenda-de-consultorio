using Itix.Agenda.Core.Agenda;
using Itix.Agenda.Core.Infra.Utils;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Itix.Agenda.Tests.Agenda.AtendimentoFactsNS
{
    public class CancelarAtendimentoFacts : AtendimentoFacts
    {
        DateTime dataCancelamento;

        public CancelarAtendimentoFacts()
        {
            dataCancelamento = DateTime.Parse("2018-06-20 00:00");
        }


        [Fact]
        void Ja_esta_cancelado_falha()
        {
            //ARRANGE
            var atendimento = new Atendimento(atendimentoRepo, timeProvider, horario, paciente, observacao);


            timeProvider.Now.Returns(dataCancelamento);

            atendimento.Cancelar(timeProvider);//Está cancelado

            //ACT
            var ex = Should.Throw<DomainException>(() => atendimento.Cancelar(timeProvider));


            //ASSERT
            ex.Message.ShouldBe("Não é possível Cancelar no Status CANC");
        }



        [Fact]
        void Tem_sucesso()
        {
            //ARRANGE
            var atendimento = new Atendimento(atendimentoRepo, timeProvider, horario, paciente, observacao);

            timeProvider.Now.Returns(dataCancelamento);


            //ACT
            atendimento.Cancelar(timeProvider);//Está cancelado


            //ASSERT
            atendimento.Status.ShouldBe(TipoStatus.CANC);

            atendimento.DataCancelamento.ShouldBe(dataCancelamento);

        }

    }
}
