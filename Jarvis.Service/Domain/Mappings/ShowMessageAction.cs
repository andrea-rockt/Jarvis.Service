using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;


namespace Jarvis.Service.Domain.Mappings
{
    public class ShowMessageAction : SubclassMap<Action.ShowMessageAction>
    {
        public ShowMessageAction()
        {
            Map(x => x.Message).Not.Nullable();
        }
    }
}
