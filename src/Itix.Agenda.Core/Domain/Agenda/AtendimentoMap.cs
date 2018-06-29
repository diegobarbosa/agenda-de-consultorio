using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core.Agenda
{
    public class AtendimentoMap : ClassMap<Atendimento>
    {
        public AtendimentoMap()
        {
            Table("atendimento");

            Id(x => x.IdAtendimento, "id_atendimento")
                .GeneratedBy
                .Identity();


            Component(x => x.Paciente, y =>
            {
                y.Map(z => z.Nome, "paciente_nome");
                y.Map(z => z.DataNascimento, "paciente_data_nascimento");
            });


            Map(x => x.Observacao, "observacao");

            Component(x => x.Horario, y =>
            {
                y.Map(z => z.DataInicial, "data_inicial");
                y.Map(z => z.DataFinal, "data_final");
            }
            );


            Map(x => x.Status, "status");

            Map(x => x.DataCadastro, "data_cadastro");

            Map(x => x.DataCancelamento, "data_cancelamento");


        }
    }
}
