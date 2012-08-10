using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Action
{
    public abstract class Action : Entity<Guid>
    {
        public abstract void Execute();
    }
}
