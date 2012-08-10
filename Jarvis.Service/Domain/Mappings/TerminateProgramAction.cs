using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Jarvis.Service.Domain.Action;

namespace Jarvis.Service.Domain.Mappings
{
        public class TerminateProgramActionMap: SubclassMap<TerminateProgramAction>
        {
            public TerminateProgramActionMap()
            {
                Map(x => x.ProcessName).Not.Nullable();
            }
        }
    
}
