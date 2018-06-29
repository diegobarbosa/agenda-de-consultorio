using Itix.Agenda.Core.Data;
using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Itix.Agenda.Core.Agenda
{
    public interface IAtendimentoRepo
    {
        List<Atendimento> ExisteColisaoComOHorario(PeriodoFechado periodo, int? idAtendimentoParaIgnorar = null);

        void Insert(Atendimento atendimento);

        Atendimento ById(int idAtendimento);
    }

    public class AtendimentoRepo : IAtendimentoRepo
    {
        IUnitOfWork uow;

        public AtendimentoRepo(IUnitOfWork uow) =>
                this.uow = uow;


        public Atendimento ById(int idAtendimento) =>
                uow.GetById<Atendimento>(idAtendimento);

        public List<Atendimento> ExisteColisaoComOHorario(PeriodoFechado horario, int? idAtendimentoParaIgnorar = null)
        {
            // Cenários de Referência em migrations/teste-de-colisao-de-datas.sql
            //Referência: http://salman-w.blogspot.com/2012/06/sql-query-overlapping-date-ranges.html

            var sql = @"

    select {atend.*}
        
    from atendimento atend
    
    where

        atend.status = :statusMarcado

and 
	
(
		   (atend.data_final > :novaDataInicial  and atend.data_final <= :novaDataFinal )   -- caso 1

		or (atend.data_inicial >= :novaDataInicial and atend.data_inicial < :novaDataFinal) -- caso 2
	
		or (atend.data_inicial = :novaDataInicial and atend.data_final = :novaDataFinal)    -- caso 3
	
		or (atend.data_inicial > :novaDataInicial and atend.data_final < :novaDataFinal)    -- caso 4 

		or (atend.data_inicial < :novaDataInicial and atend.data_final > :novaDataFinal)    -- caso 5
	
	)

";

            if (idAtendimentoParaIgnorar.HasValue)
            {
                sql += " and atend.id_atendimento != :idAtendimentoParaIgnorar";
            }


            var query = uow
            .Session
            .CreateSQLQuery(sql)
            .AddEntity("atend", typeof(Atendimento))
            .SetDateTime("novaDataInicial", horario.DataInicial)
            .SetDateTime("novaDataFinal", horario.DataFinal)
            .SetString("statusMarcado", TipoStatus.MARC.ToString());

            if (idAtendimentoParaIgnorar.HasValue)
            {
                query.SetInt32("idAtendimentoParaIgnorar", idAtendimentoParaIgnorar.Value);
            }


            return query.List<Atendimento>().ToList();

        }

        public void Insert(Atendimento atendimento) =>
            uow.Insert(atendimento);
    }
}
