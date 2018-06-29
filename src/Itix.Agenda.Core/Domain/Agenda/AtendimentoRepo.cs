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
        Atendimento ExisteAtendimentoNoHorario(PeriodoFechado periodo, int? idAtendimentoParaIgnorar = null);

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

        public Atendimento ExisteAtendimentoNoHorario(PeriodoFechado horario, int? idAtendimentoParaIgnorar = null)
        {
         // Cenários de Referência:
         // Dessa forma é possível term um horário 14:00 às 15:00 e de 15:00 às 16:00
         //
         //   declare @dataInicial datetime = '2018-06-29 15:00'
         //   declare @dataFinal datetime = '2018-06-29 16:00'

         //   select * 
         //   from atendimento

         //   where (atendimento.data_final > @dataInicial  and atendimento.data_final <= @dataFinal )
	     //   or (atendimento.data_inicial >= @dataInicial and atendimento.data_inicial <= @dataFinal)
                
         //   --Nova Data----------------15:00---------------16:00-------------
         //   --B-------------14:00---------------15:30----------------------------
         //   --C-----------------------------------15:30----16:00-----
         //   --B-------------14:00------15:00----------------------------



            var query = (from atend in uow.QueryByLinq<Atendimento>()
                         where ((atend.Horario.DataFinal > horario.DataInicial && atend.Horario.DataFinal <= horario.DataFinal)
                             || (atend.Horario.DataInicial >= horario.DataInicial && atend.Horario.DataInicial <= horario.DataFinal)
                            )
                            && atend.Status == TipoStatus.MARC
                         select atend
                            );

            if (idAtendimentoParaIgnorar.HasValue)
            {
                query = query.Where(x => x.IdAtendimento != idAtendimentoParaIgnorar);
            }

            return query.SingleOrDefault();

        }

        public void Insert(Atendimento atendimento) =>
            uow.Insert(atendimento);
    }
}
