using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Jarvis.Service.Domain.Mappings
{
    public class ActionMap:ClassMap<Action.Action>
    {
        public ActionMap() 
        {
            //UseUnionSubclassForInheritanceMapping();
            Id(x => x.Id).GeneratedBy.GuidComb();
        }
    }
}
