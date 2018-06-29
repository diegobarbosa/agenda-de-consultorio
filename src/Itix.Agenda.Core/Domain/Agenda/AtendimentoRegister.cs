using Itix.Agenda.Core.Infra.IocContainer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core.Agenda
{
    public class AtendimentoRegister : IContainerRegister
    {
        public override void Register(SimpleInjector.Container container)
        {
            container.Register<IAgendamentosDoDiaQuery, AtendimentosDoDiaQuery>();

            container.Register<IAtendimentoRepo, AtendimentoRepo>();
        }
    }
}
