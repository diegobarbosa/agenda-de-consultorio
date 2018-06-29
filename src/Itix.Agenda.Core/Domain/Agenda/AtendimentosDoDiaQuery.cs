using Itix.Agenda.Core.Data;
using Itix.Agenda.Core.Infra.Utils;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Agenda.Core.Agenda
{
    public interface IAgendamentosDoDiaQuery
    {
        List<AtendimentosDoDiaQuery.Item> Executar(DateTime date);
    }

    public class AtendimentosDoDiaQuery : IAgendamentosDoDiaQuery
    {
        IUnitOfWork uow;

        public AtendimentosDoDiaQuery(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public List<Item> Executar(DateTime date)
        {
            var sql = @"

                        select 

                        IdAtendimento = atendimento.id_atendimento,
                        DataInicial = atendimento.data_inicial,
                        DataFinal =  atendimento.data_final,
                        Status = atendimento.status,
                        Observacao = atendimento.observacao,

                        
                        PacienteNome = atendimento.paciente_nome,
                        PacienteDataNascimento = atendimento.paciente_data_nascimento
           
 
                        from atendimento

                        where  
                    
                        cast(:date as date) between cast(data_inicial as date) and cast(data_final as date)
                        
                        order by atendimento.data_inicial
                        ";


            var query = uow.Session
                   .CreateSQLQuery(sql)
                   .SetDateTime("date", date)
                   .SetResultTransformer(Transformers.AliasToBean(typeof(Item)));

            return query
                   .List<Item>()
                   .ToList();

        }

        public class Item
        {
            public int IdAtendimento { get; set; }

            public DateTime DataInicial { get; set; }

            public DateTime DataFinal { get; set; }


            public int IdPaciente { get; set; }

            public string PacienteNome { get; set; }

            public DateTime PacienteDataNascimento { get; set; }

            public string Status { get; set; }

            public string Observacao { get; set; }
        }
    }
}
