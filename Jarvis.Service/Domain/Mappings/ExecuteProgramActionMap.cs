using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Jarvis.Service.Domain.Action;


namespace Jarvis.Service.Domain.Mappings
{
    public class ExecuteProgramActionMap :SubclassMap<ExecuteProgramAction>
    {
        public ExecuteProgramActionMap()
        {
            //Abstract();
            Map(x => x.CommandString).Not.Nullable();
            Map(x => x.ExecuteInDirectory);
        }
    }
}
