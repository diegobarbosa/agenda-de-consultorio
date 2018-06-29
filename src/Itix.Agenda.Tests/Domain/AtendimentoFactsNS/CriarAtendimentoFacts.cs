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
    public class CriarAtendimentoFacts : AtendimentoFacts
    {
        public class Falha_quando : CriarAtendimentoFacts
        {

            [Fact]
            void atendimentoRepo_null()
            {
                var ex = Should.Throw<DomainException>(() => new Atendimento(null, timeProvider, horario, paciente, observacao));

                ex.Message.ShouldBe("atendimentoRepo é null");
            }

            [Fact]
            void timeProvider_null()
            {
                var ex = Should.Throw<DomainException>(() => new Atendimento(atendimentoRepo, null, horario, paciente, observacao));

                ex.Message.ShouldBe("timeProvider é null");
            }

            [Fact]
            void horario_null()
            {
                var ex = Should.Throw<DomainException>(() => new Atendimento(atendimentoRepo, timeProvider, null, paciente, observacao));

                ex.Message.ShouldBe("horario é null");
            }

            [Fact]
            void horario_eh_no_passado()
            {
                //Arrange
                //hoje = DateTime.Parse("01/05/2018 07:00");
                horario = new PeriodoFechado(DateTime.Parse("2018-05-01 06:59"), DateTime.Parse("2018-05-01 07:30"));

                //ACT
                var ex = Should.Throw<DomainException>(() => new Atendimento(atendimentoRepo, timeProvider, horario, paciente, observacao));


                //ASSERT
                ex.Message.ShouldBe("Informe um Horário com data maior ou igual a de agora");
            }



            [Fact]
            void paciente_nao_informado()
            {
                var ex = Should.Throw<DomainException>(() => new Atendimento(atendimentoRepo, timeProvider, horario, null, observacao));

                ex.Message.ShouldBe("Informe o Paciente");
            }



            [Fact]
            void observacao_mais_de_500_caracteres()
            {
                //ARRANGE
                observacao = new string('p', 501);

                //ACT
                var ex = Should.Throw<DomainException>(() => new Atendimento(atendimentoRepo, timeProvider, horario, paciente, observacao));

                //ASSERT
                ex.Message.ShouldBe("Observação deve ter no máximo 500 caracteres");
            }


            [Fact]
            void periodo_informado_esta_indisponivel()
            {
                //ARRANGE
                var atendimento = Substitute.For<Atendimento>();
                atendimentoRepo.ExisteAtendimentoNoHorario(horario).Returns(atendimento);//SIM

                //ACT
                var ex = Should.Throw<DomainException>(() => new Atendimento(atendimentoRepo, timeProvider, horario, paciente, observacao));


                //ASSERT
                ex.Message.ShouldBe("Já existe um Atendimento marcado para o Horário informado");
            }


        }


        [Fact]
        void tem_sucesso()
        {
            //ARRANGE
            var atendimento = new Atendimento(atendimentoRepo, timeProvider, horario, paciente, observacao);



            //ASSERT
            atendimento.Horario.ShouldBe(horario);

            atendimento.Paciente.ShouldBe(paciente);

            atendimento.Observacao.ShouldBe(observacao);

            atendimento.Status.ShouldBe(TipoStatus.MARC);

            atendimento.DataCadastro.ShouldBe(hoje);
                        
        }

    }
}
