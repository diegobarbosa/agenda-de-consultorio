using System;
using Itix.Agenda.Core.Infra.Utils;

namespace Itix.Agenda.UI.Features.Agenda
{
    internal class Periodo : PeriodoFechado
    {
        public Periodo(DateTime? dataInicial, DateTime? dataFinal) : base(dataInicial, dataFinal)
        {
        }
    }
}