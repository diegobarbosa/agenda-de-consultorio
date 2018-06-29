using System;
using System.Collections.Generic;
using System.Text;
using Itix.Agenda.Core.Domain.Pacientes;
using Itix.Agenda.Core.Infra.Utils;
using Shouldly;
using Xunit;

namespace Itix.Agenda.Tests.Domain.Pacientes
{
    public class PacienteFacts
    {
        string nome = "Robert C Martin";

        DateTime dataNascimento;

        public PacienteFacts()
        {
            dataNascimento = DateTime.Parse("2018-05-01");
        }

        public class Cria_com : PacienteFacts
        {

            [Theory,
                  InlineData(null),
                  InlineData("   ")
                  ]
            void nome_vazio_falha(string nome)
            {
                var ex = Should.Throw<DomainException>(() => new Paciente(nome, dataNascimento));

                ex.Message.ShouldBe("Informe o Nome");
            }

            [Fact]
            void nome_com_mais_de_100_caracteres_falha()
            {
                //ARRANGE
                nome = new string('p', 101);

                //ARRANGE
                var ex = Should.Throw<DomainException>(() => new Paciente(nome, dataNascimento));


                //ASSERT
                ex.Message.ShouldBe("Nome deve ter até 100 caracteres");
            }

            [Fact]
            void data_nascimento_invalida_falha()
            {
                //ARRANGE
                var ex = Should.Throw<DomainException>(() => new Paciente(nome, null));


                //ASSERT
                ex.Message.ShouldBe("Informe uma Data de Nascimento válida");
            }


            [Fact]
            void sucesso()
            {
                var paciente = new Paciente(nome, dataNascimento);

                paciente.Nome.ShouldBe(nome);

                paciente.DataNascimento.ShouldBe(dataNascimento);
            }

        }
    }
}
